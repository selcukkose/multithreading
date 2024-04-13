namespace Multithreading.Synchronization;

public class InterLockedEx
{
    private long _currentBalance;

    private void Deposit(long amount)
    {
        Interlocked.Add(ref _currentBalance, amount);
    }

    private void Withdraw(long amount)
    {
        Interlocked.Add(ref _currentBalance, -amount);
    }

    public void Run()
    {
        Task.Factory.StartNew(() =>
        {
            for (var i = 0; i < 1000; i++)
            {
                Deposit(100);
            }
        });
        
        Task.Factory.StartNew(() =>
        {
            for (var i = 0; i < 1000; i++)
            {
                Withdraw(100);
            }
        });

        Console.WriteLine(_currentBalance);
    }
}