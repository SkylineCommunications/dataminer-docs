---
uid: Connectivity_xml_files_representing_chains
---

# Connectivity.xml files representing chains

To configure connectivity chains:

1. For every connectivity chain that you want to configure, create a subfolder with a meaningful name in *C:\\Skyline DataMiner\\Connectivity\\*

   > [!NOTE]
   > The name of the subfolder will be the name of the connectivity chain configuration.

1. Create a *Connectivity.xml* file in each subfolder. In these files, you can define a connectivity path by specifying a number of so-called mappings for every connection in that path.

   In a mapping, you can compare internal connectivity connections with either a static or a dynamic value, and add conditions. In case of a match, the internal connection is considered part of the connectivity path.

   > [!NOTE]
   >
   > - External connections (i.e. connections between elements, services or redundancy groups) are automatically part of the path if the two internal connections (inside an element, a service or a redundancy group) at either end of those external connections are part of the path.
   > - The chained connections do not necessarily have to follow one another (e.g. Interface 1 -> Interface 2 -> interface 3). It is also possible to have connections on the same destination or source, for instance to create a star topology. For example, a chain may look like this:
   >   - Interface 1 -> Interface 2
   >   - Interface 3 -> Interface 2

## Example of Connectivity.xml files representing a chain

The following example illustrates the basic syntax of a *Connectivity.xml* file.

```xml
<DCF>
  <Links>
    <Link id="edf13cc4-e740-4bfc-82e1-459893c0489e" itemA="DCF Stream Output" itemB="QA_Basic_Element_RF" type="Service">
      <Map propertyA="" propertyB="SVC Name" match="WildCard" type="Optional" value="*[PROPERTYB]*" direction="Undefined" invert="false" referenceValue="SVCNAME:///" />
      <Map propertyA="" propertyB="SVC Name" match="WildCard" type="Optional" value="*[PROPERTYB]*" direction="Undefined" invert="false" referenceValue="RDGNAME:///" />
    </Link>
    <Link id="4a24258d-2833-497b-a376-2c6103fd2637"  itemA="QA_Basic_Element_ENC" itemB="QA_Basic_Element_DCM" type="Protocol">
      <Map propertyA="Primary" propertyB="" match="Exact" type="Optional"  value="TRUE" direction="Undefined" invert="false" referenceValue="" />
      <Map propertyA="Port" propertyB="VLAN" match="Exact" type="Optional"  value="" direction="Undefined" invert="false" referenceValue="" />
    </Link>
    <Link id="d1415b3f-0203-425c-b056-cafe52cdf8cc" itemA="QA_Basic_Element_ENC" itemB="QA_Basic_Element_RF" type="Protocol">
      <Map propertyA="Primary" propertyB="" match="Exact" type="Optional"  value="TRUE" direction="Undefined" invert="false" referenceValue="" />
    </Link>
    <Link id="4eb68cee-2423-486d-8ffe-ed97c23edaf6" itemA="QA_Basic_Element_DCM" itemB="QA_Basic_Element_Dish" type="Protocol">
      <Map propertyA="VLAN" propertyB="streams" match="list" type="Optional"  value="" direction="Undefined" invert="false" referenceValue="" />
    </Link>
  </Links>
</DCF>
```

The following example illustrates a *Connectivity.xml* file where hops are configured to indicate the position of elements in the chain:

