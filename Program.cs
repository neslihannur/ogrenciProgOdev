using System.ComponentModel.Design;

namespace ogrenciProgOdev
{
    internal class Program
    {
        //Method ÖRNEK
        static string Sor(string soru)
        {
            Console.Write(soru);
            return Console.ReadLine();
        }
        class Ogrenci
        {
            public string Ad { get; set; }
            public string Soyad { get; set; }
            public int Yas { get; set; }
            public string Cinsiyet { get; set; } 
            public int OgrenciNo { get; set; }
        }

        static List<Ogrenci> ogrenciler = new List<Ogrenci>();
        static Ogrenci? OgrenciBul(string arananAd)
        {
            Ogrenci? bulunanOgrenci = null;

            foreach (var ogrenci in ogrenciler)
            {
                if (arananAd == ogrenci.Ad)
                {
                    bulunanOgrenci = ogrenci;
                    break;
                }
            }

            return bulunanOgrenci;
        }
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Hoş geldiniz");
                Console.WriteLine("1 - Öğrencileri Listele-Filtrele");
                Console.WriteLine("2 - Öğrenci Ekle");
                Console.WriteLine("3 - Öğrenci Düzenle");
                Console.WriteLine("4 - Çıkış");

                int inputSecim = int.Parse(Sor("Seçiminiz: "));

                if (inputSecim == 1)
                {
                    Console.Clear();
                    Console.WriteLine("Öğrenci Listesi");
                    Console.WriteLine("1 - Tüm öğrencileri listele");
                    Console.WriteLine("2 - Cinsiyete göre filtrele");
                    Console.WriteLine("3 - Ada göre filtrele");

                    int listelemeSecim = int.Parse(Sor("Seçiminiz: "));

                    if (listelemeSecim == 1)
                    {
                        // Tüm öğrencileri listele
                        foreach (Ogrenci ogrenci in ogrenciler)
                        {
                            Console.WriteLine($"{ogrenci.Ad} {ogrenci.Soyad} - {ogrenci.Yas} - {ogrenci.Cinsiyet}");
                        }
                    }
                    else if (listelemeSecim == 2)
                    {
                        // Cinsiyete göre filtrele
                        Console.WriteLine("Cinsiyet seçin (Erkek/Kadın): ");
                        string filtreCinsiyet = Sor("Seçiminiz: ");

                        foreach (Ogrenci ogrenci in ogrenciler)
                        {
                            if (ogrenci.Cinsiyet == filtreCinsiyet)
                            {
                                Console.WriteLine($"{ogrenci.Ad} {ogrenci.Soyad} - {ogrenci.Yas} - {ogrenci.Cinsiyet}");
                            }
                        }
                    }
                    else if (listelemeSecim == 3)
                    {
                        // Ada göre filtrele
                        string anahtarKelime = Sor("Aranacak adı girin: ").ToLower();

                        foreach (Ogrenci ogrenci in ogrenciler)
                        {
                            if (ogrenci.Ad.ToLower().Contains(anahtarKelime))
                            {
                                Console.WriteLine($"{ogrenci.Ad} {ogrenci.Soyad} - {ogrenci.Yas} - {ogrenci.Cinsiyet}");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Geçersiz seçim!");
                    }

                    Console.WriteLine("\nDevam etmek için bir tuşa basın");
                    Console.ReadKey();
                }
                else if (inputSecim == 2)
                {
                    Console.Clear();
                    Console.WriteLine("Öğrenci Ekle");
                    Ogrenci ogrenci = new Ogrenci();
                    ogrenci.Ad = Sor("Ad: ");
                    ogrenci.Soyad = Sor("Soyad: ");
                    ogrenci.Yas = int.Parse(Sor("Yaş: "));
                    ogrenci.Cinsiyet = Sor("Cinsiyet (Erkek/Kadın): ");

                    ogrenciler.Add(ogrenci);
                }
                else if (inputSecim == 3)
                {
                    Console.Clear();
                    Console.WriteLine("Öğrenci Düzenle");
                    string inputDuzenlenecekOgrenci = Sor("Düzenlemek istediğiniz öğrencinin adı: ");

                    Ogrenci? duzenlenecekOgrenci = OgrenciBul(inputDuzenlenecekOgrenci);

                    if (duzenlenecekOgrenci != null)
                    {
                        Console.WriteLine($"Seçilen Öğrenci: {duzenlenecekOgrenci.Ad} {duzenlenecekOgrenci.Soyad}");

                        Console.WriteLine("1 - Adı düzenle");
                        Console.WriteLine("2 - Soyadı düzenle");
                        Console.WriteLine("3 - Yaşı düzenle");
                        int duzenlemeSecim = int.Parse(Sor("Ne düzenlemek istersiniz? "));

                        if (duzenlemeSecim == 1)
                        {
                            string yeniAd = Sor("Yeni Ad: ");
                            duzenlenecekOgrenci.Ad = yeniAd;
                        }
                        else if (duzenlemeSecim == 2)
                        {
                            string yeniSoyad = Sor("Yeni Soyad: ");
                            duzenlenecekOgrenci.Soyad = yeniSoyad;
                        }
                        else if (duzenlemeSecim == 3)
                        {
                            int yeniYas = int.Parse(Sor("Yeni Yaş: "));
                            duzenlenecekOgrenci.Yas = yeniYas;
                        }
                        else
                        {
                            Console.WriteLine("Geçersiz seçim!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Böyle bir öğrenci yok!");
                    }

                    Console.WriteLine("\nDevam etmek için bir tuşa basın");
                    Console.ReadKey();
                }

            }
        }
      }
}
