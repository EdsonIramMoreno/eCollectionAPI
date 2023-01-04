USE eCollection;

GO
ALTER VIEW vw_collectionInfo_Display
AS
	WITH categoriesList(collectionId, categories)
	AS
		(
			SELECT TOP 5 CLN.collectionId, STRING_AGG(CAT.categoryName, ', ') 
				WITHIN GROUP (ORDER BY CAT.categoryName) AS categories
					FROM rel_Category_Collection AS REL
					INNER JOIN collectionInfo AS CLN ON CLN.collectionId = REL.fk_collectionId
					INNER JOIN categoryList AS CAT ON CAT.categoryId = REL.fk_categoryId
				GROUP BY CLN.collectionId
		),
		categoriesItemNumber(collectionId, itemNumberCollection)
	AS
		(
			SELECT CLN.collectionId, COUNT(1) itemNumberCollection
			FROM collectionInfo CLN
			INNER JOIN itemInfo ITEM ON ITEM.fk_collectionId = CLN.collectionId
			GROUP BY CLN.collectionId
		)
	SELECT 
			CLN.collectionId, 
			CLN.collectionCover, 
			CLN.collectionName, 
			CATs.categories, 
			CLN.creationDate,
			CLN.lastUpdateDate, 
			ITEM.itemNumberCollection,CLN.fk_userId
		FROM collectionInfo CLN
		INNER JOIN categoriesList CATs ON CATs.collectionId = CLN.collectionId
		INNER JOIN categoriesItemNumber ITEM ON ITEM.collectionId = CLN.collectionId