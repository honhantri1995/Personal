from queue import Queue 
from threading import Thread 
import time

# Object that signals shutdown 
is_stop = object() 

# A thread that consumes data 
def worker_thread(in_q):
    i = 0
    while True:
        print("i is " + str(i));
        i += 1
        if i == 5:
            in_q.put(is_stop)
            print("After put is_stop")
            break
        time.sleep(2)
     
    print("End worker thread")


# Create the shared queue and launch both threads 
q = Queue() 

# Start worker thread
t = Thread(target = worker_thread, args =(q, )) 
t.start() 

while True: 
    # Get some data 
    q.put(1)    # without this put, the queue will be empty and the q.get() will wait forever
    data = q.get()
    print("data is " + str(data))
      
    # Check for termination 
    if data is is_stop: 
        print("Get is_stop")
        break
    time.sleep(1)
        
print("End main thread")
