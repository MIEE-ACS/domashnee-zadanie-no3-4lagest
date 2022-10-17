using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Globalization;

namespace HomeWork3_Zakshevskij_UTS_22
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public string Vigen(string a)
        {
            
            return a;
        }
        private void Bt_Click(object sender, RoutedEventArgs e)
        {
            int c = 0;
            char[] alph = new char[] { 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З', 'И',
                                                'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С',
                                                'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ь', 'Ы', 'Ъ',
                                                'Э', 'Ю', 'Я'};
            char[] alph1 = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J',
                                                'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S',
                                                'T', 'U', 'V', 'W', 'X', 'Y', 'Z'};
            int P = alph.Length;
            int N = alph1.Length;
            string a = Convert.ToString(Tb.Text);
            a = a.ToUpper();
            string key = Convert.ToString(Tb_2.Text);
            key = key.ToUpper();
            string result = "";
            bool o = true;
            foreach (char d in key)
            {
                if (Char.IsWhiteSpace(d))
                {
                    MessageBox.Show("Введите ключ без пробелов");
                    o = false;
                    break;
                }    
                if (Char.IsPunctuation(d))
                {
                    MessageBox.Show("Введите ключ без знаков препинания");
                    o = false;
                    break;
                }
            }
            if (string.IsNullOrEmpty(a))
            {
                MessageBox.Show("Введите текст для шифрования в поле");
            }
            else if (string.IsNullOrEmpty(key))
            {
                MessageBox.Show("Введите ключ в поле");
                
            }
            else if (o == true)
            {
                int h = 0;
                int m = a.Length;
                while (a.Length != key.Length)
                {
                    if (key.Length > h)
                    {
                        key = key + key[h];
                        h++;
                    }
                    else
                    {
                        h = 0;
                        key = key + key[h];
                        h++;
                    }
                }

                int key_step = 0;
                int operation = Cb.SelectedIndex;
                switch (operation)
                {
                    case 0:
                        foreach (char s in a)
                        {
                            if (Char.IsWhiteSpace(s))
                            {
                                result += s;
                            }
                            if (Char.IsPunctuation(s))
                            {
                                result += s;
                            }
                            else if (alph.Contains(s))
                            {
                                c = (Array.IndexOf(alph, s) + Array.IndexOf(alph, key[key_step])) % P;
                                result += alph[c];
                                key_step++;
                            }
                            else if (alph1.Contains(s))
                            {
                                c = (Array.IndexOf(alph1, s) + Array.IndexOf(alph1, key[key_step]))% N;
                                result += alph1[c];
                                key_step++;
                            }
                        }
                        break;
                    case 1:
                        foreach (char s in a)
                        {
                            if (Char.IsWhiteSpace(s))
                            {
                                result += s;
                            }
                            if (Char.IsPunctuation(s))
                            {
                                result += s;
                            }
                            else if (alph.Contains(s))
                            {
                                c = (Array.IndexOf(alph, s) + P - Array.IndexOf(alph, key[key_step])) % P;
                                result += alph[c];
                                key_step++;
                            }
                            else if (alph1.Contains(s))
                            {
                                c = (Array.IndexOf(alph1, s) + N - Array.IndexOf(alph1, key[key_step])) % N;
                                result += alph1[c];
                                key_step++;
                            }
                        }
                        break;
                }
                Tb_3.Text = String.Format("{0}", result);
            }
        }
        private void Tb_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void Tb_2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void Tb_3_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Cb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
