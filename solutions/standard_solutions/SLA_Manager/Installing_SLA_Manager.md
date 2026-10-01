---
uid: Installing_SLA_Manager
description: Deploy the SLA Manager Standard Solution from the DataMiner Catalog after checking whether the prerequisites are met.
---

# Installing SLA Manager

## Prerequisites

- DataMiner 10.5.9 or higher.

- Internet access to the DataMiner Catalog during deployment.

  The package bundles the following dependencies, which are installed automatically:

  - The *Skyline SLA Definition Basic* connector.
  - The *Standard Data Model Registration* solution.

## Deploying SLA Manager

1. Look up the *SLA Manager* package in the DataMiner Catalog.

1. Click the *Deploy* button.

   > [!TIP]
   > For more details on deploying items from the Catalog, see [Deploying a Catalog item to your system](xref:Deploying_a_catalog_item).

1. Select the target DataMiner System and confirm the deployment.

   The package is pushed to the DataMiner System. Installation automatically synchronizes all SLA elements present on the DataMiner System into the SLA Manager inventory, so the solution is ready to use immediately after deployment.

> [!NOTE]
> After you upgrade the package, refresh the web app using Ctrl+F5. Otherwise your browser might keep using a previously cached version of the app.

For more information about accessing the app, see [Accessing the SLA Manager app](xref:Accessing_SLA_Manager).
