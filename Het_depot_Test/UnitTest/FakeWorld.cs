public class FakeWorld : IWorld
{
    private DateTime? _now = null;

    public DateTime Now
    {
        get => _now ?? throw new NullReferenceException();
        set => _now = value;
    }

    public void Clear()
    {
        // Console.Clear();
    }

    public void Write(string text)
    {
        // Console.Write(text);
        LinesWritten.Add(text);
    }

    public List<string> LinesWritten { get; } = new();

    public void WriteLine(string line)
    {
        LinesWritten.Add(line);
    }
    
    public List<string> LinesToRead { private get; set; } = new List<string>();

    public string ReadLine()
    {
        string firstLine = LinesToRead[0];
        LinesToRead.RemoveAt(0);
        return firstLine;
    }

    public Dictionary<string, string> Files = new();

    public string ReadAllText(string path)
    {
        return Files[path];
    }

    public void WriteAllText(string path, string contents)
    {
        Files[path] = contents;
    }
}