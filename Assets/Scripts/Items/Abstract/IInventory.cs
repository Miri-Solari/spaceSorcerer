using System;

public interface IInventory
{
    int capacity { get; set; }
    bool isFull { get; }
    IInventotyItem GetItem(Type itemType);
    IInventotyItem[] GetAllItems();
    IInventotyItem[] GetAllItems(Type itemType);
    IInventotyItem[] GetEquippedItems();
    int GetItemAmount(Type itemType);
    bool TryToAdd(object sender, IInventotyItem item);
    void Remove(object sender, Type itemType, int amount = 1);
    bool HasItem(Type itemType, out IInventotyItem item);


}

