from tkinter import Tk, Scrollbar, Text, VERTICAL, RIGHT, LEFT, BOTH, END, Y, FLAT, DISABLED, WORD
from tkinter.font import Font
import keyboard

from conf import Conf

POPUP_MAX_WIDTH = 700
POPUP_MAX_HEIGHT = 400
PADDING = 20

class Popup:
    def __init__(self, org_text, translated_text, is_uicontrol_label):
        self.org_text = org_text
        self.translated_text = translated_text
        self.is_uicontrol_label = is_uicontrol_label
        self.displayed_text = ''
        self.conf = Conf()
        self.popup = None
        self.text_widget = None
        self.font = None

    def show(self):
        self.__init_popup()
        self.__init_font()
        self.__init_text_widget()
        self.__set_popup_size_and_pos()
        self.__set_evenbinding()
        self.__set_focus()

        self.popup.mainloop()

    def __init_popup(self):
        # Create a popup (= the root/master window) and set its properties
        self.popup = Tk()
        self.popup.title('Popup Translator')
        self.popup.attributes('-topmost', True)     # Always on top
        self.popup.attributes('-toolwindow', True)  # No icon on taskbar, no icon on menu, no min button, no max button
        self.popup.configure(bg=self.conf.get_popup_bkcolor())

        # Scrollbar
        vbar = Scrollbar(self.popup, orient=VERTICAL)
        vbar.pack(side=RIGHT, fill=Y)
        # FIXME: Scrollbar works with mouse wheel, but doesn't work with mouse click
        # Note: We don't need a horizontial scrollbar because out-of-width text is automatically wrapped
        # hbar = Scrollbar(self.popup, orient=HORIZONTAL)
        # hbar.pack(side=BOTTOM, fill=X)

    def __init_text_widget(self):
        # Choose text to display on popup
        if self.is_uicontrol_label:
            self.displayed_text = self.org_text + '\n' + '===\n' + self.translated_text
        else:
            self.displayed_text = self.translated_text

        # Add text to popup
        self.text_widget = Text(self.popup)
        self.text_widget.insert(END, self.displayed_text)
        self.text_widget.pack(side=LEFT, fill=BOTH, expand=True)
        self.text_widget.configure(bg=self.popup.cget('bg'), relief=FLAT, state=DISABLED, font=self.font, wrap=WORD)

    def __init_font(self):
        self.font = Font(root=self.popup, family=self.conf.get_font(), size=self.conf.get_fontsize())

    ''' Set size and position for the popup
        Details:
            - Popup size fits the text size (both horizonal and vertical side),
              but the text size cannot exceed POPUP_MAX_WIDTH or POPUP_MAX_HEIGHT
            - Popup position is at the cursor position
    '''
    def __set_popup_size_and_pos(self):
        ###### Size #####
        # Warning: Cannot measure(self.displayed_text) because the measure() method considers multiple lines as one line, making the width in pixels too wrong
        text_width_in_pixels = 0
        if not self.is_uicontrol_label:
            text_width_in_pixels = self.font.measure(self.translated_text)
        else:
            translated_text_width = self.font.measure(self.translated_text)
            org_text_width = self.font.measure(self.org_text)
            text_width_in_pixels = translated_text_width if translated_text_width > org_text_width else org_text_width

        popup_width = 0
        if text_width_in_pixels < POPUP_MAX_WIDTH:     # Warning: pixels of text width and of popup width are slightly different even when the same length. Cannot know why ??
                                                       # Therefore, popup size does not fit the text size exactly, just acceptable in most cases
            popup_width = text_width_in_pixels + PADDING*2
        else:
            popup_width = POPUP_MAX_WIDTH + PADDING

        line_sum = text_width_in_pixels/POPUP_MAX_WIDTH
        popup_height = line_sum*self.font.metrics("linespace") + PADDING
        if (line_sum) < 1:
            line_sum = 1

        # For UI control label, we have to display both orginal text and translated text (plus a separate line at between),
        # we have to triple the height of popup
        if self.is_uicontrol_label:
            popup_height = 3*popup_height

        if popup_height > POPUP_MAX_HEIGHT:
            popup_height = POPUP_MAX_HEIGHT + PADDING

        ###### Position ######
        cursor_pos_x, cursor_pos_y = self.popup.winfo_pointerxy()

        ###### It's time to set popup size and position #######
        self.popup.geometry("%dx%d+%d+%d" % (popup_width, popup_height, cursor_pos_x + 5, cursor_pos_y + 5))

    def __set_evenbinding(self):
        # What to do if popup is out of focus? (close the popup)
        self.popup.bind('<FocusOut>', self.__on_focus_out)

        # What to do is a key (or hotkey) is pressed
        self.popup.bind('<KeyPress>', self.__on_key_pressed)

    ''' Force to focus on the popup when it's displayed '''
    def __set_focus(self):
        self.popup.focus_force()

    ''' Close the popup when clicking anywhere outside of it '''
    def __on_focus_out(self, event):
        if self.conf.get_is_close_popup_when_outoffocus():
            self.popup.destroy()

    ''' Close the popup when the starting hotkey is press
        Details: When the next text is translated, the current popup is closed and the new popup is shown.
        This is useful when translating items in the UI content menu. '''
    def __on_key_pressed(self, event):
        if keyboard.is_pressed(self.conf.get_hotkey()):
            self.popup.destroy()