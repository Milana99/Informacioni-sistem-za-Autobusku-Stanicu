using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IISAS.Service
{
    class AutoprevoznikService : GenericService<Model.Autoprevoznik>
    {
        public AutoprevoznikService(Repository.GenericRepository<Model.Autoprevoznik> repository) : base(repository)
        {
        }

        public override int returnId(Model.Autoprevoznik autoprevoznik)
        {
            return autoprevoznik.id_prev;
        }
    }
}
