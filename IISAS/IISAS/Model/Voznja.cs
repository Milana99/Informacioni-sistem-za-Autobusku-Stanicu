using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IISAS.Model
{
    public class Voznja
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_voz { get; set; }
        public String dol_sat {get; set;}
        public String pol_sat { get; set; }
        private int? _polaznaStanicaId;

        public int? polaznaStanicaId
        {
            get { return _polaznaStanicaId; }
            set
            {
                _polaznaStanicaId = value;
                var asContext = new ASContext();
                var stanicaRepsitory = new Repository.StanicaRepository(asContext);
                var stanicaService = new Service.StanicaService(stanicaRepsitory);

                if (value.HasValue)
                {
                    polazna_stan = stanicaService.GetOne(value.Value);
                }
            }
        }

        [NotMapped]
        public Stanica polazna_stan { get; set; }
        private int _autobusId;

        public int autobusId
        {
            get { return _autobusId; }
            set
            {
                _autobusId = value;
                var asContext = new ASContext();
                var autobusRepository = new Repository.AutobusRepository(asContext);
                var autobusService = new Service.AutobusService(autobusRepository);

                autobus = autobusService.GetOne(value);
            }
        }

        [NotMapped]
        public Autobus autobus { get; set; }
        public bool obrisan { get; set; }
        public String preko { get; set; }
        public int brSlobodnih { get; set; }
        public float cena { get; set; }
        private int? _peronId;

        public int? peronId
        {
            get { return _peronId; }
            set
            {
                _peronId = value;
                var asContext = new ASContext();
                var peronRepository = new Repository.PeronRepository(asContext);
                var peronService = new Service.PeronService(peronRepository);

                if (value.HasValue) {
                    peron = peronService.GetOne(value.Value); 
                }
            }
        }

        [NotMapped]
        public Peron peron { get; set; }
        public String datum { get; set; }

        private int? _krajnjaStanicaId;

        public int? krajnjaStanicaId
        {
            get { return _krajnjaStanicaId; }
            set
            {
                _krajnjaStanicaId = value;
                var asContext = new ASContext();
                var stanicaRepsitory = new Repository.StanicaRepository(asContext);
                var stanicaService = new Service.StanicaService(stanicaRepsitory);
                if (value.HasValue)
                {
                    krajnja_stan = stanicaService.GetOne(value.Value);
                }
            }
        }

        [NotMapped]
        public Stanica krajnja_stan { get; set; }
        public float popustPovratna { get; set; }
        public float popustStudentska { get; set; }
        public float popustPenzioner { get; set; }

        public Voznja() { }
        public Voznja(String dol_sat, String pol_sat, int polaznaStanId, int krajnjaStanId, int autobusId, String preko, float cena, int peronId, String datum, int brSlobodnih, float popustPovratna, float popustStudentska, float popustPenzioner)
        {
            var stanicaRepository = new Repository.StanicaRepository(new ASContext());
            var stanicaService = new Service.StanicaService(stanicaRepository);
            var autobusRepository = new Repository.AutobusRepository(new ASContext());
            var autobusService = new Service.AutobusService(autobusRepository);
            var peronRepository = new Repository.PeronRepository(new ASContext());
            var peronService = new Service.PeronService(peronRepository);

            _autobusId = autobusId;
            _peronId = peronId;
            _polaznaStanicaId = polaznaStanId;
            _krajnjaStanicaId = krajnjaStanId;
            this.dol_sat = dol_sat;
            this.pol_sat = pol_sat;
            this.polazna_stan = stanicaService.GetOne(polaznaStanId);
            this.krajnja_stan = stanicaService.GetOne(krajnjaStanId);
            this.autobus = autobusService.GetOne(autobusId);
            this.obrisan = false;
            this.preko = preko;
            this.brSlobodnih = brSlobodnih;
            this.cena = cena;
            this.peron = peronService.GetOne(peronId);
            this.datum = datum;
            this.popustPenzioner = popustPenzioner;
            this.popustPovratna = popustPovratna;
            this.popustStudentska = popustStudentska;
        }

        public Voznja(String dol_sat, String pol_sat, int polaznaStanId, int krajnjaStanId, int autobusId, String preko, float cena, int peronId, String datum, int brSlobodnih)
        {
            var stanicaRepository = new Repository.StanicaRepository(new ASContext());
            var stanicaService = new Service.StanicaService(stanicaRepository);
            var autobusRepository = new Repository.AutobusRepository(new ASContext());
            var autobusService = new Service.AutobusService(autobusRepository);
            var peronRepository = new Repository.PeronRepository(new ASContext());
            var peronService = new Service.PeronService(peronRepository);

            _autobusId = autobusId;
            _peronId = peronId;
            _polaznaStanicaId = polaznaStanId;
            _krajnjaStanicaId = krajnjaStanId;
            this.dol_sat = dol_sat;
            this.pol_sat = pol_sat;
            this.polazna_stan = stanicaService.GetOne(polaznaStanId);
            this.krajnja_stan = stanicaService.GetOne(krajnjaStanId);
            this.autobus = autobusService.GetOne(autobusId);
            this.obrisan = false;
            this.preko = preko;
            this.brSlobodnih = brSlobodnih;
            this.cena = cena;
            this.peron = peronService.GetOne(peronId);
            this.datum = datum;
            this.popustPenzioner = 1;
            this.popustPovratna = 1;
            this.popustStudentska = 1;
        }
        public int getStanicaId()
        {
            return id_voz;
        }
    }
}
