namespace NRemote
{
    partial class frmSetting
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
            this.label1 = new System.Windows.Forms.Label();
            this.selCameraID = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.selCom = new System.Windows.Forms.NumericUpDown();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.selW = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.selH = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.selCom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selW)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selH)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "カメラID:";
            // 
            // selCameraID
            // 
            this.selCameraID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selCameraID.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.selCameraID.FormattingEnabled = true;
            this.selCameraID.Location = new System.Drawing.Point(75, 15);
            this.selCameraID.Name = "selCameraID";
            this.selCameraID.Size = new System.Drawing.Size(91, 24);
            this.selCameraID.TabIndex = 1;
            this.selCameraID.SelectedIndexChanged += new System.EventHandler(this.selCameraID_SelectedIndexChanged);
            this.selCameraID.SelectedValueChanged += new System.EventHandler(this.selCameraID_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(25, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "COM:";
            // 
            // selCom
            // 
            this.selCom.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.selCom.Location = new System.Drawing.Point(75, 100);
            this.selCom.Name = "selCom";
            this.selCom.Size = new System.Drawing.Size(91, 23);
            this.selCom.TabIndex = 3;
            this.selCom.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.btnOK.Location = new System.Drawing.Point(31, 139);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(85, 31);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.btnCancel.Location = new System.Drawing.Point(169, 139);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 31);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // selW
            // 
            this.selW.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.selW.Location = new System.Drawing.Point(75, 58);
            this.selW.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.selW.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.selW.Name = "selW";
            this.selW.Size = new System.Drawing.Size(73, 23);
            this.selW.TabIndex = 6;
            this.selW.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.selW.Value = new decimal(new int[] {
            1920,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(12, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "解像度";
            // 
            // selH
            // 
            this.selH.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.selH.Location = new System.Drawing.Point(169, 58);
            this.selH.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.selH.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.selH.Name = "selH";
            this.selH.Size = new System.Drawing.Size(73, 23);
            this.selH.TabIndex = 6;
            this.selH.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.selH.Value = new decimal(new int[] {
            1080,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.Location = new System.Drawing.Point(152, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "x";
            // 
            // frmSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(266, 181);
            this.ControlBox = false;
            this.Controls.Add(this.selH);
            this.Controls.Add(this.selW);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.selCom);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.selCameraID);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmSetting";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Setting";
            ((System.ComponentModel.ISupportInitialize)(this.selCom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selW)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selH)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox selCameraID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown selCom;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.NumericUpDown selW;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown selH;
        private System.Windows.Forms.Label label4;
    }
}