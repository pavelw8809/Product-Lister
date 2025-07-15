CREATE TABLE categories (
    categoryid UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    categoryname VARCHAR(30) NOT NULL,
    categorycolor VARCHAR(7) NOT NULL
);

CREATE TABLE products (
    productid UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    productname VARCHAR(50) NOT NULL,
    productvendor VARCHAR(30),
    productprice DECIMAL
);

CREATE TABLE productcategory (
    productid UUID NOT NULL,
    categoryid UUID NOT NULL,
    PRIMARY KEY (productid, categoryid),
    FOREIGN KEY (productid) REFERENCES products(productid),
    FOREIGN KEY (categoryid) REFERENCES categories(categoryid)
);

INSERT INTO categories (categoryid, categoryname, categorycolor) VALUES
('9d0f1a87-bc73-41f5-a97a-5f8fcb60e1e1', 'Electronics', '#1F8EF1'),
('7f40c92d-7646-4d93-bad4-e325a984e137', 'Home & Garden', '#28B463'),
('e49c5bb2-2e18-437e-8f08-0d83c5d22f48', 'Fashion', '#FF5733'),
('bd890b94-c0e8-42c4-9e75-860aad1e1051', 'Sports', '#F1C40F'),
('5356f9b8-63cb-4ff7-a5e9-d70fcfe10e29', 'Toys', '#8E44AD'),
('4c4b60ab-737c-45ac-98d7-78d11e98a154', 'Books', '#34495E'),
('55b17640-aab6-4dc5-9678-420ea3dd5dc5', 'Music', '#E74C3C'),
('f5a074ec-7a09-42f5-9355-3f3f191e7112', 'Office Supplies', '#5D6D7E'),
('1a326f4f-f98c-4cd7-a381-05de7f216492', 'Automotive', '#2ECC71'),
('d3f20a34-a601-4a1f-bb77-d31a41c3f459', 'Games', '#9B59B6'),
('2736a1d2-1b8b-4bdb-a23e-93d359979d6d', 'Health', '#F39C12'),
('a0429d8b-fcd6-4f93-8d13-a6af7255bc72', 'Beauty', '#EC7063'),
('e95e56bd-c5df-4d6f-af1d-814fd6ec9115', 'Grocery', '#1ABC9C'),
('ffb71b81-6111-495e-a9fe-b2c1e87e6e8e', 'Appliances', '#D35400'),
('37652d86-dacf-4a1b-9fce-a508d22c0586', 'Handmade', '#7D3C98');

