using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyCreative.Cub.Utilities
{
    public class Ensure
    {
        public static void NotNull(object instance,string argName)
        {
            if (instance == null)
                throw new ArgumentNullException(argName + " should not be null.");
        }
    }
}
