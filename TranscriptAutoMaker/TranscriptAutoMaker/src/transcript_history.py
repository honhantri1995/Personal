import os
from tkinter import messagebox

from conf import Conf
from logger import Logger
from constants import TRANSCRIPT_DIR

class TranscriptHistory():
    def __init__(self):
        self.conf = Conf.get_instance()
        self.logger = Logger.get_instance()

        # Although the user might not choose the defaul transcript path,
        # it's better to always create it
        self.__create_dir()

        self.path = self.conf.get_transcript_path()

    def __create_dir(self):
        transcript_dir = os.path.join(os.getcwd(), TRANSCRIPT_DIR)    # Append current dir + transcript path
        if not os.path.isdir(transcript_dir):                         # If no dir is found, create it
            os.mkdir(transcript_dir)

    def write_to_file(self, file_name, transcript):
        try:
            path = self.path + file_name
            with open(path, "w", encoding="utf-8") as file:
                file.write(transcript)
        except Exception as e:
            self.logger.error('Failed to save transcript to {}. Error: {}.'.format(file_name, e))
            messagebox.showerror('Error', 'Failed to save transcript to file.\nError: {}'.format(e))