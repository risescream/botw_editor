using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
		public readonly static string[] SECTIONS;

		public readonly static string[] ACTION_SECTIONS;

		public readonly static string[] EXTENDED_ACTION_SECTIONS;

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

		private long rupeesAddress = (long)-1;

		private long inventoryStartAddress = (long)-1;

		private long healthAddress = (long)-1;

		private long staminaAddress = (long)-1;

		private long equippedWeaponDurabilityAddress = (long)-1;

		private long equippedBowDurabilityAddress = (long)-1;

		private long equippedShieldDurabilityAddress = (long)-1;

		private long divinePowersAddress = (long)-1;

		private long amiiboDateAddress = (long)-1;

		private long speedHackAddress = (long)-1;

		private long weaponsSlotsAddress = (long)-1;

		private long bowsSlotsAddress = (long)-1;

		private long shieldsSlotsAddress = (long)-1;

		private long weaponsSlotsPersistAddress = (long)-1;

		private long bowsSlotsPersistAddress = (long)-1;

		private long shieldsSlotsPersistAddress = (long)-1;

		private long coordinatesAddress = (long)-1;

		private float savedX;

		private float savedY;

		private float savedZ;

		private float lockedY;

		private long noStaminaBarAddress = (long)-1;

		private long divinePowerMiphaTimerAddress = (long)-1;

		private long divinePowerRevaliAddress = (long)-1;

		private long divinePowerUrbosaAddress = (long)-1;

		private long divinePowerDarukAddress = (long)-1;

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
				if (this.frmMain == null)
				{
					return false;
				}
				return this.frmMain.InvokeRequired;
			}
		}

		static App()
		{
			App.SECTIONS = new string[] { "Inventory", "Weapons", "Archery", "Shields", "Armors", "Food", "Materials", "Other" };
			App.ACTION_SECTIONS = new string[] { "Weapons", "Bows", "Shields", "Arrows" };
			App.EXTENDED_ACTION_SECTIONS = new string[] { "UnbreakableWeapons", "UnbreakableBows", "UnbreakableShields", "LockHealth", "LockStamina", "PowersMipha", "PowersRevali", "PowersUrbosa", "PowersDaruk", "UnlimitAmiibo", "RunSpeedUp", "RunSpeedDown", "RunSpeedDefault", "PositionSave", "PositionRestore", "PositionLockHeight", "PositionJump" };
		}

		public App(FrmMain frm)
		{
			int i;
			this.mem = new MemAPI()
			{
				ProcessName = "Cemu"
			};
			MemAPI.obj = this;
			this.frmMain = frm;
			itemdata.parent = this;
			this.frmMain.btnActionsNew.Click += new EventHandler(this.btnActionsNew_Click);
			this.frmMain.btnActionsRemove.Click += new EventHandler(this.btnActionsRemove_Click);
			ListBox listBox = this.frmMain.lstActionsRegistered;
			listBox.DataSource = this.CreateBindingSource<actiondata>(this.customActions);
			listBox.SelectedIndexChanged += new EventHandler(this.lstActionsRegistered_SelectedIndexChanged);
			listBox.SelectedValueChanged += new EventHandler(this.lstActionsRegistered_SelectedValueChanged);
			this.frmMain.cbActionsList.SelectedIndexChanged += new EventHandler(this.cbActionsList_SelectedIndexChanged);
			this.frmMain.txtActionsHotKey.TextChanged += new EventHandler(this.txtActionsHotKey_TextChanged);
			this.frmMain.txtActionsFixed.TextChanged += new EventHandler(this.txtActionsFixed_TextChanged);
			this.frmMain.txtActionsTimer.TextChanged += new EventHandler(this.txtActionsTimer_TextChanged);
			this.frmMain.txtActionsQuantity.TextChanged += new EventHandler(this.txtActionsQuantity_TextChanged);
			this.frmMain.txtActionsMax.TextChanged += new EventHandler(this.txtActionsMax_TextChanged);
			this.frmMain.chkActionsDisableWhenDone.CheckedChanged += new EventHandler(this.chkActionsDisableWhenDone_CheckedChanged);
			CheckBox checkBox = this.frmMain.chkActionsUseHotkey;
			checkBox.CheckedChanged += new EventHandler(this.chkActionsUseHotKey_CheckedChanged);
			this.frmMain.chkActionsActiveInactive.CheckedChanged += new EventHandler(this.chkActionsActiveInactive_CheckedChanged);
			this.frmMain.optionActionsFixed.CheckedChanged += new EventHandler(this.optionActionsFixed_CheckedChanged);
			this.frmMain.optionActionsTimer.CheckedChanged += new EventHandler(this.optionActionsTimer_CheckedChanged);
			this.frmMain.optionActionsNoFilter.CheckedChanged += new EventHandler(this.optionActionsNoFilter_CheckedChanged);
			this.frmMain.optionActionsFilterList.CheckedChanged += new EventHandler(this.optionActionsFilterList_CheckedChanged);
			this.frmMain.lstActionsFilter.DoubleClick += new EventHandler(this.lstActionsFilter_DoubleClick);
			checkBox.CheckedChanged += new EventHandler(this.chkUseHotKey_CheckedChanged);
			string[] sECTIONS = App.SECTIONS;
			for (i = 0; i < (int)sECTIONS.Length; i++)
			{
				string str = sECTIONS[i];
				this.lists.Add(str, new BindingList<itemdata>());
				this.sources.Add(str, this.CreateBindingSource<itemdata>(this.lists[str]));
				this.names.Add(str, new List<itemname>());
				ListBox item = (ListBox)this.findControl(string.Concat("lst", str));
				if (item != null)
				{
					item.DataSource = this.sources[str];
					item.SelectedIndexChanged += new EventHandler(this.lst_SelectedIndexChanged);
					item.DoubleClick += new EventHandler(this.lst_DoubleClick);
				}
				Button button = (Button)this.findControl(string.Concat("btn", str, "ItemUpdate"));
				if (button != null)
				{
					button.Click += new EventHandler(this.btnItemUpdate_Click);
				}
				Button button1 = (Button)this.findControl(string.Concat("btn", str, "ItemUnlock"));
				if (button1 != null)
				{
					button1.Click += new EventHandler(this.btnItemUnlock_Click);
				}
				ComboBox comboBox = (ComboBox)this.findControl(string.Concat("cb", str, "ItemName"));
				if (comboBox != null)
				{
					comboBox.SelectedIndexChanged += new EventHandler(this.cbItemName_SelectedIndexChanged);
				}
			}
			this.names.Add("All", new List<itemname>());
			Button button2 = this.frmMain.btnRefreshRupees;
			Button button3 = this.frmMain.btnUpdateRupees;
			button2.Click += new EventHandler(this.btnRefreshRupees_Click);
			button3.Click += new EventHandler(this.btnUpdateRupees_Click);
			this.items = this.lists["Inventory"];
			this.lists.Add("Equipped", new BindingList<itemdata>());
			this.equipped = this.lists["Equipped"];
			ListBox listBox1 = this.frmMain.lstEquippedWeapons;
			listBox1.DataSource = this.equipped;
			listBox1.DoubleClick += new EventHandler(this.lst_DoubleClick);
			sECTIONS = App.ACTION_SECTIONS;
			for (i = 0; i < (int)sECTIONS.Length; i++)
			{
				string str1 = sECTIONS[i];
				actiondata actiondatum = new actiondata()
				{
					filterList = new BList<itemdata>(),
					section = str1
				};
				ListBox listBox2 = (ListBox)this.findControl(string.Concat("lst", str1, "Filter"));
				this.listActions.Add(str1, actiondatum);
				listBox2.DataSource = this.CreateBindingSource<itemdata>(actiondatum.filterList);
				listBox2.DoubleClick += new EventHandler(this.lstActionsFilter_DoubleClick);
				CheckBox checkBox1 = (CheckBox)this.findControl(string.Concat("chk", str1, "UseHotkey"));
				if (checkBox1 != null)
				{
					checkBox1.CheckedChanged += new EventHandler(this.chkUseHotKey_CheckedChanged);
				}
			}
			BList<itemdata> bList = new BList<itemdata>();
			ListBox listBox3 = (ListBox)this.findControl("lstUnbreakableFilter");
			listBox3.DataSource = this.CreateBindingSource<itemdata>(bList);
			listBox3.DoubleClick += new EventHandler(this.lstActionsFilter_DoubleClick);
			sECTIONS = App.EXTENDED_ACTION_SECTIONS;
			for (i = 0; i < (int)sECTIONS.Length; i++)
			{
				string str2 = sECTIONS[i];
				actiondata actiondatum1 = new actiondata()
				{
					section = str2,
					filterList = bList
				};
				this.listActions.Add(str2, actiondatum1);
				CheckBox checkBox2 = (CheckBox)this.findControl(string.Concat("chk", str2, "UseHotkey"));
				if (checkBox2 != null)
				{
					checkBox2.CheckedChanged += new EventHandler(this.chkUseHotKey_CheckedChanged);
				}
			}
			ListBox listBox4 = (ListBox)this.findControl("lstCapturedPositions");
			listBox4.DataSource = this.capturedPositions;
			listBox4.SelectedIndexChanged += new EventHandler(this.LstCapturedPositions_SelectedIndexChanged);
			listBox4.DoubleClick += new EventHandler(this.LstCapturedPositions_DoubleClick);
			Settings setting = this.readSettings(Settings.getConfigFilePath());
			if (setting == null || !this.applySettings(setting))
			{
				this.Putlog("No settings loaded.");
			}
			else
			{
				this.Putlog(string.Concat("Settings loaded from ", Settings.getConfigFilePath()));
			}
			if (!this.frmMain.chkUpdateList.Checked)
			{
				this.Putlog("Click the Scan Memory button to start.");
			}
			this.gKH = new globalKeyboardHook();
			this.gKH.KeyPress += new KeyEventHandler(this.gKH_KeyPress);
			this.worker = new BackgroundWorker()
			{
				WorkerReportsProgress = true,
				WorkerSupportsCancellation = true
			};
			this.worker.DoWork += new DoWorkEventHandler(this.worker_DoWork);
			this.worker.ProgressChanged += new ProgressChangedEventHandler(this.worker_ProgressChanged);
			this.worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.worker_RunWorkerCompleted);
			this.worker.RunWorkerAsync();
		}

		public void AddCapturedPosition()
		{
			CapturedPosition capturedPosition = new CapturedPosition();
			float singleAt = 0f;
			float single = 0f;
			float singleAt1 = 0f;
			string str = "";
			if (this.coordinatesAddress > (long)0)
			{
				singleAt = this.mem.GetSingleAt(this.coordinatesAddress);
				single = this.mem.GetSingleAt(this.coordinatesAddress + (long)4);
				singleAt1 = this.mem.GetSingleAt(this.coordinatesAddress + (long)8);
			}
			capturedPosition.X = singleAt;
			capturedPosition.Y = single;
			capturedPosition.Z = singleAt1;
			capturedPosition.Name = str;
			this.capturedPositions.Add(capturedPosition);
			this.UpdateCapturedPositionDetails(this.getCurrentSelectedCapturePosition());
		}

		public void addressesSummary()
		{
			this.Putlog("Summary :");
			this.Putlog(string.Concat("Run speed address : ", this.speedHackAddress.ToString("X")));
			this.Putlog(string.Concat("Coordinates address : ", this.coordinatesAddress.ToString("X")));
			this.Putlog(string.Concat("Rupees address : ", this.rupeesAddress.ToString("X")));
			long addressesDiff = this.getAddressesDiff(this.speedHackAddress, this.rupeesAddress);
			this.Putlog(string.Concat("Diff [Run speed] [Rupees] : ", addressesDiff.ToString("X")));
			addressesDiff = this.getAddressesDiff(this.speedHackAddress, this.coordinatesAddress);
			this.Putlog(string.Concat("Diff [Run speed] [Coordinates] : ", addressesDiff.ToString("X")));
			addressesDiff = this.getAddressesDiff(this.rupeesAddress, this.coordinatesAddress);
			this.Putlog(string.Concat("Diff [Rupees] [Coordinates] : ", addressesDiff.ToString("X")));
			this.Putlog(string.Concat("Weapons slot address : ", this.weaponsSlotsAddress.ToString("X")));
			this.Putlog(string.Concat("Weapons slot persist address : ", this.weaponsSlotsPersistAddress.ToString("X")));
			addressesDiff = this.getAddressesDiff(this.weaponsSlotsAddress, this.weaponsSlotsPersistAddress);
			this.Putlog(string.Concat("Diff [Weapons] : ", addressesDiff.ToString("X")));
			this.Putlog(string.Concat("Bows slot address : ", this.bowsSlotsAddress.ToString("X")));
			this.Putlog(string.Concat("Bows slot persist address : ", this.bowsSlotsPersistAddress.ToString("X")));
			addressesDiff = this.getAddressesDiff(this.bowsSlotsAddress, this.bowsSlotsPersistAddress);
			this.Putlog(string.Concat("Diff [Bows] : ", addressesDiff.ToString("X")));
			this.Putlog(string.Concat("Shields slot address : ", this.shieldsSlotsAddress.ToString("X")));
			this.Putlog(string.Concat("Shields slot persist address : ", this.shieldsSlotsPersistAddress.ToString("X")));
			addressesDiff = this.getAddressesDiff(this.shieldsSlotsAddress, this.shieldsSlotsPersistAddress);
			this.Putlog(string.Concat("Diff [Shields] : ", addressesDiff.ToString("X")));
			addressesDiff = this.getAddressesDiff(this.weaponsSlotsAddress, this.bowsSlotsAddress);
			this.Putlog(string.Concat("Diff [Weapons] [Bows] : ", addressesDiff.ToString("X")));
			addressesDiff = this.getAddressesDiff(this.bowsSlotsAddress, this.shieldsSlotsAddress);
			this.Putlog(string.Concat("Diff [Bows] [Shields] : ", addressesDiff.ToString("X")));
			addressesDiff = this.getAddressesDiff(this.weaponsSlotsAddress, this.shieldsSlotsAddress);
			this.Putlog(string.Concat("Diff [Weapons] [Shields] : ", addressesDiff.ToString("X")));
			addressesDiff = this.getAddressesDiff(this.weaponsSlotsPersistAddress, this.bowsSlotsPersistAddress);
			this.Putlog(string.Concat("Diff [Weapons Persist] [Bows Persist] : ", addressesDiff.ToString("X")));
			addressesDiff = this.getAddressesDiff(this.bowsSlotsPersistAddress, this.shieldsSlotsPersistAddress);
			this.Putlog(string.Concat("Diff [Bows Persist] [Shields Persist] : ", addressesDiff.ToString("X")));
			addressesDiff = this.getAddressesDiff(this.weaponsSlotsPersistAddress, this.shieldsSlotsPersistAddress);
			this.Putlog(string.Concat("Diff [Weapons Persist] [Shields Persist] : ", addressesDiff.ToString("X")));
			addressesDiff = this.getAddressesDiff(this.speedHackAddress, this.weaponsSlotsAddress);
			this.Putlog(string.Concat("Diff [Run speed] [Weapons] : ", addressesDiff.ToString("X")));
			addressesDiff = this.getAddressesDiff(this.coordinatesAddress, this.weaponsSlotsAddress);
			this.Putlog(string.Concat("Diff [Coordinates] [Weapons] : ", addressesDiff.ToString("X")));
			addressesDiff = this.getAddressesDiff(this.rupeesAddress, this.weaponsSlotsAddress);
			this.Putlog(string.Concat("Diff [Rupees] [Weapons] : ", addressesDiff.ToString("X")));
			this.Putlog(string.Concat("Inventory start address : ", this.inventoryStartAddress.ToString("X")));
			this.Putlog("End Summary.");
			this.Putlog("Speculative address search :");
			long num = this.speedHackAddress - (long)22565198 + (long)2;
			addressesDiff = num - (long)2;
			this.Putlog(string.Concat("STAMINA: : ", addressesDiff.ToString("X")));
			addressesDiff = num + (long)22565196;
			this.Putlog(string.Concat("SPEED: ", addressesDiff.ToString("X")));
			addressesDiff = num - (long)38868761;
			this.Putlog(string.Concat("BLOODMOON: ", addressesDiff.ToString("X")));
			addressesDiff = num - (long)33962117;
			this.Putlog(string.Concat("FREEZE CHRONO: ", addressesDiff.ToString("X")));
			addressesDiff = num + (long)1567901152;
			this.Putlog(string.Concat("TIME: ", addressesDiff.ToString("X")));
			this.Putlog("End speculative address search.");
		}

		public void applySelectedIndexItemID(string section)
		{
			ComboBox comboBox = (ComboBox)this.findControl(string.Concat("cb", section, "ItemName"));
			TextBox textBox = (TextBox)this.findControl(string.Concat("txt", section, "ItemID"));
			if (comboBox != null && textBox != null && comboBox.SelectedItem != null && comboBox.SelectedItem.GetType() == typeof(itemname))
			{
				itemname selectedItem = (itemname)comboBox.SelectedItem;
				if (selectedItem != null)
				{
					textBox.Text = selectedItem.itemID;
				}
			}
		}

		public bool applySettings(Settings s)
		{
			int j;
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
			for (int i = 0; i < s.item_ids.Count && i < s.item_names.Count; i++)
			{
				this.itemNames.Add(s.item_ids[i], s.item_names[i]);
			}
			this.listActions.Clear();
			string[] aCTIONSECTIONS = App.ACTION_SECTIONS;
			for (j = 0; j < (int)aCTIONSECTIONS.Length; j++)
			{
				string str = aCTIONSECTIONS[j];
				actiondata actiondatum = new actiondata()
				{
					filterList = new BList<itemdata>(),
					section = str
				};
				ListBox listBox = (ListBox)this.findControl(string.Concat("lst", str, "Filter"));
				this.listActions.Add(str, actiondatum);
				listBox.DataSource = this.CreateBindingSource<itemdata>(actiondatum.filterList);
			}
			aCTIONSECTIONS = App.EXTENDED_ACTION_SECTIONS;
			for (j = 0; j < (int)aCTIONSECTIONS.Length; j++)
			{
				string str1 = aCTIONSECTIONS[j];
				actiondata actiondatum1 = new actiondata()
				{
					section = str1,
					filterList = null
				};
				this.listActions.Add(str1, actiondatum1);
			}
			for (int k = 0; k < s.action_keys.Count && k < s.action_datas.Count; k++)
			{
				if (!this.listActions.ContainsKey(s.action_keys[k]))
				{
					this.listActions.Add(s.action_keys[k], s.action_datas[k]);
				}
				else
				{
					this.listActions[s.action_keys[k]] = s.action_datas[k];
				}
			}
			foreach (KeyValuePair<string, object> listAction in this.listActions)
			{
				BList<itemdata> bList = null;
				if (Array.IndexOf<string>(App.EXTENDED_ACTION_SECTIONS, listAction.Key) >= 0)
				{
					actiondata value = (actiondata)listAction.Value;
					if (bList != null)
					{
						value.filterList = bList;
					}
					else
					{
						bList = value.filterList;
					}
				}
				this.updateUiFromActionData((actiondata)listAction.Value);
			}
			this.customActions.Clear();
			for (int l = 0; l < s.custom_actions.Count; l++)
			{
				this.customActions.Add(s.custom_actions[l]);
			}
			foreach (KeyValuePair<string, BindingSource> source in this.sources)
			{
				for (int m = 0; m < source.Value.Count; m++)
				{
					source.Value.ResetItem(m);
				}
			}
			this.capturedPositions.Clear();
			foreach (CapturedPosition capturedPosition in s.capturedPositions)
			{
				this.capturedPositions.Add(capturedPosition);
			}
			return true;
		}

		private void btnActionsNew_Click(object sender, EventArgs e)
		{
			actiondata actiondatum = new actiondata();
			this.customActions.Add(actiondatum);
			this.frmMain.lstActionsRegistered.SelectedItem = actiondatum;
		}

		private void btnActionsRemove_Click(object sender, EventArgs e)
		{
			actiondata selectedItem = (actiondata)this.frmMain.lstActionsRegistered.SelectedItem;
			if (selectedItem != null)
			{
				this.customActions.Remove(selectedItem);
			}
		}

		private void btnItemUnlock_Click(object sender, EventArgs e)
		{
			string controlSection = App.getControlSection((Button)sender);
			if (controlSection != "")
			{
				ListBox listBox = (ListBox)this.findControl(string.Concat("lst", controlSection));
				if (listBox != null && listBox.SelectedItem != null && listBox.SelectedItem.GetType() == typeof(itemdata))
				{
					itemdata selectedItem = (itemdata)listBox.SelectedItem;
					TextBox textBox = (TextBox)this.findControl(string.Concat("txt", controlSection, "ItemID"));
					TextBox textBox1 = (TextBox)this.findControl(string.Concat("txt", controlSection, "ItemQtDur"));
					TextBox textBox2 = (TextBox)this.findControl(string.Concat("txt", controlSection, "ItemBonusType"));
					TextBox textBox3 = (TextBox)this.findControl(string.Concat("txt", controlSection, "ItemBonusValue"));
					ComboBox item = (ComboBox)this.findControl(string.Concat("cb", controlSection, "ItemName"));
					ComboBox comboBox = (ComboBox)this.findControl(string.Concat("cb", controlSection, "ItemBonusType"));
					this.EnableControl(string.Concat("gb", controlSection, "Edit"), true);
					this.EnableControl(string.Concat("cb", controlSection, "ItemName"), true);
					this.ShowControl(string.Concat("btn", controlSection, "ItemUnlock"), false);
					if (item != null && (!this.InvokeRequired || item.DataSource == null))
					{
						int idIndexInNames = this.getIdIndexInNames(selectedItem.itemID, "All");
						if (idIndexInNames < 0)
						{
							item.DataSource = null;
							try
							{
								item.Items.Clear();
								item.Items.Add(selectedItem.itemName);
								item.Text = selectedItem.itemName;
							}
							catch (Exception exception)
							{
							}
							item.Enabled = true;
							return;
						}
						item.DataSource = null;
						try
						{
							item.Items.Clear();
							item.DataSource = this.names["All"];
							item.SelectedIndex = idIndexInNames;
						}
						catch (Exception exception1)
						{
						}
						item.Enabled = true;
					}
				}
			}
		}

		private void btnItemUpdate_Click(object sender, EventArgs e)
		{
			string controlSection = App.getControlSection((Button)sender);
			if (controlSection != "")
			{
				ListBox listBox = (ListBox)this.findControl(string.Concat("lst", controlSection));
				if (listBox != null && listBox.SelectedItem != null && listBox.SelectedItem.GetType() == typeof(itemdata))
				{
					itemdata selectedItem = (itemdata)listBox.SelectedItem;
					TextBox textBox = (TextBox)this.findControl(string.Concat("txt", controlSection, "ItemID"));
					TextBox textBox1 = (TextBox)this.findControl(string.Concat("txt", controlSection, "ItemQtDur"));
					TextBox textBox2 = (TextBox)this.findControl(string.Concat("txt", controlSection, "ItemBonusType"));
					TextBox textBox3 = (TextBox)this.findControl(string.Concat("txt", controlSection, "ItemBonusValue"));
					ComboBox comboBox = (ComboBox)this.findControl(string.Concat("cb", controlSection, "ItemBonusType"));
					byte[] numArray = new byte[selectedItem.itemID.Length];
					Array.Clear(numArray, 0, (int)numArray.Length);
					byte[] bytes = Encoding.ASCII.GetBytes(textBox.Text.Trim());
					this.mem.SetInt32At(selectedItem.itemQtDurAddress, App.StringToInt32(textBox1.Text));
					if (textBox2 != null && textBox2.Visible)
					{
						this.mem.SetUInt32At(selectedItem.itemBonusTypeAddress, App.StringToUInt32(textBox2.Text));
					}
					else if (comboBox != null && comboBox.Visible)
					{
						Bonus bonu = (Bonus)comboBox.SelectedItem;
						if (bonu.type != Bonus.BonusTypeValue.A_UNKNOWN)
						{
							this.mem.SetUInt32At(selectedItem.itemBonusTypeAddress, (uint)bonu.type);
						}
					}
					this.mem.SetInt32At(selectedItem.itemBonusValueAddress, App.StringToInt32(textBox3.Text));
					this.mem.SetBytesAt(selectedItem.itemAddress + (long)1, numArray, (int)numArray.Length);
					this.mem.SetBytesAt(selectedItem.itemAddress + (long)1, bytes, (int)bytes.Length);
					this.mem.SetByteAt(selectedItem.itemAddress + (long)1 + (long)((int)bytes.Length), 0);
					selectedItem.itemID = this.mem.GetStringAt(selectedItem.itemAddress + (long)1);
					this.updateItems(this.items.ToList<itemdata>());
					this.refreshSelectedIndex(controlSection);
				}
			}
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

		private void btnUpdateRupees_Click(object sender, EventArgs e)
		{
			if (this.GetRupees() < 0)
			{
				this.SetTextBoxText(this.frmMain.txtRupees, "");
				this.EnableControl("gbRupees", false);
				return;
			}
			this.SetRupees(App.StringToInt32(this.frmMain.txtRupees.Text));
			int rupees = this.GetRupees();
			this.SetTextBoxText(this.frmMain.txtRupees, rupees.ToString());
		}

		private void cbActionsList_SelectedIndexChanged(object sender, EventArgs e)
		{
			ComboBox comboBox = (ComboBox)sender;
			if (comboBox.Items.Count == 0)
			{
				return;
			}
			actiondata selectedItem = (actiondata)this.frmMain.lstActionsRegistered.SelectedItem;
			if (selectedItem != null)
			{
				selectedItem.type = (ActionType)((byte)comboBox.SelectedIndex);
				BindingSource dataSource = (BindingSource)this.frmMain.lstActionsRegistered.DataSource;
				if (dataSource != null && dataSource.Current != null)
				{
					dataSource.ResetCurrentItem();
				}
				this.updateCurrentAction();
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

		private void chkActionsActiveInactive_CheckedChanged(object sender, EventArgs e)
		{
			this.updateCurrentAction();
		}

		private void chkActionsDisableWhenDone_CheckedChanged(object sender, EventArgs e)
		{
			this.updateCurrentAction();
		}

		private void chkActionsUseHotKey_CheckedChanged(object sender, EventArgs e)
		{
			this.updateCurrentAction();
		}

		private void chkUseHotKey_CheckedChanged(object sender, EventArgs e)
		{
			CheckBox checkBox = (CheckBox)sender;
			if (!checkBox.Checked)
			{
				string str = checkBox.Name.Replace("chk", "").Replace("UseHotkey", "");
				TextBox textBox = (TextBox)this.findControl(string.Concat("txt", str, "HotKey"));
				if (textBox != null && textBox.GetType() == typeof(TextBox) && textBox.Text != "")
				{
					this.TextControl(string.Concat("txt", str, "HotKey"), "");
				}
			}
		}

		public void compareMemory(string fileName)
		{
			this.memoryChanges.Clear();
			this.Putlog(string.Concat("Trying to load dump file '", fileName, "'..."));
			long length = (long)0;
			if (!File.Exists(fileName))
			{
				this.Putlog(string.Concat("Dump file '", fileName, "' not found!"));
				return;
			}
			this.Putlog(string.Concat("Found dump file '", fileName, "'."));
			length = (new FileInfo(fileName)).Length;
			this.Putlog(string.Concat("Trying to load process '", this.mem.ProcessName, "'..."));
			this.mem.UpdateProcess("");
			if (this.mem.p == null)
			{
				this.Putlog(string.Concat("Process '", this.mem.ProcessName, "' not found !"));
				return;
			}
			if (!this.mem.CheckOpenProcess())
			{
				this.Putlog("Could not open process with desired access flags...");
				return;
			}
			this.Putlog("Process found, scanning memory...");
			long num = (long)0;
			long num1 = (long)0;
			long num2 = (long)1416757248;
			long num3 = (long)1441923072;
			if (!this.mem.FindRegionBySize(num2, out num, out num1, IntPtr.Zero, (long)0, true) || num <= (long)0)
			{
				if (!this.mem.FindRegionBySize(num3, out num, out num1, IntPtr.Zero, (long)0, true) || num <= (long)0)
				{
					this.Putlog("Memory region not found, need some thinking ?");
					return;
				}
			}
			else
			{
			}
			long num4 = num;
			long num5 = num + num1;
			this.Putlog(string.Concat("Memory region start : ", num4.ToString("X")));
			this.Putlog(string.Concat("Memory region end : ", num5.ToString("X")));
			if (num1 != length)
			{
				this.Putlog("Dump size is not equal to memory region size !");
				return;
			}
			this.Putlog(string.Concat("Starting Memory Comparison between Memory Dump and Process '", this.mem.ProcessName, "'..."));
			using (BinaryReader binaryReader = new BinaryReader(File.OpenRead(fileName)))
			{
				if (this.mem.OpenProcessHandle())
				{
					int num6 = 131072;
					byte[] numArray = new byte[num6];
					byte[] numArray1 = new byte[num6];
					int num7 = 0;
					int num8 = 0;
					int num9 = 0;
					while (true)
					{
						int num10 = binaryReader.Read(numArray, 0, num6);
						num7 = num10;
						if (num10 <= 0)
						{
							break;
						}
						MemAPI.ReadBytes(num4 + (long)num9, numArray1, num7, this.mem.p, this.mem.Handle);
						for (int i = 0; i < num7; i++)
						{
							if (numArray[i] != numArray1[i])
							{
								long num11 = num4 + (long)num9 + (long)i;
								this.Putlog(string.Concat("Changes found at address 0x", num11.ToString("X")));
								this.Putlog(string.Concat("Byte value changed from 0x", numArray[i].ToString("X"), " to 0x", numArray1[i].ToString("X")));
								num8++;
								int num12 = 13;
								MemoryChange memoryChange = new MemoryChange()
								{
									regionStart = num4,
									regionSize = num5 - num4,
									address = num4 + (long)num9 + (long)i,
									oldValue = numArray[i],
									newValue = numArray1[i]
								};
								int num13 = -1 * num12 * 16;
								MemAPI.ReadBytes(memoryChange.address + (long)num13, memoryChange.newBuffer, 16 * (num12 * 2 + 1), this.mem.p, this.mem.Handle);
								this.ReadBytesFromFile(fileName, memoryChange.oldBuffer, (long)(num9 + i + num13), 16 * (num12 * 2 + 1));
								this.memoryChanges.Add(memoryChange);
							}
						}
						num9 = num9 + num7;
					}
					binaryReader.Close();
					this.Putlog(string.Concat(new object[] { "Total bytes read from ", fileName, " : ", num9 }));
					this.Putlog(string.Concat("Total bytes changes : ", num8));
				}
				this.mem.CloseProcessHandle();
			}
			this.Putlog("Memory Comparison done.");
		}

		public actiondata createActionData(string action_section)
		{
			bool flag;
			actiondata actiondatum = new actiondata();
			if (Array.IndexOf<string>(App.ACTION_SECTIONS, action_section) > -1)
			{
				RadioButton radioButton = (RadioButton)this.findControl(string.Concat("option", action_section, "Fixed"));
				RadioButton radioButton1 = (RadioButton)this.findControl(string.Concat("option", action_section, "Timer"));
				RadioButton radioButton2 = (RadioButton)this.findControl(string.Concat("option", action_section, "NoFilter"));
				RadioButton radioButton3 = (RadioButton)this.findControl(string.Concat("option", action_section, "FilterList"));
				ListBox listBox = (ListBox)this.findControl(string.Concat("lst", action_section, "Filter"));
				CheckBox checkBox = (CheckBox)this.findControl(string.Concat("chk", action_section, "DisableWhenDone"));
				CheckBox checkBox1 = (CheckBox)this.findControl(string.Concat("chk", action_section, "UseHotkey"));
				CheckBox checkBox2 = (CheckBox)this.findControl(string.Concat("chk", action_section, "ActiveInactive"));
				TextBox textBox = (TextBox)this.findControl(string.Concat("txt", action_section, "Fixed"));
				TextBox textBox1 = (TextBox)this.findControl(string.Concat("txt", action_section, "Timer"));
				TextBox textBox2 = (TextBox)this.findControl(string.Concat("txt", action_section, "Quantity"));
				TextBox textBox3 = (TextBox)this.findControl(string.Concat("txt", action_section, "Max"));
				TextBox textBox4 = (TextBox)this.findControl(string.Concat("txt", action_section, "HotKey"));
				actiondatum.type = ActionType.NEW;
				actiondatum.mode = (radioButton.Checked ? ActionMode.FIXED : ActionMode.TIMER);
				actiondatum.UseFilter = (radioButton2.Checked ? false : true);
				actiondatum.StopWhenDone = (checkBox.Checked ? true : false);
				actiondatum.UseHotKey = (checkBox1.Checked ? true : false);
				actiondatum.Active = (checkBox2.Checked ? true : false);
				actiondatum.fixedValue = (textBox.Text.Trim().Length == 0 ? -1 : App.StringToInt32(textBox.Text.Trim()));
				actiondatum.timerSec = (textBox1.Text.Trim().Length == 0 ? -1 : App.StringToInt32(textBox1.Text.Trim()));
				actiondatum.timerQt = (textBox2.Text.Trim().Length == 0 ? -1 : App.StringToInt32(textBox2.Text.Trim()));
				actiondatum.timerMax = (textBox3.Text.Trim().Length == 0 ? -1 : App.StringToInt32(textBox3.Text.Trim()));
				actiondatum.hotKey = textBox4.Text;
				BindingSource dataSource = (BindingSource)listBox.DataSource;
				if (!(dataSource != null & dataSource.DataSource != null))
				{
					actiondatum.filterList = null;
				}
				else
				{
					actiondatum.filterList = (BList<itemdata>)dataSource.DataSource;
				}
			}
			else if (Array.IndexOf<string>(App.EXTENDED_ACTION_SECTIONS, action_section) > -1)
			{
				CheckBox checkBox3 = (CheckBox)this.findControl(string.Concat("chk", action_section, "Set"));
				CheckBox checkBox4 = (CheckBox)this.findControl(string.Concat("chk", action_section, "UseHotkey"));
				TextBox textBox5 = (TextBox)this.findControl(string.Concat("txt", action_section, "HotKey"));
				RadioButton radioButton4 = this.frmMain.optionUnbreakableNoFilter;
				RadioButton radioButton5 = this.frmMain.optionUnbreakableFilterList;
				ListBox listBox1 = this.frmMain.lstUnbreakableFilter;
				actiondatum.UseFilter = (radioButton4.Checked ? false : true);
				actiondatum.type = ActionType.NEW;
				actiondatum.mode = ActionMode.FIXED;
				actiondatum.section = action_section;
				actiondata actiondatum1 = actiondatum;
				if (checkBox3 != null)
				{
					flag = (checkBox3.Checked ? true : false);
				}
				else
				{
					flag = false;
				}
				actiondatum1.Active = flag;
				actiondatum.UseHotKey = (checkBox4.Checked ? true : false);
				actiondatum.hotKey = textBox5.Text;
				actiondatum.fixedValue = 0;
				BindingSource bindingSources = (BindingSource)listBox1.DataSource;
				if (!(bindingSources != null & bindingSources.DataSource != null))
				{
					actiondatum.filterList = null;
				}
				else
				{
					actiondatum.filterList = (BList<itemdata>)bindingSources.DataSource;
				}
			}
			return actiondatum;
		}

		private BindingSource CreateBindingSource<T>(BindingList<T> list)
		{
			return new BindingSource()
			{
				DataSource = list
			};
		}

		public void dumpMemoryToFile(string fileName)
		{
			this.Putlog(string.Concat("Trying to dump process '", this.mem.ProcessName, "'..."));
			this.mem.UpdateProcess("");
			if (this.mem.p == null)
			{
				this.Putlog(string.Concat("Process '", this.mem.ProcessName, "' not found !"));
				return;
			}
			if (!this.mem.CheckOpenProcess())
			{
				this.Putlog("Could not open process with desired access flags...");
				return;
			}
			this.Putlog("Process found, scanning memory...");
			long num = (long)0;
			long num1 = (long)0;
			long num2 = (long)1416757248;
			long num3 = (long)1441923072;
			if (!this.mem.FindRegionBySize(num2, out num, out num1, IntPtr.Zero, (long)0, true) || num <= (long)0)
			{
				if (!this.mem.FindRegionBySize(num3, out num, out num1, IntPtr.Zero, (long)0, true) || num <= (long)0)
				{
					this.Putlog("Memory region not found, need some thinking ?");
					return;
				}
			}
			else
			{
			}
			long num4 = num;
			long num5 = num + num1;
			this.Putlog(string.Concat("Memory region start : ", num4.ToString("X")));
			this.Putlog(string.Concat("Memory region end : ", num5.ToString("X")));
			BinaryWriter binaryWriter = null;
			this.Putlog(string.Concat(new string[] { "Starting to dump memory to '", fileName, "' from process ", this.mem.ProcessName, "'..." }));
			if (this.mem.OpenProcessHandle())
			{
				int num6 = 32768;
				byte[] numArray = new byte[num6];
				int num7 = 0;
				int num8 = 0;
				for (long i = num4; i <= num5 - (long)num6; i = i + (long)num6)
				{
					num7 = MemAPI.ReadBytes(i, numArray, num6, this.mem.p, this.mem.Handle);
					num8 = num8 + num7;
					if (binaryWriter == null)
					{
						binaryWriter = new BinaryWriter(File.OpenWrite(fileName));
					}
					binaryWriter.Write(numArray, 0, num7);
					binaryWriter.Flush();
				}
				if (binaryWriter != null)
				{
					binaryWriter.Close();
					binaryWriter.Dispose();
					binaryWriter = null;
				}
				this.Putlog(string.Concat(new object[] { "Total bytes written to ", fileName, " : ", num8 }));
			}
			this.mem.CloseProcessHandle();
			this.Putlog("Dump terminated.");
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

		public void enableStaminaBar(bool enable = true)
		{
			if (this.inventoryStartAddress == (long)-1)
			{
				return;
			}
			this.Putlog("Scanning memory...");
			long num = this.findNoStaminaBarAddress(enable);
			byte[] numArray = new byte[] { 69, 15, 56, 241, 116, 5, 104 };
			byte[] numArray1 = new byte[] { 144, 144, 144, 144, 144, 144, 144 };
			if (num <= (long)0)
			{
				this.Putlog("Not found.");
				return;
			}
			this.mem.SetBytesAt(num, (enable ? numArray : numArray1), 7);
			this.Putlog(string.Concat("Stamina bar ", (enable ? "enabled" : "disabled"), "."));
		}

		public void executeActionData(actiondata ad, bool force = false)
		{
			long num;
			long num1;
			long num2;
			long num3;
			long num4;
			long num5;
			long num6;
			long num7;
			long num8;
			long num9;
			long num10;
			long num11;
			long num12;
			long num13;
			long num14;
			long num15;
			long num16;
			long num17;
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
			DateTime now = DateTime.Now;
			TimeSpan timeSpan = now.Subtract(new DateTime(1970, 1, 9, 0, 0, 0));
			double totalSeconds = timeSpan.TotalSeconds;
			if (force || ad.mode == ActionMode.TIMER && totalSeconds - ad.timeLast >= (double)ad.timerSec || ad.mode == ActionMode.FIXED)
			{
				if (ad.section != "")
				{
					if (Array.IndexOf<string>(App.ACTION_SECTIONS, ad.section) > -1)
					{
						string str = ad.section;
						if (ad.section == "Bows" || ad.section == "Arrows")
						{
							str = "Archery";
						}
						if (this.lists.ContainsKey(str))
						{
							bool flag = true;
							if (ad.Active)
							{
								if (ad.counter == (long)-1)
								{
									this.Putlog(string.Concat("[Restore ", ad.section, "] Enabled."));
									ad.counter = (long)0;
								}
								foreach (itemdata item in this.lists[str])
								{
									if (item.isWeaponBowShield && this.findItemByAddr(item.itemAddress, this.equipped.ToList<itemdata>()) != null || ad.section == "Arrows" && !item.itemID.Contains("Arrow") || ad.section != "Arrows" && item.itemID.Contains("Arrow") || ad.UseFilter && this.findItemByID(item.itemID, ad.filterList.ToList<itemdata>()) == null || ad.mode == ActionMode.FIXED && !ad.HiddenTimerElapsed())
									{
										continue;
									}
									if (ad.mode != ActionMode.FIXED)
									{
										if (ad.mode != ActionMode.TIMER)
										{
											continue;
										}
										int int32At = this.mem.GetInt32At(item.itemQtDurAddress);
										if (int32At < ad.timerMax)
										{
											this.mem.SetInt32At(item.itemQtDurAddress, int32At + (int32At + ad.timerQt <= ad.timerMax ? ad.timerQt : ad.timerMax - int32At));
											actiondata actiondatum = ad;
											actiondatum.counter = actiondatum.counter + (long)1;
										}
										if (int32At + ad.timerQt >= ad.timerMax)
										{
											continue;
										}
										flag = false;
									}
									else
									{
										ad.HiddenTimerSec = 2;
										this.mem.SetInt32At(item.itemQtDurAddress, ad.fixedValue);
										ad.HiddenTimerTick();
										actiondata actiondatum1 = ad;
										actiondatum1.counter = actiondatum1.counter + (long)1;
									}
								}
							}
							if (ad.Active & flag && ad.StopWhenDone)
							{
								this.Putlog(string.Concat("[", ad.section, "] Auto restore stopped."));
								this.CheckControl(string.Concat("chk", ad.section, "ActiveInactive"), false);
								ad.Active = false;
							}
							if (!ad.Active && ad.counter >= (long)0)
							{
								ad.counter = (long)-1;
								this.Putlog(string.Concat("[Restore ", ad.section, "] Disabled."));
							}
						}
					}
					else if (Array.IndexOf<string>(App.EXTENDED_ACTION_SECTIONS, ad.section) > -1)
					{
						if (ad.section == "LockHealth")
						{
							if (!ad.Active)
							{
								this.TextControl(string.Concat("lbl", ad.section, "Info"), "");
								if (ad.fixedValue > 0)
								{
									this.healthAddress = (long)-1;
									this.Putlog(string.Concat("[", ad.section, "] Disabled."));
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
							if (this.healthAddress == (long)-1)
							{
								if (this.mem.FindRegionByAddr(this.inventoryStartAddress, out num, out num1, IntPtr.Zero, true))
								{
									long num18 = num + num1;
									if (this.inventoryStartAddress > (long)0)
									{
										num18 = this.inventoryStartAddress;
									}
									if (this.speedHackAddress > (long)0)
									{
										num18 = this.speedHackAddress;
									}
									if (this.coordinatesAddress > (long)0)
									{
										num = this.coordinatesAddress;
									}
									if (this.rupeesAddress > (long)0)
									{
										num = this.rupeesAddress;
									}
									if (this.weaponsSlotsAddress > (long)0)
									{
										num = this.weaponsSlotsAddress;
									}
									if (this.bowsSlotsAddress > (long)0)
									{
										num = this.bowsSlotsAddress;
									}
									if (this.shieldsSlotsAddress > (long)0)
									{
										num = this.shieldsSlotsAddress;
									}
									num1 = num18 - num;
									this.TextControl(string.Concat("lbl", ad.section, "Info"), "Scanning memory...");
									this.Putlog(string.Concat("[", ad.section, "] Scanning memory..."));
									this.healthAddress = this.findHealthAddress(num, num1);
									if (this.healthAddress < (long)0)
									{
										this.TextControl(string.Concat("lbl", ad.section, "Info"), "Could not find offset");
										this.Putlog(string.Concat("[", ad.section, "] Could not find offset"));
										this.CheckControl(string.Concat("chk", ad.section, "Set"), false);
										ad.timerSec = 2;
									}
									else
									{
										this.TextControl(string.Concat("lbl", ad.section, "Info"), string.Concat("Found offset at 0x", this.healthAddress.ToString("X")));
										this.Putlog(string.Concat("[", ad.section, "] Found offset at 0x", this.healthAddress.ToString("X")));
										ad.fixedValue = this.mem.GetInt32At(this.healthAddress);
									}
								}
							}
							else if (ad.fixedValue > 0)
							{
								this.mem.SetInt32At(this.healthAddress, ad.fixedValue);
							}
							else
							{
								ad.timerSec = 2;
								ad.fixedValue = 0;
								this.healthAddress = (long)-1;
								this.Putlog(string.Concat(new object[] { "[", ad.section, "] Warning ! Null or Negative value : ", ad.fixedValue }));
							}
						}
						if (ad.section == "LockStamina")
						{
							if (!ad.Active)
							{
								this.TextControl(string.Concat("lbl", ad.section, "Info"), "");
								if (ad.fixedValue > 0)
								{
									this.staminaAddress = (long)-1;
									this.Putlog(string.Concat("[", ad.section, "] Disabled."));
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
							if (this.staminaAddress == (long)-1)
							{
								if (this.mem.FindRegionByAddr(this.inventoryStartAddress, out num2, out num3, IntPtr.Zero, true))
								{
									long num19 = num2 + num3;
									if (this.inventoryStartAddress > (long)0)
									{
										num19 = this.inventoryStartAddress;
									}
									if (this.speedHackAddress > (long)0)
									{
										num19 = this.speedHackAddress;
									}
									if (this.coordinatesAddress > (long)0)
									{
										num2 = this.coordinatesAddress;
									}
									if (this.rupeesAddress > (long)0)
									{
										num2 = this.rupeesAddress;
									}
									if (this.weaponsSlotsAddress > (long)0)
									{
										num2 = this.weaponsSlotsAddress;
									}
									if (this.bowsSlotsAddress > (long)0)
									{
										num2 = this.bowsSlotsAddress;
									}
									if (this.shieldsSlotsAddress > (long)0)
									{
										num2 = this.shieldsSlotsAddress;
									}
									num3 = num19 - num2;
									this.TextControl(string.Concat("lbl", ad.section, "Info"), "Scanning memory...");
									this.Putlog(string.Concat("[", ad.section, "] Scanning memory..."));
									this.staminaAddress = this.findStaminaAddress(num2, num3);
									if (this.staminaAddress < (long)0)
									{
										this.TextControl(string.Concat("lbl", ad.section, "Info"), "Could not find offset");
										this.Putlog(string.Concat("[", ad.section, "] Could not find offset"));
										this.CheckControl(string.Concat("chk", ad.section, "Set"), false);
										ad.timerSec = 2;
									}
									else
									{
										this.TextControl(string.Concat("lbl", ad.section, "Info"), string.Concat("Found offset at 0x", this.staminaAddress.ToString("X")));
										this.Putlog(string.Concat("[", ad.section, "] Found offset at 0x", this.staminaAddress.ToString("X")));
										ad.fixedValue = this.mem.GetInt32At(this.staminaAddress);
									}
								}
							}
							else if (ad.fixedValue > 0)
							{
								this.mem.SetInt32At(this.staminaAddress, ad.fixedValue);
							}
							else
							{
								ad.timerSec = 2;
								ad.fixedValue = 0;
								this.staminaAddress = (long)-1;
								this.Putlog(string.Concat(new object[] { "[", ad.section, "] Warning ! Null or Negative value : ", ad.fixedValue }));
							}
						}
						if (ad.section == "UnbreakableWeapons")
						{
							if (!ad.Active)
							{
								this.TextControl(string.Concat("lbl", ad.section, "Info"), "");
								if (ad.fixedValue > 0)
								{
									this.equippedWeaponDurabilityAddress = (long)-1;
									this.Putlog(string.Concat("[", ad.section, "] Disabled."));
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
							if (this.equippedWeaponDurabilityAddress == (long)-1)
							{
								foreach (itemdata list in this.equipped.ToList<itemdata>())
								{
									if (!list.isWeapon)
									{
										continue;
									}
									this.TextControl(string.Concat("lbl", ad.section, "Info"), "Scanning memory...");
									this.Putlog(string.Concat("[", ad.section, "] Scanning memory..."));
									this.equippedWeaponDurabilityAddress = this.findEquippedDurabilityAddress(list);
									if (this.equippedWeaponDurabilityAddress < (long)0)
									{
										this.TextControl(string.Concat("lbl", ad.section, "Info"), "Could not find offset");
										this.Putlog(string.Concat("[", ad.section, "] Could not find offset"));
										ad.timerSec = 2;
									}
									else
									{
										this.TextControl(string.Concat("lbl", ad.section, "Info"), string.Concat("Found offset at 0x", this.equippedWeaponDurabilityAddress.ToString("X")));
										this.Putlog(string.Concat("[", ad.section, "] Found offset at 0x", this.equippedWeaponDurabilityAddress.ToString("X")));
										ad.fixedValue = this.mem.GetInt32At(this.equippedWeaponDurabilityAddress);
										if (ad.fixedValue >= 1000)
										{
											continue;
										}
										ad.fixedValue = 7777;
										if (ad.UseFilter && this.findItemByID(list.itemID, ad.filterList.ToList<itemdata>()) == null)
										{
											continue;
										}
										this.mem.SetInt32At(this.equippedWeaponDurabilityAddress, ad.fixedValue);
										this.mem.SetInt32At(list.itemQtDurAddress, ad.fixedValue);
									}
								}
							}
							else if (ad.fixedValue > 0)
							{
								itemdata equippedWeapon = this.getEquippedWeapon();
								if (equippedWeapon != null && (!ad.UseFilter || this.findItemByID(equippedWeapon.itemID, ad.filterList.ToList<itemdata>()) != null))
								{
									this.mem.SetInt32At(this.equippedWeaponDurabilityAddress, ad.fixedValue);
									this.mem.SetInt32At(equippedWeapon.itemQtDurAddress, ad.fixedValue);
								}
							}
							else
							{
								ad.timerSec = 2;
								ad.fixedValue = 0;
								this.equippedWeaponDurabilityAddress = (long)-1;
							}
						}
						if (ad.section == "UnbreakableBows")
						{
							if (!ad.Active)
							{
								this.TextControl(string.Concat("lbl", ad.section, "Info"), "");
								if (ad.fixedValue > 0)
								{
									this.equippedBowDurabilityAddress = (long)-1;
									this.Putlog(string.Concat("[", ad.section, "] Disabled."));
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
							if (this.equippedBowDurabilityAddress == (long)-1)
							{
								foreach (itemdata itemdatum in this.equipped)
								{
									if (!itemdatum.isBow)
									{
										continue;
									}
									this.TextControl(string.Concat("lbl", ad.section, "Info"), "Scanning memory...");
									this.Putlog(string.Concat("[", ad.section, "] Scanning memory..."));
									this.equippedBowDurabilityAddress = this.findEquippedDurabilityAddress(itemdatum);
									if (this.equippedBowDurabilityAddress < (long)0)
									{
										this.TextControl(string.Concat("lbl", ad.section, "Info"), "Could not find offset");
										this.Putlog(string.Concat("[", ad.section, "] Could not find offset"));
										ad.timerSec = 2;
									}
									else
									{
										this.TextControl(string.Concat("lbl", ad.section, "Info"), string.Concat("Found offset at 0x", this.equippedBowDurabilityAddress.ToString("X")));
										this.Putlog(string.Concat("[", ad.section, "] Found offset at 0x", this.equippedBowDurabilityAddress.ToString("X")));
										ad.fixedValue = this.mem.GetInt32At(this.equippedBowDurabilityAddress);
										if (ad.fixedValue >= 1000)
										{
											continue;
										}
										ad.fixedValue = 7776;
										if (ad.UseFilter && this.findItemByID(itemdatum.itemID, ad.filterList.ToList<itemdata>()) == null)
										{
											continue;
										}
										this.mem.SetInt32At(this.equippedBowDurabilityAddress, ad.fixedValue);
										this.mem.SetInt32At(itemdatum.itemQtDurAddress, ad.fixedValue);
									}
								}
							}
							else if (ad.fixedValue > 0)
							{
								itemdata equippedBow = this.getEquippedBow();
								if (equippedBow != null && (!ad.UseFilter || this.findItemByID(equippedBow.itemID, ad.filterList.ToList<itemdata>()) != null))
								{
									this.mem.SetInt32At(this.equippedBowDurabilityAddress, ad.fixedValue);
									this.mem.SetInt32At(equippedBow.itemQtDurAddress, ad.fixedValue);
								}
							}
							else
							{
								ad.timerSec = 2;
								ad.fixedValue = 0;
								this.equippedBowDurabilityAddress = (long)-1;
							}
						}
						if (ad.section == "UnbreakableShields")
						{
							if (!ad.Active)
							{
								this.TextControl(string.Concat("lbl", ad.section, "Info"), "");
								if (ad.fixedValue > 0)
								{
									this.equippedShieldDurabilityAddress = (long)-1;
									this.Putlog(string.Concat("[", ad.section, "] Disabled."));
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
							if (this.equippedShieldDurabilityAddress == (long)-1)
							{
								foreach (itemdata itemdatum1 in this.equipped)
								{
									if (!itemdatum1.isShield)
									{
										continue;
									}
									this.TextControl(string.Concat("lbl", ad.section, "Info"), "Scanning memory...");
									this.Putlog(string.Concat("[", ad.section, "] Scanning memory..."));
									this.equippedShieldDurabilityAddress = this.findEquippedDurabilityAddress(itemdatum1);
									if (this.equippedShieldDurabilityAddress < (long)0)
									{
										this.TextControl(string.Concat("lbl", ad.section, "Info"), "Could not find offset");
										this.Putlog(string.Concat("[", ad.section, "] Could not find offset"));
										ad.timerSec = 2;
									}
									else
									{
										this.TextControl(string.Concat("lbl", ad.section, "Info"), string.Concat("Found offset at 0x", this.equippedShieldDurabilityAddress.ToString("X")));
										this.Putlog(string.Concat("[", ad.section, "] Found offset at 0x", this.equippedShieldDurabilityAddress.ToString("X")));
										ad.fixedValue = this.mem.GetInt32At(this.equippedShieldDurabilityAddress);
										if (ad.fixedValue >= 1000)
										{
											continue;
										}
										ad.fixedValue = 7775;
										if (ad.UseFilter && this.findItemByID(itemdatum1.itemID, ad.filterList.ToList<itemdata>()) == null)
										{
											continue;
										}
										this.mem.SetInt32At(this.equippedShieldDurabilityAddress, ad.fixedValue);
										this.mem.SetInt32At(itemdatum1.itemQtDurAddress, ad.fixedValue);
									}
								}
							}
							else if (ad.fixedValue > 0)
							{
								itemdata equippedShield = this.getEquippedShield();
								if (equippedShield != null && (!ad.UseFilter || this.findItemByID(equippedShield.itemID, ad.filterList.ToList<itemdata>()) != null))
								{
									this.mem.SetInt32At(this.equippedShieldDurabilityAddress, ad.fixedValue);
									this.mem.SetInt32At(equippedShield.itemQtDurAddress, ad.fixedValue);
								}
							}
							else
							{
								ad.timerSec = 2;
								ad.fixedValue = 0;
								this.equippedShieldDurabilityAddress = (long)-1;
							}
						}
						if (ad.section == "PowersMipha")
						{
							if (!ad.Active)
							{
								this.TextControl(string.Concat("lbl", ad.section, "Info"), "");
								if (ad.fixedValue > 0)
								{
									this.divinePowerMiphaTimerAddress = (long)-1;
									this.Putlog(string.Concat("[", ad.section, "] Disabled."));
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
							if (this.divinePowerMiphaTimerAddress == (long)-1)
							{
								if (this.mem.FindRegionByAddr(this.inventoryStartAddress, out num4, out num5, IntPtr.Zero, true))
								{
									this.TextControl(string.Concat("lbl", ad.section, "Info"), "Scanning memory...");
									this.Putlog(string.Concat("[", ad.section, "] Scanning memory..."));
									int num20 = 324;
									long num21 = (long)-1;
									long num22 = (long)-1;
									if (this.divinePowerMiphaTimerAddress != (long)-1)
									{
										num22 = this.divinePowerMiphaTimerAddress - (long)324;
									}
									if (this.divinePowerRevaliAddress != (long)-1)
									{
										num22 = this.divinePowerRevaliAddress;
									}
									if (this.divinePowerUrbosaAddress != (long)-1)
									{
										num22 = this.divinePowerUrbosaAddress - (long)4;
									}
									if (this.divinePowerDarukAddress != (long)-1)
									{
										num22 = this.divinePowerDarukAddress - (long)8;
									}
									num21 = (num22 == (long)-1 ? this.findPowersAddress(num4, this.inventoryStartAddress - num4) : num22);
									if (num21 < (long)0)
									{
										this.divinePowerMiphaTimerAddress = (long)-1;
										this.TextControl(string.Concat("lbl", ad.section, "Info"), "Could not find offset");
										this.Putlog(string.Concat("[", ad.section, "] Could not find offset"));
										this.CheckControl(string.Concat("chk", ad.section, "Set"), false);
										ad.timerSec = 2;
									}
									else
									{
										this.divinePowerMiphaTimerAddress = num21 + (long)num20;
										this.TextControl(string.Concat("lbl", ad.section, "Info"), string.Concat("Found offset at 0x", this.divinePowerMiphaTimerAddress.ToString("X")));
										this.Putlog(string.Concat("[", ad.section, "] Found offset at 0x", this.divinePowerMiphaTimerAddress.ToString("X")));
										ad.fixedValue = 65;
									}
								}
							}
							else if (ad.fixedValue > 0)
							{
								if (this.mem.GetByteAt(this.divinePowerMiphaTimerAddress) < 190)
								{
									this.mem.SetByteAt(this.divinePowerMiphaTimerAddress, (byte)ad.fixedValue);
								}
								ad.timerSec = 5;
							}
							else
							{
								ad.timerSec = 2;
								ad.fixedValue = 0;
								this.divinePowerMiphaTimerAddress = (long)-1;
							}
						}
						if (ad.section == "PowersRevali")
						{
							if (!ad.Active)
							{
								this.TextControl(string.Concat("lbl", ad.section, "Info"), "");
								if (ad.fixedValue > 0)
								{
									this.divinePowerRevaliAddress = (long)-1;
									this.Putlog(string.Concat("[", ad.section, "] Disabled."));
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
							if (this.divinePowerRevaliAddress == (long)-1)
							{
								if (this.mem.FindRegionByAddr(this.inventoryStartAddress, out num6, out num7, IntPtr.Zero, true))
								{
									this.TextControl(string.Concat("lbl", ad.section, "Info"), "Scanning memory...");
									this.Putlog(string.Concat("[", ad.section, "] Scanning memory..."));
									int num23 = 0;
									long num24 = (long)-1;
									long num25 = (long)-1;
									if (this.divinePowerMiphaTimerAddress != (long)-1)
									{
										num25 = this.divinePowerMiphaTimerAddress - (long)324;
									}
									if (this.divinePowerRevaliAddress != (long)-1)
									{
										num25 = this.divinePowerRevaliAddress;
									}
									if (this.divinePowerUrbosaAddress != (long)-1)
									{
										num25 = this.divinePowerUrbosaAddress - (long)4;
									}
									if (this.divinePowerDarukAddress != (long)-1)
									{
										num25 = this.divinePowerDarukAddress - (long)8;
									}
									num24 = (num25 == (long)-1 ? this.findPowersAddress(num6, this.inventoryStartAddress - num6) : num25);
									if (num24 < (long)0)
									{
										this.divinePowerRevaliAddress = (long)-1;
										this.TextControl(string.Concat("lbl", ad.section, "Info"), "Could not find offset");
										this.Putlog(string.Concat("[", ad.section, "] Could not find offset"));
										this.CheckControl(string.Concat("chk", ad.section, "Set"), false);
										ad.timerSec = 2;
									}
									else
									{
										this.divinePowerRevaliAddress = num24 + (long)num23;
										this.TextControl(string.Concat("lbl", ad.section, "Info"), string.Concat("Found offset at 0x", this.divinePowerRevaliAddress.ToString("X")));
										this.Putlog(string.Concat("[", ad.section, "] Found offset at 0x", this.divinePowerRevaliAddress.ToString("X")));
										ad.fixedValue = 99;
									}
								}
							}
							else if (ad.fixedValue > 0)
							{
								this.mem.SetInt32At(this.divinePowerRevaliAddress, ad.fixedValue);
								ad.timerSec = 5;
							}
							else
							{
								ad.timerSec = 2;
								ad.fixedValue = 0;
								this.divinePowerRevaliAddress = (long)-1;
							}
						}
						if (ad.section == "PowersUrbosa")
						{
							if (!ad.Active)
							{
								this.TextControl(string.Concat("lbl", ad.section, "Info"), "");
								if (ad.fixedValue > 0)
								{
									this.divinePowerUrbosaAddress = (long)-1;
									this.Putlog(string.Concat("[", ad.section, "] Disabled."));
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
							if (this.divinePowerUrbosaAddress == (long)-1)
							{
								if (this.mem.FindRegionByAddr(this.inventoryStartAddress, out num8, out num9, IntPtr.Zero, true))
								{
									this.TextControl(string.Concat("lbl", ad.section, "Info"), "Scanning memory...");
									this.Putlog(string.Concat("[", ad.section, "] Scanning memory..."));
									int num26 = 4;
									long num27 = (long)-1;
									long num28 = (long)-1;
									if (this.divinePowerMiphaTimerAddress != (long)-1)
									{
										num28 = this.divinePowerMiphaTimerAddress - (long)324;
									}
									if (this.divinePowerRevaliAddress != (long)-1)
									{
										num28 = this.divinePowerRevaliAddress;
									}
									if (this.divinePowerUrbosaAddress != (long)-1)
									{
										num28 = this.divinePowerUrbosaAddress - (long)4;
									}
									if (this.divinePowerDarukAddress != (long)-1)
									{
										num28 = this.divinePowerDarukAddress - (long)8;
									}
									num27 = (num28 == (long)-1 ? this.findPowersAddress(num8, this.inventoryStartAddress - num8) : num28);
									if (num27 < (long)0)
									{
										this.divinePowerUrbosaAddress = (long)-1;
										this.TextControl(string.Concat("lbl", ad.section, "Info"), "Could not find offset");
										this.Putlog(string.Concat("[", ad.section, "] Could not find offset"));
										this.CheckControl(string.Concat("chk", ad.section, "Set"), false);
										ad.timerSec = 2;
									}
									else
									{
										this.divinePowerUrbosaAddress = num27 + (long)num26;
										this.TextControl(string.Concat("lbl", ad.section, "Info"), string.Concat("Found offset at 0x", this.divinePowerUrbosaAddress.ToString("X")));
										this.Putlog(string.Concat("[", ad.section, "] Found offset at 0x", this.divinePowerUrbosaAddress.ToString("X")));
										ad.fixedValue = 99;
									}
								}
							}
							else if (ad.fixedValue > 0)
							{
								this.mem.SetInt32At(this.divinePowerUrbosaAddress, ad.fixedValue);
								ad.timerSec = 5;
							}
							else
							{
								ad.timerSec = 2;
								ad.fixedValue = 0;
								this.divinePowerUrbosaAddress = (long)-1;
							}
						}
						if (ad.section == "PowersDaruk")
						{
							if (!ad.Active)
							{
								this.TextControl(string.Concat("lbl", ad.section, "Info"), "");
								if (ad.fixedValue > 0)
								{
									this.divinePowerDarukAddress = (long)-1;
									this.Putlog(string.Concat("[", ad.section, "] Disabled."));
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
							if (this.divinePowerDarukAddress == (long)-1)
							{
								if (this.mem.FindRegionByAddr(this.inventoryStartAddress, out num10, out num11, IntPtr.Zero, true))
								{
									this.TextControl(string.Concat("lbl", ad.section, "Info"), "Scanning memory...");
									this.Putlog(string.Concat("[", ad.section, "] Scanning memory..."));
									int num29 = 8;
									long num30 = (long)-1;
									long num31 = (long)-1;
									if (this.divinePowerMiphaTimerAddress != (long)-1)
									{
										num31 = this.divinePowerMiphaTimerAddress - (long)324;
									}
									if (this.divinePowerRevaliAddress != (long)-1)
									{
										num31 = this.divinePowerRevaliAddress;
									}
									if (this.divinePowerUrbosaAddress != (long)-1)
									{
										num31 = this.divinePowerUrbosaAddress - (long)4;
									}
									if (this.divinePowerDarukAddress != (long)-1)
									{
										num31 = this.divinePowerDarukAddress - (long)8;
									}
									num30 = (num31 == (long)-1 ? this.findPowersAddress(num10, this.inventoryStartAddress - num10) : num31);
									if (num30 < (long)0)
									{
										this.divinePowerDarukAddress = (long)-1;
										this.TextControl(string.Concat("lbl", ad.section, "Info"), "Could not find offset");
										this.Putlog(string.Concat("[", ad.section, "] Could not find offset"));
										this.CheckControl(string.Concat("chk", ad.section, "Set"), false);
										ad.timerSec = 2;
									}
									else
									{
										this.divinePowerDarukAddress = num30 + (long)num29;
										this.TextControl(string.Concat("lbl", ad.section, "Info"), string.Concat("Found offset at 0x", this.divinePowerDarukAddress.ToString("X")));
										this.Putlog(string.Concat("[", ad.section, "] Found offset at 0x", this.divinePowerDarukAddress.ToString("X")));
										ad.fixedValue = 99;
									}
								}
							}
							else if (ad.fixedValue > 0)
							{
								this.mem.SetInt32At(this.divinePowerDarukAddress, ad.fixedValue);
								ad.timerSec = 5;
							}
							else
							{
								ad.timerSec = 2;
								ad.fixedValue = 0;
								this.divinePowerDarukAddress = (long)-1;
							}
						}
						if (ad.section == "UnlimitAmiibo")
						{
							if (!ad.Active)
							{
								this.TextControl(string.Concat("lbl", ad.section, "Info"), "");
								if (ad.fixedValue > 0)
								{
									if (this.amiiboDateAddress != (long)-1)
									{
										this.mem.SetInt32At(this.amiiboDateAddress, ad.fixedValue);
									}
									this.amiiboDateAddress = (long)-1;
									this.Putlog(string.Concat("[", ad.section, "] Disabled."));
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
							if (this.amiiboDateAddress == (long)-1)
							{
								if (this.mem.FindRegionByAddr(this.inventoryStartAddress, out num12, out num13, IntPtr.Zero, true))
								{
									this.TextControl(string.Concat("lbl", ad.section, "Info"), "Scanning memory...");
									this.Putlog(string.Concat("[", ad.section, "] Scanning memory..."));
									long num32 = this.findAmiiboDateAddress(num12, this.inventoryStartAddress - num12);
									if (num32 < (long)0)
									{
										this.amiiboDateAddress = (long)-1;
										this.TextControl(string.Concat("lbl", ad.section, "Info"), "Could not find offset");
										this.Putlog(string.Concat("[", ad.section, "] Could not find offset"));
										this.CheckControl(string.Concat("chk", ad.section, "Set"), false);
										ad.timerSec = 2;
									}
									else
									{
										this.amiiboDateAddress = num32;
										this.TextControl(string.Concat("lbl", ad.section, "Info"), string.Concat("Found offset at 0x", this.amiiboDateAddress.ToString("X")));
										this.Putlog(string.Concat("[", ad.section, "] Found offset at 0x", this.amiiboDateAddress.ToString("X")));
										ad.fixedValue = this.mem.GetInt32At(this.amiiboDateAddress);
									}
								}
							}
							else if (ad.fixedValue > 0)
							{
								this.mem.SetInt32At(this.amiiboDateAddress, 19700101);
								ad.timerSec = 5;
							}
							else
							{
								ad.timerSec = 2;
								ad.fixedValue = 0;
								this.amiiboDateAddress = (long)-1;
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
									this.Putlog(string.Concat("[", ad.section, "] Disabled."));
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
							if (this.lockedY != 0f)
							{
								this.mem.SetSingleAt(this.coordinatesAddress + (long)4, ad.singleValue);
							}
							else
							{
								this.lockedY = this.mem.GetSingleAt(this.coordinatesAddress + (long)4);
								ad.singleValue = this.lockedY;
								this.Putlog(string.Concat("[", ad.section, "] Locking Altitude (Y) to ", ad.singleValue.ToString()));
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
							this.UpdateRunSpeedMultiplier(1);
							ad.Active = false;
						}
					}
					ad.timeLast = totalSeconds;
					return;
				}
				if (!ad.Active)
				{
					if (ad.counter >= (long)0)
					{
						this.Putlog(string.Concat("[Restore ", ad.ToString(), "] Disabled."));
						ad.counter = (long)-1;
					}
					return;
				}
				if (ad.counter == (long)-1)
				{
					this.Putlog(string.Concat("[Restore ", ad.ToString(), "] Enabled."));
					ad.counter = (long)0;
				}
				string str1 = "";
				if (ad.type == ActionType.SET_BOWS_DUR)
				{
					str1 = "Archery";
				}
				if (ad.type == ActionType.SET_WEAPONS_DUR)
				{
					str1 = "Weapons";
				}
				if (ad.type == ActionType.SET_SHIELDS_DUR)
				{
					str1 = "Shields";
				}
				if (ad.type == ActionType.SET_ITEMS_QT)
				{
					str1 = "Inventory";
				}
				if (!(str1 != "") || !this.lists.ContainsKey(str1))
				{
					bool flag1 = true;
					if (ad.type == ActionType.SET_RUPEES && this.rupeesAddress >= (long)0)
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
							actiondata actiondatum2 = ad;
							actiondatum2.counter = actiondatum2.counter + (long)1;
						}
						else if (ad.mode == ActionMode.TIMER)
						{
							int int32At1 = this.mem.GetInt32At(this.rupeesAddress);
							if (int32At1 < ad.timerMax)
							{
								this.mem.SetInt32At(this.rupeesAddress, int32At1 + (int32At1 + ad.timerQt <= ad.timerMax ? ad.timerQt : ad.timerMax - int32At1));
								actiondata actiondatum3 = ad;
								actiondatum3.counter = actiondatum3.counter + (long)1;
							}
							if (int32At1 + ad.timerQt < ad.timerMax)
							{
								flag1 = false;
							}
						}
					}
					if (ad.type == ActionType.SET_HEALTH)
					{
						if (this.healthAddress < (long)0 && this.mem.FindRegionByAddr(this.inventoryStartAddress, out num14, out num15, IntPtr.Zero, true))
						{
							this.Putlog(string.Concat("[", ad.ToString(), "] Scanning memory..."));
							long num33 = this.findHealthAddress(num14, this.inventoryStartAddress - num14);
							if (num33 < (long)0)
							{
								this.Putlog(string.Concat("[", ad.ToString(), "] Could not find offset"));
							}
							else
							{
								this.Putlog(string.Concat("[", ad.ToString(), "] Found offset at 0x", num33.ToString("X")));
								this.healthAddress = num33;
							}
						}
						if (this.healthAddress >= (long)0)
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
								actiondata actiondatum4 = ad;
								actiondatum4.counter = actiondatum4.counter + (long)1;
							}
							else if (ad.mode == ActionMode.TIMER)
							{
								int int32At2 = this.mem.GetInt32At(this.healthAddress);
								if (int32At2 < ad.timerMax)
								{
									this.mem.SetInt32At(this.healthAddress, int32At2 + (int32At2 + ad.timerQt <= ad.timerMax ? ad.timerQt : ad.timerMax - int32At2));
									actiondata actiondatum5 = ad;
									actiondatum5.counter = actiondatum5.counter + (long)1;
								}
								if (int32At2 + ad.timerQt < ad.timerMax)
								{
									flag1 = false;
								}
							}
						}
					}
					if (ad.type == ActionType.SET_STAMINA)
					{
						if (this.staminaAddress < (long)0 && this.mem.FindRegionByAddr(this.inventoryStartAddress, out num16, out num17, IntPtr.Zero, true))
						{
							this.Putlog(string.Concat("[", ad.ToString(), "] Scanning memory..."));
							long num34 = this.findStaminaAddress(num16, this.inventoryStartAddress - num16);
							if (num34 < (long)0)
							{
								this.Putlog(string.Concat("[", ad.ToString(), "] Could not find offset"));
							}
							else
							{
								this.Putlog(string.Concat("[", ad.ToString(), "] Found offset at 0x", num34.ToString("X")));
								this.staminaAddress = num34;
							}
						}
						if (this.staminaAddress >= (long)0)
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
								actiondata actiondatum6 = ad;
								actiondatum6.counter = actiondatum6.counter + (long)1;
							}
							else if (ad.mode == ActionMode.TIMER)
							{
								int int32At3 = this.mem.GetInt32At(this.staminaAddress);
								if (int32At3 < ad.timerMax)
								{
									this.mem.SetInt32At(this.staminaAddress, int32At3 + (int32At3 + ad.timerQt <= ad.timerMax ? ad.timerQt : ad.timerMax - int32At3));
									actiondata actiondatum7 = ad;
									actiondatum7.counter = actiondatum7.counter + (long)1;
								}
								if (int32At3 + ad.timerQt < ad.timerMax)
								{
									flag1 = false;
								}
							}
						}
					}
					if (flag1 && ad.StopWhenDone)
					{
						this.Putlog(string.Concat("[", ad.ToString(), "] stopped."));
						actiondata selectedItem = (actiondata)((ListBox)this.findControl("lstActionsRegistered")).SelectedItem;
						if (selectedItem != null && selectedItem == ad)
						{
							this.CheckControl("chkActionsActiveInactive", false);
						}
						ad.Active = false;
					}
				}
				else
				{
					bool flag2 = true;
					foreach (itemdata item1 in this.lists[str1])
					{
						if (item1.isWeaponBowShield && this.findItemByAddr(item1.itemAddress, this.equipped.ToList<itemdata>()) != null || ad.type == ActionType.SET_BOWS_DUR && item1.itemID.Contains("Arrow") || ad.type == ActionType.SET_ITEMS_QT && item1.isEquipment || ad.UseFilter && this.findItemByID(item1.itemID, ad.filterList.ToList<itemdata>()) == null || ad.mode == ActionMode.FIXED && !ad.HiddenTimerElapsed())
						{
							continue;
						}
						if (ad.mode != ActionMode.FIXED)
						{
							if (ad.mode != ActionMode.TIMER)
							{
								continue;
							}
							int int32At4 = this.mem.GetInt32At(item1.itemQtDurAddress);
							if (int32At4 < ad.timerMax)
							{
								this.mem.SetInt32At(item1.itemQtDurAddress, int32At4 + (int32At4 + ad.timerQt <= ad.timerMax ? ad.timerQt : ad.timerMax - int32At4));
								actiondata actiondatum8 = ad;
								actiondatum8.counter = actiondatum8.counter + (long)1;
							}
							if (int32At4 + ad.timerQt >= ad.timerMax)
							{
								continue;
							}
							flag2 = false;
						}
						else
						{
							ad.HiddenTimerSec = 2;
							this.mem.SetInt32At(item1.itemQtDurAddress, ad.fixedValue);
							ad.HiddenTimerTick();
							actiondata actiondatum9 = ad;
							actiondatum9.counter = actiondatum9.counter + (long)1;
						}
					}
					if (flag2 && ad.StopWhenDone)
					{
						this.Putlog(string.Concat("[", ad.ToString(), "] Auto restore stopped."));
						actiondata selectedItem1 = (actiondata)((ListBox)this.findControl("lstActionsRegistered")).SelectedItem;
						if (selectedItem1 != null && selectedItem1 == ad)
						{
							this.CheckControl("chkActionsActiveInactive", false);
						}
						ad.Active = false;
					}
				}
				ad.timeLast = totalSeconds;
			}
		}

		public void executeUiAction(QueueItem q)
		{
			if (q.byteCode == QueueItemCode.UIACTION)
			{
				string str = q.message;
				if (str == "ENABLE_CONTROL")
				{
					this.EnableControl(q.type, q.status);
					return;
				}
				if (str == "CHECK_CONTROL")
				{
					this.CheckControl(q.type, q.status);
					return;
				}
				if (str == "SHOW_CONTROL")
				{
					this.ShowControl(q.type, q.status);
					return;
				}
				if (str == "TEXT_CONTROL")
				{
					this.TextControl(q.type, (string)q.data);
					return;
				}
				if (str != "REFRESH_SELECTED_INDEX")
				{
					return;
				}
				this.refreshSelectedIndex(q.type);
			}
		}

		public void extractNamesFromMemory(long startAddress, long endAddress, bool debug = false)
		{
			byte[] numArray;
			this.itemNames.Clear();
			this.SetLblScan("Looking for item names in memory...");
			byte[] numArray1 = new byte[] { 77, 115, 103, 83, 116, 100, 66, 110 };
			byte[] numArray2 = new byte[] { 76, 66, 76, 49 };
			byte[] numArray3 = new byte[] { 65, 84, 82, 49 };
			byte[] numArray4 = new byte[] { 84, 88, 84, 50 };
			byte[] numArray5 = new byte[] { 0, 14, 0, 201, 0, 0 };
			byte[] numArray6 = new byte[] { 0, 14, 0, 2 };
			byte[] numArray7 = new byte[8];
			byte[] numArray8 = new byte[12];
			long num = startAddress;
			long num1 = (long)-1;
			while (num < endAddress)
			{
				long num2 = this.mem.pagedMemorySearch(numArray1, num, endAddress - num);
				num1 = num2;
				if (num2 < (long)0)
				{
					break;
				}
				List<string> strs = new List<string>();
				Dictionary<string, int> strs1 = new Dictionary<string, int>();
				int int32At = this.mem.GetInt32At(num1 + (long)12) - 16973824;
				int int32At1 = this.mem.GetInt32At(num1 + (long)18);
				if (int32At <= 0 || int32At1 <= 0)
				{
					numArray = new byte[0];
					int32At = 0;
					int32At1 = 0;
				}
				else
				{
					numArray = new byte[int32At1];
					this.mem.GetBytesAt(num1, numArray, int32At1);
				}
				int num3 = 32;
				for (int i = 0; int32At > 0 && i < int32At; i++)
				{
					while (num3 < int32At1 && numArray[num3] == 171)
					{
						num3++;
					}
					int num4 = MemAPI.ExtractInt32FromArray(numArray, num3 + 4);
					int num5 = MemAPI.ExtractInt32FromArray(numArray, num3 + 16);
					if (MemAPI.findSequence(numArray, num3, numArray2, false, false) == num3)
					{
						num4 = num4 + 16;
						for (int j = 0; j < num5; j++)
						{
							int num6 = MemAPI.ExtractInt32FromArray(numArray, num3 + 20 + 8 * j);
							int num7 = MemAPI.ExtractInt32FromArray(numArray, num3 + 20 + 8 * j + 4);
							int num8 = num3 + num7 + 16;
							for (int k = 0; k < num6; k++)
							{
								byte num9 = numArray[num8];
								string str = MemAPI.ExtractStringFromArray(numArray, num8 + 1, (int)num9);
								int num10 = MemAPI.ExtractInt32FromArray(numArray, num8 + 1 + num9);
								num8 = num8 + 1 + num9 + 4;
								if (str.EndsWith("_Name"))
								{
									strs1.Add(str.Substring(0, str.Length - 5), num10);
								}
							}
						}
					}
					else if (strs1.Count <= 0 || MemAPI.findSequence(numArray, num3, numArray3, false, false) != num3)
					{
						if (strs1.Count <= 0 || MemAPI.findSequence(numArray, num3, numArray4, false, false) != num3)
						{
							break;
						}
						num4 = num4 + 16;
						for (int l = num3 + 20; l < num3 + num4 - 12; l++)
						{
							if (MemAPI.findSequence(numArray, l, numArray5, false, false) >= 0)
							{
								for (int m = 0; m < 12; m++)
								{
									numArray[l + m] = 0;
								}
							}
							else if (MemAPI.findSequence(numArray, l, numArray6, false, false) >= 0)
							{
								for (int n = 0; n < 8; n++)
								{
									numArray[l + n] = 0;
								}
							}
						}
						for (int o = 0; o < num5; o++)
						{
							int num11 = MemAPI.ExtractInt32FromArray(numArray, num3 + 20 + 4 * o);
							int num12 = num3 + num11 + 16;
							if (MemAPI.findSequence(numArray, num12, numArray5, false, false) == num12)
							{
								num12 = num12 + 12;
							}
							else if (MemAPI.findSequence(numArray, num12, numArray8, false, false) == num12)
							{
								num12 = num12 + 12;
							}
							else if (MemAPI.findSequence(numArray, num12, numArray7, false, false) == num12)
							{
								num12 = num12 + 8;
							}
							int num13 = 0;
							string str1 = App.RemoveInvalidXmlChars(MemAPI.GetBigEndianUnicodeString(numArray, num12, out num13));
							strs.Add(str1);
						}
					}
					else
					{
						num4 = num4 + 16;
					}
					num3 = num3 + num4;
				}
				foreach (KeyValuePair<string, int> keyValuePair in strs1)
				{
					if (strs.Count <= keyValuePair.Value || this.itemNames.ContainsKey(keyValuePair.Key))
					{
						continue;
					}
					this.itemNames.Add(keyValuePair.Key, strs[keyValuePair.Value]);
				}
				strs1.Clear();
				strs.Clear();
				num = num1 + (long)((int32At1 > 0 ? int32At1 : (int)numArray1.Length));
			}
			this.SetLblScan(string.Concat("Found ", this.itemNames.Count, " names in memory."));
		}

		public long findAmiiboDateAddress(long startAddress, long regionSize)
		{
			long num = (long)-1;
			byte[] numArray = new byte[] { 1, 44, 153, 133, 1, 44, 153, 133 };
			long length = (long)((int)numArray.Length + 4);
			num = this.mem.pagedMemorySearch(numArray, startAddress, regionSize);
			if (num >= (long)0)
			{
				num = num + length;
			}
			return num;
		}

		public long findBowsSlotsAddressInMemory(long startAddress, long endAddress)
		{
			long num = (long)-1;
			int[] numArray = new int[] { 1, 7, 0, 0, 0, 0, 0, 5, 0, 0, 0, 5, 0, 0, 0, 14 };
			long length = (long)((int)numArray.Length);
			num = this.mem.pagedMemorySearchMatch(numArray, startAddress, endAddress - startAddress);
			if (num >= (long)0)
			{
				num = num + length;
			}
			return num;
		}

		public long findBowsSlotsPersistAddressInMemory(long startAddress, long endAddress)
		{
			long num = (long)-1;
			int[] numArray = new int[] { 231, 206, 8, 34, 0, 0, 0, 0, 231, 206, 68, 83 };
			long length = (long)((int)numArray.Length);
			num = this.mem.pagedMemorySearchMatch(numArray, startAddress, endAddress - startAddress);
			if (num >= (long)0)
			{
				num = num + length;
			}
			return num;
		}

		public Control findControl(string name)
		{
			Control control = null;
			foreach (Control control1 in this.getControls(null))
			{
				if (control1.Name != name)
				{
					continue;
				}
				control = control1;
				return control;
			}
			return control;
		}

		public long findCoordinatesAddress(long startAddress, long regionSize)
		{
			long num = (long)-1;
			int[] numArray = new int[] { 3, 1, 61, 47, 206, 179, 16, -1, -1, -1, 255, 255, 0, 1, 7, 255 };
			long num1 = (long)102;
			num = this.mem.pagedMemorySearchMatch(numArray, startAddress, regionSize);
			if (num >= (long)0)
			{
				num = num + num1;
			}
			return num;
		}

		public long findEquippedDurabilityAddress(itemdata item)
		{
			long num;
			long num1;
			long num2 = (long)-1;
			if (!this.mem.FindRegionByAddr(this.inventoryStartAddress, out num, out num1, IntPtr.Zero, true))
			{
				return num2;
			}
			byte[] bytes = BitConverter.GetBytes(this.mem.GetInt32At(item.itemQtDurAddress));
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(bytes);
			}
			byte[] numArray = new byte[] { 191, 128, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 0, 0, 0 };
			numArray[4] = bytes[0];
			numArray[5] = bytes[1];
			numArray[6] = bytes[2];
			numArray[7] = bytes[3];
			byte[] numArray1 = numArray;
			byte[] numArray2 = new byte[8];
			byte[] numArray3 = new byte[] { 63, 128, 0, 0, 63, 128, 0, 0, 63, 128, 0, 0 };
			byte[] numArray4 = new byte[] { 0, 0, 255, 255, 1, 68 };
			byte[] numArray5 = new byte[] { 0, 0, 255, 255, 1, 69 };
			byte[] numArray6 = new byte[] { 0, 0, 255, 255, 1, 70 };
			byte[] numArray7 = new byte[] { 0, 0, 255, 255, 1, 75 };
			byte[] numArray8 = new byte[] { 0, 0, 255, 255, 2, 75 };
			byte[] numArray9 = new byte[3];
			byte[] numArray10 = new byte[] { 0, 4, 0 };
			byte[] numArray11 = new byte[32];
			byte[] numArray12 = new byte[4];
			int length = (int)numArray2.Length;
			int length1 = (int)numArray1.Length;
			int num3 = length + length1;
			int num4 = 20;
			bool flag = false;
			long num5 = this.inventoryStartAddress;
			long num6 = num + num1;
			long num7 = num6 - num5;
			byte[] numArray13 = new byte[512];
			while (!flag && num5 < num6 - (long)length1)
			{
				num2 = this.mem.pagedMemorySearch(numArray1, num5, num7 - (long)length1);
				if (num2 >= (long)0 && this.mem.GetBytesAt(num2 - (long)length - (long)num4, numArray13, num3 + 255) > 0)
				{
					int num8 = num4;
					int num9 = 12;
					int num10 = 14;
					byte num11 = numArray13[num8 + num3];
					byte num12 = numArray13[num8 + num10 + 147];
					if (num11 < 3 && (num12 == 0 || num12 == 4) && MemAPI.findSequence(numArray13, num8, numArray2, false, false) == num8 && MemAPI.findSequence(numArray13, num8 + num3 + 1 + 4, numArray3, false, false) == num8 + num3 + 1 + 4 && (MemAPI.findSequence(numArray13, num8 + num10 + 147 - 9, numArray4, false, false) >= 0 || MemAPI.findSequence(numArray13, num8 + num10 + 147 - 9, numArray5, false, false) >= 0 || MemAPI.findSequence(numArray13, num8 + num10 + 147 - 9, numArray6, false, false) >= 0 || MemAPI.findSequence(numArray13, num8 + num10 + 147 - 9, numArray7, false, false) >= 0 || MemAPI.findSequence(numArray13, num8 + num10 + 147 - 9, numArray8, false, false) >= 0) && (MemAPI.findSequence(numArray13, num8 + num10 + 147 - 1, numArray9, false, false) >= 0 || MemAPI.findSequence(numArray13, num8 + num10 + 147 - 1, numArray10, false, false) >= 0) && MemAPI.findSequence(numArray13, num8 + num9 + 80, numArray11, false, false) < 0 && MemAPI.findSequence(numArray13, num8 + num9 - 32, numArray12, false, false) < 0)
					{
						num2 = num2 + (long)(num9 - length);
						flag = true;
						break;
					}
				}
				if (num2 == (long)-1)
				{
					break;
				}
				num5 = num2 + (long)length1;
				num7 = num6 - num5;
			}
			if (!flag)
			{
				num2 = (long)-1;
			}
			return num2;
		}

		public long findHealthAddress(long startAddress, long regionSize)
		{
			long num = (long)-1;
			byte[] numArray = new byte[] { 63, 128, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
			byte[] numArray1 = new byte[13];
			byte[] numArray2 = new byte[4];
			int num1 = 223;
			int num2 = 224;
			int num3 = 226;
			int num4 = 199;
			int num5 = 159;
			int num6 = 190;
			int num7 = 206;
			int num8 = 254;
			int num9 = 14;
			int length = (int)numArray.Length;
			int length1 = (int)numArray1.Length;
			int num10 = length1 + length;
			bool flag = false;
			long num11 = startAddress;
			long num12 = regionSize;
			long num13 = num11 + num12;
			byte[] numArray3 = new byte[512];
			while (!flag && num11 < num13)
			{
				num = this.mem.pagedMemorySearch(numArray, num11, num12);
				if (num > (long)0 && this.mem.GetBytesAt(num - (long)length1, numArray3, num10 + 255) > 0)
				{
					byte num14 = numArray3[num10];
					byte num15 = numArray3[num10 + 1];
					if (num14 != 0 && num15 != 0 && numArray3[num10 + 8] == num14 && numArray3[num10 + 9] == num15 && numArray3[num10 + 12] == num14 && numArray3[num10 + 13] == num15 && numArray3[num10 + 4] == 0 && numArray3[num10 + 5] == 0 && (num14 == 67 || num14 == 68) && (num15 == num1 || num15 == num2 || num15 == num3 || num15 == num4 || num15 == num5 || num15 == num6 || num15 == num7 || num15 == num8 || num15 == num9 || numArray3[num10 + 6] != 0 || numArray3[num10 + 7] != 1) && MemAPI.findSequence(numArray3, 0, numArray1, false, false) == 0 && MemAPI.findSequence(numArray3, num10 + 16, numArray2, false, false) == -1)
					{
						num = num + (long)length + (long)4;
						flag = true;
						break;
					}
				}
				if (num == (long)-1)
				{
					break;
				}
				num11 = num + (long)length;
				num12 = num13 - num11;
			}
			if (!flag)
			{
				num = (long)-1;
			}
			return num;
		}

		public itemdata findItemByAddr(long addr, List<itemdata> list)
		{
			itemdata itemdatum = null;
			foreach (itemdata itemdatum1 in list)
			{
				if (itemdatum1.itemAddress != addr)
				{
					continue;
				}
				itemdatum = itemdatum1;
				return itemdatum;
			}
			return itemdatum;
		}

		public itemdata findItemByID(string ID, List<itemdata> list)
		{
			itemdata itemdatum = null;
			foreach (itemdata itemdatum1 in list)
			{
				if (itemdatum1.itemID != ID)
				{
					continue;
				}
				itemdatum = itemdatum1;
				return itemdatum;
			}
			return itemdatum;
		}

		public void FindItemsInMemory(bool silent = false)
		{
			uint uInt32At;
			this.updateItems(new List<itemdata>());
			List<itemdata> itemdatas = new List<itemdata>();
			if (!silent)
			{
				this.SetLblScan(string.Concat("Looking for process '", this.mem.ProcessName, "'..."));
			}
			this.mem.UpdateProcess("");
			if (this.mem.p == null)
			{
				if (!silent)
				{
					this.SetLblScan(string.Concat("Process '", this.mem.ProcessName, "' not found !"));
				}
				this.updateItems(itemdatas);
				return;
			}
			if (!this.mem.CheckOpenProcess())
			{
				if (!silent)
				{
					this.SetLblScan("Could not open process with desired access flags...");
				}
				this.updateItems(itemdatas);
				return;
			}
			if (!silent)
			{
				this.SetLblScan("Process found, scanning memory...");
			}
			long num = (long)0;
			long num1 = (long)0;
			long num2 = (long)1416757248;
			long num3 = (long)1441923072;
			long num4 = (long)1308622848;
			long num5 = (long)-1;
			long num6 = (long)-1;
			if (this.mem.FindRegionBySize(num2, out num, out num1, IntPtr.Zero, (long)0, true) && num > (long)0)
			{
				num5 = num;
				num6 = num5 + num1;
			}
			else if (!this.mem.FindRegionBySize(num3, out num, out num1, IntPtr.Zero, (long)0, true) || num <= (long)0)
			{
				if (!this.mem.FindRegionBySize(num4, out num, out num1, IntPtr.Zero, (long)0, true) || num <= (long)0)
				{
					if (!silent)
					{
						this.SetLblScan("Memory region not found, need some thinking ?");
					}
					this.updateItems(itemdatas);
					return;
				}
				num5 = num;
				num6 = num5 + num1;
			}
			else
			{
				num5 = num;
				num6 = num5 + num1;
			}
			if (this.rupeesAddress < (long)0)
			{
				if (!silent)
				{
					this.SetLblScan("Memory region found, looking for rupees...");
				}
				long num7 = this.findRupeesAddressInMemory(num5, num6);
				if (num7 < (long)0)
				{
					if (!silent)
					{
						this.SetLblScan("Could not find rupees offset in memory !");
					}
					this.EnableControl("gbRupees", false);
					this.TextControl(this.frmMain.txtRupees.Name, "");
				}
				else
				{
					this.rupeesAddress = num7;
					int int32At = this.mem.GetInt32At(this.rupeesAddress);
					if (!silent)
					{
						this.SetLblScan(string.Concat("Found ", int32At.ToString(), " rupees."));
					}
					this.TextControl(this.frmMain.txtRupees.Name, int32At.ToString());
					num1 = num6 - num7;
					num = num7;
					this.EnableControl("gbRupees", true);
				}
			}
			if (this.coordinatesAddress < (long)0)
			{
				if (!silent)
				{
					this.SetLblScan("Memory region found, looking for player coordinates...");
				}
				long num8 = this.findCoordinatesAddress(num5, num6 - num5);
				if (num8 < (long)0)
				{
					if (!silent)
					{
						this.SetLblScan("Could not find coordinates offset in memory !");
					}
					this.Putlog("Could not find coordinates offset in memory !");
				}
				else
				{
					this.coordinatesAddress = num8;
					float singleAt = this.mem.GetSingleAt(this.coordinatesAddress);
					float single = this.mem.GetSingleAt(this.coordinatesAddress + (long)4);
					float singleAt1 = this.mem.GetSingleAt(this.coordinatesAddress + (long)8);
					this.Putlog(string.Concat(new string[] { "Coordinates: X=", singleAt.ToString(), " Y=", single.ToString(), " Z=", singleAt1.ToString() }));
				}
			}
			if (this.weaponsSlotsAddress < (long)0 || this.bowsSlotsAddress < (long)0 || this.shieldsSlotsAddress < (long)0)
			{
				if (!silent)
				{
					this.SetLblScan("Memory region found, looking for slots count addresses...");
				}
				long num9 = (long)0;
				num9 = (this.rupeesAddress <= (long)0 ? this.findWeaponsSlotsAddressInMemory(num5, num6) : this.rupeesAddress + (long)2368);
				if (num9 < (long)0)
				{
					this.EnableControl("gbWeaponsSlots", false);
				}
				else
				{
					this.weaponsSlotsAddress = num9;
					this.RefreshTxtSlot("Weapons");
					if (!silent)
					{
						uInt32At = this.mem.GetUInt32At(this.weaponsSlotsAddress);
						this.SetLblScan(string.Concat("Found weapons slots count : ", uInt32At.ToString(), "."));
					}
					this.EnableControl("gbWeaponsSlots", true);
					num9 = this.findWeaponsSlotsPersistAddressInMemory(num5, num6);
					if (num9 >= (long)0)
					{
						this.weaponsSlotsPersistAddress = num9;
						if (!silent)
						{
							this.SetLblScan("Found persist weapons slots address.");
						}
					}
				}
				num9 = (this.rupeesAddress <= (long)0 ? this.findBowsSlotsAddressInMemory(num5, num6) : this.rupeesAddress + (long)2368 + (long)24352);
				if (num9 < (long)0)
				{
					this.EnableControl("gbBowsSlots", false);
				}
				else
				{
					this.bowsSlotsAddress = num9;
					this.RefreshTxtSlot("Bows");
					if (!silent)
					{
						uInt32At = this.mem.GetUInt32At(this.bowsSlotsAddress);
						this.SetLblScan(string.Concat("Found bows slots count : ", uInt32At.ToString(), "."));
					}
					this.EnableControl("gbBowsSlots", true);
					num9 = this.findBowsSlotsPersistAddressInMemory(num5, num6);
					if (num9 >= (long)0)
					{
						this.bowsSlotsPersistAddress = num9;
						if (!silent)
						{
							this.SetLblScan("Found persist bows slots address.");
						}
					}
				}
				num9 = (this.rupeesAddress <= (long)0 ? this.findShieldsSlotsAddressInMemory(num5, num6) : this.rupeesAddress + (long)2368 + (long)24384);
				if (num9 < (long)0)
				{
					this.EnableControl("gbShieldsSlots", false);
				}
				else
				{
					this.shieldsSlotsAddress = num9;
					this.RefreshTxtSlot("Shields");
					if (!silent)
					{
						uInt32At = this.mem.GetUInt32At(this.shieldsSlotsAddress);
						this.SetLblScan(string.Concat("Found shields slots count : ", uInt32At.ToString(), "."));
					}
					this.EnableControl("gbShieldsSlots", true);
					num9 = this.findShieldsSlotsPersistAddressInMemory(num5, num6);
					if (num9 >= (long)0)
					{
						this.shieldsSlotsPersistAddress = num9;
						if (!silent)
						{
							this.SetLblScan("Found persist shields slots address.");
						}
					}
				}
			}
			if (this.speedHackAddress < (long)0)
			{
				if (!silent)
				{
					this.SetLblScan("Memory region found, looking for run speed address...");
				}
				long num10 = this.findSpeedHackAddressInMemory(num5, num6);
				if (num10 < (long)0)
				{
					if (!silent)
					{
						this.SetLblScan("Could not find run speed offset in memory !");
					}
					int num11 = 1;
					this.TextControl(this.frmMain.txtRunSpeed.Name, num11.ToString());
				}
				else
				{
					this.speedHackAddress = num10;
					float single1 = this.mem.GetSingleAt(this.speedHackAddress);
					if (!silent)
					{
						this.SetLblScan(string.Concat("Found run speed multiplier : x ", single1.ToString()) ?? "");
					}
					this.TextControl(this.frmMain.txtRunSpeed.Name, single1.ToString());
				}
			}
			if (this.inventoryStartAddress > (long)0)
			{
				if (num5 >= this.inventoryStartAddress || this.inventoryStartAddress >= num6)
				{
					this.inventoryStartAddress = (long)-1;
				}
				else
				{
					num1 = num6 - this.inventoryStartAddress;
					num = this.inventoryStartAddress;
				}
			}
			if (!silent)
			{
				this.SetLblScan("Memory region found, looking for items...");
			}
			long num12 = (long)-1;
			long num13 = num;
			long num14 = num + num1;
			this.Putlog(string.Concat("Memory region start : ", num13.ToString("X")));
			this.Putlog(string.Concat("Memory region end : ", num14.ToString("X")));
			byte[] numArray = new byte[] { 16, 30 };
			byte[] numArray1 = new byte[] { 0, 0, 0, 64 };
			int[] numArray2 = new int[] { 16, -1, -1, -1, 0, 0, 0, 64 };
			byte[] numArray3 = new byte[] { 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255 };
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			int num15 = 0;
			if (this.mem.OpenProcessHandle())
			{
				int num16 = 32768;
				byte[] numArray4 = new byte[num16];
				long length = num13;
				while (length < num14)
				{
					num15++;
					if (num12 >= (long)0)
					{
						if (this.inventoryStartAddress < (long)0)
						{
							this.inventoryStartAddress = num12;
						}
						MemAPI.ReadBytes(length, numArray4, num16, this.mem.p, this.mem.Handle);
						if (MemAPI.findSequenceMatch(numArray4, 0, numArray2, false, false) != 0)
						{
							break;
						}
						long num17 = length + (long)7;
						if (MemAPI.IsValidItemIDInArray(numArray4, 8))
						{
							string str = MemAPI.ExtractStringFromMemory(num17 + (long)1, 128, this.mem.p, this.mem.Handle);
							itemdata itemdatum = new itemdata()
							{
								itemAddress = num17,
								itemID = str
							};
							itemdatas.Add(itemdatum);
						}
						length = length + (long)544;
					}
					else
					{
						MemAPI.ReadBytes(length, numArray4, num16, this.mem.p, this.mem.Handle);
						int num18 = -1;
						int num19 = MemAPI.findSequenceMatch(numArray4, 0, numArray2, true, false);
						num18 = num19;
						if (num19 < 0)
						{
							length = length + (long)(num16 - (int)numArray.Length);
						}
						else
						{
							length = length + (long)num18;
							MemAPI.ReadBytes(length, numArray4, num16, this.mem.p, this.mem.Handle);
							if (numArray4[1] != 30 && numArray4[1] != 31 && numArray4[1] != 32 && numArray4[1] != 33)
							{
								length = length + (long)((int)numArray.Length);
							}
							else if (MemAPI.findSequenceMatch(numArray4, 544, numArray2, false, false) != 544)
							{
								length = length + (long)((int)numArray.Length);
							}
							else
							{
								num12 = length;
							}
						}
					}
				}
			}
			this.mem.CloseProcessHandle();
			stopwatch.Stop();
			if (!silent)
			{
				this.SetLblScan(string.Concat("Found ", itemdatas.Count, " items in memory."));
			}
			if (this.itemNames.Count == 0)
			{
				this.mem.OpenProcessHandle();
				this.extractNamesFromMemory(num5, (this.inventoryStartAddress >= (long)0 ? this.inventoryStartAddress : num6), false);
				this.mem.CloseProcessHandle();
			}
			this.updateItems(itemdatas);
		}

		public long findNoStaminaBarAddress(bool barDisabled = false)
		{
			this.mem.UpdateProcess("");
			MemAPI.MemoryRegion[] memoryRegionArray = this.mem.listProcessMemoryRegions(this.mem.Handle);
			List<MemAPI.MemoryRegion> memoryRegions = new List<MemAPI.MemoryRegion>();
			MemAPI.MemoryRegion[] memoryRegionArray1 = memoryRegionArray;
			for (int i = 0; i < (int)memoryRegionArray1.Length; i++)
			{
				MemAPI.MemoryRegion memoryRegion = memoryRegionArray1[i];
				if (memoryRegion.regionSize >= (long)4194304)
				{
					memoryRegions.Add(memoryRegion);
				}
			}
			byte[] numArray = new byte[] { 69, 15, 56, 241, 116, 5, 104, 139, 84, 36, 8, 69, 15, 56, 240, 116, 21, 24, 102, 65, 15, 110, 198, 243, 15, 90, 192 };
			byte[] numArray1 = new byte[] { 144, 144, 144, 144, 144, 144, 144, 139, 84, 36, 8, 69, 15, 56, 240, 116, 21, 24, 102, 65, 15, 110, 198, 243, 15, 90, 192 };
			return this.mem.pagedMemorySearch((barDisabled ? numArray1 : numArray), memoryRegions.ToArray());
		}

		public long findPowersAddress(long startAddress, long regionSize)
		{
			long num = (long)-1;
			byte[] numArray = new byte[] { 255, 255, 255, 255, 255, 255, 255, 255, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0 };
			long length = (long)((int)numArray.Length + 4);
			while (true)
			{
				long num1 = this.mem.pagedMemorySearch(numArray, startAddress, regionSize);
				num = num1;
				if (num1 <= (long)0)
				{
					break;
				}
				if (this.mem.GetInt32At(num - (long)4) != 0 || this.mem.GetInt32At(num + (long)20) != 0 && this.mem.GetInt32At(num + (long)20) != -1)
				{
					regionSize = regionSize - (num + (long)20 - startAddress);
					startAddress = num + (long)20;
				}
				else
				{
					num = num + length;
					break;
				}
			}
			return num;
		}

		public long findRupeesAddressInMemory(long startAddress, long endAddress)
		{
			long num = (long)-1;
			int[] numArray = new int[] { 16, -1, -1, -1, 1, 7, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 15, 66, 63 };
			long length = (long)((int)numArray.Length);
			num = this.mem.pagedMemorySearchMatch(numArray, startAddress, endAddress - startAddress);
			if (num >= (long)0)
			{
				num = num + length;
			}
			return num;
		}

		public long findShieldsSlotsAddressInMemory(long startAddress, long endAddress)
		{
			long num = (long)-1;
			int[] numArray = new int[] { 1, 7, 0, 0, 0, 0, 0, 4, 0, 0, 0, 4, 0, 0, 0, 20 };
			long length = (long)((int)numArray.Length);
			num = this.mem.pagedMemorySearchMatch(numArray, startAddress, endAddress - startAddress);
			if (num >= (long)0)
			{
				num = num + length;
			}
			return num;
		}

		public long findShieldsSlotsPersistAddressInMemory(long startAddress, long endAddress)
		{
			long num = (long)-1;
			int[] numArray = new int[] { 47, 192, 108, 95, 0, 0, 0, 0, 47, 192, 210, 171 };
			long length = (long)((int)numArray.Length);
			num = this.mem.pagedMemorySearchMatch(numArray, startAddress, endAddress - startAddress);
			if (num >= (long)0)
			{
				num = num + length;
			}
			return num;
		}

		public long findSpeedHackAddressInMemory(long startAddress, long endAddress)
		{
			long num = (long)-1;
			int[] numArray = new int[] { 66, 112, 0, 0, 66, 200, 0, 0, 68, 122, 0, 0 };
			long num1 = (long)-8;
			num = this.mem.pagedMemorySearchMatch(numArray, startAddress, endAddress - startAddress);
			if (num >= (long)0)
			{
				num = num + num1;
			}
			return num;
		}

		public long findStaminaAddress(long startAddress, long regionSize)
		{
			long num = (long)-1;
			int[] numArray = new int[] { -2, 0, 0, 0, -2, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 0, 0, 0, 0, -2, -2, -2, -2 };
			int[] numArray1 = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 66 };
			int length = (int)numArray.Length;
			long num1 = (long)(length + 22);
			bool flag = false;
			long num2 = startAddress;
			long num3 = regionSize;
			long num4 = num2 + num3;
			if (this.speedHackAddress > (long)0)
			{
				num = this.speedHackAddress - (long)22565198;
				float singleAt = this.mem.GetSingleAt(num + (long)2);
				float single = this.mem.GetSingleAt(num + (long)6);
				if (singleAt != 0f && single != 0f && (double)singleAt == Math.Truncate((double)singleAt) && (double)single == Math.Truncate((double)single))
				{
					flag = true;
				}
			}
			byte[] numArray2 = new byte[512];
			while (!flag && num2 < num4)
			{
				num = this.mem.pagedMemorySearchMatch(numArray, num2, num3);
				if (num < (long)0 || this.mem.GetBytesAt(num, numArray2, length + 255) <= 0 || numArray2[length] != 67 && numArray2[length] != 66 || numArray2[checked((IntPtr)num1)] != 128 && numArray2[checked((IntPtr)num1)] != 0 || numArray2[checked((IntPtr)(num1 + (long)4))] != 128 && numArray2[checked((IntPtr)(num1 + (long)4))] != 0 || numArray2[checked((IntPtr)(num1 + (long)8))] != 128 && numArray2[checked((IntPtr)(num1 + (long)8))] != 0 || MemAPI.findSequenceMatch(numArray2, (int)(num1 + (long)9), numArray1, false, false) != (int)(num1 + (long)9))
				{
					if (num == (long)-1)
					{
						break;
					}
					num2 = num + (long)length;
					num3 = num4 - num2;
				}
				else
				{
					num = num + num1;
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				num = (long)-1;
			}
			return num;
		}

		public long findWeaponsSlotsAddressInMemory(long startAddress, long endAddress)
		{
			long num = (long)-1;
			int[] numArray = new int[] { 1, 7, 0, 0, 0, 0, 0, 8, 0, 0, 0, 8, 0, 0, 0, 20 };
			long length = (long)((int)numArray.Length);
			num = this.mem.pagedMemorySearchMatch(numArray, startAddress, endAddress - startAddress);
			if (num >= (long)0)
			{
				num = num + length;
			}
			return num;
		}

		public long findWeaponsSlotsPersistAddressInMemory(long startAddress, long endAddress)
		{
			long num = (long)-1;
			int[] numArray = new int[] { 140, 36, 149, 241, 0, 0, 0, 0, 140, 39, 12, 86 };
			long length = (long)((int)numArray.Length);
			num = this.mem.pagedMemorySearchMatch(numArray, startAddress, endAddress - startAddress);
			if (num >= (long)0)
			{
				num = num + length;
			}
			return num;
		}

		public void generateCompareReport(string fileName)
		{
			if (this.memoryChanges.Count == 0)
			{
				this.Putlog("Nothing to report.");
				return;
			}
			this.Putlog(string.Concat("Reporting ", this.memoryChanges.Count, " changes in memory since last dump..."));
			this.Putlog(string.Concat("Creating report file '", fileName, "'..."));
			try
			{
				using (StreamWriter streamWriter = new StreamWriter(fileName))
				{
					streamWriter.WriteLine(string.Concat("Memory changes report - Number of affected offsets : ", this.memoryChanges.Count));
					streamWriter.WriteLine("");
					streamWriter.WriteLine(string.Concat("[info] region Start address = 0x", this.memoryChanges[0].regionStart.ToString("X")));
					long item = this.memoryChanges[0].regionStart + this.memoryChanges[0].regionSize;
					streamWriter.WriteLine(string.Concat("[info] region End address = 0x", item.ToString("X")));
					streamWriter.WriteLine(string.Concat("[info] Size = 0x", this.memoryChanges[0].regionSize.ToString("X")));
					if (this.speedHackAddress > (long)0)
					{
						streamWriter.WriteLine("");
						streamWriter.WriteLine(string.Concat("[info] runspeed address = 0x", this.speedHackAddress.ToString("X")));
					}
					if (this.rupeesAddress > (long)0)
					{
						streamWriter.WriteLine(string.Concat("[info] rupees address = 0x", this.rupeesAddress.ToString("X")));
					}
					if (this.coordinatesAddress > (long)0)
					{
						streamWriter.WriteLine(string.Concat("[info] coordinates address = 0x", this.coordinatesAddress.ToString("X")));
					}
					int num = 13;
					foreach (MemoryChange memoryChange in this.memoryChanges)
					{
						streamWriter.WriteLine("");
						streamWriter.WriteLine(string.Concat(new string[] { "[0x", memoryChange.address.ToString("X"), "] (0x", memoryChange.oldValue.ToString("X2"), ") -> (0x", memoryChange.newValue.ToString("X2"), ")" }));
						streamWriter.WriteLine("");
						streamWriter.WriteLine(string.Concat("Reference Memory Buffer (", (int)memoryChange.oldBuffer.Length, " bytes) :"));
						streamWriter.WriteLine("");
						string str = "";
						int num1 = 0;
						for (int i = 0; i < (int)memoryChange.oldBuffer.Length; i++)
						{
							if (str.Length > 0)
							{
								str = string.Concat(str, " ");
							}
							str = string.Concat(str, memoryChange.oldBuffer[i].ToString("X2"));
							if (i > 0 && (i + 1) % 16 == 0)
							{
								num1++;
								if (num1 == num + 1)
								{
									str = string.Concat(new string[] { str, " => (", memoryChange.oldValue.ToString("X2"), " -> ", memoryChange.newValue.ToString("X2"), ")" });
								}
								streamWriter.WriteLine(str);
								str = "";
							}
						}
						streamWriter.WriteLine("");
						streamWriter.WriteLine(string.Concat("Process Memory Buffer (", (int)memoryChange.newBuffer.Length, " bytes) :"));
						streamWriter.WriteLine("");
						str = "";
						num1 = 0;
						for (int j = 0; j < (int)memoryChange.newBuffer.Length; j++)
						{
							if (str.Length > 0)
							{
								str = string.Concat(str, " ");
							}
							str = string.Concat(str, memoryChange.newBuffer[j].ToString("X2"));
							if (j > 0 && (j + 1) % 16 == 0)
							{
								num1++;
								if (num1 == num + 1)
								{
									str = string.Concat(new string[] { str, " => (", memoryChange.newValue.ToString("X2"), " <- ", memoryChange.oldValue.ToString("X2"), ")" });
								}
								streamWriter.WriteLine(str);
								str = "";
							}
						}
					}
				}
			}
			catch (Exception exception)
			{
				this.Putlog(string.Concat("Error writing report to file '", fileName, "'"));
				return;
			}
			this.Putlog(string.Concat("Report file '", fileName, "' created successfully."));
		}

		public long getAddressesDiff(long addr1, long addr2)
		{
			if (addr1 <= addr2)
			{
				return addr2 - addr1;
			}
			return addr1 - addr2;
		}

		public List<Control> getControls(Control parent = null)
		{
			Control control;
			List<Control> controls = new List<Control>();
			if (parent == null)
			{
				control = this.frmMain;
			}
			else
			{
				control = parent;
			}
			parent = control;
			if (parent != null)
			{
				foreach (Control control1 in parent.Controls)
				{
					controls.Add(control1);
					controls.AddRange(this.getControls(control1));
				}
			}
			return controls;
		}

		private static string getControlSection(Control ctrl)
		{
			string[] strArrays = Regex.Split(ctrl.Name, "(?<!^)(?=[A-Z])");
			if ((int)strArrays.Length <= 1)
			{
				return "";
			}
			return strArrays[1];
		}

		private CapturedPosition getCurrentSelectedCapturePosition()
		{
			CapturedPosition selectedItem = null;
			ListBox listBox = (ListBox)this.findControl("lstCapturedPositions");
			if (listBox != null && listBox.Items.Count > 0)
			{
				selectedItem = (CapturedPosition)listBox.SelectedItem;
			}
			return selectedItem;
		}

		public Settings getCurrentSettings()
		{
			Settings setting = new Settings()
			{
				auto_update_timer = App.StringToInt32(this.frmMain.txtTimerUpdateList.Text),
				auto_update = this.frmMain.chkUpdateList.Checked,
				internalLoopMs = this.getInternalLoopMsValue(),
				spacingMs = this.getSpacingMsValue()
			};
			foreach (KeyValuePair<string, string> itemName in this.itemNames)
			{
				setting.item_ids.Add(itemName.Key);
				setting.item_names.Add(itemName.Value);
			}
			foreach (KeyValuePair<string, object> listAction in this.listActions)
			{
				actiondata value = (actiondata)listAction.Value;
				setting.action_keys.Add(listAction.Key);
				setting.action_datas.Add(value);
			}
			foreach (actiondata customAction in this.customActions)
			{
				setting.custom_actions.Add(customAction);
			}
			setting.capturedPositions = this.capturedPositions.ToList<CapturedPosition>();
			return setting;
		}

		public itemdata getEquippedBow()
		{
			itemdata itemdatum = null;
			foreach (itemdata itemdatum1 in this.equipped)
			{
				if (!itemdatum1.isBow)
				{
					continue;
				}
				itemdatum = itemdatum1;
				return itemdatum;
			}
			return itemdatum;
		}

		public itemdata getEquippedShield()
		{
			itemdata itemdatum = null;
			foreach (itemdata itemdatum1 in this.equipped)
			{
				if (!itemdatum1.isShield)
				{
					continue;
				}
				itemdatum = itemdatum1;
				return itemdatum;
			}
			return itemdatum;
		}

		public itemdata getEquippedWeapon()
		{
			itemdata itemdatum = null;
			foreach (itemdata itemdatum1 in this.equipped)
			{
				if (!itemdatum1.isWeapon)
				{
					continue;
				}
				itemdatum = itemdatum1;
				return itemdatum;
			}
			return itemdatum;
		}

		public int getIdIndexInNames(string key, string section)
		{
			int num = -1;
			int num1 = 0;
			if (this.names.ContainsKey(section))
			{
				foreach (itemname item in this.names[section])
				{
					if (item.itemID != key)
					{
						num1++;
					}
					else
					{
						num = num1;
						return num;
					}
				}
			}
			return num;
		}

		public int getInternalLoopMsValue()
		{
			int num = 100;
			try
			{
				num = Convert.ToInt32(this.frmMain.numInternalLoopMs.Value);
			}
			catch (Exception exception)
			{
			}
			return num;
		}

		public int GetRupees()
		{
			int int32At = -1;
			if (this.rupeesAddress >= (long)0)
			{
				int32At = this.mem.GetInt32At(this.rupeesAddress);
			}
			return int32At;
		}

		public int getSpacingMsValue()
		{
			int num = 0;
			try
			{
				num = Convert.ToInt32(this.frmMain.numSpacingMs.Value);
			}
			catch (Exception exception)
			{
			}
			return num;
		}

		public float GetTxtPositionJumpHeight()
		{
			float single = 0f;
			float.TryParse(this.frmMain.txtPositionJumpHeight.Text, out single);
			return single;
		}

		public double GetTxtRunSpeed()
		{
			double num = 1;
			double.TryParse(this.frmMain.txtRunSpeed.Text, out num);
			return num;
		}

		public uint GetTxtSlot(string what)
		{
			uint num = 0;
			TextBox textBox = (TextBox)this.findControl(string.Concat("txt", what, "Slots"));
			if (textBox != null)
			{
				uint.TryParse(textBox.Text, out num);
			}
			return num;
		}

		private void gKH_KeyPress(object sender, KeyEventArgs e)
		{
			int i;
			TextBox textBox = this.frmMain.txtActionsHotKey;
			if (!textBox.Focused)
			{
				bool flag = false;
				string[] aCTIONSECTIONS = App.ACTION_SECTIONS;
				i = 0;
				while (i < (int)aCTIONSECTIONS.Length)
				{
					string str = aCTIONSECTIONS[i];
					TextBox textBox1 = (TextBox)this.findControl(string.Concat("txt", str, "HotKey"));
					if (!textBox1.Focused)
					{
						i++;
					}
					else
					{
						globalKeyboardHook.keyboardHookStruct _keyboardHookStruct = this.gKH.lastKey;
						globalKeyboardHook.keyboardHookStruct _keyboardHookStruct1 = this.gKH.lastKey;
						globalKeyboardHook.keyboardHookStruct _keyboardHookStruct2 = this.gKH.lastKey;
						globalKeyboardHook.keyboardHookStruct _keyboardHookStruct3 = this.gKH.lastKey;
						string keyText = this.gKH.GetKeyText(ref this.gKH.lastKey);
						textBox1.Text = keyText;
						e.Handled = true;
						flag = true;
						break;
					}
				}
				if (flag)
				{
					return;
				}
				aCTIONSECTIONS = App.EXTENDED_ACTION_SECTIONS;
				i = 0;
				while (i < (int)aCTIONSECTIONS.Length)
				{
					string str1 = aCTIONSECTIONS[i];
					TextBox textBox2 = (TextBox)this.findControl(string.Concat("txt", str1, "HotKey"));
					if (!textBox2.Focused)
					{
						i++;
					}
					else
					{
						globalKeyboardHook.keyboardHookStruct _keyboardHookStruct4 = this.gKH.lastKey;
						globalKeyboardHook.keyboardHookStruct _keyboardHookStruct5 = this.gKH.lastKey;
						globalKeyboardHook.keyboardHookStruct _keyboardHookStruct6 = this.gKH.lastKey;
						globalKeyboardHook.keyboardHookStruct _keyboardHookStruct7 = this.gKH.lastKey;
						string keyText1 = this.gKH.GetKeyText(ref this.gKH.lastKey);
						textBox2.Text = keyText1;
						e.Handled = true;
						flag = true;
						break;
					}
				}
			}
			else
			{
				globalKeyboardHook.keyboardHookStruct _keyboardHookStruct8 = this.gKH.lastKey;
				globalKeyboardHook.keyboardHookStruct _keyboardHookStruct9 = this.gKH.lastKey;
				globalKeyboardHook.keyboardHookStruct _keyboardHookStruct10 = this.gKH.lastKey;
				globalKeyboardHook.keyboardHookStruct _keyboardHookStruct11 = this.gKH.lastKey;
				string keyText2 = this.gKH.GetKeyText(ref this.gKH.lastKey);
				textBox.Text = keyText2;
				e.Handled = true;
			}
			bool flag1 = false;
			if (!e.Handled && WinAPI.ApplicationIsActivated())
			{
				Control control = WinAPI.FindFocusedControl(this.frmMain);
				if (control != null && control.GetType() == typeof(TextBox))
				{
					flag1 = true;
				}
			}
			if (!flag1 && !e.Handled)
			{
				string str2 = this.gKH.GetKeyText(ref this.gKH.lastKey);
				bool flag2 = false;
				int num = 0;
				object[] array = this.listActions.Values.ToArray<object>();
				for (i = 0; i < (int)array.Length; i++)
				{
					actiondata active = (actiondata)array[i];
					if (active.UseHotKey && active.hotKey != "" && active.hotKey == str2)
					{
						active.Active = !active.Active;
						flag2 = true;
						num++;
						this.updateUiFromActionData(active);
					}
				}
				actiondata[] actiondataArray = this.customActions.ToArray<actiondata>();
				for (i = 0; i < (int)actiondataArray.Length; i++)
				{
					actiondata actiondatum = actiondataArray[i];
					if (actiondatum.UseHotKey && actiondatum.hotKey != "" && actiondatum.hotKey == str2)
					{
						actiondatum.Active = !actiondatum.Active;
						flag2 = true;
						num++;
						this.updateUiFromActionData(actiondatum);
					}
				}
				if (flag2)
				{
					this.FlagEvent_1 = false;
					this.updateActionsSelected();
					this.FlagEvent_1 = true;
					this.Putlog(string.Concat("HotKey '", str2, "' triggered. Settings affected: ", num.ToString()));
				}
			}
		}

		public void JumpPosition()
		{
			if (this.coordinatesAddress > (long)0)
			{
				float txtPositionJumpHeight = this.GetTxtPositionJumpHeight();
				float singleAt = this.mem.GetSingleAt(this.coordinatesAddress + (long)4);
				float single = singleAt + txtPositionJumpHeight;
				this.mem.SetSingleAt(this.coordinatesAddress + (long)4, single);
				this.Putlog(string.Concat("Jumping from Y=", singleAt.ToString(), " to Y=", single.ToString()));
			}
		}

		public void listMemoryRegions()
		{
			this.mem.UpdateProcess("");
			MemAPI.MemoryRegion[] memoryRegionArray = this.mem.listProcessMemoryRegions(this.mem.Handle);
			List<MemAPI.MemoryRegion> memoryRegions = new List<MemAPI.MemoryRegion>();
			MemAPI.MemoryRegion[] memoryRegionArray1 = memoryRegionArray;
			for (int i = 0; i < (int)memoryRegionArray1.Length; i++)
			{
				MemAPI.MemoryRegion memoryRegion = memoryRegionArray1[i];
				if (memoryRegion.regionSize >= (long)4194304)
				{
					memoryRegions.Add(memoryRegion);
				}
			}
			byte[] numArray = new byte[] { 69, 15, 56, 241, 116, 5, 104, 139, 84, 36, 8, 69, 15, 56, 240, 116, 21, 24, 102, 65, 15, 110, 198, 243, 15, 90, 192 };
			this.Putlog("Searching offset...");
			long num = this.mem.pagedMemorySearch(numArray, memoryRegions.ToArray());
			if (num <= (long)0)
			{
				this.Putlog("Offset not found !");
				return;
			}
			this.Putlog(string.Concat("Address found : 0x", num.ToString("X")));
		}

		public void loadMemoryFromFile(string fileName)
		{
			this.Putlog(string.Concat("Trying to load process '", this.mem.ProcessName, "' memory dump..."));
			this.mem.UpdateProcess("");
			if (this.mem.p == null)
			{
				this.Putlog(string.Concat("Process '", this.mem.ProcessName, "' not found !"));
				return;
			}
			if (!this.mem.CheckOpenProcess())
			{
				this.Putlog("Could not open process with desired access flags...");
				return;
			}
			this.Putlog("Process found, scanning memory...");
			long num = (long)0;
			long num1 = (long)0;
			long num2 = (long)1416757248;
			long num3 = (long)1441923072;
			if (!this.mem.FindRegionBySize(num2, out num, out num1, IntPtr.Zero, (long)0, true) || num <= (long)0)
			{
				if (!this.mem.FindRegionBySize(num3, out num, out num1, IntPtr.Zero, (long)0, true) || num <= (long)0)
				{
					this.Putlog("Memory region not found, need some thinking ?");
					return;
				}
			}
			else
			{
			}
			long num4 = num;
			long num5 = num + num1;
			this.Putlog(string.Concat("Memory region start : ", num4.ToString("X")));
			this.Putlog(string.Concat("Memory region end : ", num5.ToString("X")));
			using (BinaryReader binaryReader = new BinaryReader(File.OpenRead(fileName)))
			{
				if (this.mem.OpenProcessHandle())
				{
					this.Putlog("Loading started.");
					int num6 = 131072;
					byte[] numArray = new byte[num6];
					int num7 = 0;
					int num8 = 0;
					while (true)
					{
						int num9 = binaryReader.Read(numArray, 0, num6);
						num7 = num9;
						if (num9 <= 0)
						{
							break;
						}
						num8 = num8 + num7;
						this.Putlog(string.Concat(new object[] { "Read ", num7, " bytes (total: ", num8, ")" }));
						MemAPI.WriteBytes(num4 + (long)num8, numArray, num7, this.mem.p, this.mem.Handle);
					}
					binaryReader.Close();
					this.Putlog(string.Concat(new object[] { "Total bytes read from ", fileName, " : ", num8 }));
				}
				this.mem.CloseProcessHandle();
			}
			this.Putlog("Load terminated.");
		}

		private void lst_DoubleClick(object sender, EventArgs e)
		{
			BindingList<itemdata> dataSource;
			BindingList<itemdata> itemdatas;
			itemdata selectedItem = (itemdata)((ListBox)sender).SelectedItem;
			if (selectedItem != null)
			{
				TabPage parent = (TabPage)this.frmMain.lstActionsFilter.Parent.Parent;
				if (((TabControl)parent.Parent).SelectedTab == parent && this.frmMain.lstActionsFilter.Parent.Enabled)
				{
					actiondata actiondatum = (actiondata)this.frmMain.lstActionsRegistered.SelectedItem;
					if (actiondatum != null)
					{
						foreach (itemdata itemdatum in actiondatum.filterList)
						{
							if (itemdatum.itemID != selectedItem.itemID)
							{
								continue;
							}
							return;
						}
						actiondatum.filterList.Add(new itemdata(selectedItem.itemID));
						BindingSource bindingSources = (BindingSource)this.frmMain.lstActionsFilter.DataSource;
						if (bindingSources != null)
						{
							for (int i = 0; i < bindingSources.Count; i++)
							{
								bindingSources.ResetItem(i);
							}
						}
					}
				}
				ListBox listBox = (ListBox)this.findControl("lstUnbreakableFilter");
				TabPage tabPage = (TabPage)listBox.Parent.Parent.Parent;
				if (((TabControl)tabPage.Parent).SelectedTab == tabPage)
				{
					BindingSource dataSource1 = (BindingSource)listBox.DataSource;
					if (dataSource1 == null || dataSource1.DataSource == null)
					{
						itemdatas = null;
					}
					else
					{
						itemdatas = (BindingList<itemdata>)dataSource1.DataSource;
					}
					BindingList<itemdata> itemdatas1 = itemdatas;
					if (itemdatas1 != null)
					{
						foreach (itemdata itemdatum1 in itemdatas1)
						{
							if (itemdatum1.itemID != selectedItem.itemID)
							{
								continue;
							}
							return;
						}
						itemdatas1.Add(new itemdata(selectedItem.itemID));
						for (int j = 0; j < dataSource1.Count; j++)
						{
							dataSource1.ResetItem(j);
						}
					}
				}
				string[] aCTIONSECTIONS = App.ACTION_SECTIONS;
				for (int k = 0; k < (int)aCTIONSECTIONS.Length; k++)
				{
					string str = aCTIONSECTIONS[k];
					ListBox listBox1 = (ListBox)this.findControl(string.Concat("lst", str, "Filter"));
					TabPage parent1 = (TabPage)listBox1.Parent.Parent;
					if (((TabControl)parent1.Parent).SelectedTab == parent1)
					{
						BindingSource bindingSources1 = (BindingSource)listBox1.DataSource;
						if (bindingSources1 == null || bindingSources1.DataSource == null)
						{
							dataSource = null;
						}
						else
						{
							dataSource = (BindingList<itemdata>)bindingSources1.DataSource;
						}
						BindingList<itemdata> itemdatas2 = dataSource;
						if (itemdatas2 != null)
						{
							foreach (itemdata itemdatum2 in itemdatas2)
							{
								if (itemdatum2.itemID != selectedItem.itemID)
								{
									continue;
								}
								return;
							}
							itemdatas2.Add(new itemdata(selectedItem.itemID));
							for (int l = 0; l < bindingSources1.Count; l++)
							{
								bindingSources1.ResetItem(l);
							}
						}
					}
				}
			}
		}

		private void lst_SelectedIndexChanged(object sender, EventArgs e)
		{
			string controlSection = App.getControlSection((Control)sender);
			if (controlSection != "")
			{
				this.refreshSelectedIndex(controlSection);
			}
		}

		private void lstActionsFilter_DoubleClick(object sender, EventArgs e)
		{
			BindingList<itemdata> dataSource;
			ListBox listBox = (ListBox)sender;
			itemdata selectedItem = (itemdata)listBox.SelectedItem;
			if (selectedItem != null)
			{
				BindingSource bindingSources = (BindingSource)listBox.DataSource;
				if (bindingSources == null || bindingSources.DataSource == null)
				{
					dataSource = null;
				}
				else
				{
					dataSource = (BindingList<itemdata>)bindingSources.DataSource;
				}
				BindingList<itemdata> itemdatas = dataSource;
				if (itemdatas != null)
				{
					itemdatas.Remove(selectedItem);
					for (int i = 0; i < bindingSources.Count; i++)
					{
						bindingSources.ResetItem(i);
					}
				}
			}
		}

		private void lstActionsRegistered_SelectedIndexChanged(object sender, EventArgs e)
		{
		}

		private void lstActionsRegistered_SelectedValueChanged(object sender, EventArgs e)
		{
			this.FlagEvent_1 = false;
			this.updateActionsSelected();
			this.FlagEvent_1 = true;
		}

		private void LstCapturedPositions_DoubleClick(object sender, EventArgs e)
		{
			if (this.getCurrentSelectedCapturePosition() != null)
			{
				this.TPCapturedPosition();
			}
		}

		private void LstCapturedPositions_SelectedIndexChanged(object sender, EventArgs e)
		{
			ListBox listBox = (ListBox)sender;
			if (listBox.Items.Count == 0)
			{
				return;
			}
			this.UpdateCapturedPositionDetails((CapturedPosition)listBox.SelectedItem);
		}

		private void optionActionsFilterList_CheckedChanged(object sender, EventArgs e)
		{
			this.updateCurrentAction();
		}

		private void optionActionsFixed_CheckedChanged(object sender, EventArgs e)
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

		private void optionUnbreakableFilterList_CheckedChanged(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}

		private void optionUnbreakableNoFilter_CheckedChanged(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}

		public void Putlog(string what)
		{
			if (!this.InvokeRequired)
			{
				this.frmMain.Putlog(what);
				return;
			}
			this.uiQueue.Enqueue(new QueueItem(QueueItemCode.PUTLOG, what, null, false, "", "", null));
			this.worker.ReportProgress(0);
		}

		public bool ReadBytesFromFile(string fileName, byte[] buffer, long startFileOffset, int count)
		{
			bool flag;
			if (!File.Exists(fileName))
			{
				return false;
			}
			if (startFileOffset >= (new FileInfo(fileName)).Length)
			{
				this.Putlog("Error index too big");
				return false;
			}
			try
			{
				using (BinaryReader binaryReader = new BinaryReader(File.OpenRead(fileName)))
				{
					binaryReader.BaseStream.Seek(startFileOffset, SeekOrigin.Begin);
					int num = binaryReader.Read(buffer, 0, count);
					binaryReader.Close();
					flag = (num == count ? true : false);
				}
			}
			catch (Exception exception1)
			{
				Exception exception = exception1;
				this.Putlog(string.Concat("Error reading bytes from file '", fileName, "' : ", exception.Message));
				flag = false;
			}
			return flag;
		}

		public Settings readSettings(string xmlfile)
		{
			return Settings.loadFile(xmlfile);
		}

		public void refreshSelectedIndex(string section)
		{
			int int32At;
			if (this.InvokeRequired)
			{
				this.uiQueue.Enqueue(new QueueItem(QueueItemCode.UIACTION, "REFRESH_SELECTED_INDEX", null, false, section, "", null));
				this.worker.ReportProgress(0);
				return;
			}
			this.ShowControl(string.Concat("btn", section, "ItemUnlock"), false);
			ListBox listBox = (ListBox)this.findControl(string.Concat("lst", section));
			if (listBox == null)
			{
				return;
			}
			itemdata selectedItem = (itemdata)listBox.SelectedItem;
			if (selectedItem == null)
			{
				return;
			}
			TextBox textBox = (TextBox)this.findControl(string.Concat("txt", section, "ItemID"));
			TextBox str = (TextBox)this.findControl(string.Concat("txt", section, "ItemQtDur"));
			TextBox str1 = (TextBox)this.findControl(string.Concat("txt", section, "ItemBonusType"));
			TextBox textBox1 = (TextBox)this.findControl(string.Concat("txt", section, "ItemBonusValue"));
			ComboBox item = (ComboBox)this.findControl(string.Concat("cb", section, "ItemName"));
			ComboBox comboBox = (ComboBox)this.findControl(string.Concat("cb", section, "ItemBonusType"));
			if (textBox != null)
			{
				textBox.Text = selectedItem.itemID;
			}
			if (str != null)
			{
				int32At = this.mem.GetInt32At(selectedItem.itemQtDurAddress);
				str.Text = int32At.ToString();
			}
			if (str1 != null)
			{
				uint uInt32At = this.mem.GetUInt32At(selectedItem.itemBonusTypeAddress);
				str1.Text = uInt32At.ToString();
			}
			if (textBox1 != null)
			{
				int32At = this.mem.GetInt32At(selectedItem.itemBonusValueAddress);
				textBox1.Text = int32At.ToString();
			}
			if (!selectedItem.isWeaponBowShield)
			{
				if (str1 != null)
				{
					str1.Visible = true;
				}
				if (comboBox != null)
				{
					comboBox.Visible = false;
				}
			}
			else
			{
				if (str1 != null)
				{
					str1.Visible = false;
				}
				if (comboBox != null)
				{
					comboBox.Visible = true;
				}
			}
			if (comboBox != null && (!this.InvokeRequired || item.DataSource == null))
			{
				uint num = this.mem.GetUInt32At(selectedItem.itemBonusTypeAddress);
				comboBox.DataSource = null;
				try
				{
					comboBox.Items.Clear();
					List<Bonus> bonusList = Bonus.getBonusList();
					comboBox.DataSource = bonusList;
					foreach (Bonus bonu in bonusList)
					{
						if (!bonu.Match((long)num))
						{
							continue;
						}
						comboBox.SelectedItem = bonu;
						break;
					}
				}
				catch (Exception exception)
				{
				}
			}
			if (item != null && (!this.InvokeRequired || item.DataSource == null))
			{
				int idIndexInNames = this.getIdIndexInNames(selectedItem.itemID, section);
				if (idIndexInNames >= 0)
				{
					item.DataSource = null;
					try
					{
						item.Items.Clear();
						item.DataSource = this.names[section];
						item.SelectedIndex = idIndexInNames;
					}
					catch (Exception exception1)
					{
					}
					item.Enabled = true;
				}
				else
				{
					item.DataSource = null;
					try
					{
						item.Items.Clear();
						item.Items.Add(selectedItem.itemName);
						item.Text = selectedItem.itemName;
					}
					catch (Exception exception2)
					{
					}
					item.Enabled = false;
				}
			}
			if (!selectedItem.isWeaponBowShield || this.mem.GetByteAt(selectedItem.itemEquippedFlagAddress) != 1)
			{
				this.EnableControl(string.Concat("gb", section, "Edit"), true);
			}
			else
			{
				this.EnableControl(string.Concat("gb", section, "Edit"), false);
			}
			this.ShowControl(string.Concat("btn", section, "ItemUnlock"), true);
		}

		public void RefreshTxtRunSpeed()
		{
			if (this.speedHackAddress <= (long)0)
			{
				int num = 1;
				this.TextControl(this.frmMain.txtRunSpeed.Name, num.ToString());
				return;
			}
			float singleAt = this.mem.GetSingleAt(this.speedHackAddress);
			this.TextControl(this.frmMain.txtRunSpeed.Name, singleAt.ToString());
		}

		public void RefreshTxtSlot(string what)
		{
			long num = (long)0;
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
			if (num > (long)0)
			{
				TextBox textBox = (TextBox)this.findControl(string.Concat("txt", what, "Slots"));
				if (textBox != null)
				{
					uint uInt32At = this.mem.GetUInt32At(num);
					this.TextControl(textBox.Name, uInt32At.ToString());
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

		public static string RemoveInvalidXmlChars(string input)
		{
			return new string(Array.FindAll<char>(input.ToCharArray(), (char value) => {
				if (value >= ' ' && value <= '\uD7FF' || value >= '\uE000' && value <= '\uFFFD' || value == '\t' || value == '\n')
				{
					return true;
				}
				return value == '\r';
			}));
		}

		public void requestMemoryScan()
		{
			this.workingQueue.Enqueue(new QueueItem(QueueItemCode.REQUEST_SCAN, "", null, false, "", "", null));
		}

		public void resetAddresses(bool clearInventoryAddress = false)
		{
			this.healthAddress = (long)-1;
			this.staminaAddress = (long)-1;
			this.rupeesAddress = (long)-1;
			this.amiiboDateAddress = (long)-1;
			this.speedHackAddress = (long)-1;
			this.weaponsSlotsAddress = (long)-1;
			this.bowsSlotsAddress = (long)-1;
			this.shieldsSlotsAddress = (long)-1;
			this.weaponsSlotsPersistAddress = (long)-1;
			this.bowsSlotsPersistAddress = (long)-1;
			this.shieldsSlotsPersistAddress = (long)-1;
			this.divinePowerDarukAddress = (long)-1;
			this.divinePowerMiphaTimerAddress = (long)-1;
			this.divinePowerRevaliAddress = (long)-1;
			this.divinePowersAddress = (long)-1;
			this.divinePowerUrbosaAddress = (long)-1;
			this.equippedBowDurabilityAddress = (long)-1;
			this.equippedShieldDurabilityAddress = (long)-1;
			this.equippedWeaponDurabilityAddress = (long)-1;
			if (clearInventoryAddress)
			{
				this.inventoryStartAddress = (long)-1;
			}
			this.coordinatesAddress = (long)-1;
		}

		public void resetSettings()
		{
			this.itemNames.Clear();
		}

		public void RestorePosition()
		{
			if (this.coordinatesAddress > (long)0)
			{
				float single = this.savedX;
				float single1 = this.savedY;
				float single2 = this.savedZ;
				this.mem.SetSingleAt(this.coordinatesAddress, single);
				this.mem.SetSingleAt(this.coordinatesAddress + (long)4, single1);
				this.mem.SetSingleAt(this.coordinatesAddress + (long)8, single2);
				this.Putlog(string.Concat(new string[] { "Restored position X=", single.ToString(), " Y=", single1.ToString(), " Z=", single2.ToString() }));
			}
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
			this.Putlog(string.Concat("Could not find process '", this.mem.ProcessName, "'."));
		}

		public void SaveCapturedPosition()
		{
			float single;
			float single1;
			float single2;
			CapturedPosition currentSelectedCapturePosition = this.getCurrentSelectedCapturePosition();
			if (currentSelectedCapturePosition != null)
			{
				string text = this.frmMain.txtCapturedPositionName.Text;
				float.TryParse(this.frmMain.txtCapturedPositionX.Text, out single);
				float.TryParse(this.frmMain.txtCapturedPositionY.Text, out single1);
				float.TryParse(this.frmMain.txtCapturedPositionZ.Text, out single2);
				currentSelectedCapturePosition.X = single;
				currentSelectedCapturePosition.Y = single1;
				currentSelectedCapturePosition.Z = single2;
				currentSelectedCapturePosition.Name = text;
				try
				{
					this.capturedPositions.ResetItem(this.capturedPositions.IndexOf(currentSelectedCapturePosition));
				}
				catch (Exception exception)
				{
				}
			}
		}

		public void SavePosition()
		{
			if (this.coordinatesAddress > (long)0)
			{
				float singleAt = this.mem.GetSingleAt(this.coordinatesAddress);
				float single = this.mem.GetSingleAt(this.coordinatesAddress + (long)4);
				float singleAt1 = this.mem.GetSingleAt(this.coordinatesAddress + (long)8);
				this.savedX = singleAt;
				this.savedY = single;
				this.savedZ = singleAt1;
				this.Putlog(string.Concat(new string[] { "Saved position X=", singleAt.ToString(), " Y=", single.ToString(), " Z=", singleAt1.ToString() }));
			}
		}

		public void searchMemoryRegionForAddress(long addr)
		{
			this.Putlog(string.Concat(new string[] { "Trying to find memory region related to address 0x", addr.ToString("X"), " in process '", this.mem.ProcessName, "'..." }));
			this.mem.UpdateProcess("");
			if (this.mem.p == null)
			{
				this.Putlog(string.Concat("Process '", this.mem.ProcessName, "' not found !"));
				return;
			}
			if (!this.mem.CheckOpenProcess())
			{
				this.Putlog("Could not open process with desired access flags...");
				return;
			}
			this.Putlog("Process found, scanning memory...");
			long num = (long)0;
			long num1 = (long)0;
			if (!this.mem.FindRegionByAddr(addr, out num, out num1, this.mem.Handle, false))
			{
				this.Putlog("Region not found !");
				return;
			}
			this.Putlog(string.Concat("Found region start : 0x", num.ToString("X")));
			long num2 = num + num1;
			this.Putlog(string.Concat("Found region end : 0x", num2.ToString("X")));
			this.Putlog(string.Concat("Found region size : 0x", num1.ToString("X")));
		}

		public void searchMemoryRegionForSize(long size, long startAddress = 0L)
		{
			this.Putlog(string.Concat(new string[] { "Trying to find memory region with size 0x", size.ToString("X"), " with address starting at 0x", startAddress.ToString("X"), "' in process '", this.mem.ProcessName, "'..." }));
			this.mem.UpdateProcess("");
			if (this.mem.p == null)
			{
				this.Putlog(string.Concat("Process '", this.mem.ProcessName, "' not found !"));
				return;
			}
			if (!this.mem.CheckOpenProcess())
			{
				this.Putlog("Could not open process with desired access flags...");
				return;
			}
			this.Putlog("Process found, scanning memory...");
			long num = (long)0;
			long num1 = (long)0;
			if (!this.mem.FindRegionBySize(size, out num, out num1, this.mem.Handle, startAddress, false))
			{
				this.Putlog("Region not found !");
				return;
			}
			this.Putlog(string.Concat("Found region start : 0x", num.ToString("X")));
			long num2 = num + num1;
			this.Putlog(string.Concat("Found region end : 0x", num2.ToString("X")));
			this.Putlog(string.Concat("Found region size : 0x", num1.ToString("X")));
		}

		public void SetLblScan(string what)
		{
			if (!this.InvokeRequired)
			{
				this.frmMain.SetLblScan(what);
				this.Putlog(what);
				return;
			}
			this.uiQueue.Enqueue(new QueueItem(QueueItemCode.SET_LBL_SCAN, what, null, false, "", "", null));
			this.worker.ReportProgress(0);
		}

		public void SetRupees(int value)
		{
			if (this.rupeesAddress >= (long)0)
			{
				this.mem.SetInt32At(this.rupeesAddress, value);
				this.mem.SetInt32At(this.rupeesAddress - (long)4704656, value);
			}
		}

		public void SetTextBoxText(TextBox txtBox, string text)
		{
			if (txtBox != null && txtBox.GetType() == typeof(TextBox) && txtBox.Text != text)
			{
				txtBox.Text = text;
			}
		}

		public void setTime(int value)
		{
			if (this.InvokeRequired)
			{
				return;
			}
			if (this.staminaAddress > (long)0 || this.speedHackAddress > (long)0)
			{
				long num = (this.staminaAddress > (long)0 ? this.staminaAddress + (long)2 : this.speedHackAddress - (long)22565198 + (long)2);
				long num1 = num + (long)1567901152;
				float singleAt = this.mem.GetSingleAt(num1);
				if (singleAt <= 0f || singleAt > 360f)
				{
					num1 = num + (long)1581909472;
					singleAt = this.mem.GetSingleAt(num1);
				}
				if (singleAt <= 0f || singleAt > 360f)
				{
					return;
				}
				float single = Convert.ToSingle(value);
				this.mem.SetSingleAt(num1, single);
			}
		}

		public void showCompareAddress(long address)
		{
			this.Putlog(string.Concat("Comparing address 0x", address.ToString("X"), " with known ones..."));
			string str = this.speedHackAddress.ToString("X");
			long addressesDiff = this.getAddressesDiff(this.speedHackAddress, address);
			this.Putlog(string.Concat("Run speed address : 0x", str, " diff=0x", addressesDiff.ToString("X")));
			string str1 = this.coordinatesAddress.ToString("X");
			addressesDiff = this.getAddressesDiff(this.coordinatesAddress, address);
			this.Putlog(string.Concat("Coordinates address : 0x", str1, " diff=0x", addressesDiff.ToString("X")));
			string str2 = this.rupeesAddress.ToString("X");
			addressesDiff = this.getAddressesDiff(this.rupeesAddress, address);
			this.Putlog(string.Concat("Rupees address : 0x", str2, " diff=0x", addressesDiff.ToString("X")));
			string str3 = this.weaponsSlotsAddress.ToString("X");
			addressesDiff = this.getAddressesDiff(this.weaponsSlotsAddress, address);
			this.Putlog(string.Concat("Weapons slot address : 0x", str3, " diff=0x", addressesDiff.ToString("X")));
			if (this.staminaAddress > (long)0)
			{
				string str4 = this.staminaAddress.ToString("X");
				addressesDiff = this.getAddressesDiff(this.staminaAddress, address);
				this.Putlog(string.Concat("Stamina address : 0x", str4, " diff=0x", addressesDiff.ToString("X")));
			}
			if (this.healthAddress > (long)0)
			{
				string str5 = this.healthAddress.ToString("X");
				addressesDiff = this.getAddressesDiff(this.healthAddress, address);
				this.Putlog(string.Concat("Health address : 0x", str5, " diff=0x", addressesDiff.ToString("X")));
			}
			if (this.inventoryStartAddress > (long)0)
			{
				string str6 = this.inventoryStartAddress.ToString("X");
				addressesDiff = this.getAddressesDiff(this.inventoryStartAddress, address);
				this.Putlog(string.Concat("Inventory start address : 0x", str6, " diff=0x", addressesDiff.ToString("X")));
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

		private static byte StringToByte(string str)
		{
			byte num = 0;
			byte.TryParse(str.Trim(), out num);
			return num;
		}

		private static int StringToInt32(string str)
		{
			int num = 0;
			int.TryParse(str.Trim(), out num);
			return num;
		}

		private static uint StringToUInt32(string str)
		{
			uint num = 0;
			uint.TryParse(str.Trim(), out num);
			return num;
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
			this.Putlog(string.Concat("Could not find process '", this.mem.ProcessName, "'."));
		}

		public void SwitchEditPosition()
		{
			if (this.coordinatesAddress > (long)0)
			{
				Button button = (Button)this.findControl("btnPositionEdit");
				TextBox textBox = (TextBox)this.findControl("txtPositionX");
				TextBox textBox1 = (TextBox)this.findControl("txtPositionY");
				TextBox textBox2 = (TextBox)this.findControl("txtPositionZ");
				if (button != null)
				{
					if (button.Text == "Edit")
					{
						textBox.ReadOnly = false;
						textBox1.ReadOnly = false;
						textBox2.ReadOnly = false;
						button.Text = "Ok";
						return;
					}
					float singleAt = this.mem.GetSingleAt(this.coordinatesAddress);
					float single = this.mem.GetSingleAt(this.coordinatesAddress + (long)4);
					float singleAt1 = this.mem.GetSingleAt(this.coordinatesAddress + (long)8);
					float.TryParse(textBox.Text, out singleAt);
					float.TryParse(textBox1.Text, out single);
					float.TryParse(textBox2.Text, out singleAt1);
					this.mem.SetSingleAt(this.coordinatesAddress, singleAt);
					this.mem.SetSingleAt(this.coordinatesAddress + (long)4, single);
					this.mem.SetSingleAt(this.coordinatesAddress + (long)8, singleAt1);
					textBox.ReadOnly = true;
					textBox1.ReadOnly = true;
					textBox2.ReadOnly = true;
					button.Text = "Edit";
				}
			}
		}

		public void TextControl(string what, string text)
		{
			Control control = this.findControl(what);
			if (control == null || control != null && control.Text == text)
			{
				return;
			}
			if (!this.InvokeRequired)
			{
				if (control != null)
				{
					control.Text = text;
				}
				return;
			}
			this.uiQueue.Enqueue(new QueueItem(QueueItemCode.UIACTION, "TEXT_CONTROL", text, false, what, "", null));
			this.worker.ReportProgress(0);
		}

		public void TPCapturedPosition()
		{
			CapturedPosition currentSelectedCapturePosition = this.getCurrentSelectedCapturePosition();
			if (currentSelectedCapturePosition != null && this.coordinatesAddress > (long)0)
			{
				this.Putlog(string.Concat(new string[] { "Changed position to X=", currentSelectedCapturePosition.X.ToString(), " Y=", currentSelectedCapturePosition.Y.ToString(), " Z=", currentSelectedCapturePosition.Z.ToString() }));
				this.mem.SetSingleAt(this.coordinatesAddress, currentSelectedCapturePosition.X);
				this.mem.SetSingleAt(this.coordinatesAddress + (long)4, currentSelectedCapturePosition.Y);
				this.mem.SetSingleAt(this.coordinatesAddress + (long)8, currentSelectedCapturePosition.Z);
			}
		}

		private void txtActionsFixed_TextChanged(object sender, EventArgs e)
		{
			this.updateCurrentAction();
		}

		private void txtActionsHotKey_TextChanged(object sender, EventArgs e)
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

		public void updateActionDatas()
		{
			int i;
			string[] aCTIONSECTIONS = App.ACTION_SECTIONS;
			for (i = 0; i < (int)aCTIONSECTIONS.Length; i++)
			{
				string str = aCTIONSECTIONS[i];
				try
				{
					if (this.listActions.ContainsKey(str))
					{
						actiondata hiddenTimerSec = this.createActionData(str);
						actiondata item = (actiondata)this.listActions[str];
						hiddenTimerSec.timeLast = item.timeLast;
						hiddenTimerSec.section = item.section;
						hiddenTimerSec.desc = item.desc;
						hiddenTimerSec.counter = item.counter;
						hiddenTimerSec.HiddenTimerSec = item.HiddenTimerSec;
						this.listActions[str] = hiddenTimerSec;
					}
				}
				catch (Exception exception)
				{
				}
			}
			aCTIONSECTIONS = App.EXTENDED_ACTION_SECTIONS;
			for (i = 0; i < (int)aCTIONSECTIONS.Length; i++)
			{
				string str1 = aCTIONSECTIONS[i];
				try
				{
					if (this.listActions.ContainsKey(str1))
					{
						CheckBox checkBox = (CheckBox)this.findControl(string.Concat("chk", str1, "Set"));
						actiondata active = this.createActionData(str1);
						actiondata actiondatum = (actiondata)this.listActions[str1];
						if (checkBox == null)
						{
							active.Active = actiondatum.Active;
						}
						active.timeLast = actiondatum.timeLast;
						active.section = actiondatum.section;
						active.desc = actiondatum.desc;
						active.counter = actiondatum.counter;
						active.HiddenTimerSec = actiondatum.HiddenTimerSec;
						if (actiondatum.fixedValue >= 0)
						{
							active.fixedValue = actiondatum.fixedValue;
						}
						if (actiondatum.singleValue != 0f)
						{
							active.singleValue = actiondatum.singleValue;
						}
						this.listActions[str1] = active;
					}
				}
				catch (Exception exception1)
				{
				}
			}
		}

		public void updateActionsSelected()
		{
			actiondata selectedItem = (actiondata)this.frmMain.lstActionsRegistered.SelectedItem;
			if (this.frmMain.lstActionsRegistered.Items.Count == 0)
			{
				this.EnableControl("gbActionsSettings", false);
				this.EnableControl("gbActionsFilter", false);
				foreach (Control control in this.getControls(this.findControl("gbActionsSettings")))
				{
					if (control.GetType() == typeof(TextBox))
					{
						((TextBox)control).Clear();
					}
					if (control.GetType() == typeof(ComboBox))
					{
						((ComboBox)control).Items.Clear();
					}
					if (control.GetType() == typeof(ListBox))
					{
						((ListBox)control).Items.Clear();
					}
					if (control.GetType() != typeof(CheckBox))
					{
						continue;
					}
					((CheckBox)control).Checked = false;
				}
				foreach (Control control1 in this.getControls(this.findControl("gbActionsFilter")))
				{
					if (control1.GetType() == typeof(TextBox))
					{
						((TextBox)control1).Clear();
					}
					if (control1.GetType() == typeof(ComboBox))
					{
						((ComboBox)control1).Items.Clear();
					}
					if (control1.GetType() == typeof(ListBox))
					{
						((ListBox)control1).DataSource = null;
					}
					if (control1.GetType() == typeof(ListBox))
					{
						((ListBox)control1).Items.Clear();
					}
					if (control1.GetType() != typeof(CheckBox))
					{
						continue;
					}
					((CheckBox)control1).Checked = false;
				}
			}
			else if (selectedItem != null)
			{
				this.EnableControl("gbActionsSettings", true);
				this.EnableControl("gbActionsFilter", true);
				if (this.frmMain.cbActionsList.Items.Count == 0)
				{
					foreach (ActionType value in Enum.GetValues(typeof(ActionType)))
					{
						this.frmMain.cbActionsList.Items.Add(actiondata.ACTIONTYPESTRING[(int)value]);
					}
				}
				this.frmMain.cbActionsList.SelectedIndex = (int)selectedItem.type;
				this.frmMain.optionActionsFixed.Checked = (selectedItem.mode == ActionMode.FIXED ? true : false);
				this.frmMain.optionActionsTimer.Checked = (selectedItem.mode == ActionMode.TIMER ? true : false);
				this.frmMain.optionActionsNoFilter.Checked = (!selectedItem.UseFilter ? true : false);
				this.frmMain.optionActionsFilterList.Checked = (selectedItem.UseFilter ? true : false);
				this.SetTextBoxText(this.frmMain.txtActionsFixed, (selectedItem.fixedValue >= 0 ? selectedItem.fixedValue.ToString() : ""));
				this.SetTextBoxText(this.frmMain.txtActionsTimer, (selectedItem.timerSec >= 0 ? selectedItem.timerSec.ToString() : ""));
				this.SetTextBoxText(this.frmMain.txtActionsQuantity, (selectedItem.timerQt >= 0 ? selectedItem.timerQt.ToString() : ""));
				this.SetTextBoxText(this.frmMain.txtActionsMax, (selectedItem.timerMax >= 0 ? selectedItem.timerMax.ToString() : ""));
				this.frmMain.chkActionsActiveInactive.Checked = selectedItem.Active;
				this.frmMain.chkActionsDisableWhenDone.Checked = selectedItem.StopWhenDone;
				this.frmMain.chkActionsUseHotkey.Checked = selectedItem.UseHotKey;
				this.SetTextBoxText(this.frmMain.txtActionsHotKey, selectedItem.hotKey);
				this.frmMain.lstActionsFilter.DataSource = this.CreateBindingSource<itemdata>(selectedItem.filterList);
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

		public void updateCurrentAction()
		{
			if (!this.FlagEvent_1)
			{
				return;
			}
			actiondata selectedItem = (actiondata)this.frmMain.lstActionsRegistered.SelectedItem;
			if (selectedItem != null)
			{
				selectedItem.type = (ActionType)((byte)this.frmMain.cbActionsList.SelectedIndex);
				selectedItem.mode = (this.frmMain.optionActionsFixed.Checked ? ActionMode.FIXED : ActionMode.TIMER);
				selectedItem.fixedValue = (this.frmMain.txtActionsFixed.Text.Length > 0 ? App.StringToInt32(this.frmMain.txtActionsFixed.Text) : selectedItem.fixedValue);
				selectedItem.timerSec = (this.frmMain.txtActionsTimer.Text.Length > 0 ? App.StringToInt32(this.frmMain.txtActionsTimer.Text) : selectedItem.timerSec);
				selectedItem.timerQt = (this.frmMain.txtActionsQuantity.Text.Length > 0 ? App.StringToInt32(this.frmMain.txtActionsQuantity.Text) : selectedItem.timerQt);
				selectedItem.timerMax = (this.frmMain.txtActionsMax.Text.Length > 0 ? App.StringToInt32(this.frmMain.txtActionsMax.Text) : selectedItem.timerMax);
				selectedItem.hotKey = (this.frmMain.txtActionsHotKey.Text.Length > 0 ? this.frmMain.txtActionsHotKey.Text : "");
				selectedItem.UseHotKey = this.frmMain.chkActionsUseHotkey.Checked;
				selectedItem.StopWhenDone = this.frmMain.chkActionsDisableWhenDone.Checked;
				selectedItem.Active = this.frmMain.chkActionsActiveInactive.Checked;
				selectedItem.UseFilter = (this.frmMain.optionActionsFilterList.Checked ? true : false);
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
			foreach (itemdata item in items)
			{
				if (!item.isWeaponBowShield)
				{
					continue;
				}
				if (this.mem.GetByteAt(item.itemEquippedFlagAddress) != 1)
				{
					if (!this.equipped.Contains(item))
					{
						continue;
					}
					if (item.isShield)
					{
						this.equippedShieldDurabilityAddress = (long)-1;
					}
					else if (!item.isBow)
					{
						this.equippedWeaponDurabilityAddress = (long)-1;
					}
					else
					{
						this.equippedBowDurabilityAddress = (long)-1;
					}
					this.equipped.Remove(item);
				}
				else
				{
					if (this.equipped.Contains(item))
					{
						continue;
					}
					if (item.isShield)
					{
						this.equippedShieldDurabilityAddress = (long)-1;
					}
					else if (!item.isBow)
					{
						this.equippedWeaponDurabilityAddress = (long)-1;
					}
					else
					{
						this.equippedBowDurabilityAddress = (long)-1;
					}
					this.equipped.Add(item);
				}
			}
		}

		public void updateItemLists()
		{
		}

		public void updateItems(List<itemdata> newItems)
		{
			// ERROR
		}

		public void updatePosition()
		{
			if (this.coordinatesAddress > (long)0)
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
					float single = this.mem.GetSingleAt(this.coordinatesAddress + (long)4);
					float singleAt1 = this.mem.GetSingleAt(this.coordinatesAddress + (long)8);
					this.TextControl("txtPositionX", singleAt.ToString());
					this.TextControl("txtPositionY", single.ToString());
					this.TextControl("txtPositionZ", singleAt1.ToString());
				}
			}
		}

		public void UpdateRunSpeedMultiplier(double multiplier)
		{
			if (this.speedHackAddress > (long)0)
			{
				this.mem.SetSingleAt(this.speedHackAddress, Convert.ToSingle(multiplier));
				this.Putlog(string.Concat("Run speed multiplier set to value : x ", multiplier.ToString()));
			}
			this.RefreshTxtRunSpeed();
		}

		public void UpdateSlot(string what, uint value)
		{
			long num = (long)0;
			long num1 = (long)0;
			if (what == "Weapons")
			{
				num = this.weaponsSlotsAddress;
				num1 = this.weaponsSlotsPersistAddress;
			}
			else if (what == "Bows")
			{
				num = this.bowsSlotsAddress;
				num1 = this.bowsSlotsPersistAddress;
			}
			else if (what == "Shields")
			{
				num = this.shieldsSlotsAddress;
				num1 = this.shieldsSlotsPersistAddress;
			}
			if (num > (long)0 && value >= 0)
			{
				this.mem.SetUInt32At(num, value);
				this.Putlog(string.Concat("Slot count for ", what, " changed to : ", value.ToString()));
				if (num1 > (long)0)
				{
					this.mem.SetUInt32At(num1, value);
				}
			}
		}

		public void updateTime()
		{
			if (this.staminaAddress > (long)0 || this.speedHackAddress > (long)0)
			{
				if (this.InvokeRequired)
				{
					this.uiQueue.Enqueue(new QueueItem(QueueItemCode.UPDATE_TIME, "", null, false, "", "", null));
					this.worker.ReportProgress(0);
					return;
				}
				long num = (this.staminaAddress > (long)0 ? this.staminaAddress + (long)2 : this.speedHackAddress - (long)22565198 + (long)2);
				long num1 = num + (long)1567901152;
				float singleAt = this.mem.GetSingleAt(num1);
				if (singleAt <= 0f || singleAt > 360f)
				{
					num1 = num + (long)1581909472;
					singleAt = this.mem.GetSingleAt(num1);
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
			if (Array.IndexOf<string>(App.ACTION_SECTIONS, ad.section) <= -1)
			{
				if (Array.IndexOf<string>(App.EXTENDED_ACTION_SECTIONS, ad.section) > -1)
				{
					CheckBox active = (CheckBox)this.findControl(string.Concat("chk", ad.section, "Set"));
					CheckBox useHotKey = (CheckBox)this.findControl(string.Concat("chk", ad.section, "UseHotkey"));
					TextBox textBox = (TextBox)this.findControl(string.Concat("txt", ad.section, "HotKey"));
					ListBox listBox = this.frmMain.lstUnbreakableFilter;
					RadioButton useFilter = this.frmMain.optionUnbreakableNoFilter;
					RadioButton radioButton = this.frmMain.optionUnbreakableFilterList;
					useFilter.Checked = !ad.UseFilter;
					radioButton.Checked = ad.UseFilter;
					BindingSource dataSource = (BindingSource)listBox.DataSource;
					if (dataSource == null)
					{
						listBox.DataSource = this.CreateBindingSource<itemdata>(ad.filterList);
					}
					else
					{
						dataSource.DataSource = ad.filterList;
					}
					textBox.Text = ad.hotKey;
					useHotKey.Checked = ad.UseHotKey;
					if (active != null)
					{
						active.Checked = ad.Active;
					}
				}
				return;
			}
			RadioButton radioButton1 = (RadioButton)this.findControl(string.Concat("option", ad.section, "Fixed"));
			RadioButton radioButton2 = (RadioButton)this.findControl(string.Concat("option", ad.section, "Timer"));
			RadioButton useFilter1 = (RadioButton)this.findControl(string.Concat("option", ad.section, "NoFilter"));
			RadioButton useFilter2 = (RadioButton)this.findControl(string.Concat("option", ad.section, "FilterList"));
			ListBox listBox1 = (ListBox)this.findControl(string.Concat("lst", ad.section, "Filter"));
			CheckBox stopWhenDone = (CheckBox)this.findControl(string.Concat("chk", ad.section, "DisableWhenDone"));
			CheckBox checkBox = (CheckBox)this.findControl(string.Concat("chk", ad.section, "UseHotkey"));
			CheckBox active1 = (CheckBox)this.findControl(string.Concat("chk", ad.section, "ActiveInactive"));
			TextBox textBox1 = (TextBox)this.findControl(string.Concat("txt", ad.section, "Fixed"));
			TextBox textBox2 = (TextBox)this.findControl(string.Concat("txt", ad.section, "Timer"));
			TextBox textBox3 = (TextBox)this.findControl(string.Concat("txt", ad.section, "Quantity"));
			TextBox textBox4 = (TextBox)this.findControl(string.Concat("txt", ad.section, "Max"));
			TextBox textBox5 = (TextBox)this.findControl(string.Concat("txt", ad.section, "HotKey"));
			radioButton1.Checked = ad.mode == ActionMode.FIXED;
			radioButton2.Checked = ad.mode == ActionMode.TIMER;
			useFilter1.Checked = !ad.UseFilter;
			useFilter2.Checked = ad.UseFilter;
			BindingSource bindingSources = (BindingSource)listBox1.DataSource;
			if (bindingSources == null)
			{
				listBox1.DataSource = this.CreateBindingSource<itemdata>(ad.filterList);
			}
			else
			{
				bindingSources.DataSource = ad.filterList;
			}
			stopWhenDone.Checked = ad.StopWhenDone;
			checkBox.Checked = ad.UseHotKey;
			textBox1.Text = (ad.fixedValue >= 0 ? ad.fixedValue.ToString() : "");
			textBox2.Text = (ad.timerSec > 0 ? ad.timerSec.ToString() : "");
			textBox3.Text = (ad.timerQt > 0 ? ad.timerQt.ToString() : "");
			textBox4.Text = (ad.timerMax > 0 ? ad.timerMax.ToString() : "");
			textBox5.Text = ad.hotKey;
			active1.Checked = ad.Active;
		}

		public void worker_DoWork(object sender, DoWorkEventArgs e)
		{
			int i;
			while (!this.worker.CancellationPending)
			{
				if (this.nbInternalLoopMs > 0)
				{
					Thread.Sleep(this.nbInternalLoopMs);
				}
				DateTime now = DateTime.Now;
				TimeSpan timeSpan = now.Subtract(new DateTime(1970, 1, 9, 0, 0, 0));
				double totalSeconds = timeSpan.TotalSeconds;
				if (this.worker.CancellationPending)
				{
					break;
				}
				if (this.frmMain.chkUpdateList.Checked)
				{
					double num = 0;
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
				if (this.worker.CancellationPending)
				{
					break;
				}
				if (this.inventoryStartAddress >= (long)0)
				{
					if (this.items.Count > 0)
					{
						itemdata item = this.items[0];
						if (this.mem.GetStringAt(item.itemAddress) != string.Concat("@", item.itemID))
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
					if (this.worker.CancellationPending)
					{
						break;
					}
					string[] aCTIONSECTIONS = App.ACTION_SECTIONS;
					for (i = 0; i < (int)aCTIONSECTIONS.Length; i++)
					{
						string str = aCTIONSECTIONS[i];
						if (this.worker.CancellationPending)
						{
							break;
						}
						if (this.listActions.ContainsKey(str))
						{
							actiondata actiondatum = (actiondata)this.listActions[str];
							if (actiondatum != null)
							{
								this.executeActionData(actiondatum, false);
								if (this.nbSpacingMs > 0)
								{
									Thread.Sleep(this.nbSpacingMs);
								}
							}
						}
					}
					aCTIONSECTIONS = App.EXTENDED_ACTION_SECTIONS;
					for (i = 0; i < (int)aCTIONSECTIONS.Length; i++)
					{
						string str1 = aCTIONSECTIONS[i];
						if (this.worker.CancellationPending)
						{
							break;
						}
						if (this.listActions.ContainsKey(str1))
						{
							actiondata item1 = (actiondata)this.listActions[str1];
							if (item1 != null)
							{
								this.executeActionData(item1, false);
								if (this.nbSpacingMs > 0)
								{
									Thread.Sleep(this.nbSpacingMs);
								}
							}
						}
					}
					foreach (actiondata customAction in this.customActions)
					{
						if (!this.worker.CancellationPending)
						{
							if (customAction == null)
							{
								continue;
							}
							this.executeActionData(customAction, false);
							if (this.nbSpacingMs <= 0)
							{
								continue;
							}
							Thread.Sleep(this.nbSpacingMs);
						}
						else
						{
							goto Label0;
						}
					}
				}
			Label0:
				while (!this.worker.CancellationPending)
				{
					if (this.uiQueue.Count > 0)
					{
						this.worker.ReportProgress(0);
					}
					else
					{
						break;
					}
				}
				while (!this.worker.CancellationPending && this.workingQueue.Count > 0)
				{
					if (this.workingQueue.Dequeue().byteCode != QueueItemCode.REQUEST_SCAN)
					{
						continue;
					}
					this.FindItemsInMemory(false);
				}
			}
			e.Cancel = true;
			bool cancellationPending = this.worker.CancellationPending;
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
					{
						try
						{
							this.SetLblScan(queueItem.message);
							continue;
						}
						catch (Exception exception1)
						{
							Exception exception = exception1;
							MessageBox.Show(string.Concat("Error SetLblScan: ", exception.Message));
							continue;
						}
						break;
					}
					case QueueItemCode.UPDATE_ITEMS_LISTS:
					{
						if (queueItem.data == null)
						{
							continue;
						}
						this.updateItems((List<itemdata>)queueItem.data);
						continue;
					}
					case QueueItemCode.PUTLOG:
					{
						try
						{
							this.Putlog(queueItem.message);
							continue;
						}
						catch (Exception exception3)
						{
							Exception exception2 = exception3;
							MessageBox.Show(string.Concat("Error Putlog: ", exception2.Message));
							continue;
						}
						break;
					}
					case QueueItemCode.UIACTION:
					{
						try
						{
							this.executeUiAction(queueItem);
							continue;
						}
						catch (Exception exception5)
						{
							Exception exception4 = exception5;
							MessageBox.Show(string.Concat("Error: ", exception4.Message));
							continue;
						}
						break;
					}
					case QueueItemCode.UPDATE_EQUIPPED_LIST:
					{
						if (queueItem.data == null)
						{
							continue;
						}
						this.updateEquippedItems((List<itemdata>)queueItem.data);
						continue;
					}
					case QueueItemCode.UPDATE_POSITION:
					{
						this.updatePosition();
						continue;
					}
					case QueueItemCode.UPDATE_TIME:
					{
						this.updateTime();
						continue;
					}
					default:
					{
						continue;
					}
				}
			}
		}

		private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
		}

		public bool writeSettings(Settings s, string xmlfile)
		{
			return s.writeFile(xmlfile);
		}
	}
}