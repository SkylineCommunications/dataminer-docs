---
uid: Tutorial_Apps_Panel
---
# Creating and showing a panel

This tutorial explains how you can add and display a panel in an app.

The content and screenshots for this tutorial were created in DataMiner version 10.3.11.

Expected duration: 5 minutes

> [!TIP]
> See also: [Kata #7: Pages, panels and headers in a low-code app](https://community.dataminer.services/courses/kata-7/) on DataMiner Dojo ![Video](~/dataminer/images/video_Duo.png)

## Overview

- [Step 1: Install the dummy data sources package](#step-1-install-the-dummy-data-sources-package)
- [Step 2: Create a panel](#step-2-create-a-panel)
- [Step 3: Add content to the panel](#step-3-add-content-to-the-panel)
- [Step 4: Show the panel](#step-4-show-the-panel)

## Prerequisites

- A DataMiner System that is [connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).

## Step 1: Install the dummy data sources package

1. Go to <https://catalog.dataminer.services/details/d9089bae-0680-4da2-9c30-1c768f68fe63>.

1. Click the *Deploy* button to deploy the *IPAM - GQI dummy data sources* packages on your DMA.

   This package contains data that will be used in this tutorial.

## Step 2: Create a panel

1. Make sure that you are editing the application, and expand the "panels" section in the gray side panel.

1. Click the "+" sign in this section to create a panel.

   ![Add a panel](~/dataminer/images/AddPanel.png)

1. Specify a meaningful name for the panel, for example "Metrics".

> [!NOTE]
> If you have already created apps in the past, a panel will already be created by default.

## Step 3: Add content to the panel

1. Create a GQI query:

   1. Use the "IP subnets - Dummy" ad hoc data source.

   1. Add an *Aggregate* operator to it.

   1. Configure it to count the records using the "Network address" column.

      ![Count the subnets](~/dataminer/images/CountSubnets.png)

1. Drag the query onto the panel and display it using a state component.

1. Configure the layout of the component.

   - Use the large design.

   - Align in the center.

   The result should look like this:

   ![Subnet count](~/dataminer/images/SubnetCountState.png)

1. Close the panel editor by clicking the back button.

## Step 4: Show the panel

You have now added a panel; however, panels are not automatically displayed in a low-code app. They need to be activated through a specific action. Actions define tasks that need to be executed in response to events.

1. Add a button component to the page and configure its layout:

   - Specify a label.

   - Select an icon.

   - Under *Styles*, select the *Transparent* theme.

   The button should look like this:

   ![Show metrics](~/dataminer/images/ShowMetrics.png)

   At this point, nothing will happen yet if a user clicks the button, because actions still need to be associated with the *On click* event of the button.

1. Go to the settings of the button and click the "Configure actions" icon.

   This will open the action editor.

   ![Button on click](~/dataminer/images/ButtonOnClick.png)

1. Select the *Open a panel* action.

   Additional configuration options will become available.

   - The panel will be automatically selected in this case, as you have only one panel. If you were to have multiple panels, you would first have to select the right one.

   - Under *Where*, you can configure the display location of the panel.

   - Under *Width*, adjust the width of the panel to a percentage of the screen.

   - Enable the *As overlay* toggle button to open the panel as an overlay over the original page, which is automatically closed as soon as the user clicks outside the panel.

   ![Open a panel action](~/dataminer/images/OpenPanelAction.png)

1. Publish your changes and check if clicking the button indeed opens the **Metrics** panel.

## Next tutorial

You can also use a header bar to open panels:

- [Using a header bar](xref:Tutorial_Apps_Headerbar)

## Learning paths

This tutorial is part of the following learning path:

- [Low-Code Apps](xref:Tutorial_Apps)

## Related documentation

- [Configuring an app panel](xref:LowCodeApps_panel_config)
