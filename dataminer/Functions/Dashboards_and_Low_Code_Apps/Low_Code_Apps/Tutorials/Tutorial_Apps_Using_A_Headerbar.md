---
uid: Tutorial_Apps_Headerbar
---
# Using a header bar

This tutorial explains how you can add a header bar to your pages and panels.

The content and screenshots for this tutorial were created in DataMiner version 10.3.11.

Expected duration: 5 minutes

> [!TIP]
> See also: [Kata #7: Pages, panels and headers in a low-code app](https://community.dataminer.services/courses/kata-7/) on DataMiner Dojo ![Video](~/dataminer/images/video_Duo.png)

## Overview

- [Step 1: Add a page header bar](#step-1-add-a-page-header-bar)
- [Step 2: Create a header button](#step-2-create-a-header-button)
- [Step 3: (Optional) Create a panel header bar](#step-3-optional-create-a-panel-header-bar)

## Step 1: Add a page header bar

1. Make sure you are editing the app.

1. In the gray side panel on the left, next to *Header bar*, toggle the switch to the right.

   This will add a header bar to your page.

   ![Enable a header bar](~/dataminer/images/HeaderBarOption.png)

## Step 2: Create a header button

1. Click the "+" icon on the right side of the header bar.

   This will add a header bar button on the right. There is also a "+" icon on the left, which can be used to add a button on the left.

   ![Header bar button](~/dataminer/images/HeaderbarButton.png)

1. Click the button you have added.

   This will activate additional configuration options in the gray side panel, within the "Header bar" section.

   ![Header bar button config](~/dataminer/images/HeaderBarButtonConfig.png)

   1. Give the button a suitable icon.

      You can search for "Dashboard" to find applicable icons for a "Metrics" panel.

   1. Configure the button to open a side panel, similar to the way this was done in [Creating and showing a panel](xref:Tutorial_Apps_Panel).

1. Publish the app and check if clicking the button in the header bar opens the panel.

## Step 3: (Optional) Create a panel header bar

1. Follow the same steps as outlined in the previous instructions to add a header bar to the "Metrics" panel.

   - Include a button on the right side of the panel header bar.

   - Use a "Close" icon for the button.

   - Do not specify a name for the button.

   ![Header bar close button](~/dataminer/images/HeaderBarClose.png)

1. Configure the *Close a panel* action, so that the panel closes when a user clicks the header bar button.

   ![Close a panel action](~/dataminer/images/ClosePanelAction.png)

1. Publish the app and check if clicking the new button in the panel header closes the panel.

## Next tutorial

Now that you know how to create navigational controls, take a look at how you can execute actions:

- [Running a script when a page opens](xref:Tutorial_Apps_Script_Upon_Page_Load)

## Learning paths

This tutorial is part of the following learning path:

- [Low-Code Apps](xref:Tutorial_Apps)

## Related documentation

- [Configuring the app header bar](xref:LowCodeApps_header_config)
- [Closing a panel of a low-code app](xref:LowCodeApps_event_config#closing-a-panel-of-the-app)
