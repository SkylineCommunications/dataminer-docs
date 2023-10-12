---
uid: AdvancedDVEs
---

# Dynamic Virtual Elements

Suppose a protocol needs to be developed for a chassis that has a number of slots where cards of different types can be inserted. As it can be useful to have a DataMiner element for every card in the chassis, a protocol can be implemented in such a way that it can dynamically create an element for every card in the chassis: so-called Dynamic Virtual Elements (DVEs). This is only one use case illustrating the usefulness of DVEs. Many other use cases exist where DVEs can be useful.

A Dynamic Virtual Element (DVE) is an element that is dynamically created by a parent element. No data is stored for those elements; everything is managed by the parent element (hence the word virtual in DVE). The parent element is responsible for all communication with the DMS, and all parameters of the DVEs are derived from the parent element.

More information on DVEs is detailed in the following sections:

- <xref:AdvancedDVEsImplementation>
- <xref:AdvancedDVEsExportRules>
- <xref:AdvancedDVEsViews>
- <xref:AdvancedDVEsTimeoutState>
- <xref:AdvancedDVEsSeverityState>
- <xref:AdvancedDVEsTogglingCreation>
- <xref:AdvancedDVEsRemarks>
- <xref:AdvancedDVEsExercise>

> [!NOTE]
> An example protocol "SLC SDF DVE" is available in the [Protocol Development Guide Companion Files](https://community.dataminer.services/documentation/protocol-development-guide-companion-files/).

## See also

DataMiner Protocol Markup Language:

- [Protocol.Type](xref:Protocol.Type):
  - [options](xref:Protocol.Type-options)
  - [overrideTimeoutDVE](xref:Protocol.Type-overrideTimeoutDVE)
- [Protocol.ExportRules](xref:Protocol.ExportRules)
- [Protocol.Params.Param.ArrayOptions.ColumnOption@options](xref:Protocol.Params.Param.ArrayOptions.ColumnOption-options):
  - [element](xref:ColumnOptionOptionsOverview#element)
  - [severity](xref:ColumnOptionOptionsOverview#severity)

DataMiner Class Library:

- [NT_DVE_CREATION_FLAG (340)](xref:NT_DVE_CREATION_FLAG)

Coding guidelines:

- [DVE](xref:DVE)
