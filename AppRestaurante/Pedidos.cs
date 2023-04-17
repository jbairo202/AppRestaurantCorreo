using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;

namespace AppRestaurante
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class Pedidos : AppCompatActivity
    {

        EditText txtId;
        EditText txtNombre;
        EditText txtApellido;
        EditText txtTelefono;
        EditText txtDireccion;
        EditText txtMetodoPago;
        Button btnMostrarP;
        Button btnInsertarP;
        Button btnActualizarP;
        Button btnEliminarP;
        Button btnAtras;
        TextView ViewOne;
        TextView ViewTwo;
        TextView ViewThree;
        TextView ViewFour;
        TextView ViewFive;
        TextView ViewSix;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.Pedidos);
            // Set our view from the "main" layout resource
            btnMostrarP = FindViewById<Button>(Resource.Id.btnMostrarP);
            btnInsertarP = FindViewById<Button>(Resource.Id.btnInsertarP);
            btnActualizarP = FindViewById<Button>(Resource.Id.btnActualizarP);
            btnEliminarP = FindViewById<Button>(Resource.Id.btnEliminarP);
            btnAtras = FindViewById<Button>(Resource.Id.btnAtras);
            txtId = FindViewById<EditText>(Resource.Id.txtId);
            txtNombre = FindViewById<EditText>(Resource.Id.txtNombre);
            txtApellido = FindViewById<EditText>(Resource.Id.txtApellido);
            txtTelefono = FindViewById<EditText>(Resource.Id.txtTelefono);
            txtDireccion = FindViewById<EditText>(Resource.Id.txtDireccion);
            txtMetodoPago = FindViewById<EditText>(Resource.Id.txtMetodoPago);
            ViewOne = FindViewById<TextView>(Resource.Id.ViewOne);
            ViewTwo = FindViewById<TextView>(Resource.Id.ViewTwo);
            ViewThree = FindViewById<TextView>(Resource.Id.ViewThree);
            ViewFour = FindViewById<TextView>(Resource.Id.ViewFour);
            ViewFive = FindViewById<TextView>(Resource.Id.ViewFive);
            ViewSix = FindViewById<TextView>(Resource.Id.ViewSix);

            btnMostrarP.Click += BtnMostrarP_Click;
            btnInsertarP.Click += BtnInsertarP_Click;
            btnActualizarP.Click += BtnActualizarP_Click;
            btnEliminarP.Click += BtnEliminarP_Click;
            btnAtras.Click += BtnAtras_Click;

        }

        private void BtnAtras_Click(object sender, EventArgs e)
        {
            Intent i = new Intent(this, typeof(Bienvenido));
            StartActivity(i);
        }

        private void BtnMostrarP_Click(object sender, EventArgs e)
        {
            try
            {
                Sign Data = null;
                if (!string.IsNullOrEmpty(txtId.Text.Trim()))
                {
                    Data = new AuxiliarP().Selection(int.Parse(txtId.Text.Trim()));
                    if (Data != null)
                    {
                        ViewOne.Text = Data.ID.ToString();
                        ViewTwo.Text = Data.Nombre.ToString();
                        ViewThree.Text = Data.Apellido.ToString();
                        ViewFour.Text = Data.Telefono.ToString();
                        ViewFive.Text = Data.Direccion.ToString();
                        ViewSix.Text = Data.MetoPago.ToString();
                    }
                    else
                    {
                        Toast.MakeText(this, "Datos invalidos", ToastLength.Short).Show();
                    }
                }
                else
                {
                    Toast.MakeText(this, "Campos o campo vacio. Rellene todos los campos", ToastLength.Long).Show();
                }

            }
            catch (Exception X)
            {
                Toast.MakeText(this, X.ToString(), ToastLength.Short).Show();
            }
            // throw new System.NotImplementedException();
        }

        private void BtnEliminarP_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtId.Text.Trim()))
                {
                    new AuxiliarP().Destroy(int.Parse(txtId.Text.Trim()));
                    Toast.MakeText(this, "Pedido eliminado", ToastLength.Short).Show();
                }
                else
                {
                    Toast.MakeText(this, "Campo vacio. Rellene el campo de ID", ToastLength.Long).Show();
                }
            }
            catch (Exception x)
            {
                Toast.MakeText(this, x.ToString(), ToastLength.Short).Show();
            }
            //throw new System.NotImplementedException();
        }

        private void BtnActualizarP_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtNombre.Text.Trim()) && !string.IsNullOrEmpty(txtId.Text.Trim()) && !string.IsNullOrEmpty(txtApellido.Text.Trim()) && !string.IsNullOrEmpty(txtTelefono.Text.Trim()) && !string.IsNullOrEmpty(txtDireccion.Text.Trim()) && !string.IsNullOrEmpty(txtMetodoPago.Text.Trim()))
                {
                    // = new Auxiliar().Insert( txtId.Text.Trim(), txtNombre.Text.Trim(), txtApellido.Text.Trim(), txtTelefono.Text.Trim(), txtDireccion.Text.Trim(), txtMetodoPago.Text.Trim());
                    new AuxiliarP().Insert(new Sign() { ID = int.Parse(txtId.Text.Trim()), Nombre = txtNombre.Text.Trim(), Apellido = txtApellido.Text.Trim(), Telefono = txtTelefono.Text.Trim(), Direccion = txtDireccion.Text.Trim(), MetoPago = txtMetodoPago.Text.Trim() });
                    Toast.MakeText(this, "Pedido actualizado", ToastLength.Short).Show();
                }
                else
                {
                    Toast.MakeText(this, "Campos o campo vacio. Rellene todos los campos", ToastLength.Long).Show();
                }
            }
            catch (Exception X)
            {
                Toast.MakeText(this, X.ToString(), ToastLength.Short).Show();
            }
            //throw new System.NotImplementedException();
        }

        private void BtnInsertarP_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtNombre.Text.Trim()) && !string.IsNullOrEmpty(txtApellido.Text.Trim()) && !string.IsNullOrEmpty(txtTelefono.Text.Trim()) && !string.IsNullOrEmpty(txtDireccion.Text.Trim()) && !string.IsNullOrEmpty(txtMetodoPago.Text.Trim()))
                {
                    // = new Auxiliar().Insert(txtUser.Text.Trim(), txtId.Text.Trim(), txtEmail.Text.Trim(), txtDescription.Text.Trim());
                    new AuxiliarP().Insert(new Sign() { ID = 0, Nombre = txtNombre.Text.Trim(), Apellido = txtApellido.Text.Trim(), Telefono = txtTelefono.Text.Trim(), Direccion = txtDireccion.Text.Trim(), MetoPago = txtMetodoPago.Text.Trim() });
                    Toast.MakeText(this, "Pedido guardado", ToastLength.Short).Show();


                }
                else
                {
                    Toast.MakeText(this, "Campos o campo vacio. Rellene todos los campos", ToastLength.Long).Show();
                }
            }
            catch (Exception X)
            {
                Toast.MakeText(this, X.ToString(), ToastLength.Short).Show();
            }
            //throw new System.NotImplementedException();
        }

       

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}