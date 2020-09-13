@echo off

set vir_env_path=%CD%

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
pip install configobj
echo.
pip install google-cloud-speech
echo.
pip install google-cloud-storage
echo.
pip install pydub
echo.
pip install pyinstaller
echo DONE

echo.
echo ----------------------------------------------
echo CHECKING ALL PACKAGES JUST BEING INSTALLED
echo.
echo CHECK PACKAGE "configobj" ...
pip show configobj
echo.
echo CHECK PACKAGE "google-cloud-speech" ...
pip show google-cloud-speech
echo.
echo CHECK PACKAGE "google-cloud-storage" ...
pip show google-cloud-storage
echo.
echo CHECK PACKAGE "pydub" ...
pip show pydub
echo.
echo CHECK PACKAGE "pyinstaller" ...
pip show pyinstaller

echo.
echo EVERYTHING IS DONE!

pause