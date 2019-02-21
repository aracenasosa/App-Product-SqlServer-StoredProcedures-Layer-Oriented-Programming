using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Interfaz_Morderna_de_Productos.Datos;

namespace Interfaz_Morderna_de_Productos
{
   
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int num = 0;

        Metodos Met = new Metodos();
        string Operacion = "Insertar";
        string IdProd;

        private void Form1_Load(object sender, EventArgs e)
        {

            ListCategories();
            ListBrands();
            ListProduct();
        }

        private void ListCategories()
        {

            Categories.DataSource = Met.Categories();
            Categories.DisplayMember = "Categoria";
            Categories.ValueMember = "IdCag";
        }

        private void ListBrands()
        {

            Brands.DataSource = Met.Brands();
            Brands.DisplayMember = "Marca";
            Brands.ValueMember = "IdMarca";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Operacion.Equals("Insertar"))
            {

                Met.IdCategorie1 = Convert.ToInt32(Categories.SelectedValue);
                Met.IdMarca1 = Convert.ToInt32(Brands.SelectedValue);
                Met.Description1 = Description.Text;
                Met.Price1 = Convert.ToDouble(Precio.Text);
                MessageBox.Show("Insertado Correctamente");
                Met.Insert();

            }else if (Operacion.Equals("Editar"))
            {

                Met.IdProduct1 = Convert.ToInt32(IdProd);
                Met.IdCategorie1 = Convert.ToInt32(Categories.SelectedValue);
                Met.IdMarca1 = Convert.ToInt32(Brands.SelectedValue);
                Met.Description1 = Description.Text;
                Met.Price1 = Convert.ToDouble(Precio.Text);
                Operacion = "Insertar";
                MessageBox.Show("Actualizado Correctamente");
                Met.Update();

            }

            ListProduct();
            Limpiar();
        }
        
        private void ListProduct()
        {
            Panel.DataSource = Met.List();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Panel.SelectedRows.Count > 0)
            {

                Operacion = "Editar";
                Categories.Text = Panel.CurrentRow.Cells["Categoria"].Value.ToString();
                Brands.Text = Panel.CurrentRow.Cells["Marca"].Value.ToString();
                Description.Text = Panel.CurrentRow.Cells["Descripcion"].Value.ToString();
                Precio.Text = Panel.CurrentRow.Cells["Precio"].Value.ToString();
                IdProd = Panel.CurrentRow.Cells["Id"].Value.ToString();

            }
            else
            {
                MessageBox.Show("Debe selecionar una Fila");
            }
        }

        private void Limpiar()
        {
            Categories.Text = "";
            Brands.Text = "";
            Description.Text = "";
            Precio.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(Panel.SelectedRows.Count > 0)
            {

                Met.IdProduct1 = Convert.ToInt32(Panel.CurrentRow.Cells[0].Value.ToString());
                MessageBox.Show("Eliminado Correctamente");
                Met.Delete();
                
            }
            else
            {

                MessageBox.Show("Debe selecionar una Fila");
            }

           ListProduct();
        }
    }
}
