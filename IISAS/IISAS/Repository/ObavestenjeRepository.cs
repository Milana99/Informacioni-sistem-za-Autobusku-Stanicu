using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IISAS.Model;

namespace IISAS.Repository
{
    class ObavestenjeRepository : GenericRepository<Obavestenje>
    {

        public ObavestenjeRepository(ASContext context) : base(context)
        {
        }

    }
}
