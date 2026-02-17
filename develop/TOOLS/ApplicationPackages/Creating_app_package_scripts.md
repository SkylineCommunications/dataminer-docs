---
uid: Creating_app_package_scripts
---

# Creating application package scripts

Application packages can contain different scripts.

This includes a script to install an application version without having to restart a DMA. This script, *Install.xml*, must always be included in an application package. You can find more information about this below.

## Install.xml

This script is used to define the installation procedure.

### AutomationEntryPoint InstallAppPackage

As a first step, a method indicated as Automation entry point needs to be created. The default Run method can never be executed during the installation of an app package.

You can define an Automation entry point using the `AutomationEntryPoint` attribute by defining it as `AutomationEntryPointType.Types.InstallAppPackage`.

The method needs to have 2 arguments.

- The `Engine` object.
- The `AppInstallContext` object.

Both arguments will obtain their value automatically during runtime and therefore do not need to be defined in the script.

Example:

```csharp
[AutomationEntryPoint(AutomationEntryPointType.Types.InstallAppPackage)]
public void Install(Engine engine, AppInstallContext context)
{
   ...
}
```

> [!NOTE]
> The namespace `Skyline.DataMiner.Net.AppPackages` needs to be included to provide access to `AppInstallContext`.

### AppInstaller

The created method should contain all actions that need to be performed in order to have a successful installation.

The [Skyline.AppInstaller](xref:Skyline.AppInstaller) namespace contains various classes related to installing an application package and can be used to define the installation.

The example below will install all (by default supported) content of the package using the [InstallDefaultContent](xref:Skyline.AppInstaller.AppInstaller.InstallDefaultContent) method.

```csharp
[AutomationEntryPoint(AutomationEntryPointType.Types.InstallAppPackage)]
public void Install(Engine engine, AppInstallContext context)
{
   AppInstaller installer = new AppInstaller(Engine.SLNetRaw, context);
   installer.InstallDefaultContent();
}
```

Note that DIS will always include the latest version of the `SLAppPackageInstaller` library. A reference to the DLL needs to be present on the EXE using *Param* with the *type* attribute set to "ref".

```xml
<Script>
   </Exe>
      <Value>
      ...
      </Value>
      <Param type="ref">SLAppPackageInstaller.dll</Param>
   </Exe>
</Script>
```

> [!NOTE]
> While for regular automation scripts you need to provide a full path to any referenced assemblies, this is not the case for references in an install script. This is because when the package is installed, the referenced assemblies will be available in the `C:\Skyline DataMiner\AppPackages\Installed\<PackageName>.<PackageVersion>\Scripts\InstallDependencies` directory, and DataMiner will automatically update the references to point to the corresponding assemblies in this directory.

#### SetupContent

In case you require specific files that you only need during the installation of the package, you can configure this by putting these files in the `SetupContent` directory of the solution. These files will only be available during the installation.

To obtain the path to this directory from the install script, you can use `installer.GetSetupContentDirectory()`. If the package contains a `SetupContent` directory, this method will return the full path to this directory, so you can use the files in this folder to perform custom operations during installation of the package. If the folder does not exist, this method will return `null`.