
namespace Beans
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class EditorialBean
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string correspondencia { get; set; }
        public string telefono { get; set; }
        public string correo { get; set; }
        public Nullable<int> max_registros { get; set; }

    }
}
