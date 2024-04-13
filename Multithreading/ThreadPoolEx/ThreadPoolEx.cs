namespace Multithreading.ThreadPoolEx;

public class ThreadPoolEx
{
    public void Run()
    {
        Task.Factory.StartNew(() =>
        {
            for (var i = 0; i < 1000; i++)
            {
                Console.Write("x");
            }
        }, TaskCreationOptions.LongRunning);
        
        Console.WriteLine("Main thread");
    }
}