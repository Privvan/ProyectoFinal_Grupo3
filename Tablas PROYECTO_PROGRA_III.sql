USE [Northwind]
GO
ALTER PROCEDURE [dbo].[SP_FILTRAR_REGIONES]
(
	@filtro nchar(50)
)
AS
BEGIN
SELECT [RegionID]
      ,[RegionDescription]
  FROM [dbo].[Region]
  WHERE [RegionDescription] like '%' + RTRIM(LTRIM(@filtro)) + '%'
END
GO

EXEC [dbo].[SP_FILTRAR_REGIONES] 'OR'