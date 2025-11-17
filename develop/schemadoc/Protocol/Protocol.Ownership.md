---
uid: Protocol.Ownership
---

# Ownership element

Specifies the level of access users will have to elements, views, services and redundancy groups created by elements based on this protocol.<!-- RN 13010 -->

## Parent

[Protocol](xref:Protocol)

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|***All***|||
|&nbsp;&nbsp;[Elements](xref:Protocol.Ownership.Elements)|[0, 1]|Groups ownership declarations of DataMiner elements.|
|&nbsp;&nbsp;[Views](xref:Protocol.Ownership.Views)|[0, 1]|Groups ownership declarations of view properties.|
|&nbsp;&nbsp;[Services](xref:Protocol.Ownership.Services)|[0, 1]|Groups service ownership declarations.|
|&nbsp;&nbsp;[RedundancyGroups](xref:Protocol.Ownership.RedundancyGroups)|[0, 1]|Groups redundancy group ownership declarations.|

## Remarks

This will allow you, for instance, to grant users either read-write access or read-only access to an element (or parts of that element, e.g. certain fields like Description). However, administrators will always have full access, regardless of the ownership settings you have specified.

Please note the following regarding the usage of this tag:

- If no ownership settings are specified in a protocol, then the access type of all properties of the created objects will by default be "read-write". If a protocol contains ownership settings, then the access type of all properties of the created object will by default be "read-only". If necessary, however, the access type of specific properties can be overridden inside the tag of the protocol.
- The tags matched by wildcard (Protocol, Property Name) are applied on a first come, first serve basis. Therefore, the ordering of these tags is of importance.
- For every element based on a protocol with a tag, an XML file named DmaId_ElementId_Components.xml will be created. This file will contain the IDs of all elements, views, services and redundancy groups created by that so-called "owner element". These files will be synchronized across the DataMiner System, and are attached to the managing element on export/import. When the protocol or protocol version of an owner element is changed, a check is performed to find out whether the new protocol (version) applies any ownership settings. If so, the currently owned components are transferred and the new ownership settings are applied. If the new protocol (version) does not apply any ownership settings, the ownership file will be deleted.

  See the following example:

    ```xml
    <Components protocol="protocolname" protocolversion="protocolversion">
       <Views>
          <View></View>
       </Views>
       <Elements>
          <Element>7/145</Element>
       </Elements>
       <Services></Services>
       <RedundancyGroups></RedundancyGroups>
    </Components>
    ```

  These files will be synchronized across the DataMiner System, and are attached to the managing element on export/import.

  When the protocol or protocol version of an owner element is changed, a check is performed to find out whether the new protocol (version) applies any ownership settings. If so, the currently owned components are transferred and the new ownership settings are applied. If the new protocol (version) does not apply any ownership settings, the ownership file will be deleted.

## Examples

```xml
<Ownership>
   <Elements>
      <Element>
         <Protocol>*</Protocol>
         <Properties>
            <Property>
               <Name>*</Name>
               <AccessType>read-write</AccessType>
            </Property>
         </Properties>
         <AlarmTemplate>
            <AccessType>read-write</AccessType>
         </AlarmTemplate>
         <TrendTemplate>
            <AccessType>read-write</AccessType>
         </TrendTemplate>
         <Description>
            <AccessType>read-write</AccessType>
         </Description>
      </Element>
   </Elements>
   <Views>
      <View>
         <Properties>
            <Property>
               <Name>*</Name>
               <AccessType>read-write</AccessType>
            </Property>
         </Properties>
      </View>
   </Views>
   <Services>
      <Service>
         <Description>
            <AccessType>read-write</AccessType>
         </Description>
         <Properties>
            <Property>
               <Name>*</Name>
               <AccessType>read-write</AccessType>
            </Property>
         </Properties>
      </Service>
   </Services>
   <RedundancyGroups>
      <RedundancyGroup>
         <Switching>
            <AccessType>read-write</AccessType>
         </Switching>
         <Maintenance>
            <AccessType>read-write</AccessType>
         </Maintenance>
         <Description>
            <AccessType>read-write</AccessType>
         </Description>
      </RedundancyGroup>
   </RedundancyGroups>
</Ownership>
```
