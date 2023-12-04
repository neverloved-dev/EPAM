IF OBJECT_ID('PopulateGeolocation','TR') IS NOT NULL
	DROP TRIGGER PopulateGeolocation;
GO

CREATE TRIGGER PopulateGeolocation
ON Address
AFTER INSERT
AS
BEGIN
 
    DECLARE @Latitude FLOAT;
    DECLARE @Longitude FLOAT;
    
    -- Check if latitude and longitude are already provided
    IF NOT EXISTS (
        SELECT 1
        FROM INSERTED
        WHERE Geolocation IS NOT NULL
    )
    BEGIN
        DECLARE @InsertedAddress NVARCHAR(MAX);
        SELECT @InsertedAddress = CONVERT(NVARCHAR(MAX), Geolocation) FROM INSERTED; 
        EXEC ExecutePythonScript @InsertedAddress;
      --  UPDATE A
      --  SET Geolocation = geography::Point(@Latitude, @Longitude, 4326)
      --  FROM Address A
      --  INNER JOIN INSERTED I ON A.Id = I.Id; 
    END
END;
