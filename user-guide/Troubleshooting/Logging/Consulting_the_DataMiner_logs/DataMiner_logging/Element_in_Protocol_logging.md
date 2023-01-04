---
uid: Element_in_Protocol_logging
---

# Element in Protocol logging

The *Element in Protocol* log file allows you to map all the running elements on a DMA to the protocol processes they use. This can be very useful to investigate protocol thread run-time errors.

## Element in Protocol log entries

An entry in the *Element in Protocol* log file can for instance look like this:

```txt
2021/02/22 08:01:52|101/184|Comstream Radyne Ku DC|11132|Comstream Radyne SFC4200A-B8-P8|Production|1.0.0.2|7952
```

This record contains the following information, separated by pipe characters:

- Date and time, in the format "Year/Month/Day Hour:Minutes:Seconds"
- DataMiner element ID, in the format DataMiner ID/Element ID
- DataMiner element name
- Protocol process ID
- DataMiner protocol name
- Selected protocol version, e.g. Production
- Linked protocol version e.g. 1.0.0.2
- Scripting process ID

When a DMA starts up, the list of elements is added to the file, after a separator line consisting of asterisk signs. For example:

```txt
2021/02/20 16:53:28|101/3|Example SNMP - Stand Alone|13552|Example SNMP|1.0.0.1|1.0.0.1|13572
2021/02/20 16:53:29|101/164|{ Verimatrix RTES Pair test.Primary }|13684|Verimatrix RTES Pair - DVE|2.0.1.15|2.0.1.15|13572
***********************
2021/02/22 08:01:52|101/190|CPI 4940L Ku UC|11132|CPI 4940L|1.0.0.2|1.0.0.2|7952
2021/02/22 08:01:52|101/151|smart serial 1header- Simulator|8032|Best Practice - Generic Server|Production|1.0.0.9|7952
```

When a DataMiner element starts up, a new line is added to indicate the new protocol process that is used. For example:

```txt
2021/02/23 12:06:39|101/193|Envivio Caster|11212|Envivio 4Caster C4 2|2.1.0.1|2.1.0.1|7952
2021/02/23 12:55:54|101/193|Envivio Caster|8032|Envivio 4Caster C4 2|2.1.0.1|2.1.0.1|7952
```

> [!NOTE]
> As each element restart generates a new entry in this log file, you should look for the latest item in the file to know which protocol process is used. As such, you should always search through this file from bottom to top.

## Accessing Element in Protocol logging

There are two ways to consult the Element in Protocol logging:

- In DataMiner Cube, go to *System Center > Logging > DataMiner*, select the DMA for which you want to see the logging, and select *Element in Protocol* in the list of files on the left.
- On the DMA, go to the folder `C:\Skyline DataMiner\Logging` and open the file *SLElementInProtocol.txt*.

![Element in Protocol logging in DataMiner Cube (version 10.1.0)](~/user-guide/images/element-in-protocol-logging-1024x447.png)<br>
*Element in Protocol logging in DataMiner Cube (version 10.1.0)*

## Useful links

- [DataMiner logging](xref:DataMiner_logging)
- [Investigating a protocol thread RTE](xref:Investigating_a_protocol_thread_RTE)
