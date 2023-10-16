---
uid: CreatingApplicationPackages
---

# Creating application packages

There are currently two ways to create application packages:

- Infrastructure as Code (IaC)
- Using the application package builder API.

> [!TIP]
> [DataMiner Integration Studio](xref:DIS) supports creating application packages for Automation scripts solutions.

## Infrastructure as Code (IaC)

> [!IMPORTANT]
> This section might include some information that is only applicable to Skyline employees and/or links that are only accessible to Skyline employees.

Infrastructure as Code is the practice of using a descriptive model (i.e. code) for provisioning and deploying resources. This enables using version control and linking it with CI/CD pipelines just like any other codebase. IaC also makes it possible to have a repeatable way of provisioning and deploying resources.

Skyline employees can use the SLC SE Repository Manager tool to create a repository for an application install package. For more information, refer to [Creating a repository for an install package](xref:Creating_a_repository_for_an_install_package).

The repository contains a Visual Studio solution that consists of the following components:

- A **manifest**. The manifest provides information about the install package, such as its name, version, and content.
- An **install script**. This is an Automation script that gets executed when the application package is installed on DataMiner. This install script can perform custom actions (e.g. creating an element that runs a connector that is included in the application package).

The repository is linked to a CI/CD pipeline that will create the application package as an artifact. For more information about this pipeline, refer to [Pipeline stages for install packages](xref:Pipeline_stages_for_install_packages).

> [!NOTE]
> The IaC approach currently only supports install scripts and therefore does not support uninstall or configuration scripts.

### Manifest

In addition to the metadata, the manifest specifies the content to be included in the application package. The manifest can refer to protocols, Automation scripts, dashboards, functions, etc. to be included in the application package. It can even refer to other application packages to be included (which in turn can contain other application packages). In case you want to include custom files, you can create a [CompanionFiles repository](xref:Repository_types#files) and reference it in the application package manifest.

The manifest is an XML file. More info about the manifest XML schema can be found under [Package manifest schema](xref:SchemaPackageManifest).

The following example defines an application package that consists of an Automation script and companion files:

```xml
<?xml version="1.0" encoding="utf-8"?>
<Manifest xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns="http://www.skyline.be/packageManifest">
	<Name>Incident Manager</Name>
	<Version>1.0.2-CU0</Version>
	<Content>
		<AutomationScripts>
			<AutomationScript>
				<RepoPath>Automation\Generic\Sample apps\Incident Manager</RepoPath>
				<Version>
					<Selection>
						<Range triggerPackagePipelineOnChange="false" rangeSelection="latestRelease">1.0.0.X</Range>
					</Selection>
				</Version>
			</AutomationScript>
		</AutomationScripts>
		<CompanionFiles>
			<CompanionFile>
				<RepoPath>CompanionFiles\Generic\Sample apps\Incident Manager</RepoPath>
				<Version>
					<Selection>
						<Range triggerPackagePipelineOnChange="false" rangeSelection="latestRelease">1.0.0.X</Range>
					</Selection>
				</Version>
			</CompanionFile>
		</CompanionFiles>
	</Content>
	<VersionHistory>
		<Branches>
			<Branch id="1">
				<MajorVersions>
					<MajorVersion id="0">
						<MinorVersions>
							<MinorVersion id="1">
								<CUVersions>
									<CU id="0">
										<Changes>
											<NewFeature>Initial Version</NewFeature>
										</Changes>
										<Date>2023-04-14</Date>
										<Provider>
											<Company>Skyline Communications</Company>
											<Author>JVW</Author>
										</Provider>
									</CU>
								</CUVersions>
							</MinorVersion>
							<MinorVersion id="2">
								<CUVersions>
									<CU id="0">
										<Changes>
											<NewFeature>Add Incidents API</NewFeature>
										</Changes>
										<Date>2023-06-09</Date>
										<Provider>
											<Company>Skyline Communications</Company>
											<Author>AVV</Author>
										</Provider>
									</CU>
								</CUVersions>
							</MinorVersion>
						</MinorVersions>
					</MajorVersion>
				</MajorVersions>
			</Branch>
		</Branches>
	</VersionHistory>
</Manifest>
```

### Install script

The installation script is an Automation script with an [AutomationEntryPoint type](xref:Skyline.DataMiner.Automation.AutomationEntryPointType.Types) attribute of type `AutomationEntryPointType.Types.InstallAppPackage`. For more information, refer to [Creating application package scripts](xref:Creating_app_package_scripts).

```csharp
namespace Script
{
	using System;

	using Skyline.AppInstaller;
	using Skyline.DataMiner.Automation;
	using Skyline.DataMiner.Net.AppPackages;

	/// <summary>
	///     DataMiner Script Class.
	/// </summary>
	internal class Script
	{
		/// <summary>
		///     The script entry point.
		/// </summary>
		/// <param name="engine">Provides access to the Automation engine.</param>
		/// <param name="context">Provides access to the installation context.</param>
		[AutomationEntryPoint(AutomationEntryPointType.Types.InstallAppPackage)]
		public void Install(Engine engine, AppInstallContext context)
		{
			try
			{
				engine.Timeout = new TimeSpan(0, 10, 0);
				engine.GenerateInformation("Starting installation");
				var installer = new AppInstaller(Engine.SLNetRaw, context);
				installer.InstallDefaultContent();

				// Custom installation logic can be added here for each individual install package.
				var subScript = engine.PrepareSubScript("Incidents_Dependencies_Import");
				subScript.Synchronous = true;
				subScript.StartScript();
			}
			catch (Exception e)
			{
				engine.ExitFail("Exception encountered during installation: " + e);
			}
		}
	}
}
```

## Application package builder API

The application package builder API is an API that can be used to creating application packages. The API is available as a NuGet package: [Skyline.DataMiner.Core.AppPackageCreator](https://www.nuget.org/packages/Skyline.DataMiner.Core.AppPackageCreator).

For the API documentation, refer to [Skyline.AppInstaller.AppPackage](xref:Skyline.AppInstaller.AppPackage).
