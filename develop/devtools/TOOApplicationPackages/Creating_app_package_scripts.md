---
uid: Creating_app_package_scripts
---

# Creating application package scripts

Application packages can contain different scripts, each used for a different purpose:

- A script to install an application version without having to restart a DMA. This script, *Install.xml*, must always be included in an application package.
- A script to configure the application, e.g. to configure parameter values. This script, *Config.xml*, is optional.
- A script to uninstall an application version. This script, *Uninstall.xml*, is optional.

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

### SLAppInstaller

The created method should contain all actions that need to be performed in order to have a successful installation.

The `SLAppInstaller` namespace contains various classes related to installing a DMAPP and can be used to define the installation.

The example below will install all (by default supported) content of the package.

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
> An example is available in the [Protocol Development Guide Companion Files](https://community.dataminer.services/documentation/protocol-development-guide-companion-files/).

## Config.xml

This (optional) script is used to perform configuration steps requiring user interaction once the installation is complete.

A configuration script always expects a set of input parameters defining the user input; it cannot be executed without them.

### AutomationEntryPoint ConfigureApp

As a first step, a method indicated as ConfigureApp Automation entry point needs to be created. The default Run method can never be executed during the installation of an app package.

You can define an Automation entry point using the `AutomationEntryPoint` attribute by defining it as `AutomationEntryPointType.Types.ConfigureApp`.

The method needs to have 2 arguments.

- The `Engine` object.
- The `AppConfigurationContext` object.

Both arguments will obtain their value automatically during runtime and therefore do not need to be defined in the script. The content of the method should consist of all the actions needed to install the application, e.g. to create elements.

Example:

```csharp
[AutomationEntryPoint(AutomationEntryPointType.Types.ConfigureApp)]
public void Configure(Engine engine, AppConfigurationContext context)
{
   ...
}
```

> [!NOTE]
> - The namespace `Skyline.DataMiner.Net.AppPackages` needs to be included to provide access to `AppConfigurationContext`.
> - At present, a configuration can only be executed using the SLNETCLientTest tool.

### Input parameters

Input parameters can be used during configuration. A pop-up message will ask the user to fill in the necessary parameters from the script.

The parameter values can be accessed through the `AppConfigurationContext`, as a dictionary where the keys are the input parameter keys and the values are the values provided by the user.

Example:

```csharp
[AutomationEntryPoint(AutomationEntryPointType.Types.ConfigureApp)]
public void Configure(Engine engine, AppConfigurationContext context)
{
   var entriesToDictionary = context.Values.ToDictionary(entry => entry.ID, entry => entry.Value);
   var username = entriesToDictionary["username"];
   var password = entriesToDictionary["password"];
   
   engine.Log("username:" + username);
   engine.Log("password:" + password);
}
```

> [!NOTE]
> An example is available in the [Protocol Development Guide Companion Files](https://community.dataminer.services/documentation/protocol-development-guide-companion-files/).

## Uninstall.xml

As a first step, a method indicated as *Uninstall Automation entry point* needs to be created. The default Run method can never be executed during the uninstallation of an app package.

You can define an Automation entry point using the `AutomationEntryPoint` attribute by defining it as `AutomationEntryPointType.Types.UnInstallApp`.

The method needs to have 2 arguments.

- The `Engine` object.
- The `AppUninstallContext` object.

Both arguments will obtain their value automatically during runtime and therefore do not need to be defined in the script. The content of the method should consist of all actions needed to uninstall the application, e.g. to delete elements.

Example:

```csharp
[AutomationEntryPoint(AutomationEntryPointType.Types.UnInstallApp)]
public void Uninstall(Engine engine, AppUninstallContext context)
{
   ...
}
```

> [!NOTE]
>
> - The namespace `Skyline.DataMiner.Net.AppPackages` needs to be included to provide access to `AppUninstallContext`.
> - An example is available in the [Protocol Development Guide Companion Files](https://community.dataminer.services/documentation/protocol-development-guide-companion-files/).
