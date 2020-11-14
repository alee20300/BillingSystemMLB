CREATE TABLE [dbo].[Island]
(
	[IslandId] INT NOT NULL PRIMARY KEY, 
    [AtollId] INT NOT NULL, 
    [IslandName] NCHAR(10) NOT NULL, 
    CONSTRAINT [FK_Island_ToTable] FOREIGN KEY (AtollId) REFERENCES dbo.Atoll (AtollId)
)
