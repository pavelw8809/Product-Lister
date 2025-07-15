UPDATE products
SET
	productname = @ProductName,
	productvendor = @ProductVendor,
	productprice = @ProductPrice
WHERE
	productid = @ProductId;