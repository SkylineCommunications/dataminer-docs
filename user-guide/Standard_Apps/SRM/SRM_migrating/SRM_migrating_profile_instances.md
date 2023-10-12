---
uid: SRM_migrating_profile_instances
---

# Migrating profile instances

To export and import profile instances, you can use the *PFM_ProfileInstancesImportExport* Automation script.

> [!IMPORTANT]
> The *PFM_ProfileInstancesImportExport* script needs to be able to generate an .xlsx file. For this reason, before you use the script, you need to make sure *AccessDatabaseEngine.exe* is installed in the DMS. You can download this from [microsoft.com](https://www.microsoft.com/en-in/download/details.aspx?id=54920).

## Exporting profile instances

1. In the Automation module, execute the *PFM_ProfileInstancesImportExport* script.

1. As the input data, specify a JSON string that includes an action and working folder.

   - *Action*: The action to be executed, in this case, *Export*.

   - *WorkingFolder*: Defines the destination folder for the exported files. Special characters must be escaped according to the JSON syntax. If you do not specify this folder, the working directory will be a subfolder of the Documents module: `C:\Skyline DataMiner\Documents\DMA_COMMON_DOCUMENTS\Automation Scripts\Profile Manager\Instances`.

   For example: `{"Action":"Export", "WorkingFolder":"C:\\profileinstances\\"}`

1. Select the profile definitions for which you want to export the profile instances.

1. Click *Export*.

   The script will create an Excel file with one tab per profile definition and save it in the *Export* subfolder of the specified working folder.

   > [!NOTE]
   > You can manually add new rows to the Excel file in order to create new profile instances. If you do so, leave the *guid* field empty.

## Importing profile instances

1. In the Automation module, execute the *PFM_ProfileInstancesImportExport* script.

1. As the input data, specify a JSON string that includes an action and working folder.

   - *Action*: The action to be executed, in this case, *Import*.

   - *WorkingFolder*: Defines the source folder for the files to import. Special characters must be escaped according to the JSON syntax. If you do not specify this folder, the working directory will be a subfolder of the Documents module: `C:\Skyline DataMiner\Documents\DMA_COMMON_DOCUMENTS\Automation Scripts\Profile Manager\Instances`.

1. Select the import file you want and click *Load Excel*.

   The script will display high-level information about the content of the selected file.

1. Click *Import*.

   The script will import the selected file, as well as create a backup of the current *Profiles.xml* file and save it in the *Backup* subfolder of the specified working folder.
