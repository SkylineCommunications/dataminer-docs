---
uid: Automatically_generating_service_RCA_chains_based_on_connectivity
---

# Automatically generating service RCA chains based on connectivity

From DataMiner 9.5.2 onwards, it is possible to have RCA chains generated automatically for elements in a service, based on connectivity.

For this, a specific *Connectivity.xml* file must be created, which is very similar to a regular connectivity file, with two notable differences:

- A *Connectivity.xml* file that is used to generate RCA chains must be stored in the folder *C:\\Skyline DataMiner\\Connectivity\\RCA Chain*.

- A *Connectivity.xml* file that is used to generate RCA chains must contain the following link:

    ```xml
    <Link id="33248E87-157C-480B-8754-15582008E0E0" itemA="RCA Chain" itemB="*" type="Service">
    ```

In addition, some configuration is necessary in the relevant *Service.xml* file(s). See [Service.xml configuration for automatic RCA chain generation for services](#servicexml-configuration-for-automatic-rca-chain-generation-for-services).

> [!NOTE]
> A DCF-based RCA chain has priority over any other RCA chain defined in the service or the service template.

## Example of Connectivity.xml files representing a chain

The following example illustrates the basic syntax of a *Connectivity.xml* file.

```xml
<DCF>
  <Conditions>
    <Condition id="1">
      <Field>InterfaceProperty:[RCA Service ID]</Field>
      <Value>*[REFERENCE:0]*</Value>
      <Compare>equal to masked</Compare>
    </Condition>
    <Condition id="2">
      <Field>ConnectionType</Field>
      <Value>external</Value>
      <Compare>equal to</Compare>
    </Condition>
    <Condition id="3">
      <Field>ConnectionType</Field>
      <Value>internal</Value>
      <Compare>equal to</Compare>
    </Condition>
  </Conditions>
  <Links>
    <Link id="33248E87-157C-480B-8754-15582008E0E0" itemA="RCA Chain" itemB="*" type="Service">
      <Map propertyA="" propertyB="" match="Exact" type="Mandatory" value="" direction="Undefined" invert="false" referenceValue="SVCID:///" conditions="1" />
    </Link>
    <Link id="400FBE99-F768-4ACB-B447-6D558F839DC3" itemA="*" itemB="*" type="Protocol">
      <Map propertyA="" propertyB="" match="Exact" type="Mandatory" value="" direction="Undefined" invert="false" referenceValue="SVCID:///" conditions="3 OR (1 AND 2)" />
    </Link>
  </Links>
</DCF>
```

## Service.xml configuration for automatic RCA chain generation for services

In the *Service.xml* files for which RCA chains should be generated, information must be added about the element that serves as the entry point to calculate the DCF chain.

This information is added in the *\<RCA>* tag. For example:

```xml
<RCA>
  <DCF entryPoint="131/10" isRootLevel="false" interfaceID="1" addExternals="true" />
</RCA>
```

Attributes of the \<DCF> tag:

| Attribute | Description |
|--|--|
| entryPoint | The DmaId/ElementId of the element that serves as entry point to calculate the DCF chain. |
| isRootLevel | \-  True: The entry point is the root RCA level, and the chain will be resolved from input to output.<br> -  False: The entry point is the maximum RCA level, and the chain will be resolved from output to input. |
| interfaceID | The interface from which to start. |
| addExternals | \-  True: External connections will be added<br> -  False: No external connections will be added.<br> Default: False |

Example of a Service.xml file:

```xml
<Service version="2" dmaid="131" id="5" name="Parent Service" description="myService" vdxfile="" ignoreTimeouts="false" isTemplate="false" generatedFromTemplate=""  type="" timestamp="636168981380371823" keepCopiesOnReApply="false">
  <RCA>
    <DCF entryPoint="131/10" isRootLevel="false" interfaceID="1" addExternals="true" />
  </RCA>
  <Element idx="0" dmaid="131" eid="4" alias="" group="-1" notUsedCapped="" includedCapped="" service="true" serviceElement="False" includeTrigger=""  excludeTrigger="" notUsedTrigger="" state="" description="" templateOptions="" />
  <Element idx="1" dmaid="131" eid="2" alias="" group="-1" notUsedCapped="" includedCapped="" service="false" serviceElement="False" includeTrigger=""  excludeTrigger="" notUsedTrigger="" state="" description="" templateOptions="" />
  <Element idx="2" dmaid="131" eid="11" alias="" group="-1" notUsedCapped="" includedCapped="" service="true" serviceElement="False" includeTrigger=""  excludeTrigger="" notUsedTrigger="" state="" description="" templateOptions="" />
  <Triggers />
  <Properties>
    <Property name="A random property" type="read-write" value="foobar" />
  </Properties>
</Service>
```

## Service.xml configuration for automatic RCA chain generation for service templates

From DataMiner 9.5.3 onwards, automatic RCA chain generation based on connectivity is also supported for service templates. In that case, in the *Service.xml* file of the service template, information must be added about the element and interface that serve as the entry point to calculate the DCF chain.

This information is added in the *\<RCA>* tag. For example:

```xml
<RCA>
  <DCF entryPoint="" isRootLevel="True" interfaceID="" addExternals="True" templateEntryPoint="ID:[data:Element Entry Point]" templateInterface="ID:[data:Interface Entry Points]" templateOptions="" />
</RCA>
```

> [!NOTE]
> If interfaces or elements are not found during service creation, an error will be thrown and service creation will stop.

Attributes of the \<DCF> tag:

| Attribute | Description |
|--|--|
| entryPoint | Not used for service templates. |
| isRootLevel | \-  True: The entry point is the root RCA level, and the chain will be resolved from input to output.<br> -  False: The entry point is the maximum RCA level, and the chain will be resolved from output to input. |
| interfaceID | Not used for service templates |
| addExternals | \-  True: External connections will be added<br> -  False: No external connections will be added.<br> Default: False |
| templateEntryPoint | The element that serves as the entry point to calculate the DCF chain, defined either using the element name or the ID (in the format DMA ID/element ID). |
| templateInterface | The interface from which to start calculating the DCF chain. |
| templateOptions | Reserved for future use. |

> [!NOTE]
> Though it is not possible to use wildcards for the *templateEntryPoint* or *templateInterface*, it is possible to use placeholders from the service template.

Example of a Service.xml file:

```xml
<Service version="2" dmaid="131" id="18" name="MyDCFTemplate" description="" vdxfile="" ignoreTimeouts="false" isTemplate="true" generatedFromTemplate="" type="" timestamp="636253477373961897" keepCopiesOnReApply="false">
  <Element idx="1" dmaid="132" eid="513351" alias="[element:1:title]" group="-1" notUsedCapped="Normal" includedCapped="Critical" service="false" serviceElement="False" includeTrigger="" excludeTrigger="" notUsedTrigger="" state="" description="1"  templateOptions="" />
  <RCA>
    <DCF entryPoint="" isRootLevel="True" interfaceID="" addExternals="True" templateEntryPoint="ID:[data:Element Entry Point]" templateInterface="ID:[data:Interface Entry Points]" templateOptions="" />
  </RCA>
  <Triggers />
  <Properties />
  <Template autoGenerateName="DCFTemplatedService" options="NoSLA" generateDescription="">
    <RequiredData neededBeforeElements="true" name="Element Entry Point" title="Element Entry Point" type="text" values="" displayValues=""  defaultValue="" options="" />
    <RequiredData neededBeforeElements="true" name="Interface Entry Points" title="Interface Entry Points" type="text" values="" displayValues=""  defaultValue="" options="" />
  </Template>
</Service>
```
