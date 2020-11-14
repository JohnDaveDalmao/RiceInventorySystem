﻿namespace RiceInventorySystem {
    partial class Main {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.riceComboBox = new System.Windows.Forms.ComboBox();
            this.quantityTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.saveBtn = new System.Windows.Forms.Button();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.summaryPanel = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label12 = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.stockPanel = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.addPanel = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.addItemPanel = new System.Windows.Forms.Panel();
            this.priceValue = new System.Windows.Forms.Label();
            this.riceClassIndicator = new System.Windows.Forms.Label();
            this.totalValue = new System.Windows.Forms.Label();
            this.mainSummaryPanel = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.close = new System.Windows.Forms.PictureBox();
            this.minimize = new System.Windows.Forms.PictureBox();
            this.mainStockPanel = new System.Windows.Forms.Panel();
            this.stockListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label13 = new System.Windows.Forms.Label();
            this.addRicePanel = new System.Windows.Forms.Panel();
            this.label19 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label17 = new System.Windows.Forms.Label();
            this.editRiceClassBtn = new System.Windows.Forms.Button();
            this.addPriceTextBox = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.addRiceTextBox = new System.Windows.Forms.TextBox();
            this.addRiceClassBtn = new System.Windows.Forms.Button();
            this.removeRiceClassBtn = new System.Windows.Forms.Button();
            this.riceComboBoxPreview = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.mainAddPanel = new System.Windows.Forms.Panel();
            this.addRicePanelbtn = new System.Windows.Forms.Button();
            this.addItemPanelbtn = new System.Windows.Forms.Button();
            this.mainPanel.SuspendLayout();
            this.summaryPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.stockPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.addPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.addItemPanel.SuspendLayout();
            this.mainSummaryPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.close)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minimize)).BeginInit();
            this.mainStockPanel.SuspendLayout();
            this.addRicePanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.mainAddPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // riceComboBox
            // 
            this.riceComboBox.FormattingEnabled = true;
            this.riceComboBox.Items.AddRange(new object[] {
            "Rice A",
            "Rice B",
            "Rice C"});
            this.riceComboBox.Location = new System.Drawing.Point(61, 184);
            this.riceComboBox.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.riceComboBox.Name = "riceComboBox";
            this.riceComboBox.Size = new System.Drawing.Size(242, 30);
            this.riceComboBox.TabIndex = 0;
            this.riceComboBox.SelectedIndexChanged += new System.EventHandler(this.riceComboBox_SelectedIndexChanged);
            this.riceComboBox.TextChanged += new System.EventHandler(this.riceComboBox_TextChanged);
            // 
            // quantityTextBox
            // 
            this.quantityTextBox.Location = new System.Drawing.Point(357, 184);
            this.quantityTextBox.Name = "quantityTextBox";
            this.quantityTextBox.Size = new System.Drawing.Size(155, 29);
            this.quantityTextBox.TabIndex = 1;
            this.quantityTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.quantityTextBox_KeyPress);
            this.quantityTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.quantityTextBox_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 154);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 22);
            this.label1.TabIndex = 3;
            this.label1.Text = "Rice Class";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(353, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 22);
            this.label2.TabIndex = 4;
            this.label2.Text = "Quantity";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(63, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 22);
            this.label3.TabIndex = 5;
            this.label3.Text = "Price: ₱";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(63, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 22);
            this.label4.TabIndex = 7;
            this.label4.Text = "Total: ₱";
            // 
            // saveBtn
            // 
            this.saveBtn.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveBtn.Location = new System.Drawing.Point(577, 173);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(107, 40);
            this.saveBtn.TabIndex = 2;
            this.saveBtn.Text = "S A V E";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.mainPanel.Controls.Add(this.summaryPanel);
            this.mainPanel.Controls.Add(this.pictureBox5);
            this.mainPanel.Controls.Add(this.stockPanel);
            this.mainPanel.Controls.Add(this.addPanel);
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(217, 653);
            this.mainPanel.TabIndex = 9;
            // 
            // summaryPanel
            // 
            this.summaryPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.summaryPanel.Controls.Add(this.pictureBox3);
            this.summaryPanel.Controls.Add(this.label12);
            this.summaryPanel.Location = new System.Drawing.Point(0, 468);
            this.summaryPanel.Name = "summaryPanel";
            this.summaryPanel.Size = new System.Drawing.Size(217, 138);
            this.summaryPanel.TabIndex = 12;
            this.summaryPanel.Click += new System.EventHandler(this.summaryPanel_Click);
            this.summaryPanel.MouseLeave += new System.EventHandler(this.summaryPanel_MouseLeave);
            this.summaryPanel.MouseHover += new System.EventHandler(this.summaryPanel_MouseHover);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::RiceInventorySystem.Properties.Resources.newspaper;
            this.pictureBox3.Location = new System.Drawing.Point(71, 22);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(68, 67);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 11;
            this.pictureBox3.TabStop = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label12.Location = new System.Drawing.Point(20, 92);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(171, 28);
            this.label12.TabIndex = 11;
            this.label12.Text = "S U M M A R Y";
            // 
            // pictureBox5
            // 
            this.pictureBox5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox5.Image = global::RiceInventorySystem.Properties.Resources.rice;
            this.pictureBox5.Location = new System.Drawing.Point(49, 39);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Padding = new System.Windows.Forms.Padding(10);
            this.pictureBox5.Size = new System.Drawing.Size(119, 116);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 11;
            this.pictureBox5.TabStop = false;
            // 
            // stockPanel
            // 
            this.stockPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.stockPanel.Controls.Add(this.pictureBox2);
            this.stockPanel.Controls.Add(this.label6);
            this.stockPanel.Location = new System.Drawing.Point(0, 330);
            this.stockPanel.Name = "stockPanel";
            this.stockPanel.Size = new System.Drawing.Size(217, 138);
            this.stockPanel.TabIndex = 11;
            this.stockPanel.Click += new System.EventHandler(this.stockPanel_Click);
            this.stockPanel.MouseLeave += new System.EventHandler(this.stockPanel_MouseLeave);
            this.stockPanel.MouseHover += new System.EventHandler(this.stockPanel_MouseHover);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::RiceInventorySystem.Properties.Resources.gold;
            this.pictureBox2.Location = new System.Drawing.Point(73, 15);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(68, 67);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 11;
            this.pictureBox2.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label6.Location = new System.Drawing.Point(46, 85);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(122, 28);
            this.label6.TabIndex = 11;
            this.label6.Text = "S T O C K";
            // 
            // addPanel
            // 
            this.addPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.addPanel.Controls.Add(this.pictureBox1);
            this.addPanel.Controls.Add(this.label5);
            this.addPanel.Location = new System.Drawing.Point(0, 192);
            this.addPanel.Name = "addPanel";
            this.addPanel.Size = new System.Drawing.Size(217, 138);
            this.addPanel.TabIndex = 10;
            this.addPanel.Click += new System.EventHandler(this.addPanel_Click);
            this.addPanel.MouseLeave += new System.EventHandler(this.addPanel_MouseLeave);
            this.addPanel.MouseHover += new System.EventHandler(this.addPanel_MouseHover);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::RiceInventorySystem.Properties.Resources.file_plus_alt;
            this.pictureBox1.Location = new System.Drawing.Point(75, 18);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(63, 67);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label5.Location = new System.Drawing.Point(68, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 28);
            this.label5.TabIndex = 10;
            this.label5.Text = "A D D";
            // 
            // addItemPanel
            // 
            this.addItemPanel.BackColor = System.Drawing.SystemColors.Control;
            this.addItemPanel.Controls.Add(this.priceValue);
            this.addItemPanel.Controls.Add(this.riceClassIndicator);
            this.addItemPanel.Controls.Add(this.totalValue);
            this.addItemPanel.Controls.Add(this.riceComboBox);
            this.addItemPanel.Controls.Add(this.saveBtn);
            this.addItemPanel.Controls.Add(this.label1);
            this.addItemPanel.Controls.Add(this.label2);
            this.addItemPanel.Controls.Add(this.label4);
            this.addItemPanel.Controls.Add(this.label3);
            this.addItemPanel.Controls.Add(this.quantityTextBox);
            this.addItemPanel.Location = new System.Drawing.Point(223, 12);
            this.addItemPanel.Name = "addItemPanel";
            this.addItemPanel.Size = new System.Drawing.Size(52, 50);
            this.addItemPanel.TabIndex = 10;
            // 
            // priceValue
            // 
            this.priceValue.AutoSize = true;
            this.priceValue.Location = new System.Drawing.Point(142, 71);
            this.priceValue.Name = "priceValue";
            this.priceValue.Size = new System.Drawing.Size(21, 22);
            this.priceValue.TabIndex = 13;
            this.priceValue.Text = "0";
            // 
            // riceClassIndicator
            // 
            this.riceClassIndicator.AutoSize = true;
            this.riceClassIndicator.Location = new System.Drawing.Point(169, 154);
            this.riceClassIndicator.Name = "riceClassIndicator";
            this.riceClassIndicator.Size = new System.Drawing.Size(21, 22);
            this.riceClassIndicator.TabIndex = 12;
            this.riceClassIndicator.Text = "0";
            this.riceClassIndicator.Visible = false;
            // 
            // totalValue
            // 
            this.totalValue.AutoSize = true;
            this.totalValue.Location = new System.Drawing.Point(142, 32);
            this.totalValue.Name = "totalValue";
            this.totalValue.Size = new System.Drawing.Size(21, 22);
            this.totalValue.TabIndex = 11;
            this.totalValue.Text = "0";
            // 
            // mainSummaryPanel
            // 
            this.mainSummaryPanel.BackColor = System.Drawing.SystemColors.Control;
            this.mainSummaryPanel.Controls.Add(this.label11);
            this.mainSummaryPanel.Controls.Add(this.label9);
            this.mainSummaryPanel.Controls.Add(this.label10);
            this.mainSummaryPanel.Location = new System.Drawing.Point(337, 12);
            this.mainSummaryPanel.Name = "mainSummaryPanel";
            this.mainSummaryPanel.Size = new System.Drawing.Size(50, 50);
            this.mainSummaryPanel.TabIndex = 11;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(324, 301);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(109, 22);
            this.label11.TabIndex = 11;
            this.label11.Text = "SUMMARY";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(260, 30);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(159, 22);
            this.label9.TabIndex = 10;
            this.label9.Text = "location: 223, 37";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(107, 30);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(134, 22);
            this.label10.TabIndex = 9;
            this.label10.Text = "size: 778, 616";
            // 
            // close
            // 
            this.close.Image = global::RiceInventorySystem.Properties.Resources.x_square;
            this.close.Location = new System.Drawing.Point(957, 0);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(44, 40);
            this.close.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.close.TabIndex = 12;
            this.close.TabStop = false;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // minimize
            // 
            this.minimize.Image = global::RiceInventorySystem.Properties.Resources.minus_square;
            this.minimize.Location = new System.Drawing.Point(913, 0);
            this.minimize.Name = "minimize";
            this.minimize.Size = new System.Drawing.Size(44, 40);
            this.minimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.minimize.TabIndex = 11;
            this.minimize.TabStop = false;
            // 
            // mainStockPanel
            // 
            this.mainStockPanel.BackColor = System.Drawing.SystemColors.Control;
            this.mainStockPanel.Controls.Add(this.stockListView);
            this.mainStockPanel.Controls.Add(this.label13);
            this.mainStockPanel.Location = new System.Drawing.Point(223, 67);
            this.mainStockPanel.Name = "mainStockPanel";
            this.mainStockPanel.Size = new System.Drawing.Size(778, 586);
            this.mainStockPanel.TabIndex = 12;
            // 
            // stockListView
            // 
            this.stockListView.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.stockListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.stockListView.FullRowSelect = true;
            this.stockListView.GridLines = true;
            this.stockListView.HideSelection = false;
            this.stockListView.HoverSelection = true;
            this.stockListView.Location = new System.Drawing.Point(24, 67);
            this.stockListView.Name = "stockListView";
            this.stockListView.Size = new System.Drawing.Size(724, 490);
            this.stockListView.TabIndex = 12;
            this.stockListView.UseCompatibleStateImageBehavior = false;
            this.stockListView.View = System.Windows.Forms.View.Details;
            this.stockListView.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.stockListView_DrawColumnHeader);
            this.stockListView.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.stockListView_DrawSubItem);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "NAME (Rice Class)";
            this.columnHeader1.Width = 215;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "PRICE";
            this.columnHeader3.Width = 143;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "QUANTITY";
            this.columnHeader4.Width = 143;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "ACTIONS";
            this.columnHeader5.Width = 265;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(352, 18);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(78, 22);
            this.label13.TabIndex = 11;
            this.label13.Text = "STOCK";
            // 
            // addRicePanel
            // 
            this.addRicePanel.BackColor = System.Drawing.SystemColors.Control;
            this.addRicePanel.Controls.Add(this.label19);
            this.addRicePanel.Controls.Add(this.panel1);
            this.addRicePanel.Controls.Add(this.riceComboBoxPreview);
            this.addRicePanel.Controls.Add(this.label18);
            this.addRicePanel.Location = new System.Drawing.Point(393, 12);
            this.addRicePanel.Name = "addRicePanel";
            this.addRicePanel.Size = new System.Drawing.Size(50, 50);
            this.addRicePanel.TabIndex = 16;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(59, 219);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(237, 12);
            this.label19.TabIndex = 21;
            this.label19.Text = "Select Rice Class to DELETE  or EDIT Here";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.editRiceClassBtn);
            this.panel1.Controls.Add(this.addPriceTextBox);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.addRiceTextBox);
            this.panel1.Controls.Add(this.addRiceClassBtn);
            this.panel1.Controls.Add(this.removeRiceClassBtn);
            this.panel1.Location = new System.Drawing.Point(348, 21);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(334, 417);
            this.panel1.TabIndex = 19;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(36, 161);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(58, 22);
            this.label17.TabIndex = 16;
            this.label17.Text = "Price";
            // 
            // editRiceClassBtn
            // 
            this.editRiceClassBtn.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editRiceClassBtn.Location = new System.Drawing.Point(40, 283);
            this.editRiceClassBtn.Name = "editRiceClassBtn";
            this.editRiceClassBtn.Size = new System.Drawing.Size(262, 40);
            this.editRiceClassBtn.TabIndex = 20;
            this.editRiceClassBtn.Text = "Edit Rice Class / Price";
            this.editRiceClassBtn.UseVisualStyleBackColor = true;
            this.editRiceClassBtn.Click += new System.EventHandler(this.editRiceClassBtn_Click);
            // 
            // addPriceTextBox
            // 
            this.addPriceTextBox.Location = new System.Drawing.Point(40, 186);
            this.addPriceTextBox.Name = "addPriceTextBox";
            this.addPriceTextBox.Size = new System.Drawing.Size(262, 29);
            this.addPriceTextBox.TabIndex = 15;
            this.addPriceTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.addPriceTextBox_KeyPress);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(38, 93);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(106, 22);
            this.label16.TabIndex = 14;
            this.label16.Text = "Rice Class";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(36, 41);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(147, 22);
            this.label8.TabIndex = 13;
            this.label8.Text = "A D D  /  E D I T";
            // 
            // addRiceTextBox
            // 
            this.addRiceTextBox.Location = new System.Drawing.Point(42, 118);
            this.addRiceTextBox.Name = "addRiceTextBox";
            this.addRiceTextBox.Size = new System.Drawing.Size(260, 29);
            this.addRiceTextBox.TabIndex = 12;
            // 
            // addRiceClassBtn
            // 
            this.addRiceClassBtn.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addRiceClassBtn.Location = new System.Drawing.Point(40, 237);
            this.addRiceClassBtn.Name = "addRiceClassBtn";
            this.addRiceClassBtn.Size = new System.Drawing.Size(262, 40);
            this.addRiceClassBtn.TabIndex = 14;
            this.addRiceClassBtn.Text = "Add Rice Class / Price";
            this.addRiceClassBtn.UseVisualStyleBackColor = true;
            this.addRiceClassBtn.Click += new System.EventHandler(this.addRiceClassBtn_Click);
            // 
            // removeRiceClassBtn
            // 
            this.removeRiceClassBtn.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removeRiceClassBtn.Location = new System.Drawing.Point(40, 329);
            this.removeRiceClassBtn.Name = "removeRiceClassBtn";
            this.removeRiceClassBtn.Size = new System.Drawing.Size(262, 40);
            this.removeRiceClassBtn.TabIndex = 15;
            this.removeRiceClassBtn.Text = "Remove Rice Class / Price";
            this.removeRiceClassBtn.UseVisualStyleBackColor = true;
            this.removeRiceClassBtn.Click += new System.EventHandler(this.removeRiceClassBtn_Click);
            // 
            // riceComboBoxPreview
            // 
            this.riceComboBoxPreview.FormattingEnabled = true;
            this.riceComboBoxPreview.Location = new System.Drawing.Point(61, 184);
            this.riceComboBoxPreview.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.riceComboBoxPreview.Name = "riceComboBoxPreview";
            this.riceComboBoxPreview.Size = new System.Drawing.Size(242, 30);
            this.riceComboBoxPreview.TabIndex = 0;
            this.riceComboBoxPreview.SelectedIndexChanged += new System.EventHandler(this.riceComboBoxPreview_SelectedIndexChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(57, 154);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(198, 22);
            this.label18.TabIndex = 3;
            this.label18.Text = "Rice Class (Preview)";
            // 
            // mainAddPanel
            // 
            this.mainAddPanel.BackColor = System.Drawing.SystemColors.Control;
            this.mainAddPanel.Controls.Add(this.addRicePanelbtn);
            this.mainAddPanel.Controls.Add(this.addItemPanelbtn);
            this.mainAddPanel.Location = new System.Drawing.Point(448, 12);
            this.mainAddPanel.Name = "mainAddPanel";
            this.mainAddPanel.Size = new System.Drawing.Size(50, 50);
            this.mainAddPanel.TabIndex = 12;
            // 
            // addRicePanelbtn
            // 
            this.addRicePanelbtn.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addRicePanelbtn.Location = new System.Drawing.Point(280, 189);
            this.addRicePanelbtn.Name = "addRicePanelbtn";
            this.addRicePanelbtn.Size = new System.Drawing.Size(230, 79);
            this.addRicePanelbtn.TabIndex = 9;
            this.addRicePanelbtn.Text = "ADD RICE CLASS";
            this.addRicePanelbtn.UseVisualStyleBackColor = true;
            this.addRicePanelbtn.Click += new System.EventHandler(this.addRicePanelbtn_Click);
            // 
            // addItemPanelbtn
            // 
            this.addItemPanelbtn.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addItemPanelbtn.Location = new System.Drawing.Point(280, 278);
            this.addItemPanelbtn.Name = "addItemPanelbtn";
            this.addItemPanelbtn.Size = new System.Drawing.Size(230, 79);
            this.addItemPanelbtn.TabIndex = 8;
            this.addItemPanelbtn.Text = "ADD ITEM";
            this.addItemPanelbtn.UseVisualStyleBackColor = true;
            this.addItemPanelbtn.Click += new System.EventHandler(this.addItemPanelbtn_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 650);
            this.Controls.Add(this.mainAddPanel);
            this.Controls.Add(this.addRicePanel);
            this.Controls.Add(this.mainSummaryPanel);
            this.Controls.Add(this.mainStockPanel);
            this.Controls.Add(this.close);
            this.Controls.Add(this.minimize);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.addItemPanel);
            this.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.MaximumSize = new System.Drawing.Size(1000, 650);
            this.MinimumSize = new System.Drawing.Size(500, 350);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "1";
            this.Load += new System.EventHandler(this.Main_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Main_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Main_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Main_MouseUp);
            this.mainPanel.ResumeLayout(false);
            this.summaryPanel.ResumeLayout(false);
            this.summaryPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.stockPanel.ResumeLayout(false);
            this.stockPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.addPanel.ResumeLayout(false);
            this.addPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.addItemPanel.ResumeLayout(false);
            this.addItemPanel.PerformLayout();
            this.mainSummaryPanel.ResumeLayout(false);
            this.mainSummaryPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.close)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minimize)).EndInit();
            this.mainStockPanel.ResumeLayout(false);
            this.mainStockPanel.PerformLayout();
            this.addRicePanel.ResumeLayout(false);
            this.addRicePanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.mainAddPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox riceComboBox;
        private System.Windows.Forms.TextBox quantityTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel addPanel;
        private System.Windows.Forms.Panel stockPanel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel addItemPanel;
        private System.Windows.Forms.PictureBox minimize;
        private System.Windows.Forms.PictureBox close;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Panel mainSummaryPanel;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel summaryPanel;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel mainStockPanel;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label totalValue;
        private System.Windows.Forms.Panel addRicePanel;
        private System.Windows.Forms.Button removeRiceClassBtn;
        private System.Windows.Forms.Button addRiceClassBtn;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox addRiceTextBox;
        private System.Windows.Forms.ComboBox riceComboBoxPreview;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Panel mainAddPanel;
        private System.Windows.Forms.Button addItemPanelbtn;
        private System.Windows.Forms.Button addRicePanelbtn;
        private System.Windows.Forms.Label riceClassIndicator;
        private System.Windows.Forms.Label priceValue;
        private System.Windows.Forms.ListView stockListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button editRiceClassBtn;
        private System.Windows.Forms.TextBox addPriceTextBox;
        private System.Windows.Forms.Label label16;
    }
}

