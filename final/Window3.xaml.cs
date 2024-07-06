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
    /// Interaction logic for Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        public Window3()
        {
            InitializeComponent();
            LoadGrid();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-7O57EOG;Initial Catalog=musicclass;Integrated Security=True;Encrypt=False");

        public void LoadGrid()
        {
            SqlCommand cmd = new SqlCommand("select * from classes", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            datagrid.ItemsSource = dt.DefaultView;
        }

        public bool IsValid()
        {
            if (classNum_txt.Text == string.Empty)
            {
                MessageBox.Show("classNum is required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (dayAndHour_txt.Text == string.Empty)
            {
                MessageBox.Show("dayAndHour is required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (id_txt.Text == string.Empty)
            {
                MessageBox.Show("id is required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (studentId_txt.Text == string.Empty)
            {
                MessageBox.Show("studentId is required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (NumberOfSessions_txt.Text == string.Empty)
            {
                MessageBox.Show("NumberOfSessions is required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (Tuition_txt.Text == string.Empty)
            {
                MessageBox.Show("Tuition is required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (level_txt.Text == string.Empty)
            {
                MessageBox.Show("level is required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (publicPrivate_txt.Text == string.Empty)
            {
                MessageBox.Show("publicPrivate is required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (instrument_txt.Text == string.Empty)
            {
                MessageBox.Show("instrument is required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }
        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from classes where classNum= " + classNum_txt.Text + " ", con);
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
                    SqlCommand cmd = new SqlCommand("INSERT INTO classes VALUES (@classNum, @dayAndHour, @id,@studentId,@NumberOfSessions,@Tuition,@level,@publicPrivate,@instruments)", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("classNum", classNum_txt.Text);
                    cmd.Parameters.AddWithValue("dayAndHour", dayAndHour_txt.Text);
                    cmd.Parameters.AddWithValue("id", id_txt.Text);
                    cmd.Parameters.AddWithValue("studentId", studentId_txt.Text);
                    cmd.Parameters.AddWithValue("NumberOfSessions", NumberOfSessions_txt.Text);
                    cmd.Parameters.AddWithValue("Tuition", Tuition_txt.Text);
                    cmd.Parameters.AddWithValue("level", level_txt.Text);
                    cmd.Parameters.AddWithValue("publicPrivate", publicPrivate_txt.Text);
                    cmd.Parameters.AddWithValue("instruments",instrument_txt.Text);

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
            SqlCommand cmd = new SqlCommand("update classes set classNum ='" + classNum_txt.Text
                + "' , dayAndHour='" + dayAndHour_txt.Text + "',id='" + id_txt.Text + "',studentId='" + studentId_txt.Text + "' , NumberOfSessions='"
                + NumberOfSessions_txt.Text + "',Tuition='" + Tuition_txt.Text + "',level='" + level_txt.Text + "',publicPrivate='" + publicPrivate_txt.Text + "', instrument = '" + instrument_txt.Text + "'  where classNum ='" + classNum_txt.Text + "'", con);
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
