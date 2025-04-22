---
uid: skyline_dataminer_sdk_troubleshooting
keywords: Skyline.DataMiner.Sdk, Software Development Kit, Troubleshooting, help, issue
---

# Troubleshooting – Skyline DataMiner SDK

Below you can find troubleshooting procedures for some common issues encountered with the Skyline DataMiner SDK.

If you have followed the procedures below, but the issue you have encountered persists, please [contact tech support](xref:Contacting_tech_support).

## Missing DataMiner project templates

If the DataMiner project templates are missing in Visual Studio:

1. Ensure you are using **Visual Studio 2022 or higher**.

1. Check if the **templates are installed** by running the following command in the command line:

   ```sh
   dotnet new uninstall
   ```

   You should see `Skyline.DataMiner.VisualStudioTemplates` version **2.0.3 or higher** listed.

1. If this is not listed, **install the templates** using one of the following methods:

   - Install via CLI:

     ```sh
     dotnet new install skyline.dataminer.visualstudiotemplates
     ```

   - Install or update DataMiner Integration Studio (DIS) via the [Visual Studio Marketplace](https://marketplace.visualstudio.com/items?itemName=skyline-communications.DataMinerIntegrationStudio) and restart Visual Studio.

## .NET SDK not found error

The DataMiner SDK depends on the .NET SDK.

If you encounter an error stating that no .NET SDKs were found, install the required SDK as follows:

```sh
winget install Microsoft.DotNet.SDK.8
```

## Unable to find Skyline.DataMiner.Sdk in Visual Studio

1. Visual Studio has to retrieve the SDK from **nuget.org**, so verify if this is configured as a NuGet source by running the following command:

   ```sh
   dotnet nuget list source
   ```

   The following source should be listed:

   ```
   nuget.org [Enabled]
   ```

1. If it is missing, add it as follows:

   ```sh
   dotnet nuget add source https://api.nuget.org/v3/index.json -n "nuget.org"
   ```

1. Alternatively, if it is not missing, make sure your NuGet configuration is not blocking access because of **package source mapping**:

   1. Open **Visual Studio 2022**.

   1. Navigate to *Options* > *NuGet Package Manager* > *Package Source Mapping*.

   1. Ensure that *Skyline.DataMiner.Sdk* is not blocked from accessing *nuget.org*.

1. If the issue still persists, manually **download the SDK** using the following command:

   ```sh
   dotnet tool install --global Skyline.DataMiner.Sdk.Download
   dataminer-sdk-download
   ```

## Missing 'Manage User Secrets' context menu in Visual Studio

The **Manage User Secrets** option is part of the ASP.NET and web development workflow. You can enable it as follows:

1. Open the **Visual Studio Installer**.

1. Select **Modify** for Visual Studio 2022 or higher.

1. Enable the **ASP.NET and web development** workload.

## DotNet publish succeeds but item is not visible in the Catalog

1. Check whether you are viewing the **correct organization** in the Catalog, as items are by default published as **private**.

1. Check whether your **.csproj** file contains the following property:

   ```xml
   <GenerateDataMinerPackage>True</GenerateDataMinerPackage>
   ```

   If this property is missing or set to `false`, publishing will "succeed" without actually uploading a DataMiner package to the Catalog.

## DotNet publish succeeds but the new version is not visible

Ensure the **version number** is updated before publishing:

- Check the **Visual Studio Project** (`.csproj` file).

- If you are using custom **CI/CD**, update the version via CLI arguments.

> [!NOTE]
> If an **existing version** is uploaded, only the **metadata and README** are updated. The previously released version itself **cannot be overwritten**.

## DIS publish or other features are not working with new projects

This issue is often caused by an outdated or misaligned DIS or SDK version. To resolve this, **check the DIS and SDK version alignment**:

1. Check *Visual Studio Notifications* for a new DIS version and update if available.

1. Verify the installed SDK version:

   1. Locate `global.json` in your solution directory.

   1. Compare the version with the latest stable release on [NuGet](https://www.nuget.org/packages/Skyline.DataMiner.Sdk).

      Example `global.json` file:

      ```json
      {
         "msbuild-sdks": {
            "Skyline.DataMiner.Sdk": "1.1.0"
         }
      }
      ```

      The version must be the **latest stable release** (i.e. without "*-abc" suffix).
