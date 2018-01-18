
using System;
namespace Matris
{
    class Uygulama
    {
        static void Main(string[] args)
        {
            int secim = 0; //while dongusu'nun devami icin kullanicidan deger alacak bir degisken tanimlandi.

            while (secim < 4)
            {
                Console.Clear();
                Console.WriteLine("..:: Islemler ::.. \n 1-Matris Islemleri \n 2-String Islemleri \n 3-Cikis");
                Console.Write("Seciminiz:");
                secim = int.Parse(Console.ReadLine());//secim degeri alindi.
              
                if (secim == 1)//secim degiskeninin kontrolu yapildi.
                {
                    int satirsayi;
                    Console.Clear();
                    Console.Write("..:: Matris Islemleri ::.. \n Matrisin satir sayisini giriniz(1-10 arasinda):");
                    satirsayi = int.Parse(Console.ReadLine());//kullanicidan matris icin satir sayisi alindi.
                    int[,] matris = new int[satirsayi, satirsayi];//2 boyutlu matris adinda bir dizi olusturuldu.
         
                    for (int i = 0; i < satirsayi; i++)
                    {
                        for (int k = 0; k < satirsayi; k++)
                        {
                            Console.Write("[{0},{1}]=", i + 1, k + 1);
                            int deger = int.Parse(Console.ReadLine()); //Kullanicidan matrisin degerleri alindi.              
                            matris[k, i] = deger;
                        }
                        Console.WriteLine();
                    }

                    int[] enbuyukler = new int[satirsayi];
                    int[] toplamlar = new int[satirsayi];//enbuyukler ve toplamlar adinda dizi olusturuldu.
                    for (int i = 0; i < satirsayi; i++)
                    {
                        int toplam = 0;
                        int enbuyuk = 0;
                        for (int k = 0; k < satirsayi; k++)
                        {
                            toplam = toplam + matris[k, i];
                            toplamlar[i] = toplam;
                            Console.Write(" {0}", matris[k, i]);
                            if (matris[k, i] > enbuyuk)
                            {
                                enbuyuk = matris[k, i];
                                enbuyukler[i] = enbuyuk;
                            }
                        }
                        Console.WriteLine();
                    }

                    Console.Write(" 1-Satir En Buyuk \n 2-Satir Toplam \n Seciminiz:");
                    //Bu for dongusunda her satirdaki elemlar arasinda tek tek gezinip if kontroluyle satirdaki en buyuk deger bulundu.
                    //Ayni zamanda satirdaki toplamlar bulundu.
                    int secim2 = int.Parse(Console.ReadLine());//kullanici secimi icin yine bir secim degiskeni olusturuldu.
                    if (secim2 == 1)
                    {
                        for (int k = 0; k < satirsayi; k++)
                            Console.Write(" {0}", enbuyukler[k]);
                        Console.WriteLine();
                    }
                    else if (secim2 == 2)
                    {
                        for (int b = 0; b < satirsayi; b++)
                            Console.Write(" {0}", toplamlar[b]);
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("Yanlis Bir Secim Yaptiniz");
                    }
                    Console.WriteLine("Devam Icin Tusa Basin");
                    Console.ReadKey();
                }//if ve else kontrol yapisiyla ekrana istenen degerler yazdirildi.
                else if (secim == 2)
                {
                    Console.Clear();
                    Console.Write("..:: String Islemleri ::.. \n Islem Yapilacak Stringi Giriniz:");
                    string islem = Console.ReadLine();
                    Console.Write("Istenen Harf:");
                    char aharf = Char.Parse(Console.ReadLine());
                    int sayac = 0;

                    foreach (char i in islem)
                    {
                        if (i == aharf)
                            sayac++; //foreach dongusu ile islem stringi'nin icidneki istenen i harfinin kac tane bulundugu hesaplandi.
                    }
                    int aharfkacinci1 = islem.IndexOf(aharf);//aranan harfin bastan kacinci oldugu bulundu.
                    int aharfkacinci2 = islem.LastIndexOf(aharf);//aranan harfin sondan kacinci oldugu bulundu.
                    int boyut = aharfkacinci2 - aharfkacinci1;//aradaki fark alindi.
                    if (sayac == 0)
                    {
                        Console.WriteLine("Istediginiz Harf Bulunamamistir");
                    }
                    else
                    {
                        Console.WriteLine("Istediginiz Harften {0} adet vardir", sayac);
                        if (sayac == 1)
                        {
                            Console.WriteLine("Islem Yapilmasi Icin Istenen Harften  2 Adet Bulunmasi Gerekiyor ");
                        }
                        else if (sayac == 2)
                        {
                            Console.WriteLine("***Lutfen Islem Yapmak Icin Tuslayiniz***\n1-Ara Metni Tersten Yaz \n2-Ara Metni Tekrarli Yaz");
                            int secim3 = int.Parse(Console.ReadLine());//kullanici secimi icin deger alindi.
                            string ters = islem.Substring(aharfkacinci1 + 1, boyut - 1);/*substring fonksiyonu ile istenen string ters adinda bir
                           degiskene atandi. */
                            if (secim3 == 1)
                            {
                                for (int i = ters.Length - 1; i >= 0; i--)
                                    Console.Write(ters[i]);
                                Console.WriteLine();
                            }
                            else if (secim3 == 2)
                            {
                                for (int i = 0; i < 5; i++)
                                    Console.WriteLine(ters);
                            }
                            else
                            {
                                Console.WriteLine("Yanlis Tusladiniz");
                            }
                        }

                    }
                    Console.WriteLine("Devam Icin Bir Tusa Basiniz");
                    Console.ReadKey();
                }
                else if (secim == 3)
                {
                    Console.WriteLine("Cikis Yapiliyor");
                    Environment.Exit(0);
                }

                else
                {
                    secim = 0;
                    Console.WriteLine("Yanlis Secim Yaptiniz \n Devam Etmek Icin Bir Tusa Basiniz");
                    Console.ReadKey();
                }
            }
        }
    }
}
