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
using Technoservis;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Разработка_программного_модуля_для_учета_заявок_на_ремонт_оборудования
{
    public partial class Statistic : Form
    {
        public Statistic()
        {
            InitializeComponent();
            //SELECT(select count(*) from application WHERE status = 1) AS count
        }

        private void Statistic_Load(object sender, EventArgs e)
        {
            
            NpgsqlConnection conn1 = new NpgsqlConnection("Host=localhost;port=5432;database=Technoservis;Username=postgres;password = 12345");
            conn1.Open();
            string request = "select count(*) from application WHERE status = 1";
            string sqlP = Funcion.SQLtable(request).Rows[0][0].ToString();
            NpgsqlCommand command = new NpgsqlCommand(sqlP, conn1);
            NpgsqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Kolvo.Text = Convert.ToString(reader[0].ToString()); 
            }
            conn1.Close();
            conn1.Open();
             sqlP = "SELECT(select count(*) from application WHERE type_malfunction = 1) AS count";
             command = new NpgsqlCommand(sqlP, conn1);
             reader = command.ExecuteReader();
            while (reader.Read())
            {
                Polomka.Text = Convert.ToString(reader[0].ToString());
            }
            conn1.Close();
            conn1.Open();
            sqlP = "SELECT(select count(*) from application WHERE type_malfunction = 2) AS count";
            command = new NpgsqlCommand(sqlP, conn1);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Garanty.Text = Convert.ToString(reader[0].ToString());
            }
            conn1.Close();
            conn1.Open();
            sqlP = "SELECT(select count(*) from application WHERE type_malfunction = 3) AS count";
            command = new NpgsqlCommand(sqlP, conn1);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Sboi.Text = Convert.ToString(reader[0].ToString());
            }
            conn1.Close();
            conn1.Open();
            sqlP = "SELECT(select count(*) from application WHERE type_malfunction = 4) AS count";
            command = new NpgsqlCommand(sqlP, conn1);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Brak.Text = Convert.ToString(reader[0].ToString());
            }
            conn1.Close();
        }
    }
}
