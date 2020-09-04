using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Proyecto_Final
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Conexion.Conectar();
            MessageBox.Show("Conectado");

            dataGridView1.DataSource = Llenar_grid();

        }

        public DataTable Llenar_grid()
        {
            Conexion.Conectar();
            DataTable dt = new DataTable();
            string consulta = "Select * from solicitudes";
            SqlCommand cmd = new SqlCommand(consulta, Conexion.Conectar());

            SqlDataAdapter dat = new SqlDataAdapter(cmd);

        dat.Fill(dt);
        return dt;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string insertar = "INSERT INTO solicitudes (Personal,Cliente,Numero,Correo,Empresa,Direccion,Descripcion,Costo)VALUES(@Personal,@Cliente,@Numero,@Correo,@Empresa,@Direccion,@Descripcion,@Costo)";
            SqlCommand cmd1 = new SqlCommand(insertar, Conexion.Conectar());
            cmd1.Parameters.AddWithValue("@Personal", textPersonal.Text);
            cmd1.Parameters.AddWithValue("@Cliente", textCliente.Text);
            cmd1.Parameters.AddWithValue("@Numero", textNumero.Text);
            cmd1.Parameters.AddWithValue("@Correo", textCorreo.Text);
            cmd1.Parameters.AddWithValue("@Empresa", textEmpresa.Text);
            cmd1.Parameters.AddWithValue("@Direccion", textDireccion.Text);
            cmd1.Parameters.AddWithValue("@Descripcion", textDescripcion.Text);
            cmd1.Parameters.AddWithValue("@Costo", textCosto.Text);

            cmd1.ExecuteNonQuery();

            MessageBox.Show("Los datos fueron agregados");

            dataGridView1.DataSource = Llenar_grid();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          try
            {
                textPersonal.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                textCliente.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textNumero.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                textCorreo.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                textEmpresa.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                textDireccion.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                textDescripcion.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                textCosto.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            }
            catch{ }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string actualizar = "update solicitudes set Personal=@Personal, Cliente=@Cliente, Numero=@Numero, Correo=@Correo, Empresa=@Empresa, Direccion=@Direccion, Descripcion=@Descripcion, Costo=@Costo where Cliente=@Cliente";
            SqlCommand cmd2 = new SqlCommand(actualizar, Conexion.Conectar());

            cmd2.Parameters.AddWithValue("@Personal", textPersonal.Text);
            cmd2.Parameters.AddWithValue("@Cliente", textCliente.Text);
            cmd2.Parameters.AddWithValue("@Numero", textNumero.Text);
            cmd2.Parameters.AddWithValue("@Correo", textCorreo.Text);
            cmd2.Parameters.AddWithValue("@Empresa", textEmpresa.Text);
            cmd2.Parameters.AddWithValue("@Direccion", textDireccion.Text);
            cmd2.Parameters.AddWithValue("@Descripcion", textDescripcion.Text);
            cmd2.Parameters.AddWithValue("@Costo", textCosto.Text);

            cmd2.ExecuteNonQuery();

            MessageBox.Show("Los datos fueron actualizados");
            dataGridView1.DataSource = Llenar_grid();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string eliminar = "Delete from solicitudes where Cliente=@Cliente";
            SqlCommand cmd3 = new SqlCommand(eliminar, Conexion.Conectar());
            cmd3.Parameters.AddWithValue("@Cliente", textCliente.Text);

            cmd3.ExecuteNonQuery();

            MessageBox.Show("Los datos fueron eliminados");
            dataGridView1.DataSource = Llenar_grid();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            textPersonal.Clear();
            textCliente.Clear();
            textNumero.Clear();
            textCorreo.Clear();
            textEmpresa.Clear();
            textDireccion.Clear();
            textDescripcion.Clear();
            textCosto.Clear();
            textCliente.Focus();

        }
    }
}
