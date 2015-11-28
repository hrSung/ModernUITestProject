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
                //Path 변수에 선택된 폴더의 경로를 집어넣는다.
            }
        }

        private void OnClickFindBtn2(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.OpenFileDialog ofd = new System.Windows.Forms.OpenFileDialog();
            ofd.Filter = "Text Files(*.txt)|*.txt|All Files(*.*)|*.*";

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox2.Text = ofd.SafeFileName;
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
