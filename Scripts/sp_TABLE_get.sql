USE eCollection;


------====================================================------
------====================================================------
-----------------------------userInfo---------------------------
------====================================================------
------====================================================------
GO
ALTER PROCEDURE sp_userInfo_get @userId VARCHAR(50)
AS
	SELECT userId, userName, userLastName,userPhoto, userEmail 
		FROM userInfo 
			WHERE userId = @userId;


------====================================================------
------====================================================------
---------------------------categoryList-------------------------
------====================================================------
------====================================================------
GO 
ALTER PROCEDURE sp_Category_get @categoryId INT = 0
AS
	SELECT categoryId, categoryName, CategoryColor 
		FROM categoryList 
			WHERE categoryId = IIF(@categoryId = 0,categoryId, @categoryId);

------====================================================------
------====================================================------
-----------------------------itemPhoto--------------------------
------====================================================------
------====================================================------
--GO
--CREATE PROCEDURE sp_itemPhoto_get @itemId INT, @itemPhotoId INT = 0
--AS
--	SELECT itemPhotoId, itemPhoto 
--		FROM itemPhoto 
--			WHERE fk_itemId = @itemId AND itemPhotoId = IIF(@itemPhotoId = 0,itemPhotoId, @itemPhotoId);


------====================================================------
------====================================================------
---------------------------itemList-------------------------
------====================================================------
------====================================================------
GO 
CREATE PROCEDURE sp_itemInfo_get @collectionId INT, @itemId INT = 0
AS
	SELECT itemId, itemName, itemCover, LastUpdateDate
		FROM itemInfo
			WHERE fk_collectionId = @collectionId AND itemId = IIF(@itemId = 0, itemId, @itemId);

------====================================================------
------====================================================------
---------------------------collectionInfo-----------------------
------====================================================------
------====================================================------
GO 
ALTER PROCEDURE sp_collectionInfo_Display_get @userId VARCHAR(50)
AS
	SELECT collectionId,collectionCover,collectionName,categories,itemNumberCollection, creationDate,lastUpdateDate, @userId AS fk_userId
		FROM vw_collectionInfo_Display
		WHERE fk_userId = @userId

GO 
CREATE PROCEDURE sp_collectionInfo_get @collectionId INT
AS
	SELECT collectionId,collectionCover,collectionName, totalPrice, creationDate,lastUpdateDate, fk_userId
		FROM collectionInfo
		WHERE collectionId = @collectionId