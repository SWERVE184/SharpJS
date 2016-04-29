﻿using System;
using ExaPhaser.WebForms.Themes;
using SharpJS.Dom.Elements;

namespace ExaPhaser.WebForms.Controls
{
    /// <summary>
    /// A clickable rectangle that fires an event when clicked. Represented by an A element in most CSS frameworks.
    /// </summary>
    public sealed class Button : TextControl
    {
        #region Private Fields

        private string _text;

        #endregion Private Fields

        #region Public Constructors

        public Button()
        {
            switch (WebApplication.CurrentTheme.Stylesheet)
            {
                case CSSFramework.Foundation6:
                    InternalElement = new AnchorElement
                    {
                        Class = "button"
                    };
                    break;

                case CSSFramework.PolyUI:
                    InternalElement = new AnchorElement
                    {
                        Class = "btn--default"
                    };
                    break;

                case CSSFramework.Kubism:
                    InternalElement = new AnchorElement
                    {
                        Class = "btn"
                    };
                    break;

                default:
                    InternalElement = new AnchorElement
                    {
                        Class = "button"
                    };
                    break;
            }
            Click += OnClick;
            PerformLayout();
        }

        #endregion Public Constructors

        #region Public Properties

        public override string Text
        {
            get { return _text; }
            set { SetText(value); }
        }

        #endregion Public Properties

        #region Private Methods

        private void OnClick(object sender, EventArgs e)
        {
            Command?.Execute(new ICommandParameter(e));
        }

        private void SetText(string value)
        {
            InternalElement.TextContent = value;
            _text = value;
        }

        #endregion Private Methods

        #region Command

        /// <summary>
        /// The command fired when the button is clicked
        /// </summary>
        /// <value>The command.</value>
        public ICommand Command { get; set; }

        #endregion Command
    }
}