namespace Multithreading.Synchronization;

public class LockEx
{
    private double _currentBalance;
    private readonly object _lockObject = new();
    private void Deposit(double amount)
    {
        _currentBalance += amount;
    }
    
    private void Withdraw(double amount)
    {
        _currentBalance -= amount;
    }
    
    public void Run()
    {
        var t1 = new Thread(() =>
        {
            for (var i = 0; i < 1000; i++)
            {
                lock (_lockObject)
                {
                    Deposit(100);
                }
            }
        });
        
        var t2 = new Thread(() =>
        {
            for (var i = 0; i < 1000; i++)
            {
                lock (_lockObject)
                {
                    Withdraw(100);
                }
            }
        });
        
        t1.Start();
        t2.Start();
        
        t1.Join();
        t2.Join();
        
        Console.WriteLine(_currentBalance);
    }
}