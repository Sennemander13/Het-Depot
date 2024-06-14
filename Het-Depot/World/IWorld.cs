public interface IWorld
{
    DateTime Now { get; }

    void WriteLine(string line);

    string ReadLine();

    void Clear();

    void Write(string line);

    string ReadAllText(string path);

    bool Exists(string path);

    void WriteAllText(string path, string contents);
}