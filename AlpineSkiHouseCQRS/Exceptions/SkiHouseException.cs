using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlpineSkiHouseCQRS.Exceptions
{
    public abstract class SkiHouseException : Exception
    {
        protected SkiHouseException(string message)
            : base(message)
        {

        }
    }
}
