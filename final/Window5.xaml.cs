using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
    /// Interaction logic for Window5.xaml
    /// </summary>
    public partial class Window5 : Window
    {
        public Window5()
        {
            InitializeComponent();
            LoadGrid();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-7O57EOG;Initial Catalog=musicclass;Integrated Security=True;Encrypt=False");

        public void LoadGrid()
        {
            SqlCommand cmd = new SqlCommand("select * from academy", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            datagrid.ItemsSource = dt.DefaultView;
        }

        public bool IsValid()
        {
            if (branchCode_txt.Text == string.Empty)
            {
                MessageBox.Show("bookId is required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (lcenseNumber_txt.Text == string.Empty)
            {
                MessageBox.Show("bookId is required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (phone_txt.Text == string.Empty)
            {
                MessageBox.Show("forInstrument is required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (address_txt.Text == string.Empty)
            {
                MessageBox.Show("name is required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (webAddress_txt.Text == string.Empty)
            {
                MessageBox.Show("studentId is required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (MessengerAddress_txt.Text == string.Empty)
            {
                MessageBox.Show("studentId is required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }
        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from academy where branchCode= " + branchCode_txt.Text + " ", con);
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
                    SqlCommand cmd = new SqlCommand("INSERT INTO academy VALUES (@branchCode, @lcenseNumber, @phone,@addres,@webAddress,@MessengerAddress)", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("branchCode", branchCode_txt.Text);
                    cmd.Parameters.AddWithValue("lcenseNumber", lcenseNumber_txt.Text);
                    cmd.Parameters.AddWithValue("phone", phone_txt.Text);
                    cmd.Parameters.AddWithValue("addres", address_txt.Text);
                    cmd.Parameters.AddWithValue("webAddress", webAddress_txt.Text);
                    cmd.Parameters.AddWithValue("MessengerAddress", MessengerAddress_txt.Text);


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



        private void UpdateBtn_Click_1(object sender, RoutedEventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("update academy set lcenseNumber ='" + lcenseNumber_txt.Text + "' , phone='" + phone_txt.Text + "',addres='" + address_txt.Text + "',webAddress='" + webAddress_txt.Text + "' , MessengerAddress='" + MessengerAddress_txt.Text + "'  where branchCode ='" + branchCode_txt.Text + "'", con);
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
