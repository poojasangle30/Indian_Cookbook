using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace IndianCookbook
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static ObservableCollection<Recipes> _recipe;



        public void Application_Startup(object sender, StartupEventArgs e)
        {

            _recipe = My_Storage.ReadXml<ObservableCollection<Recipes>>("Recipe.xml");
            if (_recipe == null)
                _recipe = new ObservableCollection<Recipes>();
        }



        private void Application_Exit(object sender, ExitEventArgs e)
        {
            //var recipes = new ObservableCollection<Recipes> { new Recipes { id = 0, recipeTitle = "a", subCategory= "pvs" , category = "abc" , image = "abc" , difficultyLevel = "abc" , cookingTime = "abc" , idealFor = "abc" , servings = "abc" , ingredient = "abc" , method = "abc" , },
            //                                                new Recipes { id = 0, recipeTitle = "a", subCategory = "pvs" , category = "abc", image = "abc" , difficultyLevel = "abc" , cookingTime = "abc" , idealFor = "abc" , servings = "abc" , ingredient = "abc" , method = "abc" , },
            //                                                new Recipes { id = 0, recipeTitle = "a", subCategory= "pvs" , category = "abc", image = "abc" , difficultyLevel = "abc" , cookingTime = "abc" , idealFor = "abc" , servings = "abc" , ingredient = "abc" , method = "abc" , }, };
            My_Storage.WriteXml(App._recipe, "Recipe.xml");



        }
    }
}
