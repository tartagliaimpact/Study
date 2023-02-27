using System.Collections.Generic;
using System.Xml.Serialization;
using System.Text.Json;
using System.Text;

namespace лаб2_ООП
{


    public partial class Form1 : Form
    {
        List<Apartment> apartments = new List<Apartment>();



        List<int> years = new List<int>()
        { 1930, 1931, 1932, 1933, 1934, 1935, 1936, 1937, 1938, 1939, 1940, 1941, 1942, 1943, 1944, 1945, 1946, 1947, 1948, 1949, 1950, 1960, 1961, 1962, 1963, 1964, 1965, 1966, 1967, 1968, 1969 , 1970,
          1971, 1972, 1973, 1974, 1975, 1976, 1977, 1978, 1979, 1980, 1981, 1982, 1983, 1984, 1985, 1986, 1987, 1988, 1989, 1990, 1991, 1992, 1993, 1994, 1995, 1996, 1997, 1998, 1999, 2000, 2001, 2002,
          2003, 2004, 2005, 2006, 2007, 2008, 2009, 2010, 2011, 2012, 2013, 2014, 2015, 2016, 2017, 2018, 2019, 2020, 2021, 2022, 2023
        };

        List<string> materials = new List<string>()
        {
            "", "Панель", "Кирпич", "Монолит(Армированный бетон)"
        };

        List<string> countries = new List<string>()
        {
            "", "Беларусь", "Германия" 
        };

        List<string> cities = new List<string>()
        {
            "", "Минск", "Берлин"
        };

        List<string> areas = new List<string>()
        {
            "", "Октябрьский", "Friedrichshain-Kreuzberg"
        };

        List<string> streets = new List<string>()
        {
            "","Асаналиева", "Кижеватова", "Lichtenberger Straße", "Kleine Andreasstraße"
    };



        List<int> houses = new List<int>()
        {
           1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63, 64, 65, 66
        };

        public Form1()
        {
            InitializeComponent();

            this.comboBox1.DataSource = years;
            this.comboBox2.DataSource = materials;
            this.comboBox3.DataSource = countries;
            this.comboBox4.DataSource = cities;
            this.comboBox5.DataSource = areas;
            this.comboBox6.DataSource = streets;
            this.comboBox7.DataSource = houses;
            this.trackBar1.Minimum = 1;
            this.trackBar1.Maximum = 400;
            this.hScrollBar2.Minimum = 0;
            this.hScrollBar2.Maximum = 15;



        }

        private void DataGridRowAdd(DataGridView dgv)
        {
            string alphabet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯабвгдеёжзийклмнопрстуфхцчшщъыьэюяABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz!№;:?*()-=_+@#$%^&";
            try
            {
                foreach (char x in this.footgtb.Text)
                {
                    foreach (char y in alphabet)
                    {
                        if (x.Equals(y) == true)
                        {
                            throw new Exception("Ошибка! Некорректные данные!");
                        }
                    }
                }
                dataGridView1.Rows.Add(this.footgtb.Text, this.colkomnud.Value, this.checkBox1.Checked, this.checkBox2.Checked, this.checkBox3.Checked, this.checkBox4.Checked, this.checkBox5.Checked,
                this.comboBox1.SelectedItem, this.comboBox2.SelectedItem, this.floorNuD.Value,
                "" + this.comboBox3.SelectedItem + ", город " + this.comboBox4.SelectedItem + ", район : "
                + this.comboBox5.SelectedItem + ", ул." + this.comboBox6.SelectedItem + ",  д." + this.comboBox7.SelectedItem + "/" + this.hScrollBar2.Value + ", кв." + this.trackBar1.Value + "");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                return;
            }
        }
        private void AddAp_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren(ValidationConstraints.Enabled))
                return;
            apartments.Add(new Apartment(new Adress(this.comboBox3, this.comboBox4, this.comboBox5, this.comboBox6, this.comboBox7, this.hScrollBar2, this.trackBar1),
                this.footgtb, this.colkomnud, this.checkBox1, this.checkBox2, this.checkBox3, this.checkBox4, this.checkBox5, 
                this.comboBox1, this.comboBox2, this.floorNuD));
            
