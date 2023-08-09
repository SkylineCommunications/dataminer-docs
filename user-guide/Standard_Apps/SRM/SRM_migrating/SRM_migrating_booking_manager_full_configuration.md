---
uid: SRM_migrating_booking_manager_full_configuration
---

# Migrating a complete Booking Manager configuration

The SRM framework allows you to export all artifacts of a Booking Manager application to facilitate deployment. You can then add the configuration to a Companion Files repository so it can be included in an install package, as detailed below.

This functionality is available since version 1.2.24 of the SRM framework.

Consider deploying the *Ziine SatUplink* booking application.

## Exporting the configuration

To export the configuration related to a specific Booking Manager application and its virtual platform, use the *SRM_ExportFullConfiguration* Automation script, which is included in the SRM package.

1. In the Automation module, select the *SRM_ExportFullConfiguration* script and click *Execute*.

1. As the input data for the script, specify a JSON object that defines which Booking Manager application should be exported.

   For example:

   ```json
   { "BookingManagerName" : "Ziine SatUplink" }
   ```

1. Click *Execute now* to start the script.

When the configuration has been exported, it will be available as a zip file in the *Skyline Booking Manager* > *Full Configurations* documents folder. The file name consists of the specified Booking Manager and the export time, e.g. "Ziine SatUplink_\`export time\`".

The export will include:

- The Booking Manager element, including:

  - Its settings

  - The custom Visio drawing

  - The custom Automation scripts defined for the actions and related to the custom actions

  - The view containing the Booking Manager element

  - The views and the Visio drawings used in the custom actions

  - The alarm and trend template

- The related booking monitoring element, view, alarm template, and trend template

- Service definitions, based on the virtual platform they are linked to

  - The service Visio drawing set in the definition

  - The functions used in the service definitions, including their profile parameters, profile definitions, and profile load scripts

  - The resource pools referenced in the service definition, including inheritance, *Resource pool* property, *Contributing Configuration* property, and *Path* property

  - Resources used for inheritance and the parameters they reference

  - Profile instances linked to the profile definitions of the functions referenced in the service definitions

- Resource pools related to the virtual platform

## Including the configuration in a .dmapp package

### Including the configuration in a 'Companion Files' repository

To include the exported configuration in a package, the files in the exported zip file should be added to the *Companion Files* repository. After adding that repository and cloning it, create a folder called "SRM" in the *Content* folder of that repository. Next, export the folders inside the exported zip file to that newly created *SRM* folder. Commit these files and push the repository.

When exporting an updated version of the booking application, first remove all current folders in the *SRM* folder before exporting the folders in the newly created zip. This will later on prevent importing artifacts that are no longer in use.

### Adding the 'Companion Files' repository to the 'Package' repository

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

### Importing the configuration

Finally, that configuration must be imported during the package installation. This means that the import step needs to be added to the *Install* Automation script of the package.

First add the *Skyline.DataMiner.Core.AppPackageInstaller.SRM* NuGet to the *Install* project. In the code of the install script, reference the *Skyline.DataMiner.Srm.AppPackageInstaller* namespace. In the *Install* method, add the following lines:

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

Before you install the *.dmapp* package that the CI/CD pipeline has generated, make sure the SRM framework is installed on the target system. As soon as the installation is complete and the system is online, you can [install the *.dmapp* package](xref:Installing_an_app_package).

> [!IMPORTANT]
> We highly recommended installing the same SRM framework version as in the setup where the configuration was exported.

> [!NOTE]
> Double-check whether the DataMiner version is compliant with the SRM framework version you are about to install.
