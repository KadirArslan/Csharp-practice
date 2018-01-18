using System;
namespace SagSolToplam
{
    class Program
    {
        static void Main(string[] args)
        {
            char karar;
            do
            {
                Console.Write("Lutfen Dizi Boyutu Girin....:");
                int boyut = int.Parse(Console.ReadLine());
                int[] sayilar = new int[boyut];
                Random rnd = new Random();
                Console.Write("Sayilar...........:");
                for (int i = 0; i < sayilar.Length; i++)
                {
                    int sayi = rnd.Next(0, 10);
                    sayilar[i] = sayi;
                    Console.Write(" {0} ", sayi);
                }
                Console.WriteLine();
                int index = 0;
                do
                {
                    Console.Write("Lutfen Bir index girin....:");
                    index = int.Parse(Console.ReadLine());

                } while (index < 0 || index > sayilar.Length);
                int sagtoplam = 0;
                for (int i = 0; i < (index - 1); i++)
                {
                    sagtoplam += sayilar[i];
                }
                Console.WriteLine("Sag toplam....:{0}", sagtoplam);
                int soltoplam = 0;
                for (int i = index; i < sayilar.Length; i++)
                {
                    soltoplam += sayilar[i];
                }
                Console.WriteLine("Sol Toplam...:{0}", soltoplam);
                Console.WriteLine("Devam Etmek Istiyor Musunuz?(e/h)");
                karar = char.Parse(Console.ReadLine());
            } while (karar != 'h');
            }
        }
    }

