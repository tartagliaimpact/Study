using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;

namespace лаб3_ООП
{
    //-----------------------------------------------------------------
    //Классы Квартира и Адресс
    //-----------------------------------------------------------------

    public class Adress
    {
        public string? country;
        public string? city;
        public string? area;
        public string? street;
        public int house;
        public int housling;
        public int apart_number;
        public int index;
        public Adress()
        { }
        public Adress(ComboBox ctr, ComboBox ct, ComboBox ar, ComboBox str, ComboBox hse, HScrollBar hsling, TrackBar an, TextBox ib)
        {
            try
            {
                country = ctr.SelectedValue.ToString();
                city = ct.SelectedValue.ToString();
                area = ar.SelectedValue.ToString();
                street = str.SelectedValue.ToString();
                house = Convert.ToInt32(hse.SelectedItem);
                housling = hsling.Value;

                apart_number = an.Value;
                int buff1;
                if (int.TryParse(ib.Text, out buff1))
                {
                    index = buff1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
        [Range(10, 1000,
        ErrorMessage = "Некорректный метраж!")]
        public int footage;
        [Range(1, 20,
        ErrorMessage = "Некорректное количество комнат!")]
        public decimal roomcolich;
        public bool kitchen;
        public bool bath;
        public bool toilet;
        public bool basement;
        public bool balcony;
        public int year_of_building;
        public string? material_type;
        public double cost;
        [Range(1, 160,
        ErrorMessage = "Некорректный этаж!")]
        public int floor;
        public Apartment()
        {

        }

        public Apartment(Adress adr)
        {
            adress = adr;
        }


        public Apartment(Adress adr, TextBox f, NumericUpDown roomcl,
            CheckBox kitch, CheckBox bathr, CheckBox t, CheckBox bas, CheckBox balc,
            ComboBox yof, ComboBox mt, NumericUpDown flr, TextBox ct)
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
            double buff2;
            if (Double.TryParse(ct.Text, out buff2))
            {
                cost = buff2;
            }
        }


        public static void Clear(ComboBox ctr, ComboBox ct, ComboBox ar, ComboBox str, ComboBox hse, HScrollBar hsling, TrackBar an, TextBox f, NumericUpDown roomcl,
            CheckBox kitch, CheckBox bathr, CheckBox t, CheckBox bas, CheckBox balc,
            ComboBox yof, ComboBox mt, NumericUpDown flr, TextBox ib, TextBox cst)
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
            ib.Text = "";
            cst.Text = "";
        }

    }
}
