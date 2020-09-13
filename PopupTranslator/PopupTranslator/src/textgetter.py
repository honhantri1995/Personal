import keyboard
import pyperclip
import time
import clr          # pythonnet
import sys

from logger import Logger
from messagebox import MessageBox
from constants import ExceptionEnum, DLL_PATH

# Import .NET dlls
sys.path.append(DLL_PATH)
clr.AddReference(r"System.Windows.Forms")
clr.AddReference(r"UIAutomationClient")
clr.AddReference(r"UIAutomationTypes")
from System.Windows.Forms import Cursor
from System.Windows.Automation import AutomationElement
from System.Windows import Point

class TextGetter:
    def __init__(self):
        self.is_uicontrol = True

    def get_text(self):
        copied_text = self.__try_to_copy_text()
        # If text is a UI control label
        if copied_text == '':
            return self.__get_uicontrol_label()
        # Else if text is selectable (from MS Word, Web-browswer, etc.)
        else:
            self.is_uicontrol = False
            return copied_text

    def __try_to_copy_text(self):
        # Clear clipboard
        # This trick makes sure the auto choosing between selectable text and UI control label works correctly in all cases
        pyperclip.copy('')

        keyboard.send('ctrl+c')
        time.sleep(0.1)

        try:
            text = pyperclip.paste()
            return text
        except Exception as e:
            # Write log
            logger = Logger.get_instance()
            logger.get_instance().error('Failed to copy text! ' + 'Details: ' + str(e))
            # Show message box
            mb = MessageBox()
            mb.show_error('Failed to copy text!' + '\n\nDetails: ' + str(e))

            raise ValueError(ExceptionEnum.CANNOT_TRANSLATE)
            
    def __get_uicontrol_label(self):
        cur_pos = Cursor.Position
        cur_point = Point(cur_pos.X, cur_pos.Y)
        element = AutomationElement.FromPoint(cur_point)

        control_label = element.Current.Name
        if control_label == '':
            control_label = element.Current.HelpText

        if control_label == '':
            ms = 'Failed to get text from UI controls!'
            # Write log
            logger = Logger.get_instance()
            logger.get_instance().error(ms)
            # Show message box
            mb = MessageBox()
            mb.show_error(ms)

            raise ValueError(ExceptionEnum.CANNOT_GET_TEXT)

        return control_label

    def is_uicontrol_label(self):
        return self.is_uicontrol