import os

from google.cloud import speech_v1
from google.oauth2 import service_account

from conf import Conf
from constants import GOOGLE_API_KEY_PATH

class SpeechToText:
    def __init__(self):
        self.conf = Conf.get_instance()

    def recognize(self, file_path):
        """
        Transcribe a long audio file using asynchronous speech recognition

        Args:
        file_path Path to local audio file, e.g. /path/audio.wav
        """
        google_api_key = os.path.join(os.getcwd(), GOOGLE_API_KEY_PATH)    # Append current dir + transcript path

        credentials = service_account.Credentials.from_service_account_file(google_api_key)
        client = speech_v1.SpeechClient(credentials=credentials)

        config = {
            "language_code": self.conf.get_language(),
            # "sample_rate_hertz": 44100,   # This attribute must either be omitted or match the value in the WAV header of the file
            "enable_word_time_offsets": True
        }

        with open(file_path, "rb") as f:
            content = f.read()
        audio = {"content": content}

        operation = client.long_running_recognize(config, audio)
        response = operation.result()
        print("response.results.length: ", len(response.results))

        alternatives = []
        for result in response.results:
            # First alternative is the most probable result
            alternatives.append(result.alternatives[0])

        return alternatives