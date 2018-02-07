using System;

namespace botw_editor
{
	public enum QueueItemCode : byte
	{
		NONE,
		REQUEST_SCAN,
		SET_LBL_SCAN,
		UPDATE_ITEMS_LISTS,
		PUTLOG,
		ENABLE_ITEMS,
		ENABLE_ACTIONS,
		UIACTION,
		UPDATE_EQUIPPED_LIST,
		UPDATE_POSITION,
		UPDATE_TIME
	}
}