using Cryptocurrency_Helper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptocurrency_Helper.Interfaces
{
    public interface IService
    {
        Task<List<MainIndex>> GetMainIndex();
    }
}
