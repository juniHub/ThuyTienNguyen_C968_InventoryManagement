
namespace ThuyTienNguyen_C968_InventoryManagement
{
    partial class MainScreen
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.labelProduct = new System.Windows.Forms.Label();
            this.labelPart = new System.Windows.Forms.Label();
            this.labelMain = new System.Windows.Forms.Label();
            this.searchTextBox1 = new System.Windows.Forms.TextBox();
            this.searchTextBox2 = new System.Windows.Forms.TextBox();
            this.SearchPart = new System.Windows.Forms.Button();
            this.SearchProduct = new System.Windows.Forms.Button();
            this.AddPart = new System.Windows.Forms.Button();
            this.ModifyPart = new System.Windows.Forms.Button();
            this.DeletePart = new System.Windows.Forms.Button();
            this.AddProduct = new System.Windows.Forms.Button();
            this.ModifyProduct = new System.Windows.Forms.Button();
            this.DeleteProduct = new System.Windows.Forms.Button();
            this.Exit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(24, 169);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(673, 294);
            this.dataGridView1.StandardTab = true;
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(750, 169);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView2.MultiSelect = false;
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(673, 294);
            this.dataGridView2.StandardTab = true;
            this.dataGridView2.TabIndex = 6;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // labelProduct
            // 
            this.labelProduct.AutoSize = true;
            this.labelProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProduct.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.labelProduct.Location = new System.Drawing.Point(746, 123);
            this.labelProduct.Name = "labelProduct";
            this.labelProduct.Size = new System.Drawing.Size(72, 20);
            this.labelProduct.TabIndex = 2;
            this.labelProduct.Text = "Products";
            // 
            // labelPart
            // 
            this.labelPart.AutoSize = true;
            this.labelPart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPart.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.labelPart.Location = new System.Drawing.Point(20, 123);
            this.labelPart.Name = "labelPart";
            this.labelPart.Size = new System.Drawing.Size(46, 20);
            this.labelPart.TabIndex = 3;
            this.labelPart.Text = "Parts";
            // 
            // labelMain
            // 
            this.labelMain.AutoSize = true;
            this.labelMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMain.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.labelMain.Location = new System.Drawing.Point(18, 25);
            this.labelMain.Name = "labelMain";
            this.labelMain.Size = new System.Drawing.Size(389, 31);
            this.labelMain.TabIndex = 4;
            this.labelMain.Text = "Inventory Management System";
            // 
            // searchTextBox1
            // 
            this.searchTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchTextBox1.ForeColor = System.Drawing.SystemColors.GrayText;
            this.searchTextBox1.Location = new System.Drawing.Point(489, 117);
            this.searchTextBox1.Name = "searchTextBox1";
            this.searchTextBox1.Size = new System.Drawing.Size(208, 26);
            this.searchTextBox1.TabIndex = 14;
            this.searchTextBox1.Text = "Search Part Name Here...";
            this.searchTextBox1.TextChanged += new System.EventHandler(this.ResetGrid1Search_TextChanged);
            this.searchTextBox1.Enter += new System.EventHandler(this.Grid1SearchEnter_TextChanged);
            this.searchTextBox1.Leave += new System.EventHandler(this.Grid1SearchLeave_TextChanged);
            // 
            // searchTextBox2
            // 
            this.searchTextBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchTextBox2.ForeColor = System.Drawing.SystemColors.GrayText;
            this.searchTextBox2.Location = new System.Drawing.Point(1199, 117);
            this.searchTextBox2.Name = "searchTextBox2";
            this.searchTextBox2.Size = new System.Drawing.Size(224, 26);
            this.searchTextBox2.TabIndex = 15;
            this.searchTextBox2.Text = "Search Product Name Here...";
            this.searchTextBox2.TextChanged += new System.EventHandler(this.ResetGrid2Search_TextChanged);
            this.searchTextBox2.Enter += new System.EventHandler(this.Grid2SearchEnter_TextChanged);
            this.searchTextBox2.Leave += new System.EventHandler(this.Grid2SearchLeave_TextChanged);
            // 
            // SearchPart
            // 
            this.SearchPart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchPart.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.SearchPart.Location = new System.Drawing.Point(395, 113);
            this.SearchPart.Name = "SearchPart";
            this.SearchPart.Size = new System.Drawing.Size(88, 34);
            this.SearchPart.TabIndex = 16;
            this.SearchPart.Text = "Search";
            this.SearchPart.UseVisualStyleBackColor = true;
            this.SearchPart.Click += new System.EventHandler(this.Grid1Search_Click);
            // 
            // SearchProduct
            // 
            this.SearchProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchProduct.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.SearchProduct.Location = new System.Drawing.Point(1105, 113);
            this.SearchProduct.Name = "SearchProduct";
            this.SearchProduct.Size = new System.Drawing.Size(88, 34);
            this.SearchProduct.TabIndex = 17;
            this.SearchProduct.Text = "Search";
            this.SearchProduct.UseVisualStyleBackColor = true;
            this.SearchProduct.Click += new System.EventHandler(this.Grid2Search_Click);
            // 
            // AddPart
            // 
            this.AddPart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddPart.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.AddPart.Location = new System.Drawing.Point(395, 484);
            this.AddPart.Name = "AddPart";
            this.AddPart.Size = new System.Drawing.Size(88, 34);
            this.AddPart.TabIndex = 18;
            this.AddPart.Text = "Add";
            this.AddPart.UseVisualStyleBackColor = true;
            this.AddPart.Click += new System.EventHandler(this.Grid1Add_Click);
            // 
            // ModifyPart
            // 
            this.ModifyPart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ModifyPart.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.ModifyPart.Location = new System.Drawing.Point(503, 484);
            this.ModifyPart.Name = "ModifyPart";
            this.ModifyPart.Size = new System.Drawing.Size(88, 34);
            this.ModifyPart.TabIndex = 19;
            this.ModifyPart.Text = "Modify";
            this.ModifyPart.UseVisualStyleBackColor = true;
            this.ModifyPart.Click += new System.EventHandler(this.Grid1Modify_Click);
            // 
            // DeletePart
            // 
            this.DeletePart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeletePart.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.DeletePart.Location = new System.Drawing.Point(609, 484);
            this.DeletePart.Name = "DeletePart";
            this.DeletePart.Size = new System.Drawing.Size(88, 34);
            this.DeletePart.TabIndex = 20;
            this.DeletePart.Text = "Delete";
            this.DeletePart.UseVisualStyleBackColor = true;
            this.DeletePart.Click += new System.EventHandler(this.Grid1Delete_Click);
            // 
            // AddProduct
            // 
            this.AddProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddProduct.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.AddProduct.Location = new System.Drawing.Point(1117, 484);
            this.AddProduct.Name = "AddProduct";
            this.AddProduct.Size = new System.Drawing.Size(88, 34);
            this.AddProduct.TabIndex = 21;
            this.AddProduct.Text = "Add";
            this.AddProduct.UseVisualStyleBackColor = true;
            this.AddProduct.Click += new System.EventHandler(this.Grid2Add_Click);
            // 
            // ModifyProduct
            // 
            this.ModifyProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ModifyProduct.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.ModifyProduct.Location = new System.Drawing.Point(1225, 484);
            this.ModifyProduct.Name = "ModifyProduct";
            this.ModifyProduct.Size = new System.Drawing.Size(88, 34);
            this.ModifyProduct.TabIndex = 22;
            this.ModifyProduct.Text = "Modify";
            this.ModifyProduct.UseVisualStyleBackColor = true;
            this.ModifyProduct.Click += new System.EventHandler(this.Grid2Modify_Click);
            // 
            // DeleteProduct
            // 
            this.DeleteProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteProduct.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.DeleteProduct.Location = new System.Drawing.Point(1335, 484);
            this.DeleteProduct.Name = "DeleteProduct";
            this.DeleteProduct.Size = new System.Drawing.Size(88, 34);
            this.DeleteProduct.TabIndex = 23;
            this.DeleteProduct.Text = "Delete";
            this.DeleteProduct.UseVisualStyleBackColor = true;
            this.DeleteProduct.Click += new System.EventHandler(this.Grid2Delete_Click);
            // 
            // Exit
            // 
            this.Exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Exit.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.Exit.Location = new System.Drawing.Point(1335, 554);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(88, 34);
            this.Exit.TabIndex = 24;
            this.Exit.Text = "Exit";
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(1885, 641);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.DeleteProduct);
            this.Controls.Add(this.ModifyProduct);
            this.Controls.Add(this.AddProduct);
            this.Controls.Add(this.DeletePart);
            this.Controls.Add(this.ModifyPart);
            this.Controls.Add(this.AddPart);
            this.Controls.Add(this.SearchProduct);
            this.Controls.Add(this.SearchPart);
            this.Controls.Add(this.searchTextBox2);
            this.Controls.Add(this.searchTextBox1);
            this.Controls.Add(this.labelMain);
            this.Controls.Add(this.labelPart);
            this.Controls.Add(this.labelProduct);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainScreen";
            this.Text = "Main Screen";
            this.Load += new System.EventHandler(this.MainScreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label labelProduct;
        private System.Windows.Forms.Label labelPart;
        private System.Windows.Forms.Label labelMain;
        private System.Windows.Forms.TextBox searchTextBox1;
        private System.Windows.Forms.TextBox searchTextBox2;
        private System.Windows.Forms.Button SearchPart;
        private System.Windows.Forms.Button SearchProduct;
        private System.Windows.Forms.Button AddPart;
        private System.Windows.Forms.Button ModifyPart;
        private System.Windows.Forms.Button DeletePart;
        private System.Windows.Forms.Button AddProduct;
        private System.Windows.Forms.Button ModifyProduct;
        private System.Windows.Forms.Button DeleteProduct;
        private System.Windows.Forms.Button Exit;
     
    }
}