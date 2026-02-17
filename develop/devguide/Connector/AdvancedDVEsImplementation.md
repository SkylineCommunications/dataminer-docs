---
uid: AdvancedDVEsImplementation
---

# Implementing DVE functionality

To implement DVE functionality, the following steps must be performed:

1. A DVE will always correspond to a row in a table defined in the protocol. To specify that a table should generate DVEs, the protocol must specify which table generates DVEs.

    Note that multiple tables can be defined in a protocol each generating DVEs. For every table that generates DVEs, a protocol is automatically derived from the parent protocol. Therefore, when defining which tables will generate DVEs, the names of the corresponding generated DVE protocols must be provided. For more info, refer to the “exportProtocol” option in the section options.

    Just like regular protocols, the automatically generated DVE protocol(s) can be found in the C:\Skyline DataMiner\Protocols\[DVE Protocol Name]\ folder.

1. The table(s) that will generate DVEs must contain a column that uses the [element](xref:ColumnOptionOptionsOverview#element) option. This column will then automatically be filled in by DataMiner with the global element ID ("DMA/element ID") of the corresponding DVEs.

1. Every DVE table will result in the generation of a corresponding DVE protocol. The content of this DVE protocol is defined by exporting parameters of the parent protocol. For example, in case a parameter defined in the main protocol should also be included in the DVE protocol, set the [export](xref:Protocol.Params.Param-export) attribute value to "true". In case multiple DVE tables are defined, set the export attribute to the table ID(s) where the parameter should be included.

    Exporting columns of the DVE table to the corresponding DVE protocol will result in standalone parameters. It is also possible to export referenced tables. Note that in this case the table must be linked to the DVE table (See [Foreign keys](xref:UIComponentsTableForeignKeys) and [Relations](xref:UIComponentsTableRelations)).

For example, suppose a protocol contains a table (ID: 1000) that will generate DVEs (i.e., the protocol defines that table 1000 generates DVEs). In the DVE table, the columns "X", "Y" and "Z" are exported and the column "DVE ID" has the option "element". In addition, the protocol contains another table (ID: 2000) that is linked to the DVE table. This table is also exported.

![A table linked to a DVE table](~/develop/images/Advanced_Topics_-_DVE_concept.svg)

The DVE generated for the first row in the DVE table will look like this:

![Resulting DVE layout](~/develop/images/Advanced_Topics_-_DVE_concept_-_result.svg)

When implementing DVE functionality, keep the following in mind:

- The DVE element name is based on either the primary key or the display key of the corresponding row in the DVE table. Therefore, it is important to fill in this column before any other data.
- Alarm descriptions use the primary key or display key. This information must be available before any other cells are set that can cause an alarm.
- Consequently, for SNMP tables it can occur that you need to copy data in a custom table.
