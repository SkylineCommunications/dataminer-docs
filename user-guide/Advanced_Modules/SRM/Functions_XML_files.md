---
uid: Functions_XML_files
---

# Functions XML files

In this section:

> [!TIP]
> See also: [Implementing virtual functions](xref:implementing_function_srm)

### About functions files

Functions are defined in DataMiner by means of XML files linked to protocols. These files are located within the *Functions* subfolder of each relevant protocol folder in *C:\\Skyline DataMiner\\Protocols*.

Based on these functions XML files, “virtual function” elements can be created for elements that use the matching protocol. Such virtual function elements, or “virtual function resources”, are created by the Service & Resource Management module when the functions are in use. It is not possible to manually delete or edit these elements, change their state (e.g. pause or stop them), mask these elements, assign alarm or trend templates to them or use them in element simulations. Overall, they act much like DVE child elements, except that they are controlled by the Service & Resource Management module instead of by a DVE parent element.

In the Protocols & Templates module, virtual function definitions are indicated in the same way as DVE child protocols, except with a different icon. This can be a default icon or a custom icon defined in the functions XML file. The same icon will also be used to display the virtual function elements in the Surveyor.

> [!NOTE]
>
> - Several functions XML files can be uploaded for one protocol, but in that case each of the files must have a unique file name.
> - When a functions XML file is uploaded to a protocol, the system will check the validity of the XML file structure. An information event will indicate whether the upload succeeded or failed, or if there is a duplicate file name.
> - In addition to functions XML files, the system can also contain virtual function protocols that are automatically generated based on virtual function definitions. These are listed in the *Virtual functions* section at the bottom of the first column of the Protocols & Templates module.

### Functions XML structure

A functions XML file has the following basic file structure:

