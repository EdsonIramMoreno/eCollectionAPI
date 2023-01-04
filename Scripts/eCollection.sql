CREATE SCHEMA eCollection;

USE eCollection;

CREATE TABLE loginType(
	loginTypeId INT IDENTITY(1,1) PRIMARY KEY,
	typeName VARCHAR(20)
);

CREATE TABLE categoryList(
	categoryId INT IDENTITY(1,1) PRIMARY KEY,
	categoryName VARCHAR(20) NOT NULL,
	categoryDescription VARCHAR(MAX),
	categoryColor VARCHAR(7) NOT NULL
);

CREATE TABLE userInfo(
	userId VARCHAR(50) PRIMARY KEY,
	userName VARCHAR(30) NOT NULL,
	userLastName VARCHAR(30) NOT NULL,
	userEmail VARCHAR(50) NOT NULL,
	userPhoto VARCHAR(MAX),
	creationDate DATE DEFAULT GETDATE(),
	fk_loginTypeId INT FOREIGN KEY REFERENCES loginType(loginTypeId)
);

CREATE TABLE collectionInfo(
	collectionId INT IDENTITY(1,1) PRIMARY KEY,
	collectionName VARCHAR(50) NOT NULL,
	collectionCover VARCHAR(MAX),
	totalPrice MONEY default 0,
	creationDate DATE DEFAULT GETDATE(),
	lastUpdateDate DATE DEFAULT GETDATE(),
    fk_userId VARCHAR(50) FOREIGN KEY REFERENCES userInfo(userId)
);

CREATE TABLE rel_Category_Collection(
	id INT IDENTITY(1,1) PRIMARY KEY,
	fk_categoryId INT FOREIGN KEY REFERENCES categoryList(categoryId),
	fk_collectionId INT FOREIGN KEY REFERENCES collectionInfo(collectionId)
);

CREATE TABLE itemInfo(
	itemId INT IDENTITY(1,1) PRIMARY KEY,
	itemName VARCHAR(50) NOT NULL,
	itemDescription VARCHAR(MAX),
	marketPrice MONEY default 0,
	acquiredPrice MONEY default 0,
	itemCover VARCHAR(MAX),
	creationDate DATE DEFAULT GETDATE(),
    lastUpdateDate DATE DEFAULT GETDATE(),
	fk_collectionId INT FOREIGN KEY REFERENCES collectionInfo(collectionId)
);

CREATE TABLE itemPhoto(
	itemPhotoId INT IDENTITY(1,1) PRIMARY KEY,
	itemPhoto VARCHAR(MAX),
	fk_itemId INT FOREIGN KEY REFERENCES itemInfo(itemId)
);