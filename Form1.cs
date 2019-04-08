using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace Mitiendita
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        double total, sub_total,pagar,cambio;
        private void Agregar_Click(object sender, EventArgs e)
        {
           // double total, sub_total;
            string producto = Producto.Text;
            double precio = Convert.ToDouble(Precio.Text);
            int cantidad = Convert.ToInt32(Cantidad.Text);
            Tiendita tienda = new Tiendita(producto, precio, cantidad);
            double importe = tienda.Importe();//(Precio por cantidad)
            Importe.Text = Convert.ToString(importe);
            sub_total =sub_total +importe;
            Sub_total.Text = Convert.ToString(sub_total);
            double Iva = tienda.IVA(sub_total);
            IVA.Text = Convert.ToString(Iva);//Tuve que poner Iva sin mayuscula por que no me tomaba la textbox
            total = sub_total + Iva;
            Total.Text = Convert.ToString(total);
            Carrito.Items.Add(tienda.ToString());
        }

        private void Ticket_Click(object sender, EventArgs e)
        {
            /*No supe como mostrar el total antes de pagar, por que puestra el total ya restandolo el pagar*/
            saveFileDialog1.ShowDialog();
            string rutaArchivo;
            rutaArchivo = saveFileDialog1.FileName;
            FileStream fs = new FileStream(rutaArchivo, FileMode.Create);
            StreamWriter ticket = new StreamWriter(fs);
            ticket.WriteLine("Ticket");
            ticket.WriteLine("Kiosko" + Environment.NewLine);
            for(int i = 0; i < Carrito.Items.Count; i++)
            {
                ticket.WriteLine(Carrito.Items[i].ToString());
            }
            ticket.WriteLine("Subtotal: $"+sub_total.ToString());
            ticket.WriteLine("Subtotal con Iva del 16%:  $"+total.ToString());
            ticket.WriteLine("Se pago con: "+pagar.ToString());
            ticket.WriteLine("Cambio: " + (pagar-total).ToString());//tuve que hacer asi el cambio por que no me daba con la variable cambio
            ticket.Close();
            fs.Close();
        }

        private void Pagar_Click(object sender, EventArgs e)
        {
             pagar = Convert.ToDouble(Supago.Text);
            double cambio;
            if (pagar < 0)
            {
                pagar =0;
            }
            if (pagar > total)
            {
                cambio = pagar - total;
                Cambio.Text = Convert.ToString(cambio);
                cambio = pagar - total;
                Total.Text = "0";
            }
            else
            {
                total -= pagar;
                Cambio.Text = "0";
                Sub_total.Text = Convert.ToString(sub_total);
                Total.Text = Convert.ToString(total);
            }
           
            
        }
    }
}
