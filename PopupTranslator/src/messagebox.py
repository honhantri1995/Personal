from tkinter import Tk
from tkinter import messagebox

class MessageBox:
    def __init__(self):
        # Hide main window
        root = Tk()
        root.attributes('-topmost', True)     # Always on top
        root.withdraw()

    def show_error(self, msg):
        messagebox.showerror("Error", msg)

    def show_warning(self, msg):
        messagebox.showwarning("Warning", msg)

    def show_info(self, msg):
        messagebox.showinfo("Information", msg)

    # def show_yesnoquestion(self, msg):
    #     return messagebox.askquestion('Question', msg, default='no')