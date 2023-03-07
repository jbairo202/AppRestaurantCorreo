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
    [Activity(Label = "RegistroUsuario")]
    public class RegistroUsuario : Activity
    {
        EditText txtNuevoUsuario;
        EditText txtNuevaClaveUsuario;
        EditText txtNuevoNombreUsuario;
        EditText txtNuevoApellidoUsuario;
        EditText txtNuevoTelefonoUsuario;
        Button btnRegistrarUsuario;
        Button btnYaTienesCuenta;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.RegistroUsuario);
            txtNuevoUsuario = FindViewById<EditText>(Resource.Id.txtNuevoUsuario);
            txtNuevaClaveUsuario = FindViewById<EditText>(Resource.Id.txtNuevaClaveUsuario);
            txtNuevoNombreUsuario = FindViewById<EditText> (Resource.Id.txtNuevoNombreUsuario);
            txtNuevoApellidoUsuario = FindViewById<EditText>(Resource.Id.txtNuevoApellidoUsuario);
            txtNuevoTelefonoUsuario = FindViewById<EditText>(Resource.Id.txtNuevoTelefonoUsuario);
            btnRegistrarUsuario = FindViewById<Button>(Resource.Id.btnRegistrarUsuarioNuevo);
            btnYaTienesCuenta = FindViewById<Button>(Resource.Id.btnYaTienesCuenta);
            
            btnRegistrarUsuario.Click += BtnRegistrarUsuario_Click;
            btnYaTienesCuenta.Click += BtnYaTienesCuenta_Click; 
          
        }

        private void BtnYaTienesCuenta_Click(object sender, System.EventArgs e)
        {
            Intent i = new Intent(this, typeof(MainActivity));
            StartActivity(i);
        }

        private void BtnRegistrarUsuario_Click(object sender,  EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtNuevoUsuario.Text.Trim()) && !string.IsNullOrEmpty(txtNuevaClaveUsuario.Text.Trim()) && (!string.IsNullOrEmpty(txtNuevoNombreUsuario.Text.Trim()) && (!string.IsNullOrEmpty(txtNuevoApellidoUsuario.Text.Trim()) && (!string.IsNullOrEmpty(txtNuevoTelefonoUsuario.Text.Trim())))))
                {
                    new Auxiliar().guardar(new Login() { Id = 0, Usuario = txtNuevoUsuario.Text.Trim(), Password = txtNuevaClaveUsuario.Text.Trim(), Nombre = txtNuevoNombreUsuario.Text.Trim(), Apellido = txtNuevoNombreUsuario.Text.Trim(), Telefono = txtNuevoNombreUsuario.Text.Trim(), });
                    Toast.MakeText(this, "Registro guardado", ToastLength.Long).Show();
                }
                else
                {
                    Toast.MakeText(this, "Por favor ingrese un nombre de usuario y una clave", ToastLength.Long).Show();
                }
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, ex.ToString(), ToastLength.Short).Show();
            }
        }


    }
}