using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using HomeTask.Models;

namespace UI_Home_Task
{
    public partial class Form1 : Form
    {
        private readonly HttpClient _httpClient;

        public Form1()
        {
            InitializeComponent();
            var handler = new HttpClientHandler()
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
            };
            _httpClient = new HttpClient(handler);
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await LoadOperatorsAsync();
        }

        private async Task LoadOperatorsAsync()
        {
            try
            {
                string url = "https://localhost:7009/api/operators";
                HttpResponseMessage response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                List<Operator> operators = JsonSerializer.Deserialize<List<Operator>>(responseBody) ?? new List<Operator>();

                comboBoxOperation.Items.Clear();
                foreach (var op in operators)
                {
                    comboBoxOperation.Items.Add(op.OperatorName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading operators: {ex.Message}");
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var request = new CalculateRequest
            {
                ValueA = textBoxValueA.Text,
                ValueB = textBoxValueB.Text,
                Operation = comboBoxOperation.SelectedItem?.ToString() ?? ""
            };

           
            if (string.IsNullOrWhiteSpace(request.Operation))
            {
                MessageBox.Show("Please select an operator.");
                return;
            }

           
            if (string.IsNullOrWhiteSpace(request.ValueA) || string.IsNullOrWhiteSpace(request.ValueB))
            {
                MessageBox.Show("Please enter valid values.");
                return;
            }

            await CallCalculateApiAsync(request);
        }

        private async Task CallCalculateApiAsync(CalculateRequest request)
        {
            try
            {
                string url = "https://localhost:7009/api/calculate";
                var json = JsonSerializer.Serialize(request);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _httpClient.PostAsync(url, content);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();
                MessageBox.Show($"Calculation result: {responseBody}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error performing calculation: {ex.Message}");
            }
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }
    }
}
