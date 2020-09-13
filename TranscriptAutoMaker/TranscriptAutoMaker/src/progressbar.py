from tkinter import Toplevel
from tkinter import ttk

class ProgressBar:
    def __init__(self, master):
        self.master = master
        self.exc_info = None

    def create(self):
        self.__create_window()
        self.__create_label()
        self.__create_progressbar()
        # TODO: Support stop button
        # self.__create_stop_btn()

        # Because we use Toplevel() instead of Tk(), we don't need root.mainloop() here
        # self.root.mainloop()

    def destroy(self):
        self.root.destroy()

    def __create_window(self):
        self.root = Toplevel(self.master)
        self.root.title('Transcripting ...')
        self.root.focus_set()                 # Set focus on this widget
        self.root.resizable(0, 0)             # Prevent resize the window
        self.__set_window_size_and_position()

    def __set_window_size_and_position(self):
        # Size
        width = 320
        height = 100

        # Always center the window to the screen
        x = (self.root.winfo_screenwidth() // 2) - (width // 2)
        y = (self.root.winfo_screenheight() // 2) - (height // 2)

        self.root.geometry('{}x{}+{}+{}'.format(width, height, x, y))

    def __create_label(self):
        label = ttk.Label(master=self.root, text='Transcripting... Please wait for a few minutes!')
        label.grid(column=1, row=1, padx=10, pady=5)

    def __create_progressbar(self):
        self.pb = ttk.Progressbar(self.root, length=300, mode='indeterminate')       # Marquee style
        self.pb.grid(column=1, row=2, padx=10, pady=5)
        self.pb.start(20)

    def __create_stop_btn(self):
        stop_btn = ttk.Button(master=self.root, text='Stop', command=self.__on_click_stop_btn)
        stop_btn.grid(column=1, row=3, padx=10, pady=5)

    def __on_click_stop_btn(self):
        # TODO: If support stop button, modify code here
        self.root.destroy()