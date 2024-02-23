---
uid: Getting_started_with_basic_shapes
---
# Getting started with basic shapes

This tutorial explains how to start from a blank Visio file and edit basic element info in an efficient way through shape grouping.

Expected duration: 15 minutes

## Prerequisites

- A DataMiner System that is [connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud) that has a Microsoft Platform element.

  > [!TIP]
  > A [new DataMiner as a Service](xref:Creating_a_DMS_on_dataminer_services) system comes with a Microsoft Platform element out of the box, so it automatically meets this requirement.
- [Microsoft Visio Software](https://www.microsoft.com/microsoft-365/visio/flowchart-software)

## Overview

- [Step 1: Create a new blank Visio file for the element](#step-1-create-a-new-blank-visio-file-for-the-element)
- [Step 2: Set up an element alarm color LED shape](#step-2-set-up-an-element-alarm-color-led-shape)
- [Step 3: Show more information efficiently](#step-3-show-more-information-efficiently)
- [Step 4: Clean up the drawing](#step-4-clean-up-the-drawing)

## Step 1: Create a new blank Visio file for the element

1. Open DataMiner Cube and connect to your system.

   > [!TIP]
   > If you have created a new DaaS System for this tutorial, see [Accessing a newly created DMS for the first time](xref:Accessing_a_new_DMS) for detailed info.
1. Open your Microsoft Platform element on the Visual page.

1. Right-click the Visual page and select *Set as active \<element name> element Visio file* > *New blank*.

1. In the dialog box asking whether you want to assign a new drawing, click *Yes*.

At this point, your Microsoft Visio application should start up automatically, and you can start modifying your new Visio file.

## Step 2: Set up an element alarm color LED shape

1. Remove all shapes from your Visio page by pressing CTRL+A and then Delete.

1. In the ribbon at the top, go to the *Tools* section of the *Home* tab, and select the ellipse.

1. Draw a circle on your page by clicking and dragging the mouse on it while this tool is selected.

   ![Add ellipse to Visio page](~/user-guide/images/AddEllipseToVisioPage.gif)

1. Right-click the newly created ellipse and select *Data* > *Define Shape Data*.

1. Set the *Label* field to `Element`.

1. Set the *Value* field to the name of your element.

1. Click *OK*.

1. Save your Visio file.

In DataMiner Cube, your Visual Overview should now be updated with your changes. You should see an interactive ellipse shape that is filled with the current alarm state color.

![Basic element shape](~/user-guide/images/BasicElementShape.webp)

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

   ![Group shapes](~/user-guide/images/GroupShapes.gif)

1. Right-click the newly created shape group and select *Data* > *Define Shape Data*.

1. Add shape data with label `Element` and set its value to the name of your element.

1. Save your Visio file.

In DataMiner Cube, you should see two colored shapes, one of which displays the value of your parameter.

![Group shape result](~/user-guide/images/GroupShapeResult.webp)

## Step 4: Clean up the drawing

1. Right-click the shape group and select *Data* > *Define Shape Data*.

1. Click the *New* button to add shape data with label `Enabled` and value `false`. Setting enabled to false makes it so the shape can no longer be clicked and doesn't show a hover effect.

1. Right-click the shape group and select *Group* > *Open Group*.

1. Right-click the ellipse shape and select *Data* > *Define Shape Data*.

1. Click the *New* button to add shape data with label `Enabled` and value `true`. Overriding the enabled state from earlier in this child shape will enable just the ellipse, rather than the whole group.

1. Right-click the rectangle shape and select *Data* > *Define Shape Data*.

1. Click the *New* button to add shape data with label `Options` and value `NoAlarmColorFill`.

1. Make sure you have no shapes selected, click the "..." in the top-right corner of the Advanced Editing panel and select *Add pretty hover*. This hover effect will ensure that when you hover over the ellipse, the highlighted area will move along with the ellipse itself, instead of highlighting its bounding rectangle.

   ![Add pretty hover](~/user-guide/images/AddPrettyHover.gif)

   > [!NOTE]
   > If you followed this tutorial, the advanced editing panel should be available in your Microsoft Visio application. The panel is created when launching Microsoft Visio from DataMiner Cube (by creating a new blank Visio file or doing an edit of an existing one).

1. Save your Visio file.

In DataMiner Cube, only your ellipse will now be colored with the alarm state of the element, and only that shape will be clickable. The pretty hover will ensure that the highlighted area upon hover of the ellipse follows the ellipse rather than its bounding rectangle.

![End result](~/user-guide/images/Endresult.webp)

## Related documentation

- [Working with shape data in Microsoft Visio](xref:Working_with_shape_data_in_Microsoft_Visio)
- [Linking a shape to an element, a service or a redundancy group](xref:Linking_a_shape_to_an_element_a_service_or_a_redundancy_group)
- [Linking a shape to an element parameter](xref:Linking_a_shape_to_an_element_parameter)
- [Grouping shapes](xref:Grouping_shapes)
- [NoAlarmColorFill](xref:Overview_of_page_and_shape_options#noalarmcolorfill)
- [Disabling the default hyperlink behavior of a linked shape](xref:Disabling_the_default_hyperlink_behavior_of_a_linked_shape)
