WITH selected_products AS (
	SELECT
		productid,
		productname,
		productvendor,
		productprice
	FROM products
	WHERE productname ILIKE @ProductName
	ORDER BY productid
	LIMIT @PageSize
	OFFSET (@Page - 1) * @PageSize
)
SELECT
	sp.productid,
	sp.productname,
	sp.productvendor,
	sp.productprice,
	pc.categoryid
FROM selected_products sp
LEFT JOIN productcategory pc ON sp.productid = pc.productid