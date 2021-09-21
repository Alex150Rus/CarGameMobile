using System;
using UnityEngine.Purchasing;

namespace Services.Shop
{
    [Serializable]
    internal class ShopProduct
    {
        public string Id;
        public ProductType CurrentProductType;
    }
}