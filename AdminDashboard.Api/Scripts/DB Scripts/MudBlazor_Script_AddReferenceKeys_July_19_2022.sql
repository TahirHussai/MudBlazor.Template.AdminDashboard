ALTER TABLE LuSubCategory
ADD CategoryRID INT 
 FOREIGN KEY (CategoryRID) REFERENCES LuCategory(ID)
 GO
 ALTER TABLE LuSubRegion
ADD RegionRID INT 
 FOREIGN KEY (RegionRID) REFERENCES LuRegion(RegionID)