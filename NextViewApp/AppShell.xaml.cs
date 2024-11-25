using Microsoft.Maui.Controls;
using NextViewApp.Views;

namespace NextViewApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            // Registro de rotas para itens do topo
            Routing.RegisterRoute(nameof(BuscarPage), typeof(BuscarPage));
            Routing.RegisterRoute(nameof(VideosPage), typeof(VideosPage));
            Routing.RegisterRoute(nameof(MusicasPage), typeof(MusicasPage));
            Routing.RegisterRoute(nameof(PodcastPage), typeof(PodcastPage));

            // Registro de rotas para itens da parte inferior
            Routing.RegisterRoute("VideosBottom", typeof(VideosPage));
            Routing.RegisterRoute("FastViewsBottom", typeof(FastViewsPage));
            Routing.RegisterRoute("PlaylistsBottom", typeof(PlaylistsPage));
            Routing.RegisterRoute("PerfilBottom", typeof(PerfilPage));
        }
    }
}
