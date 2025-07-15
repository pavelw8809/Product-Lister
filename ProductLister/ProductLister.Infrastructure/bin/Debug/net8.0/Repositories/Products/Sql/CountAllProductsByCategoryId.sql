SELECT
	COUNT(DISTINCT p.productid)
FROM
	products p
JOIN
	productcategory pc ON p.productid = pc.productid
WHERE
	pc.categoryid = @CategoryId;