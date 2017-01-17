using Newtonsoft.Json;
using RestSharp;
using System;
using System.Data;
using System.Windows.Forms;
using WebApi.Models;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private const string _webApiUri = "http://localhost:49702/";

        public Form1()
        {
            InitializeComponent();
        }

        protected async override void OnLoad(EventArgs e)
        {
            var client = new RestClient(_webApiUri);

            var request = new RestRequest("api/client", Method.GET);

            var response = await client.ExecuteTaskAsync(request);

            dataGridView1.DataSource = JsonConvert.DeserializeObject<DataTable>(response.Content);
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var client = new RestClient(_webApiUri);

            var request = new RestRequest("api/client/{id}", Method.GET);

            request.AddParameter("id", "1", ParameterType.UrlSegment);

            var response = await client.ExecuteTaskAsync(request);
            dataGridView1.DataSource = JsonConvert.DeserializeObject<DataTable>($"[{response.Content}]");
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            var client = new RestClient(_webApiUri);

            var request = new RestRequest("api/client/{id}", Method.POST);

            request.AddParameter("id", "1", ParameterType.UrlSegment);

            request.AddObject(new Client() { Id = 1, FirstName = "Alojzy", LastName = "Aktualny", IdNmbr = "AZZ01234" });

            var response = await client.ExecuteTaskAsync(request);
            dataGridView1.DataSource = JsonConvert.DeserializeObject<DataTable>(response.Content);
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            var client = new RestClient(_webApiUri);

            var request = new RestRequest("api/client/", Method.POST);

            RandomNameGeneratorLibrary.PersonNameGenerator names = new RandomNameGeneratorLibrary.PersonNameGenerator();

            request.AddObject(new Client()
            {
                FirstName = names.GenerateRandomFirstName()
                ,
                LastName = names.GenerateRandomLastName()
                ,
                IdNmbr = "X-X-X"
            });

            var response = await client.ExecuteTaskAsync(request);

            if (response.StatusCode == System.Net.HttpStatusCode.Created)
            {
                request = new RestRequest("api/client", Method.GET);

                response = await client.ExecuteTaskAsync(request);
                dataGridView1.DataSource = JsonConvert.DeserializeObject<DataTable>(response.Content);

                MessageBox.Show("OK");
            }
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            var client = new RestClient(_webApiUri);

            var request = new RestRequest("api/client", Method.GET);

            var response = await client.ExecuteTaskAsync(request);
            dataGridView1.DataSource = JsonConvert.DeserializeObject<DataTable>(response.Content);
        }
    }
}