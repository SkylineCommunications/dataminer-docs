---
uid: GQI_Extensions_Best_Practices
---

# Best practices for developing GQI extensions

When developing a GQI extension, keep the following in mind:

- [Use DIS to create and publish extensions](#use-dis-to-create-and-publish-extensions)
- [Do not use Skyline.DataMiner.Automation](#do-not-use-skylinedataminerautomation)
- [Only use 64-bit assembly references](#only-use-64-bit-assembly-references)

## Use DIS to create and publish extensions

Using [DataMiner Integration Studio (DIS)](xref:DIS) in Visual Studio is the most efficient way to develop a GQI extension. You can use the *DataMiner Automation Script Solution* project template to get started or import an existing Automation script to edit.

This way of working gives you the best tools to write and maintain the required C# code. It also allows you to easily push your extension to a DataMiner Agent for testing.

Remember to **compile the script as a library**. You can configure this in your Automation Script project by adding the *preCompile* and *libraryName* parameters in the associated XML file:

```xml
<DMSScript>
 ...
 <Script>
  <Exe>
   ...
   <Param type="preCompile">true</Param>
   <Param type="libraryName">My GQI extension library name</Param>
  </Exe>
 </Script>
</DMSScript>
```

## Do not use Skyline.DataMiner.Automation

Never use references to the Skyline.DataMiner.Automation namespace in your GQI extension code.

If you [use DIS to create your extensions](#use-dis-to-create-and-publish-extensions), these references are automatically available through the *Skyline.DataMiner.Dev.Automation* NuGet package. They should only ever be used in actual Automation scripts.

Types and methods in this namespace have no use in a GQI extension and, more importantly, **will prevent GQI from loading your extension** (see: [Only use 64-bit DLL references](#only-use-64-bit-assembly-references)).

## Only use 64-bit assembly references

GQI runs in a 64-bit process and cannot load any extensions that require 32-bit assemblies. You should therefore only use 64-bit assembly references.
