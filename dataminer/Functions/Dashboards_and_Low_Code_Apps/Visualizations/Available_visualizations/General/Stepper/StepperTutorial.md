---
uid: TutorialStepper
---

# Using the stepper component in a low-code app

In this tutorial, you will learn how to add and configure a stepper component in a low-code app, by means of an example where the stepper component is used to help with managing incidents and their different states.

The content and screenshots for this tutorial have been created in DataMiner version 10.3.10.

## Overview

- [Step 1: Set up the data](#step-1-set-up-the-data)
- [Step 2: Create the components](#step-2-create-the-components)
- [Step 3: Add the data](#step-3-add-the-data)
- [Step 4: Add a save action](#step-4-add-a-save-action)
- [Step 5: Style the stepper](#step-5-style-the-stepper)
- [Step 6: Use the low-code app](#step-6-use-the-low-code-app)

## Step 1: Set up the data

Before you can begin to create the app, you will need to add some data to your system that you can visualize in the app. To do so, deploy the [Incident Manager package](https://catalog.dataminer.services/catalog/4383) from the catalog.

The package will create an "Incident" [DOM definition](xref:DomDefinition) and some [DOM instances](xref:DomInstance) using it.

> [!TIP]
> For information on how to deploy a package, see [Deploying a Catalog item](xref:Deploying_a_catalog_item).

## Step 2: Create the components

Now that you have deployed the package with the data, you can create the app to visualize this data.

1. [Create a new application](xref:Creating_custom_apps).

1. Click the pencil icon next to the initial page of the application in order to edit it.

1. Hover the mouse pointer over the bar with the "+" on the left until it expands to show the Visualizations pane, and add a [stepper](xref:DashboardStepper), a [form](xref:DashboardForm), and a [table](xref:DashboardTable) component by dragging them onto the page.

   You can find the stepper and form components in the *General* category and the table in the *Tables* category.

The end result of this step should look like this:

![Components](~/dataminer/images/StepperComponents.png)

## Step 3: Add the data

[Add data to the components](xref:Adding_data_to_component).

Each of the components on the page has to receive some data:

- Add the DOM definition to the stepper component and the form component.

  ![Definition data](~/dataminer/images/StepperDefinitionData.png)

- Create a query to fetch all object manager instances of the DOM definition and add it to the table component. See [Creating a GQI query](xref:Creating_GQI_query).

  ![Incidents query](~/dataminer/images/StepperQuery.png)

- Link the *Object manager instances* data from the table component to both the stepper and the form component. Make sure to select a row in the table to expose this data.

  ![Instance data](~/dataminer/images/StepperInstanceData.png)

## Step 4: Add a save action

To complete the app, you should now add a header bar with a button to save changes to incidents:

1. Enable the header bar and add a button to it. See [Configuring the app header bar](xref:LowCodeApps_header_config).

1. Add a chain of the following three actions to the *On click* event of the button:

   1. Save the current changes of the form component.

   1. Fetch the data in the table component.

   1. Select the updated incident in the table component.

   ![Action configuration](~/dataminer/images/StepperActions.png)

## Step 5: Style the stepper

By default, every stepper component uses the same template, but you can switch to a different template of your choice.

To do so, use the *Appearance* setting in the component *Layout* pane on the right.

![Appearance presets](~/dataminer/images/StepperAppearance.png)

## Step 6: Use the low-code app

Now that everything is configured, you can publish and use your app.

You can create new incidents using the form component and the save button in the header bar. You can inspect and update existing incidents by selecting them in the table component at the bottom.

The stepper component will visualize the past states and the possible future states of an incident. This visualization will clearly show what steps were taken to resolve the incident and what steps still need to happen before it is fully resolved.

![Application usage](~/dataminer/images/StepperApp.gif)
