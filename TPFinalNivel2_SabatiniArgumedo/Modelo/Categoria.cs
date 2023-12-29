using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Categoria
    {
        private int id;
        private string description;

        public Categoria()
        {
        }

        public Categoria(int id, string description)
        {
            this.id = id;
            this.description = description;
        }

        [DisplayName("Id")]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        [DisplayName("Descripcion")]
        public string Description
        {
            get { return description; }
            set {  description = value; }
        }


        override
        public string ToString()
        {
            return description;
        }
    }
}
