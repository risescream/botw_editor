using System;

namespace botw_editor
{
	public class actiondata
	{
		public ActionType type;

		public ActionMode mode = ActionMode.TIMER;

		public int fixedValue = -1;

		public float singleValue;

		public int timerSec = -1;

		public int timerQt = -1;

		public int timerMax = -1;

		public bool UseHotKey;

		public string hotKey = "";

		public bool StopWhenDone;

		public bool Active;

		public bool UseFilter;

		public BList<itemdata> filterList = new BList<itemdata>();

		public double timeLast;

		public string section = "";

		public string desc = "";

		public long counter = -1L;

		private int _hiddenTimer = -1;

		private double _hiddenTimerLast;

		public static readonly string[] ACTIONTYPESTRING = new string[]
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

		public void HiddenTimerTick()
		{
			this._hiddenTimerLast = DateTime.Now.Subtract(new DateTime(1970, 1, 9, 0, 0, 0)).TotalSeconds;
		}

		public bool HiddenTimerElapsed()
		{
			double totalSeconds = DateTime.Now.Subtract(new DateTime(1970, 1, 9, 0, 0, 0)).TotalSeconds;
			return this._hiddenTimer < 0 || totalSeconds - this._hiddenTimerLast >= (double)this._hiddenTimer;
		}

		public actiondata(ActionType type = ActionType.NEW, ActionMode mode = ActionMode.FIXED)
		{
			this.type = type;
			this.mode = mode;
			switch (type)
			{
			case ActionType.NEW:
				return;
			case ActionType.SET_WEAPONS_DUR:
				this.fixedValue = 5000;
				this.timerSec = 5;
				this.timerQt = 200;
				this.timerMax = 5000;
				return;
			case ActionType.SET_BOWS_DUR:
				this.fixedValue = 5000;
				this.timerSec = 5;
				this.timerQt = 200;
				this.timerMax = 5000;
				return;
			case ActionType.SET_SHIELDS_DUR:
				this.fixedValue = 5000;
				this.timerSec = 5;
				this.timerQt = 200;
				this.timerMax = 5000;
				return;
			}
			this.fixedValue = 100;
			this.timerSec = 5;
			this.timerQt = 100;
			this.timerMax = 100;
		}

		public actiondata()
		{
		}

		public override string ToString()
		{
			return actiondata.ACTIONTYPESTRING[(int)this.type];
		}
	}
}
