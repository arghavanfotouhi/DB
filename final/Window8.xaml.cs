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

namespace final
{
    /// <summary>
    /// Interaction logic for Window8.xaml
    /// </summary>
    public partial class Window8 : Window
    {
        public Window8()
        {
            InitializeComponent();
            LoadGrid();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-7O57EOG;Initial Catalog=musicclass;Integrated Security=True;Encrypt=False");

        public void LoadGrid()
        {
            SqlCommand cmd = new SqlCommand("select * from student", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            datagrid.ItemsSource = dt.DefaultView;
        }

        public bool IsValid()
        {
            if (StudentId_txt.Text == string.Empty)
            {
                MessageBox.Show("Id is required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (FirstName_txt.Text == string.Empty)
            {
                MessageBox.Show("FirstName is required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (LastName_txt.Text == string.Empty)
            {
                MessageBox.Show("LastName is required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (FatherName_txt.Text == string.Empty)
            {
                MessageBox.Show("FatherName is required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (Phone_txt.Text == string.Empty)
            {
                MessageBox.Show("Phone is required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (Address_txt.Text == string.Empty)
            {
                MessageBox.Show("Address is required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (BirthDate_txt.Text == string.Empty)
            {
                MessageBox.Show("BirthDate is required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (Instruments_txt.Text == string.Empty)
            {
                MessageBox.Show("Instrument is required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (Fee_txt.Text == string.Empty)
            {
                MessageBox.Show("Fee is required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from student where studentId= " + StudentId_txt.Text + " ", con);
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
                    SqlCommand cmd = new SqlCommand("INSERT INTO student VALUES (@studentId, @fname, @lname,@fatherName,@phone,@addres ,@birthDate,@instruments,@fee)", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("studentId", StudentId_txt.Text);
                    cmd.Parameters.AddWithValue("fname", FirstName_txt.Text);
                    cmd.Parameters.AddWithValue("lname", LastName_txt.Text);
                    cmd.Parameters.AddWithValue("fatherName", FatherName_txt.Text);
                    /*cmd.Parameters.AddWithValue("phone", Phone_txt.Text);*/

                    if (int.TryParse(Phone_txt.Text, out int phone))
                    {
                        cmd.Parameters.AddWithValue("@phone", phone);
                    }
                    else
                    {
                        throw new Exception("Invalid phone number format.");
                    }

                    cmd.Parameters.AddWithValue("addres", Address_txt.Text);
                    cmd.Parameters.AddWithValue("birthDate", BirthDate_txt.Text);
                    cmd.Parameters.AddWithValue("instruments", Instruments_txt.Text);
                    cmd.Parameters.AddWithValue("fee", Fee_txt.Text);
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
            SqlCommand cmd = new SqlCommand("update student set fname ='" + FirstName_txt.Text + "' , lname='" + LastName_txt.Text + "',fathername='" + FatherName_txt.Text + "' ,  phone='" + Phone_txt.Text + "' , addres='" + Address_txt.Text + "' ,birthDate='" + BirthDate_txt.Text + "', instruments='" + Instruments_txt + "' , fee='" + Fee_txt.Text + "' where studentId='" + StudentId_txt.Text + "'", con);
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
