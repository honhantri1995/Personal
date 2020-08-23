import threading
import time

class ExcThread(threading.Thread):
    def run(self):
        self.exc = None
        try:
            a = 1 / 0       # Diviseby0 exception
        except:
            import sys
            self.exc = sys.exc_info()
            print("Exception occur in the worker thread. self.exc is " + str(self.exc))
            # Save details of the exception thrown but don't rethrow,
            # just complete the function

    def func(self):
        print("Enter func")
        if self.exc:
            msg = "Thread '%s' threw an exception: %s" % (self.getName(), self.exc[1])
            new_exc = Exception(msg)
            raise new_exc.with_traceback(self.exc[2])
            
t = ExcThread()
t.start()

while True:
    time.sleep(1)
    try:
        t.func()
        print("No exception")
    except Exception as e:
        print("Catch exception from the main thread. " + str(e))
        
    