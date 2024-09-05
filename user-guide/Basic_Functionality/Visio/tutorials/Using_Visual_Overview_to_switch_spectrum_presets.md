---
uid: Using_Visual_Overview_to_switch_spectrum_presets
---

# Using Visual Overview to switch spectrum presets

This tutorial explains how to start from a blank Visio file and add a spectrum control and several buttons to switch between presets.

Expected duration: 25 minutes

## Prerequisites

- A DataMiner System that is [connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud) and where the connector  [Skyline Spectrum Simulator](https://catalog.dataminer.services/details/6f33ec9f-e83d-49d5-8f85-87ad66eaa5c7) has been deployed.
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
   > If have you created a new DaaS system for this tutorial, refer to [Accessing a newly created DMS for the first time](xref:Accessing_a_new_DMS) for more information.

1. Right-click the root view and select *New* > *View*.

1. Give the view a name of your choice, e.g. `Visio spectrum presets`.

## Step 2: Create a spectrum simulation element

1. Right-click the view you have just created and select *New* > *Element*.

1. Configure the new element as follows:

   - *Name*: Enter a name of your choice e.g. `Spectrum Simulation`.
   - *Protocol*: *Skyline Spectrum Simulator*.

1. Click *Create*.

> [!TIP]
> See also: [Adding elements](xref:Adding_elements)

## Step 3: Add a blank Visio file to the view

1. Open the new view on the *Visual* page.

1. Right-click the *Visual* page, and select *Set as active Visio file* > *New blank*.

   ![Assign a blank Visio file](~/user-guide/images/Tutorial_VO_spectrum_blank_Visio.png)

1. In the *New Visio file* pop-up window, click *Yes*.

At this point, your Microsoft Visio application should start up automatically, and you can start modifying your new Visio file.

## Step 4: Add a spectrum component shape

1. In the Visio drawing, select the grey rectangle and press Delete to remove the shape from the page.

   You can leave the title shape in place.

1. In the *Home* tab of the ribbon, click the rectangle in the *Tools* section.

1. Draw a large rectangle on your page by clicking and dragging the mouse on it.

1. If the shape data pane is not yet open, right-click the rectangle shape and select *Data* > *Shape Data*.

   By default, this will open the shape data pane as a pop-up window, but you can dock it to one of the sides of the Visio UI instead. This will be handy, as you will need this pane often when editing Visio files for use in DataMiner.

1. Right-click the shape data pane and select *Define Shape Data*.

1. In the pop-up window, replace the default "Property1" label with the shape data label `Element` and change the value to the name of the spectrum simulation element you created earlier.

   <!-- Add screenshot of window -->

1. Click the *New* button to add another shape data field with label `Component` and value `Spectrum`.

   <!-- Add screenshot of window -->

1. Click *OK* to close the *Define Shape Data* window.

1. Make sure no more shapes are selected.

1. Save the Visio file.

1. Check the *Visual* page in DataMiner Cube.

The page should now contain a basic spectrum control, with all the features of the spectrum control in the element, but without the ribbon. This control will also display the info pane. In the next step, you will learn how you can keep this from being shown.

## Step 5: Create a preset to hide the info pane

1. In DataMiner Cube, navigate to the *Spectrum Analyzer* data page of your spectrum simulation element.

1. In the *View* tab of the ribbon, click the *Info pane* button to hide the info pane.

1. In the spectrum sidebar on the right, select the *Presets* tab and click the *Manage* button at the bottom.

1. Click the *New* button.

1. Configure the preset:

   - Give the preset the name `NoInfoPane`.

   - Select the *Share preset with other users* checkbox.

   - Click *OK*.

   <!-- Add screenshot of preset configuration before you click OK -->

1. Click *OK* again to close the *Manage presets* pane.

## Step 6: Use the preset on the spectrum component

1. In DataMiner Cube, navigate back to the *Visio spectrum presets* view.

1. Go back to the Visio file you were working on earlier.

   If you have already closed the Visio file, re-open it by right-clicking the *Visual* page on the view card and selecting *Edit in Visio*.

1. Select the rectangular shape that you linked to the spectrum component.

1. Right-click the shape data pane and select *Define Shape Data*.

1. Click *New* to add another shape data field.

1. Configure the new shape data field with the label `ComponentOptions` and the value `preset=NoInfoPane`, and click *OK*.

1. Make sure no more shapes are selected.

1. Save the Visio file.

1. Check the *Visual* page in DataMiner Cube.

You will see that in DataMiner Cube, the spectrum control no longer includes the info pane.

## Step 7: Create presets for the measurements

In this step, you will create additional presets for each of the center frequencies from which the frequency spectrum should be retrieved.

1. In DataMiner Cube, navigate to the *Spectrum Analyzer* data page of your spectrum simulation element.

1. In the *Manual* tab of the spectrum sidebar, change the settings to the desired values. e.g. for a satellite signal this could be around 12GHz center frequency and 200MHz bandwidth.

   <!-- Add screenshot of configuration -->

1. In the spectrum sidebar, select the *Presets* tab and click the *Manage* button at the bottom.

1. Click the *New* button.

1. Configure the preset:

   - Give the preset the name `Satellite`.

   - Select the *Share preset with other users* checkbox.

   - Click *OK*.

   <!-- Add screenshot of preset configuration before you click OK -->

1. Click *OK* again to close the *Manage presets* pane.

1. Repeat the steps above for a second signal. E.g. For a cable signal, we could use a center frequency of 260 MHz and a Bandwidth of 8 MHz. Give it the name `Cable`.

   <!-- Add screenshot of configuration -->

## Step 8: Use session variables to link the presets to buttons

In this step, you will use session variables and placeholders to link buttons to the presets.

1. In DataMiner Cube, navigate back to the *Visio spectrum presets* view.

1. Go back to the Visio file you were working on earlier.

   If you have already closed the Visio file, re-open it by right-clicking the *Visual* page on the view card and selecting *Edit in Visio*.

1. Resize the shape linked to the spectrum analyzer control to make room for buttons.

   <!-- Add screenshot of Visio page with resized control -->

1. Create a small rectangular shape, and add the text `Switch to Satellite` in the shape.

1. Add a shape data field to this shape, with label `SetVar` and value `varPreset:Satellite (public)`.

   In this value, `varPreset` is the name of the session variable, and `Satellite (public)` refers to the name of the spectrum preset. The (public) suffix is needed to indicate that this is a shared preset.

   <!-- Add screenshot with the new shape selected so that the configured shape data are visible -->

1. Duplicate this shape and change the text and shape data so it refers to the `Cable` preset.

   <!-- Add screenshot with the new shape selected so that the configured shape data are visible -->

1. In the spectrum component shape, replace the fixed preset reference by a session variable placeholder. The new value becomes `preset=[var:varPreset]`

1. Make sure no more shapes are selected.

1. Save the Visio file.

1. On the *Visual* page in DataMiner Cube, click the buttons and verify whether the presets are correctly changed.

## Step 9: Display the current selection

1. Add a number of images in the Visio file that represent the setup in your system. You can for example use the [Skylicons](https://skyline.be/skylicons)

   <!-- Add screenshot of example Visio drawing with added images -->

1. Draw lines that represent the connections between the components. To enhance the visualization, you can use a different line color for the connections to the image that represents the spectrum analyzer.

1. On the lines connected to the spectrum analyzer, add a shape data with label `Show` and value `<A>-A|Value|[var:varPreset]|=Satellite (public)` for the connection to the satellite dish.

   > [!TIP]
   > For more information on the *Show* condition format, see [Extended conditional shape manipulation actions](xref:Extended_conditional_shape_manipulation_actions).

1. Add a shape data field with label `Show` and value `<A>-A|Value|[var:varPreset]|=Cable (public)` for the connection to the cable.

   <!-- Add screenshot of the selected connection and the configured shape data -->

1. Make sure no more shapes are selected.

1. Save the Visio file.

1. On the *Visual* page in DataMiner Cube, click the buttons and verify whether the lines are correctly shown or hidden.

## Related documentation

- [Working with shape data in Microsoft Visio](xref:Working_with_shape_data_in_Microsoft_Visio)

- [Embedding a Spectrum Analysis component](xref:Embedding_a_Spectrum_Analysis_component)

- [Using Spectrum Analysis presets](xref:Using_Spectrum_Analysis_presets)

- [Turning a shape into a control to update a session variable](xref:Turning_a_shape_into_a_control_to_update_a_session_variable)

- [Placeholders for variables in shape data values](xref:Placeholders_for_variables_in_shape_data_values)

- [Extended conditional shape manipulation actions](xref:Extended_conditional_shape_manipulation_actions)
