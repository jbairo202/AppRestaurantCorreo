using Android.App;
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
        Button show;
        Button insert;
        Button update;
        Button delete;
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
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            show = FindViewById<Button>(Resource.Id.show);
            insert = FindViewById<Button>(Resource.Id.insert);
            update = FindViewById<Button>(Resource.Id.update);
            delete = FindViewById<Button>(Resource.Id.delete);
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

            show.Click += Show_Click;
            insert.Click += Insert_Click;
            update.Click += Update_Click;
            delete.Click += Delete_Click;

        }

        private void Delete_Click(object sender, System.EventArgs e)
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

        private void Update_Click(object sender, System.EventArgs e)
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

        private void Insert_Click(object sender, System.EventArgs e)
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

        private void Show_Click(object sender, System.EventArgs e)
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

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}