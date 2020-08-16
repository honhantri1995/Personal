@echo off

set vir_env_path=%CD%
set proj_dir=%vir_env_path%\TranscriptAutoMaker

:: Notify users which resource paths have to be changed
echo.
echo ------------------------------------------------------------------------------------------------
echo NEED TO CHANGE PROJECT PATH DEFINED IN "constants.py". FROM ... TO ...:
echo   "PROJECT_DIR = '..\\''    -->    PROJECT_DIR = '.\\'"
start /B /wait notepad %proj_dir%\src\constants.py

choice /C yn /m "DID YOU DO THAT?"
set /a err_level=%ERRORLEVEL%

if %err_level% EQU 1 (
    :: Activate virtualenv
    echo.
    echo ------------------------------------
    echo ACTIVATING VIRTUALENV ...
    call %vir_env_path%\Scripts\activate.bat
    echo DONE
    
    :: Update setuptools to fix error "no module named pkg_resources.py2_warn" at the time of testing (8/2020)
    echo.
    echo ------------------------------------
    echo UPDATING setuptools ...
    pip install --upgrade setuptools
    echo DONE
    
    :: Create exe file
    echo.
    echo ------------------------------------
    echo RUNNING PYSTALLER ...
    cd %proj_dir%
    pyinstaller --onefile --noconsole --clean --icon=./conf/icon.ico  --additional-hooks-dir D:\CODE\GIT\Personal\TranscriptAutoMaker\Lib\site-packages\PyInstaller\hooks  --exclude-module pip  src/main.py
    
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
    echo YOU'RE DONE. LET'S REVERT THE PROJECT PATH DEFINED IN "constants.py" BACK TO NORMAL. FROM ... TO ...:
    echo   "PROJECT_DIR = '.\\''    -->    PROJECT_DIR = '..\\'"

    start /B /wait notepad %proj_dir%\src\constants.py
    
    echo.
    echo EVERYTHING IS DONE! LET'S OPEN THE EXE FILE
    
    explorer %proj_dir%\dist
)

if %err_level% EQU 2 (
    echo PLEASE CHANGE RESOURCE PATHS FIRST. OTHERWISE, CANNOT RUN THE GENERATED EXE FILE!
)

pause