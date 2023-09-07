---
uid: DOM_Designer_Excel_deployment
---

# Deploying the Excel file

1. Log in to DataMiner Cube with an account that has administrator rights.

1. In the Automation app in DataMiner Cube, run the *DOM Designer* script. You can find this script in the folder `DOM\DOM Main scripts`.

1. Click *Browse*.

   ![DOM Designer wizard](~/user-guide/images/DOM_Designer_Browse.png)

1. Browse to the location of the Excel file and click *Open*.

   The file you have selected will now be displayed in the script window.

   ![DOM Designer wizard](~/user-guide/images/DOM_Designer_Import.png)

1. Click *Import*.

   When the import is complete, the script window will display *Complete: SUCCEEDED*.

   While deploying a new object model, the script will log its actions in the information events. If something is wrong with your Excel file, an error message will be displayed there.

> [!TIP]
> When you have successfully imported the file, you can check what your data model looks like in a DataMiner low-code app. For more information on how to create such an app, refer to [this demo on DataMiner Dojo](https://community.dataminer.services/video/object-modeling-and-apps/). Prior to DataMiner 10.3.6/10.4.0, this requires the [DOMManager](xref:Overview_of_Soft_Launch_Options#dommanager) soft-launch option.
