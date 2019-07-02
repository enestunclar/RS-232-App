using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkuApp
{
    class values
    {
        private string[] cell = new string[8];

        public string[] valuess(string data, int counters)
        {

            if (counters == 1)
            {
                cell[0]=data.Substring(13, 16);
                cell[1]=data.Substring(17, 20);
                cell[3]=data.Substring(21, 24);
                cell[4]=data.Substring(25, 28);
                cell[5]=data.Substring(29, 32);
                cell[6]=data.Substring(33, 36);
                cell[7]=data.Substring(37, 40);
            }

            return cell;
        }


    }
}
