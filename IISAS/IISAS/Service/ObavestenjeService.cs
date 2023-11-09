using IISAS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IISAS.Service
{
    class ObavestenjeService : GenericService<Model.Obavestenje>
    {
        

        public ObavestenjeService(Repository.GenericRepository<Model.Obavestenje> repository) :base(repository)
        {
        }

        public override int returnId(Model.Obavestenje obavestenje)
        {
            return obavestenje.id_obavestenja;
        }

        public List<Model.Obavestenje> getAllByKorisnik(string korisnik)
        {
            return repository.Load()
                .Where(obavestenje => obavestenje.korisnik.username == korisnik)
                .ToList();
        }
    }
}
