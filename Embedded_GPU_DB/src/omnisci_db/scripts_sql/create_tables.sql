# Table phonenumber_100M
CREATE TABLE IF NOT EXISTS phonenumber_100M (id INT, name TEXT ENCODING DICT, phone TEXT ENCODING DICT);
COPY phonenumber_100M FROM '/home/omnisci/repo/db/phonenumber_100M.csv';
