---
uid: Consuming_NuGet
---

# Consuming NuGet packages

You can consume [NuGet packages](https://learn.microsoft.com/en-us/nuget/what-is-nuget) in your Visual Studio protocol or Automation script solution by going to the [NuGet Package Manager](https://learn.microsoft.com/en-us/nuget/quickstart/install-and-use-a-package-in-visual-studio), searching for existing NuGets and installing them.

When DIS compiles the Automation script or protocol, it will extract the required DLLs from the NuGet packages and save them alongside the protocol.xml/script.xml. To make sure elements using such a protocol can work correctly, those folders with DLLs need to be placed in the *Skyline DataMiner/ProtocolScripts/DllImport* folder.

> [!NOTE]
> Support for subfolders in the ProtocolScripts folder is introduced in DataMiner 9.6.12 (RN 23565). However, the DllImport subfolder of the ProtocolScripts folder is  only introduced in DataMiner 10.0.10 (RN 26605).
>
> This means that prior to DataMiner 10.0.10, only the Files and ProtocolScripts folder are used as hint paths. For example, when you have the QAction@dllImport value `slc.lib.common\1.1.4.2\lib\net462\SLC.Lib.Common.dll`, DataMiner will try to find the assembly in the location `C:\Skyline DataMiner\ProtocolScripts\slc.lib.common\1.1.4.2\lib\net462\SLC.Lib.Common.dll`.
> Starting from DataMiner 10.0.10, the ProtocolScripts\\DllImport folder is added as an additional hint path (which is probed before the Files and ProtocolScripts folders). For the previous example, this means the following path will be tried first:  `C:\Skyline DataMiner\ProtocolScripts\DllImport\slc.lib.common\1.1.4.2\lib\net462\SLC.Lib.Common.dll`.
>
> Also note that only from DataMiner 10.0.10 onwards, subfolder paths for assemblies in a .dmprotocol package will be preserved during installation. This means that prior to DataMiner 10.0.10, you have to put the DLLs in the correct subfolder manually if a subfolder structure should be used.

> [!NOTE]
> For DIS and CI/CD, the PackageReference package management format must be used. The packages.config packages management format is not supported.

> [!IMPORTANT]
> DIS currently only processes the *lib* folder of NuGet packages. Other folders such as *ref* or *runtimes* are currently not supported.

Within Skyline, we have an internal NuGet store (<https://devcore3/nuget>) where Skyline employees can produce and consume private libraries. You will need to [add this store in Visual Studio](https://learn.microsoft.com/en-us/nuget/consume-packages/install-use-packages-visual-studio#package-sources) to use it.

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

Try to avoid using NuGet packages that perform direct external communication (unless using them will drastically reduce development time).

A NuGet with direct communication will circumvent the use of DataMiner processes. This will cause the following issues:

- It will not be possible to edit some communication settings (e.g. retries, timeouts) via the element settings.
- Communication will be hidden from the Stream Viewer.
- Unless this is taken into account during development, there will be no element timeouts when communication is lost.

We try to solve some of these limitations by writing middleware packages that bridge the QAction with the external communication package or technology. For more information, go to [Communication middleware](xref:Nuget_Communication_Middleware).

## Access in Visual Studio towards GitHub NuGet registry

### Step 0: Create Personal Access Token

> [!NOTE]
> This step isn't required if you already created a token to create packages.
> See [Producing NuGet packages via GitHub](xref:Producing_NuGet_GitHub).

First off you need to make a Personal Access Token (PAT). This will enable you to read from the NuGet registry. More information on how to create a PAT can be found here: [Creating a personal access token (classic)](https://docs.github.com/en/authentication/keeping-your-account-and-data-secure/managing-your-personal-access-tokens#creating-a-personal-access-token-classic)

Set the expiration to *No expiration*. You can let it expire, but then you'll need to more frequently update this locally and on your repositories.

For the scopes select:

- *read:packages*

Click *Generate token* at the bottom and make sure to copy the token as you are unable to see it again afterwards!

### Step 1: Configure Visual Studio to see the GitHub packages

Open Visual Studio and go to *Tools* > *NuGet Package Manager* > *Package Manager Settings*. This will open the Options window.

In the *Package Sources* tab you need to add a new package source. Click the green plus sign to add a new entry. In the textboxes below you can fill in a *Name* (free to choose) and for the *Source* use `https://nuget.pkg.github.com/SkylineCommunications/index.json`. Click the Update button to make sure that the entry is properly saved.

### Step 2: Fill in credentials

The easiest way to handle this is by trying to add a package to a project and selecting the new package source. A popup will appear to ask for credentials. For the username, use your GitHub username and for the password the PAT token. Select the 'remember password' so that you don't have the fill it in each time.

#### Edit credentials

In case you use an expiring token or you entered a wrong value, you can go to the Windows Credentials in the *Control Panel* > *User Accounts* > *Credential Manager*.

This shows a list with all the credentials. There is a difference between Visual Studio 2019 & 2022, but in principle they are the same.

For Visual Studio 2019, you'll find the record under the *Generic Credentials* > *VSCredentials_nuget.pkg.github.com*.

For Visual Studio 2022, you'll find the record under the *Windows Credentials* > *nuget.pkg.github.com*.
