using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using WIA;
using Aspose.Pdf;

namespace UPSkaner
{
    public partial class Form1 : Form
    {
        static int color_mode = 1;

        public Form1()
        {
            InitializeComponent();
            RGB.Checked = true;
            zapis.SelectedIndex = 0;
            wyswietl.Text = "200 DPI";
        }

        private void skanuj_Click(object sender, EventArgs e)
        {
            try
            {
                String nazwaSkanera = (string)skanery.SelectedItem;
                DeviceInfo skaner = null;
                var deviceManager = new DeviceManager();

                for (int i = 1; i <= deviceManager.DeviceInfos.Count; i++)
                {
                    if (deviceManager.DeviceInfos[i].Properties["Name"].get_Value() == nazwaSkanera)
                    {
                        skaner = deviceManager.DeviceInfos[i];
                    }
                }

                if (skaner == null)
                {
                    MessageBox.Show("Błędny skaner");
                    return;
                }

                var skan = skaner.Connect().Items[1];

                ustawSkaner(skan);
                ustawKolor(skan);
                ustawRozdzielczosc(skan);

                ImageFile obraz = skan.Transfer();
                String sciezka = null;
                SaveFileDialog okienko = new SaveFileDialog();

                if (okienko.ShowDialog() == DialogResult.OK)
                {
                    sciezka = okienko.FileName;
                    sciezka = sciezka.Split('.')[0];
                    sciezka += zapis.SelectedItem;
                    Console.WriteLine(sciezka);
                }
                else
                {
                    MessageBox.Show("Błędna ścieżka zapisu");
                    return;
                }

                if (File.Exists(sciezka))
                {
                    File.Delete(sciezka);
                }

                if (zapis.SelectedItem == ".pdf")
                {
                    obraz.SaveFile(sciezka.Split('.')[0] + ".jpg");
                    String sciezkaPomocnicza = sciezka.Split('.')[0] + ".jpg";

                    Document dokument = new Document();
                    Page strona = dokument.Pages.Add();
                    Aspose.Pdf.Image obrazPomocniczy = new Aspose.Pdf.Image();
                    obrazPomocniczy.File = (sciezkaPomocnicza);

                    System.Drawing.Image wczytanyObraz = System.Drawing.Image.FromFile(sciezkaPomocnicza);
                    int h = wczytanyObraz.Height;
                    int w = wczytanyObraz.Width;
                    strona.PageInfo.Height = (h);
                    strona.PageInfo.Width = (w);
                    strona.PageInfo.Margin.Bottom = (0);
                    strona.PageInfo.Margin.Top = (0);
                    strona.PageInfo.Margin.Right = (0);
                    strona.PageInfo.Margin.Left = (0);

                    strona.Paragraphs.Add(obrazPomocniczy);
                    dokument.Save(sciezka);
                    drukujSkan.ImageLocation = sciezkaPomocnicza;
                }
                else
                {
                    obraz.SaveFile(sciezka);
                    drukujSkan.ImageLocation = sciezka;
                }
            }
            catch (COMException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void odswierz_Click(object sender, EventArgs e)
        {
            try
            {
                var deviceManager = new DeviceManager();
                for (int i = 1; i <= deviceManager.DeviceInfos.Count; i++)
                {
                    if (deviceManager.DeviceInfos[i].Type != WiaDeviceType.ScannerDeviceType)
                    {
                        continue;
                    }
                    skanery.Items.Add(deviceManager.DeviceInfos[i].Properties["Name"].get_Value());
                }
            }
            catch (COMException ex)
            {
                MessageBox.Show(ex.Message);
            };
        }


        ////////////////////////USTAWIENIE SKANERA////////////////////////////////

        private static void ustawSkaner(IItem skan)
        {
            const string WIA_HORIZONTAL_SCAN_SIZE_PIXELS = "6151";
            const string WIA_VERTICAL_SCAN_SIZE_PIXELS = "6152";

            zmienOpcje(skan.Properties, WIA_HORIZONTAL_SCAN_SIZE_PIXELS, 2500);
            zmienOpcje(skan.Properties, WIA_VERTICAL_SCAN_SIZE_PIXELS, 3500);
        }

        private void ustawRozdzielczosc(IItem skan)
        {
            const string WIA_HORIZONTAL_SCAN_RESOLUTION_DPI = "6147";
            const string WIA_VERTICAL_SCAN_RESOLUTION_DPI = "6148";

            zmienOpcje(skan.Properties, WIA_HORIZONTAL_SCAN_RESOLUTION_DPI, rozdzielczosc.Value);
            zmienOpcje(skan.Properties, WIA_VERTICAL_SCAN_RESOLUTION_DPI, rozdzielczosc.Value);
        }

        private static void ustawKolor(IItem skan)
        {
            const string WIA_SCAN_COLOR_MODE = "6146";
            zmienOpcje(skan.Properties, WIA_SCAN_COLOR_MODE, color_mode);
        }

        private static void zmienOpcje(IProperties properties, object propName, object propValue)
        {
            Property prop = properties.get_Item(ref propName);
            prop.set_Value(ref propValue);
        }


        ////////////////////////USTAWIENIE KOLORU////////////////////////////////

        private void szarosc_CheckedChanged(object sender, EventArgs e)
        {
            if (szarosc.Checked == true)
            {
                color_mode = 2;
            }
        }

        private void RGB_CheckedChanged(object sender, EventArgs e)
        {
            if (RGB.Checked == true)
            {
                color_mode = 1;
            }
        }

        private void bitowy_CheckedChanged(object sender, EventArgs e)
        {
            if (bitowy.Checked == true)
            {
                color_mode = 4;
            }
        }


        private void rozdzielczosc_ValueChanged(object sender, EventArgs e)
        {
            if (rozdzielczosc.Value % 100 < 50)
            {
                rozdzielczosc.Value -= rozdzielczosc.Value % 100;
            }
            else
            {
                rozdzielczosc.Value -= rozdzielczosc.Value % 100;
                rozdzielczosc.Value += 100;
            }
            wyswietl.Text = rozdzielczosc.Value.ToString() + " DPI";
        }
    }
}
