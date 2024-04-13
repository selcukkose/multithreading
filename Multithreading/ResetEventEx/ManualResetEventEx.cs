namespace Multithreading.ResetEventEx;

public class ManualResetEventEx
{
    private readonly ManualResetEvent _producerEvent = new(true);
    private readonly ManualResetEvent _consumerEvent = new(false);
    private int _value = 0;

    public void Run()
    {
        var producerTask = Task.Factory.StartNew(Producer);
        var consumerTask = Task.Factory.StartNew(Consumer);

        Task.WaitAll(producerTask, consumerTask);
    }

    private void Producer()
    {
        for (var i = 0; i < 10; i++)
        {
            _producerEvent.WaitOne();
            _value = i * 2;
            _producerEvent.Reset();
            _consumerEvent.Set();
        }
    }

    private void Consumer()
    {
        for (var i = 0; i < 10; i++)
        {
            _consumerEvent.WaitOne();
            Console.WriteLine(_value);
            _consumerEvent.Reset();
            _producerEvent.Set();
        }
    }
}