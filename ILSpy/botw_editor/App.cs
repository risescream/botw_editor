using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace botw_editor
{
	public class App
	{
		[CompilerGenerated]
		[Serializable]
		private sealed class <>c
		{
			public static readonly App.<>c <>9 = new App.<>c();

			public static Predicate<char> <>9__62_0;

			public static Comparison<itemname> <>9__129_0;

			public static Comparison<itemname> <>9__129_1;

			internal bool <RemoveInvalidXmlChars>b__62_0(char value)
			{
				return (value >= ' ' && value <= '퟿') || (value >= '' && value <= '�') || value == '\t' || value == '\n' || value == '\r';
			}

			internal int <updateItems>b__129_0(itemname x, itemname y)
			{
				return x.itemID.CompareTo(y.itemID);
			}

			internal int <updateItems>b__129_1(itemname x, itemname y)
			{
				return x.itemName.CompareTo(y.itemName);
			}
		}

		public static readonly string[] SECTIONS = new string[]
		{
			"Inventory",
			"Weapons",
			"Archery",
			"Shields",
			"Armors",
			"Food",
			"Materials",
			"Other"
		};

		public static readonly string[] ACTION_SECTIONS = new string[]
		{
			"Weapons",
			"Bows",
			"Shields",
			"Arrows"
		};

		public static readonly string[] EXTENDED_ACTION_SECTIONS = new string[]
		{
			"UnbreakableWeapons",
			"UnbreakableBows",
			"UnbreakableShields",
			"LockHealth",
			"LockStamina",
			"PowersMipha",
			"PowersRevali",
			"PowersUrbosa",
			"PowersDaruk",
			"UnlimitAmiibo",
			"RunSpeedUp",
			"RunSpeedDown",
			"RunSpeedDefault",
			"PositionSave",
			"PositionRestore",
			"PositionLockHeight",
			"PositionJump"
		};

		private FrmMain frmMain;

		public BackgroundWorker worker;

		private MemAPI mem;

		private Queue<QueueItem> uiQueue = new Queue<QueueItem>();

		private Queue<QueueItem> workingQueue = new Queue<QueueItem>();

		private BindingList<itemdata> items;

		private BindingList<itemdata> equipped;

		public Dictionary<string, string> itemNames = new Dictionary<string, string>();

		private Dictionary<string, BindingList<itemdata>> lists = new Dictionary<string, BindingList<itemdata>>();

		private Dictionary<string, BindingSource> sources = new Dictionary<string, BindingSource>();

		private Dictionary<string, List<itemname>> names = new Dictionary<string, List<itemname>>();

		private BindingList<actiondata> customActions = new BindingList<actiondata>();

		private Dictionary<string, object> listActions = new Dictionary<string, object>();

		private BindingList<CapturedPosition> capturedPositions = new BindingList<CapturedPosition>();

		private long rupeesAddress = -1L;

		private long inventoryStartAddress = -1L;

		private long healthAddress = -1L;

		private long staminaAddress = -1L;

		private long equippedWeaponDurabilityAddress = -1L;

		private long equippedBowDurabilityAddress = -1L;

		private long equippedShieldDurabilityAddress = -1L;

		private long divinePowersAddress = -1L;

		private long amiiboDateAddress = -1L;

		private long speedHackAddress = -1L;

		private long weaponsSlotsAddress = -1L;

		private long bowsSlotsAddress = -1L;

		private long shieldsSlotsAddress = -1L;

		private long weaponsSlotsPersistAddress = -1L;

		private long bowsSlotsPersistAddress = -1L;

		private long shieldsSlotsPersistAddress = -1L;

		private long coordinatesAddress = -1L;

		private float savedX;

		private float savedY;

		private float savedZ;

		private float lockedY;

		private long noStaminaBarAddress = -1L;

		private long divinePowerMiphaTimerAddress = -1L;

		private long divinePowerRevaliAddress = -1L;

		private long divinePowerUrbosaAddress = -1L;

		private long divinePowerDarukAddress = -1L;

		private const int divinePowerMiphaTimerOffset = 324;

		private const int divinePowerRevaliOffset = 0;

		private const int divinePowerUrbosaOffset = 4;

		private const int divinePowerDarukOffset = 8;

		public double timeLastUpdateList;

		public int nbInternalLoopMs = 100;

		public int nbSpacingMs;

		private globalKeyboardHook gKH;

		private bool FlagEvent_1 = true;

		public List<MemoryChange> memoryChanges = new List<MemoryChange>();

		public bool InvokeRequired
		{
			get
			{
				return this.frmMain != null && this.frmMain.InvokeRequired;
			}
		}

		public App(FrmMain frm)
		{
			this.mem = new MemAPI();
			this.mem.ProcessName = "Cemu";
			MemAPI.obj = this;
			this.frmMain = frm;
			itemdata.parent = this;
			this.frmMain.btnActionsNew.Click += new EventHandler(this.btnActionsNew_Click);
			this.frmMain.btnActionsRemove.Click += new EventHandler(this.btnActionsRemove_Click);
			ListBox expr_1A4 = this.frmMain.lstActionsRegistered;
			expr_1A4.DataSource = this.CreateBindingSource<actiondata>(this.customActions);
			expr_1A4.SelectedIndexChanged += new EventHandler(this.lstActionsRegistered_SelectedIndexChanged);
			expr_1A4.SelectedValueChanged += new EventHandler(this.lstActionsRegistered_SelectedValueChanged);
			this.frmMain.cbActionsList.SelectedIndexChanged += new EventHandler(this.cbActionsList_SelectedIndexChanged);
			this.frmMain.txtActionsHotKey.TextChanged += new EventHandler(this.txtActionsHotKey_TextChanged);
			this.frmMain.txtActionsFixed.TextChanged += new EventHandler(this.txtActionsFixed_TextChanged);
			this.frmMain.txtActionsTimer.TextChanged += new EventHandler(this.txtActionsTimer_TextChanged);
			this.frmMain.txtActionsQuantity.TextChanged += new EventHandler(this.txtActionsQuantity_TextChanged);
			this.frmMain.txtActionsMax.TextChanged += new EventHandler(this.txtActionsMax_TextChanged);
			this.frmMain.chkActionsDisableWhenDone.CheckedChanged += new EventHandler(this.chkActionsDisableWhenDone_CheckedChanged);
			CheckBox expr_2A8 = this.frmMain.chkActionsUseHotkey;
			expr_2A8.CheckedChanged += new EventHandler(this.chkActionsUseHotKey_CheckedChanged);
			this.frmMain.chkActionsActiveInactive.CheckedChanged += new EventHandler(this.chkActionsActiveInactive_CheckedChanged);
			this.frmMain.optionActionsFixed.CheckedChanged += new EventHandler(this.optionActionsFixed_CheckedChanged);
			this.frmMain.optionActionsTimer.CheckedChanged += new EventHandler(this.optionActionsTimer_CheckedChanged);
			this.frmMain.optionActionsNoFilter.CheckedChanged += new EventHandler(this.optionActionsNoFilter_CheckedChanged);
			this.frmMain.optionActionsFilterList.CheckedChanged += new EventHandler(this.optionActionsFilterList_CheckedChanged);
			this.frmMain.lstActionsFilter.DoubleClick += new EventHandler(this.lstActionsFilter_DoubleClick);
			expr_2A8.CheckedChanged += new EventHandler(this.chkUseHotKey_CheckedChanged);
			string[] array = App.SECTIONS;
			for (int i = 0; i < array.Length; i++)
			{
				string text = array[i];
				this.lists.Add(text, new BindingList<itemdata>());
				this.sources.Add(text, this.CreateBindingSource<itemdata>(this.lists[text]));
				this.names.Add(text, new List<itemname>());
				ListBox listBox = (ListBox)this.findControl("lst" + text);
				if (listBox != null)
				{
					listBox.DataSource = this.sources[text];
					listBox.SelectedIndexChanged += new EventHandler(this.lst_SelectedIndexChanged);
					listBox.DoubleClick += new EventHandler(this.lst_DoubleClick);
				}
				Button button = (Button)this.findControl("btn" + text + "ItemUpdate");
				if (button != null)
				{
					button.Click += new EventHandler(this.btnItemUpdate_Click);
				}
				Button button2 = (Button)this.findControl("btn" + text + "ItemUnlock");
				if (button2 != null)
				{
					button2.Click += new EventHandler(this.btnItemUnlock_Click);
				}
				ComboBox comboBox = (ComboBox)this.findControl("cb" + text + "ItemName");
				if (comboBox != null)
				{
					comboBox.SelectedIndexChanged += new EventHandler(this.cbItemName_SelectedIndexChanged);
				}
			}
			this.names.Add("All", new List<itemname>());
			Button btnRefreshRupees = this.frmMain.btnRefreshRupees;
			Control arg_51B_0 = this.frmMain.btnUpdateRupees;
			btnRefreshRupees.Click += new EventHandler(this.btnRefreshRupees_Click);
			arg_51B_0.Click += new EventHandler(this.btnUpdateRupees_Click);
			this.items = this.lists["Inventory"];
			this.lists.Add("Equipped", new BindingList<itemdata>());
			this.equipped = this.lists["Equipped"];
			ListBox expr_56C = this.frmMain.lstEquippedWeapons;
			expr_56C.DataSource = this.equipped;
			expr_56C.DoubleClick += new EventHandler(this.lst_DoubleClick);
			array = App.ACTION_SECTIONS;
			for (int i = 0; i < array.Length; i++)
			{
				string text2 = array[i];
				actiondata actiondata = new actiondata();
				actiondata.filterList = new BList<itemdata>();
				actiondata.section = text2;
				ListBox arg_5E4_0 = (ListBox)this.findControl("lst" + text2 + "Filter");
				this.listActions.Add(text2, actiondata);
				arg_5E4_0.DataSource = this.CreateBindingSource<itemdata>(actiondata.filterList);
				arg_5E4_0.DoubleClick += new EventHandler(this.lstActionsFilter_DoubleClick);
				CheckBox checkBox = (CheckBox)this.findControl("chk" + text2 + "UseHotkey");
				if (checkBox != null)
				{
					checkBox.CheckedChanged += new EventHandler(this.chkUseHotKey_CheckedChanged);
				}
			}
			BList<itemdata> bList = new BList<itemdata>();
			ListBox expr_663 = (ListBox)this.findControl("lstUnbreakableFilter");
			expr_663.DataSource = this.CreateBindingSource<itemdata>(bList);
			expr_663.DoubleClick += new EventHandler(this.lstActionsFilter_DoubleClick);
			array = App.EXTENDED_ACTION_SECTIONS;
			for (int i = 0; i < array.Length; i++)
			{
				string text3 = array[i];
				actiondata actiondata2 = new actiondata();
				actiondata2.section = text3;
				actiondata2.filterList = bList;
				this.listActions.Add(text3, actiondata2);
				CheckBox checkBox2 = (CheckBox)this.findControl("chk" + text3 + "UseHotkey");
				if (checkBox2 != null)
				{
					checkBox2.CheckedChanged += new EventHandler(this.chkUseHotKey_CheckedChanged);
				}
			}
			ListBox expr_70B = (ListBox)this.findControl("lstCapturedPositions");
			expr_70B.DataSource = this.capturedPositions;
			expr_70B.SelectedIndexChanged += new EventHandler(this.LstCapturedPositions_SelectedIndexChanged);
			expr_70B.DoubleClick += new EventHandler(this.LstCapturedPositions_DoubleClick);
			Settings settings = this.readSettings(Settings.getConfigFilePath());
			if (settings != null && this.applySettings(settings))
			{
				this.Putlog("Settings loaded from " + Settings.getConfigFilePath());
			}
			else
			{
				this.Putlog("No settings loaded.");
			}
			if (!this.frmMain.chkUpdateList.Checked)
			{
				this.Putlog("Click the Scan Memory button to start.");
			}
			this.gKH = new globalKeyboardHook();
			this.gKH.KeyPress += new KeyEventHandler(this.gKH_KeyPress);
			this.worker = new BackgroundWorker();
			this.worker.WorkerReportsProgress = true;
			this.worker.WorkerSupportsCancellation = true;
			this.worker.DoWork += new DoWorkEventHandler(this.worker_DoWork);
			this.worker.ProgressChanged += new ProgressChangedEventHandler(this.worker_ProgressChanged);
			this.worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.worker_RunWorkerCompleted);
			this.worker.RunWorkerAsync();
		}

		public int getInternalLoopMsValue()
		{
			int result = 100;
			try
			{
				result = Convert.ToInt32(this.frmMain.numInternalLoopMs.Value);
			}
			catch (Exception)
			{
			}
			return result;
		}

		public int getSpacingMsValue()
		{
			int result = 0;
			try
			{
				result = Convert.ToInt32(this.frmMain.numSpacingMs.Value);
			}
			catch (Exception)
			{
			}
			return result;
		}

		public Settings getCurrentSettings()
		{
			Settings settings = new Settings();
			settings.auto_update_timer = App.StringToInt32(this.frmMain.txtTimerUpdateList.Text);
			settings.auto_update = this.frmMain.chkUpdateList.Checked;
			settings.internalLoopMs = this.getInternalLoopMsValue();
			settings.spacingMs = this.getSpacingMsValue();
			foreach (KeyValuePair<string, string> current in this.itemNames)
			{
				settings.item_ids.Add(current.Key);
				settings.item_names.Add(current.Value);
			}
			foreach (KeyValuePair<string, object> current2 in this.listActions)
			{
				actiondata item = (actiondata)current2.Value;
				settings.action_keys.Add(current2.Key);
				settings.action_datas.Add(item);
			}
			foreach (actiondata current3 in this.customActions)
			{
				settings.custom_actions.Add(current3);
			}
			settings.capturedPositions = this.capturedPositions.ToList<CapturedPosition>();
			return settings;
		}

		public bool applySettings(Settings s)
		{
			if (s == null)
			{
				return false;
			}
			this.frmMain.txtTimerUpdateList.Text = s.auto_update_timer.ToString();
			this.frmMain.chkUpdateList.Checked = s.auto_update;
			this.frmMain.numInternalLoopMs.Value = s.internalLoopMs;
			this.frmMain.numSpacingMs.Value = s.spacingMs;
			this.nbInternalLoopMs = s.internalLoopMs;
			this.nbSpacingMs = s.spacingMs;
			this.itemNames.Clear();
			int num = 0;
			while (num < s.item_ids.Count && num < s.item_names.Count)
			{
				this.itemNames.Add(s.item_ids[num], s.item_names[num]);
				num++;
			}
			this.listActions.Clear();
			string[] array = App.ACTION_SECTIONS;
			for (int i = 0; i < array.Length; i++)
			{
				string text = array[i];
				actiondata actiondata = new actiondata();
				actiondata.filterList = new BList<itemdata>();
				actiondata.section = text;
				ListControl arg_140_0 = (ListBox)this.findControl("lst" + text + "Filter");
				this.listActions.Add(text, actiondata);
				arg_140_0.DataSource = this.CreateBindingSource<itemdata>(actiondata.filterList);
			}
			array = App.EXTENDED_ACTION_SECTIONS;
			for (int i = 0; i < array.Length; i++)
			{
				string text2 = array[i];
				actiondata actiondata2 = new actiondata();
				actiondata2.section = text2;
				actiondata2.filterList = null;
				this.listActions.Add(text2, actiondata2);
			}
			int num2 = 0;
			while (num2 < s.action_keys.Count && num2 < s.action_datas.Count)
			{
				if (this.listActions.ContainsKey(s.action_keys[num2]))
				{
					this.listActions[s.action_keys[num2]] = s.action_datas[num2];
				}
				else
				{
					this.listActions.Add(s.action_keys[num2], s.action_datas[num2]);
				}
				num2++;
			}
			foreach (KeyValuePair<string, object> current in this.listActions)
			{
				BList<itemdata> bList = null;
				if (Array.IndexOf<string>(App.EXTENDED_ACTION_SECTIONS, current.Key) >= 0)
				{
					actiondata actiondata3 = (actiondata)current.Value;
					if (bList == null)
					{
						bList = actiondata3.filterList;
					}
					else
					{
						actiondata3.filterList = bList;
					}
				}
				this.updateUiFromActionData((actiondata)current.Value);
			}
			this.customActions.Clear();
			for (int j = 0; j < s.custom_actions.Count; j++)
			{
				this.customActions.Add(s.custom_actions[j]);
			}
			foreach (KeyValuePair<string, BindingSource> current2 in this.sources)
			{
				for (int k = 0; k < current2.Value.Count; k++)
				{
					current2.Value.ResetItem(k);
				}
			}
			this.capturedPositions.Clear();
			foreach (CapturedPosition current3 in s.capturedPositions)
			{
				this.capturedPositions.Add(current3);
			}
			return true;
		}

		public void resetSettings()
		{
			this.itemNames.Clear();
		}

		public Settings readSettings(string xmlfile)
		{
			return Settings.loadFile(xmlfile);
		}

		public bool writeSettings(Settings s, string xmlfile)
		{
			return s.writeFile(xmlfile);
		}

		public static string RemoveInvalidXmlChars(string input)
		{
			Predicate<char> arg_1F_0;
			if ((arg_1F_0 = App.<>c.<>9__62_0) == null)
			{
				arg_1F_0 = (App.<>c.<>9__62_0 = new Predicate<char>(App.<>c.<>9.<RemoveInvalidXmlChars>b__62_0));
			}
			Predicate<char> match = arg_1F_0;
			return new string(Array.FindAll<char>(input.ToCharArray(), match));
		}

		public void suspendGame()
		{
			this.mem.UpdateProcess("");
			if (this.mem.p != null)
			{
				MemAPI.SuspendProcess(this.mem.p);
				this.Putlog("Game process suspended.");
				return;
			}
			this.Putlog("Could not find process '" + this.mem.ProcessName + "'.");
		}

		public void resumeGame()
		{
			this.mem.UpdateProcess("");
			if (this.mem.p != null)
			{
				MemAPI.ResumeProcess(this.mem.p);
				this.Putlog("Game process resumed.");
				return;
			}
			this.Putlog("Could not find process '" + this.mem.ProcessName + "'.");
		}

		public void resetAddresses(bool clearInventoryAddress = false)
		{
			this.healthAddress = -1L;
			this.staminaAddress = -1L;
			this.rupeesAddress = -1L;
			this.amiiboDateAddress = -1L;
			this.speedHackAddress = -1L;
			this.weaponsSlotsAddress = -1L;
			this.bowsSlotsAddress = -1L;
			this.shieldsSlotsAddress = -1L;
			this.weaponsSlotsPersistAddress = -1L;
			this.bowsSlotsPersistAddress = -1L;
			this.shieldsSlotsPersistAddress = -1L;
			this.divinePowerDarukAddress = -1L;
			this.divinePowerMiphaTimerAddress = -1L;
			this.divinePowerRevaliAddress = -1L;
			this.divinePowersAddress = -1L;
			this.divinePowerUrbosaAddress = -1L;
			this.equippedBowDurabilityAddress = -1L;
			this.equippedShieldDurabilityAddress = -1L;
			this.equippedWeaponDurabilityAddress = -1L;
			if (clearInventoryAddress)
			{
				this.inventoryStartAddress = -1L;
			}
			this.coordinatesAddress = -1L;
		}

		private void chkUseHotKey_CheckedChanged(object sender, EventArgs e)
		{
			CheckBox checkBox = (CheckBox)sender;
			if (!checkBox.Checked)
			{
				string str = checkBox.Name.Replace("chk", "").Replace("UseHotkey", "");
				TextBox textBox = (TextBox)this.findControl("txt" + str + "HotKey");
				if (textBox != null && textBox.GetType() == typeof(TextBox) && textBox.Text != "")
				{
					this.TextControl("txt" + str + "HotKey", "");
				}
			}
		}

		public int GetRupees()
		{
			int result = -1;
			if (this.rupeesAddress >= 0L)
			{
				result = this.mem.GetInt32At(this.rupeesAddress);
			}
			return result;
		}

		public void SetRupees(int value)
		{
			if (this.rupeesAddress >= 0L)
			{
				this.mem.SetInt32At(this.rupeesAddress, value);
				this.mem.SetInt32At(this.rupeesAddress - 4704656L, value);
			}
		}

		private void btnUpdateRupees_Click(object sender, EventArgs e)
		{
			int rupees = this.GetRupees();
			if (rupees >= 0)
			{
				this.SetRupees(App.StringToInt32(this.frmMain.txtRupees.Text));
				rupees = this.GetRupees();
				this.SetTextBoxText(this.frmMain.txtRupees, rupees.ToString());
				return;
			}
			this.SetTextBoxText(this.frmMain.txtRupees, "");
			this.EnableControl("gbRupees", false);
		}

		private void btnRefreshRupees_Click(object sender, EventArgs e)
		{
			int rupees = this.GetRupees();
			if (rupees >= 0)
			{
				this.SetTextBoxText(this.frmMain.txtRupees, rupees.ToString());
				return;
			}
			this.SetTextBoxText(this.frmMain.txtRupees, "");
			this.EnableControl("gbRupees", false);
		}

		private void lstActionsFilter_DoubleClick(object sender, EventArgs e)
		{
			ListBox listBox = (ListBox)sender;
			itemdata itemdata = (itemdata)listBox.SelectedItem;
			if (itemdata != null)
			{
				BindingSource bindingSource = (BindingSource)listBox.DataSource;
				BindingList<itemdata> bindingList = (bindingSource != null && bindingSource.DataSource != null) ? ((BindingList<itemdata>)bindingSource.DataSource) : null;
				if (bindingList != null)
				{
					bindingList.Remove(itemdata);
					for (int i = 0; i < bindingSource.Count; i++)
					{
						bindingSource.ResetItem(i);
					}
				}
			}
		}

		private void optionUnbreakableFilterList_CheckedChanged(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}

		private void optionUnbreakableNoFilter_CheckedChanged(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}

		private void optionActionsFilterList_CheckedChanged(object sender, EventArgs e)
		{
			this.updateCurrentAction();
		}

		private void optionActionsNoFilter_CheckedChanged(object sender, EventArgs e)
		{
			this.updateCurrentAction();
		}

		private void optionActionsTimer_CheckedChanged(object sender, EventArgs e)
		{
			this.updateCurrentAction();
		}

		private void optionActionsFixed_CheckedChanged(object sender, EventArgs e)
		{
			this.updateCurrentAction();
		}

		private void chkActionsActiveInactive_CheckedChanged(object sender, EventArgs e)
		{
			this.updateCurrentAction();
		}

		private void chkActionsUseHotKey_CheckedChanged(object sender, EventArgs e)
		{
			this.updateCurrentAction();
		}

		private void chkActionsDisableWhenDone_CheckedChanged(object sender, EventArgs e)
		{
			this.updateCurrentAction();
		}

		private void txtActionsMax_TextChanged(object sender, EventArgs e)
		{
			this.updateCurrentAction();
		}

		private void txtActionsQuantity_TextChanged(object sender, EventArgs e)
		{
			this.updateCurrentAction();
		}

		private void txtActionsTimer_TextChanged(object sender, EventArgs e)
		{
			this.updateCurrentAction();
		}

		private void txtActionsFixed_TextChanged(object sender, EventArgs e)
		{
			this.updateCurrentAction();
		}

		private void txtActionsHotKey_TextChanged(object sender, EventArgs e)
		{
			this.updateCurrentAction();
		}

		private void gKH_KeyPress(object sender, KeyEventArgs e)
		{
			TextBox txtActionsHotKey = this.frmMain.txtActionsHotKey;
			if (txtActionsHotKey.Focused)
			{
				globalKeyboardHook.keyboardHookStruct arg_1F_0 = this.gKH.lastKey;
				globalKeyboardHook.keyboardHookStruct arg_2B_0 = this.gKH.lastKey;
				globalKeyboardHook.keyboardHookStruct arg_37_0 = this.gKH.lastKey;
				globalKeyboardHook.keyboardHookStruct arg_43_0 = this.gKH.lastKey;
				string keyText = this.gKH.GetKeyText(ref this.gKH.lastKey);
				txtActionsHotKey.Text = keyText;
				e.Handled = true;
			}
			else
			{
				bool flag = false;
				string[] array = App.ACTION_SECTIONS;
				for (int i = 0; i < array.Length; i++)
				{
					string str = array[i];
					TextBox textBox = (TextBox)this.findControl("txt" + str + "HotKey");
					if (textBox.Focused)
					{
						globalKeyboardHook.keyboardHookStruct arg_B8_0 = this.gKH.lastKey;
						globalKeyboardHook.keyboardHookStruct arg_C4_0 = this.gKH.lastKey;
						globalKeyboardHook.keyboardHookStruct arg_D0_0 = this.gKH.lastKey;
						globalKeyboardHook.keyboardHookStruct arg_DC_0 = this.gKH.lastKey;
						string keyText2 = this.gKH.GetKeyText(ref this.gKH.lastKey);
						textBox.Text = keyText2;
						e.Handled = true;
						flag = true;
						break;
					}
				}
				if (flag)
				{
					return;
				}
				array = App.EXTENDED_ACTION_SECTIONS;
				for (int i = 0; i < array.Length; i++)
				{
					string str2 = array[i];
					TextBox textBox2 = (TextBox)this.findControl("txt" + str2 + "HotKey");
					if (textBox2.Focused)
					{
						globalKeyboardHook.keyboardHookStruct arg_166_0 = this.gKH.lastKey;
						globalKeyboardHook.keyboardHookStruct arg_172_0 = this.gKH.lastKey;
						globalKeyboardHook.keyboardHookStruct arg_17E_0 = this.gKH.lastKey;
						globalKeyboardHook.keyboardHookStruct arg_18A_0 = this.gKH.lastKey;
						string keyText3 = this.gKH.GetKeyText(ref this.gKH.lastKey);
						textBox2.Text = keyText3;
						e.Handled = true;
						break;
					}
				}
			}
			bool flag2 = false;
			if (!e.Handled && WinAPI.ApplicationIsActivated())
			{
				Control control = WinAPI.FindFocusedControl(this.frmMain);
				if (control != null && control.GetType() == typeof(TextBox))
				{
					flag2 = true;
				}
			}
			if (!flag2 && !e.Handled)
			{
				string keyText4 = this.gKH.GetKeyText(ref this.gKH.lastKey);
				bool flag3 = false;
				int num = 0;
				object[] array2 = this.listActions.Values.ToArray<object>();
				for (int i = 0; i < array2.Length; i++)
				{
					actiondata actiondata = (actiondata)array2[i];
					if (actiondata.UseHotKey && actiondata.hotKey != "" && actiondata.hotKey == keyText4)
					{
						actiondata.Active = !actiondata.Active;
						flag3 = true;
						num++;
						this.updateUiFromActionData(actiondata);
					}
				}
				actiondata[] array3 = this.customActions.ToArray<actiondata>();
				for (int i = 0; i < array3.Length; i++)
				{
					actiondata actiondata2 = array3[i];
					if (actiondata2.UseHotKey && actiondata2.hotKey != "" && actiondata2.hotKey == keyText4)
					{
						actiondata2.Active = !actiondata2.Active;
						flag3 = true;
						num++;
						this.updateUiFromActionData(actiondata2);
					}
				}
				if (flag3)
				{
					this.FlagEvent_1 = false;
					this.updateActionsSelected();
					this.FlagEvent_1 = true;
					this.Putlog("HotKey '" + keyText4 + "' triggered. Settings affected: " + num.ToString());
				}
			}
		}

		private void cbActionsList_SelectedIndexChanged(object sender, EventArgs e)
		{
			ComboBox comboBox = (ComboBox)sender;
			if (comboBox.Items.Count == 0)
			{
				return;
			}
			actiondata actiondata = (actiondata)this.frmMain.lstActionsRegistered.SelectedItem;
			if (actiondata != null)
			{
				actiondata.type = (ActionType)comboBox.SelectedIndex;
				BindingSource bindingSource = (BindingSource)this.frmMain.lstActionsRegistered.DataSource;
				if (bindingSource != null && bindingSource.Current != null)
				{
					bindingSource.ResetCurrentItem();
				}
				this.updateCurrentAction();
			}
		}

		public itemdata getEquippedWeapon()
		{
			itemdata result = null;
			foreach (itemdata current in this.equipped)
			{
				if (current.isWeapon)
				{
					result = current;
					break;
				}
			}
			return result;
		}

		public itemdata getEquippedBow()
		{
			itemdata result = null;
			foreach (itemdata current in this.equipped)
			{
				if (current.isBow)
				{
					result = current;
					break;
				}
			}
			return result;
		}

		public itemdata getEquippedShield()
		{
			itemdata result = null;
			foreach (itemdata current in this.equipped)
			{
				if (current.isShield)
				{
					result = current;
					break;
				}
			}
			return result;
		}

		public void executeActionData(actiondata ad, bool force = false)
		{
			if (ad.mode == ActionMode.TIMER)
			{
				if (ad.timerSec < 0 || ad.timerQt <= 0 || ad.timerMax <= 0)
				{
					return;
				}
			}
			else if (ad.mode == ActionMode.FIXED && ad.fixedValue < 0)
			{
				return;
			}
			double totalSeconds = DateTime.Now.Subtract(new DateTime(1970, 1, 9, 0, 0, 0)).TotalSeconds;
			if (force || (ad.mode == ActionMode.TIMER && totalSeconds - ad.timeLast >= (double)ad.timerSec) || ad.mode == ActionMode.FIXED)
			{
				if (ad.section != "")
				{
					if (Array.IndexOf<string>(App.ACTION_SECTIONS, ad.section) > -1)
					{
						string key = ad.section;
						if (ad.section == "Bows" || ad.section == "Arrows")
						{
							key = "Archery";
						}
						if (this.lists.ContainsKey(key))
						{
							bool flag = true;
							if (ad.Active)
							{
								if (ad.counter == -1L)
								{
									this.Putlog("[Restore " + ad.section + "] Enabled.");
									ad.counter = 0L;
								}
								foreach (itemdata current in this.lists[key])
								{
									if ((!current.isWeaponBowShield || this.findItemByAddr(current.itemAddress, this.equipped.ToList<itemdata>()) == null) && (!(ad.section == "Arrows") || current.itemID.Contains("Arrow")) && (!(ad.section != "Arrows") || !current.itemID.Contains("Arrow")) && (!ad.UseFilter || this.findItemByID(current.itemID, ad.filterList.ToList<itemdata>()) != null) && (ad.mode != ActionMode.FIXED || ad.HiddenTimerElapsed()))
									{
										if (ad.mode == ActionMode.FIXED)
										{
											ad.HiddenTimerSec = 2;
											this.mem.SetInt32At(current.itemQtDurAddress, ad.fixedValue);
											ad.HiddenTimerTick();
											ad.counter += 1L;
										}
										else if (ad.mode == ActionMode.TIMER)
										{
											int int32At = this.mem.GetInt32At(current.itemQtDurAddress);
											if (int32At < ad.timerMax)
											{
												int num = (int32At + ad.timerQt <= ad.timerMax) ? ad.timerQt : (ad.timerMax - int32At);
												this.mem.SetInt32At(current.itemQtDurAddress, int32At + num);
												ad.counter += 1L;
											}
											if (int32At + ad.timerQt < ad.timerMax)
											{
												flag = false;
											}
										}
									}
								}
							}
							if ((ad.Active & flag) && ad.StopWhenDone)
							{
								this.Putlog("[" + ad.section + "] Auto restore stopped.");
								this.CheckControl("chk" + ad.section + "ActiveInactive", false);
								ad.Active = false;
							}
							if (!ad.Active && ad.counter >= 0L)
							{
								ad.counter = -1L;
								this.Putlog("[Restore " + ad.section + "] Disabled.");
							}
						}
					}
					else if (Array.IndexOf<string>(App.EXTENDED_ACTION_SECTIONS, ad.section) > -1)
					{
						if (ad.section == "LockHealth")
						{
							if (!ad.Active)
							{
								this.TextControl("lbl" + ad.section + "Info", "");
								if (ad.fixedValue > 0)
								{
									this.healthAddress = -1L;
									this.Putlog("[" + ad.section + "] Disabled.");
								}
								ad.fixedValue = 0;
								return;
							}
							if (ad.timerSec > 0 && totalSeconds - ad.timeLast >= (double)ad.timerSec)
							{
								ad.timerSec = 0;
							}
							else if (ad.timerSec > 0)
							{
								return;
							}
							if (this.healthAddress == -1L)
							{
								long num2;
								long num3;
								if (this.mem.FindRegionByAddr(this.inventoryStartAddress, out num2, out num3, IntPtr.Zero, true))
								{
									long num4 = num2 + num3;
									if (this.inventoryStartAddress > 0L)
									{
										num4 = this.inventoryStartAddress;
									}
									if (this.speedHackAddress > 0L)
									{
										num4 = this.speedHackAddress;
									}
									if (this.coordinatesAddress > 0L)
									{
										num2 = this.coordinatesAddress;
									}
									if (this.rupeesAddress > 0L)
									{
										num2 = this.rupeesAddress;
									}
									if (this.weaponsSlotsAddress > 0L)
									{
										num2 = this.weaponsSlotsAddress;
									}
									if (this.bowsSlotsAddress > 0L)
									{
										num2 = this.bowsSlotsAddress;
									}
									if (this.shieldsSlotsAddress > 0L)
									{
										num2 = this.shieldsSlotsAddress;
									}
									num3 = num4 - num2;
									this.TextControl("lbl" + ad.section + "Info", "Scanning memory...");
									this.Putlog("[" + ad.section + "] Scanning memory...");
									this.healthAddress = this.findHealthAddress(num2, num3);
									if (this.healthAddress >= 0L)
									{
										this.TextControl("lbl" + ad.section + "Info", "Found offset at 0x" + this.healthAddress.ToString("X"));
										this.Putlog("[" + ad.section + "] Found offset at 0x" + this.healthAddress.ToString("X"));
										ad.fixedValue = this.mem.GetInt32At(this.healthAddress);
									}
									else
									{
										this.TextControl("lbl" + ad.section + "Info", "Could not find offset");
										this.Putlog("[" + ad.section + "] Could not find offset");
										this.CheckControl("chk" + ad.section + "Set", false);
										ad.timerSec = 2;
									}
								}
							}
							else if (ad.fixedValue <= 0)
							{
								ad.timerSec = 2;
								ad.fixedValue = 0;
								this.healthAddress = -1L;
								this.Putlog(string.Concat(new object[]
								{
									"[",
									ad.section,
									"] Warning ! Null or Negative value : ",
									ad.fixedValue
								}));
							}
							else
							{
								this.mem.SetInt32At(this.healthAddress, ad.fixedValue);
							}
						}
						if (ad.section == "LockStamina")
						{
							if (!ad.Active)
							{
								this.TextControl("lbl" + ad.section + "Info", "");
								if (ad.fixedValue > 0)
								{
									this.staminaAddress = -1L;
									this.Putlog("[" + ad.section + "] Disabled.");
								}
								ad.fixedValue = 0;
								return;
							}
							if (ad.timerSec > 0 && totalSeconds - ad.timeLast >= (double)ad.timerSec)
							{
								ad.timerSec = 0;
							}
							else if (ad.timerSec > 0)
							{
								return;
							}
							if (this.staminaAddress == -1L)
							{
								long num5;
								long num6;
								if (this.mem.FindRegionByAddr(this.inventoryStartAddress, out num5, out num6, IntPtr.Zero, true))
								{
									long num7 = num5 + num6;
									if (this.inventoryStartAddress > 0L)
									{
										num7 = this.inventoryStartAddress;
									}
									if (this.speedHackAddress > 0L)
									{
										num7 = this.speedHackAddress;
									}
									if (this.coordinatesAddress > 0L)
									{
										num5 = this.coordinatesAddress;
									}
									if (this.rupeesAddress > 0L)
									{
										num5 = this.rupeesAddress;
									}
									if (this.weaponsSlotsAddress > 0L)
									{
										num5 = this.weaponsSlotsAddress;
									}
									if (this.bowsSlotsAddress > 0L)
									{
										num5 = this.bowsSlotsAddress;
									}
									if (this.shieldsSlotsAddress > 0L)
									{
										num5 = this.shieldsSlotsAddress;
									}
									num6 = num7 - num5;
									this.TextControl("lbl" + ad.section + "Info", "Scanning memory...");
									this.Putlog("[" + ad.section + "] Scanning memory...");
									this.staminaAddress = this.findStaminaAddress(num5, num6);
									if (this.staminaAddress >= 0L)
									{
										this.TextControl("lbl" + ad.section + "Info", "Found offset at 0x" + this.staminaAddress.ToString("X"));
										this.Putlog("[" + ad.section + "] Found offset at 0x" + this.staminaAddress.ToString("X"));
										ad.fixedValue = this.mem.GetInt32At(this.staminaAddress);
									}
									else
									{
										this.TextControl("lbl" + ad.section + "Info", "Could not find offset");
										this.Putlog("[" + ad.section + "] Could not find offset");
										this.CheckControl("chk" + ad.section + "Set", false);
										ad.timerSec = 2;
									}
								}
							}
							else if (ad.fixedValue <= 0)
							{
								ad.timerSec = 2;
								ad.fixedValue = 0;
								this.staminaAddress = -1L;
								this.Putlog(string.Concat(new object[]
								{
									"[",
									ad.section,
									"] Warning ! Null or Negative value : ",
									ad.fixedValue
								}));
							}
							else
							{
								this.mem.SetInt32At(this.staminaAddress, ad.fixedValue);
							}
						}
						if (ad.section == "UnbreakableWeapons")
						{
							if (!ad.Active)
							{
								this.TextControl("lbl" + ad.section + "Info", "");
								if (ad.fixedValue > 0)
								{
									this.equippedWeaponDurabilityAddress = -1L;
									this.Putlog("[" + ad.section + "] Disabled.");
								}
								ad.fixedValue = 0;
								return;
							}
							if (ad.timerSec > 0 && totalSeconds - ad.timeLast >= (double)ad.timerSec)
							{
								ad.timerSec = 0;
							}
							else if (ad.timerSec > 0)
							{
								return;
							}
							if (this.equippedWeaponDurabilityAddress == -1L)
							{
								using (List<itemdata>.Enumerator enumerator2 = this.equipped.ToList<itemdata>().GetEnumerator())
								{
									while (enumerator2.MoveNext())
									{
										itemdata current2 = enumerator2.Current;
										if (current2.isWeapon)
										{
											this.TextControl("lbl" + ad.section + "Info", "Scanning memory...");
											this.Putlog("[" + ad.section + "] Scanning memory...");
											this.equippedWeaponDurabilityAddress = this.findEquippedDurabilityAddress(current2);
											if (this.equippedWeaponDurabilityAddress >= 0L)
											{
												this.TextControl("lbl" + ad.section + "Info", "Found offset at 0x" + this.equippedWeaponDurabilityAddress.ToString("X"));
												this.Putlog("[" + ad.section + "] Found offset at 0x" + this.equippedWeaponDurabilityAddress.ToString("X"));
												ad.fixedValue = this.mem.GetInt32At(this.equippedWeaponDurabilityAddress);
												if (ad.fixedValue < 1000)
												{
													ad.fixedValue = 7777;
													if (!ad.UseFilter || this.findItemByID(current2.itemID, ad.filterList.ToList<itemdata>()) != null)
													{
														this.mem.SetInt32At(this.equippedWeaponDurabilityAddress, ad.fixedValue);
														this.mem.SetInt32At(current2.itemQtDurAddress, ad.fixedValue);
													}
												}
											}
											else
											{
												this.TextControl("lbl" + ad.section + "Info", "Could not find offset");
												this.Putlog("[" + ad.section + "] Could not find offset");
												ad.timerSec = 2;
											}
										}
									}
									goto IL_C64;
								}
							}
							if (ad.fixedValue <= 0)
							{
								ad.timerSec = 2;
								ad.fixedValue = 0;
								this.equippedWeaponDurabilityAddress = -1L;
							}
							else
							{
								itemdata equippedWeapon = this.getEquippedWeapon();
								if (equippedWeapon != null && (!ad.UseFilter || this.findItemByID(equippedWeapon.itemID, ad.filterList.ToList<itemdata>()) != null))
								{
									this.mem.SetInt32At(this.equippedWeaponDurabilityAddress, ad.fixedValue);
									this.mem.SetInt32At(equippedWeapon.itemQtDurAddress, ad.fixedValue);
								}
							}
						}
						IL_C64:
						if (ad.section == "UnbreakableBows")
						{
							if (!ad.Active)
							{
								this.TextControl("lbl" + ad.section + "Info", "");
								if (ad.fixedValue > 0)
								{
									this.equippedBowDurabilityAddress = -1L;
									this.Putlog("[" + ad.section + "] Disabled.");
								}
								ad.fixedValue = 0;
								return;
							}
							if (ad.timerSec > 0 && totalSeconds - ad.timeLast >= (double)ad.timerSec)
							{
								ad.timerSec = 0;
							}
							else if (ad.timerSec > 0)
							{
								return;
							}
							if (this.equippedBowDurabilityAddress == -1L)
							{
								using (IEnumerator<itemdata> enumerator = this.equipped.GetEnumerator())
								{
									while (enumerator.MoveNext())
									{
										itemdata current3 = enumerator.Current;
										if (current3.isBow)
										{
											this.TextControl("lbl" + ad.section + "Info", "Scanning memory...");
											this.Putlog("[" + ad.section + "] Scanning memory...");
											this.equippedBowDurabilityAddress = this.findEquippedDurabilityAddress(current3);
											if (this.equippedBowDurabilityAddress >= 0L)
											{
												this.TextControl("lbl" + ad.section + "Info", "Found offset at 0x" + this.equippedBowDurabilityAddress.ToString("X"));
												this.Putlog("[" + ad.section + "] Found offset at 0x" + this.equippedBowDurabilityAddress.ToString("X"));
												ad.fixedValue = this.mem.GetInt32At(this.equippedBowDurabilityAddress);
												if (ad.fixedValue < 1000)
												{
													ad.fixedValue = 7776;
													if (!ad.UseFilter || this.findItemByID(current3.itemID, ad.filterList.ToList<itemdata>()) != null)
													{
														this.mem.SetInt32At(this.equippedBowDurabilityAddress, ad.fixedValue);
														this.mem.SetInt32At(current3.itemQtDurAddress, ad.fixedValue);
													}
												}
											}
											else
											{
												this.TextControl("lbl" + ad.section + "Info", "Could not find offset");
												this.Putlog("[" + ad.section + "] Could not find offset");
												ad.timerSec = 2;
											}
										}
									}
									goto IL_F4E;
								}
							}
							if (ad.fixedValue <= 0)
							{
								ad.timerSec = 2;
								ad.fixedValue = 0;
								this.equippedBowDurabilityAddress = -1L;
							}
							else
							{
								itemdata equippedBow = this.getEquippedBow();
								if (equippedBow != null && (!ad.UseFilter || this.findItemByID(equippedBow.itemID, ad.filterList.ToList<itemdata>()) != null))
								{
									this.mem.SetInt32At(this.equippedBowDurabilityAddress, ad.fixedValue);
									this.mem.SetInt32At(equippedBow.itemQtDurAddress, ad.fixedValue);
								}
							}
						}
						IL_F4E:
						if (ad.section == "UnbreakableShields")
						{
							if (!ad.Active)
							{
								this.TextControl("lbl" + ad.section + "Info", "");
								if (ad.fixedValue > 0)
								{
									this.equippedShieldDurabilityAddress = -1L;
									this.Putlog("[" + ad.section + "] Disabled.");
								}
								ad.fixedValue = 0;
								return;
							}
							if (ad.timerSec > 0 && totalSeconds - ad.timeLast >= (double)ad.timerSec)
							{
								ad.timerSec = 0;
							}
							else if (ad.timerSec > 0)
							{
								return;
							}
							if (this.equippedShieldDurabilityAddress == -1L)
							{
								using (IEnumerator<itemdata> enumerator = this.equipped.GetEnumerator())
								{
									while (enumerator.MoveNext())
									{
										itemdata current4 = enumerator.Current;
										if (current4.isShield)
										{
											this.TextControl("lbl" + ad.section + "Info", "Scanning memory...");
											this.Putlog("[" + ad.section + "] Scanning memory...");
											this.equippedShieldDurabilityAddress = this.findEquippedDurabilityAddress(current4);
											if (this.equippedShieldDurabilityAddress >= 0L)
											{
												this.TextControl("lbl" + ad.section + "Info", "Found offset at 0x" + this.equippedShieldDurabilityAddress.ToString("X"));
												this.Putlog("[" + ad.section + "] Found offset at 0x" + this.equippedShieldDurabilityAddress.ToString("X"));
												ad.fixedValue = this.mem.GetInt32At(this.equippedShieldDurabilityAddress);
												if (ad.fixedValue < 1000)
												{
													ad.fixedValue = 7775;
													if (!ad.UseFilter || this.findItemByID(current4.itemID, ad.filterList.ToList<itemdata>()) != null)
													{
														this.mem.SetInt32At(this.equippedShieldDurabilityAddress, ad.fixedValue);
														this.mem.SetInt32At(current4.itemQtDurAddress, ad.fixedValue);
													}
												}
											}
											else
											{
												this.TextControl("lbl" + ad.section + "Info", "Could not find offset");
												this.Putlog("[" + ad.section + "] Could not find offset");
												ad.timerSec = 2;
											}
										}
									}
									goto IL_1238;
								}
							}
							if (ad.fixedValue <= 0)
							{
								ad.timerSec = 2;
								ad.fixedValue = 0;
								this.equippedShieldDurabilityAddress = -1L;
							}
							else
							{
								itemdata equippedShield = this.getEquippedShield();
								if (equippedShield != null && (!ad.UseFilter || this.findItemByID(equippedShield.itemID, ad.filterList.ToList<itemdata>()) != null))
								{
									this.mem.SetInt32At(this.equippedShieldDurabilityAddress, ad.fixedValue);
									this.mem.SetInt32At(equippedShield.itemQtDurAddress, ad.fixedValue);
								}
							}
						}
						IL_1238:
						if (ad.section == "PowersMipha")
						{
							if (!ad.Active)
							{
								this.TextControl("lbl" + ad.section + "Info", "");
								if (ad.fixedValue > 0)
								{
									this.divinePowerMiphaTimerAddress = -1L;
									this.Putlog("[" + ad.section + "] Disabled.");
								}
								ad.fixedValue = 0;
								return;
							}
							if (ad.timerSec > 0 && totalSeconds - ad.timeLast >= (double)ad.timerSec)
							{
								ad.timerSec = 0;
							}
							else if (ad.timerSec > 0)
							{
								return;
							}
							if (this.divinePowerMiphaTimerAddress == -1L)
							{
								long num8;
								long num9;
								if (this.mem.FindRegionByAddr(this.inventoryStartAddress, out num8, out num9, IntPtr.Zero, true))
								{
									this.TextControl("lbl" + ad.section + "Info", "Scanning memory...");
									this.Putlog("[" + ad.section + "] Scanning memory...");
									int num10 = 324;
									long num11 = -1L;
									if (this.divinePowerMiphaTimerAddress != -1L)
									{
										num11 = this.divinePowerMiphaTimerAddress - 324L;
									}
									if (this.divinePowerRevaliAddress != -1L)
									{
										num11 = this.divinePowerRevaliAddress;
									}
									if (this.divinePowerUrbosaAddress != -1L)
									{
										num11 = this.divinePowerUrbosaAddress - 4L;
									}
									if (this.divinePowerDarukAddress != -1L)
									{
										num11 = this.divinePowerDarukAddress - 8L;
									}
									long num12;
									if (num11 != -1L)
									{
										num12 = num11;
									}
									else
									{
										num12 = this.findPowersAddress(num8, this.inventoryStartAddress - num8);
									}
									if (num12 >= 0L)
									{
										this.divinePowerMiphaTimerAddress = num12 + (long)num10;
										this.TextControl("lbl" + ad.section + "Info", "Found offset at 0x" + this.divinePowerMiphaTimerAddress.ToString("X"));
										this.Putlog("[" + ad.section + "] Found offset at 0x" + this.divinePowerMiphaTimerAddress.ToString("X"));
										ad.fixedValue = 65;
									}
									else
									{
										this.divinePowerMiphaTimerAddress = -1L;
										this.TextControl("lbl" + ad.section + "Info", "Could not find offset");
										this.Putlog("[" + ad.section + "] Could not find offset");
										this.CheckControl("chk" + ad.section + "Set", false);
										ad.timerSec = 2;
									}
								}
							}
							else if (ad.fixedValue <= 0)
							{
								ad.timerSec = 2;
								ad.fixedValue = 0;
								this.divinePowerMiphaTimerAddress = -1L;
							}
							else
							{
								if (this.mem.GetByteAt(this.divinePowerMiphaTimerAddress) < 190)
								{
									this.mem.SetByteAt(this.divinePowerMiphaTimerAddress, (byte)ad.fixedValue);
								}
								ad.timerSec = 5;
							}
						}
						if (ad.section == "PowersRevali")
						{
							if (!ad.Active)
							{
								this.TextControl("lbl" + ad.section + "Info", "");
								if (ad.fixedValue > 0)
								{
									this.divinePowerRevaliAddress = -1L;
									this.Putlog("[" + ad.section + "] Disabled.");
								}
								ad.fixedValue = 0;
								return;
							}
							if (ad.timerSec > 0 && totalSeconds - ad.timeLast >= (double)ad.timerSec)
							{
								ad.timerSec = 0;
							}
							else if (ad.timerSec > 0)
							{
								return;
							}
							if (this.divinePowerRevaliAddress == -1L)
							{
								long num13;
								long num14;
								if (this.mem.FindRegionByAddr(this.inventoryStartAddress, out num13, out num14, IntPtr.Zero, true))
								{
									this.TextControl("lbl" + ad.section + "Info", "Scanning memory...");
									this.Putlog("[" + ad.section + "] Scanning memory...");
									int num15 = 0;
									long num16 = -1L;
									if (this.divinePowerMiphaTimerAddress != -1L)
									{
										num16 = this.divinePowerMiphaTimerAddress - 324L;
									}
									if (this.divinePowerRevaliAddress != -1L)
									{
										num16 = this.divinePowerRevaliAddress;
									}
									if (this.divinePowerUrbosaAddress != -1L)
									{
										num16 = this.divinePowerUrbosaAddress - 4L;
									}
									if (this.divinePowerDarukAddress != -1L)
									{
										num16 = this.divinePowerDarukAddress - 8L;
									}
									long num17;
									if (num16 != -1L)
									{
										num17 = num16;
									}
									else
									{
										num17 = this.findPowersAddress(num13, this.inventoryStartAddress - num13);
									}
									if (num17 >= 0L)
									{
										this.divinePowerRevaliAddress = num17 + (long)num15;
										this.TextControl("lbl" + ad.section + "Info", "Found offset at 0x" + this.divinePowerRevaliAddress.ToString("X"));
										this.Putlog("[" + ad.section + "] Found offset at 0x" + this.divinePowerRevaliAddress.ToString("X"));
										ad.fixedValue = 99;
									}
									else
									{
										this.divinePowerRevaliAddress = -1L;
										this.TextControl("lbl" + ad.section + "Info", "Could not find offset");
										this.Putlog("[" + ad.section + "] Could not find offset");
										this.CheckControl("chk" + ad.section + "Set", false);
										ad.timerSec = 2;
									}
								}
							}
							else if (ad.fixedValue <= 0)
							{
								ad.timerSec = 2;
								ad.fixedValue = 0;
								this.divinePowerRevaliAddress = -1L;
							}
							else
							{
								this.mem.SetInt32At(this.divinePowerRevaliAddress, ad.fixedValue);
								ad.timerSec = 5;
							}
						}
						if (ad.section == "PowersUrbosa")
						{
							if (!ad.Active)
							{
								this.TextControl("lbl" + ad.section + "Info", "");
								if (ad.fixedValue > 0)
								{
									this.divinePowerUrbosaAddress = -1L;
									this.Putlog("[" + ad.section + "] Disabled.");
								}
								ad.fixedValue = 0;
								return;
							}
							if (ad.timerSec > 0 && totalSeconds - ad.timeLast >= (double)ad.timerSec)
							{
								ad.timerSec = 0;
							}
							else if (ad.timerSec > 0)
							{
								return;
							}
							if (this.divinePowerUrbosaAddress == -1L)
							{
								long num18;
								long num19;
								if (this.mem.FindRegionByAddr(this.inventoryStartAddress, out num18, out num19, IntPtr.Zero, true))
								{
									this.TextControl("lbl" + ad.section + "Info", "Scanning memory...");
									this.Putlog("[" + ad.section + "] Scanning memory...");
									int num20 = 4;
									long num21 = -1L;
									if (this.divinePowerMiphaTimerAddress != -1L)
									{
										num21 = this.divinePowerMiphaTimerAddress - 324L;
									}
									if (this.divinePowerRevaliAddress != -1L)
									{
										num21 = this.divinePowerRevaliAddress;
									}
									if (this.divinePowerUrbosaAddress != -1L)
									{
										num21 = this.divinePowerUrbosaAddress - 4L;
									}
									if (this.divinePowerDarukAddress != -1L)
									{
										num21 = this.divinePowerDarukAddress - 8L;
									}
									long num22;
									if (num21 != -1L)
									{
										num22 = num21;
									}
									else
									{
										num22 = this.findPowersAddress(num18, this.inventoryStartAddress - num18);
									}
									if (num22 >= 0L)
									{
										this.divinePowerUrbosaAddress = num22 + (long)num20;
										this.TextControl("lbl" + ad.section + "Info", "Found offset at 0x" + this.divinePowerUrbosaAddress.ToString("X"));
										this.Putlog("[" + ad.section + "] Found offset at 0x" + this.divinePowerUrbosaAddress.ToString("X"));
										ad.fixedValue = 99;
									}
									else
									{
										this.divinePowerUrbosaAddress = -1L;
										this.TextControl("lbl" + ad.section + "Info", "Could not find offset");
										this.Putlog("[" + ad.section + "] Could not find offset");
										this.CheckControl("chk" + ad.section + "Set", false);
										ad.timerSec = 2;
									}
								}
							}
							else if (ad.fixedValue <= 0)
							{
								ad.timerSec = 2;
								ad.fixedValue = 0;
								this.divinePowerUrbosaAddress = -1L;
							}
							else
							{
								this.mem.SetInt32At(this.divinePowerUrbosaAddress, ad.fixedValue);
								ad.timerSec = 5;
							}
						}
						if (ad.section == "PowersDaruk")
						{
							if (!ad.Active)
							{
								this.TextControl("lbl" + ad.section + "Info", "");
								if (ad.fixedValue > 0)
								{
									this.divinePowerDarukAddress = -1L;
									this.Putlog("[" + ad.section + "] Disabled.");
								}
								ad.fixedValue = 0;
								return;
							}
							if (ad.timerSec > 0 && totalSeconds - ad.timeLast >= (double)ad.timerSec)
							{
								ad.timerSec = 0;
							}
							else if (ad.timerSec > 0)
							{
								return;
							}
							if (this.divinePowerDarukAddress == -1L)
							{
								long num23;
								long num24;
								if (this.mem.FindRegionByAddr(this.inventoryStartAddress, out num23, out num24, IntPtr.Zero, true))
								{
									this.TextControl("lbl" + ad.section + "Info", "Scanning memory...");
									this.Putlog("[" + ad.section + "] Scanning memory...");
									int num25 = 8;
									long num26 = -1L;
									if (this.divinePowerMiphaTimerAddress != -1L)
									{
										num26 = this.divinePowerMiphaTimerAddress - 324L;
									}
									if (this.divinePowerRevaliAddress != -1L)
									{
										num26 = this.divinePowerRevaliAddress;
									}
									if (this.divinePowerUrbosaAddress != -1L)
									{
										num26 = this.divinePowerUrbosaAddress - 4L;
									}
									if (this.divinePowerDarukAddress != -1L)
									{
										num26 = this.divinePowerDarukAddress - 8L;
									}
									long num27;
									if (num26 != -1L)
									{
										num27 = num26;
									}
									else
									{
										num27 = this.findPowersAddress(num23, this.inventoryStartAddress - num23);
									}
									if (num27 >= 0L)
									{
										this.divinePowerDarukAddress = num27 + (long)num25;
										this.TextControl("lbl" + ad.section + "Info", "Found offset at 0x" + this.divinePowerDarukAddress.ToString("X"));
										this.Putlog("[" + ad.section + "] Found offset at 0x" + this.divinePowerDarukAddress.ToString("X"));
										ad.fixedValue = 99;
									}
									else
									{
										this.divinePowerDarukAddress = -1L;
										this.TextControl("lbl" + ad.section + "Info", "Could not find offset");
										this.Putlog("[" + ad.section + "] Could not find offset");
										this.CheckControl("chk" + ad.section + "Set", false);
										ad.timerSec = 2;
									}
								}
							}
							else if (ad.fixedValue <= 0)
							{
								ad.timerSec = 2;
								ad.fixedValue = 0;
								this.divinePowerDarukAddress = -1L;
							}
							else
							{
								this.mem.SetInt32At(this.divinePowerDarukAddress, ad.fixedValue);
								ad.timerSec = 5;
							}
						}
						if (ad.section == "UnlimitAmiibo")
						{
							if (!ad.Active)
							{
								this.TextControl("lbl" + ad.section + "Info", "");
								if (ad.fixedValue > 0)
								{
									if (this.amiiboDateAddress != -1L)
									{
										this.mem.SetInt32At(this.amiiboDateAddress, ad.fixedValue);
									}
									this.amiiboDateAddress = -1L;
									this.Putlog("[" + ad.section + "] Disabled.");
								}
								ad.fixedValue = 0;
								return;
							}
							if (ad.timerSec > 0 && totalSeconds - ad.timeLast >= (double)ad.timerSec)
							{
								ad.timerSec = 0;
							}
							else if (ad.timerSec > 0)
							{
								return;
							}
							if (this.amiiboDateAddress == -1L)
							{
								long num28;
								long num29;
								if (this.mem.FindRegionByAddr(this.inventoryStartAddress, out num28, out num29, IntPtr.Zero, true))
								{
									this.TextControl("lbl" + ad.section + "Info", "Scanning memory...");
									this.Putlog("[" + ad.section + "] Scanning memory...");
									long num30 = this.findAmiiboDateAddress(num28, this.inventoryStartAddress - num28);
									if (num30 >= 0L)
									{
										this.amiiboDateAddress = num30;
										this.TextControl("lbl" + ad.section + "Info", "Found offset at 0x" + this.amiiboDateAddress.ToString("X"));
										this.Putlog("[" + ad.section + "] Found offset at 0x" + this.amiiboDateAddress.ToString("X"));
										ad.fixedValue = this.mem.GetInt32At(this.amiiboDateAddress);
									}
									else
									{
										this.amiiboDateAddress = -1L;
										this.TextControl("lbl" + ad.section + "Info", "Could not find offset");
										this.Putlog("[" + ad.section + "] Could not find offset");
										this.CheckControl("chk" + ad.section + "Set", false);
										ad.timerSec = 2;
									}
								}
							}
							else if (ad.fixedValue <= 0)
							{
								ad.timerSec = 2;
								ad.fixedValue = 0;
								this.amiiboDateAddress = -1L;
							}
							else
							{
								this.mem.SetInt32At(this.amiiboDateAddress, 19700101);
								ad.timerSec = 5;
							}
						}
						if (ad.section == "PositionSave" && ad.Active)
						{
							this.SavePosition();
							ad.Active = false;
						}
						if (ad.section == "PositionRestore" && ad.Active)
						{
							this.RestorePosition();
							ad.Active = false;
						}
						if (ad.section == "PositionJump" && ad.Active)
						{
							this.JumpPosition();
							ad.Active = false;
						}
						if (ad.section == "PositionLockHeight")
						{
							if (!ad.Active)
							{
								if (ad.singleValue != 0f)
								{
									this.lockedY = 0f;
									this.Putlog("[" + ad.section + "] Disabled.");
								}
								ad.singleValue = 0f;
								return;
							}
							if (ad.timerSec > 0 && totalSeconds - ad.timeLast >= (double)ad.timerSec)
							{
								ad.timerSec = 0;
							}
							else if (ad.timerSec > 0)
							{
								return;
							}
							if (this.lockedY == 0f)
							{
								this.lockedY = this.mem.GetSingleAt(this.coordinatesAddress + 4L);
								ad.singleValue = this.lockedY;
								this.Putlog("[" + ad.section + "] Locking Altitude (Y) to " + ad.singleValue.ToString());
							}
							else
							{
								this.mem.SetSingleAt(this.coordinatesAddress + 4L, ad.singleValue);
							}
						}
						if (ad.section == "RunSpeedUp" && ad.Active)
						{
							this.UpdateRunSpeedMultiplier(this.GetTxtRunSpeed() + 0.25);
							ad.Active = false;
						}
						if (ad.section == "RunSpeedDown" && ad.Active)
						{
							this.UpdateRunSpeedMultiplier(this.GetTxtRunSpeed() - 0.25);
							ad.Active = false;
						}
						if (ad.section == "RunSpeedDefault" && ad.Active)
						{
							this.UpdateRunSpeedMultiplier(1.0);
							ad.Active = false;
						}
					}
					ad.timeLast = totalSeconds;
					return;
				}
				if (!ad.Active)
				{
					if (ad.counter >= 0L)
					{
						this.Putlog("[Restore " + ad.ToString() + "] Disabled.");
						ad.counter = -1L;
					}
					return;
				}
				if (ad.counter == -1L)
				{
					this.Putlog("[Restore " + ad.ToString() + "] Enabled.");
					ad.counter = 0L;
				}
				string text = "";
				if (ad.type == ActionType.SET_BOWS_DUR)
				{
					text = "Archery";
				}
				if (ad.type == ActionType.SET_WEAPONS_DUR)
				{
					text = "Weapons";
				}
				if (ad.type == ActionType.SET_SHIELDS_DUR)
				{
					text = "Shields";
				}
				if (ad.type == ActionType.SET_ITEMS_QT)
				{
					text = "Inventory";
				}
				if (text != "" && this.lists.ContainsKey(text))
				{
					bool flag2 = true;
					foreach (itemdata current5 in this.lists[text])
					{
						if ((!current5.isWeaponBowShield || this.findItemByAddr(current5.itemAddress, this.equipped.ToList<itemdata>()) == null) && (ad.type != ActionType.SET_BOWS_DUR || !current5.itemID.Contains("Arrow")) && (ad.type != ActionType.SET_ITEMS_QT || !current5.isEquipment) && (!ad.UseFilter || this.findItemByID(current5.itemID, ad.filterList.ToList<itemdata>()) != null) && (ad.mode != ActionMode.FIXED || ad.HiddenTimerElapsed()))
						{
							if (ad.mode == ActionMode.FIXED)
							{
								ad.HiddenTimerSec = 2;
								this.mem.SetInt32At(current5.itemQtDurAddress, ad.fixedValue);
								ad.HiddenTimerTick();
								ad.counter += 1L;
							}
							else if (ad.mode == ActionMode.TIMER)
							{
								int int32At2 = this.mem.GetInt32At(current5.itemQtDurAddress);
								if (int32At2 < ad.timerMax)
								{
									int num31 = (int32At2 + ad.timerQt <= ad.timerMax) ? ad.timerQt : (ad.timerMax - int32At2);
									this.mem.SetInt32At(current5.itemQtDurAddress, int32At2 + num31);
									ad.counter += 1L;
								}
								if (int32At2 + ad.timerQt < ad.timerMax)
								{
									flag2 = false;
								}
							}
						}
					}
					if (flag2 && ad.StopWhenDone)
					{
						this.Putlog("[" + ad.ToString() + "] Auto restore stopped.");
						actiondata actiondata = (actiondata)((ListBox)this.findControl("lstActionsRegistered")).SelectedItem;
						if (actiondata != null && actiondata == ad)
						{
							this.CheckControl("chkActionsActiveInactive", false);
						}
						ad.Active = false;
					}
				}
				else
				{
					bool flag3 = true;
					if (ad.type == ActionType.SET_RUPEES && this.rupeesAddress >= 0L)
					{
						if (ad.mode == ActionMode.FIXED && !ad.HiddenTimerElapsed())
						{
							return;
						}
						if (ad.mode == ActionMode.FIXED)
						{
							ad.HiddenTimerSec = 2;
							this.mem.SetInt32At(this.rupeesAddress, ad.fixedValue);
							ad.HiddenTimerTick();
							ad.counter += 1L;
						}
						else if (ad.mode == ActionMode.TIMER)
						{
							int int32At3 = this.mem.GetInt32At(this.rupeesAddress);
							if (int32At3 < ad.timerMax)
							{
								int num32 = (int32At3 + ad.timerQt <= ad.timerMax) ? ad.timerQt : (ad.timerMax - int32At3);
								this.mem.SetInt32At(this.rupeesAddress, int32At3 + num32);
								ad.counter += 1L;
							}
							if (int32At3 + ad.timerQt < ad.timerMax)
							{
								flag3 = false;
							}
						}
					}
					if (ad.type == ActionType.SET_HEALTH)
					{
						long num33;
						long num34;
						if (this.healthAddress < 0L && this.mem.FindRegionByAddr(this.inventoryStartAddress, out num33, out num34, IntPtr.Zero, true))
						{
							this.Putlog("[" + ad.ToString() + "] Scanning memory...");
							long num35 = this.findHealthAddress(num33, this.inventoryStartAddress - num33);
							if (num35 >= 0L)
							{
								this.Putlog("[" + ad.ToString() + "] Found offset at 0x" + num35.ToString("X"));
								this.healthAddress = num35;
							}
							else
							{
								this.Putlog("[" + ad.ToString() + "] Could not find offset");
							}
						}
						if (this.healthAddress >= 0L)
						{
							if (ad.mode == ActionMode.FIXED && !ad.HiddenTimerElapsed())
							{
								return;
							}
							if (ad.mode == ActionMode.FIXED)
							{
								ad.HiddenTimerSec = 2;
								this.mem.SetInt32At(this.healthAddress, ad.fixedValue);
								ad.HiddenTimerTick();
								ad.counter += 1L;
							}
							else if (ad.mode == ActionMode.TIMER)
							{
								int int32At4 = this.mem.GetInt32At(this.healthAddress);
								if (int32At4 < ad.timerMax)
								{
									int num36 = (int32At4 + ad.timerQt <= ad.timerMax) ? ad.timerQt : (ad.timerMax - int32At4);
									this.mem.SetInt32At(this.healthAddress, int32At4 + num36);
									ad.counter += 1L;
								}
								if (int32At4 + ad.timerQt < ad.timerMax)
								{
									flag3 = false;
								}
							}
						}
					}
					if (ad.type == ActionType.SET_STAMINA)
					{
						long num37;
						long num38;
						if (this.staminaAddress < 0L && this.mem.FindRegionByAddr(this.inventoryStartAddress, out num37, out num38, IntPtr.Zero, true))
						{
							this.Putlog("[" + ad.ToString() + "] Scanning memory...");
							long num39 = this.findStaminaAddress(num37, this.inventoryStartAddress - num37);
							if (num39 >= 0L)
							{
								this.Putlog("[" + ad.ToString() + "] Found offset at 0x" + num39.ToString("X"));
								this.staminaAddress = num39;
							}
							else
							{
								this.Putlog("[" + ad.ToString() + "] Could not find offset");
							}
						}
						if (this.staminaAddress >= 0L)
						{
							if (ad.mode == ActionMode.FIXED && !ad.HiddenTimerElapsed())
							{
								return;
							}
							if (ad.mode == ActionMode.FIXED)
							{
								ad.HiddenTimerSec = 2;
								this.mem.SetInt32At(this.staminaAddress, ad.fixedValue);
								ad.HiddenTimerTick();
								ad.counter += 1L;
							}
							else if (ad.mode == ActionMode.TIMER)
							{
								int int32At5 = this.mem.GetInt32At(this.staminaAddress);
								if (int32At5 < ad.timerMax)
								{
									int num40 = (int32At5 + ad.timerQt <= ad.timerMax) ? ad.timerQt : (ad.timerMax - int32At5);
									this.mem.SetInt32At(this.staminaAddress, int32At5 + num40);
									ad.counter += 1L;
								}
								if (int32At5 + ad.timerQt < ad.timerMax)
								{
									flag3 = false;
								}
							}
						}
					}
					if (flag3 && ad.StopWhenDone)
					{
						this.Putlog("[" + ad.ToString() + "] stopped.");
						actiondata actiondata2 = (actiondata)((ListBox)this.findControl("lstActionsRegistered")).SelectedItem;
						if (actiondata2 != null && actiondata2 == ad)
						{
							this.CheckControl("chkActionsActiveInactive", false);
						}
						ad.Active = false;
					}
				}
				ad.timeLast = totalSeconds;
			}
		}

		public void updateActionDatas()
		{
			string[] array = App.ACTION_SECTIONS;
			for (int i = 0; i < array.Length; i++)
			{
				string text = array[i];
				try
				{
					if (this.listActions.ContainsKey(text))
					{
						actiondata actiondata = this.createActionData(text);
						actiondata actiondata2 = (actiondata)this.listActions[text];
						actiondata.timeLast = actiondata2.timeLast;
						actiondata.section = actiondata2.section;
						actiondata.desc = actiondata2.desc;
						actiondata.counter = actiondata2.counter;
						actiondata.HiddenTimerSec = actiondata2.HiddenTimerSec;
						this.listActions[text] = actiondata;
					}
				}
				catch (Exception)
				{
				}
			}
			array = App.EXTENDED_ACTION_SECTIONS;
			for (int i = 0; i < array.Length; i++)
			{
				string text2 = array[i];
				try
				{
					if (this.listActions.ContainsKey(text2))
					{
						bool arg_F8_0 = (CheckBox)this.findControl("chk" + text2 + "Set") != null;
						actiondata actiondata3 = this.createActionData(text2);
						actiondata actiondata4 = (actiondata)this.listActions[text2];
						if (!arg_F8_0)
						{
							actiondata3.Active = actiondata4.Active;
						}
						actiondata3.timeLast = actiondata4.timeLast;
						actiondata3.section = actiondata4.section;
						actiondata3.desc = actiondata4.desc;
						actiondata3.counter = actiondata4.counter;
						actiondata3.HiddenTimerSec = actiondata4.HiddenTimerSec;
						if (actiondata4.fixedValue >= 0)
						{
							actiondata3.fixedValue = actiondata4.fixedValue;
						}
						if (actiondata4.singleValue != 0f)
						{
							actiondata3.singleValue = actiondata4.singleValue;
						}
						this.listActions[text2] = actiondata3;
					}
				}
				catch (Exception)
				{
				}
			}
		}

		public actiondata createActionData(string action_section)
		{
			actiondata actiondata = new actiondata();
			if (Array.IndexOf<string>(App.ACTION_SECTIONS, action_section) > -1)
			{
				RadioButton radioButton = (RadioButton)this.findControl("option" + action_section + "Fixed");
				RadioButton arg_4E_0 = (RadioButton)this.findControl("option" + action_section + "Timer");
				RadioButton radioButton2 = (RadioButton)this.findControl("option" + action_section + "NoFilter");
				RadioButton arg_86_0 = (RadioButton)this.findControl("option" + action_section + "FilterList");
				ListControl arg_2AD_0 = (ListBox)this.findControl("lst" + action_section + "Filter");
				CheckBox checkBox = (CheckBox)this.findControl("chk" + action_section + "DisableWhenDone");
				CheckBox checkBox2 = (CheckBox)this.findControl("chk" + action_section + "UseHotkey");
				CheckBox checkBox3 = (CheckBox)this.findControl("chk" + action_section + "ActiveInactive");
				TextBox textBox = (TextBox)this.findControl("txt" + action_section + "Fixed");
				TextBox textBox2 = (TextBox)this.findControl("txt" + action_section + "Timer");
				TextBox textBox3 = (TextBox)this.findControl("txt" + action_section + "Quantity");
				TextBox textBox4 = (TextBox)this.findControl("txt" + action_section + "Max");
				TextBox textBox5 = (TextBox)this.findControl("txt" + action_section + "HotKey");
				actiondata.type = ActionType.NEW;
				actiondata.mode = (radioButton.Checked ? ActionMode.FIXED : ActionMode.TIMER);
				actiondata.UseFilter = !radioButton2.Checked;
				actiondata.StopWhenDone = checkBox.Checked;
				actiondata.UseHotKey = checkBox2.Checked;
				actiondata.Active = checkBox3.Checked;
				actiondata.fixedValue = ((textBox.Text.Trim().Length == 0) ? -1 : App.StringToInt32(textBox.Text.Trim()));
				actiondata.timerSec = ((textBox2.Text.Trim().Length == 0) ? -1 : App.StringToInt32(textBox2.Text.Trim()));
				actiondata.timerQt = ((textBox3.Text.Trim().Length == 0) ? -1 : App.StringToInt32(textBox3.Text.Trim()));
				actiondata.timerMax = ((textBox4.Text.Trim().Length == 0) ? -1 : App.StringToInt32(textBox4.Text.Trim()));
				actiondata.hotKey = textBox5.Text;
				BindingSource bindingSource = (BindingSource)arg_2AD_0.DataSource;
				if (bindingSource != null & bindingSource.DataSource != null)
				{
					actiondata.filterList = (BList<itemdata>)bindingSource.DataSource;
				}
				else
				{
					actiondata.filterList = null;
				}
			}
			else if (Array.IndexOf<string>(App.EXTENDED_ACTION_SECTIONS, action_section) > -1)
			{
				CheckBox checkBox4 = (CheckBox)this.findControl("chk" + action_section + "Set");
				CheckBox checkBox5 = (CheckBox)this.findControl("chk" + action_section + "UseHotkey");
				TextBox textBox6 = (TextBox)this.findControl("txt" + action_section + "HotKey");
				RadioButton optionUnbreakableNoFilter = this.frmMain.optionUnbreakableNoFilter;
				RadioButton arg_36E_0 = this.frmMain.optionUnbreakableFilterList;
				ListControl arg_3E3_0 = this.frmMain.lstUnbreakableFilter;
				actiondata.UseFilter = !optionUnbreakableNoFilter.Checked;
				actiondata.type = ActionType.NEW;
				actiondata.mode = ActionMode.FIXED;
				actiondata.section = action_section;
				actiondata.Active = (checkBox4 != null && checkBox4.Checked);
				actiondata.UseHotKey = checkBox5.Checked;
				actiondata.hotKey = textBox6.Text;
				actiondata.fixedValue = 0;
				BindingSource bindingSource2 = (BindingSource)arg_3E3_0.DataSource;
				if (bindingSource2 != null & bindingSource2.DataSource != null)
				{
					actiondata.filterList = (BList<itemdata>)bindingSource2.DataSource;
				}
				else
				{
					actiondata.filterList = null;
				}
			}
			return actiondata;
		}

		public void updateUiFromActionData(actiondata ad)
		{
			if (ad == null)
			{
				return;
			}
			if (ad.section == "")
			{
				return;
			}
			if (Array.IndexOf<string>(App.ACTION_SECTIONS, ad.section) > -1)
			{
				RadioButton radioButton = (RadioButton)this.findControl("option" + ad.section + "Fixed");
				RadioButton radioButton2 = (RadioButton)this.findControl("option" + ad.section + "Timer");
				RadioButton radioButton3 = (RadioButton)this.findControl("option" + ad.section + "NoFilter");
				RadioButton radioButton4 = (RadioButton)this.findControl("option" + ad.section + "FilterList");
				ListBox listBox = (ListBox)this.findControl("lst" + ad.section + "Filter");
				CheckBox checkBox = (CheckBox)this.findControl("chk" + ad.section + "DisableWhenDone");
				CheckBox checkBox2 = (CheckBox)this.findControl("chk" + ad.section + "UseHotkey");
				CheckBox arg_2FF_0 = (CheckBox)this.findControl("chk" + ad.section + "ActiveInactive");
				Control arg_281_0 = (TextBox)this.findControl("txt" + ad.section + "Fixed");
				TextBox textBox = (TextBox)this.findControl("txt" + ad.section + "Timer");
				TextBox textBox2 = (TextBox)this.findControl("txt" + ad.section + "Quantity");
				TextBox textBox3 = (TextBox)this.findControl("txt" + ad.section + "Max");
				TextBox textBox4 = (TextBox)this.findControl("txt" + ad.section + "HotKey");
				radioButton.Checked = (ad.mode == ActionMode.FIXED);
				radioButton2.Checked = (ad.mode == ActionMode.TIMER);
				radioButton3.Checked = !ad.UseFilter;
				radioButton4.Checked = ad.UseFilter;
				BindingSource bindingSource = (BindingSource)listBox.DataSource;
				if (bindingSource != null)
				{
					bindingSource.DataSource = ad.filterList;
				}
				else
				{
					listBox.DataSource = this.CreateBindingSource<itemdata>(ad.filterList);
				}
				checkBox.Checked = ad.StopWhenDone;
				checkBox2.Checked = ad.UseHotKey;
				arg_281_0.Text = ((ad.fixedValue >= 0) ? ad.fixedValue.ToString() : "");
				textBox.Text = ((ad.timerSec > 0) ? ad.timerSec.ToString() : "");
				textBox2.Text = ((ad.timerQt > 0) ? ad.timerQt.ToString() : "");
				textBox3.Text = ((ad.timerMax > 0) ? ad.timerMax.ToString() : "");
				textBox4.Text = ad.hotKey;
				arg_2FF_0.Checked = ad.Active;
				return;
			}
			if (Array.IndexOf<string>(App.EXTENDED_ACTION_SECTIONS, ad.section) > -1)
			{
				CheckBox checkBox3 = (CheckBox)this.findControl("chk" + ad.section + "Set");
				CheckBox arg_402_0 = (CheckBox)this.findControl("chk" + ad.section + "UseHotkey");
				Control arg_3F7_0 = (TextBox)this.findControl("txt" + ad.section + "HotKey");
				ListBox lstUnbreakableFilter = this.frmMain.lstUnbreakableFilter;
				RadioButton arg_3AB_0 = this.frmMain.optionUnbreakableNoFilter;
				RadioButton optionUnbreakableFilterList = this.frmMain.optionUnbreakableFilterList;
				arg_3AB_0.Checked = !ad.UseFilter;
				optionUnbreakableFilterList.Checked = ad.UseFilter;
				BindingSource bindingSource2 = (BindingSource)lstUnbreakableFilter.DataSource;
				if (bindingSource2 != null)
				{
					bindingSource2.DataSource = ad.filterList;
				}
				else
				{
					lstUnbreakableFilter.DataSource = this.CreateBindingSource<itemdata>(ad.filterList);
				}
				arg_3F7_0.Text = ad.hotKey;
				arg_402_0.Checked = ad.UseHotKey;
				if (checkBox3 != null)
				{
					checkBox3.Checked = ad.Active;
				}
			}
		}

		public void updateCurrentAction()
		{
			if (!this.FlagEvent_1)
			{
				return;
			}
			actiondata actiondata = (actiondata)this.frmMain.lstActionsRegistered.SelectedItem;
			if (actiondata != null)
			{
				actiondata.type = (ActionType)this.frmMain.cbActionsList.SelectedIndex;
				actiondata.mode = (this.frmMain.optionActionsFixed.Checked ? ActionMode.FIXED : ActionMode.TIMER);
				actiondata.fixedValue = ((this.frmMain.txtActionsFixed.Text.Length > 0) ? App.StringToInt32(this.frmMain.txtActionsFixed.Text) : actiondata.fixedValue);
				actiondata.timerSec = ((this.frmMain.txtActionsTimer.Text.Length > 0) ? App.StringToInt32(this.frmMain.txtActionsTimer.Text) : actiondata.timerSec);
				actiondata.timerQt = ((this.frmMain.txtActionsQuantity.Text.Length > 0) ? App.StringToInt32(this.frmMain.txtActionsQuantity.Text) : actiondata.timerQt);
				actiondata.timerMax = ((this.frmMain.txtActionsMax.Text.Length > 0) ? App.StringToInt32(this.frmMain.txtActionsMax.Text) : actiondata.timerMax);
				actiondata.hotKey = ((this.frmMain.txtActionsHotKey.Text.Length > 0) ? this.frmMain.txtActionsHotKey.Text : "");
				actiondata.UseHotKey = this.frmMain.chkActionsUseHotkey.Checked;
				actiondata.StopWhenDone = this.frmMain.chkActionsDisableWhenDone.Checked;
				actiondata.Active = this.frmMain.chkActionsActiveInactive.Checked;
				actiondata.UseFilter = this.frmMain.optionActionsFilterList.Checked;
			}
		}

		public void updateActionsSelected()
		{
			actiondata actiondata = (actiondata)this.frmMain.lstActionsRegistered.SelectedItem;
			if (this.frmMain.lstActionsRegistered.Items.Count == 0)
			{
				this.EnableControl("gbActionsSettings", false);
				this.EnableControl("gbActionsFilter", false);
				foreach (Control current in this.getControls(this.findControl("gbActionsSettings")))
				{
					if (current.GetType() == typeof(TextBox))
					{
						((TextBox)current).Clear();
					}
					if (current.GetType() == typeof(ComboBox))
					{
						((ComboBox)current).Items.Clear();
					}
					if (current.GetType() == typeof(ListBox))
					{
						((ListBox)current).Items.Clear();
					}
					if (current.GetType() == typeof(CheckBox))
					{
						((CheckBox)current).Checked = false;
					}
				}
				using (List<Control>.Enumerator enumerator = this.getControls(this.findControl("gbActionsFilter")).GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						Control current2 = enumerator.Current;
						if (current2.GetType() == typeof(TextBox))
						{
							((TextBox)current2).Clear();
						}
						if (current2.GetType() == typeof(ComboBox))
						{
							((ComboBox)current2).Items.Clear();
						}
						if (current2.GetType() == typeof(ListBox))
						{
							((ListBox)current2).DataSource = null;
						}
						if (current2.GetType() == typeof(ListBox))
						{
							((ListBox)current2).Items.Clear();
						}
						if (current2.GetType() == typeof(CheckBox))
						{
							((CheckBox)current2).Checked = false;
						}
					}
					return;
				}
			}
			if (actiondata != null)
			{
				this.EnableControl("gbActionsSettings", true);
				this.EnableControl("gbActionsFilter", true);
				if (this.frmMain.cbActionsList.Items.Count == 0)
				{
					foreach (ActionType actionType in Enum.GetValues(typeof(ActionType)))
					{
						this.frmMain.cbActionsList.Items.Add(actiondata.ACTIONTYPESTRING[(int)actionType]);
					}
				}
				this.frmMain.cbActionsList.SelectedIndex = (int)actiondata.type;
				this.frmMain.optionActionsFixed.Checked = (actiondata.mode == ActionMode.FIXED);
				this.frmMain.optionActionsTimer.Checked = (actiondata.mode == ActionMode.TIMER);
				this.frmMain.optionActionsNoFilter.Checked = !actiondata.UseFilter;
				this.frmMain.optionActionsFilterList.Checked = actiondata.UseFilter;
				this.SetTextBoxText(this.frmMain.txtActionsFixed, (actiondata.fixedValue >= 0) ? actiondata.fixedValue.ToString() : "");
				this.SetTextBoxText(this.frmMain.txtActionsTimer, (actiondata.timerSec >= 0) ? actiondata.timerSec.ToString() : "");
				this.SetTextBoxText(this.frmMain.txtActionsQuantity, (actiondata.timerQt >= 0) ? actiondata.timerQt.ToString() : "");
				this.SetTextBoxText(this.frmMain.txtActionsMax, (actiondata.timerMax >= 0) ? actiondata.timerMax.ToString() : "");
				this.frmMain.chkActionsActiveInactive.Checked = actiondata.Active;
				this.frmMain.chkActionsDisableWhenDone.Checked = actiondata.StopWhenDone;
				this.frmMain.chkActionsUseHotkey.Checked = actiondata.UseHotKey;
				this.SetTextBoxText(this.frmMain.txtActionsHotKey, actiondata.hotKey);
				this.frmMain.lstActionsFilter.DataSource = this.CreateBindingSource<itemdata>(actiondata.filterList);
			}
		}

		public void SetTextBoxText(TextBox txtBox, string text)
		{
			if (txtBox != null && txtBox.GetType() == typeof(TextBox) && txtBox.Text != text)
			{
				txtBox.Text = text;
			}
		}

		private void lstActionsRegistered_SelectedValueChanged(object sender, EventArgs e)
		{
			this.FlagEvent_1 = false;
			this.updateActionsSelected();
			this.FlagEvent_1 = true;
		}

		private void lstActionsRegistered_SelectedIndexChanged(object sender, EventArgs e)
		{
		}

		private void btnActionsRemove_Click(object sender, EventArgs e)
		{
			actiondata actiondata = (actiondata)this.frmMain.lstActionsRegistered.SelectedItem;
			if (actiondata != null)
			{
				this.customActions.Remove(actiondata);
			}
		}

		private void btnActionsNew_Click(object sender, EventArgs e)
		{
			actiondata actiondata = new actiondata();
			this.customActions.Add(actiondata);
			this.frmMain.lstActionsRegistered.SelectedItem = actiondata;
		}

		private BindingSource CreateBindingSource<T>(BindingList<T> list)
		{
			return new BindingSource
			{
				DataSource = list
			};
		}

		private static string getControlSection(Control ctrl)
		{
			string[] array = Regex.Split(ctrl.Name, "(?<!^)(?=[A-Z])");
			if (array.Length <= 1)
			{
				return "";
			}
			return array[1];
		}

		private static int StringToInt32(string str)
		{
			int result = 0;
			int.TryParse(str.Trim(), out result);
			return result;
		}

		private static uint StringToUInt32(string str)
		{
			uint result = 0u;
			uint.TryParse(str.Trim(), out result);
			return result;
		}

		private static byte StringToByte(string str)
		{
			byte result = 0;
			byte.TryParse(str.Trim(), out result);
			return result;
		}

		private void lst_SelectedIndexChanged(object sender, EventArgs e)
		{
			string controlSection = App.getControlSection((Control)sender);
			if (controlSection != "")
			{
				this.refreshSelectedIndex(controlSection);
			}
		}

		private void lst_DoubleClick(object sender, EventArgs e)
		{
			itemdata itemdata = (itemdata)((ListBox)sender).SelectedItem;
			if (itemdata != null)
			{
				TabPage tabPage = (TabPage)this.frmMain.lstActionsFilter.Parent.Parent;
				if (((TabControl)tabPage.Parent).SelectedTab == tabPage && this.frmMain.lstActionsFilter.Parent.Enabled)
				{
					actiondata actiondata = (actiondata)this.frmMain.lstActionsRegistered.SelectedItem;
					if (actiondata != null)
					{
						using (IEnumerator<itemdata> enumerator = actiondata.filterList.GetEnumerator())
						{
							while (enumerator.MoveNext())
							{
								if (enumerator.Current.itemID == itemdata.itemID)
								{
									return;
								}
							}
						}
						actiondata.filterList.Add(new itemdata(itemdata.itemID));
						BindingSource bindingSource = (BindingSource)this.frmMain.lstActionsFilter.DataSource;
						if (bindingSource != null)
						{
							for (int i = 0; i < bindingSource.Count; i++)
							{
								bindingSource.ResetItem(i);
							}
						}
					}
				}
				ListBox listBox = (ListBox)this.findControl("lstUnbreakableFilter");
				TabPage tabPage2 = (TabPage)listBox.Parent.Parent.Parent;
				if (((TabControl)tabPage2.Parent).SelectedTab == tabPage2)
				{
					BindingSource bindingSource2 = (BindingSource)listBox.DataSource;
					BindingList<itemdata> bindingList = (bindingSource2 != null && bindingSource2.DataSource != null) ? ((BindingList<itemdata>)bindingSource2.DataSource) : null;
					if (bindingList != null)
					{
						using (IEnumerator<itemdata> enumerator = bindingList.GetEnumerator())
						{
							while (enumerator.MoveNext())
							{
								if (enumerator.Current.itemID == itemdata.itemID)
								{
									return;
								}
							}
						}
						bindingList.Add(new itemdata(itemdata.itemID));
						for (int j = 0; j < bindingSource2.Count; j++)
						{
							bindingSource2.ResetItem(j);
						}
					}
				}
				string[] aCTION_SECTIONS = App.ACTION_SECTIONS;
				for (int k = 0; k < aCTION_SECTIONS.Length; k++)
				{
					string str = aCTION_SECTIONS[k];
					ListBox listBox2 = (ListBox)this.findControl("lst" + str + "Filter");
					TabPage tabPage3 = (TabPage)listBox2.Parent.Parent;
					if (((TabControl)tabPage3.Parent).SelectedTab == tabPage3)
					{
						BindingSource bindingSource3 = (BindingSource)listBox2.DataSource;
						BindingList<itemdata> bindingList2 = (bindingSource3 != null && bindingSource3.DataSource != null) ? ((BindingList<itemdata>)bindingSource3.DataSource) : null;
						if (bindingList2 != null)
						{
							using (IEnumerator<itemdata> enumerator = bindingList2.GetEnumerator())
							{
								while (enumerator.MoveNext())
								{
									if (enumerator.Current.itemID == itemdata.itemID)
									{
										return;
									}
								}
							}
							bindingList2.Add(new itemdata(itemdata.itemID));
							for (int l = 0; l < bindingSource3.Count; l++)
							{
								bindingSource3.ResetItem(l);
							}
						}
					}
				}
			}
		}

		private void cbItemName_SelectedIndexChanged(object sender, EventArgs e)
		{
			string controlSection = App.getControlSection((Control)sender);
			if (controlSection != "")
			{
				this.applySelectedIndexItemID(controlSection);
			}
		}

		private void btnItemUpdate_Click(object sender, EventArgs e)
		{
			string controlSection = App.getControlSection((Button)sender);
			if (controlSection != "")
			{
				ListBox listBox = (ListBox)this.findControl("lst" + controlSection);
				if (listBox != null && listBox.SelectedItem != null && listBox.SelectedItem.GetType() == typeof(itemdata))
				{
					itemdata itemdata = (itemdata)listBox.SelectedItem;
					TextBox textBox = (TextBox)this.findControl("txt" + controlSection + "ItemID");
					TextBox textBox2 = (TextBox)this.findControl("txt" + controlSection + "ItemQtDur");
					TextBox textBox3 = (TextBox)this.findControl("txt" + controlSection + "ItemBonusType");
					TextBox textBox4 = (TextBox)this.findControl("txt" + controlSection + "ItemBonusValue");
					ComboBox comboBox = (ComboBox)this.findControl("cb" + controlSection + "ItemBonusType");
					byte[] array = new byte[itemdata.itemID.Length];
					Array.Clear(array, 0, array.Length);
					byte[] bytes = Encoding.ASCII.GetBytes(textBox.Text.Trim());
					this.mem.SetInt32At(itemdata.itemQtDurAddress, App.StringToInt32(textBox2.Text));
					if (textBox3 != null && textBox3.Visible)
					{
						this.mem.SetUInt32At(itemdata.itemBonusTypeAddress, App.StringToUInt32(textBox3.Text));
					}
					else if (comboBox != null && comboBox.Visible)
					{
						Bonus bonus = (Bonus)comboBox.SelectedItem;
						if (bonus.type != Bonus.BonusTypeValue.A_UNKNOWN)
						{
							this.mem.SetUInt32At(itemdata.itemBonusTypeAddress, (uint)bonus.type);
						}
					}
					this.mem.SetInt32At(itemdata.itemBonusValueAddress, App.StringToInt32(textBox4.Text));
					this.mem.SetBytesAt(itemdata.itemAddress + 1L, array, array.Length);
					this.mem.SetBytesAt(itemdata.itemAddress + 1L, bytes, bytes.Length);
					this.mem.SetByteAt(itemdata.itemAddress + 1L + (long)bytes.Length, 0);
					itemdata.itemID = this.mem.GetStringAt(itemdata.itemAddress + 1L);
					this.updateItems(this.items.ToList<itemdata>());
					this.refreshSelectedIndex(controlSection);
				}
			}
		}

		private void btnItemUnlock_Click(object sender, EventArgs e)
		{
			string controlSection = App.getControlSection((Button)sender);
			if (controlSection != "")
			{
				ListBox listBox = (ListBox)this.findControl("lst" + controlSection);
				if (listBox != null && listBox.SelectedItem != null && listBox.SelectedItem.GetType() == typeof(itemdata))
				{
					itemdata itemdata = (itemdata)listBox.SelectedItem;
					TextBox arg_8A_0 = (TextBox)this.findControl("txt" + controlSection + "ItemID");
					TextBox arg_A6_0 = (TextBox)this.findControl("txt" + controlSection + "ItemQtDur");
					TextBox arg_C2_0 = (TextBox)this.findControl("txt" + controlSection + "ItemBonusType");
					TextBox arg_DE_0 = (TextBox)this.findControl("txt" + controlSection + "ItemBonusValue");
					ComboBox comboBox = (ComboBox)this.findControl("cb" + controlSection + "ItemName");
					ComboBox arg_116_0 = (ComboBox)this.findControl("cb" + controlSection + "ItemBonusType");
					this.EnableControl("gb" + controlSection + "Edit", true);
					this.EnableControl("cb" + controlSection + "ItemName", true);
					this.ShowControl("btn" + controlSection + "ItemUnlock", false);
					if (comboBox != null && (!this.InvokeRequired || comboBox.DataSource == null))
					{
						int idIndexInNames = this.getIdIndexInNames(itemdata.itemID, "All");
						if (idIndexInNames < 0)
						{
							comboBox.DataSource = null;
							try
							{
								comboBox.Items.Clear();
								comboBox.Items.Add(itemdata.itemName);
								comboBox.Text = itemdata.itemName;
							}
							catch (Exception)
							{
							}
							comboBox.Enabled = true;
							return;
						}
						comboBox.DataSource = null;
						try
						{
							comboBox.Items.Clear();
							comboBox.DataSource = this.names["All"];
							comboBox.SelectedIndex = idIndexInNames;
						}
						catch (Exception)
						{
						}
						comboBox.Enabled = true;
					}
				}
			}
		}

		public void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			while (!this.worker.CancellationPending && this.uiQueue.Count > 0)
			{
				QueueItem queueItem = this.uiQueue.Dequeue();
				if (queueItem == null)
				{
					return;
				}
				switch (queueItem.byteCode)
				{
				case QueueItemCode.SET_LBL_SCAN:
					try
					{
						this.SetLblScan(queueItem.message);
						continue;
					}
					catch (Exception ex)
					{
						MessageBox.Show("Error SetLblScan: " + ex.Message);
						continue;
					}
					break;
				case QueueItemCode.UPDATE_ITEMS_LISTS:
					goto IL_A6;
				case QueueItemCode.PUTLOG:
					break;
				case QueueItemCode.ENABLE_ITEMS:
				case QueueItemCode.ENABLE_ACTIONS:
					continue;
				case QueueItemCode.UIACTION:
					try
					{
						this.executeUiAction(queueItem);
					}
					catch (Exception ex2)
					{
						MessageBox.Show("Error: " + ex2.Message);
					}
					continue;
				case QueueItemCode.UPDATE_EQUIPPED_LIST:
					if (queueItem.data != null)
					{
						List<itemdata> list = (List<itemdata>)queueItem.data;
						this.updateEquippedItems(list);
						continue;
					}
					continue;
				case QueueItemCode.UPDATE_POSITION:
					this.updatePosition();
					continue;
				case QueueItemCode.UPDATE_TIME:
					this.updateTime();
					continue;
				default:
					continue;
				}
				try
				{
					this.Putlog(queueItem.message);
					continue;
				}
				catch (Exception ex3)
				{
					MessageBox.Show("Error Putlog: " + ex3.Message);
					continue;
				}
				IL_A6:
				if (queueItem.data != null)
				{
					List<itemdata> newItems = (List<itemdata>)queueItem.data;
					this.updateItems(newItems);
				}
			}
		}

		private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
		}

		public void worker_DoWork(object sender, DoWorkEventArgs e)
		{
			while (!this.worker.CancellationPending)
			{
				if (this.nbInternalLoopMs > 0)
				{
					Thread.Sleep(this.nbInternalLoopMs);
				}
				double totalSeconds = DateTime.Now.Subtract(new DateTime(1970, 1, 9, 0, 0, 0)).TotalSeconds;
				if (this.worker.CancellationPending)
				{
					break;
				}
				if (this.frmMain.chkUpdateList.Checked)
				{
					double num = 0.0;
					double.TryParse(this.frmMain.txtTimerUpdateList.Text.Trim(), out num);
					if (totalSeconds - this.timeLastUpdateList >= num)
					{
						this.Putlog("Updating items list from memory...");
						this.FindItemsInMemory(this.items.Count > 0);
						this.timeLastUpdateList = totalSeconds;
						if (this.nbSpacingMs > 0)
						{
							Thread.Sleep(this.nbSpacingMs);
						}
					}
				}
				if (this.worker.CancellationPending)
				{
					break;
				}
				this.updateActionDatas();
				if (!this.worker.CancellationPending)
				{
					if (this.inventoryStartAddress >= 0L)
					{
						if (this.items.Count > 0)
						{
							itemdata itemdata = this.items[0];
							if (this.mem.GetStringAt(itemdata.itemAddress) != "@" + itemdata.itemID)
							{
								this.Putlog("Memory structure change detected. Updating data from memory...");
								this.resetAddresses(false);
								this.FindItemsInMemory(this.items.Count > 0);
								this.timeLastUpdateList = totalSeconds;
								if (this.nbSpacingMs > 0)
								{
									Thread.Sleep(this.nbSpacingMs);
								}
							}
						}
						if (this.worker.CancellationPending)
						{
							break;
						}
						this.updateEquippedItems(this.items.ToList<itemdata>());
						if (this.worker.CancellationPending)
						{
							break;
						}
						this.updatePosition();
						this.updateTime();
						if (!this.worker.CancellationPending)
						{
							string[] array = App.ACTION_SECTIONS;
							for (int i = 0; i < array.Length; i++)
							{
								string key = array[i];
								if (this.worker.CancellationPending)
								{
									break;
								}
								if (this.listActions.ContainsKey(key))
								{
									actiondata actiondata = (actiondata)this.listActions[key];
									if (actiondata != null)
									{
										this.executeActionData(actiondata, false);
										if (this.nbSpacingMs > 0)
										{
											Thread.Sleep(this.nbSpacingMs);
										}
									}
								}
							}
							array = App.EXTENDED_ACTION_SECTIONS;
							for (int i = 0; i < array.Length; i++)
							{
								string key2 = array[i];
								if (this.worker.CancellationPending)
								{
									break;
								}
								if (this.listActions.ContainsKey(key2))
								{
									actiondata actiondata2 = (actiondata)this.listActions[key2];
									if (actiondata2 != null)
									{
										this.executeActionData(actiondata2, false);
										if (this.nbSpacingMs > 0)
										{
											Thread.Sleep(this.nbSpacingMs);
										}
									}
								}
							}
							using (IEnumerator<actiondata> enumerator = this.customActions.GetEnumerator())
							{
								while (enumerator.MoveNext())
								{
									actiondata current = enumerator.Current;
									if (this.worker.CancellationPending)
									{
										break;
									}
									if (current != null)
									{
										this.executeActionData(current, false);
										if (this.nbSpacingMs > 0)
										{
											Thread.Sleep(this.nbSpacingMs);
										}
									}
								}
								goto IL_323;
							}
							goto IL_317;
						}
						break;
					}
					IL_323:
					if (!this.worker.CancellationPending)
					{
						if (this.uiQueue.Count > 0)
						{
							goto IL_317;
						}
					}
					while (!this.worker.CancellationPending && this.workingQueue.Count > 0)
					{
						QueueItemCode byteCode = this.workingQueue.Dequeue().byteCode;
						if (byteCode == QueueItemCode.REQUEST_SCAN)
						{
							this.FindItemsInMemory(false);
						}
					}
					continue;
					IL_317:
					this.worker.ReportProgress(0);
					goto IL_323;
				}
				break;
			}
			e.Cancel = true;
			bool arg_39B_0 = this.worker.CancellationPending;
		}

		public void requestMemoryScan()
		{
			this.workingQueue.Enqueue(new QueueItem(QueueItemCode.REQUEST_SCAN, "", null, false, "", "", null));
		}

		public void executeUiAction(QueueItem q)
		{
			QueueItemCode byteCode = q.byteCode;
			if (byteCode == QueueItemCode.UIACTION)
			{
				string message = q.message;
				if (message == "ENABLE_CONTROL")
				{
					this.EnableControl(q.type, q.status);
					return;
				}
				if (message == "CHECK_CONTROL")
				{
					this.CheckControl(q.type, q.status);
					return;
				}
				if (message == "SHOW_CONTROL")
				{
					this.ShowControl(q.type, q.status);
					return;
				}
				if (message == "TEXT_CONTROL")
				{
					this.TextControl(q.type, (string)q.data);
					return;
				}
				if (!(message == "REFRESH_SELECTED_INDEX"))
				{
					return;
				}
				this.refreshSelectedIndex(q.type);
			}
		}

		public void SetLblScan(string what)
		{
			if (this.InvokeRequired)
			{
				this.uiQueue.Enqueue(new QueueItem(QueueItemCode.SET_LBL_SCAN, what, null, false, "", "", null));
				this.worker.ReportProgress(0);
				return;
			}
			this.frmMain.SetLblScan(what);
			this.Putlog(what);
		}

		public void Putlog(string what)
		{
			if (this.InvokeRequired)
			{
				this.uiQueue.Enqueue(new QueueItem(QueueItemCode.PUTLOG, what, null, false, "", "", null));
				this.worker.ReportProgress(0);
				return;
			}
			this.frmMain.Putlog(what);
		}

		public void TextControl(string what, string text)
		{
			Control control = this.findControl(what);
			if (control == null || (control != null && control.Text == text))
			{
				return;
			}
			if (this.InvokeRequired)
			{
				this.uiQueue.Enqueue(new QueueItem(QueueItemCode.UIACTION, "TEXT_CONTROL", text, false, what, "", null));
				this.worker.ReportProgress(0);
				return;
			}
			if (control != null)
			{
				control.Text = text;
			}
		}

		public void EnableControl(string what, bool enabled)
		{
			if (this.InvokeRequired)
			{
				this.uiQueue.Enqueue(new QueueItem(QueueItemCode.UIACTION, "ENABLE_CONTROL", null, enabled, what, "", null));
				this.worker.ReportProgress(0);
				return;
			}
			Control control = this.findControl(what);
			if (control != null)
			{
				control.Enabled = enabled;
			}
		}

		public void ShowControl(string what, bool visible)
		{
			if (this.InvokeRequired)
			{
				this.uiQueue.Enqueue(new QueueItem(QueueItemCode.UIACTION, "SHOW_CONTROL", null, visible, what, "", null));
				this.worker.ReportProgress(0);
				return;
			}
			Control control = this.findControl(what);
			if (control != null)
			{
				control.Visible = visible;
			}
		}

		public void CheckControl(string what, bool value)
		{
			if (this.InvokeRequired)
			{
				this.uiQueue.Enqueue(new QueueItem(QueueItemCode.UIACTION, "CHECK_CONTROL", null, value, what, "", null));
				this.worker.ReportProgress(0);
				return;
			}
			Control control = this.findControl(what);
			if (control == null)
			{
				return;
			}
			if (control.GetType() == typeof(CheckBox))
			{
				((CheckBox)control).Checked = value;
				return;
			}
			if (control.GetType() == typeof(RadioButton))
			{
				((RadioButton)control).Checked = value;
			}
		}

		public itemdata findItemByAddr(long addr, List<itemdata> list)
		{
			itemdata result = null;
			foreach (itemdata current in list)
			{
				if (current.itemAddress == addr)
				{
					result = current;
					break;
				}
			}
			return result;
		}

		public itemdata findItemByID(string ID, List<itemdata> list)
		{
			itemdata result = null;
			foreach (itemdata current in list)
			{
				if (current.itemID == ID)
				{
					result = current;
					break;
				}
			}
			return result;
		}

		public void setTime(int value)
		{
			if (this.InvokeRequired)
			{
				return;
			}
			if (this.staminaAddress > 0L || this.speedHackAddress > 0L)
			{
				long num = (this.staminaAddress > 0L) ? (this.staminaAddress + 2L) : (this.speedHackAddress - 22565198L + 2L);
				long address = num + 1567901152L;
				float singleAt = this.mem.GetSingleAt(address);
				if (singleAt <= 0f || singleAt > 360f)
				{
					address = num + 1581909472L;
					singleAt = this.mem.GetSingleAt(address);
				}
				if (singleAt <= 0f || singleAt > 360f)
				{
					return;
				}
				float newValue = Convert.ToSingle(value);
				this.mem.SetSingleAt(address, newValue);
			}
		}

		public void updateTime()
		{
			if (this.staminaAddress > 0L || this.speedHackAddress > 0L)
			{
				if (this.InvokeRequired)
				{
					this.uiQueue.Enqueue(new QueueItem(QueueItemCode.UPDATE_TIME, "", null, false, "", "", null));
					this.worker.ReportProgress(0);
					return;
				}
				long num = (this.staminaAddress > 0L) ? (this.staminaAddress + 2L) : (this.speedHackAddress - 22565198L + 2L);
				long address = num + 1567901152L;
				float singleAt = this.mem.GetSingleAt(address);
				if (singleAt <= 0f || singleAt > 360f)
				{
					address = num + 1581909472L;
					singleAt = this.mem.GetSingleAt(address);
				}
				if (singleAt <= 0f || singleAt > 360f)
				{
					return;
				}
				this.frmMain.trackTime.Tag = this;
				this.frmMain.trackTime.Value = (int)Math.Truncate((double)singleAt);
				this.frmMain.trackTime.Tag = null;
			}
		}

		public void updatePosition()
		{
			if (this.coordinatesAddress > 0L)
			{
				if (this.InvokeRequired)
				{
					this.uiQueue.Enqueue(new QueueItem(QueueItemCode.UPDATE_POSITION, "", null, false, "", "", null));
					this.worker.ReportProgress(0);
					return;
				}
				if (((Button)this.findControl("btnPositionEdit")).Text == "Edit")
				{
					float singleAt = this.mem.GetSingleAt(this.coordinatesAddress);
					float singleAt2 = this.mem.GetSingleAt(this.coordinatesAddress + 4L);
					float singleAt3 = this.mem.GetSingleAt(this.coordinatesAddress + 8L);
					this.TextControl("txtPositionX", singleAt.ToString());
					this.TextControl("txtPositionY", singleAt2.ToString());
					this.TextControl("txtPositionZ", singleAt3.ToString());
				}
			}
		}

		public void updateEquippedItems(List<itemdata> items)
		{
			if (this.InvokeRequired)
			{
				this.uiQueue.Enqueue(new QueueItem(QueueItemCode.UPDATE_EQUIPPED_LIST, "", items, false, "", "", null));
				this.worker.ReportProgress(0);
				return;
			}
			foreach (itemdata current in items)
			{
				if (current.isWeaponBowShield)
				{
					if (this.mem.GetByteAt(current.itemEquippedFlagAddress) == 1)
					{
						if (!this.equipped.Contains(current))
						{
							if (current.isShield)
							{
								this.equippedShieldDurabilityAddress = -1L;
							}
							else if (current.isBow)
							{
								this.equippedBowDurabilityAddress = -1L;
							}
							else
							{
								this.equippedWeaponDurabilityAddress = -1L;
							}
							this.equipped.Add(current);
						}
					}
					else if (this.equipped.Contains(current))
					{
						if (current.isShield)
						{
							this.equippedShieldDurabilityAddress = -1L;
						}
						else if (current.isBow)
						{
							this.equippedBowDurabilityAddress = -1L;
						}
						else
						{
							this.equippedWeaponDurabilityAddress = -1L;
						}
						this.equipped.Remove(current);
					}
				}
			}
		}

		public void updateItems(List<itemdata> newItems)
		{
			if (this.InvokeRequired)
			{
				this.uiQueue.Enqueue(new QueueItem(QueueItemCode.UPDATE_ITEMS_LISTS, "", newItems, false, "", "", null));
				this.worker.ReportProgress(0);
				return;
			}
			if (newItems.Count > 0)
			{
				this.EnableControl("tabItems", true);
			}
			else
			{
				this.EnableControl("tabItems", false);
			}
			if (this.itemNames.Count > 0)
			{
				foreach (KeyValuePair<string, List<itemname>> current in this.names)
				{
					if (current.Value.Count <= 0)
					{
						foreach (KeyValuePair<string, string> current2 in this.itemNames)
						{
							string key = current.Key;
							uint num = <PrivateImplementationDetails>.ComputeStringHash(key);
							if (num <= 2689875649u)
							{
								if (num <= 1849229205u)
								{
									if (num != 1456985430u)
									{
										if (num == 1849229205u)
										{
											if (!(key == "Other"))
											{
											}
										}
									}
									else if (key == "Weapons")
									{
										if (current2.Key.StartsWith("Weapon_", true, null) && !current2.Key.StartsWith("Weapon_Bow_", true, null) && !current2.Key.StartsWith("Weapon_Shield_", true, null))
										{
											current.Value.Add(new itemname(current2.Key, current2.Value));
										}
									}
								}
								else if (num != 1974461284u)
								{
									if (num == 2689875649u)
									{
										if (key == "Archery")
										{
											if (current2.Key.StartsWith("Weapon_Bow_", true, null) || (current2.Key.Contains("Arrow") && !current2.Key.StartsWith("Obj_", true, null)))
											{
												current.Value.Add(new itemname(current2.Key, current2.Value));
											}
										}
									}
								}
								else if (key == "All")
								{
									current.Value.Add(new itemname(current2.Key, current2.Value));
								}
							}
							else if (num <= 3369262303u)
							{
								if (num != 3179069417u)
								{
									if (num == 3369262303u)
									{
										if (key == "Inventory")
										{
											if (current2.Key.StartsWith("Item_", true, null) || current2.Key.StartsWith("Weapon_", true, null) || current2.Key.StartsWith("Armor_", true, null) || (current2.Key.Contains("Arrow") && !current2.Key.StartsWith("Obj", true, null)) || current2.Key.StartsWith("Animal_Insect_", true, null))
											{
												current.Value.Add(new itemname(current2.Key, current2.Value));
											}
										}
									}
								}
								else if (key == "Food")
								{
									if (current2.Key.StartsWith("Item_Cook_", true, null) || current2.Key.StartsWith("Item_Roast", true, null))
									{
										current.Value.Add(new itemname(current2.Key, current2.Value));
									}
								}
							}
							else if (num != 3553418121u)
							{
								if (num != 4111359493u)
								{
									if (num == 4152021657u)
									{
										if (key == "Shields")
										{
											if (current2.Key.StartsWith("Weapon_Shield_", true, null))
											{
												current.Value.Add(new itemname(current2.Key, current2.Value));
											}
										}
									}
								}
								else if (key == "Armors")
								{
									if (current2.Key.StartsWith("Armor_", true, null))
									{
										current.Value.Add(new itemname(current2.Key, current2.Value));
									}
								}
							}
							else if (key == "Materials")
							{
								if ((current2.Key.StartsWith("Item_", true, null) && !current2.Key.StartsWith("Item_Cook_", true, null) && !current2.Key.StartsWith("Item_Roast", true, null)) || current2.Key.StartsWith("Animal_", true, null) || current2.Key.Contains("BeeHome") || current2.Key.Contains("Obj_FireWoodBundle"))
								{
									current.Value.Add(new itemname(current2.Key, current2.Value));
								}
							}
						}
						List<itemname> arg_555_0 = current.Value;
						Comparison<itemname> arg_555_1;
						if ((arg_555_1 = App.<>c.<>9__129_0) == null)
						{
							arg_555_1 = (App.<>c.<>9__129_0 = new Comparison<itemname>(App.<>c.<>9.<updateItems>b__129_0));
						}
						arg_555_0.Sort(arg_555_1);
						List<itemname> arg_580_0 = current.Value;
						Comparison<itemname> arg_580_1;
						if ((arg_580_1 = App.<>c.<>9__129_1) == null)
						{
							arg_580_1 = (App.<>c.<>9__129_1 = new Comparison<itemname>(App.<>c.<>9.<updateItems>b__129_1));
						}
						arg_580_0.Sort(arg_580_1);
					}
				}
			}
			List<itemdata> list = new List<itemdata>();
			List<itemdata> list2 = new List<itemdata>();
			foreach (itemdata current3 in this.items)
			{
				itemdata itemdata = this.findItemByAddr(current3.itemAddress, newItems);
				if (itemdata == null)
				{
					list.Add(current3);
				}
				else if (current3.itemID != itemdata.itemID)
				{
					list.Add(current3);
				}
				else
				{
					list2.Add(current3);
				}
			}
			foreach (itemdata current4 in list)
			{
				foreach (KeyValuePair<string, BindingList<itemdata>> current5 in this.lists)
				{
					if (current5.Value.Contains(current4))
					{
						current5.Value.Remove(current4);
					}
				}
			}
			List<itemdata> list3 = this.items.ToList<itemdata>();
			foreach (itemdata current6 in newItems)
			{
				if (this.findItemByAddr(current6.itemAddress, list3) == null)
				{
					foreach (KeyValuePair<string, BindingList<itemdata>> current7 in this.lists)
					{
						string key = current7.Key;
						uint num = <PrivateImplementationDetails>.ComputeStringHash(key);
						if (num <= 3179069417u)
						{
							if (num <= 1849229205u)
							{
								if (num != 1456985430u)
								{
									if (num == 1849229205u)
									{
										if (key == "Other")
										{
											if (!current6.itemID.StartsWith("Weapon_", true, null) && !current6.itemID.StartsWith("Armor_", true, null) && !current6.itemID.StartsWith("Item_", true, null) && !current6.itemID.StartsWith("Animal_", true, null) && !current6.itemID.Contains("Arrow") && !current6.itemID.Contains("BeeHome") && !current6.itemID.Contains("Obj_FireWoodBundle"))
											{
												current7.Value.Add(current6);
											}
										}
									}
								}
								else if (key == "Weapons")
								{
									if (current6.itemID.StartsWith("Weapon_", true, null) && !current6.itemID.StartsWith("Weapon_Bow_", true, null) && !current6.itemID.StartsWith("Weapon_Shield_", true, null))
									{
										current7.Value.Add(current6);
									}
								}
							}
							else if (num != 2689875649u)
							{
								if (num == 3179069417u)
								{
									if (key == "Food")
									{
										if (current6.itemID.StartsWith("Item_Cook_", true, null) || current6.itemID.StartsWith("Item_Roast", true, null))
										{
											current7.Value.Add(current6);
										}
									}
								}
							}
							else if (key == "Archery")
							{
								if (current6.itemID.StartsWith("Weapon_Bow_", true, null) || (current6.itemID.Contains("Arrow") && !current6.itemID.StartsWith("Obj_", true, null)))
								{
									current7.Value.Add(current6);
								}
							}
						}
						else if (num <= 3553418121u)
						{
							if (num != 3369262303u)
							{
								if (num == 3553418121u)
								{
									if (key == "Materials")
									{
										if ((current6.itemID.StartsWith("Item_", true, null) && !current6.itemID.StartsWith("Item_Cook_", true, null) && !current6.itemID.StartsWith("Item_Roast", true, null)) || current6.itemID.StartsWith("Animal_", true, null) || current6.itemID.Contains("BeeHome") || current6.itemID.Contains("Obj_FireWoodBundle"))
										{
											current7.Value.Add(current6);
										}
									}
								}
							}
							else if (key == "Inventory")
							{
								current7.Value.Add(current6);
							}
						}
						else if (num != 4111359493u)
						{
							if (num == 4152021657u)
							{
								if (key == "Shields")
								{
									if (current6.itemID.StartsWith("Weapon_Shield_", true, null))
									{
										current7.Value.Add(current6);
									}
								}
							}
						}
						else if (key == "Armors")
						{
							if (current6.itemID.StartsWith("Armor_", true, null))
							{
								current7.Value.Add(current6);
							}
						}
					}
				}
			}
			foreach (KeyValuePair<string, BindingSource> current8 in this.sources)
			{
				for (int i = 0; i < current8.Value.Count; i++)
				{
					current8.Value.ResetItem(i);
				}
			}
		}

		public int getIdIndexInNames(string key, string section)
		{
			int result = -1;
			int num = 0;
			if (this.names.ContainsKey(section))
			{
				using (List<itemname>.Enumerator enumerator = this.names[section].GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						if (enumerator.Current.itemID == key)
						{
							result = num;
							break;
						}
						num++;
					}
				}
			}
			return result;
		}

		public List<Control> getControls(Control parent = null)
		{
			List<Control> list = new List<Control>();
			parent = ((parent == null) ? this.frmMain : parent);
			if (parent != null)
			{
				foreach (Control control in parent.Controls)
				{
					list.Add(control);
					list.AddRange(this.getControls(control));
				}
			}
			return list;
		}

		public Control findControl(string name)
		{
			Control result = null;
			foreach (Control current in this.getControls(null))
			{
				if (current.Name == name)
				{
					result = current;
					break;
				}
			}
			return result;
		}

		public void applySelectedIndexItemID(string section)
		{
			ComboBox comboBox = (ComboBox)this.findControl("cb" + section + "ItemName");
			TextBox textBox = (TextBox)this.findControl("txt" + section + "ItemID");
			if (comboBox != null && textBox != null && comboBox.SelectedItem != null && comboBox.SelectedItem.GetType() == typeof(itemname))
			{
				itemname itemname = (itemname)comboBox.SelectedItem;
				if (itemname != null)
				{
					textBox.Text = itemname.itemID;
				}
			}
		}

		public void refreshSelectedIndex(string section)
		{
			if (this.InvokeRequired)
			{
				this.uiQueue.Enqueue(new QueueItem(QueueItemCode.UIACTION, "REFRESH_SELECTED_INDEX", null, false, section, "", null));
				this.worker.ReportProgress(0);
				return;
			}
			this.ShowControl("btn" + section + "ItemUnlock", false);
			ListBox listBox = (ListBox)this.findControl("lst" + section);
			if (listBox == null)
			{
				return;
			}
			itemdata itemdata = (itemdata)listBox.SelectedItem;
			if (itemdata == null)
			{
				return;
			}
			TextBox textBox = (TextBox)this.findControl("txt" + section + "ItemID");
			TextBox textBox2 = (TextBox)this.findControl("txt" + section + "ItemQtDur");
			TextBox textBox3 = (TextBox)this.findControl("txt" + section + "ItemBonusType");
			TextBox textBox4 = (TextBox)this.findControl("txt" + section + "ItemBonusValue");
			ComboBox comboBox = (ComboBox)this.findControl("cb" + section + "ItemName");
			ComboBox comboBox2 = (ComboBox)this.findControl("cb" + section + "ItemBonusType");
			if (textBox != null)
			{
				textBox.Text = itemdata.itemID;
			}
			if (textBox2 != null)
			{
				textBox2.Text = this.mem.GetInt32At(itemdata.itemQtDurAddress).ToString();
			}
			if (textBox3 != null)
			{
				textBox3.Text = this.mem.GetUInt32At(itemdata.itemBonusTypeAddress).ToString();
			}
			if (textBox4 != null)
			{
				textBox4.Text = this.mem.GetInt32At(itemdata.itemBonusValueAddress).ToString();
			}
			if (itemdata.isWeaponBowShield)
			{
				if (textBox3 != null)
				{
					textBox3.Visible = false;
				}
				if (comboBox2 != null)
				{
					comboBox2.Visible = true;
				}
			}
			else
			{
				if (textBox3 != null)
				{
					textBox3.Visible = true;
				}
				if (comboBox2 != null)
				{
					comboBox2.Visible = false;
				}
			}
			if (comboBox2 != null && (!this.InvokeRequired || comboBox.DataSource == null))
			{
				uint uInt32At = this.mem.GetUInt32At(itemdata.itemBonusTypeAddress);
				comboBox2.DataSource = null;
				try
				{
					comboBox2.Items.Clear();
					List<Bonus> bonusList = Bonus.getBonusList();
					comboBox2.DataSource = bonusList;
					foreach (Bonus current in bonusList)
					{
						if (current.Match((long)((ulong)uInt32At)))
						{
							comboBox2.SelectedItem = current;
							break;
						}
					}
				}
				catch (Exception)
				{
				}
			}
			if (comboBox != null && (!this.InvokeRequired || comboBox.DataSource == null))
			{
				int idIndexInNames = this.getIdIndexInNames(itemdata.itemID, section);
				if (idIndexInNames < 0)
				{
					comboBox.DataSource = null;
					try
					{
						comboBox.Items.Clear();
						comboBox.Items.Add(itemdata.itemName);
						comboBox.Text = itemdata.itemName;
					}
					catch (Exception)
					{
					}
					comboBox.Enabled = false;
				}
				else
				{
					comboBox.DataSource = null;
					try
					{
						comboBox.Items.Clear();
						comboBox.DataSource = this.names[section];
						comboBox.SelectedIndex = idIndexInNames;
					}
					catch (Exception)
					{
					}
					comboBox.Enabled = true;
				}
			}
			if (itemdata.isWeaponBowShield && this.mem.GetByteAt(itemdata.itemEquippedFlagAddress) == 1)
			{
				this.EnableControl("gb" + section + "Edit", false);
			}
			else
			{
				this.EnableControl("gb" + section + "Edit", true);
			}
			this.ShowControl("btn" + section + "ItemUnlock", true);
		}

		public void updateItemLists()
		{
		}

		public float GetTxtPositionJumpHeight()
		{
			float result = 0f;
			float.TryParse(this.frmMain.txtPositionJumpHeight.Text, out result);
			return result;
		}

		public void SavePosition()
		{
			if (this.coordinatesAddress > 0L)
			{
				float singleAt = this.mem.GetSingleAt(this.coordinatesAddress);
				float singleAt2 = this.mem.GetSingleAt(this.coordinatesAddress + 4L);
				float singleAt3 = this.mem.GetSingleAt(this.coordinatesAddress + 8L);
				this.savedX = singleAt;
				this.savedY = singleAt2;
				this.savedZ = singleAt3;
				this.Putlog(string.Concat(new string[]
				{
					"Saved position X=",
					singleAt.ToString(),
					" Y=",
					singleAt2.ToString(),
					" Z=",
					singleAt3.ToString()
				}));
			}
		}

		public void RestorePosition()
		{
			if (this.coordinatesAddress > 0L)
			{
				float newValue = this.savedX;
				float newValue2 = this.savedY;
				float newValue3 = this.savedZ;
				this.mem.SetSingleAt(this.coordinatesAddress, newValue);
				this.mem.SetSingleAt(this.coordinatesAddress + 4L, newValue2);
				this.mem.SetSingleAt(this.coordinatesAddress + 8L, newValue3);
				this.Putlog(string.Concat(new string[]
				{
					"Restored position X=",
					newValue.ToString(),
					" Y=",
					newValue2.ToString(),
					" Z=",
					newValue3.ToString()
				}));
			}
		}

		public void JumpPosition()
		{
			if (this.coordinatesAddress > 0L)
			{
				float txtPositionJumpHeight = this.GetTxtPositionJumpHeight();
				float singleAt = this.mem.GetSingleAt(this.coordinatesAddress + 4L);
				float newValue = singleAt + txtPositionJumpHeight;
				this.mem.SetSingleAt(this.coordinatesAddress + 4L, newValue);
				this.Putlog("Jumping from Y=" + singleAt.ToString() + " to Y=" + newValue.ToString());
			}
		}

		public void SwitchEditPosition()
		{
			if (this.coordinatesAddress > 0L)
			{
				Button button = (Button)this.findControl("btnPositionEdit");
				TextBox textBox = (TextBox)this.findControl("txtPositionX");
				TextBox textBox2 = (TextBox)this.findControl("txtPositionY");
				TextBox textBox3 = (TextBox)this.findControl("txtPositionZ");
				if (button != null)
				{
					if (button.Text == "Edit")
					{
						textBox.ReadOnly = false;
						textBox2.ReadOnly = false;
						textBox3.ReadOnly = false;
						button.Text = "Ok";
						return;
					}
					float singleAt = this.mem.GetSingleAt(this.coordinatesAddress);
					float singleAt2 = this.mem.GetSingleAt(this.coordinatesAddress + 4L);
					float singleAt3 = this.mem.GetSingleAt(this.coordinatesAddress + 8L);
					float.TryParse(textBox.Text, out singleAt);
					float.TryParse(textBox2.Text, out singleAt2);
					float.TryParse(textBox3.Text, out singleAt3);
					this.mem.SetSingleAt(this.coordinatesAddress, singleAt);
					this.mem.SetSingleAt(this.coordinatesAddress + 4L, singleAt2);
					this.mem.SetSingleAt(this.coordinatesAddress + 8L, singleAt3);
					textBox.ReadOnly = true;
					textBox2.ReadOnly = true;
					textBox3.ReadOnly = true;
					button.Text = "Edit";
				}
			}
		}

		private void LstCapturedPositions_SelectedIndexChanged(object sender, EventArgs e)
		{
			ListBox listBox = (ListBox)sender;
			if (listBox.Items.Count == 0)
			{
				return;
			}
			CapturedPosition capture = (CapturedPosition)listBox.SelectedItem;
			this.UpdateCapturedPositionDetails(capture);
		}

		private void LstCapturedPositions_DoubleClick(object sender, EventArgs e)
		{
			if (this.getCurrentSelectedCapturePosition() != null)
			{
				this.TPCapturedPosition();
			}
		}

		private void UpdateCapturedPositionDetails(CapturedPosition capture)
		{
			if (capture == null)
			{
				this.frmMain.txtCapturedPositionX.Text = "";
				this.frmMain.txtCapturedPositionY.Text = "";
				this.frmMain.txtCapturedPositionZ.Text = "";
				this.frmMain.txtCapturedPositionName.Text = "";
				return;
			}
			this.frmMain.txtCapturedPositionX.Text = capture.X.ToString();
			this.frmMain.txtCapturedPositionY.Text = capture.Y.ToString();
			this.frmMain.txtCapturedPositionZ.Text = capture.Z.ToString();
			this.frmMain.txtCapturedPositionName.Text = capture.Name;
		}

		private CapturedPosition getCurrentSelectedCapturePosition()
		{
			CapturedPosition result = null;
			ListBox listBox = (ListBox)this.findControl("lstCapturedPositions");
			if (listBox != null && listBox.Items.Count > 0)
			{
				result = (CapturedPosition)listBox.SelectedItem;
			}
			return result;
		}

		public void TPCapturedPosition()
		{
			CapturedPosition currentSelectedCapturePosition = this.getCurrentSelectedCapturePosition();
			if (currentSelectedCapturePosition != null && this.coordinatesAddress > 0L)
			{
				this.Putlog(string.Concat(new string[]
				{
					"Changed position to X=",
					currentSelectedCapturePosition.X.ToString(),
					" Y=",
					currentSelectedCapturePosition.Y.ToString(),
					" Z=",
					currentSelectedCapturePosition.Z.ToString()
				}));
				this.mem.SetSingleAt(this.coordinatesAddress, currentSelectedCapturePosition.X);
				this.mem.SetSingleAt(this.coordinatesAddress + 4L, currentSelectedCapturePosition.Y);
				this.mem.SetSingleAt(this.coordinatesAddress + 8L, currentSelectedCapturePosition.Z);
			}
		}

		public void AddCapturedPosition()
		{
			CapturedPosition capturedPosition = new CapturedPosition();
			float x = 0f;
			float y = 0f;
			float z = 0f;
			string name = "";
			if (this.coordinatesAddress > 0L)
			{
				x = this.mem.GetSingleAt(this.coordinatesAddress);
				y = this.mem.GetSingleAt(this.coordinatesAddress + 4L);
				z = this.mem.GetSingleAt(this.coordinatesAddress + 8L);
			}
			capturedPosition.X = x;
			capturedPosition.Y = y;
			capturedPosition.Z = z;
			capturedPosition.Name = name;
			this.capturedPositions.Add(capturedPosition);
			this.UpdateCapturedPositionDetails(this.getCurrentSelectedCapturePosition());
		}

		public void SaveCapturedPosition()
		{
			CapturedPosition currentSelectedCapturePosition = this.getCurrentSelectedCapturePosition();
			if (currentSelectedCapturePosition != null)
			{
				string text = this.frmMain.txtCapturedPositionName.Text;
				float x;
				float.TryParse(this.frmMain.txtCapturedPositionX.Text, out x);
				float y;
				float.TryParse(this.frmMain.txtCapturedPositionY.Text, out y);
				float z;
				float.TryParse(this.frmMain.txtCapturedPositionZ.Text, out z);
				currentSelectedCapturePosition.X = x;
				currentSelectedCapturePosition.Y = y;
				currentSelectedCapturePosition.Z = z;
				currentSelectedCapturePosition.Name = text;
				try
				{
					this.capturedPositions.ResetItem(this.capturedPositions.IndexOf(currentSelectedCapturePosition));
				}
				catch (Exception)
				{
				}
			}
		}

		public void RemoveCapturedPosition()
		{
			CapturedPosition currentSelectedCapturePosition = this.getCurrentSelectedCapturePosition();
			if (currentSelectedCapturePosition != null)
			{
				this.capturedPositions.Remove(currentSelectedCapturePosition);
			}
		}

		public double GetTxtRunSpeed()
		{
			double result = 1.0;
			double.TryParse(this.frmMain.txtRunSpeed.Text, out result);
			return result;
		}

		public void RefreshTxtRunSpeed()
		{
			if (this.speedHackAddress > 0L)
			{
				float singleAt = this.mem.GetSingleAt(this.speedHackAddress);
				this.TextControl(this.frmMain.txtRunSpeed.Name, singleAt.ToString());
				return;
			}
			this.TextControl(this.frmMain.txtRunSpeed.Name, 1.ToString());
		}

		public void UpdateRunSpeedMultiplier(double multiplier)
		{
			if (this.speedHackAddress > 0L)
			{
				this.mem.SetSingleAt(this.speedHackAddress, Convert.ToSingle(multiplier));
				this.Putlog("Run speed multiplier set to value : x " + multiplier.ToString());
			}
			this.RefreshTxtRunSpeed();
		}

		public uint GetTxtSlot(string what)
		{
			uint result = 0u;
			TextBox textBox = (TextBox)this.findControl("txt" + what + "Slots");
			if (textBox != null)
			{
				uint.TryParse(textBox.Text, out result);
			}
			return result;
		}

		public void RefreshTxtSlot(string what)
		{
			long num = 0L;
			if (what == "Weapons")
			{
				num = this.weaponsSlotsAddress;
			}
			else if (what == "Bows")
			{
				num = this.bowsSlotsAddress;
			}
			else if (what == "Shields")
			{
				num = this.shieldsSlotsAddress;
			}
			if (num > 0L)
			{
				TextBox textBox = (TextBox)this.findControl("txt" + what + "Slots");
				if (textBox != null)
				{
					uint uInt32At = this.mem.GetUInt32At(num);
					this.TextControl(textBox.Name, uInt32At.ToString());
				}
			}
		}

		public void UpdateSlot(string what, uint value)
		{
			long num = 0L;
			long num2 = 0L;
			if (what == "Weapons")
			{
				num = this.weaponsSlotsAddress;
				num2 = this.weaponsSlotsPersistAddress;
			}
			else if (what == "Bows")
			{
				num = this.bowsSlotsAddress;
				num2 = this.bowsSlotsPersistAddress;
			}
			else if (what == "Shields")
			{
				num = this.shieldsSlotsAddress;
				num2 = this.shieldsSlotsPersistAddress;
			}
			if (num > 0L && value >= 0u)
			{
				this.mem.SetUInt32At(num, value);
				this.Putlog("Slot count for " + what + " changed to : " + value.ToString());
				if (num2 > 0L)
				{
					this.mem.SetUInt32At(num2, value);
				}
			}
		}

		public long findWeaponsSlotsAddressInMemory(long startAddress, long endAddress)
		{
			int[] array = new int[]
			{
				1,
				7,
				0,
				0,
				0,
				0,
				0,
				8,
				0,
				0,
				0,
				8,
				0,
				0,
				0,
				20
			};
			long num = (long)array.Length;
			long num2 = this.mem.pagedMemorySearchMatch(array, startAddress, endAddress - startAddress);
			if (num2 >= 0L)
			{
				num2 += num;
			}
			return num2;
		}

		public long findWeaponsSlotsPersistAddressInMemory(long startAddress, long endAddress)
		{
			int[] array = new int[]
			{
				140,
				36,
				149,
				241,
				0,
				0,
				0,
				0,
				140,
				39,
				12,
				86
			};
			long num = (long)array.Length;
			long num2 = this.mem.pagedMemorySearchMatch(array, startAddress, endAddress - startAddress);
			if (num2 >= 0L)
			{
				num2 += num;
			}
			return num2;
		}

		public long findBowsSlotsAddressInMemory(long startAddress, long endAddress)
		{
			int[] array = new int[]
			{
				1,
				7,
				0,
				0,
				0,
				0,
				0,
				5,
				0,
				0,
				0,
				5,
				0,
				0,
				0,
				14
			};
			long num = (long)array.Length;
			long num2 = this.mem.pagedMemorySearchMatch(array, startAddress, endAddress - startAddress);
			if (num2 >= 0L)
			{
				num2 += num;
			}
			return num2;
		}

		public long findBowsSlotsPersistAddressInMemory(long startAddress, long endAddress)
		{
			int[] array = new int[]
			{
				231,
				206,
				8,
				34,
				0,
				0,
				0,
				0,
				231,
				206,
				68,
				83
			};
			long num = (long)array.Length;
			long num2 = this.mem.pagedMemorySearchMatch(array, startAddress, endAddress - startAddress);
			if (num2 >= 0L)
			{
				num2 += num;
			}
			return num2;
		}

		public long findShieldsSlotsAddressInMemory(long startAddress, long endAddress)
		{
			int[] array = new int[]
			{
				1,
				7,
				0,
				0,
				0,
				0,
				0,
				4,
				0,
				0,
				0,
				4,
				0,
				0,
				0,
				20
			};
			long num = (long)array.Length;
			long num2 = this.mem.pagedMemorySearchMatch(array, startAddress, endAddress - startAddress);
			if (num2 >= 0L)
			{
				num2 += num;
			}
			return num2;
		}

		public long findShieldsSlotsPersistAddressInMemory(long startAddress, long endAddress)
		{
			int[] array = new int[]
			{
				47,
				192,
				108,
				95,
				0,
				0,
				0,
				0,
				47,
				192,
				210,
				171
			};
			long num = (long)array.Length;
			long num2 = this.mem.pagedMemorySearchMatch(array, startAddress, endAddress - startAddress);
			if (num2 >= 0L)
			{
				num2 += num;
			}
			return num2;
		}

		public long findSpeedHackAddressInMemory(long startAddress, long endAddress)
		{
			int[] search = new int[]
			{
				66,
				112,
				0,
				0,
				66,
				200,
				0,
				0,
				68,
				122,
				0,
				0
			};
			long num = -8L;
			long num2 = this.mem.pagedMemorySearchMatch(search, startAddress, endAddress - startAddress);
			if (num2 >= 0L)
			{
				num2 += num;
			}
			return num2;
		}

		public long findRupeesAddressInMemory(long startAddress, long endAddress)
		{
			int[] array = new int[]
			{
				16,
				-1,
				-1,
				-1,
				1,
				7,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				15,
				66,
				63
			};
			long num = (long)array.Length;
			long num2 = this.mem.pagedMemorySearchMatch(array, startAddress, endAddress - startAddress);
			if (num2 >= 0L)
			{
				num2 += num;
			}
			return num2;
		}

		public long findPowersAddress(long startAddress, long regionSize)
		{
			byte[] array = new byte[]
			{
				255,
				255,
				255,
				255,
				255,
				255,
				255,
				255,
				0,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				0,
				0,
				0,
				0
			};
			long num = (long)(array.Length + 4);
			long num2;
			while ((num2 = this.mem.pagedMemorySearch(array, startAddress, regionSize)) > 0L)
			{
				if (this.mem.GetInt32At(num2 - 4L) == 0 && (this.mem.GetInt32At(num2 + 20L) == 0 || this.mem.GetInt32At(num2 + 20L) == -1))
				{
					num2 += num;
					break;
				}
				regionSize -= num2 + 20L - startAddress;
				startAddress = num2 + 20L;
			}
			return num2;
		}

		public long findAmiiboDateAddress(long startAddress, long regionSize)
		{
			byte[] array = new byte[]
			{
				1,
				44,
				153,
				133,
				1,
				44,
				153,
				133
			};
			long num = (long)(array.Length + 4);
			long num2 = this.mem.pagedMemorySearch(array, startAddress, regionSize);
			if (num2 >= 0L)
			{
				num2 += num;
			}
			return num2;
		}

		public long findHealthAddress(long startAddress, long regionSize)
		{
			long num = -1L;
			byte[] expr_0A = new byte[12];
			expr_0A[0] = 63;
			expr_0A[1] = 128;
			byte[] array = expr_0A;
			byte[] array2 = new byte[13];
			byte[] sequence = new byte[4];
			int num2 = 223;
			int num3 = 224;
			int num4 = 226;
			int num5 = 199;
			int num6 = 159;
			int num7 = 190;
			int num8 = 206;
			int num9 = 254;
			int num10 = 14;
			int num11 = array.Length;
			int num12 = array2.Length;
			int num13 = num12 + num11;
			bool flag = false;
			long num14 = startAddress;
			long num15 = regionSize;
			long num16 = num14 + num15;
			byte[] array3 = new byte[512];
			while (!flag && num14 < num16)
			{
				num = this.mem.pagedMemorySearch(array, num14, num15);
				if (num > 0L && this.mem.GetBytesAt(num - (long)num12, array3, num13 + 255) > 0)
				{
					byte b = array3[num13];
					byte b2 = array3[num13 + 1];
					if (b != 0 && b2 != 0 && array3[num13 + 8] == b && array3[num13 + 9] == b2 && array3[num13 + 12] == b && array3[num13 + 13] == b2 && array3[num13 + 4] == 0 && array3[num13 + 5] == 0 && (b == 67 || b == 68) && ((int)b2 == num2 || (int)b2 == num3 || (int)b2 == num4 || (int)b2 == num5 || (int)b2 == num6 || (int)b2 == num7 || (int)b2 == num8 || (int)b2 == num9 || (int)b2 == num10 || array3[num13 + 6] != 0 || array3[num13 + 7] != 1) && MemAPI.findSequence(array3, 0, array2, false, false) == 0 && MemAPI.findSequence(array3, num13 + 16, sequence, false, false) == -1)
					{
						num = num + (long)num11 + 4L;
						flag = true;
						break;
					}
				}
				if (num == -1L)
				{
					break;
				}
				num14 = num + (long)num11;
				num15 = num16 - num14;
			}
			if (!flag)
			{
				num = -1L;
			}
			return num;
		}

		public long findStaminaAddress(long startAddress, long regionSize)
		{
			long num = -1L;
			int[] array = new int[]
			{
				-2,
				0,
				0,
				0,
				-2,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				255,
				255,
				255,
				255,
				0,
				0,
				0,
				0,
				-2,
				-2,
				-2,
				-2
			};
			int[] sequence = new int[]
			{
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				66
			};
			int num2 = array.Length;
			long num3 = (long)(num2 + 22);
			bool flag = false;
			long num4 = startAddress;
			long num5 = regionSize;
			long num6 = num4 + num5;
			if (this.speedHackAddress > 0L)
			{
				num = this.speedHackAddress - 22565198L;
				float singleAt = this.mem.GetSingleAt(num + 2L);
				float singleAt2 = this.mem.GetSingleAt(num + 6L);
				if (singleAt != 0f && singleAt2 != 0f && (double)singleAt == Math.Truncate((double)singleAt) && (double)singleAt2 == Math.Truncate((double)singleAt2))
				{
					flag = true;
				}
			}
			byte[] array2 = new byte[512];
			while (!flag && num4 < num6)
			{
				num = this.mem.pagedMemorySearchMatch(array, num4, num5);
				if (checked(num >= 0L && this.mem.GetBytesAt(num, array2, unchecked(num2 + 255)) > 0 && (array2[num2] == 67 || array2[num2] == 66) && (array2[(int)((IntPtr)num3)] == 128 || array2[(int)((IntPtr)num3)] == 0) && (array2[(int)((IntPtr)(unchecked(num3 + 4L)))] == 128 || array2[(int)((IntPtr)(unchecked(num3 + 4L)))] == 0) && (array2[(int)((IntPtr)(unchecked(num3 + 8L)))] == 128 || array2[(int)((IntPtr)(unchecked(num3 + 8L)))] == 0)) && MemAPI.findSequenceMatch(array2, (int)(num3 + 9L), sequence, false, false) == (int)(num3 + 9L))
				{
					num += num3;
					flag = true;
					break;
				}
				if (num == -1L)
				{
					break;
				}
				num4 = num + (long)num2;
				num5 = num6 - num4;
			}
			if (!flag)
			{
				num = -1L;
			}
			return num;
		}

		public long findNoStaminaBarAddress(bool barDisabled = false)
		{
			this.mem.UpdateProcess("");
			MemAPI.MemoryRegion[] arg_2C_0 = this.mem.listProcessMemoryRegions(this.mem.Handle);
			List<MemAPI.MemoryRegion> list = new List<MemAPI.MemoryRegion>();
			MemAPI.MemoryRegion[] array = arg_2C_0;
			for (int i = 0; i < array.Length; i++)
			{
				MemAPI.MemoryRegion memoryRegion = array[i];
				if (memoryRegion.regionSize >= 4194304L)
				{
					list.Add(memoryRegion);
				}
			}
			byte[] array2 = new byte[]
			{
				69,
				15,
				56,
				241,
				116,
				5,
				104,
				139,
				84,
				36,
				8,
				69,
				15,
				56,
				240,
				116,
				21,
				24,
				102,
				65,
				15,
				110,
				198,
				243,
				15,
				90,
				192
			};
			byte[] array3 = new byte[]
			{
				144,
				144,
				144,
				144,
				144,
				144,
				144,
				139,
				84,
				36,
				8,
				69,
				15,
				56,
				240,
				116,
				21,
				24,
				102,
				65,
				15,
				110,
				198,
				243,
				15,
				90,
				192
			};
			return this.mem.pagedMemorySearch(barDisabled ? array3 : array2, list.ToArray());
		}

		public long findCoordinatesAddress(long startAddress, long regionSize)
		{
			int[] search = new int[]
			{
				3,
				1,
				61,
				47,
				206,
				179,
				16,
				-1,
				-1,
				-1,
				255,
				255,
				0,
				1,
				7,
				255
			};
			long num = 102L;
			long num2 = this.mem.pagedMemorySearchMatch(search, startAddress, regionSize);
			if (num2 >= 0L)
			{
				num2 += num;
			}
			return num2;
		}

		public long findEquippedDurabilityAddress(itemdata item)
		{
			long num = -1L;
			long num2;
			long num3;
			if (!this.mem.FindRegionByAddr(this.inventoryStartAddress, out num2, out num3, IntPtr.Zero, true))
			{
				return num;
			}
			byte[] bytes = BitConverter.GetBytes(this.mem.GetInt32At(item.itemQtDurAddress));
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(bytes);
			}
			byte[] expr_4D = new byte[]
			{
				191,
				128,
				0,
				0,
				0,
				0,
				0,
				0,
				255,
				255,
				255,
				255,
				0,
				0,
				0
			};
			expr_4D[4] = bytes[0];
			expr_4D[5] = bytes[1];
			expr_4D[6] = bytes[2];
			expr_4D[7] = bytes[3];
			byte[] array = expr_4D;
			byte[] array2 = new byte[8];
			byte[] sequence = new byte[]
			{
				63,
				128,
				0,
				0,
				63,
				128,
				0,
				0,
				63,
				128,
				0,
				0
			};
			byte[] sequence2 = new byte[]
			{
				0,
				0,
				255,
				255,
				1,
				68
			};
			byte[] sequence3 = new byte[]
			{
				0,
				0,
				255,
				255,
				1,
				69
			};
			byte[] sequence4 = new byte[]
			{
				0,
				0,
				255,
				255,
				1,
				70
			};
			byte[] sequence5 = new byte[]
			{
				0,
				0,
				255,
				255,
				1,
				75
			};
			byte[] sequence6 = new byte[]
			{
				0,
				0,
				255,
				255,
				2,
				75
			};
			byte[] sequence7 = new byte[3];
			byte[] expr_FB = new byte[3];
			expr_FB[1] = 4;
			byte[] sequence8 = expr_FB;
			byte[] sequence9 = new byte[32];
			byte[] sequence10 = new byte[4];
			int num4 = array2.Length;
			int num5 = array.Length;
			int num6 = num4 + num5;
			int num7 = 20;
			bool flag = false;
			long num8 = this.inventoryStartAddress;
			long num9 = num2 + num3;
			long num10 = num9 - num8;
			byte[] array3 = new byte[512];
			while (!flag && num8 < num9 - (long)num5)
			{
				num = this.mem.pagedMemorySearch(array, num8, num10 - (long)num5);
				if (num >= 0L && this.mem.GetBytesAt(num - (long)num4 - (long)num7, array3, num6 + 255) > 0)
				{
					int num11 = num7;
					int num12 = 12;
					int num13 = 14;
					int arg_1B8_0 = (int)array3[num11 + num6];
					byte b = array3[num11 + num13 + 147];
					if (arg_1B8_0 < 3 && (b == 0 || b == 4) && MemAPI.findSequence(array3, num11, array2, false, false) == num11 && MemAPI.findSequence(array3, num11 + num6 + 1 + 4, sequence, false, false) == num11 + num6 + 1 + 4 && (MemAPI.findSequence(array3, num11 + num13 + 147 - 9, sequence2, false, false) >= 0 || MemAPI.findSequence(array3, num11 + num13 + 147 - 9, sequence3, false, false) >= 0 || MemAPI.findSequence(array3, num11 + num13 + 147 - 9, sequence4, false, false) >= 0 || MemAPI.findSequence(array3, num11 + num13 + 147 - 9, sequence5, false, false) >= 0 || MemAPI.findSequence(array3, num11 + num13 + 147 - 9, sequence6, false, false) >= 0) && (MemAPI.findSequence(array3, num11 + num13 + 147 - 1, sequence7, false, false) >= 0 || MemAPI.findSequence(array3, num11 + num13 + 147 - 1, sequence8, false, false) >= 0) && MemAPI.findSequence(array3, num11 + num12 + 80, sequence9, false, false) < 0 && MemAPI.findSequence(array3, num11 + num12 - 32, sequence10, false, false) < 0)
					{
						num += (long)(num12 - num4);
						flag = true;
						break;
					}
				}
				if (num == -1L)
				{
					break;
				}
				num8 = num + (long)num5;
				num10 = num9 - num8;
			}
			if (!flag)
			{
				num = -1L;
			}
			return num;
		}

		public void enableStaminaBar(bool enable = true)
		{
			if (this.inventoryStartAddress == -1L)
			{
				return;
			}
			this.Putlog("Scanning memory...");
			long num = this.findNoStaminaBarAddress(enable);
			byte[] array = new byte[]
			{
				69,
				15,
				56,
				241,
				116,
				5,
				104
			};
			byte[] array2 = new byte[]
			{
				144,
				144,
				144,
				144,
				144,
				144,
				144
			};
			if (num > 0L)
			{
				this.mem.SetBytesAt(num, enable ? array : array2, 7);
				this.Putlog("Stamina bar " + (enable ? "enabled" : "disabled") + ".");
				return;
			}
			this.Putlog("Not found.");
		}

		public void listMemoryRegions()
		{
			this.mem.UpdateProcess("");
			MemAPI.MemoryRegion[] arg_2C_0 = this.mem.listProcessMemoryRegions(this.mem.Handle);
			List<MemAPI.MemoryRegion> list = new List<MemAPI.MemoryRegion>();
			MemAPI.MemoryRegion[] array = arg_2C_0;
			for (int i = 0; i < array.Length; i++)
			{
				MemAPI.MemoryRegion memoryRegion = array[i];
				if (memoryRegion.regionSize >= 4194304L)
				{
					list.Add(memoryRegion);
				}
			}
			byte[] search = new byte[]
			{
				69,
				15,
				56,
				241,
				116,
				5,
				104,
				139,
				84,
				36,
				8,
				69,
				15,
				56,
				240,
				116,
				21,
				24,
				102,
				65,
				15,
				110,
				198,
				243,
				15,
				90,
				192
			};
			this.Putlog("Searching offset...");
			long num = this.mem.pagedMemorySearch(search, list.ToArray());
			if (num > 0L)
			{
				this.Putlog("Address found : 0x" + num.ToString("X"));
				return;
			}
			this.Putlog("Offset not found !");
		}

		public void searchMemoryRegionForAddress(long addr)
		{
			this.Putlog(string.Concat(new string[]
			{
				"Trying to find memory region related to address 0x",
				addr.ToString("X"),
				" in process '",
				this.mem.ProcessName,
				"'..."
			}));
			this.mem.UpdateProcess("");
			if (this.mem.p == null)
			{
				this.Putlog("Process '" + this.mem.ProcessName + "' not found !");
				return;
			}
			if (!this.mem.CheckOpenProcess())
			{
				this.Putlog("Could not open process with desired access flags...");
				return;
			}
			this.Putlog("Process found, scanning memory...");
			long num = 0L;
			long num2 = 0L;
			if (this.mem.FindRegionByAddr(addr, out num, out num2, this.mem.Handle, false))
			{
				this.Putlog("Found region start : 0x" + num.ToString("X"));
				this.Putlog("Found region end : 0x" + (num + num2).ToString("X"));
				this.Putlog("Found region size : 0x" + num2.ToString("X"));
				return;
			}
			this.Putlog("Region not found !");
		}

		public void searchMemoryRegionForSize(long size, long startAddress = 0L)
		{
			this.Putlog(string.Concat(new string[]
			{
				"Trying to find memory region with size 0x",
				size.ToString("X"),
				" with address starting at 0x",
				startAddress.ToString("X"),
				"' in process '",
				this.mem.ProcessName,
				"'..."
			}));
			this.mem.UpdateProcess("");
			if (this.mem.p == null)
			{
				this.Putlog("Process '" + this.mem.ProcessName + "' not found !");
				return;
			}
			if (!this.mem.CheckOpenProcess())
			{
				this.Putlog("Could not open process with desired access flags...");
				return;
			}
			this.Putlog("Process found, scanning memory...");
			long num = 0L;
			long num2 = 0L;
			if (this.mem.FindRegionBySize(size, out num, out num2, this.mem.Handle, startAddress, false))
			{
				this.Putlog("Found region start : 0x" + num.ToString("X"));
				this.Putlog("Found region end : 0x" + (num + num2).ToString("X"));
				this.Putlog("Found region size : 0x" + num2.ToString("X"));
				return;
			}
			this.Putlog("Region not found !");
		}

		public void showCompareAddress(long address)
		{
			this.Putlog("Comparing address 0x" + address.ToString("X") + " with known ones...");
			this.Putlog("Run speed address : 0x" + this.speedHackAddress.ToString("X") + " diff=0x" + this.getAddressesDiff(this.speedHackAddress, address).ToString("X"));
			this.Putlog("Coordinates address : 0x" + this.coordinatesAddress.ToString("X") + " diff=0x" + this.getAddressesDiff(this.coordinatesAddress, address).ToString("X"));
			this.Putlog("Rupees address : 0x" + this.rupeesAddress.ToString("X") + " diff=0x" + this.getAddressesDiff(this.rupeesAddress, address).ToString("X"));
			this.Putlog("Weapons slot address : 0x" + this.weaponsSlotsAddress.ToString("X") + " diff=0x" + this.getAddressesDiff(this.weaponsSlotsAddress, address).ToString("X"));
			if (this.staminaAddress > 0L)
			{
				this.Putlog("Stamina address : 0x" + this.staminaAddress.ToString("X") + " diff=0x" + this.getAddressesDiff(this.staminaAddress, address).ToString("X"));
			}
			if (this.healthAddress > 0L)
			{
				this.Putlog("Health address : 0x" + this.healthAddress.ToString("X") + " diff=0x" + this.getAddressesDiff(this.healthAddress, address).ToString("X"));
			}
			if (this.inventoryStartAddress > 0L)
			{
				this.Putlog("Inventory start address : 0x" + this.inventoryStartAddress.ToString("X") + " diff=0x" + this.getAddressesDiff(this.inventoryStartAddress, address).ToString("X"));
			}
		}

		public void dumpMemoryToFile(string fileName)
		{
			this.Putlog("Trying to dump process '" + this.mem.ProcessName + "'...");
			this.mem.UpdateProcess("");
			if (this.mem.p == null)
			{
				this.Putlog("Process '" + this.mem.ProcessName + "' not found !");
				return;
			}
			if (!this.mem.CheckOpenProcess())
			{
				this.Putlog("Could not open process with desired access flags...");
				return;
			}
			this.Putlog("Process found, scanning memory...");
			long num = 0L;
			long num2 = 0L;
			long size = 1416757248L;
			long size2 = 1441923072L;
			if (!this.mem.FindRegionBySize(size, out num, out num2, IntPtr.Zero, 0L, true) || num <= 0L)
			{
				if (!this.mem.FindRegionBySize(size2, out num, out num2, IntPtr.Zero, 0L, true) || num <= 0L)
				{
					this.Putlog("Memory region not found, need some thinking ?");
					return;
				}
			}
			long num3 = num;
			long num4 = num + num2;
			this.Putlog("Memory region start : " + num3.ToString("X"));
			this.Putlog("Memory region end : " + num4.ToString("X"));
			BinaryWriter binaryWriter = null;
			this.Putlog(string.Concat(new string[]
			{
				"Starting to dump memory to '",
				fileName,
				"' from process ",
				this.mem.ProcessName,
				"'..."
			}));
			if (this.mem.OpenProcessHandle())
			{
				int num5 = 32768;
				byte[] buffer = new byte[num5];
				int num6 = 0;
				for (long num7 = num3; num7 <= num4 - (long)num5; num7 += (long)num5)
				{
					int num8 = MemAPI.ReadBytes(num7, buffer, num5, this.mem.p, this.mem.Handle);
					num6 += num8;
					if (binaryWriter == null)
					{
						binaryWriter = new BinaryWriter(File.OpenWrite(fileName));
					}
					binaryWriter.Write(buffer, 0, num8);
					binaryWriter.Flush();
				}
				if (binaryWriter != null)
				{
					binaryWriter.Close();
					binaryWriter.Dispose();
				}
				this.Putlog(string.Concat(new object[]
				{
					"Total bytes written to ",
					fileName,
					" : ",
					num6
				}));
			}
			this.mem.CloseProcessHandle();
			this.Putlog("Dump terminated.");
		}

		public void generateCompareReport(string fileName)
		{
			if (this.memoryChanges.Count == 0)
			{
				this.Putlog("Nothing to report.");
				return;
			}
			this.Putlog("Reporting " + this.memoryChanges.Count + " changes in memory since last dump...");
			this.Putlog("Creating report file '" + fileName + "'...");
			try
			{
				using (StreamWriter streamWriter = new StreamWriter(fileName))
				{
					streamWriter.WriteLine("Memory changes report - Number of affected offsets : " + this.memoryChanges.Count);
					streamWriter.WriteLine("");
					streamWriter.WriteLine("[info] region Start address = 0x" + this.memoryChanges[0].regionStart.ToString("X"));
					streamWriter.WriteLine("[info] region End address = 0x" + (this.memoryChanges[0].regionStart + this.memoryChanges[0].regionSize).ToString("X"));
					streamWriter.WriteLine("[info] Size = 0x" + this.memoryChanges[0].regionSize.ToString("X"));
					if (this.speedHackAddress > 0L)
					{
						streamWriter.WriteLine("");
						streamWriter.WriteLine("[info] runspeed address = 0x" + this.speedHackAddress.ToString("X"));
					}
					if (this.rupeesAddress > 0L)
					{
						streamWriter.WriteLine("[info] rupees address = 0x" + this.rupeesAddress.ToString("X"));
					}
					if (this.coordinatesAddress > 0L)
					{
						streamWriter.WriteLine("[info] coordinates address = 0x" + this.coordinatesAddress.ToString("X"));
					}
					int num = 13;
					foreach (MemoryChange current in this.memoryChanges)
					{
						streamWriter.WriteLine("");
						streamWriter.WriteLine(string.Concat(new string[]
						{
							"[0x",
							current.address.ToString("X"),
							"] (0x",
							current.oldValue.ToString("X2"),
							") -> (0x",
							current.newValue.ToString("X2"),
							")"
						}));
						streamWriter.WriteLine("");
						streamWriter.WriteLine("Reference Memory Buffer (" + current.oldBuffer.Length + " bytes) :");
						streamWriter.WriteLine("");
						string text = "";
						int num2 = 0;
						for (int i = 0; i < current.oldBuffer.Length; i++)
						{
							if (text.Length > 0)
							{
								text += " ";
							}
							text += current.oldBuffer[i].ToString("X2");
							if (i > 0 && (i + 1) % 16 == 0)
							{
								num2++;
								if (num2 == num + 1)
								{
									text = string.Concat(new string[]
									{
										text,
										" => (",
										current.oldValue.ToString("X2"),
										" -> ",
										current.newValue.ToString("X2"),
										")"
									});
								}
								streamWriter.WriteLine(text);
								text = "";
							}
						}
						streamWriter.WriteLine("");
						streamWriter.WriteLine("Process Memory Buffer (" + current.newBuffer.Length + " bytes) :");
						streamWriter.WriteLine("");
						text = "";
						num2 = 0;
						for (int j = 0; j < current.newBuffer.Length; j++)
						{
							if (text.Length > 0)
							{
								text += " ";
							}
							text += current.newBuffer[j].ToString("X2");
							if (j > 0 && (j + 1) % 16 == 0)
							{
								num2++;
								if (num2 == num + 1)
								{
									text = string.Concat(new string[]
									{
										text,
										" => (",
										current.newValue.ToString("X2"),
										" <- ",
										current.oldValue.ToString("X2"),
										")"
									});
								}
								streamWriter.WriteLine(text);
								text = "";
							}
						}
					}
				}
			}
			catch (Exception)
			{
				this.Putlog("Error writing report to file '" + fileName + "'");
				return;
			}
			this.Putlog("Report file '" + fileName + "' created successfully.");
		}

		public void compareMemory(string fileName)
		{
			this.memoryChanges.Clear();
			this.Putlog("Trying to load dump file '" + fileName + "'...");
			if (!File.Exists(fileName))
			{
				this.Putlog("Dump file '" + fileName + "' not found!");
				return;
			}
			this.Putlog("Found dump file '" + fileName + "'.");
			long length = new FileInfo(fileName).Length;
			this.Putlog("Trying to load process '" + this.mem.ProcessName + "'...");
			this.mem.UpdateProcess("");
			if (this.mem.p == null)
			{
				this.Putlog("Process '" + this.mem.ProcessName + "' not found !");
				return;
			}
			if (!this.mem.CheckOpenProcess())
			{
				this.Putlog("Could not open process with desired access flags...");
				return;
			}
			this.Putlog("Process found, scanning memory...");
			long num = 0L;
			long num2 = 0L;
			long size = 1416757248L;
			long size2 = 1441923072L;
			if (!this.mem.FindRegionBySize(size, out num, out num2, IntPtr.Zero, 0L, true) || num <= 0L)
			{
				if (!this.mem.FindRegionBySize(size2, out num, out num2, IntPtr.Zero, 0L, true) || num <= 0L)
				{
					this.Putlog("Memory region not found, need some thinking ?");
					return;
				}
			}
			long num3 = num;
			long num4 = num + num2;
			this.Putlog("Memory region start : " + num3.ToString("X"));
			this.Putlog("Memory region end : " + num4.ToString("X"));
			if (num2 != length)
			{
				this.Putlog("Dump size is not equal to memory region size !");
				return;
			}
			this.Putlog("Starting Memory Comparison between Memory Dump and Process '" + this.mem.ProcessName + "'...");
			using (BinaryReader binaryReader = new BinaryReader(File.OpenRead(fileName)))
			{
				if (this.mem.OpenProcessHandle())
				{
					int num5 = 131072;
					byte[] array = new byte[num5];
					byte[] array2 = new byte[num5];
					int num6 = 0;
					int num7 = 0;
					int num8;
					while ((num8 = binaryReader.Read(array, 0, num5)) > 0)
					{
						MemAPI.ReadBytes(num3 + (long)num7, array2, num8, this.mem.p, this.mem.Handle);
						for (int i = 0; i < num8; i++)
						{
							if (array[i] != array2[i])
							{
								this.Putlog("Changes found at address 0x" + (num3 + (long)num7 + (long)i).ToString("X"));
								this.Putlog("Byte value changed from 0x" + array[i].ToString("X") + " to 0x" + array2[i].ToString("X"));
								num6++;
								int num9 = 13;
								MemoryChange memoryChange = new MemoryChange();
								memoryChange.regionStart = num3;
								memoryChange.regionSize = num4 - num3;
								memoryChange.address = num3 + (long)num7 + (long)i;
								memoryChange.oldValue = array[i];
								memoryChange.newValue = array2[i];
								int num10 = -1 * (num9 * 16);
								MemAPI.ReadBytes(memoryChange.address + (long)num10, memoryChange.newBuffer, 16 * (num9 * 2 + 1), this.mem.p, this.mem.Handle);
								this.ReadBytesFromFile(fileName, memoryChange.oldBuffer, (long)(num7 + i + num10), 16 * (num9 * 2 + 1));
								this.memoryChanges.Add(memoryChange);
							}
						}
						num7 += num8;
					}
					binaryReader.Close();
					this.Putlog(string.Concat(new object[]
					{
						"Total bytes read from ",
						fileName,
						" : ",
						num7
					}));
					this.Putlog("Total bytes changes : " + num6);
				}
				this.mem.CloseProcessHandle();
			}
			this.Putlog("Memory Comparison done.");
		}

		public bool ReadBytesFromFile(string fileName, byte[] buffer, long startFileOffset, int count)
		{
			if (!File.Exists(fileName))
			{
				return false;
			}
			long length = new FileInfo(fileName).Length;
			if (startFileOffset >= length)
			{
				this.Putlog("Error index too big");
				return false;
			}
			bool result;
			try
			{
				using (BinaryReader binaryReader = new BinaryReader(File.OpenRead(fileName)))
				{
					binaryReader.BaseStream.Seek(startFileOffset, SeekOrigin.Begin);
					int arg_54_0 = binaryReader.Read(buffer, 0, count);
					binaryReader.Close();
					result = (arg_54_0 == count);
				}
			}
			catch (Exception ex)
			{
				this.Putlog("Error reading bytes from file '" + fileName + "' : " + ex.Message);
				result = false;
			}
			return result;
		}

		public void loadMemoryFromFile(string fileName)
		{
			this.Putlog("Trying to load process '" + this.mem.ProcessName + "' memory dump...");
			this.mem.UpdateProcess("");
			if (this.mem.p == null)
			{
				this.Putlog("Process '" + this.mem.ProcessName + "' not found !");
				return;
			}
			if (!this.mem.CheckOpenProcess())
			{
				this.Putlog("Could not open process with desired access flags...");
				return;
			}
			this.Putlog("Process found, scanning memory...");
			long num = 0L;
			long num2 = 0L;
			long size = 1416757248L;
			long size2 = 1441923072L;
			if (!this.mem.FindRegionBySize(size, out num, out num2, IntPtr.Zero, 0L, true) || num <= 0L)
			{
				if (!this.mem.FindRegionBySize(size2, out num, out num2, IntPtr.Zero, 0L, true) || num <= 0L)
				{
					this.Putlog("Memory region not found, need some thinking ?");
					return;
				}
			}
			long num3 = num;
			long num4 = num + num2;
			this.Putlog("Memory region start : " + num3.ToString("X"));
			this.Putlog("Memory region end : " + num4.ToString("X"));
			using (BinaryReader binaryReader = new BinaryReader(File.OpenRead(fileName)))
			{
				if (this.mem.OpenProcessHandle())
				{
					this.Putlog("Loading started.");
					int num5 = 131072;
					byte[] buffer = new byte[num5];
					int num6 = 0;
					int num7;
					while ((num7 = binaryReader.Read(buffer, 0, num5)) > 0)
					{
						num6 += num7;
						this.Putlog(string.Concat(new object[]
						{
							"Read ",
							num7,
							" bytes (total: ",
							num6,
							")"
						}));
						MemAPI.WriteBytes(num3 + (long)num6, buffer, num7, this.mem.p, this.mem.Handle);
					}
					binaryReader.Close();
					this.Putlog(string.Concat(new object[]
					{
						"Total bytes read from ",
						fileName,
						" : ",
						num6
					}));
				}
				this.mem.CloseProcessHandle();
			}
			this.Putlog("Load terminated.");
		}

		public void FindItemsInMemory(bool silent = false)
		{
			this.updateItems(new List<itemdata>());
			List<itemdata> list = new List<itemdata>();
			if (!silent)
			{
				this.SetLblScan("Looking for process '" + this.mem.ProcessName + "'...");
			}
			this.mem.UpdateProcess("");
			if (this.mem.p == null)
			{
				if (!silent)
				{
					this.SetLblScan("Process '" + this.mem.ProcessName + "' not found !");
				}
				this.updateItems(list);
				return;
			}
			if (!this.mem.CheckOpenProcess())
			{
				if (!silent)
				{
					this.SetLblScan("Could not open process with desired access flags...");
				}
				this.updateItems(list);
				return;
			}
			if (!silent)
			{
				this.SetLblScan("Process found, scanning memory...");
			}
			long num = 0L;
			long num2 = 0L;
			long size = 1416757248L;
			long size2 = 1441923072L;
			long size3 = 1308622848L;
			long num3;
			long num4;
			if (this.mem.FindRegionBySize(size, out num, out num2, IntPtr.Zero, 0L, true) && num > 0L)
			{
				num3 = num;
				num4 = num3 + num2;
			}
			else if (this.mem.FindRegionBySize(size2, out num, out num2, IntPtr.Zero, 0L, true) && num > 0L)
			{
				num3 = num;
				num4 = num3 + num2;
			}
			else
			{
				if (!this.mem.FindRegionBySize(size3, out num, out num2, IntPtr.Zero, 0L, true) || num <= 0L)
				{
					if (!silent)
					{
						this.SetLblScan("Memory region not found, need some thinking ?");
					}
					this.updateItems(list);
					return;
				}
				num3 = num;
				num4 = num3 + num2;
			}
			if (this.rupeesAddress < 0L)
			{
				if (!silent)
				{
					this.SetLblScan("Memory region found, looking for rupees...");
				}
				long num5 = this.findRupeesAddressInMemory(num3, num4);
				if (num5 >= 0L)
				{
					this.rupeesAddress = num5;
					int int32At = this.mem.GetInt32At(this.rupeesAddress);
					if (!silent)
					{
						this.SetLblScan("Found " + int32At.ToString() + " rupees.");
					}
					this.TextControl(this.frmMain.txtRupees.Name, int32At.ToString());
					num2 = num4 - num5;
					num = num5;
					this.EnableControl("gbRupees", true);
				}
				else
				{
					if (!silent)
					{
						this.SetLblScan("Could not find rupees offset in memory !");
					}
					this.EnableControl("gbRupees", false);
					this.TextControl(this.frmMain.txtRupees.Name, "");
				}
			}
			if (this.coordinatesAddress < 0L)
			{
				if (!silent)
				{
					this.SetLblScan("Memory region found, looking for player coordinates...");
				}
				long num6 = this.findCoordinatesAddress(num3, num4 - num3);
				if (num6 >= 0L)
				{
					this.coordinatesAddress = num6;
					float singleAt = this.mem.GetSingleAt(this.coordinatesAddress);
					float singleAt2 = this.mem.GetSingleAt(this.coordinatesAddress + 4L);
					float singleAt3 = this.mem.GetSingleAt(this.coordinatesAddress + 8L);
					this.Putlog(string.Concat(new string[]
					{
						"Coordinates: X=",
						singleAt.ToString(),
						" Y=",
						singleAt2.ToString(),
						" Z=",
						singleAt3.ToString()
					}));
				}
				else
				{
					if (!silent)
					{
						this.SetLblScan("Could not find coordinates offset in memory !");
					}
					this.Putlog("Could not find coordinates offset in memory !");
				}
			}
			if (this.weaponsSlotsAddress < 0L || this.bowsSlotsAddress < 0L || this.shieldsSlotsAddress < 0L)
			{
				if (!silent)
				{
					this.SetLblScan("Memory region found, looking for slots count addresses...");
				}
				long num7;
				if (this.rupeesAddress > 0L)
				{
					num7 = this.rupeesAddress + 2368L;
				}
				else
				{
					num7 = this.findWeaponsSlotsAddressInMemory(num3, num4);
				}
				if (num7 >= 0L)
				{
					this.weaponsSlotsAddress = num7;
					this.RefreshTxtSlot("Weapons");
					if (!silent)
					{
						this.SetLblScan("Found weapons slots count : " + this.mem.GetUInt32At(this.weaponsSlotsAddress).ToString() + ".");
					}
					this.EnableControl("gbWeaponsSlots", true);
					num7 = this.findWeaponsSlotsPersistAddressInMemory(num3, num4);
					if (num7 >= 0L)
					{
						this.weaponsSlotsPersistAddress = num7;
						if (!silent)
						{
							this.SetLblScan("Found persist weapons slots address.");
						}
					}
				}
				else
				{
					this.EnableControl("gbWeaponsSlots", false);
				}
				if (this.rupeesAddress > 0L)
				{
					num7 = this.rupeesAddress + 2368L + 24352L;
				}
				else
				{
					num7 = this.findBowsSlotsAddressInMemory(num3, num4);
				}
				if (num7 >= 0L)
				{
					this.bowsSlotsAddress = num7;
					this.RefreshTxtSlot("Bows");
					if (!silent)
					{
						this.SetLblScan("Found bows slots count : " + this.mem.GetUInt32At(this.bowsSlotsAddress).ToString() + ".");
					}
					this.EnableControl("gbBowsSlots", true);
					num7 = this.findBowsSlotsPersistAddressInMemory(num3, num4);
					if (num7 >= 0L)
					{
						this.bowsSlotsPersistAddress = num7;
						if (!silent)
						{
							this.SetLblScan("Found persist bows slots address.");
						}
					}
				}
				else
				{
					this.EnableControl("gbBowsSlots", false);
				}
				if (this.rupeesAddress > 0L)
				{
					num7 = this.rupeesAddress + 2368L + 24384L;
				}
				else
				{
					num7 = this.findShieldsSlotsAddressInMemory(num3, num4);
				}
				if (num7 >= 0L)
				{
					this.shieldsSlotsAddress = num7;
					this.RefreshTxtSlot("Shields");
					if (!silent)
					{
						this.SetLblScan("Found shields slots count : " + this.mem.GetUInt32At(this.shieldsSlotsAddress).ToString() + ".");
					}
					this.EnableControl("gbShieldsSlots", true);
					num7 = this.findShieldsSlotsPersistAddressInMemory(num3, num4);
					if (num7 >= 0L)
					{
						this.shieldsSlotsPersistAddress = num7;
						if (!silent)
						{
							this.SetLblScan("Found persist shields slots address.");
						}
					}
				}
				else
				{
					this.EnableControl("gbShieldsSlots", false);
				}
			}
			if (this.speedHackAddress < 0L)
			{
				if (!silent)
				{
					this.SetLblScan("Memory region found, looking for run speed address...");
				}
				long num8 = this.findSpeedHackAddressInMemory(num3, num4);
				if (num8 >= 0L)
				{
					this.speedHackAddress = num8;
					float singleAt4 = this.mem.GetSingleAt(this.speedHackAddress);
					if (!silent)
					{
						this.SetLblScan(("Found run speed multiplier : x " + singleAt4.ToString()) ?? "");
					}
					this.TextControl(this.frmMain.txtRunSpeed.Name, singleAt4.ToString());
				}
				else
				{
					if (!silent)
					{
						this.SetLblScan("Could not find run speed offset in memory !");
					}
					this.TextControl(this.frmMain.txtRunSpeed.Name, 1.ToString());
				}
			}
			if (this.inventoryStartAddress > 0L)
			{
				if (num3 < this.inventoryStartAddress && this.inventoryStartAddress < num4)
				{
					num2 = num4 - this.inventoryStartAddress;
					num = this.inventoryStartAddress;
				}
				else
				{
					this.inventoryStartAddress = -1L;
				}
			}
			if (!silent)
			{
				this.SetLblScan("Memory region found, looking for items...");
			}
			long num9 = -1L;
			long num10 = num;
			long num11 = num + num2;
			this.Putlog("Memory region start : " + num10.ToString("X"));
			this.Putlog("Memory region end : " + num11.ToString("X"));
			byte[] array = new byte[]
			{
				16,
				30
			};
			(new byte[4])[3] = 64;
			int[] sequence = new int[]
			{
				16,
				-1,
				-1,
				-1,
				0,
				0,
				0,
				64
			};
			RuntimeHelpers.InitializeArray(new byte[128], fieldof(<PrivateImplementationDetails>.CD5BD20E9A0F22D7367CC169E2844A02751C7C91).FieldHandle);
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			int num12 = 0;
			if (this.mem.OpenProcessHandle())
			{
				int num13 = 32768;
				byte[] array2 = new byte[num13];
				long num14 = num10;
				while (num14 < num11)
				{
					num12++;
					if (num9 < 0L)
					{
						MemAPI.ReadBytes(num14, array2, num13, this.mem.p, this.mem.Handle);
						int num15;
						if ((num15 = MemAPI.findSequenceMatch(array2, 0, sequence, true, false)) >= 0)
						{
							num14 += (long)num15;
							MemAPI.ReadBytes(num14, array2, num13, this.mem.p, this.mem.Handle);
							if (array2[1] == 30 || array2[1] == 31 || array2[1] == 32 || array2[1] == 33)
							{
								if (MemAPI.findSequenceMatch(array2, 544, sequence, false, false) == 544)
								{
									num9 = num14;
								}
								else
								{
									num14 += (long)array.Length;
								}
							}
							else
							{
								num14 += (long)array.Length;
							}
						}
						else
						{
							num14 += (long)(num13 - array.Length);
						}
					}
					else
					{
						if (this.inventoryStartAddress < 0L)
						{
							this.inventoryStartAddress = num9;
						}
						MemAPI.ReadBytes(num14, array2, num13, this.mem.p, this.mem.Handle);
						if (MemAPI.findSequenceMatch(array2, 0, sequence, false, false) != 0)
						{
							break;
						}
						long num16 = num14 + 7L;
						if (MemAPI.IsValidItemIDInArray(array2, 8))
						{
							string itemID = MemAPI.ExtractStringFromMemory(num16 + 1L, 128, this.mem.p, this.mem.Handle);
							list.Add(new itemdata
							{
								itemAddress = num16,
								itemID = itemID
							});
						}
						num14 += 544L;
					}
				}
			}
			this.mem.CloseProcessHandle();
			stopwatch.Stop();
			if (!silent)
			{
				this.SetLblScan("Found " + list.Count + " items in memory.");
			}
			if (this.itemNames.Count == 0)
			{
				this.mem.OpenProcessHandle();
				this.extractNamesFromMemory(num3, (this.inventoryStartAddress >= 0L) ? this.inventoryStartAddress : num4, false);
				this.mem.CloseProcessHandle();
			}
			this.updateItems(list);
		}

		public void addressesSummary()
		{
			this.Putlog("Summary :");
			this.Putlog("Run speed address : " + this.speedHackAddress.ToString("X"));
			this.Putlog("Coordinates address : " + this.coordinatesAddress.ToString("X"));
			this.Putlog("Rupees address : " + this.rupeesAddress.ToString("X"));
			this.Putlog("Diff [Run speed] [Rupees] : " + this.getAddressesDiff(this.speedHackAddress, this.rupeesAddress).ToString("X"));
			this.Putlog("Diff [Run speed] [Coordinates] : " + this.getAddressesDiff(this.speedHackAddress, this.coordinatesAddress).ToString("X"));
			this.Putlog("Diff [Rupees] [Coordinates] : " + this.getAddressesDiff(this.rupeesAddress, this.coordinatesAddress).ToString("X"));
			this.Putlog("Weapons slot address : " + this.weaponsSlotsAddress.ToString("X"));
			this.Putlog("Weapons slot persist address : " + this.weaponsSlotsPersistAddress.ToString("X"));
			this.Putlog("Diff [Weapons] : " + this.getAddressesDiff(this.weaponsSlotsAddress, this.weaponsSlotsPersistAddress).ToString("X"));
			this.Putlog("Bows slot address : " + this.bowsSlotsAddress.ToString("X"));
			this.Putlog("Bows slot persist address : " + this.bowsSlotsPersistAddress.ToString("X"));
			this.Putlog("Diff [Bows] : " + this.getAddressesDiff(this.bowsSlotsAddress, this.bowsSlotsPersistAddress).ToString("X"));
			this.Putlog("Shields slot address : " + this.shieldsSlotsAddress.ToString("X"));
			this.Putlog("Shields slot persist address : " + this.shieldsSlotsPersistAddress.ToString("X"));
			this.Putlog("Diff [Shields] : " + this.getAddressesDiff(this.shieldsSlotsAddress, this.shieldsSlotsPersistAddress).ToString("X"));
			this.Putlog("Diff [Weapons] [Bows] : " + this.getAddressesDiff(this.weaponsSlotsAddress, this.bowsSlotsAddress).ToString("X"));
			this.Putlog("Diff [Bows] [Shields] : " + this.getAddressesDiff(this.bowsSlotsAddress, this.shieldsSlotsAddress).ToString("X"));
			this.Putlog("Diff [Weapons] [Shields] : " + this.getAddressesDiff(this.weaponsSlotsAddress, this.shieldsSlotsAddress).ToString("X"));
			this.Putlog("Diff [Weapons Persist] [Bows Persist] : " + this.getAddressesDiff(this.weaponsSlotsPersistAddress, this.bowsSlotsPersistAddress).ToString("X"));
			this.Putlog("Diff [Bows Persist] [Shields Persist] : " + this.getAddressesDiff(this.bowsSlotsPersistAddress, this.shieldsSlotsPersistAddress).ToString("X"));
			this.Putlog("Diff [Weapons Persist] [Shields Persist] : " + this.getAddressesDiff(this.weaponsSlotsPersistAddress, this.shieldsSlotsPersistAddress).ToString("X"));
			this.Putlog("Diff [Run speed] [Weapons] : " + this.getAddressesDiff(this.speedHackAddress, this.weaponsSlotsAddress).ToString("X"));
			this.Putlog("Diff [Coordinates] [Weapons] : " + this.getAddressesDiff(this.coordinatesAddress, this.weaponsSlotsAddress).ToString("X"));
			this.Putlog("Diff [Rupees] [Weapons] : " + this.getAddressesDiff(this.rupeesAddress, this.weaponsSlotsAddress).ToString("X"));
			this.Putlog("Inventory start address : " + this.inventoryStartAddress.ToString("X"));
			this.Putlog("End Summary.");
			this.Putlog("Speculative address search :");
			long num = this.speedHackAddress - 22565198L + 2L;
			this.Putlog("STAMINA: : " + (num - 2L).ToString("X"));
			this.Putlog("SPEED: " + (num + 22565196L).ToString("X"));
			this.Putlog("BLOODMOON: " + (num - 38868761L).ToString("X"));
			this.Putlog("FREEZE CHRONO: " + (num - 33962117L).ToString("X"));
			this.Putlog("TIME: " + (num + 1567901152L).ToString("X"));
			this.Putlog("End speculative address search.");
		}

		public long getAddressesDiff(long addr1, long addr2)
		{
			if (addr1 <= addr2)
			{
				return addr2 - addr1;
			}
			return addr1 - addr2;
		}

		public void extractNamesFromMemory(long startAddress, long endAddress, bool debug = false)
		{
			this.itemNames.Clear();
			this.SetLblScan("Looking for item names in memory...");
			byte[] array = new byte[]
			{
				77,
				115,
				103,
				83,
				116,
				100,
				66,
				110
			};
			byte[] sequence = new byte[]
			{
				76,
				66,
				76,
				49
			};
			byte[] sequence2 = new byte[]
			{
				65,
				84,
				82,
				49
			};
			byte[] sequence3 = new byte[]
			{
				84,
				88,
				84,
				50
			};
			byte[] expr_64 = new byte[6];
			expr_64[1] = 14;
			expr_64[3] = 201;
			byte[] sequence4 = expr_64;
			byte[] sequence5 = new byte[]
			{
				0,
				14,
				0,
				2
			};
			byte[] sequence6 = new byte[8];
			byte[] sequence7 = new byte[12];
			long num = startAddress;
			long num2 = -1L;
			while (num < endAddress && (num2 = this.mem.pagedMemorySearch(array, num, endAddress - num)) >= 0L)
			{
				List<string> list = new List<string>();
				Dictionary<string, int> dictionary = new Dictionary<string, int>();
				int num3 = this.mem.GetInt32At(num2 + 12L) - 16973824;
				int num4 = this.mem.GetInt32At(num2 + 18L);
				byte[] array2;
				if (num3 > 0 && num4 > 0)
				{
					array2 = new byte[num4];
					this.mem.GetBytesAt(num2, array2, num4);
				}
				else
				{
					array2 = new byte[0];
					num3 = 0;
					num4 = 0;
				}
				int num5 = 32;
				int num6 = 0;
				while (num3 > 0 && num6 < num3)
				{
					while (num5 < num4 && array2[num5] == 171)
					{
						num5++;
					}
					int num7 = MemAPI.ExtractInt32FromArray(array2, num5 + 4);
					int num8 = MemAPI.ExtractInt32FromArray(array2, num5 + 16);
					if (MemAPI.findSequence(array2, num5, sequence, false, false) == num5)
					{
						num7 += 16;
						for (int i = 0; i < num8; i++)
						{
							int num9 = MemAPI.ExtractInt32FromArray(array2, num5 + 20 + 8 * i);
							int num10 = MemAPI.ExtractInt32FromArray(array2, num5 + 20 + 8 * i + 4);
							int num11 = num5 + num10 + 16;
							for (int j = 0; j < num9; j++)
							{
								byte b = array2[num11];
								string text = MemAPI.ExtractStringFromArray(array2, num11 + 1, (int)b);
								int value = MemAPI.ExtractInt32FromArray(array2, num11 + 1 + (int)b);
								num11 += (int)(1 + b + 4);
								if (text.EndsWith("_Name"))
								{
									dictionary.Add(text.Substring(0, text.Length - 5), value);
								}
							}
						}
					}
					else if (dictionary.Count > 0 && MemAPI.findSequence(array2, num5, sequence2, false, false) == num5)
					{
						num7 += 16;
					}
					else
					{
						if (dictionary.Count <= 0 || MemAPI.findSequence(array2, num5, sequence3, false, false) != num5)
						{
							break;
						}
						num7 += 16;
						for (int k = num5 + 20; k < num5 + num7 - 12; k++)
						{
							if (MemAPI.findSequence(array2, k, sequence4, false, false) >= 0)
							{
								for (int l = 0; l < 12; l++)
								{
									array2[k + l] = 0;
								}
							}
							else if (MemAPI.findSequence(array2, k, sequence5, false, false) >= 0)
							{
								for (int m = 0; m < 8; m++)
								{
									array2[k + m] = 0;
								}
							}
						}
						for (int n = 0; n < num8; n++)
						{
							int num12 = MemAPI.ExtractInt32FromArray(array2, num5 + 20 + 4 * n);
							int num13 = num5 + num12 + 16;
							if (MemAPI.findSequence(array2, num13, sequence4, false, false) == num13)
							{
								num13 += 12;
							}
							else if (MemAPI.findSequence(array2, num13, sequence7, false, false) == num13)
							{
								num13 += 12;
							}
							else if (MemAPI.findSequence(array2, num13, sequence6, false, false) == num13)
							{
								num13 += 8;
							}
							int num14 = 0;
							string item = App.RemoveInvalidXmlChars(MemAPI.GetBigEndianUnicodeString(array2, num13, out num14));
							list.Add(item);
						}
					}
					num5 += num7;
					num6++;
				}
				foreach (KeyValuePair<string, int> current in dictionary)
				{
					if (list.Count > current.Value && !this.itemNames.ContainsKey(current.Key))
					{
						this.itemNames.Add(current.Key, list[current.Value]);
					}
				}
				dictionary.Clear();
				list.Clear();
				num = num2 + (long)((num4 > 0) ? num4 : array.Length);
			}
			this.SetLblScan("Found " + this.itemNames.Count + " names in memory.");
		}
	}
}
