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
                return (from i in connection.Table<Login>() select i).ToList();
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
    
    
        //Creación de la tabla de base de datos
        public class Sign
        {
            public Sign() { }

            //Columna ID con su llave primaria
            [PrimaryKey, AutoIncrement]
            [MaxLength(8)]
            public int ID { set; get; }

            //Columna Nombre
            [MaxLength(15)]
            public String Nombre { get; set; }

            //Columna Apellido
            [MaxLength(15)]
            public String Apellido { get; set; }

            //Columna Telefono
            [MaxLength(10)]
            public String Telefono { get; set; }

            //Columna Direccion
            [MaxLength(10)]
            public String Direccion { get; set; }

            //Columna Metodo de pago
            [MaxLength(10)]
            public String MetoPago { get; set; }
        }
    
    #endregion

    #region Manejo de datos y conexion a BD de Peddido
    //Hacemos la conexión a la base de datos
    public class AuxiliarP
    {
        static object locker = new object();
        SQLiteConnection connection;
        public AuxiliarP()
        {
            connection = conectarBD();
            connection.CreateTable<Sign>();

        }

        public SQLite.SQLiteConnection conectarBD()
        {
            SQLiteConnection enterDatabase;
            String nameDatabase = "queryDatabase.db3";
            String path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            String completPath = Path.Combine(path, nameDatabase);
            enterDatabase = new SQLiteConnection(completPath);
            return enterDatabase;
        }

        //Buscar registro
        public Sign Selection(int Data)
        {
            lock (locker)
            {
                return connection.Table<Sign>().FirstOrDefault(i => i.ID == Data);
            }
        }

        /*public Sign selecionarTodo(int Data)
        {
            lock (locker)
            {
                return (from i in connection.Table<Sign>() select i).ToList();
            }
        }*/

        //Eliminar registro
        public int Destroy(int Id)
        {
            lock (locker)
            {
                return connection.Delete<Sign>(Id);
            }
        }

        //Insertar registro y/o actualizar
        public int Insert(Sign sign)
        {
            lock (locker)
            {
                if (sign.ID == 0)
                {
                    return connection.Insert(sign);
                }
                else
                {
                    return connection.Update(sign);
                }
            }
        }
    }
}
        #endregion

