---
uid: Restricting_the_use_of_line_objects_to_specific_connections
---

# Restricting the use of line objects to specific connections

If, especially in EPM environments, you use different types of lines for different types of connections, then you can use a shape data field of type **SubscriptionFilter** to specify a filter that will make sure that the line object in question is only used for connections of which the specified column of the row describing the connection contains a particular value.

> [!TIP]
> See also:
> - [Specifying an EPM parameter that can be used to filter](xref:Specifying_an_EPM_parameter_that_can_be_used_to_filter)
> - [Dynamic table filter syntax](xref:Dynamic_table_filter_syntax)

## Configuring the shape data field

To the line object, add a shape data field of type **SubscriptionFilter**, and set its value to:

```txt
value=[comparison]
```

If you want to specify multiple comparisons, separate them with semicolons (”;”).

Example:

```txt
value=4005 == 1
```

Use this line if column ID 4005 contains “1”.