```xml
<Functions>
  <Version>1.0.0.0</Version>
  <Protocol>
    <Name>MyProtocolName</Name>
  </Protocol>
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

The file includes the following tags:

| Tag | Description |
|--|--|
| Protocol.Name | Indicates the name of the protocol that the functions file depends on. This tag must be specified in order to make it possible to upload the file via the Protocols & Templates module. |
| Version | Contains the version number of the functions file. |
| Function | Defines a function for the protocol. This tag can have the following attributes:<br> -  **id**: The unique GUID of the function.<br> -  **name**: The name of the protocol function (e.g. encoder, decoder). The name of VFs created with this element will consist of the main protocol name followed by this name: “mainProtocolName.Name”.<br> -  **maxInstances**: Determines the maximum number of instances of this function that can be active at the same time.<br> -  **profile** (optional): The GUID of the profile corresponding to the function. |
| Function.Parameters  | Contains a *Parameter* subtag for each parameter of the function. These are the parameters that will be exported to the function from the main protocol.<br> The *Parameter* subtags have a mandatory **id** attribute, which indicates the parameter ID. |
| Function.EntryPoints | Links to a table in the main protocol to which the function is linked. If resources are made based on the function, they are linked to the rows of this table.<br> This tag can have the following attributes:<br> -  **pid**: Links to a table parameter that contains the available entry points.<br> -  **type**: Reserved for future use. |
| Function.ExportRules | This tag functions similarly to the *ExportRules* tag for a DVE element. It can have the following attributes:<br> -  **regex**: Allows you to specify regular expression to find particular tag values.<br> -  **tag**: Indicates the XML tag the rule should be applied to.<br> -  **attribute**: Specifies the attribute of the tag specified in the “tag” attribute to which this rule should be applied.<br> -  **value**: Indicates the value that should be set in the XML tag.<br> -  **whereTag**, **whereAttribute**, **whereValue**: Allow you to specify a condition determining when the export rule will be applied. <br> Note that *whereAttribute* is only available from DataMiner 9.5.10 onwards. From that version of DataMiner onwards, you can use the *ExportRules* tag to overrule the positions of exported parameters. |
| Function.Interfaces  | Contains an *Interface* subtag for each interface available on the function.<br> The *Interface* subtags can have the following attributes:<br> -  **id** (mandatory): The unique GUID of the interface.<br> -  **name** (mandatory): The name of the interface.<br> -  **type** (mandatory): The interface type, which can be *in*, *out* or *inout*.<br> -  **parameterGroupLink** (optional): Links to a parameter group in the protocol to which the function is linked.<br> -  **profile** (optional): The GUID of the profile corresponding to the interface.<br> -  **broadcast** (optional): Available from DataMiner 9.5.7 onwards. When set to “true”, this attribute indicates that there is no actual DCF connection, but the interface acts as a broadcaster to one or more receiving interfaces. |
| Function.Graphical   | Contains a CDATA tag with the configuration of the function’s icon. Prior to DataMiner 10.0.5, only XAML format is supported for the icons. From DataMiner 10.0.5, SVG icons are also supported. |

The following example illustrates how a XAML or SVG icon can be configured:

```xml
<Functions>
  <Version>1.0.3</Version>
  <Protocol><Name>Icons example</Name></Protocol>
  <Function id="fcc2bafd-3847-44e4-9412-097f895f8350" name="Wave" maxInstances="1000" profile="91615c02-22f2-4580-80bd-3d0d6a63cf9f">
    <Parameters>
      <Parameter id="1"/>
      <Parameter id="2"/>
    </Parameters>
    <EntryPoints/>
    <Graphical>
    <![CDATA[<?xml version="1.0" encoding="UTF-8"?>
    <Viewbox Width="24.186" Height="11.801" xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation" xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">
    <Canvas Width="24.186" Height="11.801">
      <Canvas>
        <Canvas>
          <Canvas>
            <Path StrokeThickness="0.4" Stroke="#ff221f1f" StrokeStartLineCap="Round" StrokeEndLineCap="Round" StrokeLineJoin="Round" Data="F1 M 11.788,3.632 L 14.053,5.897 L 11.781,8.169"/>
            <Path StrokeThickness="0.4" Stroke="#ff221f1f" StrokeStartLineCap="Round" StrokeEndLineCap="Round" StrokeLineJoin="Round" Data="F1 M 13.904,5.901 L 0.210,5.901"/>
          </Canvas>
          <Path StrokeThickness="0.4" Stroke="#ff221f1f" StrokeStartLineCap="Round" StrokeEndLineCap="Round" StrokeLineJoin="Round" Data="F1 M 23.981,11.596 L 7.089,11.596 L 7.089,0.205 L 23.981,0.205 L 23.981,11.596 Z"/>
        </Canvas>
      </Canvas>
    </Canvas>
    </Viewbox>]]>
    </Graphical>
  </Function>
  <Function id="fcc2bafd-3847-44e4-9412-097f895f8351" name="Kick" maxInstances="1000" profile="c3129b0e-ce57-4492-986d-823940a25b6c" parent="7a430c94-cc1f-4ec0-b41d-744edcd316b5">
    <Parameters>
      <Parameter id="3"/>
    </Parameters>
    <EntryPoints/>
    <Graphical>
    <![CDATA[
    <svg version="1.1" id="Layer_1" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" x="0px" y="0px" width="512px" height="512px" viewBox="0 0 512 512" enable-background="new 0 0 512 512" xml:space="preserve">
      <g>
        <g>
          <g>
            <path fill="#020202" M204.192,62.194c14.147-20.472,29.339-41.613,50.963-54.72c21.323,12.782,36.366,33.547,50.311,53.656 c32.847,49.754,52.929,109.515,48.878,169.578c10.615,8.898,21.537,17.441,31.994,26.521 c15.011,13.797,22.02,35.319,18.406,55.327c-5.036,25.275-9.876,50.607-15.206,75.813c-2.963,12.968-20.508,18.905-30.823,10.62 c-17.121-14.291-33.816-29.108-50.932-43.417c-12.95,12.462-30.153,20.772-48.214,21.773 c-20.791,1.466-41.375-7.156-56.448-21.242c-12.28,9.401-23.666,20.686-35.664,30.755c-5.799,4.66-10.621,10.784-17.484,13.966 c-10.64,4.565-24.342-2.248-26.747-13.685c-5.479-24.642-11.203-49.24-16.52-73.92c-4.321-20.878,3.332-43.61,19.419-57.607 c9.313-7.822,18.756-15.487,28.243-23.096c2.643-1.39,1.315-4.596,1.465-6.951C153.005,167.614,172.8,110.333,204.192,62.194z  M220.995,138.526c-12.424,15.994-10.921,40.768,3.488,55.052c15.255,16.809,44.15,17.422,60.106,1.29 c12.317-11.253,16.482-30.146,10.603-45.671c-5.387-14.967-19.809-26.195-35.671-27.591 C244.873,119.92,229.706,126.659,220.995,138.526z"/>
          </g>
          <path fill="#020202" d="M198.263,407.819c-0.213-7.266,8.83-12.262,14.942-8.417c25.87,13.32,58.027,13.314,83.896-0.007 c5.937-3.645,14.736,0.733,14.955,7.803c0.087,15.432,0.105,30.88,0.024,46.317c0.119,7.533-9.832,12.337-15.681,7.626 c-4.452-3.926-8.467-8.341-12.75-12.461c-6.776,13.201-13.163,26.602-19.995,39.772c-3.281,6.275-13.533,6.318-16.877,0.105 c-6.87-13.195-13.213-26.676-20.121-39.858c-4.221,4.157-8.248,8.548-12.694,12.468c-5.824,4.734-15.756-0.162-15.675-7.647 C198.163,438.291,198.244,423.055,198.263,407.819z"/>
        </g>
        <circle fill="#020202" cx="254.831" cy="164.509" r="20.812"/>
      </g>
    </svg>
    ]]>
    </Graphical>
  </Function>
