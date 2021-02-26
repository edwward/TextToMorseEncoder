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

namespace TextToMorseConverter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.FontFamily = new FontFamily("Roboto");
            this.FontSize = 15;
            writeText.Focus();
        }

        TextToMorse txtMor = new TextToMorse();
        StringBuilder sb = new StringBuilder();
        
        private void convert_Click(object sender, RoutedEventArgs e)
        {
            string txt = writeText.Text.ToUpper();
            for (int i = 0; i < txt.Length; i++)
            {
                if (i > 0)
                {
                    sb.Append('/');
                }

                char c = txt[i];
                if (txtMor.GetMorseForText().ContainsKey(c))
                {
                    sb.Append(txtMor.GetMorseForText()[c]);
                }
            }
            output.Text = sb.ToString();
            writeText.Text = string.Empty;
        }

        private void clear_Click(object sender, RoutedEventArgs e)
        {
            writeText.Text = string.Empty;
            output.Text = string.Empty;
            sb.Clear();
        }
    }
}
