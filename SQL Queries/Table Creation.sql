-----------------------------------------------------------------------------------------------------------
CREATE TABLE [YelpRestaurants].[dbo].[test_biz_to_labels]
	(
		[id] [bigint] IDENTITY(1,1) NOT NULL,
		[rectime] [datetime] NULL,
		[business_id] [varchar](10) NULL,
		[labels] [varchar](20) NULL,
		CONSTRAINT [PK_test_biz_to_label] PRIMARY KEY CLUSTERED 
			(
				[id] ASC
			)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]

ALTER TABLE [YelpRestaurants].[dbo].[test_biz_to_labels] ADD  CONSTRAINT [DF_test_biz_to_label_rectime]  DEFAULT (getdate()) FOR [rectime]
-----------------------------------------------------------------------------------------------------------

-----------------------------------------------------------------------------------------------------------
CREATE TABLE [YelpRestaurants].[dbo].[test_photo_keypoint_vectors]
	(
		[id] [bigint] IDENTITY(1,1) NOT NULL,
		[rectime] [datetime] NULL,
		[business_id] [nvarchar](10) NULL,
		[photo_id] [int] NULL,
		[keypoint_id] [smallint] NULL,
		[keypoint_x] [smallint] NULL,
		[keypoint_y] [smallint] NULL,
		[keypoint_radius] [smallint] NULL,
		[keypoint_color_vector] [varchar](max) NULL,
		[cluster_number] [int] NULL,
		CONSTRAINT [PK_test_photo_keypoint_vectors] PRIMARY KEY CLUSTERED 
			(
				[id] ASC
			)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]

ALTER TABLE [YelpRestaurants].[dbo].[test_photo_keypoint_vectors] ADD  CONSTRAINT [DF_test_photo_keypoint_vectors_rectime]  DEFAULT (getdate()) FOR [rectime]

CREATE NONCLUSTERED INDEX [IX_test_photo_keypoint_vectors_1] ON [YelpRestaurants].[dbo].[test_photo_keypoint_vectors] 
	(
		[photo_id] ASC
	) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]

CREATE NONCLUSTERED INDEX [IX_test_photo_keypoint_vectors] ON [YelpRestaurants].[dbo].[test_photo_keypoint_vectors] 
	(
		[business_id] ASC
	) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
-----------------------------------------------------------------------------------------------------------

-----------------------------------------------------------------------------------------------------------
CREATE TABLE [YelpRestaurants].[dbo].[test_photo_to_biz]
	(
		[id] [bigint] IDENTITY(1,1) NOT NULL,
		[rectime] [datetime] NULL,
		[photo_id] [int] NULL,
		[business_id] [nvarchar](10) NULL,
		[to_be_used] [bit] NULL,
		CONSTRAINT [PK_test_photo_to_biz] PRIMARY KEY CLUSTERED 
			(
				[id] ASC
			)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]

ALTER TABLE [YelpRestaurants].[dbo].[test_photo_to_biz] ADD  CONSTRAINT [DF_test_photo_to_biz_rectime]  DEFAULT (getdate()) FOR [rectime]
ALTER TABLE [YelpRestaurants].[dbo].[test_photo_to_biz] ADD  CONSTRAINT [DF_test_photo_to_biz_to_be_used]  DEFAULT ((0)) FOR [to_be_used]
-----------------------------------------------------------------------------------------------------------

-----------------------------------------------------------------------------------------------------------
CREATE TABLE [YelpRestaurants].[dbo].[test_single_instances]
	(
		[id] [bigint] IDENTITY(1,1) NOT NULL,
		[rectime] [datetime] NULL,
		[business_id] [varchar](10) NULL,
		[vector] [varchar](max) NULL,
		CONSTRAINT [PK_test_single_instances] PRIMARY KEY CLUSTERED 
			(
				[id] ASC
			)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]

ALTER TABLE [YelpRestaurants].[dbo].[test_single_instances] ADD  CONSTRAINT [DF_test_single_instances_rectime]  DEFAULT (getdate()) FOR [rectime]
-----------------------------------------------------------------------------------------------------------

-----------------------------------------------------------------------------------------------------------
CREATE TABLE [YelpRestaurants].[dbo].[test_photo_vectors_cluster_level1]
	(
		[id] [bigint] IDENTITY(1,1) NOT NULL,
		[rectime] [datetime] NULL,
		[photo_id] [int] NULL,
		[business_id] [varchar](10) NULL,
		[vector] [varchar](max) NULL,
		[cluster_number] [int] NULL,
		CONSTRAINT [PK_test_photo_vectors_cluster_level1] PRIMARY KEY CLUSTERED 
			(
				[id] ASC
			)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]

ALTER TABLE [YelpRestaurants].[dbo].[test_photo_vectors_cluster_level1] ADD  CONSTRAINT [DF_test_photo_vectors_cluster_level1_rectime]  DEFAULT (getdate()) FOR [rectime]

CREATE NONCLUSTERED INDEX [IX_test_photo_vectors_cluster_level1] ON [YelpRestaurants].[dbo].[test_photo_vectors_cluster_level1] 
	(
		[business_id] ASC
	)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]

CREATE NONCLUSTERED INDEX [IX_test_photo_vectors_cluster_level1_1] ON [YelpRestaurants].[dbo].[test_photo_vectors_cluster_level1] 
	(
		[photo_id] ASC
	)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
