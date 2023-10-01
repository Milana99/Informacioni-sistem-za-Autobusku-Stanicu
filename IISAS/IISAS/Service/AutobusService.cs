using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IISAS.Service
{
    class AutobusService : GenericService<Model.Autobus>
    {
        

        public AutobusService(Repository.GenericRepository<Model.Autobus> repository) :base(repository)
        {
        }

        public override int returnId(Model.Autobus autobus)
        {
            return autobus.id_aut;
        }

        public List<Model.Autobus> getAllByPrevoznik(string autoprevoznik)
        {
            return repository.Load()
                .Where(autobus => autobus.autoprev.naziv_prev == autoprevoznik)
                .ToList();
        }
    }
}
