using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IISAS.Model;

namespace IISAS.Repository
{
    class AutobusRepository : GenericRepository<Autobus>
    {

        public AutobusRepository(ASContext context) : base(context)
        {
        }

    }
}
