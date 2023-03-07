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
    [Activity(Label = "VerMenu")]
    public class VerMenu : Activity
    {
        CheckBox checkRecogerTienda;
        CheckBox checkDomicilio;
        CheckedTextView Categorias;
        Switch monitored_switch;

        public CheckBox CheckBox { get; private set; }
        public CheckedTextView CheckedTextView { get; private set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.VerMenu);
            CheckedTextView = FindViewById<CheckedTextView>(Resource.Id.bottom);
            // Create your application here
            Switch s = FindViewById<Switch>(Resource.Id.monitored_switch);

            s.CheckedChange += delegate (object sender, CompoundButton.CheckedChangeEventArgs e) {
                var toast = Toast.MakeText(this, "Your answer is " +
                    (e.IsChecked ? "correct" : "incorrect"), ToastLength.Short);
                toast.Show();
            };

        }

    }
}