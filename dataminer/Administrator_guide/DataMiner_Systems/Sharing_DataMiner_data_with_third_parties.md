---
uid: Sharing_DataMiner_data_with_third_parties
---

# Sharing DataMiner data with third parties

There are many ways in which you can make your DataMiner System share information (real-time device readings, fault data, performance data, etc.) with third parties.

## Sharing app

The Sharing app allows you to share live data via dataminer.services. For more information, see [About the Sharing app](xref:About_the_Sharing_app).

## DataMiner Cube

- Allow the third party to remotely access your DataMiner System through the ports required for DataMiner Cube.

- Set up and maintain a dedicated user profile for the third party (which devices can be accessed, what kind of actions can be performed, etc.).

> [!TIP]
> See also:
>
> - [Configuring client communication settings](xref:DMA_configuration_related_to_client_applications#configuring-client-communication-settings)
> - [Security](xref:About_DMS_Security)

## DataMiner Monitoring app

- Allow the third party to remotely access your DataMiner System through the ports required for DataMiner web applications.

- Use the Monitoring app for mobile access to DataMiner.

- Set up and maintain a dedicated user profile for the third party (which devices can be accessed, what kind of actions can be performed, etc.).

> [!TIP]
> See also:
>
> - [Working with the Monitoring app](xref:Working_with_the_Monitoring_app)
> - [Security](xref:About_DMS_Security)

## DataMiner Dashboard Gateway

- Set up DataMiner Dashboard Gateway on your internet server.

- Define and configure the necessary dashboards, which should contain all relevant information that you want to share with the third party.

> [!TIP]
> See also: [Dashboard Gateway installation](xref:Dashboard_Gateway_installation)

## DataMiner Northbound Interfaces

- Use the DataMiner NBIs to query DataMiner for the information that you want to share with the third party.

- Create the client application (e.g., web page, mobile phone app, etc.) with which you want to share the information with the third party.

- Not all DataMiner NBIs are available by default. Optional licenses may be required.

> [!TIP]
> See also:
>
> - [DataMiner interfaces](xref:DataMiner_interfaces)
> - [Web Services](xref:Using_the_Web_Services_v1)

## DataMiner Replication

- Allow the third party to remotely access your DataMiner System through the ports required for DataMiner Cube.

- Set up and maintain a dedicated user profile for the third party.

- The third party needs to have a separate DataMiner System onto which the elements can be replicated.

> [!TIP]
> See also: [Replicated elements](xref:Replicated_elements)
