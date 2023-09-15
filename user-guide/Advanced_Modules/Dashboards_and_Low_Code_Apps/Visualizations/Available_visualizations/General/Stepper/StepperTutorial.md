---
uid: TutorialStepper
---

# Using the stepper component

In this tutorial, you'll learn how to add and configure a stepper component in your dashboard or low-code app. This tutorial shows the usage of the stepper component to help with creating and managing incidents and their different states.

## Overview

- [Step 1: Setting up the data](#step-1-setting-up-the-data)
- [Step 2: Creating the components](#step-2-creating-the-components)
- [Step 3: Adding the data](#step-3-adding-the-data)
- [Step 4: Adding a save action](#step-4-adding-a-save-action)
- [Step 5: Styling the stepper](#step-5-styling-the-stepper)

## Step 1: Setting up the data

Before you can begin using the stepper component, you'll need some data to visualize. To get some basic data for this tutorial, you can deploy [this package](https://catalog.dataminer.services/catalog/4383) from the catalog. The package will create an 'Incident' [DOM definition](https://docs.dataminer.services/user-guide/Advanced_Modules/DOM/DOM_objects/DomDefinition.html) and some [DOM instances](https://docs.dataminer.services/user-guide/Advanced_Modules/DOM/DOM_objects/DomInstance.html) using it.

## Step 2: Creating the components

Now that there is some data to visualize, we can create the app to do so. Start with [creating a new application](https://docs.dataminer.services/user-guide/Advanced_Modules/Dashboards_and_Low_Code_Apps/Low_Code_Apps/Creating_custom_apps.html). On the initial page of this application, you can add a stepper, a form and a table component. All of these components can be found in the side panel containing the visualizations. The stepper and form components are located under the 'General category', the table in the 'Tables' category. From there, you can just drag and drop them onto your dashboard.

![Components](~/user-guide/images/StepperComponents.png)

## Step 3: Adding the data

Data can be added to components via a [data feed](https://docs.dataminer.services/user-guide/Advanced_Modules/Dashboards_and_Low_Code_Apps/Dashboards_app/Creating_and_configuring_dashboards/Configuring_dashboard_components.html#applying-a-data-feed). Each of the components on our page has to receive some data:

- Add the DOM definition to the stepper component and the form component.
- Create a simple query to fetch all Object Manager Instances of the DOM definition.
- Link the 'Object manager instances' feed from the table component to both the stepper and the form component.

![Components with their data](~/user-guide/images/StepperData.png)

## Step 4: Adding a save action

The last step to complete our simple app is to add a header bar with a save button to save the changes to the incidents. Enable the header bar for the page and add a button to it. Then a chain of 3 actions can be added to the 'On click' event of the button:

1. Save the current changes of the form component.
1. Fetch the data in the table component.
1. Select the updated incident in the table component.

![Action configuration](~/user-guide/images/StepperActions.png)

## Step 5: Styling the stepper

Every stepper component has the same default template. You have the option to change the template using the appearance setting in the layout tab. You can pick from a list of 13 presets that we have provided.

![Appearance presets](~/user-guide/images/StepperAppearance.png)

## Using the low-code app

Now that everything is configured, the app can be published and used. New incidents can be created using the form component and the save button in the header bar. Existing incidents can be inspected and updated by selecting them in the table component at the bottom.

![Application usage](~/user-guide/images/StepperApp.gif)
