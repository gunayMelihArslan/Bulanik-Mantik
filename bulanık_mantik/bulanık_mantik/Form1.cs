using System;
using System.Windows.Forms;
namespace bulanık_mantik
{
    public partial class Form1 : Form
    {
        double sicaklikDeger, nemDeger;
        bool ve1, veya1, maksimum1, agirlikliOrtalama1;
        string om1;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // SOM MOM LOM yaklaşım seçenekleri ComboBox öğesine eklenir
            om.Items.Add("SOM");
            om.Items.Add("LOM");
            om.Items.Add("MOM");
        }
        private void maksimum_CheckedChanged(object sender, EventArgs e)
        {
            // ComboBox sadece maksimum üyelik yaklaşımı seçildiğinde lazım olduğundan sadece seçildiğinde aktif edilir
            om.Enabled = maksimum.Checked;
        }

        private void agirlikliOrtalama_CheckedChanged(object sender, EventArgs e)
        {
            // ve, veya metotları sadece ağırlıklı ortalama yaklaşımı seçildiğinde lazım olduğundan sadece seçildiğinde aktif edilirler
            ve.Enabled = agirlikliOrtalama.Checked;
            veya.Enabled = agirlikliOrtalama.Checked;
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Değerler girildikten sonra kullanıcı elini klavyeden ayırmadan hesaplama yapabilsin diye klavyeden enter tuşu hesapla butonuna bağlanır
                hesapla.PerformClick();
            }
            
        }
        public void okuma()
        {   
            // TextBox ComboBox ve RadioButton nesnelerine girilen değerler okunur ve ilgili değişkenlere tanımlanır

            ve1 = ve.Checked;
            veya1 = veya.Checked;
            maksimum1 = maksimum.Checked;
            agirlikliOrtalama1 = agirlikliOrtalama.Checked;
            om1 = om.Text;
        }
        private void hesapla_Click(object sender, EventArgs e)
        {
            
            if (sicaklik.Text == string.Empty || nem.Text == string.Empty)
            {   
                // Sıcaklık veya nem değerleri girilmezse bir uyarı penceresi açılır
                MessageBox.Show("Boş alan hatası", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                okuma();
                sicaklikDeger = Convert.ToDouble(sicaklik.Text);
                nemDeger = Convert.ToDouble(nem.Text);
                if (sicaklikDeger > 50 || sicaklikDeger < -10)
                {
                    // Olması gereken aralığın dışında bir sıcaklık değeri girilirse uyarı penceresi açılır
                    MessageBox.Show("Hatalı sıcaklık değeri", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (nemDeger > 100 || nemDeger < 0)
                {
                    // Olması gereken aralığın dışında bir nem değeri girilirse uyarı penceresi açılır
                    MessageBox.Show("Hatalı nem değeri", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (agirlikliOrtalama1 == true && veya1 == false && ve1 == false) 
                {
                    // Ağırlıklı ortalama yaklaşımı seçilmişken ve, veya yöntemlerinden biri seçilmemişse uyarı penceresi açılır
                    MessageBox.Show("Metot seçilmedi", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (maksimum1 == false && agirlikliOrtalama1 == false)
                {
                    // Herhangi yaklaşım seçilmezse uyarı penceresi açılır
                    MessageBox.Show("Yaklaşım seçilmedi", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (maksimum1 == true && om.Text == string.Empty || om.Text == " ")
                {
                    // Maksimum üyelik yaklaşımı seçilmişken SOM MOM LOM seçilmemişse uyarı penceresi açılır
                    MessageBox.Show("Hatalı seçim", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    // Tüm seçimler doğru yapılmış ve değerler doğru girilmişse gerekli değişkenler gönderilerek Form2 açılır
                    Form2 form2 = new Form2();
                    form2.sicaklikDeger2 = sicaklikDeger;
                    form2.nemDeger2 = nemDeger;
                    form2.ve2 = ve1;
                    form2.veya2 = veya1;
                    form2.maksimum2 = maksimum1;
                    form2.agirlikliOrtalama2 = agirlikliOrtalama1;
                    form2.om2 = om1;
                    form2.ShowDialog();
                }
            }
        }
        private void sicaklik_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Sıcaklık değeri girmek için kullanılan TextBox öğesine harf veya olmaması gereken bir sembol girilmesi engellenir
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '-' && e.KeyChar != ',';
        }
        private void nem_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Nem değeri girmek için kullanılan TextBox öğesine harf veya olmaması gereken bir sembol girilmesi engellenir
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';
        }
    }
}