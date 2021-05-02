using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace IndianCookbook
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            var lst = App._recipe;
            Lbx_ImgList.ItemsSource = lst;
            Lbx_ImgList1.ItemsSource = lst;
            Lbx_NvImgList.ItemsSource = lst;
            Lbx_Recipe.ItemsSource = App._recipe;
            Lbx_Recipe_Veg.ItemsSource = App._recipe;
            Lbx_Recipe_NonVeg.ItemsSource = App._recipe;
        }

        private ObservableCollection<Recipes> CreateRecipeList(int cnt)
        {
            var recList = new ObservableCollection<Recipes>();
            for (int i = 0; i < cnt; i++)
            {
                recList.Add(new Recipes { recipeTitle = $"recipeTitle{i}"});
            }
            return recList;
        }

        private void Tbx_Filter_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (App._recipe == null) return;
            var filter = (sender as TextBox).Text;
            var result = from s in App._recipe where s.recipeTitle.ToLower().Contains(filter) select s;
            Lbx_Recipe.ItemsSource = result;
        }


        private void Lbx_Recipe_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedRecipe = (Recipes)Lbx_Recipe.SelectedItem;
            var window = new Recipe_Instructions();
            window.Txt_Recipe_Title.Text = selectedRecipe.recipeTitle;
            window.Txt_Difficulty.Text = selectedRecipe.difficultyLevel;
            window.Txt_Duration.Text = selectedRecipe.cookingTime;
            window.Txt_Ideal_For.Text = selectedRecipe.idealFor;
            window.Txt_Servings.Text = selectedRecipe.servings;
            window.Txt_Ingredients.Text = selectedRecipe.ingredient;
            window.Txt_Method.Text = selectedRecipe.method;
            window.Img_Recipe.Source = new BitmapImage(new Uri("/Images/" + selectedRecipe.image + ".jpg", UriKind.RelativeOrAbsolute));


            window.Width = Width;
            window.Height = Height;
            window.Title = "Recipe Instructions";
            window.Owner = this;
            window.Show();

            Visibility = Visibility.Collapsed;
        }

        private void Cbx_SubCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            if (App._recipe == null) return;
            var filter = Cbx_SubCategory.Items.GetItemAt(Cbx_SubCategory.SelectedIndex).ToString().ToLower();
            var result = from c in App._recipe where c.subCategory.ToLower().Contains(filter) select c;

            Lbx_Recipe.ItemsSource = result;
            Lbx_ImgList1.ItemsSource = result;

        }

        private void Tabs1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Tbx_Filter_Veg_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (App._recipe == null) return;
            var filter = (sender as TextBox).Text;
            var result = from s in App._recipe where s.recipeTitle.ToLower().Contains(filter) select s;
            Lbx_Recipe_Veg.ItemsSource = result;
        }

        private void Lbx_Recipe_Veg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedRecipe = (Recipes)Lbx_Recipe_Veg.SelectedItem;
            var win = new Recipe_Instructions();
            win.Txt_Recipe_Title.Text = selectedRecipe.recipeTitle;
            win.Txt_Difficulty.Text = selectedRecipe.difficultyLevel;
            win.Txt_Duration.Text = selectedRecipe.cookingTime;
            win.Txt_Ideal_For.Text = selectedRecipe.idealFor;
            win.Txt_Servings.Text = selectedRecipe.servings;
            win.Txt_Ingredients.Text = selectedRecipe.ingredient;
            win.Txt_Method.Text = selectedRecipe.method;
            win.Img_Recipe.Source = new BitmapImage(new Uri("/Images/" + selectedRecipe.image + ".jpg", UriKind.RelativeOrAbsolute));




            win.Width = Width;
            win.Height = Height;
            win.Title = "Recipe Instructions";
            win.Owner = this;
            win.Show();
            Visibility = Visibility.Collapsed;

        }

        private void Cbx_SubCategory_Veg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            TabItem ti = Tabs1.SelectedItem as TabItem;
            var tabHeader = ti.Header.ToString().ToLower();
            if (App._recipe == null) return;
            var filter = Cbx_SubCategory_Veg.Items.GetItemAt(Cbx_SubCategory_Veg.SelectedIndex).ToString().ToLower();
            var result = from c in App._recipe where c.subCategory.ToLower().Contains(filter) && c.category.ToLower().Contains(tabHeader) select c;
            Lbx_Recipe_Veg.ItemsSource = result;
            Lbx_ImgList.ItemsSource = result;

        }



        private void Btn_pani_puri_Click(object sender, RoutedEventArgs e)
        {
            var win = new Recipe_Instructions();
            win.Width = Width;
            win.Height = Height;
            win.Title = "Recipe Instructions";
            win.Owner = this;
            win.Show();

            Visibility = Visibility.Collapsed;
        }

        private void Lbx_ImgList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedRecipe = (Recipes)Lbx_ImgList.SelectedItem;
            var win = new Recipe_Instructions();
            win.Txt_Recipe_Title.Text = selectedRecipe.recipeTitle;
            win.Txt_Difficulty.Text = selectedRecipe.difficultyLevel;
            win.Txt_Duration.Text = selectedRecipe.cookingTime;
            win.Txt_Ideal_For.Text = selectedRecipe.idealFor;
            win.Txt_Servings.Text = selectedRecipe.servings;
            win.Txt_Ingredients.Text = selectedRecipe.ingredient;
            win.Txt_Method.Text = selectedRecipe.method;
            win.Img_Recipe.Source = new BitmapImage(new Uri("/Images/" + selectedRecipe.image + ".jpg", UriKind.RelativeOrAbsolute));




            win.Width = Width;
            win.Height = Height;
            win.Title = "Recipe Instructions";
            win.Owner = this;
            win.Show();
            Visibility = Visibility.Collapsed;
        }

        

        private void Lbx_ImgList1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedRecipe = (Recipes)Lbx_ImgList1.SelectedItem;
            var win = new Recipe_Instructions();
            win.Txt_Recipe_Title.Text = selectedRecipe.recipeTitle;
            win.Txt_Difficulty.Text = selectedRecipe.difficultyLevel;
            win.Txt_Duration.Text = selectedRecipe.cookingTime;
            win.Txt_Ideal_For.Text = selectedRecipe.idealFor;
            win.Txt_Servings.Text = selectedRecipe.servings;
            win.Txt_Ingredients.Text = selectedRecipe.ingredient;
            win.Txt_Method.Text = selectedRecipe.method;
            win.Img_Recipe.Source = new BitmapImage(new Uri("/Images/" + selectedRecipe.image + ".jpg", UriKind.RelativeOrAbsolute));




            win.Width = Width;
            win.Height = Height;
            win.Title = "Recipe Instructions";
            win.Owner = this;
            win.Show();
            Visibility = Visibility.Collapsed;
        }

        private void Tbx_Filter_NonVeg_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (App._recipe == null) return;
            var filter = (sender as TextBox).Text;
            var result = from s in App._recipe where s.recipeTitle.ToLower().Contains(filter) select s;
            Lbx_Recipe_NonVeg.ItemsSource = result;

        }

        private void Lbx_Recipe_NonVeg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedRecipe = (Recipes)Lbx_Recipe_NonVeg.SelectedItem;
            var win = new Recipe_Instructions();
            win.Txt_Recipe_Title.Text = selectedRecipe.recipeTitle;
            win.Txt_Difficulty.Text = selectedRecipe.difficultyLevel;
            win.Txt_Duration.Text = selectedRecipe.cookingTime;
            win.Txt_Ideal_For.Text = selectedRecipe.idealFor;
            win.Txt_Servings.Text = selectedRecipe.servings;
            win.Txt_Ingredients.Text = selectedRecipe.ingredient;
            win.Txt_Method.Text = selectedRecipe.method;
            win.Img_Recipe.Source = new BitmapImage(new Uri("/Images/" + selectedRecipe.image + ".jpg", UriKind.RelativeOrAbsolute));




            win.Width = Width;
            win.Height = Height;
            win.Title = "Recipe Instructions";
            win.Owner = this;
            win.Show();
            Visibility = Visibility.Collapsed;
        }

        private void Lbx_NvImgList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedRecipe = (Recipes)Lbx_NvImgList.SelectedItem;
            var win = new Recipe_Instructions();
            win.Txt_Recipe_Title.Text = selectedRecipe.recipeTitle;
            win.Txt_Difficulty.Text = selectedRecipe.difficultyLevel;
            win.Txt_Duration.Text = selectedRecipe.cookingTime;
            win.Txt_Ideal_For.Text = selectedRecipe.idealFor;
            win.Txt_Servings.Text = selectedRecipe.servings;
            win.Txt_Ingredients.Text = selectedRecipe.ingredient;
            win.Txt_Method.Text = selectedRecipe.method;
            win.Img_Recipe.Source = new BitmapImage(new Uri("/Images/" + selectedRecipe.image + ".jpg", UriKind.RelativeOrAbsolute));




            win.Width = Width;
            win.Height = Height;
            win.Title = "Recipe Instructions";
            win.Owner = this;
            win.Show();
            Visibility = Visibility.Collapsed;
        }

        private void Cbx_SubCategory_NonVeg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TabItem ti = Tabs1.SelectedItem as TabItem;
            var tabHeader = ti.Header.ToString().ToLower();
            if (App._recipe == null) return;
            var filter = Cbx_SubCategory_NonVeg.Items.GetItemAt(Cbx_SubCategory_NonVeg.SelectedIndex).ToString().ToLower();
            var result = from c in App._recipe where c.subCategory.ToLower().Contains(filter) && c.category.ToLower().Contains(tabHeader) select c;
            Lbx_Recipe_NonVeg.ItemsSource = result;
            Lbx_NvImgList.ItemsSource = result;
        }
    }
}
