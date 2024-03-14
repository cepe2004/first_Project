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
    public partial class ResponsibleWork : Form
    {
        public ResponsibleWork()
        {
            InitializeComponent();
        }

        private void ResponsibleWork_Load(object sender, EventArgs e)
        {
            NpgsqlConnection conn = new NpgsqlConnection("Host=localhost;port=5432;database=Technoservis;Username=postgres;password = 12345");
            //Напольнение ComboBox данными
            conn.Open();
            string sqlP = "select fio from users where role=2";
            NpgsqlCommand cmdM = new NpgsqlCommand(sqlP, conn);
            NpgsqlDataReader readerM = cmdM.ExecuteReader();
            while (readerM.Read())
            {
                CbWorker.Items.Add(readerM.GetString(0));
            }
            conn.Close();
            conn.Open();
            sqlP = "select equipment from application";
            NpgsqlCommand cmdA = new NpgsqlCommand(sqlP, conn);
            NpgsqlDataReader readerA = cmdA.ExecuteReader();
            while (readerA.Read())
            {
                CbApp.Items.Add(readerA.GetString(0));
            }
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TbDescription.Text) ||
              string.IsNullOrWhiteSpace(CbWorker.Text))
            {
                MessageBox.Show("Заполните поля", "Информация");
            }
            else
            {
                NpgsqlConnection conn1 = new NpgsqlConnection("Host=localhost;port=5432;database=Technoservis;Username=postgres;password = 12345");
                conn1.Open();
                //Получение индекса профессии
                int index_cbA = CbApp.SelectedIndex;
                index_cbA += 1;
                int index_cbW = CbWorker.SelectedIndex;
                string sqlP = "select id_user from users where fio='" + CbWorker.Text + "'";
                NpgsqlCommand command = new NpgsqlCommand(sqlP, conn1);
                NpgsqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    index_cbW = Int32.Parse(reader[0].ToString());
                }
                conn1.Close();
                conn1.Open();
                NpgsqlDataAdapter adp1 = new NpgsqlDataAdapter("UPDATE public.application SET comment = '" + TbDescription.Text + "'::character varying WHERE id_application = '" + index_cbA + "'; ", conn1);
                DataTable dt1 = new DataTable();
                adp1.Fill(dt1);
                conn1.Close();
                conn1.Open();
                NpgsqlDataAdapter adpW = new NpgsqlDataAdapter("INSERT INTO public.work (app, worker) VALUES('"+ index_cbA + "'::integer, '"+ index_cbW + "'::integer) returning id_work; ", conn1);
                DataTable dtW = new DataTable();
                adpW.Fill(dtW);

                MessageBox.Show("Ответственный успешно добавлен", "Успех");
            }
        }
    }
}
