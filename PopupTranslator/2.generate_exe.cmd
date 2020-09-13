@echo off

set cur_path=%CD%
set vir_env_folder=VirtualEnv
set vir_env_path=%cur_path%\%vir_env_folder%
set proj_path=%cur_path%\PopupTranslator

:: Notify users which resource paths have to be changed
echo.
echo ------------------------------------------------------------------------------------------------
echo NEED TO CHANGE PATHS OF PROJECT DIRECTORY DEFINED IN "constants.py". FROM ... TO ...:
echo     "PROJECT_DIR = '..\\'         -->    PROJECT_DIR = '.\\'"
start /B /wait notepad %proj_path%\src\constants.py

:: Notify users whether select the correct version of pystray
echo.
echo ONE MORE THING, WE HAVE A SMALL ISSUE WITH PACKAGE pystray WHEN WORKING WITH PyInstaller.
echo SO PLEASE READ THIS NOTE AND FOLLOW IT TO FIX THE ISSUE:
start /B /wait notepad %cur_path%\fix_pystray_error.txt

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
    cd %proj_path%
    pyinstaller --onefile --noconsole  --icon=./conf/tray.ico  --add-data ./dll;.  --exclude-module pyinstaller  --exclude-module pip  src/main.py
    
    :: Copy folder "conf" to folder "dist". This step is required for the exe to run
    echo.
    echo ------------------------------------
    echo COPYING CONF FILES ...
    xcopy /e /y conf dist\conf\
    echo DONE

    echo.
    echo ---------------------------------------------------------------------
    echo THE EXE FILE IS SUCCESSFULLY GENERATED. CHECK IT IN FOLDER "%proj_path%\dist"

    :: Notify users to revert resource paths back to normal
    echo.
    echo ----------------------------------------------------------------------------------------------------------------------
    echo YOU'RE DONE. LET'S REVERT THE PATHS OF PROJECT DIRECTORY DEFINED IN "constants.py" BACK TO NORMAL. FROM ... TO ...:
    echo     "PROJECT_DIR = '.\\'         -->    PROJECT_DIR = '..\\'"
    start /B /wait notepad %proj_path%\src\constants.py
    
    echo.
    echo EVERYTHING IS DONE!
)

if %err_level% EQU 2 (
    echo PLEASE CHANGE RESOURCE PATHS FIRST. OTHERWISE, CANNOT RUN THE GENERATED EXE FILE!
)

pause