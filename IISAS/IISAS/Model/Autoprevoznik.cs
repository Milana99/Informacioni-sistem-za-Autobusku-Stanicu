using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IISAS.Model
{
    public class Autoprevoznik
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_prev { get; set; }
        public String naziv_prev { get; set; }
        public bool obrisan;

        public Autoprevoznik() { }
        public Autoprevoznik(String Naziv_prev)
        {
            naziv_prev = Naziv_prev;
            obrisan = false;
        }
    }
}
