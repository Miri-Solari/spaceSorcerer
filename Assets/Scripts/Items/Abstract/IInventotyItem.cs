using System;

public interface IInventotyItem
{
    bool IsEquiped { get; set; }
    Type type { get; }
    int maxItemsInInventorySlot { get; }
    int amount { get; set; }

    IInventotyItem Clone();

}
