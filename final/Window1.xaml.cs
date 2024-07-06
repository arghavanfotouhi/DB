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
using System.Security.RightsManagement;
using System.Data;
using System.Linq.Expressions;
using System.Net;

namespace final
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            LoadGrid();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-7O57EOG;Initial Catalog=musicclass;Integrated Security=True;Encrypt=False");

        public void LoadGrid()
        {
            SqlCommand cmd = new SqlCommand("select * from Concert", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            datagrid.ItemsSource = dt.DefaultView;
        }

        public bool IsValid()
        {
            if (Address_txt.Text == string.Empty)
            {
                MessageBox.Show("classNum is required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (DateAndHour_txt.Text == string.Empty)
            {
                MessageBox.Show("dateAndHour is required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (TiketFee_txt.Text == string.Empty)
            {
                MessageBox.Show("TiketFee is required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (OrchestraNum_txt.Text == string.Empty)
            {
                MessageBox.Show("OrchestraNum is required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (StudentId_txt.Text == string.Empty)
            {
                MessageBox.Show("StudentId is required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (Capacity_txt.Text == string.Empty)
            {
                MessageBox.Show("Capacity is required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Address_txt.Text))
            {
                MessageBox.Show("Address is required to delete a record", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Concert WHERE address = @address", con);
                cmd.Parameters.AddWithValue("@address", Address_txt.Text);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Record has been deleted", "Deleted", MessageBoxButton.OK, MessageBoxImage.Information);
                    con.Close();
                    LoadGrid();
                }
                else
                {
                    MessageBox.Show("No record found with the provided address", "Not Deleted", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Not deleted. Error: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
                    SqlCommand cmd = new SqlCommand("INSERT INTO Concert VALUES (@address, @dateAndHour, @tiketFee ,@orchestraNum,@studentId,@capacity)", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("address", Address_txt.Text);
                    cmd.Parameters.AddWithValue("dateAndHour", DateAndHour_txt.Text);
                    cmd.Parameters.AddWithValue("tiketFee", TiketFee_txt.Text);
                    cmd.Parameters.AddWithValue("orchestraNum", OrchestraNum_txt.Text);
                    cmd.Parameters.AddWithValue("studentId", StudentId_txt.Text);
                    cmd.Parameters.AddWithValue("capacity", Capacity_txt.Text);

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
            SqlCommand cmd = new SqlCommand("update Concert set address ='" + Address_txt.Text + "' , dateAndHour='" + DateAndHour_txt.Text + "',tiketFee='" + TiketFee_txt.Text + "' , orchestraNum='" + OrchestraNum_txt.Text + "' , studentId='" + StudentId_txt.Text + "',capacity='" + Capacity_txt.Text + "'  where address= '" + Address_txt.Text + "'  and dateAndHour='" + DateAndHour_txt.Text + " '", con);
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
