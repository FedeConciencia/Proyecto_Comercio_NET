using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Modelo;
using Controlador;

namespace presentacion
{
    public partial class Form1 : Form
    {
        //Variable de Clase:
        private List<Articulo> listArticulo;

        public Form1()
        {
            InitializeComponent();
        }

        //Metodo Carga del Formulario:
        private void Form1_Load(object sender, EventArgs e)
        {


            cargar();

            //Cargamos los desplegables del Filtro Avanzado:
            cboCampo.Items.Add("Codigo");
            cboCampo.Items.Add("Nombre");
            cboCampo.Items.Add("Descripcion");

            cboCriterio.Items.Clear();
            cboCriterio.Items.Add("Comienza con");
            cboCriterio.Items.Add("Termina con");
            cboCriterio.Items.Add("Contiene a");

            //Permite que siempre se seleccione un valor (Primero):
            cboCampo.SelectedIndex = 0;
            cboCriterio.SelectedIndex = 0;


        }

        

        //Funcion Creada para cargar una imagen y atrapar una excepcion en caso de error:
        private void cargarImagen(string imagen)
        {
            try
            {

                if (imagen != null && imagen != "")
                {
                    pictureBox.Load(imagen);
                }
                else
                {
                    pictureBox.Load("https://www.pngall.com/wp-content/uploads/2/Upload-PNG-Pic.png");
                }

            }
            catch (Exception ex)
            {
                pictureBox.Load("https://www.pngall.com/wp-content/uploads/2/Upload-PNG-Pic.png");
            }
        }


        private void cargar()
        {
            try
            {
                ControladorArticulo controlArt = new ControladorArticulo();

                listArticulo = controlArt.allArtCatMar();

                if (listArticulo.Count > 0)
                {
                    dataGrid.DataSource = listArticulo;
                    dataGrid.Columns[4].Visible = false;
                    cargarImagen(listArticulo[0].ImgUrl);

                }
                else
                {

                    MessageBox.Show("No hay articulos disponibles en la BD, Inserte algunos.");

                }

               

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error. " + ex.ToString());

            }
        }

        //Metodo Busqueda Filtro:
        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {

        }

        //Con este metodo lanzamos el evento selector de fila y capturamos el valor de la URL imagen:
        private void dataGrid_SelectionChanged_1(object sender, EventArgs e)
        {
            Articulo articulo = (Articulo) dataGrid.CurrentRow.DataBoundItem;
            cargarImagen(articulo.ImgUrl);
        }

        private void btnFiltro_Click(object sender, EventArgs e)
        {
            ControladorArticulo controlador = new ControladorArticulo();
            List<Articulo> listArticulo = new List<Articulo>();

            try
            {

                string campo = cboCampo.SelectedItem.ToString();
                string criterio = cboCriterio.SelectedItem.ToString();
                string filtro = txtFiltro.Text;

                //Si el Filtro es Vacio que traiga todos los Pokemons:
                if (filtro != "")
                {

                    listArticulo = controlador.filtroAvanzado(campo, criterio, filtro);

                    dataGrid.DataSource = listArticulo;

                    cargarImagen(listArticulo[0].ImgUrl);

                }
                else
                {
                    //Actualiza 
                    cargar();

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error. No se encuentran Articulos para el Filtro Ingresado." + ex.Message);
                cargar();
            }
        }
    }
}
