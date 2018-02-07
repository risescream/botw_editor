using System;

namespace botw_editor
{
  public class actiondata
  {
    public static readonly string[] ACTIONTYPESTRING = new string[8]
    {
      "[undefined]",
      "Items (Quantity)",
      "Unequipped Weapons",
      "Unequipped Bows",
      "Unequipped Shields",
      "Health (Value)",
      "Stamina (Value)",
      "Rupees (Value)"
    };
    public ActionMode mode = ActionMode.TIMER;
    public int fixedValue = -1;
    public int timerSec = -1;
    public int timerQt = -1;
    public int timerMax = -1;
    public string hotKey = "";
    public BList<itemdata> filterList = new BList<itemdata>();
    public string section = "";
    public string desc = "";
    public long counter = -1;
    private int _hiddenTimer = -1;
    public ActionType type;
    public float singleValue;
    public bool UseHotKey;
    public bool StopWhenDone;
    public bool Active;
    public bool UseFilter;
    public double timeLast;
    private double _hiddenTimerLast;

    public int HiddenTimerSec
    {
      get
      {
        return this._hiddenTimer;
      }
      set
      {
        this._hiddenTimer = value;
      }
    }

    public actiondata(ActionType type = ActionType.NEW, ActionMode mode = ActionMode.FIXED)
    {
      this.type = type;
      this.mode = mode;
      switch (type)
      {
        case ActionType.NEW:
          break;
        case ActionType.SET_WEAPONS_DUR:
          this.fixedValue = 5000;
          this.timerSec = 5;
          this.timerQt = 200;
          this.timerMax = 5000;
          break;
        case ActionType.SET_BOWS_DUR:
          this.fixedValue = 5000;
          this.timerSec = 5;
          this.timerQt = 200;
          this.timerMax = 5000;
          break;
        case ActionType.SET_SHIELDS_DUR:
          this.fixedValue = 5000;
          this.timerSec = 5;
          this.timerQt = 200;
          this.timerMax = 5000;
          break;
        default:
          this.fixedValue = 100;
          this.timerSec = 5;
          this.timerQt = 100;
          this.timerMax = 100;
          break;
      }
    }

    public actiondata()
    {
    }

    public void HiddenTimerTick()
    {
      this._hiddenTimerLast = DateTime.Now.Subtract(new DateTime(1970, 1, 9, 0, 0, 0)).TotalSeconds;
    }

    public bool HiddenTimerElapsed()
    {
      double totalSeconds = DateTime.Now.Subtract(new DateTime(1970, 1, 9, 0, 0, 0)).TotalSeconds;
      if (this._hiddenTimer >= 0)
        return totalSeconds - this._hiddenTimerLast >= (double) this._hiddenTimer;
      return true;
    }

    public override string ToString()
    {
      return actiondata.ACTIONTYPESTRING[(int) this.type];
    }
  }
}
