using Aspose.Pdf;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using WIA;

namespace UPSkaner
{
    public partial class Skaner : Form
    {
        private static int color_mode = 1;
        WIA.CommonDialog oknoSkanowania = new WIA.CommonDialog();

        public Skaner()
        {
            InitializeComponent();
            RGB.Checked = true;
            zapis.SelectedIndex = 0;
            DPI.SelectedIndex = 2;
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

                File.Delete("skan.jpg");
                obraz.SaveFile("skan.jpg");
                drukujSkan.ImageLocation = "skan.jpg";
            }
            catch (COMException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void odswierz_Click(object sender, EventArgs e)
        {
            skanery.Items.Clear();
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

        private void systemowy_Click(object sender, EventArgs e)
        {
            var obraz = oknoSkanowania.ShowAcquireImage();
            File.Delete("skan.jpg");
            obraz.SaveFile("skan.jpg");
            drukujSkan.ImageLocation = "skan.jpg";
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

            zmienOpcje(skan.Properties, WIA_HORIZONTAL_SCAN_RESOLUTION_DPI, int.Parse(DPI.SelectedItem.ToString()) );
            zmienOpcje(skan.Properties, WIA_VERTICAL_SCAN_RESOLUTION_DPI, int.Parse(DPI.SelectedItem.ToString()));
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

        private void zapisz_Click(object sender, EventArgs e)
        {
            String sciezka = null;
            SaveFileDialog okienko = new SaveFileDialog();
            System.Drawing.Image obraz = System.Drawing.Image.FromFile("skan.jpg");

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
                Document dokument = new Document();
                Page strona = dokument.Pages.Add();
                Aspose.Pdf.Image obrazPomocniczy = new Aspose.Pdf.Image();
                obrazPomocniczy.File = ("skan.jpg");

                int h = obraz.Height;
                int w = obraz.Width;
                strona.PageInfo.Height = (h);
                strona.PageInfo.Width = (w);
                strona.PageInfo.Margin.Bottom = (0);
                strona.PageInfo.Margin.Top = (0);
                strona.PageInfo.Margin.Right = (0);
                strona.PageInfo.Margin.Left = (0);

                strona.Paragraphs.Add(obrazPomocniczy);
                dokument.Save(sciezka);
            }
            else
            {
                obraz.Save(sciezka);
                drukujSkan.ImageLocation = sciezka;
            }
        }
    }
}
