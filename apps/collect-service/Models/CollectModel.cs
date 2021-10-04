using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WatchLog.Infra.Data.Entities;

namespace WatchLog.Services.CollectService.Models
{
    public class CollectModel
    {
        public IEnumerable<Collectable> Collection { get; set; }
    }
}
