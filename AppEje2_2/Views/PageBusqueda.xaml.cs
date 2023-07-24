using AppEje2_2.Controllers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppEje2_2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageBusqueda : ContentPage
    {
        private List<Post> allPosts;
        private ObservableCollection<Post> filteredPosts;
        public PageBusqueda(List<Post> posts)
        {
            InitializeComponent();
            allPosts = posts;
            filteredPosts = new ObservableCollection<Post>(allPosts);
            listado.ItemsSource = filteredPosts;
        }

        private void SearchButtonPressed(object sender, EventArgs e)
        {
            string searchTerm = searchBar.Text;
            FilterPosts(searchTerm);
        }

        private void FilterPosts(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                filteredPosts = new ObservableCollection<Post>(allPosts);
            }
            else
            {
                filteredPosts = new ObservableCollection<Post>(
                    allPosts.Where(post =>
                        post.Title.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0 ||
                        post.Body.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0
                    ).ToList()
                );
            }

            listado.ItemsSource = filteredPosts;
        }
    }
}