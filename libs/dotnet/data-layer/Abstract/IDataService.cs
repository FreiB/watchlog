using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchLog.Infra.Data.Entities;

namespace WatchLog.Infra.Data.Abstract
{
    public interface IDataService
    {
        void InsertData(Collectable collectable);
        void InsertDataCollection(IEnumerable<Collectable> collection);
    }
}
