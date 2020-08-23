import threading
from os import path
from tkinter import messagebox

from wav_converter import WavConverter
from audio_sampling import AudioSampling
from transcripting import Transcripting
from conf import Conf
from logger import Logger

class TranscriptThread(threading.Thread):
    def __init__(self):
        threading.Thread.__init__(self)
        self.conf = Conf.get_instance()
        self.logger = Logger.get_instance()
        self.wav_path = ''

    def run(self):
        ''' Override the run() method of threading.Thread
        '''

        #########################
        # Validate input
        audio_video_path = self.conf.get_audio_video_path()

        # Get input format (extension)
        audio_video_basename = path.basename(audio_video_path)
        audio_video_ext = path.splitext(audio_video_basename)[1]
        print(audio_video_ext)

        # If input format is not supported, show error message
        if self.__check_format(audio_video_ext) == False:
            return False

        # If input is a video, convert it to wav
        video_formats = ['.flv', '.avi', '.mkv', '.mp4']
        if audio_video_ext in video_formats:
            if self.__video_to_wav_convert(audio_video_path) == False:
                return False
        # If input is mp3, convert it to wav
        elif audio_video_ext == '.mp3':
            if self.__mp3_to_wav_convert(audio_video_path) == False:
                return False
        # If input is audio file, keep using it as it was inputted
        else:
            self.wav_path = self.conf.get_audio_video_path()
        #########################

        #########################
        # Sample audio file
        audio_files_dict = self.__sample()
        if len(audio_files_dict) == 0:
            return False
        #########################

        #########################
        # Transcript
        self.__transcript(audio_files_dict)
        #########################

    def __check_format(self, audio_video_ext):
        all_supported_formats = ['.wav', '.mp3', '.flv', '.avi', '.mkv', '.mp4']
        if audio_video_ext not in all_supported_formats:
            self.logger.error('Audio/video format ({}) is not supported.'.format(audio_video_ext))
            messagebox.showerror('Error', 'Sorry, the tool does not support this format.\n\nSupported format:\n- Audio: wav, mp3\n- Video: flv, avi, mkv, mp4')
            return False

        return True

    def __video_to_wav_convert(self, video_path):
        wav_converter = WavConverter()
        self.wav_path = wav_converter.get_wav_path(video_path)
        if wav_converter.video_to_wav(video_path, self.wav_path):
            return True
        else:
            return False

    def __mp3_to_wav_convert(self, mp3_path):
        wav_converter = WavConverter()
        self.wav_path = wav_converter.get_wav_path(mp3_path)
        if wav_converter.mp3_to_wav(mp3_path, self.wav_path):
            return True
        else:
            return False

    def __sample(self):
        audio_sampling = AudioSampling()
        audio_files_dict = audio_sampling.sample(self.wav_path,
                                                 self.conf.get_min_silence_len(),
                                                 self.conf.get_max_silence_dB())
        return audio_files_dict

    def __transcript(self, audio_files_dict):
        # FOR TESTING ONLY
        # import time
        # time.sleep(3)
        # print('1')
        # time.sleep(3)
        # print('2')
        # time.sleep(3)
        # print('fisnish')

        transcripting = Transcripting()
        text = transcripting.transcript(audio_files_dict, timestamp_mode_id=self.conf.get_timestamp_setting())
        transcripting.save_to_file(text)