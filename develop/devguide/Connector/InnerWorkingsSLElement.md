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

- The parameter is a column parameter displayed in a table (i.e. included in the [Measurement](xref:Protocol.Params.Param.Measurement) tag of the table).

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
  - Reporter (legacy)
  - Dashboard
  - Spectrum Analyzer parameters (parameter ID > 64000)

- A method of the SLProtocol interface is called expecting the parameter to be present in the SLElement process:

  - NotifyProtocol type 168 method call ([NT_GET_INDEXES](xref:NT_GET_INDEXES))
  - NotifyDataMiner type 73 method call ([NT_GET_PARAMETER](xref:NT_GET_PARAMETER)) when called from SLDataMiner (protocol.NotifyDataMiner).
  - NotifyDataMiner type 106 method call ([NT_MAKE_ALARM](xref:NT_MAKE_ALARM))
  - GetKeys: In legacy DataMiner versions prior to DataMiner 9.0, retrieving the primary keys ([KeyType.Index](xref:Skyline.DataMiner.Scripting.NotifyProtocol.KeyType)) used the [NT_GET_INDEXES](xref:NT_GET_INDEXES) call. In the currently supported DataMiner versions, retrieving the primary keys using this method does not involve the SLElement process, but retrieving the display keys ([KeyType.DisplayKey](xref:Skyline.DataMiner.Scripting.NotifyProtocol.KeyType)) does still involve the SLElement process.
  - Prior to DataMiner 10.4.0 [CU15]/10.5.0 [CU3]/10.5.6<!-- RN 42368 -->, ClearAllKeys (SLProtocol), as the implementation of this method contains an NT_GET_INDEXES call. From DataMiner 10.4.0 [CU15]/10.5.0 [CU3]/10.5.6 onwards, instead a new NT_CLEAR_PARAMETER call is used, which eliminates the SLElement dependency.

- A property of the QActionTable class is called expecting the parameter to be present in the SLElement process:

  - Keys: The implementation of this property contains a GetKeys method call. Therefore the same remarks apply to this property as to the GetKeys method of the SLProtocol interface for retrieving the primary keys.
  - DisplayKeys: The implementation of this property contains a GetKeys method call.
  - In legacy DataMiner versions prior to DataMiner 9.0, retrieving the primary keys ([KeyType.Index](xref:Skyline.DataMiner.Scripting.NotifyProtocol.KeyType)) used the [NT_GET_INDEXES](xref:NT_GET_INDEXES) call. In the currently supported DataMiner versions, retrieving the primary keys using this method does not involve the SLElement process, but retrieving the display keys ([KeyType.DisplayKey](xref:Skyline.DataMiner.Scripting.NotifyProtocol.KeyType)) does still involve the SLElement process.

- A Notify type 87 (DMS_GET_PARAMETER) call of the DMS class is called retrieving the specified parameter.

## Column processing order in tables

The SLElement process processes the column values in the order it receives them from SLProtocol, as is defined in the protocol. However, there is also a default processing order:<!-- RN 28139 -->

1. Primary key
1. Display column
1. Foreign key(s)
1. Columns part of the naming or namingformat definition
1. Columns part of a conditional monitoring definition
1. Columns part of a threshold definition
1. Columns part of a property definition
1. Any other column (processed in the order defined in the table parameter)

Always keep the column processing order in mind when implementing tables. The following list provides an overview of situations where the column processing order may or may not be of concern:

- Custom tables (i.e. non-SNMP tables):

  - If you add/set the entire row at once: No problem can occur, not even if the columns that are part of the display key are defined after the columns that have monitoring support in the table.
  - If you add/set row data in multiple steps: In this case, you need to ensure that all the columns holding FKs and the columns that are part of the display key are set before setting any alarmed/trended column.

- SNMP tables without any additional custom columns: No problem can occur, no matter the order of the columns.

- SNMP tables with some custom/retrieved columns (where SNMP columns support trending/alarming and custom/retrieved columns are used as part of the display key or hold a FK):

  - If you use a QAction on the table with `row="true"` to fill in custom/retrieved columns, this is no problem as data is buffered in SLProtocol before anything is sent to SLElement.
  - If you use a QAction on the table without `row="true"` to fill in custom/retrieved columns, this is problematic as data is sent to SLElement before that QAction will go off.
  - If you use concatenation to fill in the columns that are part of the display key, this is no problem as data is buffered before data is sent to SLElement.

> [!NOTE]
> For a detailed overview of how SNMP tables are processed internally, see [How tables are processed internally](xref:ConnectionsSnmpProtocolInnterWorkings#how-tables-are-processed-internally).

The column processing order can be overruled in the protocol with the [processingOrder](xref:Protocol.Params.Param.ArrayOptions-options#processingorder) option.

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
