using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IISAS.Service
{
    class KartaService : GenericService<Model.Karta>
    {
        public KartaService(Repository.GenericRepository<Model.Karta> repository) : base(repository)
        {
        }

        public override int returnId(Model.Karta karta)
        {
            return karta.id_karte;
        }

        public List<Model.Karta> GetAllOrdered()
        {
            return repository.Load()
                .OrderBy(karta => karta.voznja.datum)
                .ThenBy(karta => karta.voznja.pol_sat)
                .ThenBy(karta => karta.voznja.dol_sat)
                .ToList();
        }

        public List<Model.Karta> GetAllOrderedBySalterskiRadnik()
        {
            return repository.Load()
                .Where(karta => karta.voznja.polazna_stan.naz_stan.Contains("Sid AS"))
                .OrderBy(karta => karta.voznja.datum)
                .ThenBy(karta => karta.voznja.pol_sat)
                .ThenBy(karta => karta.voznja.dol_sat)
                .ToList();
        }


        public List<Model.Karta> filterByPolazna(String polaznaStanica, Model.Korisnik korisnik)
        {
            return repository.Load()
                .Where(karta => karta.voznja.polazna_stan.naz_stan.Contains(polaznaStanica))
                .OrderBy(karta => karta.voznja.datum)
                .ThenBy(karta => karta.voznja.pol_sat)
                .ToList();
        }
        
        public List<Model.Karta> GetAllByVoznja(Model.Voznja voznja)
        {
            return repository.Load()
                .Where(karta => karta.voznjaId == voznja.id_voz).ToList();
        }

        public List<Model.Karta> filterByKrajnja(String krajnjaStanica, Model.Korisnik korisnik)
        {
            return repository.Load()
                .Where(karta => karta.voznja.krajnja_stan.naz_stan.Contains(krajnjaStanica))
                .OrderBy(karta => karta.voznja.datum)
                .ThenBy(karta => karta.voznja.pol_sat)
                .ToList();
        }

       

        public List<Model.Karta> filterByPrevoznik(String nazivPrevoznika, Model.Korisnik korisnik)
        {
            return repository.Load()
                .Where(karta => karta.voznja.autobus.autoprev.naziv_prev.Contains(nazivPrevoznika))
                .OrderBy(karta => karta.voznja.datum)
                .ThenBy(karta => karta.voznja.pol_sat)
                .ToList();
        }

        public List<Model.Karta> filterByDatum(String Datum, Model.Korisnik korisnik)
        {
            return repository.Load()
                .Where(karta => karta.voznja.datum.Contains(Datum))
                .OrderBy(karta => karta.voznja.datum)
                .ThenBy(karta => karta.voznja.pol_sat)
                .ToList();
        }

        public void updateRezervisana(Model.Karta karta)
        {
            karta.rezervisana.Equals(0);
            Update(karta);
        }

        public void updateVazeca(Model.Karta karta)
        {
            karta.vazeca.Equals("Nevazeca");
            Update(karta);
        }

        public List<Model.Karta> getKarteByKorisnik(Model.Korisnik korisnik)
        {
            return repository.Load()
                .Where(karta => karta.korisnik.id_kor == korisnik.id_kor)
                .ToList();
        }

        public List<Model.Karta> GetRecentByKorisnik(Model.Korisnik korisnik)
        {
            var karte = getKarteByKorisnik(korisnik)
                .OrderByDescending(karta => karta.datum)
                .Take(5)
                .ToList();

            return karte;
        }

        public List<Model.Karta> getKarteByKorisnikOrdered(Model.Korisnik korisnik)
        {
            return repository.Load()
                .Where(karta => karta.korisnik.id_kor == korisnik.id_kor)
                .OrderByDescending(karta => karta.vazeca)
                .ThenBy(karta => karta.voznja.datum)
                .ThenBy(karta => karta.voznja.pol_sat)
                .ToList();
        }

        public List<Model.Karta> getKarteByKorisnikVazecaOrdered(Model.Korisnik korisnik)
        {
            return repository.Load()
                .Where(karta => karta.korisnik.id_kor == korisnik.id_kor & karta.vazeca == "Vazeca")
                .OrderByDescending(karta => karta.vazeca)
                .ThenBy(karta => karta.voznja.datum)
                .ThenBy(karta => karta.voznja.pol_sat)
                .ToList();
        }
        public List<Model.Karta> getKarteByKorisnikNevazecaOrdered(Model.Korisnik korisnik)
        {
            return repository.Load()
                .Where(karta => karta.korisnik.id_kor == korisnik.id_kor & karta.vazeca == "Nevazeca")
                .OrderByDescending(karta => karta.vazeca)
                .ThenBy(karta => karta.voznja.datum)
                .ThenBy(karta => karta.voznja.pol_sat)
                .ToList();
        }

        public List<Model.Karta> getKarteBySalterskiRadnik(Model.Korisnik korisnik)
        {
            return repository.Load()
                .Where(karta => karta.salterski_radnik == korisnik.username)
                .ToList();
        }

        public List<Model.Karta> filterByPolazna(string polaznaStanica)
        {
            return repository.Load()
                .Where(karta => karta.voznja.polazna_stan.naz_stan.Contains(polaznaStanica))
                .OrderBy(karta => karta.voznja.datum)
                .ThenBy(karta => karta.voznja.pol_sat)
                .ToList();
        }

        public List<Model.Karta> filterByPolazna(string polaznaStanica, string datum)
        {
            return repository.Load()
                .Where(karta => karta.voznja.polazna_stan.naz_stan.Contains(polaznaStanica) & karta.voznja.datum == datum)
                .OrderBy(karta => karta.voznja.pol_sat)
                .ThenBy(karta => karta.voznja.dol_sat)
                .ToList();
        }

        public List<Model.Karta> filterByPolaznaIPrevoznik(string polaznaStanica, string prevoznik, string datum)
        {
            return repository.Load()
                .Where(karta => karta.voznja.polazna_stan.naz_stan.Contains(polaznaStanica) & karta.voznja.autobus.autoprev.naziv_prev.Contains(prevoznik)
                & karta.voznja.datum == datum)
                .OrderBy(karta => karta.voznja.pol_sat)
                .ThenBy(karta => karta.voznja.dol_sat)
                .ToList();
        }

        public List<Model.Karta> filterByKrajnja(string krajnjaStanica)
        {
            return repository.Load()
                .Where(karta => karta.voznja.krajnja_stan.naz_stan.Contains(krajnjaStanica))
                .OrderBy(karta => karta.voznja.datum)
                .ThenBy(karta => karta.voznja.pol_sat)
                .ToList();
        }

        public List<Model.Karta> filterByKrajnja(string krajnjaStanica, string datum)
        {
            return repository.Load()
                .Where(karta => karta.voznja.krajnja_stan.naz_stan.Contains(krajnjaStanica) & karta.voznja.datum == datum
                & karta.voznja.polazna_stan.naz_stan == "Sid AS")
                .OrderBy(karta => karta.voznja.pol_sat)
                .ThenBy(karta => karta.voznja.dol_sat)
                .ToList();
        }
        public List<Model.Karta> filterByKrajnjaIPolazna(string krajnjaStanica, string polazna, string datum )
        {
            return repository.Load()
                .Where(karta => karta.voznja.krajnja_stan.naz_stan.Contains(krajnjaStanica) & karta.voznja.polazna_stan.naz_stan.Contains(polazna)
                & karta.voznja.datum == datum)
                .OrderBy(karta => karta.voznja.pol_sat)
                .ThenBy(karta => karta.voznja.dol_sat)
                .ToList();
        }

        public List<Model.Karta> filterByKrajnjaPolaznaIPrevoznik(string krajnjaStanica, string polazna, string prevoznik, string datum)
        {
            return repository.Load()
                .Where(karta => karta.voznja.krajnja_stan.naz_stan.Contains(krajnjaStanica) & karta.voznja.polazna_stan.naz_stan.Contains(polazna) & karta.voznja.autobus.autoprev.naziv_prev.Contains(prevoznik)
                & karta.voznja.datum == datum)
                .OrderBy(karta => karta.voznja.pol_sat)
                .ThenBy(karta => karta.voznja.dol_sat)
                .ToList();
        }

        public List<Model.Karta> filterByKrajnjaIPrevoznik(string krajnjaStanica, string prevoznik, string datum)
        {
            return repository.Load()
                .Where(karta => karta.voznja.krajnja_stan.naz_stan.Contains(krajnjaStanica) & karta.voznja.autobus.autoprev.naziv_prev.Contains(prevoznik)
                & karta.voznja.datum == datum & karta.voznja.polazna_stan.naz_stan == "Sid AS")
                .OrderBy(karta => karta.voznja.pol_sat)
                .ThenBy(karta => karta.voznja.dol_sat)
                .ToList();
        }

        public List<Model.Karta> filterByPrevoznik(string nazivPrevoznika, string datum)
        {
            return repository.Load()
                .Where(karta => karta.voznja.autobus.autoprev.naziv_prev.Contains(nazivPrevoznika) & karta.voznja.datum == datum
                & karta.voznja.polazna_stan.naz_stan == "Sid AS")
                .OrderBy(karta => karta.voznja.pol_sat)
                .ThenBy(karta => karta.voznja.dol_sat)
                .ToList();
        }
        public List<Model.Karta> filterByPrevoznik(string nazivPrevoznika)
        {
            return repository.Load()
                .Where(karta => karta.voznja.autobus.autoprev.naziv_prev.Contains(nazivPrevoznika))
                .OrderBy(karta => karta.voznja.datum)
                .ThenBy(karta => karta.voznja.pol_sat)
                .ToList();
        }
        public List<Model.Karta> filterByDatum(string datum)
        {
            return repository.Load()
                .Where(karta => karta.voznja.datum.Contains(datum))
                .OrderBy(karta => karta.voznja.datum)
                .ThenBy(karta => karta.voznja.pol_sat)
                .ToList();
        }

        public List<Model.Karta> filterByPolaznaUsername(string polaznaStanica, Model.Korisnik korisnik)
        {
            return repository.Load()
                .Where(karta => karta.korisnik.id_kor == korisnik.id_kor &&
                                karta.voznja.polazna_stan.naz_stan.Contains(polaznaStanica))
                .OrderByDescending(karta => karta.vazeca)
                .ThenBy(karta => karta.voznja.datum)
                .ThenBy(karta => karta.voznja.pol_sat)
                .ToList();
        }

        public List<Model.Karta> filterByIdKarte(string idKarte, Model.Korisnik korisnik)
        {
            return repository.Load()
                .Where(karta => karta.korisnik.id_kor == korisnik.id_kor &&
                 karta.id_karte.ToString().Contains(idKarte))
                .OrderByDescending(karta => karta.vazeca)
                .ThenBy(karta => karta.voznja.datum)
                .ThenBy(karta => karta.voznja.pol_sat)
                .ToList();
        }

        public List<Model.Karta> filterByKrajnjaUsername(string krajnjaStanica, Model.Korisnik korisnik)
        {
            return repository.Load()
                .Where(karta => karta.korisnik.id_kor == korisnik.id_kor &&
                                karta.voznja.krajnja_stan.naz_stan.Contains(krajnjaStanica))
                .OrderByDescending(karta => karta.vazeca)
                .ThenBy(karta => karta.voznja.datum)
                .ThenBy(karta => karta.voznja.pol_sat)
                .ToList();
        }

        public List<Model.Karta> filterByPrevoznikUsername(string nazivPrevoznika, Model.Korisnik korisnik)
        {
            return repository.Load()
                .Where(karta => karta.korisnik.id_kor == korisnik.id_kor &&
                                karta.voznja.autobus.autoprev.naziv_prev.Contains(nazivPrevoznika))
                .OrderByDescending(karta => karta.vazeca)
                .ThenBy(karta => karta.voznja.datum)
                .ThenBy(karta => karta.voznja.pol_sat)
                .ToList();
        }

        public List<Model.Karta> filterByDatumUsername(string datum, Model.Korisnik korisnik)
        {
            return repository.Load()
                .Where(karta => karta.korisnik.id_kor == korisnik.id_kor &&
                                karta.voznja.datum.Contains(datum))
                .OrderByDescending(karta => karta.vazeca)
                .ThenBy(karta => karta.voznja.datum)
                .ThenBy(karta => karta.voznja.pol_sat)
                .ToList();
        }

        public List<Model.Karta> filterByDatumSR(string datum)
        {
            return repository.Load()
                .Where(karta => karta.voznja.polazna_stan.naz_stan == "Sid AS" &&
                                karta.voznja.datum.Contains(datum))
                .OrderBy(karta => karta.voznja.pol_sat)
                .ThenBy(karta => karta.voznja.dol_sat)
                .ToList();
        }

        public List<Model.Karta> filterByIdKarteSR(string id_karte)
        {
            return repository.Load()
                .Where(karta => karta.voznja.polazna_stan.naz_stan == "Sid AS" &&
                                karta.id_karte.ToString().Contains(id_karte))
                .ToList();
        }

        public List<Model.Karta> filterByImeSR(string ime)
        {
            return repository.Load()
                .Where(karta => karta.voznja.polazna_stan.naz_stan == "Sid AS" &&
                                karta.ime != null && karta.ime.Contains(ime))
                .OrderBy(karta => karta.voznja.datum)
                .ThenBy(karta => karta.voznja.pol_sat)
                .ThenBy(karta => karta.voznja.dol_sat)
                .ToList();
        }
        public List<Model.Karta> filterByPrezimeSR(String prezime)
        {
           
                return repository.Load()
                .Where(karta => karta.voznja.polazna_stan.naz_stan == "Sid AS" &&
                                karta.prezime != null && karta.prezime.Contains(prezime))
                .OrderBy(karta => karta.voznja.datum)
                .ThenBy(karta => karta.voznja.pol_sat)
                .ThenBy(karta => karta.voznja.dol_sat)
                .ToList();
            
            
            
        }

        public List<Model.Karta> filterByPolaznaNevazecaUsername(string polaznaStanica, Model.Korisnik korisnik)
        {
            return repository.Load()
                .Where(karta => karta.korisnik.id_kor == korisnik.id_kor &&
                                karta.voznja.polazna_stan.naz_stan.Contains(polaznaStanica) & karta.vazeca == "Nevazeca")
                .OrderBy(karta => karta.voznja.datum)
                .ThenBy(karta => karta.voznja.pol_sat)
                .ThenBy(karta => karta.voznja.dol_sat)
                .ToList();
        }

        public List<Model.Karta> filterByKrajnjaNevazecaUsername(string krajnjaStanica, Model.Korisnik korisnik)
        {
            return repository.Load()
                .Where(karta => karta.korisnik.id_kor == korisnik.id_kor &&
                                karta.voznja.krajnja_stan.naz_stan.Contains(krajnjaStanica) & karta.vazeca == "Nevazeca")
                .OrderBy(karta => karta.voznja.datum)
                .ThenBy(karta => karta.voznja.pol_sat)
                .ThenBy(karta => karta.voznja.dol_sat)
                .ToList();
        }

        public List<Model.Karta> filterByPrevoznikNevazecaUsername(string nazivPrevoznika, Model.Korisnik korisnik)
        {
            return repository.Load()
                .Where(karta => karta.korisnik.id_kor == korisnik.id_kor &&
                                karta.voznja.autobus.autoprev.naziv_prev.Contains(nazivPrevoznika) & karta.vazeca == "Nevazeca")
                .OrderBy(karta => karta.voznja.datum)
                .ThenBy(karta => karta.voznja.pol_sat)
                .ThenBy(karta => karta.voznja.dol_sat)
                .ToList();
        }

        public List<Model.Karta> filterByDatumNevazecaUsername(string datum, Model.Korisnik korisnik)
        {
            return repository.Load()
                .Where(karta => karta.korisnik.id_kor == korisnik.id_kor &&
                                karta.voznja.datum.Contains(datum) & karta.vazeca == "Nevazeca")
                .OrderBy(karta => karta.voznja.datum)
                .ThenBy(karta => karta.voznja.pol_sat)
                .ThenBy(karta => karta.voznja.dol_sat)
                .ToList();
        }

        public List<Model.Karta> filterByPolaznaVazecaUsername(string polaznaStanica, Model.Korisnik korisnik)
        {
            return repository.Load()
                .Where(karta => karta.korisnik.id_kor == korisnik.id_kor &&
                                karta.voznja.polazna_stan.naz_stan.Contains(polaznaStanica) & karta.vazeca == "Vazeca")
                .OrderBy(karta => karta.voznja.datum)
                .ThenBy(karta => karta.voznja.pol_sat)
                .ThenBy(karta => karta.voznja.dol_sat)
                .ToList();
        }

        public List<Model.Karta> filterByKrajnjaVazecaUsername(string krajnjaStanica, Model.Korisnik korisnik)
        {
            return repository.Load()
                .Where(karta => karta.korisnik.id_kor == korisnik.id_kor &&
                                karta.voznja.krajnja_stan.naz_stan.Contains(krajnjaStanica) & karta.vazeca == "Vazeca")
                .OrderBy(karta => karta.voznja.datum)
                .ThenBy(karta => karta.voznja.pol_sat)
                .ThenBy(karta => karta.voznja.dol_sat)
                .ToList();
        }

        public List<Model.Karta> filterByPrevoznikVazecaUsername(string nazivPrevoznika, Model.Korisnik korisnik)
        {
            return repository.Load()
                .Where(karta => karta.korisnik.id_kor == korisnik.id_kor &&
                                karta.voznja.autobus.autoprev.naziv_prev.Contains(nazivPrevoznika) & karta.vazeca == "Vazeca")
                .OrderBy(karta => karta.voznja.datum)
                .ThenBy(karta => karta.voznja.pol_sat)
                .ThenBy(karta => karta.voznja.dol_sat)
                .ToList();
        }

        public List<Model.Karta> filterByDatumVazecaUsername(string datum, Model.Korisnik korisnik)
        {
            return repository.Load()
                .Where(karta => karta.korisnik.id_kor == korisnik.id_kor &&
                                karta.voznja.datum.Contains(datum) & karta.vazeca == "Vazeca")
                .OrderBy(karta => karta.voznja.datum)
                .ThenBy(karta => karta.voznja.pol_sat)
                .ThenBy(karta => karta.voznja.dol_sat)
                .ToList();
        }

    }
}
