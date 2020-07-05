@echo off

set vir_env_path=%CD%
set proj_dir=%vir_env_path%\PopupTranslator

:: Notify users which resource paths have to be changed
echo.
echo ------------------------------------------------------------------------------------------------
echo NEED TO CHANGE PATHS OF FOLLOWING RESOURCES DEFINED IN "constants.py". FROM ... TO ...:
echo     "ICON_PATH = '../conf/tray.ico'         -->    ICON_PATH = './conf/tray.ico'"
echo     "CONFIG_PATH = '../conf/conf.ini'       -->    CONFIG_PATH = './conf/conf.ini'"
echo     "LOG_PATH = '../log/log.txt'            -->    LOG_PATH = './log/log.txt'"
echo     "HISTORY_PATH = '../log/history.txt'    -->    HISTORY_PATH = './log/history.txt'"
start /B /wait notepad %proj_dir%\src\constants.py

:: Notify users whether select the correct version of pystray
echo.
echo ONE MORE THING, WE HAVE A SMALL ISSUE WITH PACKAGE pystray WHEN WORKING WITH PyInstaller.
echo SO PLEASE READ THIS NOTE AND FOLLOW IT TO FIX THE ISSUE:
start /B /wait notepad %vir_env_path%\fix_pystray_error.txt

choice /C yn /m "DID YOU DO THAT?"
set /a err_level=%ERRORLEVEL%

if %err_level% EQU 1 (
    :: Activate virtualenv
    echo.
    echo ------------------------------------
    echo ACTIVATING VIRTUALENV ...
    call %vir_env_path%\Scripts\activate.bat
    echo DONE

    :: Create exe file
    echo.
    echo ------------------------------------
    echo RUNNING PYSTALLER ...
    cd %proj_dir%
    pyinstaller --onefile --noconsole  --icon=./conf/tray.ico  --add-data ./dll;.  --exclude-module pyinstaller  --exclude-module pip  src/main.py
    
    :: Copy folder "conf" to folder "dist". This step is required for the exe to run
    echo.
    echo ------------------------------------
    echo COPYING CONF FILES ...
    xcopy /e /y conf dist\conf\
    echo DONE

    echo.
    echo ---------------------------------------------------------------------
    echo THE EXE FILE IS SUCCESSFULLY GENERATED. CHECK IT IN FOLDER "%proj_dir%\dist"

    :: Notify users to revert resource paths back to normal
    echo.
    echo ----------------------------------------------------------------------------------------------------------------------
    echo YOU'RE DONE. LET'S REVERT THE PATHS OF FOLLOWING RESOURCES DEFINED IN "constants.py" BACK TO NORMAL. FROM ... TO ...:
    echo     "ICON_PATH = './conf/tray.ico'         -->    ICON_PATH = '../conf/tray.ico'"
    echo     "CONFIG_PATH = './conf/conf.ini'       -->    CONFIG_PATH = '../conf/conf.ini'"
    echo     "LOG_PATH = './log/log.txt'            -->    LOG_PATH = '../log/log.txt'"
    echo     "HISTORY_PATH = './log/history.txt'    -->    HISTORY_PATH = '../log/history.txt'"
    start /B /wait notepad %proj_dir%\src\constants.py
    
    echo.
    echo EVERYTHING IS DONE!
)

if %err_level% EQU 2 (
    echo PLEASE CHANGE RESOURCE PATHS FIRST. OTHERWISE, CANNOT RUN THE GENERATED EXE FILE!
)

pause