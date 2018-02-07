using System;

namespace botw_editor
{
	// Token: 0x02000004 RID: 4
	public class actiondata
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000001 RID: 1 RVA: 0x00002048 File Offset: 0x00000248
		// (set) Token: 0x06000002 RID: 2 RVA: 0x00002050 File Offset: 0x00000250
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

		// Token: 0x06000003 RID: 3 RVA: 0x0000205C File Offset: 0x0000025C
		public void HiddenTimerTick()
		{
			this._hiddenTimerLast = DateTime.Now.Subtract(new DateTime(1970, 1, 9, 0, 0, 0)).TotalSeconds;
		}

		// Token: 0x06000004 RID: 4 RVA: 0x00002094 File Offset: 0x00000294
		public bool HiddenTimerElapsed()
		{
			double totalSeconds = DateTime.Now.Subtract(new DateTime(1970, 1, 9, 0, 0, 0)).TotalSeconds;
			return this._hiddenTimer < 0 || totalSeconds - this._hiddenTimerLast >= (double)this._hiddenTimer;
		}

		// Token: 0x06000005 RID: 5 RVA: 0x000020E8 File Offset: 0x000002E8
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

		// Token: 0x06000006 RID: 6 RVA: 0x00002220 File Offset: 0x00000420
		public actiondata()
		{
		}

		// Token: 0x06000007 RID: 7 RVA: 0x00002291 File Offset: 0x00000491
		public override string ToString()
		{
			return actiondata.ACTIONTYPESTRING[(int)this.type];
		}

		// Token: 0x0400000D RID: 13
		public ActionType type;

		// Token: 0x0400000E RID: 14
		public ActionMode mode = ActionMode.TIMER;

		// Token: 0x0400000F RID: 15
		public int fixedValue = -1;

		// Token: 0x04000010 RID: 16
		public float singleValue;

		// Token: 0x04000011 RID: 17
		public int timerSec = -1;

		// Token: 0x04000012 RID: 18
		public int timerQt = -1;

		// Token: 0x04000013 RID: 19
		public int timerMax = -1;

		// Token: 0x04000014 RID: 20
		public bool UseHotKey;

		// Token: 0x04000015 RID: 21
		public string hotKey = "";

		// Token: 0x04000016 RID: 22
		public bool StopWhenDone;

		// Token: 0x04000017 RID: 23
		public bool Active;

		// Token: 0x04000018 RID: 24
		public bool UseFilter;

		// Token: 0x04000019 RID: 25
		public BList<itemdata> filterList = new BList<itemdata>();

		// Token: 0x0400001A RID: 26
		public double timeLast;

		// Token: 0x0400001B RID: 27
		public string section = "";

		// Token: 0x0400001C RID: 28
		public string desc = "";

		// Token: 0x0400001D RID: 29
		public long counter = -1L;

		// Token: 0x0400001E RID: 30
		private int _hiddenTimer = -1;

		// Token: 0x0400001F RID: 31
		private double _hiddenTimerLast;

		// Token: 0x04000020 RID: 32
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
	}
}
