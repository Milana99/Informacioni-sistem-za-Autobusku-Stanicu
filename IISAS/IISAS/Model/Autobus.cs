using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IISAS.Model
{
    public class Autobus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_aut { get; set; }
        public int kap_aut { get; set; }
        public String reg_aut { get; set; }
        public bool obrisan { get; set; }
        private int _prevoznikId;

        public int prevoznikId
        {
            get { return _prevoznikId; }
            set
            {
                _prevoznikId = value;
                var asContext = new ASContext();
                var prevoznikRepository = new Repository.AutoprevoznikRepository(asContext);
                var prevoznikService = new Service.AutoprevoznikService(prevoznikRepository);

                autoprev = prevoznikService.GetOne(value);
            }
        }

        [NotMapped]
        public Autoprevoznik autoprev { get; set; }

        public Autobus() { }
        public Autobus(int kap_aut, String reg_aut, int autoprevId)
        {
            var asContext = new ASContext();
            var autoprevoznikRepository = new Repository.AutoprevoznikRepository(asContext);
            var autoprevoznikService = new Service.AutoprevoznikService(autoprevoznikRepository);

            _prevoznikId = autoprevId;
            this.kap_aut = kap_aut;
            this.reg_aut = reg_aut;
            this.autoprev = autoprevoznikService.GetOne(autoprevId);
            this.obrisan = false;
        }

        public int getAutoprevId()
        {
            return autoprev.id_prev;
        }
    }
}
