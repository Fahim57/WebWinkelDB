namespace WinkelClient
{
    partial class Winkel
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
            this.koopButton = new System.Windows.Forms.Button();
            this.productenBox = new System.Windows.Forms.DataGridView();
            this.historieBox = new System.Windows.Forms.DataGridView();
            this.histNaamColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.histPrijsColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aantalSelector = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.productIdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productNaamColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productPrijsColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productAantalColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.saldoLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.productenBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.historieBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aantalSelector)).BeginInit();
            this.SuspendLayout();
            // 
            // koopButton
            // 
            this.koopButton.Location = new System.Drawing.Point(80, 207);
            this.koopButton.Margin = new System.Windows.Forms.Padding(2);
            this.koopButton.Name = "koopButton";
            this.koopButton.Size = new System.Drawing.Size(95, 26);
            this.koopButton.TabIndex = 2;
            this.koopButton.Text = "Koop";
            this.koopButton.UseVisualStyleBackColor = true;
            this.koopButton.Click += new System.EventHandler(this.koopButton_Click);
            // 
            // productenBox
            // 
            this.productenBox.AllowUserToAddRows = false;
            this.productenBox.AllowUserToDeleteRows = false;
            this.productenBox.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.productenBox.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.productIdColumn,
            this.productNaamColumn,
            this.productPrijsColumn,
            this.productAantalColumn});
            this.productenBox.Location = new System.Drawing.Point(12, 37);
            this.productenBox.Name = "productenBox";
            this.productenBox.ReadOnly = true;
            this.productenBox.Size = new System.Drawing.Size(394, 150);
            this.productenBox.TabIndex = 4;
            // 
            // historieBox
            // 
            this.historieBox.AllowUserToAddRows = false;
            this.historieBox.AllowUserToDeleteRows = false;
            this.historieBox.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.historieBox.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.histNaamColumn,
            this.histPrijsColumn});
            this.historieBox.Location = new System.Drawing.Point(412, 37);
            this.historieBox.Name = "historieBox";
            this.historieBox.ReadOnly = true;
            this.historieBox.Size = new System.Drawing.Size(240, 150);
            this.historieBox.TabIndex = 5;
            // 
            // histNaamColumn
            // 
            this.histNaamColumn.Frozen = true;
            this.histNaamColumn.HeaderText = "Naam";
            this.histNaamColumn.Name = "histNaamColumn";
            this.histNaamColumn.ReadOnly = true;
            // 
            // histPrijsColumn
            // 
            this.histPrijsColumn.Frozen = true;
            this.histPrijsColumn.HeaderText = "Prijs";
            this.histPrijsColumn.Name = "histPrijsColumn";
            this.histPrijsColumn.ReadOnly = true;
            // 
            // aantalSelector
            // 
            this.aantalSelector.Location = new System.Drawing.Point(12, 212);
            this.aantalSelector.Name = "aantalSelector";
            this.aantalSelector.Size = new System.Drawing.Size(63, 20);
            this.aantalSelector.TabIndex = 6;
            this.aantalSelector.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(409, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Historie";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Producten";
            // 
            // productIdColumn
            // 
            this.productIdColumn.Frozen = true;
            this.productIdColumn.HeaderText = "id";
            this.productIdColumn.Name = "productIdColumn";
            this.productIdColumn.ReadOnly = true;
            this.productIdColumn.Visible = false;
            // 
            // productNaamColumn
            // 
            this.productNaamColumn.HeaderText = "Naam";
            this.productNaamColumn.Name = "productNaamColumn";
            this.productNaamColumn.ReadOnly = true;
            // 
            // productPrijsColumn
            // 
            this.productPrijsColumn.HeaderText = "Prijs";
            this.productPrijsColumn.Name = "productPrijsColumn";
            this.productPrijsColumn.ReadOnly = true;
            // 
            // productAantalColumn
            // 
            this.productAantalColumn.HeaderText = "Beschikbaar";
            this.productAantalColumn.Name = "productAantalColumn";
            this.productAantalColumn.ReadOnly = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(194, 212);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Saldo: ";
            // 
            // saldoLabel
            // 
            this.saldoLabel.AutoSize = true;
            this.saldoLabel.Location = new System.Drawing.Point(228, 212);
            this.saldoLabel.Name = "saldoLabel";
            this.saldoLabel.Size = new System.Drawing.Size(13, 13);
            this.saldoLabel.TabIndex = 10;
            this.saldoLabel.Text = "0";
            // 
            // Winkel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 255);
            this.Controls.Add(this.saldoLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.aantalSelector);
            this.Controls.Add(this.historieBox);
            this.Controls.Add(this.productenBox);
            this.Controls.Add(this.koopButton);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Winkel";
            this.Text = "Winkel";
            this.Load += new System.EventHandler(this.Winkel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.productenBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.historieBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aantalSelector)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button koopButton;
        private System.Windows.Forms.DataGridView productenBox;
        private System.Windows.Forms.DataGridView historieBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn histNaamColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn histPrijsColumn;
        private System.Windows.Forms.NumericUpDown aantalSelector;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn productIdColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productNaamColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productPrijsColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productAantalColumn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label saldoLabel;
    }
}