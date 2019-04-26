namespace VideoSurveillance
{
    partial class SettingForm
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
            this.acceptButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.videoOutputDirTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.videoOutputDirRefButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // acceptButton
            // 
            this.acceptButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.acceptButton.Location = new System.Drawing.Point(541, 142);
            this.acceptButton.Name = "acceptButton";
            this.acceptButton.Size = new System.Drawing.Size(75, 23);
            this.acceptButton.TabIndex = 0;
            this.acceptButton.Text = "OK";
            this.acceptButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(634, 142);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "キャンセル";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // videoOutputDirTextBox
            // 
            this.videoOutputDirTextBox.Location = new System.Drawing.Point(181, 71);
            this.videoOutputDirTextBox.Name = "videoOutputDirTextBox";
            this.videoOutputDirTextBox.ReadOnly = true;
            this.videoOutputDirTextBox.Size = new System.Drawing.Size(437, 19);
            this.videoOutputDirTextBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "動画出力先ディレクトリ";
            // 
            // videoOutputDirRefButton
            // 
            this.videoOutputDirRefButton.Location = new System.Drawing.Point(634, 69);
            this.videoOutputDirRefButton.Name = "videoOutputDirRefButton";
            this.videoOutputDirRefButton.Size = new System.Drawing.Size(75, 23);
            this.videoOutputDirRefButton.TabIndex = 4;
            this.videoOutputDirRefButton.Text = "参照";
            this.videoOutputDirRefButton.UseVisualStyleBackColor = true;
            this.videoOutputDirRefButton.Click += new System.EventHandler(this.videoOutputDirRefButton_Click);
            // 
            // SettingForm
            // 
            this.AcceptButton = this.acceptButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(800, 198);
            this.Controls.Add(this.videoOutputDirRefButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.videoOutputDirTextBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.acceptButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "設定";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.SettingForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button acceptButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TextBox videoOutputDirTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button videoOutputDirRefButton;
    }
}