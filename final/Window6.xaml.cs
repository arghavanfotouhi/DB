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

namespace final
{
    /// <summary>
    /// Interaction logic for Window6.xaml
    /// </summary>
    public partial class Window6 : Window
    {
        public Window6()
        {
            InitializeComponent();
            LoadGrid();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-7O57EOG;Initial Catalog=musicclass;Integrated Security=True;Encrypt=False");


        public void LoadGrid()
        {
            SqlCommand cmd = new SqlCommand("select * from manager", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            datagrid.ItemsSource = dt.DefaultView;
        }

        public bool IsValid()
        {
            if (Id_txt.Text == string.Empty)
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

            if (education_txt.Text == string.Empty)
            {
                MessageBox.Show("education is required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (matrialstatus_txt.Text == string.Empty)
            {
                MessageBox.Show("matrialstatus is required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (Salary_txt.Text == string.Empty)
            {
                MessageBox.Show("Salary is required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (employmentDate_txt.Text == string.Empty)
            {
                MessageBox.Show("employmentDate is required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (Duties_txt.Text == string.Empty)
            {
                MessageBox.Show("Duties is required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (WorkTime_txt.Text == string.Empty)
            {
                MessageBox.Show("WorkTime is required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from manager where id= " + Id_txt.Text + " ", con);
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
                    SqlCommand cmd = new SqlCommand("INSERT INTO manager VALUES (@id, @fname, @lname,@fatherName,@phone,@addres ,@birthDate,@maritalStatus,@salary,@employeementDate,@education,@Duties,@workTime)", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("id", Id_txt.Text);
                    cmd.Parameters.AddWithValue("fname", FirstName_txt.Text);
                    cmd.Parameters.AddWithValue("lname", LastName_txt.Text);
                    cmd.Parameters.AddWithValue("fatherName", FatherName_txt.Text);
                    cmd.Parameters.AddWithValue("phone", Phone_txt.Text);


                    cmd.Parameters.AddWithValue("addres", Address_txt.Text);
                    cmd.Parameters.AddWithValue("birthDate", BirthDate_txt.Text);
                    cmd.Parameters.AddWithValue("maritalStatus", matrialstatus_txt.Text);
                    /*cmd.Parameters.AddWithValue("salary", Salary_txt.Text);*/

                    if (int.TryParse(Salary_txt.Text, out int salary))
                    {
                        cmd.Parameters.AddWithValue("@salary", salary);
                    }
                    else
                    {
                        throw new Exception("Invalid phone number format.");
                    }
                    cmd.Parameters.AddWithValue("employeementDate", employmentDate_txt.Text);
                    cmd.Parameters.AddWithValue("education", education_txt.Text);
                    cmd.Parameters.AddWithValue("Duties", Duties_txt.Text);
                    cmd.Parameters.AddWithValue("workTime", WorkTime_txt.Text);

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
            SqlCommand cmd = new SqlCommand("update manager set fname ='" + FirstName_txt.Text + "' , lname='" + LastName_txt.Text + "',fathername='" + FatherName_txt.Text + "' ,  phone='" + Phone_txt.Text + "' , addres='" + Address_txt.Text + "' ,birthDate='" + BirthDate_txt.Text + "',maritalStatus='" + matrialstatus_txt.Text + "' ,salary='" + Salary_txt.Text + "', employeementDate='" + employmentDate_txt.Text + "',education='" + education_txt.Text + "', Duties='" + Duties_txt.Text + "', workTime='" + WorkTime_txt.Text + "'  where id ='" + Id_txt.Text + "'", con);
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
