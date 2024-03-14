﻿using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Разработка_программного_модуля_для_учета_заявок_на_ремонт_оборудования
{
    public partial class EditApp : Form
    {
        public EditApp()
        {
            InitializeComponent();
        }

        private void BtAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CbStatus.Text) ||
               string.IsNullOrWhiteSpace(TbDescription.Text) ||
               string.IsNullOrWhiteSpace(CbWorker.Text))
            {
                MessageBox.Show("Заполните поля", "Информация");
            }
            else
            {
                NpgsqlConnection conn1 = new NpgsqlConnection("Host=localhost;port=5432;database=Technoservis;Username=postgres;password = 12345");
                conn1.Open();
                //Получение индекса профессии
                int index_cb1 = CbStatus.SelectedIndex;
                index_cb1 += 1;
                int index_cbA = CbApp.SelectedIndex;
                index_cbA += 1;
                int index_cbW = CbWorker.SelectedIndex;
                string sqlP = "select id_user from users where fio='"+CbWorker.Text+ "'";
                NpgsqlCommand command= new NpgsqlCommand(sqlP,conn1);
                NpgsqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    index_cbW = Int32.Parse(reader[0].ToString());
                }
                conn1.Close();
                conn1.Open();
                NpgsqlDataAdapter adp1 = new NpgsqlDataAdapter("UPDATE public.application SET info_problen = '"+TbDescription.Text+ "'::character varying WHERE id_application = '"+ index_cbA + "'; ", conn1);
                DataTable dt1 = new DataTable();
                adp1.Fill(dt1);
                conn1.Close();
                conn1.Open();
                NpgsqlDataAdapter adpW = new NpgsqlDataAdapter("UPDATE public.work SET worker = '" + index_cbW+"'::integer WHERE app = '"+index_cbA+"'; ", conn1);
                DataTable dtW = new DataTable();
                adpW.Fill(dtW);
               
                MessageBox.Show("Заявка успешно отредактирована", "Успех");
            }
        }

        private void EditApp_Load(object sender, EventArgs e)
        {
            NpgsqlConnection conn = new NpgsqlConnection("Host=localhost;port=5432;database=Technoservis;Username=postgres;password = 12345");
            //Напольнение ComboBox данными
            conn.Open();
            string sqlP = "select status from status_application";
            NpgsqlCommand cmdP = new NpgsqlCommand(sqlP, conn);
            NpgsqlDataReader reader = cmdP.ExecuteReader();
            while (reader.Read())
            {
                CbStatus.Items.Add(reader.GetString(0));
            }
            conn.Close();
            conn.Open();
            sqlP = "select fio from users where role=2";
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

        private void TbDescription_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
