using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Technoservis;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Разработка_программного_модуля_для_учета_заявок_на_ремонт_оборудования
{
    public partial class Applcation : Form
    {
        public Applcation()
        {
            InitializeComponent();
        }

        private void BtAdd_Click(object sender, EventArgs e)
        {   //Проверка на пустые строки
            if (string.IsNullOrWhiteSpace(TbNomer.Text) ||
                string.IsNullOrWhiteSpace(TbObor.Text) ||
                string.IsNullOrWhiteSpace(TbNomer.Text) ||
                string.IsNullOrWhiteSpace(CbType.Text) ||
                string.IsNullOrWhiteSpace(TbFIO.Text) ||
                string.IsNullOrWhiteSpace(Cbstatus.Text))
            {
                MessageBox.Show("Заполните поля", "Информация");
            }
            else
            {
                //Получение индекса профессии
                int index_cb1 = CbType.SelectedIndex;
                index_cb1 += 1;
                int index_cb2 = Cbstatus.SelectedIndex;
                index_cb2 += 1;
                //Конвертирование String значения в int 
                int lef = Convert.ToInt32(TbNomer.Text);
                //Проверка переменной id: если в ней номер пользователя то этот пользователь будет изменён. Если Create будет создан новый пользователь

                NpgsqlConnection conn1 = new NpgsqlConnection("Host=localhost;port=5432;database=Technoservis;Username=postgres;password = 12345");
                NpgsqlDataAdapter adp1 = new NpgsqlDataAdapter("INSERT INTO public.application (id_application, date_plus, equipment, type_malfunction, info_problen, klient, status) VALUES('" + lef + "'::integer, '" + dateTimePicker1.Value + "'::date, '" + TbObor.Text + "'::character varying, '" + index_cb1 + "'::integer, '" + TbAddress.Text + "'::character varying, '" + TbFIO.Text + "'::character varying, '" + index_cb2 + "'::integer) returning id_application; ", conn1);
                DataTable dt1 = new DataTable();
                adp1.Fill(dt1);
                MessageBox.Show("Заявка успешно добавлена", "Успех");
            }
        }

        private void Applcation_Load(object sender, EventArgs e)
        {
            //NpgsqlConnection conn = new NpgsqlConnection("Host=localhost;port=5432;database=Technoservis;Username=postgres;password = 12345");
            ////Напольнение ComboBox данными
            //conn.Open();
            string sqlP = "select typeofmalfunction from typeofmalfunction";
            CbType = Funcion.comboBoxFill(sqlP, CbType);
            sqlP = "select status from status_application";
            Cbstatus= Funcion.comboBoxFill(sqlP,Cbstatus);
            //    NpgsqlCommand cmdP = new NpgsqlCo
            //    mmand(sqlP, conn);
            //    NpgsqlDataReader reader = cmdP.ExecuteReader();
            //    while (reader.Read())
            //    {
            //        CbType.Items.Add(reader.GetString(0));
            //    }
            //    conn.Close();
            //conn.Open();
            //sqlP = "select status from status_application";
            //NpgsqlCommand cmdM = new NpgsqlCommand(sqlP, conn);
            //NpgsqlDataReader readerM = cmdM.ExecuteReader();
            //while (readerM.Read())
            //{
            //    Cbstatus.Items.Add(readerM.GetString(0));
            //}
            //conn.Close();
        }
    }
    
}
