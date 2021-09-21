using Services.Shop;
using UnityEngine;

namespace Datas
{
    [CreateAssetMenu(fileName = "ShopProductsData", menuName = "Data/Shop/ShopProducts", order = 0)]
    internal class ShopProductsData: ScriptableObject
    {
        [field: SerializeField] public ShopProduct[] ShopProducts { get; private set; }
    }
}