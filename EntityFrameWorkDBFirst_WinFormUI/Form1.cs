using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityFrameWorkDBFirst_BLL;
using EntityFrameWorkDBFirst_BLL.ViewModels;

namespace EntityFrameWorkDBFirst_WinFormUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ProductManager myProductManager = new ProductManager();

        private void Form1_Load(object sender, EventArgs e)
        {
            //from yüklenirken grid'e product bilgileri gelsin.
            GrideProductlariGetir();
        }

        private void GrideProductlariGetir()
        {
            //BLL aracığıyla listemiz gelecek.
            dataGridView1.DataSource=myProductManager.TumUrunleriGetir();
            dataGridView1.Columns["SupplierID"].Visible = false;
            dataGridView1.Columns["CategoryID"].Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Deneme amaçlı yazıyoruz.
            ProductViewModel yeniUrun = new ProductViewModel()
            {
                ProductName="Deneme Ürün",
                Discontinued=false,
                CategoryID=1
            };
            //myProductManager.YeniUrunEkle(yeniUrun);
        }
    }
}
