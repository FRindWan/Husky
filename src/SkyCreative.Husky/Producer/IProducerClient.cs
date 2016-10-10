using SkyCreative.Husky.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyCreative.Husky.Producer
{
    public interface IProducerClient
    {
        Task SendAsync(IMessage message);
    }
}
