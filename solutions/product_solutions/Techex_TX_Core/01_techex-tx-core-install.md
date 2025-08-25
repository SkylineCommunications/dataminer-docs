---
uid: techex-tx-core-install
---

# Installing the Techex TX Core app

## Prerequisites

- DataMiner license [Tier 1](xref:Pricing_Perpetual_Use_Licensing) or [subscription](xref:Pricing_Usage_based_service).
- DataMiner 10.4.8/10.5.0 or higher.
- DataMiner System using [STaaS](xref:STaaS) or [dedicated clustered storage](xref:Dedicated_clustered_storage).
- The [GenericInterface](xref:Overview_of_Soft_Launch_Options#genericinterface) soft-launch option must be enabled.

## Deploying the DataMiner Techex TX Core app

1. Look up the [*Techex TX Core* package](https://catalog.dataminer.services/details/3db5e1b5-9d22-44f6-bf6c-7c6c205f8c13) in the Catalog.

1. Click the *Deploy* button.

1. Select the target DataMiner System and confirm the deployment. The package will be pushed to the DataMiner System.

> [!NOTE]
> When you deploy the *Techex TX Core* package, the connector is included, so there is no need to install it separately.

## Accessing the Techex TX Core app

To access the Techex TX Core app:

1. Go to `http(s)://[DMA name]/root`.

1. In the *Tech Partner* section, select *Techex TX Core* to start using the application.

![Techex TX Core app](~/solutions/images/techex-txcore-app.png)

> [!NOTE]
> This application enhances the functionality of existing TX Core elements on your DMA. If these elements have not been configured yet, [add and configure the necessary elements](#dataminer-element-configuration) using the Techex MWCore connector.

## DataMiner element configuration

The solution package installs the latest version of the [Techex MWCore connector](https://catalog.dataminer.services/details/838c9515-69fd-4405-9284-822cb8bd5686). You can also choose to install a specific version of the connector from the Catalog. However, note that the connector version must be in **1.0.4.x range**.

When you have [created the elements](xref:Adding_elements) using this connector, on the *General* page of the elements, configure the username and password to connect to TX Core. The *Connections* table on the *General* page allows you to specify additional TX Core nodes for DataMiner to automatically connect to if the primary connection becomes unavailable.

The *MWEdges* page displays a table listing either all TX Edges or those specified on the *Polling Configuration* page. In this table, you can monitor the state of each TX Edge, including addresses, licenses, the number of streams, and more.

Bandwidth usage metrics (source total, output total, total usage, license left) are not retrieved through polling. Instead, DataMiner receives this data asynchronously via the statistics connections. Periodically, DataMiner performs the necessary calculations based on the values available in the sources and outputs tables. This feature is disabled by default. To enable it, navigate to the *General* > *Statistics Configuration* subpage and configure the *Total MWEdge Bitrate Calculation Interval* parameter.
