using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IISAS.Service
{
    class KorisnikService : GenericService<Model.Korisnik>
    {
        public KorisnikService(Repository.GenericRepository<Model.Korisnik> repository) : base(repository)
        {
        }

        public override int returnId(Model.Korisnik korisnik)
        {
            return korisnik.id_kor;
        }


        public List<Model.Korisnik> FilterByPrezime(string prezime)
        {
            return repository.Load()
                .Where(korisnik => korisnik.prezime.Contains(prezime))
                .ToList();
        }

        public List<Model.Korisnik> FilterByStatus(string status)
        {
            return repository.Load()
                .Where(korisnik => korisnik.status_korisnika.Contains(status))
                .ToList();
        }

        public List<Model.Korisnik> FilterByUsername(string username)
        {
            return repository.Load()
                .Where(korisnik => korisnik.username.Contains(username))
                .ToList();
        }

        public List<Model.Korisnik> FilterByName(string name)
        {
            return repository.Load()
                .Where(korisnik => korisnik.ime.Contains(name))
                .ToList();
        }

        public int FilterByUsernameCount(string username)
        {
            return repository.Load()
                .Count(korisnik => korisnik.username == username);
        }

        public Model.Korisnik GetOne(string username, string password)
        {
            return repository.Load()
                .FirstOrDefault(korisnik => korisnik.username == username && korisnik.password == password);
        }

        public Model.Korisnik GetOne(string username)
        {
            return repository.Load()
                .FirstOrDefault(korisnik => korisnik.username == username);
        }

    }
}
