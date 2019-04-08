using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mitiendita
{
    class Tiendita
    {
        private string _Producto;
        public int _Cantidad;
        private double _Total;
        private double _Precio;
        public string Producto
        {
            get { return _Producto; }
        }
        public int Cantidad
        {
            get { return _Cantidad; }
        }
        public double Total
        {
            get { return _Cantidad; }
        }
        public double Precio
        {
            get { return _Precio; }
        }
        public Tiendita(string producto, double precio, int cantidad)
        {
            _Producto = producto;
            _Cantidad = cantidad;
            _Precio = precio;
            _Total = precio * cantidad;
        }
        public double Importe()
        {    //El importe se saca multiplicando la cantidad por el precio del producto
            double Importe = Precio * _Cantidad;
            return Importe;
        }
        public double IVA(double SubT)
        {       //El iva en mexico es 0.16%
            double iva = SubT * 0.16;
            return iva;
        }
        public override string ToString()
        {
            return "Producto: " + _Producto.ToString() + "  Cantidad: " + _Cantidad.ToString() +"  Precio C/u: $ " + _Precio.ToString() + "  Monto Total: $" + _Total.ToString() + Environment.NewLine;

        }
    }
}
