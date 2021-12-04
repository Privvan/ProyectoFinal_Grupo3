USE [Northwind]
GO

CREATE PROCEDURE [dbo].[SP_LISTAR_REGIONES]
as
begin
SELECT [RegionID]
      ,[RegionDescription]
  FROM [dbo].[Region]
  end
GO


