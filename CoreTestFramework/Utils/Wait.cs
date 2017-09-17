using System;
using System.Diagnostics;
using System.Threading;

namespace FunctionalTestinngCore.Utils
{
    public static class Wait
    {
        public static bool Until(Func<bool> task, int timeout, int retryInterval = 1)
        {
            bool success = false;
            TimeSpan maxDuration = TimeSpan.FromSeconds(timeout);
            Stopwatch sw = Stopwatch.StartNew();
            while ((!success) && (sw.Elapsed < maxDuration))
            {
                Thread.Sleep(retryInterval * 1000);
                success = task();
            }
            return success;
        }
    }
}
