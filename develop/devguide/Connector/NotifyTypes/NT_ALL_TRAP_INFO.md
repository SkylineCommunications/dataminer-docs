---
uid: NT_ALL_TRAP_INFO
---

# NT_ALL_TRAP_INFO (287)

Can be used to trigger a custom context menu item.

For example, suppose the following context menu item has been defined:

```xml
<Param id="3210" trending="false">
   <Name>Functional Units_ContextMenu</Name>
   <Description>Functional Units_ContextMenu</Description>
   <Type>write</Type>
   <Interprete>
      <RawType>other</RawType>
      <LengthType>next param</LengthType>
      <Type>string</Type>
   </Interprete>
   <Display>
      <RTDisplay>true</RTDisplay>
   </Display>
   <Measurement>
      <Type>discreet</Type>
      <Discreets>
         <Discreet dependencyValues="3214;3213">
            <Display>Add Functional Unit...</Display>
            <Value>addrow</Value>
         </Discreet>
         <Discreet options="table:selection">
            <Display>Delete Functional Units</Display>
            <Value>delete</Value>
         </Discreet>
      </Discreets>
   </Measurement>
</Param>
```

```csharp
uint dmaId = (uint)protocol.DataMinerID;
uint elementId = (uint)protocol.ElementID;
uint parameterId = (uint)3210;

uint[] ids = new[] { dmaId, elementId, parameterId };

string guid = Guid.NewGuid().ToString("N");
string contextMenuItem = "addrow";

// Additional dependency values.
string resourceName = "myResourceName";
string unitType = "MyUnitType";

string[] values = new [] { guid, contextMenuItem, resourceName, unitType };

protocol.NotifyDataMiner(287 /*NT_ALL_TRAP_INFO*/, ids, values);
```

## Parameters

- ids (uint[]):
  - ids[0]: DataMiner Agent ID
  - ids[1]: element ID
  - ids[2]: parameter ID
- values (string[]):
  - values[0]: GUID
  - values[1]: Name of the context menu item (as defined in Discreet/Value).
  - values[2..n]: Additional dependency values (as defined in Discreet@dependencyValues).

## Return Value

- Does not return a value.
