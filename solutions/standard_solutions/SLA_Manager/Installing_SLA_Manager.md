---
uid: Installing_SLA_Manager
description: "Deploy the SLA Manager Standard Solution from the DataMiner Catalog after checking whether the prerequisites are met."
---

# Installing SLA Manager

## Prerequisites

- DataMiner 10.5.9 or higher.

- Internet access to the DataMiner Catalog during deployment.

## Deploying SLA Manager

1. Look up the *SLA Manager* package in the DataMiner Catalog.

1. Click the *Deploy* button.

   The package bundles the following dependencies, which will automatically be installed as part of the *SLA Manager* solution:

   - The *Skyline SLA Definition Basic* connector.
   - The *Standard Data Model Registration* solution.

   > [!TIP]
   > For more details on deploying items from the Catalog, see [Deploying a Catalog item to your system](xref:Deploying_a_catalog_item).

1. Select the target DataMiner System, and confirm the deployment.

   The package will be pushed to the DataMiner System. Installation will automatically synchronize all SLA elements present on the DataMiner System into the SLA Manager inventory, so the solution is ready to use immediately after deployment.

## Deploying another SLA Manager version

If SLA Manager is already installed, you can deploy another version of the package from the DataMiner Catalog on top of it. Depending on the version currently installed and the version selected, the deployment will install, upgrade, or downgrade SLA Manager.

1. Look up the *SLA Manager* package in the DataMiner Catalog.

1. Select the version you want to deploy.

1. Click the *Deploy* button.

1. Select the target DataMiner System, and confirm the deployment.

   The Catalog will automatically determine whether the selected version needs to be installed, upgraded, or downgraded.

1. Refresh the SLA Manager web app by pressing CTRL+F5.

   This will ensure that the browser does not continue to use the previous version of the app that is still present in its cache.
