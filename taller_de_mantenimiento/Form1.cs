using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace taller_de_mantenimiento
{
   
  

    public partial class TxtID_usuario : Form
    {
        
        clases.Conexion conexion = new clases.Conexion();

        public clases.Clientes cliente_seleccionado { get; set; }
        public TxtID_usuario()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                if (conexion.abriconexion()== true)
                {
                    listaclientes(conexion.conexion, TxtNombre.Text, TxtApellido.Text, TxtIdentificacion.Text, TxtTelefono.Text, TxtDireccion.Text, Txtserial.Text, Txtmarca.Text, Txtequipo.Text);
                    conexion.cerrarconexion();
                }

                               
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);

                throw;
            }
            
        }

        public void listaclientes(MySqlConnection conexion, string pNombre, string pApellido, string pIdentificacion,
           string pDatos_equipo, string pSerial, string pMarca, string pTelefono, string pDireccion)
        {
            DgvDatos.DataSource = clases.Clientes.buscar(conexion, pNombre, pApellido, pIdentificacion, pDatos_equipo, pSerial, pMarca, pTelefono, pDireccion);

        }

        private void TbnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (conexion.abriconexion() == true)
                {
                    clases.Clientes pcliente = new clases.Clientes();
                     pcliente.Nombre = TxtNombre.Text;
                    pcliente.Apellido = TxtApellido.Text;
                    pcliente.Indentificacion = TxtIdentificacion.Text;
                    pcliente.Datos_equipo = Txtequipo.Text;
                    pcliente.Serial = Txtserial.Text;
                    pcliente.Marca = Txtmarca.Text;
                    pcliente.Telefono = TxtTelefono.Text;
                    pcliente.Direccion = TxtDireccion.Text;


                    int resultado;

                    if (string.IsNullOrEmpty(TxtIdusuario.Text))
                    {
                        resultado = clases.Clientes.agregar(conexion.conexion, pcliente);
                    }
                    else
                    {
                        pcliente.Id_usuario = Convert.ToInt32(TxtIdusuario.Text);
                        resultado= resultado = clases.Clientes.actualizar(conexion.conexion, pcliente);
                    }

                 

                    if (resultado > 0)
                    {
                        limpiarcajas();
                        listaclientes(conexion.conexion, TxtNombre.Text, TxtApellido.Text, TxtIdentificacion.Text, TxtTelefono.Text, TxtDireccion.Text, Txtserial.Text, Txtmarca.Text, Txtequipo.Text);

                    }

                    conexion.cerrarconexion();
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message, "");
                throw;
            }
        }

        public void limpiarcajas()
        {
            TxtIdusuario.Clear();
            TxtNombre.Clear();
            TxtApellido.Clear();
            TxtIdentificacion.Clear();
            Txtequipo.Clear();
            Txtserial.Clear();
            Txtmarca.Clear();
            TxtTelefono.Clear();
            TxtDireccion.Clear();

           
        }

        private void TbnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (conexion.abriconexion() == true)
                {
                    listaclientes(conexion.conexion, TxtNombre.Text, TxtApellido.Text, TxtIdentificacion.Text, TxtTelefono.Text, TxtDireccion.Text, Txtserial.Text, Txtmarca.Text, Txtequipo.Text);
                    conexion.cerrarconexion();
                }


            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);

                throw;
            }
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (DgvDatos.SelectedRows.Count == 1)
                {
                    int Id_usuario = Convert.ToInt32( DgvDatos.CurrentRow.Cells[0].Value);
                    if (conexion.abriconexion() == true)
                    {
                        cliente_seleccionado = clases.Clientes.obtenercliente(conexion.conexion, Id_usuario);

                        TxtIdusuario.Text = cliente_seleccionado.Id_usuario.ToString();
                        TxtNombre.Text = cliente_seleccionado.Nombre;
                        TxtApellido.Text = cliente_seleccionado.Apellido;
                        TxtIdentificacion.Text = cliente_seleccionado.Indentificacion;
                        TxtTelefono.Text = cliente_seleccionado.Telefono;
                        TxtDireccion.Text = cliente_seleccionado.Direccion;
                        Txtequipo.Text = cliente_seleccionado.Datos_equipo;
                        Txtserial.Text = cliente_seleccionado.Serial;
                        Txtmarca.Text = cliente_seleccionado.Marca;

                    }
                    if (conexion.cerrarconexion() == true)
                    {

                    }
                }
                else
                {
                    MessageBox.Show("debe seleccionar un registro");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void TbnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (DgvDatos.SelectedRows.Count == 1)
                {
                     int idusuario = Convert.ToInt32(DgvDatos.CurrentRow.Cells[0].Value);

                    DialogResult confirmacionEliminacion = MessageBox.Show("se eliminara el registro"+idusuario+",desea continuar","ALERTA DE ELIMINACION",MessageBoxButtons.YesNo);

                    if (confirmacionEliminacion == DialogResult.Yes)
                    {
                        if (conexion.abriconexion() == true)
                        {
                            int resultado = clases.Clientes.eliminar(conexion.conexion, idusuario);
                            if (resultado > 0)
                            {
                                TxtIdusuario.Clear();
                                TxtNombre.Clear();
                                TxtApellido.Clear();
                                TxtIdentificacion.Clear();
                                Txtequipo.Clear();
                                Txtserial.Clear();
                                Txtmarca.Clear();
                                TxtTelefono.Clear();
                                TxtDireccion.Clear();
                                listaclientes(conexion.conexion, TxtNombre.Text, TxtApellido.Text, TxtIdentificacion.Text, TxtTelefono.Text, TxtDireccion.Text, Txtserial.Text, Txtmarca.Text, Txtequipo.Text);
                                conexion.cerrarconexion();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Eliminacion cancelada");
                        TxtIdusuario.Clear();
                        TxtNombre.Clear();
                        TxtApellido.Clear();
                        TxtIdentificacion.Clear();
                        Txtequipo.Clear();
                        Txtserial.Clear();
                        Txtmarca.Clear();
                        TxtTelefono.Clear();
                        TxtDireccion.Clear();
                        conexion.cerrarconexion();

                    }

                    }
                else
                {
                    MessageBox.Show("debe seleccionar un registro");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
