namespace Custom_Data_Structures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //MyList<int> list = new MyList<int>();

            //// === Add ===
            //Console.WriteLine("=== Testing Add ===");
            //list.Add(5);
            //list.Add(10);
            //list.Add(15);
            //PrintList(list);

            //// === AddRange ===
            //Console.WriteLine("=== Testing AddRange ===");
            //list.AddRange([ 20, 25 ]);
            //PrintList(list);

            //// === Insert ===
            //Console.WriteLine("=== Testing Insert ===");
            //list.Insert(1, 7); // Insert 7 between 5 and 10
            //PrintList(list);

            //// === InsertRange ===
            //Console.WriteLine("=== Testing InsertRange ===");
            //list.InsertRange(2, [ 8, 9 ]); // Insert at index 2
            //PrintList(list);

            //// === RemoveAt ===
            //Console.WriteLine("=== Testing RemoveAt ===");
            //list.RemoveAt(0); // Remove 5
            //PrintList(list);

            //// === Remove ===
            //Console.WriteLine("=== Testing Remove ===");
            //list.Remove(9); // Remove 9
            //PrintList(list);

            //// === RemoveRange ===
            //Console.WriteLine("=== Testing RemoveRange ===");
            //list.RemoveRange(1, 2); // Remove 2 items starting from index 1
            //PrintList(list);

            //// === Contains ===
            //Console.WriteLine("=== Testing Contains ===");
            //Console.WriteLine($"Contains 10? {list.Contains(10)}\n");

            //// === Indexer (int) ===
            //Console.WriteLine("=== Testing Indexer (int) ===");
            //Console.WriteLine($"Element at index 0: {list[0]}\n");

            //// === Indexer (string) ===
            //Console.WriteLine("=== Testing Indexer (string) ===");
            //Console.Write("Elements at indices \"0,1\": ");
            //var multi = list["0,1"];
            //foreach (var item in multi)
            //    Console.Write(item + " ");
            //Console.WriteLine("\n");

            //// === Sort ===
            //Console.WriteLine("=== Testing Sort ===");
            //list.Sort();
            //PrintList(list);

            //// === Reverse ===
            //Console.WriteLine("=== Testing Reverse ===");
            //list.Reverse();
            //PrintList(list);

            //// === ToArray ===
            //Console.WriteLine("=== Testing ToArray ===");
            //var array = list.ToArray();
            //Console.Write("Array: ");
            //foreach (var item in array)
            //    Console.Write(item + " ");
            //Console.WriteLine("\n");

            // === Undo ===
            //Console.WriteLine("=== Testing Undo ===");
            //list.Remove(10);
            //list.Undo(); // Should restore 10
            //PrintList(list);

            // === UndoAll ===
            //Console.WriteLine("=== Testing UndoAll ===");
            //list.Remove(25);
            //list.Remove(20);
            //list.UndoAll(); // Should restore 25 and 20
            //PrintList(list);

            // === Clear ===
            //Console.WriteLine("=== Testing Clear ===");
            //list.Clear();
            //PrintList(list);

            //// === RemoveAll ===
            //Console.WriteLine("=== Testing RemoveAll ===");
            //list.AddRange([1, 2, 3, 4 ]);
            //list.RemoveAll();
            //PrintList(list);
        }

        //static void PrintList(MyList<int> list)
        //{
        //    Console.Write("MyList: ");
        //    foreach (var item in list)
        //        Console.Write(item + " ");
        //    Console.WriteLine($"\nCount: {list.Count}\n");
        //}
    }
}