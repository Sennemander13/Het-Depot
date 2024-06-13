public class RealWorld : IWorld
{
    public DateTime test = DateTime.Now;
    public DateTime Now
    {
        get
        {
            return new DateTime(test.Year, test.Month, 13, 16, 00, test.Second, test.Millisecond);
        }

        // get => test;
    }

    public void WriteLine(string line)
    {
        Console.WriteLine(line);
    }

    public string ReadLine()
    {
        return Console.ReadLine()!;
    }

    public void Clear()
    {
        Console.Clear();
    }

    public string ReadAllText(string path)
    {
        return File.ReadAllText(path);
    }

    public void WriteAllText(string path, string contents)
    {
        File.WriteAllText(path, contents);
    }

    public void Write(string text)
    {
        Console.Write(text);
    }
}