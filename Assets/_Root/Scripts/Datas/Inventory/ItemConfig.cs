using UnityEngine;

namespace Datas.Inventory
{
    [CreateAssetMenu(fileName = nameof(ItemConfig), menuName = "Data/Inventory/" + nameof(ItemConfig), order = 0)]
    internal class ItemConfig : ScriptableObject
    {
        [field: SerializeField] public int Id { get; private set; }
        [field: SerializeField] public string Title { get; private set; }
        [field: SerializeField] public Sprite Icon { get; private set; }
    }
}