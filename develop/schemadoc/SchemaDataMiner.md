---
uid: SchemaDataMiner
---

# DataMiner schema

DataMiner XML schema.

## Root element

[DataMiner](xref:DataMiner)

## Example

This is an example of a DataMiner.xml file:

```xml
<DataMiner id="7" disableElementIP="false">
  <AlarmSocket port="5024"/>
  <PollSocket port="5025"/>
  <SMTP>...</SMTP>
  <Colors>...</Colors>
  <LDAP nonDomainLDAP="true"
      host="dc.gtc.be" port="389"
      username="" password=""
      auth=""
      namingContext="DC=gtc,DC=local">
    ...
  </LDAP>
  <ProcessOptions protocolProcesses="5"/>
  <Logging>
    <Debug>0</Debug>
    <Error>0</Error>
    <Info>1</Info>
  </Logging>
</DataMiner>
```
