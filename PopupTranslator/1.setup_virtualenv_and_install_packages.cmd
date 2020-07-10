@echo off

set cur_path=%CD%
set vir_env_folder=VirtualEnv
mkdir %cur_path%\%vir_env_folder%
set vir_env_path=%cur_path%\%vir_env_folder%

:: Install virtualenv
echo ------------------------------------
echo INSTALLING VIRTUALENV ...
pip install virtualenv
echo DONE

:: Activate virtualenv
echo.
echo ------------------------------------
echo ACTIVATING VIRTUALENV ...
virtualenv %vir_env_path% --python=python3.7
call %vir_env_path%\Scripts\activate.bat
echo Your virutal environment is stored in folder %vir_env_path%
echo DONE

:: Update pip
echo.
echo ------------------------------------
echo UPDATING PIP ...
Scripts\python.exe -m pip install --upgrade pip
echo DONE

:: Install packages
echo.
echo ------------------------------------
echo INSTALLING PACKAGES ...
echo.
pip install keyboard
echo.
pip install pystray
echo.
pip install translate
echo.
pip install pyperclip
echo.
pip install pythonnet
echo.
pip install pyinstaller
echo DONE

echo.
echo ----------------------------------------------
echo CHECKING ALL PACKAGES JUST BEING INSTALLED
echo.
echo CHECK PACKAGE "keyboard" ...
pip show keyboard
echo.
echo CHECK PACKAGE "pystray" ...
pip show pystray
echo.
echo CHECK PACKAGE "translate" ...
pip show translate
echo.
echo CHECK PACKAGE "pyperclip" ...
pip show pyperclip
echo.
echo CHECK PACKAGE "pythonnet" ...
pip show pythonnet
echo.
echo CHECK PACKAGE "keyboard" ...
pip show pyinstaller

echo.
echo EVERYTHING IS DONE!

pause