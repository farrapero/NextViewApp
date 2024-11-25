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
                Nome = "Jo�o da Silva",
                Email = "joao.silva@exemplo.com"
            };
            BindingContext = this;
        }

        private void OnEditarPerfilClicked(object sender, EventArgs e)
        {
            DisplayAlert("Editar Perfil", "Funcionalidade de edi��o de perfil simulada.", "OK");
        }

        private void OnAnaliseMetricasClicked(object sender, EventArgs e)
        {
            DisplayAlert("An�lise de M�tricas", "Funcionalidade de an�lise de m�tricas simulada.", "OK");
        }

        private void OnSairClicked(object sender, EventArgs e)
        {
            DisplayAlert("Sair", "Voc� saiu da sua conta.", "OK");
            // Implementar l�gica de logout se necess�rio
        }
    }
}
