namespace botw_editor
{
	// Token: 0x02000009 RID: 9
	public partial class FrmMain : global::System.Windows.Forms.Form
	{
		// Token: 0x060000C3 RID: 195 RVA: 0x0000E5A5 File Offset: 0x0000C7A5
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x0000E5C4 File Offset: 0x0000C7C4
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::botw_editor.FrmMain));
			this.tabMain = new global::System.Windows.Forms.TabControl();
			this.tabPage9 = new global::System.Windows.Forms.TabPage();
			this.txtLog = new global::System.Windows.Forms.TextBox();
			this.tabItems = new global::System.Windows.Forms.TabControl();
			this.tabPage1 = new global::System.Windows.Forms.TabPage();
			this.btnInventoryItemUnlock = new global::System.Windows.Forms.Button();
			this.gbInventoryEdit = new global::System.Windows.Forms.GroupBox();
			this.cbInventoryItemBonusType = new global::System.Windows.Forms.ComboBox();
			this.btnInventoryItemUpdate = new global::System.Windows.Forms.Button();
			this.label4 = new global::System.Windows.Forms.Label();
			this.txtInventoryItemBonusValue = new global::System.Windows.Forms.TextBox();
			this.label5 = new global::System.Windows.Forms.Label();
			this.txtInventoryItemBonusType = new global::System.Windows.Forms.TextBox();
			this.label3 = new global::System.Windows.Forms.Label();
			this.cbInventoryItemName = new global::System.Windows.Forms.ComboBox();
			this.label2 = new global::System.Windows.Forms.Label();
			this.txtInventoryItemQtDur = new global::System.Windows.Forms.TextBox();
			this.label1 = new global::System.Windows.Forms.Label();
			this.txtInventoryItemID = new global::System.Windows.Forms.TextBox();
			this.lstInventory = new global::System.Windows.Forms.ListBox();
			this.tabPage2 = new global::System.Windows.Forms.TabPage();
			this.btnWeaponsItemUnlock = new global::System.Windows.Forms.Button();
			this.gbWeaponsEdit = new global::System.Windows.Forms.GroupBox();
			this.cbWeaponsItemBonusType = new global::System.Windows.Forms.ComboBox();
			this.btnWeaponsItemUpdate = new global::System.Windows.Forms.Button();
			this.label6 = new global::System.Windows.Forms.Label();
			this.txtWeaponsItemBonusValue = new global::System.Windows.Forms.TextBox();
			this.label7 = new global::System.Windows.Forms.Label();
			this.txtWeaponsItemBonusType = new global::System.Windows.Forms.TextBox();
			this.label8 = new global::System.Windows.Forms.Label();
			this.cbWeaponsItemName = new global::System.Windows.Forms.ComboBox();
			this.label9 = new global::System.Windows.Forms.Label();
			this.txtWeaponsItemQtDur = new global::System.Windows.Forms.TextBox();
			this.label10 = new global::System.Windows.Forms.Label();
			this.txtWeaponsItemID = new global::System.Windows.Forms.TextBox();
			this.lstWeapons = new global::System.Windows.Forms.ListBox();
			this.tabPage3 = new global::System.Windows.Forms.TabPage();
			this.btnArcheryItemUnlock = new global::System.Windows.Forms.Button();
			this.gbArcheryEdit = new global::System.Windows.Forms.GroupBox();
			this.cbArcheryItemBonusType = new global::System.Windows.Forms.ComboBox();
			this.btnArcheryItemUpdate = new global::System.Windows.Forms.Button();
			this.label11 = new global::System.Windows.Forms.Label();
			this.txtArcheryItemBonusValue = new global::System.Windows.Forms.TextBox();
			this.label12 = new global::System.Windows.Forms.Label();
			this.txtArcheryItemBonusType = new global::System.Windows.Forms.TextBox();
			this.label13 = new global::System.Windows.Forms.Label();
			this.cbArcheryItemName = new global::System.Windows.Forms.ComboBox();
			this.label14 = new global::System.Windows.Forms.Label();
			this.txtArcheryItemQtDur = new global::System.Windows.Forms.TextBox();
			this.label15 = new global::System.Windows.Forms.Label();
			this.txtArcheryItemID = new global::System.Windows.Forms.TextBox();
			this.lstArchery = new global::System.Windows.Forms.ListBox();
			this.tabPage4 = new global::System.Windows.Forms.TabPage();
			this.btnShieldsItemUnlock = new global::System.Windows.Forms.Button();
			this.gbShieldsEdit = new global::System.Windows.Forms.GroupBox();
			this.cbShieldsItemBonusType = new global::System.Windows.Forms.ComboBox();
			this.btnShieldsItemUpdate = new global::System.Windows.Forms.Button();
			this.label16 = new global::System.Windows.Forms.Label();
			this.txtShieldsItemBonusValue = new global::System.Windows.Forms.TextBox();
			this.label17 = new global::System.Windows.Forms.Label();
			this.txtShieldsItemBonusType = new global::System.Windows.Forms.TextBox();
			this.label18 = new global::System.Windows.Forms.Label();
			this.cbShieldsItemName = new global::System.Windows.Forms.ComboBox();
			this.label19 = new global::System.Windows.Forms.Label();
			this.txtShieldsItemQtDur = new global::System.Windows.Forms.TextBox();
			this.label20 = new global::System.Windows.Forms.Label();
			this.txtShieldsItemID = new global::System.Windows.Forms.TextBox();
			this.lstShields = new global::System.Windows.Forms.ListBox();
			this.tabPage5 = new global::System.Windows.Forms.TabPage();
			this.btnArmorsItemUnlock = new global::System.Windows.Forms.Button();
			this.gbArmorsEdit = new global::System.Windows.Forms.GroupBox();
			this.cbArmorsItemBonusType = new global::System.Windows.Forms.ComboBox();
			this.btnArmorsItemUpdate = new global::System.Windows.Forms.Button();
			this.label21 = new global::System.Windows.Forms.Label();
			this.txtArmorsItemBonusValue = new global::System.Windows.Forms.TextBox();
			this.label22 = new global::System.Windows.Forms.Label();
			this.txtArmorsItemBonusType = new global::System.Windows.Forms.TextBox();
			this.label23 = new global::System.Windows.Forms.Label();
			this.cbArmorsItemName = new global::System.Windows.Forms.ComboBox();
			this.label24 = new global::System.Windows.Forms.Label();
			this.txtArmorsItemQtDur = new global::System.Windows.Forms.TextBox();
			this.label25 = new global::System.Windows.Forms.Label();
			this.txtArmorsItemID = new global::System.Windows.Forms.TextBox();
			this.lstArmors = new global::System.Windows.Forms.ListBox();
			this.tabPage6 = new global::System.Windows.Forms.TabPage();
			this.btnMaterialsItemUnlock = new global::System.Windows.Forms.Button();
			this.gbMaterialsEdit = new global::System.Windows.Forms.GroupBox();
			this.cbMaterialsItemBonusType = new global::System.Windows.Forms.ComboBox();
			this.btnMaterialsItemUpdate = new global::System.Windows.Forms.Button();
			this.label26 = new global::System.Windows.Forms.Label();
			this.txtMaterialsItemBonusValue = new global::System.Windows.Forms.TextBox();
			this.label27 = new global::System.Windows.Forms.Label();
			this.txtMaterialsItemBonusType = new global::System.Windows.Forms.TextBox();
			this.label28 = new global::System.Windows.Forms.Label();
			this.cbMaterialsItemName = new global::System.Windows.Forms.ComboBox();
			this.label29 = new global::System.Windows.Forms.Label();
			this.txtMaterialsItemQtDur = new global::System.Windows.Forms.TextBox();
			this.label30 = new global::System.Windows.Forms.Label();
			this.txtMaterialsItemID = new global::System.Windows.Forms.TextBox();
			this.lstMaterials = new global::System.Windows.Forms.ListBox();
			this.tabPage7 = new global::System.Windows.Forms.TabPage();
			this.btnFoodItemUnlock = new global::System.Windows.Forms.Button();
			this.gbFoodEdit = new global::System.Windows.Forms.GroupBox();
			this.cbFoodItemBonusType = new global::System.Windows.Forms.ComboBox();
			this.btnFoodItemUpdate = new global::System.Windows.Forms.Button();
			this.label31 = new global::System.Windows.Forms.Label();
			this.txtFoodItemBonusValue = new global::System.Windows.Forms.TextBox();
			this.label32 = new global::System.Windows.Forms.Label();
			this.txtFoodItemBonusType = new global::System.Windows.Forms.TextBox();
			this.label33 = new global::System.Windows.Forms.Label();
			this.cbFoodItemName = new global::System.Windows.Forms.ComboBox();
			this.label34 = new global::System.Windows.Forms.Label();
			this.txtFoodItemQtDur = new global::System.Windows.Forms.TextBox();
			this.label35 = new global::System.Windows.Forms.Label();
			this.txtFoodItemID = new global::System.Windows.Forms.TextBox();
			this.lstFood = new global::System.Windows.Forms.ListBox();
			this.tabPage8 = new global::System.Windows.Forms.TabPage();
			this.btnOtherItemUnlock = new global::System.Windows.Forms.Button();
			this.gbOtherEdit = new global::System.Windows.Forms.GroupBox();
			this.cbOtherItemBonusType = new global::System.Windows.Forms.ComboBox();
			this.btnOtherItemUpdate = new global::System.Windows.Forms.Button();
			this.label36 = new global::System.Windows.Forms.Label();
			this.txtOtherItemBonusValue = new global::System.Windows.Forms.TextBox();
			this.label37 = new global::System.Windows.Forms.Label();
			this.txtOtherItemBonusType = new global::System.Windows.Forms.TextBox();
			this.label38 = new global::System.Windows.Forms.Label();
			this.cbOtherItemName = new global::System.Windows.Forms.ComboBox();
			this.label39 = new global::System.Windows.Forms.Label();
			this.txtOtherItemQtDur = new global::System.Windows.Forms.TextBox();
			this.label40 = new global::System.Windows.Forms.Label();
			this.txtOtherItemID = new global::System.Windows.Forms.TextBox();
			this.lstOther = new global::System.Windows.Forms.ListBox();
			this.tabPage12 = new global::System.Windows.Forms.TabPage();
			this.gbRupees = new global::System.Windows.Forms.GroupBox();
			this.btnRefreshRupees = new global::System.Windows.Forms.Button();
			this.btnUpdateRupees = new global::System.Windows.Forms.Button();
			this.label71 = new global::System.Windows.Forms.Label();
			this.txtRupees = new global::System.Windows.Forms.TextBox();
			this.tabPage20 = new global::System.Windows.Forms.TabPage();
			this.gbShieldsSlots = new global::System.Windows.Forms.GroupBox();
			this.btnRefreshShieldsSlots = new global::System.Windows.Forms.Button();
			this.btnUpdateShieldsSlots = new global::System.Windows.Forms.Button();
			this.label52 = new global::System.Windows.Forms.Label();
			this.txtShieldsSlots = new global::System.Windows.Forms.TextBox();
			this.gbBowsSlots = new global::System.Windows.Forms.GroupBox();
			this.btnRefreshBowsSlots = new global::System.Windows.Forms.Button();
			this.btnUpdateBowsSlots = new global::System.Windows.Forms.Button();
			this.label51 = new global::System.Windows.Forms.Label();
			this.txtBowsSlots = new global::System.Windows.Forms.TextBox();
			this.gbWeaponsSlots = new global::System.Windows.Forms.GroupBox();
			this.btnRefreshWeaponsSlots = new global::System.Windows.Forms.Button();
			this.btnUpdateWeaponsSlots = new global::System.Windows.Forms.Button();
			this.label50 = new global::System.Windows.Forms.Label();
			this.txtWeaponsSlots = new global::System.Windows.Forms.TextBox();
			this.btnScan = new global::System.Windows.Forms.Button();
			this.lblScan = new global::System.Windows.Forms.Label();
			this.tabActions = new global::System.Windows.Forms.TabControl();
			this.tabPage11 = new global::System.Windows.Forms.TabPage();
			this.groupBox13 = new global::System.Windows.Forms.GroupBox();
			this.lstWeaponsFilter = new global::System.Windows.Forms.ListBox();
			this.optionWeaponsFilterList = new global::System.Windows.Forms.RadioButton();
			this.optionWeaponsNoFilter = new global::System.Windows.Forms.RadioButton();
			this.groupBox10 = new global::System.Windows.Forms.GroupBox();
			this.chkWeaponsUseHotkey = new global::System.Windows.Forms.CheckBox();
			this.txtWeaponsHotKey = new global::System.Windows.Forms.TextBox();
			this.chkWeaponsDisableWhenDone = new global::System.Windows.Forms.CheckBox();
			this.chkWeaponsActiveInactive = new global::System.Windows.Forms.CheckBox();
			this.txtWeaponsMax = new global::System.Windows.Forms.TextBox();
			this.label44 = new global::System.Windows.Forms.Label();
			this.txtWeaponsQuantity = new global::System.Windows.Forms.TextBox();
			this.label46 = new global::System.Windows.Forms.Label();
			this.txtWeaponsTimer = new global::System.Windows.Forms.TextBox();
			this.label47 = new global::System.Windows.Forms.Label();
			this.txtWeaponsFixed = new global::System.Windows.Forms.TextBox();
			this.optionWeaponsTimer = new global::System.Windows.Forms.RadioButton();
			this.optionWeaponsFixed = new global::System.Windows.Forms.RadioButton();
			this.tabPage14 = new global::System.Windows.Forms.TabPage();
			this.groupBox17 = new global::System.Windows.Forms.GroupBox();
			this.lstBowsFilter = new global::System.Windows.Forms.ListBox();
			this.optionBowsFilterList = new global::System.Windows.Forms.RadioButton();
			this.optionBowsNoFilter = new global::System.Windows.Forms.RadioButton();
			this.groupBox18 = new global::System.Windows.Forms.GroupBox();
			this.chkBowsUseHotkey = new global::System.Windows.Forms.CheckBox();
			this.txtBowsHotKey = new global::System.Windows.Forms.TextBox();
			this.chkBowsDisableWhenDone = new global::System.Windows.Forms.CheckBox();
			this.chkBowsActiveInactive = new global::System.Windows.Forms.CheckBox();
			this.txtBowsMax = new global::System.Windows.Forms.TextBox();
			this.label54 = new global::System.Windows.Forms.Label();
			this.txtBowsQuantity = new global::System.Windows.Forms.TextBox();
			this.label56 = new global::System.Windows.Forms.Label();
			this.txtBowsTimer = new global::System.Windows.Forms.TextBox();
			this.label60 = new global::System.Windows.Forms.Label();
			this.txtBowsFixed = new global::System.Windows.Forms.TextBox();
			this.optionBowsTimer = new global::System.Windows.Forms.RadioButton();
			this.optionBowsFixed = new global::System.Windows.Forms.RadioButton();
			this.tabPage15 = new global::System.Windows.Forms.TabPage();
			this.groupBox20 = new global::System.Windows.Forms.GroupBox();
			this.lstShieldsFilter = new global::System.Windows.Forms.ListBox();
			this.optionShieldsFilterList = new global::System.Windows.Forms.RadioButton();
			this.optionShieldsNoFilter = new global::System.Windows.Forms.RadioButton();
			this.groupBox21 = new global::System.Windows.Forms.GroupBox();
			this.chkShieldsUseHotkey = new global::System.Windows.Forms.CheckBox();
			this.txtShieldsHotKey = new global::System.Windows.Forms.TextBox();
			this.chkShieldsDisableWhenDone = new global::System.Windows.Forms.CheckBox();
			this.chkShieldsActiveInactive = new global::System.Windows.Forms.CheckBox();
			this.txtShieldsMax = new global::System.Windows.Forms.TextBox();
			this.label61 = new global::System.Windows.Forms.Label();
			this.txtShieldsQuantity = new global::System.Windows.Forms.TextBox();
			this.label62 = new global::System.Windows.Forms.Label();
			this.txtShieldsTimer = new global::System.Windows.Forms.TextBox();
			this.label63 = new global::System.Windows.Forms.Label();
			this.txtShieldsFixed = new global::System.Windows.Forms.TextBox();
			this.optionShieldsTimer = new global::System.Windows.Forms.RadioButton();
			this.optionShieldsFixed = new global::System.Windows.Forms.RadioButton();
			this.tabPage16 = new global::System.Windows.Forms.TabPage();
			this.groupBox22 = new global::System.Windows.Forms.GroupBox();
			this.lstArrowsFilter = new global::System.Windows.Forms.ListBox();
			this.optionArrowsFilterList = new global::System.Windows.Forms.RadioButton();
			this.optionArrowsNoFilter = new global::System.Windows.Forms.RadioButton();
			this.groupBox23 = new global::System.Windows.Forms.GroupBox();
			this.chkArrowsUseHotkey = new global::System.Windows.Forms.CheckBox();
			this.txtArrowsHotKey = new global::System.Windows.Forms.TextBox();
			this.chkArrowsDisableWhenDone = new global::System.Windows.Forms.CheckBox();
			this.chkArrowsActiveInactive = new global::System.Windows.Forms.CheckBox();
			this.txtArrowsMax = new global::System.Windows.Forms.TextBox();
			this.label64 = new global::System.Windows.Forms.Label();
			this.txtArrowsQuantity = new global::System.Windows.Forms.TextBox();
			this.label65 = new global::System.Windows.Forms.Label();
			this.txtArrowsTimer = new global::System.Windows.Forms.TextBox();
			this.label66 = new global::System.Windows.Forms.Label();
			this.txtArrowsFixed = new global::System.Windows.Forms.TextBox();
			this.optionArrowsTimer = new global::System.Windows.Forms.RadioButton();
			this.optionArrowsFixed = new global::System.Windows.Forms.RadioButton();
			this.tabPage17 = new global::System.Windows.Forms.TabPage();
			this.groupBox16 = new global::System.Windows.Forms.GroupBox();
			this.lblLockStaminaInfo = new global::System.Windows.Forms.Label();
			this.chkLockStaminaSet = new global::System.Windows.Forms.CheckBox();
			this.txtLockStaminaHotKey = new global::System.Windows.Forms.TextBox();
			this.chkLockStaminaUseHotkey = new global::System.Windows.Forms.CheckBox();
			this.lblLockHealthInfo = new global::System.Windows.Forms.Label();
			this.chkLockHealthSet = new global::System.Windows.Forms.CheckBox();
			this.txtLockHealthHotKey = new global::System.Windows.Forms.TextBox();
			this.chkLockHealthUseHotkey = new global::System.Windows.Forms.CheckBox();
			this.groupBox14 = new global::System.Windows.Forms.GroupBox();
			this.groupBox3 = new global::System.Windows.Forms.GroupBox();
			this.lstUnbreakableFilter = new global::System.Windows.Forms.ListBox();
			this.optionUnbreakableFilterList = new global::System.Windows.Forms.RadioButton();
			this.optionUnbreakableNoFilter = new global::System.Windows.Forms.RadioButton();
			this.lblUnbreakableShieldsInfo = new global::System.Windows.Forms.Label();
			this.chkUnbreakableShieldsSet = new global::System.Windows.Forms.CheckBox();
			this.txtUnbreakableShieldsHotKey = new global::System.Windows.Forms.TextBox();
			this.chkUnbreakableShieldsUseHotkey = new global::System.Windows.Forms.CheckBox();
			this.lblUnbreakableBowsInfo = new global::System.Windows.Forms.Label();
			this.chkUnbreakableBowsSet = new global::System.Windows.Forms.CheckBox();
			this.txtUnbreakableBowsHotKey = new global::System.Windows.Forms.TextBox();
			this.chkUnbreakableBowsUseHotkey = new global::System.Windows.Forms.CheckBox();
			this.lblUnbreakableWeaponsInfo = new global::System.Windows.Forms.Label();
			this.chkUnbreakableWeaponsSet = new global::System.Windows.Forms.CheckBox();
			this.txtUnbreakableWeaponsHotKey = new global::System.Windows.Forms.TextBox();
			this.chkUnbreakableWeaponsUseHotkey = new global::System.Windows.Forms.CheckBox();
			this.tabPage21 = new global::System.Windows.Forms.TabPage();
			this.groupBox6 = new global::System.Windows.Forms.GroupBox();
			this.btnCapturedPositionTP = new global::System.Windows.Forms.Button();
			this.label70 = new global::System.Windows.Forms.Label();
			this.txtCapturedPositionName = new global::System.Windows.Forms.TextBox();
			this.label57 = new global::System.Windows.Forms.Label();
			this.txtCapturedPositionZ = new global::System.Windows.Forms.TextBox();
			this.label58 = new global::System.Windows.Forms.Label();
			this.txtCapturedPositionY = new global::System.Windows.Forms.TextBox();
			this.label69 = new global::System.Windows.Forms.Label();
			this.txtCapturedPositionX = new global::System.Windows.Forms.TextBox();
			this.btnCapturedPositionRemove = new global::System.Windows.Forms.Button();
			this.btnCapturedPositionSave = new global::System.Windows.Forms.Button();
			this.btnCapturedPositionNew = new global::System.Windows.Forms.Button();
			this.lstCapturedPositions = new global::System.Windows.Forms.ListBox();
			this.groupBox7 = new global::System.Windows.Forms.GroupBox();
			this.btnPositionEdit = new global::System.Windows.Forms.Button();
			this.btnPositionRestore = new global::System.Windows.Forms.Button();
			this.txtPositionRestoreHotKey = new global::System.Windows.Forms.TextBox();
			this.chkPositionRestoreUseHotkey = new global::System.Windows.Forms.CheckBox();
			this.btnPositionSave = new global::System.Windows.Forms.Button();
			this.txtPositionSaveHotKey = new global::System.Windows.Forms.TextBox();
			this.chkPositionSaveUseHotkey = new global::System.Windows.Forms.CheckBox();
			this.btnPositionJump = new global::System.Windows.Forms.Button();
			this.txtPositionJumpHeight = new global::System.Windows.Forms.TextBox();
			this.txtPositionJumpHotKey = new global::System.Windows.Forms.TextBox();
			this.chkPositionJumpUseHotkey = new global::System.Windows.Forms.CheckBox();
			this.chkPositionLockHeightSet = new global::System.Windows.Forms.CheckBox();
			this.txtPositionLockHeightHotKey = new global::System.Windows.Forms.TextBox();
			this.chkPositionLockHeightUseHotkey = new global::System.Windows.Forms.CheckBox();
			this.label68 = new global::System.Windows.Forms.Label();
			this.txtPositionZ = new global::System.Windows.Forms.TextBox();
			this.label67 = new global::System.Windows.Forms.Label();
			this.txtPositionY = new global::System.Windows.Forms.TextBox();
			this.label59 = new global::System.Windows.Forms.Label();
			this.txtPositionX = new global::System.Windows.Forms.TextBox();
			this.tabPage18 = new global::System.Windows.Forms.TabPage();
			this.groupBox19 = new global::System.Windows.Forms.GroupBox();
			this.lblPowersDarukInfo = new global::System.Windows.Forms.Label();
			this.chkPowersDarukSet = new global::System.Windows.Forms.CheckBox();
			this.txtPowersDarukHotKey = new global::System.Windows.Forms.TextBox();
			this.chkPowersDarukUseHotkey = new global::System.Windows.Forms.CheckBox();
			this.lblPowersUrbosaInfo = new global::System.Windows.Forms.Label();
			this.chkPowersUrbosaSet = new global::System.Windows.Forms.CheckBox();
			this.txtPowersUrbosaHotKey = new global::System.Windows.Forms.TextBox();
			this.chkPowersUrbosaUseHotkey = new global::System.Windows.Forms.CheckBox();
			this.lblPowersRevaliInfo = new global::System.Windows.Forms.Label();
			this.chkPowersRevaliSet = new global::System.Windows.Forms.CheckBox();
			this.txtPowersRevaliHotKey = new global::System.Windows.Forms.TextBox();
			this.chkPowersRevaliUseHotkey = new global::System.Windows.Forms.CheckBox();
			this.lblPowersMiphaInfo = new global::System.Windows.Forms.Label();
			this.chkPowersMiphaSet = new global::System.Windows.Forms.CheckBox();
			this.txtPowersMiphaHotKey = new global::System.Windows.Forms.TextBox();
			this.chkPowersMiphaUseHotkey = new global::System.Windows.Forms.CheckBox();
			this.tabPage19 = new global::System.Windows.Forms.TabPage();
			this.groupBox4 = new global::System.Windows.Forms.GroupBox();
			this.btnRunSpeedDefault = new global::System.Windows.Forms.Button();
			this.txtRunSpeedDefaultHotKey = new global::System.Windows.Forms.TextBox();
			this.chkRunSpeedDefaultUseHotkey = new global::System.Windows.Forms.CheckBox();
			this.btnRunSpeedDown = new global::System.Windows.Forms.Button();
			this.txtRunSpeedDownHotKey = new global::System.Windows.Forms.TextBox();
			this.chkRunSpeedDownUseHotkey = new global::System.Windows.Forms.CheckBox();
			this.btnRunSpeedUp = new global::System.Windows.Forms.Button();
			this.txtRunSpeedUpHotKey = new global::System.Windows.Forms.TextBox();
			this.chkRunSpeedUpUseHotkey = new global::System.Windows.Forms.CheckBox();
			this.btnRunSpeedUpdate = new global::System.Windows.Forms.Button();
			this.label49 = new global::System.Windows.Forms.Label();
			this.txtRunSpeed = new global::System.Windows.Forms.TextBox();
			this.groupBox15 = new global::System.Windows.Forms.GroupBox();
			this.lblUnlimitAmiiboInfo = new global::System.Windows.Forms.Label();
			this.chkUnlimitAmiiboSet = new global::System.Windows.Forms.CheckBox();
			this.txtUnlimitAmiiboHotKey = new global::System.Windows.Forms.TextBox();
			this.chkUnlimitAmiiboUseHotkey = new global::System.Windows.Forms.CheckBox();
			this.tabPage13 = new global::System.Windows.Forms.TabPage();
			this.gbActionsFilter = new global::System.Windows.Forms.GroupBox();
			this.lstActionsFilter = new global::System.Windows.Forms.ListBox();
			this.optionActionsFilterList = new global::System.Windows.Forms.RadioButton();
			this.optionActionsNoFilter = new global::System.Windows.Forms.RadioButton();
			this.gbActionsSettings = new global::System.Windows.Forms.GroupBox();
			this.chkActionsUseHotkey = new global::System.Windows.Forms.CheckBox();
			this.txtActionsHotKey = new global::System.Windows.Forms.TextBox();
			this.chkActionsDisableWhenDone = new global::System.Windows.Forms.CheckBox();
			this.cbActionsList = new global::System.Windows.Forms.ComboBox();
			this.chkActionsActiveInactive = new global::System.Windows.Forms.CheckBox();
			this.txtActionsMax = new global::System.Windows.Forms.TextBox();
			this.label41 = new global::System.Windows.Forms.Label();
			this.txtActionsQuantity = new global::System.Windows.Forms.TextBox();
			this.label42 = new global::System.Windows.Forms.Label();
			this.txtActionsTimer = new global::System.Windows.Forms.TextBox();
			this.label43 = new global::System.Windows.Forms.Label();
			this.txtActionsFixed = new global::System.Windows.Forms.TextBox();
			this.optionActionsTimer = new global::System.Windows.Forms.RadioButton();
			this.optionActionsFixed = new global::System.Windows.Forms.RadioButton();
			this.groupBox9 = new global::System.Windows.Forms.GroupBox();
			this.btnActionsRemove = new global::System.Windows.Forms.Button();
			this.lstActionsRegistered = new global::System.Windows.Forms.ListBox();
			this.btnActionsNew = new global::System.Windows.Forms.Button();
			this.tabControl2 = new global::System.Windows.Forms.TabControl();
			this.tabPage10 = new global::System.Windows.Forms.TabPage();
			this.groupBox5 = new global::System.Windows.Forms.GroupBox();
			this.label55 = new global::System.Windows.Forms.Label();
			this.label53 = new global::System.Windows.Forms.Label();
			this.numSpacingMs = new global::System.Windows.Forms.NumericUpDown();
			this.numInternalLoopMs = new global::System.Windows.Forms.NumericUpDown();
			this.groupBox2 = new global::System.Windows.Forms.GroupBox();
			this.btnGameProcessResume = new global::System.Windows.Forms.Button();
			this.btnGameProcessPause = new global::System.Windows.Forms.Button();
			this.groupBox1 = new global::System.Windows.Forms.GroupBox();
			this.btnSettingsImport = new global::System.Windows.Forms.Button();
			this.btnSettingsExport = new global::System.Windows.Forms.Button();
			this.btnSettingsClear = new global::System.Windows.Forms.Button();
			this.btnSettingsSave = new global::System.Windows.Forms.Button();
			this.groupBox12 = new global::System.Windows.Forms.GroupBox();
			this.chkUpdateList = new global::System.Windows.Forms.CheckBox();
			this.txtTimerUpdateList = new global::System.Windows.Forms.TextBox();
			this.label45 = new global::System.Windows.Forms.Label();
			this.groupBox11 = new global::System.Windows.Forms.GroupBox();
			this.lstEquippedWeapons = new global::System.Windows.Forms.ListBox();
			this.tabPage22 = new global::System.Windows.Forms.TabPage();
			this.btntxtFindMemoryRegionBySize = new global::System.Windows.Forms.Button();
			this.label73 = new global::System.Windows.Forms.Label();
			this.txtFindMemoryRegionBySize = new global::System.Windows.Forms.TextBox();
			this.btnFindMemoryRegionByAddress = new global::System.Windows.Forms.Button();
			this.label72 = new global::System.Windows.Forms.Label();
			this.txtFindMemoryRegionByAddress = new global::System.Windows.Forms.TextBox();
			this.label48 = new global::System.Windows.Forms.Label();
			this.lblVersion = new global::System.Windows.Forms.Label();
			this.button1 = new global::System.Windows.Forms.Button();
			this.button2 = new global::System.Windows.Forms.Button();
			this.button3 = new global::System.Windows.Forms.Button();
			this.btnMemoryRegions = new global::System.Windows.Forms.Button();
			this.trackTime = new global::System.Windows.Forms.TrackBar();
			this.btnCompareAddress = new global::System.Windows.Forms.Button();
			this.label74 = new global::System.Windows.Forms.Label();
			this.txtCompareAddress = new global::System.Windows.Forms.TextBox();
			this.btnNoStaminaBar = new global::System.Windows.Forms.Button();
			this.btnRestoreStaminaBar = new global::System.Windows.Forms.Button();
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
			((global::System.ComponentModel.ISupportInitialize)this.numSpacingMs).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.numInternalLoopMs).BeginInit();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox12.SuspendLayout();
			this.groupBox11.SuspendLayout();
			this.tabPage22.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.trackTime).BeginInit();
			base.SuspendLayout();
			this.tabMain.Controls.Add(this.tabPage9);
			this.tabMain.Location = new global::System.Drawing.Point(502, 310);
			this.tabMain.Name = "tabMain";
			this.tabMain.SelectedIndex = 0;
			this.tabMain.Size = new global::System.Drawing.Size(507, 173);
			this.tabMain.TabIndex = 4;
			this.tabPage9.Controls.Add(this.txtLog);
			this.tabPage9.Location = new global::System.Drawing.Point(4, 22);
			this.tabPage9.Name = "tabPage9";
			this.tabPage9.Padding = new global::System.Windows.Forms.Padding(3);
			this.tabPage9.Size = new global::System.Drawing.Size(499, 147);
			this.tabPage9.TabIndex = 0;
			this.tabPage9.Text = "Log";
			this.tabPage9.UseVisualStyleBackColor = true;
			this.txtLog.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.txtLog.Location = new global::System.Drawing.Point(6, 7);
			this.txtLog.Multiline = true;
			this.txtLog.Name = "txtLog";
			this.txtLog.ReadOnly = true;
			this.txtLog.ScrollBars = global::System.Windows.Forms.ScrollBars.Vertical;
			this.txtLog.Size = new global::System.Drawing.Size(487, 134);
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
			this.tabItems.Location = new global::System.Drawing.Point(12, 41);
			this.tabItems.Multiline = true;
			this.tabItems.Name = "tabItems";
			this.tabItems.SelectedIndex = 0;
			this.tabItems.Size = new global::System.Drawing.Size(484, 267);
			this.tabItems.TabIndex = 0;
			this.tabPage1.Controls.Add(this.btnInventoryItemUnlock);
			this.tabPage1.Controls.Add(this.gbInventoryEdit);
			this.tabPage1.Controls.Add(this.lstInventory);
			this.tabPage1.Location = new global::System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new global::System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new global::System.Drawing.Size(476, 241);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Inventory";
			this.tabPage1.UseVisualStyleBackColor = true;
			this.btnInventoryItemUnlock.Location = new global::System.Drawing.Point(362, 200);
			this.btnInventoryItemUnlock.Name = "btnInventoryItemUnlock";
			this.btnInventoryItemUnlock.Size = new global::System.Drawing.Size(75, 23);
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
			this.gbInventoryEdit.Location = new global::System.Drawing.Point(193, 6);
			this.gbInventoryEdit.Name = "gbInventoryEdit";
			this.gbInventoryEdit.Size = new global::System.Drawing.Size(244, 188);
			this.gbInventoryEdit.TabIndex = 1;
			this.gbInventoryEdit.TabStop = false;
			this.gbInventoryEdit.Text = "Edit Item";
			this.cbInventoryItemBonusType.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbInventoryItemBonusType.FormattingEnabled = true;
			this.cbInventoryItemBonusType.Location = new global::System.Drawing.Point(77, 98);
			this.cbInventoryItemBonusType.Name = "cbInventoryItemBonusType";
			this.cbInventoryItemBonusType.Size = new global::System.Drawing.Size(161, 21);
			this.cbInventoryItemBonusType.TabIndex = 17;
			this.btnInventoryItemUpdate.Location = new global::System.Drawing.Point(7, 150);
			this.btnInventoryItemUpdate.Name = "btnInventoryItemUpdate";
			this.btnInventoryItemUpdate.Size = new global::System.Drawing.Size(75, 23);
			this.btnInventoryItemUpdate.TabIndex = 10;
			this.btnInventoryItemUpdate.Text = "Update";
			this.btnInventoryItemUpdate.UseVisualStyleBackColor = true;
			this.label4.AutoSize = true;
			this.label4.Location = new global::System.Drawing.Point(4, 127);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(67, 13);
			this.label4.TabIndex = 9;
			this.label4.Text = "Bonus Value";
			this.txtInventoryItemBonusValue.Location = new global::System.Drawing.Point(77, 124);
			this.txtInventoryItemBonusValue.Name = "txtInventoryItemBonusValue";
			this.txtInventoryItemBonusValue.Size = new global::System.Drawing.Size(161, 20);
			this.txtInventoryItemBonusValue.TabIndex = 8;
			this.label5.AutoSize = true;
			this.label5.Location = new global::System.Drawing.Point(4, 101);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(64, 13);
			this.label5.TabIndex = 7;
			this.label5.Text = "Bonus Type";
			this.txtInventoryItemBonusType.Location = new global::System.Drawing.Point(77, 98);
			this.txtInventoryItemBonusType.Name = "txtInventoryItemBonusType";
			this.txtInventoryItemBonusType.Size = new global::System.Drawing.Size(161, 20);
			this.txtInventoryItemBonusType.TabIndex = 6;
			this.label3.AutoSize = true;
			this.label3.Location = new global::System.Drawing.Point(4, 22);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(35, 13);
			this.label3.TabIndex = 5;
			this.label3.Text = "Name";
			this.cbInventoryItemName.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbInventoryItemName.FormattingEnabled = true;
			this.cbInventoryItemName.Location = new global::System.Drawing.Point(77, 19);
			this.cbInventoryItemName.Name = "cbInventoryItemName";
			this.cbInventoryItemName.Size = new global::System.Drawing.Size(161, 21);
			this.cbInventoryItemName.TabIndex = 4;
			this.label2.AutoSize = true;
			this.label2.Location = new global::System.Drawing.Point(4, 75);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(46, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Qt / Dur";
			this.txtInventoryItemQtDur.Location = new global::System.Drawing.Point(77, 72);
			this.txtInventoryItemQtDur.Name = "txtInventoryItemQtDur";
			this.txtInventoryItemQtDur.Size = new global::System.Drawing.Size(161, 20);
			this.txtInventoryItemQtDur.TabIndex = 2;
			this.label1.AutoSize = true;
			this.label1.Location = new global::System.Drawing.Point(4, 49);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(18, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "ID";
			this.txtInventoryItemID.Location = new global::System.Drawing.Point(77, 46);
			this.txtInventoryItemID.Name = "txtInventoryItemID";
			this.txtInventoryItemID.Size = new global::System.Drawing.Size(161, 20);
			this.txtInventoryItemID.TabIndex = 0;
			this.lstInventory.FormattingEnabled = true;
			this.lstInventory.Location = new global::System.Drawing.Point(6, 6);
			this.lstInventory.Name = "lstInventory";
			this.lstInventory.Size = new global::System.Drawing.Size(181, 225);
			this.lstInventory.TabIndex = 0;
			this.tabPage2.Controls.Add(this.btnWeaponsItemUnlock);
			this.tabPage2.Controls.Add(this.gbWeaponsEdit);
			this.tabPage2.Controls.Add(this.lstWeapons);
			this.tabPage2.Location = new global::System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new global::System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new global::System.Drawing.Size(476, 241);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Weapons";
			this.tabPage2.UseVisualStyleBackColor = true;
			this.btnWeaponsItemUnlock.Location = new global::System.Drawing.Point(362, 200);
			this.btnWeaponsItemUnlock.Name = "btnWeaponsItemUnlock";
			this.btnWeaponsItemUnlock.Size = new global::System.Drawing.Size(75, 23);
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
			this.gbWeaponsEdit.Location = new global::System.Drawing.Point(193, 6);
			this.gbWeaponsEdit.Name = "gbWeaponsEdit";
			this.gbWeaponsEdit.Size = new global::System.Drawing.Size(244, 188);
			this.gbWeaponsEdit.TabIndex = 3;
			this.gbWeaponsEdit.TabStop = false;
			this.gbWeaponsEdit.Text = "Edit Item";
			this.cbWeaponsItemBonusType.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbWeaponsItemBonusType.FormattingEnabled = true;
			this.cbWeaponsItemBonusType.Location = new global::System.Drawing.Point(77, 98);
			this.cbWeaponsItemBonusType.Name = "cbWeaponsItemBonusType";
			this.cbWeaponsItemBonusType.Size = new global::System.Drawing.Size(161, 21);
			this.cbWeaponsItemBonusType.TabIndex = 18;
			this.btnWeaponsItemUpdate.Location = new global::System.Drawing.Point(7, 150);
			this.btnWeaponsItemUpdate.Name = "btnWeaponsItemUpdate";
			this.btnWeaponsItemUpdate.Size = new global::System.Drawing.Size(75, 23);
			this.btnWeaponsItemUpdate.TabIndex = 10;
			this.btnWeaponsItemUpdate.Text = "Update";
			this.btnWeaponsItemUpdate.UseVisualStyleBackColor = true;
			this.label6.AutoSize = true;
			this.label6.Location = new global::System.Drawing.Point(4, 127);
			this.label6.Name = "label6";
			this.label6.Size = new global::System.Drawing.Size(67, 13);
			this.label6.TabIndex = 9;
			this.label6.Text = "Bonus Value";
			this.txtWeaponsItemBonusValue.Location = new global::System.Drawing.Point(77, 124);
			this.txtWeaponsItemBonusValue.Name = "txtWeaponsItemBonusValue";
			this.txtWeaponsItemBonusValue.Size = new global::System.Drawing.Size(161, 20);
			this.txtWeaponsItemBonusValue.TabIndex = 8;
			this.label7.AutoSize = true;
			this.label7.Location = new global::System.Drawing.Point(4, 101);
			this.label7.Name = "label7";
			this.label7.Size = new global::System.Drawing.Size(64, 13);
			this.label7.TabIndex = 7;
			this.label7.Text = "Bonus Type";
			this.txtWeaponsItemBonusType.Location = new global::System.Drawing.Point(77, 98);
			this.txtWeaponsItemBonusType.Name = "txtWeaponsItemBonusType";
			this.txtWeaponsItemBonusType.Size = new global::System.Drawing.Size(161, 20);
			this.txtWeaponsItemBonusType.TabIndex = 6;
			this.label8.AutoSize = true;
			this.label8.Location = new global::System.Drawing.Point(4, 22);
			this.label8.Name = "label8";
			this.label8.Size = new global::System.Drawing.Size(35, 13);
			this.label8.TabIndex = 5;
			this.label8.Text = "Name";
			this.cbWeaponsItemName.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbWeaponsItemName.FormattingEnabled = true;
			this.cbWeaponsItemName.Location = new global::System.Drawing.Point(77, 19);
			this.cbWeaponsItemName.Name = "cbWeaponsItemName";
			this.cbWeaponsItemName.Size = new global::System.Drawing.Size(161, 21);
			this.cbWeaponsItemName.TabIndex = 4;
			this.label9.AutoSize = true;
			this.label9.Location = new global::System.Drawing.Point(4, 75);
			this.label9.Name = "label9";
			this.label9.Size = new global::System.Drawing.Size(46, 13);
			this.label9.TabIndex = 3;
			this.label9.Text = "Qt / Dur";
			this.txtWeaponsItemQtDur.Location = new global::System.Drawing.Point(77, 72);
			this.txtWeaponsItemQtDur.Name = "txtWeaponsItemQtDur";
			this.txtWeaponsItemQtDur.Size = new global::System.Drawing.Size(161, 20);
			this.txtWeaponsItemQtDur.TabIndex = 2;
			this.label10.AutoSize = true;
			this.label10.Location = new global::System.Drawing.Point(4, 49);
			this.label10.Name = "label10";
			this.label10.Size = new global::System.Drawing.Size(18, 13);
			this.label10.TabIndex = 1;
			this.label10.Text = "ID";
			this.txtWeaponsItemID.Location = new global::System.Drawing.Point(77, 46);
			this.txtWeaponsItemID.Name = "txtWeaponsItemID";
			this.txtWeaponsItemID.Size = new global::System.Drawing.Size(161, 20);
			this.txtWeaponsItemID.TabIndex = 0;
			this.lstWeapons.FormattingEnabled = true;
			this.lstWeapons.Location = new global::System.Drawing.Point(6, 6);
			this.lstWeapons.Name = "lstWeapons";
			this.lstWeapons.Size = new global::System.Drawing.Size(181, 225);
			this.lstWeapons.TabIndex = 2;
			this.tabPage3.Controls.Add(this.btnArcheryItemUnlock);
			this.tabPage3.Controls.Add(this.gbArcheryEdit);
			this.tabPage3.Controls.Add(this.lstArchery);
			this.tabPage3.Location = new global::System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new global::System.Windows.Forms.Padding(3);
			this.tabPage3.Size = new global::System.Drawing.Size(476, 241);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Archery";
			this.tabPage3.UseVisualStyleBackColor = true;
			this.btnArcheryItemUnlock.Location = new global::System.Drawing.Point(362, 200);
			this.btnArcheryItemUnlock.Name = "btnArcheryItemUnlock";
			this.btnArcheryItemUnlock.Size = new global::System.Drawing.Size(75, 23);
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
			this.gbArcheryEdit.Location = new global::System.Drawing.Point(193, 6);
			this.gbArcheryEdit.Name = "gbArcheryEdit";
			this.gbArcheryEdit.Size = new global::System.Drawing.Size(244, 188);
			this.gbArcheryEdit.TabIndex = 3;
			this.gbArcheryEdit.TabStop = false;
			this.gbArcheryEdit.Text = "Edit Item";
			this.cbArcheryItemBonusType.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbArcheryItemBonusType.FormattingEnabled = true;
			this.cbArcheryItemBonusType.Location = new global::System.Drawing.Point(77, 98);
			this.cbArcheryItemBonusType.Name = "cbArcheryItemBonusType";
			this.cbArcheryItemBonusType.Size = new global::System.Drawing.Size(161, 21);
			this.cbArcheryItemBonusType.TabIndex = 18;
			this.btnArcheryItemUpdate.Location = new global::System.Drawing.Point(7, 150);
			this.btnArcheryItemUpdate.Name = "btnArcheryItemUpdate";
			this.btnArcheryItemUpdate.Size = new global::System.Drawing.Size(75, 23);
			this.btnArcheryItemUpdate.TabIndex = 10;
			this.btnArcheryItemUpdate.Text = "Update";
			this.btnArcheryItemUpdate.UseVisualStyleBackColor = true;
			this.label11.AutoSize = true;
			this.label11.Location = new global::System.Drawing.Point(4, 127);
			this.label11.Name = "label11";
			this.label11.Size = new global::System.Drawing.Size(67, 13);
			this.label11.TabIndex = 9;
			this.label11.Text = "Bonus Value";
			this.txtArcheryItemBonusValue.Location = new global::System.Drawing.Point(77, 124);
			this.txtArcheryItemBonusValue.Name = "txtArcheryItemBonusValue";
			this.txtArcheryItemBonusValue.Size = new global::System.Drawing.Size(161, 20);
			this.txtArcheryItemBonusValue.TabIndex = 8;
			this.label12.AutoSize = true;
			this.label12.Location = new global::System.Drawing.Point(4, 101);
			this.label12.Name = "label12";
			this.label12.Size = new global::System.Drawing.Size(64, 13);
			this.label12.TabIndex = 7;
			this.label12.Text = "Bonus Type";
			this.txtArcheryItemBonusType.Location = new global::System.Drawing.Point(77, 98);
			this.txtArcheryItemBonusType.Name = "txtArcheryItemBonusType";
			this.txtArcheryItemBonusType.Size = new global::System.Drawing.Size(161, 20);
			this.txtArcheryItemBonusType.TabIndex = 6;
			this.label13.AutoSize = true;
			this.label13.Location = new global::System.Drawing.Point(4, 22);
			this.label13.Name = "label13";
			this.label13.Size = new global::System.Drawing.Size(35, 13);
			this.label13.TabIndex = 5;
			this.label13.Text = "Name";
			this.cbArcheryItemName.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbArcheryItemName.FormattingEnabled = true;
			this.cbArcheryItemName.Location = new global::System.Drawing.Point(77, 19);
			this.cbArcheryItemName.Name = "cbArcheryItemName";
			this.cbArcheryItemName.Size = new global::System.Drawing.Size(161, 21);
			this.cbArcheryItemName.TabIndex = 4;
			this.label14.AutoSize = true;
			this.label14.Location = new global::System.Drawing.Point(4, 75);
			this.label14.Name = "label14";
			this.label14.Size = new global::System.Drawing.Size(46, 13);
			this.label14.TabIndex = 3;
			this.label14.Text = "Qt / Dur";
			this.txtArcheryItemQtDur.Location = new global::System.Drawing.Point(77, 72);
			this.txtArcheryItemQtDur.Name = "txtArcheryItemQtDur";
			this.txtArcheryItemQtDur.Size = new global::System.Drawing.Size(161, 20);
			this.txtArcheryItemQtDur.TabIndex = 2;
			this.label15.AutoSize = true;
			this.label15.Location = new global::System.Drawing.Point(4, 49);
			this.label15.Name = "label15";
			this.label15.Size = new global::System.Drawing.Size(18, 13);
			this.label15.TabIndex = 1;
			this.label15.Text = "ID";
			this.txtArcheryItemID.Location = new global::System.Drawing.Point(77, 46);
			this.txtArcheryItemID.Name = "txtArcheryItemID";
			this.txtArcheryItemID.Size = new global::System.Drawing.Size(161, 20);
			this.txtArcheryItemID.TabIndex = 0;
			this.lstArchery.FormattingEnabled = true;
			this.lstArchery.Location = new global::System.Drawing.Point(6, 6);
			this.lstArchery.Name = "lstArchery";
			this.lstArchery.Size = new global::System.Drawing.Size(181, 225);
			this.lstArchery.TabIndex = 2;
			this.tabPage4.Controls.Add(this.btnShieldsItemUnlock);
			this.tabPage4.Controls.Add(this.gbShieldsEdit);
			this.tabPage4.Controls.Add(this.lstShields);
			this.tabPage4.Location = new global::System.Drawing.Point(4, 22);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Padding = new global::System.Windows.Forms.Padding(3);
			this.tabPage4.Size = new global::System.Drawing.Size(476, 241);
			this.tabPage4.TabIndex = 3;
			this.tabPage4.Text = "Shields";
			this.tabPage4.UseVisualStyleBackColor = true;
			this.btnShieldsItemUnlock.Location = new global::System.Drawing.Point(362, 200);
			this.btnShieldsItemUnlock.Name = "btnShieldsItemUnlock";
			this.btnShieldsItemUnlock.Size = new global::System.Drawing.Size(75, 23);
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
			this.gbShieldsEdit.Location = new global::System.Drawing.Point(193, 6);
			this.gbShieldsEdit.Name = "gbShieldsEdit";
			this.gbShieldsEdit.Size = new global::System.Drawing.Size(244, 188);
			this.gbShieldsEdit.TabIndex = 5;
			this.gbShieldsEdit.TabStop = false;
			this.gbShieldsEdit.Text = "Edit Item";
			this.cbShieldsItemBonusType.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbShieldsItemBonusType.FormattingEnabled = true;
			this.cbShieldsItemBonusType.Location = new global::System.Drawing.Point(77, 98);
			this.cbShieldsItemBonusType.Name = "cbShieldsItemBonusType";
			this.cbShieldsItemBonusType.Size = new global::System.Drawing.Size(161, 21);
			this.cbShieldsItemBonusType.TabIndex = 18;
			this.btnShieldsItemUpdate.Location = new global::System.Drawing.Point(7, 150);
			this.btnShieldsItemUpdate.Name = "btnShieldsItemUpdate";
			this.btnShieldsItemUpdate.Size = new global::System.Drawing.Size(75, 23);
			this.btnShieldsItemUpdate.TabIndex = 10;
			this.btnShieldsItemUpdate.Text = "Update";
			this.btnShieldsItemUpdate.UseVisualStyleBackColor = true;
			this.label16.AutoSize = true;
			this.label16.Location = new global::System.Drawing.Point(4, 127);
			this.label16.Name = "label16";
			this.label16.Size = new global::System.Drawing.Size(67, 13);
			this.label16.TabIndex = 9;
			this.label16.Text = "Bonus Value";
			this.txtShieldsItemBonusValue.Location = new global::System.Drawing.Point(77, 124);
			this.txtShieldsItemBonusValue.Name = "txtShieldsItemBonusValue";
			this.txtShieldsItemBonusValue.Size = new global::System.Drawing.Size(161, 20);
			this.txtShieldsItemBonusValue.TabIndex = 8;
			this.label17.AutoSize = true;
			this.label17.Location = new global::System.Drawing.Point(4, 101);
			this.label17.Name = "label17";
			this.label17.Size = new global::System.Drawing.Size(64, 13);
			this.label17.TabIndex = 7;
			this.label17.Text = "Bonus Type";
			this.txtShieldsItemBonusType.Location = new global::System.Drawing.Point(77, 98);
			this.txtShieldsItemBonusType.Name = "txtShieldsItemBonusType";
			this.txtShieldsItemBonusType.Size = new global::System.Drawing.Size(161, 20);
			this.txtShieldsItemBonusType.TabIndex = 6;
			this.label18.AutoSize = true;
			this.label18.Location = new global::System.Drawing.Point(4, 22);
			this.label18.Name = "label18";
			this.label18.Size = new global::System.Drawing.Size(35, 13);
			this.label18.TabIndex = 5;
			this.label18.Text = "Name";
			this.cbShieldsItemName.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbShieldsItemName.FormattingEnabled = true;
			this.cbShieldsItemName.Location = new global::System.Drawing.Point(77, 19);
			this.cbShieldsItemName.Name = "cbShieldsItemName";
			this.cbShieldsItemName.Size = new global::System.Drawing.Size(161, 21);
			this.cbShieldsItemName.TabIndex = 4;
			this.label19.AutoSize = true;
			this.label19.Location = new global::System.Drawing.Point(4, 75);
			this.label19.Name = "label19";
			this.label19.Size = new global::System.Drawing.Size(46, 13);
			this.label19.TabIndex = 3;
			this.label19.Text = "Qt / Dur";
			this.txtShieldsItemQtDur.Location = new global::System.Drawing.Point(77, 72);
			this.txtShieldsItemQtDur.Name = "txtShieldsItemQtDur";
			this.txtShieldsItemQtDur.Size = new global::System.Drawing.Size(161, 20);
			this.txtShieldsItemQtDur.TabIndex = 2;
			this.label20.AutoSize = true;
			this.label20.Location = new global::System.Drawing.Point(4, 49);
			this.label20.Name = "label20";
			this.label20.Size = new global::System.Drawing.Size(18, 13);
			this.label20.TabIndex = 1;
			this.label20.Text = "ID";
			this.txtShieldsItemID.Location = new global::System.Drawing.Point(77, 46);
			this.txtShieldsItemID.Name = "txtShieldsItemID";
			this.txtShieldsItemID.Size = new global::System.Drawing.Size(161, 20);
			this.txtShieldsItemID.TabIndex = 0;
			this.lstShields.FormattingEnabled = true;
			this.lstShields.Location = new global::System.Drawing.Point(6, 6);
			this.lstShields.Name = "lstShields";
			this.lstShields.Size = new global::System.Drawing.Size(181, 225);
			this.lstShields.TabIndex = 4;
			this.tabPage5.Controls.Add(this.btnArmorsItemUnlock);
			this.tabPage5.Controls.Add(this.gbArmorsEdit);
			this.tabPage5.Controls.Add(this.lstArmors);
			this.tabPage5.Location = new global::System.Drawing.Point(4, 22);
			this.tabPage5.Name = "tabPage5";
			this.tabPage5.Padding = new global::System.Windows.Forms.Padding(3);
			this.tabPage5.Size = new global::System.Drawing.Size(476, 241);
			this.tabPage5.TabIndex = 4;
			this.tabPage5.Text = "Armors";
			this.tabPage5.UseVisualStyleBackColor = true;
			this.btnArmorsItemUnlock.Location = new global::System.Drawing.Point(362, 200);
			this.btnArmorsItemUnlock.Name = "btnArmorsItemUnlock";
			this.btnArmorsItemUnlock.Size = new global::System.Drawing.Size(75, 23);
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
			this.gbArmorsEdit.Location = new global::System.Drawing.Point(193, 6);
			this.gbArmorsEdit.Name = "gbArmorsEdit";
			this.gbArmorsEdit.Size = new global::System.Drawing.Size(244, 188);
			this.gbArmorsEdit.TabIndex = 7;
			this.gbArmorsEdit.TabStop = false;
			this.gbArmorsEdit.Text = "Edit Item";
			this.cbArmorsItemBonusType.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbArmorsItemBonusType.FormattingEnabled = true;
			this.cbArmorsItemBonusType.Location = new global::System.Drawing.Point(77, 98);
			this.cbArmorsItemBonusType.Name = "cbArmorsItemBonusType";
			this.cbArmorsItemBonusType.Size = new global::System.Drawing.Size(161, 21);
			this.cbArmorsItemBonusType.TabIndex = 18;
			this.btnArmorsItemUpdate.Location = new global::System.Drawing.Point(7, 150);
			this.btnArmorsItemUpdate.Name = "btnArmorsItemUpdate";
			this.btnArmorsItemUpdate.Size = new global::System.Drawing.Size(75, 23);
			this.btnArmorsItemUpdate.TabIndex = 10;
			this.btnArmorsItemUpdate.Text = "Update";
			this.btnArmorsItemUpdate.UseVisualStyleBackColor = true;
			this.label21.AutoSize = true;
			this.label21.Location = new global::System.Drawing.Point(4, 127);
			this.label21.Name = "label21";
			this.label21.Size = new global::System.Drawing.Size(67, 13);
			this.label21.TabIndex = 9;
			this.label21.Text = "Bonus Value";
			this.txtArmorsItemBonusValue.Location = new global::System.Drawing.Point(77, 124);
			this.txtArmorsItemBonusValue.Name = "txtArmorsItemBonusValue";
			this.txtArmorsItemBonusValue.Size = new global::System.Drawing.Size(161, 20);
			this.txtArmorsItemBonusValue.TabIndex = 8;
			this.label22.AutoSize = true;
			this.label22.Location = new global::System.Drawing.Point(4, 101);
			this.label22.Name = "label22";
			this.label22.Size = new global::System.Drawing.Size(64, 13);
			this.label22.TabIndex = 7;
			this.label22.Text = "Bonus Type";
			this.txtArmorsItemBonusType.Location = new global::System.Drawing.Point(77, 98);
			this.txtArmorsItemBonusType.Name = "txtArmorsItemBonusType";
			this.txtArmorsItemBonusType.Size = new global::System.Drawing.Size(161, 20);
			this.txtArmorsItemBonusType.TabIndex = 6;
			this.label23.AutoSize = true;
			this.label23.Location = new global::System.Drawing.Point(4, 22);
			this.label23.Name = "label23";
			this.label23.Size = new global::System.Drawing.Size(35, 13);
			this.label23.TabIndex = 5;
			this.label23.Text = "Name";
			this.cbArmorsItemName.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbArmorsItemName.FormattingEnabled = true;
			this.cbArmorsItemName.Location = new global::System.Drawing.Point(77, 19);
			this.cbArmorsItemName.Name = "cbArmorsItemName";
			this.cbArmorsItemName.Size = new global::System.Drawing.Size(161, 21);
			this.cbArmorsItemName.TabIndex = 4;
			this.label24.AutoSize = true;
			this.label24.Location = new global::System.Drawing.Point(4, 75);
			this.label24.Name = "label24";
			this.label24.Size = new global::System.Drawing.Size(46, 13);
			this.label24.TabIndex = 3;
			this.label24.Text = "Qt / Dur";
			this.txtArmorsItemQtDur.Location = new global::System.Drawing.Point(77, 72);
			this.txtArmorsItemQtDur.Name = "txtArmorsItemQtDur";
			this.txtArmorsItemQtDur.Size = new global::System.Drawing.Size(161, 20);
			this.txtArmorsItemQtDur.TabIndex = 2;
			this.label25.AutoSize = true;
			this.label25.Location = new global::System.Drawing.Point(4, 49);
			this.label25.Name = "label25";
			this.label25.Size = new global::System.Drawing.Size(18, 13);
			this.label25.TabIndex = 1;
			this.label25.Text = "ID";
			this.txtArmorsItemID.Location = new global::System.Drawing.Point(77, 46);
			this.txtArmorsItemID.Name = "txtArmorsItemID";
			this.txtArmorsItemID.Size = new global::System.Drawing.Size(161, 20);
			this.txtArmorsItemID.TabIndex = 0;
			this.lstArmors.FormattingEnabled = true;
			this.lstArmors.Location = new global::System.Drawing.Point(6, 6);
			this.lstArmors.Name = "lstArmors";
			this.lstArmors.Size = new global::System.Drawing.Size(181, 225);
			this.lstArmors.TabIndex = 6;
			this.tabPage6.Controls.Add(this.btnMaterialsItemUnlock);
			this.tabPage6.Controls.Add(this.gbMaterialsEdit);
			this.tabPage6.Controls.Add(this.lstMaterials);
			this.tabPage6.Location = new global::System.Drawing.Point(4, 22);
			this.tabPage6.Name = "tabPage6";
			this.tabPage6.Padding = new global::System.Windows.Forms.Padding(3);
			this.tabPage6.Size = new global::System.Drawing.Size(476, 241);
			this.tabPage6.TabIndex = 5;
			this.tabPage6.Text = "Materials";
			this.tabPage6.UseVisualStyleBackColor = true;
			this.btnMaterialsItemUnlock.Location = new global::System.Drawing.Point(362, 200);
			this.btnMaterialsItemUnlock.Name = "btnMaterialsItemUnlock";
			this.btnMaterialsItemUnlock.Size = new global::System.Drawing.Size(75, 23);
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
			this.gbMaterialsEdit.Location = new global::System.Drawing.Point(193, 6);
			this.gbMaterialsEdit.Name = "gbMaterialsEdit";
			this.gbMaterialsEdit.Size = new global::System.Drawing.Size(244, 188);
			this.gbMaterialsEdit.TabIndex = 9;
			this.gbMaterialsEdit.TabStop = false;
			this.gbMaterialsEdit.Text = "Edit Item";
			this.cbMaterialsItemBonusType.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbMaterialsItemBonusType.FormattingEnabled = true;
			this.cbMaterialsItemBonusType.Location = new global::System.Drawing.Point(77, 98);
			this.cbMaterialsItemBonusType.Name = "cbMaterialsItemBonusType";
			this.cbMaterialsItemBonusType.Size = new global::System.Drawing.Size(161, 21);
			this.cbMaterialsItemBonusType.TabIndex = 18;
			this.btnMaterialsItemUpdate.Location = new global::System.Drawing.Point(7, 150);
			this.btnMaterialsItemUpdate.Name = "btnMaterialsItemUpdate";
			this.btnMaterialsItemUpdate.Size = new global::System.Drawing.Size(75, 23);
			this.btnMaterialsItemUpdate.TabIndex = 10;
			this.btnMaterialsItemUpdate.Text = "Update";
			this.btnMaterialsItemUpdate.UseVisualStyleBackColor = true;
			this.label26.AutoSize = true;
			this.label26.Location = new global::System.Drawing.Point(4, 127);
			this.label26.Name = "label26";
			this.label26.Size = new global::System.Drawing.Size(67, 13);
			this.label26.TabIndex = 9;
			this.label26.Text = "Bonus Value";
			this.txtMaterialsItemBonusValue.Location = new global::System.Drawing.Point(77, 124);
			this.txtMaterialsItemBonusValue.Name = "txtMaterialsItemBonusValue";
			this.txtMaterialsItemBonusValue.Size = new global::System.Drawing.Size(161, 20);
			this.txtMaterialsItemBonusValue.TabIndex = 8;
			this.label27.AutoSize = true;
			this.label27.Location = new global::System.Drawing.Point(4, 101);
			this.label27.Name = "label27";
			this.label27.Size = new global::System.Drawing.Size(64, 13);
			this.label27.TabIndex = 7;
			this.label27.Text = "Bonus Type";
			this.txtMaterialsItemBonusType.Location = new global::System.Drawing.Point(77, 98);
			this.txtMaterialsItemBonusType.Name = "txtMaterialsItemBonusType";
			this.txtMaterialsItemBonusType.Size = new global::System.Drawing.Size(161, 20);
			this.txtMaterialsItemBonusType.TabIndex = 6;
			this.label28.AutoSize = true;
			this.label28.Location = new global::System.Drawing.Point(4, 22);
			this.label28.Name = "label28";
			this.label28.Size = new global::System.Drawing.Size(35, 13);
			this.label28.TabIndex = 5;
			this.label28.Text = "Name";
			this.cbMaterialsItemName.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbMaterialsItemName.FormattingEnabled = true;
			this.cbMaterialsItemName.Location = new global::System.Drawing.Point(77, 19);
			this.cbMaterialsItemName.Name = "cbMaterialsItemName";
			this.cbMaterialsItemName.Size = new global::System.Drawing.Size(161, 21);
			this.cbMaterialsItemName.TabIndex = 4;
			this.label29.AutoSize = true;
			this.label29.Location = new global::System.Drawing.Point(4, 75);
			this.label29.Name = "label29";
			this.label29.Size = new global::System.Drawing.Size(46, 13);
			this.label29.TabIndex = 3;
			this.label29.Text = "Qt / Dur";
			this.txtMaterialsItemQtDur.Location = new global::System.Drawing.Point(77, 72);
			this.txtMaterialsItemQtDur.Name = "txtMaterialsItemQtDur";
			this.txtMaterialsItemQtDur.Size = new global::System.Drawing.Size(161, 20);
			this.txtMaterialsItemQtDur.TabIndex = 2;
			this.label30.AutoSize = true;
			this.label30.Location = new global::System.Drawing.Point(4, 49);
			this.label30.Name = "label30";
			this.label30.Size = new global::System.Drawing.Size(18, 13);
			this.label30.TabIndex = 1;
			this.label30.Text = "ID";
			this.txtMaterialsItemID.Location = new global::System.Drawing.Point(77, 46);
			this.txtMaterialsItemID.Name = "txtMaterialsItemID";
			this.txtMaterialsItemID.Size = new global::System.Drawing.Size(161, 20);
			this.txtMaterialsItemID.TabIndex = 0;
			this.lstMaterials.FormattingEnabled = true;
			this.lstMaterials.Location = new global::System.Drawing.Point(6, 6);
			this.lstMaterials.Name = "lstMaterials";
			this.lstMaterials.Size = new global::System.Drawing.Size(181, 225);
			this.lstMaterials.TabIndex = 8;
			this.tabPage7.Controls.Add(this.btnFoodItemUnlock);
			this.tabPage7.Controls.Add(this.gbFoodEdit);
			this.tabPage7.Controls.Add(this.lstFood);
			this.tabPage7.Location = new global::System.Drawing.Point(4, 22);
			this.tabPage7.Name = "tabPage7";
			this.tabPage7.Padding = new global::System.Windows.Forms.Padding(3);
			this.tabPage7.Size = new global::System.Drawing.Size(476, 241);
			this.tabPage7.TabIndex = 6;
			this.tabPage7.Text = "Food";
			this.tabPage7.UseVisualStyleBackColor = true;
			this.btnFoodItemUnlock.Location = new global::System.Drawing.Point(362, 200);
			this.btnFoodItemUnlock.Name = "btnFoodItemUnlock";
			this.btnFoodItemUnlock.Size = new global::System.Drawing.Size(75, 23);
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
			this.gbFoodEdit.Location = new global::System.Drawing.Point(193, 6);
			this.gbFoodEdit.Name = "gbFoodEdit";
			this.gbFoodEdit.Size = new global::System.Drawing.Size(244, 188);
			this.gbFoodEdit.TabIndex = 11;
			this.gbFoodEdit.TabStop = false;
			this.gbFoodEdit.Text = "Edit Item";
			this.cbFoodItemBonusType.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbFoodItemBonusType.FormattingEnabled = true;
			this.cbFoodItemBonusType.Location = new global::System.Drawing.Point(77, 98);
			this.cbFoodItemBonusType.Name = "cbFoodItemBonusType";
			this.cbFoodItemBonusType.Size = new global::System.Drawing.Size(161, 21);
			this.cbFoodItemBonusType.TabIndex = 18;
			this.btnFoodItemUpdate.Location = new global::System.Drawing.Point(7, 150);
			this.btnFoodItemUpdate.Name = "btnFoodItemUpdate";
			this.btnFoodItemUpdate.Size = new global::System.Drawing.Size(75, 23);
			this.btnFoodItemUpdate.TabIndex = 10;
			this.btnFoodItemUpdate.Text = "Update";
			this.btnFoodItemUpdate.UseVisualStyleBackColor = true;
			this.label31.AutoSize = true;
			this.label31.Location = new global::System.Drawing.Point(4, 127);
			this.label31.Name = "label31";
			this.label31.Size = new global::System.Drawing.Size(67, 13);
			this.label31.TabIndex = 9;
			this.label31.Text = "Bonus Value";
			this.txtFoodItemBonusValue.Location = new global::System.Drawing.Point(77, 124);
			this.txtFoodItemBonusValue.Name = "txtFoodItemBonusValue";
			this.txtFoodItemBonusValue.Size = new global::System.Drawing.Size(161, 20);
			this.txtFoodItemBonusValue.TabIndex = 8;
			this.label32.AutoSize = true;
			this.label32.Location = new global::System.Drawing.Point(4, 101);
			this.label32.Name = "label32";
			this.label32.Size = new global::System.Drawing.Size(64, 13);
			this.label32.TabIndex = 7;
			this.label32.Text = "Bonus Type";
			this.txtFoodItemBonusType.Location = new global::System.Drawing.Point(77, 98);
			this.txtFoodItemBonusType.Name = "txtFoodItemBonusType";
			this.txtFoodItemBonusType.Size = new global::System.Drawing.Size(161, 20);
			this.txtFoodItemBonusType.TabIndex = 6;
			this.label33.AutoSize = true;
			this.label33.Location = new global::System.Drawing.Point(4, 22);
			this.label33.Name = "label33";
			this.label33.Size = new global::System.Drawing.Size(35, 13);
			this.label33.TabIndex = 5;
			this.label33.Text = "Name";
			this.cbFoodItemName.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbFoodItemName.FormattingEnabled = true;
			this.cbFoodItemName.Location = new global::System.Drawing.Point(77, 19);
			this.cbFoodItemName.Name = "cbFoodItemName";
			this.cbFoodItemName.Size = new global::System.Drawing.Size(161, 21);
			this.cbFoodItemName.TabIndex = 4;
			this.label34.AutoSize = true;
			this.label34.Location = new global::System.Drawing.Point(4, 75);
			this.label34.Name = "label34";
			this.label34.Size = new global::System.Drawing.Size(46, 13);
			this.label34.TabIndex = 3;
			this.label34.Text = "Qt / Dur";
			this.txtFoodItemQtDur.Location = new global::System.Drawing.Point(77, 72);
			this.txtFoodItemQtDur.Name = "txtFoodItemQtDur";
			this.txtFoodItemQtDur.Size = new global::System.Drawing.Size(161, 20);
			this.txtFoodItemQtDur.TabIndex = 2;
			this.label35.AutoSize = true;
			this.label35.Location = new global::System.Drawing.Point(4, 49);
			this.label35.Name = "label35";
			this.label35.Size = new global::System.Drawing.Size(18, 13);
			this.label35.TabIndex = 1;
			this.label35.Text = "ID";
			this.txtFoodItemID.Location = new global::System.Drawing.Point(77, 46);
			this.txtFoodItemID.Name = "txtFoodItemID";
			this.txtFoodItemID.Size = new global::System.Drawing.Size(161, 20);
			this.txtFoodItemID.TabIndex = 0;
			this.lstFood.FormattingEnabled = true;
			this.lstFood.Location = new global::System.Drawing.Point(6, 6);
			this.lstFood.Name = "lstFood";
			this.lstFood.Size = new global::System.Drawing.Size(181, 225);
			this.lstFood.TabIndex = 10;
			this.tabPage8.Controls.Add(this.btnOtherItemUnlock);
			this.tabPage8.Controls.Add(this.gbOtherEdit);
			this.tabPage8.Controls.Add(this.lstOther);
			this.tabPage8.Location = new global::System.Drawing.Point(4, 22);
			this.tabPage8.Name = "tabPage8";
			this.tabPage8.Padding = new global::System.Windows.Forms.Padding(3);
			this.tabPage8.Size = new global::System.Drawing.Size(476, 241);
			this.tabPage8.TabIndex = 7;
			this.tabPage8.Text = "Other";
			this.tabPage8.UseVisualStyleBackColor = true;
			this.btnOtherItemUnlock.Location = new global::System.Drawing.Point(362, 200);
			this.btnOtherItemUnlock.Name = "btnOtherItemUnlock";
			this.btnOtherItemUnlock.Size = new global::System.Drawing.Size(75, 23);
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
			this.gbOtherEdit.Location = new global::System.Drawing.Point(193, 6);
			this.gbOtherEdit.Name = "gbOtherEdit";
			this.gbOtherEdit.Size = new global::System.Drawing.Size(244, 188);
			this.gbOtherEdit.TabIndex = 13;
			this.gbOtherEdit.TabStop = false;
			this.gbOtherEdit.Text = "Edit Item";
			this.cbOtherItemBonusType.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbOtherItemBonusType.FormattingEnabled = true;
			this.cbOtherItemBonusType.Location = new global::System.Drawing.Point(77, 98);
			this.cbOtherItemBonusType.Name = "cbOtherItemBonusType";
			this.cbOtherItemBonusType.Size = new global::System.Drawing.Size(161, 21);
			this.cbOtherItemBonusType.TabIndex = 18;
			this.btnOtherItemUpdate.Location = new global::System.Drawing.Point(7, 150);
			this.btnOtherItemUpdate.Name = "btnOtherItemUpdate";
			this.btnOtherItemUpdate.Size = new global::System.Drawing.Size(75, 23);
			this.btnOtherItemUpdate.TabIndex = 10;
			this.btnOtherItemUpdate.Text = "Update";
			this.btnOtherItemUpdate.UseVisualStyleBackColor = true;
			this.label36.AutoSize = true;
			this.label36.Location = new global::System.Drawing.Point(4, 127);
			this.label36.Name = "label36";
			this.label36.Size = new global::System.Drawing.Size(67, 13);
			this.label36.TabIndex = 9;
			this.label36.Text = "Bonus Value";
			this.txtOtherItemBonusValue.Location = new global::System.Drawing.Point(77, 124);
			this.txtOtherItemBonusValue.Name = "txtOtherItemBonusValue";
			this.txtOtherItemBonusValue.Size = new global::System.Drawing.Size(161, 20);
			this.txtOtherItemBonusValue.TabIndex = 8;
			this.label37.AutoSize = true;
			this.label37.Location = new global::System.Drawing.Point(4, 101);
			this.label37.Name = "label37";
			this.label37.Size = new global::System.Drawing.Size(64, 13);
			this.label37.TabIndex = 7;
			this.label37.Text = "Bonus Type";
			this.txtOtherItemBonusType.Location = new global::System.Drawing.Point(77, 98);
			this.txtOtherItemBonusType.Name = "txtOtherItemBonusType";
			this.txtOtherItemBonusType.Size = new global::System.Drawing.Size(161, 20);
			this.txtOtherItemBonusType.TabIndex = 6;
			this.label38.AutoSize = true;
			this.label38.Location = new global::System.Drawing.Point(4, 22);
			this.label38.Name = "label38";
			this.label38.Size = new global::System.Drawing.Size(35, 13);
			this.label38.TabIndex = 5;
			this.label38.Text = "Name";
			this.cbOtherItemName.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbOtherItemName.FormattingEnabled = true;
			this.cbOtherItemName.Location = new global::System.Drawing.Point(77, 19);
			this.cbOtherItemName.Name = "cbOtherItemName";
			this.cbOtherItemName.Size = new global::System.Drawing.Size(161, 21);
			this.cbOtherItemName.TabIndex = 4;
			this.label39.AutoSize = true;
			this.label39.Location = new global::System.Drawing.Point(4, 75);
			this.label39.Name = "label39";
			this.label39.Size = new global::System.Drawing.Size(46, 13);
			this.label39.TabIndex = 3;
			this.label39.Text = "Qt / Dur";
			this.txtOtherItemQtDur.Location = new global::System.Drawing.Point(77, 72);
			this.txtOtherItemQtDur.Name = "txtOtherItemQtDur";
			this.txtOtherItemQtDur.Size = new global::System.Drawing.Size(161, 20);
			this.txtOtherItemQtDur.TabIndex = 2;
			this.label40.AutoSize = true;
			this.label40.Location = new global::System.Drawing.Point(4, 49);
			this.label40.Name = "label40";
			this.label40.Size = new global::System.Drawing.Size(18, 13);
			this.label40.TabIndex = 1;
			this.label40.Text = "ID";
			this.txtOtherItemID.Location = new global::System.Drawing.Point(77, 46);
			this.txtOtherItemID.Name = "txtOtherItemID";
			this.txtOtherItemID.Size = new global::System.Drawing.Size(161, 20);
			this.txtOtherItemID.TabIndex = 0;
			this.lstOther.FormattingEnabled = true;
			this.lstOther.Location = new global::System.Drawing.Point(6, 6);
			this.lstOther.Name = "lstOther";
			this.lstOther.Size = new global::System.Drawing.Size(181, 225);
			this.lstOther.TabIndex = 12;
			this.tabPage12.Controls.Add(this.gbRupees);
			this.tabPage12.Location = new global::System.Drawing.Point(4, 22);
			this.tabPage12.Name = "tabPage12";
			this.tabPage12.Padding = new global::System.Windows.Forms.Padding(3);
			this.tabPage12.Size = new global::System.Drawing.Size(476, 241);
			this.tabPage12.TabIndex = 8;
			this.tabPage12.Text = "Money";
			this.tabPage12.UseVisualStyleBackColor = true;
			this.gbRupees.Controls.Add(this.btnRefreshRupees);
			this.gbRupees.Controls.Add(this.btnUpdateRupees);
			this.gbRupees.Controls.Add(this.label71);
			this.gbRupees.Controls.Add(this.txtRupees);
			this.gbRupees.Enabled = false;
			this.gbRupees.Location = new global::System.Drawing.Point(7, 6);
			this.gbRupees.Name = "gbRupees";
			this.gbRupees.Size = new global::System.Drawing.Size(180, 71);
			this.gbRupees.TabIndex = 2;
			this.gbRupees.TabStop = false;
			this.gbRupees.Text = "Edit Money (Rupees)";
			this.btnRefreshRupees.Location = new global::System.Drawing.Point(6, 42);
			this.btnRefreshRupees.Name = "btnRefreshRupees";
			this.btnRefreshRupees.Size = new global::System.Drawing.Size(75, 23);
			this.btnRefreshRupees.TabIndex = 11;
			this.btnRefreshRupees.Text = "Refresh";
			this.btnRefreshRupees.UseVisualStyleBackColor = true;
			this.btnUpdateRupees.Location = new global::System.Drawing.Point(99, 42);
			this.btnUpdateRupees.Name = "btnUpdateRupees";
			this.btnUpdateRupees.Size = new global::System.Drawing.Size(75, 23);
			this.btnUpdateRupees.TabIndex = 10;
			this.btnUpdateRupees.Text = "Update";
			this.btnUpdateRupees.UseVisualStyleBackColor = true;
			this.label71.AutoSize = true;
			this.label71.Location = new global::System.Drawing.Point(4, 19);
			this.label71.Name = "label71";
			this.label71.Size = new global::System.Drawing.Size(44, 13);
			this.label71.TabIndex = 1;
			this.label71.Text = "Rupees";
			this.txtRupees.Location = new global::System.Drawing.Point(54, 16);
			this.txtRupees.Name = "txtRupees";
			this.txtRupees.Size = new global::System.Drawing.Size(120, 20);
			this.txtRupees.TabIndex = 0;
			this.tabPage20.Controls.Add(this.gbShieldsSlots);
			this.tabPage20.Controls.Add(this.gbBowsSlots);
			this.tabPage20.Controls.Add(this.gbWeaponsSlots);
			this.tabPage20.Location = new global::System.Drawing.Point(4, 22);
			this.tabPage20.Name = "tabPage20";
			this.tabPage20.Padding = new global::System.Windows.Forms.Padding(3);
			this.tabPage20.Size = new global::System.Drawing.Size(476, 241);
			this.tabPage20.TabIndex = 9;
			this.tabPage20.Text = "Slots";
			this.tabPage20.UseVisualStyleBackColor = true;
			this.gbShieldsSlots.Controls.Add(this.btnRefreshShieldsSlots);
			this.gbShieldsSlots.Controls.Add(this.btnUpdateShieldsSlots);
			this.gbShieldsSlots.Controls.Add(this.label52);
			this.gbShieldsSlots.Controls.Add(this.txtShieldsSlots);
			this.gbShieldsSlots.Enabled = false;
			this.gbShieldsSlots.Location = new global::System.Drawing.Point(7, 155);
			this.gbShieldsSlots.Name = "gbShieldsSlots";
			this.gbShieldsSlots.Size = new global::System.Drawing.Size(180, 71);
			this.gbShieldsSlots.TabIndex = 13;
			this.gbShieldsSlots.TabStop = false;
			this.gbShieldsSlots.Text = "Edit Shields Slots";
			this.btnRefreshShieldsSlots.Location = new global::System.Drawing.Point(6, 42);
			this.btnRefreshShieldsSlots.Name = "btnRefreshShieldsSlots";
			this.btnRefreshShieldsSlots.Size = new global::System.Drawing.Size(75, 23);
			this.btnRefreshShieldsSlots.TabIndex = 11;
			this.btnRefreshShieldsSlots.Text = "Refresh";
			this.btnRefreshShieldsSlots.UseVisualStyleBackColor = true;
			this.btnRefreshShieldsSlots.Click += new global::System.EventHandler(this.btnRefreshShieldsSlots_Click);
			this.btnUpdateShieldsSlots.Location = new global::System.Drawing.Point(99, 42);
			this.btnUpdateShieldsSlots.Name = "btnUpdateShieldsSlots";
			this.btnUpdateShieldsSlots.Size = new global::System.Drawing.Size(75, 23);
			this.btnUpdateShieldsSlots.TabIndex = 10;
			this.btnUpdateShieldsSlots.Text = "Update";
			this.btnUpdateShieldsSlots.UseVisualStyleBackColor = true;
			this.btnUpdateShieldsSlots.Click += new global::System.EventHandler(this.btnUpdateShieldsSlots_Click);
			this.label52.AutoSize = true;
			this.label52.Location = new global::System.Drawing.Point(4, 19);
			this.label52.Name = "label52";
			this.label52.Size = new global::System.Drawing.Size(30, 13);
			this.label52.TabIndex = 1;
			this.label52.Text = "Slots";
			this.txtShieldsSlots.Location = new global::System.Drawing.Point(54, 16);
			this.txtShieldsSlots.Name = "txtShieldsSlots";
			this.txtShieldsSlots.Size = new global::System.Drawing.Size(120, 20);
			this.txtShieldsSlots.TabIndex = 0;
			this.gbBowsSlots.Controls.Add(this.btnRefreshBowsSlots);
			this.gbBowsSlots.Controls.Add(this.btnUpdateBowsSlots);
			this.gbBowsSlots.Controls.Add(this.label51);
			this.gbBowsSlots.Controls.Add(this.txtBowsSlots);
			this.gbBowsSlots.Enabled = false;
			this.gbBowsSlots.Location = new global::System.Drawing.Point(7, 81);
			this.gbBowsSlots.Name = "gbBowsSlots";
			this.gbBowsSlots.Size = new global::System.Drawing.Size(180, 71);
			this.gbBowsSlots.TabIndex = 12;
			this.gbBowsSlots.TabStop = false;
			this.gbBowsSlots.Text = "Edit Bows Slots";
			this.btnRefreshBowsSlots.Location = new global::System.Drawing.Point(6, 42);
			this.btnRefreshBowsSlots.Name = "btnRefreshBowsSlots";
			this.btnRefreshBowsSlots.Size = new global::System.Drawing.Size(75, 23);
			this.btnRefreshBowsSlots.TabIndex = 11;
			this.btnRefreshBowsSlots.Text = "Refresh";
			this.btnRefreshBowsSlots.UseVisualStyleBackColor = true;
			this.btnRefreshBowsSlots.Click += new global::System.EventHandler(this.btnRefreshBowsSlots_Click);
			this.btnUpdateBowsSlots.Location = new global::System.Drawing.Point(99, 42);
			this.btnUpdateBowsSlots.Name = "btnUpdateBowsSlots";
			this.btnUpdateBowsSlots.Size = new global::System.Drawing.Size(75, 23);
			this.btnUpdateBowsSlots.TabIndex = 10;
			this.btnUpdateBowsSlots.Text = "Update";
			this.btnUpdateBowsSlots.UseVisualStyleBackColor = true;
			this.btnUpdateBowsSlots.Click += new global::System.EventHandler(this.btnUpdateBowsSlots_Click);
			this.label51.AutoSize = true;
			this.label51.Location = new global::System.Drawing.Point(4, 19);
			this.label51.Name = "label51";
			this.label51.Size = new global::System.Drawing.Size(30, 13);
			this.label51.TabIndex = 1;
			this.label51.Text = "Slots";
			this.txtBowsSlots.Location = new global::System.Drawing.Point(54, 16);
			this.txtBowsSlots.Name = "txtBowsSlots";
			this.txtBowsSlots.Size = new global::System.Drawing.Size(120, 20);
			this.txtBowsSlots.TabIndex = 0;
			this.gbWeaponsSlots.Controls.Add(this.btnRefreshWeaponsSlots);
			this.gbWeaponsSlots.Controls.Add(this.btnUpdateWeaponsSlots);
			this.gbWeaponsSlots.Controls.Add(this.label50);
			this.gbWeaponsSlots.Controls.Add(this.txtWeaponsSlots);
			this.gbWeaponsSlots.Enabled = false;
			this.gbWeaponsSlots.Location = new global::System.Drawing.Point(7, 6);
			this.gbWeaponsSlots.Name = "gbWeaponsSlots";
			this.gbWeaponsSlots.Size = new global::System.Drawing.Size(180, 71);
			this.gbWeaponsSlots.TabIndex = 3;
			this.gbWeaponsSlots.TabStop = false;
			this.gbWeaponsSlots.Text = "Edit Weapons Slots";
			this.btnRefreshWeaponsSlots.Location = new global::System.Drawing.Point(6, 42);
			this.btnRefreshWeaponsSlots.Name = "btnRefreshWeaponsSlots";
			this.btnRefreshWeaponsSlots.Size = new global::System.Drawing.Size(75, 23);
			this.btnRefreshWeaponsSlots.TabIndex = 11;
			this.btnRefreshWeaponsSlots.Text = "Refresh";
			this.btnRefreshWeaponsSlots.UseVisualStyleBackColor = true;
			this.btnRefreshWeaponsSlots.Click += new global::System.EventHandler(this.btnRefreshWeaponsSlots_Click);
			this.btnUpdateWeaponsSlots.Location = new global::System.Drawing.Point(99, 42);
			this.btnUpdateWeaponsSlots.Name = "btnUpdateWeaponsSlots";
			this.btnUpdateWeaponsSlots.Size = new global::System.Drawing.Size(75, 23);
			this.btnUpdateWeaponsSlots.TabIndex = 10;
			this.btnUpdateWeaponsSlots.Text = "Update";
			this.btnUpdateWeaponsSlots.UseVisualStyleBackColor = true;
			this.btnUpdateWeaponsSlots.Click += new global::System.EventHandler(this.btnUpdateWeaponsSlots_Click);
			this.label50.AutoSize = true;
			this.label50.Location = new global::System.Drawing.Point(4, 19);
			this.label50.Name = "label50";
			this.label50.Size = new global::System.Drawing.Size(30, 13);
			this.label50.TabIndex = 1;
			this.label50.Text = "Slots";
			this.txtWeaponsSlots.Location = new global::System.Drawing.Point(54, 16);
			this.txtWeaponsSlots.Name = "txtWeaponsSlots";
			this.txtWeaponsSlots.Size = new global::System.Drawing.Size(120, 20);
			this.txtWeaponsSlots.TabIndex = 0;
			this.btnScan.Location = new global::System.Drawing.Point(12, 12);
			this.btnScan.Name = "btnScan";
			this.btnScan.Size = new global::System.Drawing.Size(85, 23);
			this.btnScan.TabIndex = 3;
			this.btnScan.Text = "Scan Memory";
			this.btnScan.UseVisualStyleBackColor = true;
			this.btnScan.Click += new global::System.EventHandler(this.btnScan_Click);
			this.lblScan.AutoSize = true;
			this.lblScan.Location = new global::System.Drawing.Point(103, 17);
			this.lblScan.Name = "lblScan";
			this.lblScan.Size = new global::System.Drawing.Size(110, 13);
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
			this.tabActions.Location = new global::System.Drawing.Point(502, 41);
			this.tabActions.Name = "tabActions";
			this.tabActions.SelectedIndex = 0;
			this.tabActions.Size = new global::System.Drawing.Size(507, 267);
			this.tabActions.TabIndex = 1;
			this.tabPage11.Controls.Add(this.groupBox13);
			this.tabPage11.Controls.Add(this.groupBox10);
			this.tabPage11.Location = new global::System.Drawing.Point(4, 22);
			this.tabPage11.Name = "tabPage11";
			this.tabPage11.Padding = new global::System.Windows.Forms.Padding(3);
			this.tabPage11.Size = new global::System.Drawing.Size(499, 241);
			this.tabPage11.TabIndex = 1;
			this.tabPage11.Text = "Weapons";
			this.tabPage11.UseVisualStyleBackColor = true;
			this.groupBox13.Controls.Add(this.lstWeaponsFilter);
			this.groupBox13.Controls.Add(this.optionWeaponsFilterList);
			this.groupBox13.Controls.Add(this.optionWeaponsNoFilter);
			this.groupBox13.Location = new global::System.Drawing.Point(183, 6);
			this.groupBox13.Name = "groupBox13";
			this.groupBox13.Size = new global::System.Drawing.Size(176, 229);
			this.groupBox13.TabIndex = 28;
			this.groupBox13.TabStop = false;
			this.groupBox13.Text = "Restore Filter";
			this.lstWeaponsFilter.FormattingEnabled = true;
			this.lstWeaponsFilter.Location = new global::System.Drawing.Point(8, 71);
			this.lstWeaponsFilter.Name = "lstWeaponsFilter";
			this.lstWeaponsFilter.Size = new global::System.Drawing.Size(162, 147);
			this.lstWeaponsFilter.TabIndex = 2;
			this.optionWeaponsFilterList.AutoSize = true;
			this.optionWeaponsFilterList.Location = new global::System.Drawing.Point(8, 42);
			this.optionWeaponsFilterList.Name = "optionWeaponsFilterList";
			this.optionWeaponsFilterList.Size = new global::System.Drawing.Size(138, 17);
			this.optionWeaponsFilterList.TabIndex = 1;
			this.optionWeaponsFilterList.Text = "Apply only to items in list";
			this.optionWeaponsFilterList.UseVisualStyleBackColor = true;
			this.optionWeaponsNoFilter.AutoSize = true;
			this.optionWeaponsNoFilter.Checked = true;
			this.optionWeaponsNoFilter.Location = new global::System.Drawing.Point(8, 19);
			this.optionWeaponsNoFilter.Name = "optionWeaponsNoFilter";
			this.optionWeaponsNoFilter.Size = new global::System.Drawing.Size(61, 17);
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
			this.groupBox10.Location = new global::System.Drawing.Point(6, 6);
			this.groupBox10.Name = "groupBox10";
			this.groupBox10.Size = new global::System.Drawing.Size(171, 229);
			this.groupBox10.TabIndex = 24;
			this.groupBox10.TabStop = false;
			this.groupBox10.Text = "Restore Unequipped Weapons";
			this.chkWeaponsUseHotkey.AutoSize = true;
			this.chkWeaponsUseHotkey.Location = new global::System.Drawing.Point(6, 149);
			this.chkWeaponsUseHotkey.Name = "chkWeaponsUseHotkey";
			this.chkWeaponsUseHotkey.Size = new global::System.Drawing.Size(60, 17);
			this.chkWeaponsUseHotkey.TabIndex = 19;
			this.chkWeaponsUseHotkey.Text = "Hotkey";
			this.chkWeaponsUseHotkey.UseVisualStyleBackColor = true;
			this.txtWeaponsHotKey.Location = new global::System.Drawing.Point(95, 145);
			this.txtWeaponsHotKey.Name = "txtWeaponsHotKey";
			this.txtWeaponsHotKey.ReadOnly = true;
			this.txtWeaponsHotKey.Size = new global::System.Drawing.Size(62, 20);
			this.txtWeaponsHotKey.TabIndex = 18;
			this.chkWeaponsDisableWhenDone.AutoSize = true;
			this.chkWeaponsDisableWhenDone.Location = new global::System.Drawing.Point(6, 129);
			this.chkWeaponsDisableWhenDone.Name = "chkWeaponsDisableWhenDone";
			this.chkWeaponsDisableWhenDone.Size = new global::System.Drawing.Size(104, 17);
			this.chkWeaponsDisableWhenDone.TabIndex = 17;
			this.chkWeaponsDisableWhenDone.Text = "Stop when done";
			this.chkWeaponsDisableWhenDone.UseVisualStyleBackColor = true;
			this.chkWeaponsActiveInactive.AutoSize = true;
			this.chkWeaponsActiveInactive.Location = new global::System.Drawing.Point(5, 201);
			this.chkWeaponsActiveInactive.Name = "chkWeaponsActiveInactive";
			this.chkWeaponsActiveInactive.Size = new global::System.Drawing.Size(105, 17);
			this.chkWeaponsActiveInactive.TabIndex = 15;
			this.chkWeaponsActiveInactive.Text = "Active / Inactive";
			this.chkWeaponsActiveInactive.UseVisualStyleBackColor = true;
			this.txtWeaponsMax.Location = new global::System.Drawing.Point(95, 105);
			this.txtWeaponsMax.Name = "txtWeaponsMax";
			this.txtWeaponsMax.Size = new global::System.Drawing.Size(62, 20);
			this.txtWeaponsMax.TabIndex = 13;
			this.label44.AutoSize = true;
			this.label44.Location = new global::System.Drawing.Point(22, 108);
			this.label44.Name = "label44";
			this.label44.Size = new global::System.Drawing.Size(27, 13);
			this.label44.TabIndex = 14;
			this.label44.Text = "Max";
			this.txtWeaponsQuantity.Location = new global::System.Drawing.Point(95, 85);
			this.txtWeaponsQuantity.Name = "txtWeaponsQuantity";
			this.txtWeaponsQuantity.Size = new global::System.Drawing.Size(62, 20);
			this.txtWeaponsQuantity.TabIndex = 11;
			this.label46.AutoSize = true;
			this.label46.Location = new global::System.Drawing.Point(22, 88);
			this.label46.Name = "label46";
			this.label46.Size = new global::System.Drawing.Size(50, 13);
			this.label46.TabIndex = 12;
			this.label46.Text = "Durability";
			this.txtWeaponsTimer.Location = new global::System.Drawing.Point(95, 65);
			this.txtWeaponsTimer.Name = "txtWeaponsTimer";
			this.txtWeaponsTimer.Size = new global::System.Drawing.Size(62, 20);
			this.txtWeaponsTimer.TabIndex = 9;
			this.label47.AutoSize = true;
			this.label47.Location = new global::System.Drawing.Point(22, 68);
			this.label47.Name = "label47";
			this.label47.Size = new global::System.Drawing.Size(59, 13);
			this.label47.TabIndex = 10;
			this.label47.Text = "Timer (sec)";
			this.txtWeaponsFixed.Location = new global::System.Drawing.Point(95, 20);
			this.txtWeaponsFixed.Name = "txtWeaponsFixed";
			this.txtWeaponsFixed.Size = new global::System.Drawing.Size(62, 20);
			this.txtWeaponsFixed.TabIndex = 7;
			this.optionWeaponsTimer.AutoSize = true;
			this.optionWeaponsTimer.Checked = true;
			this.optionWeaponsTimer.Location = new global::System.Drawing.Point(6, 44);
			this.optionWeaponsTimer.Name = "optionWeaponsTimer";
			this.optionWeaponsTimer.Size = new global::System.Drawing.Size(83, 17);
			this.optionWeaponsTimer.TabIndex = 1;
			this.optionWeaponsTimer.TabStop = true;
			this.optionWeaponsTimer.Text = "Timer based";
			this.optionWeaponsTimer.UseVisualStyleBackColor = true;
			this.optionWeaponsFixed.AutoSize = true;
			this.optionWeaponsFixed.Location = new global::System.Drawing.Point(6, 21);
			this.optionWeaponsFixed.Name = "optionWeaponsFixed";
			this.optionWeaponsFixed.Size = new global::System.Drawing.Size(79, 17);
			this.optionWeaponsFixed.TabIndex = 0;
			this.optionWeaponsFixed.Text = "Fixed (Dur.)";
			this.optionWeaponsFixed.UseVisualStyleBackColor = true;
			this.tabPage14.Controls.Add(this.groupBox17);
			this.tabPage14.Controls.Add(this.groupBox18);
			this.tabPage14.Location = new global::System.Drawing.Point(4, 22);
			this.tabPage14.Name = "tabPage14";
			this.tabPage14.Padding = new global::System.Windows.Forms.Padding(3);
			this.tabPage14.Size = new global::System.Drawing.Size(499, 241);
			this.tabPage14.TabIndex = 2;
			this.tabPage14.Text = "Bows";
			this.tabPage14.UseVisualStyleBackColor = true;
			this.groupBox17.Controls.Add(this.lstBowsFilter);
			this.groupBox17.Controls.Add(this.optionBowsFilterList);
			this.groupBox17.Controls.Add(this.optionBowsNoFilter);
			this.groupBox17.Location = new global::System.Drawing.Point(183, 6);
			this.groupBox17.Name = "groupBox17";
			this.groupBox17.Size = new global::System.Drawing.Size(176, 229);
			this.groupBox17.TabIndex = 30;
			this.groupBox17.TabStop = false;
			this.groupBox17.Text = "Restore Filter";
			this.lstBowsFilter.FormattingEnabled = true;
			this.lstBowsFilter.Location = new global::System.Drawing.Point(8, 71);
			this.lstBowsFilter.Name = "lstBowsFilter";
			this.lstBowsFilter.Size = new global::System.Drawing.Size(162, 147);
			this.lstBowsFilter.TabIndex = 2;
			this.optionBowsFilterList.AutoSize = true;
			this.optionBowsFilterList.Location = new global::System.Drawing.Point(8, 42);
			this.optionBowsFilterList.Name = "optionBowsFilterList";
			this.optionBowsFilterList.Size = new global::System.Drawing.Size(138, 17);
			this.optionBowsFilterList.TabIndex = 1;
			this.optionBowsFilterList.Text = "Apply only to items in list";
			this.optionBowsFilterList.UseVisualStyleBackColor = true;
			this.optionBowsNoFilter.AutoSize = true;
			this.optionBowsNoFilter.Checked = true;
			this.optionBowsNoFilter.Location = new global::System.Drawing.Point(8, 19);
			this.optionBowsNoFilter.Name = "optionBowsNoFilter";
			this.optionBowsNoFilter.Size = new global::System.Drawing.Size(61, 17);
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
			this.groupBox18.Location = new global::System.Drawing.Point(6, 6);
			this.groupBox18.Name = "groupBox18";
			this.groupBox18.Size = new global::System.Drawing.Size(171, 229);
			this.groupBox18.TabIndex = 29;
			this.groupBox18.TabStop = false;
			this.groupBox18.Text = "Restore Unequipped Bows";
			this.chkBowsUseHotkey.AutoSize = true;
			this.chkBowsUseHotkey.Location = new global::System.Drawing.Point(6, 149);
			this.chkBowsUseHotkey.Name = "chkBowsUseHotkey";
			this.chkBowsUseHotkey.Size = new global::System.Drawing.Size(60, 17);
			this.chkBowsUseHotkey.TabIndex = 19;
			this.chkBowsUseHotkey.Text = "Hotkey";
			this.chkBowsUseHotkey.UseVisualStyleBackColor = true;
			this.txtBowsHotKey.Location = new global::System.Drawing.Point(95, 145);
			this.txtBowsHotKey.Name = "txtBowsHotKey";
			this.txtBowsHotKey.ReadOnly = true;
			this.txtBowsHotKey.Size = new global::System.Drawing.Size(62, 20);
			this.txtBowsHotKey.TabIndex = 18;
			this.chkBowsDisableWhenDone.AutoSize = true;
			this.chkBowsDisableWhenDone.Location = new global::System.Drawing.Point(6, 129);
			this.chkBowsDisableWhenDone.Name = "chkBowsDisableWhenDone";
			this.chkBowsDisableWhenDone.Size = new global::System.Drawing.Size(104, 17);
			this.chkBowsDisableWhenDone.TabIndex = 17;
			this.chkBowsDisableWhenDone.Text = "Stop when done";
			this.chkBowsDisableWhenDone.UseVisualStyleBackColor = true;
			this.chkBowsActiveInactive.AutoSize = true;
			this.chkBowsActiveInactive.Location = new global::System.Drawing.Point(5, 201);
			this.chkBowsActiveInactive.Name = "chkBowsActiveInactive";
			this.chkBowsActiveInactive.Size = new global::System.Drawing.Size(105, 17);
			this.chkBowsActiveInactive.TabIndex = 15;
			this.chkBowsActiveInactive.Text = "Active / Inactive";
			this.chkBowsActiveInactive.UseVisualStyleBackColor = true;
			this.txtBowsMax.Location = new global::System.Drawing.Point(95, 105);
			this.txtBowsMax.Name = "txtBowsMax";
			this.txtBowsMax.Size = new global::System.Drawing.Size(62, 20);
			this.txtBowsMax.TabIndex = 13;
			this.label54.AutoSize = true;
			this.label54.Location = new global::System.Drawing.Point(22, 108);
			this.label54.Name = "label54";
			this.label54.Size = new global::System.Drawing.Size(27, 13);
			this.label54.TabIndex = 14;
			this.label54.Text = "Max";
			this.txtBowsQuantity.Location = new global::System.Drawing.Point(95, 85);
			this.txtBowsQuantity.Name = "txtBowsQuantity";
			this.txtBowsQuantity.Size = new global::System.Drawing.Size(62, 20);
			this.txtBowsQuantity.TabIndex = 11;
			this.label56.AutoSize = true;
			this.label56.Location = new global::System.Drawing.Point(22, 88);
			this.label56.Name = "label56";
			this.label56.Size = new global::System.Drawing.Size(50, 13);
			this.label56.TabIndex = 12;
			this.label56.Text = "Durability";
			this.txtBowsTimer.Location = new global::System.Drawing.Point(95, 65);
			this.txtBowsTimer.Name = "txtBowsTimer";
			this.txtBowsTimer.Size = new global::System.Drawing.Size(62, 20);
			this.txtBowsTimer.TabIndex = 9;
			this.label60.AutoSize = true;
			this.label60.Location = new global::System.Drawing.Point(22, 68);
			this.label60.Name = "label60";
			this.label60.Size = new global::System.Drawing.Size(59, 13);
			this.label60.TabIndex = 10;
			this.label60.Text = "Timer (sec)";
			this.txtBowsFixed.Location = new global::System.Drawing.Point(95, 20);
			this.txtBowsFixed.Name = "txtBowsFixed";
			this.txtBowsFixed.Size = new global::System.Drawing.Size(62, 20);
			this.txtBowsFixed.TabIndex = 7;
			this.optionBowsTimer.AutoSize = true;
			this.optionBowsTimer.Checked = true;
			this.optionBowsTimer.Location = new global::System.Drawing.Point(6, 44);
			this.optionBowsTimer.Name = "optionBowsTimer";
			this.optionBowsTimer.Size = new global::System.Drawing.Size(83, 17);
			this.optionBowsTimer.TabIndex = 1;
			this.optionBowsTimer.TabStop = true;
			this.optionBowsTimer.Text = "Timer based";
			this.optionBowsTimer.UseVisualStyleBackColor = true;
			this.optionBowsFixed.AutoSize = true;
			this.optionBowsFixed.Location = new global::System.Drawing.Point(6, 21);
			this.optionBowsFixed.Name = "optionBowsFixed";
			this.optionBowsFixed.Size = new global::System.Drawing.Size(79, 17);
			this.optionBowsFixed.TabIndex = 0;
			this.optionBowsFixed.Text = "Fixed (Dur.)";
			this.optionBowsFixed.UseVisualStyleBackColor = true;
			this.tabPage15.Controls.Add(this.groupBox20);
			this.tabPage15.Controls.Add(this.groupBox21);
			this.tabPage15.Location = new global::System.Drawing.Point(4, 22);
			this.tabPage15.Name = "tabPage15";
			this.tabPage15.Padding = new global::System.Windows.Forms.Padding(3);
			this.tabPage15.Size = new global::System.Drawing.Size(499, 241);
			this.tabPage15.TabIndex = 3;
			this.tabPage15.Text = "Shields";
			this.tabPage15.UseVisualStyleBackColor = true;
			this.groupBox20.Controls.Add(this.lstShieldsFilter);
			this.groupBox20.Controls.Add(this.optionShieldsFilterList);
			this.groupBox20.Controls.Add(this.optionShieldsNoFilter);
			this.groupBox20.Location = new global::System.Drawing.Point(183, 6);
			this.groupBox20.Name = "groupBox20";
			this.groupBox20.Size = new global::System.Drawing.Size(176, 229);
			this.groupBox20.TabIndex = 30;
			this.groupBox20.TabStop = false;
			this.groupBox20.Text = "Restore Filter";
			this.lstShieldsFilter.FormattingEnabled = true;
			this.lstShieldsFilter.Location = new global::System.Drawing.Point(8, 71);
			this.lstShieldsFilter.Name = "lstShieldsFilter";
			this.lstShieldsFilter.Size = new global::System.Drawing.Size(162, 147);
			this.lstShieldsFilter.TabIndex = 2;
			this.optionShieldsFilterList.AutoSize = true;
			this.optionShieldsFilterList.Location = new global::System.Drawing.Point(8, 42);
			this.optionShieldsFilterList.Name = "optionShieldsFilterList";
			this.optionShieldsFilterList.Size = new global::System.Drawing.Size(138, 17);
			this.optionShieldsFilterList.TabIndex = 1;
			this.optionShieldsFilterList.Text = "Apply only to items in list";
			this.optionShieldsFilterList.UseVisualStyleBackColor = true;
			this.optionShieldsNoFilter.AutoSize = true;
			this.optionShieldsNoFilter.Checked = true;
			this.optionShieldsNoFilter.Location = new global::System.Drawing.Point(8, 19);
			this.optionShieldsNoFilter.Name = "optionShieldsNoFilter";
			this.optionShieldsNoFilter.Size = new global::System.Drawing.Size(61, 17);
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
			this.groupBox21.Location = new global::System.Drawing.Point(6, 6);
			this.groupBox21.Name = "groupBox21";
			this.groupBox21.Size = new global::System.Drawing.Size(171, 229);
			this.groupBox21.TabIndex = 29;
			this.groupBox21.TabStop = false;
			this.groupBox21.Text = "Restore Unequipped Shields";
			this.chkShieldsUseHotkey.AutoSize = true;
			this.chkShieldsUseHotkey.Location = new global::System.Drawing.Point(6, 149);
			this.chkShieldsUseHotkey.Name = "chkShieldsUseHotkey";
			this.chkShieldsUseHotkey.Size = new global::System.Drawing.Size(60, 17);
			this.chkShieldsUseHotkey.TabIndex = 19;
			this.chkShieldsUseHotkey.Text = "Hotkey";
			this.chkShieldsUseHotkey.UseVisualStyleBackColor = true;
			this.txtShieldsHotKey.Location = new global::System.Drawing.Point(95, 145);
			this.txtShieldsHotKey.Name = "txtShieldsHotKey";
			this.txtShieldsHotKey.ReadOnly = true;
			this.txtShieldsHotKey.Size = new global::System.Drawing.Size(62, 20);
			this.txtShieldsHotKey.TabIndex = 18;
			this.chkShieldsDisableWhenDone.AutoSize = true;
			this.chkShieldsDisableWhenDone.Location = new global::System.Drawing.Point(6, 129);
			this.chkShieldsDisableWhenDone.Name = "chkShieldsDisableWhenDone";
			this.chkShieldsDisableWhenDone.Size = new global::System.Drawing.Size(104, 17);
			this.chkShieldsDisableWhenDone.TabIndex = 17;
			this.chkShieldsDisableWhenDone.Text = "Stop when done";
			this.chkShieldsDisableWhenDone.UseVisualStyleBackColor = true;
			this.chkShieldsActiveInactive.AutoSize = true;
			this.chkShieldsActiveInactive.Location = new global::System.Drawing.Point(5, 201);
			this.chkShieldsActiveInactive.Name = "chkShieldsActiveInactive";
			this.chkShieldsActiveInactive.Size = new global::System.Drawing.Size(105, 17);
			this.chkShieldsActiveInactive.TabIndex = 15;
			this.chkShieldsActiveInactive.Text = "Active / Inactive";
			this.chkShieldsActiveInactive.UseVisualStyleBackColor = true;
			this.txtShieldsMax.Location = new global::System.Drawing.Point(95, 105);
			this.txtShieldsMax.Name = "txtShieldsMax";
			this.txtShieldsMax.Size = new global::System.Drawing.Size(62, 20);
			this.txtShieldsMax.TabIndex = 13;
			this.label61.AutoSize = true;
			this.label61.Location = new global::System.Drawing.Point(22, 108);
			this.label61.Name = "label61";
			this.label61.Size = new global::System.Drawing.Size(27, 13);
			this.label61.TabIndex = 14;
			this.label61.Text = "Max";
			this.txtShieldsQuantity.Location = new global::System.Drawing.Point(95, 85);
			this.txtShieldsQuantity.Name = "txtShieldsQuantity";
			this.txtShieldsQuantity.Size = new global::System.Drawing.Size(62, 20);
			this.txtShieldsQuantity.TabIndex = 11;
			this.label62.AutoSize = true;
			this.label62.Location = new global::System.Drawing.Point(22, 88);
			this.label62.Name = "label62";
			this.label62.Size = new global::System.Drawing.Size(50, 13);
			this.label62.TabIndex = 12;
			this.label62.Text = "Durability";
			this.txtShieldsTimer.Location = new global::System.Drawing.Point(95, 65);
			this.txtShieldsTimer.Name = "txtShieldsTimer";
			this.txtShieldsTimer.Size = new global::System.Drawing.Size(62, 20);
			this.txtShieldsTimer.TabIndex = 9;
			this.label63.AutoSize = true;
			this.label63.Location = new global::System.Drawing.Point(22, 68);
			this.label63.Name = "label63";
			this.label63.Size = new global::System.Drawing.Size(59, 13);
			this.label63.TabIndex = 10;
			this.label63.Text = "Timer (sec)";
			this.txtShieldsFixed.Location = new global::System.Drawing.Point(95, 20);
			this.txtShieldsFixed.Name = "txtShieldsFixed";
			this.txtShieldsFixed.Size = new global::System.Drawing.Size(62, 20);
			this.txtShieldsFixed.TabIndex = 7;
			this.optionShieldsTimer.AutoSize = true;
			this.optionShieldsTimer.Checked = true;
			this.optionShieldsTimer.Location = new global::System.Drawing.Point(6, 44);
			this.optionShieldsTimer.Name = "optionShieldsTimer";
			this.optionShieldsTimer.Size = new global::System.Drawing.Size(83, 17);
			this.optionShieldsTimer.TabIndex = 1;
			this.optionShieldsTimer.TabStop = true;
			this.optionShieldsTimer.Text = "Timer based";
			this.optionShieldsTimer.UseVisualStyleBackColor = true;
			this.optionShieldsFixed.AutoSize = true;
			this.optionShieldsFixed.Location = new global::System.Drawing.Point(6, 21);
			this.optionShieldsFixed.Name = "optionShieldsFixed";
			this.optionShieldsFixed.Size = new global::System.Drawing.Size(79, 17);
			this.optionShieldsFixed.TabIndex = 0;
			this.optionShieldsFixed.Text = "Fixed (Dur.)";
			this.optionShieldsFixed.UseVisualStyleBackColor = true;
			this.tabPage16.Controls.Add(this.groupBox22);
			this.tabPage16.Controls.Add(this.groupBox23);
			this.tabPage16.Location = new global::System.Drawing.Point(4, 22);
			this.tabPage16.Name = "tabPage16";
			this.tabPage16.Padding = new global::System.Windows.Forms.Padding(3);
			this.tabPage16.Size = new global::System.Drawing.Size(499, 241);
			this.tabPage16.TabIndex = 4;
			this.tabPage16.Text = "Arrows";
			this.tabPage16.UseVisualStyleBackColor = true;
			this.groupBox22.Controls.Add(this.lstArrowsFilter);
			this.groupBox22.Controls.Add(this.optionArrowsFilterList);
			this.groupBox22.Controls.Add(this.optionArrowsNoFilter);
			this.groupBox22.Location = new global::System.Drawing.Point(183, 6);
			this.groupBox22.Name = "groupBox22";
			this.groupBox22.Size = new global::System.Drawing.Size(176, 229);
			this.groupBox22.TabIndex = 30;
			this.groupBox22.TabStop = false;
			this.groupBox22.Text = "Restore Filter";
			this.lstArrowsFilter.FormattingEnabled = true;
			this.lstArrowsFilter.Location = new global::System.Drawing.Point(8, 71);
			this.lstArrowsFilter.Name = "lstArrowsFilter";
			this.lstArrowsFilter.Size = new global::System.Drawing.Size(162, 147);
			this.lstArrowsFilter.TabIndex = 2;
			this.optionArrowsFilterList.AutoSize = true;
			this.optionArrowsFilterList.Location = new global::System.Drawing.Point(8, 42);
			this.optionArrowsFilterList.Name = "optionArrowsFilterList";
			this.optionArrowsFilterList.Size = new global::System.Drawing.Size(138, 17);
			this.optionArrowsFilterList.TabIndex = 1;
			this.optionArrowsFilterList.Text = "Apply only to items in list";
			this.optionArrowsFilterList.UseVisualStyleBackColor = true;
			this.optionArrowsNoFilter.AutoSize = true;
			this.optionArrowsNoFilter.Checked = true;
			this.optionArrowsNoFilter.Location = new global::System.Drawing.Point(8, 19);
			this.optionArrowsNoFilter.Name = "optionArrowsNoFilter";
			this.optionArrowsNoFilter.Size = new global::System.Drawing.Size(61, 17);
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
			this.groupBox23.Location = new global::System.Drawing.Point(6, 6);
			this.groupBox23.Name = "groupBox23";
			this.groupBox23.Size = new global::System.Drawing.Size(171, 229);
			this.groupBox23.TabIndex = 29;
			this.groupBox23.TabStop = false;
			this.groupBox23.Text = "Restore Arrows Quantity";
			this.chkArrowsUseHotkey.AutoSize = true;
			this.chkArrowsUseHotkey.Location = new global::System.Drawing.Point(6, 149);
			this.chkArrowsUseHotkey.Name = "chkArrowsUseHotkey";
			this.chkArrowsUseHotkey.Size = new global::System.Drawing.Size(60, 17);
			this.chkArrowsUseHotkey.TabIndex = 19;
			this.chkArrowsUseHotkey.Text = "Hotkey";
			this.chkArrowsUseHotkey.UseVisualStyleBackColor = true;
			this.txtArrowsHotKey.Location = new global::System.Drawing.Point(95, 145);
			this.txtArrowsHotKey.Name = "txtArrowsHotKey";
			this.txtArrowsHotKey.ReadOnly = true;
			this.txtArrowsHotKey.Size = new global::System.Drawing.Size(62, 20);
			this.txtArrowsHotKey.TabIndex = 18;
			this.chkArrowsDisableWhenDone.AutoSize = true;
			this.chkArrowsDisableWhenDone.Location = new global::System.Drawing.Point(6, 129);
			this.chkArrowsDisableWhenDone.Name = "chkArrowsDisableWhenDone";
			this.chkArrowsDisableWhenDone.Size = new global::System.Drawing.Size(104, 17);
			this.chkArrowsDisableWhenDone.TabIndex = 17;
			this.chkArrowsDisableWhenDone.Text = "Stop when done";
			this.chkArrowsDisableWhenDone.UseVisualStyleBackColor = true;
			this.chkArrowsActiveInactive.AutoSize = true;
			this.chkArrowsActiveInactive.Location = new global::System.Drawing.Point(5, 201);
			this.chkArrowsActiveInactive.Name = "chkArrowsActiveInactive";
			this.chkArrowsActiveInactive.Size = new global::System.Drawing.Size(105, 17);
			this.chkArrowsActiveInactive.TabIndex = 15;
			this.chkArrowsActiveInactive.Text = "Active / Inactive";
			this.chkArrowsActiveInactive.UseVisualStyleBackColor = true;
			this.txtArrowsMax.Location = new global::System.Drawing.Point(95, 105);
			this.txtArrowsMax.Name = "txtArrowsMax";
			this.txtArrowsMax.Size = new global::System.Drawing.Size(62, 20);
			this.txtArrowsMax.TabIndex = 13;
			this.label64.AutoSize = true;
			this.label64.Location = new global::System.Drawing.Point(22, 108);
			this.label64.Name = "label64";
			this.label64.Size = new global::System.Drawing.Size(27, 13);
			this.label64.TabIndex = 14;
			this.label64.Text = "Max";
			this.txtArrowsQuantity.Location = new global::System.Drawing.Point(95, 85);
			this.txtArrowsQuantity.Name = "txtArrowsQuantity";
			this.txtArrowsQuantity.Size = new global::System.Drawing.Size(62, 20);
			this.txtArrowsQuantity.TabIndex = 11;
			this.label65.AutoSize = true;
			this.label65.Location = new global::System.Drawing.Point(22, 88);
			this.label65.Name = "label65";
			this.label65.Size = new global::System.Drawing.Size(46, 13);
			this.label65.TabIndex = 12;
			this.label65.Text = "Quantity";
			this.txtArrowsTimer.Location = new global::System.Drawing.Point(95, 65);
			this.txtArrowsTimer.Name = "txtArrowsTimer";
			this.txtArrowsTimer.Size = new global::System.Drawing.Size(62, 20);
			this.txtArrowsTimer.TabIndex = 9;
			this.label66.AutoSize = true;
			this.label66.Location = new global::System.Drawing.Point(22, 68);
			this.label66.Name = "label66";
			this.label66.Size = new global::System.Drawing.Size(59, 13);
			this.label66.TabIndex = 10;
			this.label66.Text = "Timer (sec)";
			this.txtArrowsFixed.Location = new global::System.Drawing.Point(95, 20);
			this.txtArrowsFixed.Name = "txtArrowsFixed";
			this.txtArrowsFixed.Size = new global::System.Drawing.Size(62, 20);
			this.txtArrowsFixed.TabIndex = 7;
			this.optionArrowsTimer.AutoSize = true;
			this.optionArrowsTimer.Checked = true;
			this.optionArrowsTimer.Location = new global::System.Drawing.Point(6, 44);
			this.optionArrowsTimer.Name = "optionArrowsTimer";
			this.optionArrowsTimer.Size = new global::System.Drawing.Size(83, 17);
			this.optionArrowsTimer.TabIndex = 1;
			this.optionArrowsTimer.TabStop = true;
			this.optionArrowsTimer.Text = "Timer based";
			this.optionArrowsTimer.UseVisualStyleBackColor = true;
			this.optionArrowsFixed.AutoSize = true;
			this.optionArrowsFixed.Location = new global::System.Drawing.Point(6, 21);
			this.optionArrowsFixed.Name = "optionArrowsFixed";
			this.optionArrowsFixed.Size = new global::System.Drawing.Size(70, 17);
			this.optionArrowsFixed.TabIndex = 0;
			this.optionArrowsFixed.Text = "Fixed (Qt)";
			this.optionArrowsFixed.UseVisualStyleBackColor = true;
			this.tabPage17.Controls.Add(this.groupBox16);
			this.tabPage17.Controls.Add(this.groupBox14);
			this.tabPage17.Location = new global::System.Drawing.Point(4, 22);
			this.tabPage17.Name = "tabPage17";
			this.tabPage17.Padding = new global::System.Windows.Forms.Padding(3);
			this.tabPage17.Size = new global::System.Drawing.Size(499, 241);
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
			this.groupBox16.Location = new global::System.Drawing.Point(6, 168);
			this.groupBox16.Name = "groupBox16";
			this.groupBox16.Size = new global::System.Drawing.Size(487, 67);
			this.groupBox16.TabIndex = 30;
			this.groupBox16.TabStop = false;
			this.groupBox16.Text = "Health && Stamina";
			this.lblLockStaminaInfo.AutoSize = true;
			this.lblLockStaminaInfo.Location = new global::System.Drawing.Point(294, 43);
			this.lblLockStaminaInfo.Name = "lblLockStaminaInfo";
			this.lblLockStaminaInfo.Size = new global::System.Drawing.Size(75, 13);
			this.lblLockStaminaInfo.TabIndex = 25;
			this.lblLockStaminaInfo.Text = "<informations>";
			this.chkLockStaminaSet.AutoSize = true;
			this.chkLockStaminaSet.Location = new global::System.Drawing.Point(132, 42);
			this.chkLockStaminaSet.Name = "chkLockStaminaSet";
			this.chkLockStaminaSet.Size = new global::System.Drawing.Size(91, 17);
			this.chkLockStaminaSet.TabIndex = 24;
			this.chkLockStaminaSet.Text = "Lock Stamina";
			this.chkLockStaminaSet.UseVisualStyleBackColor = true;
			this.txtLockStaminaHotKey.Location = new global::System.Drawing.Point(64, 40);
			this.txtLockStaminaHotKey.Name = "txtLockStaminaHotKey";
			this.txtLockStaminaHotKey.ReadOnly = true;
			this.txtLockStaminaHotKey.Size = new global::System.Drawing.Size(62, 20);
			this.txtLockStaminaHotKey.TabIndex = 23;
			this.chkLockStaminaUseHotkey.AutoSize = true;
			this.chkLockStaminaUseHotkey.Location = new global::System.Drawing.Point(6, 42);
			this.chkLockStaminaUseHotkey.Name = "chkLockStaminaUseHotkey";
			this.chkLockStaminaUseHotkey.Size = new global::System.Drawing.Size(61, 17);
			this.chkLockStaminaUseHotkey.TabIndex = 22;
			this.chkLockStaminaUseHotkey.Text = "HotKey";
			this.chkLockStaminaUseHotkey.UseVisualStyleBackColor = true;
			this.lblLockHealthInfo.AutoSize = true;
			this.lblLockHealthInfo.Location = new global::System.Drawing.Point(294, 20);
			this.lblLockHealthInfo.Name = "lblLockHealthInfo";
			this.lblLockHealthInfo.Size = new global::System.Drawing.Size(75, 13);
			this.lblLockHealthInfo.TabIndex = 21;
			this.lblLockHealthInfo.Text = "<informations>";
			this.chkLockHealthSet.AutoSize = true;
			this.chkLockHealthSet.Location = new global::System.Drawing.Point(132, 19);
			this.chkLockHealthSet.Name = "chkLockHealthSet";
			this.chkLockHealthSet.Size = new global::System.Drawing.Size(84, 17);
			this.chkLockHealthSet.TabIndex = 20;
			this.chkLockHealthSet.Text = "Lock Health";
			this.chkLockHealthSet.UseVisualStyleBackColor = true;
			this.txtLockHealthHotKey.Location = new global::System.Drawing.Point(64, 17);
			this.txtLockHealthHotKey.Name = "txtLockHealthHotKey";
			this.txtLockHealthHotKey.ReadOnly = true;
			this.txtLockHealthHotKey.Size = new global::System.Drawing.Size(62, 20);
			this.txtLockHealthHotKey.TabIndex = 19;
			this.chkLockHealthUseHotkey.AutoSize = true;
			this.chkLockHealthUseHotkey.Location = new global::System.Drawing.Point(6, 19);
			this.chkLockHealthUseHotkey.Name = "chkLockHealthUseHotkey";
			this.chkLockHealthUseHotkey.Size = new global::System.Drawing.Size(61, 17);
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
			this.groupBox14.Location = new global::System.Drawing.Point(6, 6);
			this.groupBox14.Name = "groupBox14";
			this.groupBox14.Size = new global::System.Drawing.Size(487, 156);
			this.groupBox14.TabIndex = 29;
			this.groupBox14.TabStop = false;
			this.groupBox14.Text = "Unbreakable";
			this.groupBox3.Controls.Add(this.lstUnbreakableFilter);
			this.groupBox3.Controls.Add(this.optionUnbreakableFilterList);
			this.groupBox3.Controls.Add(this.optionUnbreakableNoFilter);
			this.groupBox3.Location = new global::System.Drawing.Point(6, 83);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new global::System.Drawing.Size(313, 69);
			this.groupBox3.TabIndex = 31;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Filter";
			this.lstUnbreakableFilter.FormattingEnabled = true;
			this.lstUnbreakableFilter.Location = new global::System.Drawing.Point(147, 9);
			this.lstUnbreakableFilter.Name = "lstUnbreakableFilter";
			this.lstUnbreakableFilter.Size = new global::System.Drawing.Size(162, 56);
			this.lstUnbreakableFilter.TabIndex = 2;
			this.optionUnbreakableFilterList.AutoSize = true;
			this.optionUnbreakableFilterList.Location = new global::System.Drawing.Point(8, 36);
			this.optionUnbreakableFilterList.Name = "optionUnbreakableFilterList";
			this.optionUnbreakableFilterList.Size = new global::System.Drawing.Size(138, 17);
			this.optionUnbreakableFilterList.TabIndex = 1;
			this.optionUnbreakableFilterList.Text = "Apply only to items in list";
			this.optionUnbreakableFilterList.UseVisualStyleBackColor = true;
			this.optionUnbreakableNoFilter.AutoSize = true;
			this.optionUnbreakableNoFilter.Checked = true;
			this.optionUnbreakableNoFilter.Location = new global::System.Drawing.Point(8, 16);
			this.optionUnbreakableNoFilter.Name = "optionUnbreakableNoFilter";
			this.optionUnbreakableNoFilter.Size = new global::System.Drawing.Size(61, 17);
			this.optionUnbreakableNoFilter.TabIndex = 0;
			this.optionUnbreakableNoFilter.TabStop = true;
			this.optionUnbreakableNoFilter.Text = "No filter";
			this.optionUnbreakableNoFilter.UseVisualStyleBackColor = true;
			this.lblUnbreakableShieldsInfo.AutoSize = true;
			this.lblUnbreakableShieldsInfo.Location = new global::System.Drawing.Point(294, 66);
			this.lblUnbreakableShieldsInfo.Name = "lblUnbreakableShieldsInfo";
			this.lblUnbreakableShieldsInfo.Size = new global::System.Drawing.Size(75, 13);
			this.lblUnbreakableShieldsInfo.TabIndex = 29;
			this.lblUnbreakableShieldsInfo.Text = "<informations>";
			this.chkUnbreakableShieldsSet.AutoSize = true;
			this.chkUnbreakableShieldsSet.Location = new global::System.Drawing.Point(132, 65);
			this.chkUnbreakableShieldsSet.Name = "chkUnbreakableShieldsSet";
			this.chkUnbreakableShieldsSet.Size = new global::System.Drawing.Size(143, 17);
			this.chkUnbreakableShieldsSet.TabIndex = 28;
			this.chkUnbreakableShieldsSet.Text = "Set Shields Unbreakable";
			this.chkUnbreakableShieldsSet.UseVisualStyleBackColor = true;
			this.txtUnbreakableShieldsHotKey.Location = new global::System.Drawing.Point(64, 63);
			this.txtUnbreakableShieldsHotKey.Name = "txtUnbreakableShieldsHotKey";
			this.txtUnbreakableShieldsHotKey.ReadOnly = true;
			this.txtUnbreakableShieldsHotKey.Size = new global::System.Drawing.Size(62, 20);
			this.txtUnbreakableShieldsHotKey.TabIndex = 27;
			this.chkUnbreakableShieldsUseHotkey.AutoSize = true;
			this.chkUnbreakableShieldsUseHotkey.Location = new global::System.Drawing.Point(6, 65);
			this.chkUnbreakableShieldsUseHotkey.Name = "chkUnbreakableShieldsUseHotkey";
			this.chkUnbreakableShieldsUseHotkey.Size = new global::System.Drawing.Size(61, 17);
			this.chkUnbreakableShieldsUseHotkey.TabIndex = 26;
			this.chkUnbreakableShieldsUseHotkey.Text = "HotKey";
			this.chkUnbreakableShieldsUseHotkey.UseVisualStyleBackColor = true;
			this.lblUnbreakableBowsInfo.AutoSize = true;
			this.lblUnbreakableBowsInfo.Location = new global::System.Drawing.Point(294, 43);
			this.lblUnbreakableBowsInfo.Name = "lblUnbreakableBowsInfo";
			this.lblUnbreakableBowsInfo.Size = new global::System.Drawing.Size(75, 13);
			this.lblUnbreakableBowsInfo.TabIndex = 25;
			this.lblUnbreakableBowsInfo.Text = "<informations>";
			this.chkUnbreakableBowsSet.AutoSize = true;
			this.chkUnbreakableBowsSet.Location = new global::System.Drawing.Point(132, 42);
			this.chkUnbreakableBowsSet.Name = "chkUnbreakableBowsSet";
			this.chkUnbreakableBowsSet.Size = new global::System.Drawing.Size(135, 17);
			this.chkUnbreakableBowsSet.TabIndex = 24;
			this.chkUnbreakableBowsSet.Text = "Set Bows Unbreakable";
			this.chkUnbreakableBowsSet.UseVisualStyleBackColor = true;
			this.txtUnbreakableBowsHotKey.Location = new global::System.Drawing.Point(64, 40);
			this.txtUnbreakableBowsHotKey.Name = "txtUnbreakableBowsHotKey";
			this.txtUnbreakableBowsHotKey.ReadOnly = true;
			this.txtUnbreakableBowsHotKey.Size = new global::System.Drawing.Size(62, 20);
			this.txtUnbreakableBowsHotKey.TabIndex = 23;
			this.chkUnbreakableBowsUseHotkey.AutoSize = true;
			this.chkUnbreakableBowsUseHotkey.Location = new global::System.Drawing.Point(6, 42);
			this.chkUnbreakableBowsUseHotkey.Name = "chkUnbreakableBowsUseHotkey";
			this.chkUnbreakableBowsUseHotkey.Size = new global::System.Drawing.Size(61, 17);
			this.chkUnbreakableBowsUseHotkey.TabIndex = 22;
			this.chkUnbreakableBowsUseHotkey.Text = "HotKey";
			this.chkUnbreakableBowsUseHotkey.UseVisualStyleBackColor = true;
			this.lblUnbreakableWeaponsInfo.AutoSize = true;
			this.lblUnbreakableWeaponsInfo.Location = new global::System.Drawing.Point(294, 20);
			this.lblUnbreakableWeaponsInfo.Name = "lblUnbreakableWeaponsInfo";
			this.lblUnbreakableWeaponsInfo.Size = new global::System.Drawing.Size(75, 13);
			this.lblUnbreakableWeaponsInfo.TabIndex = 21;
			this.lblUnbreakableWeaponsInfo.Text = "<informations>";
			this.chkUnbreakableWeaponsSet.AutoSize = true;
			this.chkUnbreakableWeaponsSet.Location = new global::System.Drawing.Point(132, 19);
			this.chkUnbreakableWeaponsSet.Name = "chkUnbreakableWeaponsSet";
			this.chkUnbreakableWeaponsSet.Size = new global::System.Drawing.Size(155, 17);
			this.chkUnbreakableWeaponsSet.TabIndex = 20;
			this.chkUnbreakableWeaponsSet.Text = "Set Weapons Unbreakable";
			this.chkUnbreakableWeaponsSet.UseVisualStyleBackColor = true;
			this.txtUnbreakableWeaponsHotKey.Location = new global::System.Drawing.Point(64, 17);
			this.txtUnbreakableWeaponsHotKey.Name = "txtUnbreakableWeaponsHotKey";
			this.txtUnbreakableWeaponsHotKey.ReadOnly = true;
			this.txtUnbreakableWeaponsHotKey.Size = new global::System.Drawing.Size(62, 20);
			this.txtUnbreakableWeaponsHotKey.TabIndex = 19;
			this.chkUnbreakableWeaponsUseHotkey.AutoSize = true;
			this.chkUnbreakableWeaponsUseHotkey.Location = new global::System.Drawing.Point(6, 19);
			this.chkUnbreakableWeaponsUseHotkey.Name = "chkUnbreakableWeaponsUseHotkey";
			this.chkUnbreakableWeaponsUseHotkey.Size = new global::System.Drawing.Size(61, 17);
			this.chkUnbreakableWeaponsUseHotkey.TabIndex = 0;
			this.chkUnbreakableWeaponsUseHotkey.Text = "HotKey";
			this.chkUnbreakableWeaponsUseHotkey.UseVisualStyleBackColor = true;
			this.tabPage21.Controls.Add(this.groupBox6);
			this.tabPage21.Controls.Add(this.groupBox7);
			this.tabPage21.Location = new global::System.Drawing.Point(4, 22);
			this.tabPage21.Name = "tabPage21";
			this.tabPage21.Padding = new global::System.Windows.Forms.Padding(3);
			this.tabPage21.Size = new global::System.Drawing.Size(499, 241);
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
			this.groupBox6.Location = new global::System.Drawing.Point(8, 107);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new global::System.Drawing.Size(487, 124);
			this.groupBox6.TabIndex = 36;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "Captured Positions";
			this.btnCapturedPositionTP.Location = new global::System.Drawing.Point(239, 16);
			this.btnCapturedPositionTP.Name = "btnCapturedPositionTP";
			this.btnCapturedPositionTP.Size = new global::System.Drawing.Size(29, 97);
			this.btnCapturedPositionTP.TabIndex = 58;
			this.btnCapturedPositionTP.Text = "TP";
			this.btnCapturedPositionTP.UseVisualStyleBackColor = true;
			this.btnCapturedPositionTP.Click += new global::System.EventHandler(this.btnCapturedPositionTP_Click);
			this.label70.AutoSize = true;
			this.label70.Location = new global::System.Drawing.Point(337, 100);
			this.label70.Name = "label70";
			this.label70.Size = new global::System.Drawing.Size(35, 13);
			this.label70.TabIndex = 57;
			this.label70.Text = "Name";
			this.txtCapturedPositionName.Location = new global::System.Drawing.Point(372, 97);
			this.txtCapturedPositionName.Name = "txtCapturedPositionName";
			this.txtCapturedPositionName.Size = new global::System.Drawing.Size(109, 20);
			this.txtCapturedPositionName.TabIndex = 56;
			this.label57.AutoSize = true;
			this.label57.Location = new global::System.Drawing.Point(349, 74);
			this.label57.Name = "label57";
			this.label57.Size = new global::System.Drawing.Size(23, 13);
			this.label57.TabIndex = 55;
			this.label57.Text = "Z =";
			this.txtCapturedPositionZ.Location = new global::System.Drawing.Point(372, 71);
			this.txtCapturedPositionZ.Name = "txtCapturedPositionZ";
			this.txtCapturedPositionZ.Size = new global::System.Drawing.Size(109, 20);
			this.txtCapturedPositionZ.TabIndex = 54;
			this.label58.AutoSize = true;
			this.label58.Location = new global::System.Drawing.Point(349, 48);
			this.label58.Name = "label58";
			this.label58.Size = new global::System.Drawing.Size(23, 13);
			this.label58.TabIndex = 53;
			this.label58.Text = "Y =";
			this.txtCapturedPositionY.Location = new global::System.Drawing.Point(372, 45);
			this.txtCapturedPositionY.Name = "txtCapturedPositionY";
			this.txtCapturedPositionY.Size = new global::System.Drawing.Size(109, 20);
			this.txtCapturedPositionY.TabIndex = 52;
			this.label69.AutoSize = true;
			this.label69.Location = new global::System.Drawing.Point(349, 22);
			this.label69.Name = "label69";
			this.label69.Size = new global::System.Drawing.Size(23, 13);
			this.label69.TabIndex = 51;
			this.label69.Text = "X =";
			this.txtCapturedPositionX.Location = new global::System.Drawing.Point(372, 19);
			this.txtCapturedPositionX.Name = "txtCapturedPositionX";
			this.txtCapturedPositionX.Size = new global::System.Drawing.Size(109, 20);
			this.txtCapturedPositionX.TabIndex = 50;
			this.btnCapturedPositionRemove.Location = new global::System.Drawing.Point(273, 74);
			this.btnCapturedPositionRemove.Name = "btnCapturedPositionRemove";
			this.btnCapturedPositionRemove.Size = new global::System.Drawing.Size(66, 23);
			this.btnCapturedPositionRemove.TabIndex = 49;
			this.btnCapturedPositionRemove.Text = "Remove";
			this.btnCapturedPositionRemove.UseVisualStyleBackColor = true;
			this.btnCapturedPositionRemove.Click += new global::System.EventHandler(this.btnCapturedPositionRemove_Click);
			this.btnCapturedPositionSave.Location = new global::System.Drawing.Point(273, 45);
			this.btnCapturedPositionSave.Name = "btnCapturedPositionSave";
			this.btnCapturedPositionSave.Size = new global::System.Drawing.Size(66, 23);
			this.btnCapturedPositionSave.TabIndex = 48;
			this.btnCapturedPositionSave.Text = "Save";
			this.btnCapturedPositionSave.UseVisualStyleBackColor = true;
			this.btnCapturedPositionSave.Click += new global::System.EventHandler(this.btnCapturedPositionSave_Click);
			this.btnCapturedPositionNew.Location = new global::System.Drawing.Point(273, 16);
			this.btnCapturedPositionNew.Name = "btnCapturedPositionNew";
			this.btnCapturedPositionNew.Size = new global::System.Drawing.Size(66, 23);
			this.btnCapturedPositionNew.TabIndex = 47;
			this.btnCapturedPositionNew.Text = "New";
			this.btnCapturedPositionNew.UseVisualStyleBackColor = true;
			this.btnCapturedPositionNew.Click += new global::System.EventHandler(this.btnCapturedPositionNew_Click);
			this.lstCapturedPositions.FormattingEnabled = true;
			this.lstCapturedPositions.Location = new global::System.Drawing.Point(6, 16);
			this.lstCapturedPositions.Name = "lstCapturedPositions";
			this.lstCapturedPositions.Size = new global::System.Drawing.Size(227, 95);
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
			this.groupBox7.Location = new global::System.Drawing.Point(8, 6);
			this.groupBox7.Name = "groupBox7";
			this.groupBox7.Size = new global::System.Drawing.Size(487, 99);
			this.groupBox7.TabIndex = 35;
			this.groupBox7.TabStop = false;
			this.groupBox7.Text = "Current Position";
			this.btnPositionEdit.Location = new global::System.Drawing.Point(266, 17);
			this.btnPositionEdit.Name = "btnPositionEdit";
			this.btnPositionEdit.Size = new global::System.Drawing.Size(66, 23);
			this.btnPositionEdit.TabIndex = 46;
			this.btnPositionEdit.Text = "Edit";
			this.btnPositionEdit.UseVisualStyleBackColor = true;
			this.btnPositionEdit.Click += new global::System.EventHandler(this.btnPositionEdit_Click);
			this.btnPositionRestore.Location = new global::System.Drawing.Point(131, 67);
			this.btnPositionRestore.Name = "btnPositionRestore";
			this.btnPositionRestore.Size = new global::System.Drawing.Size(66, 23);
			this.btnPositionRestore.TabIndex = 45;
			this.btnPositionRestore.Text = "Restore";
			this.btnPositionRestore.UseVisualStyleBackColor = true;
			this.btnPositionRestore.Click += new global::System.EventHandler(this.btnPositionRestore_Click);
			this.txtPositionRestoreHotKey.Location = new global::System.Drawing.Point(63, 69);
			this.txtPositionRestoreHotKey.Name = "txtPositionRestoreHotKey";
			this.txtPositionRestoreHotKey.ReadOnly = true;
			this.txtPositionRestoreHotKey.Size = new global::System.Drawing.Size(62, 20);
			this.txtPositionRestoreHotKey.TabIndex = 44;
			this.chkPositionRestoreUseHotkey.AutoSize = true;
			this.chkPositionRestoreUseHotkey.Location = new global::System.Drawing.Point(5, 71);
			this.chkPositionRestoreUseHotkey.Name = "chkPositionRestoreUseHotkey";
			this.chkPositionRestoreUseHotkey.Size = new global::System.Drawing.Size(61, 17);
			this.chkPositionRestoreUseHotkey.TabIndex = 43;
			this.chkPositionRestoreUseHotkey.Text = "HotKey";
			this.chkPositionRestoreUseHotkey.UseVisualStyleBackColor = true;
			this.btnPositionSave.Location = new global::System.Drawing.Point(131, 41);
			this.btnPositionSave.Name = "btnPositionSave";
			this.btnPositionSave.Size = new global::System.Drawing.Size(66, 23);
			this.btnPositionSave.TabIndex = 42;
			this.btnPositionSave.Text = "Save";
			this.btnPositionSave.UseVisualStyleBackColor = true;
			this.btnPositionSave.Click += new global::System.EventHandler(this.btnPositionSave_Click);
			this.txtPositionSaveHotKey.Location = new global::System.Drawing.Point(63, 43);
			this.txtPositionSaveHotKey.Name = "txtPositionSaveHotKey";
			this.txtPositionSaveHotKey.ReadOnly = true;
			this.txtPositionSaveHotKey.Size = new global::System.Drawing.Size(62, 20);
			this.txtPositionSaveHotKey.TabIndex = 41;
			this.chkPositionSaveUseHotkey.AutoSize = true;
			this.chkPositionSaveUseHotkey.Location = new global::System.Drawing.Point(5, 45);
			this.chkPositionSaveUseHotkey.Name = "chkPositionSaveUseHotkey";
			this.chkPositionSaveUseHotkey.Size = new global::System.Drawing.Size(61, 17);
			this.chkPositionSaveUseHotkey.TabIndex = 40;
			this.chkPositionSaveUseHotkey.Text = "HotKey";
			this.chkPositionSaveUseHotkey.UseVisualStyleBackColor = true;
			this.btnPositionJump.Location = new global::System.Drawing.Point(351, 66);
			this.btnPositionJump.Name = "btnPositionJump";
			this.btnPositionJump.Size = new global::System.Drawing.Size(66, 23);
			this.btnPositionJump.TabIndex = 39;
			this.btnPositionJump.Text = "Jump";
			this.btnPositionJump.UseVisualStyleBackColor = true;
			this.btnPositionJump.Click += new global::System.EventHandler(this.btnPositionJump_Click);
			this.txtPositionJumpHeight.Location = new global::System.Drawing.Point(423, 68);
			this.txtPositionJumpHeight.Name = "txtPositionJumpHeight";
			this.txtPositionJumpHeight.Size = new global::System.Drawing.Size(56, 20);
			this.txtPositionJumpHeight.TabIndex = 38;
			this.txtPositionJumpHeight.Text = "100";
			this.txtPositionJumpHotKey.Location = new global::System.Drawing.Point(283, 68);
			this.txtPositionJumpHotKey.Name = "txtPositionJumpHotKey";
			this.txtPositionJumpHotKey.ReadOnly = true;
			this.txtPositionJumpHotKey.Size = new global::System.Drawing.Size(62, 20);
			this.txtPositionJumpHotKey.TabIndex = 37;
			this.chkPositionJumpUseHotkey.AutoSize = true;
			this.chkPositionJumpUseHotkey.Location = new global::System.Drawing.Point(225, 70);
			this.chkPositionJumpUseHotkey.Name = "chkPositionJumpUseHotkey";
			this.chkPositionJumpUseHotkey.Size = new global::System.Drawing.Size(61, 17);
			this.chkPositionJumpUseHotkey.TabIndex = 36;
			this.chkPositionJumpUseHotkey.Text = "HotKey";
			this.chkPositionJumpUseHotkey.UseVisualStyleBackColor = true;
			this.chkPositionLockHeightSet.AutoSize = true;
			this.chkPositionLockHeightSet.Location = new global::System.Drawing.Point(351, 45);
			this.chkPositionLockHeightSet.Name = "chkPositionLockHeightSet";
			this.chkPositionLockHeightSet.Size = new global::System.Drawing.Size(100, 17);
			this.chkPositionLockHeightSet.TabIndex = 35;
			this.chkPositionLockHeightSet.Text = "Lock Height (Y)";
			this.chkPositionLockHeightSet.UseVisualStyleBackColor = true;
			this.txtPositionLockHeightHotKey.Location = new global::System.Drawing.Point(283, 43);
			this.txtPositionLockHeightHotKey.Name = "txtPositionLockHeightHotKey";
			this.txtPositionLockHeightHotKey.ReadOnly = true;
			this.txtPositionLockHeightHotKey.Size = new global::System.Drawing.Size(62, 20);
			this.txtPositionLockHeightHotKey.TabIndex = 34;
			this.chkPositionLockHeightUseHotkey.AutoSize = true;
			this.chkPositionLockHeightUseHotkey.Location = new global::System.Drawing.Point(225, 45);
			this.chkPositionLockHeightUseHotkey.Name = "chkPositionLockHeightUseHotkey";
			this.chkPositionLockHeightUseHotkey.Size = new global::System.Drawing.Size(61, 17);
			this.chkPositionLockHeightUseHotkey.TabIndex = 33;
			this.chkPositionLockHeightUseHotkey.Text = "HotKey";
			this.chkPositionLockHeightUseHotkey.UseVisualStyleBackColor = true;
			this.label68.AutoSize = true;
			this.label68.Location = new global::System.Drawing.Point(175, 22);
			this.label68.Name = "label68";
			this.label68.Size = new global::System.Drawing.Size(23, 13);
			this.label68.TabIndex = 32;
			this.label68.Text = "Z =";
			this.txtPositionZ.Location = new global::System.Drawing.Point(198, 19);
			this.txtPositionZ.Name = "txtPositionZ";
			this.txtPositionZ.ReadOnly = true;
			this.txtPositionZ.Size = new global::System.Drawing.Size(62, 20);
			this.txtPositionZ.TabIndex = 31;
			this.label67.AutoSize = true;
			this.label67.Location = new global::System.Drawing.Point(89, 22);
			this.label67.Name = "label67";
			this.label67.Size = new global::System.Drawing.Size(23, 13);
			this.label67.TabIndex = 30;
			this.label67.Text = "Y =";
			this.txtPositionY.Location = new global::System.Drawing.Point(112, 19);
			this.txtPositionY.Name = "txtPositionY";
			this.txtPositionY.ReadOnly = true;
			this.txtPositionY.Size = new global::System.Drawing.Size(62, 20);
			this.txtPositionY.TabIndex = 29;
			this.label59.AutoSize = true;
			this.label59.Location = new global::System.Drawing.Point(3, 22);
			this.label59.Name = "label59";
			this.label59.Size = new global::System.Drawing.Size(23, 13);
			this.label59.TabIndex = 28;
			this.label59.Text = "X =";
			this.txtPositionX.Location = new global::System.Drawing.Point(26, 19);
			this.txtPositionX.Name = "txtPositionX";
			this.txtPositionX.ReadOnly = true;
			this.txtPositionX.Size = new global::System.Drawing.Size(62, 20);
			this.txtPositionX.TabIndex = 23;
			this.tabPage18.Controls.Add(this.groupBox19);
			this.tabPage18.Location = new global::System.Drawing.Point(4, 22);
			this.tabPage18.Name = "tabPage18";
			this.tabPage18.Padding = new global::System.Windows.Forms.Padding(3);
			this.tabPage18.Size = new global::System.Drawing.Size(499, 241);
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
			this.groupBox19.Location = new global::System.Drawing.Point(6, 6);
			this.groupBox19.Name = "groupBox19";
			this.groupBox19.Size = new global::System.Drawing.Size(487, 114);
			this.groupBox19.TabIndex = 31;
			this.groupBox19.TabStop = false;
			this.groupBox19.Text = "Unlimit Divine Powers";
			this.lblPowersDarukInfo.AutoSize = true;
			this.lblPowersDarukInfo.Location = new global::System.Drawing.Point(294, 89);
			this.lblPowersDarukInfo.Name = "lblPowersDarukInfo";
			this.lblPowersDarukInfo.Size = new global::System.Drawing.Size(75, 13);
			this.lblPowersDarukInfo.TabIndex = 33;
			this.lblPowersDarukInfo.Text = "<informations>";
			this.chkPowersDarukSet.AutoSize = true;
			this.chkPowersDarukSet.Location = new global::System.Drawing.Point(132, 88);
			this.chkPowersDarukSet.Name = "chkPowersDarukSet";
			this.chkPowersDarukSet.Size = new global::System.Drawing.Size(113, 17);
			this.chkPowersDarukSet.TabIndex = 32;
			this.chkPowersDarukSet.Text = "Daruk's Protection";
			this.chkPowersDarukSet.UseVisualStyleBackColor = true;
			this.txtPowersDarukHotKey.Location = new global::System.Drawing.Point(64, 86);
			this.txtPowersDarukHotKey.Name = "txtPowersDarukHotKey";
			this.txtPowersDarukHotKey.ReadOnly = true;
			this.txtPowersDarukHotKey.Size = new global::System.Drawing.Size(62, 20);
			this.txtPowersDarukHotKey.TabIndex = 31;
			this.chkPowersDarukUseHotkey.AutoSize = true;
			this.chkPowersDarukUseHotkey.Location = new global::System.Drawing.Point(6, 88);
			this.chkPowersDarukUseHotkey.Name = "chkPowersDarukUseHotkey";
			this.chkPowersDarukUseHotkey.Size = new global::System.Drawing.Size(61, 17);
			this.chkPowersDarukUseHotkey.TabIndex = 30;
			this.chkPowersDarukUseHotkey.Text = "HotKey";
			this.chkPowersDarukUseHotkey.UseVisualStyleBackColor = true;
			this.lblPowersUrbosaInfo.AutoSize = true;
			this.lblPowersUrbosaInfo.Location = new global::System.Drawing.Point(294, 66);
			this.lblPowersUrbosaInfo.Name = "lblPowersUrbosaInfo";
			this.lblPowersUrbosaInfo.Size = new global::System.Drawing.Size(75, 13);
			this.lblPowersUrbosaInfo.TabIndex = 29;
			this.lblPowersUrbosaInfo.Text = "<informations>";
			this.chkPowersUrbosaSet.AutoSize = true;
			this.chkPowersUrbosaSet.Location = new global::System.Drawing.Point(132, 65);
			this.chkPowersUrbosaSet.Name = "chkPowersUrbosaSet";
			this.chkPowersUrbosaSet.Size = new global::System.Drawing.Size(90, 17);
			this.chkPowersUrbosaSet.TabIndex = 28;
			this.chkPowersUrbosaSet.Text = "Urbosa's Fury";
			this.chkPowersUrbosaSet.UseVisualStyleBackColor = true;
			this.txtPowersUrbosaHotKey.Location = new global::System.Drawing.Point(64, 63);
			this.txtPowersUrbosaHotKey.Name = "txtPowersUrbosaHotKey";
			this.txtPowersUrbosaHotKey.ReadOnly = true;
			this.txtPowersUrbosaHotKey.Size = new global::System.Drawing.Size(62, 20);
			this.txtPowersUrbosaHotKey.TabIndex = 27;
			this.chkPowersUrbosaUseHotkey.AutoSize = true;
			this.chkPowersUrbosaUseHotkey.Location = new global::System.Drawing.Point(6, 65);
			this.chkPowersUrbosaUseHotkey.Name = "chkPowersUrbosaUseHotkey";
			this.chkPowersUrbosaUseHotkey.Size = new global::System.Drawing.Size(61, 17);
			this.chkPowersUrbosaUseHotkey.TabIndex = 26;
			this.chkPowersUrbosaUseHotkey.Text = "HotKey";
			this.chkPowersUrbosaUseHotkey.UseVisualStyleBackColor = true;
			this.lblPowersRevaliInfo.AutoSize = true;
			this.lblPowersRevaliInfo.Location = new global::System.Drawing.Point(294, 43);
			this.lblPowersRevaliInfo.Name = "lblPowersRevaliInfo";
			this.lblPowersRevaliInfo.Size = new global::System.Drawing.Size(75, 13);
			this.lblPowersRevaliInfo.TabIndex = 25;
			this.lblPowersRevaliInfo.Text = "<informations>";
			this.chkPowersRevaliSet.AutoSize = true;
			this.chkPowersRevaliSet.Location = new global::System.Drawing.Point(132, 42);
			this.chkPowersRevaliSet.Name = "chkPowersRevaliSet";
			this.chkPowersRevaliSet.Size = new global::System.Drawing.Size(88, 17);
			this.chkPowersRevaliSet.TabIndex = 24;
			this.chkPowersRevaliSet.Text = "Revali's Gale";
			this.chkPowersRevaliSet.UseVisualStyleBackColor = true;
			this.txtPowersRevaliHotKey.Location = new global::System.Drawing.Point(64, 40);
			this.txtPowersRevaliHotKey.Name = "txtPowersRevaliHotKey";
			this.txtPowersRevaliHotKey.ReadOnly = true;
			this.txtPowersRevaliHotKey.Size = new global::System.Drawing.Size(62, 20);
			this.txtPowersRevaliHotKey.TabIndex = 23;
			this.chkPowersRevaliUseHotkey.AutoSize = true;
			this.chkPowersRevaliUseHotkey.Location = new global::System.Drawing.Point(6, 42);
			this.chkPowersRevaliUseHotkey.Name = "chkPowersRevaliUseHotkey";
			this.chkPowersRevaliUseHotkey.Size = new global::System.Drawing.Size(61, 17);
			this.chkPowersRevaliUseHotkey.TabIndex = 22;
			this.chkPowersRevaliUseHotkey.Text = "HotKey";
			this.chkPowersRevaliUseHotkey.UseVisualStyleBackColor = true;
			this.lblPowersMiphaInfo.AutoSize = true;
			this.lblPowersMiphaInfo.Location = new global::System.Drawing.Point(294, 20);
			this.lblPowersMiphaInfo.Name = "lblPowersMiphaInfo";
			this.lblPowersMiphaInfo.Size = new global::System.Drawing.Size(75, 13);
			this.lblPowersMiphaInfo.TabIndex = 21;
			this.lblPowersMiphaInfo.Text = "<informations>";
			this.chkPowersMiphaSet.AutoSize = true;
			this.chkPowersMiphaSet.Location = new global::System.Drawing.Point(132, 19);
			this.chkPowersMiphaSet.Name = "chkPowersMiphaSet";
			this.chkPowersMiphaSet.Size = new global::System.Drawing.Size(94, 17);
			this.chkPowersMiphaSet.TabIndex = 20;
			this.chkPowersMiphaSet.Text = "Mipha's Grace";
			this.chkPowersMiphaSet.UseVisualStyleBackColor = true;
			this.txtPowersMiphaHotKey.Location = new global::System.Drawing.Point(64, 17);
			this.txtPowersMiphaHotKey.Name = "txtPowersMiphaHotKey";
			this.txtPowersMiphaHotKey.ReadOnly = true;
			this.txtPowersMiphaHotKey.Size = new global::System.Drawing.Size(62, 20);
			this.txtPowersMiphaHotKey.TabIndex = 19;
			this.chkPowersMiphaUseHotkey.AutoSize = true;
			this.chkPowersMiphaUseHotkey.Location = new global::System.Drawing.Point(6, 19);
			this.chkPowersMiphaUseHotkey.Name = "chkPowersMiphaUseHotkey";
			this.chkPowersMiphaUseHotkey.Size = new global::System.Drawing.Size(61, 17);
			this.chkPowersMiphaUseHotkey.TabIndex = 0;
			this.chkPowersMiphaUseHotkey.Text = "HotKey";
			this.chkPowersMiphaUseHotkey.UseVisualStyleBackColor = true;
			this.tabPage19.Controls.Add(this.groupBox4);
			this.tabPage19.Controls.Add(this.groupBox15);
			this.tabPage19.Location = new global::System.Drawing.Point(4, 22);
			this.tabPage19.Name = "tabPage19";
			this.tabPage19.Padding = new global::System.Windows.Forms.Padding(3);
			this.tabPage19.Size = new global::System.Drawing.Size(499, 241);
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
			this.groupBox4.Location = new global::System.Drawing.Point(6, 58);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new global::System.Drawing.Size(487, 136);
			this.groupBox4.TabIndex = 33;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Run speed";
			this.btnRunSpeedDefault.Location = new global::System.Drawing.Point(132, 98);
			this.btnRunSpeedDefault.Name = "btnRunSpeedDefault";
			this.btnRunSpeedDefault.Size = new global::System.Drawing.Size(91, 23);
			this.btnRunSpeedDefault.TabIndex = 30;
			this.btnRunSpeedDefault.Text = "Default Speed";
			this.btnRunSpeedDefault.UseVisualStyleBackColor = true;
			this.btnRunSpeedDefault.Click += new global::System.EventHandler(this.btnRunSpeedDefault_Click);
			this.txtRunSpeedDefaultHotKey.Location = new global::System.Drawing.Point(64, 100);
			this.txtRunSpeedDefaultHotKey.Name = "txtRunSpeedDefaultHotKey";
			this.txtRunSpeedDefaultHotKey.ReadOnly = true;
			this.txtRunSpeedDefaultHotKey.Size = new global::System.Drawing.Size(62, 20);
			this.txtRunSpeedDefaultHotKey.TabIndex = 29;
			this.chkRunSpeedDefaultUseHotkey.AutoSize = true;
			this.chkRunSpeedDefaultUseHotkey.Location = new global::System.Drawing.Point(6, 102);
			this.chkRunSpeedDefaultUseHotkey.Name = "chkRunSpeedDefaultUseHotkey";
			this.chkRunSpeedDefaultUseHotkey.Size = new global::System.Drawing.Size(61, 17);
			this.chkRunSpeedDefaultUseHotkey.TabIndex = 28;
			this.chkRunSpeedDefaultUseHotkey.Text = "HotKey";
			this.chkRunSpeedDefaultUseHotkey.UseVisualStyleBackColor = true;
			this.btnRunSpeedDown.Location = new global::System.Drawing.Point(132, 69);
			this.btnRunSpeedDown.Name = "btnRunSpeedDown";
			this.btnRunSpeedDown.Size = new global::System.Drawing.Size(91, 23);
			this.btnRunSpeedDown.TabIndex = 27;
			this.btnRunSpeedDown.Text = "Speed Down";
			this.btnRunSpeedDown.UseVisualStyleBackColor = true;
			this.btnRunSpeedDown.Click += new global::System.EventHandler(this.btnRunSpeedDown_Click);
			this.txtRunSpeedDownHotKey.Location = new global::System.Drawing.Point(64, 71);
			this.txtRunSpeedDownHotKey.Name = "txtRunSpeedDownHotKey";
			this.txtRunSpeedDownHotKey.ReadOnly = true;
			this.txtRunSpeedDownHotKey.Size = new global::System.Drawing.Size(62, 20);
			this.txtRunSpeedDownHotKey.TabIndex = 26;
			this.chkRunSpeedDownUseHotkey.AutoSize = true;
			this.chkRunSpeedDownUseHotkey.Location = new global::System.Drawing.Point(6, 73);
			this.chkRunSpeedDownUseHotkey.Name = "chkRunSpeedDownUseHotkey";
			this.chkRunSpeedDownUseHotkey.Size = new global::System.Drawing.Size(61, 17);
			this.chkRunSpeedDownUseHotkey.TabIndex = 25;
			this.chkRunSpeedDownUseHotkey.Text = "HotKey";
			this.chkRunSpeedDownUseHotkey.UseVisualStyleBackColor = true;
			this.btnRunSpeedUp.Location = new global::System.Drawing.Point(132, 41);
			this.btnRunSpeedUp.Name = "btnRunSpeedUp";
			this.btnRunSpeedUp.Size = new global::System.Drawing.Size(91, 23);
			this.btnRunSpeedUp.TabIndex = 24;
			this.btnRunSpeedUp.Text = "Speed Up";
			this.btnRunSpeedUp.UseVisualStyleBackColor = true;
			this.btnRunSpeedUp.Click += new global::System.EventHandler(this.btnRunSpeedUp_Click);
			this.txtRunSpeedUpHotKey.Location = new global::System.Drawing.Point(64, 43);
			this.txtRunSpeedUpHotKey.Name = "txtRunSpeedUpHotKey";
			this.txtRunSpeedUpHotKey.ReadOnly = true;
			this.txtRunSpeedUpHotKey.Size = new global::System.Drawing.Size(62, 20);
			this.txtRunSpeedUpHotKey.TabIndex = 23;
			this.chkRunSpeedUpUseHotkey.AutoSize = true;
			this.chkRunSpeedUpUseHotkey.Location = new global::System.Drawing.Point(6, 45);
			this.chkRunSpeedUpUseHotkey.Name = "chkRunSpeedUpUseHotkey";
			this.chkRunSpeedUpUseHotkey.Size = new global::System.Drawing.Size(61, 17);
			this.chkRunSpeedUpUseHotkey.TabIndex = 22;
			this.chkRunSpeedUpUseHotkey.Text = "HotKey";
			this.chkRunSpeedUpUseHotkey.UseVisualStyleBackColor = true;
			this.btnRunSpeedUpdate.Location = new global::System.Drawing.Point(132, 13);
			this.btnRunSpeedUpdate.Name = "btnRunSpeedUpdate";
			this.btnRunSpeedUpdate.Size = new global::System.Drawing.Size(91, 23);
			this.btnRunSpeedUpdate.TabIndex = 11;
			this.btnRunSpeedUpdate.Text = "Update";
			this.btnRunSpeedUpdate.UseVisualStyleBackColor = true;
			this.btnRunSpeedUpdate.Click += new global::System.EventHandler(this.btnRunSpeedUpdate_Click);
			this.label49.AutoSize = true;
			this.label49.Location = new global::System.Drawing.Point(3, 20);
			this.label49.Name = "label49";
			this.label49.Size = new global::System.Drawing.Size(48, 13);
			this.label49.TabIndex = 3;
			this.label49.Text = "Multiplier";
			this.txtRunSpeed.Location = new global::System.Drawing.Point(64, 16);
			this.txtRunSpeed.Name = "txtRunSpeed";
			this.txtRunSpeed.Size = new global::System.Drawing.Size(62, 20);
			this.txtRunSpeed.TabIndex = 2;
			this.groupBox15.Controls.Add(this.lblUnlimitAmiiboInfo);
			this.groupBox15.Controls.Add(this.chkUnlimitAmiiboSet);
			this.groupBox15.Controls.Add(this.txtUnlimitAmiiboHotKey);
			this.groupBox15.Controls.Add(this.chkUnlimitAmiiboUseHotkey);
			this.groupBox15.Location = new global::System.Drawing.Point(6, 6);
			this.groupBox15.Name = "groupBox15";
			this.groupBox15.Size = new global::System.Drawing.Size(487, 46);
			this.groupBox15.TabIndex = 32;
			this.groupBox15.TabStop = false;
			this.groupBox15.Text = "Unlimit Amiibo";
			this.lblUnlimitAmiiboInfo.AutoSize = true;
			this.lblUnlimitAmiiboInfo.Location = new global::System.Drawing.Point(294, 20);
			this.lblUnlimitAmiiboInfo.Name = "lblUnlimitAmiiboInfo";
			this.lblUnlimitAmiiboInfo.Size = new global::System.Drawing.Size(75, 13);
			this.lblUnlimitAmiiboInfo.TabIndex = 21;
			this.lblUnlimitAmiiboInfo.Text = "<informations>";
			this.chkUnlimitAmiiboSet.AutoSize = true;
			this.chkUnlimitAmiiboSet.Location = new global::System.Drawing.Point(132, 19);
			this.chkUnlimitAmiiboSet.Name = "chkUnlimitAmiiboSet";
			this.chkUnlimitAmiiboSet.Size = new global::System.Drawing.Size(91, 17);
			this.chkUnlimitAmiiboSet.TabIndex = 20;
			this.chkUnlimitAmiiboSet.Text = "Unlimit Amiibo";
			this.chkUnlimitAmiiboSet.UseVisualStyleBackColor = true;
			this.txtUnlimitAmiiboHotKey.Location = new global::System.Drawing.Point(64, 17);
			this.txtUnlimitAmiiboHotKey.Name = "txtUnlimitAmiiboHotKey";
			this.txtUnlimitAmiiboHotKey.ReadOnly = true;
			this.txtUnlimitAmiiboHotKey.Size = new global::System.Drawing.Size(62, 20);
			this.txtUnlimitAmiiboHotKey.TabIndex = 19;
			this.chkUnlimitAmiiboUseHotkey.AutoSize = true;
			this.chkUnlimitAmiiboUseHotkey.Location = new global::System.Drawing.Point(6, 19);
			this.chkUnlimitAmiiboUseHotkey.Name = "chkUnlimitAmiiboUseHotkey";
			this.chkUnlimitAmiiboUseHotkey.Size = new global::System.Drawing.Size(61, 17);
			this.chkUnlimitAmiiboUseHotkey.TabIndex = 0;
			this.chkUnlimitAmiiboUseHotkey.Text = "HotKey";
			this.chkUnlimitAmiiboUseHotkey.UseVisualStyleBackColor = true;
			this.tabPage13.Controls.Add(this.gbActionsFilter);
			this.tabPage13.Controls.Add(this.gbActionsSettings);
			this.tabPage13.Controls.Add(this.groupBox9);
			this.tabPage13.Location = new global::System.Drawing.Point(4, 22);
			this.tabPage13.Name = "tabPage13";
			this.tabPage13.Padding = new global::System.Windows.Forms.Padding(3);
			this.tabPage13.Size = new global::System.Drawing.Size(499, 241);
			this.tabPage13.TabIndex = 0;
			this.tabPage13.Text = "Custom";
			this.tabPage13.UseVisualStyleBackColor = true;
			this.gbActionsFilter.Controls.Add(this.lstActionsFilter);
			this.gbActionsFilter.Controls.Add(this.optionActionsFilterList);
			this.gbActionsFilter.Controls.Add(this.optionActionsNoFilter);
			this.gbActionsFilter.Enabled = false;
			this.gbActionsFilter.Location = new global::System.Drawing.Point(317, 6);
			this.gbActionsFilter.Name = "gbActionsFilter";
			this.gbActionsFilter.Size = new global::System.Drawing.Size(176, 230);
			this.gbActionsFilter.TabIndex = 27;
			this.gbActionsFilter.TabStop = false;
			this.gbActionsFilter.Text = "Filter";
			this.lstActionsFilter.FormattingEnabled = true;
			this.lstActionsFilter.Location = new global::System.Drawing.Point(8, 71);
			this.lstActionsFilter.Name = "lstActionsFilter";
			this.lstActionsFilter.Size = new global::System.Drawing.Size(162, 147);
			this.lstActionsFilter.TabIndex = 2;
			this.optionActionsFilterList.AutoSize = true;
			this.optionActionsFilterList.Location = new global::System.Drawing.Point(8, 42);
			this.optionActionsFilterList.Name = "optionActionsFilterList";
			this.optionActionsFilterList.Size = new global::System.Drawing.Size(138, 17);
			this.optionActionsFilterList.TabIndex = 1;
			this.optionActionsFilterList.Text = "Apply only to items in list";
			this.optionActionsFilterList.UseVisualStyleBackColor = true;
			this.optionActionsNoFilter.AutoSize = true;
			this.optionActionsNoFilter.Checked = true;
			this.optionActionsNoFilter.Location = new global::System.Drawing.Point(8, 19);
			this.optionActionsNoFilter.Name = "optionActionsNoFilter";
			this.optionActionsNoFilter.Size = new global::System.Drawing.Size(61, 17);
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
			this.gbActionsSettings.Location = new global::System.Drawing.Point(141, 6);
			this.gbActionsSettings.Name = "gbActionsSettings";
			this.gbActionsSettings.Size = new global::System.Drawing.Size(166, 230);
			this.gbActionsSettings.TabIndex = 23;
			this.gbActionsSettings.TabStop = false;
			this.gbActionsSettings.Text = "Settings";
			this.chkActionsUseHotkey.AutoSize = true;
			this.chkActionsUseHotkey.Location = new global::System.Drawing.Point(6, 180);
			this.chkActionsUseHotkey.Name = "chkActionsUseHotkey";
			this.chkActionsUseHotkey.Size = new global::System.Drawing.Size(60, 17);
			this.chkActionsUseHotkey.TabIndex = 19;
			this.chkActionsUseHotkey.Text = "Hotkey";
			this.chkActionsUseHotkey.UseVisualStyleBackColor = true;
			this.txtActionsHotKey.Location = new global::System.Drawing.Point(95, 176);
			this.txtActionsHotKey.Name = "txtActionsHotKey";
			this.txtActionsHotKey.ReadOnly = true;
			this.txtActionsHotKey.Size = new global::System.Drawing.Size(62, 20);
			this.txtActionsHotKey.TabIndex = 18;
			this.chkActionsDisableWhenDone.AutoSize = true;
			this.chkActionsDisableWhenDone.Location = new global::System.Drawing.Point(6, 160);
			this.chkActionsDisableWhenDone.Name = "chkActionsDisableWhenDone";
			this.chkActionsDisableWhenDone.Size = new global::System.Drawing.Size(104, 17);
			this.chkActionsDisableWhenDone.TabIndex = 17;
			this.chkActionsDisableWhenDone.Text = "Stop when done";
			this.chkActionsDisableWhenDone.UseVisualStyleBackColor = true;
			this.cbActionsList.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbActionsList.FormattingEnabled = true;
			this.cbActionsList.Location = new global::System.Drawing.Point(6, 19);
			this.cbActionsList.Name = "cbActionsList";
			this.cbActionsList.Size = new global::System.Drawing.Size(151, 21);
			this.cbActionsList.TabIndex = 16;
			this.chkActionsActiveInactive.AutoSize = true;
			this.chkActionsActiveInactive.Location = new global::System.Drawing.Point(6, 209);
			this.chkActionsActiveInactive.Name = "chkActionsActiveInactive";
			this.chkActionsActiveInactive.Size = new global::System.Drawing.Size(105, 17);
			this.chkActionsActiveInactive.TabIndex = 15;
			this.chkActionsActiveInactive.Text = "Active / Inactive";
			this.chkActionsActiveInactive.UseVisualStyleBackColor = true;
			this.txtActionsMax.Location = new global::System.Drawing.Point(95, 136);
			this.txtActionsMax.Name = "txtActionsMax";
			this.txtActionsMax.Size = new global::System.Drawing.Size(62, 20);
			this.txtActionsMax.TabIndex = 13;
			this.label41.AutoSize = true;
			this.label41.Location = new global::System.Drawing.Point(22, 139);
			this.label41.Name = "label41";
			this.label41.Size = new global::System.Drawing.Size(27, 13);
			this.label41.TabIndex = 14;
			this.label41.Text = "Max";
			this.txtActionsQuantity.Location = new global::System.Drawing.Point(95, 116);
			this.txtActionsQuantity.Name = "txtActionsQuantity";
			this.txtActionsQuantity.Size = new global::System.Drawing.Size(62, 20);
			this.txtActionsQuantity.TabIndex = 11;
			this.label42.AutoSize = true;
			this.label42.Location = new global::System.Drawing.Point(22, 119);
			this.label42.Name = "label42";
			this.label42.Size = new global::System.Drawing.Size(46, 13);
			this.label42.TabIndex = 12;
			this.label42.Text = "Quantity";
			this.txtActionsTimer.Location = new global::System.Drawing.Point(95, 96);
			this.txtActionsTimer.Name = "txtActionsTimer";
			this.txtActionsTimer.Size = new global::System.Drawing.Size(62, 20);
			this.txtActionsTimer.TabIndex = 9;
			this.label43.AutoSize = true;
			this.label43.Location = new global::System.Drawing.Point(22, 99);
			this.label43.Name = "label43";
			this.label43.Size = new global::System.Drawing.Size(59, 13);
			this.label43.TabIndex = 10;
			this.label43.Text = "Timer (sec)";
			this.txtActionsFixed.Location = new global::System.Drawing.Point(95, 51);
			this.txtActionsFixed.Name = "txtActionsFixed";
			this.txtActionsFixed.Size = new global::System.Drawing.Size(62, 20);
			this.txtActionsFixed.TabIndex = 7;
			this.optionActionsTimer.AutoSize = true;
			this.optionActionsTimer.Checked = true;
			this.optionActionsTimer.Location = new global::System.Drawing.Point(6, 75);
			this.optionActionsTimer.Name = "optionActionsTimer";
			this.optionActionsTimer.Size = new global::System.Drawing.Size(83, 17);
			this.optionActionsTimer.TabIndex = 1;
			this.optionActionsTimer.TabStop = true;
			this.optionActionsTimer.Text = "Timer based";
			this.optionActionsTimer.UseVisualStyleBackColor = true;
			this.optionActionsFixed.AutoSize = true;
			this.optionActionsFixed.Location = new global::System.Drawing.Point(6, 52);
			this.optionActionsFixed.Name = "optionActionsFixed";
			this.optionActionsFixed.Size = new global::System.Drawing.Size(50, 17);
			this.optionActionsFixed.TabIndex = 0;
			this.optionActionsFixed.Text = "Fixed";
			this.optionActionsFixed.UseVisualStyleBackColor = true;
			this.groupBox9.Controls.Add(this.btnActionsRemove);
			this.groupBox9.Controls.Add(this.lstActionsRegistered);
			this.groupBox9.Controls.Add(this.btnActionsNew);
			this.groupBox9.Location = new global::System.Drawing.Point(6, 6);
			this.groupBox9.Name = "groupBox9";
			this.groupBox9.Size = new global::System.Drawing.Size(129, 230);
			this.groupBox9.TabIndex = 0;
			this.groupBox9.TabStop = false;
			this.groupBox9.Text = "Registered";
			this.btnActionsRemove.Location = new global::System.Drawing.Point(9, 197);
			this.btnActionsRemove.Name = "btnActionsRemove";
			this.btnActionsRemove.Size = new global::System.Drawing.Size(114, 23);
			this.btnActionsRemove.TabIndex = 30;
			this.btnActionsRemove.Text = "Remove";
			this.btnActionsRemove.UseVisualStyleBackColor = true;
			this.lstActionsRegistered.FormattingEnabled = true;
			this.lstActionsRegistered.Location = new global::System.Drawing.Point(9, 19);
			this.lstActionsRegistered.Name = "lstActionsRegistered";
			this.lstActionsRegistered.Size = new global::System.Drawing.Size(114, 147);
			this.lstActionsRegistered.TabIndex = 0;
			this.btnActionsNew.Location = new global::System.Drawing.Point(9, 172);
			this.btnActionsNew.Name = "btnActionsNew";
			this.btnActionsNew.Size = new global::System.Drawing.Size(114, 23);
			this.btnActionsNew.TabIndex = 28;
			this.btnActionsNew.Text = "New";
			this.btnActionsNew.UseVisualStyleBackColor = true;
			this.tabControl2.Controls.Add(this.tabPage10);
			this.tabControl2.Controls.Add(this.tabPage22);
			this.tabControl2.Location = new global::System.Drawing.Point(12, 310);
			this.tabControl2.Name = "tabControl2";
			this.tabControl2.SelectedIndex = 0;
			this.tabControl2.Size = new global::System.Drawing.Size(484, 173);
			this.tabControl2.TabIndex = 6;
			this.tabPage10.Controls.Add(this.groupBox5);
			this.tabPage10.Controls.Add(this.groupBox2);
			this.tabPage10.Controls.Add(this.groupBox1);
			this.tabPage10.Controls.Add(this.groupBox12);
			this.tabPage10.Controls.Add(this.groupBox11);
			this.tabPage10.Location = new global::System.Drawing.Point(4, 22);
			this.tabPage10.Name = "tabPage10";
			this.tabPage10.Padding = new global::System.Windows.Forms.Padding(3);
			this.tabPage10.Size = new global::System.Drawing.Size(476, 147);
			this.tabPage10.TabIndex = 0;
			this.tabPage10.Text = "Status && Settings";
			this.tabPage10.UseVisualStyleBackColor = true;
			this.groupBox5.Controls.Add(this.label55);
			this.groupBox5.Controls.Add(this.label53);
			this.groupBox5.Controls.Add(this.numSpacingMs);
			this.groupBox5.Controls.Add(this.numInternalLoopMs);
			this.groupBox5.Location = new global::System.Drawing.Point(193, 7);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new global::System.Drawing.Size(100, 135);
			this.groupBox5.TabIndex = 26;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Timings";
			this.label55.AutoSize = true;
			this.label55.Location = new global::System.Drawing.Point(9, 77);
			this.label55.Name = "label55";
			this.label55.Size = new global::System.Drawing.Size(68, 13);
			this.label55.TabIndex = 3;
			this.label55.Text = "Spacing (ms)";
			this.label53.AutoSize = true;
			this.label53.Location = new global::System.Drawing.Point(9, 18);
			this.label53.Name = "label53";
			this.label53.Size = new global::System.Drawing.Size(87, 13);
			this.label53.TabIndex = 2;
			this.label53.Text = "Internal loop (ms)";
			this.numSpacingMs.Location = new global::System.Drawing.Point(12, 93);
			global::System.Windows.Forms.NumericUpDown arg_BCE7_0 = this.numSpacingMs;
			int[] expr_BCDA = new int[4];
			expr_BCDA[0] = 1000;
			arg_BCE7_0.Maximum = new decimal(expr_BCDA);
			this.numSpacingMs.Name = "numSpacingMs";
			this.numSpacingMs.Size = new global::System.Drawing.Size(65, 20);
			this.numSpacingMs.TabIndex = 1;
			this.numSpacingMs.ValueChanged += new global::System.EventHandler(this.numSpacingMs_ValueChanged);
			this.numInternalLoopMs.Location = new global::System.Drawing.Point(12, 34);
			global::System.Windows.Forms.NumericUpDown arg_BD60_0 = this.numInternalLoopMs;
			int[] expr_BD53 = new int[4];
			expr_BD53[0] = 1000;
			arg_BD60_0.Maximum = new decimal(expr_BD53);
			this.numInternalLoopMs.Name = "numInternalLoopMs";
			this.numInternalLoopMs.Size = new global::System.Drawing.Size(65, 20);
			this.numInternalLoopMs.TabIndex = 0;
			global::System.Windows.Forms.NumericUpDown arg_BDAB_0 = this.numInternalLoopMs;
			int[] expr_BDA1 = new int[4];
			expr_BDA1[0] = 100;
			arg_BDAB_0.Value = new decimal(expr_BDA1);
			this.numInternalLoopMs.ValueChanged += new global::System.EventHandler(this.numInternalLoopMs_ValueChanged);
			this.groupBox2.Controls.Add(this.btnGameProcessResume);
			this.groupBox2.Controls.Add(this.btnGameProcessPause);
			this.groupBox2.Location = new global::System.Drawing.Point(299, 94);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new global::System.Drawing.Size(171, 48);
			this.groupBox2.TabIndex = 25;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Game Process";
			this.btnGameProcessResume.Location = new global::System.Drawing.Point(85, 18);
			this.btnGameProcessResume.Name = "btnGameProcessResume";
			this.btnGameProcessResume.Size = new global::System.Drawing.Size(75, 23);
			this.btnGameProcessResume.TabIndex = 2;
			this.btnGameProcessResume.Text = "Resume";
			this.btnGameProcessResume.UseVisualStyleBackColor = true;
			this.btnGameProcessResume.Click += new global::System.EventHandler(this.btnGameProcessResume_Click);
			this.btnGameProcessPause.Location = new global::System.Drawing.Point(7, 18);
			this.btnGameProcessPause.Name = "btnGameProcessPause";
			this.btnGameProcessPause.Size = new global::System.Drawing.Size(75, 23);
			this.btnGameProcessPause.TabIndex = 1;
			this.btnGameProcessPause.Text = "Pause";
			this.btnGameProcessPause.UseVisualStyleBackColor = true;
			this.btnGameProcessPause.Click += new global::System.EventHandler(this.btnGameProcessPause_Click);
			this.groupBox1.Controls.Add(this.btnSettingsImport);
			this.groupBox1.Controls.Add(this.btnSettingsExport);
			this.groupBox1.Controls.Add(this.btnSettingsClear);
			this.groupBox1.Controls.Add(this.btnSettingsSave);
			this.groupBox1.Location = new global::System.Drawing.Point(299, 6);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new global::System.Drawing.Size(171, 82);
			this.groupBox1.TabIndex = 24;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Settings";
			this.btnSettingsImport.Location = new global::System.Drawing.Point(88, 48);
			this.btnSettingsImport.Name = "btnSettingsImport";
			this.btnSettingsImport.Size = new global::System.Drawing.Size(75, 23);
			this.btnSettingsImport.TabIndex = 3;
			this.btnSettingsImport.Text = "Import";
			this.btnSettingsImport.UseVisualStyleBackColor = true;
			this.btnSettingsImport.Click += new global::System.EventHandler(this.btnSettingsImport_Click);
			this.btnSettingsExport.Location = new global::System.Drawing.Point(88, 19);
			this.btnSettingsExport.Name = "btnSettingsExport";
			this.btnSettingsExport.Size = new global::System.Drawing.Size(75, 23);
			this.btnSettingsExport.TabIndex = 2;
			this.btnSettingsExport.Text = "Export";
			this.btnSettingsExport.UseVisualStyleBackColor = true;
			this.btnSettingsExport.Click += new global::System.EventHandler(this.btnSettingsExport_Click);
			this.btnSettingsClear.Location = new global::System.Drawing.Point(7, 48);
			this.btnSettingsClear.Name = "btnSettingsClear";
			this.btnSettingsClear.Size = new global::System.Drawing.Size(75, 23);
			this.btnSettingsClear.TabIndex = 1;
			this.btnSettingsClear.Text = "Clear";
			this.btnSettingsClear.UseVisualStyleBackColor = true;
			this.btnSettingsClear.Click += new global::System.EventHandler(this.btnSettingsClear_Click);
			this.btnSettingsSave.Location = new global::System.Drawing.Point(7, 19);
			this.btnSettingsSave.Name = "btnSettingsSave";
			this.btnSettingsSave.Size = new global::System.Drawing.Size(75, 23);
			this.btnSettingsSave.TabIndex = 0;
			this.btnSettingsSave.Text = "Save";
			this.btnSettingsSave.UseVisualStyleBackColor = true;
			this.btnSettingsSave.Click += new global::System.EventHandler(this.btnSettingsSave_Click);
			this.groupBox12.Controls.Add(this.chkUpdateList);
			this.groupBox12.Controls.Add(this.txtTimerUpdateList);
			this.groupBox12.Controls.Add(this.label45);
			this.groupBox12.Location = new global::System.Drawing.Point(6, 84);
			this.groupBox12.Name = "groupBox12";
			this.groupBox12.Size = new global::System.Drawing.Size(179, 58);
			this.groupBox12.TabIndex = 23;
			this.groupBox12.TabStop = false;
			this.groupBox12.Text = "Update list from memory";
			this.chkUpdateList.AutoSize = true;
			this.chkUpdateList.Location = new global::System.Drawing.Point(15, 35);
			this.chkUpdateList.Name = "chkUpdateList";
			this.chkUpdateList.Size = new global::System.Drawing.Size(101, 17);
			this.chkUpdateList.TabIndex = 6;
			this.chkUpdateList.Text = "Activate update";
			this.chkUpdateList.UseVisualStyleBackColor = true;
			this.txtTimerUpdateList.Location = new global::System.Drawing.Point(84, 13);
			this.txtTimerUpdateList.Name = "txtTimerUpdateList";
			this.txtTimerUpdateList.Size = new global::System.Drawing.Size(44, 20);
			this.txtTimerUpdateList.TabIndex = 6;
			this.txtTimerUpdateList.Text = "15";
			this.label45.AutoSize = true;
			this.label45.Location = new global::System.Drawing.Point(6, 16);
			this.label45.Name = "label45";
			this.label45.Size = new global::System.Drawing.Size(59, 13);
			this.label45.TabIndex = 6;
			this.label45.Text = "Timer (sec)";
			this.groupBox11.Controls.Add(this.lstEquippedWeapons);
			this.groupBox11.Location = new global::System.Drawing.Point(7, 6);
			this.groupBox11.Name = "groupBox11";
			this.groupBox11.Size = new global::System.Drawing.Size(180, 72);
			this.groupBox11.TabIndex = 22;
			this.groupBox11.TabStop = false;
			this.groupBox11.Text = "Equipped Weapons";
			this.lstEquippedWeapons.FormattingEnabled = true;
			this.lstEquippedWeapons.Location = new global::System.Drawing.Point(8, 21);
			this.lstEquippedWeapons.Name = "lstEquippedWeapons";
			this.lstEquippedWeapons.Size = new global::System.Drawing.Size(166, 43);
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
			this.tabPage22.Location = new global::System.Drawing.Point(4, 22);
			this.tabPage22.Name = "tabPage22";
			this.tabPage22.Padding = new global::System.Windows.Forms.Padding(3);
			this.tabPage22.Size = new global::System.Drawing.Size(476, 147);
			this.tabPage22.TabIndex = 1;
			this.tabPage22.Text = "Testing";
			this.tabPage22.UseVisualStyleBackColor = true;
			this.btntxtFindMemoryRegionBySize.Enabled = false;
			this.btntxtFindMemoryRegionBySize.Location = new global::System.Drawing.Point(293, 29);
			this.btntxtFindMemoryRegionBySize.Name = "btntxtFindMemoryRegionBySize";
			this.btntxtFindMemoryRegionBySize.Size = new global::System.Drawing.Size(66, 23);
			this.btntxtFindMemoryRegionBySize.TabIndex = 52;
			this.btntxtFindMemoryRegionBySize.Text = "Find";
			this.btntxtFindMemoryRegionBySize.UseVisualStyleBackColor = true;
			this.btntxtFindMemoryRegionBySize.Click += new global::System.EventHandler(this.btntxtFindMemoryRegionBySize_Click);
			this.label73.AutoSize = true;
			this.label73.Location = new global::System.Drawing.Point(10, 34);
			this.label73.Name = "label73";
			this.label73.Size = new global::System.Drawing.Size(141, 13);
			this.label73.TabIndex = 51;
			this.label73.Text = "Find Memory Region by Size";
			this.txtFindMemoryRegionBySize.Location = new global::System.Drawing.Point(175, 31);
			this.txtFindMemoryRegionBySize.Name = "txtFindMemoryRegionBySize";
			this.txtFindMemoryRegionBySize.Size = new global::System.Drawing.Size(112, 20);
			this.txtFindMemoryRegionBySize.TabIndex = 50;
			this.btnFindMemoryRegionByAddress.Enabled = false;
			this.btnFindMemoryRegionByAddress.Location = new global::System.Drawing.Point(293, 7);
			this.btnFindMemoryRegionByAddress.Name = "btnFindMemoryRegionByAddress";
			this.btnFindMemoryRegionByAddress.Size = new global::System.Drawing.Size(66, 23);
			this.btnFindMemoryRegionByAddress.TabIndex = 49;
			this.btnFindMemoryRegionByAddress.Text = "Find";
			this.btnFindMemoryRegionByAddress.UseVisualStyleBackColor = true;
			this.btnFindMemoryRegionByAddress.Click += new global::System.EventHandler(this.btnFindMemoryRegionByAddress_Click);
			this.label72.AutoSize = true;
			this.label72.Location = new global::System.Drawing.Point(10, 12);
			this.label72.Name = "label72";
			this.label72.Size = new global::System.Drawing.Size(159, 13);
			this.label72.TabIndex = 48;
			this.label72.Text = "Find Memory Region by Address";
			this.txtFindMemoryRegionByAddress.Location = new global::System.Drawing.Point(175, 9);
			this.txtFindMemoryRegionByAddress.Name = "txtFindMemoryRegionByAddress";
			this.txtFindMemoryRegionByAddress.Size = new global::System.Drawing.Size(112, 20);
			this.txtFindMemoryRegionByAddress.TabIndex = 47;
			this.label48.AutoSize = true;
			this.label48.Location = new global::System.Drawing.Point(623, 9);
			this.label48.Name = "label48";
			this.label48.Size = new global::System.Drawing.Size(378, 13);
			this.label48.TabIndex = 30;
			this.label48.Text = "You may need to run this program as Administrator for the memory scan to work";
			this.lblVersion.AutoSize = true;
			this.lblVersion.Location = new global::System.Drawing.Point(923, 25);
			this.lblVersion.Name = "lblVersion";
			this.lblVersion.Size = new global::System.Drawing.Size(41, 13);
			this.lblVersion.TabIndex = 31;
			this.lblVersion.Text = "version";
			this.button1.Location = new global::System.Drawing.Point(271, 9);
			this.button1.Name = "button1";
			this.button1.Size = new global::System.Drawing.Size(93, 23);
			this.button1.TabIndex = 32;
			this.button1.Text = "Dump Memory";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Visible = false;
			this.button1.Click += new global::System.EventHandler(this.button1_Click);
			this.button2.Location = new global::System.Drawing.Point(370, 9);
			this.button2.Name = "button2";
			this.button2.Size = new global::System.Drawing.Size(97, 23);
			this.button2.TabIndex = 33;
			this.button2.Text = "Compare Dump";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Visible = false;
			this.button2.Click += new global::System.EventHandler(this.button2_Click);
			this.button3.Location = new global::System.Drawing.Point(473, 9);
			this.button3.Name = "button3";
			this.button3.Size = new global::System.Drawing.Size(97, 23);
			this.button3.TabIndex = 34;
			this.button3.Text = "Generate Report";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Visible = false;
			this.button3.Click += new global::System.EventHandler(this.button3_Click);
			this.btnMemoryRegions.Enabled = false;
			this.btnMemoryRegions.Location = new global::System.Drawing.Point(365, 9);
			this.btnMemoryRegions.Name = "btnMemoryRegions";
			this.btnMemoryRegions.Size = new global::System.Drawing.Size(105, 23);
			this.btnMemoryRegions.TabIndex = 53;
			this.btnMemoryRegions.Text = "Memory Regions";
			this.btnMemoryRegions.UseVisualStyleBackColor = true;
			this.btnMemoryRegions.Click += new global::System.EventHandler(this.btnMemoryRegions_Click);
			this.trackTime.AutoSize = false;
			this.trackTime.Location = new global::System.Drawing.Point(6, 121);
			this.trackTime.Maximum = 360;
			this.trackTime.Name = "trackTime";
			this.trackTime.Size = new global::System.Drawing.Size(457, 20);
			this.trackTime.TabIndex = 54;
			this.trackTime.TickStyle = global::System.Windows.Forms.TickStyle.None;
			this.trackTime.ValueChanged += new global::System.EventHandler(this.trackTime_ValueChanged);
			this.btnCompareAddress.Enabled = false;
			this.btnCompareAddress.Location = new global::System.Drawing.Point(293, 51);
			this.btnCompareAddress.Name = "btnCompareAddress";
			this.btnCompareAddress.Size = new global::System.Drawing.Size(66, 23);
			this.btnCompareAddress.TabIndex = 57;
			this.btnCompareAddress.Text = "Comp";
			this.btnCompareAddress.UseVisualStyleBackColor = true;
			this.btnCompareAddress.Click += new global::System.EventHandler(this.btnCompareAddress_Click);
			this.label74.AutoSize = true;
			this.label74.Location = new global::System.Drawing.Point(10, 56);
			this.label74.Name = "label74";
			this.label74.Size = new global::System.Drawing.Size(145, 13);
			this.label74.TabIndex = 56;
			this.label74.Text = "Compare address with offsets";
			this.txtCompareAddress.Location = new global::System.Drawing.Point(175, 53);
			this.txtCompareAddress.Name = "txtCompareAddress";
			this.txtCompareAddress.Size = new global::System.Drawing.Size(112, 20);
			this.txtCompareAddress.TabIndex = 55;
			this.btnNoStaminaBar.Location = new global::System.Drawing.Point(15, 92);
			this.btnNoStaminaBar.Name = "btnNoStaminaBar";
			this.btnNoStaminaBar.Size = new global::System.Drawing.Size(96, 23);
			this.btnNoStaminaBar.TabIndex = 58;
			this.btnNoStaminaBar.Text = "No Stamina Bar";
			this.btnNoStaminaBar.UseVisualStyleBackColor = true;
			this.btnNoStaminaBar.Click += new global::System.EventHandler(this.btnNoStaminaBar_Click);
			this.btnRestoreStaminaBar.Location = new global::System.Drawing.Point(119, 92);
			this.btnRestoreStaminaBar.Name = "btnRestoreStaminaBar";
			this.btnRestoreStaminaBar.Size = new global::System.Drawing.Size(124, 23);
			this.btnRestoreStaminaBar.TabIndex = 59;
			this.btnRestoreStaminaBar.Text = "Restore Stamina Bar";
			this.btnRestoreStaminaBar.UseVisualStyleBackColor = true;
			this.btnRestoreStaminaBar.Click += new global::System.EventHandler(this.btnRestoreStaminaBar_Click);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.None;
			base.ClientSize = new global::System.Drawing.Size(1017, 494);
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
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.Name = "FrmMain";
			this.Text = "Cemu - Breath of the Wild Memory Editor - by LibreVR";
			base.FormClosing += new global::System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
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
			((global::System.ComponentModel.ISupportInitialize)this.numSpacingMs).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.numInternalLoopMs).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox12.ResumeLayout(false);
			this.groupBox12.PerformLayout();
			this.groupBox11.ResumeLayout(false);
			this.tabPage22.ResumeLayout(false);
			this.tabPage22.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.trackTime).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x0400005E RID: 94
		private global::System.ComponentModel.IContainer components;

		// Token: 0x0400005F RID: 95
		private global::System.Windows.Forms.TabPage tabPage9;

		// Token: 0x04000060 RID: 96
		private global::System.Windows.Forms.TabPage tabPage1;

		// Token: 0x04000061 RID: 97
		private global::System.Windows.Forms.TabPage tabPage2;

		// Token: 0x04000062 RID: 98
		private global::System.Windows.Forms.TabPage tabPage3;

		// Token: 0x04000063 RID: 99
		private global::System.Windows.Forms.TabPage tabPage4;

		// Token: 0x04000064 RID: 100
		private global::System.Windows.Forms.TabPage tabPage5;

		// Token: 0x04000065 RID: 101
		private global::System.Windows.Forms.TabPage tabPage6;

		// Token: 0x04000066 RID: 102
		private global::System.Windows.Forms.TabPage tabPage7;

		// Token: 0x04000067 RID: 103
		private global::System.Windows.Forms.TabPage tabPage8;

		// Token: 0x04000068 RID: 104
		private global::System.Windows.Forms.TabPage tabPage12;

		// Token: 0x04000069 RID: 105
		private global::System.Windows.Forms.Button btnScan;

		// Token: 0x0400006A RID: 106
		public global::System.Windows.Forms.ListBox lstInventory;

		// Token: 0x0400006B RID: 107
		private global::System.Windows.Forms.Label lblScan;

		// Token: 0x0400006C RID: 108
		private global::System.Windows.Forms.GroupBox gbInventoryEdit;

		// Token: 0x0400006D RID: 109
		private global::System.Windows.Forms.Label label3;

		// Token: 0x0400006E RID: 110
		private global::System.Windows.Forms.Label label2;

		// Token: 0x0400006F RID: 111
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000070 RID: 112
		public global::System.Windows.Forms.ComboBox cbInventoryItemName;

		// Token: 0x04000071 RID: 113
		public global::System.Windows.Forms.TextBox txtInventoryItemQtDur;

		// Token: 0x04000072 RID: 114
		public global::System.Windows.Forms.TextBox txtInventoryItemID;

		// Token: 0x04000073 RID: 115
		private global::System.Windows.Forms.Label label4;

		// Token: 0x04000074 RID: 116
		public global::System.Windows.Forms.TextBox txtInventoryItemBonusValue;

		// Token: 0x04000075 RID: 117
		private global::System.Windows.Forms.Label label5;

		// Token: 0x04000076 RID: 118
		public global::System.Windows.Forms.TextBox txtInventoryItemBonusType;

		// Token: 0x04000077 RID: 119
		private global::System.Windows.Forms.GroupBox gbWeaponsEdit;

		// Token: 0x04000078 RID: 120
		public global::System.Windows.Forms.Button btnWeaponsItemUpdate;

		// Token: 0x04000079 RID: 121
		private global::System.Windows.Forms.Label label6;

		// Token: 0x0400007A RID: 122
		public global::System.Windows.Forms.TextBox txtWeaponsItemBonusValue;

		// Token: 0x0400007B RID: 123
		private global::System.Windows.Forms.Label label7;

		// Token: 0x0400007C RID: 124
		public global::System.Windows.Forms.TextBox txtWeaponsItemBonusType;

		// Token: 0x0400007D RID: 125
		private global::System.Windows.Forms.Label label8;

		// Token: 0x0400007E RID: 126
		public global::System.Windows.Forms.ComboBox cbWeaponsItemName;

		// Token: 0x0400007F RID: 127
		private global::System.Windows.Forms.Label label9;

		// Token: 0x04000080 RID: 128
		public global::System.Windows.Forms.TextBox txtWeaponsItemQtDur;

		// Token: 0x04000081 RID: 129
		private global::System.Windows.Forms.Label label10;

		// Token: 0x04000082 RID: 130
		public global::System.Windows.Forms.TextBox txtWeaponsItemID;

		// Token: 0x04000083 RID: 131
		public global::System.Windows.Forms.ListBox lstWeapons;

		// Token: 0x04000084 RID: 132
		private global::System.Windows.Forms.GroupBox gbArcheryEdit;

		// Token: 0x04000085 RID: 133
		public global::System.Windows.Forms.Button btnArcheryItemUpdate;

		// Token: 0x04000086 RID: 134
		private global::System.Windows.Forms.Label label11;

		// Token: 0x04000087 RID: 135
		public global::System.Windows.Forms.TextBox txtArcheryItemBonusValue;

		// Token: 0x04000088 RID: 136
		private global::System.Windows.Forms.Label label12;

		// Token: 0x04000089 RID: 137
		public global::System.Windows.Forms.TextBox txtArcheryItemBonusType;

		// Token: 0x0400008A RID: 138
		private global::System.Windows.Forms.Label label13;

		// Token: 0x0400008B RID: 139
		public global::System.Windows.Forms.ComboBox cbArcheryItemName;

		// Token: 0x0400008C RID: 140
		private global::System.Windows.Forms.Label label14;

		// Token: 0x0400008D RID: 141
		public global::System.Windows.Forms.TextBox txtArcheryItemQtDur;

		// Token: 0x0400008E RID: 142
		private global::System.Windows.Forms.Label label15;

		// Token: 0x0400008F RID: 143
		public global::System.Windows.Forms.TextBox txtArcheryItemID;

		// Token: 0x04000090 RID: 144
		public global::System.Windows.Forms.ListBox lstArchery;

		// Token: 0x04000091 RID: 145
		private global::System.Windows.Forms.GroupBox gbShieldsEdit;

		// Token: 0x04000092 RID: 146
		public global::System.Windows.Forms.Button btnShieldsItemUpdate;

		// Token: 0x04000093 RID: 147
		private global::System.Windows.Forms.Label label16;

		// Token: 0x04000094 RID: 148
		public global::System.Windows.Forms.TextBox txtShieldsItemBonusValue;

		// Token: 0x04000095 RID: 149
		private global::System.Windows.Forms.Label label17;

		// Token: 0x04000096 RID: 150
		public global::System.Windows.Forms.TextBox txtShieldsItemBonusType;

		// Token: 0x04000097 RID: 151
		private global::System.Windows.Forms.Label label18;

		// Token: 0x04000098 RID: 152
		public global::System.Windows.Forms.ComboBox cbShieldsItemName;

		// Token: 0x04000099 RID: 153
		private global::System.Windows.Forms.Label label19;

		// Token: 0x0400009A RID: 154
		public global::System.Windows.Forms.TextBox txtShieldsItemQtDur;

		// Token: 0x0400009B RID: 155
		private global::System.Windows.Forms.Label label20;

		// Token: 0x0400009C RID: 156
		public global::System.Windows.Forms.TextBox txtShieldsItemID;

		// Token: 0x0400009D RID: 157
		public global::System.Windows.Forms.ListBox lstShields;

		// Token: 0x0400009E RID: 158
		private global::System.Windows.Forms.GroupBox gbArmorsEdit;

		// Token: 0x0400009F RID: 159
		public global::System.Windows.Forms.Button btnArmorsItemUpdate;

		// Token: 0x040000A0 RID: 160
		private global::System.Windows.Forms.Label label21;

		// Token: 0x040000A1 RID: 161
		public global::System.Windows.Forms.TextBox txtArmorsItemBonusValue;

		// Token: 0x040000A2 RID: 162
		private global::System.Windows.Forms.Label label22;

		// Token: 0x040000A3 RID: 163
		public global::System.Windows.Forms.TextBox txtArmorsItemBonusType;

		// Token: 0x040000A4 RID: 164
		private global::System.Windows.Forms.Label label23;

		// Token: 0x040000A5 RID: 165
		public global::System.Windows.Forms.ComboBox cbArmorsItemName;

		// Token: 0x040000A6 RID: 166
		private global::System.Windows.Forms.Label label24;

		// Token: 0x040000A7 RID: 167
		public global::System.Windows.Forms.TextBox txtArmorsItemQtDur;

		// Token: 0x040000A8 RID: 168
		private global::System.Windows.Forms.Label label25;

		// Token: 0x040000A9 RID: 169
		public global::System.Windows.Forms.TextBox txtArmorsItemID;

		// Token: 0x040000AA RID: 170
		public global::System.Windows.Forms.ListBox lstArmors;

		// Token: 0x040000AB RID: 171
		private global::System.Windows.Forms.GroupBox gbMaterialsEdit;

		// Token: 0x040000AC RID: 172
		public global::System.Windows.Forms.Button btnMaterialsItemUpdate;

		// Token: 0x040000AD RID: 173
		private global::System.Windows.Forms.Label label26;

		// Token: 0x040000AE RID: 174
		public global::System.Windows.Forms.TextBox txtMaterialsItemBonusValue;

		// Token: 0x040000AF RID: 175
		private global::System.Windows.Forms.Label label27;

		// Token: 0x040000B0 RID: 176
		public global::System.Windows.Forms.TextBox txtMaterialsItemBonusType;

		// Token: 0x040000B1 RID: 177
		private global::System.Windows.Forms.Label label28;

		// Token: 0x040000B2 RID: 178
		public global::System.Windows.Forms.ComboBox cbMaterialsItemName;

		// Token: 0x040000B3 RID: 179
		private global::System.Windows.Forms.Label label29;

		// Token: 0x040000B4 RID: 180
		public global::System.Windows.Forms.TextBox txtMaterialsItemQtDur;

		// Token: 0x040000B5 RID: 181
		private global::System.Windows.Forms.Label label30;

		// Token: 0x040000B6 RID: 182
		public global::System.Windows.Forms.TextBox txtMaterialsItemID;

		// Token: 0x040000B7 RID: 183
		public global::System.Windows.Forms.ListBox lstMaterials;

		// Token: 0x040000B8 RID: 184
		private global::System.Windows.Forms.GroupBox gbFoodEdit;

		// Token: 0x040000B9 RID: 185
		public global::System.Windows.Forms.Button btnFoodItemUpdate;

		// Token: 0x040000BA RID: 186
		private global::System.Windows.Forms.Label label31;

		// Token: 0x040000BB RID: 187
		public global::System.Windows.Forms.TextBox txtFoodItemBonusValue;

		// Token: 0x040000BC RID: 188
		private global::System.Windows.Forms.Label label32;

		// Token: 0x040000BD RID: 189
		public global::System.Windows.Forms.TextBox txtFoodItemBonusType;

		// Token: 0x040000BE RID: 190
		private global::System.Windows.Forms.Label label33;

		// Token: 0x040000BF RID: 191
		public global::System.Windows.Forms.ComboBox cbFoodItemName;

		// Token: 0x040000C0 RID: 192
		private global::System.Windows.Forms.Label label34;

		// Token: 0x040000C1 RID: 193
		public global::System.Windows.Forms.TextBox txtFoodItemQtDur;

		// Token: 0x040000C2 RID: 194
		private global::System.Windows.Forms.Label label35;

		// Token: 0x040000C3 RID: 195
		public global::System.Windows.Forms.TextBox txtFoodItemID;

		// Token: 0x040000C4 RID: 196
		public global::System.Windows.Forms.ListBox lstFood;

		// Token: 0x040000C5 RID: 197
		private global::System.Windows.Forms.GroupBox gbOtherEdit;

		// Token: 0x040000C6 RID: 198
		public global::System.Windows.Forms.Button btnOtherItemUpdate;

		// Token: 0x040000C7 RID: 199
		private global::System.Windows.Forms.Label label36;

		// Token: 0x040000C8 RID: 200
		public global::System.Windows.Forms.TextBox txtOtherItemBonusValue;

		// Token: 0x040000C9 RID: 201
		private global::System.Windows.Forms.Label label37;

		// Token: 0x040000CA RID: 202
		public global::System.Windows.Forms.TextBox txtOtherItemBonusType;

		// Token: 0x040000CB RID: 203
		private global::System.Windows.Forms.Label label38;

		// Token: 0x040000CC RID: 204
		public global::System.Windows.Forms.ComboBox cbOtherItemName;

		// Token: 0x040000CD RID: 205
		private global::System.Windows.Forms.Label label39;

		// Token: 0x040000CE RID: 206
		public global::System.Windows.Forms.TextBox txtOtherItemQtDur;

		// Token: 0x040000CF RID: 207
		private global::System.Windows.Forms.Label label40;

		// Token: 0x040000D0 RID: 208
		public global::System.Windows.Forms.TextBox txtOtherItemID;

		// Token: 0x040000D1 RID: 209
		public global::System.Windows.Forms.ListBox lstOther;

		// Token: 0x040000D2 RID: 210
		private global::System.Windows.Forms.TabPage tabPage13;

		// Token: 0x040000D3 RID: 211
		public global::System.Windows.Forms.ComboBox cbActionsList;

		// Token: 0x040000D4 RID: 212
		private global::System.Windows.Forms.TextBox txtLog;

		// Token: 0x040000D5 RID: 213
		private global::System.Windows.Forms.TabControl tabControl2;

		// Token: 0x040000D6 RID: 214
		private global::System.Windows.Forms.TabPage tabPage10;

		// Token: 0x040000D7 RID: 215
		private global::System.Windows.Forms.GroupBox groupBox12;

		// Token: 0x040000D8 RID: 216
		private global::System.Windows.Forms.Label label45;

		// Token: 0x040000D9 RID: 217
		private global::System.Windows.Forms.GroupBox groupBox11;

		// Token: 0x040000DA RID: 218
		public global::System.Windows.Forms.TextBox txtActionsHotKey;

		// Token: 0x040000DB RID: 219
		public global::System.Windows.Forms.CheckBox chkActionsDisableWhenDone;

		// Token: 0x040000DC RID: 220
		public global::System.Windows.Forms.GroupBox gbActionsFilter;

		// Token: 0x040000DD RID: 221
		public global::System.Windows.Forms.ListBox lstActionsFilter;

		// Token: 0x040000DE RID: 222
		public global::System.Windows.Forms.RadioButton optionActionsFilterList;

		// Token: 0x040000DF RID: 223
		public global::System.Windows.Forms.RadioButton optionActionsNoFilter;

		// Token: 0x040000E0 RID: 224
		public global::System.Windows.Forms.GroupBox gbActionsSettings;

		// Token: 0x040000E1 RID: 225
		public global::System.Windows.Forms.CheckBox chkActionsActiveInactive;

		// Token: 0x040000E2 RID: 226
		public global::System.Windows.Forms.TextBox txtActionsMax;

		// Token: 0x040000E3 RID: 227
		public global::System.Windows.Forms.Label label41;

		// Token: 0x040000E4 RID: 228
		public global::System.Windows.Forms.TextBox txtActionsQuantity;

		// Token: 0x040000E5 RID: 229
		public global::System.Windows.Forms.Label label42;

		// Token: 0x040000E6 RID: 230
		public global::System.Windows.Forms.TextBox txtActionsTimer;

		// Token: 0x040000E7 RID: 231
		public global::System.Windows.Forms.Label label43;

		// Token: 0x040000E8 RID: 232
		public global::System.Windows.Forms.TextBox txtActionsFixed;

		// Token: 0x040000E9 RID: 233
		public global::System.Windows.Forms.RadioButton optionActionsTimer;

		// Token: 0x040000EA RID: 234
		public global::System.Windows.Forms.RadioButton optionActionsFixed;

		// Token: 0x040000EB RID: 235
		public global::System.Windows.Forms.GroupBox groupBox9;

		// Token: 0x040000EC RID: 236
		public global::System.Windows.Forms.ListBox lstActionsRegistered;

		// Token: 0x040000ED RID: 237
		public global::System.Windows.Forms.Button btnActionsRemove;

		// Token: 0x040000EE RID: 238
		public global::System.Windows.Forms.Button btnActionsNew;

		// Token: 0x040000EF RID: 239
		public global::System.Windows.Forms.TabControl tabActions;

		// Token: 0x040000F0 RID: 240
		public global::System.Windows.Forms.TabControl tabItems;

		// Token: 0x040000F1 RID: 241
		public global::System.Windows.Forms.TabControl tabMain;

		// Token: 0x040000F2 RID: 242
		public global::System.Windows.Forms.CheckBox chkActionsUseHotkey;

		// Token: 0x040000F3 RID: 243
		private global::System.Windows.Forms.TabPage tabPage11;

		// Token: 0x040000F4 RID: 244
		public global::System.Windows.Forms.GroupBox groupBox13;

		// Token: 0x040000F5 RID: 245
		public global::System.Windows.Forms.ListBox lstWeaponsFilter;

		// Token: 0x040000F6 RID: 246
		public global::System.Windows.Forms.RadioButton optionWeaponsFilterList;

		// Token: 0x040000F7 RID: 247
		public global::System.Windows.Forms.RadioButton optionWeaponsNoFilter;

		// Token: 0x040000F8 RID: 248
		public global::System.Windows.Forms.GroupBox groupBox10;

		// Token: 0x040000F9 RID: 249
		public global::System.Windows.Forms.CheckBox chkWeaponsUseHotkey;

		// Token: 0x040000FA RID: 250
		public global::System.Windows.Forms.TextBox txtWeaponsHotKey;

		// Token: 0x040000FB RID: 251
		public global::System.Windows.Forms.CheckBox chkWeaponsDisableWhenDone;

		// Token: 0x040000FC RID: 252
		public global::System.Windows.Forms.CheckBox chkWeaponsActiveInactive;

		// Token: 0x040000FD RID: 253
		public global::System.Windows.Forms.TextBox txtWeaponsMax;

		// Token: 0x040000FE RID: 254
		public global::System.Windows.Forms.Label label44;

		// Token: 0x040000FF RID: 255
		public global::System.Windows.Forms.TextBox txtWeaponsQuantity;

		// Token: 0x04000100 RID: 256
		public global::System.Windows.Forms.Label label46;

		// Token: 0x04000101 RID: 257
		public global::System.Windows.Forms.TextBox txtWeaponsTimer;

		// Token: 0x04000102 RID: 258
		public global::System.Windows.Forms.Label label47;

		// Token: 0x04000103 RID: 259
		public global::System.Windows.Forms.TextBox txtWeaponsFixed;

		// Token: 0x04000104 RID: 260
		public global::System.Windows.Forms.RadioButton optionWeaponsTimer;

		// Token: 0x04000105 RID: 261
		public global::System.Windows.Forms.RadioButton optionWeaponsFixed;

		// Token: 0x04000106 RID: 262
		private global::System.Windows.Forms.TabPage tabPage14;

		// Token: 0x04000107 RID: 263
		private global::System.Windows.Forms.TabPage tabPage15;

		// Token: 0x04000108 RID: 264
		private global::System.Windows.Forms.TabPage tabPage16;

		// Token: 0x04000109 RID: 265
		private global::System.Windows.Forms.TabPage tabPage17;

		// Token: 0x0400010A RID: 266
		public global::System.Windows.Forms.GroupBox groupBox17;

		// Token: 0x0400010B RID: 267
		public global::System.Windows.Forms.ListBox lstBowsFilter;

		// Token: 0x0400010C RID: 268
		public global::System.Windows.Forms.RadioButton optionBowsFilterList;

		// Token: 0x0400010D RID: 269
		public global::System.Windows.Forms.RadioButton optionBowsNoFilter;

		// Token: 0x0400010E RID: 270
		public global::System.Windows.Forms.GroupBox groupBox18;

		// Token: 0x0400010F RID: 271
		public global::System.Windows.Forms.CheckBox chkBowsUseHotkey;

		// Token: 0x04000110 RID: 272
		public global::System.Windows.Forms.TextBox txtBowsHotKey;

		// Token: 0x04000111 RID: 273
		public global::System.Windows.Forms.CheckBox chkBowsDisableWhenDone;

		// Token: 0x04000112 RID: 274
		public global::System.Windows.Forms.CheckBox chkBowsActiveInactive;

		// Token: 0x04000113 RID: 275
		public global::System.Windows.Forms.TextBox txtBowsMax;

		// Token: 0x04000114 RID: 276
		public global::System.Windows.Forms.Label label54;

		// Token: 0x04000115 RID: 277
		public global::System.Windows.Forms.TextBox txtBowsQuantity;

		// Token: 0x04000116 RID: 278
		public global::System.Windows.Forms.Label label56;

		// Token: 0x04000117 RID: 279
		public global::System.Windows.Forms.TextBox txtBowsTimer;

		// Token: 0x04000118 RID: 280
		public global::System.Windows.Forms.Label label60;

		// Token: 0x04000119 RID: 281
		public global::System.Windows.Forms.TextBox txtBowsFixed;

		// Token: 0x0400011A RID: 282
		public global::System.Windows.Forms.RadioButton optionBowsTimer;

		// Token: 0x0400011B RID: 283
		public global::System.Windows.Forms.RadioButton optionBowsFixed;

		// Token: 0x0400011C RID: 284
		public global::System.Windows.Forms.GroupBox groupBox20;

		// Token: 0x0400011D RID: 285
		public global::System.Windows.Forms.ListBox lstShieldsFilter;

		// Token: 0x0400011E RID: 286
		public global::System.Windows.Forms.RadioButton optionShieldsFilterList;

		// Token: 0x0400011F RID: 287
		public global::System.Windows.Forms.RadioButton optionShieldsNoFilter;

		// Token: 0x04000120 RID: 288
		public global::System.Windows.Forms.GroupBox groupBox21;

		// Token: 0x04000121 RID: 289
		public global::System.Windows.Forms.CheckBox chkShieldsUseHotkey;

		// Token: 0x04000122 RID: 290
		public global::System.Windows.Forms.TextBox txtShieldsHotKey;

		// Token: 0x04000123 RID: 291
		public global::System.Windows.Forms.CheckBox chkShieldsDisableWhenDone;

		// Token: 0x04000124 RID: 292
		public global::System.Windows.Forms.CheckBox chkShieldsActiveInactive;

		// Token: 0x04000125 RID: 293
		public global::System.Windows.Forms.TextBox txtShieldsMax;

		// Token: 0x04000126 RID: 294
		public global::System.Windows.Forms.Label label61;

		// Token: 0x04000127 RID: 295
		public global::System.Windows.Forms.TextBox txtShieldsQuantity;

		// Token: 0x04000128 RID: 296
		public global::System.Windows.Forms.Label label62;

		// Token: 0x04000129 RID: 297
		public global::System.Windows.Forms.TextBox txtShieldsTimer;

		// Token: 0x0400012A RID: 298
		public global::System.Windows.Forms.Label label63;

		// Token: 0x0400012B RID: 299
		public global::System.Windows.Forms.TextBox txtShieldsFixed;

		// Token: 0x0400012C RID: 300
		public global::System.Windows.Forms.RadioButton optionShieldsTimer;

		// Token: 0x0400012D RID: 301
		public global::System.Windows.Forms.RadioButton optionShieldsFixed;

		// Token: 0x0400012E RID: 302
		public global::System.Windows.Forms.GroupBox groupBox22;

		// Token: 0x0400012F RID: 303
		public global::System.Windows.Forms.ListBox lstArrowsFilter;

		// Token: 0x04000130 RID: 304
		public global::System.Windows.Forms.RadioButton optionArrowsFilterList;

		// Token: 0x04000131 RID: 305
		public global::System.Windows.Forms.RadioButton optionArrowsNoFilter;

		// Token: 0x04000132 RID: 306
		public global::System.Windows.Forms.GroupBox groupBox23;

		// Token: 0x04000133 RID: 307
		public global::System.Windows.Forms.CheckBox chkArrowsUseHotkey;

		// Token: 0x04000134 RID: 308
		public global::System.Windows.Forms.TextBox txtArrowsHotKey;

		// Token: 0x04000135 RID: 309
		public global::System.Windows.Forms.CheckBox chkArrowsDisableWhenDone;

		// Token: 0x04000136 RID: 310
		public global::System.Windows.Forms.CheckBox chkArrowsActiveInactive;

		// Token: 0x04000137 RID: 311
		public global::System.Windows.Forms.TextBox txtArrowsMax;

		// Token: 0x04000138 RID: 312
		public global::System.Windows.Forms.Label label64;

		// Token: 0x04000139 RID: 313
		public global::System.Windows.Forms.TextBox txtArrowsQuantity;

		// Token: 0x0400013A RID: 314
		public global::System.Windows.Forms.Label label65;

		// Token: 0x0400013B RID: 315
		public global::System.Windows.Forms.TextBox txtArrowsTimer;

		// Token: 0x0400013C RID: 316
		public global::System.Windows.Forms.Label label66;

		// Token: 0x0400013D RID: 317
		public global::System.Windows.Forms.TextBox txtArrowsFixed;

		// Token: 0x0400013E RID: 318
		public global::System.Windows.Forms.RadioButton optionArrowsTimer;

		// Token: 0x0400013F RID: 319
		public global::System.Windows.Forms.RadioButton optionArrowsFixed;

		// Token: 0x04000140 RID: 320
		public global::System.Windows.Forms.TextBox txtLockStaminaHotKey;

		// Token: 0x04000141 RID: 321
		public global::System.Windows.Forms.TextBox txtLockHealthHotKey;

		// Token: 0x04000142 RID: 322
		public global::System.Windows.Forms.TextBox txtUnbreakableShieldsHotKey;

		// Token: 0x04000143 RID: 323
		public global::System.Windows.Forms.TextBox txtUnbreakableBowsHotKey;

		// Token: 0x04000144 RID: 324
		public global::System.Windows.Forms.TextBox txtUnbreakableWeaponsHotKey;

		// Token: 0x04000145 RID: 325
		private global::System.Windows.Forms.TabPage tabPage18;

		// Token: 0x04000146 RID: 326
		public global::System.Windows.Forms.TextBox txtPowersDarukHotKey;

		// Token: 0x04000147 RID: 327
		public global::System.Windows.Forms.TextBox txtPowersUrbosaHotKey;

		// Token: 0x04000148 RID: 328
		public global::System.Windows.Forms.TextBox txtPowersRevaliHotKey;

		// Token: 0x04000149 RID: 329
		public global::System.Windows.Forms.TextBox txtPowersMiphaHotKey;

		// Token: 0x0400014A RID: 330
		private global::System.Windows.Forms.TabPage tabPage19;

		// Token: 0x0400014B RID: 331
		public global::System.Windows.Forms.TextBox txtUnlimitAmiiboHotKey;

		// Token: 0x0400014C RID: 332
		private global::System.Windows.Forms.GroupBox gbRupees;

		// Token: 0x0400014D RID: 333
		public global::System.Windows.Forms.Button btnUpdateRupees;

		// Token: 0x0400014E RID: 334
		private global::System.Windows.Forms.Label label71;

		// Token: 0x0400014F RID: 335
		public global::System.Windows.Forms.TextBox txtRupees;

		// Token: 0x04000150 RID: 336
		public global::System.Windows.Forms.Button btnRefreshRupees;

		// Token: 0x04000151 RID: 337
		public global::System.Windows.Forms.TextBox txtTimerUpdateList;

		// Token: 0x04000152 RID: 338
		public global::System.Windows.Forms.CheckBox chkUpdateList;

		// Token: 0x04000153 RID: 339
		public global::System.Windows.Forms.ListBox lstEquippedWeapons;

		// Token: 0x04000154 RID: 340
		public global::System.Windows.Forms.GroupBox groupBox16;

		// Token: 0x04000155 RID: 341
		public global::System.Windows.Forms.Label lblLockStaminaInfo;

		// Token: 0x04000156 RID: 342
		public global::System.Windows.Forms.CheckBox chkLockStaminaSet;

		// Token: 0x04000157 RID: 343
		public global::System.Windows.Forms.CheckBox chkLockStaminaUseHotkey;

		// Token: 0x04000158 RID: 344
		public global::System.Windows.Forms.Label lblLockHealthInfo;

		// Token: 0x04000159 RID: 345
		public global::System.Windows.Forms.CheckBox chkLockHealthSet;

		// Token: 0x0400015A RID: 346
		public global::System.Windows.Forms.CheckBox chkLockHealthUseHotkey;

		// Token: 0x0400015B RID: 347
		public global::System.Windows.Forms.GroupBox groupBox14;

		// Token: 0x0400015C RID: 348
		public global::System.Windows.Forms.Label lblUnbreakableShieldsInfo;

		// Token: 0x0400015D RID: 349
		public global::System.Windows.Forms.CheckBox chkUnbreakableShieldsSet;

		// Token: 0x0400015E RID: 350
		public global::System.Windows.Forms.CheckBox chkUnbreakableShieldsUseHotkey;

		// Token: 0x0400015F RID: 351
		public global::System.Windows.Forms.Label lblUnbreakableBowsInfo;

		// Token: 0x04000160 RID: 352
		public global::System.Windows.Forms.CheckBox chkUnbreakableBowsSet;

		// Token: 0x04000161 RID: 353
		public global::System.Windows.Forms.CheckBox chkUnbreakableBowsUseHotkey;

		// Token: 0x04000162 RID: 354
		public global::System.Windows.Forms.Label lblUnbreakableWeaponsInfo;

		// Token: 0x04000163 RID: 355
		public global::System.Windows.Forms.CheckBox chkUnbreakableWeaponsSet;

		// Token: 0x04000164 RID: 356
		public global::System.Windows.Forms.CheckBox chkUnbreakableWeaponsUseHotkey;

		// Token: 0x04000165 RID: 357
		public global::System.Windows.Forms.GroupBox groupBox19;

		// Token: 0x04000166 RID: 358
		public global::System.Windows.Forms.Label lblPowersDarukInfo;

		// Token: 0x04000167 RID: 359
		public global::System.Windows.Forms.CheckBox chkPowersDarukSet;

		// Token: 0x04000168 RID: 360
		public global::System.Windows.Forms.CheckBox chkPowersDarukUseHotkey;

		// Token: 0x04000169 RID: 361
		public global::System.Windows.Forms.Label lblPowersUrbosaInfo;

		// Token: 0x0400016A RID: 362
		public global::System.Windows.Forms.CheckBox chkPowersUrbosaSet;

		// Token: 0x0400016B RID: 363
		public global::System.Windows.Forms.CheckBox chkPowersUrbosaUseHotkey;

		// Token: 0x0400016C RID: 364
		public global::System.Windows.Forms.Label lblPowersRevaliInfo;

		// Token: 0x0400016D RID: 365
		public global::System.Windows.Forms.CheckBox chkPowersRevaliSet;

		// Token: 0x0400016E RID: 366
		public global::System.Windows.Forms.CheckBox chkPowersRevaliUseHotkey;

		// Token: 0x0400016F RID: 367
		public global::System.Windows.Forms.Label lblPowersMiphaInfo;

		// Token: 0x04000170 RID: 368
		public global::System.Windows.Forms.CheckBox chkPowersMiphaSet;

		// Token: 0x04000171 RID: 369
		public global::System.Windows.Forms.CheckBox chkPowersMiphaUseHotkey;

		// Token: 0x04000172 RID: 370
		public global::System.Windows.Forms.GroupBox groupBox15;

		// Token: 0x04000173 RID: 371
		public global::System.Windows.Forms.Label lblUnlimitAmiiboInfo;

		// Token: 0x04000174 RID: 372
		public global::System.Windows.Forms.CheckBox chkUnlimitAmiiboSet;

		// Token: 0x04000175 RID: 373
		public global::System.Windows.Forms.CheckBox chkUnlimitAmiiboUseHotkey;

		// Token: 0x04000176 RID: 374
		private global::System.Windows.Forms.GroupBox groupBox2;

		// Token: 0x04000177 RID: 375
		private global::System.Windows.Forms.Button btnGameProcessResume;

		// Token: 0x04000178 RID: 376
		private global::System.Windows.Forms.Button btnGameProcessPause;

		// Token: 0x04000179 RID: 377
		private global::System.Windows.Forms.GroupBox groupBox1;

		// Token: 0x0400017A RID: 378
		private global::System.Windows.Forms.Button btnSettingsImport;

		// Token: 0x0400017B RID: 379
		private global::System.Windows.Forms.Button btnSettingsExport;

		// Token: 0x0400017C RID: 380
		private global::System.Windows.Forms.Button btnSettingsClear;

		// Token: 0x0400017D RID: 381
		private global::System.Windows.Forms.Button btnSettingsSave;

		// Token: 0x0400017E RID: 382
		private global::System.Windows.Forms.Label label48;

		// Token: 0x0400017F RID: 383
		private global::System.Windows.Forms.Label lblVersion;

		// Token: 0x04000180 RID: 384
		public global::System.Windows.Forms.GroupBox groupBox3;

		// Token: 0x04000181 RID: 385
		public global::System.Windows.Forms.ListBox lstUnbreakableFilter;

		// Token: 0x04000182 RID: 386
		public global::System.Windows.Forms.RadioButton optionUnbreakableFilterList;

		// Token: 0x04000183 RID: 387
		public global::System.Windows.Forms.RadioButton optionUnbreakableNoFilter;

		// Token: 0x04000184 RID: 388
		public global::System.Windows.Forms.ComboBox cbInventoryItemBonusType;

		// Token: 0x04000185 RID: 389
		public global::System.Windows.Forms.ComboBox cbWeaponsItemBonusType;

		// Token: 0x04000186 RID: 390
		public global::System.Windows.Forms.ComboBox cbArcheryItemBonusType;

		// Token: 0x04000187 RID: 391
		public global::System.Windows.Forms.ComboBox cbShieldsItemBonusType;

		// Token: 0x04000188 RID: 392
		public global::System.Windows.Forms.ComboBox cbArmorsItemBonusType;

		// Token: 0x04000189 RID: 393
		public global::System.Windows.Forms.ComboBox cbMaterialsItemBonusType;

		// Token: 0x0400018A RID: 394
		public global::System.Windows.Forms.ComboBox cbFoodItemBonusType;

		// Token: 0x0400018B RID: 395
		public global::System.Windows.Forms.ComboBox cbOtherItemBonusType;

		// Token: 0x0400018C RID: 396
		public global::System.Windows.Forms.Button btnInventoryItemUpdate;

		// Token: 0x0400018D RID: 397
		public global::System.Windows.Forms.GroupBox groupBox4;

		// Token: 0x0400018E RID: 398
		public global::System.Windows.Forms.Button btnRunSpeedDefault;

		// Token: 0x0400018F RID: 399
		public global::System.Windows.Forms.TextBox txtRunSpeedDefaultHotKey;

		// Token: 0x04000190 RID: 400
		public global::System.Windows.Forms.CheckBox chkRunSpeedDefaultUseHotkey;

		// Token: 0x04000191 RID: 401
		public global::System.Windows.Forms.Button btnRunSpeedDown;

		// Token: 0x04000192 RID: 402
		public global::System.Windows.Forms.TextBox txtRunSpeedDownHotKey;

		// Token: 0x04000193 RID: 403
		public global::System.Windows.Forms.CheckBox chkRunSpeedDownUseHotkey;

		// Token: 0x04000194 RID: 404
		public global::System.Windows.Forms.Button btnRunSpeedUp;

		// Token: 0x04000195 RID: 405
		public global::System.Windows.Forms.TextBox txtRunSpeedUpHotKey;

		// Token: 0x04000196 RID: 406
		public global::System.Windows.Forms.CheckBox chkRunSpeedUpUseHotkey;

		// Token: 0x04000197 RID: 407
		public global::System.Windows.Forms.Button btnRunSpeedUpdate;

		// Token: 0x04000198 RID: 408
		private global::System.Windows.Forms.Label label49;

		// Token: 0x04000199 RID: 409
		public global::System.Windows.Forms.TextBox txtRunSpeed;

		// Token: 0x0400019A RID: 410
		private global::System.Windows.Forms.TabPage tabPage20;

		// Token: 0x0400019B RID: 411
		private global::System.Windows.Forms.GroupBox gbShieldsSlots;

		// Token: 0x0400019C RID: 412
		public global::System.Windows.Forms.Button btnRefreshShieldsSlots;

		// Token: 0x0400019D RID: 413
		public global::System.Windows.Forms.Button btnUpdateShieldsSlots;

		// Token: 0x0400019E RID: 414
		private global::System.Windows.Forms.Label label52;

		// Token: 0x0400019F RID: 415
		public global::System.Windows.Forms.TextBox txtShieldsSlots;

		// Token: 0x040001A0 RID: 416
		private global::System.Windows.Forms.GroupBox gbBowsSlots;

		// Token: 0x040001A1 RID: 417
		public global::System.Windows.Forms.Button btnRefreshBowsSlots;

		// Token: 0x040001A2 RID: 418
		public global::System.Windows.Forms.Button btnUpdateBowsSlots;

		// Token: 0x040001A3 RID: 419
		private global::System.Windows.Forms.Label label51;

		// Token: 0x040001A4 RID: 420
		public global::System.Windows.Forms.TextBox txtBowsSlots;

		// Token: 0x040001A5 RID: 421
		private global::System.Windows.Forms.GroupBox gbWeaponsSlots;

		// Token: 0x040001A6 RID: 422
		public global::System.Windows.Forms.Button btnRefreshWeaponsSlots;

		// Token: 0x040001A7 RID: 423
		public global::System.Windows.Forms.Button btnUpdateWeaponsSlots;

		// Token: 0x040001A8 RID: 424
		private global::System.Windows.Forms.Label label50;

		// Token: 0x040001A9 RID: 425
		public global::System.Windows.Forms.TextBox txtWeaponsSlots;

		// Token: 0x040001AA RID: 426
		private global::System.Windows.Forms.GroupBox groupBox5;

		// Token: 0x040001AB RID: 427
		private global::System.Windows.Forms.Label label55;

		// Token: 0x040001AC RID: 428
		private global::System.Windows.Forms.Label label53;

		// Token: 0x040001AD RID: 429
		public global::System.Windows.Forms.NumericUpDown numInternalLoopMs;

		// Token: 0x040001AE RID: 430
		public global::System.Windows.Forms.NumericUpDown numSpacingMs;

		// Token: 0x040001AF RID: 431
		private global::System.Windows.Forms.Button button1;

		// Token: 0x040001B0 RID: 432
		private global::System.Windows.Forms.Button button2;

		// Token: 0x040001B1 RID: 433
		public global::System.Windows.Forms.Button btnInventoryItemUnlock;

		// Token: 0x040001B2 RID: 434
		public global::System.Windows.Forms.Button btnWeaponsItemUnlock;

		// Token: 0x040001B3 RID: 435
		public global::System.Windows.Forms.Button btnArcheryItemUnlock;

		// Token: 0x040001B4 RID: 436
		public global::System.Windows.Forms.Button btnShieldsItemUnlock;

		// Token: 0x040001B5 RID: 437
		public global::System.Windows.Forms.Button btnArmorsItemUnlock;

		// Token: 0x040001B6 RID: 438
		public global::System.Windows.Forms.Button btnMaterialsItemUnlock;

		// Token: 0x040001B7 RID: 439
		public global::System.Windows.Forms.Button btnFoodItemUnlock;

		// Token: 0x040001B8 RID: 440
		public global::System.Windows.Forms.Button btnOtherItemUnlock;

		// Token: 0x040001B9 RID: 441
		private global::System.Windows.Forms.TabPage tabPage21;

		// Token: 0x040001BA RID: 442
		public global::System.Windows.Forms.GroupBox groupBox7;

		// Token: 0x040001BB RID: 443
		private global::System.Windows.Forms.Label label68;

		// Token: 0x040001BC RID: 444
		public global::System.Windows.Forms.TextBox txtPositionZ;

		// Token: 0x040001BD RID: 445
		private global::System.Windows.Forms.Label label67;

		// Token: 0x040001BE RID: 446
		public global::System.Windows.Forms.TextBox txtPositionY;

		// Token: 0x040001BF RID: 447
		private global::System.Windows.Forms.Label label59;

		// Token: 0x040001C0 RID: 448
		public global::System.Windows.Forms.TextBox txtPositionX;

		// Token: 0x040001C1 RID: 449
		public global::System.Windows.Forms.Button btnPositionRestore;

		// Token: 0x040001C2 RID: 450
		public global::System.Windows.Forms.TextBox txtPositionRestoreHotKey;

		// Token: 0x040001C3 RID: 451
		public global::System.Windows.Forms.CheckBox chkPositionRestoreUseHotkey;

		// Token: 0x040001C4 RID: 452
		public global::System.Windows.Forms.Button btnPositionSave;

		// Token: 0x040001C5 RID: 453
		public global::System.Windows.Forms.TextBox txtPositionSaveHotKey;

		// Token: 0x040001C6 RID: 454
		public global::System.Windows.Forms.CheckBox chkPositionSaveUseHotkey;

		// Token: 0x040001C7 RID: 455
		public global::System.Windows.Forms.Button btnPositionJump;

		// Token: 0x040001C8 RID: 456
		public global::System.Windows.Forms.TextBox txtPositionJumpHeight;

		// Token: 0x040001C9 RID: 457
		public global::System.Windows.Forms.TextBox txtPositionJumpHotKey;

		// Token: 0x040001CA RID: 458
		public global::System.Windows.Forms.CheckBox chkPositionJumpUseHotkey;

		// Token: 0x040001CB RID: 459
		public global::System.Windows.Forms.CheckBox chkPositionLockHeightSet;

		// Token: 0x040001CC RID: 460
		public global::System.Windows.Forms.TextBox txtPositionLockHeightHotKey;

		// Token: 0x040001CD RID: 461
		public global::System.Windows.Forms.CheckBox chkPositionLockHeightUseHotkey;

		// Token: 0x040001CE RID: 462
		public global::System.Windows.Forms.Button btnPositionEdit;

		// Token: 0x040001CF RID: 463
		public global::System.Windows.Forms.GroupBox groupBox6;

		// Token: 0x040001D0 RID: 464
		private global::System.Windows.Forms.Label label70;

		// Token: 0x040001D1 RID: 465
		public global::System.Windows.Forms.TextBox txtCapturedPositionName;

		// Token: 0x040001D2 RID: 466
		private global::System.Windows.Forms.Label label57;

		// Token: 0x040001D3 RID: 467
		public global::System.Windows.Forms.TextBox txtCapturedPositionZ;

		// Token: 0x040001D4 RID: 468
		private global::System.Windows.Forms.Label label58;

		// Token: 0x040001D5 RID: 469
		public global::System.Windows.Forms.TextBox txtCapturedPositionY;

		// Token: 0x040001D6 RID: 470
		private global::System.Windows.Forms.Label label69;

		// Token: 0x040001D7 RID: 471
		public global::System.Windows.Forms.TextBox txtCapturedPositionX;

		// Token: 0x040001D8 RID: 472
		public global::System.Windows.Forms.Button btnCapturedPositionRemove;

		// Token: 0x040001D9 RID: 473
		public global::System.Windows.Forms.Button btnCapturedPositionSave;

		// Token: 0x040001DA RID: 474
		public global::System.Windows.Forms.Button btnCapturedPositionNew;

		// Token: 0x040001DB RID: 475
		public global::System.Windows.Forms.ListBox lstCapturedPositions;

		// Token: 0x040001DC RID: 476
		public global::System.Windows.Forms.Button btnCapturedPositionTP;

		// Token: 0x040001DD RID: 477
		private global::System.Windows.Forms.Button button3;

		// Token: 0x040001DE RID: 478
		private global::System.Windows.Forms.TabPage tabPage22;

		// Token: 0x040001DF RID: 479
		public global::System.Windows.Forms.Button btnFindMemoryRegionByAddress;

		// Token: 0x040001E0 RID: 480
		private global::System.Windows.Forms.Label label72;

		// Token: 0x040001E1 RID: 481
		public global::System.Windows.Forms.TextBox txtFindMemoryRegionByAddress;

		// Token: 0x040001E2 RID: 482
		public global::System.Windows.Forms.Button btntxtFindMemoryRegionBySize;

		// Token: 0x040001E3 RID: 483
		private global::System.Windows.Forms.Label label73;

		// Token: 0x040001E4 RID: 484
		public global::System.Windows.Forms.TextBox txtFindMemoryRegionBySize;

		// Token: 0x040001E5 RID: 485
		public global::System.Windows.Forms.Button btnMemoryRegions;

		// Token: 0x040001E6 RID: 486
		public global::System.Windows.Forms.TrackBar trackTime;

		// Token: 0x040001E7 RID: 487
		public global::System.Windows.Forms.Button btnCompareAddress;

		// Token: 0x040001E8 RID: 488
		private global::System.Windows.Forms.Label label74;

		// Token: 0x040001E9 RID: 489
		public global::System.Windows.Forms.TextBox txtCompareAddress;

		// Token: 0x040001EA RID: 490
		public global::System.Windows.Forms.Button btnRestoreStaminaBar;

		// Token: 0x040001EB RID: 491
		public global::System.Windows.Forms.Button btnNoStaminaBar;
	}
}
