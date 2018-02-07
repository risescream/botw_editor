using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.Layout;

namespace botw_editor
{
  public class App
  {
    public static readonly string[] SECTIONS = new string[8]
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
    public static readonly string[] ACTION_SECTIONS = new string[4]
    {
      "Weapons",
      "Bows",
      "Shields",
      "Arrows"
    };
    public static readonly string[] EXTENDED_ACTION_SECTIONS = new string[17]
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
    private Queue<QueueItem> uiQueue = new Queue<QueueItem>();
    private Queue<QueueItem> workingQueue = new Queue<QueueItem>();
    public Dictionary<string, string> itemNames = new Dictionary<string, string>();
    private Dictionary<string, BindingList<itemdata>> lists = new Dictionary<string, BindingList<itemdata>>();
    private Dictionary<string, BindingSource> sources = new Dictionary<string, BindingSource>();
    private Dictionary<string, List<itemname>> names = new Dictionary<string, List<itemname>>();
    private BindingList<actiondata> customActions = new BindingList<actiondata>();
    private Dictionary<string, object> listActions = new Dictionary<string, object>();
    private BindingList<CapturedPosition> capturedPositions = new BindingList<CapturedPosition>();
    private long rupeesAddress = -1;
    private long inventoryStartAddress = -1;
    private long healthAddress = -1;
    private long staminaAddress = -1;
    private long equippedWeaponDurabilityAddress = -1;
    private long equippedBowDurabilityAddress = -1;
    private long equippedShieldDurabilityAddress = -1;
    private long divinePowersAddress = -1;
    private long amiiboDateAddress = -1;
    private long speedHackAddress = -1;
    private long weaponsSlotsAddress = -1;
    private long bowsSlotsAddress = -1;
    private long shieldsSlotsAddress = -1;
    private long weaponsSlotsPersistAddress = -1;
    private long bowsSlotsPersistAddress = -1;
    private long shieldsSlotsPersistAddress = -1;
    private long coordinatesAddress = -1;
    private long noStaminaBarAddress = -1;
    private long divinePowerMiphaTimerAddress = -1;
    private long divinePowerRevaliAddress = -1;
    private long divinePowerUrbosaAddress = -1;
    private long divinePowerDarukAddress = -1;
    public int nbInternalLoopMs = 100;
    private bool FlagEvent_1 = true;
    public List<MemoryChange> memoryChanges = new List<MemoryChange>();
    private FrmMain frmMain;
    public BackgroundWorker worker;
    private MemAPI mem;
    private BindingList<itemdata> items;
    private BindingList<itemdata> equipped;
    private float savedX;
    private float savedY;
    private float savedZ;
    private float lockedY;
    private const int divinePowerMiphaTimerOffset = 324;
    private const int divinePowerRevaliOffset = 0;
    private const int divinePowerUrbosaOffset = 4;
    private const int divinePowerDarukOffset = 8;
    public double timeLastUpdateList;
    public int nbSpacingMs;
    private globalKeyboardHook gKH;

    public bool InvokeRequired
    {
      get
      {
        if (this.frmMain == null)
          return false;
        return this.frmMain.InvokeRequired;
      }
    }

    public App(FrmMain frm)
    {
      this.mem = new MemAPI();
      this.mem.ProcessName = "Cemu";
      MemAPI.obj = (object) this;
      this.frmMain = frm;
      itemdata.parent = this;
      this.frmMain.btnActionsNew.Click += new EventHandler(this.btnActionsNew_Click);
      this.frmMain.btnActionsRemove.Click += new EventHandler(this.btnActionsRemove_Click);
      ListBox actionsRegistered = this.frmMain.lstActionsRegistered;
      BindingSource bindingSource1 = this.CreateBindingSource<actiondata>(this.customActions);
      actionsRegistered.DataSource = (object) bindingSource1;
      EventHandler eventHandler1 = new EventHandler(this.lstActionsRegistered_SelectedIndexChanged);
      actionsRegistered.SelectedIndexChanged += eventHandler1;
      EventHandler eventHandler2 = new EventHandler(this.lstActionsRegistered_SelectedValueChanged);
      actionsRegistered.SelectedValueChanged += eventHandler2;
      this.frmMain.cbActionsList.SelectedIndexChanged += new EventHandler(this.cbActionsList_SelectedIndexChanged);
      this.frmMain.txtActionsHotKey.TextChanged += new EventHandler(this.txtActionsHotKey_TextChanged);
      this.frmMain.txtActionsFixed.TextChanged += new EventHandler(this.txtActionsFixed_TextChanged);
      this.frmMain.txtActionsTimer.TextChanged += new EventHandler(this.txtActionsTimer_TextChanged);
      this.frmMain.txtActionsQuantity.TextChanged += new EventHandler(this.txtActionsQuantity_TextChanged);
      this.frmMain.txtActionsMax.TextChanged += new EventHandler(this.txtActionsMax_TextChanged);
      this.frmMain.chkActionsDisableWhenDone.CheckedChanged += new EventHandler(this.chkActionsDisableWhenDone_CheckedChanged);
      CheckBox actionsUseHotkey = this.frmMain.chkActionsUseHotkey;
      EventHandler eventHandler3 = new EventHandler(this.chkActionsUseHotKey_CheckedChanged);
      actionsUseHotkey.CheckedChanged += eventHandler3;
      this.frmMain.chkActionsActiveInactive.CheckedChanged += new EventHandler(this.chkActionsActiveInactive_CheckedChanged);
      this.frmMain.optionActionsFixed.CheckedChanged += new EventHandler(this.optionActionsFixed_CheckedChanged);
      this.frmMain.optionActionsTimer.CheckedChanged += new EventHandler(this.optionActionsTimer_CheckedChanged);
      this.frmMain.optionActionsNoFilter.CheckedChanged += new EventHandler(this.optionActionsNoFilter_CheckedChanged);
      this.frmMain.optionActionsFilterList.CheckedChanged += new EventHandler(this.optionActionsFilterList_CheckedChanged);
      this.frmMain.lstActionsFilter.DoubleClick += new EventHandler(this.lstActionsFilter_DoubleClick);
      EventHandler eventHandler4 = new EventHandler(this.chkUseHotKey_CheckedChanged);
      actionsUseHotkey.CheckedChanged += eventHandler4;
      foreach (string key in App.SECTIONS)
      {
        this.lists.Add(key, new BindingList<itemdata>());
        this.sources.Add(key, this.CreateBindingSource<itemdata>(this.lists[key]));
        this.names.Add(key, new List<itemname>());
        ListBox control1 = (ListBox) this.findControl("lst" + key);
        if (control1 != null)
        {
          control1.DataSource = (object) this.sources[key];
          control1.SelectedIndexChanged += new EventHandler(this.lst_SelectedIndexChanged);
          control1.DoubleClick += new EventHandler(this.lst_DoubleClick);
        }
        Button control2 = (Button) this.findControl("btn" + key + "ItemUpdate");
        if (control2 != null)
          control2.Click += new EventHandler(this.btnItemUpdate_Click);
        Button control3 = (Button) this.findControl("btn" + key + "ItemUnlock");
        if (control3 != null)
          control3.Click += new EventHandler(this.btnItemUnlock_Click);
        ComboBox control4 = (ComboBox) this.findControl("cb" + key + "ItemName");
        if (control4 != null)
          control4.SelectedIndexChanged += new EventHandler(this.cbItemName_SelectedIndexChanged);
      }
      this.names.Add("All", new List<itemname>());
      Button btnRefreshRupees = this.frmMain.btnRefreshRupees;
      Button btnUpdateRupees = this.frmMain.btnUpdateRupees;
      btnRefreshRupees.Click += new EventHandler(this.btnRefreshRupees_Click);
      EventHandler eventHandler5 = new EventHandler(this.btnUpdateRupees_Click);
      btnUpdateRupees.Click += eventHandler5;
      this.items = this.lists["Inventory"];
      this.lists.Add("Equipped", new BindingList<itemdata>());
      this.equipped = this.lists["Equipped"];
      ListBox lstEquippedWeapons = this.frmMain.lstEquippedWeapons;
      BindingList<itemdata> equipped = this.equipped;
      lstEquippedWeapons.DataSource = (object) equipped;
      EventHandler eventHandler6 = new EventHandler(this.lst_DoubleClick);
      lstEquippedWeapons.DoubleClick += eventHandler6;
      foreach (string key in App.ACTION_SECTIONS)
      {
        actiondata actiondata = new actiondata();
        actiondata.filterList = new BList<itemdata>();
        actiondata.section = key;
        ListBox control1 = (ListBox) this.findControl("lst" + key + "Filter");
        this.listActions.Add(key, (object) actiondata);
        BindingSource bindingSource2 = this.CreateBindingSource<itemdata>((BindingList<itemdata>) actiondata.filterList);
        control1.DataSource = (object) bindingSource2;
        EventHandler eventHandler7 = new EventHandler(this.lstActionsFilter_DoubleClick);
        control1.DoubleClick += eventHandler7;
        CheckBox control2 = (CheckBox) this.findControl("chk" + key + "UseHotkey");
        if (control2 != null)
          control2.CheckedChanged += new EventHandler(this.chkUseHotKey_CheckedChanged);
      }
      BList<itemdata> blist = new BList<itemdata>();
      ListBox control5 = (ListBox) this.findControl("lstUnbreakableFilter");
      BindingSource bindingSource3 = this.CreateBindingSource<itemdata>((BindingList<itemdata>) blist);
      control5.DataSource = (object) bindingSource3;
      EventHandler eventHandler8 = new EventHandler(this.lstActionsFilter_DoubleClick);
      control5.DoubleClick += eventHandler8;
      foreach (string key in App.EXTENDED_ACTION_SECTIONS)
      {
        this.listActions.Add(key, (object) new actiondata()
        {
          section = key,
          filterList = blist
        });
        CheckBox control1 = (CheckBox) this.findControl("chk" + key + "UseHotkey");
        if (control1 != null)
          control1.CheckedChanged += new EventHandler(this.chkUseHotKey_CheckedChanged);
      }
      ListBox control6 = (ListBox) this.findControl("lstCapturedPositions");
      BindingList<CapturedPosition> capturedPositions = this.capturedPositions;
      control6.DataSource = (object) capturedPositions;
      EventHandler eventHandler9 = new EventHandler(this.LstCapturedPositions_SelectedIndexChanged);
      control6.SelectedIndexChanged += eventHandler9;
      EventHandler eventHandler10 = new EventHandler(this.LstCapturedPositions_DoubleClick);
      control6.DoubleClick += eventHandler10;
      Settings s = this.readSettings(Settings.getConfigFilePath());
      if (s != null && this.applySettings(s))
        this.Putlog("Settings loaded from " + Settings.getConfigFilePath());
      else
        this.Putlog("No settings loaded.");
      if (!this.frmMain.chkUpdateList.Checked)
        this.Putlog("Click the Scan Memory button to start.");
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
      int num = 100;
      try
      {
        num = Convert.ToInt32(this.frmMain.numInternalLoopMs.Value);
      }
      catch (Exception ex)
      {
      }
      return num;
    }

    public int getSpacingMsValue()
    {
      int num = 0;
      try
      {
        num = Convert.ToInt32(this.frmMain.numSpacingMs.Value);
      }
      catch (Exception ex)
      {
      }
      return num;
    }

    public Settings getCurrentSettings()
    {
      Settings settings = new Settings();
      settings.auto_update_timer = App.StringToInt32(this.frmMain.txtTimerUpdateList.Text);
      settings.auto_update = this.frmMain.chkUpdateList.Checked;
      settings.internalLoopMs = this.getInternalLoopMsValue();
      settings.spacingMs = this.getSpacingMsValue();
      foreach (KeyValuePair<string, string> itemName in this.itemNames)
      {
        settings.item_ids.Add(itemName.Key);
        settings.item_names.Add(itemName.Value);
      }
      foreach (KeyValuePair<string, object> listAction in this.listActions)
      {
        actiondata actiondata = (actiondata) listAction.Value;
        settings.action_keys.Add(listAction.Key);
        settings.action_datas.Add(actiondata);
      }
      foreach (actiondata customAction in (Collection<actiondata>) this.customActions)
        settings.custom_actions.Add(customAction);
      settings.capturedPositions = this.capturedPositions.ToList<CapturedPosition>();
      return settings;
    }

    public bool applySettings(Settings s)
    {
      if (s == null)
        return false;
      this.frmMain.txtTimerUpdateList.Text = s.auto_update_timer.ToString();
      this.frmMain.chkUpdateList.Checked = s.auto_update;
      this.frmMain.numInternalLoopMs.Value = (Decimal) s.internalLoopMs;
      this.frmMain.numSpacingMs.Value = (Decimal) s.spacingMs;
      this.nbInternalLoopMs = s.internalLoopMs;
      this.nbSpacingMs = s.spacingMs;
      this.itemNames.Clear();
      for (int index = 0; index < s.item_ids.Count && index < s.item_names.Count; ++index)
        this.itemNames.Add(s.item_ids[index], s.item_names[index]);
      this.listActions.Clear();
      foreach (string key in App.ACTION_SECTIONS)
      {
        actiondata actiondata = new actiondata();
        actiondata.filterList = new BList<itemdata>();
        actiondata.section = key;
        ListBox control = (ListBox) this.findControl("lst" + key + "Filter");
        this.listActions.Add(key, (object) actiondata);
        BindingSource bindingSource = this.CreateBindingSource<itemdata>((BindingList<itemdata>) actiondata.filterList);
        control.DataSource = (object) bindingSource;
      }
      foreach (string key in App.EXTENDED_ACTION_SECTIONS)
        this.listActions.Add(key, (object) new actiondata()
        {
          section = key,
          filterList = (BList<itemdata>) null
        });
      for (int index = 0; index < s.action_keys.Count && index < s.action_datas.Count; ++index)
      {
        if (this.listActions.ContainsKey(s.action_keys[index]))
          this.listActions[s.action_keys[index]] = (object) s.action_datas[index];
        else
          this.listActions.Add(s.action_keys[index], (object) s.action_datas[index]);
      }
      foreach (KeyValuePair<string, object> listAction in this.listActions)
      {
        BList<itemdata> blist = (BList<itemdata>) null;
        if (Array.IndexOf<string>(App.EXTENDED_ACTION_SECTIONS, listAction.Key) >= 0)
        {
          actiondata actiondata = (actiondata) listAction.Value;
          if (blist == null)
          {
            BList<itemdata> filterList = actiondata.filterList;
          }
          else
            actiondata.filterList = blist;
        }
        this.updateUiFromActionData((actiondata) listAction.Value);
      }
      this.customActions.Clear();
      for (int index = 0; index < s.custom_actions.Count; ++index)
        this.customActions.Add(s.custom_actions[index]);
      foreach (KeyValuePair<string, BindingSource> source in this.sources)
      {
        for (int itemIndex = 0; itemIndex < source.Value.Count; ++itemIndex)
          source.Value.ResetItem(itemIndex);
      }
      this.capturedPositions.Clear();
      foreach (CapturedPosition capturedPosition in s.capturedPositions)
        this.capturedPositions.Add(capturedPosition);
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
      Predicate<char> match = (Predicate<char>) (value =>
      {
        if (((int) value < 32 || (int) value > 55295) && ((int) value < 57344 || (int) value > 65533) && ((int) value != 9 && (int) value != 10))
          return (int) value == 13;
        return true;
      });
      return new string(Array.FindAll<char>(input.ToCharArray(), match));
    }

    public void suspendGame()
    {
      this.mem.UpdateProcess("");
      if (this.mem.p != null)
      {
        MemAPI.SuspendProcess(this.mem.p);
        this.Putlog("Game process suspended.");
      }
      else
        this.Putlog("Could not find process '" + this.mem.ProcessName + "'.");
    }

    public void resumeGame()
    {
      this.mem.UpdateProcess("");
      if (this.mem.p != null)
      {
        MemAPI.ResumeProcess(this.mem.p);
        this.Putlog("Game process resumed.");
      }
      else
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
        this.inventoryStartAddress = -1L;
      this.coordinatesAddress = -1L;
    }

    private void chkUseHotKey_CheckedChanged(object sender, EventArgs e)
    {
      CheckBox checkBox = (CheckBox) sender;
      if (checkBox.Checked)
        return;
      string str = checkBox.Name.Replace("chk", "").Replace("UseHotkey", "");
      TextBox control = (TextBox) this.findControl("txt" + str + "HotKey");
      if (control == null || !(control.GetType() == typeof (TextBox)) || !(control.Text != ""))
        return;
      this.TextControl("txt" + str + "HotKey", "");
    }

    public int GetRupees()
    {
      int num = -1;
      if (this.rupeesAddress >= 0L)
        num = this.mem.GetInt32At(this.rupeesAddress);
      return num;
    }

    public void SetRupees(int value)
    {
      if (this.rupeesAddress < 0L)
        return;
      this.mem.SetInt32At(this.rupeesAddress, value);
      this.mem.SetInt32At(this.rupeesAddress - 4704656L, value);
    }

    private void btnUpdateRupees_Click(object sender, EventArgs e)
    {
      if (this.GetRupees() >= 0)
      {
        this.SetRupees(App.StringToInt32(this.frmMain.txtRupees.Text));
        this.SetTextBoxText(this.frmMain.txtRupees, this.GetRupees().ToString());
      }
      else
      {
        this.SetTextBoxText(this.frmMain.txtRupees, "");
        this.EnableControl("gbRupees", false);
      }
    }

    private void btnRefreshRupees_Click(object sender, EventArgs e)
    {
      int rupees = this.GetRupees();
      if (rupees >= 0)
      {
        this.SetTextBoxText(this.frmMain.txtRupees, rupees.ToString());
      }
      else
      {
        this.SetTextBoxText(this.frmMain.txtRupees, "");
        this.EnableControl("gbRupees", false);
      }
    }

    private void lstActionsFilter_DoubleClick(object sender, EventArgs e)
    {
      ListBox listBox = (ListBox) sender;
      itemdata selectedItem = (itemdata) listBox.SelectedItem;
      if (selectedItem == null)
        return;
      BindingSource dataSource = (BindingSource) listBox.DataSource;
      BindingList<itemdata> bindingList = dataSource == null || dataSource.DataSource == null ? (BindingList<itemdata>) null : (BindingList<itemdata>) dataSource.DataSource;
      if (bindingList == null)
        return;
      bindingList.Remove(selectedItem);
      for (int itemIndex = 0; itemIndex < dataSource.Count; ++itemIndex)
        dataSource.ResetItem(itemIndex);
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
        globalKeyboardHook.keyboardHookStruct lastKey1 = this.gKH.lastKey;
        globalKeyboardHook.keyboardHookStruct lastKey2 = this.gKH.lastKey;
        globalKeyboardHook.keyboardHookStruct lastKey3 = this.gKH.lastKey;
        globalKeyboardHook.keyboardHookStruct lastKey4 = this.gKH.lastKey;
        string keyText = this.gKH.GetKeyText(ref this.gKH.lastKey);
        txtActionsHotKey.Text = keyText;
        e.Handled = true;
      }
      else
      {
        bool flag = false;
        foreach (string str in App.ACTION_SECTIONS)
        {
          TextBox control = (TextBox) this.findControl("txt" + str + "HotKey");
          if (control.Focused)
          {
            globalKeyboardHook.keyboardHookStruct lastKey1 = this.gKH.lastKey;
            globalKeyboardHook.keyboardHookStruct lastKey2 = this.gKH.lastKey;
            globalKeyboardHook.keyboardHookStruct lastKey3 = this.gKH.lastKey;
            globalKeyboardHook.keyboardHookStruct lastKey4 = this.gKH.lastKey;
            string keyText = this.gKH.GetKeyText(ref this.gKH.lastKey);
            control.Text = keyText;
            e.Handled = true;
            flag = true;
            break;
          }
        }
        if (flag)
          return;
        foreach (string str in App.EXTENDED_ACTION_SECTIONS)
        {
          TextBox control = (TextBox) this.findControl("txt" + str + "HotKey");
          if (control.Focused)
          {
            globalKeyboardHook.keyboardHookStruct lastKey1 = this.gKH.lastKey;
            globalKeyboardHook.keyboardHookStruct lastKey2 = this.gKH.lastKey;
            globalKeyboardHook.keyboardHookStruct lastKey3 = this.gKH.lastKey;
            globalKeyboardHook.keyboardHookStruct lastKey4 = this.gKH.lastKey;
            string keyText = this.gKH.GetKeyText(ref this.gKH.lastKey);
            control.Text = keyText;
            e.Handled = true;
            break;
          }
        }
      }
      bool flag1 = false;
      if (!e.Handled && WinAPI.ApplicationIsActivated())
      {
        Control focusedControl = WinAPI.FindFocusedControl((Control) this.frmMain);
        if (focusedControl != null && focusedControl.GetType() == typeof (TextBox))
          flag1 = true;
      }
      if (flag1 || e.Handled)
        return;
      string keyText1 = this.gKH.GetKeyText(ref this.gKH.lastKey);
      bool flag2 = false;
      int num = 0;
      foreach (actiondata ad in this.listActions.Values.ToArray<object>())
      {
        if (ad.UseHotKey && ad.hotKey != "" && ad.hotKey == keyText1)
        {
          ad.Active = !ad.Active;
          flag2 = true;
          ++num;
          this.updateUiFromActionData(ad);
        }
      }
      foreach (actiondata ad in this.customActions.ToArray<actiondata>())
      {
        if (ad.UseHotKey && ad.hotKey != "" && ad.hotKey == keyText1)
        {
          ad.Active = !ad.Active;
          flag2 = true;
          ++num;
          this.updateUiFromActionData(ad);
        }
      }
      if (!flag2)
        return;
      this.FlagEvent_1 = false;
      this.updateActionsSelected();
      this.FlagEvent_1 = true;
      this.Putlog("HotKey '" + keyText1 + "' triggered. Settings affected: " + num.ToString());
    }

