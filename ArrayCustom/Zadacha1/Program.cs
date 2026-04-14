namespace Zadacha1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomArrayList myList = new CustomArrayList();


            Console.WriteLine("1. Добавяне на елементи:");
            myList.Add("Ябълка");
            myList.Add("Круша");
            myList.Add("Банан");
            myList.Add("Портокал");

            Console.WriteLine($"   Брой елементи: {myList.Count}");
            myList.Add("Грозде");
            Console.WriteLine($"   Брой елементи: {myList.Count}");

            for (int i = 0; i < myList.Count; i++)
            {
                Console.WriteLine(myList[i]);
            }
        }
    }
}
