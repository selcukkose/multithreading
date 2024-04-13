namespace Multithreading;

public class ExceptionHandling
{
    public static void Run()
    {
        var t = Task.Factory.StartNew(() => { throw new InvalidOperationException("An error occured"); });

        var t2 = Task.Factory.StartNew(() => { throw new AccessViolationException("An error occured"); });

        try
        {
            Task.WaitAll(t, t2);
        }
        catch (AggregateException ae)
        {
            foreach (var e in ae.InnerExceptions)
            {
                Console.WriteLine(e.GetType().Name + " " + e.Message);
            }
        }

        Console.WriteLine("Main program");
    }
}