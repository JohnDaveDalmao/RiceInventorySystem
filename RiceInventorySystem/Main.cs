using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//STOCK size: 870, 503
namespace RiceInventorySystem {
    public partial class Main : Form {

        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SystemDatabaseConnection"].ConnectionString);


        private const int cGrip = 16;
        private const int cCaption = 32;

        int mov, movX, movY;
        int panelWidth = 1134, panelHeight = 615;
        int locationX = 166, locationY = 39;

        public Main() {
            InitializeComponent();
            this.SetStyle(ControlStyles.ResizeRedraw, true);

            mainPanel.BackColor = Color.FromArgb(55, 71, 79);
            addPanel.BackColor = Color.FromArgb(69, 90, 100);
            stockPanel.BackColor = Color.FromArgb(69, 90, 100);
            summaryPanel.BackColor = Color.FromArgb(69, 90, 100);

            DataTable dt = new DataTable();

            DataColumn newColumn = new DataColumn("addOrSubtractItem", typeof(System.String));
            newColumn.DefaultValue = "Your DropDownList value";
            dt.Columns.Add(newColumn);
        }

        private void Main_Load(object sender, EventArgs e) {
            dropdownRefresh();
            populateStockDataGridView();
            populateSummaryDataGridView();

            foreach (DataGridViewColumn column in stockGridView.Columns) {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            foreach (DataGridViewColumn column in summaryGridView.Columns) {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            foreach (DataGridViewRow row in stockGridView.Rows) {
                row.Height = 35;
            }

            foreach (DataGridViewRow row in summaryGridView.Rows) {
                row.Height = 32;
            }

            /*
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("addOrSubtractItem", typeof(string)));
            string sessionIDValue = Convert.ToString(Guid.NewGuid());
            foreach (DataRow row in dt.Rows) {
                row["addOrSubtractItem"] = sessionIDValue;
            }*/

            /*DataTable dt = new DataTable();
            DataColumn newColumn = new DataColumn("addOrSubtractItem", typeof(String));
            newColumn.DefaultValue = "Your DropDownList value";
            dt.Columns.Add(newColumn);*/
        }


        // F U N C T I O N S //
        private void dropdownRefresh() {
            riceComboBoxPreview.Items.Clear();
            riceComboBox.Items.Clear();

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT RiceClass FROM RiceClassPreview";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows) {
                riceComboBoxPreview.Items.Add(dr["RiceClass"].ToString());
                riceComboBox.Items.Add(dr["RiceClass"].ToString());
            }
            con.Close();
        }

        private void populateStockDataGridView() {

            /* "tried" for stackoverflow
             * foreach (DataRow row in dt.Rows) {
                row["addOrSubtractItem"] = 0;
            }*/

            /* con.Open();
             DataTable dt = new DataTable();
             SqlCommand cm = new SqlCommand("SELECT * FROM Stock");
             cm.Connection = con;

             SqlDataAdapter da = new SqlDataAdapter(cm);
             da.Fill(dt);
             stockGridView.AutoGenerateColumns = false;
             stockGridView.Columns[0].DataPropertyName = "Name";
             stockGridView.Columns[1].DataPropertyName = "Price";
             stockGridView.Columns[2].DataPropertyName = "Total";
             stockGridView.Columns[3].DataPropertyName = "Quantity";
             stockGridView.DataSource = dt;
             con.Close();*/

            /*DataGridViewTextBoxColumn buttonColumn = new DataGridViewTextBoxColumn();
             buttonColumn.Name = "Item/s Added or Subtracted";
             buttonColumn.HeaderText = "Item/s Added or Subtracted";
             stockGridView.Columns.Insert(4, buttonColumn);*/

            con.Open();
            DataTable dt = new DataTable();
            SqlCommand cm = new SqlCommand("SELECT * FROM Stock");
            cm.Connection = con;

            SqlDataAdapter da = new SqlDataAdapter(cm);
            da.Fill(dt);
            con.Close();

            stockGridView.AutoGenerateColumns = false;
            stockGridView.Columns[0].DataPropertyName = "Name";
            stockGridView.Columns[1].DataPropertyName = "Price";
            stockGridView.Columns[2].DataPropertyName = "Total";
            stockGridView.Columns[3].DataPropertyName = "Quantity";
            stockGridView.Columns[4].DataPropertyName = "addOrSubtractItem";
            stockGridView.DataSource = dt;

            //add new column to Datatable
            dt.Columns.Add("addOrSubtractItem", typeof(int));
            foreach (DataRow dr in dt.Rows) {
                dr["addOrSubtractItem"] = 0;
            }
        }

        private void populateSummaryDataGridView() {
            con.Open();
            SqlCommand cm = new SqlCommand("SELECT * FROM FullSummary");
            cm.Connection = con;

            SqlDataAdapter da = new SqlDataAdapter(cm);
            DataTable dt = new DataTable();
            da.Fill(dt);
            summaryGridView.AutoGenerateColumns = false;
            summaryGridView.Columns[0].DataPropertyName = "Name";
            summaryGridView.Columns[1].DataPropertyName = "Type";
            summaryGridView.Columns[2].DataPropertyName = "Price";
            summaryGridView.Columns[3].DataPropertyName = "Quantity";
            summaryGridView.Columns[4].DataPropertyName = "Total";
            summaryGridView.Columns[5].DataPropertyName = "DateAndTime";
            summaryGridView.Columns[5].DefaultCellStyle.Format = "dddd, MMMM dd, yyyy hh:mm tt";

            summaryGridView.DataSource = dt;
            con.Close();
        }

        void quantity_change(int n) {
            var row = stockGridView.CurrentRow;
            var itemsAddedOrSubtracted = Convert.ToInt32(row.Cells["addOrSubtractItem"].Value) + n;
            row.Cells["addOrSubtractItem"].Value = itemsAddedOrSubtracted; //The ["Quantity"] here is found in -> right click datagridview -> edit columns -> column property (Name). This is used to select the quantity of the selected row.

            //var price = Convert.ToDouble(row.Cells["Price"].Value);
            //row.Cells["Total"].Value = quantity * price;

            var newQty = (Convert.ToInt32(row.Cells["Quantity"].Value) + Convert.ToInt32(row.Cells["addOrSubtractItem"].Value));
            newQuantity.Text = newQty.ToString();
            newTotal.Text = (Convert.ToDouble(row.Cells["Price"].Value) * newQty).ToString();
        }

        protected override void WndProc(ref Message m) {
            if (m.Msg == 0x84) {
                Point pos = new Point(m.LParam.ToInt32());
                pos = this.PointToClient(pos);

                if (pos.Y < cCaption) {
                    m.Result = (IntPtr)2;
                    return;
                }

                if (pos.X >= this.ClientSize.Width - cGrip && pos.Y >= this.ClientSize.Height - cGrip) {
                    m.Result = (IntPtr)17;
                    return;
                }
            }
            base.WndProc(ref m);
        }

        //////////////////////////////////////////////////////////////////////

        private void Main_MouseMove(object sender, MouseEventArgs e) {
            if (mov == 1) {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
            }
        }

        private void Main_MouseDown(object sender, MouseEventArgs e) {
            mov = 1;
            movX = e.X;
            movY = e.Y;
        }

        private void Main_MouseUp(object sender, MouseEventArgs e) {
            mov = 0;
        }
        private void minimize_Click(object sender, EventArgs e) {
            this.WindowState = FormWindowState.Minimized;
        }

        private void maximize_Click(object sender, EventArgs e) {
            this.WindowState = FormWindowState.Maximized;
        }

        private void close_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void addPanel_MouseHover(object sender, EventArgs e) {
            addPanel.BackColor = Color.FromArgb(99, 125, 130);
        }

        private void addPanel_MouseLeave(object sender, EventArgs e) {
            addPanel.BackColor = Color.FromArgb(69, 90, 100);
        }

        private void stockPanel_MouseHover(object sender, EventArgs e) {
            stockPanel.BackColor = Color.FromArgb(99, 125, 130);
        }

        private void stockPanel_MouseLeave(object sender, EventArgs e) {
            stockPanel.BackColor = Color.FromArgb(69, 90, 100);
        }

        private void summaryPanel_MouseHover(object sender, EventArgs e) {
            summaryPanel.BackColor = Color.FromArgb(99, 125, 130);
        }


        private void summaryPanel_MouseLeave(object sender, EventArgs e) {
            summaryPanel.BackColor = Color.FromArgb(69, 90, 100);
        }

        private void addPanel_Click(object sender, EventArgs e) {
            mainAddPanel.Location = new Point(locationX, locationY);
            mainAddPanel.Size = new Size(panelWidth, panelHeight);

            mainStockPanel.Location = new Point(279, 12);
            mainStockPanel.Size = new Size(50, 50);

            mainSummaryPanel.Location = new Point(337, 12);
            mainSummaryPanel.Size = new Size(50, 50);

            addRicePanel.Location = new Point(393, 12);
            addRicePanel.Size = new Size(50, 50);

            addItemPanel.Location = new Point(223, 12);
            addItemPanel.Size = new Size(50, 50);
        }

        private void stockPanel_Click(object sender, EventArgs e) {
            populateStockDataGridView();
            mainStockPanel.Location = new Point(locationX, locationY);
            mainStockPanel.Size = new Size(panelWidth, panelHeight);

            mainAddPanel.Location = new Point(448, 12);
            mainAddPanel.Size = new Size(50, 50);

            mainSummaryPanel.Location = new Point(337, 12);
            mainSummaryPanel.Size = new Size(50, 50);

            addRicePanel.Location = new Point(393, 12);
            addRicePanel.Size = new Size(50, 50);

            addItemPanel.Location = new Point(223, 12);
            addItemPanel.Size = new Size(50, 50);
        }

        private void summaryPanel_Click(object sender, EventArgs e) {
            //populateSummaryDataGridView();
            mainSummaryPanel.Location = new Point(locationX, locationY);
            mainSummaryPanel.Size = new Size(panelWidth, panelHeight);

            mainStockPanel.Location = new Point(279, 12);
            mainStockPanel.Size = new Size(50, 50);

            mainAddPanel.Location = new Point(448, 12);
            mainAddPanel.Size = new Size(50, 50);

            addRicePanel.Location = new Point(393, 12);
            addRicePanel.Size = new Size(50, 50);

            addItemPanel.Location = new Point(223, 12);
            addItemPanel.Size = new Size(50, 50);
        }

        private void addRicePanelbtn_Click(object sender, EventArgs e) {
            addRicePanel.Location = new Point(locationX, locationY);
            addRicePanel.Size = new Size(panelWidth, panelHeight);

            mainSummaryPanel.Location = new Point(337, 12);
            mainSummaryPanel.Size = new Size(50, 50);

            mainStockPanel.Location = new Point(279, 12);
            mainStockPanel.Size = new Size(50, 50);

            mainAddPanel.Location = new Point(448, 12);
            mainAddPanel.Size = new Size(50, 50);

            addItemPanel.Location = new Point(223, 12);
            addItemPanel.Size = new Size(50, 50);
        }

        private void addItemPanelbtn_Click(object sender, EventArgs e) {
            addItemPanel.Location = new Point(locationX, locationY);
            addItemPanel.Size = new Size(panelWidth, panelHeight);

            mainSummaryPanel.Location = new Point(337, 12);
            mainSummaryPanel.Size = new Size(50, 50);

            mainStockPanel.Location = new Point(279, 12);
            mainStockPanel.Size = new Size(50, 50);

            mainAddPanel.Location = new Point(448, 12);
            mainAddPanel.Size = new Size(50, 50);

            addRicePanel.Location = new Point(393, 12);
            addRicePanel.Size = new Size(50, 50);
        }

        private void addRiceClassBtn_Click(object sender, EventArgs e) {
            if (String.IsNullOrEmpty(addRiceTextBox.Text) || String.IsNullOrEmpty(addPriceTextBox.Text)) {
                MessageBox.Show("Can't add empty string!", "!");
            }
            else {

                SqlDataAdapter sda = new SqlDataAdapter("SELECT RiceClass FROM RiceClassPreview WHERE RiceClass = '" + addRiceTextBox.Text + "'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows.Count >= 1) {
                    MessageBox.Show("Rice Class Already Exists!", "!");
                }
                else {
                    DialogResult dialog = MessageBox.Show("Do you want to add " + addRiceTextBox.Text + " worth ₱" + addPriceTextBox.Text + "?", "Continue Process?", MessageBoxButtons.YesNo);
                    if (dialog == DialogResult.Yes) {
                        con.Open();
                        // Auto increment Id to avoid error (Id properties -> Identity Specification (set to TRUE))
                        SqlCommand cmd = new SqlCommand("INSERT INTO RiceClassPreview VALUES (@RiceClass, @Price)", con);
                        cmd.Parameters.AddWithValue("@RiceClass", addRiceTextBox.Text);
                        cmd.Parameters.AddWithValue("@Price", addPriceTextBox.Text);
                        cmd.ExecuteNonQuery();
                        con.Close();

                        dropdownRefresh();

                        MessageBox.Show(addRiceTextBox.Text + " Added! Check the dropdown.", "!");
                    }
                }
            }
        }


        private void removeRiceClassBtn_Click(object sender, EventArgs e) {
            if (riceComboBoxPreview.Items.Count > 0 && !(String.IsNullOrEmpty(riceComboBoxPreview.Text))) {
                DialogResult dialog = MessageBox.Show("Do you want to delete " + riceComboBoxPreview.Text + " ?", "Continue Process?", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes) {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "DELETE FROM RiceClassPreview WHERE RiceClass='" + riceComboBoxPreview.Text + "'";
                    cmd.ExecuteNonQuery();
                    con.Close();
                    dropdownRefresh();

                    MessageBox.Show(riceComboBoxPreview.Text + " Deleted!", "!");

                    riceComboBoxPreview.Text = "";
                    addRiceTextBox.Text = "";
                    addPriceTextBox.Text = "";
                }
            }
            else {
                MessageBox.Show("No item selected!");
            }
        }

        private void riceComboBox_TextChanged(object sender, EventArgs e) {
            //Check if Rice (from the dropdown is in the database)
            if (String.IsNullOrEmpty(riceComboBox.Text)) {
                riceClassIndicator.Text = "0";
            }
            else {
                SqlDataAdapter sda = new SqlDataAdapter("SELECT RiceClass FROM RiceClassPreview WHERE RiceClass = '" + riceComboBox.Text + "'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows.Count >= 1) {
                    riceClassIndicator.Text = "1";
                }
                else {
                    riceClassIndicator.Text = "0";
                }
            }
        }

        private void saveBtn_Click(object sender, EventArgs e) {
            if (riceClassIndicator.Text != "1" || String.IsNullOrEmpty(riceComboBox.Text) || String.IsNullOrEmpty(quantityTextBox.Text)) {
                MessageBox.Show("Fill up all fields correctly!", "!");
            }
            else {
                SqlDataAdapter sda = new SqlDataAdapter("SELECT Name FROM Stock WHERE Name = '" + riceComboBox.Text + "'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows.Count >= 1) {
                    MessageBox.Show(riceComboBox.Text + " Already Exists! Increase its quantity on the STOCK page!", "!");
                }
                else {
                    DialogResult dialog = MessageBox.Show("Do you want to add " + quantityTextBox.Text + " " + riceComboBox.Text + "/s ?", "Continue Process?", MessageBoxButtons.YesNo);
                    if (dialog == DialogResult.Yes) {
                        //(@Name1, @Price1, @Total1, @Quantity1) and (@Name2, @Price2, @Total2, @Quantity2) because variable names must be unique within a query batch or stored procedure
                        SqlCommand cmd = new SqlCommand("INSERT INTO FullSummary VALUES (@Name1, @Price1, @Quantity1, @Type1, @Total1, @DateAndTime1)", con);
                        con.Open();
                        // Auto increment Id to avoid error (Id properties -> Identity Specification (set to TRUE))
                        cmd.Parameters.AddWithValue("@Name1", riceComboBox.Text);
                        cmd.Parameters.AddWithValue("@Price1", priceValue.Text);
                        cmd.Parameters.AddWithValue("@Quantity1", quantityTextBox.Text);
                        cmd.Parameters.AddWithValue("@Type1", "Added");
                        cmd.Parameters.AddWithValue("@Total1", totalValue.Text);
                        cmd.Parameters.AddWithValue("@DateAndTime1", Convert.ToDateTime(DateTime.Now.ToLongTimeString()));
                        cmd.ExecuteNonQuery();
                        con.Close();

                        con.Open();
                        cmd.CommandText = "INSERT INTO Stock VALUES (@Name2, @Price2, @Total2, @Quantity2)";
                        cmd.Parameters.AddWithValue("@Name2", riceComboBox.Text);
                        cmd.Parameters.AddWithValue("@Price2", priceValue.Text);
                        cmd.Parameters.AddWithValue("@Total2", totalValue.Text);
                        cmd.Parameters.AddWithValue("@Quantity2", quantityTextBox.Text);
                        cmd.ExecuteNonQuery();
                        con.Close();

                        dropdownRefresh();
                        MessageBox.Show(quantityTextBox.Text + " " + riceComboBox.Text + "/s Addded!", ":)");
                    }
                }
            }
        }

        private void quantityTextBox_KeyPress(object sender, KeyPressEventArgs e) {
            char ch = e.KeyChar;
            if (ch == 46 && quantityTextBox.Text.IndexOf(".") != -1) {
                e.Handled = true;
                return;
            }

            if (!Char.IsDigit(ch) && ch != 8 && ch != 46) {
                e.Handled = true;
            }
        }

        private void quantityTextBox_KeyUp(object sender, KeyEventArgs e) {
            float num1, num2, sum;
            num1 = String.IsNullOrEmpty(priceValue.Text) ? 0 : float.Parse(priceValue.Text);
            num2 = String.IsNullOrEmpty(quantityTextBox.Text) ? 0 : float.Parse(quantityTextBox.Text);
            sum = num1 * num2;
            totalValue.Text = sum.ToString();
        }

        private void riceComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            //priceValue.Text = "0";
            quantityTextBox.Text = "";

            //Check If RiceClass exists then Display its PRICE
            SqlDataAdapter sda = new SqlDataAdapter("SELECT RiceClass FROM RiceClassPreview WHERE RiceClass = '" + riceComboBox.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (dt.Rows.Count >= 1) {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT Price FROM RiceClassPreview WHERE RiceClass = '" + riceComboBox.Text + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read()) {
                    priceValue.Text = dr.GetValue(dr.GetOrdinal("Price")).ToString();
                }
                con.Close();
            }
            else {
                priceValue.Text = "0";
            }
            ///////////////////////////////////////////////////
        }

