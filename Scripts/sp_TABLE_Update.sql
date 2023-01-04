USE eCollection;


------====================================================------
------====================================================------
-----------------------------userInfo---------------------------
------====================================================------
------====================================================------
GO
ALTER PROCEDURE sp_userInfo_Update @userId VARCHAR(50), @userName VARCHAR(30), @userLastName VARCHAR(30)		
AS
	UPDATE userInfo
	   SET userName = IIF(@userName = '', userName, @userName)
		  ,userLastName = IIF(@userLastName = '', userLastName, @userLastName)
	 WHERE userId = @userId

	 SELECT userId,userName,userLastName,userPhoto,userEmail 
		FROM userInfo 
			WHERE userId = @userId;
GO

GO
ALTER PROCEDURE sp_userInfo_Photo_Update @userId VARCHAR(50), @userPhoto VARCHAR(MAX)		
AS
	UPDATE userInfo
	   SET userPhoto = IIF(@userPhoto = '', userPhoto, @userPhoto)
	 WHERE userId = @userId

	 SELECT userId,userName,userLastName,userPhoto,userEmail 
		 FROM userInfo 
			WHERE userId = @userId;
GO

------====================================================------
------====================================================------
-----------------------------itemInfo---------------------------
------====================================================------
------====================================================------
GO
ALTER PROCEDURE sp_itemInfo_Update @itemId INT, @itemName VARCHAR(50), @itemDescription VARCHAR(MAX),
				@marketPrice MONEY, @acquiredPrice MONEY, @itemCover VARCHAR(MAX)
AS
UPDATE itemInfo
   SET itemName = IIF(@itemName = '', itemName, @itemName)
      ,itemDescription = IIF(@itemDescription = '', itemDescription, @itemDescription)
      ,marketPrice = IIF(@marketPrice = 0, marketPrice, @marketPrice)
      ,acquiredPrice = IIF(@acquiredPrice = 0, acquiredPrice, acquiredPrice)
      ,itemCover = IIF(@itemCover = '', itemCover, @itemCover)
      ,lastUpdateDate = GETDATE()
 WHERE itemId = @itemId
GO

------====================================================------
------====================================================------
-----------------------------collectionInfo---------------------------
------====================================================------
------====================================================------
GO 
ALTER PROCEDURE sp_collectionInfo_Update @collectionId INT, @collectionName VARCHAR(50), @collectionCover VARCHAR(MAX)
AS
	UPDATE collectionInfo
		SET collectionName = IIF(@collectionName = '', collectionName, @collectionName),
			collectionCover = IIF(@collectionCover = '', collectionCover, @collectionCover),
			lastUpdateDate = GETDATE()
	WHERE collectionId = @collectionId
GO
