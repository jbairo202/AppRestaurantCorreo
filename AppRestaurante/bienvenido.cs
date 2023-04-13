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
using AndroidX.AppCompat.App;
using AndroidX.AppCompat.Widget;
using Toolbar = Android.Widget.Toolbar;

namespace AppRestaurante
{
    [Activity(Label = "Bienvenido")]
    public class Bienvenido : Activity
    {
        TextView textTextoBienvenido;

        

        Toolbar toolbar;
        Button btnSalir;
        Button btnVerPedidos;
        //private EventHandler BtnSalir_Click;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Bienvenido);
            textTextoBienvenido = FindViewById<TextView>(Resource.Id.txtBienvenido);
            FindViewById<TextView>(Resource.Id.txtBienvenido).Text = textTextoBienvenido.Text + ": " + Intent.GetStringExtra("username") ?? "Error al o";
            btnSalir = FindViewById<Button>(Resource.Id.btnSalir);
            btnVerPedidos = FindViewById<Button>(Resource.Id.btnVerPedidos);

            toolbar = FindViewById<Toolbar>(Resource.Id.toolbarMenu);

            btnSalir.Click += BtnSalir_Click;
            btnVerPedidos.Click += BtnVerPedidos_Click;
            

            SetActionBar(toolbar);
     
            ActionBar.Title = "Menu";
        }

        private void BtnVerPedidos_Click(object sender, EventArgs e)
        {
            Intent i = new Intent(this, typeof(VerPedidosCRUD));
            StartActivity(i);
        }

        private void BtnSalir_Click(object sender, System.EventArgs e)
        {
            Intent i = new Intent(this, typeof(MainActivity));
            StartActivity(i);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.icacerca:
                    Intent y = new Intent(this, typeof(Acerca));
                    StartActivity(y);
                    break;
                case Resource.Id.icubic:
                    Intent z = new Intent(this, typeof(SelectSede));
                    StartActivity(z);
                    break;
                case Resource.Id.icmenu:
                    Intent x = new Intent(this, typeof(VerMenu));
                    StartActivity(x);
                    break;
                case Resource.Id.iccrear:
                    Intent i = new Intent(this, typeof(Create_Pedido));
                    StartActivity(i);
                    break;
                case Resource.Id.icayuda:
                    Intent j = new Intent(this, typeof(Ayuda));
                    StartActivity(j);
                    break;

                default:
                    break;
            }
            
            
            return base.OnOptionsItemSelected(item);
        }

    }

    
}