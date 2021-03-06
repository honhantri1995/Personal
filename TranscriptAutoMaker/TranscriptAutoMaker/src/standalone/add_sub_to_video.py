import subprocess
import os
from constants import FFPMPEG_EXE_PATH

ffmpeg_path = os.path.join(os.getcwd(), FFPMPEG_EXE_PATH)      # Append current dir + ffmpeg exe path

def __handle_space_in_path(before_path):
    return '"' + before_path + '"'

def convert_srt_to_ass(srt_file, ass_file):
    command = '{} -y -i {} {}'.format(ffmpeg_path, srt_file, ass_file)
    print(command)
    subprocess.call(command, shell=True)
    return ass_file

def add_sub(input_video_file, output_video_file, ass_file):
    command = '{} -y -i {} -vf ass={} {}'.format(ffmpeg_path, input_video_file, ass_file, output_video_file)
    print(command)
    subprocess.call(command, shell=True)


srt_file = r'path\to\input\srt\sub'
srt_file = __handle_space_in_path(srt_file)
ass_file = r'path\to\output\ass\sub'
ass_file_new = __handle_space_in_path(ass_file)

####### Convert srt format to ass format #######
# ass_file = convert_srt_to_ass(srt_file, ass_file_new)

####### Add ass sub to video #######
input_video_file = r'path\to\input\video'
input_video_file = __handle_space_in_path(input_video_file)
output_video_file = r'path\to\output\video'
output_video_file = __handle_space_in_path(output_video_file)

ass_dir_path = os.path.dirname(ass_file)
ass_file_name = os.path.basename(ass_file)
ass_file_name = __handle_space_in_path(ass_file_name)
os.chdir(ass_dir_path)
add_sub(input_video_file, output_video_file, ass_file_name)