    private void cbActionsList_SelectedIndexChanged(object sender, EventArgs e)
    {
      ComboBox comboBox = (ComboBox) sender;
      if (comboBox.Items.Count == 0)
        return;
      actiondata selectedItem = (actiondata) this.frmMain.lstActionsRegistered.SelectedItem;
      if (selectedItem == null)
        return;
      selectedItem.type = (ActionType) comboBox.SelectedIndex;
      BindingSource dataSource = (BindingSource) this.frmMain.lstActionsRegistered.DataSource;
      if (dataSource != null && dataSource.Current != null)
        dataSource.ResetCurrentItem();
      this.updateCurrentAction();
    }

    public itemdata getEquippedWeapon()
    {
      itemdata itemdata1 = (itemdata) null;
      foreach (itemdata itemdata2 in (Collection<itemdata>) this.equipped)
      {
        if (itemdata2.isWeapon)
        {
          itemdata1 = itemdata2;
          break;
        }
      }
      return itemdata1;
    }

    public itemdata getEquippedBow()
    {
      itemdata itemdata1 = (itemdata) null;
      foreach (itemdata itemdata2 in (Collection<itemdata>) this.equipped)
      {
        if (itemdata2.isBow)
        {
          itemdata1 = itemdata2;
          break;
        }
      }
      return itemdata1;
    }

    public itemdata getEquippedShield()
    {
      itemdata itemdata1 = (itemdata) null;
      foreach (itemdata itemdata2 in (Collection<itemdata>) this.equipped)
      {
        if (itemdata2.isShield)
        {
          itemdata1 = itemdata2;
          break;
        }
      }
      return itemdata1;
    }

