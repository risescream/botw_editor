using System;
using System.Collections.Generic;

namespace botw_editor
{
  public class Bonus
  {
    public static readonly string[] BONUSTYPENAME = new string[20]
    {
      "Unknown",
      "None",
      "Attack",
      "Attack (+)",
      "Durability",
      "Durability (+)",
      "Critical",
      "Critical (+)",
      "Long throw",
      "Long throw (+)",
      "5 shots",
      "5 shots (+)",
      "3 arrows",
      "3 arrows (+)",
      "Quick shot",
      "Quick shot (+)",
      "Shield surf",
      "Shield surf (+)",
      "Shield guard",
      "Shield guard (+)"
    };
    public Bonus.BonusTypeValue type = Bonus.BonusTypeValue.A_UNKNOWN;

    public override string ToString()
    {
      List<Bonus.BonusNameString> bonusNameStringList = new List<Bonus.BonusNameString>();
      foreach (Bonus.BonusTypeValue _type in Enum.GetValues(this.type.GetType()))
        bonusNameStringList.Add(new Bonus.BonusNameString(_type));
      bonusNameStringList.Sort((Comparison<Bonus.BonusNameString>) ((x, y) => x.EnumName.CompareTo(y.EnumName)));
      List<Bonus.BonusTypeValue> bonusTypeValueList = new List<Bonus.BonusTypeValue>();
      foreach (Bonus.BonusNameString bonusNameString in bonusNameStringList)
        bonusTypeValueList.Add(bonusNameString.type);
      int index = bonusTypeValueList.IndexOf(this.type);
      return Bonus.BONUSTYPENAME[index].ToUpper();
    }

    public bool Match(long value)
    {
      bool flag = false;
      if ((Bonus.BonusTypeValue) value == this.type)
        flag = true;
      return flag;
    }

    public static List<Bonus.BonusTypeValue> getBonusTypeValueList()
    {
      List<Bonus.BonusTypeValue> bonusTypeValueList = new List<Bonus.BonusTypeValue>();
      List<Bonus.BonusNameString> bonusNameStringList = new List<Bonus.BonusNameString>();
      foreach (Bonus.BonusTypeValue _type in Enum.GetValues(typeof (Bonus.BonusTypeValue)))
        bonusNameStringList.Add(new Bonus.BonusNameString(_type));
      bonusNameStringList.Sort((Comparison<Bonus.BonusNameString>) ((x, y) => x.EnumName.CompareTo(y.EnumName)));
      foreach (Bonus.BonusNameString bonusNameString in bonusNameStringList)
        bonusTypeValueList.Add(bonusNameString.type);
      return bonusTypeValueList;
    }

    public static List<Bonus> getBonusList()
    {
      List<Bonus> bonusList = new List<Bonus>();
      foreach (Bonus.BonusTypeValue bonusTypeValue in Bonus.getBonusTypeValueList())
        bonusList.Add(new Bonus()
        {
          type = bonusTypeValue
        });
      return bonusList;
    }

    public enum BonusTypeValue : long
    {
      A_UNKNOWN = -1,
      B_NONE = 0,
      C_ATTACK = 1,
      E_DURABILITY = 2,
      G_CRITICAL = 4,
      I_LONG_THROW = 8,
      K_FIVE_SHOTS = 16,
      M_THREE_ARROWS = 32,
      O_QUICK_SHOT = 64,
      Q_SHIELD_SURF = 128,
      S_SHIELD_GUARD = 256,
      D_ATTACK_PLUS = 2147483649,
      F_DURABILITY_PLUS = 2147483650,
      H_CRITICAL_PLUS = 2147483652,
      J_LONG_THROW_PLUS = 2147483656,
      L_FIVE_SHOTS_PLUS = 2147483664,
      N_THREE_ARROWS_PLUS = 2147483680,
      P_QUICK_SHOT_PLUS = 2147483712,
      R_SHIELD_SURF_PLUS = 2147483776,
      T_SHIELD_GUARD_PLUS = 2147483904,
    }

    public class BonusNameString
    {
      public Bonus.BonusTypeValue type;

      public string EnumName
      {
        get
        {
          return Enum.GetName(this.type.GetType(), (object) this.type);
        }
      }

      public BonusNameString()
      {
      }

      public BonusNameString(Bonus.BonusTypeValue _type)
      {
        this.type = _type;
      }
    }
  }
}
