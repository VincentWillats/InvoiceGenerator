namespace InvoiceGenerator
{
    partial class InvoiceGenerator
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblVenue = new System.Windows.Forms.Label();
            this.lblHours = new System.Windows.Forms.Label();
            this.dtp1 = new System.Windows.Forms.DateTimePicker();
            this.txtBillee = new System.Windows.Forms.TextBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.txtItemAmount = new System.Windows.Forms.TextBox();
            this.txtItemTotalPrice = new System.Windows.Forms.TextBox();
            this.lblInvoiceNo = new System.Windows.Forms.Label();
            this.txtInvoiceNo = new System.Windows.Forms.TextBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblHourly = new System.Windows.Forms.Label();
            this.txtItemPrice = new System.Windows.Forms.TextBox();
            this.btnConfig = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxPaid = new System.Windows.Forms.CheckBox();
            this.lbxItems = new System.Windows.Forms.ListBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtItemDesc = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpItemDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtBilleeAddress01 = new System.Windows.Forms.TextBox();
            this.txtBilleeAddress02 = new System.Windows.Forms.TextBox();
            this.txtBilleeAddress03 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(269, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Invoice Generator";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(352, 73);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(71, 13);
            this.lblDate.TabIndex = 1;
            this.lblDate.Text = "Invoice Date:";
            // 
            // lblVenue
            // 
            this.lblVenue.AutoSize = true;
            this.lblVenue.Location = new System.Drawing.Point(372, 120);
            this.lblVenue.Name = "lblVenue";
            this.lblVenue.Size = new System.Drawing.Size(51, 13);
            this.lblVenue.TabIndex = 2;
            this.lblVenue.Text = "Billed To:";
            // 
            // lblHours
            // 
            this.lblHours.AutoSize = true;
            this.lblHours.Location = new System.Drawing.Point(15, 147);
            this.lblHours.Name = "lblHours";
            this.lblHours.Size = new System.Drawing.Size(82, 13);
            this.lblHours.TabIndex = 3;
            this.lblHours.Text = "Quantity/Hours:";
            // 
            // dtp1
            // 
            this.dtp1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp1.Location = new System.Drawing.Point(429, 70);
            this.dtp1.Name = "dtp1";
            this.dtp1.Size = new System.Drawing.Size(91, 20);
            this.dtp1.TabIndex = 8;
            this.dtp1.Value = new System.DateTime(2019, 12, 3, 0, 0, 0, 0);
            // 
            // txtBillee
            // 
            this.txtBillee.Location = new System.Drawing.Point(429, 117);
            this.txtBillee.Name = "txtBillee";
            this.txtBillee.Size = new System.Drawing.Size(168, 20);
            this.txtBillee.TabIndex = 10;
            this.txtBillee.TextChanged += new System.EventHandler(this.txtBillee_TextChanged);
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(36, 173);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(70, 13);
            this.lblPrice.TabIndex = 6;
            this.lblPrice.Text = "Total Price: $";
            // 
            // txtItemAmount
            // 
            this.txtItemAmount.Location = new System.Drawing.Point(103, 144);
            this.txtItemAmount.Name = "txtItemAmount";
            this.txtItemAmount.Size = new System.Drawing.Size(57, 20);
            this.txtItemAmount.TabIndex = 4;
            this.txtItemAmount.TextChanged += new System.EventHandler(this.txtQuantOrHours_TextChanged);
            // 
            // txtItemTotalPrice
            // 
            this.txtItemTotalPrice.Location = new System.Drawing.Point(103, 170);
            this.txtItemTotalPrice.Name = "txtItemTotalPrice";
            this.txtItemTotalPrice.Size = new System.Drawing.Size(57, 20);
            this.txtItemTotalPrice.TabIndex = 5;
            this.txtItemTotalPrice.TextChanged += new System.EventHandler(this.txtTotalPrice_TextChanged);
            // 
            // lblInvoiceNo
            // 
            this.lblInvoiceNo.AutoSize = true;
            this.lblInvoiceNo.Location = new System.Drawing.Point(338, 47);
            this.lblInvoiceNo.Name = "lblInvoiceNo";
            this.lblInvoiceNo.Size = new System.Drawing.Size(85, 13);
            this.lblInvoiceNo.TabIndex = 9;
            this.lblInvoiceNo.Text = "Invoice Number:";
            // 
            // txtInvoiceNo
            // 
            this.txtInvoiceNo.Location = new System.Drawing.Point(429, 44);
            this.txtInvoiceNo.Name = "txtInvoiceNo";
            this.txtInvoiceNo.Size = new System.Drawing.Size(37, 20);
            this.txtInvoiceNo.TabIndex = 7;
            this.txtInvoiceNo.TextChanged += new System.EventHandler(this.txtInvoiceNo_TextChanged);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(334, 401);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(109, 23);
            this.btnGenerate.TabIndex = 14;
            this.btnGenerate.Text = "Generate Invoice";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.BtnGenerate_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // lblHourly
            // 
            this.lblHourly.AutoSize = true;
            this.lblHourly.Location = new System.Drawing.Point(12, 121);
            this.lblHourly.Name = "lblHourly";
            this.lblHourly.Size = new System.Drawing.Size(94, 13);
            this.lblHourly.TabIndex = 12;
            this.lblHourly.Text = "Item/Hour Price: $";
            // 
            // txtItemPrice
            // 
            this.txtItemPrice.Location = new System.Drawing.Point(103, 118);
            this.txtItemPrice.Name = "txtItemPrice";
            this.txtItemPrice.Size = new System.Drawing.Size(37, 20);
            this.txtItemPrice.TabIndex = 3;
            this.txtItemPrice.TextChanged += new System.EventHandler(this.txtItemPrice_TextChanged);
            // 
            // btnConfig
            // 
            this.btnConfig.Location = new System.Drawing.Point(528, 12);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(70, 23);
            this.btnConfig.TabIndex = 15;
            this.btnConfig.Text = "Configure";
            this.btnConfig.UseVisualStyleBackColor = true;
            this.btnConfig.Click += new System.EventHandler(this.BtnConfig_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(360, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Paid or Not:";
            // 
            // cbxPaid
            // 
            this.cbxPaid.AutoSize = true;
            this.cbxPaid.Location = new System.Drawing.Point(429, 97);
            this.cbxPaid.Name = "cbxPaid";
            this.cbxPaid.Size = new System.Drawing.Size(15, 14);
            this.cbxPaid.TabIndex = 9;
            this.cbxPaid.UseVisualStyleBackColor = true;
            // 
            // lbxItems
            // 
            this.lbxItems.FormattingEnabled = true;
            this.lbxItems.Location = new System.Drawing.Point(51, 266);
            this.lbxItems.Name = "lbxItems";
            this.lbxItems.Size = new System.Drawing.Size(451, 121);
            this.lbxItems.TabIndex = 16;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(163, 218);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "Add Item";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtItemDesc
            // 
            this.txtItemDesc.Location = new System.Drawing.Point(102, 68);
            this.txtItemDesc.Name = "txtItemDesc";
            this.txtItemDesc.Size = new System.Drawing.Size(166, 20);
            this.txtItemDesc.TabIndex = 1;
            this.txtItemDesc.TextChanged += new System.EventHandler(this.txtItemDesc_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Description:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "Date of Work:";
            // 
            // dtpItemDate
            // 
            this.dtpItemDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpItemDate.Location = new System.Drawing.Point(102, 93);
            this.dtpItemDate.Name = "dtpItemDate";
            this.dtpItemDate.Size = new System.Drawing.Size(96, 20);
            this.dtpItemDate.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(304, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "Billed Address Line One:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(331, 173);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 13);
            this.label6.TabIndex = 26;
            this.label6.Text = "Address Line Two:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(321, 198);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 13);
            this.label7.TabIndex = 27;
            this.label7.Text = "Address Line Three:";
            // 
            // txtBilleeAddress01
            // 
            this.txtBilleeAddress01.Location = new System.Drawing.Point(429, 143);
            this.txtBilleeAddress01.Name = "txtBilleeAddress01";
            this.txtBilleeAddress01.Size = new System.Drawing.Size(168, 20);
            this.txtBilleeAddress01.TabIndex = 11;
            this.txtBilleeAddress01.TextChanged += new System.EventHandler(this.txtBilleeAddress01_TextChanged);
            // 
            // txtBilleeAddress02
            // 
            this.txtBilleeAddress02.Location = new System.Drawing.Point(429, 169);
            this.txtBilleeAddress02.Name = "txtBilleeAddress02";
            this.txtBilleeAddress02.Size = new System.Drawing.Size(168, 20);
            this.txtBilleeAddress02.TabIndex = 12;
            this.txtBilleeAddress02.TextChanged += new System.EventHandler(this.txtBilleeAddress02_TextChanged);
            // 
            // txtBilleeAddress03
            // 
            this.txtBilleeAddress03.Location = new System.Drawing.Point(429, 195);
            this.txtBilleeAddress03.Name = "txtBilleeAddress03";
            this.txtBilleeAddress03.Size = new System.Drawing.Size(168, 20);
            this.txtBilleeAddress03.TabIndex = 13;
            this.txtBilleeAddress03.TextChanged += new System.EventHandler(this.txtBilleeAddress03_TextChanged);
            // 
            // InvoiceGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 449);
            this.Controls.Add(this.txtBilleeAddress03);
            this.Controls.Add(this.txtBilleeAddress02);
            this.Controls.Add(this.txtBilleeAddress01);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpItemDate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtItemDesc);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lbxItems);
            this.Controls.Add(this.cbxPaid);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnConfig);
            this.Controls.Add(this.txtItemPrice);
            this.Controls.Add(this.lblHourly);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.txtInvoiceNo);
            this.Controls.Add(this.lblInvoiceNo);
            this.Controls.Add(this.txtItemTotalPrice);
            this.Controls.Add(this.txtItemAmount);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.txtBillee);
            this.Controls.Add(this.dtp1);
            this.Controls.Add(this.lblHours);
            this.Controls.Add(this.lblVenue);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.label1);
            this.Name = "InvoiceGenerator";
            this.Text = "Invoice Generator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblVenue;
        private System.Windows.Forms.Label lblHours;
        private System.Windows.Forms.DateTimePicker dtp1;
        private System.Windows.Forms.TextBox txtBillee;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.TextBox txtItemAmount;
        private System.Windows.Forms.TextBox txtItemTotalPrice;
        private System.Windows.Forms.Label lblInvoiceNo;
        private System.Windows.Forms.TextBox txtInvoiceNo;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TextBox txtItemPrice;
        private System.Windows.Forms.Label lblHourly;
        private System.Windows.Forms.Button btnConfig;
        private System.Windows.Forms.CheckBox cbxPaid;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpItemDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtItemDesc;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListBox lbxItems;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBilleeAddress03;
        private System.Windows.Forms.TextBox txtBilleeAddress02;
        private System.Windows.Forms.TextBox txtBilleeAddress01;
    }
}

