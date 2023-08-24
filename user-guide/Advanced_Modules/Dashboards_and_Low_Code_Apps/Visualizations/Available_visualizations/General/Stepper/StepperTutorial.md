---
uid: TutorialStepper
---

# Using the stepper component

In this tutorial, you'll learn how to add and configure a stepper component in your dashboard or low-code app.

## Overview

- [Step 1: Adding the component](#step-1-adding-the-component)
- [Step 2: Adding the data](#step-2-adding-the-data)
- [Step 3: Choosing a template](#step-3-choosing-a-template)

## Step 1: Adding the component

The first step is adding the component to your dashboard or low-code app. In the side panel containing all the visualizations, you'll find the stepper under the 'General' category. From there, you can just drag and drop it onto your dashboard.

![Stepper icon](~/user-guide/images/StepperIcon.png)

## Step 2: Adding the data

Data can be added to the component via a [data feed](https://docs.dataminer.services/user-guide/Advanced_Modules/Dashboards_and_Low_Code_Apps/Dashboards_app/Creating_and_configuring_dashboards/Configuring_dashboard_components.html#applying-a-data-feed). The component can receive 2 types of data: a stateful DOM definition (only in low-code apps) or a stateful DOM instance.

In case of a DOM definition, the component shows the happy path of the definition. This is the sequence of states an instance of that definition passes through when it follows the normal flow.

In case of a DOM instance, the component shows the history of states the instance has already been in and, if necessary, supplements this with the rest of the happy path based on the current state. This happy path can be different from the happy path of the definition, as it starts from the current state of the instance and not the initial state of the definition.

## Step 3: Choosing a template

Every stepper component has the same default template.

![Default style](~/user-guide/images/StepperDefaultStyle.png)

You have the option to change the template using the appearance setting in the layout tab. You can pick from a list of 13 presets.
![Default style](~/user-guide/images/StepperAppearanceCollapsed.png)

![Default style](~/user-guide/images/StepperAppearance.png)

![Default style](~/user-guide/images/StepperArrowStyle.png)
