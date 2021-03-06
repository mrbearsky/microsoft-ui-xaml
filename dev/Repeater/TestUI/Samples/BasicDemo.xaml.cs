﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.Linq;
using Windows.UI.Xaml.Controls;

using RecyclingElementFactory = Microsoft.UI.Xaml.Controls.RecyclingElementFactory;
using SelectTemplateEventArgs = Microsoft.UI.Xaml.Controls.SelectTemplateEventArgs;

namespace MUXControlsTestApp.Samples
{
    public sealed partial class BasicDemo : Page
    {
        public BasicDemo()
        {
            this.InitializeComponent();
            goBackButton.Click += delegate { Frame.GoBack(); };
            repeater.ItemTemplate = elementFactory;
            repeater.ItemsSource = Enumerable.Range(0, 10000).Select(x => x.ToString());
        }

        private void OnSelectTemplateKey(RecyclingElementFactory sender, SelectTemplateEventArgs args)
        {
            args.TemplateKey = (int.Parse(args.DataContext.ToString()) % 2 == 0) ? "even" : "odd";
        }
    }
}
