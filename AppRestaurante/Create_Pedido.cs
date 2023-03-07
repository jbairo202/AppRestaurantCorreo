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
    [Activity(Label = "Create_Pedido")]
    public class Create_Pedido : Activity
    {
        
        EditText txtNombreUsuario;
        EditText txtApellidoUsuario;
        EditText txtTelefonoUsuario;
        EditText txtDireccion;
        EditText txtdate;
        EditText txtMetodoPago;
        Button btnCrear_Pedido;
        Button btnRegresar;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Create_Pedido);
            txtNombreUsuario = FindViewById<EditText>(Resource.Id.txtNombreUsuario);
            txtApellidoUsuario = FindViewById<EditText>(Resource.Id.txtApellidoUsuario);
            txtTelefonoUsuario = FindViewById<EditText>(Resource.Id.txtTelefonoUsuario);
            txtDireccion = FindViewById<EditText>(Resource.Id.txtDireccion);
            txtdate = FindViewById<EditText>(Resource.Id.txtdate);
            txtMetodoPago = FindViewById<EditText>(Resource.Id.txtMetodoPago);
            btnCrear_Pedido = FindViewById<Button>(Resource.Id.btnCrearPedido);
            btnRegresar = FindViewById<Button>(Resource.Id.btnRegresar);

            btnCrear_Pedido.Click += BtnCrear_Pedido_Click;
            btnRegresar.Click += BtnRegresar_Click;


            // Create your application here
        }

        private void BtnRegresar_Click(object sender, EventArgs e)
        {
            Intent i = new Intent(this, typeof(Bienvenido));
            StartActivity(i);
        }

        private async void BtnCrear_Pedido_Click(object sender, EventArgs e)
        {
            Intent i = new Intent(this, typeof(Create_Pedido));
            StartActivity(i);

            try
            {
                if (!string.IsNullOrEmpty(txtNombreUsuario.Text.Trim()) && !string.IsNullOrEmpty(txtApellidoUsuario.Text.Trim()) && (!string.IsNullOrEmpty(txtTelefonoUsuario.Text.Trim()) && (!string.IsNullOrEmpty(txtDireccion.Text.Trim()) && (!string.IsNullOrEmpty(txtMetodoPago.Text.Trim())))))
                {
                    new AuxiliarP().guardar(new Pedido() { Id = 0, Nombre = txtNombreUsuario.Text.Trim(), Apellido = txtApellidoUsuario.Text.Trim(), Telefono = txtTelefonoUsuario.Text.Trim(), Direccion = txtDireccion.Text.Trim(), MetodoPago = txtMetodoPago.Text.Trim(), });
                    Toast.MakeText(this, "Pedido Registrado", ToastLength.Long).Show();
                }
                else
                {
                    Toast.MakeText(this, "Por favor  llene todos los campos", ToastLength.Long).Show();
                }
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, ex.ToString(), ToastLength.Short).Show();
            }
        }
    }
}