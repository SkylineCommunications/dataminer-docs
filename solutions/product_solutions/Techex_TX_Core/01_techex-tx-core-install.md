---
uid: techex-tx-core-install
---

# Installing the DataMiner Techex TX Core DataMiner solution

## DataMiner Prerequisites

To deploy this integration from the Catalog, you'll need:

- DataMiner license Tier 1 or subscription
- DataMiner Minimum version 10.4.8
- DataMiner System with Indexing DB or STAAS
- Soft-launch features: GenericInterface
- [Techex MWCore connector](https://catalog.dataminer.services/details/838c9515-69fd-4405-9284-822cb8bd5686)



## Deploying the DataMiner Techex TX Core DataMiner solution

1. Look up the [*Techex TX Core* package](https://catalog.dataminer.services/details/d9ec570f-a625-40c1-a6fa-c9b4f15416cd) in the Catalog.

1. Click the *Deploy* button.

1. Select the target DataMiner System and confirm the deployment. The package will be pushed to the DataMiner System.

> [!NOTE]
> When you deploy the *Techex TX Core* package, the connector is included and do not need to be installed separately.

## Accessing the NetInsight Nimbra Vision solution

To access the NetInsight Nimbra Vision application:

1. Go to `http(s)://[DMA name]/root`.

1. Select *Techex TX Core* to start using the application.

![Techex TX Core app](./Images/techextxcore.png)

> [!NOTE]
> This application enhances the functionality of existing TX Core elements on your DMA.
> If these elements have not been configured yet, [add the necessary elements](https://docs.dataminer.services/user-guide/Basic_Functionality/Elements/Working_with_elements/Adding_elements.html) using the [appropriate protocol](#prerequisites).

## DataMiner Element
The solution package installs the latest version of the [Techex MWCore connector](https://catalog.dataminer.services/details/838c9515-69fd-4405-9284-822cb8bd5686). Alternatively, users can choose to install a specific version from the catalog. Note that the connector version required to be in range 1.0.4.x.

When the is created, on this page, you should specify the username and password for connecting to TX Core during element initialization. On the general page, connections table is available, allowing you to specify additional TX Core nodes for DataMiner to automatically connect to if the primary connection becomes unavailable. 

The MWEdges page displays a table listing either all TXEdges or those specified on the Polling Configuration page. In this table, you can monitor the state of each edge, including addresses, licenses, the number of streams, and more.

Bandwidth usage metrics (source total, output total, total usage, license left) are not retrieved through polling. Instead, DataMiner receives this data asynchronously via the statistics connections. Periodically, DataMiner performs the necessary calculations based on the values available in the sources and outputs tables. This feature is disabled by default. To enable it, navigate to the *General > Statistics Configuration* subpage and configure the Total MWEdge Bitrate Calculation Interval parameter.