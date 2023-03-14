using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Path = System.IO.Path;

namespace AppRestaurante
{
    #region uso de datos de un usuario
    public class Login
    {

        public Login() { }

        [PrimaryKey, AutoIncrement]
        [MaxLength(10)]
        public int Id { get; set; }

        [MaxLength(15)]
        public string Nombre { get; set; }

        [MaxLength(15)]
        public string Apellido { get; set; }

        [MaxLength(15)]
        public string Telefono { get; set; }

        [MaxLength(15)]
        public string Usuario { get; set; }

        [MaxLength(15)]
        public string Password { get; set; }

    }
    #endregion

    #region Manejo de datos y conexion a BD
    public class Auxiliar
    {
        static object loker = new object();
        SQLiteConnection connection;
        public Auxiliar()//Esto es un construtor
        {
            connection = conectarBD();
            connection.CreateTable<Login>();
        }

        public SQLite.SQLiteConnection conectarBD()
        {
            SQLiteConnection connectionBaseDatos;
            string nombreArchivo = "registros.db3";
            string ruta = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string completaRuta = Path.Combine(ruta, nombreArchivo);
            connectionBaseDatos = new SQLiteConnection(completaRuta);
            return connectionBaseDatos;

         }

        //Selecionar un registro
        public Login selecionarUno(string NuevoUsuario, string NuevaClaveUsuario)
        {
            lock (loker)
            {
                return connection.Table<Login>().FirstOrDefault(x => x.Usuario == NuevoUsuario && x.Password == NuevaClaveUsuario);
            }
        }

      

        //Selecionar muchos
        public IEnumerable<Login> selecionarTodo()
        {
            lock (loker)
            {
                return (from i in connection.Table<Login>()select i).ToList();
            }
        }

        //Guardar o actualizar
        public int guardar(Login registro)
        {
            lock (loker)
            {
                if (registro.Id == 0)
                {
                    return connection.Insert(registro);
                }
                else
                {
                    return connection.Update(registro); 
                }
            }
        }

        //Eliminar
        public int eliminar(int ID)
        {
            lock (loker)
            {
                return connection.Delete<Login>(ID);
            }
        }
    
    }
    #endregion

    #region uso de datos de un pedido
    public class CrearPedido
    {

        public CrearPedido() { }

        [PrimaryKey, AutoIncrement]
        [MaxLength(10)]
        public int Id { get; set; }

        [MaxLength(15)]
        public string Nombre { get; set; }

        [MaxLength(15)]
        public string Apellido { get; set; }

        [MaxLength(15)]
        public string Telefono { get; set; }

        [MaxLength(15)]
        public string Direccion { get; set; }

        [MaxLength(15)]
        public string MetodoPago { get; set; }

    }
    #endregion

    #region Manejo de datos y conexion a BD de Peddido
    public class AuxiliarP
    {
        static object loker = new object();
        SQLiteConnection connection;
        public AuxiliarP()//Esto es un construtor
        {
            connection = conectarBD();
            connection.CreateTable<CrearPedido>();
        }

        public SQLite.SQLiteConnection conectarBD()
        {
            SQLiteConnection connectionBaseDatos;
            string nombreArchivo = "registros.db3";
            string ruta = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string completaRuta = Path.Combine(ruta, nombreArchivo);
            connectionBaseDatos = new SQLiteConnection(completaRuta);
            return connectionBaseDatos;

        }

        //Selecionar un pedido
        public CrearPedido selecionarUno(int Id)
        {
            lock (loker)
            {
                return connection.Table<CrearPedido>().FirstOrDefault(x => x.Id == Id);
            }
        }



        //Selecionar muchos
        public IEnumerable<CrearPedido> selecionarTodo()
        {
            lock (loker)
            {
                return (from i in connection.Table<CrearPedido>() select i).ToList();
            }
        }

        //Guardar o actualizar
        public int GuardarPedido(CrearPedido registro)
        {
            lock (loker)
            {
                if (registro.Id == 0)
                {
                    return connection.Insert(registro);
                }
                else
                {
                    return connection.Update(registro);
                }
            }
        }

        //Eliminar
        public int eliminar(int Id)
        {
            lock (loker)
            {
                return connection.Delete<CrearPedido>(Id);
            }
        }

    }
    #endregion

}