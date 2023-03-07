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
    [Activity(Label = "SelectSede")]
    public class SelectSede : Activity
    {
        Spinner spinner;
        //protected override void OnCreate(Bundle bundle)
        //{
        //    base.OnCreate(bundle);

        //    // Set our view from the "Main" layout resource
        //    SetContentView(Resource.Layout.SelectSede);

        //    Spinner spinner = FindViewById<Spinner>(Resource.Id.action_bar_spinner);

        //    spinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
        //    var adapter = ArrayAdapter.CreateFromResource(
        //            this, Resource.Array.ubicacion_array, Android.Resource.Layout.SimpleSpinnerItem);

        //    adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
        //    spinner.Adapter = adapter;
        //}

        private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            string toast = string.Format("The planet is {0}", spinner.GetItemAtPosition(e.Position));
            Toast.MakeText(this, toast, ToastLength.Long).Show();
        }


    }
}