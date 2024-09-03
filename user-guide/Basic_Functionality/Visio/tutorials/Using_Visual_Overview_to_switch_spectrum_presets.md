---
uid: Using_Visual_Overview_to_switch_spectrum_presets
---

# Using Visio Overvie to switch spectrum presets

This tutorial explains how to start from a blank Visio file and add a spectrum control and several buttons to switch between presets

Expected duration: 25 minutes

## Prerequisites

- A DataMiner System that is [connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).
- Connector: [Skyline Spectrum Simulator](https://catalog.dataminer.services/details/6f33ec9f-e83d-49d5-8f85-87ad66eaa5c7)
- [Microsoft Visio](https://www.microsoft.com/microsoft-365/visio/flowchart-software)

## Overview

- [Step 1: Create a view](#step-1-create-a-view)
- [Step 2: Create a spectrum simulation element](#step-2-create-a-spectrum-simulation-element)
- [Step 3: Add a blank Visio file to the view](#step-3-add-a-blank-visio-file-to-the-view)
- [Step 4: Add a spectrum component shape](#step-4-add-a-spectrum-component-shape)
- [Step 5: Create a preset to hide the info pane](#step-5-create-a-preset-to-hide-the-info-pane)
- [Step 6: Use the preset on the spectrum component](#step-6-use-the-preset-on-the-spectrum-component)
- [Step 7: Create presets for the measurements](#step-7-create-presets-for-the-measurements)
- [Step 8: Use session variables to link the presets to buttons](#step-8-use-session-variables-to-link-the-presets-to-buttons)
- [Step 9: Display the current selection](#step-9-display-the-current-selection)

## Step 1: Create a view

1. Open DataMiner Cube and connect to your system.

   > [!TIP]
   > If you created a new DaaS system for this tutorial, refer to [Accessing a newly created DMS for the first time](xref:Accessing_a_new_DMS) for more information.

1. Right-click the root view and select *New* > *View*

1. Give the view a name of your choice, e.g. `Visio spectrum presets`

## Step 2: Create a spectrum simulation element

1. Right-click the view you just created and select *New* > *Element*

1. Create an element using the Skyline Spectrum Simulator connector. Give the element a name of your choice, e.g. "Spectrum Simulation". Refer to [Adding elements](xref:Adding_elements) for more information.

## Step 3: Add a blank Visio file to the view

1. Open your view on the Visual page.

1. Right-click the Visual page and select *Set as active \<view name> view Visio file* > *New blank*.

1. In the *New Visio file* pop-up window, click *Yes*.

At this point, your Microsoft Visio application should start up automatically, and you can start modifying your new Visio file.

## Step 4: Add a spectrum component shape

1. Select the grey rectangle and press the delete button to remove the shape from your Visio page. The title shape can stay in place.

1. Navigate to the *Home* tab of the ribbon click the rectangle in the *Tools* section.

1. draw a large rectangle on your page by clicking and dragging the mouse on it.

1. Right-click the rectangle shape and select *Data* > *Shape Data*. By default, this will open the shape data window as a popup, but you can dock it to one of the sides in Visio as we will need it regularly when editing Visio files for use in DataMiner

1. Right click the shape data pane and select *Define Shape Data*

1. Replace the default "Property1" label with shape data label `Element` and change the value to <element name>. This is the name you used in step 2 when creating the spectrum simulation element.

1. Click the *New* button to add another shape data with label `Component` and value `Spectrum`

1. Click the OK button in the `Define Shape Data` window. This will close the window

1. Make sure you have no shapes selected

1. Save your Visio file.

In DataMiner Cube, you will now get a basic spectrum control, with all the features of the spectrum control in the element, but without the ribbon. This control will also display the info pane, which is not desired in the visual overview for our use case.

## Step 5: Create a preset to hide the info pane

1. Open the spectrum simulation element and navigate to the `Spectrum Analyzer` page if needed

1. In the `View` tab of the ribbon, click the `Info pane` button to disable the info pane

1. In the spectrum sidebar, click the `Presets` tab and click the `Manage` button at the bottom.

1. Click the `New...` button

1. Give the preset a name of your choice, e.g. `NoInfoPane`

1. Enable the `Share preset with other users` checkbox

1. Click the `OK` button

1. Click the `OK` button once more to close the Manage presets window

## Step 6: Use the preset on the spectrum component

1. In DataMiner Cube, Navigate back to the `Visio spectrum presets` view and bring Visio to the front from your taskbar. If you have closed Visio previously, you can re-open it by right-clicking in the view card and choosing `Edit in Visio`from the menu.

1. Select the rectangular shape that is linked to the spectrum componen, and in the shape data pane right-click and select `Define Shape Data`

1. Click the "New" button to add an additional shape data field

1. Change the Label to "ComponentOptions"

1. In the value, type `preset=NoInfoPane`

1. Make sure you have no shapes selected

1. Save your Visio file.

In DataMiner Cube, you will now get the same spectrum control, but the info pane is no longer displayed.

## Step 7: Create presets for the measurements

We will now create additional presets for each of the center frequencies where we want to retrieve the frequency spectrum

1. Open the spectrum simulation element and navigate to the `Spectrum Analyzer` page if needed

1. In the `Manual` tab of the spectrum sidebar, change the settings to the desired values. e.g. for a satellite signal this could be around 12GHz center frequency and 200MHz Bandwith

1. In the spectrum sidebar, click the `Presets` tab and click the `Manage` button at the bottom.

1. Click the `New...` button

1. Give the preset a name of your choice, e.g. `Satellite`

1. Enable the `Share preset with other users` checkbox

1. Click the `OK` button

1. Click the `OK` button once more to close the Manage presets window

1. Repeat the above steps for a second signal. E.g. For a cable signal, we could use a center frequency of 260 MHz and a Bandwith of 8 MHz. Give it the name `Cable`

## Step 8: Use session variables to link the presets to buttons

In this step, we will use session variables and placeholders to link buttons to the presets.

1. In DataMiner Cube, Navigate back to the `Visio spectrum presets` view and bring Visio to the front from your taskbar. If you have closed Visio previously, you can re-open it by right-clicking in the view card and choosing `Edit in Visio`from the menu.

1. Resize the shape linked to the spectrum analyzer control, to make some space for buttons

1. Create a small rectangular shape, and add the text "Switch to Satellite"

1. Add a shape data field to this shape, with Label `SetVar` and value `varPreset:Satellite (public)`. In this value, `varPreset`is the name of the session variable and `Satellite (public)` refers to the name of the spectrum preset. The (public) suffix is needed to indicate that this is a shared preset.

1. duplicate this shape and change the text and shape data so it refers to the `Cable` preset

1. In the spectrum component shape, replace the fixed preset reference by a session variable placeholder. The new value becomes `preset=[var:varPreset]`

1. Make sure you have no shapes selected

1. Save your Visio file.

1. Click the buttons and verify that the presets are correctly changed.

## Step 9: Display the current selection

1. Add a number of images in the visio file that represent the setup in your system. You can for example use the [Skylicons](https://skyline.be/skylicons)

1. Draw lines that represent the connections between the components. To enhance the visualization, you can use a different line color for the connections to the image that represents the spectrum analyzer.

1. On the lines connected to the spectrum analyzer, add a shape data with label `Show` and value `<A>-A|Value|[var:varPreset]|=Satellite (public)` for the connection to the satellite dish. Refer to [Extended conditional shape manipulation actions](xref:Extended_conditional_shape_manipulation_actions) for more information on the show condition format

1. Add a shape data with label `Show` and value `<A>-A|Value|[var:varPreset]|=Cable (public)` for the connection to the cable

1. Make sure you have no shapes selected

1. Save your Visio file.

1. Click the buttons and verify that the lines are correctly shown or hidden.

## Related documentation

- [Working with shape data in Microsoft Visio](xref:Working_with_shape_data_in_Microsoft_Visio)

- [Embedding a Spectrum Analysis component](xref:Embedding_a_Spectrum_Analysis_component)

- [Using Spectrum Analysis presets](xref:Using_Spectrum_Analysis_presets)

- [Turning a shape into a control to update a session variable](xref:Turning_a_shape_into_a_control_to_update_a_session_variable)

- [Placeholders for variables in shape data values](xref:Placeholders_for_variables_in_shape_data_values)

- [Extended conditional shape manipulation actions](xref:Extended_conditional_shape_manipulation_actions)
