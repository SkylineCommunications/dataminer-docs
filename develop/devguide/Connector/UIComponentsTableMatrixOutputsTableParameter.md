---
uid: UIComponentsTableMatrixOutputsTableParameter
---

# Outputs Table

For a typical outputs table, the following columns are configured:

- Index: String column. Required. Indicates the index of the output.
- Label: String column. Required. Contains the label of the output.
- State: Discrete column. Required. Indicates whether the output is enabled.
- Lock: Discrete column. Required. Indicates whether the output is locked.
- Connected Input: String column. Required. Determines which input is connected to the output. Only one input can be connected.
- Page: String column. Optional. Indicates on which page the output is located.
- Tooltip: String column. Optional. The tooltip shown on the connected crosspoint for this output.
- Lock Override: String column. Optional. Can be used to change a crosspoint while it is locked.

Example:

```xml
<Param id="1200" trending="false">
   <Name>tblOutputs</Name>
   <Description>Outputs</Description>
   <Type>array</Type>
   <Information>
      <Subtext>Table representation of the matrix. This table will contain the information of the outputs.</Subtext>
   </Information>
   <ArrayOptions index="0" options=";naming=/1202">
      <ColumnOption idx="0" pid="1201" type="retrieved" options="" />
      <ColumnOption idx="1" pid="1202" type="retrieved" options=";save" />
      <ColumnOption idx="2" pid="1203" type="retrieved" options=";save" />
      <ColumnOption idx="3" pid="1204" type="retrieved" options=";save" />
      <ColumnOption idx="4" pid="1205" type="retrieved" options=";foreignKey=1000" />
      <ColumnOption idx="5" pid="1206" type="retrieved" options=";save" />
      <ColumnOption idx="6" pid="1207" type="retrieved" options=";save" />
      <ColumnOption idx="7" pid="1208" type="retrieved" options=";save" />
      <ColumnOption idx="8" pid="1209" type="retrieved" options=";save" />
      <ColumnOption idx="9" pid="1210" type="retrieved" options=";save" />
   </ArrayOptions>
   <Display>
      <RTDisplay>true</RTDisplay>
      <Positions>
         <Position>
            <Page>Tables</Page>
            <Row>1</Row>
            <Column>0</Column>
         </Position>
      </Positions>
   </Display>
   <Measurement>
      <Type options="tab=columns:1201|0-1202|1-1203|2-1204|3-1205|4-1206|5-1207|6-1208|7-1209|8-1210|9,width:80-200-60-60-112-80-80-0-112-100,sort:STRING-STRING-STRING-STRING-STRING-STRING-STRING-STRING-STRING-STRING,lines:15,filter:true">table</Type>
   </Measurement>
</Param>
```
