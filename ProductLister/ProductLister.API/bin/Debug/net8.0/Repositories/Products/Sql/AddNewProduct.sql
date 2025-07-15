INSERT INTO products
	(productname, productvendor, productprice)
VALUES
	(@ProductName, @ProductVendor, @ProductPrice)
RETURNING productid;