using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ypc
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        readonly string[] SUITS = new[] { "Pikes", "Clubs", "Tiles", "Hearts" };
        readonly string[] CARDS = new[] { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
        public HomePage()
        {
            InitializeComponent(); 
            Loaded += MainWindow_Loaded;
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            for (var i = 0; i < SUITS.Length; i++)
            {
                _grid.RowDefinitions.Add(new RowDefinition
                {
                    Height = new GridLength(1, GridUnitType.Star)
                });
            }
            for (var j = 0; j < CARDS.Length; j++)
            {
                _grid.ColumnDefinitions.Add(new ColumnDefinition
                {
                    Width = new GridLength(1, GridUnitType.Star)
                });
            }
            for (var i = 0; i < SUITS.Length; i++)
            {
                for (var j = 0; j < CARDS.Length; j++)
                {
                    var cardPath = @"\Cards\" + SUITS[i] + @"\" + CARDS[j] + "_" + SUITS[i] + ".xaml";
                    using (var fileStream = File.OpenRead(path + cardPath))
                    {
                        var aa = (UIElement)XamlReader.Load(fileStream);

                        Grid.SetRow(aa, i);
                        Grid.SetColumn(aa, j);
                        _grid.Children.Add(aa);
                    }
                }
            }

        }

        private void KlondikeButton_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("Klondike/KlondikePage.xaml", UriKind.Relative);

            // Get the navigation service that was used to
            // navigate to this page, and navigate to
            // AnotherPage.xaml
            this.NavigationService.Navigate(uri);
        }
    }
}
