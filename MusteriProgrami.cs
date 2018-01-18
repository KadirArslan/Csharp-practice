using System;
using System.IO;
using System.Threading;

namespace IsletmeProgram
{
    class Urun : urunEkle, IUrun //Urun Sifini Olusturuldu urunEkle Sınıfı ve IUrun Interface'den kalitim alindi
    {
        public void urunBilgi() //Urun Bilgilerini Yazan Fonksiyon
        {
            Console.Clear();
            Console.WriteLine("Yari Ürün Bilgileri İçin (1) Tam Ürün Bilgileri İçin (2) Tuşlayınız");
            string secim = Console.ReadKey().KeyChar.ToString();

            if (secim == "1")
            {
                Console.Clear();

                dosyaIslem.txtIslemYari(); //Static Fonksiyon Cagiriliyor

            }
            if (secim == "2")
            {
                Console.Clear();

                dosyaIslem.txtIslemTam();
            }

        }

        public void urunSil() //Urun silen Fonksiyon
        {
            Console.Clear();
            Console.Write("Silinecek Ürün Türünü Giriniz \n1-Yarı Urun \n2-Tam Urun");
            string secim = Console.ReadKey().KeyChar.ToString();

            if (secim == "1")
            {
                Console.Clear();

                dosyaIslem.txtIslemSilYari();
            }

            if (secim == "2")
            {
                Console.Clear();
                dosyaIslem.txtIslemSilTam();

            }


        }
    }
    interface IUrun //IUrun İnterface'si tanimlandi
    {
        void urunBilgi();
        void urunSil();

    }

    class Musteri : MusteriYardimci //MusteriYardimci Class'indan kalitim alan Musteri Sinifi
    {

        public void urunAl()
        {
            Console.Clear();

            FileStream fs = new FileStream("yariurun.txt", FileMode.Open, FileAccess.Read);

            StreamReader file = new StreamReader(fs);
            Urun urun = new Urun();
            urun.urunBilgi();

            Console.WriteLine("Almak Istediğiniz Urun Bilgilerini Giriniz (İsim Bilgisi Yeterlidir) :");
            string alınan = Console.ReadLine(); //Kullanicidan Alınmak istenen urun bilgileri alindi
            string str;
            while (!file.EndOfStream)
            {
                str = file.Read().ToString();

                if (str == alınan)
                {
                    Console.Write("Ürün Alma İşlemi Başarılı");
                }
            } //dosyada kontrol alinan urun bilgileri var mi diye kontrol edildi.

            fs.Flush();
            fs.Close();
            file.Close();
        }

    }


    class urunEkle // Urun Ekleme Sinifi
    {
        public void urun_Ekle() //Urun ekleyen Fonsiyon
        {
            Console.Clear();
            Console.WriteLine("Tedarik Edilecek Ürün ; \n Yarı Bitmiş ise 1 \n Tam Ürün ise 2'yi Tuslayiniz");
            var secim = Console.ReadKey().KeyChar.ToString();

            if (secim == "1")
            {
                FileStream fs = new FileStream("yariurun.txt", FileMode.Append, FileAccess.Write);
                Console.Clear();

                Console.Write("Lutfen Tedarik Edilece Yarı Urun Bilgilerini Giriniz \n ");

                Console.Write("Urun İsim :");
                string isim = Console.ReadLine();

                Console.Write("Ebatları (En/Boy/Genislik) :");
                string tarih = Console.ReadLine();

                Console.Write("Fiyati:");
                string fiyat = Console.ReadLine();

                string veri = isim + " " + tarih + " " + fiyat + "\n";

                StreamWriter sw = new StreamWriter(fs);

                sw.Write(veri);
                sw.Flush();
                sw.Close();
                fs.Close();

            }

            if (secim == "2")
            {
                FileStream fs = new FileStream("urun.txt", FileMode.Append, FileAccess.Write);
                Console.Clear();

                Console.Write("Lutfen Tedarik Edilece Urun Bilgilerini Giriniz \n ");

                Console.Write("Urun İsim :");
                string isim = Console.ReadLine();

                Console.Write("Uretim Tarihi (gg/aa/yy) - Ebatları (En/Boy/Genislik) :");
                string tarih = Console.ReadLine();

                Console.Write("Fiyati:");
                string fiyat = Console.ReadLine();

                string veri = isim + " " + tarih + " " + fiyat + "\n";

                StreamWriter sw = new StreamWriter(fs);

                sw.Write(veri);
                sw.Flush();
                sw.Close();
                fs.Close();
            }

        }
    }
    class MusteriYardimci //Musteri Sinifinin Kalitim Aldigi Yardimci Class
    {

