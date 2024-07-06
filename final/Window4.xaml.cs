using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Security.RightsManagement;
using System.Data;
using System.Linq.Expressions;
using System.Net;


namespace final
{
    /// <summary>
    /// Interaction logic for Window4.xaml
    /// </summary>
    public partial class Window4 : Window
    {
        public Window4()
        {
            InitializeComponent();
            LoadGrid();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-7O57EOG;Initial Catalog=musicclass;Integrated Security=True;Encrypt=False");

        public void LoadGrid()
        {
            SqlCommand cmd = new SqlCommand("select * from books", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            datagrid.ItemsSource = dt.DefaultView;
        }

        public bool IsValid()
        {
            if (bookId_txt.Text == string.Empty)
            {
                MessageBox.Show("bookId is required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (forInstrument_txt.Text == string.Empty)
            {
                MessageBox.Show("forInstrument is required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (name_txt.Text == string.Empty)
            {
                MessageBox.Show("name is required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (studentId_txt.Text == string.Empty)
            {
                MessageBox.Show("studentId is required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }
        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from books where bookId= " + bookId_txt.Text + " ", con);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record has been deleted", "Deleted", MessageBoxButton.OK, MessageBoxImage.Information);
                con.Close();
                LoadGrid();
                con.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Not deleted" + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }


        private void InsertBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (IsValid())
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO books VALUES (@bookId, @forInstrument, @name,@studentId)", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("bookId", bookId_txt.Text);
                    cmd.Parameters.AddWithValue("forInstrument", forInstrument_txt.Text);
                    cmd.Parameters.AddWithValue("name", name_txt.Text);
                    cmd.Parameters.AddWithValue("studentId", studentId_txt.Text);


                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    LoadGrid();
                    MessageBox.Show("Successfully registered", "Saved", MessageBoxButton.OK, MessageBoxImage.Information);


                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("update books set forInstrument ='" + forInstrument_txt.Text + "' , name='" + name_txt.Text + "',studentId='" + studentId_txt.Text + "'  where bookId ='" + bookId_txt.Text + "'", con);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record has been updated successefully", "Updated", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
                LoadGrid();
            }

        }
    }
}
