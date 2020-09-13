from tkinter import *
from tkinter import ttk

import time
import threading

def foo():
    time.sleep(3) # simulate some work
    print('1')
    time.sleep(3) # simulate some work
    print('2')
    time.sleep(3) # simulate some work
    print('3')

def start_foo_thread():
    global foo_thread
    foo_thread = threading.Thread(target=foo)
    foo_thread.daemon = True
    progressbar.start(20)
    foo_thread.start()
    root.after(20, check_foo_thread)

def check_foo_thread():
    if foo_thread.is_alive():
        root.after(20, check_foo_thread)
    else:
        progressbar.stop()

root = Tk()
mainframe = ttk.Frame(root, padding="3 3 12 12")
mainframe.grid(column=0, row=0, sticky=(N, W, E, S))
mainframe.columnconfigure(0, weight=1)
mainframe.rowconfigure(0, weight=1)
progressbar = ttk.Progressbar(mainframe, mode='indeterminate')
progressbar.grid(column=1, row=100, sticky=W)

ttk.Button(mainframe, text="Check", command=start_foo_thread).grid(column=1, row=200, sticky=E)


root.mainloop()