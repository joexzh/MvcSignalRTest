using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BGProcess
{
    public class InvokeProcess
    {
        static ProcessList list = new ProcessList();
        static int interval = 60 * 1000 * 60;

        public static void Process()
        {

            while (true)
            {
                foreach (var item in list.list)
                {
                    try
                    {
                        item.Process();
                    }
                    catch (Exception)
                    {

                    }

                }
                Thread.Sleep(interval);
            }
        }

    }
}
