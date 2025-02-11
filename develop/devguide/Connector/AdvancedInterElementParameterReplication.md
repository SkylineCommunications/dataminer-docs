---
uid: AdvancedInterElementCommunicationParameterReplication
---

# Parameter replication

Instead of doing a full replication, resulting in an exact copy of the protocol, you can also replicate specific parameters from an element.

Say for example that you have a full protocol, but you would also like a subset of that protocol, because not all information may be viewed by everybody. This is possible by specifying the replication tag on the parameter that you would like to replicate to:

```xml
<Param id="2" save="true">
  <Name>Param2</Name>
  <Description>Param2</Description>
  <Replication ip="127.10.1.1" uid="User" pwd="pwd" domain="127.10.1.2">
     <Element>41/428</Element>
     <Parameter>350</Parameter>
  </Replication>
  <Display>
     <RTDisplay>true</RTDisplay>
     <Positions>
        <Position>
           <Page>Main View</Page>
           <Row>1</Row>
           <Column>0</Column>
        </Position>
     </Positions>
  </Display>
</Param>
```

Here, you replicate parameter 350 from element 41/428. The parameter ID does not have to match the one that you replicate from.

This can also be made more dynamic in the following way:

```xml
<Replication uid="12" pwd="13">
  <Element dynamic="14" />
  <Parameter dynamic="15" />
</Replication>
```

The value of the *dynamic* attribute specifies the ID of the parameter that holds the value. See [Protocol.Params.Param.Replication.Element-dynamic](xref:Protocol.Params.Param.Replication.Element-dynamic) and [Protocol.Params.Param.Replication.Parameter-dynamic](xref:Protocol.Params.Param.Replication.Parameter-dynamic).
