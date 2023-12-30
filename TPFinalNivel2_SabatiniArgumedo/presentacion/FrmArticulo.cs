using Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controlador;
using System.Xml.Linq;

namespace presentacion
{
    public partial class FrmArticulo : Form
    {

        private Articulo articulo = null;
        bool activo = false;

        //Sobrecarga de Metodo Constructor:
        public FrmArticulo()
        {
            InitializeComponent();
            Text = "ALTA DE ARTICULO";
        }

        //Le pasamos por parametro el objeto Articulo que recibe:
        public FrmArticulo(Articulo articulo)
        {
            InitializeComponent();
            this.articulo = articulo;
            Text = "MODIFICAR ARTICULO";
        }

        //Le pasamos por parametro el objeto Articulo que recibe:
        public FrmArticulo(Articulo articulo, bool activo)
        {
            InitializeComponent();
            this.articulo = articulo;
            this.activo = activo;
            Text = "DETALLE ARTICULO";
        }

        //Metodo Evento boton cancelar:
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            //Cerramos el Form:
            this.Close();
        }

        //Metodo creado para cargar una imagen y atrapar una excepcion:
        private void cargarImagen(string imagen)
        {
            try
            {
                pictureImg.Load(imagen);
            }
            catch (Exception ex)
            {
                pictureImg.Load("https://c1.wallpaperflare.com/preview/251/931/705/not-found-404-error-file-not-found-404-file-not-found.jpg");
            }
        }

        //Metodo para evento para ingreso de caracteres en txtImgUrl:
        private void txtUrl_TextChanged(object sender, EventArgs e)
        {
        
            string img = txtUrl.Text;
            cargarImagen(img);
            
        }

