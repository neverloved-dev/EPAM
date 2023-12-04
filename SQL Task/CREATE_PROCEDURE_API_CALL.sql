DROP PROCEDURE IF EXISTS ExecutePythonScript
GO

CREATE PROCEDURE ExecutePythonScript
    @address NVARCHAR(MAX)
AS
BEGIN
    DECLARE @cmd NVARCHAR(MAX);
    DECLARE @cmdFilePath VARCHAR(8000);
    DECLARE @echoCmd VARCHAR(8000);
    DECLARE @executeCmd VARCHAR(8000);

    SET @cmd = 'python "api_call.py" "' + @address + '"';
 SET @cmdFilePath = 'C:\Temp\PythonScript.bat'; -- Modify the path as needed

    -- Construct the commands to write and execute the batch file
    SET @echoCmd = 'echo ' + @cmd + ' > ' + @cmdFilePath;
    SET @executeCmd = 'cmd.exe /C ' + @cmdFilePath;

    -- Write the command to the batch file
    EXEC xp_cmdshell @echoCmd;

    -- Execute the batch file using xp_cmdshell
    EXEC xp_cmdshell @executeCmd;
END;
