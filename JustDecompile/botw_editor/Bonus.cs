using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace botw_editor
{
	public class Bonus
	{
		public readonly static string[] BONUSTYPENAME;

		public Bonus.BonusTypeValue type = Bonus.BonusTypeValue.A_UNKNOWN;

		static Bonus()
		{
			Bonus.BONUSTYPENAME = new string[] { "Unknown", "None", "Attack", "Attack (+)", "Durability", "Durability (+)", "Critical", "Critical (+)", "Long throw", "Long throw (+)", "5 shots", "5 shots (+)", "3 arrows", "3 arrows (+)", "Quick shot", "Quick shot (+)", "Shield surf", "Shield surf (+)", "Shield guard", "Shield guard (+)" };
		}

		public Bonus()
		{
		}

		public static List<Bonus> getBonusList()
		{
			List<Bonus> bonus = new List<Bonus>();
			foreach (Bonus.BonusTypeValue bonusTypeValueList in Bonus.getBonusTypeValueList())
			{
				bonus.Add(new Bonus()
				{
					type = bonusTypeValueList
				});
			}
			return bonus;
		}

		public static List<Bonus.BonusTypeValue> getBonusTypeValueList()
		{
			List<Bonus.BonusTypeValue> bonusTypeValues = new List<Bonus.BonusTypeValue>();
			List<Bonus.BonusNameString> bonusNameStrings = new List<Bonus.BonusNameString>();
			foreach (Bonus.BonusTypeValue value in Enum.GetValues(typeof(Bonus.BonusTypeValue)))
			{
				bonusNameStrings.Add(new Bonus.BonusNameString(value));
			}
			bonusNameStrings.Sort((Bonus.BonusNameString x, Bonus.BonusNameString y) => x.EnumName.CompareTo(y.EnumName));
			foreach (Bonus.BonusNameString bonusNameString in bonusNameStrings)
			{
				bonusTypeValues.Add(bonusNameString.type);
			}
			return bonusTypeValues;
		}

		public bool Match(long value)
		{
			bool flag = false;
			if (value == (long)this.type)
			{
				flag = true;
			}
			return flag;
		}

		public override string ToString()
		{
			List<Bonus.BonusNameString> bonusNameStrings = new List<Bonus.BonusNameString>();
			foreach (Bonus.BonusTypeValue value in Enum.GetValues(this.type.GetType()))
			{
				bonusNameStrings.Add(new Bonus.BonusNameString(value));
			}
			bonusNameStrings.Sort((Bonus.BonusNameString x, Bonus.BonusNameString y) => x.EnumName.CompareTo(y.EnumName));
			List<Bonus.BonusTypeValue> bonusTypeValues = new List<Bonus.BonusTypeValue>();
			foreach (Bonus.BonusNameString bonusNameString in bonusNameStrings)
			{
				bonusTypeValues.Add(bonusNameString.type);
			}
			int num = bonusTypeValues.IndexOf(this.type);
			return Bonus.BONUSTYPENAME[num].ToUpper();
		}

		public class BonusNameString
		{
			public Bonus.BonusTypeValue type;

			public string EnumName
			{
				get
				{
					return Enum.GetName(this.type.GetType(), this.type);
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
			T_SHIELD_GUARD_PLUS = 2147483904
		}
	}
}