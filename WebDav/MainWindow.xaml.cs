using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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

namespace WebDav
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Customers c = new Customers();
        }
    }

    public class Customer
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Address { get; set; }

        public Customer(String firstName, String lastName, String address)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Address = address;
        }

    }

    public class Customers : System.Collections.ObjectModel.ObservableCollection<Customer>
    {
        // public  String s;
        public String Connect()
        {
            // Create a request for the URL. 
            WebRequest request = WebRequest.Create(
              "http://localhost/myfsu");
            // If required by the server, set the credentials.
            request.Credentials = CredentialCache.DefaultCredentials;
            // Get the response.
            WebResponse response = request.GetResponse();
            // Display the status.
            // Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            // Get the stream containing content returned by the server.
            Stream dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();
            // Display the content.
            // s = responseFromServer;
            //Console.WriteLine(responseFromServer);
            // Clean up the streams and the response.
            reader.Close();
            response.Close();
            return responseFromServer;

        }
        public Customers()
        {

            Add(new Customer("Michael", "Anderberg",
                    "12 North Third Street, Apartment 45"));
            Add(new Customer("Chris", "Ashton",
                    "34 West Fifth Street, Apartment 67"));
            Add(new Customer("Cassie", "Hicks",
                    "56 East Seventh Street, Apartment 89"));
            Add(new Customer("Guido", "Pica",
                    "78 South Ninth Street, Apartment 10"));
            Add(new Customer(Connect(), "", ""));
        }

    }




}
