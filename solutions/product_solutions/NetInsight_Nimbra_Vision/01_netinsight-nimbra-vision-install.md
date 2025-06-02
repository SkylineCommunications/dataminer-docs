---
uid: netinsight-nimbra-vision-install
---

# Installing the DataMiner NetInsight Nimbra Vision solution

## DataMiner Prerequisites

- DataMiner license **Tier 2** or subscription
- DataMiner Minimum version **10.4.8** or higher
- Soft-launch features: GenericInterface
- [NetInsight Nimbra Vision DataMiner connector](https://catalog.dataminer.services/details/e48af0b9-b52c-4106-b0e0-22c44ead85f5)

## Deploying the DataMiner NetInsight Nimbra Vision DataMiner solution

1. Look up the [*NetInsight Nimbra Vision* package](https://catalog.dataminer.services/details/d9ec570f-a625-40c1-a6fa-c9b4f15416cd) in the Catalog.

1. Click the *Deploy* button.

1. Select the target DataMiner System and confirm the deployment. The package will be pushed to the DataMiner System.

> [!NOTE]
> When you download the *NetInsight Nimbra Vision* package from the Catalog, the necessary connector is included and do not need to be installed separately.

## Accessing the NetInsight Nimbra Vision solution

To access the NetInsight Nimbra Vision application:

1. Go to `http(s)://[DMA name]/root`.

1. Select *NetInsight Nimbra Vision* to start using the application.

![NetInsight Nimbra Vision](~/user-guide/images/netinsight-nimbra-vision-openapp.png)

> [!NOTE]
> This application enhances the functionality of existing NetInsight Nimbra Vision elements on your DMA. If these elements have not been configured yet, [add the necessary elements](xref:Adding_elements) using the [appropriate connectors](https://catalog.dataminer.services/details/e48af0b9-b52c-4106-b0e0-22c44ead85f5).

## DataMiner Element
The solution package installs the latest version of the NetInsight Nimbra Vision connector. Alternatively, users can choose to install a specific version from the catalog, with a minimum required version of 1.0.1.1.

After creating the element, note the IP address and port, additional details need to be configured, such as setting the Username and Password, located at the top of the configuration page, to authenticate requests. Since this connector uses the HTTP protocol with Subscriptions, you must allow the Nimbra Vision platform to send asynchronous messages to your DataMiner element (refer to the next section).

### Subscriptions
Nimbra Vision leverages webhooks and subscriptions to receive updates from specific endpoints with filtering capabilities. Currently, data filtering and new endpoints cannot be added manually or on-demand. For support with additional endpoints or subscriptions, please contact Skyline team members for evaluation.

To process asynchronous messages, you can use the default subscription address or define other entry points. The default address is: ```http://[DMS IP ADDRESS]/NimbraVision/subscriptions```

To define which endpoints to subscribe to, navigate to the ***Subscriptions** subpage and enable the desired endpoints.

## Nimbra Vision Licenses

- **Service Provisioning**: to provision services from Nimbra Vision
- **Northbound Provisioning**: access the REST APIs
- **Scheduling**: to schedule and book resources needed by the services, e.g., ports and trunk
capacity.
- **Autoroute**: to automatically create the path based on time, and book and available resources.

### Function Enablement
The autoroute must be enabled for the provisioner to automatically route a path. If not, then it will use whatever path the northbound application provided. If none was provided, then the network will route the channel but not create and book a path. 

To enable above mentioned functions:

- Install the licenses on page *Admin > System Administration > License Details*. In *Action* menu, select *Install...*.
- Scheduling is enabled on page *Admin > Circuit Provisioning > Scheduling Configurations*, setting *Enabled: true*
- Manually trigger creation of resources using the node context menu: *Scheduling > Refresh Resources...*. 
- Default circuits to autoroute on page *Admin > Circuit Provisioning > Northbound Configuration*, setting *MSR Automatic Routing: true*