        //Evento para carga de FormArticulo:
        private void FrmArticulo_Load(object sender, EventArgs e)
        {
            
            ControladorMarca controlMarca = new ControladorMarca();
            ControladorCategoria controlCategoria = new ControladorCategoria();

            try
            {

                //Cargamos los comboBox:
                cboMarca.DataSource = controlMarca.allMarcas();
                cboMarca.ValueMember = "Id";
                cboMarca.DisplayMember = "Description";

                cboCat.DataSource = controlCategoria.allCategorias();
                cboCat.ValueMember = "Id";
                cboCat.DisplayMember = "Description";

                //Verificamos si hay datos por parametro y los traemos:
                if (articulo != null && activo == false)
                {
                    

                    txtCod.Text = articulo.Code;
                    txtNom.Text = articulo.Name;
                    txtDesc.Text = articulo.Description;
                    txtUrl.Text = articulo.ImgUrl;
                    txtPrec.Text = (articulo.Price).ToString();
                    cboMarca.SelectedValue = articulo.Marca.Id;
                    cboCat.SelectedValue = articulo.Categoria.Id;
                }
                else if (articulo != null && activo == true)
                {
                    

                    txtCod.Text = articulo.Code;
                    txtNom.Text = articulo.Name;
                    txtDesc.Text = articulo.Description;
                    txtUrl.Text = articulo.ImgUrl;
                    txtPrec.Text = (articulo.Price).ToString();
                    cboMarca.SelectedValue = articulo.Marca.Id;
                    cboCat.SelectedValue = articulo.Categoria.Id;

                    //Se bloquean todas las ediciones, solo view:
                    txtCod.Enabled = false;
                    txtNom.Enabled = false;
                    txtDesc.Enabled = false;
                    txtUrl.Enabled = false;
                    txtPrec.Enabled = false;
                    cboCat.Enabled = false;
                    cboMarca.Enabled = false;

                    btnAceptar.Enabled = false;

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error." + ex.ToString());

            }
        }

        //Gestiona la Validacion de todos los txt ingreso de datos:
        private bool validarDatos()
        {

            bool bandera = false;

            //Valida ComboBox Marca:
            if (cboMarca.SelectedIndex < 0)
            {
                lblErrMarca2.Text = "*";
                lblErrMarca1.Text = "Error. Debe seleccionar un valor.";
                cboMarca.BackColor = Color.Red;
                bandera = true;
            }
            else
            {
                lblErrMarca2.Text = "";
                lblErrMarca1.Text = "";
                cboMarca.BackColor = Color.White;

            }

            //Valida ComboBox Categoria:
            if (cboCat.SelectedIndex < 0)
            {
                lblErrCat2.Text = "*";
                lblErrMarca1.Text = "Error. Debe seleccionar un valor.";
                cboCat.BackColor = Color.Red;
                bandera = true;
            }
            else
            {
                lblErrCat2.Text = "";
                lblErrCat1.Text = "";
                cboCat.BackColor = Color.White;

            }


            //Valida Txt Codigo:
            if (string.IsNullOrEmpty(txtCod.Text))
            {
                lblErrCod2.Text = "*";
                lblErrCod1.Text = "Error. Debe ingresar un valor.";
                txtCod.BackColor = Color.Red;
                bandera = true;
            }
            else
            {
                lblErrCod2.Text = "";
                lblErrCod1.Text = "";
                txtCod.BackColor = Color.White;

            }


            //Valida Txt Nombre:
            if (string.IsNullOrEmpty(txtNom.Text))
            {
                lblErrNom2.Text = "*";
                lblErrNom1.Text = "Error. Debe ingresar un valor.";
                txtNom.BackColor = Color.Red;
                bandera = true;
            }
            else
            {
                lblErrNom2.Text = "";
                lblErrNom1.Text = "";
                txtNom.BackColor = Color.White;

            }

            //Valida Txt Descripcion:
            if (string.IsNullOrEmpty(txtDesc.Text))
            {
                lblErrDesc2.Text = "*";
                lblErrDesc1.Text = "Error. Debe ingresar un valor.";
                txtDesc.BackColor = Color.Red;
                bandera = true;
            }
            else
            {
                lblErrDesc2.Text = "";
                lblErrDesc1.Text = "";
                txtDesc.BackColor = Color.White;

            }

            //Valida Txt ImgUrl:
            if (string.IsNullOrEmpty(txtUrl.Text))
            {
                lblErrImg2.Text = "*";
                lblErrImg1.Text = "Error. Debe ingresar un valor.";
                txtUrl.BackColor = Color.Red;
                bandera = true;
            }
            else
            {
                lblErrImg2.Text = "";
                lblErrImg1.Text = "";
                txtUrl.BackColor = Color.White;

            }


            //Valida Txt Precio:
            if (string.IsNullOrEmpty(txtPrec.Text))
            {
                lblErrPrec2.Text = "*";
                lblErrPrec1.Text = "Error. Debe ingresar un valor.";
                txtPrec.BackColor = Color.Red;
                bandera = true;
            }
            else
            {
                lblErrPrec2.Text = "";
                lblErrPrec1.Text = "";
                txtPrec.BackColor = Color.White;

                if (!(soloNumeros(txtPrec.Text)))
                {

                    lblErrPrec2.Text = "*";
                    lblErrPrec1.Text = "Error. No puede ingresar caracteres.";
                    txtPrec.BackColor = Color.Red;
                    bandera = true;
                }
                else
                {

                    lblErrPrec2.Text = "";
                    lblErrPrec1.Text = "";
                    txtPrec.BackColor = Color.White;

                }

            }


            return bandera;
        }

        //Validar si el numero ingresado en precio es un numero decimal:
        private bool soloNumeros(string stringNumber)
        {
            //Devuelve False, si el numero ingresado contiene caracteres:
            double numericValue;
            bool isNumber = double.TryParse(stringNumber, out numericValue);
            return isNumber;
        }

        //Evento de boton Insertar Articulo:
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            ControladorArticulo control = new ControladorArticulo();

            List<Articulo> list = control.allArticulo();

            bool bandera = false;

            try
            {
                //Verificamos si el Objeto Articulo es null:
                if (articulo == null)
                {
                    
                    //Procedemos a un INSERT:

                    //Si existe alguna validacion erronea aborta la carga de datos:
                    if (validarDatos())
                    {
                        MessageBox.Show("Error, Verificar los datos ingresados.");
                        return;
                    }


                    articulo = new Articulo();

                    //Obtenemos o Capturamos los valores Ingresados con el evento Click:
                    string codigo = txtCod.Text;
                    string nombre = txtNom.Text;
                    string descripcion = txtDesc.Text;
                    string url = txtUrl.Text;
                    double precio = Double.Parse(txtPrec.Text);
                    Marca marca = (Marca) cboMarca.SelectedItem;
                    Categoria categoria = (Categoria) cboCat.SelectedItem;


                    //Asignamos los valores capturados a las propiedades del Objeto Articulo:
                    articulo.Code = codigo;
                    articulo.Name = nombre;
                    articulo.Description = descripcion;
                    articulo.ImgUrl = url;
                    articulo.Price = precio;
                    articulo.Marca = marca;
                    articulo.Categoria = categoria;

                    /*MessageBox.Show("Codigo: " + articulo.Code +
                                      "\nNombre: " + articulo.Name +
                                      "\nDescripcion: " + articulo.Description +
                                      "\nImgUrl: " + articulo.ImgUrl +
                                      "\nPrecio: " + articulo.Price +
                                      "\nMarca: " + articulo.Marca.Description +
                                       "\nCategoria: " + articulo.Categoria.Description);*/


                    //Verificamos si el Articulo Existe en la BD:
                    foreach (Articulo item in list)
                    {
                        if (item.Code == articulo.Code)
                        {
                            bandera = true;
                        }
                    }

                    if (bandera == true)
                    {
                        MessageBox.Show($"Importante !!! Se Verifica que el Articulo Codigo {articulo.Code}, ya se encuentra ingresado en la BD.");
                    }
                    else
                    {

                        control.insertArticulo(articulo);

                        MessageBox.Show("La carga del Articulo fue exitosa.");
                    }

                    //Cerramos el Form:
                    this.Close();

                }
                else if(articulo != null && activo == false)
                {

                    
                    //Procedemos a un UPDATE:

                    //Si existe alguna validacion erronea aborta la carga de datos:
                    if (validarDatos())
                    {
                        MessageBox.Show("Error, Verificar los datos ingresados.");
                        return;
                    }

                    //Obtenemos o Capturamos los valores Ingresados con el evento Click:
                    string codigo = txtCod.Text;
                    string nombre = txtNom.Text;
                    string descripcion = txtDesc.Text;
                    string url = txtUrl.Text;
                    double precio = Double.Parse(txtPrec.Text);
                    Marca marca = (Marca)cboMarca.SelectedItem;
                    Categoria categoria = (Categoria)cboCat.SelectedItem;


                    //Asignamos los valores capturados a las propiedades del Objeto Articulo:
                    articulo.Code = codigo;
                    articulo.Name = nombre;
                    articulo.Description = descripcion;
                    articulo.ImgUrl = url;
                    articulo.Price = precio;
                    articulo.Marca = marca;
                    articulo.Categoria = categoria;

                    /*MessageBox.Show("Codigo: " + articulo.Code +
                                      "\nNombre: " + articulo.Name + 
                                      "\nDescripcion: " + articulo.Description + 
                                      "\nImgUrl: " + articulo.ImgUrl + 
                                      "\nPrecio: " + articulo.Price + 
                                      "\nMarca: " + articulo.Marca.Description +
                                       "\nCategoria: " + articulo.Categoria.Description);*/

                    control.updateArticulo(articulo);

                    MessageBox.Show("La actualizacion del Articulo fue exitosa.");

                    //Cerramos el Form:
                    this.Close();


                }
                




            }
            catch (Exception ex)
            {

                MessageBox.Show("Error, no fue posible gestionar lo solicitado." + ex.ToString());

            }

        }

        

    }
}
