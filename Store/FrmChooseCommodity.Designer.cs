namespace Store
{
    partial class FrmChooseCommodity
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.datagrid = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnChooseCancel = new System.Windows.Forms.Button();
            this.btnChooseOK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.datagrid)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // datagrid
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.datagrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.datagrid.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.datagrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7});
            this.datagrid.Dock = System.Windows.Forms.DockStyle.Top;
            this.datagrid.Location = new System.Drawing.Point(0, 0);
            this.datagrid.MultiSelect = false;
            this.datagrid.Name = "datagrid";
            this.datagrid.ReadOnly = true;
            this.datagrid.RowTemplate.Height = 23;
            this.datagrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datagrid.Size = new System.Drawing.Size(852, 363);
            this.datagrid.TabIndex = 1;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "商品名称";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 150;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "商品类型";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 150;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "商品颜色";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 150;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "商品进价";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 150;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "进货数量";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 150;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "商品余量";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "进货日期";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnChooseCancel);
            this.panel1.Controls.Add(this.btnChooseOK);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 363);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(852, 49);
            this.panel1.TabIndex = 2;
            // 
            // btnChooseCancel
            // 
            this.btnChooseCancel.Location = new System.Drawing.Point(715, 14);
            this.btnChooseCancel.Name = "btnChooseCancel";
            this.btnChooseCancel.Size = new System.Drawing.Size(106, 23);
            this.btnChooseCancel.TabIndex = 0;
            this.btnChooseCancel.Text = "取消";
            this.btnChooseCancel.UseVisualStyleBackColor = true;
            this.btnChooseCancel.Click += new System.EventHandler(this.btnChooseCancel_Click);
            // 
            // btnChooseOK
            // 
            this.btnChooseOK.Location = new System.Drawing.Point(567, 14);
            this.btnChooseOK.Name = "btnChooseOK";
            this.btnChooseOK.Size = new System.Drawing.Size(106, 23);
            this.btnChooseOK.TabIndex = 0;
            this.btnChooseOK.Text = "确定";
            this.btnChooseOK.UseVisualStyleBackColor = true;
            this.btnChooseOK.Click += new System.EventHandler(this.btnChooseOK_Click);
            // 
            // FrmChooseCommodity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnChooseCancel;
            this.ClientSize = new System.Drawing.Size(852, 412);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.datagrid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmChooseCommodity";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "选择库存商品";
            ((System.ComponentModel.ISupportInitialize)(this.datagrid)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView datagrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnChooseCancel;
        private System.Windows.Forms.Button btnChooseOK;


    }
}