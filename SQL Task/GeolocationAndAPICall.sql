ALTER TABLE Address
ADD Geolocation SPATIAL
GO;


-- Create the trigger
CREATE TRIGGER PopulateGeolocation
ON Address
AFTER INSERT
AS
BEGIN
    -- Declare variables to store latitude and longitude
    DECLARE @Latitude FLOAT;
    DECLARE @Longitude FLOAT;
    
    -- Check if latitude and longitude are already provided
    IF NOT EXISTS (
        SELECT 1
        FROM INSERTED
        WHERE Geolocation IS NOT NULL
    )
    BEGIN
        -- For simplicity, I'll set them to example values 
        SET @Latitude = 40.7128; -- Example latitude
        SET @Longitude = -74.0060; -- Example longitude
        
        -- Update the Geolocation field for the inserted rows with the calculated values
        UPDATE Address
        SET Geolocation = geography::Point(@Latitude, @Longitude, 4326)
        FROM INSERTED
        WHERE Address.Id = INSERTED.Id; -- Assuming there is a unique identifier for the Address table

    END
END;
