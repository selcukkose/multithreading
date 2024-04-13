
using System.Diagnostics;
using Multithreading;
using Multithreading.AsyncAwait;
using Multithreading.BarrierEx;
using Multithreading.CountDownEventEx;
using Multithreading.ResetEventEx;
using Multithreading.Synchronization;
using Multithreading.ThreadEx;
using Multithreading.ThreadPoolEx;

EventWaitHandleEx eventWaitHandle = new EventWaitHandleEx();
eventWaitHandle.Run();

// AutoResetEventEx autoResetEventEx = new AutoResetEventEx();
// autoResetEventEx.Run();

// ManualResetEventEx autoResetEventEx = new ManualResetEventEx();
// autoResetEventEx.Run();

// ManuelResetEventMultipleEx manuelResetEventMultipleEx = new ManuelResetEventMultipleEx();
// manuelResetEventMultipleEx.Run();

// var barrierEx = new BarrierEx();
// barrierEx.Run();

// var countDownEx = new CountDownEventEx();
// countDownEx.Run();

// var asyncAwait = new AsyncAwaitEx();
// asyncAwait.Run().Wait();

// var threadEx = new ThreadEx();
// threadEx.Run();

// var threadPoolEx = new ThreadPoolEx();
// threadPoolEx.Run();

// var sw = new Stopwatch();
// sw.Start();
// var lockEx = new LockEx();
// lockEx.Run();
// sw.Stop();
// Console.WriteLine($"Lock: {sw.Elapsed}");

// var sw2 = new Stopwatch();
// sw2.Start();
// var interLockedEx = new InterLockedEx();
// interLockedEx.Run();
// sw2.Stop();
// Console.WriteLine($"Interlocked: {sw2.Elapsed}" );