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
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
            LoadGrid();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-7O57EOG;Initial Catalog=musicclass;Integrated Security=True;Encrypt=False");

        public void LoadGrid()
        {
            SqlCommand cmd = new SqlCommand("select * from instrument", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            datagrid.ItemsSource = dt.DefaultView;
        }

        public bool IsValid()
        {
            if (InstrumentId_txt.Text == string.Empty)
            {
                MessageBox.Show("InstrumentId is required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (Type_txt.Text == string.Empty)
            {
                MessageBox.Show("Type is required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (Name_txt.Text == string.Empty)
            {
                MessageBox.Show("Name is required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (StudentId_txt.Text == string.Empty)
            {
                MessageBox.Show("StudentId is required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (DateOfReturn_txt.Text == string.Empty)
            {
                MessageBox.Show("DateOfReturn is required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (DateOfTake_txt.Text == string.Empty)
            {
                MessageBox.Show("DateOfTake is required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;

        }
        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from instrument where instrumentId= " + InstrumentId_txt.Text + " ", con);
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
                    SqlCommand cmd = new SqlCommand("INSERT INTO instrument VALUES (@instrumentId, @Type, @name,@studentId,@dateOfreturn,@dateOfTake)", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("instrumentId", InstrumentId_txt.Text);
                    cmd.Parameters.AddWithValue("Type", Type_txt.Text);
                    cmd.Parameters.AddWithValue("name", Name_txt.Text);
                    cmd.Parameters.AddWithValue("studentId", StudentId_txt.Text);
                    cmd.Parameters.AddWithValue("dateOfreturn", DateOfReturn_txt.Text);
                    cmd.Parameters.AddWithValue("dateOftake", DateOfTake_txt.Text);

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
            SqlCommand cmd = new SqlCommand("update instrument set  instrumentId='" + InstrumentId_txt.Text + "', type='" + Type_txt.Text + "' , name='" + Name_txt.Text + "', studentId='" + StudentId_txt.Text + "',dateOfreturn='" + DateOfReturn_txt.Text + "', dateOfTake='" + DateOfReturn_txt.Text + "' where instrumentId ='" + InstrumentId_txt.Text + "'", con);
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
