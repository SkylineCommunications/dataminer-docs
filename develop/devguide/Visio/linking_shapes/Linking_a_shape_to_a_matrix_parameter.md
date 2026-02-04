---
uid: Linking_a_shape_to_a_matrix_parameter
---

# Linking a shape to a matrix parameter

By linking shapes in a visual overview to a matrix parameter of an element, you can create an interactive graphical representation of that matrix.

Each shape represents an input or an output of the matrix, while connections between shapes represent the active crosspoints. These connections between inputs and outputs are drawn automatically.

Users can alter connections directly from the visual overview using the right-click menu. However, note that for table-based matrices this is only possible from DataMiner 10.5.0 [CU12]/10.6.0/10.6.3 onwards<!--RN 44601-->. In the context menu, the outputs and inputs of table-based matrices are shown in the same order as the rows in the table.

To make a graphical representation of a matrix parameter, follow these steps:

1. [Draw the shapes that represent the inputs and the outputs](#drawing-the-shapes-representing-the-matrix-inputs-and-outputs).

1. [Draw the shapes that display the input and output labels](#drawing-the-shapes-displaying-the-input-and-output-labels).

1. [Combine all shapes into a group that represents the matrix](#combining-all-shapes-into-a-group-representing-the-matrix).

> [!NOTE]
>
> - When you right-click a shape linked to a matrix parameter, the shortcut menu will by default list all inputs defined in the protocol. However, it is possible that the number of inputs and outputs have been limited in the *port.xml* file.
> - For examples, see [Ziine](xref:ZiineDemoSystem) > *Visual Overview Design Examples* view > *[linking > MTX1/MTX2]* pages.

## Drawing the shapes representing the matrix inputs and outputs

1. Draw a number of shapes that each represent an input or an output.

1. To each of those shapes, add one of the following shape data fields according to their function.

   - **Input**: Name of a matrix input, as specified

     - in the protocol of the element (i.e. the original name), or
     - in the parameter alias file\* (i.e. the name that currently overrides the original name).

     > [!NOTE]
     >
     > - By default, connections will start from the center of the shape.
     > - If you want an "input shape" to show the current Element state, add a shape data field to it of type **Parameter**, and set its value to "\*\|Alarm".

   - **Output**: Name of a matrix output, as specified

     - in the protocol of the element (i.e. the original name), or
     - in the parameter alias file (i.e. the name that currently overrides the original name). Such parameter alias files are often called *port.xml*, although a different name can be defined in the element protocol.

     > [!NOTE]
     >
     > - By default, connections will end at the center of the shape.
     > - If you want an "output shape" to show the current Element state, add a shape data field to it of type **Parameter**, and set its value to "\*\|Alarm".

From DataMiner 10.5.0 [CU12]/10.6.0/10.6.3 onwards<!--RN 44601-->, you can link shapes to inputs and outputs of table-based matrices. Prior to these versions, this is not supported. For Visual Overview in web apps, table-based matrices are not supported in DataMiner 10.5.0 [CU12] and are only fully supported from 10.6.0/10.6.3 onwards.

## Drawing the shapes displaying the input and output labels

1. Draw a number of shapes that each represent an input label or an output label.

1. To each of those shapes, add one of the following shape data fields according to their function.

   - **InputLabel**: Name of a matrix input, as specified

     - in the protocol of the element (i.e. the original name), or
     - in the parameter alias file (i.e. the name that currently overrides the original name). Such parameter alias files are often called *port.xml*, although a different name can be defined in the element protocol.

     If, in the shape, you type "\*", that character will be replaced by the current name of the input.

   - **OutputLabel**: Name of a matrix output, as specified

     - in the protocol of the element (i.e. the original name), or
     - in the parameter alias file (i.e. the name that currently overrides the original name). Such parameter alias files are often called *port.xml*, although a different name can be defined in the element protocol.

     If, in the shape, you type "\*", that character will be replaced by the current name of the output.

## Combining all shapes into a group representing the matrix

1. Combine all shapes created in steps 1 and 2 into a group.

1. To that group, add the following shape data fields.

   - **Element**: The ID of the element containing the matrix parameter.

   - **Parameter**: The ID of the matrix parameter.

     If followed by "\|ALARM", then all inputs, outputs, and connections will have the current alarm color.

   - **Set**: If set to TRUE, users will be able to perform SET commands after right-clicking one of the shapes in the group.

   - **Line**: Optional shape data field, in which you can specify the ID of a shape. If you do so, the connections drawn between inputs and outputs will inherit the line weight of the shape specified.
