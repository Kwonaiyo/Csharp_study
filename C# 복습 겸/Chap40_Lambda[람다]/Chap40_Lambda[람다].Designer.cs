namespace MyFirstCSharp.Lesson06_Intermediate
{
    partial class Chap40_Lambda
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
            this.btnLambda1 = new System.Windows.Forms.Button();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnLambda2 = new System.Windows.Forms.Button();
            this.btnLambda3 = new System.Windows.Forms.Button();
            this.btnLambda4 = new System.Windows.Forms.Button();
            this.btnAction = new System.Windows.Forms.Button();
            this.btnFunc = new System.Windows.Forms.Button();
            this.btnAction2 = new System.Windows.Forms.Button();
            this.btnFuncWhere = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLambda1
            // 
            this.btnLambda1.Location = new System.Drawing.Point(26, 18);
            this.btnLambda1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLambda1.Name = "btnLambda1";
            this.btnLambda1.Size = new System.Drawing.Size(106, 45);
            this.btnLambda1.TabIndex = 0;
            this.btnLambda1.Text = "람다의 표현 1";
            this.btnLambda1.UseVisualStyleBackColor = true;
            this.btnLambda1.Click += new System.EventHandler(this.btnLambda_Click);
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(26, 68);
            this.txtMessage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(440, 108);
            this.txtMessage.TabIndex = 2;
            // 
            // btnLambda2
            // 
            this.btnLambda2.Location = new System.Drawing.Point(137, 18);
            this.btnLambda2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLambda2.Name = "btnLambda2";
            this.btnLambda2.Size = new System.Drawing.Size(106, 45);
            this.btnLambda2.TabIndex = 3;
            this.btnLambda2.Text = "람다의 표현 2";
            this.btnLambda2.UseVisualStyleBackColor = true;
            this.btnLambda2.Click += new System.EventHandler(this.btnLambda2_Click);
            // 
            // btnLambda3
            // 
            this.btnLambda3.Location = new System.Drawing.Point(248, 18);
            this.btnLambda3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLambda3.Name = "btnLambda3";
            this.btnLambda3.Size = new System.Drawing.Size(106, 45);
            this.btnLambda3.TabIndex = 4;
            this.btnLambda3.Text = "람다의 표현 3";
            this.btnLambda3.UseVisualStyleBackColor = true;
            this.btnLambda3.Click += new System.EventHandler(this.btnLambda3_Click);
            // 
            // btnLambda4
            // 
            this.btnLambda4.Location = new System.Drawing.Point(360, 18);
            this.btnLambda4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLambda4.Name = "btnLambda4";
            this.btnLambda4.Size = new System.Drawing.Size(106, 45);
            this.btnLambda4.TabIndex = 5;
            this.btnLambda4.Text = "람다의 표현 4";
            this.btnLambda4.UseVisualStyleBackColor = true;
            this.btnLambda4.Click += new System.EventHandler(this.btnLambda4_Click);
            // 
            // btnAction
            // 
            this.btnAction.Location = new System.Drawing.Point(26, 181);
            this.btnAction.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAction.Name = "btnAction";
            this.btnAction.Size = new System.Drawing.Size(106, 45);
            this.btnAction.TabIndex = 6;
            this.btnAction.Text = "Action1";
            this.btnAction.UseVisualStyleBackColor = true;
            this.btnAction.Click += new System.EventHandler(this.btnAction_Click);
            // 
            // btnFunc
            // 
            this.btnFunc.Location = new System.Drawing.Point(249, 181);
            this.btnFunc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnFunc.Name = "btnFunc";
            this.btnFunc.Size = new System.Drawing.Size(105, 45);
            this.btnFunc.TabIndex = 7;
            this.btnFunc.Text = "Func";
            this.btnFunc.UseVisualStyleBackColor = true;
            this.btnFunc.Click += new System.EventHandler(this.btnFunc_Click);
            // 
            // btnAction2
            // 
            this.btnAction2.Location = new System.Drawing.Point(137, 180);
            this.btnAction2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAction2.Name = "btnAction2";
            this.btnAction2.Size = new System.Drawing.Size(106, 45);
            this.btnAction2.TabIndex = 8;
            this.btnAction2.Text = "Action2";
            this.btnAction2.UseVisualStyleBackColor = true;
            this.btnAction2.Click += new System.EventHandler(this.btnAction2_Click);
            // 
            // btnFuncWhere
            // 
            this.btnFuncWhere.Location = new System.Drawing.Point(361, 180);
            this.btnFuncWhere.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnFuncWhere.Name = "btnFuncWhere";
            this.btnFuncWhere.Size = new System.Drawing.Size(105, 45);
            this.btnFuncWhere.TabIndex = 9;
            this.btnFuncWhere.Text = "예제 Where";
            this.btnFuncWhere.UseVisualStyleBackColor = true;
            this.btnFuncWhere.Click += new System.EventHandler(this.btnFuncWhere_Click);
            // 
            // Chap40_Lambda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 235);
            this.Controls.Add(this.btnFuncWhere);
            this.Controls.Add(this.btnAction2);
            this.Controls.Add(this.btnFunc);
            this.Controls.Add(this.btnAction);
            this.Controls.Add(this.btnLambda4);
            this.Controls.Add(this.btnLambda3);
            this.Controls.Add(this.btnLambda2);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.btnLambda1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Chap40_Lambda";
            this.Text = "Chap40_Lambda";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLambda1;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnLambda2;
        private System.Windows.Forms.Button btnLambda3;
        private System.Windows.Forms.Button btnLambda4;
        private System.Windows.Forms.Button btnAction;
        private System.Windows.Forms.Button btnFunc;
        private System.Windows.Forms.Button btnAction2;
        private System.Windows.Forms.Button btnFuncWhere;
    }
}