using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyCreative.Husky.Model
{
    public interface IMessage
    {
        Guid ID { get; }

        DateTime Timestamp { get; }
    }
}
