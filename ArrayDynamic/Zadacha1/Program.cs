namespace Zadacha1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DynamicList list = new DynamicList();

            list.Add("eins");
            list.Add("zwei");
            list.Add("drei");
            list.Add("drun");
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
            
        }
    }
}
