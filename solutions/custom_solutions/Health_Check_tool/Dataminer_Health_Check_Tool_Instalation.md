---
uid: DataMiner_Health_Check_Tool_Installation
---

# Installing the DataMiner Health Check Tool

## Prerequisites

- DataMiner web apps 10.4.1 or higher.
- A DataMiner System [connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).

## Deploying the DataMiner Health Check Tool

1. Look up the [*DataMiner Health Check* package](https://catalog.dataminer.services/details/56b1b9e0-ffe1-4bd2-b5d2-06c17d97c6b1) in the Catalog.

1. Deploy the package to your DataMiner Agent by clicking the *Deploy* button.

   > [!TIP]
   > See also: [Deploying a Catalog item to your system](xref:Deploying_a_catalog_item)

   If this is the first time you install the tool, a new view named *DataMiner Health Check* and element named *Health Check Manager* will automatically be created when the package is installed. A series of tests related to the health of the DataMiner System will be included by default.

   ![Element in the Surveyor](~/solutions/images/Health_Check_Element_Path.png)

1. Optionally, rename the element and view, and change their location in the Surveyor according to you preferences.

1. Open the newly created element to begin the configuration. See [Configuring the DataMiner Health Check Tool](xref:DataMiner_Health_Check_Tool_Configuration).

You will now also be able to access the [included dashboards](xref:DataMiner_Health_Dashboards) by navigating to http(s)://[DMA name]/root in a web browser.

![Dashboard Path](~/solutions/images/Health_Check_Dasboard_Path.png)

> [!NOTE]
> To **update** the DataMiner Health Check tool, redeploy the [*DataMiner Health Check* package](https://catalog.dataminer.services/details/56b1b9e0-ffe1-4bd2-b5d2-06c17d97c6b1). The tool will be updated, but a new Health Check Manager element will not be created, as one should already exist in your DMS.
