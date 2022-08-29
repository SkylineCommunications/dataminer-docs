---
uid: Defining_connectivity_chains_in_XML_files
---

# Defining connectivity chains in XML files

Connectivity chains can be configured in a number of *Connectivity.xml* files in the folder *C:\\Skyline DataMiner\\Connectivity*. These files help the DCF engine to determine whether a particular connection is part of the active path. A connection that would by default be considered part of the active path can be included or excluded based on the link and mapping information in the files.

The general *Connectivity.xml* file in the main *C:\\Skyline DataMiner\\Connectivity* folder is used for connectivity in redundancy groups and services. There can also be several subfolders in this main folder, each containing another *Connectivity.xml* file, which represent prototype chains of different connected elements in a system.

- [General Connectivity.xml file](xref:General_Connectivity_xml_file)

- [Connectivity.xml files representing chains](xref:Connectivity_xml_files_representing_chains)

- [Automatically generating service RCA chains based on connectivity](xref:Automatically_generating_service_RCA_chains_based_on_connectivity)

> [!NOTE]
>
> - The *C:\\Skyline DataMiner\\Connectivity* folders on the different DataMiner Agents are automatically synchronized in a DataMiner system. However, if you do not want to wait for the automatic synchronization and instead want to implement a change throughout the DMS immediately, you can force a DMA to synchronize with the DMS. See [Synchronizing data between DataMiner Agents](xref:Synchronizing_data_between_DataMiner_Agents).
> - Connectivity is included in default backup schemes. However, if you take a backup using a custom backup scheme, you will need to explicitly include *Connectivity settings*.
