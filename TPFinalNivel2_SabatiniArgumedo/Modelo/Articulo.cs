using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Articulo
    {

        private int id;
        private string code;
        private string name;
        private string description;
        private string imgUrl;
        private double price;
        private Marca marca;
        private Categoria categoria;

        public Articulo()
        {
        }

        public Articulo(int id, string code, string name, string description, string imgUrl, double price)
        {
            this.id = id;
            this.code = code;
            this.name = name;
            this.description = description;
            this.imgUrl = imgUrl;
            this.price = price;
        }

        public Articulo(string code, string name, string description, string imgUrl, double price, Marca marca, Categoria categoria)
        {
            this.code = code;
            this.name = name;
            this.description = description;
            this.imgUrl = imgUrl;
            this.price = price;
            this.marca = marca;
            this.categoria = categoria;
        }

        public Articulo(int id, string code, string name, string description, string imgUrl, double price, Marca marca, Categoria categoria)
        {
            this.id = id;
            this.code = code;
            this.name = name;
            this.description = description;
            this.imgUrl = imgUrl;
            this.price = price;
            this.marca = marca;
            this.categoria = categoria;
        }


        [DisplayName("Id")]
        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }


        [DisplayName("Codigo")]
        public string Code
        {
            get { return this.code; }
            set { this.code = value; }
        }

        [DisplayName("Nombre")]
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        [DisplayName("Descripcion")]
        public string Description
        {
            get { return this.description; }
            set { this.description = value; }
        }

        [DisplayName("ImagenUrl")]
        public string ImgUrl
        {
            get { return this.imgUrl; }
            set { this.imgUrl = value; }
        }

        [DisplayName("Precio")]
        public double Price
        {
            get { return this.price; }
            set { this.price = value; }

        }

        [DisplayName("Marca")]
        public Marca Marca 
        { 
            get { return this.marca; }
            set { this.marca = value; }
        
        }

        [DisplayName("Categoria")]
        public Categoria Categoria
        {
            get { return this.categoria; }
            set { this.categoria = value; }

        }

    }
}
