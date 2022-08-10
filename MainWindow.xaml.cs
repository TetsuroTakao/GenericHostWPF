using System;
using System.Collections.Generic;
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
using Microsoft.Extensions.Configuration;

namespace GenericHostWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewModel dataContext = new ();
        private ApplicationContext applicationContext = new();
        private IConfiguration configRoot;
        public MainWindow(IConfiguration config)
        {
            configRoot = config;
            InitializeComponent();
            config.GetSection(ApplicationContext.Japanese).Bind(applicationContext);
            dataContext = (MainWindowViewModel)this.DataContext;
            dataContext.Message = applicationContext.Brand;
            dataContext.Log = applicationContext.Pages.First().Title;
        }
    }
}
