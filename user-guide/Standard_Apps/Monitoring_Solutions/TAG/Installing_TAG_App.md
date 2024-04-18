---
uid: Installing_TAG_App
---

# Installing the DataMiner TAG Management app

## Prerequisites

- DataMiner version 10.4.5 or higher

- A DataMiner System [connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud)

- A connection to a TAG MCS system

- The DataMiner TAG Management app contains multiple functions that allow interaction with the TAG MCS or TAG MCM elements available in the system. To ensure the app works properly, it is necessary to have the following versions set to production at minimum:

  - TAG Video Systems MCM-9000 connector version 1.1.6.10

  - TAG Video Systems Media Control System (MCS) connector version 1.0.2.1

  > [!NOTE]
  > When you download the *TAG Management* package from the Catalog, these connectors are included and do not need to be installed separately.

## Deploying the DataMiner TAG Management app

1. Look up the [*TAG Management* package](https://catalog.dataminer.services/details/package/6076) in the DataMiner Catalog.

1. Click the *Deploy* button.

1. Select the target DataMiner System and confirm the deployment. The package will be pushed to the DataMiner System.

## Accessing the TAG Management app

To ensure full functionality of the *TAG Management* low-code app included in your package, TAG elements need to be included on your DMA. Without these elements, the application will not operate correctly.

If necessary, [add new elements](xref:Adding_elements) using the appropriate [TAG Video Systems protocol](xref:Connector_help_TAG_Video_Systems_MBC-7000), e.g. *TAG Video Systems MCM-9000* or *TAG Video Systems Media Control System*.

To access the TAG Management application:

1. Go to `http(s)://[DMA name]/root`.

1. Select *TAG Management* to start using the application.

   ![TAG Management](~/user-guide/images/TAG_application.png)

> [!TIP]
> See also: [Use case: TAG VS – Tech Partner Integration](https://community.dataminer.services/use-case/tag-vs-tech-partner-integration/).
