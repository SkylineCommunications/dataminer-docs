---
uid: Getting_started_with_basic_shapes
---
# Getting started with basic shapes

This tutorial explains how to start from a blank Visio file and edit basic element info in an efficient way through shape grouping.

Expected duration: 15 minutes

## Prerequisites

- A DataMiner System that is [connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud) that has a Microsoft Platform element. 

 > [!TIP]
  > A [new DataMiner as a Service](xref:Creating_a_DMS_on_dataminer_services) system comes with a Microsoft Platform element out of the box! 

## Overview

- [Step 1: Create a new blank Visio file for the element](#step-1-create-a-new-blank-visio-file-for-the-element)
- [Step 2: Set up an element alarm color LED shape](#step-2-set-up-an-element-alarm-color-led-shape)
- [Step 3: Showing more information efficiently](#step-3-showing-more-information-efficiently)
- [Step 4: Cleaning it up](#step-4-cleaning-it-up)

## Step 1: Create a new blank Visio file for the element

1. Launch DataMiner Cube and connect to your system.

 > [!TIP]
  > When working with DaaS, learn how to launch the desktop app and automatically connect in our [DaaS help section](xref:Accessing_a_new_DMS).

2. Open your Microsoft Platform Element on the Visual page.

2. Right click in the Visual Overview and navigate to "Set as active \<element name> element Visio file" > "New blank". 

> [!NOTE]
> Alternatively, you can go through the element card's "hamburger" menu in the top left of the card and follow the "Visual Overview" menu item.

4. Click "Yes" when prompted whether or not you want to assign a new drawing.

At this point your Microsoft Visio application should start up automatically and we can start modifying our new Visio file.

## Step 2: Set up an element alarm color LED shape

1. Remove all shapes from your Visio page by pressing CTRL+A and then the delete button.

1. Choose the ellipse from the Tools section of the Home ribbon and draw a circle on your page by clicking and dragging your mouse on it.

![Add ellipse to Visio page](~/user-guide/images/AddEllipseToVisioPage.gif)

3. Right click your newly created ellipse and navigate to "Data" > "Define Shape Data..."

3. Set the "Label" field to "Element".

3. Set its "Value" to the name of your element.

3. Click OK.

3. Save your Visio file.

In DataMiner Cube, your Visual Overview should now update with your changes. You should see an interactive ellipse shape that is filled with the current alarm state color.

![Basic element shape](~/user-guide/images/BasicElementShape.webp)

## Step 3: Showing more information efficiently

1. Choose the rectangle from the Tools section of the Home ribbon and draw a rectangle on your page by clicking and dragging your mouse on it.

1. Right click your newly created rectangle and navigate to "Data" > "Define Shape Data..."

1. Set the "Label" field to "Parameter"

1. Set its "Value" to "350" (the parameter ID of the total processor load parameter).

1. Click OK.

1. Set the shape text to "*".

1. Right click the ellipse and select "Shape Data".

1. In the Shape Data panel, set the value of the "Element" shape data to "*".

1. Select both shapes on your page, right click and select "Group".

![Group shapes](~/user-guide/images/GroupShapes.gif)

10. Right click the newly created group shape and navigate to "Data" > "Define Shape Data...".

10. Add Shape Data with Label "Element" and set its Value to the name of your element.

10. Save your Visio file.

In DataMiner Cube, you should see 2 colored shapes, one of which displays the value of your parameter.

![Group shape result](~/user-guide/images/GroupShapeResult.webp)

## Step 4: Cleaning it up

1. Right click the group shape and navigate to "Data" > "Define Shape Data...".

1. Click the "New" button to add Shape Data with Label "Enabled" and set its Value to "false". Setting enabled to false makes it so the shape can no longer be clicked and doesn't show a hover effect.

1. Right click the group shape and navigate to "Group" > "Open Group".

1. Right click the ellipse shape and navigate to "Data" > "Define Shape Data...".

1. Click the "New" button to add Shape Data with Label "Enabled" and set its Value to "true". Overriding the enabled state from earlier in this child shape will enable just the ellipse, rather than the whole group.

1. Right click the rectangle shape and navigate to "Data" > "Define Shape Data...".

1. Click the "New" button to add Shape Data with Label "Options" and set its Value to "NoAlarmColorFill".

1. Make sure you have no shapes selected. Click the "..." in the top right of the advanced editing panel and select "Add pretty hover". This hover effect will ensure that when you hover over the ellipse, the highlighted area will move along with the ellipse itself, instead of highlighting its bounding rectangle.

![Add pretty hover](~/user-guide/images/AddPrettyHover.gif)

9. Save your Visio file.

In DataMiner Cube, only your ellipse will now be colored with the alarm state of the element and only that shape will be clickable as well, with a nicer hover overlay than before.

![End result](~/user-guide/images/Endresult.webp)

## Related documentation

- [Working with shape data in Microsoft Visio](xref:Working_with_shape_data_in_Microsoft_Visio)
- [Linking a shape to an element, a service or a redundancy group](xref:Linking_a_shape_to_an_element_a_service_or_a_redundancy_group)
- [Linking a shape to an element parameter](xref:Linking_a_shape_to_an_element_parameter)
- [Grouping shapes](xref:Grouping_shapes)
- [NoAlarmColorFill](xref:Overview_of_page_and_shape_options#noalarmcolorfill)
- [Disabling the default hyperlink behavior of a linked shape](xref:Disabling_the_default_hyperlink_behavior_of_a_linked_shape)
