---
uid: AdvancedDVEsTogglingCreation
---

# Toggling DVE creation

If [Swarming](xref:Swarming) is not enabled, in the *Element.xml* file for a parent DVE element (C:\Skyline DataMiner\Elements\[Element Name]\), you can define the enabling or disabling of DVE child element creation.

```xml
<Element>
   <Name dvecreate="false">DVE Main Element</Name>
</Element>
```

If Swarming is enabled, this configuration is stored in the database instead.

By default, this setting is set to true in memory. Using a NotifyDataMiner ([NT_DVE_CREATION_FLAG (340)](xref:NT_DVE_CREATION_FLAG)), the creation of DVEs can be enabled or disabled.

When you create or edit a DVE parent element in DataMiner Cube, you can also [enable or disable the creation of DVE child elements directly in Cube](xref:Dynamic_virtual_elements#enabling-or-disabling-the-creation-of-dve-child-elements).
