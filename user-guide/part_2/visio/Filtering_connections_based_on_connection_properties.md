---
uid: Filtering_connections_based_on_connection_properties
---

## Filtering connections based on connection properties

From DataMiner 9.5.4 onwards, it is possible to filter out DCF connections based on connection properties. Connections that are filtered out will not be used in any functionality in the Visual Overview.

To set up a filter for DCF connections, add the following shape data to the **Connection** shape:

| Shape data field | Value                                                                                                                                                                                                                                                                          |
|------------------|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Filter           | *\<X>-X\|Connection\|Property:AAA\|=BBB*<br> -  AAA: The name of the property.<br> -  BBB: The value of the property. |

> [!NOTE]
> You can add multiple conditions, combining them in the same way as conditional shape manipulation actions. See [Extended conditional shape manipulation actions](Extended_conditional_shape_manipulation_actions.md).

For example:

| Shape data field | Value                                                                                   |
|------------------|-----------------------------------------------------------------------------------------|
| Connection       | Connectivity                                                                            |
| Filter           | \<A>OR\<B>-A\|Connection\|Property:Length\|\>10-B\|Connection\|Property:Bandwidth\|=100 |
