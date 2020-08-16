import os
from tkinter import messagebox
import glob

from pydub import AudioSegment
from pydub.silence import split_on_silence

from logger import Logger
from constants import AUDIO_SAMPLE_DIR, FFPMPEG_EXE_PATH

class AudioSampling:
    def __init__(self):
        self.sample_dir = os.path.join(os.getcwd(), AUDIO_SAMPLE_DIR)     # Append current dir + audio sample dir
        self.ffmpeg_path = os.path.join(os.getcwd(), FFPMPEG_EXE_PATH)    # Append current dir + ffmpeg exe path
        self.logger = Logger.get_instance()

        self.__remove_all_samples(self.sample_dir)
        self.__create_dir()

    def __create_dir(self):
        if not os.path.isdir(self.sample_dir):     # If no dir is found, create it
            os.mkdir(self.sample_dir)

    def sample(self, audio_path, min_silence_len, max_silence_dB):
        try:
            AudioSegment.converter = self.ffmpeg_path
            audio = AudioSegment.from_wav(audio_path)
            samples = split_on_silence(audio,
                min_silence_len = min_silence_len,      # (in ms) minimum length of a silence
                silence_thresh = max_silence_dB,        # (in dBFS) anything quieter than this will be silent
                keep_silence=True                       # If True is specified, all the silence is kept
            )

            if len(samples) == 0:
                self.logger.error('No sample created because either Min Silence Length ({} ms) is too long, or Max Silence dB ({} dB) is too high.'.format(min_silence_len, max_silence_dB))
                messagebox.showerror('Error', 'No sample created because either Min Silence Length ({} ms) is too long, or Max Silence dB ({} dB) is too high.\nPlease adjust them and retry!'.format(min_silence_len, max_silence_dB))
                return []

            os.chdir(self.sample_dir)

            result_dict = {'path': None, 'length_s': 0.0}
            result_dicts = []
            i = 1
            for sample in samples:
                name = "sample_{}.wav".format(i)
                sample.set_channels(1)
                sample.export(name, format='wav', bitrate ='256k')
                print("Created sample_{0}.wav".format(i))
                i += 1

                result_dict['path'] = self.sample_dir + name
                result_dict['length_s'] = AudioSegment.from_file(result_dict['path']).duration_seconds
                result_dicts.append(result_dict.copy())

            os.chdir('..')
            return result_dicts

        except Exception as e:
            self.logger.error('Failed to sample audio file. Error: {}'.format(e))
            messagebox.showerror('Error', 'Failed to sample audio file.\nError: {}'.format(e))

    def __remove_all_samples(self, path):
        try:
            if os.path.isdir(self.sample_dir):
                files = glob.glob(path + '*')
                for f in files:
                    os.remove(f)
        except Exception as e:
            self.logger.error('Failed to remove old audio samples. Error: {}'.format(e))
            messagebox.showerror('Error', 'Failed to remove old audio samples.\nError: {}'.format(e))