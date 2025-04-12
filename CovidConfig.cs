using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace tpmodul8_103022330091
{
    class CovidConfig
    {
        public class PasienCovid
        {
            public string satuan_suhu { get; set; }
            public int batas_hari_demam { get; set; }
            public string pesan_ditolak { get; set; }
            public string pesan_diterima { get; set; }

            public PasienCovid(string satuan_suhu, int batas_hari_demam, string pesan_ditolak, string pesan_diterima)
            {
                this.satuan_suhu = satuan_suhu;
                this.batas_hari_demam = batas_hari_demam;
                this.pesan_ditolak = pesan_ditolak;
                this.pesan_diterima = pesan_diterima;
            }
        }

        public PasienCovid pasienCovid;

        public const String filePath = @"covid_config.json";

        public CovidConfig()
        {
            try
            {
                ReadConfigFile();
            } 
            catch (Exception e)
            {
                WriteNewConfigFile();
            }
        }

        private PasienCovid ReadConfigFile()
        {
            String configJson = File.ReadAllText(filePath);
            pasienCovid = JsonSerializer.Deserialize<PasienCovid>(configJson);
            return pasienCovid;
        }

        private void WriteNewConfigFile()
        {
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };

            String json = JsonSerializer.Serialize(pasienCovid, options);
            File.WriteAllText("covid_config.json", json);
        }

        public void ubahSatuan()
        {
            if (pasienCovid.satuan_suhu.Equals("celsius"))
            {
                pasienCovid.satuan_suhu = "fahrenheit";
            }
            else
            {
                pasienCovid.satuan_suhu = "celsius";
            }
        }
    }
}
