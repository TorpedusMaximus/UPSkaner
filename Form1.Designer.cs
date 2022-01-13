
namespace UPSkaner
{
    partial class Skaner
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.skanuj = new System.Windows.Forms.Button();
            this.drukujSkan = new System.Windows.Forms.PictureBox();
            this.etykietaRozdz = new System.Windows.Forms.Label();
            this.szarosc = new System.Windows.Forms.RadioButton();
            this.RGB = new System.Windows.Forms.RadioButton();
            this.bitowy = new System.Windows.Forms.RadioButton();
            this.trybSkanowania = new System.Windows.Forms.Label();
            this.zapis = new System.Windows.Forms.ComboBox();
            this.eksport = new System.Windows.Forms.Label();
            this.skanery = new System.Windows.Forms.ComboBox();
            this.etykietaSKan = new System.Windows.Forms.Label();
            this.wczytajSkanery = new System.Windows.Forms.Button();
            this.ostrzezenie = new System.Windows.Forms.Label();
            this.systemowy = new System.Windows.Forms.Button();
            this.zapisz = new System.Windows.Forms.Button();
            this.DPI = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.drukujSkan)).BeginInit();
            this.SuspendLayout();
            // 
            // skanuj
            // 
            this.skanuj.Location = new System.Drawing.Point(42, 550);
            this.skanuj.Name = "skanuj";
            this.skanuj.Size = new System.Drawing.Size(94, 48);
            this.skanuj.TabIndex = 0;
            this.skanuj.Text = "Skanuj";
            this.skanuj.UseVisualStyleBackColor = true;
            this.skanuj.Click += new System.EventHandler(this.skanuj_Click);
            // 
            // drukujSkan
            // 
            this.drukujSkan.Location = new System.Drawing.Point(424, 12);
            this.drukujSkan.Name = "drukujSkan";
            this.drukujSkan.Size = new System.Drawing.Size(490, 586);
            this.drukujSkan.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.drukujSkan.TabIndex = 1;
            this.drukujSkan.TabStop = false;
            // 
            // etykietaRozdz
            // 
            this.etykietaRozdz.AutoSize = true;
            this.etykietaRozdz.Location = new System.Drawing.Point(39, 201);
            this.etykietaRozdz.Name = "etykietaRozdz";
            this.etykietaRozdz.Size = new System.Drawing.Size(78, 13);
            this.etykietaRozdz.TabIndex = 3;
            this.etykietaRozdz.Text = "Rozdzielczość:";
            // 
            // szarosc
            // 
            this.szarosc.AutoSize = true;
            this.szarosc.Location = new System.Drawing.Point(212, 325);
            this.szarosc.Name = "szarosc";
            this.szarosc.Size = new System.Drawing.Size(93, 17);
            this.szarosc.TabIndex = 4;
            this.szarosc.TabStop = true;
            this.szarosc.Text = "Skala szarości";
            this.szarosc.UseVisualStyleBackColor = true;
            this.szarosc.CheckedChanged += new System.EventHandler(this.szarosc_CheckedChanged);
            // 
            // RGB
            // 
            this.RGB.AutoSize = true;
            this.RGB.Location = new System.Drawing.Point(144, 325);
            this.RGB.Name = "RGB";
            this.RGB.Size = new System.Drawing.Size(48, 17);
            this.RGB.TabIndex = 5;
            this.RGB.TabStop = true;
            this.RGB.Text = "RGB";
            this.RGB.UseVisualStyleBackColor = true;
            this.RGB.CheckedChanged += new System.EventHandler(this.RGB_CheckedChanged);
            // 
            // bitowy
            // 
            this.bitowy.AutoSize = true;
            this.bitowy.Location = new System.Drawing.Point(322, 325);
            this.bitowy.Name = "bitowy";
            this.bitowy.Size = new System.Drawing.Size(64, 17);
            this.bitowy.TabIndex = 6;
            this.bitowy.TabStop = true;
            this.bitowy.Text = "1-bitowy";
            this.bitowy.UseVisualStyleBackColor = true;
            this.bitowy.CheckedChanged += new System.EventHandler(this.bitowy_CheckedChanged);
            // 
            // trybSkanowania
            // 
            this.trybSkanowania.AutoSize = true;
            this.trybSkanowania.Location = new System.Drawing.Point(35, 329);
            this.trybSkanowania.Name = "trybSkanowania";
            this.trybSkanowania.Size = new System.Drawing.Size(91, 13);
            this.trybSkanowania.TabIndex = 7;
            this.trybSkanowania.Text = "Tryb skanowania:";
            // 
            // zapis
            // 
            this.zapis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.zapis.FormattingEnabled = true;
            this.zapis.Items.AddRange(new object[] {
            ".jpg",
            ".jpeg",
            ".png",
            ".pdf"});
            this.zapis.Location = new System.Drawing.Point(133, 441);
            this.zapis.Name = "zapis";
            this.zapis.Size = new System.Drawing.Size(257, 21);
            this.zapis.TabIndex = 8;
            // 
            // eksport
            // 
            this.eksport.AutoSize = true;
            this.eksport.Location = new System.Drawing.Point(39, 449);
            this.eksport.Name = "eksport";
            this.eksport.Size = new System.Drawing.Size(75, 13);
            this.eksport.TabIndex = 9;
            this.eksport.Text = "Plik do zapisu:";
            // 
            // skanery
            // 
            this.skanery.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.skanery.FormattingEnabled = true;
            this.skanery.Location = new System.Drawing.Point(133, 69);
            this.skanery.Name = "skanery";
            this.skanery.Size = new System.Drawing.Size(257, 21);
            this.skanery.TabIndex = 10;
            // 
            // etykietaSKan
            // 
            this.etykietaSKan.AutoSize = true;
            this.etykietaSKan.Location = new System.Drawing.Point(39, 72);
            this.etykietaSKan.Name = "etykietaSKan";
            this.etykietaSKan.Size = new System.Drawing.Size(44, 13);
            this.etykietaSKan.TabIndex = 11;
            this.etykietaSKan.Text = "Skaner:";
            // 
            // wczytajSkanery
            // 
            this.wczytajSkanery.Location = new System.Drawing.Point(271, 111);
            this.wczytajSkanery.Name = "wczytajSkanery";
            this.wczytajSkanery.Size = new System.Drawing.Size(119, 23);
            this.wczytajSkanery.TabIndex = 12;
            this.wczytajSkanery.Text = "Wczytaj skanery";
            this.wczytajSkanery.UseVisualStyleBackColor = true;
            this.wczytajSkanery.Click += new System.EventHandler(this.odswierz_Click);
            // 
            // ostrzezenie
            // 
            this.ostrzezenie.AutoSize = true;
            this.ostrzezenie.Location = new System.Drawing.Point(39, 465);
            this.ostrzezenie.Name = "ostrzezenie";
            this.ostrzezenie.Size = new System.Drawing.Size(229, 13);
            this.ostrzezenie.TabIndex = 16;
            this.ostrzezenie.Text = "Wybór .pdf zapisze także kopię w formacie .jpg";
            // 
            // systemowy
            // 
            this.systemowy.Location = new System.Drawing.Point(142, 550);
            this.systemowy.Name = "systemowy";
            this.systemowy.Size = new System.Drawing.Size(126, 48);
            this.systemowy.TabIndex = 17;
            this.systemowy.Text = "Skanuj z aplikacją systemową";
            this.systemowy.UseVisualStyleBackColor = true;
            this.systemowy.Click += new System.EventHandler(this.systemowy_Click);
            // 
            // zapisz
            // 
            this.zapisz.Location = new System.Drawing.Point(274, 550);
            this.zapisz.Name = "zapisz";
            this.zapisz.Size = new System.Drawing.Size(112, 48);
            this.zapisz.TabIndex = 18;
            this.zapisz.Text = "Zapisz";
            this.zapisz.UseVisualStyleBackColor = true;
            this.zapisz.Click += new System.EventHandler(this.zapisz_Click);
            // 
            // DPI
            // 
            this.DPI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DPI.FormattingEnabled = true;
            this.DPI.Items.AddRange(new object[] {
            "75",
            "100",
            "200",
            "300",
            "600"});
            this.DPI.Location = new System.Drawing.Point(133, 201);
            this.DPI.Name = "DPI";
            this.DPI.Size = new System.Drawing.Size(257, 21);
            this.DPI.TabIndex = 19;
            // 
            // Skaner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 615);
            this.Controls.Add(this.DPI);
            this.Controls.Add(this.zapisz);
            this.Controls.Add(this.systemowy);
            this.Controls.Add(this.ostrzezenie);
            this.Controls.Add(this.wczytajSkanery);
            this.Controls.Add(this.etykietaSKan);
            this.Controls.Add(this.skanery);
            this.Controls.Add(this.eksport);
            this.Controls.Add(this.zapis);
            this.Controls.Add(this.trybSkanowania);
            this.Controls.Add(this.bitowy);
            this.Controls.Add(this.RGB);
            this.Controls.Add(this.szarosc);
            this.Controls.Add(this.etykietaRozdz);
            this.Controls.Add(this.drukujSkan);
            this.Controls.Add(this.skanuj);
            this.Name = "Skaner";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.drukujSkan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button skanuj;
        private System.Windows.Forms.PictureBox drukujSkan;
        private System.Windows.Forms.Label etykietaRozdz;
        private System.Windows.Forms.RadioButton szarosc;
        private System.Windows.Forms.RadioButton RGB;
        private System.Windows.Forms.RadioButton bitowy;
        private System.Windows.Forms.Label trybSkanowania;
        private System.Windows.Forms.ComboBox zapis;
        private System.Windows.Forms.Label eksport;
        private System.Windows.Forms.ComboBox skanery;
        private System.Windows.Forms.Label etykietaSKan;
        private System.Windows.Forms.Button wczytajSkanery;
        private System.Windows.Forms.Label ostrzezenie;
        private System.Windows.Forms.Button systemowy;
        private System.Windows.Forms.Button zapisz;
        private System.Windows.Forms.ComboBox DPI;
    }
}

