using System.Windows;
using System.Windows.Media;

namespace ProfessionalEx4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SaveFile saveFile;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            saveFile = new SaveFile();
            ColorPicker.SelectedColor = saveFile.ReadSet();
            ColorPicker.IsOpen = true;
            ColorPicker.ShowDropDownButton = true;
        }

        private void ColorPicker_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            label1.Background = new SolidColorBrush((Color)ColorPicker.SelectedColor);
            label1.Content = ColorPicker.SelectedColorText;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            saveFile.SaveSet((Color)ColorPicker.SelectedColor);
        }
    }
}
