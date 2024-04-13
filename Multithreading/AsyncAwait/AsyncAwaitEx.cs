namespace Multithreading.AsyncAwait;

public class AsyncAwaitEx
{
   public async Task Run()
   {
      Console.WriteLine("first");
      await RunAsync();
      Console.WriteLine("second");
      await AnotherRunAsync();
      Console.WriteLine("third");

      Console.ReadKey();
   }

   private async Task RunAsync()
   {
      Console.WriteLine($"{nameof(RunAsync)} - first");
      await Task.Delay(200);
      Console.WriteLine($"{nameof(RunAsync)} - second");
   }

   private async Task AnotherRunAsync()
   {
      Console.WriteLine($"{nameof(AnotherRunAsync)} - first");
      RunAsync();
      Console.WriteLine($"{nameof(AnotherRunAsync)} - second");
   }
}