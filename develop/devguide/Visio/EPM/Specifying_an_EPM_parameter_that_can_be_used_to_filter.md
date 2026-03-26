---
uid: Specifying_an_EPM_parameter_that_can_be_used_to_filter
---

# Specifying an EPM parameter that can be used to filter

If you have linked a page of a Visio drawing to a chain (i.e., tab page) of an EPM element using a shape data field of type **Chain**, you can use a shape data field of type **SubscriptionFilter** to specify a parameter of the EPM element on which users are allowed to filter the data displayed on the page.

If you add a shape data field of type **SubscriptionFilter** to a page of a Visio drawing, a selection box will appear in the top-right corner of that drawing, allowing users to select a filter value.

> [!TIP]
> See also:
> [Restricting the use of line objects to specific connections](xref:Restricting_the_use_of_line_objects_to_specific_connections)

## Configuring the shape data field

Add a shape data field of type **SubscriptionFilter** to the page, and set its value to:

```txt
DmaID/ElementID/ParameterID
```
