---
uid: AdvancedViewTablesSameElement
---

# View tables in the same element

It can happen that information of two tables needs to be available in a single table. For example, a table containing general information about elementary streams and another table containing only the bandwidth of these elementary streams can easily be combined into one table using the so-called view table functionality.

> [!NOTE]
>
> - View information is only updated when the card or data display is open.
> - No actions need to be implemented in the protocol to fill in the view table; this is done automatically.

To define a view table, start the name of the table with "View_" and make sure it is a volatile table (by specifying the [volatile](xref:Protocol.Params.Param.ArrayOptions-options#volatile) option on the ArrayOptions tag).

A view table always refers to another table, the so-called base table. This is done via the option [view](xref:Protocol.Params.Param.ArrayOptions-options#view) (e.g., `options=";volatile;view=200"`) of the ArrayOptions tag. In case the view table should also show data from other tables than this base table, the base table must contain columns that hold the foreign keys to these other tables.

The "view" option of the individual ColumnOption tags of the view table then specifies the column that should be shown. For example, `options=";view=201"` specifies that the data from column parameter 201 will be shown in this column of the view table.

The base table must contain foreign keys to another table in case the view should include data from the other table. To include a column in a view table from another table than the base table, the view option must specify the path to that specific column, starting from the foreign key column parameter ID of the base table. For example, `view=203:105` specifies that column 203 of the base table contains foreign keys to table 100 and that the data of the column with ID 105 of table 100 should be shown in this view table column.

The following example illustrates the definition of a view table that refers to a base table with ID 200.

```xml
<!-- This is a ViewTable with the lst, 2nd, 3rd, 4th columns from table 200 and 4th and 5th columns from table 100. The Foreign Key from table 200 to table 100 is on column 203. -->
<Param id="500">
  <Name>View_Services</Name>
  <Description>View_Services</Description>
  <Type>array</Type>
  <ArrayOptions index="0" options=";volatile;view=200">
     <ColumnOption idx="0" pid="501" type="custom" options=";view=201" /><!-- ID -->
     <ColumnOption idx="1" pid="502" type="custom" options=";view=202" /><!-- Name -->
     <ColumnOption idx="2" pid="503" type="custom" options=";view=204" /><!-- Category -->
     <ColumnOption idx="3" pid="504" type="custom" options=";view=205" /><!-- Status -->
     <ColumnOption idx="4" pid="505" type="custom" options=";view=203:104" /><!-- Stream Transport Protocol -->
     <ColumnOption idx="5" pid="506" type="custom" options=";view=203:105" /><!-- Stream Type -->
  </ArrayOptions>
  <Information>
     <Subtext>The list of services.</Subtext>
  </Information>
</Param>
```

Below is an example of a base table. Note that as the view table will show data from another table (table 100), the base table needs to include a column that holds foreign keys to this table (column parameter 203 in this example).

```xml
<Param id="200">
  <Name>Services</Name>
  <Description>Services</Description>
  <Type>array</Type>
  <ArrayOptions index="0" options="">
     <ColumnOption idx="0" pid="201" type="retrieved" /><!-- ID -->
     <ColumnOption idx="1" pid="202" type="retrieved" /><!-- Name -->
     <ColumnOption idx="2" pid="203" type="retrieved" options=";foreignKey=100" /><!-- Stream ID -->
     <ColumnOption idx="3" pid="204" type="retrieved" /><!-- Category -->
     <ColumnOption idx="4" pid="205" type="retrieved" /><!-- Status -->
     <ColumnOption idx="5" pid="206" type="retrieved" /><!-- Has CA -->
     <ColumnOption idx="6" pid="207" type="retrieved" /><!-- Bandwidth -->
     <ColumnOption idx="7" pid="208" type="retrieved" /><!-- Min Bandwidth -->
     <ColumnOption idx="8" pid="209" type="retrieved" /><!-- Max Bandwidth -->
  </ArrayOptions>
  <Information>
     <Subtext>The list of service.</Subtext>
  </Information>
  <Display>
      <RTDisplay>true</RTDisplay>
  </Display>
  ...
</Param>
```

For a view table it is not necessary to define the individual column parameters of the view table as is done for regular tables. Instead, the column parameters of the base table (or linked table) that are duplicated in the view table must have a [duplicateAs](xref:Protocol.Params.Param-duplicateAs) attribute defined. This attribute then defines the column(s) of the view table(s) that will correspond with this column.

For example, the column parameter with ID 201 of the base table will be included in the view table. Therefore, the definition of column parameter 201 includes the duplicateAs parameter and its value is set to 501 (i.e., the column parameter ID of the view table that will hold the data of this column).

```xml
<Param id="201" duplicateAs="501">
  <Name>ServiceId</Name>
  <Description>Service ID</Description>
  <Information>
     <Subtext>The ID of the service.</Subtext>
  </Information>
  <Type>read</Type>
  <Interprete>
     <RawType>other</RawType>
     <Type>string</Type>
     <LengthType>next param</LengthType>
   </Interprete>
  <Display>
     <RTDisplay>true</RTDisplay>
  </Display>
  <Measurement>
     <Type>string</Type>
  </Measurement>
</Param>
```

Note that a parameter can be duplicated multiple times using a comma as separator in the duplicateAs attribute:

```xml
<Param id="202" duplicateAs="502,605">
  <Name>ServiceName</Name>
  <Description>Service Name</Description>
  <Information>
     <Subtext>The name of the service.</Subtext>
  </Information>
  <Type>read</Type>
  <Interprete>
     <RawType>other</RawType>
     <Type>string</Type>
     <LengthType>next param</LengthType>
   </Interprete>
  <Display>
     <RTDisplay>true</RTDisplay>
  </Display>
  <Measurement>
     <Type>string</Type>
  </Measurement>
</Param>
```

In case the base table (or a linked table) has a parameter of type "write" corresponding to a parameter of type "read" that is included in the view table, the write parameter will not be visible in the view table.

In case the write parameter should also be present for the view table, you only need to specify the duplicateAs attribute on the existing write parameter that will perform the set. The value of the duplicateAs attribute is then set to a column parameter ID that is reserved for the corresponding write parameter on the view.

```xml
<Param id="212" setter="true" duplicateAs="512">
  <Name>ServiceName</Name>
  <Description>Service Name</Description>
  <Type>write</Type>
  <Interprete>
     <RawType>other</RawType>
     <Type>string</Type>
     <LengthType>next param</LengthType>
   </Interprete>
  <Display>
     <RTDisplay>true</RTDisplay>
  </Display>
  <Measurement>
     <Type>string</Type>
  </Measurement>
</Param>
```

Why does this work with a randomly chosen unique parameter ID? Consider the following example:

```xml
<Param id="3190" duplicateAs="4190">
   <Name>StreamActiveChannel</Name>
   <Description>Stream Active Channel</Description>
  <Type>write</Type>
```

In the background, DataMiner translates the original parameter name/description to "1_Stream Active Channel" for the duplicate parameter to have a unique parameter description. DataMiner Cube filters this "1_" out before displaying the parameter name. If there was a second parameter ID specified in the duplicateAs attribute, then this would have prefix "2_". In case the duplicateAs attribute of the write parameter does not specify a parameter ID, this means that no "1_" write parameter is created that matches the "1_" read parameter, so no write parameter is displayed for the duplicated read parameter.

So in case there are two view tables and there should only be a write parameter on one table view, in the duplicateAs attribute of the read parameter, first specify the parameter ID that should have a write parameter and then the parameter ID without write parameter; on the write parameter specify only one duplicateAs parameter ID.

For example:

```xml
<Param id="3127" duplicateAs="4127,5127">
   <Name>StreamActiveChannel</Name>
   <Description>Stream Active Channel</Description>
   <Type>read</Type>
  ...
<Param id="3190" duplicateAs="4190">
   <Name>StreamActiveChannel</Name>
   <Description>Stream Active Channel</Description>
   <Type>write</Type>
  ...
```

The result of this will be that parameter 4127 has a write control and parameter 5127 has no write control displayed in the table view.

To process the parameter value that the operator enters on the table view write parameter, just create a QAction triggering on the original parameter ID (not the duplicateAs parameter ID) with the option "row" set to "true".

Depending on the DataMiner version, the following functionality is available:

- You can disable updates in view tables and partial subscriptions using the option disableViewRefresh: `<Type options="disableViewRefresh" />`.
- View tables containing a column with view options like "view=:x:y:z" or "view=a:b:c:z" allow that column to be filtered by means of a "VALUE=" filter (e.g., VALUE=5 == abc). Combining filters with AND or OR is not supported.<!-- RN 30237 --> These filters can also be used to filter on a column of a view table that refers to a column of another view table.<!-- RN 30809 -->

  > [!NOTE]
  > When a direct view table links to a view table with remote columns (i.e., view=:x:y:z), it is not yet possible to filter on those columns.