-----------------------------------------------------------------------------------------------------------

-----------------------------------------------------------------------------------------------------------
CREATE TABLE [YelpRestaurants].[dbo].[train_biz_to_labels]
	(
		[id] [bigint] IDENTITY(1,1) NOT NULL,
		[rectime] [datetime] NULL,
		[business_id] [int] NULL,
		[labels] [varchar](20) NULL,
		[binary_labels] [varchar](30) NULL,
		CONSTRAINT [PK_train_biz_to_label] PRIMARY KEY CLUSTERED 
			(
				[id] ASC
			)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]

ALTER TABLE [YelpRestaurants].[dbo].[train_biz_to_labels] ADD  CONSTRAINT [DF_train_biz_to_label_rectime]  DEFAULT (getdate()) FOR [rectime]
-----------------------------------------------------------------------------------------------------------

-----------------------------------------------------------------------------------------------------------
CREATE TABLE [YelpRestaurants].[dbo].[train_photo_keypoint_vectors]
	(
		[id] [bigint] IDENTITY(1,1) NOT NULL,
		[rectime] [datetime] NULL,
		[business_id] [int] NULL,
		[photo_id] [int] NULL,
		[keypoint_id] [smallint] NULL,
		[keypoint_x] [smallint] NULL,
		[keypoint_y] [smallint] NULL,
		[keypoint_radius] [smallint] NULL,
		[keypoint_color_vector] [varchar](max) NULL,
		[cluster_number] [int] NULL,
		CONSTRAINT [PK_train_photo_keypoint_vectors] PRIMARY KEY CLUSTERED 
			(
				[id] ASC
			)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]

ALTER TABLE [YelpRestaurants].[dbo].[train_photo_keypoint_vectors] ADD  CONSTRAINT [DF_train_photo_keypoint_vectors_rectime]  DEFAULT (getdate()) FOR [rectime]

CREATE NONCLUSTERED INDEX [IX_train_photo_keypoint_vectors_1] ON [YelpRestaurants].[dbo].[train_photo_keypoint_vectors] 
	(
		[photo_id] ASC
	)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]


CREATE NONCLUSTERED INDEX [IX_train_photo_keypoint_vectors] ON [YelpRestaurants].[dbo].[train_photo_keypoint_vectors] 
	(
		[business_id] ASC
	)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
-----------------------------------------------------------------------------------------------------------

-----------------------------------------------------------------------------------------------------------
CREATE TABLE [YelpRestaurants].[dbo].[train_photo_to_biz]
	(
		[id] [bigint] IDENTITY(1,1) NOT NULL,
		[rectime] [datetime] NULL,
		[photo_id] [int] NULL,
		[business_id] [int] NULL,
		[to_be_used] [bit] NULL,
		CONSTRAINT [PK_train_photo_to_biz] PRIMARY KEY CLUSTERED 
			(
				[id] ASC
			)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]

	ALTER TABLE [YelpRestaurants].[dbo].[train_photo_to_biz] ADD  CONSTRAINT [DF_train_photo_to_biz_rectime]  DEFAULT (getdate()) FOR [rectime]
ALTER TABLE [YelpRestaurants].[dbo].[train_photo_to_biz] ADD  CONSTRAINT [DF_train_photo_to_biz_to_be_used]  DEFAULT ((0)) FOR [to_be_used]
-----------------------------------------------------------------------------------------------------------

-----------------------------------------------------------------------------------------------------------
CREATE TABLE [YelpRestaurants].[dbo].[train_single_instances]
	(
		[id] [bigint] IDENTITY(1,1) NOT NULL,
		[rectime] [datetime] NULL,
		[business_id] [int] NULL,
		[vector] [varchar](max) NULL,
		CONSTRAINT [PK_train_single_instances] PRIMARY KEY CLUSTERED 
			(
				[id] ASC
			)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]
	
ALTER TABLE [YelpRestaurants].[dbo].[train_single_instances] ADD  CONSTRAINT [DF_train_single_instances_rectime]  DEFAULT (getdate()) FOR [rectime]
-----------------------------------------------------------------------------------------------------------

-----------------------------------------------------------------------------------------------------------
CREATE TABLE [YelpRestaurants].[dbo].[train_photo_vectors_cluster_level1]
	(
		[id] [bigint] IDENTITY(1,1) NOT NULL,
		[rectime] [datetime] NULL,
		[photo_id] [int] NULL,
		[business_id] [int] NULL,
		[vector] [varchar](max) NULL,
		[cluster_number] [int] NULL,
		CONSTRAINT [PK_train_photo_vectors] PRIMARY KEY CLUSTERED 
			(
				[id] ASC
			)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [YelpRestaurants].[dbo].[train_photo_vectors_cluster_level1] ADD  CONSTRAINT [DF_train_photo_vectors_rectime]  DEFAULT (getdate()) FOR [rectime]

CREATE NONCLUSTERED INDEX [IX_train_photo_vectors_cluster_level1_1] ON [YelpRestaurants].[dbo].[train_photo_vectors_cluster_level1] 
	(
		[photo_id] ASC
	)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]


CREATE NONCLUSTERED INDEX [IX_train_photo_vectors_cluster_level1] ON [YelpRestaurants].[dbo].[train_photo_vectors_cluster_level1] 
	(
		[business_id] ASC
	)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
-----------------------------------------------------------------------------------------------------------