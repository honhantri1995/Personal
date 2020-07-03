import os
from datetime import datetime
from constants import HISTORY_PATH

class History:
    def __init__(self):
        self.__create_dir()

    def __create_dir(self):
        relative_dir = os.path.dirname(HISTORY_PATH)                # Get relative dir path from file path (eg: ../log/history.txt  --> ../log/)
        absolute_path = os.path.join(os.getcwd(), relative_dir)     # Append current dir + relative dir path

        if not os.path.isdir(absolute_path):                        # If no dir, create it
            os.mkdir(absolute_path) 

    def write_to_history(self, org_text, translated_text):
        with open(HISTORY_PATH, "a+", encoding="utf-8") as file:
            # mm/dd/YY H:M:S
            now = datetime.now().strftime("%m/%d/%Y %H:%M:%S")
            text_list = [
                '===============================================================================================================================================================',
                '{}:',
                'From: {}\n',
                'To: {}',
                '===============================================================================================================================================================\n\n'
            ]
            file.write('\n'.join(text_list).format(now, org_text, translated_text))