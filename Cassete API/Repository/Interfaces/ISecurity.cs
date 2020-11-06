using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cassete_API.Repository.Interfaces
{
    public interface ISecurity
    {
        string GetHashString(string s);
    }
}
