using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Linq;

namespace calisma
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            DataTable personelliste = new DataTable();
            personelliste.Columns.Add("Ad");
            personelliste.Columns.Add("Soyad");

            string[] adlar = { "Mehmet", "Havva", "Önder", "Derya", "Fuat", "Bekir" };
            string[] soyadlar = { "Türkoğlu", "Aslan", "Turan", "Demirci", "Aksu", "Yılmaz" };

            Random random = new Random();
            List<int> kullanilanIndexler = new List<int>();
            for (int i = 0; i < adlar.Length; i++)
            {
                int randomIndex;

                do
                {
                    randomIndex = random.Next(adlar.Length);
                } while (kullanilanIndexler.Contains(randomIndex));

                kullanilanIndexler.Add(randomIndex);

                DataRow row = personelliste.NewRow();
                row["Ad"] = adlar[randomIndex];
                row["Soyad"] = soyadlar[randomIndex];
                personelliste.Rows.Add(row);
            }
            dataGridView1.DataSource = personelliste;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToDeleteRows = false;
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            DataTable isvezorluk = new DataTable();
            isvezorluk.Columns.Add("Yapılacak İş");
            isvezorluk.Columns.Add("Zorluk");

            string[] isler = { "Yazılım Geliştirme", "Proje Yönetimi", "Yazılım Test ve Kalite Güvencesi", "Yazılım Bakım ve Destek", "Danışmanlık Hizmetleri", "Özelleştirme ve Entegrasyon" };
            string[] zorluk = { "1.Derece", "2.Derece", "3.Derece", "4.Derece", "5.Derece", "6.Derece" };

            Random randomm = new Random();
            List<int> isİndex = new List<int>();
            for (int i = 0; i < isler.Length; i++)
            {
                int isRandom;
                do
                {
                    isRandom = random.Next(isler.Length);
                } while (isİndex.Contains(isRandom));
                isİndex.Add(isRandom);

                DataRow row = isvezorluk.NewRow();
                row["Yapılacak İş"] = isler[isRandom];
                row["Zorluk"] = zorluk[isRandom];
                isvezorluk.Rows.Add(row);
            }
            dataGridView2.DataSource = isvezorluk;
            dataGridView2.ReadOnly = true;
            dataGridView2.AllowUserToDeleteRows = false;
        }
        /// <summary>
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// </summary>
        /* private void AtamaYap()
         {
             Random random = new Random();
             int maxRepeatCount = 6;

             for (int i = 0; i <= maxRepeatCount; i++)
             {
                 string personelAd = dataGridView1.Rows[random.Next(dataGridView1.Rows.Count)].Cells["Ad"].Value.ToString();
                 string personelSoyad = dataGridView1.Rows[random.Next(dataGridView1.Rows.Count)].Cells[0].Value.ToString();

                 dataGridView3.Rows.Add(personelAd,personelSoyad);*/
        //   }
        //  }
        private void button2_Click(object sender, EventArgs e)
        {
            DataTable personelliste = new DataTable();
            personelliste.Columns.Add("Ad");
            personelliste.Columns.Add("Soyad");

            DataTable isler = new DataTable();
            isler.Columns.Add("Yapılacak İş");

            // Kişilerin ad ve soyad bilgileri
            string[] adlar = { "Mehmet", "Havva", "Önder", "Derya", "Fuat", "Bekir" };
            string[] soyadlar = { "Türkoğlu", "Aslan", "Turan", "Demirci", "Aksu", "Yılmaz" };

            // İşlerin listesi
            string[] yapilacakIsler = { "Yazılım Geliştirme", "Proje Yönetimi", "Yazılım Test ve Kalite Güvencesi", "Yazılım Bakım ve Destek", "Danışmanlık Hizmetleri", "Özelleştirme ve Entegrasyon" };

            Random random = new Random();

            // Kişileri rastgele sıralayarak personelliste tablosuna ekle
            List<string> adSoyadListesi = new List<string>();
            for (int i = 0; i < adlar.Length; i++)
            {
                adSoyadListesi.Add(adlar[i] + " " + soyadlar[i]);
            }

            adSoyadListesi = adSoyadListesi.OrderBy(x => random.Next()).ToList();

            foreach (string adSoyad in adSoyadListesi)
            {
                string[] adSoyadParcalari = adSoyad.Split(' ');
                DataRow row = personelliste.NewRow();
                row["Ad"] = adSoyadParcalari[0];
                row["Soyad"] = adSoyadParcalari[1];
                personelliste.Rows.Add(row);
            }
            // İşleri rastgele sıralayarak isler tablosuna ekle          
            List<string> yapilacakIslerListesi = new List<string>(yapilacakIsler);

            yapilacakIslerListesi = yapilacakIslerListesi.OrderBy(x => random.Next()).ToList();

            foreach (string yapilacakIs in yapilacakIslerListesi)
            {
                DataRow row = isler.NewRow();
                row["Yapılacak İş"] = yapilacakIs;
                isler.Rows.Add(row);
            }
            for (int a = 0; a < yapilacakIslerListesi.Count; a++)
            {
                // Atamaları yap ve sonuçları datagrid3'e yazdır
                DataTable atamalar = new DataTable();
                atamalar.Columns.Add("Gün");
                atamalar.Columns.Add("Ad");
                atamalar.Columns.Add("Soyad");
                atamalar.Columns.Add("Yapılacak İş");

                string[] gunler = { "1.Gün", "2.Gün", "3.Gün", "4.Gün", "5.Gün", "6.Gün" };

                for (int gunIndex = 0; gunIndex < gunler.Length; gunIndex++)
                {
                    for (int personelIndex = 0; personelIndex < isler.Rows.Count; personelIndex++)
                    {
                        DataRow row = atamalar.NewRow();
                        row["Gün"] = gunler[gunIndex];
                        row["Ad"] = personelliste.Rows[personelIndex]["Ad"];
                        row["Soyad"] = personelliste.Rows[personelIndex]["Soyad"];


                        List<string> availableJobs = new List<string>(yapilacakIslerListesi);


                        while (availableJobs.Count > 0)
                        {
                            int randomIndex = random.Next(availableJobs.Count);
                            string seciliis = availableJobs[randomIndex];
                            availableJobs.RemoveAt(randomIndex);


                         //   row["Yapılacak İş"] = isler.Rows[((gunIndex * personelliste.Rows.Count) + personelIndex) % isler.Rows.Count]["Yapılacak İş"];
                              row["Yapılacak İş"] = isler.Rows[(randomIndex % isler.Rows.Count)]["Yapılacak İş"];


                            break;
                        }

                        atamalar.Rows.Add(row);
                    }
                }
                dataGridView3.DataSource = atamalar;
                dataGridView3.ReadOnly = true;
                dataGridView3.AllowUserToDeleteRows = false;


                /*for (int i = 0; i < personelliste.Rows.Count; i++)
                {
                    DataRow row = atamalar.NewRow();
                    row["Ad"] = personelliste.Rows[i]["Ad"];
                    row["Soyad"] = personelliste.Rows[i]["Soyad"];
                    row["Yapılacak İş"] = isler.Rows[i % isler.Rows.Count]["Yapılacak İş"];
                    atamalar.Rows.Add(row);
                }
                dataGridView3.DataSource = atamalar;*/
            }
            //AtamaYap();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}



