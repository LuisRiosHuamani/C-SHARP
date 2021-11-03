﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class E_PRODUCTOS
    {
        private int _Idproducto;
        private string _Codigoproducto;
        private string _Producto;
        private int _Idcategoria;
        private int _Idmarca;
        private decimal _Preciocompra;
        private decimal _Precioventa;
        private int _Stock;

        public int Idproducto { get => _Idproducto; set => _Idproducto = value; }
        public string Codigoproducto { get => _Codigoproducto; set => _Codigoproducto = value; }
        public string Producto { get => _Producto; set => _Producto = value; }
        public int Idcategoria { get => _Idcategoria; set => _Idcategoria = value; }
        public int Idmarca { get => _Idmarca; set => _Idmarca = value; }
        public decimal Preciocompra { get => _Preciocompra; set => _Preciocompra = value; }
        public decimal Precioventa { get => _Precioventa; set => _Precioventa = value; }
        public int Stock { get => _Stock; set => _Stock = value; }
    }
}
