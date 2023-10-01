using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IISAS.Service
{
    class StanicaService : GenericService<Model.Stanica>
    {


        public StanicaService(Repository.GenericRepository<Model.Stanica> repository) : base(repository)
        {
        }

        public override int returnId(Model.Stanica stanica)
        {
            return stanica.id_stan;
        }

        public int GetIdByName(string name)
        {
            var stanica = repository.Load()
                .FirstOrDefault(s => s.naz_stan == name);

            return stanica?.id_stan ?? 0;
        }
    }
}
