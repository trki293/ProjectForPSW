﻿using System;
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
using Class_diagram.Contoller;
using Class_diagram.Model.Secretary;
using HCI_wireframe;

namespace ProjekatHCI
{
    /// <summary>
    /// Interaction logic for MojiPodaci.xaml
    /// </summary>
    public partial class MojiPodaci : UserControl
    {
        string myProperty = App.Current.Properties["SecretaryEmail"].ToString();
        public SecretaryUser sekretar { get; set; }
        public MojiPodaci()
        {

            InitializeComponent();
            this.DataContext = this;
            sekretar = new SecretaryUser();
            SecretaryController scon = new SecretaryController();
            List<SecretaryUser> lista = scon.GetAll();

            foreach (SecretaryUser s in lista)
            {
                if (s.Email.Equals(myProperty))
                {
                    sekretar = s;
                    ImeBox.Text = sekretar.FirstName.ToString();
                    PrezimeBox.Text = sekretar.SecondName.ToString();
                    DatumRodjBox.Text = sekretar.DateOfBirth.ToString();
                    JMBGBox.Text = sekretar.UniqueCitizensIdentityNumber.ToString();
                    if (sekretar.city.ToString() != null)
                    {
                        AdresaBox.Text = sekretar.city.ToString();
                    }
                    else
                    {
                        AdresaBox.Text = "";
                    }
                    EmailBox.Text = sekretar.Email.ToString();
                    LozinkaBox.Text = sekretar.Password;
                    BrTelBox.Text = sekretar.PhoneNumber.ToString();
                }



            }
        }
        public void Izmeni_click(object sender, RoutedEventArgs e)
        {
            Panel.Children.Clear();
            UserControl usc = new IzmenaPodataka();
            Panel.Children.Add(usc);
        }


    }
}
