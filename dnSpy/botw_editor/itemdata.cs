using System;

namespace botw_editor
{
	// Token: 0x0200000C RID: 12
	public class itemdata
	{
		// Token: 0x17000004 RID: 4
		// (get) Token: 0x060000D7 RID: 215 RVA: 0x0001BCFC File Offset: 0x00019EFC
		public long itemQtDurAddress
		{
			get
			{
				return this.itemAddress - 19L;
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x060000D8 RID: 216 RVA: 0x0001BD08 File Offset: 0x00019F08
		public long itemEquippedFlagAddress
		{
			get
			{
				return this.itemAddress - 15L;
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x060000D9 RID: 217 RVA: 0x0001BD14 File Offset: 0x00019F14
		public long itemBonusTypeAddress
		{
			get
			{
				return this.itemAddress + 73L;
			}
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x060000DA RID: 218 RVA: 0x0001BD20 File Offset: 0x00019F20
		public long itemBonusValueAddress
		{
			get
			{
				return this.itemAddress + 65L;
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x060000DB RID: 219 RVA: 0x0001BD2C File Offset: 0x00019F2C
		public string itemName
		{
			get
			{
				if (itemdata.parent == null || !itemdata.parent.itemNames.ContainsKey(this.itemID))
				{
					return "";
				}
				return itemdata.parent.itemNames[this.itemID];
			}
		}

		// Token: 0x060000DC RID: 220 RVA: 0x0001BD67 File Offset: 0x00019F67
		public itemdata(string itemID = "")
		{
			this.itemID = itemID;
		}

		// Token: 0x060000DD RID: 221 RVA: 0x0001BD89 File Offset: 0x00019F89
		public itemdata()
		{
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x060000DE RID: 222 RVA: 0x0001BDA4 File Offset: 0x00019FA4
		public bool isWeaponBowShield
		{
			get
			{
				return this.itemID.StartsWith("Weapon_");
			}
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x060000DF RID: 223 RVA: 0x0001BDB6 File Offset: 0x00019FB6
		public bool isShield
		{
			get
			{
				return this.itemID.StartsWith("Weapon_Shield_");
			}
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x060000E0 RID: 224 RVA: 0x0001BDC8 File Offset: 0x00019FC8
		public bool isBow
		{
			get
			{
				return this.itemID.StartsWith("Weapon_Bow_");
			}
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x060000E1 RID: 225 RVA: 0x0001BDDA File Offset: 0x00019FDA
		public bool isWeapon
		{
			get
			{
				return this.isWeaponBowShield && !this.isShield && !this.isBow;
			}
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x060000E2 RID: 226 RVA: 0x0001BDF7 File Offset: 0x00019FF7
		public bool isArmor
		{
			get
			{
				return this.itemID.StartsWith("Armor_");
			}
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x060000E3 RID: 227 RVA: 0x0001BE09 File Offset: 0x0001A009
		public bool isEquipment
		{
			get
			{
				return this.isWeaponBowShield || this.isArmor;
			}
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x0001BE1B File Offset: 0x0001A01B
		public override string ToString()
		{
			if (!(this.itemName == ""))
			{
				return this.itemName;
			}
			return this.itemID;
		}

		// Token: 0x040001F8 RID: 504
		public long itemAddress = -1L;

		// Token: 0x040001F9 RID: 505
		public string itemID = "";

		// Token: 0x040001FA RID: 506
		public static App parent;
	}
}
