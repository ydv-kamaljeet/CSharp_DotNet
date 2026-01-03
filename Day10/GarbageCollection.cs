using System;
using System.Collections.Generic;

namespace Day10
{
    public class BigBoy : IDisposable
    {
        public List<string> Names { get; set; }

        public BigBoy()
        {
            Names = new List<string>();
            Names.Add("kamaljeet");
            Names.Add("Igloo");
        }

        public void Dispose()
        {
            Names=null;
            Console.WriteLine("Resources Disposed.");
        }

        //Finalizer:

        ~BigBoy()
        {
            //Can perform any operation{customize the disposing} like we want to store the data in csv before the garbage collect collects it.
            //Code here....
            Names=null; //Disposing
        }
    }

    public class GarbageCollection
    {
        public void Implement()
        {
            var list = new List<byte[]>();

            for (int i = 0; i < 300; i++)
                list.Add(new byte[1024]);

            Console.WriteLine("Allocated.");

            Console.WriteLine("Memory before GC: " + GC.GetTotalMemory(forceFullCollection:true));

            GC.Collect();
            GC.WaitForPendingFinalizers();

            Console.WriteLine("Memory after GC: " + GC.GetTotalMemory(forceFullCollection:true));
        }
    }
}
