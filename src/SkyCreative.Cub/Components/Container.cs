using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyCreative.Cub.Components
{
    public class Container
    {
        public static IContainer Current { get; private set; }

        public static void SetContainer(IContainer container)
        {
            Current = container;
        }
    }
}
