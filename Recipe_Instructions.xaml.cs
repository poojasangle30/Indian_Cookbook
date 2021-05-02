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
using System.Windows.Shapes;

namespace IndianCookbook
{
    /// <summary>
    /// Interaction logic for Recipe_Instructions.xaml
    /// </summary>
    public partial class Recipe_Instructions : Window
    {
        public Recipe_Instructions()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //var selectedRecipe = ((MainWindow)Application.Current.MainWindow).Lbx_Recipe.SelectedItem.ToString();
            //MessageBox.Show(selectedRecipe);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Btn_GoBack_Click(object sender, RoutedEventArgs e)
        {
            var win = new MainWindow();
            win.Width = Width;
            win.Height = Height;
            win.Title = "Recipe Instructions";
            win.Owner = this;
            win.Show();
            Visibility = Visibility.Collapsed;
        }
    }
}