        public void musteriEkle()
        {
            FileStream fs = new FileStream("kayit.txt", FileMode.Append, FileAccess.Write);
            Console.Clear();

            Console.Write("Lutfen Musteri Bilgilerini Giriniz \n ");

            Console.Write("İsim Soyisim :");
            string isim = Console.ReadLine();

            Console.Write("İletisim Bilgileri(Sırayla Numara/Mail/Adres/) :");
            string iletisim = Console.ReadLine();

            Console.Write("Vergi Numarası / Bakiye Bilgisi:");
            string para = Console.ReadLine();

            string veri = isim + " " + iletisim + " " + para + "\n";


            StreamWriter sw = new StreamWriter(fs);

            sw.Write(veri);
            sw.Flush();
            sw.Close();
            fs.Close();
        }

        public void musteriGoruntule()
        {
            Console.Clear();
            FileStream fs = new FileStream("kayit.txt", FileMode.Open, FileAccess.Read);
            StreamReader file = new StreamReader(fs);


            Console.WriteLine("----->Tüm Müşteri Bilgileri Listeleniyor<-----");
            while (!file.EndOfStream)
            {
                string geçiçi = file.ReadLine();
                Console.WriteLine(geçiçi);
            }

            fs.Flush();
            fs.Close();
            file.Close();


        }
        public void musteriSil()
        {

            FileStream fs = new FileStream("kayit.txt", FileMode.Open, FileAccess.Read);
            StreamReader file = new StreamReader(fs);
            StreamWriter temp = new StreamWriter("temp.txt");
            string str;

            Console.WriteLine(" \n \n");
            Console.WriteLine("Lutfen Silinecek Musteri Hesabı İle İlgili Bilgileri Giriniz (Ad Soyad Benzzerliği İçin Tüm Bilgiler Gereklidir.) :");

            var silinecek = Console.ReadLine();

            while (!file.EndOfStream)
            {
                str = file.ReadLine();

                if (str != silinecek)
                {
                    temp.WriteLine(str);
                    temp.Flush();
                }
            }

            temp.Close();

            file.Close();

            fs.Close();
            File.Delete("kayit.txt");
            File.Copy("temp.txt", "kayit.txt");
            File.Delete("temp.txt");
        }



    }
    class dosyaIslem //Icinde Statik Fonksiyonlari Bulunduran Dosya Islemleri İle ilgili sinif
    {
        public static void txtIslemYari()
        {
            FileStream fs = new FileStream("yariurun.txt", FileMode.Open, FileAccess.Read);

            StreamReader file = new StreamReader(fs);
            Console.WriteLine("----->Yarı Ürün Bilgileri Listeleniyor<-----");
            while (!file.EndOfStream)
            {
                string geçiçi = file.ReadLine();
                Console.WriteLine(geçiçi);
            }

            fs.Flush();
            fs.Close();
            file.Close();
        }

        public static void txtIslemTam()
        {
            FileStream fs = new FileStream("urun.txt", FileMode.Open, FileAccess.Read);

            StreamReader file = new StreamReader(fs);

            Console.WriteLine("----->Ürün Bilgileri Listeleniyor<-----");
            while (!file.EndOfStream)
            {
                string geçiçi = file.ReadLine();
                Console.WriteLine(geçiçi);
            }

            fs.Flush();
            fs.Close();
            file.Close();
        }

