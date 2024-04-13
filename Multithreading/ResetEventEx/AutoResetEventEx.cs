namespace Multithreading.ResetEventEx;

public class AutoResetEventEx
{
    private readonly AutoResetEvent _consumerEvent = new(false);
    private readonly AutoResetEvent _producerEvent = new(true);
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
            _consumerEvent.Set();
        }
    }
    
    private void Consumer()
    {
        for (var i = 0; i < 10; i++)
        {
            _consumerEvent.WaitOne();
            Console.WriteLine(_value);
            _producerEvent.Set();
        }
    }
}