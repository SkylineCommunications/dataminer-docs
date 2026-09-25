---
metadata_version: 1
uid: Protocol.Params.Param.CrossDriverOptions
description: "Learn how to use the CrossDriverOptions element to combine columns from multiple protocols in one direct view table in a DataMiner connector protocol."
---

# CrossDriverOptions element

Allows the creation of a direct view table using multiple columns from multiple different protocols.

## Parent

[Param](xref:Protocol.Params.Param)

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|&nbsp;&nbsp;[CrossDriverOption](xref:Protocol.Params.Param.CrossDriverOptions.CrossDriverOption)|[1, *]|Specifies column mappings from a remote protocol to this protocol.|

## Remarks

Feature introduced in DataMiner 10.2.9/10.3.0 (RN 33253).

## Examples

```xml
<Protocol>
  ...
  <Params>
    ...
    <Param id="50000">
      ...
      <ArrayOptions index="0" options=";view=1;directView=105">
        ...
      </ArrayOptions>
      <CrossDriverOptions>
        <CrossDriverOption protocol="Protocol1" remoteTablePID="30000">
          <PIDTranslation local="50002" remote="30002"/>
          <PIDTranslation local="50004" remote="30005"/>
        </CrossDriverOption>
          <CrossDriverOption protocol="Protocol2" remoteTablePID="20000">
            <PIDTranslation local="50003" remote="20002"/>
            <PIDTranslation local="50005" remote="20003"/>
          </CrossDriverOption>
        </CrossDriverOptions>
      </Param>
      ...
   </Params>
   ...
</Protocol>
```
