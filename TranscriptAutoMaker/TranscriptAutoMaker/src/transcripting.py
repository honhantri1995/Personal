from os import path
from datetime import datetime
from tkinter import messagebox

from speech_to_text import SpeechToText
from transcript_history import TranscriptHistory
from conf import Conf
from logger import Logger
from constants import TIMESTAMP_MODE_ENUM

class Transcripting:
    def __init__(self):
        self.logger = Logger.get_instance()

    def transcript(self, audio_files_dict, timestamp_mode_id=TIMESTAMP_MODE_ENUM.ONLY_START):
        try:
            transcript = ''
            if timestamp_mode_id == TIMESTAMP_MODE_ENUM.ONLY_START:
                transcript = self.transcript_start_timestamp(audio_files_dict)
            elif timestamp_mode_id == TIMESTAMP_MODE_ENUM.BOTH_START_END:
                transcript = self.transcript_start_end_timestamp(audio_files_dict)
            return transcript

        except Exception as e:
            self.logger.error('Failed to transcript. Error: {}'.format(e))
            messagebox.showerror('Error', 'Failed to transcript!\nError: {}'.format(e))

    def transcript_start_timestamp(self, audio_files_dict):
        speech_to_text = SpeechToText()
        transcript = ''
        total_previous_length = 0.0
        for audio_file in audio_files_dict:
            alternatives = speech_to_text.recognize(audio_file['path'])
            for alternative in alternatives:
                first_word = alternative.words[0]

                timestamp = datetime.strftime(datetime.utcfromtimestamp(
                            first_word.start_time.seconds + first_word.start_time.nanos*0.000000001 + total_previous_length),
                            "%H:%M:%S,%f")
                transcript += '{} {}'.format(timestamp, alternative.transcript.lstrip())
                transcript += '\n'

            total_previous_length += audio_file['length_s']

        print(transcript)
        return transcript

    def transcript_start_end_timestamp(self, audio_files_dict):
        speech_to_text = SpeechToText()
        transcript = ''
        total_previous_length_s = 0.0
        i = 1
        for audio_file in audio_files_dict:
            alternatives = speech_to_text.recognize(audio_file['path'])
            for alternative in alternatives:
                first_word = alternative.words[0]
                last_word = alternative.words[-1]

                timestamp_start = datetime.strftime(datetime.utcfromtimestamp(
                            first_word.start_time.seconds + first_word.start_time.nanos*0.000000001 + total_previous_length_s),
                            "%H:%M:%S,%f")
                timestamp_end = datetime.strftime(datetime.utcfromtimestamp(
                            last_word.end_time.seconds + last_word.end_time.nanos*0.000000001 + total_previous_length_s),
                            "%H:%M:%S,%f")

                transcript += '\n{}\n{} --> {}\n{}'.format(i, timestamp_start, timestamp_end, alternative.transcript.lstrip())
                transcript += '\n'

                i += 1

            total_previous_length_s += audio_file['length_s']

        print(transcript)
        return transcript

    def save_to_file(self, transcript):
        conf = Conf.get_instance()
        file_name = path.basename(conf.get_audio_video_path())
        file_name = path.splitext(file_name)[0]
        mode = conf.get_timestamp_setting()
        if mode == TIMESTAMP_MODE_ENUM.ONLY_START:
            file_name += '_onlyStartTime'
        elif mode == TIMESTAMP_MODE_ENUM.BOTH_START_END:
            file_name += '_bothStartAndEndTime'
        file_name += '.srt'

        transcript_history = TranscriptHistory()
        transcript_history.write_to_file(file_name, transcript)