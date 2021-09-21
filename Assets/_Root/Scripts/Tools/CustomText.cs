using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace Tools
{
    internal class CustomText: MonoBehaviour
    {
        [SerializeField] private Text _textComponent;

        public string Text
        {
            get => GetText();
            set => SetText(value);
        }

        private void OnValidate() => Initialize();

        private void Start() => Initialize();

        private void Initialize()
        {
            if (TryAttachTextComponent(ref _textComponent) == false)
                throw new UnityException("Can't attach any text component!");
        }

        private bool TryAttachTextComponent<TComponent>(ref TComponent component) where TComponent : Component
        {
            if (component != null)
                return true;

            return TryGetComponent(out component);
        }

        public void SetText(string text)
        {
            if (_textComponent != null)
            {
                _textComponent.text = text;
            }
        }

        public string GetText()
        {
            if(_textComponent != null)
                return _textComponent.text;
            
            return string.Empty;
        }
    }
}