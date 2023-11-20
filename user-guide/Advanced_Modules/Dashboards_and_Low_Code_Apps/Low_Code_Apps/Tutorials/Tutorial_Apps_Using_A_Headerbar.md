---
uid: Tutorial_Apps_Headerbar
---
# Using a headerbar

This tutorial explains how you can add a header bar to your pages and panels.

## Overview

- [Step 1: Add a page header bar](#step-1-add-a-page-header-bar)
- [Step 2: Create a header button](#step-2-create-a-header-button)
- [Step 3: (Optional) Create a panel header bar](#step-3-optional-create-a-panel-header-bar)

## Prerequisites

- A DataMiner System using DataMiner 10.2.6 or higher.

## Step 1: Add a page header bar

1. Make sure you're editing the app.

2. Within the "Header bar" section, toggle the switch to the right to add a header bar to your page.

   ![Enable a header bar](~/user-guide/images/HeaderBarOption.png)

## Step 2: Create a header button

1. There is a "+" sign visible on both the left and right sides of your header bar. Clicking on it will add a header button aligned either to the left or right. Add a button on the right side.

   ![Header bar button](~/user-guide/images/HeaderbarButton.png)

1. Clicking on that button will activate additional configuration options in the grey side panel, within the "Header bar" section.

   ![Header bar button config](~/user-guide/images/HeaderBarButtonConfig.png)

   1. Give the button a nice icon. You can search for "Dashboard" to find applicable icons for a "Metrics" panel.
   2. Configure the button to open the side panel, as was done in [Showing a panel](xref:Tutorial_Apps_Panel).

1. Publish the app and validate that clicking the button in the header bar opens the panel.

## Step 3: (Optional) Create a panel header bar

1. Follow the same steps as outlined in the previous instructions to add a header bar to our "Metrics" panel. Include a button on the right side to close the panel; a "Close" icon is adequate. There is no need for a specific name.

   ![Header bar close button](~/user-guide/images/HeaderBarClose.png)

1. To close the panel when the user clicks the header bar button, you can use the "Close a panel" action.

   ![Close a panel action](~/user-guide/images/ClosePanelAction.png)

1. Publish the app and validate that clicking the **Close** button in the panel header closes the panel.

## Learning paths

This tutorial is part of the following learning path:

- [Low-Code Apps](xref:Tutorial_Apps)

## Related documentation

- [Close a panel of a low-code app](xref:LowCodeApps_event_config)
