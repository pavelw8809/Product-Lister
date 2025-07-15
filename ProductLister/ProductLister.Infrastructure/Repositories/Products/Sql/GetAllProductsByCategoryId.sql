WITH selected_products AS (
	SELECT
		p.productid,
		p.productname,
		p.productvendor,
		p.productprice
	FROM products p
	INNER JOIN productcategory pc ON p.productid = pc.productid
	WHERE pc.categoryid = @CategoryId
	ORDER BY p.productid
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