---
uid: InnerWorkingsSLElement
---

# SLElement

## RTDisplay

The SLElement process keeps track of parameters that have to be shown to the user and creates alarms. The SLProtocol process will push all parameters with RTDisplay set to true to the SLElement process.

A parameter requires that RTDisplay is set to true in the following cases:

- The parameter is displayed on a page.
- The parameter has alarm or trending support.
  > [!NOTE]
  > Parameters with alarm or trending support should be displayed on a page.
- The parameter is a column parameter displayed in a table (i.e. included in the Measurement tag of the table).
- The parameter is a table parameter used in a tree control.
- The parameter is an exported parameter of a DVE and requires RTDisplay to be set to true.
- The parameter holds a dynamic list referred to by another parameter.
- The parameter is a context menu parameter.
- The parameter is used in alarm properties.
- The parameter is referred to by the web interface URL.
- The parameters type tag includes the virtual attribute, and the parameter acts as a source.
- The parameter needs to be available for an external source:
  - Other element
  - Visio
  - (Interactive) Automation script
  - Reporter
  - Dashboard
  - Spectrum Analyzer parameters (parameter ID > 64000)
- A method of the SLProtocol interface is called expecting the parameter to be present in the SLElement process:
  - NotifyProtocol type 168 method call ("NT_GET_INDEXES")
  - NotifyDataMiner type 73 method call ("NT_GET_PARAMETER") when called from SLDataMiner (protocol.NotifyDataMiner).
  - NotifyDataMiner type 106 method call ("NT_MAKE_ALARM")
  - GetKeys: Prior to DataMiner version 9.0, retrieving the primary keys (KeyType.Index) used the NT_GET_INDEXES call. Since DataMiner version 9.0, retrieving the primary keys using this method no longer involves the SLElement process. However, retrieving the display keys (KeyType.DisplayKey) still involves the SLElement process.
  - ClearAllKeys (SLProtocol) as the implementation of this method contains an NT_GET_INDEXES call.
- A property of the QActionTable class is called expecting the parameter to be present in the SLElement process:
  - Keys: The implementation of this property contains a GetKeys method call. Therefore the same remarks apply to this property as to the GetKeys method of the SLProtocol interface for retrieving the primary keys.
  - DisplayKeys: The implementation of this property contains a GetKeys method call.
  - Prior to DataMiner version 9.0, retrieving the primary keys (KeyType.Index) used the NT_GET_INDEXES call. Since DataMiner version 9.0, retrieving the primary keys using this method no longer involves the SLElement process. However, retrieving the display keys (KeyType.DisplayKey) still involves the SLElement process.
- A Notify type 87 (DMS_GET_PARAMETER) call of the DMS class is called retrieving the specified parameter.

## Column processing order in tables

The SLElement process processes the column values in the order it receives them from SLProtocol, as is defined in the protocol. However, there is also a default processing order:

- From DataMiner 7.5 onwards, the default processing order is as follows:
  1. Primary key
  1. Column referred to by the displayColumn attribute
  1. Foreign key(s)
  1. Local naming parameters
  1. Other parameters
- From DataMiner 9.0.0 (RN 11582) onwards, the default processing order is extended:
  1. Primary key
  1. Display key
  1. Foreign key(s)
  1. Local naming parameters ID(s)
  1. Property parameter ID(s) used as a source for alarm properties
  1. Other parameter ID(s)
  1. Parameter ID(s) to which conditions have been applied
  > [!NOTE]
  > This extended processing order among others avoids issues with alarm properties not being filled in correctly in tables.
- From DataMiner 10.1.1 (RN 28139) onwards, the default processing order is extended:
  1. Primary key
  1. Display column
  1. Foreign key(s)
  1. Columns part of the naming or namingformat definition
  1. Columns part of a conditional monitoring definition
  1. Columns part of a threshold definition
  1. Columns part of a property definition
  1. Any other column (processed in the order defined in the table parameter)

  The result is that the processing order of columns is extended so that columns that are part of a threshold option (see Options) within the same table definition get processed before columns that are part of a property definition and any other columns.

Always keep the column processing order in mind when implementing tables. The following list provides an overview of situations where the column processing order may or may not be of concern:

- Custom tables (i.e. non-SNMP tables):
  - If you add/set the entire row at once: No problem can occur, not even if the columns that are part of the display key are defined after the columns that have monitoring support in the table.
  - If you add/set row data in multiple steps: In this case, you need to ensure that all the columns holding FKs and the columns that are part of the display key are set before setting any alarmed/trended column.
- SNMP tables without any additional custom columns: No problem can occur, no matter the order of the columns.
- SNMP tables with some custom/retrieved columns (where SNMP columns support trending/alarming and custom/retrieved columns are used as part of the display key or hold a FK):
  - If you use a QAction on the table with row="true" to fill in custom/retrieved columns => no problem since data is buffered in SLProtocol before anything is sent to SLElement.
  - If you use a QAction on the table without row="true" to fill in custom/retrieved columns => problematic since data is sent to SLElement before that QAction will go off.
  - If you use concatenation to fill in the columns that are part of the display key => no problem since data is buffered before data is sent to SLElement.

> [!NOTE]
> For a detailed overview of how SNMP tables are processed internally, see How tables are processed internally.

The column processing order can be overruled in the protocol with the processingOrder option in the ArrayOptions options attribute.

> [!NOTE]
> Customizing the column processing order is not recommended.

```xml
<Param id="400" trending="false" export="true">
  <Name>Alarm Table</Name>
  <Description>Alarm Table</Description>
  <Type>array</Type>
  <ArrayOptions index="0" options=";naming=_401,404;processingOrder=0,4,5,1,2,3">
     <ColumnOption idx="0" pid="401" type="custom" options=";save"/>
     <ColumnOption idx="1" pid="403" type="custom" options=";save"/>
     <ColumnOption idx="2" pid="404" type="custom" options=";save"/>
     <ColumnOption idx="3" pid="406" type="custom" options=";save"/>
     <ColumnOption idx="4" pid="416" type="custom" options=";save;foreignKey=1200"/>
     <ColumnOption idx="5" pid="417" type="custom" options=";save;foreignKey=1300"/>
  </ArrayOptions>
  <Interprete>
     <RawType>other</RawType>
     <LengthType>next param</LengthType>
     <Type>double</Type>
  </Interprete>
  <Measurement>
     <Type options="tab-columns:401|0-403|1-404|2-406|3-416|4-417|5,lines:30,width:100-100-100-100-100-100,sort:STRING">table</Type>
  </Measurement>
</Param>
```

## See also

- [processingOrder](xref:Protocol.Params.Param.ArrayOptions-options#processingorder)