        private void addPriceTextBox_KeyPress(object sender, KeyPressEventArgs e) {
            char ch = e.KeyChar;
            if (ch == 46 && addPriceTextBox.Text.IndexOf(".") != -1) {
                e.Handled = true;
                return;
            }

            if (!Char.IsDigit(ch) && ch != 8 && ch != 46) {
                e.Handled = true;
            }
        }

        private void editRiceClassBtn_Click(object sender, EventArgs e) {
            if (String.IsNullOrEmpty(addRiceTextBox.Text) || String.IsNullOrEmpty(addPriceTextBox.Text)) {
                MessageBox.Show("Can't add empty string!", "!");
            }
            else {
                DialogResult dialog = MessageBox.Show("Do you want to Update " + riceComboBoxPreview.Text + " ?", "Continue Process?", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes) {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    //for the Dropdown
                    con.Open();
                    cmd.CommandText = "UPDATE RiceClassPreview SET RiceClass='" + addRiceTextBox.Text + "', Price='" + addPriceTextBox.Text + "' WHERE RiceClass='" + riceComboBoxPreview.Text + "'";
                    cmd.ExecuteNonQuery();
                    con.Close();

                    //for the Full Summary
                    con.Open();
                    cmd.CommandText = "UPDATE FullSummary SET Name='" + addRiceTextBox.Text + "', Price='" + addPriceTextBox.Text + "' WHERE Name='" + riceComboBoxPreview.Text + "'";
                    cmd.ExecuteNonQuery();
                    con.Close();

                    //for the Stock
                    con.Open();
                    cmd.CommandText = "UPDATE Stock SET Name='" + addRiceTextBox.Text + "', Price='" + addPriceTextBox.Text + "' WHERE Name='" + riceComboBoxPreview.Text + "'";
                    cmd.ExecuteNonQuery();
                    con.Close();
                    dropdownRefresh();
                    MessageBox.Show(riceComboBoxPreview.Text + " Updated to " + addRiceTextBox.Text, "!");
                    riceComboBoxPreview.Text = addRiceTextBox.Text;
                }
            }
        }

