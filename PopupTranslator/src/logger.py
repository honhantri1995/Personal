import os
import logging
from constants import LOG_PATH

IS_ENABLED_DEBUG_LOG = True

class Logger():
    def __init__(self):
        self.logger = None
        self.__configure_logging()

    def __create_dir(self):
        relative_dir = os.path.dirname(LOG_PATH)                    # Get relative dir path from file path (eg: ../log/log.txt  --> ../log/)
        absolute_path = os.path.join(os.getcwd(), relative_dir)     # Append current dir + relative dir path

        if not os.path.isdir(absolute_path):                        # If no dir, create it
            os.mkdir(absolute_path) 

    def __configure_logging(self):
        self.__create_dir()

        if not IS_ENABLED_DEBUG_LOG:
            logging.disable(level=logging.DEBUG)

        self.logger = logging.getLogger()
        self.logger.setLevel(logging.DEBUG)         # All log level will be outputted
        filehandler = logging.FileHandler(filename=LOG_PATH, mode='w+', encoding='utf-8')
        formatter = logging.Formatter('[%(asctime)s] [%(filename)s: %(lineno)s] [%(levelname)s] %(message)s')
        filehandler.setFormatter(formatter)
        self.logger.addHandler(filehandler)

    def error(self, log):
        return self.logger.error(log)

    def info(self, log):
        return self.logger.info(log)