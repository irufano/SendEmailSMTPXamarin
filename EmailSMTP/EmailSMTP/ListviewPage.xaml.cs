using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EmailSMTP
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListviewPage : ContentPage
    {
        readonly List<ListViewTemplate> ListItems = new List<ListViewTemplate>();

        string Part;

        public ListviewPage()
        {
            InitializeComponent();

            ListItems.Add(new ListViewTemplate() { Name = "Agus", Description = "hello 1", OrderNumber = 1 });
            ListItems.Add(new ListViewTemplate() { Name = "David", Description = "hello 2", OrderNumber = 2 });
            ListItems.Add(new ListViewTemplate() { Name = "Susanto", Description = "hello 3", OrderNumber = 3 });
            ListItems.Add(new ListViewTemplate() { Name = "Sandy", Description = "hello 4", OrderNumber = 4 });
            ListItems.Add(new ListViewTemplate() { Name = "Satrio", Description = "hello 5", OrderNumber = 5 });

            MainListView.ItemsSource = ListItems;

            foreach (ListViewTemplate aPart in ListItems)
            {
                Part += aPart.Name + " " + aPart.Description + aPart.OrderNumber + "\n";
            };

        }

        private void BtnSendEmail_Clicked(object sender, EventArgs e)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("youremail@mail.com");
                mail.To.Add("someone@email.com");
                mail.Subject = "testing list";
                mail.Body = Part;

                SmtpServer.Port = 587;
                SmtpServer.Host = "smtp.gmail.com";
                SmtpServer.EnableSsl = true;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new System.Net.NetworkCredential("youremail@mail.com", "yourpassword");

                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                DisplayAlert("Failed", ex.Message, "OK");
            }
        }
    }
}