        public static void txtIslemSilYari()
        {
            FileStream filest = new FileStream("yariurun.txt", FileMode.Open, FileAccess.Read);

            StreamReader fileread = new StreamReader(filest);

            Console.WriteLine("----->Yarı Ürün Bilgileri Listeleniyor<-----");
            while (!fileread.EndOfStream)
            {
                string geçiçi = fileread.ReadLine();
                Console.WriteLine(geçiçi);
            }

            filest.Flush();
            filest.Close();
            fileread.Close();

            FileStream fs = new FileStream("yariurun.txt", FileMode.Open, FileAccess.Read);
            StreamReader file = new StreamReader(fs);
            StreamWriter temp = new StreamWriter("yaritemp.txt");
            string str;

            Console.WriteLine(" \n \n");
            Console.WriteLine("Lutfen Silinecek Urun İle İlgili Bilgileri Giriniz (Ad Soyad Benzzerliği İçin Tüm Bilgiler Gereklidir.) :");

            var silinecek = Console.ReadLine();

            while (!file.EndOfStream)
            {
                str = file.ReadLine();

                if (str != silinecek)
                {
                    temp.WriteLine(str);
                    temp.Flush();
                }
            }

            temp.Close();

            file.Close();

            fs.Close();
            File.Delete("yariurun.txt");
            File.Copy("yaritemp.txt", "yariurun.txt");
            File.Delete("yaritemp.txt");
        }


        public static void txtIslemSilTam()
        {
            FileStream filest = new FileStream("urun.txt", FileMode.Open, FileAccess.Read);

            StreamReader fileread = new StreamReader(filest);

            Console.WriteLine("----->Ürün Bilgileri Listeleniyor<-----");
            while (!fileread.EndOfStream)
            {
                string geçiçi = fileread.ReadLine();
                Console.WriteLine(geçiçi);
            }

            filest.Flush();
            filest.Close();
            fileread.Close();

            FileStream fs = new FileStream("urun.txt", FileMode.Open, FileAccess.Read);
            StreamReader file = new StreamReader(fs);
            StreamWriter temp = new StreamWriter("uruntemp.txt");
            string str;

            Console.WriteLine(" \n \n");
            Console.WriteLine("Lutfen Silinecek Urun İle İlgili Bilgileri Giriniz (Ad Soyad Benzzerliği İçin Tüm Bilgiler Gereklidir.) :");

            var silinecek = Console.ReadLine();

            while (!file.EndOfStream)
            {
                str = file.ReadLine();

                if (str != silinecek)
                {
                    temp.WriteLine(str);
                    temp.Flush();
                }
            }

            temp.Close();

            file.Close();

            fs.Close();
            File.Delete("urun.txt");
            File.Copy("uruntemp.txt", "urun.txt");
            File.Delete("uruntemp.txt");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int secim = 1;
            while (secim == 1)
            {
                Console.Clear();
                Console.WriteLine("**** Hesap Ve Muhasabe Programi**** \n Lutfen Yapmak Istediginiz Islemi Seciniz");
                Console.WriteLine("-----Yonetici Paneli-----");
                Console.WriteLine("1)Musteri Ekleme \n2)Musteri Silme \n3)Urun tedarik Et \n4)Urun Bilgileri \n5)Urun Sil");
                Console.WriteLine("-----Musteri Paneli-----");
                Console.WriteLine("6)Urun Satin Alma");
                Console.Write("Seciminiz :");
                string ilksecim = Console.ReadKey().KeyChar.ToString();

                if (ilksecim == "1") //Musteri Ekleme Kismi
                {
                    Musteri kadir = new Musteri();

                    kadir.musteriEkle();
                    Console.WriteLine("Musteri Bilgileri Basarıyla Eklendi");
                    Thread.Sleep(3000);
                }

                if (ilksecim == "2") //Musteri Silme
                {
                    Musteri kadir = new Musteri();

                    kadir.musteriGoruntule();

                    kadir.musteriSil();
                    Console.WriteLine("Musteri Kaydi Basariyla Silindi");
                    Thread.Sleep(3000);
                }

                if (ilksecim == "3") // Urun Ekleme
                {
                    Urun urun = new Urun();
                    urun.urun_Ekle();
                    Console.WriteLine("Urun Bilgileri Basariyla Kaydedildi");
                    Thread.Sleep(3000);
                }

                if (ilksecim == "4") //Urun Bilgileri
                {
                    Urun urun = new Urun();
                    urun.urunBilgi();
                    Console.ReadKey();
                }

                if (ilksecim == "5") //Urun Silme
                {
                    Urun urun = new Urun();

                    urun.urunSil();
                    Console.WriteLine("Urun Bilgileri Basariyla Silindi");
                    Thread.Sleep(3000);
                }

                if (ilksecim == "6") //Urun Satin Alma
                {
                    Musteri musteri = new Musteri();
                    musteri.urunAl();
                    Thread.Sleep(3000);
                }

                secim = 1;
            }
        }
    }
}
