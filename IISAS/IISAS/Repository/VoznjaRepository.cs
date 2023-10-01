using IISAS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IISAS.Repository
{
    class VoznjaRepository : GenericRepository<Model.Voznja>
    {
        public VoznjaRepository(ASContext context) : base(context)
        {
        }
    }
}
