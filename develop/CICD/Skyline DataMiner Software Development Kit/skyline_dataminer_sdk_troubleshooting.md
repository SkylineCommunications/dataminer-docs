---
uid: skyline_dataminer_sdk_troubleshooting
keywords: Skyline.DataMiner.Sdk, Software Development Kit, Troubleshooting, help, issue
---

# Skyline DataMiner SDK - Troubleshooting

## Missing DataMiner Project Templates

Ensure you are using **Visual Studio 2022 or higher**.

Check if the templates are installed by running the following command in the command line:

```sh
dotnet new uninstall
```

You should see `Skyline.DataMiner.VisualStudioTemplates` version **2.0.3 or higher** listed. If not, install the templates using one of the following methods:

- Install via CLI:
  
  ```sh
  dotnet new install skyline.dataminer.visualstudiotemplates
  ```

- Install or update **DataMiner Integration Studio (DIS)** via the [Visual Studio Marketplace](https://marketplace.visualstudio.com/items?itemName=skyline-communications.DataMinerIntegrationStudio) and restart Visual Studio.

## .NET SDK Not Found Error

The DataMiner SDK depends on the .NET SDK. If you encounter an error stating that no .NET SDKs were found, install the required SDK using:

```sh
winget install Microsoft.DotNet.SDK.8
```

## Unable to Find `Skyline.DataMiner.Sdk` in Visual Studio

The SDK is retrieved from **nuget.org**. Verify that it is configured as a NuGet source by running:

```sh
dotnet nuget list source
```

Ensure that the following source is listed:

```
nuget.org [Enabled]
```

If it is missing, add it using:

```sh
dotnet nuget add source https://api.nuget.org/v3/index.json -n "nuget.org"
```

### NuGet.org is Configured but SDK Still Not Found

Your **NuGet configuration** may be blocking access due to **Package Source Mapping**. To check:

1. Open **Visual Studio 2022**.
2. Navigate to **Options > NuGet Package Manager > Package Source Mapping**.
3. Ensure that `Skyline.DataMiner.Sdk` is not blocked from accessing `nuget.org`.

### Workaround: Manually Download SDK to Local NuGet Cache

If issues persist, manually download the SDK using:

```sh
dotnet tool install --global Skyline.DataMiner.Sdk.Download --version 1.0.1
dataminer-sdk-download
```

## Missing "Manage User Secrets" Context Menu in Visual Studio

The **Manage User Secrets** option is part of the ASP.NET and web development workflow. Enable it by:

1. Opening the **Visual Studio Installer**.
2. Selecting **Modify** on Visual Studio 2022 or higher.
3. Enabling the **ASP.NET and web development** workload.

## DotNet Publish Succeeds but Item is Not Visible in the Catalog

### Verify the Organization in the Catalog

Ensure you are viewing the **correct organization** in the Catalog, as published items default to **private**.

### Check `GenerateDataMinerPackage` Property

Ensure your **.csproj** file contains:

```xml
<GenerateDataMinerPackage>True</GenerateDataMinerPackage>
```

If this property is missing or set to `false`, publishing will 'succeed' without uploading a DataMiner Package to the Catalog.

## DotNet Publish Succeeds but New Version is Not Visible

Ensure the **version number** is updated before publishing:

- Check the **Visual Studio Project** (`.csproj` file).
- If using a custom **CI/CD**, update the version via CLI arguments.

If an existing version is uploaded, only **metadata and README** are updated—**the actual version previously released cannot be overwritten**.

## DIS Publish or Other Features Not Working with New Projects

### Check DIS and SDK Version Alignment

This issue is often due to an **outdated** or **misaligned** DIS or SDK version. To resolve:

1. Check **Visual Studio Notifications** for a new DIS version and update if available.
2. Verify the installed SDK version:
   - Locate `global.json` in your solution directory.
   - Compare the version with the latest stable release on [NuGet](https://www.nuget.org/packages/Skyline.DataMiner.Sdk).

Example `global.json` file:

```json
{
   "msbuild-sdks": {
      "Skyline.DataMiner.Sdk": "1.1.0"
   }
}
```

Ensure the version is the **latest stable release** (i.e., without `"*-abc"` suffix).

---

If issues persist, consider reaching out to **Skyline Communications Support** for further assistance.