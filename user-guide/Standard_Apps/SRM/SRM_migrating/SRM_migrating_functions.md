---
uid: SRM_migrating_functions
---

# Migrating virtual function definitions

To export and import virtual functions definitions and the associated objects, you can use the *SRM_ExportFunctions* and *SRM_ImportFunctions* Automation scripts, respectively.

## Exporting virtual function definitions

1. In the Automation module, execute the *SRM_ExportFunctions* script.

1. Select the function definitions you want to export.

1. Click *Export*.

   The *SRM_ExportFunctions* script will create a .dmapp package for each selected virtual function definition, which includes:

   - The function definition.
   - The associated system function definition (if *Include associated System Functions* was selected).
   - The associated profile definition(s).
   - The associated profile parameters.
   - The associated Profile-Load Script.

   The .dmapp packages will be saved in the folder `C:\Skyline DataMiner\Documents\DMA_COMMON_DOCUMENTS\SRM\FunctionExport\`.

## Importing virtual function definitions

1. Deploy the .dmapp packages you want to import on the target DMS.

1. In the Automation module, execute the *SRM_ImportFunctions* script.

1. Specify the input data `{"IsSilent":false}` and click *Execute now*.
