namespace Inventory.Items
{
    internal interface IItem
    {
        int Id { get; }
        ItemInfo Info { get; }
    }

    
    internal class Item: IItem
    {
        public int Id { get; }
        public ItemInfo Info { get; }

        public Item(int id, ItemInfo info)
        {
            Id = id;
            Info = info;
        }
    }
}