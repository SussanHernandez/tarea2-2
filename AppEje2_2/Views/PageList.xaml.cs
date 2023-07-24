using AppEje2_2.Controllers;
using AppEje2_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppEje2_2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageList : ContentPage
    {
        private List<Post> Posts { get; set; }
        private WebService _webService;
        public PageList()
        {
            InitializeComponent();
            _webService = new WebService();
            LoadPosts();
        }
        private async void LoadPosts()
        {
            Posts = await _webService.GetAllPostsAsync();
            listado.ItemsSource = Posts;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PageBusqueda(Posts));
        }
    }
}