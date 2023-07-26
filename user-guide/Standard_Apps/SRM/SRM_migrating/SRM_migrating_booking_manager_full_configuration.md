---
uid: SRM_migrating_booking_manager_full_configuration
---

# Migrating a complete SRM booking configuration

The SRM solution allows to export the artifacts of a Booking application, to facilitate the deployment. The configuration can be added to a Companion Files repository, so it can be included in an install package.

The functionality is available since version 1.2.24 of the SRM framework.

Consider deploying the *Ziine SatUplink* Booking Application.

## Export Configuration

The configuration related to that Booking Application and it's Virtual Platform can be exported using the *SRM_ExportFullConfiguration* script. This will include:

- The Booking Manager element, including:
  - its settings
  - The custom Visio
  - The custom automation scripts defined for the actions and related to the custom actions
  - The view it's in
  - The views and the Visios used in the Custom Actions
  - The alarm and trend template
- The related Booking monitoring element, view, alarm and trend template.
- Service Definitions, based on the Virtual platform they're linked to.
  - The service Visio set on the definition
  - The functions used on them, including their Profile Parameters, Profile Definitions, Profile Load Scripts
  - Resource pools referenced throughout the definition: inheritance, Resource pool property, contributing config property and the path property
  - Resources used for inheritance and the parameters they reference
  - Profile Instances linked to the Profile Definitions of the Functions referenced in the definition
- Resource pools related with the Virtual Platform

The *Input Data* takes a JSON to define which Booking Application to export:

```json
{ "BookingManagerName" : "Ziine SatUplink" }
```

The configuration will be available as a zip file in the *Documents* application, in *Skyline Booking Manager*, *Full Configurations*, as *Ziine SatUplink_`export time`.zip*.

## Include configuration in Companion Files repository

To include the exported configuration in a package the files in the exported zip file should be added to a *Companion Files* repository. After adding that repository and cloning it, create a folder called *SRM* in the *Content* folder of that repository. Then export the folders inside the exported zip file to that newly created *SRM* folder. Commit these files and push the repository.

When exporting an updated version of the Booking Application, first remove all current folders in *SRM*, before export the folders in the newly created zip. This will later on prevent importing artifacts that are no longer in use.

## Add Companion Files repository to Package

When creating the Package repository that will deploy the configuration, select the Companion Files repository. In an existing Package repository add the following to the *manifest.xml* file, if you'd for instance add the *Ziine SatUplink* *Companion Files* repository for the *Ziine* customer.

```xml
<!-- ... -->
<Content>
    <CompanionFiles>
        <CompanionFile>
        <RepoPath>CompanionFiles\Customers\Ziine\Ziine SatUplink</RepoPath>
        <Version>
            <Selection>
                <Range triggerPackagePipelineOnChange="false" rangeSelection="latestRelease">1.0.0.X</Range>
            </Selection>
        </Version>
        </CompanionFile>
    </CompanionFiles>
</Content>
<!-- ... -->
```

## Import configuration

Finally we need to import that configuration during the Package installation. The import step needs to be added to the *Install* automation script of the package.

First add the *Skyline.DataMiner.Core.AppPackageInstaller.SRM* NuGet to the *Install* project. In the code of the install script, reference the *Skyline.DataMiner.Srm.AppPackageInstaller* namespace. In the Install method add the following lines:

```cs
[AutomationEntryPoint(AutomationEntryPointType.Types.InstallAppPackage)]
public void Install(Engine engine, AppInstallContext context)
{
    // ...
    
    var srmInstaller = new SrmInstaller(engine, context);
    srmInstaller.ImportSrm();

    //...
}
```

## Install the package

Before being able to install the *.dmapp* package, the CI/CD pipeline has generated, the SRM Solution needs the be installed on the system that is targeted. It's strongly recommended to install the SRM Solution version that was used to export the configuration previously. Keep in mind to check if the DataMiner version is compliant with the SRM Solution version your about to install.

When the system is online after that install or upgrade, [install the *.dmapp* package](xref:Installing_an_app_package) the CI/CD pipeline has created.
