---
uid: AdvancedInterElementCommunicationElementConnections
---

# Element connections

In case a parameter should receive or send its value from or to another parameter of another element, element connections can be used. Using the "Element Connections" app, links between elements can be defined.

> [!NOTE]
> For more information on the Element Connections app, refer to [Virtual elements used for element connections](xref:Virtual_elements#virtual-elements-used-for-element-connections). Note that this is not related to the [DCF element connections](xref:Viewing_element_connections) functionality, which is a completely different feature.

A parameter in a protocol can be defined as either a source or destination of an element connection. This is done via the attribute virtual of the Type tag.

For example, the following parameter indicates that this parameter can be used as a source of an element connection from this element to another:

```xml
<Param id="65" setter="true">
   <Name>generalData_Total Bandwidth</Name>
   <Description>Total Bandwidth</Description>
   <Type virtual="source">write</Type>
   <Interprete>
      <RawType>numeric text</RawType>
      <LengthType>next param</LengthType>
      <Type>double</Type>
   </Interprete>
   <Display>…</Display>
   <Measurement>
      <Type>number</Type>
   </Measurement>
</Param>
```

The virtual attribute allows you to further restrict to which protocols or parameters a connection can be established. For more information, see [virtual](xref:Protocol.Params.Param.Type-virtual).

In the Element Connections app, this parameter will be included in the overview of the elements running this protocol:

![DataMiner Cube Element Connections app](~/develop/images/element_connections_app.png)

Here you can specify the protocol and parameter of the protocol to use in the connection. Note that this method does not require any change in the protocol that defines the parameter you want to connect with.

> [!NOTE]
> In case the parameter acts as a source, RTDisplay must to be set to "true".
