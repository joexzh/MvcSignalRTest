using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGProcess
{
    public class ProcessList
    {
        public List<IProcess> List = new List<IProcess>();

        public ProcessList()
        {
            List.Add(new Wo.CheckIn());
            List.Add(new Wo.FlowRedPacket());
            List.Add(new Wo.DiamondsRedCon());
            List.Add(new Wo.DiamondsGreenCon());
            List.Add(new Wo.DiamondsYellowCon());

            List.Add(new NGA.DailyScrapeWall());
        }
    }
}
