use eCollection;

--GO
--CREATE PROCEDURE sp_userInfo_Insert @userId VARCHAR(50), @userName VARCHAR(30), @userLastName VARCHAR(30), @userEmail VARCHAR(50), @userPhoto VARCHAR(MAX), @fk_loginTypeId INT
--AS
--INSERT INTO userInfo(userId,userName,userLastName,userEmail,userPhoto,fk_loginTypeId)
--     VALUES(@userId,@userName,@userLastName,@userEmail,@userPhoto, @fk_loginTypeId)
--	SELECT userId, userName,userPhoto FROM userInfo WHERE userId = @userId;


--GO 
--ALTER PROCEDURE sp_collectionInfo_Insert @collectionName VARCHAR(50), @collectionCover VARCHAR(MAX), @fk_userId varchar(50)
--AS
--	INSERT INTO collectionInfo(collectionName,collectionCover,fk_userId)
--		VALUES(@collectionName,@collectionCover,@fk_userId);


--GO 
--CREATE PROCEDURE sp_itemInfo_Insert @itemName VARCHAR(50),@itemDescription VARCHAR(MAX),@itemCover VARCHAR(MAX),
--				@fk_collectionId INT, @acquiredPrice MONEY, @marketPrice MONEY
--AS
--	INSERT INTO itemInfo(itemName,itemDescription,itemCover,fk_collectionId,acquiredPrice,marketPrice)
--     VALUES(@itemName,@itemDescription,@itemCover,@fk_collectionId,@acquiredPrice,@marketPrice);
--GO


--GO 
--CREATE PROCEDURE sp_rel_Category_Collection_Insert @idCollection INT, @idCategory INT
--AS
--IF NOT EXISTS (SELECT * FROM rel_Category_Collection WHERE fk_categoryId = @idCategory AND fk_collectionId = @idCollection)
--	INSERT INTO rel_Category_Collection(fk_categoryId,fk_collectionId)
--		 VALUES(@idCategory,@idCollection);

--GO
--CREATE PROCEDURE sp_itemPhoto_Insert @itemPhoto VARCHAR(MAX), @itemId INT
--AS
--INSERT INTO itemPhoto(itemPhoto,fk_itemId)
--     VALUES(@itemPhoto,@itemId);
--GO

