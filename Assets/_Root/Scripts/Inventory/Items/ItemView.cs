using Tools;
using UnityEngine;
using UnityEngine.UI;

namespace Inventory.Items
{
    internal class ItemView: MonoBehaviour
    {
        [SerializeField] private Image _icon;
        [SerializeField] private CustomText _text;

        public void Init(IItem item)
        {
            _text.Text = item.Info.Title;
            _icon.sprite = item.Info.Icon;
        }
    }
}