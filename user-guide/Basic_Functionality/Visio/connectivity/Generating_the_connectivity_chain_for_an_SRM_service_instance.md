---
uid: Generating_the_connectivity_chain_for_an_SRM_service_instance
---

# Generating the connectivity chain for an SRM service instance

From DataMiner 9.5.3 onwards, it is possible to have the connectivity chain of a service instance (from the Service & Resource Management module) drawn automatically in Visual Overview.

To have a service instance chain drawn automatically, define the following shapes in Visio:

- A **Connection** shape, configured as described in [Automatically displaying external and internal connections](xref:Automatically_displaying_external_and_internal_connections).

- A second **Connection** shape (optional), of which the value is set to ServiceDefinition. The style of this shape will be used for the connection lines in the service definition (i.e. the expected connections) for which no matching DCF connections can be found, so that the difference with actual real-time connections is clear. Connection lines for which a matching DCF connection can be found will be drawn in the style of the previous **Connection** shape.

- A parent service instance shape, indicating the area within which children shapes will be placed. This shape itself will not be displayed in Visual Overview. However, it determines the possible size and position of the service chain. This shape should contain the following shape data:

  | Shape data field | Description |
  |--|--|
  | ServiceInstance | Set this shape data field to either of the following values:<br> -  The GUID of the service instance, or<br> -  A reference to a DataMiner service. This reference can be configured in the same way as any other reference to a service, i.e. by ID, by name (optionally using wildcard characters), or using placeholders such as \[this service\]. |
  | Options | Optional. Available from DataMiner 10.0.0/10.0.2 onwards.<br> To avoid gaps in the visualization of the service, add this shape data field and set it to the following value: *CollapseEmptyRowsAndColumns=True* |

- Placeholder shapes, representing the different possible elements in the service chain. These are child shapes within the service instance parent shape. These child shapes will be converted into element shapes and placed in the correct position according to the service definition.

  Each of these placeholder shapes can be configured with the following shape data:

  - **Protocol**: Mandatory shape data field. The value should be set to the protocol function name matching the element defined in the service chain. For example, for an encoder, this shape data field could be set to STA_DCF_DEVICE.Encoder.

    In addition, the service chain should ideally contain one default placeholder shape, for which the value of the Protocol shape data field is set to Default.

  - Any shape data a normal parent element shape would have, except for the element shape data itself, which is determined by the service instance chain.

- The placeholder shapes can in turn contain the following optional child shapes:

  - Child shapes representing the element interfaces. To make it possible to automatically determine which interfaces should be assigned to which element shape, we suggest setting the **Interface** shape data for these shapes to one of the following values:

    - *\[Auto\]\|Input*

    - *\[Auto\]\|InputOutput*

    - *\[Auto\]\|Output*

  - Optional additional child shapes in the placeholder shape, for example to display the element name of the shape. For the latter, a child shape should be added with shape data **Element** set to "\*" and shape data **Info** set to "Name". See [Making a shape display information about the item it is linked to](xref:Making_a_shape_display_information_about_the_item_it_is_linked_to).

> [!NOTE]
> From DataMiner 10.2.0/10.1.12 onwards, this feature supports lite contributing resources (i.e. contributing resources for which no enhanced element is created). In that case, the connections for the contributing node will be based on the connections in the service definition.

## Displaying connection property shapes for a service connectivity chain

From DataMiner 9.5.12 onwards, you can have a connection property displayed on top of every connection of the service definition that contains that property.

To do so:

1. Add a shape to the drawing, to be used as the template shape.

1. Add a shape data field of type **Options** with the value “*ServiceDefinitionConnectionProperty:*”, followed by the name of the property.

   | Shape data field | Value |
   |--|--|
   | Options | ServiceDefinitionConnectionProperty:*PropertyName* |

1. Optionally, set the shape text to "\*", to display the value of the connection property on the shape.

1. Optionally, add a shape data field of type **Tooltip**, and use an "\*" in the value of the field in order to display the property value in a tooltip.
