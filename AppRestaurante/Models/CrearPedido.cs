using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;

namespace AppRestaurante.Models
{
    public class CrearPedido
    {
        public CrearPedido() { }

        [PrimaryKey, AutoIncrement]
        [MaxLength(10)]
        public int Id { get; set; }

        [MaxLength(15)]
        public string Nombre { get; set; }

        [MaxLength(15)]
        public string Apellido { get; set; }

        [MaxLength(15)]
        public string Telefono { get; set; }

        [MaxLength(15)]
        public string Direccion { get; set; }

        [MaxLength(15)]
        public string MetodoPago { get; set; }
    }
}