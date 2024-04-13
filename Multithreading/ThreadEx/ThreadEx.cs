namespace Multithreading.ThreadEx;

public class ThreadEx
{
    public void Run() 
    {
        var t = new Thread(() =>
        {
            for (var i = 0; i < 1000; i++)
            {
                Console.Write("x");
            }
        });
        t.Start();
        
        Console.WriteLine("Main thread");
    }
}