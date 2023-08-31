namespace Telegram.src.Utility
{
  public static class Sos
  {
    public static void PrintCount<T>(this List<T> list)
    {
      Console.WriteLine(list.Count);
    }
    public static void Foo()
    {
      List<int> list = new() { 1, 2, 3 };
      list.PrintCount();
    }
  }
}