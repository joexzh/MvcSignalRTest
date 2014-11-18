using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGProcess
{
    public class ProcessList
    {
        public List<IProcess> list = new List<IProcess>();

        public ProcessList()
        {
            list.Add(new Wo.CheckIn());
            list.Add(new Wo.FlowRedPacket());
            list.Add(new Wo.DiamondsRedCon());
            list.Add(new Wo.DiamondsGreenCon());
            list.Add(new Wo.DiamondsYellowCon());
        }
    }
}
