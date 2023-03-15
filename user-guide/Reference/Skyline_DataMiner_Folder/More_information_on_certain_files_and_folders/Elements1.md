---
uid: Elements1
---

# Elements

The *C:\\Skyline DataMiner\\Elements\\* directory contains a subdirectory for every element on the DMA.

## Files found in every Element subdirectory

Each element subdirectory contains the following files:

- Element.xml

- ElementData.xml

- Description.xml

> [!NOTE]
> The folder of matrix elements can also contain a file with matrix label aliases, usually called *Port.xml* or *Ports.xml*. The name of this file depends on the element protocol.

## Element.xml

Every element on a DMA has its own *Element.xml* file. It contains the complete element definition:

- Metadata (name, description, type, Protocol, etc.),

- Port settings,

- Log settings,

- List of element properties, and

- Replication settings.

Several things can be configured in this file:

- To enable or disable the creation of DVE child elements, a *dvecreate* attribute can be added. For more information, see [Enabling or disabling the creation of DVE child elements](xref:Dynamic_virtual_elements#enabling-or-disabling-the-creation-of-dve-child-elements).

- To enable an element simulation, a *simulation* attribute can be added. For more information, see [What happens when you enable simulation?](xref:Simulated_elements#what-happens-when-you-enable-simulation)

- To enable data offloads to the offload database on element level, a *\<CentralOffload>* tag can be added. See [Disabling data offloads to the offload database on element level](xref:Configuring_data_offloads#disabling-data-offloads-to-the-offload-database-on-element-level).

- SNMP agent community strings are specified on element level with the *\<SNMPAgent>* tag. See [Configuring SNMP agent community strings](xref:Configuring_SNMP_agent_community_strings).

## Description.xml

Every element on a DMA has its own *Description.xml* file. In that file, you can specify aliases for each of the parameters of that element.

When you change something to a *Description.xml* file of an element, the changes will only take effect after a restart of the element.

Here is an example of a *Description.xml* file containing aliases for two parameters:

```xml
<Params nextSpectrumId="...">
  <Param id="100">
    <Description>OtherNameForParam100</Description>
  </Param>
  <Param id="101">
    <Description>OtherNameForParam101</Description>
  </Param>
  ...
</Params>
```

> [!NOTE]
> The *nextSpectrumId* attribute of the *\<Params>* tag holds the Parameter ID to be used when the next Monitor parameter has to be created. This ID will be a number in the 50000-59999 range.
