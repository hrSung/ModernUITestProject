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

namespace ModernUITestProject.Pages
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : UserControl
    {
        public Home()
        {
            InitializeComponent();
        }

        private void OnClickFindBtn1(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog fbd = new System.Windows.Forms.FolderBrowserDialog();
            // FolderBrowserDialog 생성

            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //대화상자(Dialog)를 띄운후 대화상자의 응답이 확인이라면,
            {
                textBox1.Text = fbd.SelectedPath;
            }
        }

        private void OnClickFindBtn2(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.OpenFileDialog ofd = new System.Windows.Forms.OpenFileDialog();
            ofd.Filter = "Text Files(*.txt)|*.txt|All Files(*.*)|*.*";

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox2.Text = ofd.SafeFileName;

                try
                {
                    System.IO.StreamReader sr = new System.IO.StreamReader(ofd.OpenFile());
                    string content = sr.ReadToEnd();
                    sr.Close();

                    selectTextBeforeValue.Text = content;
                    content = System.Text.RegularExpressions.Regex.Replace(content, "a", "QQQ");

                    System.IO.StreamWriter writer = new System.IO.StreamWriter(ofd.FileName);
                    writer.Write(content);
                    writer.Close();

                    sr = new System.IO.StreamReader(ofd.OpenFile());
                    content = sr.ReadToEnd();
                    sr.Close();

                    selectTextAfterValue.Text = content;
                }
                catch(Exception ex)
                {
                    Console.WriteLine("=-=-=-=Exception : " + ex);
                }
            }
        }

        private void OnClickFindBtn3(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.OpenFileDialog ofd = new System.Windows.Forms.OpenFileDialog();
            ofd.Multiselect = true;
            ofd.Filter = "Text Files(*.txt)|*.txt|All Files(*.*)|*.*";

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                StringBuilder sb = new StringBuilder();
                string[] arrStr = ofd.SafeFileNames;

                for (int i = 0; i < arrStr.Length; i++)
                {
                    sb.Append(arrStr[i]);
                    if (i < arrStr.Length - 1)
                    {
                        sb.Append(", ");
                    }
                }

                textBox3.Text = sb.ToString();
            }
        }
    }
}
