SELECT
	*
FROM [YelpRestaurants].[dbo].[train_photo_keypoint_vectors]
WHERE 1 = 1
	  AND business_id = '5'
	  AND photo_id = '3940'
ORDER BY cluster_number

SELECT
	*
FROM [YelpRestaurants].[dbo].[train_photo_vectors_cluster_level1]
WHERE 1 = 1
	  AND business_id = '5'
	  AND photo_id = '3940'


SELECT
	*
FROM [YelpRestaurants].[dbo].[test_photo_keypoint_vectors]
WHERE 1 = 1
	  AND business_id = '092lt'
	  AND photo_id = '96179'
ORDER BY cluster_number

SELECT
	*
FROM [YelpRestaurants].[dbo].[test_photo_vectors_cluster_level1]
WHERE 1 = 1
	  AND business_id = '092lt'
	  AND photo_id = '96179'