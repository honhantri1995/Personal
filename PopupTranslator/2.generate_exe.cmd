@echo off

set vir_env_path=virtual_env
set proj_dir=PopupTranslator

:: Copy proj_dir (including source code + libs + configurations) to the vir_env_path
echo -----------------------------------------------------------------------------
echo COPYING SOURCE CODE + LIBS + CONFIGURATIONS TO THE VIRTUAL ENVIRONMENT ...
xcopy /e /y src\ %vir_env_path%\%proj_dir%\src\ /exclude:%CD%\exclude_copy_list.txt
xcopy /e /y dll\ %vir_env_path%\%proj_dir%\dll\
xcopy /e /y conf\ %vir_env_path%\%proj_dir%\conf\
echo DONE

:: Notify users which resource paths have to be changed
echo.
echo ------------------------------------------------------------------------------------------------
echo NEED TO CHANGE PATHS OF FOLLOWING RESOURCES DEFINED IN "constants.py". FROM ... TO ...:
echo     "ICON_PATH = '../conf/tray.ico'         -->    ICON_PATH = './conf/tray.ico'"
echo     "CONFIG_PATH = '../conf/conf.ini'       -->    CONFIG_PATH = './conf/conf.ini'"
echo     "LOG_PATH = '../log/log.txt'            -->    LOG_PATH = './log/log.txt'"
echo     "HISTORY_PATH = '../log/history.txt'    -->    HISTORY_PATH = './log/history.txt'"
start /B /wait notepad %vir_env_path%\%proj_dir%\src\constants.py

:: Notify users whether select the correct version of pystray
echo.
echo ONE MORE THING, WE HAVE A SMALL ISSUE WITH PACKAGE pystray WHEN WORKING WITH PyInstaller.
echo SO PLEASE READ THIS NOTE AND FOLLOW IT TO FIX THE ISSUE:
start /B /wait notepad fix_pystray_error.txt

choice /C yn /m "DID YOU DO THAT?"
set /a err_level=%ERRORLEVEL%

if %err_level% EQU 1 (
    :: Activate virtualenv
    echo.
    echo ------------------------------------
    echo ACTIVATING VIRTUALENV ...
    cd %vir_env_path%
    call Scripts\activate.bat
    echo DONE

    :: Create exe file
    echo.
    echo ------------------------------------
    echo RUNNING PYSTALLER ...
    cd %proj_dir%
    pyinstaller --onefile --noconsole  --icon=./conf/tray.ico  --add-data ./dll;.  --log-level=DEBUG  --exclude-module pyinstaller  --exclude-module pip  src/main.py
    
    :: Copy folder "conf" to folder "dist"
    :: This step is required for the exe to run
    echo.
    echo ------------------------------------
    echo COPYING CONF FILES ...
    xcopy /e /y conf dist\conf\
    echo DONE

    echo.
    echo ---------------------------------------------------------------------
    echo THE EXE FILE IS SUCCESSFULLY GENERATED. CHECK IT IN FOLDER "PopupTranslator\virtual_env\PopupTranslator\dist"
)

if %err_level% EQU 2 (
    echo PLEASE CHANGE RESOURCE PATHS FIRST. OTHERWISE, CANNOT RUN THE GENERATED EXE FILE!
)

pause