INSERT INTO products (productid, productname, productvendor, productprice) VALUES
('ec1a51d1-2930-42b3-9cf7-0001a1d78501', 'Smartwatch Zeno X2', 'ZenoTech', 499.99),
('ec1a51d1-2930-42b3-9cf7-0001a1d78502', 'Bluetooth Speaker WaveMini', 'SoundCore', 89.99),
('ec1a51d1-2930-42b3-9cf7-0001a1d78503', 'Eco Bamboo Toothbrush Set', 'GreenLife', 12.90),
('ec1a51d1-2930-42b3-9cf7-0001a1d78504', 'SlimFit Men’s Shirt', 'ModaLux', 89.90),
('ec1a51d1-2930-42b3-9cf7-0001a1d78505', 'Leather Wallet RFID-Protected', 'StyleForge', 49.50),
('ec1a51d1-2930-42b3-9cf7-0001a1d78506', 'Gaming Mouse Phantom GX', 'ClickPro', 59.90),
('ec1a51d1-2930-42b3-9cf7-0001a1d78507', 'Cookware Set Stainless Steel', 'KitchenPlus', 229.50),
('ec1a51d1-2930-42b3-9cf7-0001a1d78508', 'LED Desk Lamp Flexi', 'BrightLite', 39.80),
('ec1a51d1-2930-42b3-9cf7-0001a1d78509', 'Mountain Bike Vortex 21', 'BikeWorld', 1599.90),
('ec1a51d1-2930-42b3-9cf7-0001a1d78510', 'Children’s Puzzle Jungle Quest', 'HappyToy', 24.90),
('ec1a51d1-2930-42b3-9cf7-0001a1d78511', 'Acoustic Guitar Strato A5', 'SoundWave', 319.00),
('ec1a51d1-2930-42b3-9cf7-0001a1d78512', 'Notebook 200 Pages Spiral Bound', 'OfficeBasics', 4.75),
('ec1a51d1-2930-42b3-9cf7-0001a1d78513', 'Organic Chamomile Tea 25 Bags', 'TeaSpring', 6.50),
('ec1a51d1-2930-42b3-9cf7-0001a1d78514', 'Hair Dryer TurboStyle 2400W', 'BeautyMax', 89.99),
('ec1a51d1-2930-42b3-9cf7-0001a1d78515', 'Washing Machine AquaSpin 8kg', 'HomePro', 1249.00),
('ec1a51d1-2930-42b3-9cf7-0001a1d78516', 'Handmade Wool Scarf', 'CraftedByEve', 39.90),
('ec1a51d1-2930-42b3-9cf7-0001a1d78517', 'Novel “The Silent Island”', 'NorthWind Books', 19.99),
('ec1a51d1-2930-42b3-9cf7-0001a1d78518', 'Yoga Mat Non-Slip ProFit', 'MoveMore', 45.00),
('ec1a51d1-2930-42b3-9cf7-0001a1d78519', 'Face Cream Vitamin E', 'GlowSkin', 14.90),
('ec1a51d1-2930-42b3-9cf7-0001a1d78520', 'Toy Car Remote Control', 'ZoomToys', 32.95),
('ec1a51d1-2930-42b3-9cf7-0001a1d78521', 'USB-C Charging Cable 1m', 'QuickCharge', 7.99),
('ec1a51d1-2930-42b3-9cf7-0001a1d78522', 'Running Shoes AeroFly', 'SprintStar', 109.00),
('ec1a51d1-2930-42b3-9cf7-0001a1d78523', 'E-Book Reader LumiBook', 'TechNest', 699.00),
('ec1a51d1-2930-42b3-9cf7-0001a1d78524', 'Lawn Mower EcoBlade 1500W', 'GardenEdge', 569.00),
('ec1a51d1-2930-42b3-9cf7-0001a1d78525', 'Fiction Book “Lost Horizons”', 'Booktique', 23.00),
('ec1a51d1-2930-42b3-9cf7-0001a1d78526', 'Bluetooth Headphones Zenith', 'WaveTune', 249.90),
('ec1a51d1-2930-42b3-9cf7-0001a1d78527', 'Protein Powder Vanilla Boost', 'NutriCore', 59.00),
('ec1a51d1-2930-42b3-9cf7-0001a1d78528', 'Makeup Brush Set 12pcs', 'GlamUp', 34.90),
('ec1a51d1-2930-42b3-9cf7-0001a1d78529', 'Electric Kettle Glass 1.7L', 'HotBrew', 89.00),
('ec1a51d1-2930-42b3-9cf7-0001a1d78530', 'Handmade Ceramic Vase', 'ClayWorld', 59.50),
('ec1a51d1-2930-42b3-9cf7-0001a1d78531', 'Notebook i5 14" 8GB RAM', 'QuickTech', 2499.00),
('ec1a51d1-2930-42b3-9cf7-0001a1d78532', 'Garden Shovel Steel Handle', 'GreenWay', 37.75),
('ec1a51d1-2930-42b3-9cf7-0001a1d78533', 'Sunglasses Polarized Aviator', 'VisionPro', 69.00),
('ec1a51d1-2930-42b3-9cf7-0001a1d78534', 'Electric Guitar Blaze V2', 'RhythmNation', 499.00),
('ec1a51d1-2930-42b3-9cf7-0001a1d78535', 'Eraser Set Colored 10pcs', 'WriteSmart', 2.99),
('ec1a51d1-2930-42b3-9cf7-0001a1d78536', 'Car Phone Mount Magnetic', 'AutoZone', 19.90),
('ec1a51d1-2930-42b3-9cf7-0001a1d78537', 'Strategy Board Game: HexaForce', 'PlayHive', 49.90),
('ec1a51d1-2930-42b3-9cf7-0001a1d78538', 'Digital Thermometer InfraScan', 'MediHealth', 24.00),
('ec1a51d1-2930-42b3-9cf7-0001a1d78539', 'Lipstick Ruby Glow', 'MakeMeUp', 16.90),
('ec1a51d1-2930-42b3-9cf7-0001a1d78540', 'Microwave Oven Compact 20L', 'CookEase', 449.00),
('ec1a51d1-2930-42b3-9cf7-0001a1d78541', 'Candle Scented Lavender', 'AromaHome', 15.00),
('ec1a51d1-2930-42b3-9cf7-0001a1d78542', 'Smartphone Case Silicone Blue', 'CoverZone', 19.90),
('ec1a51d1-2930-42b3-9cf7-0001a1d78543', 'Multivitamins Daily Pack', 'VitaCore', 21.90);

