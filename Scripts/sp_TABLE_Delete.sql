USE eCollection;

GO
CREATE PROCEDURE sp_itemPhoto_Delete @itemPhotoId INT
AS
	DELETE FROM itemPhoto
		WHERE itemPhotoId = @itemPhotoId

GO
CREATE PROCEDURE sp_CollectionInfo_Delete @collectionId INT
AS
	DELETE FROM collectionInfo
		where collectionId = @collectionId

GO
CREATE PROCEDURE sp_itemInfo_Delete @itemId INT
AS
	DELETE FROM itemInfo
		WHERE itemId = @itemId