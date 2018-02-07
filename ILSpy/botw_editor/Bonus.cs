using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace botw_editor
{
	public class Bonus
	{
		public enum BonusTypeValue : long
		{
			A_UNKNOWN = -1L,
			B_NONE,
			C_ATTACK,
			D_ATTACK_PLUS = 2147483649L,
			E_DURABILITY = 2L,
			F_DURABILITY_PLUS = 2147483650L,
			G_CRITICAL = 4L,
			H_CRITICAL_PLUS = 2147483652L,
			I_LONG_THROW = 8L,
			J_LONG_THROW_PLUS = 2147483656L,
			K_FIVE_SHOTS = 16L,
			L_FIVE_SHOTS_PLUS = 2147483664L,
			M_THREE_ARROWS = 32L,
			N_THREE_ARROWS_PLUS = 2147483680L,
			O_QUICK_SHOT = 64L,
			P_QUICK_SHOT_PLUS = 2147483712L,
			Q_SHIELD_SURF = 128L,
			R_SHIELD_SURF_PLUS = 2147483776L,
			S_SHIELD_GUARD = 256L,
			T_SHIELD_GUARD_PLUS = 2147483904L
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

		[CompilerGenerated]
		[Serializable]
		private sealed class <>c
		{
			public static readonly Bonus.<>c <>9 = new Bonus.<>c();

			public static Comparison<Bonus.BonusNameString> <>9__4_0;

			public static Comparison<Bonus.BonusNameString> <>9__6_0;

			internal int <ToString>b__4_0(Bonus.BonusNameString x, Bonus.BonusNameString y)
			{
				return x.EnumName.CompareTo(y.EnumName);
			}

			internal int <getBonusTypeValueList>b__6_0(Bonus.BonusNameString x, Bonus.BonusNameString y)
			{
				return x.EnumName.CompareTo(y.EnumName);
			}
		}

		public static readonly string[] BONUSTYPENAME = new string[]
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
			List<Bonus.BonusNameString> list = new List<Bonus.BonusNameString>();
			foreach (Bonus.BonusTypeValue bonusTypeValue in Enum.GetValues(this.type.GetType()))
			{
				list.Add(new Bonus.BonusNameString(bonusTypeValue));
			}
			List<Bonus.BonusNameString> arg_7B_0 = list;
			Comparison<Bonus.BonusNameString> arg_7B_1;
			if ((arg_7B_1 = Bonus.<>c.<>9__4_0) == null)
			{
				arg_7B_1 = (Bonus.<>c.<>9__4_0 = new Comparison<Bonus.BonusNameString>(Bonus.<>c.<>9.<ToString>b__4_0));
			}
			arg_7B_0.Sort(arg_7B_1);
			List<Bonus.BonusTypeValue> list2 = new List<Bonus.BonusTypeValue>();
			foreach (Bonus.BonusNameString current in list)
			{
				list2.Add(current.type);
			}
			int num = list2.IndexOf(this.type);
			return Bonus.BONUSTYPENAME[num].ToUpper();
		}

		public bool Match(long value)
		{
			bool result = false;
			if (value == (long)this.type)
			{
				result = true;
			}
			return result;
		}

		public static List<Bonus.BonusTypeValue> getBonusTypeValueList()
		{
			List<Bonus.BonusTypeValue> list = new List<Bonus.BonusTypeValue>();
			List<Bonus.BonusNameString> list2 = new List<Bonus.BonusNameString>();
			foreach (Bonus.BonusTypeValue bonusTypeValue in Enum.GetValues(typeof(Bonus.BonusTypeValue)))
			{
				list2.Add(new Bonus.BonusNameString(bonusTypeValue));
			}
			List<Bonus.BonusNameString> arg_79_0 = list2;
			Comparison<Bonus.BonusNameString> arg_79_1;
			if ((arg_79_1 = Bonus.<>c.<>9__6_0) == null)
			{
				arg_79_1 = (Bonus.<>c.<>9__6_0 = new Comparison<Bonus.BonusNameString>(Bonus.<>c.<>9.<getBonusTypeValueList>b__6_0));
			}
			arg_79_0.Sort(arg_79_1);
			foreach (Bonus.BonusNameString current in list2)
			{
				list.Add(current.type);
			}
			return list;
		}

		public static List<Bonus> getBonusList()
		{
			List<Bonus> list = new List<Bonus>();
			foreach (Bonus.BonusTypeValue current in Bonus.getBonusTypeValueList())
			{
				list.Add(new Bonus
				{
					type = current
				});
			}
			return list;
		}
	}
}