        private void riceComboBoxPreview_SelectedIndexChanged(object sender, EventArgs e) {
            SqlDataAdapter sda = new SqlDataAdapter("SELECT RiceClass FROM RiceClassPreview WHERE RiceClass = '" + riceComboBoxPreview.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (dt.Rows.Count >= 1) {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT Price FROM RiceClassPreview WHERE RiceClass = '" + riceComboBoxPreview.Text + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read()) {
                    addRiceTextBox.Text = riceComboBoxPreview.Text;
                    addPriceTextBox.Text = dr.GetValue(dr.GetOrdinal("Price")).ToString();
                }
                con.Close();
            }
            else {
                addPriceTextBox.Text = "0";
            }
        }

        /*  void quantity_change(int n) {
            var row = stockGridView.CurrentRow;
            var quantity = Convert.ToInt32(row.Cells["Quantity"].Value) + n;
            row.Cells["Quantity"].Value = quantity;

            var price = Convert.ToDouble(row.Cells["Price"].Value);
            row.Cells["Total"].Value = quantity * price;
        }
         */
        private void stockGridView_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            if (stockGridView.Columns[e.ColumnIndex].Name == "Add" && e.RowIndex >= 0) {
                quantity_change(1);
            }


            if (stockGridView.Columns[e.ColumnIndex].Name == "Subtract" && e.RowIndex >= 0) {
                quantity_change(-1);
            }

            if (stockGridView.Columns[e.ColumnIndex].Name == "Save" && e.RowIndex >= 0) {
                //save changes for price and quantity

                var row = stockGridView.CurrentRow;
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                DialogResult dialog = MessageBox.Show("Do you want to update " + row.Cells["RiceClass"].Value + " ?", "Continue Process?", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes) {
                    //for the Stock
                    con.Open();

                    //"UPDATE Stock SET Quantity='" + Convert.ToDouble(newQuantity.Text) + "', Total='" + Convert.ToInt32(newTotal.Text) + "' WHERE Name='" + row.Cells["RiceClass"].Value + "'"
                    cmd.CommandText = "UPDATE Stock SET Quantity='" + Convert.ToDouble(row.Cells["Quantity"].Value) + "', Total='" + Convert.ToInt32(row.Cells["Total"].Value) + "' WHERE Name='" + row.Cells["RiceClass"].Value + "'";
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                populateStockDataGridView();
            }
        }

        private void stockGridView_CellClick(object sender, DataGridViewCellEventArgs e) {

        }


    }
}
