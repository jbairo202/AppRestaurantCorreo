using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using AppRestaurante.Data;
using System;

namespace AppRestaurante
{

    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]

    public class MainActivity : AppCompatActivity 
    {
        EditText txtUser;
        EditText txtPassw;
        Button btnIngresar;
        Button btnRegistrate;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            txtUser = FindViewById<EditText>(Resource.Id.txtUser);
            txtPassw = FindViewById<EditText>(Resource.Id.txtPassw);
            btnIngresar = FindViewById<Button>(Resource.Id.buttonIngresar);
            btnRegistrate = FindViewById<Button>(Resource.Id.buttonRegistrate);


            btnIngresar.Click += BtnIngresar_Click;
            btnRegistrate.Click += BtnRegistrate_Click;
           
           
        }

        private void BtnRegistrate_Click(object sender, System.EventArgs e)
        {
           Intent i = new Intent(this,  typeof(RegistroUsuario));
           StartActivity(i);
        }

       
        private void BtnIngresar_Click(object sender, System.EventArgs e)
        {
            try
            {
                Login resultado = null;
                if (!string.IsNullOrEmpty(txtUser.Text.Trim()) && !string.IsNullOrEmpty(txtPassw.Text.Trim()))
                {
                    resultado = new Auxiliar().selecionarUno(txtUser.Text.Trim(), txtPassw.Text.Trim());
                    if (resultado != null)
                    {
                        txtUser.Text = resultado.Usuario.ToString();
                        Toast.MakeText(this, "Login realizado con exito", ToastLength.Short).Show();
                        var bienvenido = new Intent(this, typeof(Bienvenido));
                        bienvenido.PutExtra("usuario", FindViewById<EditText>(Resource.Id.txtUser).Text);
                        StartActivity(bienvenido);
                        Finish();
                    }
                    else
                    {
                        Toast.MakeText(this, "Nombre de usuario y/o clave inválida(s)", ToastLength.Long).Show();
                    }

                }
                else
                {
                    Toast.MakeText(this, "Nombre de usuario y/o clave son vacios", ToastLength.Long).Show();
                }


            }
            catch (Exception ex)

            {
                Toast.MakeText(this, ex.ToString(), ToastLength.Short).Show();
            }




        }

        private void Close()
        {
            throw new NotImplementedException();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

    }

}