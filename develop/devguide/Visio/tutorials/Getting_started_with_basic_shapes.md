---
uid: Getting_started_with_basic_shapes
---

# Getting started with basic shapes

This tutorial explains how to start from a blank Visio file and edit basic element info in an efficient way through shape grouping.

Expected duration: 15 minutes

> [!TIP]
> See also: [Kata #21: Visual Overview design basics](https://community.dataminer.services/courses/kata-21/) on DataMiner Dojo ![Video](~/dataminer/images/video_Duo.png)

## Prerequisites

- A DataMiner System that is [connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud) that has a Microsoft Platform element.

  > [!TIP]
  > A [new DataMiner as a Service](xref:Creating_a_DMS_on_dataminer_services) system comes with a Microsoft Platform element out of the box, so it automatically meets this requirement.

- [Microsoft Visio](https://www.microsoft.com/microsoft-365/visio/flowchart-software)

## Overview

- [Step 1: Create a new blank Visio file for the element](#step-1-create-a-new-blank-visio-file-for-the-element)
- [Step 2: Set up an element alarm color LED shape](#step-2-set-up-an-element-alarm-color-led-shape)
- [Step 3: Show more information efficiently](#step-3-show-more-information-efficiently)
- [Step 4: Clean up the drawing](#step-4-clean-up-the-drawing)

## Step 1: Create a new blank Visio file for the element

1. Open DataMiner Cube and connect to your system.

   > [!TIP]
   > If you created a new DaaS system for this tutorial, refer to [Accessing a newly created DMS for the first time](xref:Accessing_a_new_DMS) for more information.

1. Open your Microsoft Platform element on the Visual page.

1. Right-click the Visual page and select *Set as active \<element name> element Visio file* > *New blank*.

1. In the *New Visio file* pop-up window, click *Yes*.

At this point, your Microsoft Visio application should start up automatically, and you can start modifying your new Visio file.

## Step 2: Set up an element alarm color LED shape

1. Press Ctrl+A followed by the delete button to remove all shapes from your Visio page.

1. Navigate to the *Home* tab of the ribbon and select the downward arrow next to the rectangle in the *Tools* section.

1. Select *Ellipse* from the dropdown list, and draw a circle on your page by clicking and dragging the mouse on it.

   ![Add ellipse to Visio page](~/dataminer/images/AddEllipseToVisioPage.gif)

1. Right-click the newly created ellipse and select *Data* > *Define Shape Data*.

1. Set the *Label* field to `Element`.

1. Set the *Value* field to the name of your element.

1. Click *OK*.

1. Save your Visio file.

In DataMiner Cube, your Visual Overview should now be updated with your changes. You should see an interactive ellipse shape that is filled with the current alarm state color.

![Basic element shape](~/dataminer/images/BasicElementShape.webp)

## Step 3: Show more information efficiently

1. In the *Tools* section of the *Home* tab of the ribbon, select the rectangle.

1. Draw a rectangle on your page by clicking and dragging the mouse on it while this tool is selected.

1. Right-click the newly created rectangle and select *Data* > *Define Shape Data*.

1. Set the *Label* field to `Parameter`.

1. Set the *Value* field to `350`.

   This is the parameter ID of the *Total Processor Load* parameter.

1. Click *OK*.

1. Double-click the rectangle shape and enter the shape text `*`.

1. Right-click the ellipse and select *Shape Data* to open the *Shape Data* panel.

1. In the *Shape Data* panel, set the value of the "Element" shape data to "*".

1. In the *Tools* section of the *Home* tab of the ribbon, select *Pointer Tool*.

1. Select both shapes on your page, right-click and select *Group* > *Group*.

   ![Group shapes](~/dataminer/images/GroupShapes.gif)

1. Right-click the newly created shape group and select *Data* > *Define Shape Data*.

1. Add shape data with label `Element` and set its value to the name of your element.

1. Save your Visio file.

In DataMiner Cube, you should see two colored shapes, one of which displays the value of your parameter.

![Group shape result](~/dataminer/images/GroupShapeResult.webp)

## Step 4: Clean up the drawing

1. Right-click the shape group and select *Data* > *Define Shape Data*.

1. Click the *New* button to add shape data with label `Enabled` and value `false`, preventing the shape from being clicked and disabling the hover effect.

1. Right-click the shape group and select *Group* > *Open Group*.

1. Right-click the ellipse shape and select *Data* > *Define Shape Data*.

1. Click the *New* button to add shape data with label `Enabled` and value `true`. This will override the earlier configured `Enabled` state for this child shape, enabling only the ellipse rather than the whole group.

1. Right-click the rectangle shape and select *Data* > *Define Shape Data*.

1. Click the *New* button to add shape data with label `Options` and value `NoAlarmColorFill`.

1. Make sure you have no shapes selected, click the "..." in the top-right corner of the *Advanced Editing* panel and select *Add pretty hover*.

   > [!NOTE]
   > If you followed this tutorial, you should see the *Advanced Editing* in your Microsoft Visio application. The panel is created when you launch Microsoft Visio from DataMiner Cube by either creating a new blank Visio file or editing an existing one.

   This hover effect ensures that when you hover the mouse pointer over the ellipse, the highlighted area moves with the ellipse, not its outer rectangle.

   ![Add pretty hover](~/dataminer/images/AddPrettyHover.gif)

1. Save your Visio file.

In DataMiner Cube, only your ellipse will now be colored with the alarm state of the element, and only that shape will be clickable. The *pretty hover* option will ensure that the highlighted area of the ellipse moves with the ellipse, not its outer rectangle.

![End result](~/dataminer/images/Endresult.webp)

## Related documentation

- [Working with shape data in Microsoft Visio](xref:Working_with_shape_data_in_Microsoft_Visio)

- [Linking a shape to an element, a service or a redundancy group](xref:Linking_a_shape_to_an_element_a_service_or_a_redundancy_group)

- [Linking a shape to an element parameter](xref:Linking_a_shape_to_an_element_parameter)

- [Grouping shapes](xref:Grouping_shapes)

- [NoAlarmColorFill](xref:Overview_of_page_and_shape_options#noalarmcolorfill)

- [Disabling the default hyperlink behavior of a linked shape](xref:Disabling_the_default_hyperlink_behavior_of_a_linked_shape)
