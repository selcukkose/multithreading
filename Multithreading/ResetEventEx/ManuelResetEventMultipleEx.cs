namespace Multithreading.ResetEventEx;

public class ManuelResetEventMultipleEx
{
    private readonly ManualResetEvent _consumerEvent = new(false);
    private readonly List<int> _valueList = [];
    public void Run()
    {
        var producerTask = Task.Factory.StartNew(Producer);
        var consumerTask = Task.Factory.StartNew(Consumer);

        Task.WaitAll(producerTask, consumerTask);
    }

    private void Producer()
    {
        for (var i = 0; i < 20; i++)
        {
            _valueList.Add(i);
        }
        _consumerEvent.Set();
    }

    private void Consumer()
    {
        _consumerEvent.WaitOne();
        _valueList.ForEach(Console.WriteLine);
    }
}