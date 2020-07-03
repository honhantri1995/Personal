@echo off

set vir_env_path=virtual_env
set proj_dir=PopupTranslator

:: Copy proj_dir (including source code + libs + configurations) to the vir_env_path
echo --------------------------------------------------------------------------
echo COPY SOURCE CODE + LIBS + CONFIGURATIONS TO THE VIRTUAL ENVIRONMENT ...
cd %vir_env_path%
mkdir %proj_dir%
xcopy /e /y ..\src\ %proj_dir%\src\ /exclude:%CD%\..\exclude_copy_list.txt
xcopy /e /y ..\dll\ %proj_dir%\dll\
xcopy /e /y ..\conf\ %proj_dir%\conf\
echo DONE

:: Notify users which resource paths have to be changed
echo.
echo ------------------------------------------------------------------------------------------------
echo YOU NEED TO CHANGE PATHS OF FOLLOWING RESOURCES DEFINED IN "constants.py". FROM ... TO ...:
echo     "ICON_PATH = '../conf/tray.ico'         -->    ICON_PATH = './conf/tray.ico'"
echo     "CONFIG_PATH = '../conf/conf.ini'       -->    CONFIG_PATH = './conf/conf.ini'"
echo     "LOG_PATH = '../log/log.txt'            -->    LOG_PATH = './log/log.txt'"
echo     "HISTORY_PATH = '../log/history.txt'    -->    HISTORY_PATH = './log/history.txt'"

choice /C yn /m "DID YOU DO THAT?"
set /a err_level=%ERRORLEVEL%

if %err_level% EQU 1 (
    :: Activate virtualenv
    echo.
    echo ------------------------------------
    echo ACTIVATE VIRTUALENV ...
    REM call Scripts\activate.bat
    echo DONE

    :: Create exe file
    echo.
    echo ------------------------------------
    echo RUN PYSTALLER ...
    cd %proj_dir%
    pyinstaller --onefile --noconsole  --icon=./conf/tray.ico  --add-data ./dll;.  --log-level=DEBUG  --exclude-module pyinstaller  --exclude-module pip  src/main.py
    
    :: Copy folder "conf" to folder "dist"
    :: This step is required for the exe to run
    echo.
    echo ------------------------------------
    echo COPY CONF FILES ...
    xcopy /e /y conf dist\conf\
    echo DONE

    echo.
    echo ---------------------------------------------------------------------
    echo THE EXE FILE IS SUCCESSFULLY GENERATED. CHECK IT IN FOLDER "dist"
)

if %err_level% EQU 2 (
    echo PLEASE CHANGE RESOURCE PATHS FIRST. OTHERWISE, CANNOT RUN THE GENERATED EXE FILE!
)

pause