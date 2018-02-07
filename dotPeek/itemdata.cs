namespace botw_editor
{
  public class itemdata
  {
    public long itemAddress = -1;
    public string itemID = "";
    public static App parent;

    public long itemQtDurAddress
    {
      get
      {
        return this.itemAddress - 19L;
      }
    }

    public long itemEquippedFlagAddress
    {
      get
      {
        return this.itemAddress - 15L;
      }
    }

    public long itemBonusTypeAddress
    {
      get
      {
        return this.itemAddress + 73L;
      }
    }

    public long itemBonusValueAddress
    {
      get
      {
        return this.itemAddress + 65L;
      }
    }

    public string itemName
    {
      get
      {
        if (itemdata.parent == null || !itemdata.parent.itemNames.ContainsKey(this.itemID))
          return "";
        return itemdata.parent.itemNames[this.itemID];
      }
    }

    public bool isWeaponBowShield
    {
      get
      {
        return this.itemID.StartsWith("Weapon_");
      }
    }

    public bool isShield
    {
      get
      {
        return this.itemID.StartsWith("Weapon_Shield_");
      }
    }

    public bool isBow
    {
      get
      {
        return this.itemID.StartsWith("Weapon_Bow_");
      }
    }

    public bool isWeapon
    {
      get
      {
        if (this.isWeaponBowShield && !this.isShield)
          return !this.isBow;
        return false;
      }
    }

    public bool isArmor
    {
      get
      {
        return this.itemID.StartsWith("Armor_");
      }
    }

    public bool isEquipment
    {
      get
      {
        if (!this.isWeaponBowShield)
          return this.isArmor;
        return true;
      }
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
      if (!(this.itemName == ""))
        return this.itemName;
      return this.itemID;
    }
  }
}
