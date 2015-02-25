using System;
using System.Threading;

namespace BGProcess
{
    public class InvokeProcess
    {
        static readonly ProcessList List = new ProcessList();
        private const int Interval = 60 * 1000 * 60;

        public static void Process()
        {

            while (true)
            {
                foreach (var item in List.List)
                {
                    try
                    {
                        item.Process();
                    }
                    catch (Exception)
                    {
                        // ignored
                    }
                }
                Thread.Sleep(Interval);
            }
            // ReSharper disable once FunctionNeverReturns
        }

    }
}
