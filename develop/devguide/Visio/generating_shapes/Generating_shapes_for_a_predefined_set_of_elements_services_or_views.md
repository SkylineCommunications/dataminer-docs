---
uid: Generating_shapes_for_a_predefined_set_of_elements_services_or_views
---

# Generating shapes for a predefined set of elements, services or views

You can specify that a shape should be created automatically for every item in a particular set of elements, services or views.

To do so:

1. Create the shape representing an item in the set, and add the necessary child-level shape data fields to it. See [Child-level shape data](#child-level-shape-data).

1. Put the shape into a group, and add the necessary group-level shape data fields to the group. See [Group-level shape data](#group-level-shape-data).

## Child-level shape data

The following shape data fields can be added to a shape that has to represent a particular type of child item.

- **ChildType**: In this mandatory shape data field, specify one of the following values depending on the type of child item the shape has to represent:

  - Element

  - Service

  - View

> [!NOTE]
> Other optional shape data, e.g., **ChildMargin**, can also be specified, in the same manner as for other ChildType shapes. See [Generating shapes based on table rows](xref:Generating_shapes_based_on_table_rows), [Generating shapes based on child items in a view or a service](xref:Generating_shapes_based_on_child_items_in_a_view_or_a_service) and [Generating shapes that represent alarms](xref:Generating_shapes_that_represent_alarms).

## Group-level shape data

The following shape data fields can be added to the group containing the table row shapes.

- **Children**: In this mandatory shape data field, specify one of the following values, depending on the type of item for which shapes must be generated:

  - Element

  - Service

  - View

- **ChildrenSource**: In this mandatory shape data field, specify the set of objects in the format Set=\[Objects\], where \[Objects\] is replaced by a list of element, service or view names or IDs, separated by semicolons (";").

  For example:

  ```txt
  Set=SRM List Service 02;520/80
  ```

  This shape data field can also be used with dynamic placeholders, e.g., \[SLAFromService:\<service(s)>\]. For example, to generate child shapes for the SLAs in two services "Service A" and "Service B", you can specify the following:

  ```txt
  Set=[SLAFromService:Service A;Service B]
  ```

> [!NOTE]
> Other optional shape data can also be specified, e.g., **ChildrenOptions**, in the same manner as with other Children shapes. See [Generating shapes based on table rows](xref:Generating_shapes_based_on_table_rows), [Generating shapes based on child items in a view or a service](xref:Generating_shapes_based_on_child_items_in_a_view_or_a_service) and [Generating shapes that represent alarms](xref:Generating_shapes_that_represent_alarms).
