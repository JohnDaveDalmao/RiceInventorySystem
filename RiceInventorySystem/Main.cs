using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RiceInventorySystem;

//STOCK size: 1134, 615 // Location: 166, 39
//Stock dgv: 870, 503
/*riceComboBox
 * quantityTextBox
 * riceComboBoxPreview
 * addRiceTextBox
 * addPriceTextBox
 */
namespace RiceInventorySystem {
    public partial class Main : Form {

        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SystemDatabaseConnection"].ConnectionString); // This is set in App.config

        private const int cGrip = 16;
        private const int cCaption = 32;

        int mov, movX, movY;
        int panelWidth = 1134, panelHeight = 615;
        int locationX = 166, locationY = 39;
        string loadAllSummaryData = "SELECT * FROM FullSummary ORDER BY DateAndTime DESC";
        string primarySidePanelBtn = "#455A64";
        string secondarySidePanelBtn = "#637D82";

        // If dropdown item (in add item to stock) is selected -> price * quantity.text

        #region Main
        public Main() {
            InitializeComponent();
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            DataTable dt = new DataTable();
            DataColumn newColumn = new DataColumn("addOrSubtractItem", typeof(System.String));
            newColumn.DefaultValue = "Your DropDownList value";
            dt.Columns.Add(newColumn);
        }

        private void Main_Load(object sender, EventArgs e) {
            dropdownRefresh();
            populateStockDataGridView();
            populateSummaryDataGridView(loadAllSummaryData);

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
        }
        #endregion

        #region functions
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

            //add new column to DataGridView
            dt.Columns.Add("addOrSubtractItem", typeof(int));
            foreach (DataRow dr in dt.Rows) {
                dr["addOrSubtractItem"] = 0;
            }
        }

        private void populateSummaryDataGridView(string sqlCommandString) {
            con.Open();
            SqlCommand cm = new SqlCommand(sqlCommandString);
            cm.Connection = con;

            SqlDataAdapter da = new SqlDataAdapter(cm);
            DataTable dt = new DataTable();
            da.Fill(dt);
            summaryGridView.AutoGenerateColumns = false;
            summaryGridView.Columns[0].DataPropertyName = "Name";
            summaryGridView.Columns[1].DataPropertyName = "Price";
            summaryGridView.Columns[2].DataPropertyName = "Quantity";
            summaryGridView.Columns[3].DataPropertyName = "Total";
            summaryGridView.Columns[4].DataPropertyName = "Type";
            summaryGridView.Columns[5].DataPropertyName = "DateAndTime";
            summaryGridView.Columns[5].DefaultCellStyle.Format = "dddd, MMMM dd, yyyy hh:mm tt";

            summaryGridView.DataSource = dt;
            con.Close();
        }

        void quantity_change(int n) {
            var row = stockGridView.CurrentRow;
            var itemsAddedOrSubtracted = Convert.ToInt32(row.Cells["addOrSubtractItem"].Value) + n;

            row.Cells["addOrSubtractItem"].Value = itemsAddedOrSubtracted; //The ["Quantity"] here is found in -> right click datagridview -> edit columns -> column property (Name). This is used to select the quantity of the selected row.
            var newQty = (Convert.ToInt32(row.Cells["Quantity"].Value) + Convert.ToInt32(row.Cells["addOrSubtractItem"].Value));
            newQuantity.Text = newQty.ToString();
            newTotal.Text = (Convert.ToDouble(row.Cells["Price"].Value) * newQty).ToString();
        }

