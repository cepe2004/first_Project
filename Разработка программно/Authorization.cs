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
    public partial class Authorization : Form
    {
        public Authorization()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbLogin.Text) || string.IsNullOrWhiteSpace(tbPassword.Text))
            {
                MessageBox.Show("Заполните поля", "Информация");
                return;
            }
            else
            {
                try
                {
                    NpgsqlConnection conn = new NpgsqlConnection("Host=localhost;port=5432;database=Technoservis;Username=postgres;password = 12345");
                    NpgsqlDataAdapter adp = new NpgsqlDataAdapter("select role from users where login = '" + tbLogin.Text + "'and password = '" + tbPassword.Text + "'", conn);
                    DataTable dt = new DataTable();

                    adp.Fill(dt);



                    if (dt.Rows[0][0].ToString() == "1")
                    {
                      
                        this.Hide();
                        Applcation traderMenu = new Applcation();
                        traderMenu.Show();


                    }
                    else
                        if (dt.Rows[0][0].ToString() == "2")
                    {
                        this.Hide();
                        EditApp fm = new EditApp();
                        fm.ShowDialog();
                    }
                    else
                        if (dt.Rows[0][0].ToString() == "3")
                    {
                        this.Hide();
                        ViewApp am = new ViewApp();
                        am.ShowDialog();
                    }
                    else
                        if (dt.Rows[0][0].ToString() == "4")
                    {
                        this.Hide();
                        ResponsibleWork am = new ResponsibleWork();
                        am.ShowDialog();
                    }
                    else
                        if (dt.Rows[0][0].ToString() == "5")
                    {
                        this.Hide();
                        Statistic am = new Statistic();
                        am.ShowDialog();
                    }


                }
                //catch (NpgsqlException ex)
                //{
                //    MessageBox.Show("Проверьте подключение к интернету");
                //}
                catch (System.IndexOutOfRangeException ex)
                {
                    MessageBox.Show("Неверный логин или пароль");
                }
            }
        }
    }
}
