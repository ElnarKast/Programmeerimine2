using KooliProjekt.WpfApp.Api;
using System.Windows;

namespace KooliProjekt.WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Loaded += MainWindow_Loaded;

        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var viewModel = new MainWindowViewModel(new ApiClient());


            // Устанавливаем обработку ошибок
            viewModel.OnError = error =>
            {
                MessageBox.Show(
                    error,
                    "Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                );
            };

            viewModel.ConfirmDelete = list =>
            {
                var result = MessageBox.Show(
                "Are you sure you want to delete selected item?",
                 "Delete list",
                 MessageBoxButton.YesNo,
                 MessageBoxImage.Warning
             );
                return result == MessageBoxResult.Yes;
            };

            DataContext = viewModel;

            await viewModel.Load();
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}