INSERT INTO productcategory (productid, categoryid) VALUES
-- Smartwatch Zeno X2
('ec1a51d1-2930-42b3-9cf7-0001a1d78501', '9d0f1a87-bc73-41f5-a97a-5f8fcb60e1e1'),
('ec1a51d1-2930-42b3-9cf7-0001a1d78501', 'bd890b94-c0e8-42c4-9e75-860aad1e1051'),

-- Bluetooth Speaker WaveMini
('ec1a51d1-2930-42b3-9cf7-0001a1d78502', '9d0f1a87-bc73-41f5-a97a-5f8fcb60e1e1'),
('ec1a51d1-2930-42b3-9cf7-0001a1d78502', '55b17640-aab6-4dc5-9678-420ea3dd5dc5'),

-- Eco Bamboo Toothbrush Set
('ec1a51d1-2930-42b3-9cf7-0001a1d78503', '2736a1d2-1b8b-4bdb-a23e-93d359979d6d'),
('ec1a51d1-2930-42b3-9cf7-0001a1d78503', 'e95e56bd-c5df-4d6f-af1d-814fd6ec9115'),

-- SlimFit Men’s Shirt
('ec1a51d1-2930-42b3-9cf7-0001a1d78504', 'e49c5bb2-2e18-437e-8f08-0d83c5d22f48'),
('ec1a51d1-2930-42b3-9cf7-0001a1d78504', 'a0429d8b-fcd6-4f93-8d13-a6af7255bc72'),

-- Leather Wallet RFID-Protected
('ec1a51d1-2930-42b3-9cf7-0001a1d78505', 'e49c5bb2-2e18-437e-8f08-0d83c5d22f48'),

-- Gaming Mouse Phantom GX
('ec1a51d1-2930-42b3-9cf7-0001a1d78506', 'd3f20a34-a601-4a1f-bb77-d31a41c3f459'),
('ec1a51d1-2930-42b3-9cf7-0001a1d78506', '9d0f1a87-bc73-41f5-a97a-5f8fcb60e1e1'),

-- Cookware Set Stainless Steel
('ec1a51d1-2930-42b3-9cf7-0001a1d78507', '7f40c92d-7646-4d93-bad4-e325a984e137'),
('ec1a51d1-2930-42b3-9cf7-0001a1d78507', 'ffb71b81-6111-495e-a9fe-b2c1e87e6e8e'),

-- LED Desk Lamp Flexi
('ec1a51d1-2930-42b3-9cf7-0001a1d78508', 'f5a074ec-7a09-42f5-9355-3f3f191e7112'),

