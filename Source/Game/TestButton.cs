using System;
using System.Collections.Generic;
using FlaxEngine;
using FlaxEngine.GUI;

namespace Game
{
    /// <summary>
    /// TestButton Script.
    /// </summary>
    public class TestButton : Script
    {
        public UIControl UIEle;
        private Button _button;
        /// <inheritdoc/>
        public override void OnStart()
        {
            _button = UIEle.Get<Button>();
            Debug.Log(_button);
            _button.HoverBegin += OnHoverBegin;

            // Here you can add code that needs to be called when script is created, just before the first game update
        }

        /// <inheritdoc/>
        public override void OnEnable()
        {
            // Here you can add code that needs to be called when script is enabled (eg. register for events)
        }

        /// <inheritdoc/>
        public override void OnDisable()
        {
            // Here you can add code that needs to be called when script is disabled (eg. unregister from events)
        }

        /// <inheritdoc/>
        public override void OnUpdate()
        {
            // Here you can add code that needs to be called every frame
        }

        private void OnButtonClicked(Button button)
        {
            Debug.Log($"Hovered over card: {button}");
        }

        private void OnHoverBegin()
        {
            Debug.Log($"Hovered over card: ");
        }
    }
}
