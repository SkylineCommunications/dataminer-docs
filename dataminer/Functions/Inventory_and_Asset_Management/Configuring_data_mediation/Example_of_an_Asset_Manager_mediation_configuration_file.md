---
uid: Example_of_an_Asset_Manager_mediation_configuration_file
---

# Example of an Asset Manager mediation configuration file

This is an example of a mediation configuration file:

```xml
<AssetMediationConfig forConfig="gtc">
  <SynchronizeData>
    ...
    <Sync direction="dbToDma" type="column" interval="30">
      <DMA element="7/2898" table="101" column="117" dbKeyColumn="112" />
      <DB table="CHANNEL" column="NAME" pkColumn="CHANNEL_ID" />
    </Sync>
    ...
    <Sync direction="dmaToDb" type="cell">
      <DMA propertyType="element" propertyOwner="7/3556" dataPropertyName="ASSET_CHANNEL_NAME_REV" />
      <DB table="CHANNEL" column="NAME" pkColumn="CHANNEL_ID" pk="1" />
    </Sync>
    ...
  </SynchronizeData>
</AssetMediationConfig>
```
