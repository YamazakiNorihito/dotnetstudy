using System.Diagnostics;
using System.Threading.Tasks.Dataflow;

namespace ActionBlockStudy;

internal class Program
{
    private static void Main()
    {
        /*
         * ActionBlock
         *  並列で処理する
         *　
         *　今回のプログラムは
         *　　　第一引数が並列処理数
         *　　　第二引数が総タスク数
         *　
         *　1プロセス１秒処理です。
         * 　３並列で総タスク数が３の場合→１秒の処理
         * 　３並列で総タスク数が５の場合→２秒の処理
         * 　３並列で総タスク数が６の場合→２秒の処理
         */

        /*
         * 00:00:01.0868126
         * 00:00:02.0041298
         * 00:00:02.0162812
         */
        Console.WriteLine(TimeDataflowComputations(3, 3));
        Console.WriteLine(TimeDataflowComputations(3, 5));
        Console.WriteLine(TimeDataflowComputations(3, 6));
    }

    // Performs several computations by using dataflow and returns the elapsed
    // time required to perform the computations.
    private static TimeSpan TimeDataflowComputations(int maxDegreeOfParallelism,
        int messageCount)
    {
        // Create an ActionBlock<int> that performs some work.
        var workerBlock = new ActionBlock<int>(
            // Simulate work by suspending the current thread.
            Thread.Sleep,
            // Specify a maximum degree of parallelism.
            new ExecutionDataflowBlockOptions
            {// 並列で動かす処理数
                MaxDegreeOfParallelism = maxDegreeOfParallelism
            });

        // Compute the time that it takes for several messages to
        // flow through the dataflow block.

        var stopwatch = new Stopwatch();
        stopwatch.Start();

        for (var i = 0; i < messageCount; i++)
        {
            workerBlock.Post(1000);
        }
        workerBlock.Complete();

        // Wait for all messages to propagate through the network.
        workerBlock.Completion.Wait();

        // Stop the timer and return the elapsed number of milliseconds.
        stopwatch.Stop();
        return stopwatch.Elapsed;
    }
}