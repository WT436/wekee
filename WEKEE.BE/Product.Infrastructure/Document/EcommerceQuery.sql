﻿USE ProductDB

GO
CREATE TYPE page_list_search AS TABLE
(
  ValuesSearch NVARCHAR(MAX),
  PropertySearch NVARCHAR(MAX)
)
GO
CREATE PROC DBO.SELECT_ALL_CONDITIONAL_FULL 
			@page_list_search AS dbo.page_list_search READONLY,
			@PropertyOrder AS VARCHAR(MAX),
			@ValueOrderBy AS NVARCHAR(MAX),
			@PageIndex AS INT,
			@PageSize AS INT
AS
BEGIN
	SELECT * 
	FROM CategoryProduct		
	
END
GO;
	SELECT 
		CP.id AS ID,
		CP.nameCategory,
		CP.urlCategory,
		CP.iconCategory ,	
		CP.levelCategory,
		CP.categoryMain,
		(SELECT nameCategory FROM CategoryProduct where id = CP.categoryMain) AS categoryMainName,
		CP.numberOrder,
		CP.isEnabled,
		CP.CreatedOnUtc,
		CP.UpdatedOnUtc
	FROM CategoryProduct AS CP
	WHERE nameCategory LIKE '%S%'
	AND urlCategory LIKE '%S%'
	ORDER BY id ASC
	OFFSET ((2 - 1) * 2) ROWS
	FETCH NEXT 2 ROWS ONLY;
GO;

DECLARE @query nvarchar(max) = 'SELECT * 
	FROM CategoryProduct
	WHERE nameCategory LIKE ''%s%''
	  AND urlCategory LIKE ''%S%''
	ORDER BY id ASC
		OFFSET ((1 - 1) * 5) ROWS
	FETCH NEXT 5 ROWS ONLY;
	';
EXEC (@query);

SELECT * 
FROM CategoryProduct AS C
WHERE FREETEXT(C.*,'SEARCH')


     SELECT                                                                                           
  		CP.id                 AS 'Id',                                                                
  		CP.nameCategory       AS 'NameCategory',                                                      
  		CP.urlCategory        AS 'UrlCategory',                                                       
  		CP.iconCategory      AS 'IconCategory',                                                      
  		CP.levelCategory     AS 'LevelCategory',                                                     
  		CP.categoryMain      AS 'CategoryMain',                                                      
  		(SELECT nameCategory FROM CategoryProduct where id = CP.categoryMain) AS 'CategoryMainName',  
  		CP.numberOrder        AS 'NumberOrder',                                                       
  		CP.isEnabled          AS 'IsEnabled',                                                         
  		CP.CreatedOnUtc       AS 'CreatedOnUtc',                                                      
  		CP.UpdatedOnUtc       AS 'UpdatedOnUtc '                                                      
  	FROM CategoryProduct      AS CP                                                                
  	WHERE nameCategory LIKE '%S%'                                                                   
  	  AND urlCategory LIKE '%S%'                                                                    
  	ORDER BY id ASC                                                                                 
  	OFFSET((2 - 1) * 2) ROWS   

   SELECT                                                                                           
  		CP.id                 AS 'Id',  
		CP.[key]			  AS 'Key',
		CP.GroupSpecification AS 'GroupSpecification',
        CP.CategoryProductId  AS 'CategoryProductId',
		CP.CreateBy			  AS 'CreateBy',
  		CP.CreatedOnUtc       AS 'CreatedOnUtc',                                                    
  		CP.UpdatedOnUtc       AS 'UpdatedOnUtc '                                                    
  	FROM SpecificationAttribute      AS CP   
	--WHERE [key] LIKE '%S%'                                                                   
  	 -- AND urlCategory LIKE '%S%'      
  ORDER BY Id ASC 
  OFFSET((20 - 1) * 20) ROWS                                                                        
  FETCH NEXT 1 ROWS ONLY                                                                                                                                                                                                                           
  --------------------------------------------------------------------------------------------------
