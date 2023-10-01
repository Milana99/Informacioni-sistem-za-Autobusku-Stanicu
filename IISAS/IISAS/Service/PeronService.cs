using IISAS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IISAS.Service
{
    class PeronService : GenericService<Model.Peron>
    {
        public PeronService(Repository.GenericRepository<Model.Peron> repository) : base(repository)
        {
        }

        public override int returnId(Model.Peron peron)
        {
            return peron.id_per;
        }
        
       public List<Model.Voznja> GetByDatumVreme(string datum, string vreme)
        {
            var asContext = new ASContext();
            var voznjaRepository = new Repository.VoznjaRepository(asContext);
            var voznjaService = new VoznjaService(voznjaRepository);

            return repository.Load()
                .Select(peron =>
                {
                    var voznja = voznjaService.GetVoznjaByPeronDatumVreme(peron.id_per, datum, vreme) ??
                        new Model.Voznja( "-", "-", 0, 0, 0, "-", 0, peron.id_per, datum, 0);

                    return voznja;
                })
                .ToList();
        }

        public List<Model.Peron> GetAllByStanica(string stanica)
        {
            return repository.Load()
                .Where(peron => peron.stanica != null && peron.stanica.naz_stan == stanica)
                .ToList();
        }
    }
}
