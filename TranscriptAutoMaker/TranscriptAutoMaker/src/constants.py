PROJECT_DIR = '..\\'

CONFIG_PATH = PROJECT_DIR + 'conf\\conf.ini'
ICON_PATH = PROJECT_DIR + 'conf\\icon.ico'
LOG_PATH = PROJECT_DIR + 'log\\log.txt'
AUDIO_PATH = PROJECT_DIR + 'audio\\'
AUDIO_SAMPLE_DIR = PROJECT_DIR + 'audio-samples\\'
TRANSCRIPT_DIR = PROJECT_DIR + 'transcripts\\'
GOOGLE_API_KEY_PATH = PROJECT_DIR + 'google-api-key\\TextToSpeech-59c726f585dd.json'
FFPMPEG_EXE_PATH = PROJECT_DIR + 'external_packages\\ffmpeg-4.3.1-win64-shared\\bin\\ffmpeg.exe'

class TIMESTAMP_MODE_ENUM:
    ONLY_START = 0
    BOTH_START_END = 1