        public void ConvertDataToPDF(iTextSharp.text.Rectangle pageSize) {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "PDF (*.pdf)|*.pdf";
            sfd.FileName = "Full Summary.pdf";
            bool fileError = false;
            if (sfd.ShowDialog() == DialogResult.OK) {
                if (File.Exists(sfd.FileName)) {
                    try {
                        File.Delete(sfd.FileName);
                    }
                    catch (IOException ex) {
                        fileError = true;
                        MessageBox.Show("It wasn't possible to write the data to the disk." + ex.Message);
                    }
                }
                if (!fileError) {
                    try {

                        PdfPTable pdfTable = new PdfPTable(summaryGridView.Columns.Count);
                        //pdfTable.DefaultCell.Padding = 12;
                        pdfTable.DefaultCell.PaddingTop = 8;
                        pdfTable.DefaultCell.PaddingRight = 4;
                        pdfTable.DefaultCell.PaddingBottom = 8;
                        pdfTable.DefaultCell.PaddingLeft = 4;

                        pdfTable.WidthPercentage = 100;
                        pdfTable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        pdfTable.DefaultCell.VerticalAlignment = Element.ALIGN_MIDDLE;

                        pdfTable.HeaderRows = 1; // add datagridview header every new page in pdf
                        foreach (DataGridViewColumn column in summaryGridView.Columns) { // HEADER
                            var FontStyle = FontFactory.GetFont("Arial Rounded MT", 15, new BaseColor(245, 245, 245));
                            FontStyle.SetStyle(1); //Style "1" = BOLD

                            PdfPCell cell = new PdfPCell(new Paragraph(new Chunk(column.HeaderText, FontStyle))) {
                                BackgroundColor = new BaseColor(69, 90, 100),
                                HorizontalAlignment = Element.ALIGN_CENTER,
                                VerticalAlignment = Element.ALIGN_MIDDLE,
                                FixedHeight = 50f,
                            };
                            pdfTable.AddCell(cell);
                        }

                        foreach (DataGridViewRow row in summaryGridView.Rows) {
                            foreach (DataGridViewCell cell in row.Cells) {
                                pdfTable.AddCell(cell.FormattedValue.ToString());
                            }
                        }

                        using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create)) {
                            /*Short Bondpaper size or size = LETTER
                             8.5 inch x 72 points = 612 user units
                             12 inch x 72 points = 861 user units*/
                            // iTextSharp.text.Rectangle pagesize = new iTextSharp.text.Rectangle(612, 861);
                            //Document pdfDoc = new Document(PageSize.LETTER.Rotate(), 60f, 60f, 75f, 60f);
                            //Document pdfDoc = new Document(iTextSharp.text.PageSize.LETTER, 60f, 60f, 75f, 60f); //right, left, top, bot
                            Document pdfDoc = new Document(pageSize, 60f, 60f, 75f, 60f);

                            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                            writer.PageEvent = new HeaderAndFooter();
                            pdfDoc.Open();
                            pdfDoc.Add(pdfTable);
                            pdfDoc.Close();
                            stream.Close();
                        }

                        MessageBox.Show("Data Exported Successfully !!!", "Info");
                    }
                    catch (Exception ex) {
                        MessageBox.Show("Error :" + ex.Message);
                    }
                }
            }
        }

        private void resetTextBoxes() {
            riceComboBox.Text = "";
            quantityTextBox.Text = "";
            riceComboBoxPreview.Text = "";
            addRiceTextBox.Text = "";
            addPriceTextBox.Text = "";

            newQuantity.Text = "0";
            newTotal.Text = "0";
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
        #endregion

        #region move form
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
        #endregion

        #region min, max, close btns
        private void minimize_Click(object sender, EventArgs e) {
            this.WindowState = FormWindowState.Minimized;
        }

        private void maximize_Click(object sender, EventArgs e) {
            this.WindowState = FormWindowState.Maximized;
        }

        private void close_Click(object sender, EventArgs e) {
            Application.Exit();
        }
        #endregion

        #region side panel colors
        private void addPanel_MouseHover(object sender, EventArgs e) {
            addPanel.BackColor = ColorTranslator.FromHtml(secondarySidePanelBtn);
        }

        private void addPanel_MouseLeave(object sender, EventArgs e) {
            addPanel.BackColor = ColorTranslator.FromHtml(primarySidePanelBtn);
        }

        private void stockPanel_MouseHover(object sender, EventArgs e) {
            stockPanel.BackColor = ColorTranslator.FromHtml(secondarySidePanelBtn);
        }

        private void stockPanel_MouseLeave(object sender, EventArgs e) {
            stockPanel.BackColor = ColorTranslator.FromHtml(primarySidePanelBtn);
        }

        private void summaryPanel_MouseHover(object sender, EventArgs e) {
            summaryPanel.BackColor = ColorTranslator.FromHtml(secondarySidePanelBtn);
        }

        private void summaryPanel_MouseLeave(object sender, EventArgs e) {
            summaryPanel.BackColor = ColorTranslator.FromHtml(primarySidePanelBtn);
        }

        #endregion

        #region main panels click event
        private void addPanel_Click(object sender, EventArgs e) {
            resetTextBoxes();
            mainAddPanel.Location = new Point(locationX, locationY);
            mainAddPanel.Size = new Size(panelWidth, panelHeight);

            mainAddPanel.Visible = true;
            mainStockPanel.Visible = false;
            mainSummaryPanel.Visible = false;
            addRicePanel.Visible = false;
            addItemPanel.Visible = false;
        }

        private void stockPanel_Click(object sender, EventArgs e) {
            populateStockDataGridView();
            resetTextBoxes();
            mainStockPanel.Location = new Point(locationX, locationY);
            mainStockPanel.Size = new Size(panelWidth, panelHeight);

            mainStockPanel.Visible = true;
            mainAddPanel.Visible = false;
            mainSummaryPanel.Visible = false;
            addRicePanel.Visible = false;
            addItemPanel.Visible = false;
        }

        private void summaryPanel_Click(object sender, EventArgs e) {
            populateSummaryDataGridView(loadAllSummaryData);
            resetTextBoxes();
            mainSummaryPanel.Location = new Point(locationX, locationY);
            mainSummaryPanel.Size = new Size(panelWidth, panelHeight);

            mainSummaryPanel.Visible = true;
            mainAddPanel.Visible = false;
            mainStockPanel.Visible = false;
            addRicePanel.Visible = false;
            addItemPanel.Visible = false;
        }

        private void addRicePanelbtn_Click(object sender, EventArgs e) {
            addRicePanel.Location = new Point(locationX, locationY);
            addRicePanel.Size = new Size(panelWidth, panelHeight);

            addRicePanel.Visible = true;
            mainAddPanel.Visible = false;
            mainStockPanel.Visible = false;
            mainSummaryPanel.Visible = false;
            addItemPanel.Visible = false;
        }

        private void addItemPanelbtn_Click(object sender, EventArgs e) {
            addItemPanel.Location = new Point(locationX, locationY);
            addItemPanel.Size = new Size(panelWidth, panelHeight);

            addItemPanel.Visible = true;
            mainAddPanel.Visible = false;
            mainStockPanel.Visible = false;
            mainSummaryPanel.Visible = false;
            addRicePanel.Visible = false;
        }
        #endregion

        #region addRicePanel: INSERT, UPDATE, DELETE btns
        private void addRiceClassBtn_Click(object sender, EventArgs e) {
            if (String.IsNullOrEmpty(addRiceTextBox.Text) || String.IsNullOrEmpty(addPriceTextBox.Text)) {
                MessageBox.Show("Can't add empty strinsssssssssssg!", "!");
            }
            else {
                SqlDataAdapter sda = new SqlDataAdapter("SELECT RiceClass FROM RiceClassPreview WHERE RiceClass = @RiceClass", con);
                sda.SelectCommand.Parameters.AddWithValue("@riceClass", addRiceTextBox.Text); //Parameterized query for SqlDataAdapter
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

        private void editRiceClassBtn_Click(object sender, EventArgs e) {
            if (String.IsNullOrEmpty(addRiceTextBox.Text) || String.IsNullOrEmpty(addPriceTextBox.Text) || String.IsNullOrEmpty(riceComboBoxPreview.Text)) {
                MessageBox.Show("Can't add empty string!", "!");
            }
            else {
                DialogResult dialog = MessageBox.Show("Do you want to Update " + riceComboBoxPreview.Text + " ?", "Continue Process?", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes) {

                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;

                    SqlDataAdapter sda = new SqlDataAdapter("SELECT Name FROM Stock WHERE Name = @Name", con);
                    sda.SelectCommand.Parameters.AddWithValue("@Name", riceComboBoxPreview.Text); //Parameterized query for SqlDataAdapter
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    //Parameters
                    cmd.Parameters.AddWithValue("@initialName", riceComboBoxPreview.Text);
                    cmd.Parameters.AddWithValue("@name", addRiceTextBox.Text);
                    cmd.Parameters.AddWithValue("@price", addPriceTextBox.Text);
                    cmd.Parameters.AddWithValue("@total", newTotalEdit.Text);

                    //if riceComboBoxPreview.Text exists in Stock database:
                    if (dt.Rows.Count >= 1) {
                        //Parameterized UPDATE

                        //for the Dropdown
                        con.Open();
                        cmd.CommandText = "UPDATE RiceClassPreview SET RiceClass = @name, Price = @price WHERE RiceClass = @initialName";
                        cmd.ExecuteNonQuery();
                        con.Close();

                        //for the Stock
                        con.Open();
                        cmd.CommandText = "UPDATE Stock SET Name = @name, Price = @price, Total = @total WHERE Name = @initialName";
                        cmd.ExecuteNonQuery();
                        con.Close();

                        //for the Full Summary
                        con.Open();
                        cmd.CommandText = "UPDATE FullSummary SET Name = @name, Price = @price, Total = @total WHERE Id = (select max(ID) from FullSummary where Name = @initialName)";
                        cmd.ExecuteNonQuery();
                        con.Close();

                    }
                    else {
                        //for the Dropdown
                        con.Open();
                        cmd.CommandText = "UPDATE RiceClassPreview SET RiceClass = @name, Price = @price WHERE RiceClass = @initialName";
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    dropdownRefresh();
                    MessageBox.Show(riceComboBoxPreview.Text + " Updated to " + addRiceTextBox.Text, "!");
                    riceComboBoxPreview.Text = addRiceTextBox.Text;
                }
            }
        }

        private void removeRiceClassBtn_Click(object sender, EventArgs e) {
            if (riceComboBoxPreview.Items.Count > 0 && !(String.IsNullOrEmpty(riceComboBoxPreview.Text))) {
                DialogResult dialog = MessageBox.Show("Do you want to delete " + riceComboBoxPreview.Text + " ?", "Continue Process?", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes) {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;

                    SqlDataAdapter sda = new SqlDataAdapter("SELECT Name FROM Stock WHERE Name = @Name", con);
                    sda.SelectCommand.Parameters.AddWithValue("@Name", addRiceTextBox.Text); //Parameterized query for SqlDataAdapter
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    //Parameters
                    cmd.Parameters.AddWithValue("@RiceClass", riceComboBoxPreview.Text);
                    cmd.Parameters.AddWithValue("@Name", addRiceTextBox.Text);

                    //for stock
                    if (dt.Rows.Count >= 1) {
                        con.Open();
                        cmd.CommandText = "DELETE FROM Stock WHERE Name = @Name";
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }

                    //for the Dropdown
                    con.Open();
                    cmd.CommandText = "DELETE FROM RiceClassPreview WHERE RiceClass = @RiceClass";
                    cmd.ExecuteNonQuery();
                    con.Close();

                    dropdownRefresh();
                    riceComboBoxPreview.Text = "";
                    addRiceTextBox.Text = "";
                    addPriceTextBox.Text = "";
                    MessageBox.Show(riceComboBoxPreview.Text + " Deleted!", "!");
                }
            }

            else {
                MessageBox.Show("No item selected!");
            }
        }
        #endregion

        #region addRicePanel
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

        private void addPriceTextBox_KeyUp(object sender, KeyEventArgs e) {
            float num1, num2, product;
            num1 = String.IsNullOrEmpty(recentQuantity.Text) ? 0 : float.Parse(recentQuantity.Text);
            num2 = String.IsNullOrEmpty(addPriceTextBox.Text) ? 0 : float.Parse(addPriceTextBox.Text);
            product = num1 * num2;
            newTotalEdit.Text = product.ToString();
        }

        private void riceComboBoxPreview_SelectedIndexChanged(object sender, EventArgs e) {
            SqlDataAdapter sda1 = new SqlDataAdapter("SELECT RiceClass FROM RiceClassPreview WHERE RiceClass = @RiceClass", con);
            sda1.SelectCommand.Parameters.AddWithValue("@RiceClass", riceComboBoxPreview.Text); //Parameterized query for SqlDataAdapter
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);

            if (dt1.Rows.Count >= 1) {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT Price FROM RiceClassPreview WHERE RiceClass = @RiceClass", con);
                cmd.Parameters.AddWithValue("@RiceClass", riceComboBoxPreview.Text);
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

            SqlDataAdapter sda2 = new SqlDataAdapter("SELECT Name FROM Stock WHERE Name = @Name", con);
            sda2.SelectCommand.Parameters.AddWithValue("@Name", riceComboBoxPreview.Text); //Parameterized query for SqlDataAdapter
            DataTable dt2 = new DataTable();
            sda2.Fill(dt2);
            if (dt2.Rows.Count >= 1) {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT Quantity FROM Stock WHERE Name = @Name", con);
                cmd.Parameters.AddWithValue("@Name", riceComboBoxPreview.Text);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read()) {
                    recentQuantity.Text = dr.GetValue(dr.GetOrdinal("Quantity")).ToString();
                }
                con.Close();
            }
            else {
                recentQuantity.Text = "0";
            }
            newTotalEdit.Text = (Convert.ToInt32(recentQuantity.Text) * Convert.ToInt32(addPriceTextBox.Text)).ToString();
        }
        #endregion

        #region addItemPanel Textboxes and btn

        private void riceComboBox_TextChanged(object sender, EventArgs e) {
            //This is needed so thee user can only input valid rice class
            //Check if Rice (from the dropdown is in the database)
            //This is located in addItemPanel
            riceClassIndicator.Visible = true;
            if (String.IsNullOrEmpty(riceComboBox.Text)) {
                riceClassIndicator.Text = "0";
            }
            else {
                SqlDataAdapter sda = new SqlDataAdapter("SELECT RiceClass FROM RiceClassPreview WHERE RiceClass = @RiceClass", con);
                sda.SelectCommand.Parameters.AddWithValue("@RiceClass", riceComboBox.Text); //Parameterized query for SqlDataAdapter
                DataTable dt = new DataTable();
                sda.Fill(dt);
                _ = (dt.Rows.Count >= 1) ? riceClassIndicator.Text = "1" : riceClassIndicator.Text = "0";
            }
        }

        private void saveBtn_Click(object sender, EventArgs e) {
            if (riceClassIndicator.Text != "1" || String.IsNullOrEmpty(riceComboBox.Text) || String.IsNullOrEmpty(quantityTextBox.Text)) {
                MessageBox.Show("Fill up all fields correctly!", "!");
            }
            else {
                SqlDataAdapter sda = new SqlDataAdapter("SELECT Name FROM Stock WHERE Name = @Name", con);
                sda.SelectCommand.Parameters.AddWithValue("@Name", riceComboBox.Text); //Parameterized query for SqlDataAdapter
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows.Count >= 1) {
                    MessageBox.Show(riceComboBox.Text + " Already Exists! Increase its quantity on the STOCK page!", "!");
                }
                else {
                    DialogResult dialog = MessageBox.Show("Do you want to add " + quantityTextBox.Text + " " + riceComboBox.Text + "/s ?", "Continue Process?", MessageBoxButtons.YesNo);
                    if (dialog == DialogResult.Yes) {
                        SqlCommand cmd = con.CreateCommand();
                        cmd.CommandType = CommandType.Text;

                        // Parameters
                        // Auto increment Id to avoid error (Id properties -> Identity Specification (set to TRUE))
                        cmd.Parameters.AddWithValue("@Name", riceComboBox.Text);
                        cmd.Parameters.AddWithValue("@Price", Convert.ToDouble(priceValue.Text));
                        cmd.Parameters.AddWithValue("@Quantity", Convert.ToInt32(quantityTextBox.Text));
                        cmd.Parameters.AddWithValue("@Type", "Added");
                        cmd.Parameters.AddWithValue("@Total", Convert.ToDouble(totalValue.Text));
                        cmd.Parameters.AddWithValue("@DateAndTime", Convert.ToDateTime(DateTime.Now.ToLongTimeString()));

                        //For FullSummary
                        con.Open();
                        cmd.CommandText = "INSERT INTO FullSummary VALUES (@Name, @Price, @Quantity, @Type, @Total, @DateAndTime)";
                        cmd.ExecuteNonQuery();
                        con.Close();

                        //For Stock
                        con.Open();
                        cmd.CommandText = "INSERT INTO Stock VALUES (@Name, @Price, @Total, @Quantity)";
                        cmd.ExecuteNonQuery();
                        con.Close();

                        dropdownRefresh();
                        MessageBox.Show(quantityTextBox.Text + " " + riceComboBox.Text + "/s Added!", ":)");
                    }
                }
            }
        }

        //Start Here Later
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
            float num1, num2, product;
            num1 = String.IsNullOrEmpty(priceValue.Text) ? 0 : float.Parse(priceValue.Text);
            num2 = String.IsNullOrEmpty(quantityTextBox.Text) ? 0 : float.Parse(quantityTextBox.Text);
            product = num1 * num2;
            totalValue.Text = product.ToString();
        }

        private void riceComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            //priceValue.Text = "0";
            //quantityTextBox.Text = "";

            //Check If RiceClass exists then Display its PRICE
            SqlDataAdapter sda = new SqlDataAdapter("SELECT RiceClass FROM RiceClassPreview WHERE RiceClass = @RiceClass", con);
            sda.SelectCommand.Parameters.AddWithValue("@RiceClass", riceComboBox.Text); //Parameterized query for SqlDataAdapter
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (dt.Rows.Count >= 1) {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT Price FROM RiceClassPreview WHERE RiceClass = @RiceClass", con);
                cmd.Parameters.AddWithValue("@RiceClass", riceComboBox.Text);
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
        #endregion

        #region mainSummaryPanel btns: LOAD ALL, ADDED, SUBTRACTED, and PRINT
        private void LoadAllData_Click(object sender, EventArgs e) {
            populateSummaryDataGridView(loadAllSummaryData);
        }


        private void AddedData_Click(object sender, EventArgs e) {
            populateSummaryDataGridView("SELECT * FROM FullSummary WHERE Type LIKE 'Added' ORDER BY DateAndTime DESC ");

        }

        private void SubtractedData_Click(object sender, EventArgs e) {
            populateSummaryDataGridView("SELECT * FROM FullSummary WHERE Type LIKE 'Subtracted' ORDER BY DateAndTime DESC ");
        }

        private void printSummaryData_Click(object sender, EventArgs e) {
            if (summaryGridView.Rows.Count > 0) {
                DialogResult dialog = MessageBox.Show("Do you want to print in PORTRAIT MODE?\nSelect no to print in LANDSCAPE MODE!", "PDF Mode", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes) {
                    ConvertDataToPDF(PageSize.LETTER);
                }
                else {
                    DialogResult anotherdialog = MessageBox.Show("Print in LANDSCAPE MODE?", "PDF Mode", MessageBoxButtons.YesNo);
                    if (anotherdialog == DialogResult.Yes) {
                        ConvertDataToPDF(PageSize.LETTER.Rotate());
                    }
                }
            }
            else {
                MessageBox.Show("No Record To Export !!!", "Info");
            }
        }
        #endregion

        #region mainStockPanel
        //how to remember last selected row in a datagridview after a datagridview refresh
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

                if (Convert.ToInt32(row.Cells["addOrSubtractItem"].Value) == 0) {
                    notChanged.Visible = true;
                    Task.Delay(5000).ContinueWith(_ => {
                        Invoke(new MethodInvoker(() => { notChanged.Visible = false; }));
                    });
                }
                else {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    DialogResult dialog = MessageBox.Show("Do you want to update " + row.Cells["RiceClass"].Value + " ?", "Continue Process?", MessageBoxButtons.YesNo);
                    if (dialog == DialogResult.Yes) {

                        //for Stock
                        con.Open();
                        cmd.CommandText = "UPDATE Stock SET Quantity='" + Convert.ToInt32(newQuantity.Text) + "', Total='" + Convert.ToDouble(newTotal.Text) + "' WHERE Name='" + row.Cells["RiceClass"].Value + "'";
                        cmd.ExecuteNonQuery();
                        con.Close();

                        //for summary
                        con.Open();
                        var Type = (Convert.ToInt32(row.Cells["addOrSubtractItem"].Value) < 0) ? "Subtracted" : "Added";
                        SqlCommand cmd2 = new SqlCommand("INSERT INTO FullSummary VALUES (@Name1, @Price1, @Quantity1, @Type1, @Total1, @DateAndTime1)", con);
                        cmd2.Parameters.AddWithValue("@Name1", row.Cells["RiceClass"].Value.ToString());
                        cmd2.Parameters.AddWithValue("@Price1", Convert.ToDouble(row.Cells["Price"].Value));
                        cmd2.Parameters.AddWithValue("@Quantity1", Convert.ToInt32(newQuantity.Text));
                        cmd2.Parameters.AddWithValue("@Type1", Type);
                        cmd2.Parameters.AddWithValue("@Total1", Convert.ToDouble(newTotal.Text));
                        cmd2.Parameters.AddWithValue("@DateAndTime1", Convert.ToDateTime(DateTime.Now.ToLongTimeString()));
                        cmd2.ExecuteNonQuery();
                        con.Close();

                        newQuantity.Text = "0";
                        newTotal.Text = "0";
                        MessageBox.Show(row.Cells["RiceClass"].Value.ToString() + " Saved!", "!");

                        int FirstDisplayedScrollingRowIndex = stockGridView.FirstDisplayedScrollingRowIndex; //Save Current Scroll Index
                        int SelectedRowIndex = 0;
                        if (stockGridView.SelectedRows.Count > 0) {
                            SelectedRowIndex = stockGridView.SelectedRows[0].Index; //Save Current Selected Row Index
                        }
                        populateStockDataGridView(); // Refresh Stock DataGridView
                        if ((FirstDisplayedScrollingRowIndex >= 0) && ((stockGridView.Rows.Count - 1) >= FirstDisplayedScrollingRowIndex)) {
                            stockGridView.FirstDisplayedScrollingRowIndex = FirstDisplayedScrollingRowIndex; //Restore Scroll Index
                        }
                        if ((stockGridView.Rows.Count - 1) >= SelectedRowIndex) {
                            stockGridView.Rows[SelectedRowIndex].Selected = true; //Restore Selected Row
                        }
                    }
                }
            }
        }
        #endregion
    }
}
