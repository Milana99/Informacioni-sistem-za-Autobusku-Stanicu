using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IISAS.Model;

namespace IISAS.Repository
{
    class AutoprevoznikRepository : GenericRepository<Model.Autoprevoznik>
    {
        public AutoprevoznikRepository(ASContext context) : base(context)
        {
        }
    }
}
