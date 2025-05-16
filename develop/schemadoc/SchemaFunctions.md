---
uid: SchemaFunctions
---

# Functions Schema

DataMiner Functions XML Schema.

## Root element

[Functions](xref:Functions)

## Example

A functions XML file has the following basic file structure:

```xml
<Functions>
  <Version>1.0.0.0</Version>
  <Protocol>
    <Name>MyProtocolName</Name>
  </Protocol>
  <OverrideTimeoutVF>true</OverrideTimeoutVF>
  <Function id=" ..." name =" ..." maxInstances =" ..." profile="...">
    <Parameters>
      <Parameter id="..."/>
      <Parameter id="..."/>
      ...
    </Parameters>
    <EntryPoints>
      <EntryPoint pid ="..." type ="" />
    </EntryPoints>
    <ExportRules/>
    <Interfaces>
      <Interface id="... " name =" ..." type =" ..." parameterGroupLink =" ..." profile="..."/>
      <Interface id="... " name =" ..." type =" ..." parameterGroupLink =" ..." profile="..."/>
      ...
    </Interfaces>
    <Graphical>
      ...
    </Graphical>
  </Function>
  <Function id=" ..." name =" ..." maxInstances =" ...">
    ...
  </Function>
</Functions>
```