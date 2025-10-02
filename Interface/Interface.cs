
// Amir Moeini Rad
// November 2010

// Main Concept: Interfaces in C#.NET

// An interface can inherit from more than one interface.
// Therefore, interfaces help implement multiple inheritance in C#.

using System;


/********************************* Interfaces *********************************/


interface IWritable
{
    void Write(string s);
    void Display();
}


interface IReadable
{
    string ReadLine();
    void Display();
}


// Multiple inheritance among interfaces!
interface IFile : IWritable, IReadable 
{
    void Open(string filename);
    void Close();

    string FileName
    {
        set;
        get;
    }
}


/********************************* Classes *********************************/


// A class can also implement more than one interface at a time.
// Here, MyFile should implement IWritable & IReadable in addition to IFile,
// because IFile inherits from IWritable & IReadable.
class MyFile : IFile
{

    // Implementing IFile interface own methods and its inherited methods
    public void Open(string filename)
    {
        FileName = filename;
        Console.WriteLine("Opening file: {0}", filename);
    }

    public string ReadLine()
    {
        return "Reading a line from MyFile: " + FileName;
    }

    public void Write(string s)
    {
        Console.WriteLine("Writing '{0}' in the file: {1}", s, FileName);
    }

    public void Close()
    {
        Console.WriteLine("Closing the file: {0}", FileName);
    }

    // Explicit implementation
    // Single implementation is also possible depending on the purpose of the methods.
    void IWritable.Display()
    {
        Console.WriteLine("\nHello from IWritable...");
    }

    void IReadable.Display()
    {
        Console.WriteLine("\nHello from IReadable...");
    }

    // Implementing the property (auto property: the new style)
    public string FileName { set; get; }
}


/********************************** Client **********************************/


class Test
{
    static void Main()
    {
        Console.WriteLine("---------------------");
        Console.WriteLine("Interfaces in C#.NET.");
        Console.WriteLine("---------------------\n");


        MyFile aFile = new MyFile();

        aFile.FileName = "csharp.txt";
        aFile.Open(aFile.FileName);
        aFile.Write("My name is Faraz");
        Console.WriteLine(aFile.ReadLine());
        aFile.Close();

        if (aFile is IFile)
        {
            Console.WriteLine("\nMyFile class implemented the IFile interface.");
        }

        // Casting for explicit calls
        
        // This removes other parts of the aFile object, leaving just the IWritable methods.
        // So, you can only call iw.Write() and iw.Display().
        IWritable iw = (IWritable) aFile;
        iw.Display();

        // This removes other parts of the aFile object, leaving just the IReadable methods.
        // So, you can only call ir.ReadLine() and ir.Display().
        IReadable ir = (IReadable) aFile;        
        ir.Display();
        

        Console.WriteLine("\nDone.");
    }
}