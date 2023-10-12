---
uid: AdvancedDataMinerMediationLayerLinkingParameters
---

# Linking parameters

There are two ways to establish links between parameters in a base protocol and parameters in a device protocol. You can create a parameter in a base protocol and link it to one or more parameters in a number of device protocols or you can create a parameter in a device protocol and link it to a parameter in a base protocol.

## Creating a parameter in a base protocol and linking it to parameters in data source protocols

```xml
<Param id="73102">
   <Name>Name Process</Name>
   <Description>Name Process</Description>
   <Mediation>
      <LinkTo protocol="Network Server Manager" pid="82"/>
      <LinkTo protocol="Linux Server Manager" pid="82"/>
      <LinkTo protocol="windows Server Manager" pid="82"/>
      <LinkTo protocol="Microsoft Platform" pid="97"/>
   </Mediation>
```

From DataMiner 9.6.2 (RN 19591) onwards, it is possible to create a base protocol that is not linked to a specific element type but directly to a protocol, allowing you to link protocols with different element types to the same base protocol. When a base protocol contains a Mediation.LinkTo@protocol attribute referring a protocol, the element type in the basefor attribute of the protocol that is referred to will be disregarded.

In the example above, the base protocol refers to a protocol parameter by specifying the protocol and parameter ID. It is also possible to refer to a parameter through its description, as illustrated below.

```xml
<LinkTo description="Audio Output Level" />
```

## Creating a parameter in a data source protocol and linking it to a parameter in a base protocol

In order to link a parameter in a device protocol to a parameter in a base protocol, just add a Mediation.LinkTo tag containing the ID of the latter.

For example:

```xml
<Param id="101" trending="true" save="true">
   <Name>pct_value1</Name>
   <Description>Procentual Value 1</Description>
   <Mediation>
     <LinkTo pid="71000" />
   </Mediation>
```

## See also

<xref:AdvancedDataMinerMediationLayerSyntaxOfMediationLinkToTags>

> [!NOTE]
> Note that currently the mapping for mediation parameters is a 1-1 mapping. Each mediation parameter (on a given mediation protocol) can only link to a single data source parameter (on a given data source protocol). Each data source parameter (on a given data source protocol) can only be linked to one mediation parameter (on a given mediation protocol).
