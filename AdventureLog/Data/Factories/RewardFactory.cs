using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureLog.Data.Factories
{
    public class RewardFactory : IDbObjectFactory<Reward>
    {
        public Reward NewInstance() => new();
    }
}
