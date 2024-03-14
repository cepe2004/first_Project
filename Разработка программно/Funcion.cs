using Npgsql;
using System;
using System.Data;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;

namespace Technoservis
{
    internal class Funcion
    {
        //подключение к базе данных:
        static string host = "localhost";
        static int port = 5432;
        static string database = "Technoservis";
        static string userId = "postgres";
        static string password = "12345";

        //подключение к почте:
        static string serverMail = "";
        static string fromMail = "";
        static string fromName = "";
        static string fromPassword = "";

        public static int ToInt(string str)
        {
            int.TryParse(str, out int result);
            return result;
        }

        public static DataTable SQLtable(string request)
        {
            try
            {
                NpgsqlConnection conn = new NpgsqlConnection("Host = " + host + "; port = " + port + "; database = " + database + "; user id = " + userId + "; password = " + password);
                NpgsqlDataAdapter adp = new NpgsqlDataAdapter(request, conn);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                return dt;
            }
            catch (NpgsqlException ex)
            {
                DataTable dt = new DataTable();

                dt.Columns.Add("ErrorSQL", typeof(string));

                DataRow row = dt.NewRow();
                row["ErrorSQL"] = ex.Message;
                dt.Rows.Add(row);

                return dt;
            }

        }

        public static string SQLstring(string request, int column, int line)
        {
            if (SQLtable(request).Columns[0].ColumnName == "ErrorSQL")
            {
                return SQLtable(request).Rows[0][0].ToString();
            }
            else
            {
                return SQLtable(request).Rows[column][line].ToString();
            }
        }

        public static int SQLint(string request, int column, int line)
        {
            if (int.TryParse(SQLtable(request).Rows[column][line].ToString(), out int intValue))
            {
                return intValue;
            }
            else
            {
                return 00404;
            }
        }

        public static string SQLtableAdd(string table, string line, string values)
        {
            try
            {
                NpgsqlConnection conn = new NpgsqlConnection("Host = " + host + "; port = " + port + "; database = " + database + "; user id = " + userId + "; password = " + password);
                NpgsqlDataAdapter adp = new NpgsqlDataAdapter("INSERT INTO " + table + " (" + line + ") VALUES (" + values + ");", conn);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                return "OK";
            }
            catch (NpgsqlException ex)
            {
                return ex.Message;
            }
        }
        public static string SQLtableEdit(string table, string lineValues, string id)
        {
            try
            {
                NpgsqlConnection conn = new NpgsqlConnection("Host = " + host + "; port = " + port + "; database = " + database + "; user id = " + userId + "; password = " + password);
                NpgsqlDataAdapter adp = new NpgsqlDataAdapter("UPDATE " + table + " SET " + lineValues + " WHERE " + id + ";", conn);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                return "OK";
            }
            catch (NpgsqlException ex)
            {
                return ex.Message;
            }
        }

        public static string SQLtableDell(string table, string line, string value)
        {
            try
            {
                NpgsqlConnection conn = new NpgsqlConnection("Host = " + host + "; port = " + port + "; database = " + database + "; user id = " + userId + "; password = " + password);
                NpgsqlDataAdapter adp = new NpgsqlDataAdapter("DELETE FROM " + table + " WHERE " + line + " IN ('" + value + "');", conn);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                return "OK";
            }
            catch (NpgsqlException ex)
            {
                return ex.Message;
            }
        }

        public static ComboBox comboBoxFill(string request, ComboBox comboBox)
        {
            comboBox.Items.Clear();

            foreach (DataRow row in SQLtable(request).Rows)
            {
                comboBox.Items.Add(row[0]);
            }
            return comboBox;
        }

        public static string PasswordGeneration()
        {
            const string validChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder password = new StringBuilder();
            Random random = new Random();

            for (int i = 0; i < 8; i++)
            {
                int randomIndex = random.Next(0, validChars.Length);
                password.Append(validChars[randomIndex]);
            }

            return password.ToString();
        }

        public static void SendMailRu(string subject, string body, string mail)
        {
            try
            {
                var fromAddress = new MailAddress(fromMail, fromName);
                var toAddress = new MailAddress(mail, "Recipient Name");

                var smtp = new SmtpClient
                {
                    Host = serverMail,
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                };
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                })
                {
                    smtp.Send(message);
                }
            }
            catch
            {
                MessageBox.Show("Ошибка при отправке сообщения!");
            }
        }
    }
}
