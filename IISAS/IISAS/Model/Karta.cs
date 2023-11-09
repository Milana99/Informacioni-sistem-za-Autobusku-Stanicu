﻿using IISAS.xaml_window.korisnik_stan_usluga;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IISAS.Model
{
    public class Karta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_karte { get; set; }
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
        //Ovde dodati korisniika
        public int broj_sedista { get; set; }
        public int cena { get; set; }
        public String vrsta_karte { get; set; }
        public String vazeca { get; set; }
        public bool obrisan { get; set; }
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

        public int rezervisana { get; set; }
        public String datum { get; set; }

        public String salterski_radnik { get; set; }

        public String ime { get; set; }
        public String prezime { get; set; }
        public int? ocena { get; set; }

        public void OceniKartu(int ocena)
        {
            this.ocena = ocena;
            var asContext = new ASContext();
            var kartaRepository = new Repository.KartaRepository(asContext);
            var kartaService = new Service.KartaService(kartaRepository);
            var voznjaRepository = new Repository.VoznjaRepository(asContext);
            var voznjaService = new Service.VoznjaService(voznjaRepository);
            kartaService.Update(this);
            List<Model.Karta> karte = kartaService.GetAllByVoznja(this.voznja);
            voznjaService.CalculateOcena(this.voznja, karte);
        }

        public Karta() { }

        public Karta(int voznjaId, int broj_sedista, int cena, String vrsta_karte, String vazeca, int korisnikId, int rezervisana, String datum, string salterski_radnik, string ime, string prezime)
        {
            var asContext = new ASContext();
            var voznjaRepository = new Repository.VoznjaRepository(asContext);
            var korisnikRepository = new Repository.KorisnikRepository(asContext);
            var voznjaService = new Service.VoznjaService(voznjaRepository);
            var korisnikService = new Service.KorisnikService(korisnikRepository);

            _voznjaId = voznjaId;
            _korisnikId = korisnikId;
            this.voznja = voznjaService.GetOne(voznjaId);
            this.broj_sedista = broj_sedista;
            this.cena = cena;
            this.vrsta_karte = vrsta_karte;
            this.vazeca = vazeca;
            this.obrisan = false;
            this.korisnik = korisnikService.GetOne(korisnikId);
            this.rezervisana = rezervisana;
            this.datum = datum;
            this.salterski_radnik = salterski_radnik;
            this.ime = ime;
            this.prezime = prezime;
            this.ocena = null;
        }
    }
}