```xml
<DCF>
  <!-- element chains: entry point (hop:1) -> switch (hop:2) -> basic (hop:3) -> switch (hop:4) !-->
  <Links>
    <Link id="D21FE771-6F6A-4221-8E78-8F10E466E1E1" itemA="Hop Count" itemB="QA_Basic_Element_DCF" type="Service" hop="1">
      <Map propertyA="" propertyB="SVC Name" match="WildCard" type="Mandatory" value="*[REFERENCE:0]*" direction="InputToOutput" invert="false" referenceValue="SVCNAME:///" />
    </Link>
    <Link id="AFFB575B-68E3-474A-88F4-7AC82E9724A3" itemA="QA_backupSwitch_DCF" itemB="QA_backupSwitch_DCF" type="Protocol" hop="2">
      <Map propertyA="IP" propertyB="" match="Exact" type="Mandatory" value="[REFERENCE:0]" direction="Undefined" invert="false" referenceValue="SVCPROPERTY:///Service IP" />
    </Link>
    <Link id="0BC52454-B86C-43A2-AB27-6850FADD79F5" itemA="QA_Basic_Element_DCF" itemB="QA_Basic_Element_DCF" type="Protocol" hop="3">
      <Map propertyA="Port" propertyB="" match="Exact" type="Mandatory" value="[REFERENCE:0]" direction="Undefined" invert="false" referenceValue="SVCPROPERTY:///Service Port" />
    </Link>
    <Link id="800B165F-C73D-4AC7-A0A7-BD6EB3787AF5" itemA="QA_backupSwitch_DCF" itemB="QA_backupSwitch_DCF" type="Protocol" hop="4">
      <Map propertyA="Port" propertyB="" match="Exact" type="Mandatory" value="[REFERENCE:0]" direction="Undefined" invert="false" referenceValue="SVCPROPERTY:///Service Port" />
    </Link>
  </Links>
</DCF>
```

## Overview of tags and attributes of Connectivity.xml files representing chains

The section below lists the tags and attributes that can be used within a *Connectivity.xml* file:

