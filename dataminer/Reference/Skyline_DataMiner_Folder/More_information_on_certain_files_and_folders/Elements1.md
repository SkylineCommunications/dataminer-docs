---
uid: Elements1
---

# Elements

In systems where [Swarming](xref:Swarming) is not enabled, the `C:\Skyline DataMiner\Elements\` directory contains a subdirectory for every element on the DMA, containing the following files:

- Element.xml

- ElementData.xml

- Description.xml

> [!NOTE]
>
> - The folder of matrix elements can also contain a file with matrix label aliases, usually called *Port.xml* or *Ports.xml*. The name of this file depends on the element protocol.
> - If Swarming is enabled, the element configuration is stored in the database instead.

## Element.xml

If Swarming is not enabled, every element on a DMA has its own *Element.xml* file. It contains the complete element definition:

- Metadata (name, description, type, Protocol, etc.),

- Port settings,

- Log settings,

- List of element properties, and

- Replication settings.

Several things can be configured in this file:

- To enable or disable the creation of DVE child elements, a *dvecreate* attribute can be added. For more information, see [Enabling or disabling the creation of DVE child elements](xref:Dynamic_virtual_elements#enabling-or-disabling-the-creation-of-dve-child-elements).

- To enable data offloads to the offload database on element level, a *\<CentralOffload>* tag can be added. See [Disabling data offloads to the offload database on element level](xref:Configuring_data_offloads#disabling-data-offloads-to-the-offload-database-on-element-level).

- SNMP agent community strings are specified on element level with the *\<SNMPAgent>* tag. See [Configuring SNMP agent community strings](xref:Configuring_SNMP_agent_community_strings).

- To determine how long trend data are kept for a specific element, overriding the configuration from [DBMaintenanceDMS.xml](xref:DBMaintenanceDMS_xml), a *Trending* tag can be added with the following subtags:<!-- RN 4167 -->

  - *TimeSpan*: Determines the period during which the "real-time trending" records have to be kept in the database.
  - *TimeSpan1DayRecords*: Determines the period during which the daily "average trending" records have to be kept in the database.
  - *TimeSpan1HourRecords*: Determines the period during which the 1-hour "average trending" records have to be kept in the database.
  - *TimeSpan5MinRecords*: Determines the period during which the 5-minute "average trending" records have to be kept in the database.
  - *TimeSpanSpectrumRecords*: Determines the period during which spectrum trend data has to be kept in the database.

  For each of these tags, you can specify integer values (e.g., 1, 2, 12, etc.) or decimal values (1.5, 2.5, etc.). Each of these also has a *unit* attribute that can be set to "hour", "hours", "day", "days", "month", "months", "year" or "years".

  For example:

  ```xml
  <Trending>
      <TimeSpan1DayRecords unit="days">730</TimeSpan1DayRecords><!--2 years-->
      <TimeSpan1HourRecords unit="days">365</TimeSpan1HourRecords><!--1 year-->
      <TimeSpan5MinRecords unit="days">30</TimeSpan5MinRecords><!--1 month-->
      <TimeSpanSpectrumRecords unit="days">365</TimeSpanSpectrumRecords><!--1 year-->
      <TimeSpan unit="hours">24</TimeSpan>
  </Trending>
  ```

## Description.xml

If Swarming is not enabled, every element has its own *Description.xml* file. In that file, you can specify aliases for each of the parameters of that element.

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
