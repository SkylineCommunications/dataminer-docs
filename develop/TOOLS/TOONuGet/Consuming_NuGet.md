---
uid: Consuming_NuGet
---

# Consuming NuGet Packages

NuGet packages can be consumed in your Visual Studio Protocol or Automation script solution by going to the NuGet Manager and searching for existing NuGets and installing them.

When DIS compiles the Automation script or Protocol it will extract the required dll’s from the NuGets and save them alongside the protocol.xml/script.xml. Those folders with dll’s need to be placed under the Skyline DataMiner/ProtocolScripts/DllImports folder in DataMiner for elements of the protocol to work correctly.

DIS and CI/CD support NuGets of type:
    - PackageReference
    - Packages.config

Within Skyline, we also have an internal NuGet store: http://devcore3:81/nuget where you can produce & consume private libraries. You’ll need to add this store in the Visual Studio options to use it.

The Class Library (Common, Protocol and Automation code) is also available and ready to be used as a nuget on the Internal Store instead of through DIS Code Generation if you want.

This can help solve some of the common issues that occurred with DIS Code Generation such as the OS Maximum Path Length problems.
It will also allow you to more easily make your own libraries on top of the class library.

> [!NOTE]
> There is a breaking change for these versions of the class library. InterApp Calls are no longer able to use reflection. 
> This makes their use much more stable, but it does mean you always need to provide a list of knowntypes for every call or serialize/deserialize.
> Upgrading to these versions will likely cause compilation issues that need to be fixed.
> You are now however able to put all your Message classes into a Custom Solution and re-use that as a NuGet of your own creation.

> [!NOTE]
> NuGet Libraries from nuget.org are considered 3rd party libraries so make sure licensing is ok.
> Consult the Stop/Go/Caution list. If your license does not appear on the list, or if the use you intend (i.e. internal vs. distribution) is not listed for that license, the use will be considered as a ‘Stop’.
> If you are unsure as to the identification of the license, please contact the OSS team (oss@skyline.be).

> [!NOTE]
> Try to avoid using NuGets that perform direct external communication (unless using them will drastically improve development times). 
> A NuGet with direct communication will circumvent the use of DataMiner processes.
> This would cause the following:
>- Some Communication settings cannot be edited through element settings (retries, timeouts)
>- Communication will be hidden from the StreamViewer
>- Unless taken into account during development, element timeouts won't occur on communication loss.
