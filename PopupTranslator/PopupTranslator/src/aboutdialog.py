from tkinter import messagebox

class AboutDialog:
    def show(self):
        text = '''Popup Translator (based on Google Translate API)

Author: Hồ Nhân Trí
License: Free
Version: 1.0
'''

        messagebox.showinfo('About', text)