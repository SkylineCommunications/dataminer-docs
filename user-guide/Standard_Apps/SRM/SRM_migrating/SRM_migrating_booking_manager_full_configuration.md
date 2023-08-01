---
uid: SRM_migrating_booking_manager_full_configuration
---

# Migrating a complete SRM booking configuration

The SRM solution allows you to export the artifacts of a booking application to facilitate the deployment. The configuration can be added to a Companion Files repository so it can be included in an install package.

The functionality is available since version 1.2.24 of the SRM framework.

Consider deploying the *Ziine SatUplink* booking application.

## Export configuration

The configuration related to that booking application and its virtual platform can be exported using the *SRM_ExportFullConfiguration* script. This will include:

- The Booking Manager element, including:

  - Its settings

  - The custom Visio

  - The custom Automation scripts defined for the actions and related to the custom actions

  - The view it is in

  - The views and the Visios used in the Custom Actions

  - The alarm and trend template

- The related booking monitoring element, view, alarm and trend template

- Service definitions, based on the virtual platform they are linked to

  - The service Visio set on the definition

  - The functions used on them, including their profile parameters, profile definitions, and profile load scripts

  - Resource pools referenced throughout the definition: inheritance, *Resource pool* property, *Contributing Configuration* property, and the *Path* property

  - Resources used for inheritance and the parameters they reference

  - Profile instances linked to the profile definitions of the functions referenced in the definition

- Resource pools related to the virtual platform

The *Input Data* requires a JSON object to define which booking application to export. For example:

```json
{ "BookingManagerName" : "Ziine SatUplink" }
```

The configuration will be available as a zip file called "Ziine SatUplink_\`export time\`" in the *Skyline Booking Manager* > *Full Configurations* documents folder.

## Including the configuration in the 'Companion Files' repository

To include the exported configuration in a package, the files in the exported zip file should be added to the *Companion Files* repository. After adding that repository and cloning it, create a folder called "SRM" in the *Content* folder of that repository. Next, export the folders inside the exported zip file to that newly created *SRM* folder. Commit these files and push the repository.

When exporting an updated version of the booking application, first remove all current folders in the *SRM* folder before exporting the folders in the newly created zip. This will later on prevent importing artifacts that are no longer in use.

## Adding the 'Companion Files' repository to the 'Package' repository

To create the *Package* repository that will deploy the configuration, select the *Companion Files* repository. In an existing *Package* repository, add the following to the *manifest.xml* file:

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

In this example, you are adding the *Ziine SatUplink* *Companion Files* repository for the *Ziine* customer.

## Importing the configuration

Finally, we need to import that configuration during the package installation. The import step needs to be added to the *Install* Automation script of the package.

First add the *Skyline.DataMiner.Core.AppPackageInstaller.SRM* NuGet to the *Install* project. In the code of the install script, reference the *Skyline.DataMiner.Srm.AppPackageInstaller* namespace. In the *Install* method add the following lines:

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

## Installing the package

Before installing the *.dmapp* package the CI/CD pipeline has generated, the SRM solution must be installed on the targeted system. We highly recommended installing the SRM Solution version that was used to export the configuration previously.

> [!NOTE]
> Double-check whether the DataMiner version is compliant with the SRM Solution version you are about to install.

When the system is online after that installation or upgrade, [install the *.dmapp* package](xref:Installing_an_app_package) the CI/CD pipeline has created.
