DROP DATABASE IF EXISTS shop;

CREATE DATABASE IF NOT EXISTS shop;

USE shop;

-- Table account_admin
DROP TABLE IF EXISTS account_admin;

CREATE TABLE IF NOT EXISTS account_admin(
	username	VARCHAR(20)		NOT NULL,
	password	VARCHAR(20)		NOT NULL,
	PRIMARY KEY	(username)
);

INSERT INTO account_admin
VALUES ('admin', 'admin123');

-- Table account_customer
DROP TABLE IF EXISTS account_customer;

CREATE TABLE IF NOT EXISTS account_customer(
	username	VARCHAR(20)		NOT NULL,
	password	VARCHAR(20)		NOT NULL,
	fullname	VARCHAR(300)	NOT NULL,
	gender		VARCHAR(5)		NOT NULL,
	phone		int				NOT NULL,
	address		VARCHAR(500)	NOT NULL,
	email		VARCHAR(300),
	PRIMARY KEY	(username)
);

INSERT INTO account_customer
VALUES ('anguyen', 'anguyen123', 'Nguyen Van A', 'Male', 0905018523, '12 Ton Duc Thang', 'anguyen@gmail.com'),
 	   ('bpham', 'bpham123', 'Pham Thi B', 'Male', 0927021396, '50 Hoang Dieu', 'bpham@gmail.com');


-- Table category
DROP TABLE IF EXISTS category;

CREATE TABLE IF NOT EXISTS category(
	id		INT					NOT NULL		AUTO_INCREMENT,
	name	VARCHAR(255)		NOT NULL,
	PRIMARY KEY	(id)
);

INSERT INTO category (name)
VALUES ('iPhone'),
	   ('Android'),
	   ('Laptop');

-- Table product
DROP TABLE IF EXISTS product;

CREATE TABLE IF NOT EXISTS product(
	id					INT					NOT NULL		AUTO_INCREMENT,
	category_id			INT					NOT NULL,
	name				VARCHAR(512)		NOT NULL,
	company				VARCHAR(512)		NOT NULL,
	price				FLOAT(20,3)			NOT NULL,
	availability		VARCHAR(20)			NOT NULL,
	description			VARCHAR(2000)		NOT NULL,
	image				VARCHAR(512)		NOT NULL,
	PRIMARY KEY	(id),
	FOREIGN KEY (category_id) REFERENCES category(id) ON DELETE CASCADE
);

INSERT INTO product (category_id, name, company, image, price, availability, description)
VALUES (1, 'iPhone 12 128GB', 'Apple', 'images/1_iphone12_128gb.jpg', 23150000, 'In stock', 'This is iPhone 12 128GB'),
		(1, 'iPhone 11 128GB', 'Apple', 'images/2_iphone11_128gb.jpg', 18150000, 'In stock', 'This is iPhone 11 128GB'),
		(1, 'iPhone XR 64GB', 'Apple', 'images/3_iphoneXR_64gb.jpg', 11950000, 'In stock', 'This is iPhone XR 64GB'),
		(1, 'iPhone 8 256GB', 'Apple', 'images/4_iphone8_256gb.jpg', 11950000, 'Out of stock', 'This is iPhone 8 256GB'),
		(1, 'iPhone 7 Plus 32GB', 'Apple', 'images/5_iphone7plus_32gb.jpg', 8750000, 'Out of stock', 'This is iPhone 7 Plus 32GB'),
		(1, 'iPhone XS Max', 'Apple', 'images/6_iPhoneXSMax.png', 11950000, 'In Stock', 'This is iPhone XS Max 256GB'),
		(1, 'iPhone 12 Promax', 'Apple', 'images/7_iPhone12Promax.jpg', 11950000, 'In Stock', 'This is iPhone 12 ProMax 256GB'),
		(2, 'Samsung Galaxy Note 20', 'Android', 'images/8_SamsungGalaxyNote_20.jpg', 11950000, 'In Stock', 'This is Samsung Note 20 256GB'),
		(2, 'Samsung Galaxy Note 10', 'Android', 'images/9_SamsungGalaxyNote10.jpg', 11950000, 'In Stock', 'This is Samsung Note 10 256GB'),
		(2, 'Samsung Galaxy Note 9', 'Android', 'images/10_SamsungGalaxyNote9.jpg', 11950000, 'In Stock', 'This is Samsung Galaxy Note 9 256GB'),
		(2, 'Mi 10T Ultra', 'Android', 'images/11_Mi10TUltra.jpg', 11950000, 'In Stock', 'This is Xiaomi 256GB'),
		(3, 'Alien Ware', 'Laptop', 'images/12_AlienWare.jpg', 11950000, 'In Stock', 'This is Alien Ware 256GB'),
		(3, 'ASUS UX430U', 'Laptop', 'images/13_ASUSUX430U.jpg', 11950000, 'In Stock', 'This is ASUS 256GB'),
		(3, 'ACER Nitro 5', 'Laptop', 'images/14_ACERNitro5.jpg', 11950000, 'In Stock', 'This is ACER 256GB'),
		(3, 'ROG G531', 'Laptop', 'images/15_ROGG531.jpg', 11950000, 'In Stock', 'This is ROG 256GB');

-- Table product_details
DROP TABLE IF EXISTS product_details;

