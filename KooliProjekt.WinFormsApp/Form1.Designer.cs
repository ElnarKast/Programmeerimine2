namespace KooliProjekt.WinFormsApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            BuildingGrid = new DataGridView();
            IdLabel = new Label();
            IdField = new TextBox();
            TitleLabel = new Label();
            TitleField = new TextBox();
            NewButton = new Button();
            SaveButton = new Button();
            DeleteButton = new Button();
            NameLabel = new Label();
            NameField = new TextBox();
            DescriptionLabel = new Label();
            DescriptionField = new TextBox();
            ((System.ComponentModel.ISupportInitialize)BuildingGrid).BeginInit();
            SuspendLayout();
            // 
            // BuildingGrid
            // 
            BuildingGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            BuildingGrid.Location = new Point(5, 6);
            BuildingGrid.MultiSelect = false;
            BuildingGrid.Name = "BuildingGrid";
            BuildingGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            BuildingGrid.Size = new Size(419, 432);
            BuildingGrid.TabIndex = 0;
            // 
            // IdLabel
            // 
            IdLabel.AutoSize = true;
            IdLabel.Location = new Point(460, 16);
            IdLabel.Name = "IdLabel";
            IdLabel.Size = new Size(21, 15);
            IdLabel.TabIndex = 1;
            IdLabel.Text = "ID:";
            // 
            // IdField
            // 
            IdField.Location = new Point(507, 13);
            IdField.Name = "IdField";
            IdField.ReadOnly = true;
            IdField.Size = new Size(281, 23);
            IdField.TabIndex = 2;
            // 
            // TitleLabel
            // 
            TitleLabel.AutoSize = true;
            TitleLabel.Location = new Point(460, 56);
            TitleLabel.Name = "TitleLabel";
            TitleLabel.Size = new Size(33, 15);
            TitleLabel.TabIndex = 3;
            TitleLabel.Text = "Title:";
            // 
            // TitleField
            // 
            TitleField.Location = new Point(507, 53);
            TitleField.Name = "TitleField";
            TitleField.Size = new Size(281, 23);
            TitleField.TabIndex = 4;
            // 
            // NewButton
            // 
            NewButton.Location = new Point(525, 164);
            NewButton.Name = "NewButton";
            NewButton.Size = new Size(75, 23);
            NewButton.TabIndex = 5;
            NewButton.Text = "New";
            NewButton.UseVisualStyleBackColor = true;
            // 
            // SaveButton
            // 
            SaveButton.Location = new Point(606, 164);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(75, 23);
            SaveButton.TabIndex = 6;
            SaveButton.Text = "Save";
            SaveButton.UseVisualStyleBackColor = true;
            // 
            // DeleteButton
            // 
            DeleteButton.Location = new Point(687, 164);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(75, 23);
            DeleteButton.TabIndex = 7;
            DeleteButton.Text = "Delete";
            DeleteButton.UseVisualStyleBackColor = true;
            // 
            // NameLabel
            // 
            NameLabel.AutoSize = true;
            NameLabel.Location = new Point(460, 94);
            NameLabel.Name = "NameLabel";
            NameLabel.Size = new Size(42, 15);
            NameLabel.TabIndex = 8;
            NameLabel.Text = "Name:";
            // 
            // NameField
            // 
            NameField.Location = new Point(507, 86);
            NameField.Name = "NameField";
            NameField.Size = new Size(281, 23);
            NameField.TabIndex = 9;
            // 
            // DescriptionLabel
            // 
            DescriptionLabel.AutoSize = true;
            DescriptionLabel.Location = new Point(432, 125);
            DescriptionLabel.Name = "DescriptionLabel";
            DescriptionLabel.Size = new Size(70, 15);
            DescriptionLabel.TabIndex = 10;
            DescriptionLabel.Text = "Description:";

            // 
            // DescriptionField
            // 
            DescriptionField.Location = new Point(507, 122);
            DescriptionField.Name = "DescriptionField";
            DescriptionField.Size = new Size(281, 23);
            DescriptionField.TabIndex = 11;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(DescriptionField);
            Controls.Add(DescriptionLabel);
            Controls.Add(NameField);
            Controls.Add(NameLabel);
            Controls.Add(DeleteButton);
            Controls.Add(SaveButton);
            Controls.Add(NewButton);
            Controls.Add(TitleField);
            Controls.Add(TitleLabel);
            Controls.Add(IdField);
            Controls.Add(IdLabel);
            Controls.Add(BuildingGrid);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)BuildingGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView BuildingGrid;
        private Label IdLabel;
        private TextBox IdField;
        private Label TitleLabel;
        private TextBox TitleField;
        private Button NewButton;
        private Button SaveButton;
        private Button DeleteButton;
        private Label NameLabel;
        private TextBox NameField;
        private Label DescriptionLabel;
        private TextBox DescriptionField;
    }
}