---
uid: netinsight-nimbra-vision-install
---

# Installing the DataMiner NetInsight Nimbra Vision app

## Prerequisites

- DataMiner license **Tier 2** or subscription
- DataMiner minimum version **10.4.8** or higher
- Soft-launch features: [GenericInterface](xref:Overview_of_Soft_Launch_Options#genericinterface)
- The necessary **Nimbra Vision Licenses**:

  - **Service Provisioning**: To provision services from Nimbra Vision.
  - **Northbound Provisioning**: For access to the REST APIs.
  - **Scheduling**: To schedule and book resources needed by the services, e.g. ports and trunk.
capacity.
  - **Autoroute**: To automatically create the path based on time, and to book available resources.

## Deploying the DataMiner NetInsight Nimbra Vision DataMiner solution

1. Look up the [*NetInsight Nimbra Vision* package](https://catalog.dataminer.services/details/d9ec570f-a625-40c1-a6fa-c9b4f15416cd) in the Catalog.

> [!NOTE]
> The *NetInsight Nimbra Vision* package is scheduled to be released in September 2025.

1. Click the *Deploy* button.

1. Select the target DataMiner System and confirm the deployment. The package will be pushed to the DataMiner System.

## Accessing the NetInsight Nimbra Vision solution

To access the NetInsight Nimbra Vision application:

1. Go to `http(s)://[DMA name]/root`.

1. Select *NetInsight Nimbra Vision* to start using the application.

![NetInsight Nimbra Vision](~/solutions/images/netinsight-nimbra-vision-openapp.png)

> [!NOTE]
> This application enhances the functionality of existing NetInsight Nimbra Vision elements on your DMA. If these elements have not been configured yet, [add the necessary elements](#dataminer-element-configuration) using the [appropriate connectors](https://catalog.dataminer.services/details/e48af0b9-b52c-4106-b0e0-22c44ead85f5).

## DataMiner element configuration

The solution package installs the latest version of the NetInsight Nimbra Vision connector. You can also choose to install a specific version of the connector from the Catalog. However, note that the minimum required version of the connector is 1.0.1.1.

When you have [created the elements](xref:Adding_elements) using this connector, specify the username and password on their Configuration page so requests can be authenticated. In addition, as this connector uses the HTTP protocol with subscriptions, you must **allow the Nimbra Vision platform to send asynchronous messages** to your DataMiner element.

### Subscriptions configuration

Nimbra Vision leverages webhooks and subscriptions to receive updates from specific endpoints with filtering capabilities. Currently, data filtering and new endpoints cannot be added manually or on demand. For support with additional endpoints or subscriptions, please contact Skyline Communications.

To process asynchronous messages, you can use the default subscription address or define other entry points. The default address is `http://[DMS IP ADDRESS]/NimbraVision/subscriptions`.

To define which endpoints to subscribe to, navigate to the ***Subscriptions** subpage of the element and enable the desired endpoints.

### Function Enablement

The autoroute must be enabled in the Nimbra Vision web interface for the provisioner to automatically route a path. If not, it will use whatever path the northbound application provided. If none was provided, then the network will route the channel but not create and book a path.

To enable the above-mentioned functions:

- On the page *Admin* > *System Administration* > *License Details* install the licenses, by selecting *Install*  in the *Action* menu.
- On the page *Admin* > *Circuit Provisioning* > *Scheduling Configurations* enable Scheduling, by setting *Enabled* to *true*.
- On the page *Maps* manually trigger creation of resources using the node context menu by selecting *Scheduling* > *Refresh Resources*.
- On page *Admin* > *Circuit Provisioning* > *Northbound Configuration* enable Default circuits to autoroute, by setting *MSR Automatic Routing: true*
