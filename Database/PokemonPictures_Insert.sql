USE [PokedexDB]
GO

INSERT INTO [dbo].[PokemonPictures]
           ([Id]
           ,[InternalId]
           ,[Image])
     VALUES
           (NEWID(), 2, (SELECT * FROM OPENROWSET(BULK N'C:\Users\dzub\Desktop\pikachu.png', SINGLE_BLOB) AS CategoryImage))
GO


