---
uid: AdvancedDVEsTogglingCreation
---

# Toggling DVE creation

In a protocol, you can define the enabling or disabling of DVE element creation. This is a setting that is configured in the main element. It can be found in the *Element.xml* of the specific element (C:\Skyline DataMiner\Elements\[Element Name]\).

```xml
<Element>
   <Name dvecreate="false">DVE Main Element</Name>
</Element>
```

By default, this setting is set to true in memory. Using a NotifyDataMiner (type 340, "NT_DVE_CREATION_FLAG"), the creation of DVEs can be enabled or disabled. (See [NT_DVE_CREATION_FLAG (340)](xref:NT_DVE_CREATION_FLAG).)

When you create or edit a DVE parent element in DataMiner Cube, you can also enable or disable the creation of DVE child elements directly in Cube. See [Enabling or disabling the creation of DVE child elements](xref:Dynamic_virtual_elements#enabling-or-disabling-the-creation-of-dve-child-elements).
