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
    public partial class RTS_Status : Telerik.WinControls.UI.RadForm
    {
        int id = 0;
        int pageNumber = 1;
        int pageSize = 10; // records per page
        int totalRecords = 0;
        int totalPages = 0;


        public RTS_Status()
        {
            InitializeComponent();
        }

        private void LoadRequirements()
        {
            ConnectionSql con = new ConnectionSql();
            con.SqlCon.Open();              
    

        string countQuery = "SELECT COUNT(*) FROM Requirements WHERE Status = 'Open'";
        con.SqlCmd = new SqlCommand(countQuery, con.SqlCon);
        //SqlCommand countCmd = new SqlCommand(countQuery, con);
        totalRecords = (int)con.SqlCmd.ExecuteScalar();
        totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

        int startIndex = (pageNumber - 1) * pageSize;

        string dataQuery = @"
            SELECT Id, RequestDate, RequestedBy, ModuleOrForm, Status 
            FROM Requirements 
            WHERE Status = 'Open'
            ORDER BY Id DESC
            OFFSET @Start ROWS FETCH NEXT @PageSize ROWS ONLY";

        con.SqlCmd = new SqlCommand(dataQuery, con.SqlCon);
        //SqlCommand dataCmd = new SqlCommand(dataQuery, con);
        con.SqlCmd.Parameters.AddWithValue("@Start", startIndex);
        con.SqlCmd.Parameters.AddWithValue("@PageSize", pageSize);

        SqlDataAdapter da = new SqlDataAdapter(con.SqlCmd);
        DataTable dt = new DataTable();
        da.Fill(dt);

        DGV_RTS_details.DataSource = dt;
        label1.Text = string.Format("Page {0} of {1}", pageNumber, totalPages);

    }




        
        public void FilledDGV_RTS_details()
        {
            string strsql10 = "";
            strsql10 = @"SELECT      R.Id, R.RequestDate, R.RequestedBy, d.DepartmentName, R.ModuleOrForm, R.ChangeType, R.DescriptionOfChange, R.Priority, R.Status
FROM            Requirements R 
LEFT OUTER JOIN Departments d ON d.DepartmentId = R.DepartmentId
Where R.Status = 'Open'
Order by R.Id DESC";



            ConnectionSql con = new ConnectionSql();
            con.SqlCon.Open();
            con.SqlCmd = new SqlCommand(strsql10, con.SqlCon);
            con.SqlAdapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            con.SqlAdapter.SelectCommand = con.SqlCmd;
            con.SqlAdapter.Fill(table);


            DataSet ds = new DataSet();
            con.SqlAdapter.Fill(ds);

            DGV_RTS_details.DataSource = ds.Tables[0];



            con.SqlCon.Close();

        }

        public void FilledDGV_RTS_update()
        {
            string strsql10 = "";
            strsql10 = @"SELECT      R.Id, R.RequestDate, R.RequestedBy, d.DepartmentName, R.ModuleOrForm, R.ChangeType, R.DescriptionOfChange, R.Priority, R.Status, R.CompletionDate
FROM            Requirements R 
LEFT OUTER JOIN Departments d ON d.DepartmentId = R.DepartmentId
Where R.Status = 'Close'
Order by R.RequestDate DESC";



            ConnectionSql con = new ConnectionSql();
            con.SqlCon.Open();
            con.SqlCmd = new SqlCommand(strsql10, con.SqlCon);
            con.SqlAdapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            con.SqlAdapter.SelectCommand = con.SqlCmd;
            con.SqlAdapter.Fill(table);


            DataSet ds = new DataSet();
            con.SqlAdapter.Fill(ds);

            DGV_RTS_updated.DataSource = ds.Tables[0];



            con.SqlCon.Close();

        }

        private void RTS_Status_Load(object sender, EventArgs e)
        {
            //LoadData();
            //lblCurrentpage.Text = currentPageIndex.ToString();
            LoadRequirements();
            //FilledDGV_RTS_details();
            FilledDGV_RTS_update();
            dtp_completeDate.Format = DateTimePickerFormat.Custom;
            dtp_completeDate.CustomFormat = "dd-MMM-yyyy HH:mm:ss"; // date + time
            dtp_completeDate.ShowUpDown = true; // time pick karne ke liye spinner
            dtp_completeDate.Value = DateTime.Now; // current system date-time

        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            FilledDGV_RTS_details();
        }

        private void DGV_RTS_details_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                id = Convert.ToInt32(DGV_RTS_details.Rows[e.RowIndex].Cells["Id"].Value.ToString());
                
                cb_status.Text = Convert.ToString(DGV_RTS_details.Rows[e.RowIndex].Cells["Status"].Value);
                //dtp_completeDate.Value = Convert.ToDateTime(DGV_RTS_details.Rows[e.RowIndex].Cells["CompletionDate"].Value);
            }

        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            try
            {
                if (id == 0)
                {
                    MessageBox.Show("Invalid selection. Please select a record to update.");
                    return;
                }
                ConnectionSql con = new ConnectionSql();
                con.SqlCon.Open();

                con.SqlCmd = new SqlCommand("sp_UpdateStatus", con.SqlCon);
                con.SqlCmd.CommandType = CommandType.StoredProcedure;

                con.SqlCmd.Parameters.AddWithValue("@statusID", id); // statusID
                con.SqlCmd.Parameters.AddWithValue("@status", cb_status.Text);
                con.SqlCmd.Parameters.AddWithValue("@completeDate", dtp_completeDate.Value.Date);

                con.SqlCmd.ExecuteNonQuery();
                con.SqlCon.Close();
                

                MessageBox.Show("Record updated successfully!");
                FilledDGV_RTS_details();
                FilledDGV_RTS_update();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Update Error: " + ex.Message);
            }

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (pageNumber < totalPages)
            {
                pageNumber++;
                LoadRequirements();
            }
        }

        private void btnprev_Click(object sender, EventArgs e)
        {
            if (pageNumber > 1)
            {
                pageNumber--;
                LoadRequirements();
            }
        }

      
    }
}
