using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCCRUD.Models.ViewModels
{
    public class TablaUserViewModel
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string correo { get; set; }
        public DateTime fechaNacimiento { get; set; }

    }
}