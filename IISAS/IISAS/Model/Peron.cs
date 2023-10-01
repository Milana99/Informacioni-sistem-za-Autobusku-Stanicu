using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Data.Entity.Migrations.Model.UpdateDatabaseOperation;

namespace IISAS.Model
{
    public class Peron
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_per { get; set; }
        
        private int _stanicaId;
        
        public int stanicaId
        {
            get { return _stanicaId; }
            set
            {
                _stanicaId = value;
                var asContext = new ASContext();
                var stanicaRepsitory = new Repository.StanicaRepository(asContext);
                var stanicaService = new Service.StanicaService(stanicaRepsitory);

                stanica = stanicaService.GetOne(value);
            }
        }

        [NotMapped]
        public Stanica stanica { get; private set; }
        public String naz_per { get; set; }
        public bool obrisan { get; set; }

        public Peron() { }

        public Peron(String naz_per, int stanicaId)
        {
            var asContext = new ASContext();
            var stanicaRepsitory = new Repository.StanicaRepository(asContext);
            var stanicaService = new Service.StanicaService(stanicaRepsitory);

            _stanicaId = stanicaId;
            this.naz_per = naz_per;
            this.stanica = stanicaService.GetOne(stanicaId);
            this.obrisan = false;
        }

        public int getPeronId()
        {
            return id_per;
        }

    }
}
