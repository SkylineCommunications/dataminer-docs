---
uid: Consuming_NuGet
---

# Consuming NuGet packages

You can consume NuGet packages in your Visual Studio protocol or Automation script solution by going to the NuGet Manager, searching for existing NuGets and installing them.

When DIS compiles the Automation script or protocol, it will extract the required DLLs from the NuGets and save them alongside the protocol.xml/script.xml. To make sure elements using such a protocol can work correctly, those folders with DLLs need to be placed in the *Skyline DataMiner/ProtocolScripts/DllImport* folder.

DIS and CI/CD support NuGets of the following types:

- PackageReference
- Packages.config

> [!IMPORTANT]
> If you encounter issues with NuGets and building solutions locally, this is often related to the maximum path length of 260 characters in Windows. See [Fixing issues related to the path length](#fixing-issues-related-to-the-path-length)

Within Skyline, we have an internal NuGet store (<http://devcore3:81/nuget>) where Skyline employees can produce and consume private libraries. You will need to add this store in the Visual Studio options to use it.

## Using the Class Library as a NuGet

The Class Library (Common, Protocol and Automation code) is also available and ready to be used as a NuGet in the internal store.

It is possible to use this instead of DIS Code Generation. This can help solve some of the common issues that occur with DIS Code Generation, such as OS maximum path length problems. It will also allow you to more easily make your own libraries on top of the class library.

> [!NOTE]
> There is a breaking change for these versions of the Class Library. InterApp Calls are no longer able to use reflection. This makes their use much more stable, but it does mean that you always need to provide a list of known types for every call or serialize/deserialize operation. Upgrading to these versions will likely cause compilation issues that need to be fixed. However, you can now put all your Message classes into a custom solution and re-use that as a NuGet of your own creation.

## Licensing

NuGet Libraries from nuget.org are considered third-party libraries, so make sure licensing is OK.

Consult the Stop/Go/Caution list on the internal Skyline wiki. If your license does not appear on the list, or if the use you intend (i.e. internal vs. distribution) is not listed for that license, the use will be considered a "Stop".

If you are unsure as to the identification of the license, please contact the OSS team (oss@skyline.be).

## Avoid NuGets with direct external communication

Try to avoid using NuGets that perform direct external communication (unless using them will drastically improve development times).

A NuGet with direct communication will circumvent the use of DataMiner processes. This will cause the following issues:

- It will not be possible to edit some communication settings (e.g. retries, timeouts) via the element settings.

- Communication will be hidden from the Stream Viewer.

- Unless this is taken into account during development, there will be no element timeouts when communication is lsot.

## Fixing issues related to the path length

Issues with NuGets and building solutions locally are often related to the maximum path length of 260 characters in Windows. This usually results in exceptions mentioning not finding part of the path.

To fix this:

- Use *PackageReferences* for your NuGets:

  1. In the Visual Studio menu bar, select *Debug* > *Options*
  1. In the Options window, search for "NuGet".
  1. Set *Default package management format* to *PackageReferences*.
  1. Uninstall all your NuGets and close your Visual Studio solution.
  1. Open your solution, install all the NuGets again, and select *PackageReferences* when prompted.

- Adjust `%userprofile%\AppData\Roaming\NuGet\NuGet.Config`, by adding or updating the following tag:

  ```xml
  <configuration>
    ...
     <config>
        <add key="globalPackagesFolder" value="c:\pfpr" />
     </config>
  </configuration>
  ```
