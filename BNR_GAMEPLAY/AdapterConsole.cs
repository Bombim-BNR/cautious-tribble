using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BNR_GAMEPLAY
{
    public class AdapterConsole : Adapter
    {
        public override Commands GetCommand()
        {
            throw new NotImplementedException();
        }

        public override City GetCurrentCity()
        {
            throw new NotImplementedException();
        }

        public override City GetSecondaryCity()
        {
            throw new NotImplementedException();
        }
    }
}
