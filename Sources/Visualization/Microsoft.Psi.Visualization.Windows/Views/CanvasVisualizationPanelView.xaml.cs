﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license.

namespace Microsoft.Psi.Visualization.Views
{
    using System.Collections.Generic;
    using System.Windows.Controls;
    using GalaSoft.MvvmLight.CommandWpf;
    using Microsoft.Psi.Visualization.Helpers;
    using Microsoft.Psi.Visualization.VisualizationPanels;

    /// <summary>
    /// Interaction logic for CanvasVisualizationPanelView.xaml.
    /// </summary>
    public partial class CanvasVisualizationPanelView : VisualizationPanelView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CanvasVisualizationPanelView"/> class.
        /// </summary>
        public CanvasVisualizationPanelView()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Gets the visualization panel.
        /// </summary>
        protected CanvasVisualizationPanel VisualizationPanel => (CanvasVisualizationPanel)this.DataContext;

        /// <inheritdoc/>
        public override void AppendContextMenuItems(List<MenuItem> menuItems)
        {
            // Add Set Cursor Epsilon menu with sub-menu items
            var setCursorEpsilonMenuItem = MenuItemHelper.CreateMenuItem(
                string.Empty,
                "Set Cursor Epsilon (on All Visualizers)",
                null,
                this.VisualizationPanel.VisualizationObjects.Count > 0);

            setCursorEpsilonMenuItem.Items.Add(
                MenuItemHelper.CreateMenuItem(
                    null,
                    "Infinite Past",
                    new RelayCommand(
                        () =>
                        {
                            foreach (var visualizationObject in this.VisualizationPanel.VisualizationObjects)
                            {
                                visualizationObject.CursorEpsilonNegMs = int.MaxValue;
                                visualizationObject.CursorEpsilonPosMs = 0;
                            }
                        }),
                    true));
            setCursorEpsilonMenuItem.Items.Add(
                MenuItemHelper.CreateMenuItem(
                    null,
                    "Last 5 seconds",
                    new RelayCommand(
                        () =>
                        {
                            foreach (var visualizationObject in this.VisualizationPanel.VisualizationObjects)
                            {
                                visualizationObject.CursorEpsilonNegMs = 5000;
                                visualizationObject.CursorEpsilonPosMs = 0;
                            }
                        }),
                    true));
            setCursorEpsilonMenuItem.Items.Add(
                MenuItemHelper.CreateMenuItem(
                    null,
                    "Last 1 second",
                    new RelayCommand(
                        () =>
                        {
                            foreach (var visualizationObject in this.VisualizationPanel.VisualizationObjects)
                            {
                                visualizationObject.CursorEpsilonNegMs = 1000;
                                visualizationObject.CursorEpsilonPosMs = 0;
                            }
                        }),
                    true));
            setCursorEpsilonMenuItem.Items.Add(
                MenuItemHelper.CreateMenuItem(
                    null,
                    "Last 50 milliseconds",
                    new RelayCommand(
                        () =>
                        {
                            foreach (var visualizationObject in this.VisualizationPanel.VisualizationObjects)
                            {
                                visualizationObject.CursorEpsilonNegMs = 50;
                                visualizationObject.CursorEpsilonPosMs = 0;
                            }
                        }),
                    true));

            menuItems.Add(setCursorEpsilonMenuItem);
            menuItems.Add(null);

            base.AppendContextMenuItems(menuItems);
        }
    }
}