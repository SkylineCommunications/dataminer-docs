---
uid: SatOps_Installation
description: Deploy the SatOps package from the DataMiner Catalog after checking whether the DataMiner and MediaOps Plan prerequisites are met.
---

# Installing SatOps

To install SatOps:

1. Confirm whether the following prerequisites are met:

   - Your system uses DataMiner 10.5.11/10.6.0 or higher, as well as DataMiner Web 10.6.2 or higher.

   - [MediaOps Plan](xref:MediaOps.Plan) 1.5.1 or higher is installed.

     SatOps relies on MediaOps Plan for resource management (Resource Studio) and scheduling.

   > [!NOTE]
   > The minimum required versions can increase with newer SatOps releases. Always check the [SatOps release notes](xref:SatOps_1.2.0) for the requirements of the SatOps version you intend to install.

1. Look up the [SatOps package](https://catalog.dataminer.services/details/08798aa7-6c1f-42a9-bdd2-4b3d8b4afea1) in the DataMiner Catalog.

1. If all prerequisites are met, click the *Deploy* button.

   > [!TIP]
   > For more details on deploying items from the Catalog, see [Deploying a Catalog item to your system](xref:Deploying_a_catalog_item).

After installation, the SatOps applications ([Satellite Inventory](xref:Satellite_Inventory) and [Satellite Scheduling](xref:Satellite_Scheduling)) are available in your DataMiner System and ready for use out of the box. Both apps start out empty. To evaluate or test SatOps without building an inventory from scratch, deploy the [TerraBeam demo data](https://catalog.dataminer.services/details/668a9580-1c5d-4215-a20e-b62fdaea5fe8) package, a separate DataMiner Catalog item. It sets up a scenario around TerraBeam, a fictitious European satellite operator, and populates the apps with satellites, beams, and transponders.
