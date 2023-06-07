---
uid: MarkerDetails
---

# MarkerDetails

In the *\<MarkerDetails>* tag, placeholders can be defined to add additional values dynamically to the URL, which can be used for various purposes, including generating marker images dynamically.

To do so, add a *\<Detail>* tag for every placeholder used in the *\<MarkerImages>* tag, and then configure the placeholder in the same way as for the *\<PopupDetails>* tag. See [PopupDetails](xref:PopupSkeleton_and_PopupDetails#popupdetails).

Example:

```xml
<Layer sourceType="properties" refresh="20000" autoFit="false" visible="false" allowToggle="true" name="Properties Service">
  <PropertiesSourceInfo type="services">
    <LatitudePropertyName>Latitude</LatitudePropertyName>
    <LongitudePropertyName>Longitude</LongitudePropertyName>
  </PropertiesSourceInfo>
  <MarkerImages>
    <MarkerImage id="default" url="images/icons/myIcon.png?angle=[angle]&amp;location=[latitude]%2F[longitude]" width="20" height="36" anchor="10,36"/>
  </MarkerImages>
  <MarkerDetails>
    <Detail name="angle" type="parameter_elementalias" alias="computer" pid="350" />
    <Detail name="cpu" type="parameter" dmaid="157" eid="2" pid="350" />
    <Detail name="latitude" type="property_elementalias" alias="computer" property="latitude" />
    <Detail name="longitude" type="property_elementalias" alias="computer" property="longitude" />
  </MarkerDetails>
  <PopupSkeleton>
    <![CDATA[
      <p>cpu [cpu]</p>
      <p>latitude [latitude]</p>
    ]]>
  </PopupSkeleton>
  <PopupDetails>
    <Detail name="cpu" type="parameter_elementalias" alias="computer" pid="350" />
    <Detail name="latitude" type="property_elementalias" alias="computer" property="latitude" />
  </PopupDetails>
</Layer>
```

> [!NOTE]
>
> - From DataMiner 9.6.13 onwards, it is possible to specify parameters of enhanced services in \<Detail> tags, in the same way as element parameters.
> - From DataMiner 10.3.7/10.4.0 onwards, additional values can be added dynamically to the URL in layers with `sourceType` set to "objects". <!-- RN 36246 -->
