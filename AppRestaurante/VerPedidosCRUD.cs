using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppRestaurante
{
    [Activity(Label = "VerPedidosCRUD")]
    public class VerPedidosCRUD : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_main);

            var pedido = new CrearPedido(this);

            var btnCrearPedido = FindViewById<Button>(Resource.Id.btnCrearPedido);
            btnCrearPedido.Click += (sender, e) =>
            {
                var pedido = new CrearPedido
                {
                    Nombre = "Juan",
                    Apellido = "Pérez",
                    Telefono = "3103114586",
                    Direccion = "Cra: 42 # 104-34",

                };
                pedido.InsertarPedido(pedido);
            };

           /* var btnEditar = FindViewById<Button>(Resource.Id.btnEditar);
            btnEditar.Click += (sender, e) =>
            {
                var pedido = new CrearPedido
                {
                    Id = 1,
                    Nombre = "Pedro",
                    Apellido = "Gómez",
                    Telefono = "3104924586",
                    Direccion = "Cra: 42 dd # 104-34",
                    
                };
                pedido.ActualizarPedido(pedido);
            };

            var btnEliminar = FindViewById<Button>(Resource.Id.btnEliminar);
            btnEliminar.Click += (sender, e) =>
            {
                var pedido = pedido.ObtenerPedidoPorId(1);
                pedido.Eliminarpedido(pedido);
            };

            var btnConsultar = FindViewById<Button>(Resource.Id.btnConsultar);
            btnConsultar.Click += (sender, e) =>
            {
                var personas = pedido.ObtenerTodasLosPedidos();
                foreach (var pedido in pedido)
                {
                    Log.Debug("MiApp", $"{pedido.Nombre} {pedido.Apellido} ({pedido.Telefono})");
                }
            };*/
        }

    }
}