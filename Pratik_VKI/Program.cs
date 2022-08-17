public class Program
{
    struct HastaBilgileri
    {
        public string name;
        public string surname;
        public double height;
        public double weight;
        public double patientVki;
        public string vki;

        public void EkranaYazdir()
        {
            Console.WriteLine($"Hasta adi soyadi:{name} {surname};\nBoyu: {height},\nKilosu: {weight}\nVKI:{VkiHesaplama()}\nTeshis:{vki}");
            MenuAgain();
        }
        public double VkiHesaplama()
        {
            height = height / 100;
            height = Math.Pow(height, 2);
            patientVki = weight / height;
            patientVki = Math.Round(patientVki, 2);
            vki=VkiStringDondurme();
            return patientVki;
        }
        private string VkiStringDondurme()
        {
            if (patientVki <= 18.4)
            {
                vki = "ZAYIF";
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else if(patientVki>18.4 && patientVki <= 24.9)
            {
                vki = "NORMAL";
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else if(patientVki>24.9 && patientVki < 29.9)
            {
                vki = "HAFIF KILOLU";
                Console.ForegroundColor = ConsoleColor.Yellow;

            }
            else
            {
                vki = "OBEZ";
                Console.ForegroundColor = ConsoleColor.Red;
            }

            return vki;

        }
    }
    static List<HastaBilgileri> PatientList = new List<HastaBilgileri>();

    public static void Main()
    {
        Console.WriteLine("VKI programina hosgeldiniz");
        Menu();

    }
    static void Menu()
    {
        Console.Clear();
        Console.Write("Yeni Hasta: 1\nHasta Listesi: 2\nCikis: 3\n");
        MenuSelection();
    }
    static void MenuSelection()
    {
        Console.Write("Yapilacak islemi seciniz: ");
        string? input = Console.ReadLine();
        switch(input)
        {
            case "1":
                NewPatient();
                break;
            case "2":
                ListOfPatients();
                break;
            case "3":
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Hatali secim.Tekrar seciniz");
                MenuSelection();
                break;
        }
    }
    private static void NewPatient()
    {
        var r = new HastaBilgileri();
        Console.Write("Hasta Adini giriniz: ");
        r.name = Console.ReadLine();
        Console.Write("Hasta Soyadini giriniz: ");
        r.surname = Console.ReadLine();
        Console.Write("Hasta boyunu giriniz: ");
        r.height = Convert.ToDouble(Console.ReadLine());
        Console.Write("Hasta kilosunu giriniz: ");
        r.weight = Convert.ToDouble(Console.ReadLine());
        PatientList.Add(r);
        //r.EkranaYazdir();
        MenuAgain();
    }
    static void ListOfPatients()
    {
        for(int i = 0; i < PatientList.Count; i++)
        {
            PatientList[i].EkranaYazdir();

        }
    }
    static void MenuAgain()
    {
        Console.ResetColor();
        Console.WriteLine("Menuye donmek icin enter a basiniz");
        Console.ReadLine();
        Menu();
    }
}