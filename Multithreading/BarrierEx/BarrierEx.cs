namespace Multithreading.BarrierEx;

public class BarrierEx
{
    private readonly Barrier _producerBarrier = new(5, Consumer);
    private static List<int> _valueList = new();

    public void Run()
    {
        Task.Factory.StartNew(Producer);
        Task.Factory.StartNew(Producer);
        Task.Factory.StartNew(Producer);
        Task.Factory.StartNew(Producer);
        Task.Factory.StartNew(Producer);

        Console.ReadKey();
    }

    private void Producer()
    {
        var random = (new Random()).Next(100);
        Thread.Sleep(500);
        _valueList.Add(random);
        _producerBarrier.SignalAndWait();
        Console.WriteLine("Completed!!!");
    }

    private static void Consumer(Barrier barrier)
    {
        Console.WriteLine($"Package received! Count: {_valueList.Count}");
        foreach (var value in _valueList)
            Console.WriteLine(value);
        _valueList.Clear();
    }
}