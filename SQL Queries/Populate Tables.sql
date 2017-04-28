-----------------------------------------------------------------------------------------------------------
CREATE TABLE #TempTable
	(
		photo_id INT
		,business_id INT
	)

BULK INSERT #TempTable
FROM 'C:\Progs\YelpRestaurants\train_photo_to_biz_ids.csv\train_photo_to_biz_ids.csv'
WITH 
	(
		FIRSTROW = 2,
		FIELDTERMINATOR = ',',
		ROWTERMINATOR = '0x0a'
	);
	
INSERT INTO [YelpRestaurants].[dbo].[train_photo_to_biz]
	(
		photo_id
		,business_id
	)
SELECT
	photo_id
	,business_id
FROM #TempTable
	
DROP TABLE #TempTable;
GO
-----------------------------------------------------------------------------------------------------------

-----------------------------------------------------------------------------------------------------------
CREATE TABLE #TempTable
	(
		photo_id INT
		,business_id VARCHAR(10)
	)

BULK INSERT #TempTable
FROM 'C:\Progs\YelpRestaurants\test_photo_to_biz.csv\test_photo_to_biz.csv'
WITH 
	(
		FIRSTROW = 2,
		FIELDTERMINATOR = ',',
		ROWTERMINATOR = '0x0a'
	);
	
INSERT INTO [YelpRestaurants].[dbo].[test_photo_to_biz]
	(
		photo_id
		,business_id
	)
SELECT
	photo_id
	,business_id
FROM #TempTable
	
DROP TABLE #TempTable
GO
-----------------------------------------------------------------------------------------------------------

-----------------------------------------------------------------------------------------------------------
CREATE TABLE #TempTable
	(
		business_id INT
		,labels VARCHAR(max)
	)

BULK INSERT #TempTable
FROM 'C:\Progs\YelpRestaurants\train.csv\train.csv'
WITH (
		 FIRSTROW = 2,
		 FIELDTERMINATOR = ',',
		 ROWTERMINATOR = '\n'
	 );
	
INSERT INTO [YelpRestaurants].[dbo].[train_biz_to_labels]
	(
		business_id
		,labels
	)
SELECT
	business_id
	,labels
FROM #TempTable

DROP TABLE #TempTable
GO
-----------------------------------------------------------------------------------------------------------

-----------------------------------------------------------------------------------------------------------
CREATE TABLE #NumbersTable (number INT);
CREATE TABLE #Labels (business_id INT, label INT);
CREATE TABLE #BinaryLabels (business_id INT, label INT);

WITH NumberSequence(number) AS
	(
		SELECT
			1 AS number
		UNION ALL
		SELECT
			number + 1
        FROM NumberSequence
        WHERE number < 4000
	)
	
INSERT INTO #NumbersTable
	(number)
SELECT
	number
FROM NumberSequence OPTION (MaxRecursion 4000)

INSERT INTO #Labels
	(
		business_id
		,label
	)
SELECT
	Table1.number AS business_id
	,label
FROM (
		 SELECT '0' AS label UNION ALL
		 SELECT '1' UNION ALL
		 SELECT '2' UNION ALL
		 SELECT '3' UNION ALL
		 SELECT '4' UNION ALL
		 SELECT '5' UNION ALL
		 SELECT '6' UNION ALL
		 SELECT '7' UNION ALL
		 SELECT '8'
	 ) AS Table2
CROSS JOIN #NumbersTable AS Table1
WHERE 1 = 1
	  AND Table1.number <= 4000
	  AND Table1.number IN (
							   SELECT
								   business_id
							   FROM [YelpRestaurants].[dbo].[train_biz_to_labels]
						   )
ORDER BY business_id, label

;WITH TempData(business_id, label, label_part) AS 
	(
		SELECT
			business_id
			,CONVERT(VARCHAR, LEFT(labels, CHARINDEX(' ', labels + ' ') - 1)) AS label
			,CONVERT(VARCHAR, STUFF(labels, 1, CHARINDEX(' ', labels + ' '), '')) AS label_part
		FROM [YelpRestaurants].[dbo].[train_biz_to_labels]
		UNION ALL
		SELECT
			business_id
			,CONVERT(VARCHAR, LEFT(label_part, CHARINDEX(' ', label_part + ' ') - 1))
			,CONVERT(VARCHAR, STUFF(label_part, 1, CHARINDEX(' ', label_part + ' '), ''))
		FROM TempData
		WHERE label_part > ''
	)

INSERT INTO #BinaryLabels
	(
		business_id
		,label
	)
SELECT
	business_id
	,(
		 CASE WHEN (
					   SELECT
						   '1'
					   FROM TempData AS Table2
					   WHERE 1 = 1
							 AND Table2.business_id = Table1.business_id
							 AND Table2.label = Table1.label
				   ) = '1'
			 THEN '1'
			 ELSE '-1'
		 END
	 ) AS BinaryLabel
FROM #Labels AS Table1
ORDER BY business_id, label

UPDATE Table1
SET Table1.binary_labels = Table2.binary_labels
FROM [YelpRestaurants].[dbo].[train_biz_to_labels] AS Table1
INNER JOIN (
			    SELECT DISTINCT
					Table1.business_id
					,STUFF((
							   SELECT
								   ' ' + CONVERT(VARCHAR, Table2.label)
							   FROM #BinaryLabels AS Table2  
							   WHERE Table2.business_id = Table1.business_id
							   FOR XML PATH ('')  
						  ), 1, 1, '') AS binary_labels
				FROM #BinaryLabels AS Table1
		   ) AS Table2
	ON Table1.business_id = Table2.business_id

DROP TABLE #NumbersTable;
DROP TABLE #Labels;
DROP TABLE #BinaryLabels;
-----------------------------------------------------------------------------------------------------------