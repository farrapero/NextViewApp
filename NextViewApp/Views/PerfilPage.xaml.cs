using NextViewApp.Models;

namespace NextViewApp.Views
{
    public partial class PerfilPage : ContentPage
    {
        public Usuario Usuario { get; set; }

        public PerfilPage()
        {
            InitializeComponent();
            Usuario = new Usuario
            {
                Nome = "João da Silva",
                Email = "joao.silva@exemplo.com"
            };
            BindingContext = this;
        }

        private void OnEditarPerfilClicked(object sender, EventArgs e)
        {
            DisplayAlert("Editar Perfil", "Funcionalidade de edição de perfil simulada.", "OK");
        }

        private void OnAnaliseMetricasClicked(object sender, EventArgs e)
        {
            DisplayAlert("Análise de Métricas", "Funcionalidade de análise de métricas simulada.", "OK");
        }

        private void OnSairClicked(object sender, EventArgs e)
        {
            DisplayAlert("Sair", "Você saiu da sua conta.", "OK");
            // Implementar lógica de logout se necessário
        }
    }
}
