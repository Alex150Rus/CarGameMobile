using TMPro;
using Tools;
using UnityEngine;
using UnityEngine.UI;

namespace Inventory.Items
{
    internal class ItemView: MonoBehaviour
    {
        [SerializeField] private Image _icon;
        [SerializeField] private TextMeshProUGUI _text;

        public void Init(IItem item)
        {
            _text.text = item.Info.Title;
            _icon.sprite = item.Info.Icon;
        }
    }
}