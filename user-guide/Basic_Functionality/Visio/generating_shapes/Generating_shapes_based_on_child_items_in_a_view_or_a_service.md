---
uid: Generating_shapes_based_on_child_items_in_a_view_or_a_service
---

# Generating shapes based on child items in a view or a service

In a Visio drawing linked to a view or a service, you can specify that a shape should be created automatically for every child item of that view or service.

To implement this feature, do the following:

1. Create the shapes representing the child items, and add the necessary child-level shape data fields to them. See [Child-level shape data](#child-level-shape-data).

   Either create one general shape for all types of children (element, services, redundancy groups and views) or four different shapes (one for each type of child: element, service, redundancy group or view).

1. Group those shapes, and add the necessary group-level shape data fields to the group. See [Group-level shape data](#group-level-shape-data).

> [!TIP]
> For an example, see [Ziine](xref:ZiineDemoSystem) > *Visual Overview Design Examples* view > *[children > ELEMENTS AND VIEWS]* page.

## Child-level shape data

The following shape data fields can be added to a shape that has to represent a particular type of child item.

- **ChildMargin**: In this optional shape data field, you can specify the space between the different child items within the container shape.

  - A space relative to the width of the shape representing a child item, or
  - A fixed space (in pixels).

  Examples:

  ```txt
  1/20
  ```

  If the child shapes have a width of 100 px, the space between the child shapes will be 5 px (a twentieth of 100 px).

  ```txt
  5
  ```

  The space between the child shapes will always be 5 px.

- **ChildType**: In this mandatory shape data field, specify the type of child item the shape has to represent: view, element, service or redundancy group.

  | Value           | Description                                             |
  | --------------- | ------------------------------------------------------- |
  | Element         | The shape will be used to represent an element.         |
  | Service         | The shape will be used to represent a service.          |
  | View            | The shape will be used to represent a view.             |
  | RedundancyGroup | The shape will be used to represent a redundancy group. |

  Example: All child items of type "Element" will be represented by the shape of which **ChildType** is set to "Element".

- **ChildrenFilter**:

  - If you have set the shape data field of type **ChildType** to "Element", "Service" or "View", you can add an additional shape data field of type **ChildrenFilter** to indicate that you want that shape only to be used to represent elements, services or views that match a specific filter:

    - Elements using a particular protocol or protocol version.
    - Elements, services or views with a property set to a value matching a regular expression.
    - Elements, services or views with a specific alarm severity.

      If a shape should only be used to represent elements using a particular protocol, add a shape data field to it of type **ChildrenFilter**, and set its value to "Protocol:xxx" or "Protocol:xxx/yyy".

      - xxx = the protocol name
      - yyy = the protocol version

      If a shape should only be used to represent elements if these have a property with a value matching a particular regular expression, add a shape data field to it of type **ChildrenFilter**, and set its value to "Property:PropertyName=ValueRegex". A property containing a space should be placed between double quotation marks.

      > [!NOTE]
      > If there is a shape without protocol filter, that shape will be used to represent elements that do not match any of the other protocol filters you may have specified in other shapes.

  - You can combine several filters using pipe characters ("\|"), in which case all filters will need to match for a shape to be shown:

    ```txt
    Protocol:Philips DVS3810/Production|Property:Class=^A$
    ```

    - From DataMiner 9.0.5 onwards, it is possible to only have shapes generated for child objects with a specific alarm severity. To do so, specify a comma-separated list of alarm severities as the value of the **ChildrenFilter** shape data field.

      For example, if you specify "AlarmSeverity:Critical,Major", shapes will only be generated for child object of which the alarm severity is either "Critical" or "Major".

      | Shape data field   | Value                        |
      |--------------------|------------------------------|
      | ChildrenFilter     | AlarmSeverity:Critical,Major |

      > [!NOTE]
      > The *Timeout* alarm severity is currently not supported in the **ChildrenFilter** field.

    - Using placeholders such as "\[var:\]" and "\[param:\]" within **ChildrenFilter** shape data is supported from DataMiner 9.6.4 onwards. This can for instance be used to filter the child shapes using a session variable in the filter value.

  - From DataMiner 10.2.0/10.1.2 onwards, you can filter service, view and element children by name, by specifying a regular expression in the following format in the shape data: *Name=Regex*.

    For example, "Name=\[var:userSpecifiedName\]". Only objects of which the name matches the regular expression will be shown.

    - From DataMiner 10.2.0/10.1.10 onwards, you can filter service children based on whether they are mapped resources, unmapped resources, or resources inherited from a resource pool. To do so, add a data field of type **ChildrenFilter** and set its value to "ResourceMapping=", followed by one or more roles (separated by commas): "mapped", "unmapped" or "inheritance". If you specify multiple roles, all shapes of which the roles match one of the specified roles will be shown. For example:

      | Shape data field   | Value                                       |
      |--------------------|---------------------------------------------|
      | ChildrenFilter     | ResourceMapping=mapped,unmapped,inheritance |

## Group-level shape data

The following shape data fields can be added to the group containing the shapes that have to represent the different child items.

- **Children**: In this mandatory shape data field, specify the type of child items that have to be generated: "View", "Element", "Service" and/or "RedundancyGroup". In case of multiple types, separate them by pipes.

  Examples:

  ```txt
  View|Element|Service
  ```

  Generate a shape for every view, element and service in the view or service to which the drawing is linked.

  ```txt
  Element
  ```

  Generate a shape for every element in the view or service to which the drawing is linked.

    > [!NOTE]
    >
    > - By default, a **Children** shape always shows the child items of the view or service to which the Visio drawing is linked. If you want a **Children** shape to show the child items of a specific view or service, then add a shape data field of type **View** or **Element** to that same shape. In that field, you can then explicitly specify the view or the service of which the shape has to show all child items.
    > - A **Children** shape can contain another **Children** shape. That way, you can dynamically generate e.g. shapes that represent all subviews in a view, as well as shapes that represent all items in those subviews.
    > - With the DataMiner Cube user setting *Maximum number of child shapes in a 'Children' container shape*, you can control the maximum number of Visio shapes allowed in a **Children** container shape. Default: 100. See [Visual Overview settings](xref:User_settings#visual-overview-settings).

- **ChildrenOptions**: In this optional shape data field, you can specify the following options:

  | Value | Description |
  | ----- | ----------- |
  | LazyLoading | If the child shapes will be generated in a scrollable container shape (stack panel, wrap panel, etc.), use this option to configure lazy loading. Though the child shapes will then be generated immediately, they will only be initialized the moment they come into view. |
  | Recursive | Also generate a shape for every view, element and service in all subviews and subservices of the view to which the drawing is linked. |
  | ShowHiddenElements | From DataMiner 9.0.0 CU16/DataMiner 9.5.3 onwards, by default no shapes are displayed for hidden elements. To override this behavior, specify this option. |

  > [!NOTE]
  > When using the "Recursive" option, keep in mind that elements in services are always skipped.
  > This is to prevent generating shapes for elements of which only certain parameters are included in the service. If shapes were generated for such elements, we would risk showing alarm states of parameters that are not included in a service.

- **ChildrenSort**: In this optional shape data field, you can specify how the different child item shapes should be sorted:

  | Value                  | Description                                 |
  | ---------------------- | ------------------------------------------- |
  | Name                   | Order by child item name.                   |
  | Property\|PropertyName | Order by the specified child item property. |
  | Severity               | Order by alarm severity.                    |

  Also, you can specify a sort order by adding one of the following suffixes:

  | Suffix | Description                    |
  | ------ | ------------------------------ |
  | ,asc   | Ascending (default sort order) |
  | ,desc  | Descending                     |

  Examples:

  - Sort by severity, descending: `Severity,desc`
  - Sort by property "MyProperty", ascending: `Property|MyProperty,asc`

  Alternatively, from DataMiner 9.0.5 onwards, for shapes that are automatically generated to represent alarms, you can specify the name of any Alarm Console column as the value to sort the shapes. Like in the Alarm Console, the shapes will then first be sorted by the specified column, and then by time. For example, if you add a shape data field of type **ChildrenSort**, and configure the following value, the shapes will be sorted by element name in descending order (i.e. Z to A): `Element Name, desc`

  > [!NOTE]
  > From DataMiner 10.2.0/10.1.1 onwards, placeholders such as \[var:VariableName\] can be used in **ChildrenSort** shape data. See [Placeholders for variables in shape data values](xref:Placeholders_for_variables_in_shape_data_values).

- **ChildrenPanel**: In this optional shape data field, you can specify how the child items have to be organized within the container shape.

  Possible values:

  - Stack
  - StackHorizontal
  - StackVertical
  - Grid\|Cols=999
  - Grid\|Rows=999
  - Wrap
  - WrapVertical
  - WrapHorizontal

- **ElementOptions**: In this optional shape data field, you can specify that child shapes should only be generated for child items of a service that are in use, not in use or excluded:

  ```txt
  ServiceIncludeState=inuse,notinuse,excluded
  ```
