---
uid: Importing_elements_services_etc_from_a_dmimport_file
---

# Importing elements, services, etc. from a .dmimport file

With .dmimport packages, you can not only import elements, but also services, service templates, views, redundancy groups, properties, protocols, documents, SLAs, and Automation scripts. This way you can migrate entire structures from one DMS to another.

To import a .dmimport file:

1. In the DataMiner Cube Surveyor, right-click the view where you want to import the package and select *Actions* > *Import*.

   > [!NOTE]
   >
   > - This option is also available from a card’s header menu.
   > - If you do not have the *Config* permission for a particular view, export and import actions will not be available for this view.

1. In the *Import* window, select *Import DataMiner package*.

1. Click the *Browse* button.

1. Browse to the file you wish to import and click *Open*.

1. In the *Options* section of the *Import* window, if you do not want to include trend or alarm templates, Visio files, etc., clear the selection from the options in question.

1. In the *Structure to be imported* section, clear the selection from any items you do not want to include in the import.

   > [!NOTE]
   > If you have selected to include a redundancy group, any elements within that group will automatically be included in the import. Similarly, if you have selected an SLA, the SLA service and its service children will automatically be included.

1. Click *Import*.

1. If necessary, resolve any conflicts concerning names and/or IDs.

1. In the *Import* window, check the progress messages until the import is ready, and click *Finish*.

> [!NOTE]
>
> - To import a package with a size of more than 1.2 GB, we recommend to use the 64-bit version of DataMiner Cube. See [Installing & configuring the DataMiner Cube software](xref:Installing_configuring_the_DataMiner_Cube_software#installing--configuring-the-dataminer-cube-software).
> - If you import an element that uses a protocol version marked as Production, different options for the import will be available depending on whether the protocol version is more recent than the Production version used in the DMS:
>   - If the imported version is more recent than the version marked as Production in the DMS, you will be able to select whether the imported protocol becomes marked as Production in the DMS or not.
>   - If the imported version is less recent than the Production version in the DMS, you will be able to choose whether the element switches to the protocol version marked as Production in the DMS or not.
> - If you import a package that includes a custom information template that already exists in the DMS, you will be able to choose one of the following options:
>   - Keep the existing information template in the DMS, and not import the information template from the package.
>   - Overwrite the existing information template in the DMS.
>   - Import the information template from the package with a new name.
> - If you are running a DataMiner System prior to version 10.4.9/10.5.0 and import a package that includes SNMPv3 elements exported from systems running DataMiner 10.4.9/10.5.0 or higher, all [SNMPv3 credentials](xref:SNMPv3_Connection) will be lost and will have to be re-entered manually. If you used the [DataMiner Cube Credentials Library](xref:Managing_predefined_sets_of_credentials_for_SNMP_authentication) to configure the SNMPv3 credentials, you will always need to re-enter the credentials manually after an import, regardless of your DataMiner version.
