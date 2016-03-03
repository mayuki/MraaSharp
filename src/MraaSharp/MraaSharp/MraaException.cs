using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MraaSharp
{
    public class MraaException : Exception
    {
        public MraaResult Result { get; private set; }
        public MraaException(MraaResult result)
            : base("MRAA operation failed: " + result.ToString())
        {
            this.Result = result;
        }
    }
}
