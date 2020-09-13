from threading import Thread
from pystray import Icon, Menu, MenuItem
from PIL import Image
import os

from conf import Conf
from uicontroller import MainUIControllerThread
from constants import ConfigConst, ICON_PATH

class TrayThread(Thread):
    def __init__(self, threadID, name):
        Thread.__init__(self)
        self.threadID = threadID
        self.name = name

    def run(self):
        ''' Override the run() method of threading.Thread
        '''
        systray = Tray()
        systray.run()


class Tray:
    def __init__(self):
        self.tray = None
        self.conf = Conf()

        self.is_translationmodemenu_item_checked = {
            'popup' : False,
            'translateandreplace' : False
        }
        self.__update_checkmarkstate_of_tranlationmodemenu_items()

        self.__create_tray()

    def __create_tray(self):
        self.tray = Icon(ICON_PATH)
        self.tray.icon = self.__create_image_data()
        self.tray.menu = self.__create_menu()
        self.tray.title = self.__update_icon_hovertext()
        self.tray.HAS_DEFAULT_ACTION = True

    def __create_image_data(self):
        ''' Generate image data from .icon file
        '''
        return Image.open(ICON_PATH)
        # TODO: Is there any other way that does not need to convert the image ?

    def __create_menu(self):
        return Menu(
            MenuItem('Translation Mode', Menu(
                    MenuItem('Pop-Up Window',
                             self.__on_enable_popupwindow_mode,
                             checked=lambda _: self.is_translationmodemenu_item_checked['popup']),
                    MenuItem('Translate and Replace',
                             self.__on_enable_translateandreplace_mode,
                             checked=lambda _: self.is_translationmodemenu_item_checked['translateandreplace']))),
            MenuItem('Configuration', self.__on_open_mainuicontroller),
            MenuItem('Quit', self.__on_quit_program))

    def __update_icon_hovertext(self):
        if self.conf.get_translation_mode() == ConfigConst.POPUP_MODE:
            return 'Pop-Up Window Mode'
        elif self.conf.get_translation_mode() == ConfigConst.TRANSLATEANDREPLACE_MODE:
            return 'Translate and Replace Mode'

    def __update_checkmarkstate_of_tranlationmodemenu_items(self):
        if self.conf.get_translation_mode() == ConfigConst.POPUP_MODE:
            self.is_translationmodemenu_item_checked['popup'] = True
            self.is_translationmodemenu_item_checked['translateandreplace'] = False
        elif self.conf.get_translation_mode() == ConfigConst.TRANSLATEANDREPLACE_MODE:
            self.is_translationmodemenu_item_checked['popup'] = False
            self.is_translationmodemenu_item_checked['translateandreplace'] = True

    def __on_enable_popupwindow_mode(self):
        self.conf.set_translation_mode(ConfigConst.POPUP_MODE)

        self.__update_checkmarkstate_of_tranlationmodemenu_items()
        self.tray.title = self.__update_icon_hovertext()

    def __on_enable_translateandreplace_mode(self):
        self.conf.set_translation_mode(ConfigConst.TRANSLATEANDREPLACE_MODE)

        self.__update_checkmarkstate_of_tranlationmodemenu_items()
        self.tray.title = self.__update_icon_hovertext()

    def __on_quit_program(self, icon, item):
        self.tray.stop()
        os._exit(1)

    def __on_open_mainuicontroller(self, icon, item):
        uicontroller_thread = MainUIControllerThread(ConfigConst.THREAD_ID_MAINUICONTROLLER, 'MainUIControllerThread')
        uicontroller_thread.start()

    def run(self):
        self.tray.run()