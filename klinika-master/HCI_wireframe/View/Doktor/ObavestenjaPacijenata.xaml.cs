﻿using System;
using System.Collections.Generic;
using System.IO;
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
using Class_diagram.Model.Patient;
using Class_diagram.Repository;
using HCI_wireframe;
using HCI_wireframe.Model.Doctor;
using Path = System.IO.Path;

namespace Klinika
{
    /// <summary>
    /// Interaction logic for ObavestenjaPacijenata.xaml
    /// </summary>
    public partial class ObavestenjaPacijenata : UserControl
    {
        
        public DoctorUser lekar { get; set; }
        List<Question> pitanja = new List<Question>();
        string svojstvo = App.Current.Properties["DoctorEmail"].ToString();
       public List<int> idSvihpacijenta { get; set; }
        public List<PatientUser> lista { get; set; }
        public PatientController cont;
        public ObavestenjaPacijenata()
        {
            InitializeComponent();

            lekar = new DoctorUser();
             cont= new PatientController();
             lista = new List<PatientUser>();
            lista = cont.GetAll();
            Question q = new Question();
           
            DoctorController doctorController = new DoctorController();
            List<DoctorUser> listaDoktora = doctorController.GetAll();
            foreach (DoctorUser s in listaDoktora)
            {
                if (s.Email.Equals(svojstvo))
                {
                    lekar = s;

                }
            }

         
            if (pitanja == null)
            {
                pitanja = new List<Question>();
            }
            List<String> mojaObavestenja = lekar.specialNotifications;


            idSvihpacijenta = new List<int>();
            foreach(PatientUser pacijent in lista )
            {
                idSvihpacijenta.Add(pacijent.ID);
            }


            Obavestenja.ItemsSource = mojaObavestenja;
            pacijentId.ItemsSource = idSvihpacijenta;




        }
        



        private void isporuci_Click(object sender, RoutedEventArgs e)
        {
            String idPacijent = sender.ToString();
            int idPacijentInt = (int)pacijentId.SelectedValue;
            Console.WriteLine(idPacijentInt);
            if (odg.Text.Equals("") || idPacijent.Equals(""))
            {

                MessageBox.Show("Popunite sva polja!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                return;
            }
            
           // int idPacijentInt = int.Parse(idPacijent);
            PatientUser izabranPacijent = new PatientUser();
            foreach (PatientUser pacijent in lista)
            {
                if(pacijent.ID==idPacijentInt)
                {
                    izabranPacijent = pacijent;
                }
            }
            if(izabranPacijent.Notifications==null)
            {
                izabranPacijent.Notifications = new List<string>();
            }
            List<String> pacijentObavestenja = izabranPacijent.Notifications;

            pacijentObavestenja.Add("Doctor  " + lekar.FirstName + " " + lekar.SecondName + "  - answer  -" +odg.Text);
            izabranPacijent.Notifications = pacijentObavestenja;
            cont.Update(izabranPacijent);
            






        }
    }
}
