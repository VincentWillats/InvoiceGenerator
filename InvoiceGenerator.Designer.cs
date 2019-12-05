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
            this.txtVenue = new System.Windows.Forms.TextBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.txtHours = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.lblInvoiceNo = new System.Windows.Forms.Label();
            this.txtInvoiceNo = new System.Windows.Forms.TextBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblHourly = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnConfig = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxPaid = new System.Windows.Forms.CheckBox();
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
            this.lblDate.Location = new System.Drawing.Point(201, 63);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(33, 13);
            this.lblDate.TabIndex = 1;
            this.lblDate.Text = "Date:";
            // 
            // lblVenue
            // 
            this.lblVenue.AutoSize = true;
            this.lblVenue.Location = new System.Drawing.Point(166, 89);
            this.lblVenue.Name = "lblVenue";
            this.lblVenue.Size = new System.Drawing.Size(41, 13);
            this.lblVenue.TabIndex = 2;
            this.lblVenue.Text = "Venue:";
            // 
            // lblHours
            // 
            this.lblHours.AutoSize = true;
            this.lblHours.Location = new System.Drawing.Point(72, 130);
            this.lblHours.Name = "lblHours";
            this.lblHours.Size = new System.Drawing.Size(38, 13);
            this.lblHours.TabIndex = 3;
            this.lblHours.Text = "Hours:";
            // 
            // dtp1
            // 
            this.dtp1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp1.Location = new System.Drawing.Point(242, 60);
            this.dtp1.Name = "dtp1";
            this.dtp1.Size = new System.Drawing.Size(91, 20);
            this.dtp1.TabIndex = 4;
            this.dtp1.Value = new System.DateTime(2019, 12, 3, 0, 0, 0, 0);
            this.dtp1.ValueChanged += new System.EventHandler(this.Dtp1_ValueChanged);
            // 
            // txtVenue
            // 
            this.txtVenue.Location = new System.Drawing.Point(210, 86);
            this.txtVenue.Name = "txtVenue";
            this.txtVenue.ReadOnly = true;
            this.txtVenue.Size = new System.Drawing.Size(183, 20);
            this.txtVenue.TabIndex = 5;
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(37, 156);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(70, 13);
            this.lblPrice.TabIndex = 6;
            this.lblPrice.Text = "Total Price: $";
            // 
            // txtHours
            // 
            this.txtHours.Location = new System.Drawing.Point(113, 127);
            this.txtHours.Name = "txtHours";
            this.txtHours.Size = new System.Drawing.Size(57, 20);
            this.txtHours.TabIndex = 7;
            this.txtHours.TextChanged += new System.EventHandler(this.TxtHours_TextChanged);
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(113, 153);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(57, 20);
            this.txtPrice.TabIndex = 8;
            this.txtPrice.TextChanged += new System.EventHandler(this.TxtPrice_TextChanged);
            // 
            // lblInvoiceNo
            // 
            this.lblInvoiceNo.AutoSize = true;
            this.lblInvoiceNo.Location = new System.Drawing.Point(23, 64);
            this.lblInvoiceNo.Name = "lblInvoiceNo";
            this.lblInvoiceNo.Size = new System.Drawing.Size(88, 13);
            this.lblInvoiceNo.TabIndex = 9;
            this.lblInvoiceNo.Text = "Invoice Number: ";
            // 
            // txtInvoiceNo
            // 
            this.txtInvoiceNo.Location = new System.Drawing.Point(113, 61);
            this.txtInvoiceNo.Name = "txtInvoiceNo";
            this.txtInvoiceNo.ReadOnly = true;
            this.txtInvoiceNo.Size = new System.Drawing.Size(37, 20);
            this.txtInvoiceNo.TabIndex = 10;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(242, 146);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(109, 23);
            this.btnGenerate.TabIndex = 11;
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
            this.lblHourly.Location = new System.Drawing.Point(35, 86);
            this.lblHourly.Name = "lblHourly";
            this.lblHourly.Size = new System.Drawing.Size(76, 13);
            this.lblHourly.TabIndex = 12;
            this.lblHourly.Text = "Hourly Price: $";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(113, 83);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(37, 20);
            this.textBox1.TabIndex = 13;
            this.textBox1.Text = "27";
            // 
            // btnConfig
            // 
            this.btnConfig.Location = new System.Drawing.Point(312, 12);
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
            this.label2.Location = new System.Drawing.Point(261, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Paid:";
            // 
            // cbxPaid
            // 
            this.cbxPaid.AutoSize = true;
            this.cbxPaid.Location = new System.Drawing.Point(298, 112);
            this.cbxPaid.Name = "cbxPaid";
            this.cbxPaid.Size = new System.Drawing.Size(15, 14);
            this.cbxPaid.TabIndex = 17;
            this.cbxPaid.UseVisualStyleBackColor = true;
            this.cbxPaid.CheckedChanged += new System.EventHandler(this.CbxPaid_CheckedChanged);
            // 
            // InvoiceGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 188);
            this.Controls.Add(this.cbxPaid);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnConfig);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lblHourly);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.txtInvoiceNo);
            this.Controls.Add(this.lblInvoiceNo);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.txtHours);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.txtVenue);
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
        private System.Windows.Forms.TextBox txtVenue;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.TextBox txtHours;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label lblInvoiceNo;
        private System.Windows.Forms.TextBox txtInvoiceNo;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblHourly;
        private System.Windows.Forms.Button btnConfig;
        private System.Windows.Forms.CheckBox cbxPaid;
        private System.Windows.Forms.Label label2;
    }
}

