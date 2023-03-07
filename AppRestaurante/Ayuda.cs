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
    [Activity(Label = "Ayuda")]
    public class Ayuda : Activity
    {
        EditText txtNombre;
        EditText txtApellidos;
        EditText txtTelefono;
        EditText txtMensaje;
        Button btnVolver;
        ProgressBar ProgressBar1;
        
      

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Ayuda);
            txtNombre = FindViewById<EditText>(Resource.Id.txtNombre);
            txtApellidos = FindViewById<EditText>(Resource.Id.txtApellidos);
            txtTelefono = FindViewById<EditText>(Resource.Id.txtTelefono);
            txtMensaje = FindViewById<EditText>(Resource.Id.txtMensaje);
            ProgressBar1 = FindViewById<ProgressBar>(Resource.Id.progress_circular);
            btnVolver = FindViewById<Button>(Resource.Id.btnVolver);

            btnVolver.Click += BtnVolver_Click;
            // Create your application here
        }

        private void BtnVolver_Click(object sender, EventArgs e)
        {
            Intent i = new Intent(this, typeof(Bienvenido));
            StartActivity(i);
        }
    }
}