---
uid: Generating_shapes_that_represent_alarms
---

# Generating shapes that represent alarms

In a Visio drawing, you can specify that a shape should be created automatically for every alarm associated with the object to which the Visio drawing is linked (e.g. a view). Those automatically generated "alarm shapes" can be set to show the alarm severity color and the contents of one particular detail of the alarm in question (by specifying the name of the Alarm Console column displaying that field).

To implement this feature, do the following:

1. Create the shape representing an alarm, and add the necessary child-level shape data fields to it. See [Child-level shape data](#child-level-shape-data).
1. Put the shape into a group, and add the necessary group-level shape data fields to the group. See [Group-level shape data](#group-level-shape-data).

> [!NOTE]
>
> - The shape created in step 1 can itself be a group that contains a number of subshapes, each with their own **Alarm** and **Info** data fields. That way, you can e.g. visualize different details of one particular alarm.
> - From DataMiner 9.5.3 onwards, by default the shapes representing the alarms are ordered according to the time of the alarms.
> - For an example, see [Ziine](xref:ZiineDemoSystem) > *Visual Overview Design Examples* view > *[children > ALARMS]* page.

## Child-level shape data

The child-level shape data must be configured differently depending on whether an alarm will be represented by a single shape or by a number of shapes grouped together.

### A single shape represents an alarm

The following shape data fields can be added to a single shape representing an alarm:

- **Alarm**: In this mandatory shape data field, specify "\*".

- **ChildType**: In this mandatory shape data field, specify the following value:

  - Alarm

- **Info**: In this mandatory shape data field, specify the name of the Alarm Console column of which you want the contents to be shown in the shape.

  > [!NOTE]
  > To refer to property columns, use the format "ALARMPROPERTY:\*\*PropertyName" or "ELEMENTPROPERTY:\*\*PropertyName", depending on the type of property.

- **Link**: In this optional shape data field, you can specify where a dynamically generated shape will link to.

  Use the following syntax:

  ```txt
  ELEMENTPROPERTY:ElementPropertyName|ItemType
  ```

  Make sure that the element associated with the alarm has a custom property named "ElementPropertyName", which contains a name or an ID of an element, view, service or redundancy group. If you want to rule out any mix-up between IDs, you can use "ItemType" to indicate that the name or ID you specified, refers to an element, a view, a service or a redundancy group. Example: If you set the link value to "ELEMENTPROPERTY:MyAlarmLink\|Element", the shape will link to the element name or element ID stored in the element property named "MyAlarmLink".

### A group of shapes represents an alarm

To display different pieces of information for each alarm, you can group several shapes together, so that they together represent the child shape. In that case the shape data fields should be configured as follows:

- At group level:

  - **ChildType** (configured the same way as for a single shape).
  - **Link** (optional – configured the same way as for a single shape).

- For each shape within the group that has to display alarm information:

  - **Alarm** (configured the same way as for a single shape).
  - **Info** (configured the same way as for a single shape).

## Group-level shape data

The following shape data fields can be added to the group containing the alarm shapes.

- **Children**: In this mandatory shape data field, specify the following value:

  - Alarm

  > [!NOTE]
  > With the DataMiner Cube user setting *Maximum number of child shapes in a Children container shape*, you can control the maximum number of Visio shapes allowed in a **Children** container shape. Default: 100. See [Visual Overview settings](xref:User_settings#visual-overview-settings).

- **ChildrenOptions**: In this optional shape data field, you can specify the following options:

  - **Center**: Use this option to have the generated shapes centered.
  - **LazyLoading**: If the child shapes will be generated in a scrollable container shape (stack panel, wrap panel, etc.), use this option to configure lazy loading. Though the child shapes will then be generated immediately, they will only be initialized the moment they come into view.

- **ChildrenSort**: In this optional shape data field, you can specify how the different child item shapes should be sorted:

  | Value | Description |
  | ----- | ----------- |
  | Column name | Sorts alarms by the name of an Alarm Console column (which does not actually need to be displayed in the Alarm Console).<br>This is usually a property of the alarm, represented as "Alarm.PropertyName". |

  Also, you can specify a sort order by adding one of the following suffixes:

  | Suffix | Description                    |
  | ------ | ------------------------------ |
  | ,asc   | Ascending (default sort order) |
  | ,desc  | Descending                     |

  Examples:

  - Sort by severity, descending:

    ```txt
    Severity,desc
    ```

  - Sort by property "Level", ascending:

    ```txt
    Alarm.Level,asc
    ```

  > [!NOTE]
  > From DataMiner 10.2.0/10.1.1 onwards, placeholders such as \[var:VariableName\] can be used in **ChildrenSort** shape data. See [Placeholders for variables in shape data values](xref:Placeholders_for_variables_in_shape_data_values).

- **ChildrenPanel**: In this optional shape data field, you can specify how the child items have to be organized within the container shape.

  Possible values:

  - VirtualizingStack
  - VirtualizingStackHorizontal
  - VirtualizingStackVertical

  If any other option is specified, it will fall back to the most appropriate of the options above, e.g. "WrapHorizontal" will fall back to "VirtualizingStackHorizontal".

- **ChildrenFilter**: In this optional shape data field, you can specify the name of a shared alarm filter. If you do so, a shape will be generated for every alarm matching that particular shared alarm filter.

  > [!NOTE]
  > Using placeholders such as "\[var:\]" and "\[param:\]" within **ChildrenFilter** shape data is supported from DataMiner 9.6.4 onwards.

- **Options**: In this optional shape data field, you can specify the option "HideAlarmsThatAreCurrentlyCorrelated" if you do not want shapes to be generated for correlated alarms.

  If you specify this option, correlated alarms will disappear from the list and will reappear the moment the correlation alarm is cleared.

- **View**: In this optional shape data field, you can specify the name or the ID of a view. If you do so, a shape will be generated for every alarm associated with that specific view.

  If you do not add a shape data field of type **View**, then a shape will be generated for every alarm associated with the object to which the Visio drawing is linked. E.g. If the Visio file is linked to an element, a shape will be generated for every alarm associated with that particular element.
