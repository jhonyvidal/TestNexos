
namespace Beans
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class LibroBean
    {
        public int id { get; set; }
        public Nullable<int> id_autor { get; set; }
        public Nullable<int> id_editorial { get; set; }
        public string titulo { get; set; }
        public Nullable<System.DateTime> año { get; set; }
        public string genero { get; set; }
        public Nullable<int> numero_paginas { get; set; }

    }
}
