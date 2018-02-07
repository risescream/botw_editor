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

		public long counter = (long)-1;

		private int _hiddenTimer = -1;

		private double _hiddenTimerLast;

		public readonly static string[] ACTIONTYPESTRING;

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

		static actiondata()
		{
			actiondata.ACTIONTYPESTRING = new string[] { "[undefined]", "Items (Quantity)", "Unequipped Weapons", "Unequipped Bows", "Unequipped Shields", "Health (Value)", "Stamina (Value)", "Rupees (Value)" };
		}

		public actiondata(ActionType type = 0, ActionMode mode = 0)
		{
			this.type = type;
			this.mode = mode;
			switch (type)
			{
				case ActionType.NEW:
				{
					return;
				}
				case ActionType.SET_ITEMS_QT:
				{
					this.fixedValue = 100;
					this.timerSec = 5;
					this.timerQt = 100;
					this.timerMax = 100;
					return;
				}
				case ActionType.SET_WEAPONS_DUR:
				{
					this.fixedValue = 5000;
					this.timerSec = 5;
					this.timerQt = 200;
					this.timerMax = 5000;
					return;
				}
				case ActionType.SET_BOWS_DUR:
				{
					this.fixedValue = 5000;
					this.timerSec = 5;
					this.timerQt = 200;
					this.timerMax = 5000;
					return;
				}
				case ActionType.SET_SHIELDS_DUR:
				{
					this.fixedValue = 5000;
					this.timerSec = 5;
					this.timerQt = 200;
					this.timerMax = 5000;
					return;
				}
				default:
				{
					this.fixedValue = 100;
					this.timerSec = 5;
					this.timerQt = 100;
					this.timerMax = 100;
					return;
				}
			}
		}

		public actiondata()
		{
		}

		public bool HiddenTimerElapsed()
		{
			DateTime now = DateTime.Now;
			TimeSpan timeSpan = now.Subtract(new DateTime(1970, 1, 9, 0, 0, 0));
			double totalSeconds = timeSpan.TotalSeconds;
			if (this._hiddenTimer < 0)
			{
				return true;
			}
			return totalSeconds - this._hiddenTimerLast >= (double)this._hiddenTimer;
		}

		public void HiddenTimerTick()
		{
			DateTime now = DateTime.Now;
			TimeSpan timeSpan = now.Subtract(new DateTime(1970, 1, 9, 0, 0, 0));
			this._hiddenTimerLast = timeSpan.TotalSeconds;
		}

		public override string ToString()
		{
			return actiondata.ACTIONTYPESTRING[(int)this.type];
		}
	}
}