namespace HW2;

public class FileSystemEventArgs : EventArgs
{
    public string Path { get; }

    public bool Exclude { get; set; }
    public bool Abort { get; set; }

    public FileSystemEventArgs(string path)
    {
        Path = path;
        Exclude = false;
        Abort = false;
    }

}