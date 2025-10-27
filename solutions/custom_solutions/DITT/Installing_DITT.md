---
uid: Installing_DITT
---

# Installing DataMiner IT Tools

To be able to implement DITT functionality, such as initiating ping and traceroute commands or opening PuTTY, you first have to install the DITT package:

1. Make sure the following **prerequisites** are met:

   - Your DataMiner System uses DataMiner 10.3.6 or higher.

   - The DataMiner System is [connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).

1. Look up the [*DataMiner IT Tools* package](https://catalog.dataminer.services/details/5c55a26b-acca-4257-8833-e9a9675149a9) in the Catalog.

1. Click *Deploy*.

1. Select the target DataMiner System, and confirm the deployment. The package will be pushed to the DataMiner System.

   If your DataMiner System does not contain a DITT element yet, a new DITT element will automatically be created when the package is installed.

> [!NOTE]
> To update DITT, redeploy the [*DataMiner IT Tools* package](https://catalog.dataminer.services/details/5c55a26b-acca-4257-8833-e9a9675149a9). The tool will be updated, but no new DITT element will be created (as one should already exist in your DMS).
