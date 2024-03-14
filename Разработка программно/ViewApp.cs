using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Разработка_программного_модуля_для_учета_заявок_на_ремонт_оборудования
{
    public partial class ViewApp : Form
    {
        NpgsqlConnection conn = new NpgsqlConnection();
        NpgsqlDataAdapter adp = new NpgsqlDataAdapter();
        DataTable dt = new DataTable();
        public ViewApp()
        {
            InitializeComponent();
            conn = new NpgsqlConnection("Host=localhost;port=5432;database=Technoservis;Username=postgres;password = 12345");
            adp = new NpgsqlDataAdapter("SELECT * FROM application", conn);
            dt = new DataTable();
        }

        private void ViewApp_Load(object sender, EventArgs e)
        {
            adp.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.AutoResizeColumns();
            dataGridView1.Columns[0].Width = 25;
        }

        private void BSearch_Click(object sender, EventArgs e)
        {
            conn = new NpgsqlConnection("Host=localhost;port=5432;database=Technoservis;Username=postgres;password = 12345");
            adp = new NpgsqlDataAdapter("SELECT * FROM application WHERE id_application='"+TbSearch.Text+"'", conn);
            dt = new DataTable();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.AutoResizeColumns();
            dataGridView1.Columns[0].Width = 25;



        }
    }
}
