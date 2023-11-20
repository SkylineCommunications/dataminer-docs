---
uid: Tutorial_Apps_Panel
---
# Showing a panel

This tutorial explains how you can add and display a panel in an app.

## Overview

- [Step 1: Install the dummy data sources package](#step-1-install-the-dummy-data-sources-package)
- [Step 2: Create a panel](#step-2-create-a-panel)
- [Step 3: Add content to the panel](#step-3-add-content-to-the-panel)
- [Step 4: Show the panel](#step-4-show-the-panel)

## Prerequisites

- A DataMiner System using DataMiner 10.2.6 or higher, which is [connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).

## Step 1: Install the dummy data sources package

1. Go to <https://catalog.dataminer.services/catalog/5410>

1. Click the *Deploy* button to deploy the *IPAM - GQI dummy data sources* packages on your DMA.

   This package contains some data which will be used throughout the tutorial.

## Step 2: Create a panel

1. Ensure that you are editing the application, and be sure to expand the "panels" section in the grey side panel.

1. Click the "+" sign in this section to create a panel.

   ![Add a panel](~/user-guide/images/AddPanel.png)

1. Assign a meaningful name to the panel. In our IPAM app, we will name it "Metrics".

> [!NOTE]
> If you have already created apps in the past, then a panel will already be created by default.

## Step 3: Add content to the panel

1. Create a GQI query that uses the "IP subnets - Dummy" ad hoc data source. Add an aggregate operator to it and count the records using the "Network adress" column.

   ![Count the subnets](~/user-guide/images/CountSubnets.png)

1. Drag the query on the panel and display it using a state component.

1. Configure its layout.
   - Use the large design.
   - Align in the center. 

   The result should look something like this.

   ![Subnet count](~/user-guide/images/SubnetCountState.png)

1. Close the panel editor by clicking the back button.

## Step 4: Show the panel

1. We currently have a panel, however, these panels do not appear automatically in your low-code app. Instead, they require activation through a specific action. Actions define the tasks to be executed in response to events.

1. Add a button to our page and configure a label and icon for it. Additionally, use the "Transparent" team for the button. The button should look something like this.

   ![Show metrics](~/user-guide/images/ShowMetrics.png)

1. Currently nothing will happen when clicking the button as we have associated no actions with the "On click" event of the button. Go to the settings of the button and click on the "Configure actions" icon. This will open the action editor popup.

   ![Button on click](~/user-guide/images/ButtonOnClick.png)

1. Pick the "Open a panel" action which brings up additional configuration options.

   - The panel we intend to open should be automatically selected by default, given that we only have one panel.
   - You have the option to configure its display location.
   - Adjust the width of the panel as a percentage of the screen.
   - Specify whether an overlay should be applied. If enabled, an overlay will be placed on the original page, closing the panel when clicked.

   Your action configuration might resemble the following.

   ![Open a panel action](~/user-guide/images/OpenPanelAction.png)

1. Publish your changes and validate that clicking the button opens the **Metrics** panel.

[Using a headerbar](xref:Tutorial_Apps_Headerbar)

## Next tutorial

Header bars can also be used to open panels. Let's explore how to incorporate them into your app.

- [using a headerbar](xref:Tutorial_Apps_Headerbar)

## Learning paths

This tutorial is part of the following learning path:

- [Low-Code Apps](xref:Tutorial_Apps)

## Related documentation

- [Configuring a panel of a low-code app](xref:LowCodeApps_panel_config)
