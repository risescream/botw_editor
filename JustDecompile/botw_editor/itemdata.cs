using System;
using System.Collections.Generic;

namespace botw_editor
{
	public class itemdata
	{
		public long itemAddress = (long)-1;

		public string itemID = "";

		public static App parent;

		public bool isArmor
		{
			get
			{
				return this.itemID.StartsWith("Armor_");
			}
		}

		public bool isBow
		{
			get
			{
				return this.itemID.StartsWith("Weapon_Bow_");
			}
		}

		public bool isEquipment
		{
			get
			{
				if (this.isWeaponBowShield)
				{
					return true;
				}
				return this.isArmor;
			}
		}

		public bool isShield
		{
			get
			{
				return this.itemID.StartsWith("Weapon_Shield_");
			}
		}

		public bool isWeapon
		{
			get
			{
				if (!this.isWeaponBowShield || this.isShield)
				{
					return false;
				}
				return !this.isBow;
			}
		}

		public bool isWeaponBowShield
		{
			get
			{
				return this.itemID.StartsWith("Weapon_");
			}
		}

		public long itemBonusTypeAddress
		{
			get
			{
				return this.itemAddress + (long)73;
			}
		}

		public long itemBonusValueAddress
		{
			get
			{
				return this.itemAddress + (long)65;
			}
		}

		public long itemEquippedFlagAddress
		{
			get
			{
				return this.itemAddress - (long)15;
			}
		}

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

		public long itemQtDurAddress
		{
			get
			{
				return this.itemAddress - (long)19;
			}
		}

		static itemdata()
		{
		}

		public itemdata(string itemID = "")
		{
			this.itemID = itemID;
		}

		public itemdata()
		{
		}

		public override string ToString()
		{
			if (this.itemName != "")
			{
				return this.itemName;
			}
			return this.itemID;
		}
	}
}