-- Mountain Bike Vortex 21
('ec1a51d1-2930-42b3-9cf7-0001a1d78509', 'bd890b94-c0e8-42c4-9e75-860aad1e1051'),
('ec1a51d1-2930-42b3-9cf7-0001a1d78509', '1a326f4f-f98c-4cd7-a381-05de7f216492'),

-- Children’s Puzzle Jungle Quest
('ec1a51d1-2930-42b3-9cf7-0001a1d78510', '5356f9b8-63cb-4ff7-a5e9-d70fcfe10e29'),

-- Acoustic Guitar Strato A5
('ec1a51d1-2930-42b3-9cf7-0001a1d78511', '55b17640-aab6-4dc5-9678-420ea3dd5dc5'),

-- Notebook Spiral Bound
('ec1a51d1-2930-42b3-9cf7-0001a1d78512', 'f5a074ec-7a09-42f5-9355-3f3f191e7112'),

-- Organic Chamomile Tea
('ec1a51d1-2930-42b3-9cf7-0001a1d78513', 'e95e56bd-c5df-4d6f-af1d-814fd6ec9115'),
('ec1a51d1-2930-42b3-9cf7-0001a1d78513', '2736a1d2-1b8b-4bdb-a23e-93d359979d6d'),

-- Hair Dryer TurboStyle
('ec1a51d1-2930-42b3-9cf7-0001a1d78514', 'a0429d8b-fcd6-4f93-8d13-a6af7255bc72'),
('ec1a51d1-2930-42b3-9cf7-0001a1d78514', 'ffb71b81-6111-495e-a9fe-b2c1e87e6e8e'),

-- Washing Machine AquaSpin
('ec1a51d1-2930-42b3-9cf7-0001a1d78515', 'ffb71b81-6111-495e-a9fe-b2c1e87e6e8e'),

-- Handmade Wool Scarf
('ec1a51d1-2930-42b3-9cf7-0001a1d78516', 'e49c5bb2-2e18-437e-8f08-0d83c5d22f48'),
('ec1a51d1-2930-42b3-9cf7-0001a1d78516', '37652d86-dacf-4a1b-9fce-a508d22c0586'),

-- Novel “The Silent Island”
('ec1a51d1-2930-42b3-9cf7-0001a1d78517', '4c4b60ab-737c-45ac-98d7-78d11e98a154'),

-- Yoga Mat ProFit
('ec1a51d1-2930-42b3-9cf7-0001a1d78518', 'bd890b94-c0e8-42c4-9e75-860aad1e1051'),

-- Face Cream Vitamin E
('ec1a51d1-2930-42b3-9cf7-0001a1d78519', 'a0429d8b-fcd6-4f93-8d13-a6af7255bc72'),

-- Toy Car Remote
('ec1a51d1-2930-42b3-9cf7-0001a1d78520', '5356f9b8-63cb-4ff7-a5e9-d70fcfe10e29'),

-- Charging Cable
('ec1a51d1-2930-42b3-9cf7-0001a1d78521', '9d0f1a87-bc73-41f5-a97a-5f8fcb60e1e1'),

-- Running Shoes AeroFly
('ec1a51d1-2930-42b3-9cf7-0001a1d78522', 'bd890b94-c0e8-42c4-9e75-860aad1e1051'),

-- E-Book Reader LumiBook
('ec1a51d1-2930-42b3-9cf7-0001a1d78523', '4c4b60ab-737c-45ac-98d7-78d11e98a154'),
('ec1a51d1-2930-42b3-9cf7-0001a1d78523', '9d0f1a87-bc73-41f5-a97a-5f8fcb60e1e1'),

-- Lawn Mower EcoBlade
('ec1a51d1-2930-42b3-9cf7-0001a1d78524', '7f40c92d-7646-4d93-bad4-e325a984e137'),

-- “Lost Horizons” Book
('ec1a51d1-2930-42b3-9cf7-0001a1d78525', '4c4b60ab-737c-45ac-98d7-78d11e98a154'),

