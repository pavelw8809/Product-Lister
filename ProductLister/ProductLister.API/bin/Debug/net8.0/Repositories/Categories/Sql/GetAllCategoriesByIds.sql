SELECT
	categoryid,
	categoryname,
	categorycolor
FROM
	categories
WHERE
	categoryid = ANY(@CategoryIds);