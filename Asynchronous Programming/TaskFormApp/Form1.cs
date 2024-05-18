using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskFormApp
{
    public partial class Form1 : Form
    {
        public int Count { get; set; } = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string data = String.Empty;

            Task<string> okuma = ReadFileAsync();

            richTextBox2.Text = await new HttpClient().GetStringAsync("https://google.com");
            
            data = await okuma;
            richTextBox1.Text = data;

        }

        private void BtnCounter_Click(object sender, EventArgs e)
        {
            textBoxCounter.Text = Count++.ToString();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxCounter_TextChanged(object sender, EventArgs e)
        {

        }
        private string ReadFile()
        {
            string data = string.Empty;
            using(StreamReader s = new StreamReader("dosya.txt"))
            {
                //Thread 5 saniye boyunca bekler.
                Thread.Sleep(5000);
                //Dosyayı baştan sona okur.
                data = s.ReadToEnd();
            }
            return data;
        }
        //Void Task
        //string Task<string>

        private async Task<string> ReadFileAsync()
        {
            string data = string.Empty;
            using (StreamReader s = new StreamReader("dosya.txt"))
            {
                //Dosyayı baştan sona okur.
                Task<string> myTask = s.ReadToEndAsync();

                //5 saniye boyunca bekler.
                await Task.Delay(5000);

                data = await myTask;
                return data;
            }
            
        }
    }
}
