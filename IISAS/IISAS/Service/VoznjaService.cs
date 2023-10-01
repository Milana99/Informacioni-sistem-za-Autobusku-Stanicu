﻿using IISAS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IISAS.Service
{
    class VoznjaService : GenericService<Model.Voznja>
    {
        public VoznjaService(Repository.GenericRepository<Model.Voznja> repository) : base(repository)
        {
        }

        public List<Model.Voznja> OrderedVoznja()
        {
               return repository.Load()
                .OrderBy(voznja => voznja.pol_sat)
                .Where(voznja => DateTime.Parse(voznja.datum.ToString()).Add(TimeSpan.Parse(voznja.pol_sat.ToString()))
            > DateTime.Now)
                .ToList();
        }

        public List<Model.Voznja> GetAllOrdered()
        {
            return repository.Load()
             .OrderBy(voznja => voznja.datum)
             .ThenBy(voznja => voznja.pol_sat)
             .ThenBy(voznja => voznja.dol_sat)
              .Where(voznja => DateTime.Parse(voznja.datum.ToString()).Add(TimeSpan.Parse(voznja.pol_sat.ToString()))
            > DateTime.Now)
             .ToList();
        }

        public override int returnId(Model.Voznja voznja)
        {
            return voznja.id_voz;
        }

        public void ReduceBrojKarata(Model.Voznja voznja)
        {
            voznja.brSlobodnih--;
            Update(voznja);
        }

        public void AddBrojKarata(Model.Voznja voznja)
        {
            voznja.brSlobodnih++;
            Update(voznja);
        }

        public List<Model.Voznja> FilterByPolazna(string polaznaStanica)
        {
            return repository.Load()
                .Where(voznja => voznja.polazna_stan.naz_stan.Contains(polaznaStanica))
                .OrderBy(voznja => voznja.datum)
             .ThenBy(voznja => voznja.pol_sat)
             .ThenBy(voznja => voznja.dol_sat)
              .Where(voznja => DateTime.Parse(voznja.datum.ToString()).Add(TimeSpan.Parse(voznja.pol_sat.ToString()))
            > DateTime.Now)
                .ToList();
        }

        public List<Model.Voznja> FilterByKrajnja(string krajnjaStanica)
        {
            return repository.Load()
                .Where(voznja => voznja.krajnja_stan.naz_stan.Contains(krajnjaStanica))
                .OrderBy(voznja => voznja.datum)
             .ThenBy(voznja => voznja.pol_sat)
             .ThenBy(voznja => voznja.dol_sat)
              .Where(voznja => DateTime.Parse(voznja.datum.ToString()).Add(TimeSpan.Parse(voznja.pol_sat.ToString()))
            > DateTime.Now)
                .ToList();
        }


       

        public Model.Voznja GetVoznjaByPeronDatumVreme(int peronId, string datum, string vreme)
        {
            return repository.Load()
                .FirstOrDefault(voznja => voznja.peron.id_per == peronId && voznja.datum == datum && voznja.pol_sat == vreme);
        }

        public List<Model.Voznja> FilterByPrevoznik(string nazivPrevoznika)
        {
            return repository.Load()
                .Where(voznja => voznja.autobus.autoprev.naziv_prev.Contains(nazivPrevoznika))
                .OrderBy(voznja => voznja.datum)
             .ThenBy(voznja => voznja.pol_sat)
             .ThenBy(voznja => voznja.dol_sat)
              .Where(voznja => DateTime.Parse(voznja.datum.ToString()).Add(TimeSpan.Parse(voznja.pol_sat.ToString()))
            > DateTime.Now)
                .ToList();
        }

        public List<Model.Voznja> FilterByDatum(string datum)
        {
            return repository.Load()
                .Where(voznja => voznja.datum.Contains(datum))
                .OrderBy(voznja => voznja.datum)
             .ThenBy(voznja => voznja.pol_sat)
             .ThenBy(voznja => voznja.dol_sat)
              .Where(voznja => DateTime.Parse(voznja.datum.ToString()).Add(TimeSpan.Parse(voznja.pol_sat.ToString()))
            > DateTime.Now)
                .ToList();
        }



        public List<Model.Voznja> SearchByStanica(List<Model.Voznja> voznje, string polaznaStanica, string krajnjaStanica)
        {
            return voznje.Where(voznja => voznja.polazna_stan.naz_stan == polaznaStanica && voznja.krajnja_stan.naz_stan == krajnjaStanica).ToList();
        }

        public List<Model.Voznja> SearchByDatum(List<Model.Voznja> voznje, string datum)
        {
            return voznje.Where(voznja => datum == voznja.datum).ToList();
        }


        public List<Model.Voznja> SearchByVreme(List<Model.Voznja> voznje, string vreme)
        {
            string[] vremena = vreme.Split(':');
            int sat = int.Parse(vremena[0]);
            int minut = int.Parse(vremena[1]);

            return voznje.Where(voznja =>
            {
                string[] vremenaVoznje = voznja.pol_sat.Split(':');
                int satVoznje = int.Parse(vremenaVoznje[0]);
                int minutVoznje = int.Parse(vremenaVoznje[1]);

                return satVoznje > sat || (satVoznje == sat && minutVoznje >= minut);
            }).ToList();
        }

        public List<Model.Voznja> SearchByParam(string polaznaStanica, string krajnjaStanica, string vreme, string datum)
        {
            var voznje = repository.Load()
                .OrderBy(voznja => voznja.pol_sat)
                .ToList();

            if (!string.IsNullOrEmpty(polaznaStanica) && !string.IsNullOrEmpty(krajnjaStanica))
            {
                voznje = SearchByStanica(voznje, polaznaStanica, krajnjaStanica);
            }

            if (!string.IsNullOrEmpty(vreme))
            {
                voznje = SearchByVreme(voznje, vreme);
            }

            if (!string.IsNullOrEmpty(datum))
            {
                voznje = SearchByDatum(voznje, datum);
            }

            return voznje.ToList();
        }
    }
}
