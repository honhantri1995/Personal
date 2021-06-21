import csv
import random
from faker import Faker
from datetime import datetime
import random as r


l=Faker('en_GB') 
f=open("phonenumber_100M.csv","r")
k=csv.reader(f)

g=open('info1.csv', 'w', encoding='UTF8', newline='')
w=csv.writer(g)
w.writerow(('id','name','phone'))
for i in range(100000000):
    w.writerow((i+1,l.name(),r.randint(1000000000, 9999999999)))

f.close()
