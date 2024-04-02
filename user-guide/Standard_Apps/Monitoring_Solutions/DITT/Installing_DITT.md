---
uid: Installing_DITT
---

# Installing DataMiner IT Tools (DITT)

## Prerequisites

- DataMiner version 10.3.6 or higher.

- A DataMiner System [connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).

## Deploying DITT

1. Look up the [*DataMiner IT Tools* package](https://catalog.dataminer.services/details/package/5959) in the DataMiner Catalog.

1. Click the *Deploy* button.

1. Select the target DataMiner System and confirm the deployment. The package will be pushed to the DataMiner System.

   If your DataMiner System does not contain a DITT element yet, a new DITT element is automatically created when the package is installed.

> [!NOTE]
> To update the Planned Maintenance tool, redeploy the [*DataMiner IT Tools* package](https://catalog.dataminer.services/details/package/5959). The tool will be updated, but no new DITT element will be created, as one should already exist in your DMS.


> [!NOTE]
> To [configure the DITT in any Visio](xref:Working_With_DITT), the pre-installation of the package is mandatory.



