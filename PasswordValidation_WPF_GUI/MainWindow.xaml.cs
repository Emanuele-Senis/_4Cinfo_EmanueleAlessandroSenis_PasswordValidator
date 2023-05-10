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
using PasswordValidation_Lib;

namespace PasswordValidation_WPF_GUI
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private PasswordValidator _validator;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Txt_password_TextChanged(object sender, TextChangedEventArgs e)
        {
            _validator = new PasswordValidator(txt_password.Text);
            _validator.OnPasswordValidated += Validator_OnPasswordValidated;
            _validator.OnPasswordInvalid += Validator_OnPasswordInvalid;
            _validator.Validate();
        }

        private void Validator_OnPasswordInvalid()
        {
            lstBx_warnings.Items.Clear();
            lstBx_warnings.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F24333")); // red colour
            foreach (string warning in _validator.WarningsList)
            {
                lstBx_warnings.Items.Add(warning);
            }
        }

        private void Validator_OnPasswordValidated()
        {
            lstBx_warnings.Items.Clear();
            lstBx_warnings.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4DAA57")); // green colour
            lstBx_warnings.Items.Add("the password is valid");
        }
    }
}
