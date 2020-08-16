from google.cloud import speech_v1
from google.cloud.speech_v1 import enums
from google.oauth2 import service_account
import io

def sample_long_running_recognize():
    """
    Transcribe a long audio file using asynchronous speech recognition

    Args:
      local_file_path Path to local audio file, e.g. /path/audio.wav
    """

    credentials = service_account.Credentials.from_service_account_file("../google-api-key/TextToSpeech-59c726f585dd.json")
    # scoped_credentials = credentials.with_scopes(["https://www.googleapis.com/auth/cloud-platform"])

    client = speech_v1.SpeechClient(credentials=credentials)

    local_file_path = '../audio/Welcome.wav'

    # The language of the supplied audio
    language_code = "en-US"

    # Sample rate in Hertz of the audio data sent
    sample_rate_hertz = 16000

    # Encoding of audio data sent. This sample sets this explicitly.
    # This field is optional for FLAC and WAV audio formats.
    # encoding = enums.RecognitionConfig.AudioEncoding.LINEAR16
    config = {
        "language_code": language_code,
        "sample_rate_hertz": sample_rate_hertz,
        # "encoding": encoding,
    }
    with io.open(local_file_path, "rb") as f:
        content = f.read()
    audio = {"content": content}

    operation = client.long_running_recognize(config, audio)

    print(u"Waiting for operation to complete...")
    response = operation.result()

    for result in response.results:
        # First alternative is the most probable result
        alternative = result.alternatives[0]
        print(u"Transcript: {}".format(alternative.transcript))


def sample_long_running_recognize_with_timestamp():
    """
    Transcribe a long audio file using asynchronous speech recognition

    Args:
      local_file_path Path to local audio file, e.g. /path/audio.wav
    """

    credentials = service_account.Credentials.from_service_account_file("../google-api-key/TextToSpeech-59c726f585dd.json")
    # scoped_credentials = credentials.with_scopes(["https://www.googleapis.com/auth/cloud-platform"])

    client = speech_v1.SpeechClient(credentials=credentials)

    local_file_path = '../audio/Welcome.wav'

    # The language of the supplied audio
    language_code = "en-US"

    # Sample rate in Hertz of the audio data sent
    sample_rate_hertz = 16000

    # When enabled, the first result returned by the API will include a list
    # of words and the start and end time offsets (timestamps) for those words.
    enable_word_time_offsets = True

    # Encoding of audio data sent. This sample sets this explicitly.
    # This field is optional for FLAC and WAV audio formats.
    # encoding = enums.RecognitionConfig.AudioEncoding.LINEAR16
    config = {
        "language_code": language_code,
        "sample_rate_hertz": sample_rate_hertz,
        # "encoding": encoding,
        "enable_word_time_offsets": enable_word_time_offsets,
    }
    with io.open(local_file_path, "rb") as f:
        content = f.read()
    audio = {"content": content}

    operation = client.long_running_recognize(config, audio)

    print(u"Waiting for operation to complete...")
    response = operation.result()

    for result in response.results:
        # First alternative is the most probable result
        alternative = result.alternatives[0]
        print(u"Transcript: {}".format(alternative.transcript))
        # Print the start and end time of each word
        for word in alternative.words:
            print(u"Word: {}".format(word.word))
            print(
                u"{}:{}".format(
                    word.start_time.seconds, word.start_time.nanos
                )
            )


sample_long_running_recognize()
# sample_long_running_recognize_with_timestamp()