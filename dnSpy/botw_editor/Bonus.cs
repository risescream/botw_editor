using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace botw_editor
{
	// Token: 0x02000007 RID: 7
	public class Bonus
	{
		// Token: 0x06000091 RID: 145 RVA: 0x0000DA1C File Offset: 0x0000BC1C
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

		// Token: 0x06000092 RID: 146 RVA: 0x0000DB20 File Offset: 0x0000BD20
		public bool Match(long value)
		{
			bool result = false;
			if (value == (long)this.type)
			{
				result = true;
			}
			return result;
		}

		// Token: 0x06000093 RID: 147 RVA: 0x0000DB3C File Offset: 0x0000BD3C
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

		// Token: 0x06000094 RID: 148 RVA: 0x0000DC20 File Offset: 0x0000BE20
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

		// Token: 0x04000056 RID: 86
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

		// Token: 0x04000057 RID: 87
		public Bonus.BonusTypeValue type = Bonus.BonusTypeValue.A_UNKNOWN;

		// Token: 0x02000019 RID: 25
		public enum BonusTypeValue : long
		{
			// Token: 0x04000251 RID: 593
			A_UNKNOWN = -1L,
			// Token: 0x04000252 RID: 594
			B_NONE,
			// Token: 0x04000253 RID: 595
			C_ATTACK,
			// Token: 0x04000254 RID: 596
			D_ATTACK_PLUS = 2147483649L,
			// Token: 0x04000255 RID: 597
			E_DURABILITY = 2L,
			// Token: 0x04000256 RID: 598
			F_DURABILITY_PLUS = 2147483650L,
			// Token: 0x04000257 RID: 599
			G_CRITICAL = 4L,
			// Token: 0x04000258 RID: 600
			H_CRITICAL_PLUS = 2147483652L,
			// Token: 0x04000259 RID: 601
			I_LONG_THROW = 8L,
			// Token: 0x0400025A RID: 602
			J_LONG_THROW_PLUS = 2147483656L,
			// Token: 0x0400025B RID: 603
			K_FIVE_SHOTS = 16L,
			// Token: 0x0400025C RID: 604
			L_FIVE_SHOTS_PLUS = 2147483664L,
			// Token: 0x0400025D RID: 605
			M_THREE_ARROWS = 32L,
			// Token: 0x0400025E RID: 606
			N_THREE_ARROWS_PLUS = 2147483680L,
			// Token: 0x0400025F RID: 607
			O_QUICK_SHOT = 64L,
			// Token: 0x04000260 RID: 608
			P_QUICK_SHOT_PLUS = 2147483712L,
			// Token: 0x04000261 RID: 609
			Q_SHIELD_SURF = 128L,
			// Token: 0x04000262 RID: 610
			R_SHIELD_SURF_PLUS = 2147483776L,
			// Token: 0x04000263 RID: 611
			S_SHIELD_GUARD = 256L,
			// Token: 0x04000264 RID: 612
			T_SHIELD_GUARD_PLUS = 2147483904L
		}

		// Token: 0x0200001A RID: 26
		public class BonusNameString
		{
			// Token: 0x17000015 RID: 21
			// (get) Token: 0x06000149 RID: 329 RVA: 0x0001D74E File Offset: 0x0001B94E
			public string EnumName
			{
				get
				{
					return Enum.GetName(this.type.GetType(), this.type);
				}
			}

			// Token: 0x0600014A RID: 330 RVA: 0x0001D649 File Offset: 0x0001B849
			public BonusNameString()
			{
			}

			// Token: 0x0600014B RID: 331 RVA: 0x0001D770 File Offset: 0x0001B970
			public BonusNameString(Bonus.BonusTypeValue _type)
			{
				this.type = _type;
			}

			// Token: 0x04000265 RID: 613
			public Bonus.BonusTypeValue type;
		}

		// Token: 0x0200001B RID: 27
		[CompilerGenerated]
		[Serializable]
		private sealed class <>c
		{
			// Token: 0x0600014E RID: 334 RVA: 0x0001D78B File Offset: 0x0001B98B
			internal int <ToString>b__4_0(Bonus.BonusNameString x, Bonus.BonusNameString y)
			{
				return x.EnumName.CompareTo(y.EnumName);
			}

			// Token: 0x0600014F RID: 335 RVA: 0x0001D78B File Offset: 0x0001B98B
			internal int <getBonusTypeValueList>b__6_0(Bonus.BonusNameString x, Bonus.BonusNameString y)
			{
				return x.EnumName.CompareTo(y.EnumName);
			}

			// Token: 0x04000266 RID: 614
			public static readonly Bonus.<>c <>9 = new Bonus.<>c();

			// Token: 0x04000267 RID: 615
			public static Comparison<Bonus.BonusNameString> <>9__4_0;

			// Token: 0x04000268 RID: 616
			public static Comparison<Bonus.BonusNameString> <>9__6_0;
		}
	}
}
