USE eCollection;

GO
CREATE TRIGGER tr_itemInfo_Insert 
ON itemInfo
AFTER INSERT
AS
	DECLARE @price MONEY;
	DECLARE @id INT;
	SELECT @price = item.marketPrice FROM INSERTED item;
	SELECT @id = item.fk_collectionId FROM INSERTED item;
	UPDATE collectionInfo
	SET totalPrice = (totalPrice + @price)
	WHERE collectionId = @id;
GO

GO
ALTER TRIGGER tr_itemInfo_Update 
ON itemInfo
AFTER UPDATE
AS
	DECLARE @price MONEY;
	DECLARE @id INT;
	SELECT @id = item.fk_collectionId FROM INSERTED item;
	SELECT @price = SUM(marketPrice) FROM itemInfo WHERE fk_collectionId = @id;
	UPDATE collectionInfo
	SET totalPrice = @price
	WHERE collectionId = @id;
GO

GO
ALTER TRIGGER tr_itemInfo_Delete
ON itemInfo
INSTEAD OF DELETE
AS
	
	UPDATE itemPhoto
	SET isActive = 0
		WHERE fk_itemId IN (SELECT itemId FROM deleted );
	UPDATE itemInfo
	SET isActive = 0
		WHERE itemId IN (SELECT itemId FROM deleted );
GO

GO
ALTER TRIGGER tr_collectionInfo_Delete
ON collectionInfo
INSTEAD OF DELETE
AS
	DECLARE @collectionId INT;
	SELECT @collectionId = collectionI.collectionId FROM deleted collectionI;
	UPDATE rel_Category_Collection
	SET isActive = 0
		WHERE fk_collectionId = @collectionId;
	UPDATE collectionInfo
	SET isActive = 0
		WHERE collectionId = @collectionId;
	DELETE itemInfo
		WHERE fk_collectionId = @collectionId;
GO