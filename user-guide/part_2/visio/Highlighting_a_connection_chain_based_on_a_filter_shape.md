---
uid: Highlighting_a_connection_chain_based_on_a_filter_shape
---

# Highlighting a connection chain based on a filter shape

A connectivity chain can be set to highlight based on a filter condition set by either clicking a button or selecting a value from a selection box.

Create a shape, add a shape data field of type **Connection** to it, and set its value to “*Filter=xxx*”.

- If xxx is a single value (e.g. “Filter=VLAN 1”), the shape will be rendered as a button.

- If xxx is a colon-separated list of values (e.g. “Filter=VLAN 1:VLAN 2”), the shape will be rendered as a selection box listing the specified values.

- If xxx is a placeholder referring to a row of a table parameter (e.g. “\[Param:DmaID/ElementID,TableID\]”), the shape will be rendered as a selection box listing the display key values of the specified table row.

Each defined connection can have a *Connections Filter* value. This value can be configured on internal connections (e.g. VLAN configurations), but external connections will typically not be filtered, as they represent physical cable connections. The value of the filter shape in Visio will be compared with these Connections Filters for each defined connection, and any matches will be highlighted.

Signal paths in which filtered internal connections are combined with unfiltered external connections are highlighted in the following way:

- Internal connections are only highlighted if they match the filter.

- External connections (without filter) are highlighted only if they are connected to an internal connection that matches the filter.

> [!NOTE]
> For more information on how to configure filters on a connectivity chain, see [Editing element connections in the Properties window](xref:Editing_element_connections_in_the_Properties_window).
>
