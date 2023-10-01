using IISAS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IISAS.Repository
{
    class KorisnikRepository : GenericRepository<Model.Korisnik>
    {
        public KorisnikRepository(ASContext context) : base(context)
        {
        }
    }                           
}                               
                                
                                