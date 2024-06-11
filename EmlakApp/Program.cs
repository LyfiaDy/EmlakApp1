using System; 
using System.Collections.Generic; 
using System.IO; 

class Program
{
    static List<string> kiralikEvler = new List<string>(); 
    static List<string> satilikEvler = new List<string>();

    static void Main()
    {
        while (true) 
        {
            AnaMenu();
        }
    }

    static void AnaMenu()
    {
        Console.WriteLine("Emlakçı Uygulaması"); 
        Console.WriteLine("1- Kiralık ev"); 
        Console.WriteLine("2- Satılık ev"); 
        Console.WriteLine("3- Çıkış"); 
        Console.Write("Seçiminiz: "); 
        string secim = Console.ReadLine(); 

        switch (secim) 
        {
            case "1":
                KiralikMenu(); 
                break;
            case "2":
                SatilikMenu(); 
                break;
            case "3":
                Environment.Exit(0); 
                break;
            default:
                Console.WriteLine("Lütfen geçerli bir seçenek giriniz."); 
                break;
        }
    }

    static void KiralikMenu()
    {
        Console.WriteLine("1- Kayıtlı evleri görüntüleme"); 
        Console.WriteLine("2- Yeni ev girişi"); 
        Console.WriteLine("3- Ana Menüye Dön"); 
        Console.Write("Seçiminiz: "); 
        string kiralikSecim = Console.ReadLine(); 

        switch (kiralikSecim) 
        {
            case "1":
                Goruntule("kiralik_evler.txt"); 
                break;
            case "2":
                YeniKiralikEvGir(); 
                break;
            case "3":
                return; 
            default:
                Console.WriteLine("Lütfen geçerli bir seçenek giriniz."); 
                break;
        }
    }
    

    static void SatilikMenu()
    {
        Console.WriteLine("1- Kayıtlı evleri görüntüleme"); 
        Console.WriteLine("2- Yeni ev girişi"); 
        Console.WriteLine("3- Ana Menüye Dön"); 
        Console.Write("Seçiminiz: "); 
        string satilikSecim = Console.ReadLine(); 

        switch (satilikSecim) 
        {
            case "1":
                Goruntule("satilik_evler.txt");
                break;
            case "2":
                YeniSatilikEvGir(); 
                break;
            case "3":
                return; 
            default:
                Console.WriteLine("Lütfen geçerli bir seçenek giriniz."); 
                break;
        }
    }

    static void Goruntule(string dosyaAdi)
    {
        if (File.Exists(dosyaAdi)) 
        {
            string[] evler = File.ReadAllLines(dosyaAdi); 
            foreach (string ev in evler) 
            {
                Console.WriteLine(ev); 
            }
        }
        else
        {
            Console.WriteLine("Kayıtlı ev bulunamadı."); 
        }
    }

    static void YeniKiralikEvGir()
    {
        Console.WriteLine("Kiralık Ev Bilgileri Giriniz:"); 
        string odaSayisi = SayiGir("Evin oda sayısı: "); 
        string katNumarasi = SayiGir("Evin kat numarası: "); 
        string alan = SayiGir("Evin alanı: "); 
        string kira = SayiGir("Evin kirası: "); 
        string depozito = SayiGir("Evin depozitosu: "); 

        string evBilgileri = $"Oda Sayısı: {odaSayisi}, Kat Numarası: {katNumarasi}, Alan: {alan}, Kira: {kira}, Depozito: {depozito}"; 
        kiralikEvler.Add(evBilgileri); 

        DosyayaKaydet("kiralik_evler.txt", evBilgileri); 
    }

    static void YeniSatilikEvGir()
    {
        Console.WriteLine("Satılık Ev Bilgileri Giriniz:"); 
        string odaSayisi = SayiGir("Evin oda sayısı: "); 
        string katNumarasi = SayiGir("Evin kat numarası: "); 
        string alan = SayiGir("Evin alanı: "); 
        string fiyat = SayiGir("Evin fiyatı: "); 
        string depozito = SayiGir("Evin depozitosu: "); 

        string evBilgileri = $"Oda Sayısı: {odaSayisi}, Kat Numarası: {katNumarasi}, Alan: {alan}, Fiyat: {fiyat}, Depozito: {depozito}";
        satilikEvler.Add(evBilgileri); 

        DosyayaKaydet("satilik_evler.txt", evBilgileri); 
    }

    static string SayiGir(string mesaj)
    {
        while (true) 
        {
            Console.Write(mesaj); 
            string giris = Console.ReadLine(); 
            if (int.TryParse(giris, out _)) 
            {
                return giris; 
            }
            else
            {
                Console.WriteLine("Lütfen geçerli bir sayısal değer giriniz."); 
            }
        }
        static T SayiGir<T>(string mesaj) where T : IConvertible
        {
            while (true)
            {
                Console.Write(mesaj);
                string giris = Console.ReadLine();
                try
                {
                    var value = (T)Convert.ChangeType(giris, typeof(T));
                    return value;
                }
                catch
                {
                    Console.WriteLine("Lütfen geçerli bir sayısal değer giriniz.");
                }
            }
        }

    }

    static void DosyayaKaydet(string dosyaAdi, string veri)
    {
        using (StreamWriter sw = File.AppendText(dosyaAdi)) 
        {
            sw.WriteLine(veri); 
        }
        Console.WriteLine("Girilen ev bilgileri dosyaya kaydedildi."); 
    }
}
