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

namespace RiceInventorySystem {
    public partial class Main : Form {

        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SystemDatabaseConnection"].ConnectionString);


        private const int cGrip = 16;
        private const int cCaption = 32;

        int mov;
        int movX;
        int movY;

        public Main() {
            InitializeComponent();
            this.SetStyle(ControlStyles.ResizeRedraw, true);

            this.SetLastColumnWidth();
            this.stockListView.Layout += delegate {
                this.SetLastColumnWidth();
            };

            mainPanel.BackColor = Color.FromArgb(55, 71, 79);
            addPanel.BackColor = Color.FromArgb(69, 90, 100);
            stockPanel.BackColor = Color.FromArgb(69, 90, 100);
            summaryPanel.BackColor = Color.FromArgb(69, 90, 100);

            stockListView.FullRowSelect = true;
            ListViewExtender extender = new ListViewExtender(stockListView);
            // extend 4th column
            ListViewButtonColumn buttonAction = new ListViewButtonColumn(2);
            buttonAction.Click += OnButtonActionClick;
            buttonAction.FixedWidth = true;
            extender.AddColumn(buttonAction);
        }

        private void OnButtonActionClick(object sender, ListViewColumnMouseEventArgs e) {
            MessageBox.Show(this, @"you clicked " + e.SubItem.Text);
        }

        private void Main_Load(object sender, EventArgs e) {
            dropdownRefresh();
            populateListView();
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

        private void populateListView() {
            stockListView.Items.Clear();

            SqlCommand cmd = new SqlCommand("SELECT * FROM FullSummary ORDER BY Name ASC", con);

            try {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read()) {
                    ListViewItem item = new ListViewItem(dr["Name"].ToString());
                    item.SubItems.Add("₱ " + (dr["Price"].ToString()));
                    item.SubItems.Add(dr["Quantity"].ToString());

                    stockListView.Items.Add(item);
                }
                con.Close();

                /*con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                foreach (DataRow dr in dt.Rows) {
                    ListViewItem item = new ListViewItem(dr["Name"].ToString());
                    item.SubItems.Add(dr["Price"].ToString());
                    item.SubItems.Add(dr["Quantity"].ToString());
                    stockListView.Items.Add(item);
                }
                con.Close();*/
            }

            catch (Exception ex) {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

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
            mainAddPanel.Location = new Point(223, 37);
            mainAddPanel.Size = new Size(778, 616);

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
            populateListView();
            mainStockPanel.Location = new Point(223, 37);
            mainStockPanel.Size = new Size(778, 616);

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
            mainSummaryPanel.Location = new Point(223, 37);
            mainSummaryPanel.Size = new Size(778, 616);

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
            addRicePanel.Location = new Point(223, 37);
            addRicePanel.Size = new Size(778, 616);

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
            mainSummaryPanel.Location = new Point(337, 12);
            mainSummaryPanel.Size = new Size(50, 50);

            mainStockPanel.Location = new Point(279, 12);
            mainStockPanel.Size = new Size(50, 50);

            mainAddPanel.Location = new Point(448, 12);
            mainAddPanel.Size = new Size(50, 50);

            addRicePanel.Location = new Point(393, 12);
            addRicePanel.Size = new Size(50, 50);

            addItemPanel.Location = new Point(223, 37);
            addItemPanel.Size = new Size(778, 616);
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

                        MessageBox.Show(addRiceTextBox.Text + " Added!", "!");
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
                DialogResult dialog = MessageBox.Show("Do you want to add " + quantityTextBox.Text + " " + riceComboBox.Text + "/s ?", "Continue Process?", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes) {
                    con.Open();
                    // Auto increment Id to avoid error (Id properties -> Identity Specification (set to TRUE))
                    SqlCommand cmd = new SqlCommand("INSERT INTO FullSummary VALUES (@Name, @Price, @Quantity, @Type, @Total, @DateAndTime)", con);
                    cmd.Parameters.AddWithValue("@Name", riceComboBox.Text);
                    cmd.Parameters.AddWithValue("@Price", priceValue.Text);
                    cmd.Parameters.AddWithValue("@Quantity", quantityTextBox.Text);
                    cmd.Parameters.AddWithValue("@Type", "Added");
                    cmd.Parameters.AddWithValue("@Total", totalValue.Text);
                    cmd.Parameters.AddWithValue("@DateAndTime", Convert.ToDateTime(DateTime.Now.ToLongTimeString()));
                    cmd.ExecuteNonQuery();
                    con.Close();
                    dropdownRefresh();
                    MessageBox.Show(quantityTextBox.Text + " " + riceComboBox.Text + "/s Addded!", ":)");
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
            int num1, num2, sum;
            num1 = String.IsNullOrEmpty(priceValue.Text) ? 0 : Int32.Parse(priceValue.Text);
            num2 = String.IsNullOrEmpty(quantityTextBox.Text) ? 0 : Int32.Parse(quantityTextBox.Text);
            sum = num1 * num2;
            totalValue.Text = sum.ToString();
        }

        private void riceComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            //priceValue.Text = "0";
            quantityTextBox.Text = "";

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
                    //for the dropdown
                    con.Open();
                    cmd.CommandText = "UPDATE RiceClassPreview SET RiceClass='" + addRiceTextBox.Text + "', Price='" + addPriceTextBox.Text + "' WHERE RiceClass='" + riceComboBoxPreview.Text + "'";
                    cmd.ExecuteNonQuery();
                    con.Close();

                    //for the Full Summary
                    con.Open();
                    cmd.CommandText = "UPDATE FullSummary SET Name='" + addRiceTextBox.Text + "', Price='" + addPriceTextBox.Text + "' WHERE Name='" + riceComboBoxPreview.Text + "'";
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

        private void stockListView_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e) {
            //Set Ownerdraw property to true to make this work
            // Fill header background with solid yelloW color.
            e.Graphics.FillRectangle(Brushes.LightGray, e.Bounds);
            // Let ListView draw everything else.
            e.DrawText();
        }
        private void SetLastColumnWidth() {
            //Set Ownerdraw property to true to make this work
            // Force the last ListView column width to occupy all the
            // available space.
            this.stockListView.Columns[this.stockListView.Columns.Count - 1].Width = -2;
        }

        private void stockListView_DrawSubItem(object sender, DrawListViewSubItemEventArgs e) {
            e.DrawText();
        }
    }
}
