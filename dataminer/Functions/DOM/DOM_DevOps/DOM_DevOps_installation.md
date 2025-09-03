---
uid: DOM_DevOps_installation
---

# DOM DevOps tools installation

1. Make sure your DataMiner System uses an [indexing database](xref:Indexing_Database) and is [connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).

1. If you want to be able to check what your data model looks like in a DataMiner low-code app, make sure that system has the necessary [licenses to use DataMiner Low-Code Apps](xref:Pricing_Perpetual_Use_Licensing#optional-functions). If you are using a DataMiner version prior to DataMiner 10.3.6/10.4.0, also make sure that the *DOMManager* [soft-launch option](xref:SoftLaunchOptions) is enabled.

1. Deploy the DOM DevOps tools package via the [Catalog](https://catalog.dataminer.services/details/11674850-aeac-48c4-9f35-03c387ebcf18).

   The package includes:

   - The [DOM Designer](xref:DOM_Designer).

   - The [DOM Editor](xref:DOM_Editor).

   <!-- - Excel import examples to ingest instances from a definition from a CSV file. -->

   > [!NOTE]
   > To deploy the tool, pick the version that matches your DataMiner System. The versioning of the tools package indicates which **minimum version** of DataMiner is required.
   >
   > For example, package version 10.3.3.x requires at least DataMiner 10.3.3, and package 10.4.1.x requires at least DataMiner 10.4.1.

   > [!IMPORTANT]
   > Make sure your DOM Editor version matches the DataMiner Agent version as closely as possible. If you use an outdated DOM Editor version on a more recent DMA, the configuration of DOM features that have been added in the meantime could get corrupted.
