namespace Multithreading.CountDownEventEx;

public class CountDownEventEx
{
    private const int TaskCount = 5;
    private CountdownEvent _countDownEvent = new (TaskCount);
    private static List<int> _valueList = new();
    public void Run()
    {
        Task.Factory.StartNew(Producer);
        Task.Factory.StartNew(Producer);
        Task.Factory.StartNew(Producer);
        Task.Factory.StartNew(Producer);
        Task.Factory.StartNew(Producer);

        Task.Factory.StartNew(Consumer);
        Console.ReadKey();
    }
    
    private void Producer()
    {
        var random = (new Random()).Next(100);
        Thread.Sleep(500);
        _valueList.Add(random);
        _countDownEvent.Signal();
        Console.WriteLine("Completed!!!");
    }

    private void Consumer()
    {
        _countDownEvent.Wait();
        Console.WriteLine($"Package received! Count: {_valueList.Count}");
        foreach (var value in _valueList)
            Console.WriteLine(value);
        _valueList.Clear();
    }
}