- [\<Link> tag](#link-tag)

- [\<Map> tag](#map-tag)

- [\<Conditions> tag](#conditions-tag)

- [\<Protocols> tag](#protocols-tag)

- [referenceValue](#referencevalue)

### \<Link> tag

Inside the *\<Links>* tag, add a *\<Link>* tag for every connection in the connectivity path.

A *\<Link>* tag can have the following attributes:

- **id**

  To be left empty. DataMiner will automatically assign a unique GUID to every link the first time it reads the file.

  > [!NOTE]
  > For connectivity files used to automatically generate RCA chains, in one case, the id must be filled in. See [Automatically generating service RCA chains based on connectivity](xref:Automatically_generating_service_RCA_chains_based_on_connectivity).

- **itemA**

  This attribute can have the following values:

  - The name of a protocol (If *type=”Protocol”*).

  - A random service identifier (If *type*=*”Service”*).

  From DataMiner 9.5.2 onwards, you can use an asterisk (“\*”) wildcard in this attribute, for instance to specify a rule for all encountered protocols.

  > [!NOTE]
  > Usually, this is the name of the folder containing the *Connectivity.xml* file.

- **itemB**

  Should be set to the name of a protocol.

  From DataMiner 9.5.2 onwards, you can use an asterisk (“\*”) wildcard in this attribute, for instance to specify a rule for all encountered protocols.

- **itemRelation**

  This attribute can have the following values:

  - “*internalMatching*”: Link between two internal connections of the same element.

  - “*externalMatching*”: Link between two internal connections of different elements.

  - “*physicalMatching*”: Physical link between two internal connections of the same element.

  Example:

  ```xml
  <Links>
  <Link itemA="ALCALTEL" itemb="ALCALTEL" itemRelation="internalMatching" type="protocol">
  ...
  </Link>
  <Link itemA="ALCALTEL" itemb="ALCALTEL" itemRelation="externalMatching" type="protocol">
  ...
  </Link>
  <Link itemA="ALCALTEL" itemb="ALCALTEL" itemRelation="physicalMatching" type="protocol">
  ...
  </Link>
  <Link itemA="ALCALTEL" itemb="DCM" itemRelation="externalMatching" type="protocol">
  ...
  </Link>
  <Links>
  ```

  > [!NOTE]
  > When itemA and itemB are equal, you need to define an itemRelation.

- **type**

  This attribute can have the following values:

  - “*Protocol*”

  - “*Service*”

  > [!NOTE]
  >
  > - The type of the first link of a chain, i.e. the entry point, should always be “Service”.
  > - If itemA and itemB are both specified, always add `type="protocol"`.

- **includeValueInContext**

  If you want the value for the service entry point to be saved, set this attribute to “true”.

  > [!NOTE]
  > When the *RedundancyGroupConnectivity* tag is set to “true”, always set the *includeValueInContext* attribute to “true”.

- **hop**

  This attribute should be set to a number, to indicate the position of this particular connection in the connectivity path. For example, in case of a chain like ElementA \> ElementB \> ElementC \> ElementD, in the corresponding *\<Link>* tags, the hops are configured as 1 > 2 > 3 > 4.

  For an example, refer to [Example of Connectivity.xml files representing a chain](#example-of-connectivityxml-files-representing-a-chain).

### \<Map> tag

Inside a *\<Link>* tag, you can add a number of *\<Map>* tags, in which you can look up and compare properties of internal connections. If all *\<Map>* tag comparisons inside a *\<Link>* are “true”, the internal connections in question will be linked.

A *\<Map>* tag can have the following attributes:

- **propertyA** / **propertyB**

  If you want to compare the values of two properties, *propertyA* and *propertyB* must contain the names of the two properties of which the values will be compared.

  If you want to compare the value of a property to a given value, then either *propertyA* or *propertyB* must contain the name of the property.

  > [!NOTE]
  >
  > - The *propertyB* attribute is not mandatory.
  > - While resolving multiple external connections on the same interface is supported from DataMiner 9.5.5 onwards, matching property connections on external connections is currently not yet supported.

- **match**

  This attribute can have the following values:

  - “*Exact*”: An exact match is required (culture invariant, case-insensitive).

  - “*Wildcard*”: A partial match suffices (i.e. *value* contains a wildcard expression containing \* and/or ? wildcard characters).

  - “*Regex*”: *value* contains a regular expression.

  - “*List*”: Both items to be compared contain a list of values separated by semicolons. If all values in item A are found in item B, then there is a match.

  - “*Presence*”: The internal connection must have a property with the specified name.

- **type**

  This attribute can have the following values:

  - “*Mandatory*”: The properties to be compared must exist on both internal connections. Otherwise, the Map result will be “false”.

  - “*MandatoryA*”: The connection will only be added if it has property A, regardless of whether it has property B.

  - “*MandatoryB*”: The connection will only be added if it has property B, regardless of whether it has property A.

  - “*Optional*”: If the properties to be compared do not exist on both internal connections, then the Map result will be “true”.

  - “*MandatoryInElement*”: (Available from DataMiner 9.6.3 onwards.) When the internal connections have no more connections attached, or when an external connection is reached, the rule will be enforced. If no match is found up until that connection, the match (or mismatch) will cause the final connection to be added (or removed).

- **value**

  If you want to compare the value of a property (of which the name is specified in *propertyA* or *propertyB*) to a given value, then *value* must contain that value. It can be a fixed value (e.g. “10”, “true”, etc.) or a dynamic value (e.g. “\*\[PROPERTYB\]\*”).     In case of a dynamic value, the following placeholders can be used:

  - \[PROPERTYA\]

  - \[PROPERTYB\]

  - \[REFERENCE:*arrayIndex*\]

  The \[REFERENCE:*arrayIndex*\] placeholder will be replaced at runtime by the one of the values from the array stored in the *referenceValue* attribute.

  Example: “\[REFERENCE:0\]” will be replaced by the first value from the array stored in the *referenceValue* attribute.

- **direction**

  With this setting you can indicate the direction in which connectivity has to be resolved:

  - “*InputToOutput*”: From input to output.

  - “*OutputToInput*”: From output to input.

  - “*Undefined*”: Both ways.

- **invert**

  This attribute can have the following values:

  - “*true*”: The result of the comparison will be inverted, i.e. a “NOT” will be placed in front of it.

  - “*false*”: The result of the comparison will not be inverted.

- **referenceValue**

  This attribute contains one or more reference values that will be resolved at runtime. Multiple values are separated by pipe characters (“\|”).

  For more information on the reference values, refer to [referenceValue](#referencevalue).

- **behaviorOnUnavailableProperty**

  This attribute can have the following values:

  - “*Save*” (default): If the property cannot be found, then the value in memory will be used.

  - “*Forget*”: If the property cannot be found, then the value in memory will be flushed.

- **behaviorOnEmptyProperty**

  This attribute can have the following values:

  - “*Save*” (default): If the property is empty, then the value in memory will be used.

  - “*Forget*”: If the property is empty, then the value in memory will be flushed.

- **behaviorOnMatchProperty**

  Determines what happens when the properties match. This attribute can have the following values:

  - “*Save*” (default): If the property has been found, the value in memory will be used.

  - “*Forget*”: If the property has been found, the new value will be used. When the map check has already been executed within the same element, it will be skipped on the next connection with the same property.

  - “*ForgetExternal*”: If the property has been found, the new value will be used. When the map check has already been executed on another element, it will be skipped on the next connection with the same property.

- **behaviorOnMismatchProperty**

  Determines what happens when the properties do not match. This attribute can have the following values:

  - “*Remove*” (default): Remove only this connection from the active path.

  - “*RemovePath*”: Remove all the connections that have been found earlier from the path.

- **conditions**

  This attribute contains one or more IDs of conditions configured in the *\<Conditions>* tag, combined into a single expression using the logical operators *and*, *not* and *or*.     Example: “*1 and not (2 or 3)*”

- **operator**

  Available from DataMiner 9.5.2 onwards.

  Determines the logical operator that is used for the tag. By default, this is AND, but you can also set this to OR. In that case, multiple rules will be checked, and if one matches, the connection is added.

### \<Chains> tag

This tag can be used from DataMiner 9.6.4 onwards, in order to configure an external DCF chain of protocols. Specifying such a chain can improve the stability of the generated DCF chain.

The *Chains* tag is used in conjunction with the *Protocols* tag. In each of that tag’s *Protocol* subtags, a "*chainId*" attribute can be defined. The *Chain* tags within *DCF.Chains* will each contain several *Id* subtags that refer to these chain IDs.

For example:

```xml
<DCF>
 <Protocols>
 <Protocol chainId="1">My_Element_DCF_ENTRY_POINT</Protocol>
 <Protocol chainId="2">My_Element_DCF</Protocol>
 <Protocol chainId="3">My_Element_DCF_END_POINT</Protocol>
 </Protocols>
 <Chains>
 <Chain>
 <Id>1</Id>
 <Id>2</Id>
 <Id>3</Id>
 </Chain>
 </Chains>
 <Links>
 <Link type="Service" itemB="My_Element_DCF_ENTRY_POINT" itemA="RT_DCF_CHAIN_DEFINITION" id="95F39DDC-1123-40D1-8209-3B4F5C1BA85C">
 <Map type="Mandatory" referenceValue="" invert="false" direction="Undefined" value="X" match="exact" propertyB="property" propertyA=""/>
 </Link>
 </Links>
</DCF>
```

When chains are defined using the *Chains* tag, and an external connection is found that is not expected at that point in the chain, this external connection will be ignored.

A new read-only service property, *Connectivity Status*, will be added as soon as a *Connectivity.xml* file is found that has a valid *Chain* configuration. This property will have the value "Resolved" when the found path contains at least one of the defined *Chain* configurations. It will have the value "Unresolved" if either an exception occurred (e.g. because too many connections were found) or none of the defined chains were found.

> [!TIP]
> See also: [\<Protocols> tag](#protocols-tag)

### \<Conditions> tag

Inside the *\<Conditions>* tag, you can add a number of *\<Condition>* tags, which each have their own unique ID, indicated in the “*id*” attribute.

Inside a *\<Condition>* tag, you can add the following tags:

- **\<Field>**

  Possible values:

  - ConnectionType

  - DestinationInterfaceName

  - InterfaceProperty:*PropertyName*

  - RedundancyElementState

  - SourceInterfaceName

  - SourceInterfaceProperty:*PropertyName*

  - SharedInterfaceProperty:*PropertyName*

- **\<Value>**

  Possible values:

  - If *\<Field>* contains “ConnectionType”, *\<Value>* has to contain one of the following values:

    - internal

    - external

    - physical

  - If *\<Field>* contains “RedundancyElementState”, *\<Value>* has to contain one of the following values:

    - AVAILABLE (integer value 1)

    - OPERATIONAL (integer value 2)

    - UNAVAILABLE (integer value 3)

    - ERROR (integer value 4)

    - SWITCHING (integer value 5)

  - If *\<Field>* contains any other value, *\<Value>* can contain any character string, with or without the wildcard characters \* and/or ?

  Alternatively, from DataMiner 9.5.2 onwards, you can specify multiple references (e.g. \[REFERENCE:0\]/REFERENCE:1\]), which will then be replaced by items specified in the referenceValue attribute of the *\<Map>* tag.

  > [!NOTE]
  > Wildcards in the *Condition.Value* tag will only be applied if the *Condition.Compare* tag is set to *equal to masked* or *not equal to masked*.

- **\<Compare>**

  Possible values:

  - equal to

  - not equal to

  - less than

  - less than or equal

  - greater than

  - greater than or equal

  - equal to masked

  - not equal to masked

  - matches regex

  - fails regex

  > [!NOTE]
  > If no wildcards are used in the *Condition.Value* tag, do not use the types *equal to masked* or *not equal to masked*.

Examples:

```xml
<Conditions>
  <Condition id="1">
    <Field>SharedInterfaceProperty:IsEmptySHG</Field>
    <Value>FALSE</Value>
    <Compare>equal to</Compare>
  </Condition>
  <Condition id="2">
    <Field>RedundancyElementState</Field>
    <Value>Operational</Value>
    <Compare>equal to</Compare>
  </Condition>
  <Condition id="3">
    <Field>DestinationInterfaceName</Field>
    <Value>Output Primary</Value>
    <Compare>equal to</Compare>
  </Condition>
</Conditions>
```

```xml
<Conditions>
  <Condition id="1">
    <Field>DestinationInterfaceName</Field>
    <Value>streamOutband*</Value>
    <Compare>equal to masked</Compare>
  </Condition>
  <Condition id="2">
    <Field>SharedInterfaceProperty:IsEmptySHG</Field>
    <Value>FALSE</Value>
    <Compare>equal to</Compare>
  </Condition>
  <Condition id="3">
    <Field>DestinationInterfaceName</Field>
    <Value>Output Primary</Value>
    <Compare>equal to</Compare>
  </Condition>
  <Condition id="4">
    <Field>SourceInterfaceName</Field>
    <Value>IO Port*</Value>
    <Compare>equal to masked</Compare>
  </Condition>
</Conditions>
```

### \<Protocols> tag

This tag can be used from DataMiner 9.5.5 onwards, to avoid chain resolving issues when a new external connection is added between elements that were already part of an operational connectivity chain and another element based on a protocol that was not yet described in the *Connectivity.xml* file.

This tag contains a number of *\<Protocol>* subtags that provide a list of allowed protocols. During the chain resolution process, the system will only take elements based on the listed protocols into account.

For example:

```xml
<DCF>
  <Protocols>
    <Protocol>MyFirstProtocol</Protocol>
    <Protocol>MySecondProtocol</Protocol>
    <Protocol>MyThirdProtocol</Protocol>
  </Protocols>
  ...
</DCF>
```

> [!NOTE]
> From DataMiner 9.6.4 onwards, a *chainId* attribute can be defined in a *Protocol* tag. For more information, see [\<Chains> tag](#chains-tag).

### referenceValue

If, in *referenceValue*, you specify e.g. “*SVCNAME:///*”, this will be replaced at runtime by the name of the current service. If you want to refer to e.g. one particular service instead, you can specify “*SVCNAME:dmaId/serviceId//*”.

See the following table to find out which items can be entered after each placeholder (separated by forward slashes).

| Placeholder     | dmaId  | elementId           | parameterId       | name                                    |
|-----------------|--------|---------------------|-------------------|-----------------------------------------|
| DCFCONNPROPERTY | DMA ID | Element ID          | DCF connection ID | Name of DCF connection property         |
| ELNAME          | DMA ID | Element ID          |                  |                                        |
| ELPROPERTY      | DMA ID | Element ID          |                  | Name of element property                |
| PARAMETER       | DMA ID | Element ID          | Parameter ID      | Display key (in case of a table column) |
| RDGNAME         | DMA ID | Redundancy group ID |                  |                                        |
| SVCID           | DMA ID | Service ID          |                  |                                        |
| SVCNAME         | DMA ID | Service ID          |                  |                                        |
| SVCPROPERTY     | DMA ID | Service ID          |                  | Name of service property                |
| VIEWNAME        |       | View ID             |                  |                                        |
| VIEWPROPERTY    |       | View ID             |                  | Name of view property                   |
