using IISAS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IISAS.Repository
{
    class PeronRepository : GenericRepository<Model.Peron>
    {
        public PeronRepository(ASContext context) : base(context)
        {
        }
    }
}
