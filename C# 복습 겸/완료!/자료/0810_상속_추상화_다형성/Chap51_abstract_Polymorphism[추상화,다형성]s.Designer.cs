namespace MyFirstCSharp
{
    partial class Chap51_abstraction
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnUserSearch = new System.Windows.Forms.Button();
            this.btnWorkSearch = new System.Windows.Forms.Button();
            this.btnItemSearch = new System.Windows.Forms.Button();
            this.btnabstract = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnUserSearch);
            this.groupBox1.Controls.Add(this.btnWorkSearch);
            this.groupBox1.Controls.Add(this.btnItemSearch);
            this.groupBox1.Location = new System.Drawing.Point(158, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(345, 54);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            // 
            // btnUserSearch
            // 
            this.btnUserSearch.Location = new System.Drawing.Point(119, 16);
            this.btnUserSearch.Name = "btnUserSearch";
            this.btnUserSearch.Size = new System.Drawing.Size(105, 32);
            this.btnUserSearch.TabIndex = 10;
            this.btnUserSearch.Tag = "UserMaster";
            this.btnUserSearch.Text = "사용자 조회";
            this.btnUserSearch.UseVisualStyleBackColor = true;
            this.btnUserSearch.Click += new System.EventHandler(this.MenuSearch);
            // 
            // btnWorkSearch
            // 
            this.btnWorkSearch.Location = new System.Drawing.Point(230, 16);
            this.btnWorkSearch.Name = "btnWorkSearch";
            this.btnWorkSearch.Size = new System.Drawing.Size(105, 32);
            this.btnWorkSearch.TabIndex = 11;
            this.btnWorkSearch.Tag = "WorkcenterMaster";
            this.btnWorkSearch.Text = "작업장 조회";
            this.btnWorkSearch.UseVisualStyleBackColor = true;
            this.btnWorkSearch.Click += new System.EventHandler(this.MenuSearch);
            // 
            // btnItemSearch
            // 
            this.btnItemSearch.Location = new System.Drawing.Point(6, 15);
            this.btnItemSearch.Name = "btnItemSearch";
            this.btnItemSearch.Size = new System.Drawing.Size(105, 32);
            this.btnItemSearch.TabIndex = 9;
            this.btnItemSearch.Tag = "ItemMaster";
            this.btnItemSearch.Text = "품목 조회";
            this.btnItemSearch.UseVisualStyleBackColor = true;
            this.btnItemSearch.Click += new System.EventHandler(this.MenuSearch);
            // 
            // btnabstract
            // 
            this.btnabstract.Location = new System.Drawing.Point(31, 27);
            this.btnabstract.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnabstract.Name = "btnabstract";
            this.btnabstract.Size = new System.Drawing.Size(119, 32);
            this.btnabstract.TabIndex = 15;
            this.btnabstract.Text = "추상화(abstract)";
            this.btnabstract.UseVisualStyleBackColor = true;
            this.btnabstract.Click += new System.EventHandler(this.btnabstract_Click);
            // 
            // Chap51_abstraction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 73);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnabstract);
            this.Name = "Chap51_abstraction";
            this.Text = "추상화와 다형성";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnUserSearch;
        private System.Windows.Forms.Button btnWorkSearch;
        private System.Windows.Forms.Button btnItemSearch;
        private System.Windows.Forms.Button btnabstract;
    }
}