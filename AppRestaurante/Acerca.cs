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

namespace AppRestaurante
{
    [Activity(Label = "Acerca")]
    public class Acerca : Activity
    {
        TextureView txtAceraDe;
        Button btnVolver;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Acerca);
            btnVolver = FindViewById<Button>(Resource.Id.btnVolver);

            btnVolver.Click += BtnSalir_Click;

            // Create your application here
        }

        private void BtnSalir_Click(object sender, System.EventArgs e)
        {
            Intent i = new Intent(this, typeof(Bienvenido));
            StartActivity(i);
        }

    }
}