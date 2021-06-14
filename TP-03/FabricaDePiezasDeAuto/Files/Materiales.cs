using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Files
{
    [Serializable]
    public class Materiales
    {
        private List<Material> _items;

        public List<Material> Items
        {
            get { return _items; }
        }

        /// <summary>
        /// Constructor de Lista.
        /// </summary>
        public Materiales()
        {
            _items = new List<Material>();
        }
    }

    public class Pieces
    {
        private List<Piece> _items;

        public List<Piece> Items
        {
            get { return _items; }
        }

        /// <summary>
        /// Constructor de Lista.
        /// </summary>
        public Pieces()
        {
            _items = new List<Piece>();
        }
    }
}
