using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfluxDB.Client.Writes;
using WatchLog.Infra.Data.Entities;

namespace WatchLog.Infra.Data.Abstract
{
    public interface IPointDataCreator
    {
        PointData CreatePointData(Collectable collectable);
    }
}
