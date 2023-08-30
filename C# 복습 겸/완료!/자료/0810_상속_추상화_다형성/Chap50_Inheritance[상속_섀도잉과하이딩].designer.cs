namespace MyFirstCSharp
{
    partial class Chap16_Inheritance
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
            this.btnInheritance = new System.Windows.Forms.Button();
            this.btnRandomInhe = new System.Windows.Forms.Button();
            this.btnShdoing = new System.Windows.Forms.Button();
            this.btnHiding = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnInheritance
            // 
            this.btnInheritance.Location = new System.Drawing.Point(35, 15);
            this.btnInheritance.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnInheritance.Name = "btnInheritance";
            this.btnInheritance.Size = new System.Drawing.Size(139, 40);
            this.btnInheritance.TabIndex = 7;
            this.btnInheritance.Text = "상속";
            this.btnInheritance.UseVisualStyleBackColor = true;
            this.btnInheritance.Click += new System.EventHandler(this.btnInheritance_Click);
            // 
            // btnRandomInhe
            // 
            this.btnRandomInhe.Location = new System.Drawing.Point(181, 15);
            this.btnRandomInhe.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRandomInhe.Name = "btnRandomInhe";
            this.btnRandomInhe.Size = new System.Drawing.Size(139, 40);
            this.btnRandomInhe.TabIndex = 8;
            this.btnRandomInhe.Text = "랜덤 클래스의 상속";
            this.btnRandomInhe.UseVisualStyleBackColor = true;
            this.btnRandomInhe.Click += new System.EventHandler(this.btnRandomInhe_Click);
            // 
            // btnShdoing
            // 
            this.btnShdoing.Location = new System.Drawing.Point(326, 12);
            this.btnShdoing.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnShdoing.Name = "btnShdoing";
            this.btnShdoing.Size = new System.Drawing.Size(80, 40);
            this.btnShdoing.TabIndex = 9;
            this.btnShdoing.Text = "Shdoing";
            this.btnShdoing.UseVisualStyleBackColor = true;
            this.btnShdoing.Click += new System.EventHandler(this.btnShdoing_Click);
            // 
            // btnHiding
            // 
            this.btnHiding.Location = new System.Drawing.Point(412, 12);
            this.btnHiding.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnHiding.Name = "btnHiding";
            this.btnHiding.Size = new System.Drawing.Size(80, 40);
            this.btnHiding.TabIndex = 10;
            this.btnHiding.Text = "Hiding";
            this.btnHiding.UseVisualStyleBackColor = true;
            this.btnHiding.Click += new System.EventHandler(this.btnHiding_Click);
            // 
            // Chap16_Inheritance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 65);
            this.Controls.Add(this.btnHiding);
            this.Controls.Add(this.btnShdoing);
            this.Controls.Add(this.btnRandomInhe);
            this.Controls.Add(this.btnInheritance);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Chap16_Inheritance";
            this.Text = "상속";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnInheritance;
        private System.Windows.Forms.Button btnRandomInhe;
        private System.Windows.Forms.Button btnShdoing;
        private System.Windows.Forms.Button btnHiding;
    }
}