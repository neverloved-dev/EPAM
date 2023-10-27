namespace HW2;
using System;
using System.Collections.Generic;
using System.IO;

public class FileSystemVisitor
{
    private readonly string rootPath;
    private readonly Func<string, bool> filter;

    // Events
    public event EventHandler<FileSystemEventArgs> Start;
    public event EventHandler<FileSystemEventArgs> Finish;
    public event EventHandler<FileSystemEventArgs> FileFound;
    public event EventHandler<FileSystemEventArgs> DirectoryFound;
    public event EventHandler<FileSystemEventArgs> FilteredFileFound;
    public event EventHandler<FileSystemEventArgs> FilteredDirectoryFound;

    public FileSystemVisitor(string rootPath, Func<string, bool> filter = null)
    {
        if (!Directory.Exists(rootPath))
            throw new DirectoryNotFoundException("The specified root path does not exist.");

        this.rootPath = rootPath;
        this.filter = filter ?? (path => true); // If no filter is provided, default to returning all items.
    }

    public IEnumerable<string> Traverse()
    {
        OnStart(rootPath);

        foreach (var item in TraverseDirectory(rootPath))
        {
            yield return item;
        }

        OnFinish(rootPath);
    }

    private IEnumerable<string> TraverseDirectory(string directory)
    {
        foreach (var filePath in Directory.GetFiles(directory))
        {
            OnFileFound(filePath);

            if (filter(filePath))
            {
                OnFilteredFileFound(filePath);
                yield return filePath;
            }
        }

        foreach (var subDirectory in Directory.GetDirectories(directory))
        {
            OnDirectoryFound(subDirectory);

            if (filter(subDirectory))
            {
                OnFilteredDirectoryFound(subDirectory);
                yield return subDirectory;
            }

            foreach (var item in TraverseDirectory(subDirectory))
            {
                yield return item;
            }
        }
    }

    protected virtual void OnStart(string path)
    {
        Start?.Invoke(this, new FileSystemEventArgs(path));
    }

    protected virtual void OnFinish(string path)
    {
        Finish?.Invoke(this, new FileSystemEventArgs(path));
    }

    protected virtual void OnFileFound(string path)
    {
        FileFound?.Invoke(this, new FileSystemEventArgs(path));
    }

    protected virtual void OnDirectoryFound(string path)
    {
        DirectoryFound?.Invoke(this, new FileSystemEventArgs(path));
    }

    protected virtual void OnFilteredFileFound(string path)
    {
        FilteredFileFound?.Invoke(this, new FileSystemEventArgs(path));
    }

    protected virtual void OnFilteredDirectoryFound(string path)
    {
        FilteredDirectoryFound?.Invoke(this, new FileSystemEventArgs(path));
    }

    static void Main(string[] args)
    {
        string rootPath = @"C:\users\x0nr\Desktop";

        // Define a filter using a lambda expression
        Func<string, bool> filter = path =>
            !path.EndsWith(".txt", StringComparison.OrdinalIgnoreCase) &&
            !path.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase);

        var fileSystemVisitor = new FileSystemVisitor(rootPath, filter);
        // Subscribe to events
        fileSystemVisitor.Start += (sender, e) => Console.WriteLine($"Start: {e.Path}");
        fileSystemVisitor.Finish += (sender, e) => Console.WriteLine($"Finish: {e.Path}");
        fileSystemVisitor.FileFound += (sender, e) => Console.WriteLine($"FileFound: {e.Path}");
        fileSystemVisitor.DirectoryFound += (sender, e) => Console.WriteLine($"DirectoryFound: {e.Path}");
        fileSystemVisitor.FilteredFileFound += (sender, e) =>
        {
            if (e.Exclude)
            {
                Console.WriteLine($"Excluding File: {e.Path}");
            }
            else
            {
                Console.WriteLine($"FilteredFileFound: {e.Path}");
            }
        };
        fileSystemVisitor.FilteredDirectoryFound += (sender, e) =>
        {
            if (e.Exclude)
            {
                Console.WriteLine($"Excluding Directory: {e.Path}");
            }
            else
            {
                Console.WriteLine($"FilteredDirectoryFound: {e.Path}");
            }

        };

        foreach (var item in fileSystemVisitor.Traverse())
        {
            Console.WriteLine(item);
        } 
    }

}




