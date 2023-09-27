---
uid: SLNetClientTest_generating_mib_files
---

# Generating SMIv2 MIB files

From DataMiner 10.0.9 onwards, it is possible to generate SMIv2 MIB files for SNMP managers using custom bindings. This is only supported for SNMP managers of type SNMPv2 and SNMPv3. Exporting such a file can for instance be of use in case you want to integrate an SNMP manager with custom bindings into a third-party system.

> [!NOTE]
> From DataMiner 10.0.10 onwards, you can export the MIB file directly from the Cube user interface using the *Generate MIB file* button below the custom bindings in the SNMP manager configuration. This method of exporting the file is recommended over the use of the SLNetClientTest tool.

To generate such a MIB file:

1. [Connect to the DMA using the SLNetClientTest tool](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool).

1. Go to *Advanced* > *Tests* > *Generate MIB for SNMP Manager*.

1. In the pop-up window, select an SNMP manager and click *Generate*.

1. In the dialog box, browse to where you want to save the MIB file, optionally customize the file name, and click *Save*.

> [!WARNING]
> Always be extremely careful when using the SLNetClientTest tool, as it can have far-reaching consequences on the functionality of your DataMiner System.
