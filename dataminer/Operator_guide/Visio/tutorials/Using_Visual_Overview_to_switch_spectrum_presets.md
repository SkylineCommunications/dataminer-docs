---
uid: Using_Visual_Overview_to_switch_spectrum_presets
---

# Using Visual Overview to switch spectrum presets

This tutorial explains how to start from a blank Visio file and add a spectrum control and several buttons to switch between presets. As an example, a configuration will be used that represents a cable operator headend, where a channel is received from satellite, processed, and then transmitted over the cable network. In practice, this can be used for any processing chain of HF signals or to do measurements on different locations in the network.

Expected duration: 25 minutes

## Prerequisites

- A DataMiner System that is [connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud) and where the connector  [Skyline Spectrum Simulator](https://catalog.dataminer.services/details/6f33ec9f-e83d-49d5-8f85-87ad66eaa5c7) has been deployed.
- [Microsoft Visio](https://www.microsoft.com/microsoft-365/visio/flowchart-software)

> [!NOTE]
> The content and screenshots for this tutorial were created using DataMiner version 10.4.10 and Microsoft Visio Standard 2016. If you use different software versions, you may encounter some differences.

> [!TIP]
>
> - See also: [Kata #40: Create a visual workflow for the spectrum analyzer](https://community.dataminer.services/courses/kata-40/) on DataMiner Dojo ![Video](~/dataminer/images/video_Duo.png)
> - For more information about the capabilities of the Skyline Spectrum Simulator connector, refer to the connector documentation [Skyline Spectrum Simulation](https://docs.dataminer.services/connector/doc/Skyline_Spectrum_Simulation.html) and the KATA video [Kata #32: Using the spectrum analyzer](https://community.dataminer.services/courses/kata-32/).

## Overview

- [Step 1: Create a view](#step-1-create-a-view)
- [Step 2: Create a spectrum simulation element](#step-2-create-a-spectrum-simulation-element)
- [Step 3: Add a blank Visio file to the view](#step-3-add-a-blank-visio-file-to-the-view)
- [Step 4: Add a spectrum component shape](#step-4-add-a-spectrum-component-shape)
- [Step 5: Create a preset to hide the info pane](#step-5-create-a-preset-to-hide-the-info-pane)
- [Step 6: Use the preset on the spectrum component](#step-6-use-the-preset-on-the-spectrum-component)
- [Step 7: Create presets for the measurements](#step-7-create-presets-for-the-measurements)
- [Step 8: Use session variables to link the presets to buttons](#step-8-use-session-variables-to-link-the-presets-to-buttons)
- [Step 9: Draw a graphic representation of the setup](#step-9-draw-a-graphic-representation-of-the-setup)
- [Step 10: Show only the current selection](#step-10-show-only-the-current-selection)

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

   ![Assign a blank Visio file](~/dataminer/images/Tutorial_VO_spectrum_blank_Visio.png)

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

1. In the pop-up window, set the *Label* field to `Element` and the *Value* field to the name of the spectrum simulation element you created earlier, e.g. `Spectrum Simulation`.

   ![Add element shape data](~/dataminer/images/Tutorial_VO_spectrum_element_shape_data.png)

1. Click the *New* button to add another shape data field with label `Component` and value `Spectrum`.

   ![Add component shape data](~/dataminer/images/Tutorial_VO_spectrum_component_shape_data.png)

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

   ![Create the NoInfoPane preset](~/dataminer/images/Tutorial_VO_spectrum_no_info_pane_preset.png)

1. Click *OK* again to close the *Manage presets* pane.

## Step 6: Use the preset on the spectrum component

1. In DataMiner Cube, navigate back to the *Visio spectrum presets* view.

1. Go back to the Visio file you were working on earlier.

   If you have already closed the Visio file, re-open it by right-clicking the *Visual* page on the view card and selecting *Edit in Visio*.

1. Select the rectangular shape that you linked to the spectrum component.

1. Right-click the shape data pane and select *Define Shape Data*.

1. Click *New* to add another shape data field.

1. Configure the new shape data field with the label `ComponentOptions` and the value `preset=NoInfoPane (public)`, and click *OK*.

   The `(public)` suffix is needed to indicate that this is a shared preset.

1. Make sure no more shapes are selected.

1. Save the Visio file.

1. Check the *Visual* page in DataMiner Cube.

You will see that in DataMiner Cube, the spectrum control no longer includes the info pane.

## Step 7: Create presets for the measurements

In this step, you will create additional presets for each of the center frequencies from which the frequency spectrum should be retrieved.

1. In DataMiner Cube, navigate to the *Spectrum Analyzer* data page of your spectrum simulation element.

1. In the *Manual* tab of the spectrum sidebar, change the settings to the desired values. e.g. for a satellite signal this could be a 12GHz center frequency and a 800MHz frequency span. For this tutorial, you can leave the other settings as they are.

   - *Center frequency* `12` `GHz`.
   - *Frequency Span* `800` `MHz`.

   ![Settings for the Satellite preset](~/dataminer/images/Tutorial_VO_spectrum_satellite_preset.png)

1. In the spectrum sidebar, select the *Presets* tab and click the *Manage* button at the bottom.

1. Click the *New* button.

1. Configure the preset:

   - Give the preset the name `Satellite`.

   - Select the *Share preset with other users* checkbox.

   - Click *OK*.

   ![Saving the Satellite preset](~/dataminer/images/Tutorial_VO_spectrum_save_satellite_preset.png)

1. Click *OK* again to close the *Manage presets* pane.

1. Repeat the steps above for a second signal. E.g. For a cable signal, we could use a center frequency of 260 MHz and a frequency span of 12 MHz. Give it the name `Cable`.

   - *Center frequency* `260` `MHz`.
   - *Frequency Span* `12` `MHz`.

   ![Settings for the Cable preset](~/dataminer/images/Tutorial_VO_spectrum_cable_preset.png)

## Step 8: Use session variables to link the presets to buttons

In this step, you will use session variables and placeholders to link buttons to the presets.
Session variables are small pieces of data that are kept in DataMiner Cube memory for as long as the Cube session is active.

1. In DataMiner Cube, navigate back to the *Visio spectrum presets* view.

1. Go back to the Visio file you were working on earlier.

   If you have already closed the Visio file, re-open it by right-clicking the *Visual* page on the view card and selecting *Edit in Visio*.

1. Resize the shape linked to the spectrum analyzer control to make room for buttons.

   ![Resize the spectrum component](~/dataminer/images/Tutorial_VO_spectrum_resized_component.png)

1. Create a small rectangular shape, and add the text `Switch to Satellite` in the shape.

1. Add a shape data field to this shape, with label `SetVar` and value `varPreset:Satellite (public)`.

   In this value, `varPreset` is the name of the session variable, and `Satellite (public)` refers to the name of the spectrum preset. The ` (public)` suffix is needed to indicate that this is a shared preset.

   ![Create the switch to satellite button](~/dataminer/images/Tutorial_VO_spectrum_satellite_button.png)

1. Duplicate this shape by using copy/paste and change the text and shape data of the copy so it refers to the `Cable` preset.

   ![Create the switch to cable button](~/dataminer/images/Tutorial_VO_spectrum_cable_button.png)

1. In the spectrum component shape, replace the fixed preset reference by a session variable placeholder:

   1. Select the spectrum component shape.

   1. In the (docked) shape data window, replace the value for the *ComponentOptions* label. Instead of `preset=NoInfoPane (public)` to link to a fixed preset, specify `preset=[var:varPreset]`.

      The value between square brackets is a placeholder and will be replaced by the value it refers to. `var:`indicates that the placeholder should be replaced with the value of a session variable; `varPreset` indicates the name of the session variable.

   > [!TIP]
   > For more information on the use of placeholders in shape data, see [Placeholders for variables in shape data values](xref:Placeholders_for_variables_in_shape_data_values)

1. Make sure no more shapes are selected.

1. Save the Visio file.

1. On the *Visual* page in DataMiner Cube, click the buttons and verify whether the presets are correctly changed.

   It may take a few seconds before the presets are fully switched.

## Step 9: Draw a graphic representation of the setup

1. Add a number of images in the Visio file that represent the setup in your system.

   > [!TIP]
   > To quickly get suitable images, you can use the [Skylicons](https://skyline.be/skylicons). In the example below, the dual-color versions of the cable, dish, monitor, spectrum, and stacked devices skylicons were used.

   - To add images, you can drag them from a location on your computer where you stored the images and drop them onto the Visio drawing.

   - You can also add images by selecting the *Insert* tab in the Visio ribbon, and then selecting *Pictures*. You can then navigate to the images you want to add and select them.

1. Draw lines that represent the connections between the components:

   1. In the *Home* tab of the ribbon, click the downward arrow next to the rectangle in the *Tools* section, and select *Line* instead.

   1. Drag lines between the shapes to make it look as if they are connected.

1. To enhance the visualization, change the line color for the connections to the image that represents the spectrum analyzer:

   1. In the *Home* tab of the ribbon, select the *Pointer Tool* in the *Tools* section.

   1. Select the line for which you want to change the color or thickness.

   1. In the *Shape Styles* section of the *Home* tab, click the *Line* dropdown, and select the color you want to use.

   1. If you want to also change the thickness of the line, open the *Line* dropdown again, go to *Weight*, and select the thickness you want to apply.

![Add images and connectors to visualize the switching](~/dataminer/images/Tutorial_VO_spectrum_images_added.png)

## Step 10: Show only the current selection

To indicate which point of the setup is currently measured, you will now configure one of the lines to be hidden depending on the button that was last clicked.

1. Select the line between the satellite dish image and the spectrum analyzer image and define a shape data field with label `Show` and value `<A>-A|Value|[var:varPreset]|=Satellite (public)`.

   > [!TIP]
   > For more information on the *Show* condition format, see [Extended conditional shape manipulation actions](xref:Extended_conditional_shape_manipulation_actions).

1. Add a shape data field with label `Show` and value `<A>-A|Value|[var:varPreset]|=Cable (public)` for the connection line between the spectrum analyzer and the cable image.

   ![Add Show shape data with condition](~/dataminer/images/Tutorial_VO_spectrum_show_cable_connector.png)

1. Make sure no more shapes are selected.

1. Save the Visio file.

1. On the *Visual* page in DataMiner Cube, click the buttons and verify whether the lines are correctly shown or hidden when the presets are switched.

## Related documentation

- [Working with shape data in Microsoft Visio](xref:Working_with_shape_data_in_Microsoft_Visio)

- [Embedding a Spectrum Analysis component](xref:Embedding_a_Spectrum_Analysis_component)

- [Using Spectrum Analysis presets](xref:Using_Spectrum_Analysis_presets)

- [Turning a shape into a control to update a session variable](xref:Turning_a_shape_into_a_control_to_update_a_session_variable)

- [Placeholders for variables in shape data values](xref:Placeholders_for_variables_in_shape_data_values)

- [Extended conditional shape manipulation actions](xref:Extended_conditional_shape_manipulation_actions)
