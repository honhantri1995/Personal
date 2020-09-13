import subprocess
import os

YOUTUBEDL_EXE_PATH = 'youtube-dl.exe'
output_path = r"path\to\output\folder"      # CHANGE THIS

class YoutubeDownloader:
    def __init__(self):
        self.url = ''

    def __get_youtubedl_path(self):
        return os.path.join(os.getcwd(), YOUTUBEDL_EXE_PATH)

    def set_url(self, url):
        self.url = url

    def __get_output_path(self):
        return "{}\\%(title)s.%(ext)s".format(output_path)

    def download(self):
        # Tip: Set video quality: https://askubuntu.com/a/486298
        command = '{} {}  --output {} --audio-quality 256k'.format(self.__get_youtubedl_path(), self.url, self.__get_output_path())
        print(command)
        subprocess.call(command, shell=True)

# TESTING
downloader = YoutubeDownloader()
downloader.set_url(r'https://www.youtube.com/watch?v=9z8_YhWoq2o')

# NOTE: The below path is wrong. The right path must not include string after "&"
# https://www.youtube.com/watch?v=9z8_YhWoq2o&ab_channel=MattD%27Avella
downloader.download()
