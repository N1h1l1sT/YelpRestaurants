SELECT
	*
FROM [YelpRestaurants].[dbo].[train_photo_vectors_cluster_level1]
WHERE business_id = '5'
ORDER BY cluster_number

SELECT
	*
FROM [YelpRestaurants].[dbo].[train_single_instances]
WHERE business_id = '5'



SELECT
	*
FROM [YelpRestaurants].[dbo].[test_photo_vectors_cluster_level1]
WHERE business_id = '5'
ORDER BY cluster_number

SELECT
	*
FROM [YelpRestaurants].[dbo].[test_single_instances]
WHERE business_id = '5'