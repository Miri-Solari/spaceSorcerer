

using System;

public interface IInventorySlot
{
    bool isFull { get; }
    bool isEmpty { get; }
    IInventotyItem item { get; }
    Type itemType { get; }
    int amount { get; }
    int capacity { get; }
    void SetItem(IInventotyItem item);
    void Clear();
}
