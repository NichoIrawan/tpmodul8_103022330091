using tpmodul8_103022330091;

class main
{
    public static void Main(string[] args)
    {
        int derajat = -1;
        int perkiraanHari = -1;
        CovidConfig covidConfig = new CovidConfig();

        covidConfig.ubahSatuan();

        Console.WriteLine($"Berapa suhu badan anda saat \r\nini? Dalam nilai {covidConfig.pasienCovid.satuan_suhu}");
        String input = Console.ReadLine();
        try
        {
            derajat = int.Parse(input);
        } 
        catch (Exception e)
        {
            Console.WriteLine("input salah");
        }

        Console.WriteLine("Berapa hari yang lalu(perkiraan) anda terakhir memiliki gejala deman ?");
        input = Console.ReadLine();
        try
        {
            perkiraanHari = int.Parse(input);
        }
        catch (Exception e)
        {
            Console.WriteLine("input salah");
        }

        if (check(covidConfig, derajat, perkiraanHari))
        {
            Console.WriteLine(covidConfig.pasienCovid.pesan_diterima);
        }
        else
        {
            Console.WriteLine(covidConfig.pasienCovid.pesan_ditolak);
        }
    }

    private static bool check(CovidConfig config, int suhu, int perkiraanHari)
    {
        if (config.pasienCovid.satuan_suhu.Equals("celsius"))
        {
            return suhu > 36.5 && suhu < 37.5 && perkiraanHari < config.pasienCovid.batas_hari_demam;
        }
        else
        {
            return suhu > 97.7 && suhu < 99.5 && perkiraanHari < config.pasienCovid.batas_hari_demam;
        }
    }
}