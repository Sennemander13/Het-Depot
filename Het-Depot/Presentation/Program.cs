public class Program
{
    public static IWorld world = new RealWorld();
    public static void Main()
    {
        string code;
        do{
            world.Clear();
            world.WriteLine("--------------------");
            world.WriteLine("Welkom scan uw code");
            world.Write("Code: ");
            code = world.ReadLine()!;
            BaseLogic.Login(code);
        } while (code != "quit");
    }

}