</Functions>
```

### Uploading a functions XML file in DataMiner Cube

From DataMiner 9.5.4 onwards, it is possible to upload functions XML files in the Protocols & Templates module.

To do so, follow the same procedure as for a *Protocol.xml* file. See [Uploading a Protocol.xml file](xref:Adding_a_protocol_or_protocol_version_to_your_DataMiner_System#uploading-a-protocolxml-file).

> [!NOTE]
> Uploading a functions XML file is only possible if the server has the SRM license, the name of the file is unique, and the file has the Protocol tag configured (see [Functions XML structure](#functions-xml-structure)).

### Setting a functions file active

If there are several functions XML files for one protocol, you can select to set a different functions XML file as the active file. To do so, in the Protocols & Templates module, right-click the file in the *Functions files* list and select *Set as active functions file*.

> [!NOTE]
> It may not be possible to set a different functions file active if the current active file is in use in a service definition, booking definition or planned booking instance and the change of file entails one or more of the following modifications:
>
> - removing a virtual function definition
> - lowering the maximum number of instances of a virtual function definition
> - changing the name of a virtual function definition to a name that is not unique within the protocol function version
> - changing the profile of a virtual function definition
> - changing the parent of a virtual function definition
> - changing entry points of a virtual function definition
> - removing an interface of a virtual function definition

### Deleting a functions file

To delete a functions file (from DataMiner 9.5.13 onwards):

- In the Protocols & Templates module, right-click the functions file you want to remove and select *Delete*.

> [!NOTE]
> Only inactive functions files can be removed. In addition, in case the functions file is in use in the Service & Resource Management configuration, removing the file will only be possible with the [Modules > Services > Definitions > Force Updates](xref:DataMiner_user_permissions#modules--services--definitions--force-updates) (or prior to DataMiner 9.6.5 [Modules > Service Manager > Force updates](xref:DataMiner_user_permissions#modules--service-manager--definitions--force-updates)) user permission.