            DataGridRowAdd(dataGridView1);
            Apartment.Clear(this.comboBox3, this.comboBox4, this.comboBox5, this.comboBox6, this.comboBox7, this.hScrollBar2, this.trackBar1,
                this.footgtb, this.colkomnud, this.checkBox1, this.checkBox2, this.checkBox3, this.checkBox4, this.checkBox5,
                this.comboBox1, this.comboBox2, this.floorNuD);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label16.Text = String.Format("Номер: {0}", trackBar1.Value);
        }

        private void hScrollBar2_Scroll(object sender, ScrollEventArgs e)
        {
            label17.Text = String.Format("Номер: {0}", hScrollBar2.Value);
        }

        private void clearb_Click(object sender, EventArgs e)
        {
            Apartment.Clear(this.comboBox3, this.comboBox4, this.comboBox5, this.comboBox6, this.comboBox7, this.hScrollBar2, this.trackBar1,
                this.footgtb, this.colkomnud, this.checkBox1, this.checkBox2, this.checkBox3, this.checkBox4, this.checkBox5,
                this.comboBox1, this.comboBox2, this.floorNuD);
        }

        private void XMLWrite_Click(object sender, EventArgs e)
        {
            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(List<Apartment>));
                using (FileStream fs = new FileStream("Apartments.xml", FileMode.OpenOrCreate))
                {
                    xml.Serialize(fs, apartments);
                }
                MessageBox.Show("Данные уcпешно сохранены на xml");
            }
            catch 
            {
                MessageBox.Show("Ошибка!");
            }
        }


        private void XMLRead_Click(object sender, EventArgs e)
        {
            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(List<Apartment>));
                using (FileStream fs = File.OpenRead("Apartments.xml"))
                {
                    List<Apartment> bufflist = new List<Apartment>();
                    bufflist = xml.Deserialize(fs) as List<Apartment>;
                    foreach (Apartment a in bufflist)
                    {
                        apartments.Add(a);
                        dataGridView1.Rows.Add(a.footage, a.roomcolich, a.kitchen, a.bath, a.toilet, a.basement, a.balcony,
                        a.year_of_building, a.material_type, a.floor,
                        "" + a.adress.country + ", город " + a.adress.city + ", район : "
                        + a.adress.area + ", ул." + a.adress.street + ",  д." + a.adress.house + "/" + a.adress.housling + ", кв." + a.adress.apart_number + "");
                    }
                }

            }
            catch
            {
                MessageBox.Show("Ошибка!");
            }
        }








    }
    //-----------------------------------------------------------------------
    //Классы Квартира и Адресс
    //-----------------------------------------------------------------------

    public class Adress
    {
        public string country;
        public string city;
        public string area;
        public string street;
        public int house;
        public int housling;
        public int apart_number;
        public Adress()
        {}
        public Adress(ComboBox ctr, ComboBox ct, ComboBox ar, ComboBox str, ComboBox hse, HScrollBar hsling, TrackBar an)
        {
            country = ctr.SelectedValue.ToString();
            city = ct.SelectedValue.ToString();
            area = ar.SelectedValue.ToString();
            street = str.SelectedValue.ToString();
            house = Convert.ToInt32(hse.SelectedItem);
            housling = hsling.Value;
            apart_number = an.Value;

        }

        public override string ToString()
        {
            return "" + country + ", город " + city + ", район : "
                 + area + ", ул." + street + ",  д." + house + "/" + housling + ", кв." + apart_number + "";
        }
    }

    public class Apartment
    {
        public Adress adress;

        public int footage;
        public decimal roomcolich;
        public bool kitchen;
        public bool bath;
        public bool toilet;
        public bool basement;
        public bool balcony;
        public int year_of_building;
        public string material_type;
        public int floor;
        public Apartment()
        {

        }

        public Apartment(Adress adr)
        {
            adress = adr;
        }

        string alphabet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯабвгдеёжзийклмнопрстуфхцчшщъыьэюяABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz!№;:?*()-=_+@#$%^&";

        public Apartment(Adress adr, TextBox f, NumericUpDown roomcl,
            CheckBox kitch, CheckBox bathr, CheckBox t, CheckBox bas, CheckBox balc,
            ComboBox yof, ComboBox mt, NumericUpDown flr)
        {
            adress = adr;
            int buff1;
            if (int.TryParse(f.Text, out buff1))
            {
                footage = buff1;
            }
            roomcolich = Convert.ToInt32(roomcl.Value);

            kitchen = kitch.Checked;
            bath = bathr.Checked;
            toilet = t.Checked;
            basement = bas.Checked;
            balcony = balc.Checked;
            year_of_building = Convert.ToInt32(yof.SelectedItem);
            material_type = mt.SelectedItem.ToString();
            floor = Convert.ToInt32(flr.Value);
        }


        public static void Clear(ComboBox ctr, ComboBox ct, ComboBox ar, ComboBox str, ComboBox hse, HScrollBar hsling, TrackBar an, TextBox f, NumericUpDown roomcl,
            CheckBox kitch, CheckBox bathr, CheckBox t, CheckBox bas, CheckBox balc,
            ComboBox yof, ComboBox mt, NumericUpDown flr)
        {
            ctr.SelectedIndex = 0;
            ct.SelectedIndex = 0;
            ar.SelectedIndex = 0;
            str.SelectedIndex = 0;
            hse.SelectedIndex = 0;
            hsling.Value = 0;
            an.Value = an.Minimum;
            f.Text = "";
            roomcl.Value = 0;
            kitch.Checked = false;
            bathr.Checked = false;
            t.Checked = false;
            bas.Checked = false;
            balc.Checked = false;
            yof.SelectedIndex = 0;
            mt.SelectedIndex = 0;
            flr.Value = flr.Minimum;
        }

    }


}