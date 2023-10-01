using IISAS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IISAS.Repository
{
    class StanicaRepository : GenericRepository<Model.Stanica>
    {
        public StanicaRepository(ASContext context) : base(context)
        {
        }
    }
}