CREATE TABLE IF NOT EXISTS product_details(
	id					INT					NOT NULL		AUTO_INCREMENT,
	product_id			INT					NOT NULL,
	name				VARCHAR(512)		NOT NULL,
	display				VARCHAR(512),
	cpu					VARCHAR(512),
	ram					VARCHAR(512),
	rom					VARCHAR(512),
	camera_front		VARCHAR(512),
	camera_back			VARCHAR(512),
	os					VARCHAR(512),
	sim					VARCHAR(512),
	security			VARCHAR(512),
	pin					VARCHAR(512),
	color				VARCHAR(512),
	PRIMARY KEY	(id),
	FOREIGN KEY (product_id) REFERENCES product(id) ON DELETE CASCADE
);

INSERT INTO product_details (product_id, name, display, cpu, ram, rom, camera_front, camera_back, os, sim, security, pin, color)
VALUES (1, 'iPhone 12 128GB', 'Super Retina XDR OLED 6.1 inch', 'Apple A14 Bionic', '4 GB', '128 GB', '8MP', '12MP', 'iOS 14', 'Nano-SIM, eSIM', 'FaceID', 'Wireless charge QI, 18W', 'Gold, Pacific Blue, Silver, Graphite'),
		(2, 'iPhone 11 128GB', 'Super Retina XDR OLED 6.1 inch', 'Apple A14 Bionic', '4 GB', '128 GB', '8MP', '12MP', 'iOS 14', 'Nano-SIM, eSIM', 'FaceID', 'Wireless charge QI, 18W', 'Gold, Pacific Blue, Silver, Graphite'),
		(3, 'iPhone XR 64GB', 'Super Retina XDR OLED 6.1 inch', 'Apple A14 Bionic', '4 GB', '128 GB', '8MP', '12MP', 'iOS 14', 'Nano-SIM, eSIM', 'FaceID', 'Wireless charge QI, 18W', 'Gold, Pacific Blue, Silver, Graphite'),
		(4, 'iPhone 8 256GB', 'Super Retina XDR OLED 6.1 inch', 'Apple A14 Bionic', '4 GB', '128 GB', '8MP', '12MP', 'iOS 14', 'Nano-SIM, eSIM', 'FaceID', 'Wireless charge QI, 18W', 'Gold, Pacific Blue, Silver, Graphite'),
		(5, 'iPhone 7 Plus 32GB', 'Super Retina XDR OLED 6.1 inch', 'Apple A14 Bionic', '4 GB', '128 GB', '8MP', '12MP', 'iOS 14', 'Nano-SIM, eSIM', 'FaceID', 'Wireless charge QI, 18W', 'Gold, Pacific Blue, Silver, Graphite'),
		(6, 'iPhone XS Max', 'Super Retina XDR OLED 6.1 inch', 'Apple A14 Bionic', '4 GB', '128 GB', '8MP', '12MP', 'iOS 14', 'Nano-SIM, eSIM', 'FaceID', 'Wireless charge QI, 18W', 'Gold, Pacific Blue, Silver, Graphite'),
		(7, 'iPhone 12 Promax', 'Super Retina XDR OLED 6.1 inch', 'Apple A14 Bionic', '4 GB', '128 GB', '8MP', '12MP', 'iOS 14', 'Nano-SIM, eSIM', 'FaceID', 'Wireless charge QI, 18W', 'Gold, Pacific Blue, Silver, Graphite'),
		(8, 'Samsung Galaxy Note 20', 'Super Retina XDR OLED 6.1 inch', 'Apple A14 Bionic', '4 GB', '128 GB', '8MP', '12MP', 'iOS 14', 'Nano-SIM, eSIM', 'FaceID', 'Wireless charge QI, 18W', 'Gold, Pacific Blue, Silver, Graphite'),
		(9, 'Samsung Galaxy Note 10', 'Super Retina XDR OLED 6.1 inch', 'Apple A14 Bionic', '4 GB', '128 GB', '8MP', '12MP', 'iOS 14', 'Nano-SIM, eSIM', 'FaceID', 'Wireless charge QI, 18W', 'Gold, Pacific Blue, Silver, Graphite'),
		(10, 'Samsung Galaxy Note 9', 'Super Retina XDR OLED 6.1 inch', 'Apple A14 Bionic', '4 GB', '128 GB', '8MP', '12MP', 'iOS 14', 'Nano-SIM, eSIM', 'FaceID', 'Wireless charge QI, 18W', 'Gold, Pacific Blue, Silver, Graphite');

-- Table product_orders
DROP TABLE IF EXISTS product_orders;

CREATE TABLE IF NOT EXISTS product_orders(
	id					INT					NOT NULL		AUTO_INCREMENT,
	product_id			INT					NOT NULL,
	customer_username	VARCHAR(20)			NOT NULL,
	quantity			INT					NOT NULL,
	total_price			FLOAT(20,3)			NOT NULL,
	PRIMARY KEY	(id),
	FOREIGN KEY (product_id) REFERENCES product(id) ON DELETE CASCADE,
	FOREIGN KEY (customer_username) REFERENCES account_customer(username) ON DELETE CASCADE
);

INSERT INTO product_orders
VALUES (1, 1, 'anguyen', 2, 50000000),
	   (2, 2, 'bpham', 3, 70000000);