-- Bluetooth Headphones Zenith
('ec1a51d1-2930-42b3-9cf7-0001a1d78526', '55b17640-aab6-4dc5-9678-420ea3dd5dc5'),
('ec1a51d1-2930-42b3-9cf7-0001a1d78526', '9d0f1a87-bc73-41f5-a97a-5f8fcb60e1e1'),

-- Protein Powder Vanilla Boost
('ec1a51d1-2930-42b3-9cf7-0001a1d78527', '2736a1d2-1b8b-4bdb-a23e-93d359979d6d'),
('ec1a51d1-2930-42b3-9cf7-0001a1d78527', 'bd890b94-c0e8-42c4-9e75-860aad1e1051'),

-- Makeup Brush Set
('ec1a51d1-2930-42b3-9cf7-0001a1d78528', 'a0429d8b-fcd6-4f93-8d13-a6af7255bc72'),

-- Electric Kettle
('ec1a51d1-2930-42b3-9cf7-0001a1d78529', 'ffb71b81-6111-495e-a9fe-b2c1e87e6e8e'),
('ec1a51d1-2930-42b3-9cf7-0001a1d78529', '7f40c92d-7646-4d93-bad4-e325a984e137'),

-- Ceramic Vase Handmade
('ec1a51d1-2930-42b3-9cf7-0001a1d78530', '37652d86-dacf-4a1b-9fce-a508d22c0586'),

-- Notebook i5
('ec1a51d1-2930-42b3-9cf7-0001a1d78531', '9d0f1a87-bc73-41f5-a97a-5f8fcb60e1e1'),

-- Garden Shovel
('ec1a51d1-2930-42b3-9cf7-0001a1d78532', '7f40c92d-7646-4d93-bad4-e325a984e137'),

-- Sunglasses Polarized Aviator
('ec1a51d1-2930-42b3-9cf7-0001a1d78533', 'e49c5bb2-2e18-437e-8f08-0d83c5d22f48'),

-- Electric Guitar Blaze V2
('ec1a51d1-2930-42b3-9cf7-0001a1d78534', '55b17640-aab6-4dc5-9678-420ea3dd5dc5'),

-- Eraser Set
('ec1a51d1-2930-42b3-9cf7-0001a1d78535', 'f5a074ec-7a09-42f5-9355-3f3f191e7112'),

-- Car Phone Mount
('ec1a51d1-2930-42b3-9cf7-0001a1d78536', '1a326f4f-f98c-4cd7-a381-05de7f216492'),

-- Strategy Board Game: HexaForce
('ec1a51d1-2930-42b3-9cf7-0001a1d78537', 'd3f20a34-a601-4a1f-bb77-d31a41c3f459'),

-- Digital Thermometer
('ec1a51d1-2930-42b3-9cf7-0001a1d78538', '2736a1d2-1b8b-4bdb-a23e-93d359979d6d'),

-- Lipstick Ruby Glow
('ec1a51d1-2930-42b3-9cf7-0001a1d78539', 'a0429d8b-fcd6-4f93-8d13-a6af7255bc72'),

-- Microwave Oven
('ec1a51d1-2930-42b3-9cf7-0001a1d78540', 'ffb71b81-6111-495e-a9fe-b2c1e87e6e8e'),

-- Scented Candle Lavender
('ec1a51d1-2930-42b3-9cf7-0001a1d78541', '7f40c92d-7646-4d93-bad4-e325a984e137'),

-- Smartphone Case
('ec1a51d1-2930-42b3-9cf7-0001a1d78542', '9d0f1a87-bc73-41f5-a97a-5f8fcb60e1e1'),

-- Multivitamins Daily Pack
('ec1a51d1-2930-42b3-9cf7-0001a1d78543', '2736a1d2-1b8b-4bdb-a23e-93d359979d6d');