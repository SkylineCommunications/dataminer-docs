---
uid: Example_of_an_Asset_Manager_configuration_file
---

# Example of an Asset Manager configuration file

This is an example of an *Inventory and Asset Management* configuration file:

```xml
<?xml version="1.0"?>
<AssetManagerConfig xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
xmlns:xsd="http://www.w3.org/2001/XMLSchema">
  <DatabaseConfig>GTC</DatabaseConfig>
  <Schema>GTCDB</Schema>
  <DisplayName>Global Telecom Corporation</DisplayName>
  <HandlingDMA>103</HandlingDMA>
  <RootTable>channel</RootTable>
  <Security>
    <Group name="Administrators">
      <Read base="allowAll">
        <Deny>TableX</Deny>
      </Read>
      <Write base="denyAll">
        <Allow>TableY</Allow>
      </Write>
    </Group>
    <Group name="Operators">
      <Read base="allowAll" />
      <Write base="denyAll" />
    </Group>
  </Security>
  <Tables>
    <Table name="table1" displayName="Table 1" displayColumn="column1  (column2:column3)" />
    <Table name="person" displayName="person details" displayColumn="Name" >
      <ColumnRelations>
        <ColumnRelation sourceColumn="addressID" onDelete="PromptLinkedRemoval" />
        <ColumnRelation sourceColumn="employeeID" onDelete="DenyLinkedRemoval" />
      </ColumnRelations>
    </Table>
    <Table name="filtered_table" displayName="Filtered Table" displayColumn="Name">
      <Filter>
        <![CDATA[column1 = value1 OR column1 <= value2]]>
      </Filter>
    </Table>
    <Table name="ordered_table" displayName="Ordered Table" displayColumn="Name">
      <Order definition="column1 DESC" />
    </Table>
    <Table name="ca_modul" displayName="CA Modul" displayColumn="Name">
      <Columns>
        <Column name="column3" displayName="Service ID" width="123" />
        <Column name="column1" />
        <Column name="column2" />
        <Column name="column4" />
      </Columns>
    </Table>
    <Table name="ip_pool" displayName="IP Pool" displayColumn="IP">
      <PathsToFollow>
        <Path>NONE</Path>
      </PathsToFollow>
    </Table>
  </Tables>
  <AllLinkedDataOrder>
    <Table>ird</Table>
    <Table>channel</Table>
  </AllLinkedDataOrder>
</AssetManagerConfig>
```
