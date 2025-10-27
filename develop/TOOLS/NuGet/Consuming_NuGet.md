---
uid: Consuming_NuGet
---

# Consuming NuGet packages

You can consume [NuGet packages](https://learn.microsoft.com/en-us/nuget/what-is-nuget) in your Visual Studio protocol or Automation script solution by going to the [NuGet Package Manager](https://learn.microsoft.com/en-us/nuget/quickstart/install-and-use-a-package-in-visual-studio), searching for existing NuGet packages and installing them.

When DIS compiles the Automation script or protocol, it will extract the required assemblies from the NuGet packages and save them alongside the protocol.xml/script.xml. To make sure elements using such a protocol can work correctly, in recent DataMiner versions, those folders with assemblies need to be placed in the folder `C:\Skyline DataMiner\ProtocolScripts\DllImport`.

Note that support for subfolders in the `ProtocolScripts` folder is introduced in DataMiner 9.6.12 (RN 23565). However, the `DllImport` subfolder of the `ProtocolScripts` folder is only introduced in DataMiner 10.0.10 (RN 26605). This means that prior to DataMiner 10.0.10, only the `Files` and `ProtocolScripts` folder are used as hint paths. For example, when you have the `QAction@dllImport` value `slc.lib.common\1.1.4.2\lib\net462\SLC.Lib.Common.dll`, DataMiner will try to find the assembly in the location `C:\Skyline DataMiner\ProtocolScripts\slc.lib.common\1.1.4.2\lib\net462\SLC.Lib.Common.dll`. Starting from DataMiner 10.0.10, the `ProtocolScripts\DllImport` folder is added as an additional hint path (which is probed before the `Files` and `ProtocolScripts` folders). In case of the above-mentioned example, this means that the following path will be tried: `C:\Skyline DataMiner\ProtocolScripts\DllImport\slc.lib.common\1.1.4.2\lib\net462\SLC.Lib.Common.dll`. Note also that only from DataMiner 10.0.10 onwards, subfolder paths for assemblies in a .dmprotocol package will be preserved during installation.

> [!NOTE]
> For DIS and CI/CD, the *PackageReference* package management format must be used. The *packages.config* package management format is not supported.

> [!IMPORTANT]
>
> - **Do not manually put assemblies used by a protocol in the folder** `C:\Skyline DataMiner\ProtocolScripts\DllImport`. Instead, install the protocol via a .dmprotocol or .dmapp package (if you publish from [DIS](xref:Overall_concept_of_the_DataMiner_Integration_Studio), a package is created in the background, and that package is installed by DIS). When installation happens via a .dmprotocol or .dmapp package, DataMiner will know about these assemblies and make sure these are synchronized.
> - DIS currently **only processes the *lib* folder** of NuGet packages. Other folders such as *ref* or *runtimes* are currently not supported.
> - In a protocol or Automation script solution, you **cannot use NuGet packages that generate code** (e.g. the [Grpc.Tools](https://www.nuget.org/packages/Grpc.Tools) NuGet package). This is because when DataMiner compiles a protocol or Automation script, it only considers the C# code that is included in the XML file of the protocol or Automation script. Therefore, if you want to make use of this NuGet package, you need to include the generated code in the protocol or Automation script solution.
> - When consuming different versions of the same NuGet package, make sure you are aware of the **potential pitfalls** when doing so as explained in [Run-time assembly binding](xref:Run_Time_Assembly_Binding).

At Skyline, an [internal NuGet store](https://dev.azure.com/skyline-cloud/Private_NuGets/_artifacts/feed/skyline-private-nugets) is available where Skyline employees can produce and consume private libraries. As a Skyline employee, you will need to [add this store in Visual Studio](https://learn.microsoft.com/en-us/nuget/consume-packages/install-use-packages-visual-studio#package-sources) in order to use it.

## Licensing

NuGet libraries from [nuget.org](https://nuget.org) are considered third-party libraries, so make sure licensing is OK.

Consult the Stop/Go/Caution list on [SharePoint](https://skylinebe.sharepoint.com/sites/LegalPortal/SitePages/Stop-Go-Caution-List.aspx). If your license does not appear on the list, or if the use you intend (i.e. internal vs. distribution) is not listed for that license, the use will be considered a "Stop".

If you are unsure as to the identification of the license, please contact the [OSS team](mailto:oss@skyline.be).

## Avoid NuGet packages with direct external communication

Try to avoid using NuGet packages that perform direct external communication (unless using them will drastically reduce development time).

A NuGet package with direct communication will circumvent the use of DataMiner processes. This will cause the following issues:

- It will not be possible to edit some communication settings (e.g. retries, timeouts) via the element settings.
- Communication will be hidden from the Stream Viewer.
- Unless this is taken into account during development, there will be no element timeouts when communication is lost.

We try to solve some of these limitations by writing middleware packages that bridge the QAction with the external communication package or technology. For more information, see [Communication middleware](xref:Nuget_Communication_Middleware).

## Accessing GitHub NuGet registry in Visual Studio

### Step 1: Creating a personal access token

> [!NOTE]
> If you have already created a token to create packages, you can immediately proceed to step 2. See [Producing NuGet packages via GitHub](xref:Producing_NuGet_GitHub).

To access the GitHub NuGet registry, you need a personal access token (PAT). Follow these steps:

1. Follow the instructions in [the official GitHub Docs](https://docs.github.com/en/authentication/keeping-your-account-and-data-secure/managing-your-personal-access-tokens#creating-a-personal-access-token-classic) to create a PAT.

   - **Expiration**: Choose the *No expiration* default option.

     > [!NOTE]
     > You can choose to set an expiration date for your token. However, this will require you to update the token more frequently on your local machine and repositories.

   - **Scope**: Select the *read:packages* scope.

1. Click *Generate token* in the lower-left corner.

1. Copy your personal access token. You will not be able to see it again afterwards.

### Step 2: Configuring Visual Studio for GitHub packages

1. Open Visual Studio and go to *Tools > NuGet Package Manager > Package Manager Settings* to access the *Options* pop-up window.

1. Select *Package Sources* from the dropdown list on the left.

1. In the *Package Sources* tab, click the green plus icon in the top-right corner to add a new package source.

   - **Name**: Choose a name for your package source.

   - **Source**: Enter `https://nuget.pkg.github.com/SkylineCommunications/index.json`.

1. Click *Update* to save the entry.

### Step 3: Providing credentials

To handle the credentials, follow these steps:

1. When adding a package to a project, select the package source created in step 2.

1. In the pop-up window, provide the following credentials:

   - **Username**: Enter your GitHub username.

   - **Password**: Enter your personal access token.

     > [!NOTE]
     > Select *remember password* to avoid entering your PAT each time. If the pop-up window keeps getting shown anyway, refer to [Issues with credentials](#issues-with-credentials) for help.

#### Editing credentials

In case you are using a token that has an expiration date or if you entered the wrong value, you can edit the credentials:

1. Navigate to *Control Panel > User Accounts > Credential Manager* and select *Windows Credentials* to access a list of all credentials.

   A distinction is made between Visual Studio 2019 and 2022, although they share the same fundamental principles.

   - Visual Studio 2019: *Generic Credentials > VSCredentials_nuget.pkg.github.com*

   - Visual Studio 2022: *Windows Credentials > nuget.pkg.github.com*

1. Select the credentials you want to edit and click *Edit* in the lower-left corner.

1. Update the username and/or password, and click *Save*.

#### Issues with credentials

If you encounter problems with credentials in Visual Studio, particularly when the credentials pop-up window appears repeatedly, you can follow these steps to resolve the issue:

1. Ensure that all instances of Visual Studio are closed to prevent accidental credential caching.

1. Remove the stored credentials from the Windows Credential Manager. For detailed instructions, see [Editing credentials](#editing-credentials).

1. Navigate to the *%AppData%\NuGet* directory and locate the **NuGet.config** file. Inside this file, you will find XML content similar to the following:

   ```xml
   <?xml version="1.0" encoding="utf-8"?>
   <configuration>
      <packageSources>
         <add key="nuget.org" value="https://api.nuget.org/v3/index.json" protocolVersion="3" />
         <add key="Microsoft Visual Studio Offline Packages" value="C:\Program Files (x86)\Microsoft SDKs\NuGetPackages\" />
         <add key="GitHub" value="https://nuget.pkg.github.com/SkylineCommunications/index.json" />
      </packageSources>
      <packageRestore>
         <add key="enabled" value="True" />
         <add key="automatic" value="True" />
      </packageRestore>
      <bindingRedirects>
         <add key="skip" value="False" />
      </bindingRedirects>
      <packageManagement>
         <add key="format" value="1" />
         <add key="disabled" value="False" />
      </packageManagement>
   </configuration>
   ```

   In this file, you can add your credentials according to the [Microsoft guidelines](https://learn.microsoft.com/en-us/nuget/reference/nuget-config-file#packagesourcecredentials).

> [!IMPORTANT]
> If you choose to add your credentials in an unencrypted manner, it is highly recommended to restrict the token's scope to only allow reading packages, as explained in [step 1 of creating a personal access token](#step-1-creating-a-personal-access-token).

## Accessing the Azure NuGet registry

> [!NOTE]
> This NuGet registry is to be used by Skyline employees only. More information is available on [Skyline Internal Docs](https://internaldocs.skyline.be/DevDocs/Skyline%20Software%20Development%20Toolkit/Private%20NuGet%20Store.html) (accessible for Skyline employees only).
