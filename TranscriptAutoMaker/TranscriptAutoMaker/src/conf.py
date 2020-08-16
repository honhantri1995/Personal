from configobj import ConfigObj
import os

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

    def get_audio_video_path(self):
        return self.conf['PATH']['AUDIO_VIDEO']

    def set_audio_video_path(self, path):
        self.conf['PATH']['AUDIO_VIDEO'] = path
        self.conf.write()

    def get_transcript_path(self):
        return self.conf['PATH']['TRANSCRIPT']

    def set_transcript_path(self, path):
        self.conf['PATH']['TRANSCRIPT'] = path
        self.conf.write()

    def get_language(self):
        return self.conf['LANGUAGE']['CODE']

    def set_language(self, code):
        self.conf['LANGUAGE']['CODE'] = code
        self.conf.write()

    def get_timestamp_setting(self):
        return int(self.conf['TIMESTAMP']['MODE'])

    def set_timestamp_setting(self, mode):
        self.conf['TIMESTAMP']['MODE'] = str(mode)
        self.conf.write()

    def get_min_silence_len_default(self):
        return int(self.conf['SILENCE']['MIN_SILENCE_LEN_DEFAULT'])

    def get_max_silence_dB_default(self):
        return int(self.conf['SILENCE']['MAX_SILENCE_DB_DEFAULT'])

    def get_min_silence_len(self):
        return int(self.conf['SILENCE']['MIN_SILENCE_LEN'])

    def set_min_silence_len(self, value):
        self.conf['SILENCE']['MIN_SILENCE_LEN'] = str(value)
        self.conf.write()

    def get_max_silence_dB(self):
        return int(self.conf['SILENCE']['MAX_SILENCE_DB'])

    def set_max_silence_dB(self, value):
        self.conf['SILENCE']['MAX_SILENCE_DB'] = str(value)
        self.conf.write()

    def get_maincontroller_bkcolor(self):
        return self.conf['MAIN_CONTROLLER_UI']['BK_COLOR']