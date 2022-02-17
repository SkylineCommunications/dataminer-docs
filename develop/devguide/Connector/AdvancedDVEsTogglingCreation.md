---
uid: AdvancedDVEsTogglingCreation
---

# Toggling DVE creation

Since DataMiner version 7.5, it is possible to define in the protocol to enable or disable the creation of DVE elements. This is a setting that is configured in the main element. It can be found in the Element.xml of the specific element (C:\Skyline DataMiner\Elements\[Element Name]\).

```xml
<Element>
   <Name dvecreate="false">DVE Main Element</Name>
</Element>
```

By default, this setting is set to true in memory. Using a NotifyDataMiner (type 340, "NT_DVE_CREATION_FLAG"), the creation of DVEs can be enabled or disabled. (See [NT_DVE_CREATION_FLAG (340)](xref:NT_DVE_CREATION_FLAG).)

Since DataMiner version 8.0.3, DataMiner Cube supports the toggling of DVE creation during element creation or editing. (See [Enabling or disabling the creation of DVE child elements](xref:Dynamic_virtual_elements#enabling-or-disabling-the-creation-of-dve-child-elements) in the DataMiner User Guide).
