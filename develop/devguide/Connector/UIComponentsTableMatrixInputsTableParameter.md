---
uid: UIComponentsTableMatrixInputsTableParameter
---

# Inputs Table

For a typical inputs table, the following columns are configured:

- Index: String column. Required. Indicates the index of the input.
- Label: String column. Required. Contains the label of the input.
- State: Discrete column. Required. Indicates whether the input is enabled.
- Lock: Discrete column. Required. Indicates whether the input is locked.
- Page: String column. Optional. Indicates on which page the input is located.

Example:

```xml
<Param id="1000" trending="false">
   <Name>tblInputs</Name>
   <Description>Inputs</Description>
   <Type>array</Type>
   <Information>
      <Subtext>Table representation of the matrix. This table will contain the information of the inputs.</Subtext>
   </Information>
   <ArrayOptions index="0" options=";naming=/1002">
      <ColumnOption idx="0" pid="1001" type="retrieved" options="" />
      <ColumnOption idx="1" pid="1002" type="retrieved" options=";save" />
      <ColumnOption idx="2" pid="1003" type="retrieved" options=";save" />
      <ColumnOption idx="3" pid="1004" type="retrieved" options=";save" />
      <ColumnOption idx="4" pid="1005" type="retrieved" options=";save" />
   </ArrayOptions>
   <Display>
      <RTDisplay>true</RTDisplay>
      <Positions>
         <Position>
            <Page>Tables</Page>
            <Row>0</Row>
            <Column>0</Column>
         </Position>
      </Positions>
   </Display>
   <Measurement>
      <Type options="tab=columns:1001|0-1002|1-1003|2-1004|3-1005|4,width:80-200-60-60-100,sort:STRING-STRING-STRING-STRING-STRING,lines:15,filter:true">table</Type>
   </Measurement>
</Param>
```
