using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;

namespace лаб3_ООП
{
    public partial class SearchForm : Form
    {
        List<Apartment> Apartments = new List<Apartment>();
        List<Apartment> SearchedApartments = new List<Apartment>();
        public SearchForm()
        {
            InitializeComponent();
        }

        public SearchForm(List<Apartment> apartments)
        {
            InitializeComponent();
            Apartments = apartments;
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (Apartments.Count > 0)
                {
                    SearchGridView1.Rows.Clear();
                    SearchedApartments.Clear();
                    string s = $@"^{this.SearchBox.Text}\w";
                    string s1 = $@"^{this.SearchBox.Text}\d";
                    string s2 = $@"(\w*){this.SearchBox.Text}(\w*)";
                    string s3 = $@"(\w*){this.SearchBox.Text}(\w*)";
                    string s4 = $"{this.SearchBox.Text}";
                    var sl = from b in Apartments
                             where Regex.IsMatch(b.roomcolich.ToString(), s, RegexOptions.IgnoreCase)== true || Regex.IsMatch(b.year_of_building.ToString(), s, RegexOptions.IgnoreCase) == true
                             || Regex.IsMatch(b.adress.city.ToString(), s, RegexOptions.IgnoreCase) == true  || Regex.IsMatch(b.adress.area.ToString(), s, RegexOptions.IgnoreCase) == true
                             //
                             || Regex.IsMatch(b.roomcolich.ToString(), s1, RegexOptions.IgnoreCase) == true || Regex.IsMatch(b.year_of_building.ToString(), s1, RegexOptions.IgnoreCase) == true
                             || Regex.IsMatch(b.adress.city.ToString(), s1, RegexOptions.IgnoreCase) == true || Regex.IsMatch(b.adress.area.ToString(), s1, RegexOptions.IgnoreCase) == true
                             //
                             || Regex.IsMatch(b.roomcolich.ToString(), s2, RegexOptions.IgnoreCase) == true || Regex.IsMatch(b.year_of_building.ToString(), s2, RegexOptions.IgnoreCase) == true
                             || Regex.IsMatch(b.adress.city.ToString(), s2, RegexOptions.IgnoreCase) == true || Regex.IsMatch(b.adress.area.ToString(), s2, RegexOptions.IgnoreCase) == true
                             //
                             || Regex.IsMatch(b.roomcolich.ToString(), s3, RegexOptions.IgnoreCase) == true || Regex.IsMatch(b.year_of_building.ToString(), s3, RegexOptions.IgnoreCase) == true
                             || Regex.IsMatch(b.adress.city.ToString(), s3, RegexOptions.IgnoreCase) == true || Regex.IsMatch(b.adress.area.ToString(), s3, RegexOptions.IgnoreCase) == true
                             //Полное соответсвие
                             || b.roomcolich.ToString() == s4 || b.year_of_building.ToString() == s4 || b.adress.city.ToString() == s4 || b.adress.area.ToString() == s4
                             select b;
                    SearchedApartments = sl.ToList();
                    foreach (var a in SearchedApartments)
                    {
                        SearchGridView1.Rows.Add(a.footage, a.roomcolich, a.kitchen, a.bath, a.toilet, a.basement, a.balcony,
                        a.year_of_building, a.material_type, a.floor, a.adress.index,
                        "" + a.adress.country + ", город " + a.adress.city + ", район : "
                        + a.adress.area + ", ул." + a.adress.street + ",  д." + a.adress.house + "/" + a.adress.housling + ", кв." + a.adress.apart_number + "",
                        a.cost + " бел.руб.");
                    }
                }
                else
                {
                    throw new Exception("Пустой список данных!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        //-----------------------------------------------------------------
        //Очистка
        //-----------------------------------------------------------------
        private void ClearRes_Click(object sender, EventArgs e)
        {
            SearchGridView1.Rows.Clear();
            SearchedApartments.Clear();
        }


        private void SaveRes_Click(object sender, EventArgs e)
        {
            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(List<Apartment>));
                using (FileStream fs = new FileStream("ApartmentsSearch.xml", FileMode.OpenOrCreate))
                {
                    xml.Serialize(fs, SearchedApartments);
                }
                MessageBox.Show("Данные уcпешно сохранены на xml");
            }
            catch
            {
                MessageBox.Show("Ошибка!");
            }
        }

        private void ReadRes_Click(object sender, EventArgs e)
        {
            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(List<Apartment>));
                using (FileStream fs = File.OpenRead("ApartmentsSearch.xml"))
                {
                    List<Apartment>? bufflist = new List<Apartment>();
                    bufflist = xml.Deserialize(fs) as List<Apartment>;
                    foreach (Apartment a in bufflist)
                    {
                        SearchedApartments.Add(a);
                        SearchGridView1.Rows.Add(a.footage, a.roomcolich, a.kitchen, a.bath, a.toilet, a.basement, a.balcony,
                        a.year_of_building, a.material_type, a.floor, a.adress.index,
                        "" + a.adress.country + ", город " + a.adress.city + ", район : "
                        + a.adress.area + ", ул." + a.adress.street + ",  д." + a.adress.house + "/" + a.adress.housling + ", кв." + a.adress.apart_number + "",
                        a.cost + " бел.руб.");
                    }
                }

            }
            catch
            {
                MessageBox.Show("Ошибка!");
            }
        }
    }
}
