using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace exchange
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            string bugun = "https://www.tcmb.gov.tr/kurlar/today.xml";
            var xmldosya = new XmlDocument();
            xmldosya.Load(bugun);
            string dolaralis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteBuying").InnerXml;
            lbldolaralis.Text = dolaralis;
            string dolarsatis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteSelling").InnerXml;
            lbldolarsatis.Text = dolarsatis;
            string euroalis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteBuying").InnerXml;
            lbleuroalis.Text = euroalis;
            string eurosatis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteSelling").InnerXml;
            lbleurosatis.Text = eurosatis;
        }

        private void btndolaraliss_Click(object sender, EventArgs e)
        {
            txtkur.Text = lbldolaralis.Text;
        }

        private void btndolarsatis_Click(object sender, EventArgs e)
        {
            txtkur.Text = lbldolarsatis.Text;
        }

        private void btneuroalis_Click(object sender, EventArgs e)
        {
            txtkur.Text = lbleuroalis.Text;
        }

        private void btneurosatis_Click(object sender, EventArgs e)
        {
            txtkur.Text = lbleurosatis.Text;
        }

        private void btnsatis_Click(object sender, EventArgs e)
        {
            double kur, miktar, tutar;
            kur = Convert.ToDouble(txtkur.Text);
            miktar = Convert.ToDouble(txtmiktar.Text);
            tutar = kur * miktar;
            txttutar.Text = tutar.ToString();

        }

        private void txtkur_TextChanged(object sender, EventArgs e)
        {
            txtkur.Text = txtkur.Text.Replace(".",",");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double kur = Convert.ToDouble(txtkur.Text);
            int miktar = Convert.ToInt32(txtmiktar.Text);
            int tutar = Convert.ToInt32(miktar /kur );
            txttutar.Text = tutar.ToString();
            double kalan;
            kalan = miktar % kur;
            txtkalan.Text = kalan.ToString();

        }
    }
}
