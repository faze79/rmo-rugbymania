using System;
using System.Data;
using System.Data.SQLite;

namespace My
{
    public class SQLLite
    {
        public SQLLite(string dbpath, string[] create)
        {
            DBPATH = dbpath;
            DBCREATE = create;
            OpenDatabase();
        }

        private string DBPATH = "db.s3db";
        private string[] DBCREATE;
        private SQLiteConnection Connection = null;
        private void OpenDatabase()
        {
            bool newdb = false;
            if (!System.IO.File.Exists(DBPATH))
            {   // Il database non esiste è necessario crearlo
                SQLiteConnection.CreateFile(DBPATH);
                newdb = true;
            }
            Connection = new SQLiteConnection("Data Source=" + DBPATH + ";");
            Connection.Open();
            if (newdb) foreach (string sql in DBCREATE) ExecuteCommand(sql);
        }

        public void CloseDatabase()
        {
            if (Connection != null)
            {
                Connection.Close();
                Connection.Dispose();
                Connection = null;
            }
        }

        public DataTable ExecuteQuery(string sql)
        {
            DataTable dt = new DataTable();
            SQLiteCommand c = Connection.CreateCommand();
            c.CommandText = sql;
            SQLiteDataReader r = c.ExecuteReader();
            if ((r != null) && (r.FieldCount > 0))
            {
                for (int i = 0; i < r.FieldCount; i++) dt.Columns.Add(r.GetName(i));
                while (r.Read())
                {
                    DataRow dr = dt.NewRow();
                    for (int j = 0; j < r.FieldCount; j++)
                    {
                        if (!r.IsDBNull(j))
                        {
                            try
                            {
                                object s = r.GetValue(j);
                                dr[j] = s.ToString();
                            }
                            catch { dr[j] = "Error"; }
                        }
                        else dr[j] = null;
                    }
                    dt.Rows.Add(dr);
                }
            }
            return dt;
        }

        public void ExecuteCommand(string sql)
        {
            try
            {
                SQLiteCommand c = Connection.CreateCommand();
                c.CommandText = sql;
                c.ExecuteNonQuery();
            }
            catch (Exception ex)
            { System.Windows.Forms.MessageBox.Show("Errore nella query:\r\n\r\n" + sql + "\r\n\r\n" + ex.Message); }
        }

        public static string DateToSQLite(DateTime time)
        {
            string result = time.Year.ToString("0000") + "-" + time.Month.ToString("00") + "-" + time.Day.ToString("00") + " ";
            result += time.Hour.ToString("00") + ":" + time.Minute.ToString("00") + ":" + time.Second.ToString("00");
            return result;
        }
    }
}