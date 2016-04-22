﻿using ExaPhaser.WebForms.Themes;
using JSIL;
using JSIL.Dom;
using JSIL.Dom.JSLibraries;
using JSIL.Dom.JSLibraries.JQElements;

namespace ExaPhaser.WebForms
{
    public class WebApplication
    {
        private JQDivElement _formHost;

        public WebApplication(CSSUITheme theme)
        {
            if (Verbatim.Expression("0") == null)
            {
                throw new RequiresJSILRuntimeException();
            }
            UITheme = theme;
            CurrentTheme = UITheme;
        }

        public CSSUITheme UITheme { get; set; }

        public static CSSUITheme CurrentTheme { get; private set; }

        public void Run(WebForm webForm, string hostElementId)
        {
            Run(webForm, new JQElement(Document.GetElementById(hostElementId)));
        }

        public void Run(WebForm webForm, JQElement hostElement)
        {
            CreateApplication(hostElement); //Create containers
            webForm.ContainerElement = _formHost.DOMRepresentation; //Set container to new element
        }

        protected void CreateApplication(JQElement applicationHostElement)
        {
            CreateFormHostElement(applicationHostElement);
        }

        private void CreateFormHostElement(JQElement formHostParent)
        {
            var formHostContainer = new JQDivElement();
            _formHost = new JQDivElement();
            formHostContainer.Append(_formHost);
            switch (UITheme.Stylesheet)
            {
                case CSSFramework.Foundation6:
                    formHostContainer.AddClass("row");
                    _formHost.AddClass("large-12");
                    _formHost.AddClass("columns");
                    break;

                case CSSFramework.PolyUI:
                    formHostContainer.AddClass("grid");
                    _formHost.AddClass("centered grid__col--12");
                    break;

                case CSSFramework.Kubism:
                    formHostContainer.AddClass("wrap");
                    break;
            }
            formHostParent.Append(formHostContainer);
        }
    }
}