    public void executeActionData(actiondata ad, bool force = false)
    {
      if (ad.mode == ActionMode.TIMER)
      {
        if (ad.timerSec < 0 || ad.timerQt <= 0 || ad.timerMax <= 0)
          return;
      }
      else if (ad.mode == ActionMode.FIXED && ad.fixedValue < 0)
        return;
      double totalSeconds = DateTime.Now.Subtract(new DateTime(1970, 1, 9, 0, 0, 0)).TotalSeconds;
      if (!force && (ad.mode != ActionMode.TIMER || totalSeconds - ad.timeLast < (double) ad.timerSec) && ad.mode != ActionMode.FIXED)
        return;
      if (ad.section != "")
      {
        if (Array.IndexOf<string>(App.ACTION_SECTIONS, ad.section) > -1)
        {
          string key = ad.section;
          if (ad.section == "Bows" || ad.section == "Arrows")
            key = "Archery";
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
              foreach (itemdata itemdata in (Collection<itemdata>) this.lists[key])
              {
                if ((!itemdata.isWeaponBowShield || this.findItemByAddr(itemdata.itemAddress, this.equipped.ToList<itemdata>()) == null) && (!(ad.section == "Arrows") || itemdata.itemID.Contains("Arrow")) && ((!(ad.section != "Arrows") || !itemdata.itemID.Contains("Arrow")) && (!ad.UseFilter || this.findItemByID(itemdata.itemID, ad.filterList.ToList<itemdata>()) != null)) && (ad.mode != ActionMode.FIXED || ad.HiddenTimerElapsed()))
                {
                  if (ad.mode == ActionMode.FIXED)
                  {
                    ad.HiddenTimerSec = 2;
                    this.mem.SetInt32At(itemdata.itemQtDurAddress, ad.fixedValue);
                    ad.HiddenTimerTick();
                    ++ad.counter;
                  }
                  else if (ad.mode == ActionMode.TIMER)
                  {
                    int int32At = this.mem.GetInt32At(itemdata.itemQtDurAddress);
                    if (int32At < ad.timerMax)
                    {
                      int num = int32At + ad.timerQt <= ad.timerMax ? ad.timerQt : ad.timerMax - int32At;
                      this.mem.SetInt32At(itemdata.itemQtDurAddress, int32At + num);
                      ++ad.counter;
                    }
                    if (int32At + ad.timerQt < ad.timerMax)
                      flag = false;
                  }
                }
              }
            }
            if (ad.Active & flag && ad.StopWhenDone)
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
            if (ad.timerSec > 0 && totalSeconds - ad.timeLast >= (double) ad.timerSec)
              ad.timerSec = 0;
            else if (ad.timerSec > 0)
              return;
            if (this.healthAddress == -1L)
            {
              long regionStart;
              long regionSize1;
              if (this.mem.FindRegionByAddr(this.inventoryStartAddress, out regionStart, out regionSize1, IntPtr.Zero, true))
              {
                long num = regionStart + regionSize1;
                if (this.inventoryStartAddress > 0L)
                  num = this.inventoryStartAddress;
                if (this.speedHackAddress > 0L)
                  num = this.speedHackAddress;
                if (this.coordinatesAddress > 0L)
                  regionStart = this.coordinatesAddress;
                if (this.rupeesAddress > 0L)
                  regionStart = this.rupeesAddress;
                if (this.weaponsSlotsAddress > 0L)
                  regionStart = this.weaponsSlotsAddress;
                if (this.bowsSlotsAddress > 0L)
                  regionStart = this.bowsSlotsAddress;
                if (this.shieldsSlotsAddress > 0L)
                  regionStart = this.shieldsSlotsAddress;
                long regionSize2 = num - regionStart;
                this.TextControl("lbl" + ad.section + "Info", "Scanning memory...");
                this.Putlog("[" + ad.section + "] Scanning memory...");
                this.healthAddress = this.findHealthAddress(regionStart, regionSize2);
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
              this.Putlog("[" + ad.section + "] Warning ! Null or Negative value : " + (object) ad.fixedValue);
            }
            else
              this.mem.SetInt32At(this.healthAddress, ad.fixedValue);
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
            if (ad.timerSec > 0 && totalSeconds - ad.timeLast >= (double) ad.timerSec)
              ad.timerSec = 0;
            else if (ad.timerSec > 0)
              return;
            if (this.staminaAddress == -1L)
            {
              long regionStart;
              long regionSize1;
              if (this.mem.FindRegionByAddr(this.inventoryStartAddress, out regionStart, out regionSize1, IntPtr.Zero, true))
              {
                long num = regionStart + regionSize1;
                if (this.inventoryStartAddress > 0L)
                  num = this.inventoryStartAddress;
                if (this.speedHackAddress > 0L)
                  num = this.speedHackAddress;
                if (this.coordinatesAddress > 0L)
                  regionStart = this.coordinatesAddress;
                if (this.rupeesAddress > 0L)
                  regionStart = this.rupeesAddress;
                if (this.weaponsSlotsAddress > 0L)
                  regionStart = this.weaponsSlotsAddress;
                if (this.bowsSlotsAddress > 0L)
                  regionStart = this.bowsSlotsAddress;
                if (this.shieldsSlotsAddress > 0L)
                  regionStart = this.shieldsSlotsAddress;
                long regionSize2 = num - regionStart;
                this.TextControl("lbl" + ad.section + "Info", "Scanning memory...");
                this.Putlog("[" + ad.section + "] Scanning memory...");
                this.staminaAddress = this.findStaminaAddress(regionStart, regionSize2);
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
              this.Putlog("[" + ad.section + "] Warning ! Null or Negative value : " + (object) ad.fixedValue);
            }
            else
              this.mem.SetInt32At(this.staminaAddress, ad.fixedValue);
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
            if (ad.timerSec > 0 && totalSeconds - ad.timeLast >= (double) ad.timerSec)
              ad.timerSec = 0;
            else if (ad.timerSec > 0)
              return;
            if (this.equippedWeaponDurabilityAddress == -1L)
            {
              foreach (itemdata itemdata in this.equipped.ToList<itemdata>())
              {
                if (itemdata.isWeapon)
                {
                  this.TextControl("lbl" + ad.section + "Info", "Scanning memory...");
                  this.Putlog("[" + ad.section + "] Scanning memory...");
                  this.equippedWeaponDurabilityAddress = this.findEquippedDurabilityAddress(itemdata);
                  if (this.equippedWeaponDurabilityAddress >= 0L)
                  {
                    this.TextControl("lbl" + ad.section + "Info", "Found offset at 0x" + this.equippedWeaponDurabilityAddress.ToString("X"));
                    this.Putlog("[" + ad.section + "] Found offset at 0x" + this.equippedWeaponDurabilityAddress.ToString("X"));
                    ad.fixedValue = this.mem.GetInt32At(this.equippedWeaponDurabilityAddress);
                    if (ad.fixedValue < 1000)
                    {
                      ad.fixedValue = 7777;
                      if (!ad.UseFilter || this.findItemByID(itemdata.itemID, ad.filterList.ToList<itemdata>()) != null)
                      {
                        this.mem.SetInt32At(this.equippedWeaponDurabilityAddress, ad.fixedValue);
                        this.mem.SetInt32At(itemdata.itemQtDurAddress, ad.fixedValue);
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
            }
            else if (ad.fixedValue <= 0)
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
            if (ad.timerSec > 0 && totalSeconds - ad.timeLast >= (double) ad.timerSec)
              ad.timerSec = 0;
            else if (ad.timerSec > 0)
              return;
            if (this.equippedBowDurabilityAddress == -1L)
            {
              foreach (itemdata itemdata in (Collection<itemdata>) this.equipped)
              {
                if (itemdata.isBow)
                {
                  this.TextControl("lbl" + ad.section + "Info", "Scanning memory...");
                  this.Putlog("[" + ad.section + "] Scanning memory...");
                  this.equippedBowDurabilityAddress = this.findEquippedDurabilityAddress(itemdata);
                  if (this.equippedBowDurabilityAddress >= 0L)
                  {
                    this.TextControl("lbl" + ad.section + "Info", "Found offset at 0x" + this.equippedBowDurabilityAddress.ToString("X"));
                    this.Putlog("[" + ad.section + "] Found offset at 0x" + this.equippedBowDurabilityAddress.ToString("X"));
                    ad.fixedValue = this.mem.GetInt32At(this.equippedBowDurabilityAddress);
                    if (ad.fixedValue < 1000)
                    {
                      ad.fixedValue = 7776;
                      if (!ad.UseFilter || this.findItemByID(itemdata.itemID, ad.filterList.ToList<itemdata>()) != null)
                      {
                        this.mem.SetInt32At(this.equippedBowDurabilityAddress, ad.fixedValue);
                        this.mem.SetInt32At(itemdata.itemQtDurAddress, ad.fixedValue);
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
            }
            else if (ad.fixedValue <= 0)
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
            if (ad.timerSec > 0 && totalSeconds - ad.timeLast >= (double) ad.timerSec)
              ad.timerSec = 0;
            else if (ad.timerSec > 0)
              return;
            if (this.equippedShieldDurabilityAddress == -1L)
            {
              foreach (itemdata itemdata in (Collection<itemdata>) this.equipped)
              {
                if (itemdata.isShield)
                {
                  this.TextControl("lbl" + ad.section + "Info", "Scanning memory...");
                  this.Putlog("[" + ad.section + "] Scanning memory...");
                  this.equippedShieldDurabilityAddress = this.findEquippedDurabilityAddress(itemdata);
                  if (this.equippedShieldDurabilityAddress >= 0L)
                  {
                    this.TextControl("lbl" + ad.section + "Info", "Found offset at 0x" + this.equippedShieldDurabilityAddress.ToString("X"));
                    this.Putlog("[" + ad.section + "] Found offset at 0x" + this.equippedShieldDurabilityAddress.ToString("X"));
                    ad.fixedValue = this.mem.GetInt32At(this.equippedShieldDurabilityAddress);
                    if (ad.fixedValue < 1000)
                    {
                      ad.fixedValue = 7775;
                      if (!ad.UseFilter || this.findItemByID(itemdata.itemID, ad.filterList.ToList<itemdata>()) != null)
                      {
                        this.mem.SetInt32At(this.equippedShieldDurabilityAddress, ad.fixedValue);
                        this.mem.SetInt32At(itemdata.itemQtDurAddress, ad.fixedValue);
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
            }
            else if (ad.fixedValue <= 0)
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
            if (ad.timerSec > 0 && totalSeconds - ad.timeLast >= (double) ad.timerSec)
              ad.timerSec = 0;
            else if (ad.timerSec > 0)
              return;
            if (this.divinePowerMiphaTimerAddress == -1L)
            {
              long regionStart;
              long regionSize;
              if (this.mem.FindRegionByAddr(this.inventoryStartAddress, out regionStart, out regionSize, IntPtr.Zero, true))
              {
                this.TextControl("lbl" + ad.section + "Info", "Scanning memory...");
                this.Putlog("[" + ad.section + "] Scanning memory...");
                int num1 = 324;
                long num2 = -1;
                if (this.divinePowerMiphaTimerAddress != -1L)
                  num2 = this.divinePowerMiphaTimerAddress - 324L;
                if (this.divinePowerRevaliAddress != -1L)
                  num2 = this.divinePowerRevaliAddress;
                if (this.divinePowerUrbosaAddress != -1L)
                  num2 = this.divinePowerUrbosaAddress - 4L;
                if (this.divinePowerDarukAddress != -1L)
                  num2 = this.divinePowerDarukAddress - 8L;
                long num3 = num2 == -1L ? this.findPowersAddress(regionStart, this.inventoryStartAddress - regionStart) : num2;
                if (num3 >= 0L)
                {
                  this.divinePowerMiphaTimerAddress = num3 + (long) num1;
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
              if ((int) this.mem.GetByteAt(this.divinePowerMiphaTimerAddress) < 190)
                this.mem.SetByteAt(this.divinePowerMiphaTimerAddress, (byte) ad.fixedValue);
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
            if (ad.timerSec > 0 && totalSeconds - ad.timeLast >= (double) ad.timerSec)
              ad.timerSec = 0;
            else if (ad.timerSec > 0)
              return;
            if (this.divinePowerRevaliAddress == -1L)
            {
              long regionStart;
              long regionSize;
              if (this.mem.FindRegionByAddr(this.inventoryStartAddress, out regionStart, out regionSize, IntPtr.Zero, true))
              {
                this.TextControl("lbl" + ad.section + "Info", "Scanning memory...");
                this.Putlog("[" + ad.section + "] Scanning memory...");
                int num1 = 0;
                long num2 = -1;
                if (this.divinePowerMiphaTimerAddress != -1L)
                  num2 = this.divinePowerMiphaTimerAddress - 324L;
                if (this.divinePowerRevaliAddress != -1L)
                  num2 = this.divinePowerRevaliAddress;
                if (this.divinePowerUrbosaAddress != -1L)
                  num2 = this.divinePowerUrbosaAddress - 4L;
                if (this.divinePowerDarukAddress != -1L)
                  num2 = this.divinePowerDarukAddress - 8L;
                long num3 = num2 == -1L ? this.findPowersAddress(regionStart, this.inventoryStartAddress - regionStart) : num2;
                if (num3 >= 0L)
                {
                  this.divinePowerRevaliAddress = num3 + (long) num1;
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
            if (ad.timerSec > 0 && totalSeconds - ad.timeLast >= (double) ad.timerSec)
              ad.timerSec = 0;
            else if (ad.timerSec > 0)
              return;
            if (this.divinePowerUrbosaAddress == -1L)
            {
              long regionStart;
              long regionSize;
              if (this.mem.FindRegionByAddr(this.inventoryStartAddress, out regionStart, out regionSize, IntPtr.Zero, true))
              {
                this.TextControl("lbl" + ad.section + "Info", "Scanning memory...");
                this.Putlog("[" + ad.section + "] Scanning memory...");
                int num1 = 4;
                long num2 = -1;
                if (this.divinePowerMiphaTimerAddress != -1L)
                  num2 = this.divinePowerMiphaTimerAddress - 324L;
                if (this.divinePowerRevaliAddress != -1L)
                  num2 = this.divinePowerRevaliAddress;
                if (this.divinePowerUrbosaAddress != -1L)
                  num2 = this.divinePowerUrbosaAddress - 4L;
                if (this.divinePowerDarukAddress != -1L)
                  num2 = this.divinePowerDarukAddress - 8L;
                long num3 = num2 == -1L ? this.findPowersAddress(regionStart, this.inventoryStartAddress - regionStart) : num2;
                if (num3 >= 0L)
                {
                  this.divinePowerUrbosaAddress = num3 + (long) num1;
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
            if (ad.timerSec > 0 && totalSeconds - ad.timeLast >= (double) ad.timerSec)
              ad.timerSec = 0;
            else if (ad.timerSec > 0)
              return;
            if (this.divinePowerDarukAddress == -1L)
            {
              long regionStart;
              long regionSize;
              if (this.mem.FindRegionByAddr(this.inventoryStartAddress, out regionStart, out regionSize, IntPtr.Zero, true))
              {
                this.TextControl("lbl" + ad.section + "Info", "Scanning memory...");
                this.Putlog("[" + ad.section + "] Scanning memory...");
                int num1 = 8;
                long num2 = -1;
                if (this.divinePowerMiphaTimerAddress != -1L)
                  num2 = this.divinePowerMiphaTimerAddress - 324L;
                if (this.divinePowerRevaliAddress != -1L)
                  num2 = this.divinePowerRevaliAddress;
                if (this.divinePowerUrbosaAddress != -1L)
                  num2 = this.divinePowerUrbosaAddress - 4L;
                if (this.divinePowerDarukAddress != -1L)
                  num2 = this.divinePowerDarukAddress - 8L;
                long num3 = num2 == -1L ? this.findPowersAddress(regionStart, this.inventoryStartAddress - regionStart) : num2;
                if (num3 >= 0L)
                {
                  this.divinePowerDarukAddress = num3 + (long) num1;
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
                  this.mem.SetInt32At(this.amiiboDateAddress, ad.fixedValue);
                this.amiiboDateAddress = -1L;
                this.Putlog("[" + ad.section + "] Disabled.");
              }
              ad.fixedValue = 0;
              return;
            }
            if (ad.timerSec > 0 && totalSeconds - ad.timeLast >= (double) ad.timerSec)
              ad.timerSec = 0;
            else if (ad.timerSec > 0)
              return;
            if (this.amiiboDateAddress == -1L)
            {
              long regionStart;
              long regionSize;
              if (this.mem.FindRegionByAddr(this.inventoryStartAddress, out regionStart, out regionSize, IntPtr.Zero, true))
              {
                this.TextControl("lbl" + ad.section + "Info", "Scanning memory...");
                this.Putlog("[" + ad.section + "] Scanning memory...");
                long amiiboDateAddress = this.findAmiiboDateAddress(regionStart, this.inventoryStartAddress - regionStart);
                if (amiiboDateAddress >= 0L)
                {
                  this.amiiboDateAddress = amiiboDateAddress;
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
              if ((double) ad.singleValue != 0.0)
              {
                this.lockedY = 0.0f;
                this.Putlog("[" + ad.section + "] Disabled.");
              }
              ad.singleValue = 0.0f;
              return;
            }
            if (ad.timerSec > 0 && totalSeconds - ad.timeLast >= (double) ad.timerSec)
              ad.timerSec = 0;
            else if (ad.timerSec > 0)
              return;
            if ((double) this.lockedY == 0.0)
            {
              this.lockedY = this.mem.GetSingleAt(this.coordinatesAddress + 4L);
              ad.singleValue = this.lockedY;
              this.Putlog("[" + ad.section + "] Locking Altitude (Y) to " + ad.singleValue.ToString());
            }
            else
              this.mem.SetSingleAt(this.coordinatesAddress + 4L, ad.singleValue);
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
      }
      else if (!ad.Active)
      {
        if (ad.counter < 0L)
          return;
        this.Putlog("[Restore " + ad.ToString() + "] Disabled.");
        ad.counter = -1L;
      }
      else
      {
        if (ad.counter == -1L)
        {
          this.Putlog("[Restore " + ad.ToString() + "] Enabled.");
          ad.counter = 0L;
        }
        string key = "";
        if (ad.type == ActionType.SET_BOWS_DUR)
          key = "Archery";
        if (ad.type == ActionType.SET_WEAPONS_DUR)
          key = "Weapons";
        if (ad.type == ActionType.SET_SHIELDS_DUR)
          key = "Shields";
        if (ad.type == ActionType.SET_ITEMS_QT)
          key = "Inventory";
        if (key != "" && this.lists.ContainsKey(key))
        {
          bool flag = true;
          foreach (itemdata itemdata in (Collection<itemdata>) this.lists[key])
          {
            if ((!itemdata.isWeaponBowShield || this.findItemByAddr(itemdata.itemAddress, this.equipped.ToList<itemdata>()) == null) && (ad.type != ActionType.SET_BOWS_DUR || !itemdata.itemID.Contains("Arrow")) && ((ad.type != ActionType.SET_ITEMS_QT || !itemdata.isEquipment) && (!ad.UseFilter || this.findItemByID(itemdata.itemID, ad.filterList.ToList<itemdata>()) != null)) && (ad.mode != ActionMode.FIXED || ad.HiddenTimerElapsed()))
            {
              if (ad.mode == ActionMode.FIXED)
              {
                ad.HiddenTimerSec = 2;
                this.mem.SetInt32At(itemdata.itemQtDurAddress, ad.fixedValue);
                ad.HiddenTimerTick();
                ++ad.counter;
              }
              else if (ad.mode == ActionMode.TIMER)
              {
                int int32At = this.mem.GetInt32At(itemdata.itemQtDurAddress);
                if (int32At < ad.timerMax)
                {
                  int num = int32At + ad.timerQt <= ad.timerMax ? ad.timerQt : ad.timerMax - int32At;
                  this.mem.SetInt32At(itemdata.itemQtDurAddress, int32At + num);
                  ++ad.counter;
                }
                if (int32At + ad.timerQt < ad.timerMax)
                  flag = false;
              }
            }
          }
          if (flag && ad.StopWhenDone)
          {
            this.Putlog("[" + ad.ToString() + "] Auto restore stopped.");
            actiondata selectedItem = (actiondata) ((ListBox) this.findControl("lstActionsRegistered")).SelectedItem;
            if (selectedItem != null && selectedItem == ad)
              this.CheckControl("chkActionsActiveInactive", false);
            ad.Active = false;
          }
        }
        else
        {
          bool flag = true;
          if (ad.type == ActionType.SET_RUPEES && this.rupeesAddress >= 0L)
          {
            if (ad.mode == ActionMode.FIXED && !ad.HiddenTimerElapsed())
              return;
            if (ad.mode == ActionMode.FIXED)
            {
              ad.HiddenTimerSec = 2;
              this.mem.SetInt32At(this.rupeesAddress, ad.fixedValue);
              ad.HiddenTimerTick();
              ++ad.counter;
            }
            else if (ad.mode == ActionMode.TIMER)
            {
              int int32At = this.mem.GetInt32At(this.rupeesAddress);
              if (int32At < ad.timerMax)
              {
                int num = int32At + ad.timerQt <= ad.timerMax ? ad.timerQt : ad.timerMax - int32At;
                this.mem.SetInt32At(this.rupeesAddress, int32At + num);
                ++ad.counter;
              }
              if (int32At + ad.timerQt < ad.timerMax)
                flag = false;
            }
          }
          if (ad.type == ActionType.SET_HEALTH)
          {
            long regionStart;
            long regionSize;
            if (this.healthAddress < 0L && this.mem.FindRegionByAddr(this.inventoryStartAddress, out regionStart, out regionSize, IntPtr.Zero, true))
            {
              this.Putlog("[" + ad.ToString() + "] Scanning memory...");
              long healthAddress = this.findHealthAddress(regionStart, this.inventoryStartAddress - regionStart);
              if (healthAddress >= 0L)
              {
                this.Putlog("[" + ad.ToString() + "] Found offset at 0x" + healthAddress.ToString("X"));
                this.healthAddress = healthAddress;
              }
              else
                this.Putlog("[" + ad.ToString() + "] Could not find offset");
            }
            if (this.healthAddress >= 0L)
            {
              if (ad.mode == ActionMode.FIXED && !ad.HiddenTimerElapsed())
                return;
              if (ad.mode == ActionMode.FIXED)
              {
                ad.HiddenTimerSec = 2;
                this.mem.SetInt32At(this.healthAddress, ad.fixedValue);
                ad.HiddenTimerTick();
                ++ad.counter;
              }
              else if (ad.mode == ActionMode.TIMER)
              {
                int int32At = this.mem.GetInt32At(this.healthAddress);
                if (int32At < ad.timerMax)
                {
                  int num = int32At + ad.timerQt <= ad.timerMax ? ad.timerQt : ad.timerMax - int32At;
                  this.mem.SetInt32At(this.healthAddress, int32At + num);
                  ++ad.counter;
                }
                if (int32At + ad.timerQt < ad.timerMax)
                  flag = false;
              }
            }
          }
          if (ad.type == ActionType.SET_STAMINA)
          {
            long regionStart;
            long regionSize;
            if (this.staminaAddress < 0L && this.mem.FindRegionByAddr(this.inventoryStartAddress, out regionStart, out regionSize, IntPtr.Zero, true))
            {
              this.Putlog("[" + ad.ToString() + "] Scanning memory...");
              long staminaAddress = this.findStaminaAddress(regionStart, this.inventoryStartAddress - regionStart);
              if (staminaAddress >= 0L)
              {
                this.Putlog("[" + ad.ToString() + "] Found offset at 0x" + staminaAddress.ToString("X"));
                this.staminaAddress = staminaAddress;
              }
              else
                this.Putlog("[" + ad.ToString() + "] Could not find offset");
            }
            if (this.staminaAddress >= 0L)
            {
              if (ad.mode == ActionMode.FIXED && !ad.HiddenTimerElapsed())
                return;
              if (ad.mode == ActionMode.FIXED)
              {
                ad.HiddenTimerSec = 2;
                this.mem.SetInt32At(this.staminaAddress, ad.fixedValue);
                ad.HiddenTimerTick();
                ++ad.counter;
              }
              else if (ad.mode == ActionMode.TIMER)
              {
                int int32At = this.mem.GetInt32At(this.staminaAddress);
                if (int32At < ad.timerMax)
                {
                  int num = int32At + ad.timerQt <= ad.timerMax ? ad.timerQt : ad.timerMax - int32At;
                  this.mem.SetInt32At(this.staminaAddress, int32At + num);
                  ++ad.counter;
                }
                if (int32At + ad.timerQt < ad.timerMax)
                  flag = false;
              }
            }
          }
          if (flag && ad.StopWhenDone)
          {
            this.Putlog("[" + ad.ToString() + "] stopped.");
            actiondata selectedItem = (actiondata) ((ListBox) this.findControl("lstActionsRegistered")).SelectedItem;
            if (selectedItem != null && selectedItem == ad)
              this.CheckControl("chkActionsActiveInactive", false);
            ad.Active = false;
          }
        }
        ad.timeLast = totalSeconds;
      }
    }

    public void updateActionDatas()
    {
      foreach (string index in App.ACTION_SECTIONS)
      {
        try
        {
          if (this.listActions.ContainsKey(index))
          {
            actiondata actionData = this.createActionData(index);
            actiondata listAction = (actiondata) this.listActions[index];
            actionData.timeLast = listAction.timeLast;
            actionData.section = listAction.section;
            actionData.desc = listAction.desc;
            actionData.counter = listAction.counter;
            actionData.HiddenTimerSec = listAction.HiddenTimerSec;
            this.listActions[index] = (object) actionData;
          }
        }
        catch (Exception ex)
        {
        }
      }
      foreach (string index in App.EXTENDED_ACTION_SECTIONS)
      {
        try
        {
          if (this.listActions.ContainsKey(index))
          {
            CheckBox control = (CheckBox) this.findControl("chk" + index + "Set");
            actiondata actionData = this.createActionData(index);
            actiondata listAction = (actiondata) this.listActions[index];
            if (control == null)
              actionData.Active = listAction.Active;
            actionData.timeLast = listAction.timeLast;
            actionData.section = listAction.section;
            actionData.desc = listAction.desc;
            actionData.counter = listAction.counter;
            actionData.HiddenTimerSec = listAction.HiddenTimerSec;
            if (listAction.fixedValue >= 0)
              actionData.fixedValue = listAction.fixedValue;
            if ((double) listAction.singleValue != 0.0)
              actionData.singleValue = listAction.singleValue;
            this.listActions[index] = (object) actionData;
          }
        }
        catch (Exception ex)
        {
        }
      }
    }

    public actiondata createActionData(string action_section)
    {
      actiondata actiondata = new actiondata();
      if (Array.IndexOf<string>(App.ACTION_SECTIONS, action_section) > -1)
      {
        RadioButton control1 = (RadioButton) this.findControl("option" + action_section + "Fixed");
        RadioButton control2 = (RadioButton) this.findControl("option" + action_section + "Timer");
        RadioButton control3 = (RadioButton) this.findControl("option" + action_section + "NoFilter");
        RadioButton control4 = (RadioButton) this.findControl("option" + action_section + "FilterList");
        ListBox control5 = (ListBox) this.findControl("lst" + action_section + "Filter");
        CheckBox control6 = (CheckBox) this.findControl("chk" + action_section + "DisableWhenDone");
        CheckBox control7 = (CheckBox) this.findControl("chk" + action_section + "UseHotkey");
        CheckBox control8 = (CheckBox) this.findControl("chk" + action_section + "ActiveInactive");
        TextBox control9 = (TextBox) this.findControl("txt" + action_section + "Fixed");
        TextBox control10 = (TextBox) this.findControl("txt" + action_section + "Timer");
        TextBox control11 = (TextBox) this.findControl("txt" + action_section + "Quantity");
        TextBox control12 = (TextBox) this.findControl("txt" + action_section + "Max");
        TextBox control13 = (TextBox) this.findControl("txt" + action_section + "HotKey");
        actiondata.type = ActionType.NEW;
        actiondata.mode = control1.Checked ? ActionMode.FIXED : ActionMode.TIMER;
        actiondata.UseFilter = !control3.Checked;
        actiondata.StopWhenDone = control6.Checked;
        actiondata.UseHotKey = control7.Checked;
        actiondata.Active = control8.Checked;
        actiondata.fixedValue = control9.Text.Trim().Length == 0 ? -1 : App.StringToInt32(control9.Text.Trim());
        actiondata.timerSec = control10.Text.Trim().Length == 0 ? -1 : App.StringToInt32(control10.Text.Trim());
        actiondata.timerQt = control11.Text.Trim().Length == 0 ? -1 : App.StringToInt32(control11.Text.Trim());
        actiondata.timerMax = control12.Text.Trim().Length == 0 ? -1 : App.StringToInt32(control12.Text.Trim());
        actiondata.hotKey = control13.Text;
        BindingSource dataSource = (BindingSource) control5.DataSource;
        actiondata.filterList = !(dataSource != null & dataSource.DataSource != null) ? (BList<itemdata>) null : (BList<itemdata>) dataSource.DataSource;
      }
      else if (Array.IndexOf<string>(App.EXTENDED_ACTION_SECTIONS, action_section) > -1)
      {
        CheckBox control1 = (CheckBox) this.findControl("chk" + action_section + "Set");
        CheckBox control2 = (CheckBox) this.findControl("chk" + action_section + "UseHotkey");
        TextBox control3 = (TextBox) this.findControl("txt" + action_section + "HotKey");
        RadioButton unbreakableNoFilter = this.frmMain.optionUnbreakableNoFilter;
        RadioButton unbreakableFilterList = this.frmMain.optionUnbreakableFilterList;
        ListBox unbreakableFilter = this.frmMain.lstUnbreakableFilter;
        actiondata.UseFilter = !unbreakableNoFilter.Checked;
        actiondata.type = ActionType.NEW;
        actiondata.mode = ActionMode.FIXED;
        actiondata.section = action_section;
        actiondata.Active = control1 != null && control1.Checked;
        actiondata.UseHotKey = control2.Checked;
        actiondata.hotKey = control3.Text;
        actiondata.fixedValue = 0;
        BindingSource dataSource = (BindingSource) unbreakableFilter.DataSource;
        actiondata.filterList = !(dataSource != null & dataSource.DataSource != null) ? (BList<itemdata>) null : (BList<itemdata>) dataSource.DataSource;
      }
      return actiondata;
    }

    public void updateUiFromActionData(actiondata ad)
    {
      if (ad == null || ad.section == "")
        return;
      if (Array.IndexOf<string>(App.ACTION_SECTIONS, ad.section) > -1)
      {
        RadioButton control1 = (RadioButton) this.findControl("option" + ad.section + "Fixed");
        RadioButton control2 = (RadioButton) this.findControl("option" + ad.section + "Timer");
        RadioButton control3 = (RadioButton) this.findControl("option" + ad.section + "NoFilter");
        RadioButton control4 = (RadioButton) this.findControl("option" + ad.section + "FilterList");
        ListBox control5 = (ListBox) this.findControl("lst" + ad.section + "Filter");
        CheckBox control6 = (CheckBox) this.findControl("chk" + ad.section + "DisableWhenDone");
        CheckBox control7 = (CheckBox) this.findControl("chk" + ad.section + "UseHotkey");
        CheckBox control8 = (CheckBox) this.findControl("chk" + ad.section + "ActiveInactive");
        TextBox control9 = (TextBox) this.findControl("txt" + ad.section + "Fixed");
        TextBox control10 = (TextBox) this.findControl("txt" + ad.section + "Timer");
        TextBox control11 = (TextBox) this.findControl("txt" + ad.section + "Quantity");
        TextBox control12 = (TextBox) this.findControl("txt" + ad.section + "Max");
        TextBox control13 = (TextBox) this.findControl("txt" + ad.section + "HotKey");
        control1.Checked = ad.mode == ActionMode.FIXED;
        control2.Checked = ad.mode == ActionMode.TIMER;
        control3.Checked = !ad.UseFilter;
        control4.Checked = ad.UseFilter;
        BindingSource dataSource = (BindingSource) control5.DataSource;
        if (dataSource != null)
          dataSource.DataSource = (object) ad.filterList;
        else
          control5.DataSource = (object) this.CreateBindingSource<itemdata>((BindingList<itemdata>) ad.filterList);
        control6.Checked = ad.StopWhenDone;
        control7.Checked = ad.UseHotKey;
        string str = ad.fixedValue >= 0 ? ad.fixedValue.ToString() : "";
        control9.Text = str;
        control10.Text = ad.timerSec > 0 ? ad.timerSec.ToString() : "";
        control11.Text = ad.timerQt > 0 ? ad.timerQt.ToString() : "";
        control12.Text = ad.timerMax > 0 ? ad.timerMax.ToString() : "";
        control13.Text = ad.hotKey;
        int num = ad.Active ? 1 : 0;
        control8.Checked = num != 0;
      }
      else
      {
        if (Array.IndexOf<string>(App.EXTENDED_ACTION_SECTIONS, ad.section) <= -1)
          return;
        CheckBox control1 = (CheckBox) this.findControl("chk" + ad.section + "Set");
        CheckBox control2 = (CheckBox) this.findControl("chk" + ad.section + "UseHotkey");
        TextBox control3 = (TextBox) this.findControl("txt" + ad.section + "HotKey");
        ListBox unbreakableFilter = this.frmMain.lstUnbreakableFilter;
        RadioButton unbreakableNoFilter = this.frmMain.optionUnbreakableNoFilter;
        RadioButton unbreakableFilterList = this.frmMain.optionUnbreakableFilterList;
        int num1 = !ad.UseFilter ? 1 : 0;
        unbreakableNoFilter.Checked = num1 != 0;
        unbreakableFilterList.Checked = ad.UseFilter;
        BindingSource dataSource = (BindingSource) unbreakableFilter.DataSource;
        if (dataSource != null)
          dataSource.DataSource = (object) ad.filterList;
        else
          unbreakableFilter.DataSource = (object) this.CreateBindingSource<itemdata>((BindingList<itemdata>) ad.filterList);
        string hotKey = ad.hotKey;
        control3.Text = hotKey;
        int num2 = ad.UseHotKey ? 1 : 0;
        control2.Checked = num2 != 0;
        if (control1 == null)
          return;
        control1.Checked = ad.Active;
      }
    }

    public void updateCurrentAction()
    {
      if (!this.FlagEvent_1)
        return;
      actiondata selectedItem = (actiondata) this.frmMain.lstActionsRegistered.SelectedItem;
      if (selectedItem == null)
        return;
      selectedItem.type = (ActionType) this.frmMain.cbActionsList.SelectedIndex;
      selectedItem.mode = this.frmMain.optionActionsFixed.Checked ? ActionMode.FIXED : ActionMode.TIMER;
      selectedItem.fixedValue = this.frmMain.txtActionsFixed.Text.Length > 0 ? App.StringToInt32(this.frmMain.txtActionsFixed.Text) : selectedItem.fixedValue;
      selectedItem.timerSec = this.frmMain.txtActionsTimer.Text.Length > 0 ? App.StringToInt32(this.frmMain.txtActionsTimer.Text) : selectedItem.timerSec;
      selectedItem.timerQt = this.frmMain.txtActionsQuantity.Text.Length > 0 ? App.StringToInt32(this.frmMain.txtActionsQuantity.Text) : selectedItem.timerQt;
      selectedItem.timerMax = this.frmMain.txtActionsMax.Text.Length > 0 ? App.StringToInt32(this.frmMain.txtActionsMax.Text) : selectedItem.timerMax;
      selectedItem.hotKey = this.frmMain.txtActionsHotKey.Text.Length > 0 ? this.frmMain.txtActionsHotKey.Text : "";
      selectedItem.UseHotKey = this.frmMain.chkActionsUseHotkey.Checked;
      selectedItem.StopWhenDone = this.frmMain.chkActionsDisableWhenDone.Checked;
      selectedItem.Active = this.frmMain.chkActionsActiveInactive.Checked;
      selectedItem.UseFilter = this.frmMain.optionActionsFilterList.Checked;
    }

    public void updateActionsSelected()
    {
      actiondata selectedItem = (actiondata) this.frmMain.lstActionsRegistered.SelectedItem;
      if (this.frmMain.lstActionsRegistered.Items.Count == 0)
      {
        this.EnableControl("gbActionsSettings", false);
        this.EnableControl("gbActionsFilter", false);
        foreach (Control control in this.getControls(this.findControl("gbActionsSettings")))
        {
          if (control.GetType() == typeof (TextBox))
            ((TextBoxBase) control).Clear();
          if (control.GetType() == typeof (ComboBox))
            ((ComboBox) control).Items.Clear();
          if (control.GetType() == typeof (ListBox))
            ((ListBox) control).Items.Clear();
          if (control.GetType() == typeof (CheckBox))
            ((CheckBox) control).Checked = false;
        }
        foreach (Control control in this.getControls(this.findControl("gbActionsFilter")))
        {
          if (control.GetType() == typeof (TextBox))
            ((TextBoxBase) control).Clear();
          if (control.GetType() == typeof (ComboBox))
            ((ComboBox) control).Items.Clear();
          if (control.GetType() == typeof (ListBox))
            ((ListControl) control).DataSource = (object) null;
          if (control.GetType() == typeof (ListBox))
            ((ListBox) control).Items.Clear();
          if (control.GetType() == typeof (CheckBox))
            ((CheckBox) control).Checked = false;
        }
      }
      else
      {
        if (selectedItem == null)
          return;
        this.EnableControl("gbActionsSettings", true);
        this.EnableControl("gbActionsFilter", true);
        if (this.frmMain.cbActionsList.Items.Count == 0)
        {
          foreach (ActionType actionType in Enum.GetValues(typeof (ActionType)))
            this.frmMain.cbActionsList.Items.Add((object) actiondata.ACTIONTYPESTRING[(int) actionType]);
        }
        this.frmMain.cbActionsList.SelectedIndex = (int) selectedItem.type;
        this.frmMain.optionActionsFixed.Checked = selectedItem.mode == ActionMode.FIXED;
        this.frmMain.optionActionsTimer.Checked = selectedItem.mode == ActionMode.TIMER;
        this.frmMain.optionActionsNoFilter.Checked = !selectedItem.UseFilter;
        this.frmMain.optionActionsFilterList.Checked = selectedItem.UseFilter;
        this.SetTextBoxText(this.frmMain.txtActionsFixed, selectedItem.fixedValue >= 0 ? selectedItem.fixedValue.ToString() : "");
        this.SetTextBoxText(this.frmMain.txtActionsTimer, selectedItem.timerSec >= 0 ? selectedItem.timerSec.ToString() : "");
        this.SetTextBoxText(this.frmMain.txtActionsQuantity, selectedItem.timerQt >= 0 ? selectedItem.timerQt.ToString() : "");
        this.SetTextBoxText(this.frmMain.txtActionsMax, selectedItem.timerMax >= 0 ? selectedItem.timerMax.ToString() : "");
        this.frmMain.chkActionsActiveInactive.Checked = selectedItem.Active;
        this.frmMain.chkActionsDisableWhenDone.Checked = selectedItem.StopWhenDone;
        this.frmMain.chkActionsUseHotkey.Checked = selectedItem.UseHotKey;
        this.SetTextBoxText(this.frmMain.txtActionsHotKey, selectedItem.hotKey);
        this.frmMain.lstActionsFilter.DataSource = (object) this.CreateBindingSource<itemdata>((BindingList<itemdata>) selectedItem.filterList);
      }
    }

    public void SetTextBoxText(TextBox txtBox, string text)
    {
      if (txtBox == null || !(txtBox.GetType() == typeof (TextBox)) || !(txtBox.Text != text))
        return;
      txtBox.Text = text;
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
      actiondata selectedItem = (actiondata) this.frmMain.lstActionsRegistered.SelectedItem;
      if (selectedItem == null)
        return;
      this.customActions.Remove(selectedItem);
    }

    private void btnActionsNew_Click(object sender, EventArgs e)
    {
      actiondata actiondata = new actiondata();
      this.customActions.Add(actiondata);
      this.frmMain.lstActionsRegistered.SelectedItem = (object) actiondata;
    }

    private BindingSource CreateBindingSource<T>(BindingList<T> list)
    {
      return new BindingSource()
      {
        DataSource = (object) list
      };
    }

    private static string getControlSection(Control ctrl)
    {
      string[] strArray = Regex.Split(ctrl.Name, "(?<!^)(?=[A-Z])");
      if (strArray.Length <= 1)
        return "";
      return strArray[1];
    }

    private static int StringToInt32(string str)
    {
      int result = 0;
      int.TryParse(str.Trim(), out result);
      return result;
    }

    private static uint StringToUInt32(string str)
    {
      uint result = 0;
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
      string controlSection = App.getControlSection((Control) sender);
      if (!(controlSection != ""))
        return;
      this.refreshSelectedIndex(controlSection);
    }

    private void lst_DoubleClick(object sender, EventArgs e)
    {
      itemdata selectedItem1 = (itemdata) ((ListBox) sender).SelectedItem;
      if (selectedItem1 == null)
        return;
      TabPage parent1 = (TabPage) this.frmMain.lstActionsFilter.Parent.Parent;
      if (((TabControl) parent1.Parent).SelectedTab == parent1 && this.frmMain.lstActionsFilter.Parent.Enabled)
      {
        actiondata selectedItem2 = (actiondata) this.frmMain.lstActionsRegistered.SelectedItem;
        if (selectedItem2 != null)
        {
          foreach (itemdata filter in (Collection<itemdata>) selectedItem2.filterList)
          {
            if (filter.itemID == selectedItem1.itemID)
              return;
          }
          selectedItem2.filterList.Add(new itemdata(selectedItem1.itemID));
          BindingSource dataSource = (BindingSource) this.frmMain.lstActionsFilter.DataSource;
          if (dataSource != null)
          {
            for (int itemIndex = 0; itemIndex < dataSource.Count; ++itemIndex)
              dataSource.ResetItem(itemIndex);
          }
        }
      }
      ListBox control1 = (ListBox) this.findControl("lstUnbreakableFilter");
      TabPage parent2 = (TabPage) control1.Parent.Parent.Parent;
      if (((TabControl) parent2.Parent).SelectedTab == parent2)
      {
        BindingSource dataSource = (BindingSource) control1.DataSource;
        BindingList<itemdata> bindingList = dataSource == null || dataSource.DataSource == null ? (BindingList<itemdata>) null : (BindingList<itemdata>) dataSource.DataSource;
        if (bindingList != null)
        {
          foreach (itemdata itemdata in (Collection<itemdata>) bindingList)
          {
            if (itemdata.itemID == selectedItem1.itemID)
              return;
          }
          bindingList.Add(new itemdata(selectedItem1.itemID));
          for (int itemIndex = 0; itemIndex < dataSource.Count; ++itemIndex)
            dataSource.ResetItem(itemIndex);
        }
      }
      foreach (string str in App.ACTION_SECTIONS)
      {
        ListBox control2 = (ListBox) this.findControl("lst" + str + "Filter");
        TabPage parent3 = (TabPage) control2.Parent.Parent;
        if (((TabControl) parent3.Parent).SelectedTab == parent3)
        {
          BindingSource dataSource = (BindingSource) control2.DataSource;
          BindingList<itemdata> bindingList = dataSource == null || dataSource.DataSource == null ? (BindingList<itemdata>) null : (BindingList<itemdata>) dataSource.DataSource;
          if (bindingList != null)
          {
            foreach (itemdata itemdata in (Collection<itemdata>) bindingList)
            {
              if (itemdata.itemID == selectedItem1.itemID)
                return;
            }
            bindingList.Add(new itemdata(selectedItem1.itemID));
            for (int itemIndex = 0; itemIndex < dataSource.Count; ++itemIndex)
              dataSource.ResetItem(itemIndex);
          }
        }
      }
    }

    private void cbItemName_SelectedIndexChanged(object sender, EventArgs e)
    {
      string controlSection = App.getControlSection((Control) sender);
      if (!(controlSection != ""))
        return;
      this.applySelectedIndexItemID(controlSection);
    }

    private void btnItemUpdate_Click(object sender, EventArgs e)
    {
      string controlSection = App.getControlSection((Control) sender);
      if (!(controlSection != ""))
        return;
      ListBox control1 = (ListBox) this.findControl("lst" + controlSection);
      if (control1 == null || control1.SelectedItem == null || !(control1.SelectedItem.GetType() == typeof (itemdata)))
        return;
      itemdata selectedItem1 = (itemdata) control1.SelectedItem;
      TextBox control2 = (TextBox) this.findControl("txt" + controlSection + "ItemID");
      TextBox control3 = (TextBox) this.findControl("txt" + controlSection + "ItemQtDur");
      TextBox control4 = (TextBox) this.findControl("txt" + controlSection + "ItemBonusType");
      TextBox control5 = (TextBox) this.findControl("txt" + controlSection + "ItemBonusValue");
      ComboBox control6 = (ComboBox) this.findControl("cb" + controlSection + "ItemBonusType");
      byte[] buffer = new byte[selectedItem1.itemID.Length];
      Array.Clear((Array) buffer, 0, buffer.Length);
      byte[] bytes = Encoding.ASCII.GetBytes(control2.Text.Trim());
      this.mem.SetInt32At(selectedItem1.itemQtDurAddress, App.StringToInt32(control3.Text));
      if (control4 != null && control4.Visible)
        this.mem.SetUInt32At(selectedItem1.itemBonusTypeAddress, App.StringToUInt32(control4.Text));
      else if (control6 != null && control6.Visible)
      {
        Bonus selectedItem2 = (Bonus) control6.SelectedItem;
        if (selectedItem2.type != Bonus.BonusTypeValue.A_UNKNOWN)
          this.mem.SetUInt32At(selectedItem1.itemBonusTypeAddress, (uint) selectedItem2.type);
      }
      this.mem.SetInt32At(selectedItem1.itemBonusValueAddress, App.StringToInt32(control5.Text));
      this.mem.SetBytesAt(selectedItem1.itemAddress + 1L, buffer, buffer.Length);
      this.mem.SetBytesAt(selectedItem1.itemAddress + 1L, bytes, bytes.Length);
      this.mem.SetByteAt(selectedItem1.itemAddress + 1L + (long) bytes.Length, (byte) 0);
      selectedItem1.itemID = this.mem.GetStringAt(selectedItem1.itemAddress + 1L);
      this.updateItems(this.items.ToList<itemdata>());
      this.refreshSelectedIndex(controlSection);
    }

    private void btnItemUnlock_Click(object sender, EventArgs e)
    {
      string controlSection = App.getControlSection((Control) sender);
      if (!(controlSection != ""))
        return;
      ListBox control1 = (ListBox) this.findControl("lst" + controlSection);
      if (control1 == null || control1.SelectedItem == null || !(control1.SelectedItem.GetType() == typeof (itemdata)))
        return;
      itemdata selectedItem = (itemdata) control1.SelectedItem;
      TextBox control2 = (TextBox) this.findControl("txt" + controlSection + "ItemID");
      TextBox control3 = (TextBox) this.findControl("txt" + controlSection + "ItemQtDur");
      TextBox control4 = (TextBox) this.findControl("txt" + controlSection + "ItemBonusType");
      TextBox control5 = (TextBox) this.findControl("txt" + controlSection + "ItemBonusValue");
      ComboBox control6 = (ComboBox) this.findControl("cb" + controlSection + "ItemName");
      ComboBox control7 = (ComboBox) this.findControl("cb" + controlSection + "ItemBonusType");
      this.EnableControl("gb" + controlSection + "Edit", true);
      this.EnableControl("cb" + controlSection + "ItemName", true);
      this.ShowControl("btn" + controlSection + "ItemUnlock", false);
      if (control6 == null || this.InvokeRequired && control6.DataSource != null)
        return;
      int idIndexInNames = this.getIdIndexInNames(selectedItem.itemID, "All");
      if (idIndexInNames < 0)
      {
        control6.DataSource = (object) null;
        try
        {
          control6.Items.Clear();
          control6.Items.Add((object) selectedItem.itemName);
          control6.Text = selectedItem.itemName;
        }
        catch (Exception ex)
        {
        }
        control6.Enabled = true;
      }
      else
      {
        control6.DataSource = (object) null;
        try
        {
          control6.Items.Clear();
          control6.DataSource = (object) this.names["All"];
          control6.SelectedIndex = idIndexInNames;
        }
        catch (Exception ex)
        {
        }
        control6.Enabled = true;
      }
    }

    public void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
      while (!this.worker.CancellationPending && this.uiQueue.Count > 0)
      {
        QueueItem q = this.uiQueue.Dequeue();
        if (q == null)
          break;
        switch (q.byteCode)
        {
          case QueueItemCode.SET_LBL_SCAN:
            try
            {
              this.SetLblScan(q.message);
              continue;
            }
            catch (Exception ex)
            {
              int num = (int) MessageBox.Show("Error SetLblScan: " + ex.Message);
              continue;
            }
          case QueueItemCode.UPDATE_ITEMS_LISTS:
            if (q.data != null)
            {
              this.updateItems((List<itemdata>) q.data);
              continue;
            }
            continue;
          case QueueItemCode.PUTLOG:
            try
            {
              this.Putlog(q.message);
              continue;
            }
            catch (Exception ex)
            {
              int num = (int) MessageBox.Show("Error Putlog: " + ex.Message);
              continue;
            }
          case QueueItemCode.UIACTION:
            try
            {
              this.executeUiAction(q);
              continue;
            }
            catch (Exception ex)
            {
              int num = (int) MessageBox.Show("Error: " + ex.Message);
              continue;
            }
          case QueueItemCode.UPDATE_EQUIPPED_LIST:
            if (q.data != null)
            {
              this.updateEquippedItems((List<itemdata>) q.data);
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
      }
    }

    private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
    }

    public void worker_DoWork(object sender, DoWorkEventArgs e)
    {
label_49:
      while (!this.worker.CancellationPending)
      {
        if (this.nbInternalLoopMs > 0)
          Thread.Sleep(this.nbInternalLoopMs);
        double totalSeconds = DateTime.Now.Subtract(new DateTime(1970, 1, 9, 0, 0, 0)).TotalSeconds;
        if (!this.worker.CancellationPending)
        {
          if (this.frmMain.chkUpdateList.Checked)
          {
            double result = 0.0;
            double.TryParse(this.frmMain.txtTimerUpdateList.Text.Trim(), out result);
            if (totalSeconds - this.timeLastUpdateList >= result)
            {
              this.Putlog("Updating items list from memory...");
              this.FindItemsInMemory(this.items.Count > 0);
              this.timeLastUpdateList = totalSeconds;
              if (this.nbSpacingMs > 0)
                Thread.Sleep(this.nbSpacingMs);
            }
          }
          if (!this.worker.CancellationPending)
          {
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
                      Thread.Sleep(this.nbSpacingMs);
                  }
                }
                if (!this.worker.CancellationPending)
                {
                  this.updateEquippedItems(this.items.ToList<itemdata>());
                  if (!this.worker.CancellationPending)
                  {
                    this.updatePosition();
                    this.updateTime();
                    if (!this.worker.CancellationPending)
                    {
                      foreach (string key in App.ACTION_SECTIONS)
                      {
                        if (!this.worker.CancellationPending)
                        {
                          if (this.listActions.ContainsKey(key))
                          {
                            actiondata listAction = (actiondata) this.listActions[key];
                            if (listAction != null)
                            {
                              this.executeActionData(listAction, false);
                              if (this.nbSpacingMs > 0)
                                Thread.Sleep(this.nbSpacingMs);
                            }
                          }
                        }
                        else
                          break;
                      }
                      foreach (string key in App.EXTENDED_ACTION_SECTIONS)
                      {
                        if (!this.worker.CancellationPending)
                        {
                          if (this.listActions.ContainsKey(key))
                          {
                            actiondata listAction = (actiondata) this.listActions[key];
                            if (listAction != null)
                            {
                              this.executeActionData(listAction, false);
                              if (this.nbSpacingMs > 0)
                                Thread.Sleep(this.nbSpacingMs);
                            }
                          }
                        }
                        else
                          break;
                      }
                      foreach (actiondata customAction in (Collection<actiondata>) this.customActions)
                      {
                        if (!this.worker.CancellationPending)
                        {
                          if (customAction != null)
                          {
                            this.executeActionData(customAction, false);
                            if (this.nbSpacingMs > 0)
                              Thread.Sleep(this.nbSpacingMs);
                          }
                        }
                        else
                          break;
                      }
                    }
                    else
                      break;
                  }
                  else
                    break;
                }
                else
                  break;
              }
              while (!this.worker.CancellationPending && this.uiQueue.Count > 0)
                this.worker.ReportProgress(0);
              while (true)
              {
                do
                {
                  if (this.worker.CancellationPending || this.workingQueue.Count <= 0)
                    goto label_49;
                }
                while (this.workingQueue.Dequeue().byteCode != QueueItemCode.REQUEST_SCAN);
                this.FindItemsInMemory(false);
              }
            }
            else
              break;
          }
          else
            break;
        }
        else
          break;
      }
      e.Cancel = true;
      int num = this.worker.CancellationPending ? 1 : 0;
    }

    public void requestMemoryScan()
    {
      this.workingQueue.Enqueue(new QueueItem(QueueItemCode.REQUEST_SCAN, "", (object) null, false, "", "", (List<object>) null));
    }

    public void executeUiAction(QueueItem q)
    {
      if (q.byteCode != QueueItemCode.UIACTION)
        return;
      string message = q.message;
      if (!(message == "ENABLE_CONTROL"))
      {
        if (!(message == "CHECK_CONTROL"))
        {
          if (!(message == "SHOW_CONTROL"))
          {
            if (!(message == "TEXT_CONTROL"))
            {
              if (!(message == "REFRESH_SELECTED_INDEX"))
                return;
              this.refreshSelectedIndex(q.type);
            }
            else
              this.TextControl(q.type, (string) q.data);
          }
          else
            this.ShowControl(q.type, q.status);
        }
        else
          this.CheckControl(q.type, q.status);
      }
      else
        this.EnableControl(q.type, q.status);
    }

    public void SetLblScan(string what)
    {
      if (this.InvokeRequired)
      {
        this.uiQueue.Enqueue(new QueueItem(QueueItemCode.SET_LBL_SCAN, what, (object) null, false, "", "", (List<object>) null));
        this.worker.ReportProgress(0);
      }
      else
      {
        this.frmMain.SetLblScan(what);
        this.Putlog(what);
      }
    }

    public void Putlog(string what)
    {
      if (this.InvokeRequired)
      {
        this.uiQueue.Enqueue(new QueueItem(QueueItemCode.PUTLOG, what, (object) null, false, "", "", (List<object>) null));
        this.worker.ReportProgress(0);
      }
      else
        this.frmMain.Putlog(what);
    }

    public void TextControl(string what, string text)
    {
      Control control = this.findControl(what);
      if (control == null || control != null && control.Text == text)
        return;
      if (this.InvokeRequired)
      {
        this.uiQueue.Enqueue(new QueueItem(QueueItemCode.UIACTION, "TEXT_CONTROL", (object) text, false, what, "", (List<object>) null));
        this.worker.ReportProgress(0);
      }
      else
      {
        if (control == null)
          return;
        control.Text = text;
      }
    }

    public void EnableControl(string what, bool enabled)
    {
      if (this.InvokeRequired)
      {
        this.uiQueue.Enqueue(new QueueItem(QueueItemCode.UIACTION, "ENABLE_CONTROL", (object) null, enabled, what, "", (List<object>) null));
        this.worker.ReportProgress(0);
      }
      else
      {
        Control control = this.findControl(what);
        if (control == null)
          return;
        control.Enabled = enabled;
      }
    }

    public void ShowControl(string what, bool visible)
    {
      if (this.InvokeRequired)
      {
        this.uiQueue.Enqueue(new QueueItem(QueueItemCode.UIACTION, "SHOW_CONTROL", (object) null, visible, what, "", (List<object>) null));
        this.worker.ReportProgress(0);
      }
      else
      {
        Control control = this.findControl(what);
        if (control == null)
          return;
        control.Visible = visible;
      }
    }

    public void CheckControl(string what, bool value)
    {
      if (this.InvokeRequired)
      {
        this.uiQueue.Enqueue(new QueueItem(QueueItemCode.UIACTION, "CHECK_CONTROL", (object) null, value, what, "", (List<object>) null));
        this.worker.ReportProgress(0);
      }
      else
      {
        Control control = this.findControl(what);
        if (control == null)
          return;
        if (control.GetType() == typeof (CheckBox))
        {
          ((CheckBox) control).Checked = value;
        }
        else
        {
          if (!(control.GetType() == typeof (RadioButton)))
            return;
          ((RadioButton) control).Checked = value;
        }
      }
    }

    public itemdata findItemByAddr(long addr, List<itemdata> list)
    {
      itemdata itemdata1 = (itemdata) null;
      foreach (itemdata itemdata2 in list)
      {
        if (itemdata2.itemAddress == addr)
        {
          itemdata1 = itemdata2;
          break;
        }
      }
      return itemdata1;
    }

    public itemdata findItemByID(string ID, List<itemdata> list)
    {
      itemdata itemdata1 = (itemdata) null;
      foreach (itemdata itemdata2 in list)
      {
        if (itemdata2.itemID == ID)
        {
          itemdata1 = itemdata2;
          break;
        }
      }
      return itemdata1;
    }

    public void setTime(int value)
    {
      if (this.InvokeRequired || this.staminaAddress <= 0L && this.speedHackAddress <= 0L)
        return;
      long num = this.staminaAddress > 0L ? this.staminaAddress + 2L : this.speedHackAddress - 22565198L + 2L;
      long address = num + 1567901152L;
      float singleAt = this.mem.GetSingleAt(address);
      if ((double) singleAt <= 0.0 || (double) singleAt > 360.0)
      {
        address = num + 1581909472L;
        singleAt = this.mem.GetSingleAt(address);
      }
      if ((double) singleAt <= 0.0 || (double) singleAt > 360.0)
        return;
      float single = Convert.ToSingle(value);
      this.mem.SetSingleAt(address, single);
    }

    public void updateTime()
    {
      if (this.staminaAddress <= 0L && this.speedHackAddress <= 0L)
        return;
      if (this.InvokeRequired)
      {
        this.uiQueue.Enqueue(new QueueItem(QueueItemCode.UPDATE_TIME, "", (object) null, false, "", "", (List<object>) null));
        this.worker.ReportProgress(0);
      }
      else
      {
        long num = this.staminaAddress > 0L ? this.staminaAddress + 2L : this.speedHackAddress - 22565198L + 2L;
        float singleAt = this.mem.GetSingleAt(num + 1567901152L);
        if ((double) singleAt <= 0.0 || (double) singleAt > 360.0)
          singleAt = this.mem.GetSingleAt(num + 1581909472L);
        if ((double) singleAt <= 0.0 || (double) singleAt > 360.0)
          return;
        this.frmMain.trackTime.Tag = (object) this;
        this.frmMain.trackTime.Value = (int) Math.Truncate((double) singleAt);
        this.frmMain.trackTime.Tag = (object) null;
      }
    }

    public void updatePosition()
    {
      if (this.coordinatesAddress <= 0L)
        return;
      if (this.InvokeRequired)
      {
        this.uiQueue.Enqueue(new QueueItem(QueueItemCode.UPDATE_POSITION, "", (object) null, false, "", "", (List<object>) null));
        this.worker.ReportProgress(0);
      }
      else
      {
        if (!(this.findControl("btnPositionEdit").Text == "Edit"))
          return;
        float singleAt1 = this.mem.GetSingleAt(this.coordinatesAddress);
        float singleAt2 = this.mem.GetSingleAt(this.coordinatesAddress + 4L);
        float singleAt3 = this.mem.GetSingleAt(this.coordinatesAddress + 8L);
        this.TextControl("txtPositionX", singleAt1.ToString());
        this.TextControl("txtPositionY", singleAt2.ToString());
        this.TextControl("txtPositionZ", singleAt3.ToString());
      }
    }

    public void updateEquippedItems(List<itemdata> items)
    {
      if (this.InvokeRequired)
      {
        this.uiQueue.Enqueue(new QueueItem(QueueItemCode.UPDATE_EQUIPPED_LIST, "", (object) items, false, "", "", (List<object>) null));
        this.worker.ReportProgress(0);
      }
      else
      {
        foreach (itemdata itemdata in items)
        {
          if (itemdata.isWeaponBowShield)
          {
            if ((int) this.mem.GetByteAt(itemdata.itemEquippedFlagAddress) == 1)
            {
              if (!this.equipped.Contains(itemdata))
              {
                if (itemdata.isShield)
                  this.equippedShieldDurabilityAddress = -1L;
                else if (itemdata.isBow)
                  this.equippedBowDurabilityAddress = -1L;
                else
                  this.equippedWeaponDurabilityAddress = -1L;
                this.equipped.Add(itemdata);
              }
            }
            else if (this.equipped.Contains(itemdata))
            {
              if (itemdata.isShield)
                this.equippedShieldDurabilityAddress = -1L;
              else if (itemdata.isBow)
                this.equippedBowDurabilityAddress = -1L;
              else
                this.equippedWeaponDurabilityAddress = -1L;
              this.equipped.Remove(itemdata);
            }
          }
        }
      }
    }

    public void updateItems(List<itemdata> newItems)
    {
      if (this.InvokeRequired)
      {
        this.uiQueue.Enqueue(new QueueItem(QueueItemCode.UPDATE_ITEMS_LISTS, "", (object) newItems, false, "", "", (List<object>) null));
        this.worker.ReportProgress(0);
      }
      else
      {
        if (newItems.Count > 0)
          this.EnableControl("tabItems", true);
        else
          this.EnableControl("tabItems", false);
        if (this.itemNames.Count > 0)
        {
          foreach (KeyValuePair<string, List<itemname>> name in this.names)
          {
            if (name.Value.Count <= 0)
            {
              foreach (KeyValuePair<string, string> itemName in this.itemNames)
              {
                string key = name.Key;
                // ISSUE: reference to a compiler-generated method
                uint stringHash = \u003CPrivateImplementationDetails\u003E.ComputeStringHash(key);
                if (stringHash <= 2689875649U)
                {
                  if (stringHash <= 1849229205U)
                  {
                    if ((int) stringHash != 1456985430)
                    {
                      if ((int) stringHash != 1849229205 || key == "Other")
                        ;
                    }
                    else if (key == "Weapons" && itemName.Key.StartsWith("Weapon_", true, (CultureInfo) null) && (!itemName.Key.StartsWith("Weapon_Bow_", true, (CultureInfo) null) && !itemName.Key.StartsWith("Weapon_Shield_", true, (CultureInfo) null)))
                      name.Value.Add(new itemname(itemName.Key, itemName.Value));
                  }
                  else if ((int) stringHash != 1974461284)
                  {
                    if ((int) stringHash == -1605091647 && key == "Archery" && (itemName.Key.StartsWith("Weapon_Bow_", true, (CultureInfo) null) || itemName.Key.Contains("Arrow") && !itemName.Key.StartsWith("Obj_", true, (CultureInfo) null)))
                      name.Value.Add(new itemname(itemName.Key, itemName.Value));
                  }
                  else if (key == "All")
                    name.Value.Add(new itemname(itemName.Key, itemName.Value));
                }
                else if (stringHash <= 3369262303U)
                {
                  if ((int) stringHash != -1115897879)
                  {
                    if ((int) stringHash == -925704993 && key == "Inventory" && (itemName.Key.StartsWith("Item_", true, (CultureInfo) null) || itemName.Key.StartsWith("Weapon_", true, (CultureInfo) null) || itemName.Key.StartsWith("Armor_", true, (CultureInfo) null) || (itemName.Key.Contains("Arrow") && !itemName.Key.StartsWith("Obj", true, (CultureInfo) null) || itemName.Key.StartsWith("Animal_Insect_", true, (CultureInfo) null))))
                      name.Value.Add(new itemname(itemName.Key, itemName.Value));
                  }
                  else if (key == "Food" && (itemName.Key.StartsWith("Item_Cook_", true, (CultureInfo) null) || itemName.Key.StartsWith("Item_Roast", true, (CultureInfo) null)))
                    name.Value.Add(new itemname(itemName.Key, itemName.Value));
                }
                else if ((int) stringHash != -741549175)
                {
                  if ((int) stringHash != -183607803)
                  {
                    if ((int) stringHash == -142945639 && key == "Shields" && itemName.Key.StartsWith("Weapon_Shield_", true, (CultureInfo) null))
                      name.Value.Add(new itemname(itemName.Key, itemName.Value));
                  }
                  else if (key == "Armors" && itemName.Key.StartsWith("Armor_", true, (CultureInfo) null))
                    name.Value.Add(new itemname(itemName.Key, itemName.Value));
                }
                else if (key == "Materials" && (itemName.Key.StartsWith("Item_", true, (CultureInfo) null) && !itemName.Key.StartsWith("Item_Cook_", true, (CultureInfo) null) && !itemName.Key.StartsWith("Item_Roast", true, (CultureInfo) null) || (itemName.Key.StartsWith("Animal_", true, (CultureInfo) null) || itemName.Key.Contains("BeeHome") || itemName.Key.Contains("Obj_FireWoodBundle"))))
                  name.Value.Add(new itemname(itemName.Key, itemName.Value));
              }
              name.Value.Sort((Comparison<itemname>) ((x, y) => x.itemID.CompareTo(y.itemID)));
              name.Value.Sort((Comparison<itemname>) ((x, y) => x.itemName.CompareTo(y.itemName)));
            }
          }
        }
        List<itemdata> itemdataList1 = new List<itemdata>();
        List<itemdata> itemdataList2 = new List<itemdata>();
        foreach (itemdata itemdata in (Collection<itemdata>) this.items)
        {
          itemdata itemByAddr = this.findItemByAddr(itemdata.itemAddress, newItems);
          if (itemByAddr == null)
            itemdataList1.Add(itemdata);
          else if (itemdata.itemID != itemByAddr.itemID)
            itemdataList1.Add(itemdata);
          else
            itemdataList2.Add(itemdata);
        }
        foreach (itemdata itemdata in itemdataList1)
        {
          foreach (KeyValuePair<string, BindingList<itemdata>> list in this.lists)
          {
            if (list.Value.Contains(itemdata))
              list.Value.Remove(itemdata);
          }
        }
        List<itemdata> list1 = this.items.ToList<itemdata>();
        foreach (itemdata newItem in newItems)
        {
          if (this.findItemByAddr(newItem.itemAddress, list1) == null)
          {
            foreach (KeyValuePair<string, BindingList<itemdata>> list2 in this.lists)
            {
              string key = list2.Key;
              // ISSUE: reference to a compiler-generated method
              uint stringHash = \u003CPrivateImplementationDetails\u003E.ComputeStringHash(key);
              if (stringHash <= 3179069417U)
              {
                if (stringHash <= 1849229205U)
                {
                  if ((int) stringHash != 1456985430)
                  {
                    if ((int) stringHash == 1849229205 && key == "Other" && (!newItem.itemID.StartsWith("Weapon_", true, (CultureInfo) null) && !newItem.itemID.StartsWith("Armor_", true, (CultureInfo) null)) && (!newItem.itemID.StartsWith("Item_", true, (CultureInfo) null) && !newItem.itemID.StartsWith("Animal_", true, (CultureInfo) null) && (!newItem.itemID.Contains("Arrow") && !newItem.itemID.Contains("BeeHome"))) && !newItem.itemID.Contains("Obj_FireWoodBundle"))
                      list2.Value.Add(newItem);
                  }
                  else if (key == "Weapons" && newItem.itemID.StartsWith("Weapon_", true, (CultureInfo) null) && (!newItem.itemID.StartsWith("Weapon_Bow_", true, (CultureInfo) null) && !newItem.itemID.StartsWith("Weapon_Shield_", true, (CultureInfo) null)))
                    list2.Value.Add(newItem);
                }
                else if ((int) stringHash != -1605091647)
                {
                  if ((int) stringHash == -1115897879 && key == "Food" && (newItem.itemID.StartsWith("Item_Cook_", true, (CultureInfo) null) || newItem.itemID.StartsWith("Item_Roast", true, (CultureInfo) null)))
                    list2.Value.Add(newItem);
                }
                else if (key == "Archery" && (newItem.itemID.StartsWith("Weapon_Bow_", true, (CultureInfo) null) || newItem.itemID.Contains("Arrow") && !newItem.itemID.StartsWith("Obj_", true, (CultureInfo) null)))
                  list2.Value.Add(newItem);
              }
              else if (stringHash <= 3553418121U)
              {
                if ((int) stringHash != -925704993)
                {
                  if ((int) stringHash == -741549175 && key == "Materials" && (newItem.itemID.StartsWith("Item_", true, (CultureInfo) null) && !newItem.itemID.StartsWith("Item_Cook_", true, (CultureInfo) null) && !newItem.itemID.StartsWith("Item_Roast", true, (CultureInfo) null) || (newItem.itemID.StartsWith("Animal_", true, (CultureInfo) null) || newItem.itemID.Contains("BeeHome") || newItem.itemID.Contains("Obj_FireWoodBundle"))))
                    list2.Value.Add(newItem);
                }
                else if (key == "Inventory")
                  list2.Value.Add(newItem);
              }
              else if ((int) stringHash != -183607803)
              {
                if ((int) stringHash == -142945639 && key == "Shields" && newItem.itemID.StartsWith("Weapon_Shield_", true, (CultureInfo) null))
                  list2.Value.Add(newItem);
              }
              else if (key == "Armors" && newItem.itemID.StartsWith("Armor_", true, (CultureInfo) null))
                list2.Value.Add(newItem);
            }
          }
        }
        foreach (KeyValuePair<string, BindingSource> source in this.sources)
        {
          for (int itemIndex = 0; itemIndex < source.Value.Count; ++itemIndex)
            source.Value.ResetItem(itemIndex);
        }
      }
    }

    public int getIdIndexInNames(string key, string section)
    {
      int num1 = -1;
      int num2 = 0;
      if (this.names.ContainsKey(section))
      {
        foreach (itemname itemname in this.names[section])
        {
          if (itemname.itemID == key)
          {
            num1 = num2;
            break;
          }
          ++num2;
        }
      }
      return num1;
    }

    public List<Control> getControls(Control parent = null)
    {
      List<Control> controlList = new List<Control>();
      parent = parent == null ? (Control) this.frmMain : parent;
      if (parent != null)
      {
        foreach (Control control in (ArrangedElementCollection) parent.Controls)
        {
          controlList.Add(control);
          controlList.AddRange((IEnumerable<Control>) this.getControls(control));
        }
      }
      return controlList;
    }

    public Control findControl(string name)
    {
      Control control1 = (Control) null;
      foreach (Control control2 in this.getControls((Control) null))
      {
        if (control2.Name == name)
        {
          control1 = control2;
          break;
        }
      }
      return control1;
    }

    public void applySelectedIndexItemID(string section)
    {
      ComboBox control1 = (ComboBox) this.findControl("cb" + section + "ItemName");
      TextBox control2 = (TextBox) this.findControl("txt" + section + "ItemID");
      if (control1 == null || control2 == null || (control1.SelectedItem == null || !(control1.SelectedItem.GetType() == typeof (itemname))))
        return;
      itemname selectedItem = (itemname) control1.SelectedItem;
      if (selectedItem == null)
        return;
      control2.Text = selectedItem.itemID;
    }

    public void refreshSelectedIndex(string section)
    {
      if (this.InvokeRequired)
      {
        this.uiQueue.Enqueue(new QueueItem(QueueItemCode.UIACTION, "REFRESH_SELECTED_INDEX", (object) null, false, section, "", (List<object>) null));
        this.worker.ReportProgress(0);
      }
      else
      {
        this.ShowControl("btn" + section + "ItemUnlock", false);
        ListBox control1 = (ListBox) this.findControl("lst" + section);
        if (control1 == null)
          return;
        itemdata selectedItem = (itemdata) control1.SelectedItem;
        if (selectedItem == null)
          return;
        TextBox control2 = (TextBox) this.findControl("txt" + section + "ItemID");
        TextBox control3 = (TextBox) this.findControl("txt" + section + "ItemQtDur");
        TextBox control4 = (TextBox) this.findControl("txt" + section + "ItemBonusType");
        TextBox control5 = (TextBox) this.findControl("txt" + section + "ItemBonusValue");
        ComboBox control6 = (ComboBox) this.findControl("cb" + section + "ItemName");
        ComboBox control7 = (ComboBox) this.findControl("cb" + section + "ItemBonusType");
        if (control2 != null)
          control2.Text = selectedItem.itemID;
        int int32At;
        if (control3 != null)
        {
          TextBox textBox = control3;
          int32At = this.mem.GetInt32At(selectedItem.itemQtDurAddress);
          string str = int32At.ToString();
          textBox.Text = str;
        }
        if (control4 != null)
          control4.Text = this.mem.GetUInt32At(selectedItem.itemBonusTypeAddress).ToString();
        if (control5 != null)
        {
          TextBox textBox = control5;
          int32At = this.mem.GetInt32At(selectedItem.itemBonusValueAddress);
          string str = int32At.ToString();
          textBox.Text = str;
        }
        if (selectedItem.isWeaponBowShield)
        {
          if (control4 != null)
            control4.Visible = false;
          if (control7 != null)
            control7.Visible = true;
        }
        else
        {
          if (control4 != null)
            control4.Visible = true;
          if (control7 != null)
            control7.Visible = false;
        }
        if (control7 != null && (!this.InvokeRequired || control6.DataSource == null))
        {
          uint uint32At = this.mem.GetUInt32At(selectedItem.itemBonusTypeAddress);
          control7.DataSource = (object) null;
          try
          {
            control7.Items.Clear();
            List<Bonus> bonusList = Bonus.getBonusList();
            control7.DataSource = (object) bonusList;
            foreach (Bonus bonus in bonusList)
            {
              if (bonus.Match((long) uint32At))
              {
                control7.SelectedItem = (object) bonus;
                break;
              }
            }
          }
          catch (Exception ex)
          {
          }
        }
        if (control6 != null && (!this.InvokeRequired || control6.DataSource == null))
        {
          int idIndexInNames = this.getIdIndexInNames(selectedItem.itemID, section);
          if (idIndexInNames < 0)
          {
            control6.DataSource = (object) null;
            try
            {
              control6.Items.Clear();
              control6.Items.Add((object) selectedItem.itemName);
              control6.Text = selectedItem.itemName;
            }
            catch (Exception ex)
            {
            }
            control6.Enabled = false;
          }
          else
          {
            control6.DataSource = (object) null;
            try
            {
              control6.Items.Clear();
              control6.DataSource = (object) this.names[section];
              control6.SelectedIndex = idIndexInNames;
            }
            catch (Exception ex)
            {
            }
            control6.Enabled = true;
          }
        }
        if (selectedItem.isWeaponBowShield && (int) this.mem.GetByteAt(selectedItem.itemEquippedFlagAddress) == 1)
          this.EnableControl("gb" + section + "Edit", false);
        else
          this.EnableControl("gb" + section + "Edit", true);
        this.ShowControl("btn" + section + "ItemUnlock", true);
      }
    }

    public void updateItemLists()
    {
    }

    public float GetTxtPositionJumpHeight()
    {
      float result = 0.0f;
      float.TryParse(this.frmMain.txtPositionJumpHeight.Text, out result);
      return result;
    }

    public void SavePosition()
    {
      if (this.coordinatesAddress <= 0L)
        return;
      float singleAt1 = this.mem.GetSingleAt(this.coordinatesAddress);
      float singleAt2 = this.mem.GetSingleAt(this.coordinatesAddress + 4L);
      float singleAt3 = this.mem.GetSingleAt(this.coordinatesAddress + 8L);
      this.savedX = singleAt1;
      this.savedY = singleAt2;
      this.savedZ = singleAt3;
      this.Putlog("Saved position X=" + singleAt1.ToString() + " Y=" + singleAt2.ToString() + " Z=" + singleAt3.ToString());
    }

    public void RestorePosition()
    {
      if (this.coordinatesAddress <= 0L)
        return;
      float savedX = this.savedX;
      float savedY = this.savedY;
      float savedZ = this.savedZ;
      this.mem.SetSingleAt(this.coordinatesAddress, savedX);
      this.mem.SetSingleAt(this.coordinatesAddress + 4L, savedY);
      this.mem.SetSingleAt(this.coordinatesAddress + 8L, savedZ);
      this.Putlog("Restored position X=" + savedX.ToString() + " Y=" + savedY.ToString() + " Z=" + savedZ.ToString());
    }

    public void JumpPosition()
    {
      if (this.coordinatesAddress <= 0L)
        return;
      float positionJumpHeight = this.GetTxtPositionJumpHeight();
      float singleAt = this.mem.GetSingleAt(this.coordinatesAddress + 4L);
      float newValue = singleAt + positionJumpHeight;
      this.mem.SetSingleAt(this.coordinatesAddress + 4L, newValue);
      this.Putlog("Jumping from Y=" + singleAt.ToString() + " to Y=" + newValue.ToString());
    }

    public void SwitchEditPosition()
    {
      if (this.coordinatesAddress <= 0L)
        return;
      Button control1 = (Button) this.findControl("btnPositionEdit");
      TextBox control2 = (TextBox) this.findControl("txtPositionX");
      TextBox control3 = (TextBox) this.findControl("txtPositionY");
      TextBox control4 = (TextBox) this.findControl("txtPositionZ");
      if (control1 == null)
        return;
      if (control1.Text == "Edit")
      {
        control2.ReadOnly = false;
        control3.ReadOnly = false;
        control4.ReadOnly = false;
        control1.Text = "Ok";
      }
      else
      {
        float result1 = this.mem.GetSingleAt(this.coordinatesAddress);
        float result2 = this.mem.GetSingleAt(this.coordinatesAddress + 4L);
        float result3 = this.mem.GetSingleAt(this.coordinatesAddress + 8L);
        float.TryParse(control2.Text, out result1);
        float.TryParse(control3.Text, out result2);
        float.TryParse(control4.Text, out result3);
        this.mem.SetSingleAt(this.coordinatesAddress, result1);
        this.mem.SetSingleAt(this.coordinatesAddress + 4L, result2);
        this.mem.SetSingleAt(this.coordinatesAddress + 8L, result3);
        control2.ReadOnly = true;
        control3.ReadOnly = true;
        control4.ReadOnly = true;
        control1.Text = "Edit";
      }
    }

    private void LstCapturedPositions_SelectedIndexChanged(object sender, EventArgs e)
    {
      ListBox listBox = (ListBox) sender;
      if (listBox.Items.Count == 0)
        return;
      this.UpdateCapturedPositionDetails((CapturedPosition) listBox.SelectedItem);
    }

    private void LstCapturedPositions_DoubleClick(object sender, EventArgs e)
    {
      if (this.getCurrentSelectedCapturePosition() == null)
        return;
      this.TPCapturedPosition();
    }

    private void UpdateCapturedPositionDetails(CapturedPosition capture)
    {
      if (capture == null)
      {
        this.frmMain.txtCapturedPositionX.Text = "";
        this.frmMain.txtCapturedPositionY.Text = "";
        this.frmMain.txtCapturedPositionZ.Text = "";
        this.frmMain.txtCapturedPositionName.Text = "";
      }
      else
      {
        this.frmMain.txtCapturedPositionX.Text = capture.X.ToString();
        this.frmMain.txtCapturedPositionY.Text = capture.Y.ToString();
        this.frmMain.txtCapturedPositionZ.Text = capture.Z.ToString();
        this.frmMain.txtCapturedPositionName.Text = capture.Name;
      }
    }

    private CapturedPosition getCurrentSelectedCapturePosition()
    {
      CapturedPosition capturedPosition = (CapturedPosition) null;
      ListBox control = (ListBox) this.findControl("lstCapturedPositions");
      if (control != null && control.Items.Count > 0)
        capturedPosition = (CapturedPosition) control.SelectedItem;
      return capturedPosition;
    }

    public void TPCapturedPosition()
    {
      CapturedPosition selectedCapturePosition = this.getCurrentSelectedCapturePosition();
      if (selectedCapturePosition == null || this.coordinatesAddress <= 0L)
        return;
      this.Putlog("Changed position to X=" + selectedCapturePosition.X.ToString() + " Y=" + selectedCapturePosition.Y.ToString() + " Z=" + selectedCapturePosition.Z.ToString());
      this.mem.SetSingleAt(this.coordinatesAddress, selectedCapturePosition.X);
      this.mem.SetSingleAt(this.coordinatesAddress + 4L, selectedCapturePosition.Y);
      this.mem.SetSingleAt(this.coordinatesAddress + 8L, selectedCapturePosition.Z);
    }

    public void AddCapturedPosition()
    {
      CapturedPosition capturedPosition = new CapturedPosition();
      float num1 = 0.0f;
      float num2 = 0.0f;
      float num3 = 0.0f;
      string str = "";
      if (this.coordinatesAddress > 0L)
      {
        num1 = this.mem.GetSingleAt(this.coordinatesAddress);
        num2 = this.mem.GetSingleAt(this.coordinatesAddress + 4L);
        num3 = this.mem.GetSingleAt(this.coordinatesAddress + 8L);
      }
      capturedPosition.X = num1;
      capturedPosition.Y = num2;
      capturedPosition.Z = num3;
      capturedPosition.Name = str;
      this.capturedPositions.Add(capturedPosition);
      this.UpdateCapturedPositionDetails(this.getCurrentSelectedCapturePosition());
    }

    public void SaveCapturedPosition()
    {
      CapturedPosition selectedCapturePosition = this.getCurrentSelectedCapturePosition();
      if (selectedCapturePosition == null)
        return;
      string text = this.frmMain.txtCapturedPositionName.Text;
      float result1;
      float.TryParse(this.frmMain.txtCapturedPositionX.Text, out result1);
      float result2;
      float.TryParse(this.frmMain.txtCapturedPositionY.Text, out result2);
      float result3;
      float.TryParse(this.frmMain.txtCapturedPositionZ.Text, out result3);
      selectedCapturePosition.X = result1;
      selectedCapturePosition.Y = result2;
      selectedCapturePosition.Z = result3;
      selectedCapturePosition.Name = text;
      try
      {
        this.capturedPositions.ResetItem(this.capturedPositions.IndexOf(selectedCapturePosition));
      }
      catch (Exception ex)
      {
      }
    }

    public void RemoveCapturedPosition()
    {
      CapturedPosition selectedCapturePosition = this.getCurrentSelectedCapturePosition();
      if (selectedCapturePosition == null)
        return;
      this.capturedPositions.Remove(selectedCapturePosition);
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
        this.TextControl(this.frmMain.txtRunSpeed.Name, this.mem.GetSingleAt(this.speedHackAddress).ToString());
      else
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
      uint result = 0;
      TextBox control = (TextBox) this.findControl("txt" + what + "Slots");
      if (control != null)
        uint.TryParse(control.Text, out result);
      return result;
    }

    public void RefreshTxtSlot(string what)
    {
      long address = 0;
      if (what == "Weapons")
        address = this.weaponsSlotsAddress;
      else if (what == "Bows")
        address = this.bowsSlotsAddress;
      else if (what == "Shields")
        address = this.shieldsSlotsAddress;
      if (address <= 0L)
        return;
      TextBox control = (TextBox) this.findControl("txt" + what + "Slots");
      if (control == null)
        return;
      uint uint32At = this.mem.GetUInt32At(address);
      this.TextControl(control.Name, uint32At.ToString());
    }

    public void UpdateSlot(string what, uint value)
    {
      long address1 = 0;
      long address2 = 0;
      if (what == "Weapons")
      {
        address1 = this.weaponsSlotsAddress;
        address2 = this.weaponsSlotsPersistAddress;
      }
      else if (what == "Bows")
      {
        address1 = this.bowsSlotsAddress;
        address2 = this.bowsSlotsPersistAddress;
      }
      else if (what == "Shields")
      {
        address1 = this.shieldsSlotsAddress;
        address2 = this.shieldsSlotsPersistAddress;
      }
      if (address1 <= 0L || value < 0U)
        return;
      this.mem.SetUInt32At(address1, value);
      this.Putlog("Slot count for " + what + " changed to : " + value.ToString());
      if (address2 <= 0L)
        return;
      this.mem.SetUInt32At(address2, value);
    }

    public long findWeaponsSlotsAddressInMemory(long startAddress, long endAddress)
    {
      int[] search = new int[16]
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
      long length = (long) search.Length;
      long num = this.mem.pagedMemorySearchMatch(search, startAddress, endAddress - startAddress);
      if (num >= 0L)
        num += length;
      return num;
    }

    public long findWeaponsSlotsPersistAddressInMemory(long startAddress, long endAddress)
    {
      int[] search = new int[12]
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
      long length = (long) search.Length;
      long num = this.mem.pagedMemorySearchMatch(search, startAddress, endAddress - startAddress);
      if (num >= 0L)
        num += length;
      return num;
    }

    public long findBowsSlotsAddressInMemory(long startAddress, long endAddress)
    {
      int[] search = new int[16]
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
      long length = (long) search.Length;
      long num = this.mem.pagedMemorySearchMatch(search, startAddress, endAddress - startAddress);
      if (num >= 0L)
        num += length;
      return num;
    }

    public long findBowsSlotsPersistAddressInMemory(long startAddress, long endAddress)
    {
      int[] search = new int[12]
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
      long length = (long) search.Length;
      long num = this.mem.pagedMemorySearchMatch(search, startAddress, endAddress - startAddress);
      if (num >= 0L)
        num += length;
      return num;
    }

    public long findShieldsSlotsAddressInMemory(long startAddress, long endAddress)
    {
      int[] search = new int[16]
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
      long length = (long) search.Length;
      long num = this.mem.pagedMemorySearchMatch(search, startAddress, endAddress - startAddress);
      if (num >= 0L)
        num += length;
      return num;
    }

    public long findShieldsSlotsPersistAddressInMemory(long startAddress, long endAddress)
    {
      int[] search = new int[12]
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
      long length = (long) search.Length;
      long num = this.mem.pagedMemorySearchMatch(search, startAddress, endAddress - startAddress);
      if (num >= 0L)
        num += length;
      return num;
    }

    public long findSpeedHackAddressInMemory(long startAddress, long endAddress)
    {
      int[] search = new int[12]
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
      long num1 = -8;
      long num2 = this.mem.pagedMemorySearchMatch(search, startAddress, endAddress - startAddress);
      if (num2 >= 0L)
        num2 += num1;
      return num2;
    }

    public long findRupeesAddressInMemory(long startAddress, long endAddress)
    {
      int[] search = new int[20]
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
      long length = (long) search.Length;
      long num = this.mem.pagedMemorySearchMatch(search, startAddress, endAddress - startAddress);
      if (num >= 0L)
        num += length;
      return num;
    }

    public long findPowersAddress(long startAddress, long regionSize)
    {
      byte[] search = new byte[20]
      {
        byte.MaxValue,
        byte.MaxValue,
        byte.MaxValue,
        byte.MaxValue,
        byte.MaxValue,
        byte.MaxValue,
        byte.MaxValue,
        byte.MaxValue,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 1,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 0
      };
      long num1 = (long) (search.Length + 4);
      long num2;
      for (; (num2 = this.mem.pagedMemorySearch(search, startAddress, regionSize)) > 0L; startAddress = num2 + 20L)
      {
        if (this.mem.GetInt32At(num2 - 4L) == 0 && (this.mem.GetInt32At(num2 + 20L) == 0 || this.mem.GetInt32At(num2 + 20L) == -1))
        {
          num2 += num1;
          break;
        }
        regionSize -= num2 + 20L - startAddress;
      }
      return num2;
    }

    public long findAmiiboDateAddress(long startAddress, long regionSize)
    {
      byte[] search = new byte[8]
      {
        (byte) 1,
        (byte) 44,
        (byte) 153,
        (byte) 133,
        (byte) 1,
        (byte) 44,
        (byte) 153,
        (byte) 133
      };
      long num1 = (long) (search.Length + 4);
      long num2 = this.mem.pagedMemorySearch(search, startAddress, regionSize);
      if (num2 >= 0L)
        num2 += num1;
      return num2;
    }

    public long findHealthAddress(long startAddress, long regionSize)
    {
      long num1 = -1;
      byte[] numArray1 = new byte[12];
      numArray1[0] = (byte) 63;
      numArray1[1] = (byte) 128;
      byte[] search = numArray1;
      byte[] sequence1 = new byte[13];
      byte[] sequence2 = new byte[4];
      int num2 = 223;
      int num3 = 224;
      int num4 = 226;
      int num5 = 199;
      int num6 = 159;
      int num7 = 190;
      int num8 = 206;
      int num9 = 254;
      int num10 = 14;
      int length1 = search.Length;
      int length2 = sequence1.Length;
      int index = length2 + length1;
      bool flag = false;
      long startAddress1 = startAddress;
      long regionSize1 = regionSize;
      long num11 = startAddress1 + regionSize1;
      byte[] numArray2 = new byte[512];
      while (!flag && startAddress1 < num11)
      {
        num1 = this.mem.pagedMemorySearch(search, startAddress1, regionSize1);
        if (num1 > 0L && this.mem.GetBytesAt(num1 - (long) length2, numArray2, index + (int) byte.MaxValue) > 0)
        {
          byte num12 = numArray2[index];
          byte num13 = numArray2[index + 1];
          if ((int) num12 != 0 && (int) num13 != 0 && ((int) numArray2[index + 8] == (int) num12 && (int) numArray2[index + 9] == (int) num13) && ((int) numArray2[index + 12] == (int) num12 && (int) numArray2[index + 13] == (int) num13 && ((int) numArray2[index + 4] == 0 && (int) numArray2[index + 5] == 0)) && ((int) num12 == 67 || (int) num12 == 68) && ((int) num13 == num2 || (int) num13 == num3 || ((int) num13 == num4 || (int) num13 == num5) || ((int) num13 == num6 || (int) num13 == num7 || ((int) num13 == num8 || (int) num13 == num9)) || ((int) num13 == num10 || (int) numArray2[index + 6] != 0 || (int) numArray2[index + 7] != 1)) && (MemAPI.findSequence(numArray2, 0, sequence1, false, false) == 0 && MemAPI.findSequence(numArray2, index + 16, sequence2, false, false) == -1))
          {
            num1 = num1 + (long) length1 + 4L;
            flag = true;
            break;
          }
        }
        if (num1 != -1L)
        {
          startAddress1 = num1 + (long) length1;
          regionSize1 = num11 - startAddress1;
        }
        else
          break;
      }
      if (!flag)
        num1 = -1L;
      return num1;
    }

    public long findStaminaAddress(long startAddress, long regionSize)
    {
      long address = -1;
      int[] search = new int[25]
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
        (int) byte.MaxValue,
        (int) byte.MaxValue,
        (int) byte.MaxValue,
        (int) byte.MaxValue,
        0,
        0,
        0,
        0,
        -2,
        -2,
        -2,
        -2
      };
      int[] numArray1 = new int[10];
      numArray1[9] = 66;
      int[] sequence = numArray1;
      int length = search.Length;
      long index = (long) (length + 22);
      bool flag = false;
      long startAddress1 = startAddress;
      long regionSize1 = regionSize;
      long num = startAddress1 + regionSize1;
      if (this.speedHackAddress > 0L)
      {
        address = this.speedHackAddress - 22565198L;
        float singleAt1 = this.mem.GetSingleAt(address + 2L);
        float singleAt2 = this.mem.GetSingleAt(address + 6L);
        if ((double) singleAt1 != 0.0 && (double) singleAt2 != 0.0 && ((double) singleAt1 == Math.Truncate((double) singleAt1) && (double) singleAt2 == Math.Truncate((double) singleAt2)))
          flag = true;
      }
      byte[] numArray2 = new byte[512];
      while (!flag && startAddress1 < num)
      {
        address = this.mem.pagedMemorySearchMatch(search, startAddress1, regionSize1);
        if (address >= 0L && this.mem.GetBytesAt(address, numArray2, length + (int) byte.MaxValue) > 0 && ((int) numArray2[length] == 67 || (int) numArray2[length] == 66) && (((int) numArray2[index] == 128 || (int) numArray2[index] == 0) && ((int) numArray2[index + 4L] == 128 || (int) numArray2[index + 4L] == 0)) && (((int) numArray2[index + 8L] == 128 || (int) numArray2[index + 8L] == 0) && MemAPI.findSequenceMatch(numArray2, (int) (index + 9L), sequence, false, false) == (int) (index + 9L)))
        {
          address += index;
          flag = true;
          break;
        }
        if (address != -1L)
        {
          startAddress1 = address + (long) length;
          regionSize1 = num - startAddress1;
        }
        else
          break;
      }
      if (!flag)
        address = -1L;
      return address;
    }

    public long findNoStaminaBarAddress(bool barDisabled = false)
    {
      this.mem.UpdateProcess("");
      MemAPI.MemoryRegion[] memoryRegionArray = this.mem.listProcessMemoryRegions(this.mem.Handle);
      List<MemAPI.MemoryRegion> memoryRegionList = new List<MemAPI.MemoryRegion>();
      foreach (MemAPI.MemoryRegion memoryRegion in memoryRegionArray)
      {
        if (memoryRegion.regionSize >= 4194304L)
          memoryRegionList.Add(memoryRegion);
      }
      byte[] numArray1 = new byte[27]
      {
        (byte) 69,
        (byte) 15,
        (byte) 56,
        (byte) 241,
        (byte) 116,
        (byte) 5,
        (byte) 104,
        (byte) 139,
        (byte) 84,
        (byte) 36,
        (byte) 8,
        (byte) 69,
        (byte) 15,
        (byte) 56,
        (byte) 240,
        (byte) 116,
        (byte) 21,
        (byte) 24,
        (byte) 102,
        (byte) 65,
        (byte) 15,
        (byte) 110,
        (byte) 198,
        (byte) 243,
        (byte) 15,
        (byte) 90,
        (byte) 192
      };
      byte[] numArray2 = new byte[27]
      {
        (byte) 144,
        (byte) 144,
        (byte) 144,
        (byte) 144,
        (byte) 144,
        (byte) 144,
        (byte) 144,
        (byte) 139,
        (byte) 84,
        (byte) 36,
        (byte) 8,
        (byte) 69,
        (byte) 15,
        (byte) 56,
        (byte) 240,
        (byte) 116,
        (byte) 21,
        (byte) 24,
        (byte) 102,
        (byte) 65,
        (byte) 15,
        (byte) 110,
        (byte) 198,
        (byte) 243,
        (byte) 15,
        (byte) 90,
        (byte) 192
      };
      return this.mem.pagedMemorySearch(barDisabled ? numArray2 : numArray1, memoryRegionList.ToArray());
    }

    public long findCoordinatesAddress(long startAddress, long regionSize)
    {
      int[] search = new int[16]
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
        (int) byte.MaxValue,
        (int) byte.MaxValue,
        0,
        1,
        7,
        (int) byte.MaxValue
      };
      long num1 = 102;
      long num2 = this.mem.pagedMemorySearchMatch(search, startAddress, regionSize);
      if (num2 >= 0L)
        num2 += num1;
      return num2;
    }

    public long findEquippedDurabilityAddress(itemdata item)
    {
      long num1 = -1;
      long regionStart;
      long regionSize;
      if (!this.mem.FindRegionByAddr(this.inventoryStartAddress, out regionStart, out regionSize, IntPtr.Zero, true))
        return num1;
      byte[] bytes = BitConverter.GetBytes(this.mem.GetInt32At(item.itemQtDurAddress));
      if (BitConverter.IsLittleEndian)
        Array.Reverse((Array) bytes);
      byte[] search = new byte[15]
      {
        (byte) 191,
        (byte) 128,
        (byte) 0,
        (byte) 0,
        bytes[0],
        bytes[1],
        bytes[2],
        bytes[3],
        byte.MaxValue,
        byte.MaxValue,
        byte.MaxValue,
        byte.MaxValue,
        (byte) 0,
        (byte) 0,
        (byte) 0
      };
      byte[] sequence1 = new byte[8];
      byte[] sequence2 = new byte[12]
      {
        (byte) 63,
        (byte) 128,
        (byte) 0,
        (byte) 0,
        (byte) 63,
        (byte) 128,
        (byte) 0,
        (byte) 0,
        (byte) 63,
        (byte) 128,
        (byte) 0,
        (byte) 0
      };
      byte[] sequence3 = new byte[6]
      {
        (byte) 0,
        (byte) 0,
        byte.MaxValue,
        byte.MaxValue,
        (byte) 1,
        (byte) 68
      };
      byte[] sequence4 = new byte[6]
      {
        (byte) 0,
        (byte) 0,
        byte.MaxValue,
        byte.MaxValue,
        (byte) 1,
        (byte) 69
      };
      byte[] sequence5 = new byte[6]
      {
        (byte) 0,
        (byte) 0,
        byte.MaxValue,
        byte.MaxValue,
        (byte) 1,
        (byte) 70
      };
      byte[] sequence6 = new byte[6]
      {
        (byte) 0,
        (byte) 0,
        byte.MaxValue,
        byte.MaxValue,
        (byte) 1,
        (byte) 75
      };
      byte[] sequence7 = new byte[6]
      {
        (byte) 0,
        (byte) 0,
        byte.MaxValue,
        byte.MaxValue,
        (byte) 2,
        (byte) 75
      };
      byte[] sequence8 = new byte[3];
      byte[] numArray1 = new byte[3];
      numArray1[1] = (byte) 4;
      byte[] sequence9 = numArray1;
      byte[] sequence10 = new byte[32];
      byte[] sequence11 = new byte[4];
      int length1 = sequence1.Length;
      int length2 = search.Length;
      int num2 = length1 + length2;
      int num3 = 20;
      bool flag = false;
      long startAddress = this.inventoryStartAddress;
      long num4 = regionStart + regionSize;
      long num5 = num4 - startAddress;
      byte[] numArray2 = new byte[512];
      while (!flag && startAddress < num4 - (long) length2)
      {
        num1 = this.mem.pagedMemorySearch(search, startAddress, num5 - (long) length2);
        if (num1 >= 0L && this.mem.GetBytesAt(num1 - (long) length1 - (long) num3, numArray2, num2 + (int) byte.MaxValue) > 0)
        {
          int start = num3;
          int num6 = 12;
          int num7 = 14;
          int num8 = (int) numArray2[start + num2];
          byte num9 = numArray2[start + num7 + 147];
          int num10 = 3;
          if (num8 < num10 && ((int) num9 == 0 || (int) num9 == 4) && (MemAPI.findSequence(numArray2, start, sequence1, false, false) == start && MemAPI.findSequence(numArray2, start + num2 + 1 + 4, sequence2, false, false) == start + num2 + 1 + 4) && (MemAPI.findSequence(numArray2, start + num7 + 147 - 9, sequence3, false, false) >= 0 || MemAPI.findSequence(numArray2, start + num7 + 147 - 9, sequence4, false, false) >= 0 || (MemAPI.findSequence(numArray2, start + num7 + 147 - 9, sequence5, false, false) >= 0 || MemAPI.findSequence(numArray2, start + num7 + 147 - 9, sequence6, false, false) >= 0) || MemAPI.findSequence(numArray2, start + num7 + 147 - 9, sequence7, false, false) >= 0) && ((MemAPI.findSequence(numArray2, start + num7 + 147 - 1, sequence8, false, false) >= 0 || MemAPI.findSequence(numArray2, start + num7 + 147 - 1, sequence9, false, false) >= 0) && (MemAPI.findSequence(numArray2, start + num6 + 80, sequence10, false, false) < 0 && MemAPI.findSequence(numArray2, start + num6 - 32, sequence11, false, false) < 0)))
          {
            num1 += (long) (num6 - length1);
            flag = true;
            break;
          }
        }
        if (num1 != -1L)
        {
          startAddress = num1 + (long) length2;
          num5 = num4 - startAddress;
        }
        else
          break;
      }
      if (!flag)
        num1 = -1L;
      return num1;
    }

    public void enableStaminaBar(bool enable = true)
    {
      if (this.inventoryStartAddress == -1L)
        return;
      this.Putlog("Scanning memory...");
      long staminaBarAddress = this.findNoStaminaBarAddress(enable);
      byte[] numArray1 = new byte[7]
      {
        (byte) 69,
        (byte) 15,
        (byte) 56,
        (byte) 241,
        (byte) 116,
        (byte) 5,
        (byte) 104
      };
      byte[] numArray2 = new byte[7]
      {
        (byte) 144,
        (byte) 144,
        (byte) 144,
        (byte) 144,
        (byte) 144,
        (byte) 144,
        (byte) 144
      };
      if (staminaBarAddress > 0L)
      {
        this.mem.SetBytesAt(staminaBarAddress, enable ? numArray1 : numArray2, 7);
        this.Putlog("Stamina bar " + (enable ? "enabled" : "disabled") + ".");
      }
      else
        this.Putlog("Not found.");
    }

    public void listMemoryRegions()
    {
      this.mem.UpdateProcess("");
      MemAPI.MemoryRegion[] memoryRegionArray = this.mem.listProcessMemoryRegions(this.mem.Handle);
      List<MemAPI.MemoryRegion> memoryRegionList = new List<MemAPI.MemoryRegion>();
      foreach (MemAPI.MemoryRegion memoryRegion in memoryRegionArray)
      {
        if (memoryRegion.regionSize >= 4194304L)
          memoryRegionList.Add(memoryRegion);
      }
      byte[] search = new byte[27]
      {
        (byte) 69,
        (byte) 15,
        (byte) 56,
        (byte) 241,
        (byte) 116,
        (byte) 5,
        (byte) 104,
        (byte) 139,
        (byte) 84,
        (byte) 36,
        (byte) 8,
        (byte) 69,
        (byte) 15,
        (byte) 56,
        (byte) 240,
        (byte) 116,
        (byte) 21,
        (byte) 24,
        (byte) 102,
        (byte) 65,
        (byte) 15,
        (byte) 110,
        (byte) 198,
        (byte) 243,
        (byte) 15,
        (byte) 90,
        (byte) 192
      };
      this.Putlog("Searching offset...");
      long num = this.mem.pagedMemorySearch(search, memoryRegionList.ToArray());
      if (num > 0L)
        this.Putlog("Address found : 0x" + num.ToString("X"));
      else
        this.Putlog("Offset not found !");
    }

    public void searchMemoryRegionForAddress(long addr)
    {
      this.Putlog("Trying to find memory region related to address 0x" + addr.ToString("X") + " in process '" + this.mem.ProcessName + "'...");
      this.mem.UpdateProcess("");
      if (this.mem.p == null)
        this.Putlog("Process '" + this.mem.ProcessName + "' not found !");
      else if (!this.mem.CheckOpenProcess())
      {
        this.Putlog("Could not open process with desired access flags...");
      }
      else
      {
        this.Putlog("Process found, scanning memory...");
        long regionStart = 0;
        long regionSize = 0;
        if (this.mem.FindRegionByAddr(addr, out regionStart, out regionSize, this.mem.Handle, false))
        {
          this.Putlog("Found region start : 0x" + regionStart.ToString("X"));
          this.Putlog("Found region end : 0x" + (regionStart + regionSize).ToString("X"));
          this.Putlog("Found region size : 0x" + regionSize.ToString("X"));
        }
        else
          this.Putlog("Region not found !");
      }
    }

    public void searchMemoryRegionForSize(long size, long startAddress = 0)
    {
      this.Putlog("Trying to find memory region with size 0x" + size.ToString("X") + " with address starting at 0x" + startAddress.ToString("X") + "' in process '" + this.mem.ProcessName + "'...");
      this.mem.UpdateProcess("");
      if (this.mem.p == null)
        this.Putlog("Process '" + this.mem.ProcessName + "' not found !");
      else if (!this.mem.CheckOpenProcess())
      {
        this.Putlog("Could not open process with desired access flags...");
      }
      else
      {
        this.Putlog("Process found, scanning memory...");
        long regionStart = 0;
        long regionSize = 0;
        if (this.mem.FindRegionBySize(size, out regionStart, out regionSize, this.mem.Handle, startAddress, false))
        {
          this.Putlog("Found region start : 0x" + regionStart.ToString("X"));
          this.Putlog("Found region end : 0x" + (regionStart + regionSize).ToString("X"));
          this.Putlog("Found region size : 0x" + regionSize.ToString("X"));
        }
        else
          this.Putlog("Region not found !");
      }
    }

    public void showCompareAddress(long address)
    {
      this.Putlog("Comparing address 0x" + address.ToString("X") + " with known ones...");
      this.Putlog("Run speed address : 0x" + this.speedHackAddress.ToString("X") + " diff=0x" + this.getAddressesDiff(this.speedHackAddress, address).ToString("X"));
      this.Putlog("Coordinates address : 0x" + this.coordinatesAddress.ToString("X") + " diff=0x" + this.getAddressesDiff(this.coordinatesAddress, address).ToString("X"));
      this.Putlog("Rupees address : 0x" + this.rupeesAddress.ToString("X") + " diff=0x" + this.getAddressesDiff(this.rupeesAddress, address).ToString("X"));
      this.Putlog("Weapons slot address : 0x" + this.weaponsSlotsAddress.ToString("X") + " diff=0x" + this.getAddressesDiff(this.weaponsSlotsAddress, address).ToString("X"));
      long addressesDiff;
      if (this.staminaAddress > 0L)
      {
        string str1 = "Stamina address : 0x";
        string str2 = this.staminaAddress.ToString("X");
        string str3 = " diff=0x";
        addressesDiff = this.getAddressesDiff(this.staminaAddress, address);
        string str4 = addressesDiff.ToString("X");
        this.Putlog(str1 + str2 + str3 + str4);
      }
      if (this.healthAddress > 0L)
      {
        string str1 = "Health address : 0x";
        string str2 = this.healthAddress.ToString("X");
        string str3 = " diff=0x";
        addressesDiff = this.getAddressesDiff(this.healthAddress, address);
        string str4 = addressesDiff.ToString("X");
        this.Putlog(str1 + str2 + str3 + str4);
      }
      if (this.inventoryStartAddress <= 0L)
        return;
      string str5 = "Inventory start address : 0x";
      string str6 = this.inventoryStartAddress.ToString("X");
      string str7 = " diff=0x";
      addressesDiff = this.getAddressesDiff(this.inventoryStartAddress, address);
      string str8 = addressesDiff.ToString("X");
      this.Putlog(str5 + str6 + str7 + str8);
    }

    public void dumpMemoryToFile(string fileName)
    {
      this.Putlog("Trying to dump process '" + this.mem.ProcessName + "'...");
      this.mem.UpdateProcess("");
      if (this.mem.p == null)
        this.Putlog("Process '" + this.mem.ProcessName + "' not found !");
      else if (!this.mem.CheckOpenProcess())
      {
        this.Putlog("Could not open process with desired access flags...");
      }
      else
      {
        this.Putlog("Process found, scanning memory...");
        long regionStart = 0;
        long regionSize = 0;
        long size1 = 1416757248;
        long size2 = 1441923072;
        if (!this.mem.FindRegionBySize(size1, out regionStart, out regionSize, IntPtr.Zero, 0L, true) || regionStart <= 0L)
        {
          if (!this.mem.FindRegionBySize(size2, out regionStart, out regionSize, IntPtr.Zero, 0L, true) || regionStart <= 0L)
          {
            this.Putlog("Memory region not found, need some thinking ?");
            return;
          }
        }
        long num1 = regionStart;
        long num2 = regionStart + regionSize;
        this.Putlog("Memory region start : " + num1.ToString("X"));
        this.Putlog("Memory region end : " + num2.ToString("X"));
        BinaryWriter binaryWriter = (BinaryWriter) null;
        this.Putlog("Starting to dump memory to '" + fileName + "' from process " + this.mem.ProcessName + "'...");
        if (this.mem.OpenProcessHandle())
        {
          int count1 = 32768;
          byte[] buffer = new byte[count1];
          int num3 = 0;
          long address = num1;
          while (address <= num2 - (long) count1)
          {
            int count2 = MemAPI.ReadBytes(address, buffer, count1, this.mem.p, this.mem.Handle);
            num3 += count2;
            if (binaryWriter == null)
              binaryWriter = new BinaryWriter((Stream) File.OpenWrite(fileName));
            binaryWriter.Write(buffer, 0, count2);
            binaryWriter.Flush();
            address += (long) count1;
          }
          if (binaryWriter != null)
          {
            binaryWriter.Close();
            binaryWriter.Dispose();
          }
          this.Putlog("Total bytes written to " + fileName + " : " + (object) num3);
        }
        this.mem.CloseProcessHandle();
        this.Putlog("Dump terminated.");
      }
    }

    public void generateCompareReport(string fileName)
    {
      if (this.memoryChanges.Count == 0)
      {
        this.Putlog("Nothing to report.");
      }
      else
      {
        this.Putlog("Reporting " + (object) this.memoryChanges.Count + " changes in memory since last dump...");
        this.Putlog("Creating report file '" + fileName + "'...");
        try
        {
          using (StreamWriter streamWriter = new StreamWriter(fileName))
          {
            streamWriter.WriteLine("Memory changes report - Number of affected offsets : " + (object) this.memoryChanges.Count);
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
              streamWriter.WriteLine("[info] rupees address = 0x" + this.rupeesAddress.ToString("X"));
            if (this.coordinatesAddress > 0L)
              streamWriter.WriteLine("[info] coordinates address = 0x" + this.coordinatesAddress.ToString("X"));
            int num1 = 13;
            foreach (MemoryChange memoryChange in this.memoryChanges)
            {
              streamWriter.WriteLine("");
              streamWriter.WriteLine("[0x" + memoryChange.address.ToString("X") + "] (0x" + memoryChange.oldValue.ToString("X2") + ") -> (0x" + memoryChange.newValue.ToString("X2") + ")");
              streamWriter.WriteLine("");
              streamWriter.WriteLine("Reference Memory Buffer (" + (object) memoryChange.oldBuffer.Length + " bytes) :");
              streamWriter.WriteLine("");
              string str1 = "";
              int num2 = 0;
              for (int index = 0; index < memoryChange.oldBuffer.Length; ++index)
              {
                if (str1.Length > 0)
                  str1 += " ";
                str1 += memoryChange.oldBuffer[index].ToString("X2");
                if (index > 0 && (index + 1) % 16 == 0)
                {
                  ++num2;
                  if (num2 == num1 + 1)
                    str1 = str1 + " => (" + memoryChange.oldValue.ToString("X2") + " -> " + memoryChange.newValue.ToString("X2") + ")";
                  streamWriter.WriteLine(str1);
                  str1 = "";
                }
              }
              streamWriter.WriteLine("");
              streamWriter.WriteLine("Process Memory Buffer (" + (object) memoryChange.newBuffer.Length + " bytes) :");
              streamWriter.WriteLine("");
              string str2 = "";
              int num3 = 0;
              for (int index = 0; index < memoryChange.newBuffer.Length; ++index)
              {
                if (str2.Length > 0)
                  str2 += " ";
                str2 += memoryChange.newBuffer[index].ToString("X2");
                if (index > 0 && (index + 1) % 16 == 0)
                {
                  ++num3;
                  if (num3 == num1 + 1)
                    str2 = str2 + " => (" + memoryChange.newValue.ToString("X2") + " <- " + memoryChange.oldValue.ToString("X2") + ")";
                  streamWriter.WriteLine(str2);
                  str2 = "";
                }
              }
            }
          }
        }
        catch (Exception ex)
        {
          this.Putlog("Error writing report to file '" + fileName + "'");
          return;
        }
        this.Putlog("Report file '" + fileName + "' created successfully.");
      }
    }

    public void compareMemory(string fileName)
    {
      this.memoryChanges.Clear();
      this.Putlog("Trying to load dump file '" + fileName + "'...");
      if (File.Exists(fileName))
      {
        this.Putlog("Found dump file '" + fileName + "'.");
        long length = new FileInfo(fileName).Length;
        this.Putlog("Trying to load process '" + this.mem.ProcessName + "'...");
        this.mem.UpdateProcess("");
        if (this.mem.p == null)
          this.Putlog("Process '" + this.mem.ProcessName + "' not found !");
        else if (!this.mem.CheckOpenProcess())
        {
          this.Putlog("Could not open process with desired access flags...");
        }
        else
        {
          this.Putlog("Process found, scanning memory...");
          long regionStart = 0;
          long regionSize = 0;
          long size1 = 1416757248;
          long size2 = 1441923072;
          if (!this.mem.FindRegionBySize(size1, out regionStart, out regionSize, IntPtr.Zero, 0L, true) || regionStart <= 0L)
          {
            if (!this.mem.FindRegionBySize(size2, out regionStart, out regionSize, IntPtr.Zero, 0L, true) || regionStart <= 0L)
            {
              this.Putlog("Memory region not found, need some thinking ?");
              return;
            }
          }
          long num1 = regionStart;
          long num2 = regionStart + regionSize;
          this.Putlog("Memory region start : " + num1.ToString("X"));
          this.Putlog("Memory region end : " + num2.ToString("X"));
          if (regionSize != length)
          {
            this.Putlog("Dump size is not equal to memory region size !");
          }
          else
          {
            this.Putlog("Starting Memory Comparison between Memory Dump and Process '" + this.mem.ProcessName + "'...");
            using (BinaryReader binaryReader = new BinaryReader((Stream) File.OpenRead(fileName)))
            {
              if (this.mem.OpenProcessHandle())
              {
                int count1 = 131072;
                byte[] buffer1 = new byte[count1];
                byte[] buffer2 = new byte[count1];
                int num3 = 0;
                int num4 = 0;
                int count2;
                while ((count2 = binaryReader.Read(buffer1, 0, count1)) > 0)
                {
                  MemAPI.ReadBytes(num1 + (long) num4, buffer2, count2, this.mem.p, this.mem.Handle);
                  for (int index = 0; index < count2; ++index)
                  {
                    if ((int) buffer1[index] != (int) buffer2[index])
                    {
                      this.Putlog("Changes found at address 0x" + (num1 + (long) num4 + (long) index).ToString("X"));
                      this.Putlog("Byte value changed from 0x" + buffer1[index].ToString("X") + " to 0x" + buffer2[index].ToString("X"));
                      ++num3;
                      int num5 = 13;
                      MemoryChange memoryChange = new MemoryChange();
                      memoryChange.regionStart = num1;
                      memoryChange.regionSize = num2 - num1;
                      memoryChange.address = num1 + (long) num4 + (long) index;
                      memoryChange.oldValue = buffer1[index];
                      memoryChange.newValue = buffer2[index];
                      int num6 = -1 * (num5 * 16);
                      MemAPI.ReadBytes(memoryChange.address + (long) num6, memoryChange.newBuffer, 16 * (num5 * 2 + 1), this.mem.p, this.mem.Handle);
                      this.ReadBytesFromFile(fileName, memoryChange.oldBuffer, (long) (num4 + index + num6), 16 * (num5 * 2 + 1));
                      this.memoryChanges.Add(memoryChange);
                    }
                  }
                  num4 += count2;
                }
                binaryReader.Close();
                this.Putlog("Total bytes read from " + fileName + " : " + (object) num4);
                this.Putlog("Total bytes changes : " + (object) num3);
              }
              this.mem.CloseProcessHandle();
            }
            this.Putlog("Memory Comparison done.");
          }
        }
      }
      else
        this.Putlog("Dump file '" + fileName + "' not found!");
    }

    public bool ReadBytesFromFile(string fileName, byte[] buffer, long startFileOffset, int count)
    {
      if (!File.Exists(fileName))
        return false;
      long length = new FileInfo(fileName).Length;
      if (startFileOffset >= length)
      {
        this.Putlog("Error index too big");
        return false;
      }
      try
      {
        using (BinaryReader binaryReader = new BinaryReader((Stream) File.OpenRead(fileName)))
        {
          binaryReader.BaseStream.Seek(startFileOffset, SeekOrigin.Begin);
          int num1 = binaryReader.Read(buffer, 0, count);
          binaryReader.Close();
          int num2 = count;
          return num1 == num2;
        }
      }
      catch (Exception ex)
      {
        this.Putlog("Error reading bytes from file '" + fileName + "' : " + ex.Message);
        return false;
      }
    }

    public void loadMemoryFromFile(string fileName)
    {
      this.Putlog("Trying to load process '" + this.mem.ProcessName + "' memory dump...");
      this.mem.UpdateProcess("");
      if (this.mem.p == null)
        this.Putlog("Process '" + this.mem.ProcessName + "' not found !");
      else if (!this.mem.CheckOpenProcess())
      {
        this.Putlog("Could not open process with desired access flags...");
      }
      else
      {
        this.Putlog("Process found, scanning memory...");
        long regionStart = 0;
        long regionSize = 0;
        long size1 = 1416757248;
        long size2 = 1441923072;
        if (!this.mem.FindRegionBySize(size1, out regionStart, out regionSize, IntPtr.Zero, 0L, true) || regionStart <= 0L)
        {
          if (!this.mem.FindRegionBySize(size2, out regionStart, out regionSize, IntPtr.Zero, 0L, true) || regionStart <= 0L)
          {
            this.Putlog("Memory region not found, need some thinking ?");
            return;
          }
        }
        long num1 = regionStart;
        long num2 = regionStart + regionSize;
        this.Putlog("Memory region start : " + num1.ToString("X"));
        this.Putlog("Memory region end : " + num2.ToString("X"));
        using (BinaryReader binaryReader = new BinaryReader((Stream) File.OpenRead(fileName)))
        {
          if (this.mem.OpenProcessHandle())
          {
            this.Putlog("Loading started.");
            int count1 = 131072;
            byte[] buffer = new byte[count1];
            int num3 = 0;
            int count2;
            while ((count2 = binaryReader.Read(buffer, 0, count1)) > 0)
            {
              num3 += count2;
              this.Putlog("Read " + (object) count2 + " bytes (total: " + (object) num3 + ")");
              MemAPI.WriteBytes(num1 + (long) num3, buffer, count2, this.mem.p, this.mem.Handle);
            }
            binaryReader.Close();
            this.Putlog("Total bytes read from " + fileName + " : " + (object) num3);
          }
          this.mem.CloseProcessHandle();
        }
        this.Putlog("Load terminated.");
      }
    }

    public void FindItemsInMemory(bool silent = false)
    {
      this.updateItems(new List<itemdata>());
      List<itemdata> newItems = new List<itemdata>();
      if (!silent)
        this.SetLblScan("Looking for process '" + this.mem.ProcessName + "'...");
      this.mem.UpdateProcess("");
      if (this.mem.p == null)
      {
        if (!silent)
          this.SetLblScan("Process '" + this.mem.ProcessName + "' not found !");
        this.updateItems(newItems);
      }
      else if (!this.mem.CheckOpenProcess())
      {
        if (!silent)
          this.SetLblScan("Could not open process with desired access flags...");
        this.updateItems(newItems);
      }
      else
      {
        if (!silent)
          this.SetLblScan("Process found, scanning memory...");
        long regionStart = 0;
        long regionSize = 0;
        long size1 = 1416757248;
        long size2 = 1441923072;
        long size3 = 1308622848;
        long startAddress;
        long endAddress;
        if (this.mem.FindRegionBySize(size1, out regionStart, out regionSize, IntPtr.Zero, 0L, true) && regionStart > 0L)
        {
          startAddress = regionStart;
          endAddress = startAddress + regionSize;
        }
        else if (this.mem.FindRegionBySize(size2, out regionStart, out regionSize, IntPtr.Zero, 0L, true) && regionStart > 0L)
        {
          startAddress = regionStart;
          endAddress = startAddress + regionSize;
        }
        else if (this.mem.FindRegionBySize(size3, out regionStart, out regionSize, IntPtr.Zero, 0L, true) && regionStart > 0L)
        {
          startAddress = regionStart;
          endAddress = startAddress + regionSize;
        }
        else
        {
          if (!silent)
            this.SetLblScan("Memory region not found, need some thinking ?");
          this.updateItems(newItems);
          return;
        }
        if (this.rupeesAddress < 0L)
        {
          if (!silent)
            this.SetLblScan("Memory region found, looking for rupees...");
          long rupeesAddressInMemory = this.findRupeesAddressInMemory(startAddress, endAddress);
          if (rupeesAddressInMemory >= 0L)
          {
            this.rupeesAddress = rupeesAddressInMemory;
            int int32At = this.mem.GetInt32At(this.rupeesAddress);
            if (!silent)
              this.SetLblScan("Found " + int32At.ToString() + " rupees.");
            this.TextControl(this.frmMain.txtRupees.Name, int32At.ToString());
            regionSize = endAddress - rupeesAddressInMemory;
            regionStart = rupeesAddressInMemory;
            this.EnableControl("gbRupees", true);
          }
          else
          {
            if (!silent)
              this.SetLblScan("Could not find rupees offset in memory !");
            this.EnableControl("gbRupees", false);
            this.TextControl(this.frmMain.txtRupees.Name, "");
          }
        }
        if (this.coordinatesAddress < 0L)
        {
          if (!silent)
            this.SetLblScan("Memory region found, looking for player coordinates...");
          long coordinatesAddress = this.findCoordinatesAddress(startAddress, endAddress - startAddress);
          if (coordinatesAddress >= 0L)
          {
            this.coordinatesAddress = coordinatesAddress;
            this.Putlog("Coordinates: X=" + this.mem.GetSingleAt(this.coordinatesAddress).ToString() + " Y=" + this.mem.GetSingleAt(this.coordinatesAddress + 4L).ToString() + " Z=" + this.mem.GetSingleAt(this.coordinatesAddress + 8L).ToString());
          }
          else
          {
            if (!silent)
              this.SetLblScan("Could not find coordinates offset in memory !");
            this.Putlog("Could not find coordinates offset in memory !");
          }
        }
        if (this.weaponsSlotsAddress < 0L || this.bowsSlotsAddress < 0L || this.shieldsSlotsAddress < 0L)
        {
          if (!silent)
            this.SetLblScan("Memory region found, looking for slots count addresses...");
          long num1 = this.rupeesAddress <= 0L ? this.findWeaponsSlotsAddressInMemory(startAddress, endAddress) : this.rupeesAddress + 2368L;
          uint uint32At;
          if (num1 >= 0L)
          {
            this.weaponsSlotsAddress = num1;
            this.RefreshTxtSlot("Weapons");
            if (!silent)
            {
              string str1 = "Found weapons slots count : ";
              uint32At = this.mem.GetUInt32At(this.weaponsSlotsAddress);
              string str2 = uint32At.ToString();
              string str3 = ".";
              this.SetLblScan(str1 + str2 + str3);
            }
            this.EnableControl("gbWeaponsSlots", true);
            long persistAddressInMemory = this.findWeaponsSlotsPersistAddressInMemory(startAddress, endAddress);
            if (persistAddressInMemory >= 0L)
            {
              this.weaponsSlotsPersistAddress = persistAddressInMemory;
              if (!silent)
                this.SetLblScan("Found persist weapons slots address.");
            }
          }
          else
            this.EnableControl("gbWeaponsSlots", false);
          long num2 = this.rupeesAddress <= 0L ? this.findBowsSlotsAddressInMemory(startAddress, endAddress) : this.rupeesAddress + 2368L + 24352L;
          if (num2 >= 0L)
          {
            this.bowsSlotsAddress = num2;
            this.RefreshTxtSlot("Bows");
            if (!silent)
            {
              string str1 = "Found bows slots count : ";
              uint32At = this.mem.GetUInt32At(this.bowsSlotsAddress);
              string str2 = uint32At.ToString();
              string str3 = ".";
              this.SetLblScan(str1 + str2 + str3);
            }
            this.EnableControl("gbBowsSlots", true);
            long persistAddressInMemory = this.findBowsSlotsPersistAddressInMemory(startAddress, endAddress);
            if (persistAddressInMemory >= 0L)
            {
              this.bowsSlotsPersistAddress = persistAddressInMemory;
              if (!silent)
                this.SetLblScan("Found persist bows slots address.");
            }
          }
          else
            this.EnableControl("gbBowsSlots", false);
          long num3 = this.rupeesAddress <= 0L ? this.findShieldsSlotsAddressInMemory(startAddress, endAddress) : this.rupeesAddress + 2368L + 24384L;
          if (num3 >= 0L)
          {
            this.shieldsSlotsAddress = num3;
            this.RefreshTxtSlot("Shields");
            if (!silent)
            {
              string str1 = "Found shields slots count : ";
              uint32At = this.mem.GetUInt32At(this.shieldsSlotsAddress);
              string str2 = uint32At.ToString();
              string str3 = ".";
              this.SetLblScan(str1 + str2 + str3);
            }
            this.EnableControl("gbShieldsSlots", true);
            long persistAddressInMemory = this.findShieldsSlotsPersistAddressInMemory(startAddress, endAddress);
            if (persistAddressInMemory >= 0L)
            {
              this.shieldsSlotsPersistAddress = persistAddressInMemory;
              if (!silent)
                this.SetLblScan("Found persist shields slots address.");
            }
          }
          else
            this.EnableControl("gbShieldsSlots", false);
        }
        if (this.speedHackAddress < 0L)
        {
          if (!silent)
            this.SetLblScan("Memory region found, looking for run speed address...");
          long hackAddressInMemory = this.findSpeedHackAddressInMemory(startAddress, endAddress);
          if (hackAddressInMemory >= 0L)
          {
            this.speedHackAddress = hackAddressInMemory;
            float singleAt = this.mem.GetSingleAt(this.speedHackAddress);
            if (!silent)
              this.SetLblScan("Found run speed multiplier : x " + singleAt.ToString() ?? "");
            this.TextControl(this.frmMain.txtRunSpeed.Name, singleAt.ToString());
          }
          else
          {
            if (!silent)
              this.SetLblScan("Could not find run speed offset in memory !");
            this.TextControl(this.frmMain.txtRunSpeed.Name, 1.ToString());
          }
        }
        if (this.inventoryStartAddress > 0L)
        {
          if (startAddress < this.inventoryStartAddress && this.inventoryStartAddress < endAddress)
          {
            regionSize = endAddress - this.inventoryStartAddress;
            regionStart = this.inventoryStartAddress;
          }
          else
            this.inventoryStartAddress = -1L;
        }
        if (!silent)
          this.SetLblScan("Memory region found, looking for items...");
        long num4 = -1;
        long num5 = regionStart;
        long num6 = regionStart + regionSize;
        this.Putlog("Memory region start : " + num5.ToString("X"));
        this.Putlog("Memory region end : " + num6.ToString("X"));
        byte[] numArray1 = new byte[2]
        {
          (byte) 16,
          (byte) 30
        };
        new byte[4][3] = (byte) 64;
        int[] sequence = new int[8]
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
        new byte[128]
        {
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue,
          byte.MaxValue
        };
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        int num7 = 0;
        if (this.mem.OpenProcessHandle())
        {
          int count = 32768;
          byte[] numArray2 = new byte[count];
          long address = num5;
          while (address < num6)
          {
            ++num7;
            if (num4 < 0L)
            {
              MemAPI.ReadBytes(address, numArray2, count, this.mem.p, this.mem.Handle);
              int sequenceMatch;
              if ((sequenceMatch = MemAPI.findSequenceMatch(numArray2, 0, sequence, true, false)) >= 0)
              {
                address += (long) sequenceMatch;
                MemAPI.ReadBytes(address, numArray2, count, this.mem.p, this.mem.Handle);
                if ((int) numArray2[1] == 30 || (int) numArray2[1] == 31 || ((int) numArray2[1] == 32 || (int) numArray2[1] == 33))
                {
                  if (MemAPI.findSequenceMatch(numArray2, 544, sequence, false, false) == 544)
                    num4 = address;
                  else
                    address += (long) numArray1.Length;
                }
                else
                  address += (long) numArray1.Length;
              }
              else
                address += (long) (count - numArray1.Length);
            }
            else
            {
              if (this.inventoryStartAddress < 0L)
                this.inventoryStartAddress = num4;
              MemAPI.ReadBytes(address, numArray2, count, this.mem.p, this.mem.Handle);
              if (MemAPI.findSequenceMatch(numArray2, 0, sequence, false, false) == 0)
              {
                long num1 = address + 7L;
                if (MemAPI.IsValidItemIDInArray(numArray2, 8))
                {
                  string stringFromMemory = MemAPI.ExtractStringFromMemory(num1 + 1L, 128, this.mem.p, this.mem.Handle);
                  newItems.Add(new itemdata()
                  {
                    itemAddress = num1,
                    itemID = stringFromMemory
                  });
                }
                address += 544L;
              }
              else
                break;
            }
          }
        }
        this.mem.CloseProcessHandle();
        stopwatch.Stop();
        if (!silent)
          this.SetLblScan("Found " + (object) newItems.Count + " items in memory.");
        if (this.itemNames.Count == 0)
        {
          this.mem.OpenProcessHandle();
          this.extractNamesFromMemory(startAddress, this.inventoryStartAddress >= 0L ? this.inventoryStartAddress : endAddress, false);
          this.mem.CloseProcessHandle();
        }
        this.updateItems(newItems);
      }
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
        return addr2 - addr1;
      return addr1 - addr2;
    }

    public void extractNamesFromMemory(long startAddress, long endAddress, bool debug = false)
    {
      this.itemNames.Clear();
      this.SetLblScan("Looking for item names in memory...");
      byte[] search = new byte[8]
      {
        (byte) 77,
        (byte) 115,
        (byte) 103,
        (byte) 83,
        (byte) 116,
        (byte) 100,
        (byte) 66,
        (byte) 110
      };
      byte[] sequence1 = new byte[4]
      {
        (byte) 76,
        (byte) 66,
        (byte) 76,
        (byte) 49
      };
      byte[] sequence2 = new byte[4]
      {
        (byte) 65,
        (byte) 84,
        (byte) 82,
        (byte) 49
      };
      byte[] sequence3 = new byte[4]
      {
        (byte) 84,
        (byte) 88,
        (byte) 84,
        (byte) 50
      };
      byte[] numArray1 = new byte[6];
      numArray1[1] = (byte) 14;
      numArray1[3] = (byte) 201;
      byte[] sequence4 = numArray1;
      byte[] sequence5 = new byte[4]
      {
        (byte) 0,
        (byte) 14,
        (byte) 0,
        (byte) 2
      };
      byte[] sequence6 = new byte[8];
      byte[] sequence7 = new byte[12];
      long startAddress1 = startAddress;
      long address;
      int count;
      for (; startAddress1 < endAddress && (address = this.mem.pagedMemorySearch(search, startAddress1, endAddress - startAddress1)) >= 0L; startAddress1 = address + (count > 0 ? (long) count : (long) search.Length))
      {
        List<string> stringList = new List<string>();
        Dictionary<string, int> dictionary = new Dictionary<string, int>();
        int num1 = this.mem.GetInt32At(address + 12L) - 16973824;
        count = this.mem.GetInt32At(address + 18L);
        byte[] numArray2;
        if (num1 > 0 && count > 0)
        {
          numArray2 = new byte[count];
          this.mem.GetBytesAt(address, numArray2, count);
        }
        else
        {
          numArray2 = new byte[0];
          num1 = 0;
          count = 0;
        }
        int start1 = 32;
        for (int index1 = 0; num1 > 0 && index1 < num1; ++index1)
        {
          while (start1 < count && (int) numArray2[start1] == 171)
            ++start1;
          int int32FromArray1 = MemAPI.ExtractInt32FromArray(numArray2, start1 + 4);
          int int32FromArray2 = MemAPI.ExtractInt32FromArray(numArray2, start1 + 16);
          int num2;
          if (MemAPI.findSequence(numArray2, start1, sequence1, false, false) == start1)
          {
            num2 = int32FromArray1 + 16;
            for (int index2 = 0; index2 < int32FromArray2; ++index2)
            {
              int int32FromArray3 = MemAPI.ExtractInt32FromArray(numArray2, start1 + 20 + 8 * index2);
              int int32FromArray4 = MemAPI.ExtractInt32FromArray(numArray2, start1 + 20 + 8 * index2 + 4);
              int index3 = start1 + int32FromArray4 + 16;
              for (int index4 = 0; index4 < int32FromArray3; ++index4)
              {
                byte num3 = numArray2[index3];
                string stringFromArray = MemAPI.ExtractStringFromArray(numArray2, index3 + 1, (int) num3);
                int int32FromArray5 = MemAPI.ExtractInt32FromArray(numArray2, index3 + 1 + (int) num3);
                index3 += 1 + (int) num3 + 4;
                if (stringFromArray.EndsWith("_Name"))
                  dictionary.Add(stringFromArray.Substring(0, stringFromArray.Length - 5), int32FromArray5);
              }
            }
          }
          else if (dictionary.Count > 0 && MemAPI.findSequence(numArray2, start1, sequence2, false, false) == start1)
            num2 = int32FromArray1 + 16;
          else if (dictionary.Count > 0 && MemAPI.findSequence(numArray2, start1, sequence3, false, false) == start1)
          {
            num2 = int32FromArray1 + 16;
            for (int start2 = start1 + 20; start2 < start1 + num2 - 12; ++start2)
            {
              if (MemAPI.findSequence(numArray2, start2, sequence4, false, false) >= 0)
              {
                for (int index2 = 0; index2 < 12; ++index2)
                  numArray2[start2 + index2] = (byte) 0;
              }
              else if (MemAPI.findSequence(numArray2, start2, sequence5, false, false) >= 0)
              {
                for (int index2 = 0; index2 < 8; ++index2)
                  numArray2[start2 + index2] = (byte) 0;
              }
            }
            for (int index2 = 0; index2 < int32FromArray2; ++index2)
            {
              int int32FromArray3 = MemAPI.ExtractInt32FromArray(numArray2, start1 + 20 + 4 * index2);
              int start2 = start1 + int32FromArray3 + 16;
              if (MemAPI.findSequence(numArray2, start2, sequence4, false, false) == start2)
                start2 += 12;
              else if (MemAPI.findSequence(numArray2, start2, sequence7, false, false) == start2)
                start2 += 12;
              else if (MemAPI.findSequence(numArray2, start2, sequence6, false, false) == start2)
                start2 += 8;
              int size = 0;
              string str = App.RemoveInvalidXmlChars(MemAPI.GetBigEndianUnicodeString(numArray2, start2, out size));
              stringList.Add(str);
            }
          }
          else
            break;
          start1 += num2;
        }
        foreach (KeyValuePair<string, int> keyValuePair in dictionary)
        {
          if (stringList.Count > keyValuePair.Value && !this.itemNames.ContainsKey(keyValuePair.Key))
            this.itemNames.Add(keyValuePair.Key, stringList[keyValuePair.Value]);
        }
        dictionary.Clear();
        stringList.Clear();
      }
      this.SetLblScan("Found " + (object) this.itemNames.Count + " names in memory.");
    }
  }
}
