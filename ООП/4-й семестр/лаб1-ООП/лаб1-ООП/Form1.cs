
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace лаб1_ООП
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //button1.Click += button1_Click;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Оно работает");
            Calculator.Result(this.Height_, this.Bust, this.Waist, this.Hip, this.Female, this.Male, this.EU_Result, this.RusBel_Result, this.USA_Result, this.UK_Result);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Calculator.Clear(this.Height_, this.Bust, this.Waist, this.Hip, this.Female, this.Male, this.EU_Result, this.RusBel_Result, this.USA_Result, this.UK_Result);
        }
    }

    public static class Calculator
    {


         //Очистка формы
        static public void Clear(TextBox Height_, TextBox Bust, TextBox Waist, TextBox Hip, RadioButton Female, RadioButton Male,
            TextBox EU_Reuslt, TextBox RusBel_Result, TextBox USA_Result, TextBox UK_Result)
        {
            Height_.Text = "";
            Bust.Text = "";
            Waist.Text = "";
            Hip.Text = "";
            Female.Checked = false;
            Male.Checked = false;
            EU_Reuslt.Text = "";
            RusBel_Result.Text = "";
            USA_Result.Text = "";
            UK_Result.Text = "";
        }

        static public void Result(TextBox Height_, TextBox Bust, TextBox Waist, TextBox Hip, RadioButton Female, RadioButton Male, 
            TextBox EU_Reuslt, TextBox RusBel_Result, TextBox USA_Result, TextBox UK_Result)
        {


            EU_Reuslt.Text = "";
            RusBel_Result.Text = "";
            USA_Result.Text = "";
            UK_Result.Text = "";


            
            string alphabet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯабвгдеёжзийклмнопрстуфхцчшщъыьэюяABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz!№;:?*()-=_+@#$%^&";
            try
            {
                
                foreach (char x in Height_.Text)
                {
                    foreach (char y in alphabet)
                    {
                        if(x.Equals(y) == true)
                        {
                            throw new Exception("Ошибка! Некорректные данные!");
                        }
                    }
                }
                foreach (char x in Bust.Text)
                {
                    foreach (char y in alphabet)
                    {
                        if (x.Equals(y) == true)
                        {
                            throw new Exception("Ошибка! Некорректные данные!");
                        }
                    }
                }
                foreach (char x in Waist.Text)
                {
                    foreach (char y in alphabet)
                    {
                        if (x.Equals(y) == true)
                        {
                            throw new Exception("Ошибка! Некорректные данные!");
                        }
                    }
                }
                foreach (char x in Hip.Text)
                {
                    foreach (char y in alphabet)
                    {
                        if (x.Equals(y) == true)
                        {
                            throw new Exception("Ошибка! Некорректные данные!");
                        }
                    }
                }
                if (Height_.Text == "")
                {
                    throw new Exception("Ошибка! Пустые поля!");
                }
                if (Bust.Text == "")
                {
                    throw new Exception("Ошибка! Пустые поля!");
                }
                if (Waist.Text == "")
                {
                    throw new Exception("Ошибка! Пустые поля!");
                }
                if (Hip.Text == "")
                {
                    throw new Exception("Ошибка! Пустые поля!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            //string h = Height_.Text;
            //string b = Bust.Text;
            //string w = Waist.Text;
            //string hp = Hip.Text;

            int height = 0;
            int bust = 0;
            int waist = 0;
            int hip = 0;

            if (int.TryParse(Height_.Text, out height))
            {
                if (int.TryParse(Bust.Text, out bust))
                {
                    
                    if (int.TryParse(Waist.Text, out waist))
                    {
                        
                        if (int.TryParse(Hip.Text, out hip))
                        {

                            //Int32.Parse //Convert.ToInt32
                            //  var height = Int32.Parse(h);
                            //var bust = Int32.Parse(b);
                            //var waist = Int32.Parse(w);
                            //var hip = Int32.Parse(hp);



                            // используемые таблицы размеров https://shoponlina.com/en/clothes-size-uk/
                            //Данные могут быть некорректны!

                            if (Female.Checked == true)
                            {
                                if (bust >= 74 && bust <= 77 && waist >= 58 && waist <= 62 && hip >= 85 && hip <= 88)
                                {
                                    EU_Reuslt.Text = "";
                                    RusBel_Result.Text = "38";
                                    USA_Result.Text = "";
                                    UK_Result.Text = "";
                                }
                                if (bust >= 78 && bust <= 81 && waist >= 63 && waist <= 65 && hip >= 88 && hip <= 91)
                                {
                                    EU_Reuslt.Text = "";
                                    RusBel_Result.Text = "40";
                                    USA_Result.Text = "";
                                    UK_Result.Text = "";
                                }
                                if (bust >= 82 && bust <= 85 && waist >= 62 && waist <= 65 && hip >= 88 && hip <= 91)
                                {
                                    EU_Reuslt.Text = "34";
                                    RusBel_Result.Text = "42";
                                    USA_Result.Text = "6";
                                    UK_Result.Text = "2";
                                }
                                if (bust >= 86 && bust <= 89 && waist >= 66 && waist <= 69 && hip >= 92 && hip <= 95)
                                {
                                    EU_Reuslt.Text = "36";
                                    RusBel_Result.Text = "44";
                                    USA_Result.Text = "8";
                                    UK_Result.Text = "4";
                                }
                                if (bust >= 90 && bust <= 93 && waist >= 70 && waist <= 73 && hip >= 96 && hip <= 99)
                                {
                                    EU_Reuslt.Text = "38";
                                    RusBel_Result.Text = "46";
                                    USA_Result.Text = "10";
                                    UK_Result.Text = "6";
                                }
                                if (bust >= 94 && bust <= 97 && waist >= 74 && waist <= 77 && hip >= 100 && hip <= 103)
                                {
                                    EU_Reuslt.Text = "40";
                                    RusBel_Result.Text = "48";
                                    USA_Result.Text = "12";
                                    UK_Result.Text = "8";
                                }
                                if (bust >= 98 && bust <= 101 && waist >= 78 && waist <= 81 && hip >= 104 && hip <= 107)
                                {
                                    EU_Reuslt.Text = "42";
                                    RusBel_Result.Text = "50";
                                    USA_Result.Text = "14";
                                    UK_Result.Text = "10";
                                }
                                if (bust >= 102 && bust <= 105 && waist >= 82 && waist <= 85 && hip >= 108 && hip <= 111)
                                {
                                    EU_Reuslt.Text = "44";
                                    RusBel_Result.Text = "52";
                                    USA_Result.Text = "16";
                                    UK_Result.Text = "12";
                                }
                                if (bust >= 106 && bust <= 109 && waist >= 86 && waist <= 89 && hip >= 112 && hip <= 115)
                                {
                                    EU_Reuslt.Text = "46";
                                    RusBel_Result.Text = "54";
                                    USA_Result.Text = "18";
                                    UK_Result.Text = "14";
                                }
                                if (bust >= 110 && bust <= 113 && waist >= 90 && waist <= 93 && hip >= 116 && hip <= 119)
                                {
                                    EU_Reuslt.Text = "48";
                                    RusBel_Result.Text = "56";
                                    USA_Result.Text = "20";
                                    UK_Result.Text = "16";
                                }
                                if (bust >= 114 && bust <= 117 && waist >= 94 && waist <= 98 && hip >= 120 && hip <= 124)
                                {
                                    EU_Reuslt.Text = "50";
                                    RusBel_Result.Text = "58";
                                    USA_Result.Text = "22";
                                    UK_Result.Text = "18";
                                }
                            }



                            if (Male.Checked == true)
                            {

                                if (bust >= 90 && bust <= 93 && waist >= 73 && waist <= 78 && hip >= 95 && hip <= 98)
                                {
                                    EU_Reuslt.Text = "46";//40
                                    RusBel_Result.Text = "46";
                                    //16
                                    USA_Result.Text = "36";
                                    UK_Result.Text = "36";
                                }
                                if (bust >= 94 && bust <= 97 && waist >= 79 && waist <= 84 && hip >= 99 && hip <= 102)
                                {
                                    EU_Reuslt.Text = "48";//42
                                    RusBel_Result.Text = "48";
                                    //18
                                    USA_Result.Text = "38";
                                    UK_Result.Text = "38";
                                }
                                if (bust >= 98 && bust <= 101 && waist >= 85 && waist <= 90 && hip >= 103 && hip <= 106)
                                {
                                    EU_Reuslt.Text = "50";//44
                                    RusBel_Result.Text = "50";
                                    //20
                                    USA_Result.Text = "40";
                                    UK_Result.Text = "40";
                                }
                                if (bust >= 102 && bust <= 105 && waist >= 91 && waist <= 96 && hip >= 107 && hip <= 109)
                                {
                                    EU_Reuslt.Text = "52";//46
                                    RusBel_Result.Text = "52";
                                    //22
                                    USA_Result.Text = "42";
                                    UK_Result.Text = "42";
                                }
                                if (bust >= 106 && bust <= 109 && waist >= 97 && waist <= 102 && hip >= 110 && hip <= 113)
                                {
                                    EU_Reuslt.Text = "54";//48
                                    RusBel_Result.Text = "54";
                                    //24
                                    USA_Result.Text = "44";
                                    UK_Result.Text = "44";
                                }
                                if (bust >= 110 && bust <= 113 && waist >= 103 && waist <= 108 && hip >= 114 && hip <= 117)
                                {
                                    EU_Reuslt.Text = "56";//50
                                    RusBel_Result.Text = "56";
                                    //26
                                    USA_Result.Text = "46";
                                    UK_Result.Text = "46";
                                }
                                if (bust >= 114 && bust <= 117 && waist >= 109 && waist <= 114 && hip >= 118 && hip <= 121)
                                {
                                    EU_Reuslt.Text = "58";//52
                                    RusBel_Result.Text = "58";
                                    //28
                                    USA_Result.Text = "48";
                                    UK_Result.Text = "48";
                                }
                                if (bust >= 118 && bust <= 121 && waist >= 115 && waist <= 119 && hip >= 122 && hip <= 125)
                                {
                                    EU_Reuslt.Text = "60";//54
                                    RusBel_Result.Text = "60";
                                    //30
                                    USA_Result.Text = "50";
                                    UK_Result.Text = "50";
                                }
                            }
                        }
                    }
                }
            }

        }

    }
}

