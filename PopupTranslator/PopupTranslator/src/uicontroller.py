from tkinter import Tk, Frame, Label, IntVar, StringVar, BooleanVar, DISABLED, NORMAL, W, E, constants
from tkinter import ttk
from threading import Thread
import os

from conf import Conf
from constants import ConfigConst, ICON_PATH
from aboutdialog import AboutDialog
import languagelist

class MainUIControllerThread(Thread):
    def __init__(self, threadID, name):
        Thread.__init__(self)
        self.threadID = threadID
        self.name = name

    def run(self):
        ''' Override the run() method of threading.Thread
        '''
        self.running = True
        controller = MainUIController()
        controller.show()


class MainUIController:
    def __init__(self):
        self.controller = None
        self.conf = Conf()
        self.translation_mode_var = None
        self.hotkey_var = None
        self.src_lang_var = None
        self.dest_lang_var = None
        self.outoffocus_checkbox_var = None
        self.outoffocus_checkbox = None

    def show(self):
        self.__create_window()
        self.__create_translation_mode_controls()
        self.__create_hotkey_controls()
        self.__create_language_controls()
        self.__create_outoffoucus_close_checkbox()
        self.__create_buttons()

        self.controller.mainloop()

    def __create_window(self):
        self.controller = Tk()
        self.controller.title('Popup Translator')
        self.controller.iconbitmap(ICON_PATH)
        self.controller.attributes('-topmost', True)                            # Always on top
        self.controller.configure(bg=self.conf.get_maincontroller_bkcolor())    # Set background color
        self.controller.resizable(0, 0)                                         # Prevent resize the window

        # TODO: Has a small interrupt, need to fix it
        self.__set_window_size_and_position()

    def __set_window_size_and_position(self):
        # Size
        width = 400
        height = 240

        # Always center the window to the screen
        x = (self.controller.winfo_screenwidth() // 2) - (width // 2)
        y = (self.controller.winfo_screenheight() // 2) - (height // 2)

        self.controller.geometry('{}x{}+{}+{}'.format(width, height, x, y))

    def __create_translation_mode_controls(self):
        # Frame with label
        frame = ttk.LabelFrame(self.controller, text='Translation Mode')
        frame.grid(column=1, row=1, padx=10, pady=10)

        # Mode radio buttons
        modes = [
            ('Pop-Up Window', ConfigConst.POPUP_MODE),
            ('Translate and Replace', ConfigConst.TRANSLATEANDREPLACE_MODE)
        ]
        self.translation_mode_var = IntVar()
        self.translation_mode_var.set(self.conf.get_translation_mode())
        for text, value in modes:
            radio = ttk.Radiobutton(frame, text=text, variable=self.translation_mode_var,
                                    command=self.__on_click_translationmode_radiobutton, value=value)
            radio.pack(anchor=W, padx=20)

    def __on_click_translationmode_radiobutton(self):
        self.conf.set_translation_mode(self.translation_mode_var.get())
        self.__on_update_outoffocus_close_checkbox_state()

    def __create_hotkey_controls(self):
        # Framew with label
        frame = ttk.LabelFrame(self.controller, text='Hotkey')
        frame.grid(column=2, row=1, padx=10, pady=10)

        # Hotkey radio button
        hotkeys = [
            ('Ctrl + `', 'Ctrl + `'),
            ('Ctrl + Alt', 'Ctrl + Alt')
        ]
        self.hotkey_var = StringVar()
        self.hotkey_var.set(self.conf.get_hotkey())
        for text, value in hotkeys:
            radio = ttk.Radiobutton(frame, text=text, variable=self.hotkey_var,
                                    command=self.__on_click_hotkey_radiobutton, value=value)
            radio.pack(anchor=W, padx=20)

    def __on_click_hotkey_radiobutton(self):
        self.conf.set_hotkey(str(self.hotkey_var.get()))

    def __create_language_controls(self):
        # Frame with labels
        frame = ttk.LabelFrame(self.controller, text='Language')
        frame.grid(column=1, row=2, padx=10, pady=10, columnspan=2)

        # From language
        # ======================================
        from_frame = Frame(frame)
        from_frame.grid(column=1, row=1, padx=10, pady=10, sticky=W)
        src_lang = Label(from_frame, text='From:')
        src_lang.grid(column=1, row=1, sticky=W)

        self.src_lang_var = StringVar()
        self.src_lang_var.set(self.__get_key_from_dict(languagelist.src_language_code_dict, self.conf.get_source_lang()))

        src_lang_combobox = ttk.Combobox(from_frame, state='readonly', values=languagelist.src_language_list, textvariable=self.src_lang_var)
        src_lang_combobox.grid(column=2, row=1, sticky=W)
        src_lang_combobox.bind("<<ComboboxSelected>>", self.__change_src_language)

        # To language
        # ======================================
        to_frame = Frame(frame)
        to_frame.grid(column=2, row=1, padx=5, pady=10, sticky=E)
        dest_lang = Label(to_frame, text='To:')
        dest_lang.grid(column=3, row=1, sticky=W)

        self.dest_lang_var = StringVar()
        self.dest_lang_var.set(self.__get_key_from_dict(languagelist.dest_language_code_dict, self.conf.get_dest_lang()))

        dest_lang_combobox = ttk.Combobox(to_frame, state='readonly', values=languagelist.dest_language_list, textvariable=self.dest_lang_var)
        dest_lang_combobox.grid(column=4, row=1, sticky=W)
        dest_lang_combobox.bind("<<ComboboxSelected>>", self.__change_dest_language)

    def __change_src_language(self, *args):
        self.conf.set_source_lang(languagelist.src_language_code_dict[self.src_lang_var.get()])

    def __change_dest_language(self, *args):
        self.conf.set_dest_lang(languagelist.dest_language_code_dict[self.dest_lang_var.get()])

    def __get_key_from_dict(self, dictionary, val):
        ''' Return key for any value from a dictionary
        '''
        for key, value in dictionary.items():
            if val == value:
                return key

        return "Key doesn't exist"

    def __create_outoffoucus_close_checkbox(self):
        # Frame
        frame = Frame(self.controller)
        frame.grid(column=1, row=3, columnspan=2, padx=10, pady=5, sticky=W)

        # Checkbox
        self.outoffocus_checkbox_var = BooleanVar()
        self.outoffocus_checkbox_var.set(self.conf.get_is_close_popup_when_outoffocus())
        state = DISABLED if self.conf.get_translation_mode() == ConfigConst.TRANSLATEANDREPLACE_MODE else NORMAL
        self.outoffocus_checkbox = ttk.Checkbutton(frame,
                                                   text='Automatically close Popup when out-of-focus',
                                                   state=state,
                                                   variable=self.outoffocus_checkbox_var,
                                                   command=self.__on_click_outoffocus_close_checkbox)
        self.outoffocus_checkbox.grid(column=1, row=1, sticky=W)

    def __on_click_outoffocus_close_checkbox(self):
        self.conf.set_is_close_popup_when_outoffocus(self.outoffocus_checkbox_var.get())

    def __on_update_outoffocus_close_checkbox_state(self):
        if self.translation_mode_var.get() == ConfigConst.TRANSLATEANDREPLACE_MODE:
            self.outoffocus_checkbox.config(state=DISABLED)
        else:
            self.outoffocus_checkbox.config(state=NORMAL)

    def __create_buttons(self):
        # Frame
        frame = Frame(self.controller)
        frame.grid(column=1, row=4, columnspan=2, padx=10, pady=5)

        # About button
        btn_about = ttk.Button(frame, text='About', width=15, command=self.__on_click_about_button)
        btn_about.grid(column=1, row=1, padx=5, pady=10)

        # Quit button
        btn_quit = ttk.Button(frame, text='Quit', width=15, command=self.__on_click_quit_button)
        btn_quit.grid(column=2, row=1, padx=5, pady=10)

        # OK button
        btn_ok = ttk.Button(frame, text='OK', width=15, command=self.__on_click_ok_button)
        btn_ok.grid(column=3, row=1, padx=5, pady=10)

    def __on_click_ok_button(self):
        # self.controller.quit()    # CANNOT USE because it terminates the process
        self.controller.destroy()

    def __on_click_quit_button(self):
        # sys.exit()  # CANNOT USE because when UI controller is opened in worker thread, this method only exits from this worker thread, not main thread
        os._exit(1)

    def __on_click_about_button(self):
        about = AboutDialog()
        about.show()