SELECT CP.[Id]			  AS 'Id'
      ,CP.[Name]		  AS 'Name'
      ,CP.[Types]		  AS 'Types'
      ,( SELECT [nameCategory] FROM [CategoryProduct] WHERE id = CP.[CategoryProductId]	)	 AS 'CategoryProductIdName'
      ,CP.[isDelete]	  AS 'IsDelete'
      ,CP.[CreateBy]	  AS 'CreateBy'
      ,CP.[CreatedOnUtc]  AS 'CreatedOnUtc'
      ,CP.[UpdatedOnUtc]  AS 'UpdatedOnUtc'
  FROM [ProductDB].[dbo].[ProductAttribute] AS CP      
  

  SELECT distinct
		 CP.[Id]
		,CP.[Name]
		,CP.[Types]
  FROM  [dbo].[ProductAttribute] AS CP
  WHERE CP.Types = 1 
	AND CP.CreateBy = 0 
	AND CP.isDelete = 0


  SELECT CP.[Id]              AS 'Id'                                                                                        
	    ,CP.[Name]              AS 'Name'                                                                                      
	    ,CP.[Types]             AS 'Types'                                                                                     
	    ,CP.[CategoryProductId] AS 'CategoryProductId'                                                                         
	    ,(SELECT [nameCategory] FROM [CategoryProduct] WHERE id = CP.[CategoryProductId])	 AS 'CategoryProductIdName'        
	    ,CP.[isDelete]          AS 'IsDelete'                                                                                  
	    ,CP.[CreateBy]          AS 'CreateBy'                                                                                  
	    ,CP.[CreatedOnUtc]      AS 'CreatedOnUtc'                                                                              
	    ,CP.[UpdatedOnUtc]      AS 'UpdatedOnUtc'                                                                              
	FROM[ProductDB].[dbo].[ProductAttribute] AS CP                                                                             
 WHERE CAST(CP.CreatedOnUtc AS Date) = '2022-04-05'
  ORDER BY Id ASC 
  OFFSET((1 - 1) * 20) ROWS                                                                        
  FETCH NEXT 20 ROWS ONLY                                                                            
                                                                    
SELECT distinct CP.GroupSpecification 
FROM DBO.SpecificationAttribute AS CP
WHERE CP.CategoryProductId IN (2,3,4) 
AND CP.GroupSpecification!= 'NULL'

SELECT
	  CP.[nameCategory] AS 'NameCategory'
	  ,CP.[urlCategory] AS 'UrlCategory'
	  ,CP.[levelCategory] AS 'LevelCategory'
FROM CategoryProduct AS CP
JOIN Product_Category_Mapping AS PCM ON CP.id = PCM.CategoryId 
JOIN Product AS P ON P.id = PCM.ProductId
WHERE P.id = 1

--------------------------------------------------------------------------------------------------
  SELECT                                                                                  
  	  P.[name]                      AS 'Name'  
  	 ,(SELECT [name] FROM dbo.[ProductAttribute] WHERE id = P.[Trademark] AND Types = 3)  AS 'Trademark'                  
  	 ,P.[FullDescription]           AS 'FullDescription'            
  	 ,P.[ShortDescription]          AS 'ShortDescription'           
  	 ,P.[HasUserAgreement]          AS 'HasUserAgreement'           
  	 ,P.[OrderMinimumQuantity]      AS 'OrderMinimumQuantity'       
  	 ,P.[OrderMaximumQuantity]      AS 'OrderMaximumQuantity'       
  	 ,P.[ShipSeparately]            AS 'ShipSeparately'             
  	 ,P.[IsFreeShipping]            AS 'IsFreeShipping'             
  	 ,P.[BackorderModeId]           AS 'BackorderModeId'            
  	 ,P.[DisableWishlistButton]     AS 'DisableWishlistButton'      
  	 ,P.[WishlistNumber]            AS 'WishlistNumber'             
  	 ,P.[MarkAsNew]                 AS 'MarkAsNew'                  
  	 ,P.[MarkAsNewStartDateTimeUtc] AS 'MarkAsNewStartDateTimeUtc'  
  	 ,P.[MarkAsNewEndDateTimeUtc]   AS 'MarkAsNewEndDateTimeUtc'    
  FROM dbo.[Product]                  AS P                            
  WHERE P.[id] = 1                
  
--------------------------------------------------------------------------------------------------
  SELECT 
		 PSAM.[CustomValue]
		,SPA.[Key]
		,PSAM.[DisplayOrder]
  FROM [Product_SpecificationAttribute_Mapping] AS PSAM
  JOIN [SpecificationAttribute] AS SPA ON PSAM.[SpecificationId] = SPA.[Id]
  WHERE PSAM.[ProductId] = 1 AND PSAM.[ShowOnProductPage] = 1 AND PSAM.[AllowFiltering] = 1
  ORDER BY PSAM.[DisplayOrder] ASC