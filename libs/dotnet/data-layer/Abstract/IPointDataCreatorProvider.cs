using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchLog.Infra.Data.Abstract
{
    public interface IPointDataCreatorProvider
    {
        IPointDataCreator ProvidePointDataCreator(string type);
    }
}
