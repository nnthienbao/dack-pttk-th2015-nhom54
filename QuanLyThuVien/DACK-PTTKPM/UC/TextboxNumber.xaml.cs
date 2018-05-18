using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace DACK_PTTKPM.UC
{
    /// <summary>
    /// Interaction logic for TextboxNumber.xaml
    /// </summary>
    public partial class TextboxNumber : UserControl
    {
        public TextboxNumber()
        {
            InitializeComponent();
        }

        public int Number
        {
            get
            {
                int num;
                int.TryParse(tb_TextBox.Text, out num);
                return num;
            }
            set
            {
                tb_TextBox.Text = value + "";
            }
        }

        private void tb_TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9.-]+"); //regex that matches disallowed text
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
