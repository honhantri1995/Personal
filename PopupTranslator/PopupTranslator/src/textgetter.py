import keyboard
import pyperclip
import time
import clr          # pythonnet
import sys

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
        except Exception as e:
            ms = MessageBox()
            ms.show_error(e)

        return text

    def __get_uicontrol_label(self):
        cur_pos = Cursor.Position
        cur_point = Point(cur_pos.X, cur_pos.Y)
        element = AutomationElement.FromPoint(cur_point)

        control_label = element.Current.Name
        if control_label == '':
            control_label = element.Current.HelpText

        if control_label == '':
            mb = MessageBox()
            mb.show_error('Cannot get the text from UI controls to translate.')
            raise ValueError(ExceptionEnum.CANNOT_GET_TEXT)

        return control_label

    def is_uicontrol_label(self):
        return self.is_uicontrol