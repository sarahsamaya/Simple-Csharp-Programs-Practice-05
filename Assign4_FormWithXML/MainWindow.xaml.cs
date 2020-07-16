using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using System.Xml.Serialization;

namespace Assign4_FormWithXML
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DogList doglist;
        
        public MainWindow()
        {
            InitializeComponent();


            doglist = new DogList();
            doglist.Dogs = new List<Dog>();

            lbNameError.Visibility = Visibility.Hidden;
            lbOwnerError.Visibility = Visibility.Hidden;
            lbPhoneError.Visibility = Visibility.Hidden;
            lbAgeError.Visibility = Visibility.Hidden;

            tbDogs.Inlines.Add(new Bold(new Run("Dog List")));

            ReadFromXML();

        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            //DogList doglist = new DogList();
            //doglist.Dogs = new List<Dog>();

            Dog d1 = new Dog();
            d1.DogName = txtName.Text;
            d1.DogOwnerName = txtOwner.Text;
            d1.DogOwnerPhone = txtPhone.Text;
            d1.DogAge = int.Parse(txtAge.Text);
            doglist.Dogs.Add(d1);

            if (!doglist.Equals(null))
            {
                WriteToXML(doglist);

                bool result = SearchFromXML(d1.DogName);
                if (result) { 
                MessageBox.Show("Dog " + d1.DogName + " saved with sucess!");
                
                ReadFromXML();
                
                ClearForm();
               }
            }


        }
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            ClearForm();
        }
        private void ReadFromXML()
        {
            //DogList dogList = new DogList();

            string path = "Dogs.xml";

            XmlSerializer serializer = new XmlSerializer(typeof(DogList));
            
            StreamReader reader = new StreamReader(path);

            doglist = (DogList)serializer.Deserialize(reader);
            

            reader.Close();


            /*dogList.Dogs.Sort(delegate (Dog x, Dog y)
             {
                 if (x.DogName == null && y.DogName == null) return 0;
                 else if (x.DogName == null) return -1;
                 else if (y.DogName == null) return 1;
                 else return x.DogName.CompareTo(y.DogName);
             });*/

            tbDogs.Text = "";
            doglist.Dogs = doglist.Dogs.OrderBy(o => o.DogName).ToList();

            foreach (Dog d in doglist.Dogs)
            {

             tbDogs.Inlines.Add(new LineBreak());

                tbDogs.Inlines.Add("Dog name: " + d.DogName +
                      " - " +
                      "Owner: " + d.DogOwnerName +
                      " - " +
                      "Phone: " + d.DogOwnerPhone +
                        " - " +
                     "Age: "  + d.DogAge);
            }

        }
        private bool SearchFromXML(string petName)
            {

                DogList dogList = null;
                bool result = false;

                string path = "Dogs.xml";

                XmlSerializer serializer = new XmlSerializer(typeof(DogList));

                StreamReader reader = new StreamReader(path);

                dogList = (DogList)serializer.Deserialize(reader);
           
             
                foreach (Dog d in dogList.Dogs)
                {

                    if (d.DogName.Equals(petName)){
                        result = true;
                    }
                }
                    
                reader.Close();

                return result;
        }
        private static void WriteToXML(DogList doglist)
        {
            string path = "Dogs.xml";

            XmlSerializer serializer = new XmlSerializer(typeof(DogList));

            TextWriter writer = new StreamWriter(path);
            serializer.Serialize(writer, doglist);
            writer.Close();

        }
        private void txtName_TextChanged(object sender, TextChangedEventArgs e)
       {
           
             int myTry=0;

             if(int.TryParse(txtName.Text, out myTry))
             {
                 lbNameError.Visibility = Visibility.Visible;
                 lbNameError.Content = "Invalid Name";
             }else if(txtName.Text.Length > 20)
             {
                 lbNameError.Visibility = Visibility.Visible;
                 lbNameError.Content = "maximum 20 characters";
             }
             else
             {
                 lbNameError.Content="";
                 lbNameError.Visibility = Visibility.Hidden;

             }

        }
        private void txtOwner_TextChanged2(object sender, TextChangedEventArgs e)
        {
            int myTry=0;

            if (int.TryParse(txtOwner.Text, out myTry))
            {
                lbOwnerError.Visibility = Visibility.Visible;
                lbOwnerError.Content = "Invalid Name";
            }
            else if (txtOwner.Text.Length > 20)
            {
                lbOwnerError.Visibility = Visibility.Visible;
                lbOwnerError.Content = "maximum 20 characters";
            }
            else
            {
                lbOwnerError.Content = "";
                lbOwnerError.Visibility = Visibility.Hidden;

            }
        }
        private void txtPhone_TextChanged3(object sender, TextChangedEventArgs e)
        {
            int myTry;
            if (!int.TryParse(txtPhone.Text, out myTry))
            {
                lbPhoneError.Visibility = Visibility.Visible;
                lbPhoneError.Content = "Invalid Number";
            }
            else if ((myTry.ToString().Length> 10))
            {
                lbPhoneError.Visibility = Visibility.Visible;
                lbPhoneError.Content = "Invalid Number";
            }
            else
            {
                lbPhoneError.Content = "";
                lbPhoneError.Visibility = Visibility.Hidden;
            }
                                  
        }
        private void txtAge_TextChanged4(object sender, TextChangedEventArgs e)
        {
            int myTry=0;
            if (!int.TryParse(txtAge.Text, out myTry))
            {
                lbAgeError.Visibility = Visibility.Visible;
                lbAgeError.Content = "Invalid age";
            }
            else if (myTry < 0 || myTry > 30)
            {
                lbAgeError.Visibility = Visibility.Visible;
                lbAgeError.Content = "Invalid age";
            }
            else
            {
                lbAgeError.Content = "";
                lbAgeError.Visibility = Visibility.Hidden;
            }
        }
        private void ClearForm()
        {
            txtName.Clear();
            txtOwner.Clear();
            txtPhone.Clear();
            txtAge.Clear();

            lbNameError.Content = "";
            lbOwnerError.Content = "";
            lbPhoneError.Content = "";
            lbAgeError.Content = "";

            lbNameError.Visibility = Visibility.Hidden;
            lbOwnerError.Visibility = Visibility.Hidden;
            lbPhoneError.Visibility = Visibility.Hidden;
            lbAgeError.Visibility = Visibility.Hidden;
        }
    }

}
