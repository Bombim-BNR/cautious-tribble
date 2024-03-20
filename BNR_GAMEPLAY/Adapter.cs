using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BNR_GAMEPLAY
{
    public abstract class Adapter
    {
        public abstract Commands GetCommand();
        public abstract City GetCurrentCity();
        public abstract City GetSecondaryCity();
    }
}
