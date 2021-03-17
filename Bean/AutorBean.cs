
namespace Beans
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class AutorBean
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }
        public string ciudad { get; set; }
        public string correo { get; set; }

    }
}
