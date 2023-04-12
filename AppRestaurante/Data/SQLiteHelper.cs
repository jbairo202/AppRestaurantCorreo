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
using SQLite;
using AppRestaurante.Models;

namespace AppRestaurante.Data
{
    public class SQLiteHelper
    {
        SQLiteAsyncConnection db;
        
        public SQLiteHelper(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<CrearPedido>().Wait();
        }
    }
}