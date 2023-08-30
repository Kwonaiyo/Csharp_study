namespace MyFirstCSharp.Lesson06_Intermediate
{
    partial class Chap39_Delegate_AnonymousMethod
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
            this.btnCallDelegeate = new System.Windows.Forms.Button();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnCallDelegateMethod = new System.Windows.Forms.Button();
            this.btnAnonymousMethod = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCallDelegeate
            // 
            this.btnCallDelegeate.Location = new System.Drawing.Point(30, 12);
            this.btnCallDelegeate.Name = "btnCallDelegeate";
            this.btnCallDelegeate.Size = new System.Drawing.Size(129, 52);
            this.btnCallDelegeate.TabIndex = 0;
            this.btnCallDelegeate.Text = "대리자";
            this.btnCallDelegeate.UseVisualStyleBackColor = true;
            this.btnCallDelegeate.Click += new System.EventHandler(this.btnCallDelegeate_Click);
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(30, 70);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(518, 189);
            this.txtMessage.TabIndex = 1;
            // 
            // btnCallDelegateMethod
            // 
            this.btnCallDelegateMethod.Location = new System.Drawing.Point(165, 12);
            this.btnCallDelegateMethod.Name = "btnCallDelegateMethod";
            this.btnCallDelegateMethod.Size = new System.Drawing.Size(259, 52);
            this.btnCallDelegateMethod.TabIndex = 2;
            this.btnCallDelegateMethod.Text = "대리자를 인자로 한 메서드 호출";
            this.btnCallDelegateMethod.UseVisualStyleBackColor = true;
            this.btnCallDelegateMethod.Click += new System.EventHandler(this.btnCallDelegateMethod_Click);
            // 
            // btnAnonymousMethod
            // 
            this.btnAnonymousMethod.Location = new System.Drawing.Point(430, 12);
            this.btnAnonymousMethod.Name = "btnAnonymousMethod";
            this.btnAnonymousMethod.Size = new System.Drawing.Size(118, 52);
            this.btnAnonymousMethod.TabIndex = 3;
            this.btnAnonymousMethod.Text = "무명 메서드";
            this.btnAnonymousMethod.UseVisualStyleBackColor = true;
            this.btnAnonymousMethod.Click += new System.EventHandler(this.btnAnonymousMethod_Click);
            // 
            // Chap39_Delegate_AnonymousMethod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 283);
            this.Controls.Add(this.btnAnonymousMethod);
            this.Controls.Add(this.btnCallDelegateMethod);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.btnCallDelegeate);
            this.Name = "Chap39_Delegate_AnonymousMethod";
            this.Text = "Chap39_Delegate";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCallDelegeate;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnCallDelegateMethod;
        private System.Windows.Forms.Button btnAnonymousMethod;
    }
}