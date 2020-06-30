import time
import keyboard
import pyperclip

from textgetter import TextGetter
from translator import Translator
from uicontroller import MainUIController
from tray import TrayThread
from popup import Popup
from messagebox import MessageBox
from conf import Conf
from constants import ConfigConst

def main():
    # 1. Start main UI controller in main thread
    _start_mainuicontroller()

    # 2. Start system tray in a parallel worker thread
    _start_systray_thread()

    # 3. Back to main thread, repeatedly check if the hotkey is pressed. If so, do translation. Otherwise, wait for the hotkey to be pressed
    _start_main_loop()

def _start_mainuicontroller():
    mainuicontroller = MainUIController()
    mainuicontroller.show()

def _start_systray_thread():
    traythread = TrayThread(ConfigConst.THREAD_ID_TRAY, 'TrayThread')
    traythread.start()  # Starts traythread by calling the run() method.
    time.sleep(0.2)     # Need a small delay for the thread to actually start

def _start_main_loop():
    config = Conf()
    while True:
        # Need a small delay to prevent high CPU and power usagage
        time.sleep(0.1)

        _start_translate(config)

def _start_translate(config):
    # Read hotkey string from ini file and convert it to the format that 'keyboard' module can understand
    hotkey = config.get_hotkey().replace(' ', '').lower()

    if keyboard.is_pressed(hotkey):
        # Only continue the script when the hotkey is released
        while keyboard.is_pressed(hotkey):
            continue
        time.sleep(0.1)     # We need a small delay for the get_text() to work correctly [reason: loop and processor core]

        try:
            # Get text
            text = TextGetter()
            org_text = text.get_text()

            # Translate text
            trans = Translator()
            translated_text = trans.translate(org_text)

            # Write to history file
            trans.write_to_history(org_text, translated_text)

            # Display translated text on pop-up window, or replace original text by translated text
            if config.get_translation_mode() == ConfigConst.POPUP_MODE:
                pu = Popup(org_text, translated_text, text.is_uicontrol_label())
                pu.show()
            elif config.get_translation_mode() == ConfigConst.TRANSLATEANDREPLACE_MODE:
                _replace(translated_text)

        except Exception as e:
            ms = MessageBox()
            ms.show_error(e)

def _replace(translated_text):
    pyperclip.copy(translated_text)
    keyboard.send('ctrl+v')


if __name__ == '__main__':
    main()