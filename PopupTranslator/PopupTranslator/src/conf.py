import os
from configobj import ConfigObj
from constants import CONFIG_PATH

class Conf:
    __instance = None

    @staticmethod
    def get_instance():
        """ Static access method. """
        if Conf.__instance == None:
            Conf()
        return Conf.__instance

    def __init__(self):
        """ Virtually private constructor. """
        if Conf.__instance != None:
            raise Exception("This class is a singleton!")
        else:
            Conf.__instance = self
            file_path = os.path.join(os.getcwd(), CONFIG_PATH)
            self.conf = ConfigObj(file_path)
        # TODO: Add protection for multithread

    def get_hotkey(self):
        return self.conf['HOTKEY']['HOTKEY']

    def set_hotkey(self, name):
        self.conf['HOTKEY']['HOTKEY'] = name
        self.conf.write()

    def get_source_lang(self):
        return self.conf['LANGUAGE']['FROM_LANG']

    def set_source_lang(self, code):
        self.conf['LANGUAGE']['FROM_LANG'] = code
        self.conf.write()

    def get_dest_lang(self):
        return self.conf['LANGUAGE']['TO_LANG']

    def set_dest_lang(self, code):
        self.conf['LANGUAGE']['TO_LANG'] = code
        self.conf.write()

    def get_translation_mode(self):
        return int(self.conf['MODE']['TRANSLATION'])

    def set_translation_mode(self, id):
        self.conf['MODE']['TRANSLATION'] = str(id)
        self.conf.write()

    def get_font(self):
        return self.conf['POPUP_UI']['FONT']

    def get_fontsize(self):
        return self.conf['POPUP_UI']['FONT_SIZE']

    def get_popup_bkcolor(self):
        return self.conf['POPUP_UI']['BK_COLOR']

    def get_maincontroller_bkcolor(self):
        return self.conf['MAIN_CONTROLLER_UI']['BK_COLOR']

    def get_is_close_popup_when_outoffocus(self):
        return bool(self.conf['EVENT']['CLOSE_POPUP_WHEN_OUTOFFOCUS'])

    def set_is_close_popup_when_outoffocus(self, value):
        self.conf['EVENT']['CLOSE_POPUP_WHEN_OUTOFFOCUS'] = str(value)
        self.conf.write()