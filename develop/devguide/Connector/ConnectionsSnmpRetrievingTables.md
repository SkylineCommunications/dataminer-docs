---
uid: ConnectionsSnmpRetrievingTables
description: An overview of the different methods that are available for retrieving tables via SNMP in a protocol.
---

# Retrieving tables

Tables in a MIB are structured as illustrated below. There is always a table folder, followed by an entry folder containing the column parameters.

![MIB table structure](~/develop/images/iftable.png)

In a protocol, a table is implemented using a parameter representing the table (of type "array") and additional parameters for each column in the table. By adding `<SNMP>` tags that include the appropriate `<OID>` definitions, the table and its columns are mapped to the corresponding SNMP table and column OIDs, enabling SNMP polling similar to polling single variables.

## Retrieval methods

A protocol can retrieve SNMP tables using various methods. The preferred method is specified on the table parameter by setting the options attribute within the <OID> tag. Only one retrieval method can be configured per table. The following sections describe each available method:

* **[GetNext](#getnext):**
  Fetches each cell individually using SNMP **GetNext** requests.

* **[GetNext + MultipleGet](#getnext--multipleget):**
  Uses **GetNext** requests to fetch the instance identifier of each row individually. Then, **Get** requests are used to fetch multiple cells at once, proceeding column by column, only moving to the next column when all cells have been fetched.

* **[GetNext + MultipleGet by Row](#getnext--multipleget-by-row):**
  Similar to the previous method, but proceeding row by row, only moving to the next row when all cells have been fetched.

* **[MultipleGetNext](#multiplegetnext):**
  Uses **GetNext** requests to fetch all column values for one row at a time.

* **[MultipleGetBulk](#multiplegetbulk):**
  Uses **GetBulk** requests to fetch all column values for multiple rows at a time.

> [!NOTE]
> The [Protocol Development Guide Companion Files](https://community.dataminer.services/documentation/protocol-development-guide-companion-files/) include the following [Wireshark](xref:Wireshark) captures to help understand the different retrieval methods:
>
> - GetNext.pcap
> - GetNext+MultipleGet.pcap
> - MultipleGetNext.pcap
> - MultipleGetBulk.pcap
> - MultipleGetBulkMaxRep2.pcap.
> - Additionally, the companion files also include example protocols for each table retrieval method.
>
> An example protocol "SLC SDF SNMP - Tables" is also available in the companion files.

### Recommendation

In general, the more messages required to retrieve a table, the longer the process will take. To optimize performance and compatibility, and to minimize the risk of [index shift issues](#index-shift-issues-during-polling), follow this guidance when selecting a retrieval method:

* **Start with MultipleGetBulk**, as it typically offers the best performance.
* If the device does **not support SNMPv2**, fall back to **MultipleGetNext**.
* If the device cannot handle **MultipleGetNext** due to memory or processing limitations, try **GetNext + MultipleGet by Row**.
* If issues persist, **reduce the number of cells to retrieve** to lessen the burden on the device.
* Only use **GetNext + MultipleGet** if required by specific features.
* Avoid using **GetNext** due to poor performance and because you cannot as freely select which columns to poll.

### GetNext

Fetches each cell individually using SNMP GetNext requests.

![GetNext execution](~/develop/images/Interfaces_Table_GetNext.png)

With the **GetNext** method, you cannot explicitly select which columns to poll by specifying column OIDs. Only the table OID is used, and any OIDs defined on column parameters will be ignored. You can define a protocol table with fewer columns than exist in the SNMP table, but the columns must be defined in a continuous, ordered sequence starting from the first column. Skipping columns or defining them out of order is not supported. For example, if the SNMP table has eight columns, you may define only the first three, but you cannot define just the first and third columns while omitting the second.

> [!NOTE]
> Since version 10.4.0 \[CU10\]/10.5.0 \[CU0\]/10.5.1, **GetNext** only retrieves the columns defined in your protocol table. In earlier versions, all columns were polled, but only defined columns were displayed.<!-- RN 41235 -->

#### Example

```xml
<Param id="1000">
    <Name>Interfaces</Name>
    <Description>Interfaces</Description>
    <Type>array</Type>
    <ArrayOptions index="0">
        <ColumnOption idx="0" pid="1001" type="snmp" options="" />
        <ColumnOption idx="1" pid="1002" type="snmp" options="" />
        ...
    </ArrayOptions>
    <SNMP>
        <Enabled>true</Enabled>
        <OID type="complete">1.3.6.1.2.1.2.2</OID>
    </SNMP>
</Param>
<Param id="1001" trending="false">
    <Name>InterfacesIndex</Name>
    <Description>Instance [IDX] (Interfaces)</Description>
    <Type>read</Type>
    <Interprete>
        <RawType>other</RawType>
        <Type>string</Type>
        <LengthType>next param</LengthType>
    </Interprete>
</Param>
<Param id="1002" trending="false">
    <Name>InterfacesName</Name>
    <Description>Name (Interfaces)</Description>
    <Type>read</Type>
    <Interprete>
        <RawType>other</RawType>
        <Type>string</Type>
        <LengthType>next param</LengthType>
    </Interprete>
</Param>
```

> [!IMPORTANT] When using the **GetNext** method, it is mandatory to specify the table OID on the table parameter. Do not specify OIDs on the column parameters, as these will be ignored.

SNMP Communication Flow:

- The initial request is an SNMP get next request with the OID of ifEntry (1.3.6.1.2.1.2.2.1). This returns the content of 1.3.6.1.2.1.2.2.1.1 (first row, first column).
- In versions prior to 10.4.0 [CU10]/10.5.0 [CU0]/10.5.1, additional get next requests were performed until the OID in the response exceeds the table OID range. In versions 10.4.0 [CU10]/10.5.0 [CU0]/10.5.1 or above, get next requests are performed until the values of the defined column parameters are retrieved or, in case the number of defined columns exceeds the number of column values, until the table OID range is exceeded.

### GetNext + MultipleGet

Uses GetNext requests to fetch the index of each row individually. Then, Get requests are used to fetch multiple cells at once, proceeding column by column, only moving to the next column when all cells have been fetched. If the configured size is large enough, multiple columns (or part of the next column) can be included in a single request.

![GetNext + MultipleGet execution](~/develop/images/Interfaces_Table_GetNext_MultipleGet.png)

To use this polling method, add `bulk` to the `options` attribute of the table parameter's `OID` tag. You can specify the number of cells to retrieve per request by adding a value after `bulk` (e.g., `bulk:10`). If no value is provided, the default is 50.

#### Example

```xml
<Param id="1000">
    <Name>Interfaces</Name>
    <Description>Interfaces</Description>
    <Type>array</Type>
    <ArrayOptions index="0">
        <ColumnOption idx="0" pid="1001" type="snmp" options="" />
        <ColumnOption idx="1" pid="1002" type="snmp" options="" />
        ...
    </ArrayOptions>
    <SNMP>
        <Enabled>true</Enabled>
        <OID type="complete" options=";bulk:3"></OID>
    </SNMP>
</Param>
<Param id="1001" trending="false">
    <Name>InterfacesIndex</Name>
    <Description>Instance [IDX] (Interfaces)</Description>
    <Type>read</Type>
    <Interprete>
        <RawType>other</RawType>
        <Type>string</Type>
        <LengthType>next param</LengthType>
    </Interprete>
    <SNMP>
        <Enabled>true</Enabled>
        <OID type="complete">1.3.6.1.2.1.2.2.1.1</OID>
        <Type>Integer32</Type>
    </SNMP>
</Param>
<Param id="1002" trending="false">
    <Name>InterfacesName</Name>
    <Description>Name (Interfaces)</Description>
    <Type>read</Type>
    <Interprete>
        <RawType>other</RawType>
        <Type>string</Type>
        <LengthType>next param</LengthType>
    </Interprete>
    <SNMP>
        <Enabled>true</Enabled>
        <OID type="complete">1.3.6.1.2.1.2.2.1.2</OID>
        <Type>octetstring</Type>
    </SNMP>
</Param>
```

SNMP Communication Flow:

- Get next requests are performed to obtain the number of rows using the instance, starting with the OID of ifEntry (1.3.6.1.2.1.2.2.1). Once the number of rows is known, one or more get requests (with multiple variable bindings) are performed to obtain all the cells in the table.
- Rows can disappear while the table is being retrieved. If this happens, the retrieved table can get mixed up because the data was retrieved block by block. If a row was deleted during a retrieval process, it is possible that, for example, the first block contains 5 rows, while the second block only contains 4 rows.

### GetNext + MultipleGet by Row

Uses GetNext requests to fetch the index of each row individually. Then, Get requests are used to fetch multiple cells at once, proceeding row by row, only moving to the next row when all cells have been fetched. If the configured size is large enough, multiple rows (or part of the next row) can be included in a single request.

To use this polling method, add `multipleGet` to the `options` attribute of the table parameter's `OID` tag. You can specify the number of cells to retrieve per request by adding a value after `multipleGet` (e.g., `multipleGet:10`). If no value is provided, the default is 10.

#### Example

```xml
<Param id="1000">
    <Name>Interfaces</Name>
    <Description>Interfaces</Description>
    <Type>array</Type>
    <ArrayOptions index="0">
        <ColumnOption idx="0" pid="1001" type="snmp" options="" />
        <ColumnOption idx="1" pid="1002" type="snmp" options="" />
        ...
    </ArrayOptions>
    <SNMP>
        <Enabled>true</Enabled>
        <OID type="complete" options=";multipleGet:3"></OID>
    </SNMP>
</Param>
<Param id="1001" trending="false">
    <Name>InterfacesIndex</Name>
    <Description>Instance [IDX] (Interfaces)</Description>
    <Type>read</Type>
    <Interprete>
        <RawType>other</RawType>
        <Type>string</Type>
        <LengthType>next param</LengthType>
    </Interprete>
    <SNMP>
        <Enabled>true</Enabled>
        <OID type="complete">1.3.6.1.2.1.2.2.1.1</OID>
        <Type>Integer32</Type>
    </SNMP>
</Param>
<Param id="1002" trending="false">
    <Name>InterfacesName</Name>
    <Description>Name (Interfaces)</Description>
    <Type>read</Type>
    <Interprete>
        <RawType>other</RawType>
        <Type>string</Type>
        <LengthType>next param</LengthType>
    </Interprete>
    <SNMP>
        <Enabled>true</Enabled>
        <OID type="complete">1.3.6.1.2.1.2.2.1.2</OID>
        <Type>octetstring</Type>
    </SNMP>
</Param>
```

### MultipleGetNext

Uses GetNext requests to fetch all column values for one row at a time.

![MultipleGetNext execution](~/develop/images/Interfaces_Table_MultipleGetNext.png)

To use this polling method, add `multipleGetNext` to the `options` attribute of the table parameter's `OID` tag.

#### Example

```xml
<Param id="1000">
    <Name>Interfaces</Name>
    <Description>Interfaces</Description>
    <Type>array</Type>
    <ArrayOptions index="0">
        <ColumnOption idx="0" pid="1001" type="snmp" options="" />
        <ColumnOption idx="1" pid="1002" type="snmp" options="" />
        ...
    </ArrayOptions>
    <SNMP>
        <Enabled>true</Enabled>
        <OID type="complete" options=";multipleGetNext"></OID>
    </SNMP>
</Param>
<Param id="1001" trending="false">
    <Name>InterfacesIndex</Name>
    <Description>Instance [IDX] (Interfaces)</Description>
    <Type>read</Type>
    <Interprete>
        <RawType>other</RawType>
        <Type>string</Type>
        <LengthType>next param</LengthType>
    </Interprete>
    <SNMP>
        <Enabled>true</Enabled>
        <OID type="complete">1.3.6.1.2.1.2.2.1.1</OID>
        <Type>Integer32</Type>
    </SNMP>
</Param>
<Param id="1002" trending="false">
    <Name>InterfacesName</Name>
    <Description>Name (Interfaces)</Description>
    <Type>read</Type>
    <Interprete>
        <RawType>other</RawType>
        <Type>string</Type>
        <LengthType>next param</LengthType>
    </Interprete>
    <SNMP>
        <Enabled>true</Enabled>
        <OID type="complete">1.3.6.1.2.1.2.2.1.2</OID>
        <Type>octetstring</Type>
    </SNMP>
</Param>
```

SNMP Communication Flow:

- Get next requests are performed (where the variable bindings in the request correspond with all the columns defined in the protocol table) until all rows are retrieved. One row is retrieved at a time.
- Note that using this method no data will be missing.

### MultipleGetBulk

Uses GetBulk requests to fetch all column values for multiple rows at a time.

![MultipleGetBulk execution](~/develop/images/Interfaces_Table_multipleGetBulk.png)

To use this polling method, add `multipleGetBulk` to the `options` attribute of the table parameter's `OID` tag. You can specify the number of rows to retrieve per request by adding a value after `multipleGetBulk` (e.g., `multipleGetBulk:10`). If no value is provided, the default is 10.

#### Example

```xml
<Param id="1000">
    <Name>Interfaces</Name>
    <Description>Interfaces</Description>
    <Type>array</Type>
    <ArrayOptions index="0">
        <ColumnOption idx="0" pid="1001" type="snmp" options="" />
        <ColumnOption idx="1" pid="1002" type="snmp" options="" />
        ...
    </ArrayOptions>
    <SNMP>
        <Enabled>true</Enabled>
        <OID type="complete" options=";multipleGetBulk:3"></OID>
    </SNMP>
</Param>
<Param id="1001" trending="false">
    <Name>InterfacesIndex</Name>
    <Description>Instance [IDX] (Interfaces)</Description>
    <Type>read</Type>
    <Interprete>
        <RawType>other</RawType>
        <Type>string</Type>
        <LengthType>next param</LengthType>
    </Interprete>
    <SNMP>
        <Enabled>true</Enabled>
        <OID type="complete">1.3.6.1.2.1.2.2.1.1</OID>
        <Type>Integer32</Type>
    </SNMP>
</Param>
<Param id="1002" trending="false">
    <Name>InterfacesName</Name>
    <Description>Name (Interfaces)</Description>
    <Type>read</Type>
    <Interprete>
        <RawType>other</RawType>
        <Type>string</Type>
        <LengthType>next param</LengthType>
    </Interprete>
    <SNMP>
        <Enabled>true</Enabled>
        <OID type="complete">1.3.6.1.2.1.2.2.1.2</OID>
        <Type>octetstring</Type>
    </SNMP>
</Param>
```

> [!NOTE]
>
> - Choose the number of rows per request carefully to avoid SNMP responses that exceed the network Path MTU. Large responses may be fragmented, which can reduce reliability. For typical Ethernet networks, keep SNMP responses under 1472 bytes (plus 8 bytes for the UDP header and 20 bytes for the IPv4 header, totaling 1500 bytes). For more details, see [RFC 3416, section 2.3](https://www.rfc-editor.org/rfc/rfc3416.html#section-2.3).
> - The GetBulk request is only available in SNMPv2 and later. This method is not supported on SNMPv1 devices.

SNMP Communication Flow:

- Get bulk requests are performed until all data is retrieved.
- The max-repetitions field indicates how many rows will be retrieved per request. In DataMiner, you can define this field by specifying a number after the "multipleGetBulk" option. E.g multipleGetBulk:5.  

### Index Shift Issues During Polling

SNMP table indexes are often based on sequential numbers (e.g., `1`, `2`, `3`, ...). When a row is added or removed from such a table, the indexes of subsequent rows will shift. If DataMiner is polling the table during this shift, and the polling method does **not retrieve an entire row in one operation**, it can result in inconsistent data retrieval. Parts of a row may be collected **before** the shift and others **after**, causing the final row in DataMiner to contain a **mix of values from two different rows**, leading to an incorrect representation of the data.

To avoid this issue, prefer polling methods that retrieve complete rows in a single operation. Methods like **GetNext + MultipleGet by Row**, **MultipleGetNext**, and **MultipleGetBulk** are generally less prone to this issue.

> [!NOTE]
> Tables where the row indexes do **not** shift when rows are added or removed (e.g., tables with fixed or unique indexes) are **not affected** by this issue.

> [!WARNING] Methods that fetch individual columns across multiple requests, such as **GetNext** or **GetNext + MultipleGet**, are **especially vulnerable** to this problem.

## Instance Option

In DataMiner, SNMP tables must have a single **primary key**, which is expected to be the **value of the first column**.

However, some SNMP tables define **multiple index columns**, meaning the row instance identifier is composed of values from more than one column. Additionally, certain SNMP tables may define an index column from a **different table**. These tables have the same number of rows and maintain a **one-to-one relationship**.

To correctly poll these types of tables, you must add the `instance` option to the table parameter. This instructs DataMiner write the full row instance identifier into the first column of the table.

> [!IMPORTANT] Do **not** specify an OID for the first column when using the `instance` option. The value will be automatically generated and any configured OID will be ignored.

### Example

```xml
<Param id="1000">
    <Name>Table</Name>
    <Description>Table</Description>
    <Type>array</Type>
    <ArrayOptions index="0">
        <ColumnOption idx="0" pid="1001" type="snmp" options="" />
        <ColumnOption idx="1" pid="1002" type="snmp" options="" />
    </ArrayOptions>
    <SNMP>
        <Enabled>true</Enabled>
        <OID type="complete" options="instance;multipleGetNext"></OID>
    </SNMP>
</Param>
<Param id="1001" trending="false">
    <Name>TableInstance</Name>
    <Description>Instance (Table)</Description>
    <Type>read</Type>
    <Interprete>
        <RawType>other</RawType>
        <Type>string</Type>
        <LengthType>next param</LengthType>
    </Interprete>
</Param>
<Param id="1002" trending="false">
    <Name>TableColumn1</Name>
    <Description>Column 1 (Table)</Description>
    <Type>read</Type>
    <Interprete>
        <RawType>other</RawType>
        <Type>string</Type>
        <LengthType>next param</LengthType>
    </Interprete>
    <SNMP>
        <Enabled>true</Enabled>
        <OID type="complete">1.3.6.1.2.1.2.2.1.2</OID>
        <Type>octetstring</Type>
    </SNMP>
</Param>
```

![SNMP table using instance option](~/develop/images/Table_SNMP_instance_option.png)

> [!CAUTION]
> When using the `instance` option with **GetNext + MultipleGet** or **GetNext + MultipleGet by Row**, a known issue causes the instance identifier to be written into the **second column** of the table as well as the first.
>
> **Workaround:** Create a **dedicated column** to store the duplicate instance identifier. This column serves only as a workaround and can be hidden by setting `RTDisplay` to `false`.
>
> This extra column **must define an OID**. The actual value does not matter, but it is common to use the OID of the first column of the SNMP table.
>
> The reason for this requirement is that if any SNMP-type column (except the first when using `instance`) does **not** specify an OID, DataMiner will automatically fall back to using the **GetNext** method, since it is the only method that polls without column OIDs. This fallback can lead to unintended behavior and performance issues.

## Subtable

A filtered set of rows can be retrieved using the [subtable](xref:Protocol.Params.Param.SNMP.OID-options#subtable) option (options=";subtable") on the SNMP.OID tag of a table parameter (i.e. a table of type "array"). Even though the result is a filtered set of rows, queries are sent to the device until the filter matches. DataMiner retrieves the instances of the table until the filtered data is retrieved. Only the filtered data will be displayed.

The subtable option only works with the **GetNext + MultipleGet** and **GetNext + MultipleGet by Row** methods. Multiple filters can be used, separated by a comma. The filter is defined in the parameter referenced by the id attribute on the SNMP OID of the array.

## Filtered set of rows in table using dynamic OID

Another way to retrieve a filtered set of rows is by defining a dynamic OID on the columns (i.e. defining a wildcard ('*') in the OID itself and referencing the filter with the id attribute). No options need to be defined.

The advantage of this method is that only requests are sent to the device matching the desired rows.

For example, suppose the instances of a table are 1.1; 1.2; 1.3; 2.1, 2.2, 2.3 etc. and a filter of 1 is used, then only the instances that start with 1 will be retrieved. The new instances are then 1, 2 and 3.

In the example below, table 1100 will retrieve a filtered set of rows for the column OID 1.2.3.4.* ,where the asterisk is replaced by the content of parameter with ID 1.

```xml
<Param id="1100" trending="false">
  <Name>Ports</Name>
  <Description>Ports</Description>
  <Type>array</Type>
  <ArrayOptions index="0">
     <ColumnOption idx="0" pid="1101" type="snmp" />
     <ColumnOption idx="1" pid="1102" type="snmp" />
  </ArrayOptions>
  <Information>
     <Subtext>This shows Information about the Ports on this Device.</Subtext>
  </Information>
   <SNMP>
      <Enabled>true</Enabled>
     <OID type="complete" options="instance"></OID>
  </SNMP>
</Param>
<Param id="1101" trending="false">
  <Name>Port Index</Name>
  <Description>Port Index</Description>
  <Type>read</Type>
  <Interprete>
      <RawType>other</RawType>
      <Type>string</Type>
      <LengthType>next param</LengthType>
  </Interprete>
</Param>
<Param id="1102" trending="false">
  <Name>Port Type</Name>
  <Description>Port Type</Description>
  <Type>read</Type>
  <Information>
     <Subtext>The type of the port.</Subtext>
  </Information>
  <SNMP>
     <Enabled>true</Enabled>
     <OID type="complete" id="1">1.2.3.4.*</OID>
  </SNMP>
  <Interprete>
     <RawType>numeric text</RawType>
     <Type>double</Type>
     <LengthType>next param</LengthType>
  </Interprete>
...
</Param>
```