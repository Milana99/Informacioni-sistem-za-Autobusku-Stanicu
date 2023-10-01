using IISAS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IISAS.Repository
{
    class KartaRepository : GenericRepository<Model.Karta>
    {
        public KartaRepository(ASContext context) : base(context)
        {
        }
    }
}
