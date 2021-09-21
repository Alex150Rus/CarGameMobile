using Tools;

namespace Services.Shop
{
    internal interface IShop
    {
        void Buy(string id);
        string GetCost(string productID);
        void RestorePurchase();
        IReadOnlySubscriptionAction OnSuccessPurchase { get; }
        IReadOnlySubscriptionAction OnFailedPurchase { get; }

    }
}