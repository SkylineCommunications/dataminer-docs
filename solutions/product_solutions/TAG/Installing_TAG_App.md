---
uid: Installing_TAG_App
---

# Installing the DataMiner TAG Management app

## Prerequisites

- DataMiner version 10.4.5 or higher

- A DataMiner System [connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud)

- A connection to a TAG MCS system

  > [!IMPORTANT]
  > We highly recommend using TAG's Media Control System (MCS) for optimal performance. While TAG MCM is supported, certain information and KPIs may be missing.  See [Limitation: missing information](xref:How_to_TAG_App#limitation-missing-information).

- The DataMiner TAG Management app contains multiple functions that allow interaction with the TAG MCS or TAG MCM elements available in the system. To ensure the app works properly, it is necessary to have the following versions set to production at minimum:

  - TAG Video Systems MCM-9000 connector version 1.1.6.10

  - TAG Video Systems Media Control System (MCS) connector version 1.0.2.1

  > [!NOTE]
  > When you download the *TAG Management* package from the Catalog, these connectors are included and do not need to be installed separately.

## Deploying the DataMiner TAG Management app

1. Look up the [*TAG Management* package](https://catalog.dataminer.services/details/0ef8f78a-beeb-4ec0-b321-e79b26b393ce) in the Catalog.

1. Click the *Deploy* button.

1. Select the target DataMiner System and confirm the deployment. The package will be pushed to the DataMiner System.

## Accessing the TAG Management app

To access the TAG Management application:

1. Go to `http(s)://[DMA name]/root`.

1. Select *TAG Management* to start using the application.

   ![TAG Management](~/dataminer/images/TAG_application.png)

> [!NOTE]
> This application enhances the functionality of existing TAG MCM and MCS elements on your DMA. If these elements have not been configured yet, [add the necessary elements](xref:Adding_elements) using the [appropriate protocols](https://docs.dataminer.services/connector/doc/TAG_Video_Systems_MBC-7000.html).

> [!TIP]
> See also: [Use case: TAG VS – Tech Partner Integration](https://community.dataminer.services/use-case/tag-vs-tag-management-app).
