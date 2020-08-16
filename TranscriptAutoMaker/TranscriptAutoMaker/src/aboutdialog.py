from tkinter import messagebox

class AboutDialog:
    def show(self):
        text = '''Transcript Auto Maker

Author: Hồ Nhân Trí
License: Free
Version: 1.0
'''

        messagebox.showinfo('About', text)