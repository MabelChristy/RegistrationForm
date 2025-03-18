
using System;
using System.Data.SqlClient;
using System.Web.UI;

namespace RegistrationForm
{
    public partial class Register : System.Web.UI.Page
    {
        // Database connection
        string connStr = "Server=(local)\\SQLEXPRESS;Database=MemberDb;Integrated Security=True;";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtMNo.Text = "";  // to keep empty
                ViewState["isAdding"] = false;
            }
        }

        // Generate the next available M.No
        private void SetLastAvailableMemberNumber()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT ISNULL(MAX(MNo), 0) + 1 FROM Users";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    txtMNo.Text = cmd.ExecuteScalar().ToString();
                }
            }
        }

        // Fetch details 
        private void FetchMemberDetails(string mno)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT MNo, Name, DOB, Address, PAN, Aadhar FROM Users WHERE MNo = @MNo";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MNo", mno);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        txtMNo.Text = reader["MNo"].ToString(); 
                        TextBox2.Text = reader["Name"].ToString();
                        TextBox3.Text = Convert.ToDateTime(reader["DOB"]).ToString("yyyy-MM-dd");
                        TextBox4.Text = reader["Address"].ToString();
                        TextBox5.Text = reader["PAN"].ToString();
                        TextBox6.Text = reader["Aadhar"].ToString();

                        //ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Record fetched successfully!');", true);
                    }
                    else
                    {
                        ClearForm();
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('No record found!');", true);
                    }
                }
            }
        }

        // Fetch details when M.No is changed
        protected void txtMNo_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMNo.Text))
            {
                FetchMemberDetails(txtMNo.Text);
            }
        }


        // Add
        protected void Button1_Click(object sender, EventArgs e)
        {
            ViewState["isAdding"] = true;
            ClearForm();
            SetLastAvailableMemberNumber();
        }

        // Save
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(TextBox6.Text, "^[0-9]{12}$"))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Aadhar number must be exactly 12 digits and contain only numbers.');", true);
                return; 
            }

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query;
                bool isExistingMember = false;

                // Check if MNo exists
                using (SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM Users WHERE MNo = @MNo", conn))
                {
                    checkCmd.Parameters.AddWithValue("@MNo", txtMNo.Text);
                    isExistingMember = (int)checkCmd.ExecuteScalar() > 0;
                }

                if (isExistingMember)
                {
                    query = "UPDATE Users SET Name=@Name, DOB=@DOB, Address=@Address, PAN=@PAN, Aadhar=@Aadhar WHERE MNo=@MNo";
                }
                else
                {
                    query = "INSERT INTO Users (Name, DOB, Address, PAN, Aadhar) VALUES (@Name, @DOB, @Address, @PAN, @Aadhar); SELECT SCOPE_IDENTITY();";
                }

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (isExistingMember)
                    {
                        cmd.Parameters.AddWithValue("@MNo", txtMNo.Text);
                    }

                    cmd.Parameters.AddWithValue("@Name", TextBox2.Text);
                    cmd.Parameters.AddWithValue("@DOB", TextBox3.Text);
                    cmd.Parameters.AddWithValue("@Address", TextBox4.Text);
                    cmd.Parameters.AddWithValue("@PAN", TextBox5.Text);
                    cmd.Parameters.AddWithValue("@Aadhar", TextBox6.Text);

                    if (isExistingMember)
                    {
                        cmd.ExecuteNonQuery();
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Record updated successfully!');", true);
                    }
                    else
                    {
                        object newMNo = cmd.ExecuteScalar();
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('Record saved successfully! MNo: {newMNo}');", true);
                    }
                }
            }

            ClearForm();
        }

        // edit
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMNo.Text))
            {
                FetchMemberDetails(txtMNo.Text);
            }
        }

        // delete
        protected void Button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMNo.Text)) return;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "DELETE FROM Users WHERE MNo = @MNo";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MNo", txtMNo.Text);
                    cmd.ExecuteNonQuery();
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Record deleted successfully!');", true);
                }
            }

            ClearForm();
        }

        protected void btnReport_Click(object sender, EventArgs e)
        {
            Response.Redirect("Report.aspx");
        }

        private void ClearForm()
        {
            txtMNo.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            TextBox6.Text = "";

            ViewState["isAdding"] = false;
        }
    }
}
