---
uid: Creating_an_app_package
---

# Application package structure

The extension of the package is *.dmapp*. The package can be opened using any archive program (e.g. 7‑zip, Winzip). It consists of the files and folders detailed below.

## AppInfo.xml

This file contains general information about the application:

- **AppInfo.Name**: The name of the application, used as a unique identifier.

- **AppInfo.DisplayName**: The user-friendly name of the application. This name can change between versions, as long as the name used as unique identifier stays the same.

- **AppInfo.Version**: The version of the application. The expected format is `x.x.x` or `x.x.x-CUx` where x is an integer value.

- **AppInfo.Description**: The description of the application package.

- **AppInfo.MinDmaVersion**: The minimum required DataMiner version to be able to install the application. The expected format is `x.x.x.x – xxx`, consisting of the version number and the build number, with x being an integer value.

- **AppInfo.AllowMultipleInstalledVersions**: Boolean value indicating if multiple versions of the application can be installed at the same time.

- **AppInfo.LastModifiedAt**: The time when the package was last modified. The expected format is `yyyy-mm-ddThh:mm:ss`.

- **AppInfo.Configuration**: A collection of configuration entries defining a configuration script input parameter.

  - **AppInfo.Configuration.Entries.Entry**: Consist of an ID and a Name.

  - **AppInfo.Configuration.Entries.Entry.ID**: A unique identifier for the input parameter, which will be used in the configuration script to access the value.

  - **AppInfo.Configuration.Entries.Entry.Name**: Contains the name of the input parameter that will be displayed to the user in a pop-up message, requesting a value.

Example:

```xml
<AppInfo>
   <Name>Demo</Name>
   <DisplayName>Demo</DisplayName>
   <Version>1.0.1</Version>
   <Description>Demo package</Description>
   <MinDmaVersion>10.0.11</MinDmaVersion>
   <AllowMultipleInstalledVersions>true</AllowMultipleInstalledVersions>
   <LastModifiedAt>2020-10-09T13:03:42</LastModifiedAt>
   <Configuration>
      <Entries>
         <Entry>
            <ID>username</ID>
            <Name>Username</Name>
         </Entry>
         <Entry>
            <ID>password</ID>
            <Name>Password</Name>
         </Entry>
      </Entries>
   </Configuration>
</AppInfo>
```

## Scripts

This folder contains the following scripts and optional folders:

- **Install.xml**:
  - Defines the installation procedure linked to this application version.
  - Installed applications are stored in the folder `C:\Skyline DataMiner\AppPackages\Installed`.
  - Is triggered automatically when SLTaskBarUtility is used via a *.dmupgrade* package.
  - Can be triggered manually via the SLNETClientTest tool.
- **Config.xml**:
  - Defines the configuration procedure linked to this application version (optional).
  - Can only be triggered via the SLNETClientTest tool.
  - Requires user interaction.
- **Uninstall.xml**:
  - Defines the uninstall procedure linked to this application version (optional).
  - If an application is installed with **AllowMultipleInstalledVersions* set to false, the uninstall script of each previous installed version of the application will be executed.
  - If an application package contains no uninstall script or an invalid uninstall script, uninstalling the application will remove the install folder of the application from all DMAs without any other actions in the DMS, e.g. deletion of elements.
  - Can be triggered via the SLNETClientTest tool.
  - The user permission *Install app packages* is required in order to trigger uninstalling an application package.
- **InstallDependencies**: A folder containing all DLL files used by the installation script.
- **ConfigureDependencies**: A folder containing all DLL files used by the configuration script.
- **UninstallDependencies**: A folder containing all DLL files used by the script to uninstall the application.

## AppInstallContent

This folder contains all files needed by the installation script, e.g. *.dmprotocol* packages.
