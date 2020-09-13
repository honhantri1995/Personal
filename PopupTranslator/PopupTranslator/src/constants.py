from enum import Enum

PROJECT_DIR = '..\\'

ICON_PATH = PROJECT_DIR + 'conf\\tray.ico'
CONFIG_PATH = PROJECT_DIR + 'conf\\conf.ini'
DLL_PATH = PROJECT_DIR + 'dll'
LOG_PATH = PROJECT_DIR + 'log\\log.txt'
HISTORY_PATH = PROJECT_DIR + 'log\\history.txt'

class ExceptionEnum(Enum):
    CANNOT_GET_TEXT = 0
    CANNOT_TRANSLATE = 1

class ConfigConst():
    POPUP_MODE = 0
    TRANSLATEANDREPLACE_MODE = 1

    HOTKEY_0 = 0
    HOTKEY_1 = 1

    THREAD_ID_TRAY = 0
    THREAD_ID_MAINUICONTROLLER = 1