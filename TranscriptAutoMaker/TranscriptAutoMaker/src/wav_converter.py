import os
from tkinter import messagebox
import subprocess

from logger import Logger
from constants import AUDIO_PATH, FFPMPEG_EXE_PATH

class WavConverter:
    def __init__(self):
        self.audio_dir = os.path.join(os.getcwd(), AUDIO_PATH)              # Append current dir + audio path
        self.ffmpeg_path = os.path.join(os.getcwd(), FFPMPEG_EXE_PATH)      # Append current dir + ffmpeg exe path
        self.logger = Logger.get_instance()

        self.__create_audio_dir()

    def __create_audio_dir(self):
        """ Create directory to store converted audio files
        """
        if not os.path.isdir(self.audio_dir):       # If no dir is found, create it
            os.mkdir(self.audio_dir)

    def __handle_space_in_path(self, before_path):
        return '"' + before_path + '"'

    def get_wav_path(self, video_path):
        # Get base name of inputted video
        name_with_ext = os.path.basename(video_path)
        name_without_ext = os.path.splitext(name_with_ext)[0]

        # Set base name and path for audio
        wav_path = self.audio_dir + name_without_ext + '.wav'

        return wav_path

    def video_to_wav(self, video_path, wav_path):
        video_path = self.__handle_space_in_path(video_path)
        wav_path = self.__handle_space_in_path(wav_path)

        try:
            command = '{} -y -i {} -ab 128k -ac 1 -ar 44100 -vn {}'.format(self.ffmpeg_path, video_path, wav_path)
            subprocess.call(command, shell=True)
        except Exception as e:
            self.logger.error('Failed to convert {} to {}. Error: {}'.format(video_path, wav_path, e))
            messagebox.showerror('Error while converting video to wav!\nError: {}'.format(e))
            return False

        return True

    def mp3_to_wav(self, mp3_path, wav_path):
        mp3_path = self.__handle_space_in_path(mp3_path)
        wav_path = self.__handle_space_in_path(wav_path)

        try:
            command = '{} -y -i {} -acodec pcm_s16le -ac 1 -ar 44100 {}'.format(self.ffmpeg_path, mp3_path, wav_path)
            subprocess.call(command, shell=True)
        except Exception as e:
            self.logger.error('Failed to convert {} to {}. Error: {}'.format(mp3_path, wav_path, e))
            messagebox.showerror('Error while converting mp3 to wav!\nError: {}'.format(e))
            return False

        return True
