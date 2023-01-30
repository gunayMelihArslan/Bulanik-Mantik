using System;
using System.Diagnostics.Eventing.Reader;
using System.Windows.Forms;
namespace bulanık_mantik
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public double sicaklikDeger2, nemDeger2;
        public bool ve2, veya2, maksimum2, agirlikliOrtalama2;
        public string om2;
        public double bulanikSicaklikCokDusuk, bulanikSicaklikDusuk, bulanikSicaklikOrta, bulanikSicaklikYuksek, bulanikSicaklikCokYuksek;
        public double bulanikNemCokDusuk, bulanikNemDusuk, bulanikNemOrta, bulanikNemYuksek, bulanikNemCokYuksek;
        public byte sicaklikIndis1 = 5, sicaklikIndis2 = 5;
        public byte nemIndis1 = 5, nemIndis2 = 5;
        double[] sicaklikDizi = new double[6];
        double[] nemDizi = new double[6];
        byte[,] isiticiDizi = new byte[5, 5];
        byte[] isiticiIndisDizi = new byte[4] { 5, 5, 5, 5 };
        double[] karsilastirmaDizi2 = new double[4];
        double[] karsilastirmaDizi = new double[4];
        public double toplampay, toplampayda;
        public double sonuc;
        public void sicaklikBulaniklastirma()
        {
            // Form1'de girilen sıcaklık değeri programın diğer kısımlarında kullanılmak üzere bu döngüde bulanıklaştırılır ve diziye bulunan değerler atanır
            bulanikSicaklikCokDusuk = Convert.ToDouble(Math.Max(Math.Min((10 - sicaklikDeger2) / 10, 1), 0));
            bulanikSicaklikDusuk = Convert.ToDouble(Math.Max(Math.Min((sicaklikDeger2 / 7.5), ((15 - sicaklikDeger2) / 7.5)), 0));
            bulanikSicaklikOrta = Convert.ToDouble(Math.Max(Math.Min((sicaklikDeger2 - 14) / 6, (26 - sicaklikDeger2) / 6), 0));
            bulanikSicaklikYuksek = Convert.ToDouble(Math.Max(Math.Min((sicaklikDeger2 - 20) / 10, (40 - sicaklikDeger2) / 10), 0));
            bulanikSicaklikCokYuksek = Convert.ToDouble(Math.Max(Math.Min((sicaklikDeger2 - 30) / 30, 1), 0));
            sicaklikDizi[0] = bulanikSicaklikCokDusuk;
            sicaklikDizi[1] = bulanikSicaklikDusuk;
            sicaklikDizi[2] = bulanikSicaklikOrta;
            sicaklikDizi[3] = bulanikSicaklikYuksek;
            sicaklikDizi[4] = bulanikSicaklikCokYuksek;
            sicaklikDizi[5] = 0;
        }
        public void nemBulaniklastirma()
        {
            // Form1'de girilen nem değeri programın diğer kısımlarında kullanılmak üzere bu döngüde bulanıklaştırılır ve diziye bulunan değerler atanır
            bulanikNemCokDusuk = Convert.ToDouble(Math.Max(Math.Min((40 - nemDeger2) / 20, 1), 0));
            bulanikNemDusuk = Convert.ToDouble(Math.Max(Math.Min(((nemDeger2 - 20) / 19.5), ((59 - nemDeger2) / 19.5)), 0));
            bulanikNemOrta = Convert.ToDouble(Math.Max(Math.Min((nemDeger2 - 50) / 10, (70 - nemDeger2) / 10), 0));
            bulanikNemYuksek = Convert.ToDouble(Math.Max(Math.Min((nemDeger2 - 60) / 15, (90 - nemDeger2) / 15), 0));
            bulanikNemCokYuksek = Convert.ToDouble(Math.Max(Math.Min((nemDeger2 - 80) / 10, 1), 0));
            nemDizi[0] = bulanikNemCokDusuk;
            nemDizi[1] = bulanikNemDusuk;
            nemDizi[2] = bulanikNemOrta;
            nemDizi[3] = bulanikNemYuksek;
            nemDizi[4] = bulanikNemCokYuksek;
            nemDizi[5] = 0;
        }
        public void sicaklikSifirlariAyiklama()
        {
            // Kural tablosunda 0 olan değerleri hesaplarken kullanmayacağımız için sıcaklık dizisinde 0 olmayan değerlerin indis numaraları bulunur
            byte i;
            for (i = 0; i <= 4; i++)
            {
                if (sicaklikIndis1 == 5 && sicaklikDizi[i] != 0) // sicaklikIndis1 değişkeni programın başında hiçbir zaman bu for döngüsünde ulaşamayacağı değer olan 5 değerine eşitlenmiştir bu sayede döngünün içinde daha önce değişkene değer atanıp atanmadığı kontrol edilir
                {
                    sicaklikIndis1 = i; // sicaklikIndis1 değişkenine daha önce değer atanmamışsa ve dizinin 0 olmayan bir değeri varsa bu değerin indis numrası söz konusu değişkene atanır
                }
                else if (sicaklikIndis2 == 5 && sicaklikDizi[i] != 0)
                {
                    sicaklikIndis2 = i; // aynı anda 2 tane sıfıra eşit olmayan dizi elemanı olabileceğinden 2. elemanın indis değeri varsa burada tespit edilir                   
                }
            }
        }
        public void nemSifirlariAyiklama()
        {
            // Kural tablosunda 0 olan değerleri hesaplarken kullanmayacağımız için sıcaklık dizisinde 0 olmayan değerlerin indis numaraları bulunur
            byte j;
            for (j = 0; j <= 4; j++)
            {
                if (nemIndis1 == 5 && nemDizi[j] != 0) // nemIndis1 değişkeni programın başında hiçbir zaman bu for döngüsünde ulaşamayacağı değer olan 5 değerine eşitlenmiştir bu sayede döngünün içinde daha önce değişkene değer atanıp atanmadığını kontrol edebiliyoruz 
                {
                    nemIndis1 = j; // nemIndis1 değişkenine daha önce değer atanmamışsa ve dizinin 0 olmayan bir değeri varsa bu değerin indis numrası söz konusu değişkene atanır
                }
                else if (nemIndis2 == 5 && nemDizi[j] != 0)
                {
                    nemIndis2 = j; // aynı anda 2 tane sıfıra eşit olmayan dizi elemanı olabileceğinden 2. elemanın indis değeri varsa burada tespit edilir
                }
            }
        }
        public void kurallar()
        {
            // Kural tablosu iki boyutlu dizi kullanıllanılarak sol taraf nem sağ taraf sicaklik olmak üzere programa aktarılır
            // 4 = çok yüksek, 3 = yüksek, 2 = orta, 1 = düşük, 0 = çok düşük anlamına gelmektedir
            isiticiDizi[0, 0] = 4;
            isiticiDizi[0, 1] = 3;
            isiticiDizi[0, 2] = 2;
            isiticiDizi[0, 3] = 1;
            isiticiDizi[0, 4] = 0;
            isiticiDizi[1, 0] = 4;
            isiticiDizi[1, 1] = 3;
            isiticiDizi[1, 2] = 2;
            isiticiDizi[1, 3] = 1;
            isiticiDizi[1, 4] = 0;
            isiticiDizi[2, 0] = 3;
            isiticiDizi[2, 1] = 3;
            isiticiDizi[2, 2] = 2;
            isiticiDizi[2, 3] = 1;
            isiticiDizi[2, 4] = 0;
            isiticiDizi[3, 0] = 3;
            isiticiDizi[3, 1] = 2;
            isiticiDizi[3, 2] = 2;
            isiticiDizi[3, 3] = 1;
            isiticiDizi[3, 4] = 0;
            isiticiDizi[4, 0] = 3;
            isiticiDizi[4, 1] = 2;
            isiticiDizi[4, 2] = 1;
            isiticiDizi[4, 3] = 1;
            isiticiDizi[4, 4] = 0;
            // Kural tablosu oluşturulduktan sonra bulanıklaştırılmış değerler tabloda yerlerine yazılır ve bir diziye atanır
            if (nemIndis1 <= 4 && sicaklikIndis1 <= 4)
            {
                isiticiIndisDizi[0] = isiticiDizi[nemIndis1, sicaklikIndis1];
            }
            if (nemIndis1 <= 4 && sicaklikIndis2 <= 4)
            {
                isiticiIndisDizi[1] = isiticiDizi[nemIndis1, sicaklikIndis2];
            }
            if (nemIndis2 <= 4 && sicaklikIndis1 <= 4)
            {
                isiticiIndisDizi[2] = isiticiDizi[nemIndis2, sicaklikIndis1];
            }
            if (nemIndis2 <= 4 && sicaklikIndis2 <= 4)
            {
                isiticiIndisDizi[3] = isiticiDizi[nemIndis2, sicaklikIndis2];
            }
        }
        public void veYontemi()
        {
            // Kullanıcı ve yöntemi ile çözüm istemişse bu döngü çalıştırılarak program sürdürülür
            // Bilindiği üzere ve yöntemi minimum değerlerle çalışır döngü kural tablosunda kesişen değerlerin minimumlarını alarak bir diziye atar
            karsilastirmaDizi[0] = Math.Min(nemDizi[nemIndis1], sicaklikDizi[sicaklikIndis1]);
            karsilastirmaDizi[1] = Math.Min(nemDizi[nemIndis1], sicaklikDizi[sicaklikIndis2]);
            karsilastirmaDizi[2] = Math.Min(nemDizi[nemIndis2], sicaklikDizi[sicaklikIndis1]);
            karsilastirmaDizi[3] = Math.Min(nemDizi[nemIndis2], sicaklikDizi[sicaklikIndis2]);
        }
        public void veyaYontemi()
        {
            // Kullanıcı veya yöntemi ile çözüm istemişse bu döngü çalıştırılarak program sürdürülür
            // Bilindiği üzere veya yöntemi maksimum değerlerle çalışır döngü kural tablosunda kesişen değerlerin maksimumlarını alarak bir diziye atar
            karsilastirmaDizi[0] = Math.Max(nemDizi[nemIndis1], sicaklikDizi[sicaklikIndis1]);
            karsilastirmaDizi[1] = Math.Max(nemDizi[nemIndis1], sicaklikDizi[sicaklikIndis2]);
            karsilastirmaDizi[2] = Math.Max(nemDizi[nemIndis2], sicaklikDizi[sicaklikIndis1]);
            karsilastirmaDizi[3] = Math.Max(nemDizi[nemIndis2], sicaklikDizi[sicaklikIndis2]);
            // Maksimum değerler alınırken kesişimlerede değişmemiş indis değeri dizilere değer atanırken sıfıra eşitlenmiştir
            // Karşılaştırma kombinasyonlarında böyle bir durumla karşılaşılırsa program maksimum değeri alacağından hesaplamada hata olacaktır
            if (nemDizi[nemIndis1] == 0 || sicaklikDizi[sicaklikIndis1] == 0)
            {
                karsilastirmaDizi[0] = 0;
            }
            if (nemDizi[nemIndis1] == 0 || sicaklikDizi[sicaklikIndis2] == 0)
            {
                karsilastirmaDizi[1] = 0;
            }
            if (nemDizi[nemIndis2] == 0 || sicaklikDizi[sicaklikIndis1] == 0)
            {
                karsilastirmaDizi[2] = 0;
            }
            if (nemDizi[nemIndis2] == 0 || sicaklikDizi[sicaklikIndis2] == 0)
            {
                karsilastirmaDizi[3] = 0;
            }
        }
        public void metot()
        {
            // Seçilen metoda göre ilgili döngü çalıştırılır
            if (ve2 == true)
            {
                veYontemi();
                mamdani.Text = "Mamdani VE";
            }
            else if (veya2 == true)
            {
                veyaYontemi();
                mamdani.Text = "Mamdani VEYA";
            }
        }
        public void agirlikliOrtalama()
        {
            sicaklikBulaniklastirma();
            nemBulaniklastirma();
            sicaklikSifirlariAyiklama();
            nemSifirlariAyiklama();
            kurallar();
            metot();
            // Ağırlıklı ortalama yaklaşımı seçilmişse öncelikle sıcaklık ve nem değerleri bulanıklaştırılmalı bu değerlerin sıfıra eşit olmayanları kural tablosuna yerleştirilmeli ve son olarak seçilen metoda göre değerlendirilmelidir
            // Elde edilen karşılaştırma değerlerinin tablodaki karşılığı olan üyelik fonksiyonlarına göre gerekli işlemler yapılır
            byte k;
            for (k = 0; k <= 3; k++)
            {
                if (isiticiIndisDizi[k] == 0)
                {
                    karsilastirmaDizi2[k] = Convert.ToDouble(karsilastirmaDizi[k] * 0.5);
                }
                else if (isiticiIndisDizi[k] == 1)
                {
                    karsilastirmaDizi2[k] = Convert.ToDouble(karsilastirmaDizi[k] * 1.5);
                }
                else if (isiticiIndisDizi[k] == 2)
                {
                    karsilastirmaDizi2[k] = Convert.ToDouble(karsilastirmaDizi[k] * 3);
                }
                else if (isiticiIndisDizi[k] == 3)
                {
                    karsilastirmaDizi2[k] = Convert.ToDouble(karsilastirmaDizi[k] * 4.25);
                }
                else if (isiticiIndisDizi[k] == 4)
                {
                    karsilastirmaDizi2[k] = Convert.ToDouble(karsilastirmaDizi[k] * 5.25);
                }
                toplampay += Convert.ToDouble(karsilastirmaDizi2[k]);
                toplampayda += Convert.ToDouble(karsilastirmaDizi[k]);
            }
            sonuc = Convert.ToDouble((toplampay / toplampayda));
        }
        public void maksimum()
        {
            sicaklikBulaniklastirma();
            nemBulaniklastirma();
            sicaklikSifirlariAyiklama();
            nemSifirlariAyiklama();
            kurallar();
            byte l;
            byte m;
            for (l = 0; l <= 3; l++)
            {
                
                if (isiticiIndisDizi[l] == 0)
                {
                    if (om2 == "SOM")
                    {
                        sonuc = 0;
                    }
                    else if (om2 == "MOM")
                    {
                        sonuc = 0.25;
                    }
                    else if (om2 == "LOM")
                    {
                        sonuc = 0.5;
                    }
                }
                else if (isiticiIndisDizi[l] == 1)
                {
                    sonuc = 1.5;
                }
                else if (isiticiIndisDizi[l] == 2)
                {
                    sonuc = 3;
                }
                else if (isiticiIndisDizi[l] == 3)
                {
                    sonuc = 4.25;
                }
                else if (isiticiIndisDizi[l] == 4)
                {
                    if (om2 == "SOM")
                    {
                        sonuc = 5.25;
                    }
                    else if (om2 == "MOM")
                    {
                        sonuc = 5.625;
                    }
                    else if (om2 == "LOM")
                    {
                        sonuc = 6;
                    }
                }
            }
        }
        public void yaklasim()
        {
            // Sonucun hesaplanmasında kullanılacak olan yaklaşım yönteminin seçimi yapılır
            if (maksimum2 == true)
            {
                mamdani.Text = " ";
                maksimum();
                if (om2 == "SOM")
                {
                    yakinlasmaLabel.Text = "Maksimum  SOM";
                }
                else if (om2 == "LOM")
                {
                    yakinlasmaLabel.Text = "Maksimum  LOM";
                }
                else if (om2 == "MOM")
                {
                    yakinlasmaLabel.Text = "Maksimum  MOM";
                }
            }
            else if (agirlikliOrtalama2 == true)
            {
                agirlikliOrtalama();
                yakinlasmaLabel.Text = "Ağırlıklı ortalama";
            }
        }
        public void sonuclandirma()
        {
            // Sonuç kullanıcının rahatça okuyabilmesi için virgülden sonra iki basamaklı bir hale getirilir ve grafikte gösterilir
            sonuc = Convert.ToDouble(Math.Round(sonuc, 2));
            sicaklikGrafik.Series["Sıcaklık değeri"].Points.AddXY(sicaklikDeger2, 0);
            sicaklikGrafik.Series["Sıcaklık değeri"].Points.AddXY(sicaklikDeger2, 1);
            nemGrafik.Series["Nem değeri"].Points.AddXY(nemDeger2, 0);
            nemGrafik.Series["Nem değeri"].Points.AddXY(nemDeger2, 1);
            isiticiGrafik.Series["Isıtıcı değeri"].Points.AddXY(sonuc, 0);
            isiticiGrafik.Series["Isıtıcı değeri"].Points.AddXY(sonuc, 1);
            isiticiSonuc.Text = sonuc.ToString();
            sicaklikGirilen.Text = sicaklikDeger2.ToString();
            nemGirilen.Text = nemDeger2.ToString();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            yaklasim();
            sonuclandirma();
            // Grafikler çizilir
            sicaklikGrafik.Series["Çok düşük"].Points.AddXY(-10, 1);
            sicaklikGrafik.Series["Çok düşük"].Points.AddXY(0, 1);
            sicaklikGrafik.Series["Çok düşük"].Points.AddXY(10, 0);
            sicaklikGrafik.Series["Çok düşük"].Points.AddXY(50, 0);
            sicaklikGrafik.Series["Düşük"].Points.AddXY(-10, 0);
            sicaklikGrafik.Series["Düşük"].Points.AddXY(0, 0);
            sicaklikGrafik.Series["Düşük"].Points.AddXY(7.5, 1);
            sicaklikGrafik.Series["Düşük"].Points.AddXY(15, 0);
            sicaklikGrafik.Series["Düşük"].Points.AddXY(50, 0);
            sicaklikGrafik.Series["Orta"].Points.AddXY(-10, 0);
            sicaklikGrafik.Series["Orta"].Points.AddXY(14, 0);
            sicaklikGrafik.Series["Orta"].Points.AddXY(20, 1);
            sicaklikGrafik.Series["Orta"].Points.AddXY(26, 0);
            sicaklikGrafik.Series["Orta"].Points.AddXY(50, 0);
            sicaklikGrafik.Series["Yüksek"].Points.AddXY(-10, 0);
            sicaklikGrafik.Series["Yüksek"].Points.AddXY(20, 0);
            sicaklikGrafik.Series["Yüksek"].Points.AddXY(30, 1);
            sicaklikGrafik.Series["Yüksek"].Points.AddXY(40, 0);
            sicaklikGrafik.Series["Yüksek"].Points.AddXY(50, 0);
            sicaklikGrafik.Series["Çok yüksek"].Points.AddXY(-10, 0);
            sicaklikGrafik.Series["Çok yüksek"].Points.AddXY(30, 0);
            sicaklikGrafik.Series["Çok yüksek"].Points.AddXY(40, 1);
            sicaklikGrafik.Series["Çok yüksek"].Points.AddXY(50, 1);
            nemGrafik.Series["Çok düşük"].Points.AddXY(0, 1);
            nemGrafik.Series["Çok düşük"].Points.AddXY(20, 1);
            nemGrafik.Series["Çok düşük"].Points.AddXY(40, 0);
            nemGrafik.Series["Çok düşük"].Points.AddXY(100, 0);
            nemGrafik.Series["Düşük"].Points.AddXY(0, 0);
            nemGrafik.Series["Düşük"].Points.AddXY(20, 0);
            nemGrafik.Series["Düşük"].Points.AddXY(39.5, 1);
            nemGrafik.Series["Düşük"].Points.AddXY(59, 0);
            nemGrafik.Series["Düşük"].Points.AddXY(100, 0);
            nemGrafik.Series["Orta"].Points.AddXY(0, 0);
            nemGrafik.Series["Orta"].Points.AddXY(50, 0);
            nemGrafik.Series["Orta"].Points.AddXY(60, 1);
            nemGrafik.Series["Orta"].Points.AddXY(70, 0);
            nemGrafik.Series["Orta"].Points.AddXY(100, 0);
            nemGrafik.Series["Yüksek"].Points.AddXY(0, 0);
            nemGrafik.Series["Yüksek"].Points.AddXY(60, 0);
            nemGrafik.Series["Yüksek"].Points.AddXY(75, 1);
            nemGrafik.Series["Yüksek"].Points.AddXY(90, 0);
            nemGrafik.Series["Yüksek"].Points.AddXY(100, 0);
            nemGrafik.Series["Çok yüksek"].Points.AddXY(0, 0);
            nemGrafik.Series["Çok yüksek"].Points.AddXY(80, 0);
            nemGrafik.Series["Çok yüksek"].Points.AddXY(90, 1);
            nemGrafik.Series["Çok yüksek"].Points.AddXY(100, 1);
            isiticiGrafik.Series["Çok düşük"].Points.AddXY(0, 1);
            isiticiGrafik.Series["Çok düşük"].Points.AddXY(0.5, 1);
            isiticiGrafik.Series["Çok düşük"].Points.AddXY(1, 0);
            isiticiGrafik.Series["Çok düşük"].Points.AddXY(6, 0);
            isiticiGrafik.Series["Düşük"].Points.AddXY(0, 0);
            isiticiGrafik.Series["Düşük"].Points.AddXY(1.5, 1);
            isiticiGrafik.Series["Düşük"].Points.AddXY(3, 0);
            isiticiGrafik.Series["Düşük"].Points.AddXY(6, 0);
            isiticiGrafik.Series["Orta"].Points.AddXY(0, 0);
            isiticiGrafik.Series["Orta"].Points.AddXY(2, 0);
            isiticiGrafik.Series["Orta"].Points.AddXY(3, 1);
            isiticiGrafik.Series["Orta"].Points.AddXY(4, 0);
            isiticiGrafik.Series["Orta"].Points.AddXY(6, 0);
            isiticiGrafik.Series["Yüksek"].Points.AddXY(0, 0);
            isiticiGrafik.Series["Yüksek"].Points.AddXY(3.5, 0);
            isiticiGrafik.Series["Yüksek"].Points.AddXY(4.25, 1);
            isiticiGrafik.Series["Yüksek"].Points.AddXY(5, 0);
            isiticiGrafik.Series["Yüksek"].Points.AddXY(6, 0);
            isiticiGrafik.Series["Çok yüksek"].Points.AddXY(0, 0);
            isiticiGrafik.Series["Çok yüksek"].Points.AddXY(4.5, 0);
            isiticiGrafik.Series["Çok yüksek"].Points.AddXY(5.25, 1);
            isiticiGrafik.Series["Çok yüksek"].Points.AddXY(6, 1);
        }
        private void isiticiGrafik_MouseLeave(object sender, EventArgs e)
        {
            // Fare imleci grafiğin üzerinde değilse pencere eski haline döner
            isiticiGrafik.Dock = DockStyle.None;
        }
        private void isiticiGrafik_MouseEnter(object sender, EventArgs e)
        {
            // Okunurluğu attırmak için fare imleci grafiğin üzerine getirildiğinde grafik pencereyi kaplar
            isiticiGrafik.BringToFront();
            isiticiGrafik.Dock = DockStyle.Fill;
        }
        private void sicaklikGrafik_MouseLeave(object sender, EventArgs e)
        {
            // Fare imleci grafiğin üzerinde değilse pencere eski haline döner
            sicaklikGrafik.Dock = DockStyle.None;
        }
        private void sicaklikGrafik_MouseEnter(object sender, EventArgs e)
        {
            // Okunurluğu attırmak için fare imleci grafiğin üzerine getirildiğinde grafik pencereyi kaplar
            sicaklikGrafik.BringToFront();
            sicaklikGrafik.Dock = DockStyle.Fill;
        }
        private void nemGrafik_MouseEnter(object sender, EventArgs e)
        {
            // Okunurluğu attırmak için fare imleci grafiğin üzerine getirildiğinde grafik pencereyi kaplar
            nemGrafik.BringToFront();
            nemGrafik.Dock = DockStyle.Fill;
        }
        private void nemGrafik_MouseLeave(object sender, EventArgs e)
        {
            // Fare imleci grafiğin üzerinde değilse pencere eski haline döner
            nemGrafik.Dock = DockStyle.None;
        }
    }
}