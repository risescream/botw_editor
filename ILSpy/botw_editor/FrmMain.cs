using System;
using System.ComponentModel;
using System.Deployment.Application;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace botw_editor
{
	public class FrmMain : Form
	{
		private App myApp;

		public string revision = "d";

		private IContainer components;

		private TabPage tabPage9;

		private TabPage tabPage1;

		private TabPage tabPage2;

		private TabPage tabPage3;

		private TabPage tabPage4;

		private TabPage tabPage5;

		private TabPage tabPage6;

		private TabPage tabPage7;

		private TabPage tabPage8;

		private TabPage tabPage12;

		private Button btnScan;

		public ListBox lstInventory;

		private Label lblScan;

		private GroupBox gbInventoryEdit;

		private Label label3;

		private Label label2;

		private Label label1;

		public ComboBox cbInventoryItemName;

		public TextBox txtInventoryItemQtDur;

		public TextBox txtInventoryItemID;

		private Label label4;

		public TextBox txtInventoryItemBonusValue;

		private Label label5;

		public TextBox txtInventoryItemBonusType;

		private GroupBox gbWeaponsEdit;

		public Button btnWeaponsItemUpdate;

		private Label label6;

		public TextBox txtWeaponsItemBonusValue;

		private Label label7;

		public TextBox txtWeaponsItemBonusType;

		private Label label8;

		public ComboBox cbWeaponsItemName;

		private Label label9;

		public TextBox txtWeaponsItemQtDur;

		private Label label10;

		public TextBox txtWeaponsItemID;

		public ListBox lstWeapons;

		private GroupBox gbArcheryEdit;

		public Button btnArcheryItemUpdate;

		private Label label11;

		public TextBox txtArcheryItemBonusValue;

		private Label label12;

		public TextBox txtArcheryItemBonusType;

		private Label label13;

		public ComboBox cbArcheryItemName;

		private Label label14;

		public TextBox txtArcheryItemQtDur;

		private Label label15;

		public TextBox txtArcheryItemID;

		public ListBox lstArchery;

		private GroupBox gbShieldsEdit;

		public Button btnShieldsItemUpdate;

		private Label label16;

		public TextBox txtShieldsItemBonusValue;

		private Label label17;

		public TextBox txtShieldsItemBonusType;

		private Label label18;

		public ComboBox cbShieldsItemName;

		private Label label19;

		public TextBox txtShieldsItemQtDur;

		private Label label20;

		public TextBox txtShieldsItemID;

		public ListBox lstShields;

		private GroupBox gbArmorsEdit;

		public Button btnArmorsItemUpdate;

		private Label label21;

		public TextBox txtArmorsItemBonusValue;

		private Label label22;

		public TextBox txtArmorsItemBonusType;

		private Label label23;

		public ComboBox cbArmorsItemName;

		private Label label24;

		public TextBox txtArmorsItemQtDur;

		private Label label25;

		public TextBox txtArmorsItemID;

		public ListBox lstArmors;

		private GroupBox gbMaterialsEdit;

		public Button btnMaterialsItemUpdate;

		private Label label26;

		public TextBox txtMaterialsItemBonusValue;

		private Label label27;

		public TextBox txtMaterialsItemBonusType;

		private Label label28;

		public ComboBox cbMaterialsItemName;

		private Label label29;

		public TextBox txtMaterialsItemQtDur;

		private Label label30;

		public TextBox txtMaterialsItemID;

		public ListBox lstMaterials;

		private GroupBox gbFoodEdit;

		public Button btnFoodItemUpdate;

		private Label label31;

		public TextBox txtFoodItemBonusValue;

		private Label label32;

		public TextBox txtFoodItemBonusType;

		private Label label33;

		public ComboBox cbFoodItemName;

		private Label label34;

		public TextBox txtFoodItemQtDur;

		private Label label35;

		public TextBox txtFoodItemID;

		public ListBox lstFood;

		private GroupBox gbOtherEdit;

		public Button btnOtherItemUpdate;

		private Label label36;

		public TextBox txtOtherItemBonusValue;

		private Label label37;

		public TextBox txtOtherItemBonusType;

		private Label label38;

		public ComboBox cbOtherItemName;

		private Label label39;

		public TextBox txtOtherItemQtDur;

		private Label label40;

		public TextBox txtOtherItemID;

		public ListBox lstOther;

		private TabPage tabPage13;

		public ComboBox cbActionsList;

		private TextBox txtLog;

		private TabControl tabControl2;

		private TabPage tabPage10;

		private GroupBox groupBox12;

		private Label label45;

		private GroupBox groupBox11;

		public TextBox txtActionsHotKey;

		public CheckBox chkActionsDisableWhenDone;

		public GroupBox gbActionsFilter;

		public ListBox lstActionsFilter;

		public RadioButton optionActionsFilterList;

		public RadioButton optionActionsNoFilter;

		public GroupBox gbActionsSettings;

		public CheckBox chkActionsActiveInactive;

		public TextBox txtActionsMax;

		public Label label41;

		public TextBox txtActionsQuantity;

		public Label label42;

		public TextBox txtActionsTimer;

		public Label label43;

		public TextBox txtActionsFixed;

		public RadioButton optionActionsTimer;

		public RadioButton optionActionsFixed;

		public GroupBox groupBox9;

		public ListBox lstActionsRegistered;

		public Button btnActionsRemove;

		public Button btnActionsNew;

		public TabControl tabActions;

		public TabControl tabItems;

		public TabControl tabMain;

		public CheckBox chkActionsUseHotkey;

		private TabPage tabPage11;

		public GroupBox groupBox13;

		public ListBox lstWeaponsFilter;

		public RadioButton optionWeaponsFilterList;

		public RadioButton optionWeaponsNoFilter;

		public GroupBox groupBox10;

		public CheckBox chkWeaponsUseHotkey;

		public TextBox txtWeaponsHotKey;

		public CheckBox chkWeaponsDisableWhenDone;

		public CheckBox chkWeaponsActiveInactive;

		public TextBox txtWeaponsMax;

		public Label label44;

		public TextBox txtWeaponsQuantity;

		public Label label46;

		public TextBox txtWeaponsTimer;

		public Label label47;

		public TextBox txtWeaponsFixed;

		public RadioButton optionWeaponsTimer;

		public RadioButton optionWeaponsFixed;

		private TabPage tabPage14;

		private TabPage tabPage15;

		private TabPage tabPage16;

		private TabPage tabPage17;

		public GroupBox groupBox17;

		public ListBox lstBowsFilter;

		public RadioButton optionBowsFilterList;

		public RadioButton optionBowsNoFilter;

		public GroupBox groupBox18;

		public CheckBox chkBowsUseHotkey;

		public TextBox txtBowsHotKey;

		public CheckBox chkBowsDisableWhenDone;

		public CheckBox chkBowsActiveInactive;

		public TextBox txtBowsMax;

		public Label label54;

		public TextBox txtBowsQuantity;

		public Label label56;

		public TextBox txtBowsTimer;

		public Label label60;

		public TextBox txtBowsFixed;

		public RadioButton optionBowsTimer;

		public RadioButton optionBowsFixed;

		public GroupBox groupBox20;

		public ListBox lstShieldsFilter;

		public RadioButton optionShieldsFilterList;

		public RadioButton optionShieldsNoFilter;

		public GroupBox groupBox21;

		public CheckBox chkShieldsUseHotkey;

		public TextBox txtShieldsHotKey;

		public CheckBox chkShieldsDisableWhenDone;

		public CheckBox chkShieldsActiveInactive;

		public TextBox txtShieldsMax;

		public Label label61;

		public TextBox txtShieldsQuantity;

		public Label label62;

		public TextBox txtShieldsTimer;

		public Label label63;

		public TextBox txtShieldsFixed;

		public RadioButton optionShieldsTimer;

		public RadioButton optionShieldsFixed;

		public GroupBox groupBox22;

		public ListBox lstArrowsFilter;

		public RadioButton optionArrowsFilterList;

		public RadioButton optionArrowsNoFilter;

		public GroupBox groupBox23;

		public CheckBox chkArrowsUseHotkey;

		public TextBox txtArrowsHotKey;

		public CheckBox chkArrowsDisableWhenDone;

		public CheckBox chkArrowsActiveInactive;

		public TextBox txtArrowsMax;

		public Label label64;

		public TextBox txtArrowsQuantity;

		public Label label65;

		public TextBox txtArrowsTimer;

		public Label label66;

		public TextBox txtArrowsFixed;

		public RadioButton optionArrowsTimer;

		public RadioButton optionArrowsFixed;

		public TextBox txtLockStaminaHotKey;

		public TextBox txtLockHealthHotKey;

		public TextBox txtUnbreakableShieldsHotKey;

		public TextBox txtUnbreakableBowsHotKey;

		public TextBox txtUnbreakableWeaponsHotKey;

		private TabPage tabPage18;

		public TextBox txtPowersDarukHotKey;

		public TextBox txtPowersUrbosaHotKey;

		public TextBox txtPowersRevaliHotKey;

		public TextBox txtPowersMiphaHotKey;

		private TabPage tabPage19;

		public TextBox txtUnlimitAmiiboHotKey;

		private GroupBox gbRupees;

		public Button btnUpdateRupees;

		private Label label71;

		public TextBox txtRupees;

		public Button btnRefreshRupees;

		public TextBox txtTimerUpdateList;

		public CheckBox chkUpdateList;

		public ListBox lstEquippedWeapons;

		public GroupBox groupBox16;

		public Label lblLockStaminaInfo;

		public CheckBox chkLockStaminaSet;

		public CheckBox chkLockStaminaUseHotkey;

		public Label lblLockHealthInfo;

		public CheckBox chkLockHealthSet;

		public CheckBox chkLockHealthUseHotkey;

		public GroupBox groupBox14;

		public Label lblUnbreakableShieldsInfo;

		public CheckBox chkUnbreakableShieldsSet;

		public CheckBox chkUnbreakableShieldsUseHotkey;

		public Label lblUnbreakableBowsInfo;

		public CheckBox chkUnbreakableBowsSet;

		public CheckBox chkUnbreakableBowsUseHotkey;

		public Label lblUnbreakableWeaponsInfo;

		public CheckBox chkUnbreakableWeaponsSet;

		public CheckBox chkUnbreakableWeaponsUseHotkey;

		public GroupBox groupBox19;

		public Label lblPowersDarukInfo;

		public CheckBox chkPowersDarukSet;

		public CheckBox chkPowersDarukUseHotkey;

		public Label lblPowersUrbosaInfo;

		public CheckBox chkPowersUrbosaSet;

		public CheckBox chkPowersUrbosaUseHotkey;

		public Label lblPowersRevaliInfo;

		public CheckBox chkPowersRevaliSet;

		public CheckBox chkPowersRevaliUseHotkey;

		public Label lblPowersMiphaInfo;

		public CheckBox chkPowersMiphaSet;

		public CheckBox chkPowersMiphaUseHotkey;

		public GroupBox groupBox15;

		public Label lblUnlimitAmiiboInfo;

		public CheckBox chkUnlimitAmiiboSet;

		public CheckBox chkUnlimitAmiiboUseHotkey;

		private GroupBox groupBox2;

		private Button btnGameProcessResume;

		private Button btnGameProcessPause;

		private GroupBox groupBox1;

		private Button btnSettingsImport;

		private Button btnSettingsExport;

		private Button btnSettingsClear;

		private Button btnSettingsSave;

		private Label label48;

		private Label lblVersion;

		public GroupBox groupBox3;

		public ListBox lstUnbreakableFilter;

		public RadioButton optionUnbreakableFilterList;

		public RadioButton optionUnbreakableNoFilter;

		public ComboBox cbInventoryItemBonusType;

		public ComboBox cbWeaponsItemBonusType;

		public ComboBox cbArcheryItemBonusType;

		public ComboBox cbShieldsItemBonusType;

		public ComboBox cbArmorsItemBonusType;

		public ComboBox cbMaterialsItemBonusType;

		public ComboBox cbFoodItemBonusType;

		public ComboBox cbOtherItemBonusType;

		public Button btnInventoryItemUpdate;

		public GroupBox groupBox4;

		public Button btnRunSpeedDefault;

		public TextBox txtRunSpeedDefaultHotKey;

		public CheckBox chkRunSpeedDefaultUseHotkey;

		public Button btnRunSpeedDown;

		public TextBox txtRunSpeedDownHotKey;

		public CheckBox chkRunSpeedDownUseHotkey;

		public Button btnRunSpeedUp;

		public TextBox txtRunSpeedUpHotKey;

		public CheckBox chkRunSpeedUpUseHotkey;

		public Button btnRunSpeedUpdate;

		private Label label49;

		public TextBox txtRunSpeed;

		private TabPage tabPage20;

		private GroupBox gbShieldsSlots;

		public Button btnRefreshShieldsSlots;

		public Button btnUpdateShieldsSlots;

		private Label label52;

		public TextBox txtShieldsSlots;

		private GroupBox gbBowsSlots;

		public Button btnRefreshBowsSlots;

		public Button btnUpdateBowsSlots;

		private Label label51;

		public TextBox txtBowsSlots;

		private GroupBox gbWeaponsSlots;

		public Button btnRefreshWeaponsSlots;

		public Button btnUpdateWeaponsSlots;

		private Label label50;

		public TextBox txtWeaponsSlots;

		private GroupBox groupBox5;

		private Label label55;

		private Label label53;

		public NumericUpDown numInternalLoopMs;

		public NumericUpDown numSpacingMs;

		private Button button1;

		private Button button2;

		public Button btnInventoryItemUnlock;

		public Button btnWeaponsItemUnlock;

		public Button btnArcheryItemUnlock;

		public Button btnShieldsItemUnlock;

		public Button btnArmorsItemUnlock;

		public Button btnMaterialsItemUnlock;

		public Button btnFoodItemUnlock;

		public Button btnOtherItemUnlock;

		private TabPage tabPage21;

		public GroupBox groupBox7;

		private Label label68;

		public TextBox txtPositionZ;

		private Label label67;

		public TextBox txtPositionY;

		private Label label59;

		public TextBox txtPositionX;

		public Button btnPositionRestore;

		public TextBox txtPositionRestoreHotKey;

		public CheckBox chkPositionRestoreUseHotkey;

		public Button btnPositionSave;

		public TextBox txtPositionSaveHotKey;

		public CheckBox chkPositionSaveUseHotkey;

		public Button btnPositionJump;

		public TextBox txtPositionJumpHeight;

		public TextBox txtPositionJumpHotKey;

		public CheckBox chkPositionJumpUseHotkey;

		public CheckBox chkPositionLockHeightSet;

		public TextBox txtPositionLockHeightHotKey;

		public CheckBox chkPositionLockHeightUseHotkey;

		public Button btnPositionEdit;

		public GroupBox groupBox6;

		private Label label70;

		public TextBox txtCapturedPositionName;

		private Label label57;

		public TextBox txtCapturedPositionZ;

		private Label label58;

		public TextBox txtCapturedPositionY;

		private Label label69;

		public TextBox txtCapturedPositionX;

		public Button btnCapturedPositionRemove;

		public Button btnCapturedPositionSave;

		public Button btnCapturedPositionNew;

		public ListBox lstCapturedPositions;

		public Button btnCapturedPositionTP;

		private Button button3;

		private TabPage tabPage22;

		public Button btnFindMemoryRegionByAddress;

		private Label label72;

		public TextBox txtFindMemoryRegionByAddress;

		public Button btntxtFindMemoryRegionBySize;

		private Label label73;

		public TextBox txtFindMemoryRegionBySize;

		public Button btnMemoryRegions;

		public TrackBar trackTime;

		public Button btnCompareAddress;

		private Label label74;

		public TextBox txtCompareAddress;

		public Button btnRestoreStaminaBar;

		public Button btnNoStaminaBar;

		public string CurrentVersion
		{
			get
			{
				if (!ApplicationDeployment.IsNetworkDeployed)
				{
					return Assembly.GetExecutingAssembly().GetName().Version.ToString();
				}
				return ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
			}
		}

		public FrmMain()
		{
			this.InitializeComponent();
			Application.CurrentCulture = CultureInfo.InvariantCulture;
			this.lblVersion.Text = "Version " + this.CurrentVersion + this.revision;
			this.lblLockHealthInfo.Text = "";
			this.lblLockStaminaInfo.Text = "";
			this.lblPowersDarukInfo.Text = "";
			this.lblPowersMiphaInfo.Text = "";
			this.lblPowersRevaliInfo.Text = "";
			this.lblPowersUrbosaInfo.Text = "";
			this.lblUnbreakableBowsInfo.Text = "";
			this.lblUnbreakableShieldsInfo.Text = "";
			this.lblUnbreakableWeaponsInfo.Text = "";
			this.lblUnlimitAmiiboInfo.Text = "";
			this.myApp = new App(this);
		}

		public void SetLblScan(string text)
		{
			this.lblScan.Text = text;
			Application.DoEvents();
		}

		public void Putlog(string text)
		{
			string text2 = DateTime.Now.ToString("HH:mm:ss", CultureInfo.InvariantCulture);
			this.txtLog.AppendText(string.Concat(new string[]
			{
				"[",
				text2,
				"] ",
				text,
				Environment.NewLine
			}));
		}

		private void btnScan_Click(object sender, EventArgs e)
		{
			this.myApp.requestMemoryScan();
		}

		private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
		{
			this.myApp.worker.CancelAsync();
			Thread.Sleep(10);
		}

		private void btnGameProcessPause_Click(object sender, EventArgs e)
		{
			this.myApp.suspendGame();
		}

		private void btnGameProcessResume_Click(object sender, EventArgs e)
		{
			this.myApp.resumeGame();
		}

		private void btnSettingsSave_Click(object sender, EventArgs e)
		{
			if (this.myApp.writeSettings(this.myApp.getCurrentSettings(), Settings.getConfigFilePath()))
			{
				MessageBox.Show("Settings saved.");
				this.Putlog("Settings saved.");
				return;
			}
			MessageBox.Show("An error occured.");
		}

		private void btnSettingsClear_Click(object sender, EventArgs e)
		{
			this.myApp.resetSettings();
			Settings currentSettings = this.myApp.getCurrentSettings();
			currentSettings.auto_update = false;
			currentSettings.auto_update_timer = 15;
			for (int i = 0; i < currentSettings.action_datas.Count; i++)
			{
				actiondata actiondata = new actiondata();
				actiondata.section = currentSettings.action_datas[i].section;
				currentSettings.action_datas[i] = actiondata;
			}
			currentSettings.custom_actions.Clear();
			this.myApp.applySettings(currentSettings);
			this.Putlog("Settings cleared.");
		}

		private void btnSettingsExport_Click(object sender, EventArgs e)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.AddExtension = true;
			saveFileDialog.DefaultExt = "xml";
			saveFileDialog.FileName = "config.xml";
			saveFileDialog.Filter = "XML files (*.xml)|*.xml";
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				if (saveFileDialog.FileName.Length > 0 && this.myApp.writeSettings(this.myApp.getCurrentSettings(), saveFileDialog.FileName))
				{
					MessageBox.Show("Settings exported.");
					return;
				}
				MessageBox.Show("Error exporting settings.");
			}
		}

		private void btnSettingsImport_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.AddExtension = true;
			openFileDialog.DefaultExt = "xml";
			openFileDialog.Filter = "XML files (*.xml)|*.xml";
			openFileDialog.FileName = "";
			if (openFileDialog.ShowDialog() == DialogResult.OK && openFileDialog.FileName != "" && File.Exists(openFileDialog.FileName))
			{
				Settings s = this.myApp.readSettings(openFileDialog.FileName);
				this.myApp.applySettings(s);
				this.Putlog("Settings imported from " + openFileDialog.FileName);
			}
		}

		private void btnRunSpeedUpdate_Click(object sender, EventArgs e)
		{
			this.myApp.UpdateRunSpeedMultiplier(this.myApp.GetTxtRunSpeed());
		}

		private void btnRunSpeedDefault_Click(object sender, EventArgs e)
		{
			this.myApp.UpdateRunSpeedMultiplier(1.0);
		}

		private void btnRunSpeedUp_Click(object sender, EventArgs e)
		{
			this.myApp.UpdateRunSpeedMultiplier(this.myApp.GetTxtRunSpeed() + 0.25);
		}

		private void btnRunSpeedDown_Click(object sender, EventArgs e)
		{
			this.myApp.UpdateRunSpeedMultiplier(this.myApp.GetTxtRunSpeed() - 0.25);
		}

		private void btnPositionSave_Click(object sender, EventArgs e)
		{
			this.myApp.SavePosition();
		}

		private void btnPositionRestore_Click(object sender, EventArgs e)
		{
			this.myApp.RestorePosition();
		}

		private void btnPositionJump_Click(object sender, EventArgs e)
		{
			this.myApp.JumpPosition();
		}

		private void btnPositionEdit_Click(object sender, EventArgs e)
		{
			this.myApp.SwitchEditPosition();
		}

		private void btnCapturedPositionNew_Click(object sender, EventArgs e)
		{
			this.myApp.AddCapturedPosition();
		}

		private void btnCapturedPositionSave_Click(object sender, EventArgs e)
		{
			this.myApp.SaveCapturedPosition();
		}

		private void btnCapturedPositionRemove_Click(object sender, EventArgs e)
		{
			this.myApp.RemoveCapturedPosition();
		}

		private void btnCapturedPositionTP_Click(object sender, EventArgs e)
		{
			this.myApp.TPCapturedPosition();
		}

		private void btnRefreshWeaponsSlots_Click(object sender, EventArgs e)
		{
			this.myApp.RefreshTxtSlot("Weapons");
		}

		private void btnRefreshBowsSlots_Click(object sender, EventArgs e)
		{
			this.myApp.RefreshTxtSlot("Bows");
		}

		private void btnRefreshShieldsSlots_Click(object sender, EventArgs e)
		{
			this.myApp.RefreshTxtSlot("Shields");
		}

		private void btnUpdateWeaponsSlots_Click(object sender, EventArgs e)
		{
			this.myApp.UpdateSlot("Weapons", this.myApp.GetTxtSlot("Weapons"));
		}

		private void btnUpdateBowsSlots_Click(object sender, EventArgs e)
		{
			this.myApp.UpdateSlot("Bows", this.myApp.GetTxtSlot("Bows"));
		}

		private void btnUpdateShieldsSlots_Click(object sender, EventArgs e)
		{
			this.myApp.UpdateSlot("Shields", this.myApp.GetTxtSlot("Shields"));
		}

		private void numInternalLoopMs_ValueChanged(object sender, EventArgs e)
		{
			if (this.myApp == null)
			{
				return;
			}
			this.myApp.nbInternalLoopMs = this.myApp.getInternalLoopMsValue();
			this.Putlog("Internal Loop timings set to : " + this.myApp.nbInternalLoopMs + " ms");
		}

		private void numSpacingMs_ValueChanged(object sender, EventArgs e)
		{
			if (this.myApp == null)
			{
				return;
			}
			this.myApp.nbSpacingMs = this.myApp.getSpacingMsValue();
			this.Putlog("Spacing timings set to : " + this.myApp.nbSpacingMs + " ms");
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (this.myApp == null)
			{
				return;
			}
			this.myApp.dumpMemoryToFile("dump.dmp");
		}

		private void button2_Click(object sender, EventArgs e)
		{
			if (this.myApp == null)
			{
				return;
			}
			this.myApp.compareMemory("dump.dmp");
		}

		private void button3_Click(object sender, EventArgs e)
		{
			if (this.myApp == null)
			{
				return;
			}
			string str = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss", CultureInfo.InvariantCulture);
			this.myApp.generateCompareReport("memory_changes_" + str + ".txt");
		}

		private void btnFindMemoryRegionByAddress_Click(object sender, EventArgs e)
		{
			long addr = MemAPI.HexStringToInt64(this.txtFindMemoryRegionByAddress.Text);
			if (this.myApp == null)
			{
				return;
			}
			this.myApp.searchMemoryRegionForAddress(addr);
		}

		private void btntxtFindMemoryRegionBySize_Click(object sender, EventArgs e)
		{
			long size = MemAPI.HexStringToInt64(this.txtFindMemoryRegionBySize.Text);
			long startAddress = MemAPI.HexStringToInt64(this.txtFindMemoryRegionByAddress.Text);
			if (this.myApp == null)
			{
				return;
			}
			this.myApp.searchMemoryRegionForSize(size, startAddress);
		}

		private void btnMemoryRegions_Click(object sender, EventArgs e)
		{
			if (this.myApp == null)
			{
				return;
			}
			this.myApp.listMemoryRegions();
		}

		private void trackTime_ValueChanged(object sender, EventArgs e)
		{
			if (this.myApp == null)
			{
				return;
			}
			if (this.trackTime.Tag != null)
			{
				return;
			}
			int value = this.trackTime.Value;
			this.myApp.setTime(value);
		}

		private void btnCompareAddress_Click(object sender, EventArgs e)
		{
			long address = MemAPI.HexStringToInt64(this.txtCompareAddress.Text);
			if (this.myApp == null)
			{
				return;
			}
			this.myApp.showCompareAddress(address);
		}

		private void btnNoStaminaBar_Click(object sender, EventArgs e)
		{
			if (this.myApp == null)
			{
				return;
			}
			this.myApp.enableStaminaBar(false);
		}

		private void btnRestoreStaminaBar_Click(object sender, EventArgs e)
		{
			if (this.myApp == null)
			{
				return;
			}
			this.myApp.enableStaminaBar(true);
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(FrmMain));
			this.tabMain = new TabControl();
			this.tabPage9 = new TabPage();
			this.txtLog = new TextBox();
			this.tabItems = new TabControl();
			this.tabPage1 = new TabPage();
			this.btnInventoryItemUnlock = new Button();
			this.gbInventoryEdit = new GroupBox();
			this.cbInventoryItemBonusType = new ComboBox();
			this.btnInventoryItemUpdate = new Button();
			this.label4 = new Label();
			this.txtInventoryItemBonusValue = new TextBox();
			this.label5 = new Label();
			this.txtInventoryItemBonusType = new TextBox();
			this.label3 = new Label();
			this.cbInventoryItemName = new ComboBox();
			this.label2 = new Label();
			this.txtInventoryItemQtDur = new TextBox();
			this.label1 = new Label();
			this.txtInventoryItemID = new TextBox();
			this.lstInventory = new ListBox();
			this.tabPage2 = new TabPage();
			this.btnWeaponsItemUnlock = new Button();
			this.gbWeaponsEdit = new GroupBox();
			this.cbWeaponsItemBonusType = new ComboBox();
			this.btnWeaponsItemUpdate = new Button();
			this.label6 = new Label();
			this.txtWeaponsItemBonusValue = new TextBox();
			this.label7 = new Label();
			this.txtWeaponsItemBonusType = new TextBox();
			this.label8 = new Label();
			this.cbWeaponsItemName = new ComboBox();
			this.label9 = new Label();
			this.txtWeaponsItemQtDur = new TextBox();
			this.label10 = new Label();
			this.txtWeaponsItemID = new TextBox();
			this.lstWeapons = new ListBox();
			this.tabPage3 = new TabPage();
			this.btnArcheryItemUnlock = new Button();
			this.gbArcheryEdit = new GroupBox();
			this.cbArcheryItemBonusType = new ComboBox();
			this.btnArcheryItemUpdate = new Button();
			this.label11 = new Label();
			this.txtArcheryItemBonusValue = new TextBox();
			this.label12 = new Label();
			this.txtArcheryItemBonusType = new TextBox();
			this.label13 = new Label();
			this.cbArcheryItemName = new ComboBox();
			this.label14 = new Label();
			this.txtArcheryItemQtDur = new TextBox();
			this.label15 = new Label();
			this.txtArcheryItemID = new TextBox();
			this.lstArchery = new ListBox();
			this.tabPage4 = new TabPage();
			this.btnShieldsItemUnlock = new Button();
			this.gbShieldsEdit = new GroupBox();
			this.cbShieldsItemBonusType = new ComboBox();
			this.btnShieldsItemUpdate = new Button();
			this.label16 = new Label();
			this.txtShieldsItemBonusValue = new TextBox();
			this.label17 = new Label();
			this.txtShieldsItemBonusType = new TextBox();
			this.label18 = new Label();
			this.cbShieldsItemName = new ComboBox();
			this.label19 = new Label();
			this.txtShieldsItemQtDur = new TextBox();
			this.label20 = new Label();
			this.txtShieldsItemID = new TextBox();
			this.lstShields = new ListBox();
			this.tabPage5 = new TabPage();
			this.btnArmorsItemUnlock = new Button();
			this.gbArmorsEdit = new GroupBox();
			this.cbArmorsItemBonusType = new ComboBox();
			this.btnArmorsItemUpdate = new Button();
			this.label21 = new Label();
			this.txtArmorsItemBonusValue = new TextBox();
			this.label22 = new Label();
			this.txtArmorsItemBonusType = new TextBox();
			this.label23 = new Label();
			this.cbArmorsItemName = new ComboBox();
			this.label24 = new Label();
			this.txtArmorsItemQtDur = new TextBox();
			this.label25 = new Label();
			this.txtArmorsItemID = new TextBox();
			this.lstArmors = new ListBox();
			this.tabPage6 = new TabPage();
			this.btnMaterialsItemUnlock = new Button();
			this.gbMaterialsEdit = new GroupBox();
			this.cbMaterialsItemBonusType = new ComboBox();
			this.btnMaterialsItemUpdate = new Button();
			this.label26 = new Label();
			this.txtMaterialsItemBonusValue = new TextBox();
			this.label27 = new Label();
			this.txtMaterialsItemBonusType = new TextBox();
			this.label28 = new Label();
			this.cbMaterialsItemName = new ComboBox();
			this.label29 = new Label();
			this.txtMaterialsItemQtDur = new TextBox();
			this.label30 = new Label();
			this.txtMaterialsItemID = new TextBox();
			this.lstMaterials = new ListBox();
			this.tabPage7 = new TabPage();
			this.btnFoodItemUnlock = new Button();
			this.gbFoodEdit = new GroupBox();
			this.cbFoodItemBonusType = new ComboBox();
			this.btnFoodItemUpdate = new Button();
			this.label31 = new Label();
			this.txtFoodItemBonusValue = new TextBox();
			this.label32 = new Label();
			this.txtFoodItemBonusType = new TextBox();
			this.label33 = new Label();
			this.cbFoodItemName = new ComboBox();
			this.label34 = new Label();
			this.txtFoodItemQtDur = new TextBox();
			this.label35 = new Label();
			this.txtFoodItemID = new TextBox();
			this.lstFood = new ListBox();
			this.tabPage8 = new TabPage();
			this.btnOtherItemUnlock = new Button();
			this.gbOtherEdit = new GroupBox();
			this.cbOtherItemBonusType = new ComboBox();
			this.btnOtherItemUpdate = new Button();
			this.label36 = new Label();
			this.txtOtherItemBonusValue = new TextBox();
			this.label37 = new Label();
			this.txtOtherItemBonusType = new TextBox();
			this.label38 = new Label();
			this.cbOtherItemName = new ComboBox();
			this.label39 = new Label();
			this.txtOtherItemQtDur = new TextBox();
			this.label40 = new Label();
			this.txtOtherItemID = new TextBox();
			this.lstOther = new ListBox();
			this.tabPage12 = new TabPage();
			this.gbRupees = new GroupBox();
			this.btnRefreshRupees = new Button();
			this.btnUpdateRupees = new Button();
			this.label71 = new Label();
			this.txtRupees = new TextBox();
			this.tabPage20 = new TabPage();
			this.gbShieldsSlots = new GroupBox();
			this.btnRefreshShieldsSlots = new Button();
			this.btnUpdateShieldsSlots = new Button();
			this.label52 = new Label();
			this.txtShieldsSlots = new TextBox();
			this.gbBowsSlots = new GroupBox();
			this.btnRefreshBowsSlots = new Button();
			this.btnUpdateBowsSlots = new Button();
			this.label51 = new Label();
			this.txtBowsSlots = new TextBox();
			this.gbWeaponsSlots = new GroupBox();
			this.btnRefreshWeaponsSlots = new Button();
			this.btnUpdateWeaponsSlots = new Button();
			this.label50 = new Label();
			this.txtWeaponsSlots = new TextBox();
			this.btnScan = new Button();
			this.lblScan = new Label();
			this.tabActions = new TabControl();
			this.tabPage11 = new TabPage();
			this.groupBox13 = new GroupBox();
			this.lstWeaponsFilter = new ListBox();
			this.optionWeaponsFilterList = new RadioButton();
			this.optionWeaponsNoFilter = new RadioButton();
			this.groupBox10 = new GroupBox();
			this.chkWeaponsUseHotkey = new CheckBox();
			this.txtWeaponsHotKey = new TextBox();
			this.chkWeaponsDisableWhenDone = new CheckBox();
			this.chkWeaponsActiveInactive = new CheckBox();
			this.txtWeaponsMax = new TextBox();
			this.label44 = new Label();
			this.txtWeaponsQuantity = new TextBox();
			this.label46 = new Label();
			this.txtWeaponsTimer = new TextBox();
			this.label47 = new Label();
			this.txtWeaponsFixed = new TextBox();
			this.optionWeaponsTimer = new RadioButton();
			this.optionWeaponsFixed = new RadioButton();
			this.tabPage14 = new TabPage();
			this.groupBox17 = new GroupBox();
			this.lstBowsFilter = new ListBox();
			this.optionBowsFilterList = new RadioButton();
			this.optionBowsNoFilter = new RadioButton();
			this.groupBox18 = new GroupBox();
			this.chkBowsUseHotkey = new CheckBox();
			this.txtBowsHotKey = new TextBox();
			this.chkBowsDisableWhenDone = new CheckBox();
			this.chkBowsActiveInactive = new CheckBox();
			this.txtBowsMax = new TextBox();
			this.label54 = new Label();
			this.txtBowsQuantity = new TextBox();
			this.label56 = new Label();
			this.txtBowsTimer = new TextBox();
			this.label60 = new Label();
			this.txtBowsFixed = new TextBox();
			this.optionBowsTimer = new RadioButton();
			this.optionBowsFixed = new RadioButton();
			this.tabPage15 = new TabPage();
			this.groupBox20 = new GroupBox();
			this.lstShieldsFilter = new ListBox();
			this.optionShieldsFilterList = new RadioButton();
			this.optionShieldsNoFilter = new RadioButton();
			this.groupBox21 = new GroupBox();
			this.chkShieldsUseHotkey = new CheckBox();
			this.txtShieldsHotKey = new TextBox();
			this.chkShieldsDisableWhenDone = new CheckBox();
			this.chkShieldsActiveInactive = new CheckBox();
			this.txtShieldsMax = new TextBox();
			this.label61 = new Label();
			this.txtShieldsQuantity = new TextBox();
			this.label62 = new Label();
			this.txtShieldsTimer = new TextBox();
			this.label63 = new Label();
			this.txtShieldsFixed = new TextBox();
			this.optionShieldsTimer = new RadioButton();
			this.optionShieldsFixed = new RadioButton();
			this.tabPage16 = new TabPage();
			this.groupBox22 = new GroupBox();
			this.lstArrowsFilter = new ListBox();
			this.optionArrowsFilterList = new RadioButton();
			this.optionArrowsNoFilter = new RadioButton();
			this.groupBox23 = new GroupBox();
			this.chkArrowsUseHotkey = new CheckBox();
			this.txtArrowsHotKey = new TextBox();
			this.chkArrowsDisableWhenDone = new CheckBox();
			this.chkArrowsActiveInactive = new CheckBox();
			this.txtArrowsMax = new TextBox();
			this.label64 = new Label();
			this.txtArrowsQuantity = new TextBox();
			this.label65 = new Label();
			this.txtArrowsTimer = new TextBox();
			this.label66 = new Label();
			this.txtArrowsFixed = new TextBox();
			this.optionArrowsTimer = new RadioButton();
			this.optionArrowsFixed = new RadioButton();
			this.tabPage17 = new TabPage();
			this.groupBox16 = new GroupBox();
			this.lblLockStaminaInfo = new Label();
			this.chkLockStaminaSet = new CheckBox();
			this.txtLockStaminaHotKey = new TextBox();
			this.chkLockStaminaUseHotkey = new CheckBox();
			this.lblLockHealthInfo = new Label();
			this.chkLockHealthSet = new CheckBox();
			this.txtLockHealthHotKey = new TextBox();
			this.chkLockHealthUseHotkey = new CheckBox();
			this.groupBox14 = new GroupBox();
			this.groupBox3 = new GroupBox();
			this.lstUnbreakableFilter = new ListBox();
			this.optionUnbreakableFilterList = new RadioButton();
			this.optionUnbreakableNoFilter = new RadioButton();
			this.lblUnbreakableShieldsInfo = new Label();
			this.chkUnbreakableShieldsSet = new CheckBox();
			this.txtUnbreakableShieldsHotKey = new TextBox();
			this.chkUnbreakableShieldsUseHotkey = new CheckBox();
			this.lblUnbreakableBowsInfo = new Label();
			this.chkUnbreakableBowsSet = new CheckBox();
			this.txtUnbreakableBowsHotKey = new TextBox();
			this.chkUnbreakableBowsUseHotkey = new CheckBox();
			this.lblUnbreakableWeaponsInfo = new Label();
			this.chkUnbreakableWeaponsSet = new CheckBox();
			this.txtUnbreakableWeaponsHotKey = new TextBox();
			this.chkUnbreakableWeaponsUseHotkey = new CheckBox();
			this.tabPage21 = new TabPage();
			this.groupBox6 = new GroupBox();
			this.btnCapturedPositionTP = new Button();
			this.label70 = new Label();
			this.txtCapturedPositionName = new TextBox();
			this.label57 = new Label();
			this.txtCapturedPositionZ = new TextBox();
			this.label58 = new Label();
			this.txtCapturedPositionY = new TextBox();
			this.label69 = new Label();
			this.txtCapturedPositionX = new TextBox();
			this.btnCapturedPositionRemove = new Button();
			this.btnCapturedPositionSave = new Button();
			this.btnCapturedPositionNew = new Button();
			this.lstCapturedPositions = new ListBox();
			this.groupBox7 = new GroupBox();
			this.btnPositionEdit = new Button();
			this.btnPositionRestore = new Button();
			this.txtPositionRestoreHotKey = new TextBox();
			this.chkPositionRestoreUseHotkey = new CheckBox();
			this.btnPositionSave = new Button();
			this.txtPositionSaveHotKey = new TextBox();
			this.chkPositionSaveUseHotkey = new CheckBox();
			this.btnPositionJump = new Button();
			this.txtPositionJumpHeight = new TextBox();
			this.txtPositionJumpHotKey = new TextBox();
			this.chkPositionJumpUseHotkey = new CheckBox();
			this.chkPositionLockHeightSet = new CheckBox();
			this.txtPositionLockHeightHotKey = new TextBox();
			this.chkPositionLockHeightUseHotkey = new CheckBox();
			this.label68 = new Label();
			this.txtPositionZ = new TextBox();
			this.label67 = new Label();
			this.txtPositionY = new TextBox();
			this.label59 = new Label();
			this.txtPositionX = new TextBox();
			this.tabPage18 = new TabPage();
			this.groupBox19 = new GroupBox();
			this.lblPowersDarukInfo = new Label();
			this.chkPowersDarukSet = new CheckBox();
			this.txtPowersDarukHotKey = new TextBox();
			this.chkPowersDarukUseHotkey = new CheckBox();
			this.lblPowersUrbosaInfo = new Label();
			this.chkPowersUrbosaSet = new CheckBox();
			this.txtPowersUrbosaHotKey = new TextBox();
			this.chkPowersUrbosaUseHotkey = new CheckBox();
			this.lblPowersRevaliInfo = new Label();
			this.chkPowersRevaliSet = new CheckBox();
			this.txtPowersRevaliHotKey = new TextBox();
			this.chkPowersRevaliUseHotkey = new CheckBox();
			this.lblPowersMiphaInfo = new Label();
			this.chkPowersMiphaSet = new CheckBox();
			this.txtPowersMiphaHotKey = new TextBox();
			this.chkPowersMiphaUseHotkey = new CheckBox();
			this.tabPage19 = new TabPage();
			this.groupBox4 = new GroupBox();
			this.btnRunSpeedDefault = new Button();
			this.txtRunSpeedDefaultHotKey = new TextBox();
			this.chkRunSpeedDefaultUseHotkey = new CheckBox();
			this.btnRunSpeedDown = new Button();
			this.txtRunSpeedDownHotKey = new TextBox();
			this.chkRunSpeedDownUseHotkey = new CheckBox();
			this.btnRunSpeedUp = new Button();
			this.txtRunSpeedUpHotKey = new TextBox();
			this.chkRunSpeedUpUseHotkey = new CheckBox();
			this.btnRunSpeedUpdate = new Button();
			this.label49 = new Label();
			this.txtRunSpeed = new TextBox();
			this.groupBox15 = new GroupBox();
			this.lblUnlimitAmiiboInfo = new Label();
			this.chkUnlimitAmiiboSet = new CheckBox();
			this.txtUnlimitAmiiboHotKey = new TextBox();
			this.chkUnlimitAmiiboUseHotkey = new CheckBox();
			this.tabPage13 = new TabPage();
			this.gbActionsFilter = new GroupBox();
			this.lstActionsFilter = new ListBox();
			this.optionActionsFilterList = new RadioButton();
			this.optionActionsNoFilter = new RadioButton();
			this.gbActionsSettings = new GroupBox();
			this.chkActionsUseHotkey = new CheckBox();
			this.txtActionsHotKey = new TextBox();
			this.chkActionsDisableWhenDone = new CheckBox();
			this.cbActionsList = new ComboBox();
			this.chkActionsActiveInactive = new CheckBox();
			this.txtActionsMax = new TextBox();
			this.label41 = new Label();
			this.txtActionsQuantity = new TextBox();
			this.label42 = new Label();
			this.txtActionsTimer = new TextBox();
			this.label43 = new Label();
			this.txtActionsFixed = new TextBox();
			this.optionActionsTimer = new RadioButton();
			this.optionActionsFixed = new RadioButton();
			this.groupBox9 = new GroupBox();
			this.btnActionsRemove = new Button();
			this.lstActionsRegistered = new ListBox();
			this.btnActionsNew = new Button();
			this.tabControl2 = new TabControl();
			this.tabPage10 = new TabPage();
			this.groupBox5 = new GroupBox();
			this.label55 = new Label();
			this.label53 = new Label();
			this.numSpacingMs = new NumericUpDown();
			this.numInternalLoopMs = new NumericUpDown();
			this.groupBox2 = new GroupBox();
			this.btnGameProcessResume = new Button();
			this.btnGameProcessPause = new Button();
			this.groupBox1 = new GroupBox();
			this.btnSettingsImport = new Button();
			this.btnSettingsExport = new Button();
			this.btnSettingsClear = new Button();
			this.btnSettingsSave = new Button();
			this.groupBox12 = new GroupBox();
			this.chkUpdateList = new CheckBox();
			this.txtTimerUpdateList = new TextBox();
			this.label45 = new Label();
			this.groupBox11 = new GroupBox();
			this.lstEquippedWeapons = new ListBox();
			this.tabPage22 = new TabPage();
			this.btntxtFindMemoryRegionBySize = new Button();
			this.label73 = new Label();
			this.txtFindMemoryRegionBySize = new TextBox();
			this.btnFindMemoryRegionByAddress = new Button();
			this.label72 = new Label();
			this.txtFindMemoryRegionByAddress = new TextBox();
			this.label48 = new Label();
			this.lblVersion = new Label();
			this.button1 = new Button();
			this.button2 = new Button();
			this.button3 = new Button();
			this.btnMemoryRegions = new Button();
			this.trackTime = new TrackBar();
			this.btnCompareAddress = new Button();
			this.label74 = new Label();
			this.txtCompareAddress = new TextBox();
			this.btnNoStaminaBar = new Button();
			this.btnRestoreStaminaBar = new Button();
			this.tabMain.SuspendLayout();
			this.tabPage9.SuspendLayout();
			this.tabItems.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.gbInventoryEdit.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.gbWeaponsEdit.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.gbArcheryEdit.SuspendLayout();
			this.tabPage4.SuspendLayout();
			this.gbShieldsEdit.SuspendLayout();
			this.tabPage5.SuspendLayout();
			this.gbArmorsEdit.SuspendLayout();
			this.tabPage6.SuspendLayout();
			this.gbMaterialsEdit.SuspendLayout();
			this.tabPage7.SuspendLayout();
			this.gbFoodEdit.SuspendLayout();
			this.tabPage8.SuspendLayout();
			this.gbOtherEdit.SuspendLayout();
			this.tabPage12.SuspendLayout();
			this.gbRupees.SuspendLayout();
			this.tabPage20.SuspendLayout();
			this.gbShieldsSlots.SuspendLayout();
			this.gbBowsSlots.SuspendLayout();
			this.gbWeaponsSlots.SuspendLayout();
			this.tabActions.SuspendLayout();
			this.tabPage11.SuspendLayout();
			this.groupBox13.SuspendLayout();
			this.groupBox10.SuspendLayout();
			this.tabPage14.SuspendLayout();
			this.groupBox17.SuspendLayout();
			this.groupBox18.SuspendLayout();
			this.tabPage15.SuspendLayout();
			this.groupBox20.SuspendLayout();
			this.groupBox21.SuspendLayout();
			this.tabPage16.SuspendLayout();
			this.groupBox22.SuspendLayout();
			this.groupBox23.SuspendLayout();
			this.tabPage17.SuspendLayout();
			this.groupBox16.SuspendLayout();
			this.groupBox14.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.tabPage21.SuspendLayout();
			this.groupBox6.SuspendLayout();
			this.groupBox7.SuspendLayout();
			this.tabPage18.SuspendLayout();
			this.groupBox19.SuspendLayout();
			this.tabPage19.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox15.SuspendLayout();
			this.tabPage13.SuspendLayout();
			this.gbActionsFilter.SuspendLayout();
			this.gbActionsSettings.SuspendLayout();
			this.groupBox9.SuspendLayout();
			this.tabControl2.SuspendLayout();
			this.tabPage10.SuspendLayout();
			this.groupBox5.SuspendLayout();
			((ISupportInitialize)this.numSpacingMs).BeginInit();
			((ISupportInitialize)this.numInternalLoopMs).BeginInit();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox12.SuspendLayout();
			this.groupBox11.SuspendLayout();
			this.tabPage22.SuspendLayout();
			((ISupportInitialize)this.trackTime).BeginInit();
			base.SuspendLayout();
			this.tabMain.Controls.Add(this.tabPage9);
			this.tabMain.Location = new Point(502, 310);
			this.tabMain.Name = "tabMain";
			this.tabMain.SelectedIndex = 0;
			this.tabMain.Size = new Size(507, 173);
			this.tabMain.TabIndex = 4;
			this.tabPage9.Controls.Add(this.txtLog);
			this.tabPage9.Location = new Point(4, 22);
			this.tabPage9.Name = "tabPage9";
			this.tabPage9.Padding = new Padding(3);
			this.tabPage9.Size = new Size(499, 147);
			this.tabPage9.TabIndex = 0;
			this.tabPage9.Text = "Log";
			this.tabPage9.UseVisualStyleBackColor = true;
			this.txtLog.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.txtLog.Location = new Point(6, 7);
			this.txtLog.Multiline = true;
			this.txtLog.Name = "txtLog";
			this.txtLog.ReadOnly = true;
			this.txtLog.ScrollBars = ScrollBars.Vertical;
			this.txtLog.Size = new Size(487, 134);
			this.txtLog.TabIndex = 0;
			this.tabItems.Controls.Add(this.tabPage1);
			this.tabItems.Controls.Add(this.tabPage2);
			this.tabItems.Controls.Add(this.tabPage3);
			this.tabItems.Controls.Add(this.tabPage4);
			this.tabItems.Controls.Add(this.tabPage5);
			this.tabItems.Controls.Add(this.tabPage6);
			this.tabItems.Controls.Add(this.tabPage7);
			this.tabItems.Controls.Add(this.tabPage8);
			this.tabItems.Controls.Add(this.tabPage12);
			this.tabItems.Controls.Add(this.tabPage20);
			this.tabItems.Enabled = false;
			this.tabItems.Location = new Point(12, 41);
			this.tabItems.Multiline = true;
			this.tabItems.Name = "tabItems";
			this.tabItems.SelectedIndex = 0;
			this.tabItems.Size = new Size(484, 267);
			this.tabItems.TabIndex = 0;
			this.tabPage1.Controls.Add(this.btnInventoryItemUnlock);
			this.tabPage1.Controls.Add(this.gbInventoryEdit);
			this.tabPage1.Controls.Add(this.lstInventory);
			this.tabPage1.Location = new Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new Padding(3);
			this.tabPage1.Size = new Size(476, 241);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Inventory";
			this.tabPage1.UseVisualStyleBackColor = true;
			this.btnInventoryItemUnlock.Location = new Point(362, 200);
			this.btnInventoryItemUnlock.Name = "btnInventoryItemUnlock";
			this.btnInventoryItemUnlock.Size = new Size(75, 23);
			this.btnInventoryItemUnlock.TabIndex = 18;
			this.btnInventoryItemUnlock.Text = "Unlock";
			this.btnInventoryItemUnlock.UseVisualStyleBackColor = true;
			this.btnInventoryItemUnlock.Visible = false;
			this.gbInventoryEdit.Controls.Add(this.cbInventoryItemBonusType);
			this.gbInventoryEdit.Controls.Add(this.btnInventoryItemUpdate);
			this.gbInventoryEdit.Controls.Add(this.label4);
			this.gbInventoryEdit.Controls.Add(this.txtInventoryItemBonusValue);
			this.gbInventoryEdit.Controls.Add(this.label5);
			this.gbInventoryEdit.Controls.Add(this.txtInventoryItemBonusType);
			this.gbInventoryEdit.Controls.Add(this.label3);
			this.gbInventoryEdit.Controls.Add(this.cbInventoryItemName);
			this.gbInventoryEdit.Controls.Add(this.label2);
			this.gbInventoryEdit.Controls.Add(this.txtInventoryItemQtDur);
			this.gbInventoryEdit.Controls.Add(this.label1);
			this.gbInventoryEdit.Controls.Add(this.txtInventoryItemID);
			this.gbInventoryEdit.Location = new Point(193, 6);
			this.gbInventoryEdit.Name = "gbInventoryEdit";
			this.gbInventoryEdit.Size = new Size(244, 188);
			this.gbInventoryEdit.TabIndex = 1;
			this.gbInventoryEdit.TabStop = false;
			this.gbInventoryEdit.Text = "Edit Item";
			this.cbInventoryItemBonusType.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cbInventoryItemBonusType.FormattingEnabled = true;
			this.cbInventoryItemBonusType.Location = new Point(77, 98);
			this.cbInventoryItemBonusType.Name = "cbInventoryItemBonusType";
			this.cbInventoryItemBonusType.Size = new Size(161, 21);
			this.cbInventoryItemBonusType.TabIndex = 17;
			this.btnInventoryItemUpdate.Location = new Point(7, 150);
			this.btnInventoryItemUpdate.Name = "btnInventoryItemUpdate";
			this.btnInventoryItemUpdate.Size = new Size(75, 23);
			this.btnInventoryItemUpdate.TabIndex = 10;
			this.btnInventoryItemUpdate.Text = "Update";
			this.btnInventoryItemUpdate.UseVisualStyleBackColor = true;
			this.label4.AutoSize = true;
			this.label4.Location = new Point(4, 127);
			this.label4.Name = "label4";
			this.label4.Size = new Size(67, 13);
			this.label4.TabIndex = 9;
			this.label4.Text = "Bonus Value";
			this.txtInventoryItemBonusValue.Location = new Point(77, 124);
			this.txtInventoryItemBonusValue.Name = "txtInventoryItemBonusValue";
			this.txtInventoryItemBonusValue.Size = new Size(161, 20);
			this.txtInventoryItemBonusValue.TabIndex = 8;
			this.label5.AutoSize = true;
			this.label5.Location = new Point(4, 101);
			this.label5.Name = "label5";
			this.label5.Size = new Size(64, 13);
			this.label5.TabIndex = 7;
			this.label5.Text = "Bonus Type";
			this.txtInventoryItemBonusType.Location = new Point(77, 98);
			this.txtInventoryItemBonusType.Name = "txtInventoryItemBonusType";
			this.txtInventoryItemBonusType.Size = new Size(161, 20);
			this.txtInventoryItemBonusType.TabIndex = 6;
			this.label3.AutoSize = true;
			this.label3.Location = new Point(4, 22);
			this.label3.Name = "label3";
			this.label3.Size = new Size(35, 13);
			this.label3.TabIndex = 5;
			this.label3.Text = "Name";
			this.cbInventoryItemName.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cbInventoryItemName.FormattingEnabled = true;
			this.cbInventoryItemName.Location = new Point(77, 19);
			this.cbInventoryItemName.Name = "cbInventoryItemName";
			this.cbInventoryItemName.Size = new Size(161, 21);
			this.cbInventoryItemName.TabIndex = 4;
			this.label2.AutoSize = true;
			this.label2.Location = new Point(4, 75);
			this.label2.Name = "label2";
			this.label2.Size = new Size(46, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Qt / Dur";
			this.txtInventoryItemQtDur.Location = new Point(77, 72);
			this.txtInventoryItemQtDur.Name = "txtInventoryItemQtDur";
			this.txtInventoryItemQtDur.Size = new Size(161, 20);
			this.txtInventoryItemQtDur.TabIndex = 2;
			this.label1.AutoSize = true;
			this.label1.Location = new Point(4, 49);
			this.label1.Name = "label1";
			this.label1.Size = new Size(18, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "ID";
			this.txtInventoryItemID.Location = new Point(77, 46);
			this.txtInventoryItemID.Name = "txtInventoryItemID";
			this.txtInventoryItemID.Size = new Size(161, 20);
			this.txtInventoryItemID.TabIndex = 0;
			this.lstInventory.FormattingEnabled = true;
			this.lstInventory.Location = new Point(6, 6);
			this.lstInventory.Name = "lstInventory";
			this.lstInventory.Size = new Size(181, 225);
			this.lstInventory.TabIndex = 0;
			this.tabPage2.Controls.Add(this.btnWeaponsItemUnlock);
			this.tabPage2.Controls.Add(this.gbWeaponsEdit);
			this.tabPage2.Controls.Add(this.lstWeapons);
			this.tabPage2.Location = new Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new Padding(3);
			this.tabPage2.Size = new Size(476, 241);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Weapons";
			this.tabPage2.UseVisualStyleBackColor = true;
			this.btnWeaponsItemUnlock.Location = new Point(362, 200);
			this.btnWeaponsItemUnlock.Name = "btnWeaponsItemUnlock";
			this.btnWeaponsItemUnlock.Size = new Size(75, 23);
			this.btnWeaponsItemUnlock.TabIndex = 19;
			this.btnWeaponsItemUnlock.Text = "Unlock";
			this.btnWeaponsItemUnlock.UseVisualStyleBackColor = true;
			this.btnWeaponsItemUnlock.Visible = false;
			this.gbWeaponsEdit.Controls.Add(this.cbWeaponsItemBonusType);
			this.gbWeaponsEdit.Controls.Add(this.btnWeaponsItemUpdate);
			this.gbWeaponsEdit.Controls.Add(this.label6);
			this.gbWeaponsEdit.Controls.Add(this.txtWeaponsItemBonusValue);
			this.gbWeaponsEdit.Controls.Add(this.label7);
			this.gbWeaponsEdit.Controls.Add(this.txtWeaponsItemBonusType);
			this.gbWeaponsEdit.Controls.Add(this.label8);
			this.gbWeaponsEdit.Controls.Add(this.cbWeaponsItemName);
			this.gbWeaponsEdit.Controls.Add(this.label9);
			this.gbWeaponsEdit.Controls.Add(this.txtWeaponsItemQtDur);
			this.gbWeaponsEdit.Controls.Add(this.label10);
			this.gbWeaponsEdit.Controls.Add(this.txtWeaponsItemID);
			this.gbWeaponsEdit.Location = new Point(193, 6);
			this.gbWeaponsEdit.Name = "gbWeaponsEdit";
			this.gbWeaponsEdit.Size = new Size(244, 188);
			this.gbWeaponsEdit.TabIndex = 3;
			this.gbWeaponsEdit.TabStop = false;
			this.gbWeaponsEdit.Text = "Edit Item";
			this.cbWeaponsItemBonusType.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cbWeaponsItemBonusType.FormattingEnabled = true;
			this.cbWeaponsItemBonusType.Location = new Point(77, 98);
			this.cbWeaponsItemBonusType.Name = "cbWeaponsItemBonusType";
			this.cbWeaponsItemBonusType.Size = new Size(161, 21);
			this.cbWeaponsItemBonusType.TabIndex = 18;
			this.btnWeaponsItemUpdate.Location = new Point(7, 150);
			this.btnWeaponsItemUpdate.Name = "btnWeaponsItemUpdate";
			this.btnWeaponsItemUpdate.Size = new Size(75, 23);
			this.btnWeaponsItemUpdate.TabIndex = 10;
			this.btnWeaponsItemUpdate.Text = "Update";
			this.btnWeaponsItemUpdate.UseVisualStyleBackColor = true;
			this.label6.AutoSize = true;
			this.label6.Location = new Point(4, 127);
			this.label6.Name = "label6";
			this.label6.Size = new Size(67, 13);
			this.label6.TabIndex = 9;
			this.label6.Text = "Bonus Value";
			this.txtWeaponsItemBonusValue.Location = new Point(77, 124);
			this.txtWeaponsItemBonusValue.Name = "txtWeaponsItemBonusValue";
			this.txtWeaponsItemBonusValue.Size = new Size(161, 20);
			this.txtWeaponsItemBonusValue.TabIndex = 8;
			this.label7.AutoSize = true;
			this.label7.Location = new Point(4, 101);
			this.label7.Name = "label7";
			this.label7.Size = new Size(64, 13);
			this.label7.TabIndex = 7;
			this.label7.Text = "Bonus Type";
			this.txtWeaponsItemBonusType.Location = new Point(77, 98);
			this.txtWeaponsItemBonusType.Name = "txtWeaponsItemBonusType";
			this.txtWeaponsItemBonusType.Size = new Size(161, 20);
			this.txtWeaponsItemBonusType.TabIndex = 6;
			this.label8.AutoSize = true;
			this.label8.Location = new Point(4, 22);
			this.label8.Name = "label8";
			this.label8.Size = new Size(35, 13);
			this.label8.TabIndex = 5;
			this.label8.Text = "Name";
			this.cbWeaponsItemName.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cbWeaponsItemName.FormattingEnabled = true;
			this.cbWeaponsItemName.Location = new Point(77, 19);
			this.cbWeaponsItemName.Name = "cbWeaponsItemName";
			this.cbWeaponsItemName.Size = new Size(161, 21);
			this.cbWeaponsItemName.TabIndex = 4;
			this.label9.AutoSize = true;
			this.label9.Location = new Point(4, 75);
			this.label9.Name = "label9";
			this.label9.Size = new Size(46, 13);
			this.label9.TabIndex = 3;
			this.label9.Text = "Qt / Dur";
			this.txtWeaponsItemQtDur.Location = new Point(77, 72);
			this.txtWeaponsItemQtDur.Name = "txtWeaponsItemQtDur";
			this.txtWeaponsItemQtDur.Size = new Size(161, 20);
			this.txtWeaponsItemQtDur.TabIndex = 2;
			this.label10.AutoSize = true;
			this.label10.Location = new Point(4, 49);
			this.label10.Name = "label10";
			this.label10.Size = new Size(18, 13);
			this.label10.TabIndex = 1;
			this.label10.Text = "ID";
			this.txtWeaponsItemID.Location = new Point(77, 46);
			this.txtWeaponsItemID.Name = "txtWeaponsItemID";
			this.txtWeaponsItemID.Size = new Size(161, 20);
			this.txtWeaponsItemID.TabIndex = 0;
			this.lstWeapons.FormattingEnabled = true;
			this.lstWeapons.Location = new Point(6, 6);
			this.lstWeapons.Name = "lstWeapons";
			this.lstWeapons.Size = new Size(181, 225);
			this.lstWeapons.TabIndex = 2;
			this.tabPage3.Controls.Add(this.btnArcheryItemUnlock);
			this.tabPage3.Controls.Add(this.gbArcheryEdit);
			this.tabPage3.Controls.Add(this.lstArchery);
			this.tabPage3.Location = new Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new Padding(3);
			this.tabPage3.Size = new Size(476, 241);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Archery";
			this.tabPage3.UseVisualStyleBackColor = true;
			this.btnArcheryItemUnlock.Location = new Point(362, 200);
			this.btnArcheryItemUnlock.Name = "btnArcheryItemUnlock";
			this.btnArcheryItemUnlock.Size = new Size(75, 23);
			this.btnArcheryItemUnlock.TabIndex = 20;
			this.btnArcheryItemUnlock.Text = "Unlock";
			this.btnArcheryItemUnlock.UseVisualStyleBackColor = true;
			this.btnArcheryItemUnlock.Visible = false;
			this.gbArcheryEdit.Controls.Add(this.cbArcheryItemBonusType);
			this.gbArcheryEdit.Controls.Add(this.btnArcheryItemUpdate);
			this.gbArcheryEdit.Controls.Add(this.label11);
			this.gbArcheryEdit.Controls.Add(this.txtArcheryItemBonusValue);
			this.gbArcheryEdit.Controls.Add(this.label12);
			this.gbArcheryEdit.Controls.Add(this.txtArcheryItemBonusType);
			this.gbArcheryEdit.Controls.Add(this.label13);
			this.gbArcheryEdit.Controls.Add(this.cbArcheryItemName);
			this.gbArcheryEdit.Controls.Add(this.label14);
			this.gbArcheryEdit.Controls.Add(this.txtArcheryItemQtDur);
			this.gbArcheryEdit.Controls.Add(this.label15);
			this.gbArcheryEdit.Controls.Add(this.txtArcheryItemID);
			this.gbArcheryEdit.Location = new Point(193, 6);
			this.gbArcheryEdit.Name = "gbArcheryEdit";
			this.gbArcheryEdit.Size = new Size(244, 188);
			this.gbArcheryEdit.TabIndex = 3;
			this.gbArcheryEdit.TabStop = false;
			this.gbArcheryEdit.Text = "Edit Item";
			this.cbArcheryItemBonusType.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cbArcheryItemBonusType.FormattingEnabled = true;
			this.cbArcheryItemBonusType.Location = new Point(77, 98);
			this.cbArcheryItemBonusType.Name = "cbArcheryItemBonusType";
			this.cbArcheryItemBonusType.Size = new Size(161, 21);
			this.cbArcheryItemBonusType.TabIndex = 18;
			this.btnArcheryItemUpdate.Location = new Point(7, 150);
			this.btnArcheryItemUpdate.Name = "btnArcheryItemUpdate";
			this.btnArcheryItemUpdate.Size = new Size(75, 23);
			this.btnArcheryItemUpdate.TabIndex = 10;
			this.btnArcheryItemUpdate.Text = "Update";
			this.btnArcheryItemUpdate.UseVisualStyleBackColor = true;
			this.label11.AutoSize = true;
			this.label11.Location = new Point(4, 127);
			this.label11.Name = "label11";
			this.label11.Size = new Size(67, 13);
			this.label11.TabIndex = 9;
			this.label11.Text = "Bonus Value";
			this.txtArcheryItemBonusValue.Location = new Point(77, 124);
			this.txtArcheryItemBonusValue.Name = "txtArcheryItemBonusValue";
			this.txtArcheryItemBonusValue.Size = new Size(161, 20);
			this.txtArcheryItemBonusValue.TabIndex = 8;
			this.label12.AutoSize = true;
			this.label12.Location = new Point(4, 101);
			this.label12.Name = "label12";
			this.label12.Size = new Size(64, 13);
			this.label12.TabIndex = 7;
			this.label12.Text = "Bonus Type";
			this.txtArcheryItemBonusType.Location = new Point(77, 98);
			this.txtArcheryItemBonusType.Name = "txtArcheryItemBonusType";
			this.txtArcheryItemBonusType.Size = new Size(161, 20);
			this.txtArcheryItemBonusType.TabIndex = 6;
			this.label13.AutoSize = true;
			this.label13.Location = new Point(4, 22);
			this.label13.Name = "label13";
			this.label13.Size = new Size(35, 13);
			this.label13.TabIndex = 5;
			this.label13.Text = "Name";
			this.cbArcheryItemName.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cbArcheryItemName.FormattingEnabled = true;
			this.cbArcheryItemName.Location = new Point(77, 19);
			this.cbArcheryItemName.Name = "cbArcheryItemName";
			this.cbArcheryItemName.Size = new Size(161, 21);
			this.cbArcheryItemName.TabIndex = 4;
			this.label14.AutoSize = true;
			this.label14.Location = new Point(4, 75);
			this.label14.Name = "label14";
			this.label14.Size = new Size(46, 13);
			this.label14.TabIndex = 3;
			this.label14.Text = "Qt / Dur";
			this.txtArcheryItemQtDur.Location = new Point(77, 72);
			this.txtArcheryItemQtDur.Name = "txtArcheryItemQtDur";
			this.txtArcheryItemQtDur.Size = new Size(161, 20);
			this.txtArcheryItemQtDur.TabIndex = 2;
			this.label15.AutoSize = true;
			this.label15.Location = new Point(4, 49);
			this.label15.Name = "label15";
			this.label15.Size = new Size(18, 13);
			this.label15.TabIndex = 1;
			this.label15.Text = "ID";
			this.txtArcheryItemID.Location = new Point(77, 46);
			this.txtArcheryItemID.Name = "txtArcheryItemID";
			this.txtArcheryItemID.Size = new Size(161, 20);
			this.txtArcheryItemID.TabIndex = 0;
			this.lstArchery.FormattingEnabled = true;
			this.lstArchery.Location = new Point(6, 6);
			this.lstArchery.Name = "lstArchery";
			this.lstArchery.Size = new Size(181, 225);
			this.lstArchery.TabIndex = 2;
			this.tabPage4.Controls.Add(this.btnShieldsItemUnlock);
			this.tabPage4.Controls.Add(this.gbShieldsEdit);
			this.tabPage4.Controls.Add(this.lstShields);
			this.tabPage4.Location = new Point(4, 22);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Padding = new Padding(3);
			this.tabPage4.Size = new Size(476, 241);
			this.tabPage4.TabIndex = 3;
			this.tabPage4.Text = "Shields";
			this.tabPage4.UseVisualStyleBackColor = true;
			this.btnShieldsItemUnlock.Location = new Point(362, 200);
			this.btnShieldsItemUnlock.Name = "btnShieldsItemUnlock";
			this.btnShieldsItemUnlock.Size = new Size(75, 23);
			this.btnShieldsItemUnlock.TabIndex = 21;
			this.btnShieldsItemUnlock.Text = "Unlock";
			this.btnShieldsItemUnlock.UseVisualStyleBackColor = true;
			this.btnShieldsItemUnlock.Visible = false;
			this.gbShieldsEdit.Controls.Add(this.cbShieldsItemBonusType);
			this.gbShieldsEdit.Controls.Add(this.btnShieldsItemUpdate);
			this.gbShieldsEdit.Controls.Add(this.label16);
			this.gbShieldsEdit.Controls.Add(this.txtShieldsItemBonusValue);
			this.gbShieldsEdit.Controls.Add(this.label17);
			this.gbShieldsEdit.Controls.Add(this.txtShieldsItemBonusType);
			this.gbShieldsEdit.Controls.Add(this.label18);
			this.gbShieldsEdit.Controls.Add(this.cbShieldsItemName);
			this.gbShieldsEdit.Controls.Add(this.label19);
			this.gbShieldsEdit.Controls.Add(this.txtShieldsItemQtDur);
			this.gbShieldsEdit.Controls.Add(this.label20);
			this.gbShieldsEdit.Controls.Add(this.txtShieldsItemID);
			this.gbShieldsEdit.Location = new Point(193, 6);
			this.gbShieldsEdit.Name = "gbShieldsEdit";
			this.gbShieldsEdit.Size = new Size(244, 188);
			this.gbShieldsEdit.TabIndex = 5;
			this.gbShieldsEdit.TabStop = false;
			this.gbShieldsEdit.Text = "Edit Item";
			this.cbShieldsItemBonusType.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cbShieldsItemBonusType.FormattingEnabled = true;
			this.cbShieldsItemBonusType.Location = new Point(77, 98);
			this.cbShieldsItemBonusType.Name = "cbShieldsItemBonusType";
			this.cbShieldsItemBonusType.Size = new Size(161, 21);
			this.cbShieldsItemBonusType.TabIndex = 18;
			this.btnShieldsItemUpdate.Location = new Point(7, 150);
			this.btnShieldsItemUpdate.Name = "btnShieldsItemUpdate";
			this.btnShieldsItemUpdate.Size = new Size(75, 23);
			this.btnShieldsItemUpdate.TabIndex = 10;
			this.btnShieldsItemUpdate.Text = "Update";
			this.btnShieldsItemUpdate.UseVisualStyleBackColor = true;
			this.label16.AutoSize = true;
			this.label16.Location = new Point(4, 127);
			this.label16.Name = "label16";
			this.label16.Size = new Size(67, 13);
			this.label16.TabIndex = 9;
			this.label16.Text = "Bonus Value";
			this.txtShieldsItemBonusValue.Location = new Point(77, 124);
			this.txtShieldsItemBonusValue.Name = "txtShieldsItemBonusValue";
			this.txtShieldsItemBonusValue.Size = new Size(161, 20);
			this.txtShieldsItemBonusValue.TabIndex = 8;
			this.label17.AutoSize = true;
			this.label17.Location = new Point(4, 101);
			this.label17.Name = "label17";
			this.label17.Size = new Size(64, 13);
			this.label17.TabIndex = 7;
			this.label17.Text = "Bonus Type";
			this.txtShieldsItemBonusType.Location = new Point(77, 98);
			this.txtShieldsItemBonusType.Name = "txtShieldsItemBonusType";
			this.txtShieldsItemBonusType.Size = new Size(161, 20);
			this.txtShieldsItemBonusType.TabIndex = 6;
			this.label18.AutoSize = true;
			this.label18.Location = new Point(4, 22);
			this.label18.Name = "label18";
			this.label18.Size = new Size(35, 13);
			this.label18.TabIndex = 5;
			this.label18.Text = "Name";
			this.cbShieldsItemName.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cbShieldsItemName.FormattingEnabled = true;
			this.cbShieldsItemName.Location = new Point(77, 19);
			this.cbShieldsItemName.Name = "cbShieldsItemName";
			this.cbShieldsItemName.Size = new Size(161, 21);
			this.cbShieldsItemName.TabIndex = 4;
			this.label19.AutoSize = true;
			this.label19.Location = new Point(4, 75);
			this.label19.Name = "label19";
			this.label19.Size = new Size(46, 13);
			this.label19.TabIndex = 3;
			this.label19.Text = "Qt / Dur";
			this.txtShieldsItemQtDur.Location = new Point(77, 72);
			this.txtShieldsItemQtDur.Name = "txtShieldsItemQtDur";
			this.txtShieldsItemQtDur.Size = new Size(161, 20);
			this.txtShieldsItemQtDur.TabIndex = 2;
			this.label20.AutoSize = true;
			this.label20.Location = new Point(4, 49);
			this.label20.Name = "label20";
			this.label20.Size = new Size(18, 13);
			this.label20.TabIndex = 1;
			this.label20.Text = "ID";
			this.txtShieldsItemID.Location = new Point(77, 46);
			this.txtShieldsItemID.Name = "txtShieldsItemID";
			this.txtShieldsItemID.Size = new Size(161, 20);
			this.txtShieldsItemID.TabIndex = 0;
			this.lstShields.FormattingEnabled = true;
			this.lstShields.Location = new Point(6, 6);
			this.lstShields.Name = "lstShields";
			this.lstShields.Size = new Size(181, 225);
			this.lstShields.TabIndex = 4;
			this.tabPage5.Controls.Add(this.btnArmorsItemUnlock);
			this.tabPage5.Controls.Add(this.gbArmorsEdit);
			this.tabPage5.Controls.Add(this.lstArmors);
			this.tabPage5.Location = new Point(4, 22);
			this.tabPage5.Name = "tabPage5";
			this.tabPage5.Padding = new Padding(3);
			this.tabPage5.Size = new Size(476, 241);
			this.tabPage5.TabIndex = 4;
			this.tabPage5.Text = "Armors";
			this.tabPage5.UseVisualStyleBackColor = true;
			this.btnArmorsItemUnlock.Location = new Point(362, 200);
			this.btnArmorsItemUnlock.Name = "btnArmorsItemUnlock";
			this.btnArmorsItemUnlock.Size = new Size(75, 23);
			this.btnArmorsItemUnlock.TabIndex = 22;
			this.btnArmorsItemUnlock.Text = "Unlock";
			this.btnArmorsItemUnlock.UseVisualStyleBackColor = true;
			this.btnArmorsItemUnlock.Visible = false;
			this.gbArmorsEdit.Controls.Add(this.cbArmorsItemBonusType);
			this.gbArmorsEdit.Controls.Add(this.btnArmorsItemUpdate);
			this.gbArmorsEdit.Controls.Add(this.label21);
			this.gbArmorsEdit.Controls.Add(this.txtArmorsItemBonusValue);
			this.gbArmorsEdit.Controls.Add(this.label22);
			this.gbArmorsEdit.Controls.Add(this.txtArmorsItemBonusType);
			this.gbArmorsEdit.Controls.Add(this.label23);
			this.gbArmorsEdit.Controls.Add(this.cbArmorsItemName);
			this.gbArmorsEdit.Controls.Add(this.label24);
			this.gbArmorsEdit.Controls.Add(this.txtArmorsItemQtDur);
			this.gbArmorsEdit.Controls.Add(this.label25);
			this.gbArmorsEdit.Controls.Add(this.txtArmorsItemID);
			this.gbArmorsEdit.Location = new Point(193, 6);
			this.gbArmorsEdit.Name = "gbArmorsEdit";
			this.gbArmorsEdit.Size = new Size(244, 188);
			this.gbArmorsEdit.TabIndex = 7;
			this.gbArmorsEdit.TabStop = false;
			this.gbArmorsEdit.Text = "Edit Item";
			this.cbArmorsItemBonusType.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cbArmorsItemBonusType.FormattingEnabled = true;
			this.cbArmorsItemBonusType.Location = new Point(77, 98);
			this.cbArmorsItemBonusType.Name = "cbArmorsItemBonusType";
			this.cbArmorsItemBonusType.Size = new Size(161, 21);
			this.cbArmorsItemBonusType.TabIndex = 18;
			this.btnArmorsItemUpdate.Location = new Point(7, 150);
			this.btnArmorsItemUpdate.Name = "btnArmorsItemUpdate";
			this.btnArmorsItemUpdate.Size = new Size(75, 23);
			this.btnArmorsItemUpdate.TabIndex = 10;
			this.btnArmorsItemUpdate.Text = "Update";
			this.btnArmorsItemUpdate.UseVisualStyleBackColor = true;
			this.label21.AutoSize = true;
			this.label21.Location = new Point(4, 127);
			this.label21.Name = "label21";
			this.label21.Size = new Size(67, 13);
			this.label21.TabIndex = 9;
			this.label21.Text = "Bonus Value";
			this.txtArmorsItemBonusValue.Location = new Point(77, 124);
			this.txtArmorsItemBonusValue.Name = "txtArmorsItemBonusValue";
			this.txtArmorsItemBonusValue.Size = new Size(161, 20);
			this.txtArmorsItemBonusValue.TabIndex = 8;
			this.label22.AutoSize = true;
			this.label22.Location = new Point(4, 101);
			this.label22.Name = "label22";
			this.label22.Size = new Size(64, 13);
			this.label22.TabIndex = 7;
			this.label22.Text = "Bonus Type";
			this.txtArmorsItemBonusType.Location = new Point(77, 98);
			this.txtArmorsItemBonusType.Name = "txtArmorsItemBonusType";
			this.txtArmorsItemBonusType.Size = new Size(161, 20);
			this.txtArmorsItemBonusType.TabIndex = 6;
			this.label23.AutoSize = true;
			this.label23.Location = new Point(4, 22);
			this.label23.Name = "label23";
			this.label23.Size = new Size(35, 13);
			this.label23.TabIndex = 5;
			this.label23.Text = "Name";
			this.cbArmorsItemName.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cbArmorsItemName.FormattingEnabled = true;
			this.cbArmorsItemName.Location = new Point(77, 19);
			this.cbArmorsItemName.Name = "cbArmorsItemName";
			this.cbArmorsItemName.Size = new Size(161, 21);
			this.cbArmorsItemName.TabIndex = 4;
			this.label24.AutoSize = true;
			this.label24.Location = new Point(4, 75);
			this.label24.Name = "label24";
			this.label24.Size = new Size(46, 13);
			this.label24.TabIndex = 3;
			this.label24.Text = "Qt / Dur";
			this.txtArmorsItemQtDur.Location = new Point(77, 72);
			this.txtArmorsItemQtDur.Name = "txtArmorsItemQtDur";
			this.txtArmorsItemQtDur.Size = new Size(161, 20);
			this.txtArmorsItemQtDur.TabIndex = 2;
			this.label25.AutoSize = true;
			this.label25.Location = new Point(4, 49);
			this.label25.Name = "label25";
			this.label25.Size = new Size(18, 13);
			this.label25.TabIndex = 1;
			this.label25.Text = "ID";
			this.txtArmorsItemID.Location = new Point(77, 46);
			this.txtArmorsItemID.Name = "txtArmorsItemID";
			this.txtArmorsItemID.Size = new Size(161, 20);
			this.txtArmorsItemID.TabIndex = 0;
			this.lstArmors.FormattingEnabled = true;
			this.lstArmors.Location = new Point(6, 6);
			this.lstArmors.Name = "lstArmors";
			this.lstArmors.Size = new Size(181, 225);
			this.lstArmors.TabIndex = 6;
			this.tabPage6.Controls.Add(this.btnMaterialsItemUnlock);
			this.tabPage6.Controls.Add(this.gbMaterialsEdit);
			this.tabPage6.Controls.Add(this.lstMaterials);
			this.tabPage6.Location = new Point(4, 22);
			this.tabPage6.Name = "tabPage6";
			this.tabPage6.Padding = new Padding(3);
			this.tabPage6.Size = new Size(476, 241);
			this.tabPage6.TabIndex = 5;
			this.tabPage6.Text = "Materials";
			this.tabPage6.UseVisualStyleBackColor = true;
			this.btnMaterialsItemUnlock.Location = new Point(362, 200);
			this.btnMaterialsItemUnlock.Name = "btnMaterialsItemUnlock";
			this.btnMaterialsItemUnlock.Size = new Size(75, 23);
			this.btnMaterialsItemUnlock.TabIndex = 23;
			this.btnMaterialsItemUnlock.Text = "Unlock";
			this.btnMaterialsItemUnlock.UseVisualStyleBackColor = true;
			this.btnMaterialsItemUnlock.Visible = false;
			this.gbMaterialsEdit.Controls.Add(this.cbMaterialsItemBonusType);
			this.gbMaterialsEdit.Controls.Add(this.btnMaterialsItemUpdate);
			this.gbMaterialsEdit.Controls.Add(this.label26);
			this.gbMaterialsEdit.Controls.Add(this.txtMaterialsItemBonusValue);
			this.gbMaterialsEdit.Controls.Add(this.label27);
			this.gbMaterialsEdit.Controls.Add(this.txtMaterialsItemBonusType);
			this.gbMaterialsEdit.Controls.Add(this.label28);
			this.gbMaterialsEdit.Controls.Add(this.cbMaterialsItemName);
			this.gbMaterialsEdit.Controls.Add(this.label29);
			this.gbMaterialsEdit.Controls.Add(this.txtMaterialsItemQtDur);
			this.gbMaterialsEdit.Controls.Add(this.label30);
			this.gbMaterialsEdit.Controls.Add(this.txtMaterialsItemID);
			this.gbMaterialsEdit.Location = new Point(193, 6);
			this.gbMaterialsEdit.Name = "gbMaterialsEdit";
			this.gbMaterialsEdit.Size = new Size(244, 188);
			this.gbMaterialsEdit.TabIndex = 9;
			this.gbMaterialsEdit.TabStop = false;
			this.gbMaterialsEdit.Text = "Edit Item";
			this.cbMaterialsItemBonusType.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cbMaterialsItemBonusType.FormattingEnabled = true;
			this.cbMaterialsItemBonusType.Location = new Point(77, 98);
			this.cbMaterialsItemBonusType.Name = "cbMaterialsItemBonusType";
			this.cbMaterialsItemBonusType.Size = new Size(161, 21);
			this.cbMaterialsItemBonusType.TabIndex = 18;
			this.btnMaterialsItemUpdate.Location = new Point(7, 150);
			this.btnMaterialsItemUpdate.Name = "btnMaterialsItemUpdate";
			this.btnMaterialsItemUpdate.Size = new Size(75, 23);
			this.btnMaterialsItemUpdate.TabIndex = 10;
			this.btnMaterialsItemUpdate.Text = "Update";
			this.btnMaterialsItemUpdate.UseVisualStyleBackColor = true;
			this.label26.AutoSize = true;
			this.label26.Location = new Point(4, 127);
			this.label26.Name = "label26";
			this.label26.Size = new Size(67, 13);
			this.label26.TabIndex = 9;
			this.label26.Text = "Bonus Value";
			this.txtMaterialsItemBonusValue.Location = new Point(77, 124);
			this.txtMaterialsItemBonusValue.Name = "txtMaterialsItemBonusValue";
			this.txtMaterialsItemBonusValue.Size = new Size(161, 20);
			this.txtMaterialsItemBonusValue.TabIndex = 8;
			this.label27.AutoSize = true;
			this.label27.Location = new Point(4, 101);
			this.label27.Name = "label27";
			this.label27.Size = new Size(64, 13);
			this.label27.TabIndex = 7;
			this.label27.Text = "Bonus Type";
			this.txtMaterialsItemBonusType.Location = new Point(77, 98);
			this.txtMaterialsItemBonusType.Name = "txtMaterialsItemBonusType";
			this.txtMaterialsItemBonusType.Size = new Size(161, 20);
			this.txtMaterialsItemBonusType.TabIndex = 6;
			this.label28.AutoSize = true;
			this.label28.Location = new Point(4, 22);
			this.label28.Name = "label28";
			this.label28.Size = new Size(35, 13);
			this.label28.TabIndex = 5;
			this.label28.Text = "Name";
			this.cbMaterialsItemName.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cbMaterialsItemName.FormattingEnabled = true;
			this.cbMaterialsItemName.Location = new Point(77, 19);
			this.cbMaterialsItemName.Name = "cbMaterialsItemName";
			this.cbMaterialsItemName.Size = new Size(161, 21);
			this.cbMaterialsItemName.TabIndex = 4;
			this.label29.AutoSize = true;
			this.label29.Location = new Point(4, 75);
			this.label29.Name = "label29";
			this.label29.Size = new Size(46, 13);
			this.label29.TabIndex = 3;
			this.label29.Text = "Qt / Dur";
			this.txtMaterialsItemQtDur.Location = new Point(77, 72);
			this.txtMaterialsItemQtDur.Name = "txtMaterialsItemQtDur";
			this.txtMaterialsItemQtDur.Size = new Size(161, 20);
			this.txtMaterialsItemQtDur.TabIndex = 2;
			this.label30.AutoSize = true;
			this.label30.Location = new Point(4, 49);
			this.label30.Name = "label30";
			this.label30.Size = new Size(18, 13);
			this.label30.TabIndex = 1;
			this.label30.Text = "ID";
			this.txtMaterialsItemID.Location = new Point(77, 46);
			this.txtMaterialsItemID.Name = "txtMaterialsItemID";
			this.txtMaterialsItemID.Size = new Size(161, 20);
			this.txtMaterialsItemID.TabIndex = 0;
			this.lstMaterials.FormattingEnabled = true;
			this.lstMaterials.Location = new Point(6, 6);
			this.lstMaterials.Name = "lstMaterials";
			this.lstMaterials.Size = new Size(181, 225);
			this.lstMaterials.TabIndex = 8;
			this.tabPage7.Controls.Add(this.btnFoodItemUnlock);
			this.tabPage7.Controls.Add(this.gbFoodEdit);
			this.tabPage7.Controls.Add(this.lstFood);
			this.tabPage7.Location = new Point(4, 22);
			this.tabPage7.Name = "tabPage7";
			this.tabPage7.Padding = new Padding(3);
			this.tabPage7.Size = new Size(476, 241);
			this.tabPage7.TabIndex = 6;
			this.tabPage7.Text = "Food";
			this.tabPage7.UseVisualStyleBackColor = true;
			this.btnFoodItemUnlock.Location = new Point(362, 200);
			this.btnFoodItemUnlock.Name = "btnFoodItemUnlock";
			this.btnFoodItemUnlock.Size = new Size(75, 23);
			this.btnFoodItemUnlock.TabIndex = 24;
			this.btnFoodItemUnlock.Text = "Unlock";
			this.btnFoodItemUnlock.UseVisualStyleBackColor = true;
			this.btnFoodItemUnlock.Visible = false;
			this.gbFoodEdit.Controls.Add(this.cbFoodItemBonusType);
			this.gbFoodEdit.Controls.Add(this.btnFoodItemUpdate);
			this.gbFoodEdit.Controls.Add(this.label31);
			this.gbFoodEdit.Controls.Add(this.txtFoodItemBonusValue);
			this.gbFoodEdit.Controls.Add(this.label32);
			this.gbFoodEdit.Controls.Add(this.txtFoodItemBonusType);
			this.gbFoodEdit.Controls.Add(this.label33);
			this.gbFoodEdit.Controls.Add(this.cbFoodItemName);
			this.gbFoodEdit.Controls.Add(this.label34);
			this.gbFoodEdit.Controls.Add(this.txtFoodItemQtDur);
			this.gbFoodEdit.Controls.Add(this.label35);
			this.gbFoodEdit.Controls.Add(this.txtFoodItemID);
			this.gbFoodEdit.Location = new Point(193, 6);
			this.gbFoodEdit.Name = "gbFoodEdit";
			this.gbFoodEdit.Size = new Size(244, 188);
			this.gbFoodEdit.TabIndex = 11;
			this.gbFoodEdit.TabStop = false;
			this.gbFoodEdit.Text = "Edit Item";
			this.cbFoodItemBonusType.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cbFoodItemBonusType.FormattingEnabled = true;
			this.cbFoodItemBonusType.Location = new Point(77, 98);
			this.cbFoodItemBonusType.Name = "cbFoodItemBonusType";
			this.cbFoodItemBonusType.Size = new Size(161, 21);
			this.cbFoodItemBonusType.TabIndex = 18;
			this.btnFoodItemUpdate.Location = new Point(7, 150);
			this.btnFoodItemUpdate.Name = "btnFoodItemUpdate";
			this.btnFoodItemUpdate.Size = new Size(75, 23);
			this.btnFoodItemUpdate.TabIndex = 10;
			this.btnFoodItemUpdate.Text = "Update";
			this.btnFoodItemUpdate.UseVisualStyleBackColor = true;
			this.label31.AutoSize = true;
			this.label31.Location = new Point(4, 127);
			this.label31.Name = "label31";
			this.label31.Size = new Size(67, 13);
			this.label31.TabIndex = 9;
			this.label31.Text = "Bonus Value";
			this.txtFoodItemBonusValue.Location = new Point(77, 124);
			this.txtFoodItemBonusValue.Name = "txtFoodItemBonusValue";
			this.txtFoodItemBonusValue.Size = new Size(161, 20);
			this.txtFoodItemBonusValue.TabIndex = 8;
			this.label32.AutoSize = true;
			this.label32.Location = new Point(4, 101);
			this.label32.Name = "label32";
			this.label32.Size = new Size(64, 13);
			this.label32.TabIndex = 7;
			this.label32.Text = "Bonus Type";
			this.txtFoodItemBonusType.Location = new Point(77, 98);
			this.txtFoodItemBonusType.Name = "txtFoodItemBonusType";
			this.txtFoodItemBonusType.Size = new Size(161, 20);
			this.txtFoodItemBonusType.TabIndex = 6;
			this.label33.AutoSize = true;
			this.label33.Location = new Point(4, 22);
			this.label33.Name = "label33";
			this.label33.Size = new Size(35, 13);
			this.label33.TabIndex = 5;
			this.label33.Text = "Name";
			this.cbFoodItemName.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cbFoodItemName.FormattingEnabled = true;
			this.cbFoodItemName.Location = new Point(77, 19);
			this.cbFoodItemName.Name = "cbFoodItemName";
			this.cbFoodItemName.Size = new Size(161, 21);
			this.cbFoodItemName.TabIndex = 4;
			this.label34.AutoSize = true;
			this.label34.Location = new Point(4, 75);
			this.label34.Name = "label34";
			this.label34.Size = new Size(46, 13);
			this.label34.TabIndex = 3;
			this.label34.Text = "Qt / Dur";
			this.txtFoodItemQtDur.Location = new Point(77, 72);
			this.txtFoodItemQtDur.Name = "txtFoodItemQtDur";
			this.txtFoodItemQtDur.Size = new Size(161, 20);
			this.txtFoodItemQtDur.TabIndex = 2;
			this.label35.AutoSize = true;
			this.label35.Location = new Point(4, 49);
			this.label35.Name = "label35";
			this.label35.Size = new Size(18, 13);
			this.label35.TabIndex = 1;
			this.label35.Text = "ID";
			this.txtFoodItemID.Location = new Point(77, 46);
			this.txtFoodItemID.Name = "txtFoodItemID";
			this.txtFoodItemID.Size = new Size(161, 20);
			this.txtFoodItemID.TabIndex = 0;
			this.lstFood.FormattingEnabled = true;
			this.lstFood.Location = new Point(6, 6);
			this.lstFood.Name = "lstFood";
			this.lstFood.Size = new Size(181, 225);
			this.lstFood.TabIndex = 10;
			this.tabPage8.Controls.Add(this.btnOtherItemUnlock);
			this.tabPage8.Controls.Add(this.gbOtherEdit);
			this.tabPage8.Controls.Add(this.lstOther);
			this.tabPage8.Location = new Point(4, 22);
			this.tabPage8.Name = "tabPage8";
			this.tabPage8.Padding = new Padding(3);
			this.tabPage8.Size = new Size(476, 241);
			this.tabPage8.TabIndex = 7;
			this.tabPage8.Text = "Other";
			this.tabPage8.UseVisualStyleBackColor = true;
			this.btnOtherItemUnlock.Location = new Point(362, 200);
			this.btnOtherItemUnlock.Name = "btnOtherItemUnlock";
			this.btnOtherItemUnlock.Size = new Size(75, 23);
			this.btnOtherItemUnlock.TabIndex = 25;
			this.btnOtherItemUnlock.Text = "Unlock";
			this.btnOtherItemUnlock.UseVisualStyleBackColor = true;
			this.btnOtherItemUnlock.Visible = false;
			this.gbOtherEdit.Controls.Add(this.cbOtherItemBonusType);
			this.gbOtherEdit.Controls.Add(this.btnOtherItemUpdate);
			this.gbOtherEdit.Controls.Add(this.label36);
			this.gbOtherEdit.Controls.Add(this.txtOtherItemBonusValue);
			this.gbOtherEdit.Controls.Add(this.label37);
			this.gbOtherEdit.Controls.Add(this.txtOtherItemBonusType);
			this.gbOtherEdit.Controls.Add(this.label38);
			this.gbOtherEdit.Controls.Add(this.cbOtherItemName);
			this.gbOtherEdit.Controls.Add(this.label39);
			this.gbOtherEdit.Controls.Add(this.txtOtherItemQtDur);
			this.gbOtherEdit.Controls.Add(this.label40);
			this.gbOtherEdit.Controls.Add(this.txtOtherItemID);
			this.gbOtherEdit.Location = new Point(193, 6);
			this.gbOtherEdit.Name = "gbOtherEdit";
			this.gbOtherEdit.Size = new Size(244, 188);
			this.gbOtherEdit.TabIndex = 13;
			this.gbOtherEdit.TabStop = false;
			this.gbOtherEdit.Text = "Edit Item";
			this.cbOtherItemBonusType.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cbOtherItemBonusType.FormattingEnabled = true;
			this.cbOtherItemBonusType.Location = new Point(77, 98);
			this.cbOtherItemBonusType.Name = "cbOtherItemBonusType";
			this.cbOtherItemBonusType.Size = new Size(161, 21);
			this.cbOtherItemBonusType.TabIndex = 18;
			this.btnOtherItemUpdate.Location = new Point(7, 150);
			this.btnOtherItemUpdate.Name = "btnOtherItemUpdate";
			this.btnOtherItemUpdate.Size = new Size(75, 23);
			this.btnOtherItemUpdate.TabIndex = 10;
			this.btnOtherItemUpdate.Text = "Update";
			this.btnOtherItemUpdate.UseVisualStyleBackColor = true;
			this.label36.AutoSize = true;
			this.label36.Location = new Point(4, 127);
			this.label36.Name = "label36";
			this.label36.Size = new Size(67, 13);
			this.label36.TabIndex = 9;
			this.label36.Text = "Bonus Value";
			this.txtOtherItemBonusValue.Location = new Point(77, 124);
			this.txtOtherItemBonusValue.Name = "txtOtherItemBonusValue";
			this.txtOtherItemBonusValue.Size = new Size(161, 20);
			this.txtOtherItemBonusValue.TabIndex = 8;
			this.label37.AutoSize = true;
			this.label37.Location = new Point(4, 101);
			this.label37.Name = "label37";
			this.label37.Size = new Size(64, 13);
			this.label37.TabIndex = 7;
			this.label37.Text = "Bonus Type";
			this.txtOtherItemBonusType.Location = new Point(77, 98);
			this.txtOtherItemBonusType.Name = "txtOtherItemBonusType";
			this.txtOtherItemBonusType.Size = new Size(161, 20);
			this.txtOtherItemBonusType.TabIndex = 6;
			this.label38.AutoSize = true;
			this.label38.Location = new Point(4, 22);
			this.label38.Name = "label38";
			this.label38.Size = new Size(35, 13);
			this.label38.TabIndex = 5;
			this.label38.Text = "Name";
			this.cbOtherItemName.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cbOtherItemName.FormattingEnabled = true;
			this.cbOtherItemName.Location = new Point(77, 19);
			this.cbOtherItemName.Name = "cbOtherItemName";
			this.cbOtherItemName.Size = new Size(161, 21);
			this.cbOtherItemName.TabIndex = 4;
			this.label39.AutoSize = true;
			this.label39.Location = new Point(4, 75);
			this.label39.Name = "label39";
			this.label39.Size = new Size(46, 13);
			this.label39.TabIndex = 3;
			this.label39.Text = "Qt / Dur";
			this.txtOtherItemQtDur.Location = new Point(77, 72);
			this.txtOtherItemQtDur.Name = "txtOtherItemQtDur";
			this.txtOtherItemQtDur.Size = new Size(161, 20);
			this.txtOtherItemQtDur.TabIndex = 2;
			this.label40.AutoSize = true;
			this.label40.Location = new Point(4, 49);
			this.label40.Name = "label40";
			this.label40.Size = new Size(18, 13);
			this.label40.TabIndex = 1;
			this.label40.Text = "ID";
			this.txtOtherItemID.Location = new Point(77, 46);
			this.txtOtherItemID.Name = "txtOtherItemID";
			this.txtOtherItemID.Size = new Size(161, 20);
			this.txtOtherItemID.TabIndex = 0;
			this.lstOther.FormattingEnabled = true;
			this.lstOther.Location = new Point(6, 6);
			this.lstOther.Name = "lstOther";
			this.lstOther.Size = new Size(181, 225);
			this.lstOther.TabIndex = 12;
			this.tabPage12.Controls.Add(this.gbRupees);
			this.tabPage12.Location = new Point(4, 22);
			this.tabPage12.Name = "tabPage12";
			this.tabPage12.Padding = new Padding(3);
			this.tabPage12.Size = new Size(476, 241);
			this.tabPage12.TabIndex = 8;
			this.tabPage12.Text = "Money";
			this.tabPage12.UseVisualStyleBackColor = true;
			this.gbRupees.Controls.Add(this.btnRefreshRupees);
			this.gbRupees.Controls.Add(this.btnUpdateRupees);
			this.gbRupees.Controls.Add(this.label71);
			this.gbRupees.Controls.Add(this.txtRupees);
			this.gbRupees.Enabled = false;
			this.gbRupees.Location = new Point(7, 6);
			this.gbRupees.Name = "gbRupees";
			this.gbRupees.Size = new Size(180, 71);
			this.gbRupees.TabIndex = 2;
			this.gbRupees.TabStop = false;
			this.gbRupees.Text = "Edit Money (Rupees)";
			this.btnRefreshRupees.Location = new Point(6, 42);
			this.btnRefreshRupees.Name = "btnRefreshRupees";
			this.btnRefreshRupees.Size = new Size(75, 23);
			this.btnRefreshRupees.TabIndex = 11;
			this.btnRefreshRupees.Text = "Refresh";
			this.btnRefreshRupees.UseVisualStyleBackColor = true;
			this.btnUpdateRupees.Location = new Point(99, 42);
			this.btnUpdateRupees.Name = "btnUpdateRupees";
			this.btnUpdateRupees.Size = new Size(75, 23);
			this.btnUpdateRupees.TabIndex = 10;
			this.btnUpdateRupees.Text = "Update";
			this.btnUpdateRupees.UseVisualStyleBackColor = true;
			this.label71.AutoSize = true;
			this.label71.Location = new Point(4, 19);
			this.label71.Name = "label71";
			this.label71.Size = new Size(44, 13);
			this.label71.TabIndex = 1;
			this.label71.Text = "Rupees";
			this.txtRupees.Location = new Point(54, 16);
			this.txtRupees.Name = "txtRupees";
			this.txtRupees.Size = new Size(120, 20);
			this.txtRupees.TabIndex = 0;
			this.tabPage20.Controls.Add(this.gbShieldsSlots);
			this.tabPage20.Controls.Add(this.gbBowsSlots);
			this.tabPage20.Controls.Add(this.gbWeaponsSlots);
			this.tabPage20.Location = new Point(4, 22);
			this.tabPage20.Name = "tabPage20";
			this.tabPage20.Padding = new Padding(3);
			this.tabPage20.Size = new Size(476, 241);
			this.tabPage20.TabIndex = 9;
			this.tabPage20.Text = "Slots";
			this.tabPage20.UseVisualStyleBackColor = true;
			this.gbShieldsSlots.Controls.Add(this.btnRefreshShieldsSlots);
			this.gbShieldsSlots.Controls.Add(this.btnUpdateShieldsSlots);
			this.gbShieldsSlots.Controls.Add(this.label52);
			this.gbShieldsSlots.Controls.Add(this.txtShieldsSlots);
			this.gbShieldsSlots.Enabled = false;
			this.gbShieldsSlots.Location = new Point(7, 155);
			this.gbShieldsSlots.Name = "gbShieldsSlots";
			this.gbShieldsSlots.Size = new Size(180, 71);
			this.gbShieldsSlots.TabIndex = 13;
			this.gbShieldsSlots.TabStop = false;
			this.gbShieldsSlots.Text = "Edit Shields Slots";
			this.btnRefreshShieldsSlots.Location = new Point(6, 42);
			this.btnRefreshShieldsSlots.Name = "btnRefreshShieldsSlots";
			this.btnRefreshShieldsSlots.Size = new Size(75, 23);
			this.btnRefreshShieldsSlots.TabIndex = 11;
			this.btnRefreshShieldsSlots.Text = "Refresh";
			this.btnRefreshShieldsSlots.UseVisualStyleBackColor = true;
			this.btnRefreshShieldsSlots.Click += new EventHandler(this.btnRefreshShieldsSlots_Click);
			this.btnUpdateShieldsSlots.Location = new Point(99, 42);
			this.btnUpdateShieldsSlots.Name = "btnUpdateShieldsSlots";
			this.btnUpdateShieldsSlots.Size = new Size(75, 23);
			this.btnUpdateShieldsSlots.TabIndex = 10;
			this.btnUpdateShieldsSlots.Text = "Update";
			this.btnUpdateShieldsSlots.UseVisualStyleBackColor = true;
			this.btnUpdateShieldsSlots.Click += new EventHandler(this.btnUpdateShieldsSlots_Click);
			this.label52.AutoSize = true;
			this.label52.Location = new Point(4, 19);
			this.label52.Name = "label52";
			this.label52.Size = new Size(30, 13);
			this.label52.TabIndex = 1;
			this.label52.Text = "Slots";
			this.txtShieldsSlots.Location = new Point(54, 16);
			this.txtShieldsSlots.Name = "txtShieldsSlots";
			this.txtShieldsSlots.Size = new Size(120, 20);
			this.txtShieldsSlots.TabIndex = 0;
			this.gbBowsSlots.Controls.Add(this.btnRefreshBowsSlots);
			this.gbBowsSlots.Controls.Add(this.btnUpdateBowsSlots);
			this.gbBowsSlots.Controls.Add(this.label51);
			this.gbBowsSlots.Controls.Add(this.txtBowsSlots);
			this.gbBowsSlots.Enabled = false;
			this.gbBowsSlots.Location = new Point(7, 81);
			this.gbBowsSlots.Name = "gbBowsSlots";
			this.gbBowsSlots.Size = new Size(180, 71);
			this.gbBowsSlots.TabIndex = 12;
			this.gbBowsSlots.TabStop = false;
			this.gbBowsSlots.Text = "Edit Bows Slots";
			this.btnRefreshBowsSlots.Location = new Point(6, 42);
			this.btnRefreshBowsSlots.Name = "btnRefreshBowsSlots";
			this.btnRefreshBowsSlots.Size = new Size(75, 23);
			this.btnRefreshBowsSlots.TabIndex = 11;
			this.btnRefreshBowsSlots.Text = "Refresh";
			this.btnRefreshBowsSlots.UseVisualStyleBackColor = true;
			this.btnRefreshBowsSlots.Click += new EventHandler(this.btnRefreshBowsSlots_Click);
			this.btnUpdateBowsSlots.Location = new Point(99, 42);
			this.btnUpdateBowsSlots.Name = "btnUpdateBowsSlots";
			this.btnUpdateBowsSlots.Size = new Size(75, 23);
			this.btnUpdateBowsSlots.TabIndex = 10;
			this.btnUpdateBowsSlots.Text = "Update";
			this.btnUpdateBowsSlots.UseVisualStyleBackColor = true;
			this.btnUpdateBowsSlots.Click += new EventHandler(this.btnUpdateBowsSlots_Click);
			this.label51.AutoSize = true;
			this.label51.Location = new Point(4, 19);
			this.label51.Name = "label51";
			this.label51.Size = new Size(30, 13);
			this.label51.TabIndex = 1;
			this.label51.Text = "Slots";
			this.txtBowsSlots.Location = new Point(54, 16);
			this.txtBowsSlots.Name = "txtBowsSlots";
			this.txtBowsSlots.Size = new Size(120, 20);
			this.txtBowsSlots.TabIndex = 0;
			this.gbWeaponsSlots.Controls.Add(this.btnRefreshWeaponsSlots);
			this.gbWeaponsSlots.Controls.Add(this.btnUpdateWeaponsSlots);
			this.gbWeaponsSlots.Controls.Add(this.label50);
			this.gbWeaponsSlots.Controls.Add(this.txtWeaponsSlots);
			this.gbWeaponsSlots.Enabled = false;
			this.gbWeaponsSlots.Location = new Point(7, 6);
			this.gbWeaponsSlots.Name = "gbWeaponsSlots";
			this.gbWeaponsSlots.Size = new Size(180, 71);
			this.gbWeaponsSlots.TabIndex = 3;
			this.gbWeaponsSlots.TabStop = false;
			this.gbWeaponsSlots.Text = "Edit Weapons Slots";
			this.btnRefreshWeaponsSlots.Location = new Point(6, 42);
			this.btnRefreshWeaponsSlots.Name = "btnRefreshWeaponsSlots";
			this.btnRefreshWeaponsSlots.Size = new Size(75, 23);
			this.btnRefreshWeaponsSlots.TabIndex = 11;
			this.btnRefreshWeaponsSlots.Text = "Refresh";
			this.btnRefreshWeaponsSlots.UseVisualStyleBackColor = true;
			this.btnRefreshWeaponsSlots.Click += new EventHandler(this.btnRefreshWeaponsSlots_Click);
			this.btnUpdateWeaponsSlots.Location = new Point(99, 42);
			this.btnUpdateWeaponsSlots.Name = "btnUpdateWeaponsSlots";
			this.btnUpdateWeaponsSlots.Size = new Size(75, 23);
			this.btnUpdateWeaponsSlots.TabIndex = 10;
			this.btnUpdateWeaponsSlots.Text = "Update";
			this.btnUpdateWeaponsSlots.UseVisualStyleBackColor = true;
			this.btnUpdateWeaponsSlots.Click += new EventHandler(this.btnUpdateWeaponsSlots_Click);
			this.label50.AutoSize = true;
			this.label50.Location = new Point(4, 19);
			this.label50.Name = "label50";
			this.label50.Size = new Size(30, 13);
			this.label50.TabIndex = 1;
			this.label50.Text = "Slots";
			this.txtWeaponsSlots.Location = new Point(54, 16);
			this.txtWeaponsSlots.Name = "txtWeaponsSlots";
			this.txtWeaponsSlots.Size = new Size(120, 20);
			this.txtWeaponsSlots.TabIndex = 0;
			this.btnScan.Location = new Point(12, 12);
			this.btnScan.Name = "btnScan";
			this.btnScan.Size = new Size(85, 23);
			this.btnScan.TabIndex = 3;
			this.btnScan.Text = "Scan Memory";
			this.btnScan.UseVisualStyleBackColor = true;
			this.btnScan.Click += new EventHandler(this.btnScan_Click);
			this.lblScan.AutoSize = true;
			this.lblScan.Location = new Point(103, 17);
			this.lblScan.Name = "lblScan";
			this.lblScan.Size = new Size(110, 13);
			this.lblScan.TabIndex = 5;
			this.lblScan.Text = "Click to Scan Memory";
			this.tabActions.Controls.Add(this.tabPage11);
			this.tabActions.Controls.Add(this.tabPage14);
			this.tabActions.Controls.Add(this.tabPage15);
			this.tabActions.Controls.Add(this.tabPage16);
			this.tabActions.Controls.Add(this.tabPage17);
			this.tabActions.Controls.Add(this.tabPage21);
			this.tabActions.Controls.Add(this.tabPage18);
			this.tabActions.Controls.Add(this.tabPage19);
			this.tabActions.Controls.Add(this.tabPage13);
			this.tabActions.Location = new Point(502, 41);
			this.tabActions.Name = "tabActions";
			this.tabActions.SelectedIndex = 0;
			this.tabActions.Size = new Size(507, 267);
			this.tabActions.TabIndex = 1;
			this.tabPage11.Controls.Add(this.groupBox13);
			this.tabPage11.Controls.Add(this.groupBox10);
			this.tabPage11.Location = new Point(4, 22);
			this.tabPage11.Name = "tabPage11";
			this.tabPage11.Padding = new Padding(3);
			this.tabPage11.Size = new Size(499, 241);
			this.tabPage11.TabIndex = 1;
			this.tabPage11.Text = "Weapons";
			this.tabPage11.UseVisualStyleBackColor = true;
			this.groupBox13.Controls.Add(this.lstWeaponsFilter);
			this.groupBox13.Controls.Add(this.optionWeaponsFilterList);
			this.groupBox13.Controls.Add(this.optionWeaponsNoFilter);
			this.groupBox13.Location = new Point(183, 6);
			this.groupBox13.Name = "groupBox13";
			this.groupBox13.Size = new Size(176, 229);
			this.groupBox13.TabIndex = 28;
			this.groupBox13.TabStop = false;
			this.groupBox13.Text = "Restore Filter";
			this.lstWeaponsFilter.FormattingEnabled = true;
			this.lstWeaponsFilter.Location = new Point(8, 71);
			this.lstWeaponsFilter.Name = "lstWeaponsFilter";
			this.lstWeaponsFilter.Size = new Size(162, 147);
			this.lstWeaponsFilter.TabIndex = 2;
			this.optionWeaponsFilterList.AutoSize = true;
			this.optionWeaponsFilterList.Location = new Point(8, 42);
			this.optionWeaponsFilterList.Name = "optionWeaponsFilterList";
			this.optionWeaponsFilterList.Size = new Size(138, 17);
			this.optionWeaponsFilterList.TabIndex = 1;
			this.optionWeaponsFilterList.Text = "Apply only to items in list";
			this.optionWeaponsFilterList.UseVisualStyleBackColor = true;
			this.optionWeaponsNoFilter.AutoSize = true;
			this.optionWeaponsNoFilter.Checked = true;
			this.optionWeaponsNoFilter.Location = new Point(8, 19);
			this.optionWeaponsNoFilter.Name = "optionWeaponsNoFilter";
			this.optionWeaponsNoFilter.Size = new Size(61, 17);
			this.optionWeaponsNoFilter.TabIndex = 0;
			this.optionWeaponsNoFilter.TabStop = true;
			this.optionWeaponsNoFilter.Text = "No filter";
			this.optionWeaponsNoFilter.UseVisualStyleBackColor = true;
			this.groupBox10.Controls.Add(this.chkWeaponsUseHotkey);
			this.groupBox10.Controls.Add(this.txtWeaponsHotKey);
			this.groupBox10.Controls.Add(this.chkWeaponsDisableWhenDone);
			this.groupBox10.Controls.Add(this.chkWeaponsActiveInactive);
			this.groupBox10.Controls.Add(this.txtWeaponsMax);
			this.groupBox10.Controls.Add(this.label44);
			this.groupBox10.Controls.Add(this.txtWeaponsQuantity);
			this.groupBox10.Controls.Add(this.label46);
			this.groupBox10.Controls.Add(this.txtWeaponsTimer);
			this.groupBox10.Controls.Add(this.label47);
			this.groupBox10.Controls.Add(this.txtWeaponsFixed);
			this.groupBox10.Controls.Add(this.optionWeaponsTimer);
			this.groupBox10.Controls.Add(this.optionWeaponsFixed);
			this.groupBox10.Location = new Point(6, 6);
			this.groupBox10.Name = "groupBox10";
			this.groupBox10.Size = new Size(171, 229);
			this.groupBox10.TabIndex = 24;
			this.groupBox10.TabStop = false;
			this.groupBox10.Text = "Restore Unequipped Weapons";
			this.chkWeaponsUseHotkey.AutoSize = true;
			this.chkWeaponsUseHotkey.Location = new Point(6, 149);
			this.chkWeaponsUseHotkey.Name = "chkWeaponsUseHotkey";
			this.chkWeaponsUseHotkey.Size = new Size(60, 17);
			this.chkWeaponsUseHotkey.TabIndex = 19;
			this.chkWeaponsUseHotkey.Text = "Hotkey";
			this.chkWeaponsUseHotkey.UseVisualStyleBackColor = true;
			this.txtWeaponsHotKey.Location = new Point(95, 145);
			this.txtWeaponsHotKey.Name = "txtWeaponsHotKey";
			this.txtWeaponsHotKey.ReadOnly = true;
			this.txtWeaponsHotKey.Size = new Size(62, 20);
			this.txtWeaponsHotKey.TabIndex = 18;
			this.chkWeaponsDisableWhenDone.AutoSize = true;
			this.chkWeaponsDisableWhenDone.Location = new Point(6, 129);
			this.chkWeaponsDisableWhenDone.Name = "chkWeaponsDisableWhenDone";
			this.chkWeaponsDisableWhenDone.Size = new Size(104, 17);
			this.chkWeaponsDisableWhenDone.TabIndex = 17;
			this.chkWeaponsDisableWhenDone.Text = "Stop when done";
			this.chkWeaponsDisableWhenDone.UseVisualStyleBackColor = true;
			this.chkWeaponsActiveInactive.AutoSize = true;
			this.chkWeaponsActiveInactive.Location = new Point(5, 201);
			this.chkWeaponsActiveInactive.Name = "chkWeaponsActiveInactive";
			this.chkWeaponsActiveInactive.Size = new Size(105, 17);
			this.chkWeaponsActiveInactive.TabIndex = 15;
			this.chkWeaponsActiveInactive.Text = "Active / Inactive";
			this.chkWeaponsActiveInactive.UseVisualStyleBackColor = true;
			this.txtWeaponsMax.Location = new Point(95, 105);
			this.txtWeaponsMax.Name = "txtWeaponsMax";
			this.txtWeaponsMax.Size = new Size(62, 20);
			this.txtWeaponsMax.TabIndex = 13;
			this.label44.AutoSize = true;
			this.label44.Location = new Point(22, 108);
			this.label44.Name = "label44";
			this.label44.Size = new Size(27, 13);
			this.label44.TabIndex = 14;
			this.label44.Text = "Max";
			this.txtWeaponsQuantity.Location = new Point(95, 85);
			this.txtWeaponsQuantity.Name = "txtWeaponsQuantity";
			this.txtWeaponsQuantity.Size = new Size(62, 20);
			this.txtWeaponsQuantity.TabIndex = 11;
			this.label46.AutoSize = true;
			this.label46.Location = new Point(22, 88);
			this.label46.Name = "label46";
			this.label46.Size = new Size(50, 13);
			this.label46.TabIndex = 12;
			this.label46.Text = "Durability";
			this.txtWeaponsTimer.Location = new Point(95, 65);
			this.txtWeaponsTimer.Name = "txtWeaponsTimer";
			this.txtWeaponsTimer.Size = new Size(62, 20);
			this.txtWeaponsTimer.TabIndex = 9;
			this.label47.AutoSize = true;
			this.label47.Location = new Point(22, 68);
			this.label47.Name = "label47";
			this.label47.Size = new Size(59, 13);
			this.label47.TabIndex = 10;
			this.label47.Text = "Timer (sec)";
			this.txtWeaponsFixed.Location = new Point(95, 20);
			this.txtWeaponsFixed.Name = "txtWeaponsFixed";
			this.txtWeaponsFixed.Size = new Size(62, 20);
			this.txtWeaponsFixed.TabIndex = 7;
			this.optionWeaponsTimer.AutoSize = true;
			this.optionWeaponsTimer.Checked = true;
			this.optionWeaponsTimer.Location = new Point(6, 44);
			this.optionWeaponsTimer.Name = "optionWeaponsTimer";
			this.optionWeaponsTimer.Size = new Size(83, 17);
			this.optionWeaponsTimer.TabIndex = 1;
			this.optionWeaponsTimer.TabStop = true;
			this.optionWeaponsTimer.Text = "Timer based";
			this.optionWeaponsTimer.UseVisualStyleBackColor = true;
			this.optionWeaponsFixed.AutoSize = true;
			this.optionWeaponsFixed.Location = new Point(6, 21);
			this.optionWeaponsFixed.Name = "optionWeaponsFixed";
			this.optionWeaponsFixed.Size = new Size(79, 17);
			this.optionWeaponsFixed.TabIndex = 0;
			this.optionWeaponsFixed.Text = "Fixed (Dur.)";
			this.optionWeaponsFixed.UseVisualStyleBackColor = true;
			this.tabPage14.Controls.Add(this.groupBox17);
			this.tabPage14.Controls.Add(this.groupBox18);
			this.tabPage14.Location = new Point(4, 22);
			this.tabPage14.Name = "tabPage14";
			this.tabPage14.Padding = new Padding(3);
			this.tabPage14.Size = new Size(499, 241);
			this.tabPage14.TabIndex = 2;
			this.tabPage14.Text = "Bows";
			this.tabPage14.UseVisualStyleBackColor = true;
			this.groupBox17.Controls.Add(this.lstBowsFilter);
			this.groupBox17.Controls.Add(this.optionBowsFilterList);
			this.groupBox17.Controls.Add(this.optionBowsNoFilter);
			this.groupBox17.Location = new Point(183, 6);
			this.groupBox17.Name = "groupBox17";
			this.groupBox17.Size = new Size(176, 229);
			this.groupBox17.TabIndex = 30;
			this.groupBox17.TabStop = false;
			this.groupBox17.Text = "Restore Filter";
			this.lstBowsFilter.FormattingEnabled = true;
			this.lstBowsFilter.Location = new Point(8, 71);
			this.lstBowsFilter.Name = "lstBowsFilter";
			this.lstBowsFilter.Size = new Size(162, 147);
			this.lstBowsFilter.TabIndex = 2;
			this.optionBowsFilterList.AutoSize = true;
			this.optionBowsFilterList.Location = new Point(8, 42);
			this.optionBowsFilterList.Name = "optionBowsFilterList";
			this.optionBowsFilterList.Size = new Size(138, 17);
			this.optionBowsFilterList.TabIndex = 1;
			this.optionBowsFilterList.Text = "Apply only to items in list";
			this.optionBowsFilterList.UseVisualStyleBackColor = true;
			this.optionBowsNoFilter.AutoSize = true;
			this.optionBowsNoFilter.Checked = true;
			this.optionBowsNoFilter.Location = new Point(8, 19);
			this.optionBowsNoFilter.Name = "optionBowsNoFilter";
			this.optionBowsNoFilter.Size = new Size(61, 17);
			this.optionBowsNoFilter.TabIndex = 0;
			this.optionBowsNoFilter.TabStop = true;
			this.optionBowsNoFilter.Text = "No filter";
			this.optionBowsNoFilter.UseVisualStyleBackColor = true;
			this.groupBox18.Controls.Add(this.chkBowsUseHotkey);
			this.groupBox18.Controls.Add(this.txtBowsHotKey);
			this.groupBox18.Controls.Add(this.chkBowsDisableWhenDone);
			this.groupBox18.Controls.Add(this.chkBowsActiveInactive);
			this.groupBox18.Controls.Add(this.txtBowsMax);
			this.groupBox18.Controls.Add(this.label54);
			this.groupBox18.Controls.Add(this.txtBowsQuantity);
			this.groupBox18.Controls.Add(this.label56);
			this.groupBox18.Controls.Add(this.txtBowsTimer);
			this.groupBox18.Controls.Add(this.label60);
			this.groupBox18.Controls.Add(this.txtBowsFixed);
			this.groupBox18.Controls.Add(this.optionBowsTimer);
			this.groupBox18.Controls.Add(this.optionBowsFixed);
			this.groupBox18.Location = new Point(6, 6);
			this.groupBox18.Name = "groupBox18";
			this.groupBox18.Size = new Size(171, 229);
			this.groupBox18.TabIndex = 29;
			this.groupBox18.TabStop = false;
			this.groupBox18.Text = "Restore Unequipped Bows";
			this.chkBowsUseHotkey.AutoSize = true;
			this.chkBowsUseHotkey.Location = new Point(6, 149);
			this.chkBowsUseHotkey.Name = "chkBowsUseHotkey";
			this.chkBowsUseHotkey.Size = new Size(60, 17);
			this.chkBowsUseHotkey.TabIndex = 19;
			this.chkBowsUseHotkey.Text = "Hotkey";
			this.chkBowsUseHotkey.UseVisualStyleBackColor = true;
			this.txtBowsHotKey.Location = new Point(95, 145);
			this.txtBowsHotKey.Name = "txtBowsHotKey";
			this.txtBowsHotKey.ReadOnly = true;
			this.txtBowsHotKey.Size = new Size(62, 20);
			this.txtBowsHotKey.TabIndex = 18;
			this.chkBowsDisableWhenDone.AutoSize = true;
			this.chkBowsDisableWhenDone.Location = new Point(6, 129);
			this.chkBowsDisableWhenDone.Name = "chkBowsDisableWhenDone";
			this.chkBowsDisableWhenDone.Size = new Size(104, 17);
			this.chkBowsDisableWhenDone.TabIndex = 17;
			this.chkBowsDisableWhenDone.Text = "Stop when done";
			this.chkBowsDisableWhenDone.UseVisualStyleBackColor = true;
			this.chkBowsActiveInactive.AutoSize = true;
			this.chkBowsActiveInactive.Location = new Point(5, 201);
			this.chkBowsActiveInactive.Name = "chkBowsActiveInactive";
			this.chkBowsActiveInactive.Size = new Size(105, 17);
			this.chkBowsActiveInactive.TabIndex = 15;
			this.chkBowsActiveInactive.Text = "Active / Inactive";
			this.chkBowsActiveInactive.UseVisualStyleBackColor = true;
			this.txtBowsMax.Location = new Point(95, 105);
			this.txtBowsMax.Name = "txtBowsMax";
			this.txtBowsMax.Size = new Size(62, 20);
			this.txtBowsMax.TabIndex = 13;
			this.label54.AutoSize = true;
			this.label54.Location = new Point(22, 108);
			this.label54.Name = "label54";
			this.label54.Size = new Size(27, 13);
			this.label54.TabIndex = 14;
			this.label54.Text = "Max";
			this.txtBowsQuantity.Location = new Point(95, 85);
			this.txtBowsQuantity.Name = "txtBowsQuantity";
			this.txtBowsQuantity.Size = new Size(62, 20);
			this.txtBowsQuantity.TabIndex = 11;
			this.label56.AutoSize = true;
			this.label56.Location = new Point(22, 88);
			this.label56.Name = "label56";
			this.label56.Size = new Size(50, 13);
			this.label56.TabIndex = 12;
			this.label56.Text = "Durability";
			this.txtBowsTimer.Location = new Point(95, 65);
			this.txtBowsTimer.Name = "txtBowsTimer";
			this.txtBowsTimer.Size = new Size(62, 20);
			this.txtBowsTimer.TabIndex = 9;
			this.label60.AutoSize = true;
			this.label60.Location = new Point(22, 68);
			this.label60.Name = "label60";
			this.label60.Size = new Size(59, 13);
			this.label60.TabIndex = 10;
			this.label60.Text = "Timer (sec)";
			this.txtBowsFixed.Location = new Point(95, 20);
			this.txtBowsFixed.Name = "txtBowsFixed";
			this.txtBowsFixed.Size = new Size(62, 20);
			this.txtBowsFixed.TabIndex = 7;
			this.optionBowsTimer.AutoSize = true;
			this.optionBowsTimer.Checked = true;
			this.optionBowsTimer.Location = new Point(6, 44);
			this.optionBowsTimer.Name = "optionBowsTimer";
			this.optionBowsTimer.Size = new Size(83, 17);
			this.optionBowsTimer.TabIndex = 1;
			this.optionBowsTimer.TabStop = true;
			this.optionBowsTimer.Text = "Timer based";
			this.optionBowsTimer.UseVisualStyleBackColor = true;
			this.optionBowsFixed.AutoSize = true;
			this.optionBowsFixed.Location = new Point(6, 21);
			this.optionBowsFixed.Name = "optionBowsFixed";
			this.optionBowsFixed.Size = new Size(79, 17);
			this.optionBowsFixed.TabIndex = 0;
			this.optionBowsFixed.Text = "Fixed (Dur.)";
			this.optionBowsFixed.UseVisualStyleBackColor = true;
			this.tabPage15.Controls.Add(this.groupBox20);
			this.tabPage15.Controls.Add(this.groupBox21);
			this.tabPage15.Location = new Point(4, 22);
			this.tabPage15.Name = "tabPage15";
			this.tabPage15.Padding = new Padding(3);
			this.tabPage15.Size = new Size(499, 241);
			this.tabPage15.TabIndex = 3;
			this.tabPage15.Text = "Shields";
			this.tabPage15.UseVisualStyleBackColor = true;
			this.groupBox20.Controls.Add(this.lstShieldsFilter);
			this.groupBox20.Controls.Add(this.optionShieldsFilterList);
			this.groupBox20.Controls.Add(this.optionShieldsNoFilter);
			this.groupBox20.Location = new Point(183, 6);
			this.groupBox20.Name = "groupBox20";
			this.groupBox20.Size = new Size(176, 229);
			this.groupBox20.TabIndex = 30;
			this.groupBox20.TabStop = false;
			this.groupBox20.Text = "Restore Filter";
			this.lstShieldsFilter.FormattingEnabled = true;
			this.lstShieldsFilter.Location = new Point(8, 71);
			this.lstShieldsFilter.Name = "lstShieldsFilter";
			this.lstShieldsFilter.Size = new Size(162, 147);
			this.lstShieldsFilter.TabIndex = 2;
			this.optionShieldsFilterList.AutoSize = true;
			this.optionShieldsFilterList.Location = new Point(8, 42);
			this.optionShieldsFilterList.Name = "optionShieldsFilterList";
			this.optionShieldsFilterList.Size = new Size(138, 17);
			this.optionShieldsFilterList.TabIndex = 1;
			this.optionShieldsFilterList.Text = "Apply only to items in list";
			this.optionShieldsFilterList.UseVisualStyleBackColor = true;
			this.optionShieldsNoFilter.AutoSize = true;
			this.optionShieldsNoFilter.Checked = true;
			this.optionShieldsNoFilter.Location = new Point(8, 19);
			this.optionShieldsNoFilter.Name = "optionShieldsNoFilter";
			this.optionShieldsNoFilter.Size = new Size(61, 17);
			this.optionShieldsNoFilter.TabIndex = 0;
			this.optionShieldsNoFilter.TabStop = true;
			this.optionShieldsNoFilter.Text = "No filter";
			this.optionShieldsNoFilter.UseVisualStyleBackColor = true;
			this.groupBox21.Controls.Add(this.chkShieldsUseHotkey);
			this.groupBox21.Controls.Add(this.txtShieldsHotKey);
			this.groupBox21.Controls.Add(this.chkShieldsDisableWhenDone);
			this.groupBox21.Controls.Add(this.chkShieldsActiveInactive);
			this.groupBox21.Controls.Add(this.txtShieldsMax);
			this.groupBox21.Controls.Add(this.label61);
			this.groupBox21.Controls.Add(this.txtShieldsQuantity);
			this.groupBox21.Controls.Add(this.label62);
			this.groupBox21.Controls.Add(this.txtShieldsTimer);
			this.groupBox21.Controls.Add(this.label63);
			this.groupBox21.Controls.Add(this.txtShieldsFixed);
			this.groupBox21.Controls.Add(this.optionShieldsTimer);
			this.groupBox21.Controls.Add(this.optionShieldsFixed);
			this.groupBox21.Location = new Point(6, 6);
			this.groupBox21.Name = "groupBox21";
			this.groupBox21.Size = new Size(171, 229);
			this.groupBox21.TabIndex = 29;
			this.groupBox21.TabStop = false;
			this.groupBox21.Text = "Restore Unequipped Shields";
			this.chkShieldsUseHotkey.AutoSize = true;
			this.chkShieldsUseHotkey.Location = new Point(6, 149);
			this.chkShieldsUseHotkey.Name = "chkShieldsUseHotkey";
			this.chkShieldsUseHotkey.Size = new Size(60, 17);
			this.chkShieldsUseHotkey.TabIndex = 19;
			this.chkShieldsUseHotkey.Text = "Hotkey";
			this.chkShieldsUseHotkey.UseVisualStyleBackColor = true;
			this.txtShieldsHotKey.Location = new Point(95, 145);
			this.txtShieldsHotKey.Name = "txtShieldsHotKey";
			this.txtShieldsHotKey.ReadOnly = true;
			this.txtShieldsHotKey.Size = new Size(62, 20);
			this.txtShieldsHotKey.TabIndex = 18;
			this.chkShieldsDisableWhenDone.AutoSize = true;
			this.chkShieldsDisableWhenDone.Location = new Point(6, 129);
			this.chkShieldsDisableWhenDone.Name = "chkShieldsDisableWhenDone";
			this.chkShieldsDisableWhenDone.Size = new Size(104, 17);
			this.chkShieldsDisableWhenDone.TabIndex = 17;
			this.chkShieldsDisableWhenDone.Text = "Stop when done";
			this.chkShieldsDisableWhenDone.UseVisualStyleBackColor = true;
			this.chkShieldsActiveInactive.AutoSize = true;
			this.chkShieldsActiveInactive.Location = new Point(5, 201);
			this.chkShieldsActiveInactive.Name = "chkShieldsActiveInactive";
			this.chkShieldsActiveInactive.Size = new Size(105, 17);
			this.chkShieldsActiveInactive.TabIndex = 15;
			this.chkShieldsActiveInactive.Text = "Active / Inactive";
			this.chkShieldsActiveInactive.UseVisualStyleBackColor = true;
			this.txtShieldsMax.Location = new Point(95, 105);
			this.txtShieldsMax.Name = "txtShieldsMax";
			this.txtShieldsMax.Size = new Size(62, 20);
			this.txtShieldsMax.TabIndex = 13;
			this.label61.AutoSize = true;
			this.label61.Location = new Point(22, 108);
			this.label61.Name = "label61";
			this.label61.Size = new Size(27, 13);
			this.label61.TabIndex = 14;
			this.label61.Text = "Max";
			this.txtShieldsQuantity.Location = new Point(95, 85);
			this.txtShieldsQuantity.Name = "txtShieldsQuantity";
			this.txtShieldsQuantity.Size = new Size(62, 20);
			this.txtShieldsQuantity.TabIndex = 11;
			this.label62.AutoSize = true;
			this.label62.Location = new Point(22, 88);
			this.label62.Name = "label62";
			this.label62.Size = new Size(50, 13);
			this.label62.TabIndex = 12;
			this.label62.Text = "Durability";
			this.txtShieldsTimer.Location = new Point(95, 65);
			this.txtShieldsTimer.Name = "txtShieldsTimer";
			this.txtShieldsTimer.Size = new Size(62, 20);
			this.txtShieldsTimer.TabIndex = 9;
			this.label63.AutoSize = true;
			this.label63.Location = new Point(22, 68);
			this.label63.Name = "label63";
			this.label63.Size = new Size(59, 13);
			this.label63.TabIndex = 10;
			this.label63.Text = "Timer (sec)";
			this.txtShieldsFixed.Location = new Point(95, 20);
			this.txtShieldsFixed.Name = "txtShieldsFixed";
			this.txtShieldsFixed.Size = new Size(62, 20);
			this.txtShieldsFixed.TabIndex = 7;
			this.optionShieldsTimer.AutoSize = true;
			this.optionShieldsTimer.Checked = true;
			this.optionShieldsTimer.Location = new Point(6, 44);
			this.optionShieldsTimer.Name = "optionShieldsTimer";
			this.optionShieldsTimer.Size = new Size(83, 17);
			this.optionShieldsTimer.TabIndex = 1;
			this.optionShieldsTimer.TabStop = true;
			this.optionShieldsTimer.Text = "Timer based";
			this.optionShieldsTimer.UseVisualStyleBackColor = true;
			this.optionShieldsFixed.AutoSize = true;
			this.optionShieldsFixed.Location = new Point(6, 21);
			this.optionShieldsFixed.Name = "optionShieldsFixed";
			this.optionShieldsFixed.Size = new Size(79, 17);
			this.optionShieldsFixed.TabIndex = 0;
			this.optionShieldsFixed.Text = "Fixed (Dur.)";
			this.optionShieldsFixed.UseVisualStyleBackColor = true;
			this.tabPage16.Controls.Add(this.groupBox22);
			this.tabPage16.Controls.Add(this.groupBox23);
			this.tabPage16.Location = new Point(4, 22);
			this.tabPage16.Name = "tabPage16";
			this.tabPage16.Padding = new Padding(3);
			this.tabPage16.Size = new Size(499, 241);
			this.tabPage16.TabIndex = 4;
			this.tabPage16.Text = "Arrows";
			this.tabPage16.UseVisualStyleBackColor = true;
			this.groupBox22.Controls.Add(this.lstArrowsFilter);
			this.groupBox22.Controls.Add(this.optionArrowsFilterList);
			this.groupBox22.Controls.Add(this.optionArrowsNoFilter);
			this.groupBox22.Location = new Point(183, 6);
			this.groupBox22.Name = "groupBox22";
			this.groupBox22.Size = new Size(176, 229);
			this.groupBox22.TabIndex = 30;
			this.groupBox22.TabStop = false;
			this.groupBox22.Text = "Restore Filter";
			this.lstArrowsFilter.FormattingEnabled = true;
			this.lstArrowsFilter.Location = new Point(8, 71);
			this.lstArrowsFilter.Name = "lstArrowsFilter";
			this.lstArrowsFilter.Size = new Size(162, 147);
			this.lstArrowsFilter.TabIndex = 2;
			this.optionArrowsFilterList.AutoSize = true;
			this.optionArrowsFilterList.Location = new Point(8, 42);
			this.optionArrowsFilterList.Name = "optionArrowsFilterList";
			this.optionArrowsFilterList.Size = new Size(138, 17);
			this.optionArrowsFilterList.TabIndex = 1;
			this.optionArrowsFilterList.Text = "Apply only to items in list";
			this.optionArrowsFilterList.UseVisualStyleBackColor = true;
			this.optionArrowsNoFilter.AutoSize = true;
			this.optionArrowsNoFilter.Checked = true;
			this.optionArrowsNoFilter.Location = new Point(8, 19);
			this.optionArrowsNoFilter.Name = "optionArrowsNoFilter";
			this.optionArrowsNoFilter.Size = new Size(61, 17);
			this.optionArrowsNoFilter.TabIndex = 0;
			this.optionArrowsNoFilter.TabStop = true;
			this.optionArrowsNoFilter.Text = "No filter";
			this.optionArrowsNoFilter.UseVisualStyleBackColor = true;
			this.groupBox23.Controls.Add(this.chkArrowsUseHotkey);
			this.groupBox23.Controls.Add(this.txtArrowsHotKey);
			this.groupBox23.Controls.Add(this.chkArrowsDisableWhenDone);
			this.groupBox23.Controls.Add(this.chkArrowsActiveInactive);
			this.groupBox23.Controls.Add(this.txtArrowsMax);
			this.groupBox23.Controls.Add(this.label64);
			this.groupBox23.Controls.Add(this.txtArrowsQuantity);
			this.groupBox23.Controls.Add(this.label65);
			this.groupBox23.Controls.Add(this.txtArrowsTimer);
			this.groupBox23.Controls.Add(this.label66);
			this.groupBox23.Controls.Add(this.txtArrowsFixed);
			this.groupBox23.Controls.Add(this.optionArrowsTimer);
			this.groupBox23.Controls.Add(this.optionArrowsFixed);
			this.groupBox23.Location = new Point(6, 6);
			this.groupBox23.Name = "groupBox23";
			this.groupBox23.Size = new Size(171, 229);
			this.groupBox23.TabIndex = 29;
			this.groupBox23.TabStop = false;
			this.groupBox23.Text = "Restore Arrows Quantity";
			this.chkArrowsUseHotkey.AutoSize = true;
			this.chkArrowsUseHotkey.Location = new Point(6, 149);
			this.chkArrowsUseHotkey.Name = "chkArrowsUseHotkey";
			this.chkArrowsUseHotkey.Size = new Size(60, 17);
			this.chkArrowsUseHotkey.TabIndex = 19;
			this.chkArrowsUseHotkey.Text = "Hotkey";
			this.chkArrowsUseHotkey.UseVisualStyleBackColor = true;
			this.txtArrowsHotKey.Location = new Point(95, 145);
			this.txtArrowsHotKey.Name = "txtArrowsHotKey";
			this.txtArrowsHotKey.ReadOnly = true;
			this.txtArrowsHotKey.Size = new Size(62, 20);
			this.txtArrowsHotKey.TabIndex = 18;
			this.chkArrowsDisableWhenDone.AutoSize = true;
			this.chkArrowsDisableWhenDone.Location = new Point(6, 129);
			this.chkArrowsDisableWhenDone.Name = "chkArrowsDisableWhenDone";
			this.chkArrowsDisableWhenDone.Size = new Size(104, 17);
			this.chkArrowsDisableWhenDone.TabIndex = 17;
			this.chkArrowsDisableWhenDone.Text = "Stop when done";
			this.chkArrowsDisableWhenDone.UseVisualStyleBackColor = true;
			this.chkArrowsActiveInactive.AutoSize = true;
			this.chkArrowsActiveInactive.Location = new Point(5, 201);
			this.chkArrowsActiveInactive.Name = "chkArrowsActiveInactive";
			this.chkArrowsActiveInactive.Size = new Size(105, 17);
			this.chkArrowsActiveInactive.TabIndex = 15;
			this.chkArrowsActiveInactive.Text = "Active / Inactive";
			this.chkArrowsActiveInactive.UseVisualStyleBackColor = true;
			this.txtArrowsMax.Location = new Point(95, 105);
			this.txtArrowsMax.Name = "txtArrowsMax";
			this.txtArrowsMax.Size = new Size(62, 20);
			this.txtArrowsMax.TabIndex = 13;
			this.label64.AutoSize = true;
			this.label64.Location = new Point(22, 108);
			this.label64.Name = "label64";
			this.label64.Size = new Size(27, 13);
			this.label64.TabIndex = 14;
			this.label64.Text = "Max";
			this.txtArrowsQuantity.Location = new Point(95, 85);
			this.txtArrowsQuantity.Name = "txtArrowsQuantity";
			this.txtArrowsQuantity.Size = new Size(62, 20);
			this.txtArrowsQuantity.TabIndex = 11;
			this.label65.AutoSize = true;
			this.label65.Location = new Point(22, 88);
			this.label65.Name = "label65";
			this.label65.Size = new Size(46, 13);
			this.label65.TabIndex = 12;
			this.label65.Text = "Quantity";
			this.txtArrowsTimer.Location = new Point(95, 65);
			this.txtArrowsTimer.Name = "txtArrowsTimer";
			this.txtArrowsTimer.Size = new Size(62, 20);
			this.txtArrowsTimer.TabIndex = 9;
			this.label66.AutoSize = true;
			this.label66.Location = new Point(22, 68);
			this.label66.Name = "label66";
			this.label66.Size = new Size(59, 13);
			this.label66.TabIndex = 10;
			this.label66.Text = "Timer (sec)";
			this.txtArrowsFixed.Location = new Point(95, 20);
			this.txtArrowsFixed.Name = "txtArrowsFixed";
			this.txtArrowsFixed.Size = new Size(62, 20);
			this.txtArrowsFixed.TabIndex = 7;
			this.optionArrowsTimer.AutoSize = true;
			this.optionArrowsTimer.Checked = true;
			this.optionArrowsTimer.Location = new Point(6, 44);
			this.optionArrowsTimer.Name = "optionArrowsTimer";
			this.optionArrowsTimer.Size = new Size(83, 17);
			this.optionArrowsTimer.TabIndex = 1;
			this.optionArrowsTimer.TabStop = true;
			this.optionArrowsTimer.Text = "Timer based";
			this.optionArrowsTimer.UseVisualStyleBackColor = true;
			this.optionArrowsFixed.AutoSize = true;
			this.optionArrowsFixed.Location = new Point(6, 21);
			this.optionArrowsFixed.Name = "optionArrowsFixed";
			this.optionArrowsFixed.Size = new Size(70, 17);
			this.optionArrowsFixed.TabIndex = 0;
			this.optionArrowsFixed.Text = "Fixed (Qt)";
			this.optionArrowsFixed.UseVisualStyleBackColor = true;
			this.tabPage17.Controls.Add(this.groupBox16);
			this.tabPage17.Controls.Add(this.groupBox14);
			this.tabPage17.Location = new Point(4, 22);
			this.tabPage17.Name = "tabPage17";
			this.tabPage17.Padding = new Padding(3);
			this.tabPage17.Size = new Size(499, 241);
			this.tabPage17.TabIndex = 5;
			this.tabPage17.Text = "Experimental";
			this.tabPage17.UseVisualStyleBackColor = true;
			this.groupBox16.Controls.Add(this.lblLockStaminaInfo);
			this.groupBox16.Controls.Add(this.chkLockStaminaSet);
			this.groupBox16.Controls.Add(this.txtLockStaminaHotKey);
			this.groupBox16.Controls.Add(this.chkLockStaminaUseHotkey);
			this.groupBox16.Controls.Add(this.lblLockHealthInfo);
			this.groupBox16.Controls.Add(this.chkLockHealthSet);
			this.groupBox16.Controls.Add(this.txtLockHealthHotKey);
			this.groupBox16.Controls.Add(this.chkLockHealthUseHotkey);
			this.groupBox16.Location = new Point(6, 168);
			this.groupBox16.Name = "groupBox16";
			this.groupBox16.Size = new Size(487, 67);
			this.groupBox16.TabIndex = 30;
			this.groupBox16.TabStop = false;
			this.groupBox16.Text = "Health && Stamina";
			this.lblLockStaminaInfo.AutoSize = true;
			this.lblLockStaminaInfo.Location = new Point(294, 43);
			this.lblLockStaminaInfo.Name = "lblLockStaminaInfo";
			this.lblLockStaminaInfo.Size = new Size(75, 13);
			this.lblLockStaminaInfo.TabIndex = 25;
			this.lblLockStaminaInfo.Text = "<informations>";
			this.chkLockStaminaSet.AutoSize = true;
			this.chkLockStaminaSet.Location = new Point(132, 42);
			this.chkLockStaminaSet.Name = "chkLockStaminaSet";
			this.chkLockStaminaSet.Size = new Size(91, 17);
			this.chkLockStaminaSet.TabIndex = 24;
			this.chkLockStaminaSet.Text = "Lock Stamina";
			this.chkLockStaminaSet.UseVisualStyleBackColor = true;
			this.txtLockStaminaHotKey.Location = new Point(64, 40);
			this.txtLockStaminaHotKey.Name = "txtLockStaminaHotKey";
			this.txtLockStaminaHotKey.ReadOnly = true;
			this.txtLockStaminaHotKey.Size = new Size(62, 20);
			this.txtLockStaminaHotKey.TabIndex = 23;
			this.chkLockStaminaUseHotkey.AutoSize = true;
			this.chkLockStaminaUseHotkey.Location = new Point(6, 42);
			this.chkLockStaminaUseHotkey.Name = "chkLockStaminaUseHotkey";
			this.chkLockStaminaUseHotkey.Size = new Size(61, 17);
			this.chkLockStaminaUseHotkey.TabIndex = 22;
			this.chkLockStaminaUseHotkey.Text = "HotKey";
			this.chkLockStaminaUseHotkey.UseVisualStyleBackColor = true;
			this.lblLockHealthInfo.AutoSize = true;
			this.lblLockHealthInfo.Location = new Point(294, 20);
			this.lblLockHealthInfo.Name = "lblLockHealthInfo";
			this.lblLockHealthInfo.Size = new Size(75, 13);
			this.lblLockHealthInfo.TabIndex = 21;
			this.lblLockHealthInfo.Text = "<informations>";
			this.chkLockHealthSet.AutoSize = true;
			this.chkLockHealthSet.Location = new Point(132, 19);
			this.chkLockHealthSet.Name = "chkLockHealthSet";
			this.chkLockHealthSet.Size = new Size(84, 17);
			this.chkLockHealthSet.TabIndex = 20;
			this.chkLockHealthSet.Text = "Lock Health";
			this.chkLockHealthSet.UseVisualStyleBackColor = true;
			this.txtLockHealthHotKey.Location = new Point(64, 17);
			this.txtLockHealthHotKey.Name = "txtLockHealthHotKey";
			this.txtLockHealthHotKey.ReadOnly = true;
			this.txtLockHealthHotKey.Size = new Size(62, 20);
			this.txtLockHealthHotKey.TabIndex = 19;
			this.chkLockHealthUseHotkey.AutoSize = true;
			this.chkLockHealthUseHotkey.Location = new Point(6, 19);
			this.chkLockHealthUseHotkey.Name = "chkLockHealthUseHotkey";
			this.chkLockHealthUseHotkey.Size = new Size(61, 17);
			this.chkLockHealthUseHotkey.TabIndex = 0;
			this.chkLockHealthUseHotkey.Text = "HotKey";
			this.chkLockHealthUseHotkey.UseVisualStyleBackColor = true;
			this.groupBox14.Controls.Add(this.groupBox3);
			this.groupBox14.Controls.Add(this.lblUnbreakableShieldsInfo);
			this.groupBox14.Controls.Add(this.chkUnbreakableShieldsSet);
			this.groupBox14.Controls.Add(this.txtUnbreakableShieldsHotKey);
			this.groupBox14.Controls.Add(this.chkUnbreakableShieldsUseHotkey);
			this.groupBox14.Controls.Add(this.lblUnbreakableBowsInfo);
			this.groupBox14.Controls.Add(this.chkUnbreakableBowsSet);
			this.groupBox14.Controls.Add(this.txtUnbreakableBowsHotKey);
			this.groupBox14.Controls.Add(this.chkUnbreakableBowsUseHotkey);
			this.groupBox14.Controls.Add(this.lblUnbreakableWeaponsInfo);
			this.groupBox14.Controls.Add(this.chkUnbreakableWeaponsSet);
			this.groupBox14.Controls.Add(this.txtUnbreakableWeaponsHotKey);
			this.groupBox14.Controls.Add(this.chkUnbreakableWeaponsUseHotkey);
			this.groupBox14.Location = new Point(6, 6);
			this.groupBox14.Name = "groupBox14";
			this.groupBox14.Size = new Size(487, 156);
			this.groupBox14.TabIndex = 29;
			this.groupBox14.TabStop = false;
			this.groupBox14.Text = "Unbreakable";
			this.groupBox3.Controls.Add(this.lstUnbreakableFilter);
			this.groupBox3.Controls.Add(this.optionUnbreakableFilterList);
			this.groupBox3.Controls.Add(this.optionUnbreakableNoFilter);
			this.groupBox3.Location = new Point(6, 83);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new Size(313, 69);
			this.groupBox3.TabIndex = 31;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Filter";
			this.lstUnbreakableFilter.FormattingEnabled = true;
			this.lstUnbreakableFilter.Location = new Point(147, 9);
			this.lstUnbreakableFilter.Name = "lstUnbreakableFilter";
			this.lstUnbreakableFilter.Size = new Size(162, 56);
			this.lstUnbreakableFilter.TabIndex = 2;
			this.optionUnbreakableFilterList.AutoSize = true;
			this.optionUnbreakableFilterList.Location = new Point(8, 36);
			this.optionUnbreakableFilterList.Name = "optionUnbreakableFilterList";
			this.optionUnbreakableFilterList.Size = new Size(138, 17);
			this.optionUnbreakableFilterList.TabIndex = 1;
			this.optionUnbreakableFilterList.Text = "Apply only to items in list";
			this.optionUnbreakableFilterList.UseVisualStyleBackColor = true;
			this.optionUnbreakableNoFilter.AutoSize = true;
			this.optionUnbreakableNoFilter.Checked = true;
			this.optionUnbreakableNoFilter.Location = new Point(8, 16);
			this.optionUnbreakableNoFilter.Name = "optionUnbreakableNoFilter";
			this.optionUnbreakableNoFilter.Size = new Size(61, 17);
			this.optionUnbreakableNoFilter.TabIndex = 0;
			this.optionUnbreakableNoFilter.TabStop = true;
			this.optionUnbreakableNoFilter.Text = "No filter";
			this.optionUnbreakableNoFilter.UseVisualStyleBackColor = true;
			this.lblUnbreakableShieldsInfo.AutoSize = true;
			this.lblUnbreakableShieldsInfo.Location = new Point(294, 66);
			this.lblUnbreakableShieldsInfo.Name = "lblUnbreakableShieldsInfo";
			this.lblUnbreakableShieldsInfo.Size = new Size(75, 13);
			this.lblUnbreakableShieldsInfo.TabIndex = 29;
			this.lblUnbreakableShieldsInfo.Text = "<informations>";
			this.chkUnbreakableShieldsSet.AutoSize = true;
			this.chkUnbreakableShieldsSet.Location = new Point(132, 65);
			this.chkUnbreakableShieldsSet.Name = "chkUnbreakableShieldsSet";
			this.chkUnbreakableShieldsSet.Size = new Size(143, 17);
			this.chkUnbreakableShieldsSet.TabIndex = 28;
			this.chkUnbreakableShieldsSet.Text = "Set Shields Unbreakable";
			this.chkUnbreakableShieldsSet.UseVisualStyleBackColor = true;
			this.txtUnbreakableShieldsHotKey.Location = new Point(64, 63);
			this.txtUnbreakableShieldsHotKey.Name = "txtUnbreakableShieldsHotKey";
			this.txtUnbreakableShieldsHotKey.ReadOnly = true;
			this.txtUnbreakableShieldsHotKey.Size = new Size(62, 20);
			this.txtUnbreakableShieldsHotKey.TabIndex = 27;
			this.chkUnbreakableShieldsUseHotkey.AutoSize = true;
			this.chkUnbreakableShieldsUseHotkey.Location = new Point(6, 65);
			this.chkUnbreakableShieldsUseHotkey.Name = "chkUnbreakableShieldsUseHotkey";
			this.chkUnbreakableShieldsUseHotkey.Size = new Size(61, 17);
			this.chkUnbreakableShieldsUseHotkey.TabIndex = 26;
			this.chkUnbreakableShieldsUseHotkey.Text = "HotKey";
			this.chkUnbreakableShieldsUseHotkey.UseVisualStyleBackColor = true;
			this.lblUnbreakableBowsInfo.AutoSize = true;
			this.lblUnbreakableBowsInfo.Location = new Point(294, 43);
			this.lblUnbreakableBowsInfo.Name = "lblUnbreakableBowsInfo";
			this.lblUnbreakableBowsInfo.Size = new Size(75, 13);
			this.lblUnbreakableBowsInfo.TabIndex = 25;
			this.lblUnbreakableBowsInfo.Text = "<informations>";
			this.chkUnbreakableBowsSet.AutoSize = true;
			this.chkUnbreakableBowsSet.Location = new Point(132, 42);
			this.chkUnbreakableBowsSet.Name = "chkUnbreakableBowsSet";
			this.chkUnbreakableBowsSet.Size = new Size(135, 17);
			this.chkUnbreakableBowsSet.TabIndex = 24;
			this.chkUnbreakableBowsSet.Text = "Set Bows Unbreakable";
			this.chkUnbreakableBowsSet.UseVisualStyleBackColor = true;
			this.txtUnbreakableBowsHotKey.Location = new Point(64, 40);
			this.txtUnbreakableBowsHotKey.Name = "txtUnbreakableBowsHotKey";
			this.txtUnbreakableBowsHotKey.ReadOnly = true;
			this.txtUnbreakableBowsHotKey.Size = new Size(62, 20);
			this.txtUnbreakableBowsHotKey.TabIndex = 23;
			this.chkUnbreakableBowsUseHotkey.AutoSize = true;
			this.chkUnbreakableBowsUseHotkey.Location = new Point(6, 42);
			this.chkUnbreakableBowsUseHotkey.Name = "chkUnbreakableBowsUseHotkey";
			this.chkUnbreakableBowsUseHotkey.Size = new Size(61, 17);
			this.chkUnbreakableBowsUseHotkey.TabIndex = 22;
			this.chkUnbreakableBowsUseHotkey.Text = "HotKey";
			this.chkUnbreakableBowsUseHotkey.UseVisualStyleBackColor = true;
			this.lblUnbreakableWeaponsInfo.AutoSize = true;
			this.lblUnbreakableWeaponsInfo.Location = new Point(294, 20);
			this.lblUnbreakableWeaponsInfo.Name = "lblUnbreakableWeaponsInfo";
			this.lblUnbreakableWeaponsInfo.Size = new Size(75, 13);
			this.lblUnbreakableWeaponsInfo.TabIndex = 21;
			this.lblUnbreakableWeaponsInfo.Text = "<informations>";
			this.chkUnbreakableWeaponsSet.AutoSize = true;
			this.chkUnbreakableWeaponsSet.Location = new Point(132, 19);
			this.chkUnbreakableWeaponsSet.Name = "chkUnbreakableWeaponsSet";
			this.chkUnbreakableWeaponsSet.Size = new Size(155, 17);
			this.chkUnbreakableWeaponsSet.TabIndex = 20;
			this.chkUnbreakableWeaponsSet.Text = "Set Weapons Unbreakable";
			this.chkUnbreakableWeaponsSet.UseVisualStyleBackColor = true;
			this.txtUnbreakableWeaponsHotKey.Location = new Point(64, 17);
			this.txtUnbreakableWeaponsHotKey.Name = "txtUnbreakableWeaponsHotKey";
			this.txtUnbreakableWeaponsHotKey.ReadOnly = true;
			this.txtUnbreakableWeaponsHotKey.Size = new Size(62, 20);
			this.txtUnbreakableWeaponsHotKey.TabIndex = 19;
			this.chkUnbreakableWeaponsUseHotkey.AutoSize = true;
			this.chkUnbreakableWeaponsUseHotkey.Location = new Point(6, 19);
			this.chkUnbreakableWeaponsUseHotkey.Name = "chkUnbreakableWeaponsUseHotkey";
			this.chkUnbreakableWeaponsUseHotkey.Size = new Size(61, 17);
			this.chkUnbreakableWeaponsUseHotkey.TabIndex = 0;
			this.chkUnbreakableWeaponsUseHotkey.Text = "HotKey";
			this.chkUnbreakableWeaponsUseHotkey.UseVisualStyleBackColor = true;
			this.tabPage21.Controls.Add(this.groupBox6);
			this.tabPage21.Controls.Add(this.groupBox7);
			this.tabPage21.Location = new Point(4, 22);
			this.tabPage21.Name = "tabPage21";
			this.tabPage21.Padding = new Padding(3);
			this.tabPage21.Size = new Size(499, 241);
			this.tabPage21.TabIndex = 8;
			this.tabPage21.Text = "Position";
			this.tabPage21.UseVisualStyleBackColor = true;
			this.groupBox6.Controls.Add(this.btnCapturedPositionTP);
			this.groupBox6.Controls.Add(this.label70);
			this.groupBox6.Controls.Add(this.txtCapturedPositionName);
			this.groupBox6.Controls.Add(this.label57);
			this.groupBox6.Controls.Add(this.txtCapturedPositionZ);
			this.groupBox6.Controls.Add(this.label58);
			this.groupBox6.Controls.Add(this.txtCapturedPositionY);
			this.groupBox6.Controls.Add(this.label69);
			this.groupBox6.Controls.Add(this.txtCapturedPositionX);
			this.groupBox6.Controls.Add(this.btnCapturedPositionRemove);
			this.groupBox6.Controls.Add(this.btnCapturedPositionSave);
			this.groupBox6.Controls.Add(this.btnCapturedPositionNew);
			this.groupBox6.Controls.Add(this.lstCapturedPositions);
			this.groupBox6.Location = new Point(8, 107);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new Size(487, 124);
			this.groupBox6.TabIndex = 36;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "Captured Positions";
			this.btnCapturedPositionTP.Location = new Point(239, 16);
			this.btnCapturedPositionTP.Name = "btnCapturedPositionTP";
			this.btnCapturedPositionTP.Size = new Size(29, 97);
			this.btnCapturedPositionTP.TabIndex = 58;
			this.btnCapturedPositionTP.Text = "TP";
			this.btnCapturedPositionTP.UseVisualStyleBackColor = true;
			this.btnCapturedPositionTP.Click += new EventHandler(this.btnCapturedPositionTP_Click);
			this.label70.AutoSize = true;
			this.label70.Location = new Point(337, 100);
			this.label70.Name = "label70";
			this.label70.Size = new Size(35, 13);
			this.label70.TabIndex = 57;
			this.label70.Text = "Name";
			this.txtCapturedPositionName.Location = new Point(372, 97);
			this.txtCapturedPositionName.Name = "txtCapturedPositionName";
			this.txtCapturedPositionName.Size = new Size(109, 20);
			this.txtCapturedPositionName.TabIndex = 56;
			this.label57.AutoSize = true;
			this.label57.Location = new Point(349, 74);
			this.label57.Name = "label57";
			this.label57.Size = new Size(23, 13);
			this.label57.TabIndex = 55;
			this.label57.Text = "Z =";
			this.txtCapturedPositionZ.Location = new Point(372, 71);
			this.txtCapturedPositionZ.Name = "txtCapturedPositionZ";
			this.txtCapturedPositionZ.Size = new Size(109, 20);
			this.txtCapturedPositionZ.TabIndex = 54;
			this.label58.AutoSize = true;
			this.label58.Location = new Point(349, 48);
			this.label58.Name = "label58";
			this.label58.Size = new Size(23, 13);
			this.label58.TabIndex = 53;
			this.label58.Text = "Y =";
			this.txtCapturedPositionY.Location = new Point(372, 45);
			this.txtCapturedPositionY.Name = "txtCapturedPositionY";
			this.txtCapturedPositionY.Size = new Size(109, 20);
			this.txtCapturedPositionY.TabIndex = 52;
			this.label69.AutoSize = true;
			this.label69.Location = new Point(349, 22);
			this.label69.Name = "label69";
			this.label69.Size = new Size(23, 13);
			this.label69.TabIndex = 51;
			this.label69.Text = "X =";
			this.txtCapturedPositionX.Location = new Point(372, 19);
			this.txtCapturedPositionX.Name = "txtCapturedPositionX";
			this.txtCapturedPositionX.Size = new Size(109, 20);
			this.txtCapturedPositionX.TabIndex = 50;
			this.btnCapturedPositionRemove.Location = new Point(273, 74);
			this.btnCapturedPositionRemove.Name = "btnCapturedPositionRemove";
			this.btnCapturedPositionRemove.Size = new Size(66, 23);
			this.btnCapturedPositionRemove.TabIndex = 49;
			this.btnCapturedPositionRemove.Text = "Remove";
			this.btnCapturedPositionRemove.UseVisualStyleBackColor = true;
			this.btnCapturedPositionRemove.Click += new EventHandler(this.btnCapturedPositionRemove_Click);
			this.btnCapturedPositionSave.Location = new Point(273, 45);
			this.btnCapturedPositionSave.Name = "btnCapturedPositionSave";
			this.btnCapturedPositionSave.Size = new Size(66, 23);
			this.btnCapturedPositionSave.TabIndex = 48;
			this.btnCapturedPositionSave.Text = "Save";
			this.btnCapturedPositionSave.UseVisualStyleBackColor = true;
			this.btnCapturedPositionSave.Click += new EventHandler(this.btnCapturedPositionSave_Click);
			this.btnCapturedPositionNew.Location = new Point(273, 16);
			this.btnCapturedPositionNew.Name = "btnCapturedPositionNew";
			this.btnCapturedPositionNew.Size = new Size(66, 23);
			this.btnCapturedPositionNew.TabIndex = 47;
			this.btnCapturedPositionNew.Text = "New";
			this.btnCapturedPositionNew.UseVisualStyleBackColor = true;
			this.btnCapturedPositionNew.Click += new EventHandler(this.btnCapturedPositionNew_Click);
			this.lstCapturedPositions.FormattingEnabled = true;
			this.lstCapturedPositions.Location = new Point(6, 16);
			this.lstCapturedPositions.Name = "lstCapturedPositions";
			this.lstCapturedPositions.Size = new Size(227, 95);
			this.lstCapturedPositions.TabIndex = 1;
			this.groupBox7.Controls.Add(this.btnPositionEdit);
			this.groupBox7.Controls.Add(this.btnPositionRestore);
			this.groupBox7.Controls.Add(this.txtPositionRestoreHotKey);
			this.groupBox7.Controls.Add(this.chkPositionRestoreUseHotkey);
			this.groupBox7.Controls.Add(this.btnPositionSave);
			this.groupBox7.Controls.Add(this.txtPositionSaveHotKey);
			this.groupBox7.Controls.Add(this.chkPositionSaveUseHotkey);
			this.groupBox7.Controls.Add(this.btnPositionJump);
			this.groupBox7.Controls.Add(this.txtPositionJumpHeight);
			this.groupBox7.Controls.Add(this.txtPositionJumpHotKey);
			this.groupBox7.Controls.Add(this.chkPositionJumpUseHotkey);
			this.groupBox7.Controls.Add(this.chkPositionLockHeightSet);
			this.groupBox7.Controls.Add(this.txtPositionLockHeightHotKey);
			this.groupBox7.Controls.Add(this.chkPositionLockHeightUseHotkey);
			this.groupBox7.Controls.Add(this.label68);
			this.groupBox7.Controls.Add(this.txtPositionZ);
			this.groupBox7.Controls.Add(this.label67);
			this.groupBox7.Controls.Add(this.txtPositionY);
			this.groupBox7.Controls.Add(this.label59);
			this.groupBox7.Controls.Add(this.txtPositionX);
			this.groupBox7.Location = new Point(8, 6);
			this.groupBox7.Name = "groupBox7";
			this.groupBox7.Size = new Size(487, 99);
			this.groupBox7.TabIndex = 35;
			this.groupBox7.TabStop = false;
			this.groupBox7.Text = "Current Position";
			this.btnPositionEdit.Location = new Point(266, 17);
			this.btnPositionEdit.Name = "btnPositionEdit";
			this.btnPositionEdit.Size = new Size(66, 23);
			this.btnPositionEdit.TabIndex = 46;
			this.btnPositionEdit.Text = "Edit";
			this.btnPositionEdit.UseVisualStyleBackColor = true;
			this.btnPositionEdit.Click += new EventHandler(this.btnPositionEdit_Click);
			this.btnPositionRestore.Location = new Point(131, 67);
			this.btnPositionRestore.Name = "btnPositionRestore";
			this.btnPositionRestore.Size = new Size(66, 23);
			this.btnPositionRestore.TabIndex = 45;
			this.btnPositionRestore.Text = "Restore";
			this.btnPositionRestore.UseVisualStyleBackColor = true;
			this.btnPositionRestore.Click += new EventHandler(this.btnPositionRestore_Click);
			this.txtPositionRestoreHotKey.Location = new Point(63, 69);
			this.txtPositionRestoreHotKey.Name = "txtPositionRestoreHotKey";
			this.txtPositionRestoreHotKey.ReadOnly = true;
			this.txtPositionRestoreHotKey.Size = new Size(62, 20);
			this.txtPositionRestoreHotKey.TabIndex = 44;
			this.chkPositionRestoreUseHotkey.AutoSize = true;
			this.chkPositionRestoreUseHotkey.Location = new Point(5, 71);
			this.chkPositionRestoreUseHotkey.Name = "chkPositionRestoreUseHotkey";
			this.chkPositionRestoreUseHotkey.Size = new Size(61, 17);
			this.chkPositionRestoreUseHotkey.TabIndex = 43;
			this.chkPositionRestoreUseHotkey.Text = "HotKey";
			this.chkPositionRestoreUseHotkey.UseVisualStyleBackColor = true;
			this.btnPositionSave.Location = new Point(131, 41);
			this.btnPositionSave.Name = "btnPositionSave";
			this.btnPositionSave.Size = new Size(66, 23);
			this.btnPositionSave.TabIndex = 42;
			this.btnPositionSave.Text = "Save";
			this.btnPositionSave.UseVisualStyleBackColor = true;
			this.btnPositionSave.Click += new EventHandler(this.btnPositionSave_Click);
			this.txtPositionSaveHotKey.Location = new Point(63, 43);
			this.txtPositionSaveHotKey.Name = "txtPositionSaveHotKey";
			this.txtPositionSaveHotKey.ReadOnly = true;
			this.txtPositionSaveHotKey.Size = new Size(62, 20);
			this.txtPositionSaveHotKey.TabIndex = 41;
			this.chkPositionSaveUseHotkey.AutoSize = true;
			this.chkPositionSaveUseHotkey.Location = new Point(5, 45);
			this.chkPositionSaveUseHotkey.Name = "chkPositionSaveUseHotkey";
			this.chkPositionSaveUseHotkey.Size = new Size(61, 17);
			this.chkPositionSaveUseHotkey.TabIndex = 40;
			this.chkPositionSaveUseHotkey.Text = "HotKey";
			this.chkPositionSaveUseHotkey.UseVisualStyleBackColor = true;
			this.btnPositionJump.Location = new Point(351, 66);
			this.btnPositionJump.Name = "btnPositionJump";
			this.btnPositionJump.Size = new Size(66, 23);
			this.btnPositionJump.TabIndex = 39;
			this.btnPositionJump.Text = "Jump";
			this.btnPositionJump.UseVisualStyleBackColor = true;
			this.btnPositionJump.Click += new EventHandler(this.btnPositionJump_Click);
			this.txtPositionJumpHeight.Location = new Point(423, 68);
			this.txtPositionJumpHeight.Name = "txtPositionJumpHeight";
			this.txtPositionJumpHeight.Size = new Size(56, 20);
			this.txtPositionJumpHeight.TabIndex = 38;
			this.txtPositionJumpHeight.Text = "100";
			this.txtPositionJumpHotKey.Location = new Point(283, 68);
			this.txtPositionJumpHotKey.Name = "txtPositionJumpHotKey";
			this.txtPositionJumpHotKey.ReadOnly = true;
			this.txtPositionJumpHotKey.Size = new Size(62, 20);
			this.txtPositionJumpHotKey.TabIndex = 37;
			this.chkPositionJumpUseHotkey.AutoSize = true;
			this.chkPositionJumpUseHotkey.Location = new Point(225, 70);
			this.chkPositionJumpUseHotkey.Name = "chkPositionJumpUseHotkey";
			this.chkPositionJumpUseHotkey.Size = new Size(61, 17);
			this.chkPositionJumpUseHotkey.TabIndex = 36;
			this.chkPositionJumpUseHotkey.Text = "HotKey";
			this.chkPositionJumpUseHotkey.UseVisualStyleBackColor = true;
			this.chkPositionLockHeightSet.AutoSize = true;
			this.chkPositionLockHeightSet.Location = new Point(351, 45);
			this.chkPositionLockHeightSet.Name = "chkPositionLockHeightSet";
			this.chkPositionLockHeightSet.Size = new Size(100, 17);
			this.chkPositionLockHeightSet.TabIndex = 35;
			this.chkPositionLockHeightSet.Text = "Lock Height (Y)";
			this.chkPositionLockHeightSet.UseVisualStyleBackColor = true;
			this.txtPositionLockHeightHotKey.Location = new Point(283, 43);
			this.txtPositionLockHeightHotKey.Name = "txtPositionLockHeightHotKey";
			this.txtPositionLockHeightHotKey.ReadOnly = true;
			this.txtPositionLockHeightHotKey.Size = new Size(62, 20);
			this.txtPositionLockHeightHotKey.TabIndex = 34;
			this.chkPositionLockHeightUseHotkey.AutoSize = true;
			this.chkPositionLockHeightUseHotkey.Location = new Point(225, 45);
			this.chkPositionLockHeightUseHotkey.Name = "chkPositionLockHeightUseHotkey";
			this.chkPositionLockHeightUseHotkey.Size = new Size(61, 17);
			this.chkPositionLockHeightUseHotkey.TabIndex = 33;
			this.chkPositionLockHeightUseHotkey.Text = "HotKey";
			this.chkPositionLockHeightUseHotkey.UseVisualStyleBackColor = true;
			this.label68.AutoSize = true;
			this.label68.Location = new Point(175, 22);
			this.label68.Name = "label68";
			this.label68.Size = new Size(23, 13);
			this.label68.TabIndex = 32;
			this.label68.Text = "Z =";
			this.txtPositionZ.Location = new Point(198, 19);
			this.txtPositionZ.Name = "txtPositionZ";
			this.txtPositionZ.ReadOnly = true;
			this.txtPositionZ.Size = new Size(62, 20);
			this.txtPositionZ.TabIndex = 31;
			this.label67.AutoSize = true;
			this.label67.Location = new Point(89, 22);
			this.label67.Name = "label67";
			this.label67.Size = new Size(23, 13);
			this.label67.TabIndex = 30;
			this.label67.Text = "Y =";
			this.txtPositionY.Location = new Point(112, 19);
			this.txtPositionY.Name = "txtPositionY";
			this.txtPositionY.ReadOnly = true;
			this.txtPositionY.Size = new Size(62, 20);
			this.txtPositionY.TabIndex = 29;
			this.label59.AutoSize = true;
			this.label59.Location = new Point(3, 22);
			this.label59.Name = "label59";
			this.label59.Size = new Size(23, 13);
			this.label59.TabIndex = 28;
			this.label59.Text = "X =";
			this.txtPositionX.Location = new Point(26, 19);
			this.txtPositionX.Name = "txtPositionX";
			this.txtPositionX.ReadOnly = true;
			this.txtPositionX.Size = new Size(62, 20);
			this.txtPositionX.TabIndex = 23;
			this.tabPage18.Controls.Add(this.groupBox19);
			this.tabPage18.Location = new Point(4, 22);
			this.tabPage18.Name = "tabPage18";
			this.tabPage18.Padding = new Padding(3);
			this.tabPage18.Size = new Size(499, 241);
			this.tabPage18.TabIndex = 6;
			this.tabPage18.Text = "Powers";
			this.tabPage18.UseVisualStyleBackColor = true;
			this.groupBox19.Controls.Add(this.lblPowersDarukInfo);
			this.groupBox19.Controls.Add(this.chkPowersDarukSet);
			this.groupBox19.Controls.Add(this.txtPowersDarukHotKey);
			this.groupBox19.Controls.Add(this.chkPowersDarukUseHotkey);
			this.groupBox19.Controls.Add(this.lblPowersUrbosaInfo);
			this.groupBox19.Controls.Add(this.chkPowersUrbosaSet);
			this.groupBox19.Controls.Add(this.txtPowersUrbosaHotKey);
			this.groupBox19.Controls.Add(this.chkPowersUrbosaUseHotkey);
			this.groupBox19.Controls.Add(this.lblPowersRevaliInfo);
			this.groupBox19.Controls.Add(this.chkPowersRevaliSet);
			this.groupBox19.Controls.Add(this.txtPowersRevaliHotKey);
			this.groupBox19.Controls.Add(this.chkPowersRevaliUseHotkey);
			this.groupBox19.Controls.Add(this.lblPowersMiphaInfo);
			this.groupBox19.Controls.Add(this.chkPowersMiphaSet);
			this.groupBox19.Controls.Add(this.txtPowersMiphaHotKey);
			this.groupBox19.Controls.Add(this.chkPowersMiphaUseHotkey);
			this.groupBox19.Location = new Point(6, 6);
			this.groupBox19.Name = "groupBox19";
			this.groupBox19.Size = new Size(487, 114);
			this.groupBox19.TabIndex = 31;
			this.groupBox19.TabStop = false;
			this.groupBox19.Text = "Unlimit Divine Powers";
			this.lblPowersDarukInfo.AutoSize = true;
			this.lblPowersDarukInfo.Location = new Point(294, 89);
			this.lblPowersDarukInfo.Name = "lblPowersDarukInfo";
			this.lblPowersDarukInfo.Size = new Size(75, 13);
			this.lblPowersDarukInfo.TabIndex = 33;
			this.lblPowersDarukInfo.Text = "<informations>";
			this.chkPowersDarukSet.AutoSize = true;
			this.chkPowersDarukSet.Location = new Point(132, 88);
			this.chkPowersDarukSet.Name = "chkPowersDarukSet";
			this.chkPowersDarukSet.Size = new Size(113, 17);
			this.chkPowersDarukSet.TabIndex = 32;
			this.chkPowersDarukSet.Text = "Daruk's Protection";
			this.chkPowersDarukSet.UseVisualStyleBackColor = true;
			this.txtPowersDarukHotKey.Location = new Point(64, 86);
			this.txtPowersDarukHotKey.Name = "txtPowersDarukHotKey";
			this.txtPowersDarukHotKey.ReadOnly = true;
			this.txtPowersDarukHotKey.Size = new Size(62, 20);
			this.txtPowersDarukHotKey.TabIndex = 31;
			this.chkPowersDarukUseHotkey.AutoSize = true;
			this.chkPowersDarukUseHotkey.Location = new Point(6, 88);
			this.chkPowersDarukUseHotkey.Name = "chkPowersDarukUseHotkey";
			this.chkPowersDarukUseHotkey.Size = new Size(61, 17);
			this.chkPowersDarukUseHotkey.TabIndex = 30;
			this.chkPowersDarukUseHotkey.Text = "HotKey";
			this.chkPowersDarukUseHotkey.UseVisualStyleBackColor = true;
			this.lblPowersUrbosaInfo.AutoSize = true;
			this.lblPowersUrbosaInfo.Location = new Point(294, 66);
			this.lblPowersUrbosaInfo.Name = "lblPowersUrbosaInfo";
			this.lblPowersUrbosaInfo.Size = new Size(75, 13);
			this.lblPowersUrbosaInfo.TabIndex = 29;
			this.lblPowersUrbosaInfo.Text = "<informations>";
			this.chkPowersUrbosaSet.AutoSize = true;
			this.chkPowersUrbosaSet.Location = new Point(132, 65);
			this.chkPowersUrbosaSet.Name = "chkPowersUrbosaSet";
			this.chkPowersUrbosaSet.Size = new Size(90, 17);
			this.chkPowersUrbosaSet.TabIndex = 28;
			this.chkPowersUrbosaSet.Text = "Urbosa's Fury";
			this.chkPowersUrbosaSet.UseVisualStyleBackColor = true;
			this.txtPowersUrbosaHotKey.Location = new Point(64, 63);
			this.txtPowersUrbosaHotKey.Name = "txtPowersUrbosaHotKey";
			this.txtPowersUrbosaHotKey.ReadOnly = true;
			this.txtPowersUrbosaHotKey.Size = new Size(62, 20);
			this.txtPowersUrbosaHotKey.TabIndex = 27;
			this.chkPowersUrbosaUseHotkey.AutoSize = true;
			this.chkPowersUrbosaUseHotkey.Location = new Point(6, 65);
			this.chkPowersUrbosaUseHotkey.Name = "chkPowersUrbosaUseHotkey";
			this.chkPowersUrbosaUseHotkey.Size = new Size(61, 17);
			this.chkPowersUrbosaUseHotkey.TabIndex = 26;
			this.chkPowersUrbosaUseHotkey.Text = "HotKey";
			this.chkPowersUrbosaUseHotkey.UseVisualStyleBackColor = true;
			this.lblPowersRevaliInfo.AutoSize = true;
			this.lblPowersRevaliInfo.Location = new Point(294, 43);
			this.lblPowersRevaliInfo.Name = "lblPowersRevaliInfo";
			this.lblPowersRevaliInfo.Size = new Size(75, 13);
			this.lblPowersRevaliInfo.TabIndex = 25;
			this.lblPowersRevaliInfo.Text = "<informations>";
			this.chkPowersRevaliSet.AutoSize = true;
			this.chkPowersRevaliSet.Location = new Point(132, 42);
			this.chkPowersRevaliSet.Name = "chkPowersRevaliSet";
			this.chkPowersRevaliSet.Size = new Size(88, 17);
			this.chkPowersRevaliSet.TabIndex = 24;
			this.chkPowersRevaliSet.Text = "Revali's Gale";
			this.chkPowersRevaliSet.UseVisualStyleBackColor = true;
			this.txtPowersRevaliHotKey.Location = new Point(64, 40);
			this.txtPowersRevaliHotKey.Name = "txtPowersRevaliHotKey";
			this.txtPowersRevaliHotKey.ReadOnly = true;
			this.txtPowersRevaliHotKey.Size = new Size(62, 20);
			this.txtPowersRevaliHotKey.TabIndex = 23;
			this.chkPowersRevaliUseHotkey.AutoSize = true;
			this.chkPowersRevaliUseHotkey.Location = new Point(6, 42);
			this.chkPowersRevaliUseHotkey.Name = "chkPowersRevaliUseHotkey";
			this.chkPowersRevaliUseHotkey.Size = new Size(61, 17);
			this.chkPowersRevaliUseHotkey.TabIndex = 22;
			this.chkPowersRevaliUseHotkey.Text = "HotKey";
			this.chkPowersRevaliUseHotkey.UseVisualStyleBackColor = true;
			this.lblPowersMiphaInfo.AutoSize = true;
			this.lblPowersMiphaInfo.Location = new Point(294, 20);
			this.lblPowersMiphaInfo.Name = "lblPowersMiphaInfo";
			this.lblPowersMiphaInfo.Size = new Size(75, 13);
			this.lblPowersMiphaInfo.TabIndex = 21;
			this.lblPowersMiphaInfo.Text = "<informations>";
			this.chkPowersMiphaSet.AutoSize = true;
			this.chkPowersMiphaSet.Location = new Point(132, 19);
			this.chkPowersMiphaSet.Name = "chkPowersMiphaSet";
			this.chkPowersMiphaSet.Size = new Size(94, 17);
			this.chkPowersMiphaSet.TabIndex = 20;
			this.chkPowersMiphaSet.Text = "Mipha's Grace";
			this.chkPowersMiphaSet.UseVisualStyleBackColor = true;
			this.txtPowersMiphaHotKey.Location = new Point(64, 17);
			this.txtPowersMiphaHotKey.Name = "txtPowersMiphaHotKey";
			this.txtPowersMiphaHotKey.ReadOnly = true;
			this.txtPowersMiphaHotKey.Size = new Size(62, 20);
			this.txtPowersMiphaHotKey.TabIndex = 19;
			this.chkPowersMiphaUseHotkey.AutoSize = true;
			this.chkPowersMiphaUseHotkey.Location = new Point(6, 19);
			this.chkPowersMiphaUseHotkey.Name = "chkPowersMiphaUseHotkey";
			this.chkPowersMiphaUseHotkey.Size = new Size(61, 17);
			this.chkPowersMiphaUseHotkey.TabIndex = 0;
			this.chkPowersMiphaUseHotkey.Text = "HotKey";
			this.chkPowersMiphaUseHotkey.UseVisualStyleBackColor = true;
			this.tabPage19.Controls.Add(this.groupBox4);
			this.tabPage19.Controls.Add(this.groupBox15);
			this.tabPage19.Location = new Point(4, 22);
			this.tabPage19.Name = "tabPage19";
			this.tabPage19.Padding = new Padding(3);
			this.tabPage19.Size = new Size(499, 241);
			this.tabPage19.TabIndex = 7;
			this.tabPage19.Text = "Amiibo / Speed";
			this.tabPage19.UseVisualStyleBackColor = true;
			this.groupBox4.Controls.Add(this.btnRunSpeedDefault);
			this.groupBox4.Controls.Add(this.txtRunSpeedDefaultHotKey);
			this.groupBox4.Controls.Add(this.chkRunSpeedDefaultUseHotkey);
			this.groupBox4.Controls.Add(this.btnRunSpeedDown);
			this.groupBox4.Controls.Add(this.txtRunSpeedDownHotKey);
			this.groupBox4.Controls.Add(this.chkRunSpeedDownUseHotkey);
			this.groupBox4.Controls.Add(this.btnRunSpeedUp);
			this.groupBox4.Controls.Add(this.txtRunSpeedUpHotKey);
			this.groupBox4.Controls.Add(this.chkRunSpeedUpUseHotkey);
			this.groupBox4.Controls.Add(this.btnRunSpeedUpdate);
			this.groupBox4.Controls.Add(this.label49);
			this.groupBox4.Controls.Add(this.txtRunSpeed);
			this.groupBox4.Location = new Point(6, 58);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new Size(487, 136);
			this.groupBox4.TabIndex = 33;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Run speed";
			this.btnRunSpeedDefault.Location = new Point(132, 98);
			this.btnRunSpeedDefault.Name = "btnRunSpeedDefault";
			this.btnRunSpeedDefault.Size = new Size(91, 23);
			this.btnRunSpeedDefault.TabIndex = 30;
			this.btnRunSpeedDefault.Text = "Default Speed";
			this.btnRunSpeedDefault.UseVisualStyleBackColor = true;
			this.btnRunSpeedDefault.Click += new EventHandler(this.btnRunSpeedDefault_Click);
			this.txtRunSpeedDefaultHotKey.Location = new Point(64, 100);
			this.txtRunSpeedDefaultHotKey.Name = "txtRunSpeedDefaultHotKey";
			this.txtRunSpeedDefaultHotKey.ReadOnly = true;
			this.txtRunSpeedDefaultHotKey.Size = new Size(62, 20);
			this.txtRunSpeedDefaultHotKey.TabIndex = 29;
			this.chkRunSpeedDefaultUseHotkey.AutoSize = true;
			this.chkRunSpeedDefaultUseHotkey.Location = new Point(6, 102);
			this.chkRunSpeedDefaultUseHotkey.Name = "chkRunSpeedDefaultUseHotkey";
			this.chkRunSpeedDefaultUseHotkey.Size = new Size(61, 17);
			this.chkRunSpeedDefaultUseHotkey.TabIndex = 28;
			this.chkRunSpeedDefaultUseHotkey.Text = "HotKey";
			this.chkRunSpeedDefaultUseHotkey.UseVisualStyleBackColor = true;
			this.btnRunSpeedDown.Location = new Point(132, 69);
			this.btnRunSpeedDown.Name = "btnRunSpeedDown";
			this.btnRunSpeedDown.Size = new Size(91, 23);
			this.btnRunSpeedDown.TabIndex = 27;
			this.btnRunSpeedDown.Text = "Speed Down";
			this.btnRunSpeedDown.UseVisualStyleBackColor = true;
			this.btnRunSpeedDown.Click += new EventHandler(this.btnRunSpeedDown_Click);
			this.txtRunSpeedDownHotKey.Location = new Point(64, 71);
			this.txtRunSpeedDownHotKey.Name = "txtRunSpeedDownHotKey";
			this.txtRunSpeedDownHotKey.ReadOnly = true;
			this.txtRunSpeedDownHotKey.Size = new Size(62, 20);
			this.txtRunSpeedDownHotKey.TabIndex = 26;
			this.chkRunSpeedDownUseHotkey.AutoSize = true;
			this.chkRunSpeedDownUseHotkey.Location = new Point(6, 73);
			this.chkRunSpeedDownUseHotkey.Name = "chkRunSpeedDownUseHotkey";
			this.chkRunSpeedDownUseHotkey.Size = new Size(61, 17);
			this.chkRunSpeedDownUseHotkey.TabIndex = 25;
			this.chkRunSpeedDownUseHotkey.Text = "HotKey";
			this.chkRunSpeedDownUseHotkey.UseVisualStyleBackColor = true;
			this.btnRunSpeedUp.Location = new Point(132, 41);
			this.btnRunSpeedUp.Name = "btnRunSpeedUp";
			this.btnRunSpeedUp.Size = new Size(91, 23);
			this.btnRunSpeedUp.TabIndex = 24;
			this.btnRunSpeedUp.Text = "Speed Up";
			this.btnRunSpeedUp.UseVisualStyleBackColor = true;
			this.btnRunSpeedUp.Click += new EventHandler(this.btnRunSpeedUp_Click);
			this.txtRunSpeedUpHotKey.Location = new Point(64, 43);
			this.txtRunSpeedUpHotKey.Name = "txtRunSpeedUpHotKey";
			this.txtRunSpeedUpHotKey.ReadOnly = true;
			this.txtRunSpeedUpHotKey.Size = new Size(62, 20);
			this.txtRunSpeedUpHotKey.TabIndex = 23;
			this.chkRunSpeedUpUseHotkey.AutoSize = true;
			this.chkRunSpeedUpUseHotkey.Location = new Point(6, 45);
			this.chkRunSpeedUpUseHotkey.Name = "chkRunSpeedUpUseHotkey";
			this.chkRunSpeedUpUseHotkey.Size = new Size(61, 17);
			this.chkRunSpeedUpUseHotkey.TabIndex = 22;
			this.chkRunSpeedUpUseHotkey.Text = "HotKey";
			this.chkRunSpeedUpUseHotkey.UseVisualStyleBackColor = true;
			this.btnRunSpeedUpdate.Location = new Point(132, 13);
			this.btnRunSpeedUpdate.Name = "btnRunSpeedUpdate";
			this.btnRunSpeedUpdate.Size = new Size(91, 23);
			this.btnRunSpeedUpdate.TabIndex = 11;
			this.btnRunSpeedUpdate.Text = "Update";
			this.btnRunSpeedUpdate.UseVisualStyleBackColor = true;
			this.btnRunSpeedUpdate.Click += new EventHandler(this.btnRunSpeedUpdate_Click);
			this.label49.AutoSize = true;
			this.label49.Location = new Point(3, 20);
			this.label49.Name = "label49";
			this.label49.Size = new Size(48, 13);
			this.label49.TabIndex = 3;
			this.label49.Text = "Multiplier";
			this.txtRunSpeed.Location = new Point(64, 16);
			this.txtRunSpeed.Name = "txtRunSpeed";
			this.txtRunSpeed.Size = new Size(62, 20);
			this.txtRunSpeed.TabIndex = 2;
			this.groupBox15.Controls.Add(this.lblUnlimitAmiiboInfo);
			this.groupBox15.Controls.Add(this.chkUnlimitAmiiboSet);
			this.groupBox15.Controls.Add(this.txtUnlimitAmiiboHotKey);
			this.groupBox15.Controls.Add(this.chkUnlimitAmiiboUseHotkey);
			this.groupBox15.Location = new Point(6, 6);
			this.groupBox15.Name = "groupBox15";
			this.groupBox15.Size = new Size(487, 46);
			this.groupBox15.TabIndex = 32;
			this.groupBox15.TabStop = false;
			this.groupBox15.Text = "Unlimit Amiibo";
			this.lblUnlimitAmiiboInfo.AutoSize = true;
			this.lblUnlimitAmiiboInfo.Location = new Point(294, 20);
			this.lblUnlimitAmiiboInfo.Name = "lblUnlimitAmiiboInfo";
			this.lblUnlimitAmiiboInfo.Size = new Size(75, 13);
			this.lblUnlimitAmiiboInfo.TabIndex = 21;
			this.lblUnlimitAmiiboInfo.Text = "<informations>";
			this.chkUnlimitAmiiboSet.AutoSize = true;
			this.chkUnlimitAmiiboSet.Location = new Point(132, 19);
			this.chkUnlimitAmiiboSet.Name = "chkUnlimitAmiiboSet";
			this.chkUnlimitAmiiboSet.Size = new Size(91, 17);
			this.chkUnlimitAmiiboSet.TabIndex = 20;
			this.chkUnlimitAmiiboSet.Text = "Unlimit Amiibo";
			this.chkUnlimitAmiiboSet.UseVisualStyleBackColor = true;
			this.txtUnlimitAmiiboHotKey.Location = new Point(64, 17);
			this.txtUnlimitAmiiboHotKey.Name = "txtUnlimitAmiiboHotKey";
			this.txtUnlimitAmiiboHotKey.ReadOnly = true;
			this.txtUnlimitAmiiboHotKey.Size = new Size(62, 20);
			this.txtUnlimitAmiiboHotKey.TabIndex = 19;
			this.chkUnlimitAmiiboUseHotkey.AutoSize = true;
			this.chkUnlimitAmiiboUseHotkey.Location = new Point(6, 19);
			this.chkUnlimitAmiiboUseHotkey.Name = "chkUnlimitAmiiboUseHotkey";
			this.chkUnlimitAmiiboUseHotkey.Size = new Size(61, 17);
			this.chkUnlimitAmiiboUseHotkey.TabIndex = 0;
			this.chkUnlimitAmiiboUseHotkey.Text = "HotKey";
			this.chkUnlimitAmiiboUseHotkey.UseVisualStyleBackColor = true;
			this.tabPage13.Controls.Add(this.gbActionsFilter);
			this.tabPage13.Controls.Add(this.gbActionsSettings);
			this.tabPage13.Controls.Add(this.groupBox9);
			this.tabPage13.Location = new Point(4, 22);
			this.tabPage13.Name = "tabPage13";
			this.tabPage13.Padding = new Padding(3);
			this.tabPage13.Size = new Size(499, 241);
			this.tabPage13.TabIndex = 0;
			this.tabPage13.Text = "Custom";
			this.tabPage13.UseVisualStyleBackColor = true;
			this.gbActionsFilter.Controls.Add(this.lstActionsFilter);
			this.gbActionsFilter.Controls.Add(this.optionActionsFilterList);
			this.gbActionsFilter.Controls.Add(this.optionActionsNoFilter);
			this.gbActionsFilter.Enabled = false;
			this.gbActionsFilter.Location = new Point(317, 6);
			this.gbActionsFilter.Name = "gbActionsFilter";
			this.gbActionsFilter.Size = new Size(176, 230);
			this.gbActionsFilter.TabIndex = 27;
			this.gbActionsFilter.TabStop = false;
			this.gbActionsFilter.Text = "Filter";
			this.lstActionsFilter.FormattingEnabled = true;
			this.lstActionsFilter.Location = new Point(8, 71);
			this.lstActionsFilter.Name = "lstActionsFilter";
			this.lstActionsFilter.Size = new Size(162, 147);
			this.lstActionsFilter.TabIndex = 2;
			this.optionActionsFilterList.AutoSize = true;
			this.optionActionsFilterList.Location = new Point(8, 42);
			this.optionActionsFilterList.Name = "optionActionsFilterList";
			this.optionActionsFilterList.Size = new Size(138, 17);
			this.optionActionsFilterList.TabIndex = 1;
			this.optionActionsFilterList.Text = "Apply only to items in list";
			this.optionActionsFilterList.UseVisualStyleBackColor = true;
			this.optionActionsNoFilter.AutoSize = true;
			this.optionActionsNoFilter.Checked = true;
			this.optionActionsNoFilter.Location = new Point(8, 19);
			this.optionActionsNoFilter.Name = "optionActionsNoFilter";
			this.optionActionsNoFilter.Size = new Size(61, 17);
			this.optionActionsNoFilter.TabIndex = 0;
			this.optionActionsNoFilter.TabStop = true;
			this.optionActionsNoFilter.Text = "No filter";
			this.optionActionsNoFilter.UseVisualStyleBackColor = true;
			this.gbActionsSettings.Controls.Add(this.chkActionsUseHotkey);
			this.gbActionsSettings.Controls.Add(this.txtActionsHotKey);
			this.gbActionsSettings.Controls.Add(this.chkActionsDisableWhenDone);
			this.gbActionsSettings.Controls.Add(this.cbActionsList);
			this.gbActionsSettings.Controls.Add(this.chkActionsActiveInactive);
			this.gbActionsSettings.Controls.Add(this.txtActionsMax);
			this.gbActionsSettings.Controls.Add(this.label41);
			this.gbActionsSettings.Controls.Add(this.txtActionsQuantity);
			this.gbActionsSettings.Controls.Add(this.label42);
			this.gbActionsSettings.Controls.Add(this.txtActionsTimer);
			this.gbActionsSettings.Controls.Add(this.label43);
			this.gbActionsSettings.Controls.Add(this.txtActionsFixed);
			this.gbActionsSettings.Controls.Add(this.optionActionsTimer);
			this.gbActionsSettings.Controls.Add(this.optionActionsFixed);
			this.gbActionsSettings.Enabled = false;
			this.gbActionsSettings.Location = new Point(141, 6);
			this.gbActionsSettings.Name = "gbActionsSettings";
			this.gbActionsSettings.Size = new Size(166, 230);
			this.gbActionsSettings.TabIndex = 23;
			this.gbActionsSettings.TabStop = false;
			this.gbActionsSettings.Text = "Settings";
			this.chkActionsUseHotkey.AutoSize = true;
			this.chkActionsUseHotkey.Location = new Point(6, 180);
			this.chkActionsUseHotkey.Name = "chkActionsUseHotkey";
			this.chkActionsUseHotkey.Size = new Size(60, 17);
			this.chkActionsUseHotkey.TabIndex = 19;
			this.chkActionsUseHotkey.Text = "Hotkey";
			this.chkActionsUseHotkey.UseVisualStyleBackColor = true;
			this.txtActionsHotKey.Location = new Point(95, 176);
			this.txtActionsHotKey.Name = "txtActionsHotKey";
			this.txtActionsHotKey.ReadOnly = true;
			this.txtActionsHotKey.Size = new Size(62, 20);
			this.txtActionsHotKey.TabIndex = 18;
			this.chkActionsDisableWhenDone.AutoSize = true;
			this.chkActionsDisableWhenDone.Location = new Point(6, 160);
			this.chkActionsDisableWhenDone.Name = "chkActionsDisableWhenDone";
			this.chkActionsDisableWhenDone.Size = new Size(104, 17);
			this.chkActionsDisableWhenDone.TabIndex = 17;
			this.chkActionsDisableWhenDone.Text = "Stop when done";
			this.chkActionsDisableWhenDone.UseVisualStyleBackColor = true;
			this.cbActionsList.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cbActionsList.FormattingEnabled = true;
			this.cbActionsList.Location = new Point(6, 19);
			this.cbActionsList.Name = "cbActionsList";
			this.cbActionsList.Size = new Size(151, 21);
			this.cbActionsList.TabIndex = 16;
			this.chkActionsActiveInactive.AutoSize = true;
			this.chkActionsActiveInactive.Location = new Point(6, 209);
			this.chkActionsActiveInactive.Name = "chkActionsActiveInactive";
			this.chkActionsActiveInactive.Size = new Size(105, 17);
			this.chkActionsActiveInactive.TabIndex = 15;
			this.chkActionsActiveInactive.Text = "Active / Inactive";
			this.chkActionsActiveInactive.UseVisualStyleBackColor = true;
			this.txtActionsMax.Location = new Point(95, 136);
			this.txtActionsMax.Name = "txtActionsMax";
			this.txtActionsMax.Size = new Size(62, 20);
			this.txtActionsMax.TabIndex = 13;
			this.label41.AutoSize = true;
			this.label41.Location = new Point(22, 139);
			this.label41.Name = "label41";
			this.label41.Size = new Size(27, 13);
			this.label41.TabIndex = 14;
			this.label41.Text = "Max";
			this.txtActionsQuantity.Location = new Point(95, 116);
			this.txtActionsQuantity.Name = "txtActionsQuantity";
			this.txtActionsQuantity.Size = new Size(62, 20);
			this.txtActionsQuantity.TabIndex = 11;
			this.label42.AutoSize = true;
			this.label42.Location = new Point(22, 119);
			this.label42.Name = "label42";
			this.label42.Size = new Size(46, 13);
			this.label42.TabIndex = 12;
			this.label42.Text = "Quantity";
			this.txtActionsTimer.Location = new Point(95, 96);
			this.txtActionsTimer.Name = "txtActionsTimer";
			this.txtActionsTimer.Size = new Size(62, 20);
			this.txtActionsTimer.TabIndex = 9;
			this.label43.AutoSize = true;
			this.label43.Location = new Point(22, 99);
			this.label43.Name = "label43";
			this.label43.Size = new Size(59, 13);
			this.label43.TabIndex = 10;
			this.label43.Text = "Timer (sec)";
			this.txtActionsFixed.Location = new Point(95, 51);
			this.txtActionsFixed.Name = "txtActionsFixed";
			this.txtActionsFixed.Size = new Size(62, 20);
			this.txtActionsFixed.TabIndex = 7;
			this.optionActionsTimer.AutoSize = true;
			this.optionActionsTimer.Checked = true;
			this.optionActionsTimer.Location = new Point(6, 75);
			this.optionActionsTimer.Name = "optionActionsTimer";
			this.optionActionsTimer.Size = new Size(83, 17);
			this.optionActionsTimer.TabIndex = 1;
			this.optionActionsTimer.TabStop = true;
			this.optionActionsTimer.Text = "Timer based";
			this.optionActionsTimer.UseVisualStyleBackColor = true;
			this.optionActionsFixed.AutoSize = true;
			this.optionActionsFixed.Location = new Point(6, 52);
			this.optionActionsFixed.Name = "optionActionsFixed";
			this.optionActionsFixed.Size = new Size(50, 17);
			this.optionActionsFixed.TabIndex = 0;
			this.optionActionsFixed.Text = "Fixed";
			this.optionActionsFixed.UseVisualStyleBackColor = true;
			this.groupBox9.Controls.Add(this.btnActionsRemove);
			this.groupBox9.Controls.Add(this.lstActionsRegistered);
			this.groupBox9.Controls.Add(this.btnActionsNew);
			this.groupBox9.Location = new Point(6, 6);
			this.groupBox9.Name = "groupBox9";
			this.groupBox9.Size = new Size(129, 230);
			this.groupBox9.TabIndex = 0;
			this.groupBox9.TabStop = false;
			this.groupBox9.Text = "Registered";
			this.btnActionsRemove.Location = new Point(9, 197);
			this.btnActionsRemove.Name = "btnActionsRemove";
			this.btnActionsRemove.Size = new Size(114, 23);
			this.btnActionsRemove.TabIndex = 30;
			this.btnActionsRemove.Text = "Remove";
			this.btnActionsRemove.UseVisualStyleBackColor = true;
			this.lstActionsRegistered.FormattingEnabled = true;
			this.lstActionsRegistered.Location = new Point(9, 19);
			this.lstActionsRegistered.Name = "lstActionsRegistered";
			this.lstActionsRegistered.Size = new Size(114, 147);
			this.lstActionsRegistered.TabIndex = 0;
			this.btnActionsNew.Location = new Point(9, 172);
			this.btnActionsNew.Name = "btnActionsNew";
			this.btnActionsNew.Size = new Size(114, 23);
			this.btnActionsNew.TabIndex = 28;
			this.btnActionsNew.Text = "New";
			this.btnActionsNew.UseVisualStyleBackColor = true;
			this.tabControl2.Controls.Add(this.tabPage10);
			this.tabControl2.Controls.Add(this.tabPage22);
			this.tabControl2.Location = new Point(12, 310);
			this.tabControl2.Name = "tabControl2";
			this.tabControl2.SelectedIndex = 0;
			this.tabControl2.Size = new Size(484, 173);
			this.tabControl2.TabIndex = 6;
			this.tabPage10.Controls.Add(this.groupBox5);
			this.tabPage10.Controls.Add(this.groupBox2);
			this.tabPage10.Controls.Add(this.groupBox1);
			this.tabPage10.Controls.Add(this.groupBox12);
			this.tabPage10.Controls.Add(this.groupBox11);
			this.tabPage10.Location = new Point(4, 22);
			this.tabPage10.Name = "tabPage10";
			this.tabPage10.Padding = new Padding(3);
			this.tabPage10.Size = new Size(476, 147);
			this.tabPage10.TabIndex = 0;
			this.tabPage10.Text = "Status && Settings";
			this.tabPage10.UseVisualStyleBackColor = true;
			this.groupBox5.Controls.Add(this.label55);
			this.groupBox5.Controls.Add(this.label53);
			this.groupBox5.Controls.Add(this.numSpacingMs);
			this.groupBox5.Controls.Add(this.numInternalLoopMs);
			this.groupBox5.Location = new Point(193, 7);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new Size(100, 135);
			this.groupBox5.TabIndex = 26;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Timings";
			this.label55.AutoSize = true;
			this.label55.Location = new Point(9, 77);
			this.label55.Name = "label55";
			this.label55.Size = new Size(68, 13);
			this.label55.TabIndex = 3;
			this.label55.Text = "Spacing (ms)";
			this.label53.AutoSize = true;
			this.label53.Location = new Point(9, 18);
			this.label53.Name = "label53";
			this.label53.Size = new Size(87, 13);
			this.label53.TabIndex = 2;
			this.label53.Text = "Internal loop (ms)";
			this.numSpacingMs.Location = new Point(12, 93);
			NumericUpDown arg_BCE7_0 = this.numSpacingMs;
			int[] expr_BCDA = new int[4];
			expr_BCDA[0] = 1000;
			arg_BCE7_0.Maximum = new decimal(expr_BCDA);
			this.numSpacingMs.Name = "numSpacingMs";
			this.numSpacingMs.Size = new Size(65, 20);
			this.numSpacingMs.TabIndex = 1;
			this.numSpacingMs.ValueChanged += new EventHandler(this.numSpacingMs_ValueChanged);
			this.numInternalLoopMs.Location = new Point(12, 34);
			NumericUpDown arg_BD60_0 = this.numInternalLoopMs;
			int[] expr_BD53 = new int[4];
			expr_BD53[0] = 1000;
			arg_BD60_0.Maximum = new decimal(expr_BD53);
			this.numInternalLoopMs.Name = "numInternalLoopMs";
			this.numInternalLoopMs.Size = new Size(65, 20);
			this.numInternalLoopMs.TabIndex = 0;
			NumericUpDown arg_BDAB_0 = this.numInternalLoopMs;
			int[] expr_BDA1 = new int[4];
			expr_BDA1[0] = 100;
			arg_BDAB_0.Value = new decimal(expr_BDA1);
			this.numInternalLoopMs.ValueChanged += new EventHandler(this.numInternalLoopMs_ValueChanged);
			this.groupBox2.Controls.Add(this.btnGameProcessResume);
			this.groupBox2.Controls.Add(this.btnGameProcessPause);
			this.groupBox2.Location = new Point(299, 94);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new Size(171, 48);
			this.groupBox2.TabIndex = 25;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Game Process";
			this.btnGameProcessResume.Location = new Point(85, 18);
			this.btnGameProcessResume.Name = "btnGameProcessResume";
			this.btnGameProcessResume.Size = new Size(75, 23);
			this.btnGameProcessResume.TabIndex = 2;
			this.btnGameProcessResume.Text = "Resume";
			this.btnGameProcessResume.UseVisualStyleBackColor = true;
			this.btnGameProcessResume.Click += new EventHandler(this.btnGameProcessResume_Click);
			this.btnGameProcessPause.Location = new Point(7, 18);
			this.btnGameProcessPause.Name = "btnGameProcessPause";
			this.btnGameProcessPause.Size = new Size(75, 23);
			this.btnGameProcessPause.TabIndex = 1;
			this.btnGameProcessPause.Text = "Pause";
			this.btnGameProcessPause.UseVisualStyleBackColor = true;
			this.btnGameProcessPause.Click += new EventHandler(this.btnGameProcessPause_Click);
			this.groupBox1.Controls.Add(this.btnSettingsImport);
			this.groupBox1.Controls.Add(this.btnSettingsExport);
			this.groupBox1.Controls.Add(this.btnSettingsClear);
			this.groupBox1.Controls.Add(this.btnSettingsSave);
			this.groupBox1.Location = new Point(299, 6);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new Size(171, 82);
			this.groupBox1.TabIndex = 24;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Settings";
			this.btnSettingsImport.Location = new Point(88, 48);
			this.btnSettingsImport.Name = "btnSettingsImport";
			this.btnSettingsImport.Size = new Size(75, 23);
			this.btnSettingsImport.TabIndex = 3;
			this.btnSettingsImport.Text = "Import";
			this.btnSettingsImport.UseVisualStyleBackColor = true;
			this.btnSettingsImport.Click += new EventHandler(this.btnSettingsImport_Click);
			this.btnSettingsExport.Location = new Point(88, 19);
			this.btnSettingsExport.Name = "btnSettingsExport";
			this.btnSettingsExport.Size = new Size(75, 23);
			this.btnSettingsExport.TabIndex = 2;
			this.btnSettingsExport.Text = "Export";
			this.btnSettingsExport.UseVisualStyleBackColor = true;
			this.btnSettingsExport.Click += new EventHandler(this.btnSettingsExport_Click);
			this.btnSettingsClear.Location = new Point(7, 48);
			this.btnSettingsClear.Name = "btnSettingsClear";
			this.btnSettingsClear.Size = new Size(75, 23);
			this.btnSettingsClear.TabIndex = 1;
			this.btnSettingsClear.Text = "Clear";
			this.btnSettingsClear.UseVisualStyleBackColor = true;
			this.btnSettingsClear.Click += new EventHandler(this.btnSettingsClear_Click);
			this.btnSettingsSave.Location = new Point(7, 19);
			this.btnSettingsSave.Name = "btnSettingsSave";
			this.btnSettingsSave.Size = new Size(75, 23);
			this.btnSettingsSave.TabIndex = 0;
			this.btnSettingsSave.Text = "Save";
			this.btnSettingsSave.UseVisualStyleBackColor = true;
			this.btnSettingsSave.Click += new EventHandler(this.btnSettingsSave_Click);
			this.groupBox12.Controls.Add(this.chkUpdateList);
			this.groupBox12.Controls.Add(this.txtTimerUpdateList);
			this.groupBox12.Controls.Add(this.label45);
			this.groupBox12.Location = new Point(6, 84);
			this.groupBox12.Name = "groupBox12";
			this.groupBox12.Size = new Size(179, 58);
			this.groupBox12.TabIndex = 23;
			this.groupBox12.TabStop = false;
			this.groupBox12.Text = "Update list from memory";
			this.chkUpdateList.AutoSize = true;
			this.chkUpdateList.Location = new Point(15, 35);
			this.chkUpdateList.Name = "chkUpdateList";
			this.chkUpdateList.Size = new Size(101, 17);
			this.chkUpdateList.TabIndex = 6;
			this.chkUpdateList.Text = "Activate update";
			this.chkUpdateList.UseVisualStyleBackColor = true;
			this.txtTimerUpdateList.Location = new Point(84, 13);
			this.txtTimerUpdateList.Name = "txtTimerUpdateList";
			this.txtTimerUpdateList.Size = new Size(44, 20);
			this.txtTimerUpdateList.TabIndex = 6;
			this.txtTimerUpdateList.Text = "15";
			this.label45.AutoSize = true;
			this.label45.Location = new Point(6, 16);
			this.label45.Name = "label45";
			this.label45.Size = new Size(59, 13);
			this.label45.TabIndex = 6;
			this.label45.Text = "Timer (sec)";
			this.groupBox11.Controls.Add(this.lstEquippedWeapons);
			this.groupBox11.Location = new Point(7, 6);
			this.groupBox11.Name = "groupBox11";
			this.groupBox11.Size = new Size(180, 72);
			this.groupBox11.TabIndex = 22;
			this.groupBox11.TabStop = false;
			this.groupBox11.Text = "Equipped Weapons";
			this.lstEquippedWeapons.FormattingEnabled = true;
			this.lstEquippedWeapons.Location = new Point(8, 21);
			this.lstEquippedWeapons.Name = "lstEquippedWeapons";
			this.lstEquippedWeapons.Size = new Size(166, 43);
			this.lstEquippedWeapons.TabIndex = 0;
			this.tabPage22.Controls.Add(this.btnRestoreStaminaBar);
			this.tabPage22.Controls.Add(this.btnNoStaminaBar);
			this.tabPage22.Controls.Add(this.btnCompareAddress);
			this.tabPage22.Controls.Add(this.label74);
			this.tabPage22.Controls.Add(this.txtCompareAddress);
			this.tabPage22.Controls.Add(this.trackTime);
			this.tabPage22.Controls.Add(this.btnMemoryRegions);
			this.tabPage22.Controls.Add(this.btntxtFindMemoryRegionBySize);
			this.tabPage22.Controls.Add(this.label73);
			this.tabPage22.Controls.Add(this.txtFindMemoryRegionBySize);
			this.tabPage22.Controls.Add(this.btnFindMemoryRegionByAddress);
			this.tabPage22.Controls.Add(this.label72);
			this.tabPage22.Controls.Add(this.txtFindMemoryRegionByAddress);
			this.tabPage22.Location = new Point(4, 22);
			this.tabPage22.Name = "tabPage22";
			this.tabPage22.Padding = new Padding(3);
			this.tabPage22.Size = new Size(476, 147);
			this.tabPage22.TabIndex = 1;
			this.tabPage22.Text = "Testing";
			this.tabPage22.UseVisualStyleBackColor = true;
			this.btntxtFindMemoryRegionBySize.Enabled = false;
			this.btntxtFindMemoryRegionBySize.Location = new Point(293, 29);
			this.btntxtFindMemoryRegionBySize.Name = "btntxtFindMemoryRegionBySize";
			this.btntxtFindMemoryRegionBySize.Size = new Size(66, 23);
			this.btntxtFindMemoryRegionBySize.TabIndex = 52;
			this.btntxtFindMemoryRegionBySize.Text = "Find";
			this.btntxtFindMemoryRegionBySize.UseVisualStyleBackColor = true;
			this.btntxtFindMemoryRegionBySize.Click += new EventHandler(this.btntxtFindMemoryRegionBySize_Click);
			this.label73.AutoSize = true;
			this.label73.Location = new Point(10, 34);
			this.label73.Name = "label73";
			this.label73.Size = new Size(141, 13);
			this.label73.TabIndex = 51;
			this.label73.Text = "Find Memory Region by Size";
			this.txtFindMemoryRegionBySize.Location = new Point(175, 31);
			this.txtFindMemoryRegionBySize.Name = "txtFindMemoryRegionBySize";
			this.txtFindMemoryRegionBySize.Size = new Size(112, 20);
			this.txtFindMemoryRegionBySize.TabIndex = 50;
			this.btnFindMemoryRegionByAddress.Enabled = false;
			this.btnFindMemoryRegionByAddress.Location = new Point(293, 7);
			this.btnFindMemoryRegionByAddress.Name = "btnFindMemoryRegionByAddress";
			this.btnFindMemoryRegionByAddress.Size = new Size(66, 23);
			this.btnFindMemoryRegionByAddress.TabIndex = 49;
			this.btnFindMemoryRegionByAddress.Text = "Find";
			this.btnFindMemoryRegionByAddress.UseVisualStyleBackColor = true;
			this.btnFindMemoryRegionByAddress.Click += new EventHandler(this.btnFindMemoryRegionByAddress_Click);
			this.label72.AutoSize = true;
			this.label72.Location = new Point(10, 12);
			this.label72.Name = "label72";
			this.label72.Size = new Size(159, 13);
			this.label72.TabIndex = 48;
			this.label72.Text = "Find Memory Region by Address";
			this.txtFindMemoryRegionByAddress.Location = new Point(175, 9);
			this.txtFindMemoryRegionByAddress.Name = "txtFindMemoryRegionByAddress";
			this.txtFindMemoryRegionByAddress.Size = new Size(112, 20);
			this.txtFindMemoryRegionByAddress.TabIndex = 47;
			this.label48.AutoSize = true;
			this.label48.Location = new Point(623, 9);
			this.label48.Name = "label48";
			this.label48.Size = new Size(378, 13);
			this.label48.TabIndex = 30;
			this.label48.Text = "You may need to run this program as Administrator for the memory scan to work";
			this.lblVersion.AutoSize = true;
			this.lblVersion.Location = new Point(923, 25);
			this.lblVersion.Name = "lblVersion";
			this.lblVersion.Size = new Size(41, 13);
			this.lblVersion.TabIndex = 31;
			this.lblVersion.Text = "version";
			this.button1.Location = new Point(271, 9);
			this.button1.Name = "button1";
			this.button1.Size = new Size(93, 23);
			this.button1.TabIndex = 32;
			this.button1.Text = "Dump Memory";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Visible = false;
			this.button1.Click += new EventHandler(this.button1_Click);
			this.button2.Location = new Point(370, 9);
			this.button2.Name = "button2";
			this.button2.Size = new Size(97, 23);
			this.button2.TabIndex = 33;
			this.button2.Text = "Compare Dump";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Visible = false;
			this.button2.Click += new EventHandler(this.button2_Click);
			this.button3.Location = new Point(473, 9);
			this.button3.Name = "button3";
			this.button3.Size = new Size(97, 23);
			this.button3.TabIndex = 34;
			this.button3.Text = "Generate Report";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Visible = false;
			this.button3.Click += new EventHandler(this.button3_Click);
			this.btnMemoryRegions.Enabled = false;
			this.btnMemoryRegions.Location = new Point(365, 9);
			this.btnMemoryRegions.Name = "btnMemoryRegions";
			this.btnMemoryRegions.Size = new Size(105, 23);
			this.btnMemoryRegions.TabIndex = 53;
			this.btnMemoryRegions.Text = "Memory Regions";
			this.btnMemoryRegions.UseVisualStyleBackColor = true;
			this.btnMemoryRegions.Click += new EventHandler(this.btnMemoryRegions_Click);
			this.trackTime.AutoSize = false;
			this.trackTime.Location = new Point(6, 121);
			this.trackTime.Maximum = 360;
			this.trackTime.Name = "trackTime";
			this.trackTime.Size = new Size(457, 20);
			this.trackTime.TabIndex = 54;
			this.trackTime.TickStyle = TickStyle.None;
			this.trackTime.ValueChanged += new EventHandler(this.trackTime_ValueChanged);
			this.btnCompareAddress.Enabled = false;
			this.btnCompareAddress.Location = new Point(293, 51);
			this.btnCompareAddress.Name = "btnCompareAddress";
			this.btnCompareAddress.Size = new Size(66, 23);
			this.btnCompareAddress.TabIndex = 57;
			this.btnCompareAddress.Text = "Comp";
			this.btnCompareAddress.UseVisualStyleBackColor = true;
			this.btnCompareAddress.Click += new EventHandler(this.btnCompareAddress_Click);
			this.label74.AutoSize = true;
			this.label74.Location = new Point(10, 56);
			this.label74.Name = "label74";
			this.label74.Size = new Size(145, 13);
			this.label74.TabIndex = 56;
			this.label74.Text = "Compare address with offsets";
			this.txtCompareAddress.Location = new Point(175, 53);
			this.txtCompareAddress.Name = "txtCompareAddress";
			this.txtCompareAddress.Size = new Size(112, 20);
			this.txtCompareAddress.TabIndex = 55;
			this.btnNoStaminaBar.Location = new Point(15, 92);
			this.btnNoStaminaBar.Name = "btnNoStaminaBar";
			this.btnNoStaminaBar.Size = new Size(96, 23);
			this.btnNoStaminaBar.TabIndex = 58;
			this.btnNoStaminaBar.Text = "No Stamina Bar";
			this.btnNoStaminaBar.UseVisualStyleBackColor = true;
			this.btnNoStaminaBar.Click += new EventHandler(this.btnNoStaminaBar_Click);
			this.btnRestoreStaminaBar.Location = new Point(119, 92);
			this.btnRestoreStaminaBar.Name = "btnRestoreStaminaBar";
			this.btnRestoreStaminaBar.Size = new Size(124, 23);
			this.btnRestoreStaminaBar.TabIndex = 59;
			this.btnRestoreStaminaBar.Text = "Restore Stamina Bar";
			this.btnRestoreStaminaBar.UseVisualStyleBackColor = true;
			this.btnRestoreStaminaBar.Click += new EventHandler(this.btnRestoreStaminaBar_Click);
			base.AutoScaleMode = AutoScaleMode.None;
			base.ClientSize = new Size(1017, 494);
			base.Controls.Add(this.button3);
			base.Controls.Add(this.button2);
			base.Controls.Add(this.button1);
			base.Controls.Add(this.lblVersion);
			base.Controls.Add(this.label48);
			base.Controls.Add(this.tabControl2);
			base.Controls.Add(this.tabActions);
			base.Controls.Add(this.lblScan);
			base.Controls.Add(this.tabItems);
			base.Controls.Add(this.tabMain);
			base.Controls.Add(this.btnScan);
			base.FormBorderStyle = FormBorderStyle.FixedSingle;
			base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.Name = "FrmMain";
			this.Text = "Cemu - Breath of the Wild Memory Editor - by LibreVR";
			base.FormClosing += new FormClosingEventHandler(this.FrmMain_FormClosing);
			this.tabMain.ResumeLayout(false);
			this.tabPage9.ResumeLayout(false);
			this.tabPage9.PerformLayout();
			this.tabItems.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.gbInventoryEdit.ResumeLayout(false);
			this.gbInventoryEdit.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			this.gbWeaponsEdit.ResumeLayout(false);
			this.gbWeaponsEdit.PerformLayout();
			this.tabPage3.ResumeLayout(false);
			this.gbArcheryEdit.ResumeLayout(false);
			this.gbArcheryEdit.PerformLayout();
			this.tabPage4.ResumeLayout(false);
			this.gbShieldsEdit.ResumeLayout(false);
			this.gbShieldsEdit.PerformLayout();
			this.tabPage5.ResumeLayout(false);
			this.gbArmorsEdit.ResumeLayout(false);
			this.gbArmorsEdit.PerformLayout();
			this.tabPage6.ResumeLayout(false);
			this.gbMaterialsEdit.ResumeLayout(false);
			this.gbMaterialsEdit.PerformLayout();
			this.tabPage7.ResumeLayout(false);
			this.gbFoodEdit.ResumeLayout(false);
			this.gbFoodEdit.PerformLayout();
			this.tabPage8.ResumeLayout(false);
			this.gbOtherEdit.ResumeLayout(false);
			this.gbOtherEdit.PerformLayout();
			this.tabPage12.ResumeLayout(false);
			this.gbRupees.ResumeLayout(false);
			this.gbRupees.PerformLayout();
			this.tabPage20.ResumeLayout(false);
			this.gbShieldsSlots.ResumeLayout(false);
			this.gbShieldsSlots.PerformLayout();
			this.gbBowsSlots.ResumeLayout(false);
			this.gbBowsSlots.PerformLayout();
			this.gbWeaponsSlots.ResumeLayout(false);
			this.gbWeaponsSlots.PerformLayout();
			this.tabActions.ResumeLayout(false);
			this.tabPage11.ResumeLayout(false);
			this.groupBox13.ResumeLayout(false);
			this.groupBox13.PerformLayout();
			this.groupBox10.ResumeLayout(false);
			this.groupBox10.PerformLayout();
			this.tabPage14.ResumeLayout(false);
			this.groupBox17.ResumeLayout(false);
			this.groupBox17.PerformLayout();
			this.groupBox18.ResumeLayout(false);
			this.groupBox18.PerformLayout();
			this.tabPage15.ResumeLayout(false);
			this.groupBox20.ResumeLayout(false);
			this.groupBox20.PerformLayout();
			this.groupBox21.ResumeLayout(false);
			this.groupBox21.PerformLayout();
			this.tabPage16.ResumeLayout(false);
			this.groupBox22.ResumeLayout(false);
			this.groupBox22.PerformLayout();
			this.groupBox23.ResumeLayout(false);
			this.groupBox23.PerformLayout();
			this.tabPage17.ResumeLayout(false);
			this.groupBox16.ResumeLayout(false);
			this.groupBox16.PerformLayout();
			this.groupBox14.ResumeLayout(false);
			this.groupBox14.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.tabPage21.ResumeLayout(false);
			this.groupBox6.ResumeLayout(false);
			this.groupBox6.PerformLayout();
			this.groupBox7.ResumeLayout(false);
			this.groupBox7.PerformLayout();
			this.tabPage18.ResumeLayout(false);
			this.groupBox19.ResumeLayout(false);
			this.groupBox19.PerformLayout();
			this.tabPage19.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.groupBox15.ResumeLayout(false);
			this.groupBox15.PerformLayout();
			this.tabPage13.ResumeLayout(false);
			this.gbActionsFilter.ResumeLayout(false);
			this.gbActionsFilter.PerformLayout();
			this.gbActionsSettings.ResumeLayout(false);
			this.gbActionsSettings.PerformLayout();
			this.groupBox9.ResumeLayout(false);
			this.tabControl2.ResumeLayout(false);
			this.tabPage10.ResumeLayout(false);
			this.groupBox5.ResumeLayout(false);
			this.groupBox5.PerformLayout();
			((ISupportInitialize)this.numSpacingMs).EndInit();
			((ISupportInitialize)this.numInternalLoopMs).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox12.ResumeLayout(false);
			this.groupBox12.PerformLayout();
			this.groupBox11.ResumeLayout(false);
			this.tabPage22.ResumeLayout(false);
			this.tabPage22.PerformLayout();
			((ISupportInitialize)this.trackTime).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
