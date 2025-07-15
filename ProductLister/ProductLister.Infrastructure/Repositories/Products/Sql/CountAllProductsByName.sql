SELECT
	COUNT(*)
FROM
	products
WHERE
	productname ILIKE @ProductName;