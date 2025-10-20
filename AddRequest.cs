using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Data.SqlClient;

namespace RTS
{
    public partial class AddRequest : Telerik.WinControls.UI.RadForm
    {
        public AddRequest()
        {
            InitializeComponent();
        }
        int Savemode = 0;


        private void filledCBDepart()
        {
            ConnectionSql con = new ConnectionSql();
             string query = "SELECT DepartmentId,DepartmentName FROM Departments";

                using (SqlDataAdapter adapter = new SqlDataAdapter(query, con.SqlCon))
                {
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    // Add blank row at the top
                    DataRow row = table.NewRow();
                    row["DepartmentName"] = "";
                    table.Rows.InsertAt(row, 0);

                    cb_Dept.DataSource = table;
                    cb_Dept.DisplayMember = "DepartmentName";
                    cb_Dept.ValueMember = "DepartmentId";
                }
            }

        private bool SaveRequirement()
        {
            try
            {
                string queryIdentity = "SELECT SCOPE_IDENTITY()";

                ConnectionSql con = new ConnectionSql();
                con.SqlCon.Open();

                string insertQuery = @"INSERT INTO Requirements 
            (RequestDate, RequestedBy, DepartmentId, ModuleOrForm, ChangeType, DescriptionOfChange, Priority, Status, CompletionDate,
             CreatedOn, CreatedByUserId, CreatedByUserName, CreatedByMachine)
        VALUES
            (@RequestDate, @RequestedBy, @DepartmentId, @ModuleOrForm, 'Requirement', @DescriptionOfChange, 'Medium', 'Open', NULL,
             @CreatedOn, @CreatedByUserId, @CreatedByUserName, @CreatedByMachine)";

                con.SqlCmd = new SqlCommand(insertQuery, con.SqlCon);
                con.SqlCmd.CommandType = CommandType.Text;

                // Form fields
                con.SqlCmd.Parameters.Add("@RequestDate", SqlDbType.DateTime).Value = dtp_RequestDate.Value;
                con.SqlCmd.Parameters.AddWithValue("@RequestedBy", cb_RequestBy.Text);
                con.SqlCmd.Parameters.AddWithValue("@DepartmentId", cb_Dept.SelectedValue);
                con.SqlCmd.Parameters.AddWithValue("@ModuleOrForm", cb_Form.Text);
                con.SqlCmd.Parameters.AddWithValue("@DescriptionOfChange", txt_Description.Text);

                // Audit fields
                con.SqlCmd.Parameters.Add("@CreatedOn", SqlDbType.DateTime).Value = DateTime.Now;
                con.SqlCmd.Parameters.Add("@CreatedByUserId", SqlDbType.Int).Value = Global.UserId;
                con.SqlCmd.Parameters.Add("@CreatedByUserName", SqlDbType.NVarChar).Value = Global.DisplayName;
                con.SqlCmd.Parameters.Add("@CreatedByMachine", SqlDbType.NVarChar).Value = Global.SysMachineName;

                // Execute insert
                con.SqlCmd.ExecuteNonQuery();

                // Get inserted identity
                con.SqlCmd.CommandText = queryIdentity;
                Id_label.Text = Convert.ToString(con.SqlCmd.ExecuteScalar());


                MessageBox.Show("Requirement added successfully! ID: ");
                Disablefields();

                // Example: refresh grid if needed
                // Fill_DGV_Requirements();


                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return false;
            }
        }

        private void Disablefields()
        {
            dtp_RequestDate.Enabled = false;
            cb_Dept.Enabled = false;
            cb_RequestBy.Enabled = false;
            cb_Form.Enabled = false;
            txt_Description.Enabled = false;
        }

        private void EnableFields()
        {
            dtp_RequestDate.Enabled = true;
            cb_Dept.Enabled = true;
            cb_RequestBy.Enabled = true;
            cb_Form.Enabled = true;
            txt_Description.Enabled = true;
        }
       
        private void ClearFields()
        {
            dtp_RequestDate.Value = DateTime.Now; // or pick a default date
            cb_Dept.SelectedIndex = -1;           // clears selection
            cb_RequestBy.SelectedIndex = -1;      // clears selection
            cb_Form.SelectedIndex = -1;           // clears selection
            txt_Description.Clear();              // clears text
        }


        private void AddRequest_Load(object sender, EventArgs e)
        {
            filledCBDepart();
            //dtp_RequestDate.Value = System.DateTime.Now;
            dtp_RequestDate.Format = DateTimePickerFormat.Custom;
            dtp_RequestDate.CustomFormat = "dd-MMM-yyyy HH:mm:ss"; // date + time
            dtp_RequestDate.ShowUpDown = true; // time pick karne ke liye spinner
            dtp_RequestDate.Value = DateTime.Now; // current system date-time
            
        }


       

        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (Savemode == 0)
            {
                if (cb_RequestBy.SelectedIndex < 0 || cb_RequestBy.SelectedValue == DBNull.Value)
                {
                    MessageBox.Show("Please Selected Reqested By");
                    return;
                }
                SaveRequirement();
            }
        }

        private void btn_New_Click(object sender, EventArgs e)
        {
            EnableFields();
            ClearFields();
        }
    }
}
