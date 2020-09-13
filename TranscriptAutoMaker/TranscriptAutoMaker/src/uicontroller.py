from tkinter import Tk, Frame, Label, filedialog, IntVar, StringVar, W, E, N, S, END
from tkinter import ttk
from tkinter import messagebox
import os
import time

from conf import Conf
from constants import ICON_PATH, TIMESTAMP_MODE_ENUM, TRANSCRIPT_DIR
from aboutdialog import AboutDialog
import languagelist
from transcript_thread import TranscriptThread
from progressbar import ProgressBar

class UiController:
    def __init__(self):
        self.controller = None
        self.conf = Conf.get_instance()
        self.video_audio_path_entry = None
        self.audio_video_path_stringvar = None
        self.transcript_path_stringvar = None
        self.lanaguage_stringvar = None
        self.min_silence_length_entry = None
        self.max_silence_dB_entry = None
        self.transcript_thread = None
        self.progress_bar = None

        self.audio_video_path = ''
        self.transcript_path = ''

        self.__set_default_config()

    def __set_default_config(self):
        # Reset audio/video path to empty
        self.conf.set_audio_video_path('')

        # Set default transcript path
        default_transcript_path = os.path.join(os.getcwd(), TRANSCRIPT_DIR)    # Append current dir + transcript dir
        self.conf.set_transcript_path(default_transcript_path)

    def show(self):
        self.__create_window()
        self.__create_audio_video_path_entry()
        self.__create_transcript_path_entry()
        self.__create_language_combobox()
        self.__create_timestamp_mode_radiobuttons()
        self.__create_silence_setting_entry()
        self.__create__start_transcripting_btn()
        self.__create_about_btn()

        self.controller.mainloop()

    def __create_window(self):
        self.controller = Tk()
        self.controller.title('Transcript Auto Maker')
        self.controller.iconbitmap(ICON_PATH)
        # self.controller.attributes('-topmost', True)                          # Always on top
        self.controller.configure(bg=self.conf.get_maincontroller_bkcolor())    # Set background color
        self.controller.resizable(0, 0)                                         # Prevent resize the window

        # TODO: Has a small interrupt, should fix it but don't know how
        self.__set_window_size_and_position()

        # Main frame. All other widgets belong to this frame.
        self.frame = Frame(self.controller)
        self.frame.grid(column=3, row=6, padx=10, pady=10)

    def __set_window_size_and_position(self):
        # Size
        width = 580
        height = 280

        # Always center the window to the screen
        x = (self.controller.winfo_screenwidth() // 2) - (width // 2)
        y = (self.controller.winfo_screenheight() // 2) - (height // 2)

        self.controller.geometry('{}x{}+{}+{}'.format(width, height, x, y))

    def __create_audio_video_path_entry(self):
        # Label
        label = ttk.Label(master=self.frame, text='Audio/Video Path')
        label.grid(column=1, row=1, padx=(5, 2), pady=5, sticky=W)

        # String var
        self.audio_video_path_stringvar = StringVar()

        # Entry
        video_audio_path_entry = ttk.Entry(master=self.frame, width=60, textvariable=self.audio_video_path_stringvar)
        video_audio_path_entry.grid(column=2, row=1, sticky=W)

        # Button
        browse_btn = ttk.Button(master=self.frame, text='Browse', command=self.__on_click_audio_video_browse_btn)
        browse_btn.grid(column=3, row=1, padx=5, sticky=W)

    def __on_click_audio_video_browse_btn(self):
        self.audio_video_path = filedialog.askopenfilename()
        self.audio_video_path = self.audio_video_path.replace('/', '\\')      # Optional step. For Windows, we want to display "\" instead of "/"
        self.audio_video_path_stringvar.set(self.audio_video_path)

    def __create_transcript_path_entry(self):
        # Label
        label = ttk.Label(master=self.frame, text='Transcript Path')
        label.grid(column=1, row=2, padx=(5, 2), pady=5, sticky=W)

        # String var
        self.transcript_path_stringvar = StringVar()
        self.transcript_path_stringvar.set(self.conf.get_transcript_path())

        # Entry
        transcript_path_entry = ttk.Entry(master=self.frame, width=60, textvariable=self.transcript_path_stringvar)
        transcript_path_entry.grid(column=2, row=2, sticky=W)

        # Button
        browse_btn = ttk.Button(master=self.frame, text='Browse', command=self.__on_click_transcript_browse_btn)
        browse_btn.grid(column=3, row=2, padx=5, sticky=W)

    def __on_click_transcript_browse_btn(self):
        self.transcript_path = filedialog.askdirectory()
        self.transcript_path = self.transcript_path.replace('/', '\\')      # Optional step. For Windows, we want to display "\" instead of "/"
        self.transcript_path_stringvar.set(self.transcript_path)

    def __create_language_combobox(self):
        # Label
        label = Label(self.frame, text='Language')
        label.grid(column=1, row=3, padx=(5, 2), pady=5, sticky=W)

        self.lanaguage_stringvar = StringVar()
        self.lanaguage_stringvar.set(self.__get_key_from_dict(languagelist.language_code_dict, self.conf.get_language()))

        # Comboxbox
        combobox = ttk.Combobox(self.frame, state='readonly', values=languagelist.language_list, width=12, textvariable=self.lanaguage_stringvar)
        combobox.grid(column=2, row=3, sticky=W)
        combobox.bind("<<ComboboxSelected>>", self.__change_language)

        # Note
        note = Label(self.frame, text='(must match the language spoken in the audio/video)', justify='left')
        note.config(font=("Calibri", 8))
        note.grid(column=2, row=3, padx=(100, 0), sticky=W)


    def __change_language(self, *args):
        self.conf.set_language(languagelist.language_code_dict[self.lanaguage_stringvar.get()])

    def __get_key_from_dict(self, dictionary, val):
        for key, value in dictionary.items():
            if val == value:
                return key

        return "Key doesn't exist"

    def __create_timestamp_mode_radiobuttons(self):
        # Frame with label
        frame = ttk.LabelFrame(self.frame, text='Timestamp Setting')
        frame.grid(column=1, columnspan=2, row=4, padx=5, sticky=W)

        # Radio buttons
        modes = [
            ('Only Start Time', TIMESTAMP_MODE_ENUM.ONLY_START),
            ('Both Start and End Time', TIMESTAMP_MODE_ENUM.BOTH_START_END)
        ]
        self.timestamp_intstring = IntVar()
        self.timestamp_intstring.set(self.conf.get_timestamp_setting())
        for text, value in modes:
            radio = ttk.Radiobutton(frame, text=text, variable=self.timestamp_intstring,
                                    command=self.__on_click_timestamp_mode_radiobutton, value=value)
            radio.pack(anchor=W, padx=10)

    def __on_click_timestamp_mode_radiobutton(self):
        self.conf.set_timestamp_setting(self.timestamp_intstring.get())

    def __create_silence_setting_entry(self):
        # Frame with label
        frame = ttk.LabelFrame(self.frame, text='Silence Settings')
        frame.grid(column=2, row=4, padx=(120, 0), pady=10, sticky=W)

        ########## Min Silence Length ############

        # Label (Min Silence Length)
        label = Label(frame, text='Min Silence Length (millisecond)')
        label.grid(column=1, row=1, padx=5, pady=5, sticky=W)

        # Function to validate dB value on the entry widget
        is_valid_length = lambda inp: inp.isdigit() or inp == ''
        validate_length = self.controller.register(is_valid_length)

        # Entry (Min Silence Length)
        self.min_silence_length_entry = ttk.Entry(master=frame, width=6, validate = 'key', validatecommand=(validate_length, "%P"))
        self.min_silence_length_entry.insert(0, self.conf.get_min_silence_len_default())
        self.min_silence_length_entry.grid(column=2, row=1, padx=5, pady=5, sticky=W)


        # ########## Max Silence dB ############

        # Label (Max Silence dB)
        label = Label(frame, text='Max Silence dB (dB)')
        label.grid(column=1, row=2, padx=5, sticky=W)

        # Function to validate dB value on the entry widget
        is_valid_dB = lambda inp: inp.isdigit() or inp == '' or inp[0] == '-'
        validate_dB = self.controller.register(is_valid_dB)

        # Entry (Max Silence dB)
        self.max_silence_dB_entry = ttk.Entry(master=frame, width=6, validate = 'key', validatecommand=(validate_dB, "%P"))
        self.max_silence_dB_entry.insert(0, self.conf.get_max_silence_dB_default())
        self.max_silence_dB_entry.grid(column=2, row=2, padx=5, pady=5, sticky=W)

        ########## "Reset To Default Value" Button ############
        reset = ttk.Button(master=frame, text='Reset To Default Values', command=self.__on_click_reset_silence_settings_to_default_btn)
        reset.grid(column=1, columnspan=2, row=3, padx=5, pady=5)

    def __on_click_reset_silence_settings_to_default_btn(self):
        self.min_silence_length_entry.delete(0, END)
        self.min_silence_length_entry.insert(0, self.conf.get_min_silence_len_default())

        self.max_silence_dB_entry.delete(0, END)
        self.max_silence_dB_entry.insert(0, self.conf.get_max_silence_dB_default())

    def __create__start_transcripting_btn(self):
        # Button
        # browse_btn = ttk.Button(master=self.frame, text='Start Transcripting', command=self.__on_click_start_transcripting_btn)
        browse_btn = ttk.Button(master=self.frame, text='Start Transcripting', command=self.__on_click_start_transcripting_btn)
        browse_btn.grid(column=1, row=5, padx=5, pady=10)

    def __on_click_start_transcripting_btn(self):
        # Get paths from Entry and set them to config file
        self.audio_video_path = self.audio_video_path_stringvar.get()
        self.transcript_path = self.transcript_path_stringvar.get()
        self.conf.set_audio_video_path(self.audio_video_path)
        self.conf.set_transcript_path(self.transcript_path)

        # Set inputted value from Silence Setting entries
        self.conf.set_min_silence_len(int(self.min_silence_length_entry.get()))
        self.conf.set_max_silence_dB(int(self.max_silence_dB_entry.get()))

        # Check if video/audio path is enterted
        if self.conf.get_audio_video_path() == '':
            messagebox.showerror('Error', 'Please choose your audio or video!')
            return

        # Disable all widgets on the UI controller before starting transcripting
        self.__disable_children(self.controller)

        # Start transcript process in a worker thread
        self.transcript_thread = TranscriptThread()
        self.transcript_thread.daemon = True   # When the main thread exists, the worker thread will be terminated too
        self.transcript_thread.start()

        # Show progress bar
        self.progress_bar = ProgressBar(self.controller)
        self.progress_bar.create()

        # Timer to check worker thread state after each 20 ms
        self.controller.after(20, self._check_transcript_thread_state)

    def _check_transcript_thread_state(self):
        if self.transcript_thread.is_alive():
            # Timer to check worker thread state after each 20 ms
            self.controller.after(20, self._check_transcript_thread_state)
        else:
            # If the worker thread finishes, destroy the progress bar. And ...
            self.progress_bar.destroy()
            # Enable all widgets on the UI controller when finish transcripting. And ...
            self.__enable_children(self.controller)
            # Display COMPLETE message box
            messagebox.showinfo('Info', 'The transcript process was successful!')
            # TODO: Go to folder transcript

    def __disable_children(self, parent):
        for child in parent.winfo_children():
            wtype = child.winfo_class()
            # Have to exclude these wtype because they do not support 'state' param
            if wtype not in ('Frame', 'TLabelframe'):
                child.configure(state='disabled')
            else:
                self.__disable_children(child)

    def __enable_children(self, parent):
        for child in parent.winfo_children():
            wtype = child.winfo_class()
            # Have to exclude these wtype because they do not support 'state' param
            if wtype not in ('Frame', 'TLabelframe'):
                child.configure(state='normal')
            else:
                self.__enable_children(child)

    def __create_about_btn(self):
        # Button
        about_btn = ttk.Button(master=self.frame, text='About', command=self.__on_click_about_button)
        about_btn.grid(column=3, row=5, padx=5)

    def __on_click_about_button(self):
        about = AboutDialog()
        about.show()