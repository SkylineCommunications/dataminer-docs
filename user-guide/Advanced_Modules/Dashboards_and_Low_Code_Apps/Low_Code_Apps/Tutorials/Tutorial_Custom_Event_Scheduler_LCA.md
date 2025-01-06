---
uid: Tutorial_Custom_Event_Scheduler_LCA
---

# Creating a custom event scheduler low-code app

This tutorial explains how you can create an event scheduler app.
After this tutorial you will have an app with two pages, an overview page and a page showing a timeline with all the events.

Expected duration: 45 minutes

> [!NOTE]
> In this tutorial we will only focus on the functional aspects of the app. If you want to apply a nice layout and custom templates you can take a look at the example app that will be deployed with the package in step 1.

> [!TIP]
> See also: [Build a custom event scheduler](https://community.dataminer.services/courses/kata-51/) on DataMiner Dojo!

## Prerequisites

- A DataMiner system that is [connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).
- Basic understanding of low-code apps.

> [!TIP]
> If you are not that familiar with low-code apps you can take a look at the following tutorials:
>
> - [Creating and publishing](xref:Tutorial_Apps_Creating_And_Publishing)
> - [Edit an existing app](xref:Tutorial_Apps_Edit_Existing_App)
> - [Managing pages](xref:Tutorial_Apps_Managing_Pages)
> - [Creating and showing a panel](xref:Tutorial_Apps_Panel)
> - [Using a header bar](xref:Tutorial_Apps_Headerbar)

## Overview

- [Step 1: Install the example package from the catalog](#step-1-install-the-example-package-from-the-catalog)
- [Step 2: Create the app and the pages](#step-2-create-the-app-and-the-pages)
- [Step 3: Create the GQI queries](#step-3-create-the-gqi-queries)
- [Step 4: Create the event overview page](#step-4-create-the-event-overview-page)
- [Step 5: Enable users to add events](#step-5-enable-users-to-add-events)
- [Step 6: Enable users to edit events](#step-6-enable-users-to-edit-events)
- [Step 7: Create the timeline overview page](#step-7-create-the-timeline-overview-page)

## Step 1: Install the example package from the catalog

1. Go to <https://catalog.dataminer.services/details/a7776ac5-dfef-4242-ace0-fac33c1834d4>.

1. Click the *Deploy* button to deploy the package to your DMA

   This package contains the final solution that you can use as a guideline, the necessary DOM models and it will create some sample events to work with upon installation.

## Step 2: Create the app and the pages

1. Go to the landing page of your DataMiner, here you should see a new app called "Sport event manager" in the section "Event Planning"

1. Hover over the section name and click the icon that appears to create a new app

1. Choose a name for your app

1. Rename the current page to "Event table" and choose an appropriate icon to your choosing

1. Add a new page by clicking the "Create page" button under your current page, name this page "Timeline" and look for another fitting icon

These are the only pages that we will need for this exercise.

## Step 3: Create the GQI queries

### Full events query

1. [Create a GQI query](xref:Creating_GQI_query) called "Full Events" by using "Get object manager instances" as data source and select the "sporteventmanagement" module. From this module you can select the "Event" object manager definitions

1. Add a "Select" operator and add the "ID" column to the query

1. Add a "Apply custom operator" operator amd select the "Date comparer" operator.
Configure this operator to use "Start Time" for the "Start" parameter, and "End Time" for the "End" parameter. This operator will ad a new column called "Compared Times" to the result of your query indicating if the event is "Ongoing" or "Future"

![Full events query](~/user-guide/images/Full_events_query.png)

### Table events query

1. Now create a new GQI query called "Table Events" by selecting "Start From" to start from your previously created query

1. Use a Select operator to only include the following columns in the query:
   - Event Name
   - Priority
   - Type
   - Start Time
   - End Time
   - Tags

![Table events query](~/user-guide/images/Table_events_query.png)

## Step 4: Create the event overview page

### Add Title component

1. Drag a [web component](xref:DashboardWeb) on the page and position it in the top left corner

1. Now go to settings in the "Component" section and paste the following custom HTML

```html
<div>
   <h1>Sport <span data-y>Event</span> Manager</h1>
</div>
<style>
div {
	font-family: Segoe UI, sans-serif;
	line-height: .6;
	font-size: 16px;
	color: 464646;
	display: flex;
	align-items: end;
	height: 100%
}

p {
	margin: 0
}

[data-b] {
	color: rgb(0, 191, 239)
}

[data-y] {
	color: rgb(255, 179, 0)
}

[data-p] {
	color: rgb(255, 0, 107)
}

</style>
```

1. Under "Layout" change the theme to "Transparent"

### Add Query filter component

1. Add a [query filter component](xref:DashboardQueryFilter) to the page on the left side under the title

1. Drag the "Table events" query on the component to feed it with data

1. Now add all columns from the "Table events" query as filter to the query filter component, except for the "Priority" column

### Add Table component

1. Add a [dashboard table](xref:DashboardTable) to the page next to the query filter component

1. Add the previously created GQI query called "Table Events"

## Step 5: Enable users to add events

We want the user to be able to create new events when clicking a button on the page. To be able to achieve this we will create a button and configure to open a new panel when it is clicked. This panel will hold a form that the user can use to create new events, together with a button that will allow the user to save the event.

### Add button

1. Add a [Button](xref:DashboardButton) to the low-code app

1. Change the label under the "Layout" section to "Add event", feel free to change the icon

### Create the "New event" panel

1. Create a new panel and call it "New event"

> [!TIP]
> For more information on panels see: [Configuring a panel of a low-code app](xref:LowCodeApps_panel_config).

1. Add a [Form](xref:DashboardForm) to the panel

1. Take the "Event" definition under "Object Manager Definitions" from the Data tab and drag it onto the form

1. Enable the Header Bar and add a button called "Save"

> [!TIP]
> For more information on the header bar see: [Using a header bar](xref:Tutorial_Apps_Headerbar)

1. Select the button and open the "Events" section to configure the actions. We will configure 5 actions that will run upon completion of the previous action:
    1. Add a component action "Save current changes" on the form component
    1. Add an action to show a notification with a message indicating that the event was saved
    1. Add an action to close the panel
    1. Add an component action "Fetch the data" on the table component
    1. Add an component action "Select an item" on the table component

1. Go back to the "Event table" page

1. Select the "Add event" button and go to the "Settings" menu

1. Under "General" configure the actions so the "New event" panel is opened when the button is clicked

## Step 6: Enable users to edit events

The last thing we want to add to this page is functionality to allow the user to edit events. We will again add a new panel that will open when an event in the table is double clicked. This new panel will show an overview of the selected event and enable the user to save the changes or delete the event.

> [!WARNING]
> Make sure you select an event in the table before you continue. If you do not do this you will not be able to correctly link the selected event with the form component in the panel.

1. Select an event in the table

1. Create a new panel called "Event form"

1. Add a [Form](xref:DashboardForm) to the panel

1. Go to "Components" section in the Data tab and drag the "Object manager instances" from the "Selected rows" property from your table on to the form (you should now see the details in the form of the event you selected)

1. Add a button named "Save" in the header bar

1. Configure the following consecutive actions on the "Save" button
    1. Add a component action "Save current changes" on the form component on the "Event form" panel
    1. Add an action to show a notification with a message indicating that the changes were saved
    1. Add an action to close the panel
    1. Add a component action "Fetch the data" for the table component

1. Add a button named "Delete" in the header bar

1. Configure the following consecutive actions on the "Delete" button
    1. Add a component action "Delete instance" on the form component
    1. Add an action to close the panel
    1. Add a component action "Fetch the data" on the table component

## Step 7: Create the timeline overview page

### Add title component

1. Drag a [web component](xref:DashboardWeb) on the page and position it in the top left corner

1. Now go to settings in the "Component" section and paste the following custom HTML

```html
<div>
<h1>Timeline</h1>
</div>
<style>
div {
	font-family: Segoe UI, sans-serif;
	line-height: .6;
	font-size: 16px;
	color: 464646;
	display: flex;
	align-items: end;
	height: 100%
}

p {
	margin: 0
}

[data-b] {
	color: rgb(0, 191, 239)
}

[data-y] {
	color: rgb(255, 179, 0)
}

[data-p] {
	color: rgb(255, 0, 107)
}
</style>
```

### Add time range component

1. Add a [Time range](xref:DashboardTimeRange) component to the page
1. Under the "Settings" tab set the "Default range" to "Last and next 12 hours"
1. Under the "Layout" tab disable all presets
1. Enable the quick picks and select some that make sense to you

### Add time line component

1. Add a [Timeline](xref:DashboardTimeline) component to the page

1. Add the previously created query called "Full events" to the timeline component

1. Configure grouping on the "Type" column from the query (see [Configuring the timeline component](xref:DashboardTimeline#configuring-the-component))

1. Go to "Settings" and set the "Default time range" to "Last and next 12 hours"

### Link time range to timeline

Here we will link the time ranges from the timeline and the time range component to each other. This will make sure the timeline updates its viewport when we select a quick pick from the time range component, and that the time range updates when we pan in the timeline.

1. On the "Settings" tab from the timeline component, select the icon next to "Link time range"

1. Select the time range component to link the time ranges

1. Go to the "Data tab", under "Components" take the "Timespans" property from the "Viewport" of the timeline component and drag this onto the time range component

### Configure actions on the time line

In this section we will add support for different actions on the timeline like drag and dropping events or changing the start and endtime of an event by dragging the edges.

> [!TIP]
> For more information on how to configure events and actions on the timeline component go to [Configuring events and actions on the timeline component](xref:DashboardTimeline#configuring-events-and-actions)

> [!WARNING]
> Make sure you select an event in the timeline before you continue. If you do not do this you will not be able to select the event for the actions.

1. Select the timeline component and go to the "Settings" tab

1. Configure the actions for "On item resize"
    1. Add an action "Launch a script" and select the "Event manager - Update event" script
    1. Link the "Event ID" parameter to the ID of the selected event
        1. Link to "Event info"
        1. Type: "Current item/Tables"
        1. Property: "ID"
    1. Link the "From" parameter to the new start time of the event
        1. Link to "Event info"
        1. Type: "New/Timespans"
        1. Property: "From"
    1. Link the "Until" parameter to the new end time of the event
        1. Link to "Event info"
        1. Type: "New/Timespans"
        1. Property: "To"
    1. Add a component action "Fetch the data" on the timeline

1. Configure the actions for "On item move"
    Repeat the same steps as for the "On item resize" event.
