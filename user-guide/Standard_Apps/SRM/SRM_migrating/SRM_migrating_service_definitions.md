---
uid: SRM_migrating_service_definitions
---

# Migrating service definitions

To export and import a service definition, you can use the *SRM_ServiceDefinitionExportImport* Automation script.

## Exporting a service definition

1. Open DataMiner cube using the *debug=true* argument. See [Arguments for DataMiner Cube](xref:Options_for_opening_DataMiner_Cube).

1. Go to to the Services module, select the service definition you want to export, and copy its GUID (which is only displayed if you use the debug=true argument).

1. In the Automation module, execute the *SRM_ServiceDefinitionExportImport* script.

1. Specify the following input data:

   - *Operation*: `EXPORT`

   - *Working Folder*: The folder to which the service definition should be exported.

   - *Service Definition ID*: The GUID of the service definition that should be exported.

1. Click *Execute now*.

A JSON file will be created in the *Export* subfolder of the specified working folder.

## Importing a service definition

1. Make sure a working folder is present on the DMA, and add an *Import* subfolder to that folder.

1. Place the file you want to import in that *Import* subfolder.

1. In the Automation module, execute the *SRM_ServiceDefinitionExportImport* script.

1. Specify the following input data:

   - *Operation*: `IMPORT`

   - *Working Folder*: The folder containing the *Import* subfolder.

   - *Service Definition ID*: The GUID of the service definition that should be imported.

1. Click *Execute now*.

> [!NOTE]
>
> - If the import process fails, the file you tried to import will be moved to the *Failed* subfolder of the working folder.
> - If the import process succeeds, the imported file will be moved to the *Old* subfolder of the working folder.
