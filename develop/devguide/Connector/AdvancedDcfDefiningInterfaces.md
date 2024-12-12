---
uid: AdvancedDcfDefiningInterfaces
---

# Defining interfaces

In DCF, two main concepts are defined: interfaces and connections.

## Standalone interfaces

To define a standalone interface in a protocol, define a new [Group](xref:Protocol.ParameterGroups.Group) in [ParameterGroups](xref:Protocol.ParameterGroups) and specify the ID, name and type.

```xml
<ParameterGroups>
  <Group id="1" name="Input" type="in"></Group>
  <Group id="2" name="Output" type="out"></Group>
</ParameterGroups>
```

Each group needs to have a unique ID and name.

In order for the group to be considered a DCF interface, the type of the group must be one of the following: "in", "out", or "inout".

The IDs must be within the range 1 - 99 999. It is generally recommended to use IDs lower than 10 000 where possible.

## Dynamic interfaces

In order to dynamically expose an element's interface table to DCF, use the [*dynamicId* attribute](xref:Protocol.ParameterGroups.Group-dynamicId) to specify the ID of the table containing the interfaces and the [*dynamicIndex* attribute](xref:Protocol.ParameterGroups.Group-dynamicIndex) to filter the table rows.

The table containing the interfaces should be as static as possible and should not remove rows without manual interaction of a user. It should be treated just like DVE tables in terms of row removal. Make sure that all columns in interface tables that are used to create the display key are marked as "saved".

All rows of the specified table that match the filter specified in the dynamicIndex attribute will be considered an interface. The name of this interface will be the name defined in the Group concatenated with the display key of the row (with a space (" ") between the two parts).

```xml
<ParameterGroups>
  <Group id="1" name="Input" type="in" dynamicId="1000" dynamicIndex="*"></Group>
  <Group id="2" name="Output" type="out" dynamicId="2000" dynamicIndex="*"></Group>
</ParameterGroups>
```

In case you want that interface name to be the concatenation of the Group name and the primary key instead of the display key, use the [*dynamicUsePK* attribute](xref:Protocol.ParameterGroups.Group-dynamicUsePK) and set it to `true`. For example:

```xml
<ParameterGroups>
  <Group id="1" name="Input" type="in" dynamicId="1000" dynamicIndex="*" dynamicUsePK="true"></Group>
</ParameterGroups>
```

## Alarm linking

It is possible to specify that the alarm state of an interface should correspond with the alarm state of a parameter.

This is done by adding a new [Param](xref:Protocol.ParameterGroups.Group.Params.Param) to [Params](xref:Protocol.ParameterGroups.Group.Params) of the Group that represents the interface.

The mandatory [*id* attribute](xref:Protocol.ParameterGroups.Group.Params.Param-id) then specifies the ID of the parameter.

All `<Param>` tags inside a `<ParameterGroup>` should refer to a different and existing PID.

```xml
<Group id="1" name="Input" type="in">
  <Params>
     <Param id="10"/>
   </Params>
</Group>
```

Note that it is also possible to refer to multiple parameters. In this case, the alarm severity of the interface will be the highest alarm severity of the included parameters.

```xml
<Group id="1" name="Input" type="in">
  <Params>
     <Param id="10"/>
     <Param id="20"/>
     <Param id="30"/>
   </Params>
</Group>
```

In order to refer to a table cell, specify the ID of the column parameter in the [*id* attribute](xref:Protocol.ParameterGroups.Group.Params.Param-id) and the display key in the [*index*](xref:Protocol.ParameterGroups.Group.Params.Param-index).

```xml
<Group id="1" name="Input" type="in">
  <Params>
     <Param id="303" index="Port A1"/>
   </Params>
</Group>
```

You can also specify wildcard characters (`?` and `*`) in the index. In that case, the highest alarm severity of the matching cells will be selected.

Finally, it is also possible to combine standalone parameters and cells. In that case, the index attribute must be defined but left empty.

```xml
<Group id="1" name="Input" type="in">
  <Params>
     <Param id="303" index="Port A1"/>
     <Param id="10" index=""/>
     <Param id="20" index=""/>
   </Params>
</Group>
```

For dynamic interfaces, the alarm severity of the interface corresponds with the alarm severity of the corresponding row.

```xml
<Group id="1000" name="Dynamic Table IN" type="in" dynamicId="1000" dynamicIndex="I_*"/>
```
