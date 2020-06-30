from configparser import ConfigParser
from constants import CONFIG_PATH

class Conf:
    def __init__(self):
        # Note: By default, configparser considers '#' and ';' as comment marks.
        # However, this means it will automatically delete all comment marks when writing (via set() method) to the file.
        # To avoid this, we set "comment_prefixes=" to empty so that it doesn't consider '#' and ';' as comment marks.
        self.config = ConfigParser(comment_prefixes=())

    def get_hotkey(self):
        self.config.read(CONFIG_PATH)
        return self.config.get('HOTKEY', 'HOTKEY')

    def set_hotkey(self, name):
        self.config.set('HOTKEY', 'HOTKEY', name)
        with open(CONFIG_PATH, 'w') as config:
            self.config.write(config)

    def get_source_lang(self):
        self.config.read(CONFIG_PATH)
        return self.config.get('LANGUAGE', 'FROM_LANG')

    def set_source_lang(self, code):
        self.config.set('LANGUAGE', 'FROM_LANG', code)
        with open(CONFIG_PATH, 'w') as config:
            self.config.write(config)

    def get_dest_lang(self):
        self.config.read(CONFIG_PATH)
        return self.config.get('LANGUAGE', 'TO_LANG')

    def set_dest_lang(self, code):
        self.config.set('LANGUAGE', 'TO_LANG', code)
        with open(CONFIG_PATH, 'w') as config:
            self.config.write(config)

    def get_translation_mode(self):
        self.config.read(CONFIG_PATH)
        return self.config.getint('MODE', 'TRANSLATION')

    def set_translation_mode(self, id):
        self.config.set('MODE', 'TRANSLATION', str(id))
        with open(CONFIG_PATH, 'w') as config:
            self.config.write(config)

    def get_font(self):
        self.config.read(CONFIG_PATH)
        return self.config.get('POPUP_UI', 'FONT')

    def get_fontsize(self):
        self.config.read(CONFIG_PATH)
        return self.config.get('POPUP_UI', 'FONT_SIZE')

    def get_popup_bkcolor(self):
        self.config.read(CONFIG_PATH)
        return self.config.get('POPUP_UI', 'BK_COLOR')

    def get_maincontroller_bkcolor(self):
        self.config.read(CONFIG_PATH)
        return self.config.get('MAIN_CONTROLLER_UI', 'BK_COLOR')

    def get_is_close_popup_when_outoffocus(self):
        self.config.read(CONFIG_PATH)
        return self.config.getboolean('EVENT', 'CLOSE_POPUP_WHEN_OUTOFFOCUS')

    def set_is_close_popup_when_outoffocus(self, value):
        self.config.set('EVENT', 'CLOSE_POPUP_WHEN_OUTOFFOCUS', str(value))
        with open(CONFIG_PATH, 'w') as config:
            self.config.write(config)