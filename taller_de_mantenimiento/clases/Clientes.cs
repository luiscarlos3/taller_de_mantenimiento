using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace taller_de_mantenimiento.clases
{
    public class Clientes
    {
       
        public int Id_usuario { get; set; }

        public string Nombre{ get; set; }       

        public string Apellido{get; set;}

        public string Indentificacion { get; set; }

        public string Datos_equipo { get; set; }

        public string Serial { get; set; }

        public string Marca { get; set; }

        public string Telefono { get; set; }

        public string Direccion { get; set; }


        public Clientes()
        {

        }

        public Clientes(int pId_usuario, string pNombre, string pApellido, string pIdentificacion,
           string pDatos_equipo, string pSerial, string pMarca, string pTelefono, string pDireccion)
        {
            this.Id_usuario = pId_usuario;
            this.Nombre = pNombre;
            this.Apellido = pApellido;
            this.Indentificacion = pIdentificacion;
            this.Datos_equipo = pDatos_equipo;
            this.Serial = pSerial;
            this.Marca = pMarca;
            this.Telefono = pTelefono;
            this.Direccion = pDireccion;
        }

        public static int agregar(MySqlConnection conexion, Clientes pcliente)
        {
            int retorno = 0;
            MySqlCommand comando = new MySqlCommand(String.Format("INSERT INTO cliente ( Nombre, Apellido, Identificacion, Marca, `Serial`, Datos_equipo, Telefono, Direccion) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}')", pcliente.Nombre, pcliente.Apellido, pcliente.Indentificacion, pcliente.Marca, pcliente.Serial, pcliente.Datos_equipo, pcliente.Telefono, pcliente.Direccion), conexion);
            retorno = comando.ExecuteNonQuery();
            return retorno;
        }
       
        public static int actualizar(MySqlConnection conexion, Clientes pcliente)
        {
            int retorno = 0;
            MySqlCommand comando = new MySqlCommand(String.Format("UPDATE  cliente SET  Nombre= '{1}', Apellido='{2}', Identificacion='{3}', Marca='{4}', Serial='{5}', Datos_equipo='{6}', Telefono='{7}', Direccion='{8}' WHERE id_cliente='{0}')", pcliente.Id_usuario,pcliente.Nombre,pcliente.Apellido,pcliente.Indentificacion,pcliente.Marca,pcliente.Marca, pcliente.Serial, pcliente.Datos_equipo, pcliente.Telefono, pcliente.Direccion),conexion);
            retorno = comando.ExecuteNonQuery();
            return retorno;
        }
        // error public static int eliminar(MySqlConnection conexion, Clientes pid_cliente)
            public static int eliminar(MySqlConnection conexion, int pid_cliente)
        {
            int retorno = 0;
            MySqlCommand comando = new MySqlCommand(String.Format("DELETE FROM cliente WHERE id_cliente='{0}'", pid_cliente), conexion);
            retorno = comando.ExecuteNonQuery();
            return retorno;
        }
        public static IList<Clientes> buscar(MySqlConnection conexion, string pNombre, string pApellido, string pIdentificacion,
           string pDatos_equipo, string pSerial, string pMarca, string pTelefono, string pDireccion)
        {
            List<Clientes> Lista = new List<Clientes>();
            MySqlCommand comando = new MySqlCommand(String.Format("SELECT id_cliente, Nombre, Apellido, identificacion, Marca, Serial, Datos_equipo, Telefono, Direccion FROM cliente WHERE Identificacion = '{0}' ", pIdentificacion), conexion);
            MySqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                Clientes pclientes = new Clientes();
                pclientes.Id_usuario = reader.GetInt32(0);
                pclientes.Nombre = reader.GetString(1);
                pclientes.Apellido = reader.GetString(2);
                pclientes.Indentificacion = reader.GetString(3);
                pclientes.Datos_equipo = reader.GetString(4);
                pclientes.Serial = reader.GetString(5);
                pclientes.Marca = reader.GetString(6);
                pclientes.Telefono = reader.GetString(7);
                pclientes.Direccion = reader.GetString(8);

                Lista.Add(pclientes);
            }
            return Lista;
        }



        public static Clientes obtenercliente(MySqlConnection conexion, int pId_usuario)
        {
            Clientes pcliente = new Clientes();

            MySqlCommand comando = new MySqlCommand(String.Format("SELECT id_cliente FROM cliente ", pcliente), conexion);
            MySqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                pcliente.Id_usuario = reader.GetInt32(0);
                pcliente.Nombre = reader.GetString(1);
                pcliente.Apellido = reader.GetString(2);
                pcliente.Indentificacion = reader.GetString(3);
                pcliente.Datos_equipo = reader.GetString(4);
                pcliente.Serial = reader.GetString(5);
                pcliente.Marca = reader.GetString(6);
                pcliente.Telefono = reader.GetString(7);
                pcliente.Direccion = reader.GetString(8);
            }
            return pcliente;

        }






    }
}
