using System;

namespace botw_editor
{
	// Token: 0x02000011 RID: 17
	public enum QueueItemCode : byte
	{
		// Token: 0x0400020D RID: 525
		NONE,
		// Token: 0x0400020E RID: 526
		REQUEST_SCAN,
		// Token: 0x0400020F RID: 527
		SET_LBL_SCAN,
		// Token: 0x04000210 RID: 528
		UPDATE_ITEMS_LISTS,
		// Token: 0x04000211 RID: 529
		PUTLOG,
		// Token: 0x04000212 RID: 530
		ENABLE_ITEMS,
		// Token: 0x04000213 RID: 531
		ENABLE_ACTIONS,
		// Token: 0x04000214 RID: 532
		UIACTION,
		// Token: 0x04000215 RID: 533
		UPDATE_EQUIPPED_LIST,
		// Token: 0x04000216 RID: 534
		UPDATE_POSITION,
		// Token: 0x04000217 RID: 535
		UPDATE_TIME
	}
}
