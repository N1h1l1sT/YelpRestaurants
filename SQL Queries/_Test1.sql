SELECT
	cluster_number
	,COUNT(*) AS cluster_count
FROM [YelpRestaurants].[dbo].[train_photo_keypoint_vectors]
GROUP BY cluster_number
ORDER BY cluster_number

SELECT
	cluster_number
	,COUNT(*) AS cluster_count
FROM [YelpRestaurants].[dbo].[test_photo_keypoint_vectors]
GROUP BY cluster_number
ORDER BY cluster_number