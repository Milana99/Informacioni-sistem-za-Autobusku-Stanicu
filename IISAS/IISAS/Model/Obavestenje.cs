using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IISAS.xaml_window.korisnik_stan_usluga;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IISAS.Model
{
    public class Obavestenje
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_obavestenja { get; set; }
        private int _voznjaId;
        public int voznjaId
        {
            get { return _voznjaId; }
            set
            {
                _voznjaId = value;
                var asContext = new ASContext();
                var voznjaRepository = new Repository.VoznjaRepository(asContext);
                var voznjaService = new Service.VoznjaService(voznjaRepository);

                voznja = voznjaService.GetOne(value);
            }
        }
        [NotMapped]
        public Voznja voznja { get; set; }

        private int _korisnikId;

        public int korisnikId
        {
            get { return _korisnikId; }
            set
            {
                _korisnikId = value;
                var asContext = new ASContext();
                var korisnikRepository = new Repository.KorisnikRepository(asContext);
                var korisnikService = new Service.KorisnikService(korisnikRepository);

                korisnik = korisnikService.GetOne(value);
            }
        }

        [NotMapped]
        public Korisnik korisnik { get; set; }

        public String poruka { get; set; }

        public Obavestenje() { }
        public Obavestenje(int korisnikId, int voznjaId, String poruka) {
            var asContext = new ASContext();
            var voznjaRepository = new Repository.VoznjaRepository(asContext);
            var korisnikRepository = new Repository.KorisnikRepository(asContext);
            var voznjaService = new Service.VoznjaService(voznjaRepository);
            var korisnikService = new Service.KorisnikService(korisnikRepository);
            _voznjaId = voznjaId;
            _korisnikId = korisnikId;

            this.voznja = voznjaService.GetOne(voznjaId);
            this.korisnik = korisnikService.GetOne(korisnikId);
            this.poruka = poruka;
        }
    }
}
