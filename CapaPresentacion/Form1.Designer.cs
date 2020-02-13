namespace CapaPresentacion
{
    partial class Form1
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
            Janus.Windows.GridEX.GridEXLayout checkedComboBox1_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            Janus.Windows.GridEX.GridEXLayout checkedComboBox2_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            this.data = new Janus.Windows.GridEX.GridEX();
            this.checkedComboBox1 = new Janus.Windows.GridEX.EditControls.CheckedComboBox();
            this.maskedEditBox1 = new Janus.Windows.GridEX.EditControls.MaskedEditBox();
            this.numericEditBox1 = new Janus.Windows.GridEX.EditControls.NumericEditBox();
            this.uiButton1 = new Janus.Windows.EditControls.UIButton();
            this.calendarCombo1 = new Janus.Windows.CalendarCombo.CalendarCombo();
            this.checkedComboBox2 = new Janus.Windows.GridEX.EditControls.CheckedComboBox();
            this.ribbon1 = new Janus.Windows.Ribbon.Ribbon();
            this.dropDownCommand1 = new Janus.Windows.Ribbon.DropDownCommand();
            this.dropDownCommand2 = new Janus.Windows.Ribbon.DropDownCommand();
            this.dropDownCommand3 = new Janus.Windows.Ribbon.DropDownCommand();
            this.ribbonTab1 = new Janus.Windows.Ribbon.RibbonTab();
            this.ribbonGroup1 = new Janus.Windows.Ribbon.RibbonGroup();
            this.buttonCommand1 = new Janus.Windows.Ribbon.ButtonCommand();
            this.ribbonGroup2 = new Janus.Windows.Ribbon.RibbonGroup();
            this.ribbonTab2 = new Janus.Windows.Ribbon.RibbonTab();
            this.ribbonTab3 = new Janus.Windows.Ribbon.RibbonTab();
            this.uiColorPicker1 = new Janus.Windows.EditControls.UIColorPicker();
            this.uiColorButton1 = new Janus.Windows.EditControls.UIColorButton();
            this.uiFontPicker1 = new Janus.Windows.EditControls.UIFontPicker();
            this.uiPager1 = new Janus.Windows.UI.Dock.UIPager();
            this.integerUpDown1 = new Janus.Windows.GridEX.EditControls.IntegerUpDown();
            this.gridEXFieldChooserControl1 = new Janus.Windows.GridEX.GridEXFieldChooserControl();
            this.uiButton2 = new Janus.Windows.EditControls.UIButton();
            ((System.ComponentModel.ISupportInitialize)(this.data)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon1)).BeginInit();
            this.SuspendLayout();
            // 
            // data
            // 
            this.data.Location = new System.Drawing.Point(226, 80);
            this.data.Name = "data";
            this.data.Size = new System.Drawing.Size(323, 153);
            this.data.TabIndex = 0;
            // 
            // checkedComboBox1
            // 
            checkedComboBox1_DesignTimeLayout.LayoutString = resources.GetString("checkedComboBox1_DesignTimeLayout.LayoutString");
            this.checkedComboBox1.DesignTimeLayout = checkedComboBox1_DesignTimeLayout;
            this.checkedComboBox1.Location = new System.Drawing.Point(99, 40);
            this.checkedComboBox1.Name = "checkedComboBox1";
            this.checkedComboBox1.SaveSettings = false;
            this.checkedComboBox1.Size = new System.Drawing.Size(112, 20);
            this.checkedComboBox1.TabIndex = 1;
            this.checkedComboBox1.ValuesDataMember = null;
            // 
            // maskedEditBox1
            // 
            this.maskedEditBox1.Location = new System.Drawing.Point(83, 175);
            this.maskedEditBox1.Name = "maskedEditBox1";
            this.maskedEditBox1.Size = new System.Drawing.Size(100, 20);
            this.maskedEditBox1.TabIndex = 2;
            // 
            // numericEditBox1
            // 
            this.numericEditBox1.Location = new System.Drawing.Point(99, 237);
            this.numericEditBox1.Name = "numericEditBox1";
            this.numericEditBox1.Size = new System.Drawing.Size(100, 20);
            this.numericEditBox1.TabIndex = 3;
            this.numericEditBox1.Text = "0,00";
            this.numericEditBox1.Value = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // uiButton1
            // 
            this.uiButton1.Location = new System.Drawing.Point(375, 33);
            this.uiButton1.Name = "uiButton1";
            this.uiButton1.Size = new System.Drawing.Size(75, 23);
            this.uiButton1.TabIndex = 4;
            this.uiButton1.Text = "uiButton1";
            this.uiButton1.Click += new System.EventHandler(this.UiButton1_Click);
            // 
            // calendarCombo1
            // 
            this.calendarCombo1.DateFormat = Janus.Windows.CalendarCombo.DateFormat.Long;
            // 
            // 
            // 
            this.calendarCombo1.DropDownCalendar.Name = "";
            this.calendarCombo1.Location = new System.Drawing.Point(577, 53);
            this.calendarCombo1.Name = "calendarCombo1";
            this.calendarCombo1.Size = new System.Drawing.Size(133, 20);
            this.calendarCombo1.TabIndex = 5;
            // 
            // checkedComboBox2
            // 
            checkedComboBox2_DesignTimeLayout.LayoutString = resources.GetString("checkedComboBox2_DesignTimeLayout.LayoutString");
            this.checkedComboBox2.DesignTimeLayout = checkedComboBox2_DesignTimeLayout;
            this.checkedComboBox2.Location = new System.Drawing.Point(628, 137);
            this.checkedComboBox2.Name = "checkedComboBox2";
            this.checkedComboBox2.SaveSettings = false;
            this.checkedComboBox2.Size = new System.Drawing.Size(100, 20);
            this.checkedComboBox2.TabIndex = 6;
            this.checkedComboBox2.ValuesDataMember = null;
            // 
            // ribbon1
            // 
            this.ribbon1.ControlBoxMenu.LeftCommands.AddRange(new Janus.Windows.Ribbon.CommandBase[] {
            this.dropDownCommand1});
            this.ribbon1.ControlBoxMenu.RightCommands.AddRange(new Janus.Windows.Ribbon.CommandBase[] {
            this.dropDownCommand2,
            this.dropDownCommand3});
            this.ribbon1.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.Name = "ribbon1";
            this.ribbon1.Size = new System.Drawing.Size(824, 146);
            // 
            // 
            // 
            this.ribbon1.SuperTipComponent.AutoPopDelay = 2000;
            this.ribbon1.SuperTipComponent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ribbon1.SuperTipComponent.ImageList = null;
            this.ribbon1.TabIndex = 7;
            this.ribbon1.Tabs.AddRange(new Janus.Windows.Ribbon.RibbonTab[] {
            this.ribbonTab1,
            this.ribbonTab2,
            this.ribbonTab3});
            // 
            // dropDownCommand1
            // 
            this.dropDownCommand1.Key = "dropDownCommand1";
            this.dropDownCommand1.Name = "dropDownCommand1";
            this.dropDownCommand1.Text = "qqfdafd";
            // 
            // dropDownCommand2
            // 
            this.dropDownCommand2.Key = "dropDownCommand2";
            this.dropDownCommand2.Name = "dropDownCommand2";
            this.dropDownCommand2.Text = "sdfasfd";
            // 
            // dropDownCommand3
            // 
            this.dropDownCommand3.Key = "dropDownCommand3";
            this.dropDownCommand3.Name = "dropDownCommand3";
            this.dropDownCommand3.Text = "adsf";
            // 
            // ribbonTab1
            // 
            this.ribbonTab1.Groups.AddRange(new Janus.Windows.Ribbon.RibbonGroup[] {
            this.ribbonGroup1,
            this.ribbonGroup2});
            this.ribbonTab1.Key = "ribbonTab1";
            this.ribbonTab1.Name = "ribbonTab1";
            this.ribbonTab1.Text = "Tab 1";
            // 
            // ribbonGroup1
            // 
            this.ribbonGroup1.Commands.AddRange(new Janus.Windows.Ribbon.CommandBase[] {
            this.buttonCommand1});
            this.ribbonGroup1.Key = "ribbonGroup1";
            this.ribbonGroup1.Name = "ribbonGroup1";
            this.ribbonGroup1.Text = "Group 0";
            // 
            // buttonCommand1
            // 
            this.buttonCommand1.Key = "buttonCommand1";
            this.buttonCommand1.Name = "buttonCommand1";
            this.buttonCommand1.Text = "buttonCommand1";
            // 
            // ribbonGroup2
            // 
            this.ribbonGroup2.Key = "ribbonGroup2";
            this.ribbonGroup2.Name = "ribbonGroup2";
            this.ribbonGroup2.Text = "Group 1";
            // 
            // ribbonTab2
            // 
            this.ribbonTab2.Key = "ribbonTab2";
            this.ribbonTab2.Name = "ribbonTab2";
            this.ribbonTab2.Text = "Tab 2";
            // 
            // ribbonTab3
            // 
            this.ribbonTab3.Key = "ribbonTab3";
            this.ribbonTab3.Name = "ribbonTab3";
            this.ribbonTab3.Text = "Tab 3";
            // 
            // uiColorPicker1
            // 
            this.uiColorPicker1.Location = new System.Drawing.Point(577, 187);
            this.uiColorPicker1.Name = "uiColorPicker1";
            this.uiColorPicker1.Size = new System.Drawing.Size(152, 149);
            this.uiColorPicker1.TabIndex = 8;
            this.uiColorPicker1.Text = "uiColorPicker1";
            // 
            // uiColorButton1
            // 
            // 
            // 
            // 
            this.uiColorButton1.ColorPicker.BorderStyle = Janus.Windows.UI.BorderStyle.None;
            this.uiColorButton1.ColorPicker.Location = new System.Drawing.Point(0, 0);
            this.uiColorButton1.ColorPicker.Name = "";
            this.uiColorButton1.ColorPicker.Size = new System.Drawing.Size(100, 100);
            this.uiColorButton1.ColorPicker.TabIndex = 0;
            this.uiColorButton1.Location = new System.Drawing.Point(424, 266);
            this.uiColorButton1.Name = "uiColorButton1";
            this.uiColorButton1.Size = new System.Drawing.Size(147, 36);
            this.uiColorButton1.TabIndex = 9;
            this.uiColorButton1.Text = "uiColorButton1";
            // 
            // uiFontPicker1
            // 
            this.uiFontPicker1.Location = new System.Drawing.Point(154, 266);
            this.uiFontPicker1.Name = "uiFontPicker1";
            this.uiFontPicker1.Size = new System.Drawing.Size(161, 22);
            this.uiFontPicker1.TabIndex = 10;
            // 
            // uiPager1
            // 
            this.uiPager1.Location = new System.Drawing.Point(361, 308);
            this.uiPager1.Name = "uiPager1";
            this.uiPager1.Size = new System.Drawing.Size(131, 16);
            // 
            // integerUpDown1
            // 
            this.integerUpDown1.Location = new System.Drawing.Point(83, 211);
            this.integerUpDown1.Maximum = 1000000;
            this.integerUpDown1.Name = "integerUpDown1";
            this.integerUpDown1.Size = new System.Drawing.Size(100, 20);
            this.integerUpDown1.TabIndex = 12;
            // 
            // gridEXFieldChooserControl1
            // 
            this.gridEXFieldChooserControl1.Location = new System.Drawing.Point(354, 266);
            this.gridEXFieldChooserControl1.Name = "gridEXFieldChooserControl1";
            this.gridEXFieldChooserControl1.Size = new System.Drawing.Size(96, 70);
            this.gridEXFieldChooserControl1.TabIndex = 13;
            this.gridEXFieldChooserControl1.Text = "gridEXFieldChooserControl1";
            // 
            // uiButton2
            // 
            this.uiButton2.Location = new System.Drawing.Point(19, 227);
            this.uiButton2.Name = "uiButton2";
            this.uiButton2.Size = new System.Drawing.Size(75, 23);
            this.uiButton2.TabIndex = 14;
            this.uiButton2.Text = "uiButton2";
            this.uiButton2.VisualStyle = Janus.Windows.UI.VisualStyle.VS2005;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(824, 448);
            this.Controls.Add(this.uiButton2);
            this.Controls.Add(this.gridEXFieldChooserControl1);
            this.Controls.Add(this.integerUpDown1);
            this.Controls.Add(this.uiPager1);
            this.Controls.Add(this.uiFontPicker1);
            this.Controls.Add(this.uiColorButton1);
            this.Controls.Add(this.uiColorPicker1);
            this.Controls.Add(this.ribbon1);
            this.Controls.Add(this.checkedComboBox2);
            this.Controls.Add(this.calendarCombo1);
            this.Controls.Add(this.uiButton1);
            this.Controls.Add(this.numericEditBox1);
            this.Controls.Add(this.maskedEditBox1);
            this.Controls.Add(this.checkedComboBox1);
            this.Controls.Add(this.data);
            this.HelpButton = true;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.data)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Janus.Windows.GridEX.GridEX data;
        private Janus.Windows.GridEX.EditControls.CheckedComboBox checkedComboBox1;
        private Janus.Windows.GridEX.EditControls.MaskedEditBox maskedEditBox1;
        private Janus.Windows.GridEX.EditControls.NumericEditBox numericEditBox1;
        private Janus.Windows.EditControls.UIButton uiButton1;
        private Janus.Windows.CalendarCombo.CalendarCombo calendarCombo1;
        private Janus.Windows.GridEX.EditControls.CheckedComboBox checkedComboBox2;
        private Janus.Windows.Ribbon.Ribbon ribbon1;
        private Janus.Windows.Ribbon.RibbonTab ribbonTab1;
        private Janus.Windows.EditControls.UIColorPicker uiColorPicker1;
        private Janus.Windows.EditControls.UIColorButton uiColorButton1;
        private Janus.Windows.EditControls.UIFontPicker uiFontPicker1;
        private Janus.Windows.Ribbon.DropDownCommand dropDownCommand1;
        private Janus.Windows.Ribbon.DropDownCommand dropDownCommand2;
        private Janus.Windows.Ribbon.DropDownCommand dropDownCommand3;
        private Janus.Windows.Ribbon.RibbonGroup ribbonGroup1;
        private Janus.Windows.Ribbon.ButtonCommand buttonCommand1;
        private Janus.Windows.Ribbon.RibbonGroup ribbonGroup2;
        private Janus.Windows.Ribbon.RibbonTab ribbonTab2;
        private Janus.Windows.Ribbon.RibbonTab ribbonTab3;
        private Janus.Windows.UI.Dock.UIPager uiPager1;
        private Janus.Windows.GridEX.EditControls.IntegerUpDown integerUpDown1;
        private Janus.Windows.GridEX.GridEXFieldChooserControl gridEXFieldChooserControl1;
        private Janus.Windows.EditControls.UIButton uiButton2;
    }
}