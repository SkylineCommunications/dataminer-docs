---
uid: Installing_Smart_Trap_Processor
---

# Installing the Smart Trap Processor tool

## Prerequisites

- DataMiner web apps 10.4.1 or higher.

- A DataMiner System [connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).

## Deploying the Smart Trap Processor tool

1. Look up the [*Smart Trap Processor* package](https://catalog.dataminer.services/details/package/5755) in the DataMiner Catalog.

1. Click the *Deploy* button.

1. Select the target DataMiner System and confirm the deployment. The package will be pushed to the DataMiner System.

   If your DataMiner System does not contain a Trap Processor element yet, a new Trap Processor element is automatically created when the package is installed.

   Once the package has been installed, you can access the *Smart Trap Processor* low-code app at `http(s)://[DMA name]/root`.

   ![Smart Trap Processor app](~/user-guide/images/TrapProcessor_Access.png)

> [!NOTE]
> To update the Smart Trap Processor tool, redeploy the [*Smart Trap Processor* package](https://catalog.dataminer.services/details/package/5755). The tool will be updated, but no new Trap Processor element will be created, as one should already exist in your DMS.

> [!NOTE]
> Upon initial installation, a new view and element will be created and named “Smart Trap Processor”. Optionally, you can rename the element and view, and change their location in the surveyor.
