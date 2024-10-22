---
uid: VSAT_deployment
---

# EPM VSAT deployment

This page outlines the procedure for deploying the DataMiner EPM VSAT package on an **empty DataMiner System**. It provides step-by-step guidance for configuring VSAT collectors, the EPM setup, and peripheral integrations to ensure a fully operational VSAT management system.

## Package deployment

Start by deploying the DataMiner EPM VSAT package to the system:

1. Go to the [DataMiner VSAT](https://catalog.dataminer.services/details/b37e7be5-178e-4b34-be9c-2115991d90ea) package in the DataMiner Catalog.

1. Click the *Deploy* button to [deploy the package](xref:Deploying_a_catalog_item) on your DMA.

This will install the connectors, Automation scripts, and Visio drawings needed to create and configure the DataMiner EPM VSAT solution.

While the package is being deployed, you can follow the progress of the deployment in the Admin app, on the *Deployments* page for your DMS. Make sure to use the *Refresh* button in the top-left corner.

## Collectors configuration

### iDirect Evolution collector

1. In DataMiner Cube, create an element using the *iDirect Evolution Platform VSAT* connector.

   See [Adding elements](xref:Adding_elements).

1. On the **Database Configuration** page of the new element, fill in the *Database Configuration* table.

1. On the **DB Polling Config** page, adjust the polling parameters according to your preferences.

1. On the **Collector Setup** page, configure the following settings:

   - **File Import**: Enable *File Import* and *File Export* if CMDB (customer data) is available.
   - **ID Import/Export**: Enable this feature and specify the paths to the CA and CR folder.
   - **System Credentials**: Enter the system credentials.
   - **Entity Removal File Path**: Specify the path for the entity removal file.

1. Right-click the element and add the *NETWORK* custom property.

   See [Adding a custom property](xref:Managing_element_properties#adding-a-custom-property-to-an-item).

### Newtec Dialog collectors

1. In DataMiner Cube, create the collector elements using the *Newtec Dialog Platform VSAT* connector.

   When configuring the element connections, use the same HTTPS URL for all three required HTTP connections.

1. On the **User Authentication** page of the new elements, enter the usernames and passwords.

1. On the **Polling Config** page, set *TSDB Polling Status* to enabled, adjust the TSDB parameters as needed, and click *Auto Configure*.

1. On the **Polling Status** page, adjust the polling parameters according to your preferences.

1. On the **Collector Setup** page, configure the following settings:

   - **File Import**: Enable *File Import* and *File Export* if CMDB (customer data) is available.
   - **ID Import/Export**: Enable this feature and specify the paths to the CA and CR folder.
   - **System Credentials**: Enter the system credentials.
   - **Entity Removal File Path**: Specify the path for the entity removal file.

1. Right-click the element and add the *NETWORK* custom property.

## EPM configuration

Follow the steps below to set up the **front-end and back-end elements**:

1. In DataMiner Cube, create the front-end and back-end elements using the *Skyline EPM Platform VSAT GEO* connector. Its recommended to plan your elements across the DMS. See [LINK TO Architecture Page Example] and we will configure them in a later step.

1. For each of the collectors, the front end, and the back-end elements, right-click the element, select *Properties*, and take note of the element ID (in the format "DMAID/ElementID") displayed in the *Properties* window. You will need these IDs later to aid in configuring the EPM Elements.

1. Configure the **front-end element**, using the Visual page of the protocol/element.

    1. Navigate to the **configuration** page.
    1. Navigate to the **settings** tab and set the Role parameter to *Frontend*.
    1. Navigate to the **collectors** tab and populate the table with DMAID/ELEMENTID captured in the previous step.
    1. Navigate to the **backends** tab and populate the table with DMAID/ELEMENTID captured in the previous step.

> [!TIP]
> The Frontend connector should get configured with **all collectors and backends** accordingly.

1. Configure the **back-end elements** in a similar way:

    1. Navigate to the **configuration** page.
    1. Navigate to the **settings** tab and set the Role parameter to *Backend*.
    1. Navigate to the **collectors** tab and populate the table with DMAID/ELEMENTID captured in the previous step.
    1. Navigate to the **backends** tab and populate the table with DMAID/ELEMENTID captured in the previous step.

> [!TIP]
> The Frontend connector should get configured **only with collectors and backends served by the DMA hosting the element** accordingly.

1. After all EPM elements are configured, set the provisioning status to "Enabled".

> [!TIP]
> To assist with troubleshooting, you can enable the Debug parameter. This will activate debugging for all elements (collectors, front end, and back end).

> [!TIP]
> The collectors and the EPM elements may need to be restarted after the initial configuration to start working properly.

## Peripherals configuration

The DataMiner EPM VSAT package includes optional connectors that can be installed upon customer request. These peripherals enhance the system's functionality by integrating additional external data sources and tools.

### Skyline Universal Weather

This connector provides weather data integration into the DataMiner System.

To create the weather element and retrieve weather data, you will need **an API key** for the OpenWeather REST API.

### Generic Sun Outage

If sun outage predictions are required for the system, create an element using the *Generic Sun Outage* connector.

This connector will calculate and forecast sun interference for satellite communication.

### DataMiner Planned Maintenance Tool

While not included in the DataMiner EPM VSAT package, the DataMiner Planned Maintenance Tool is often installed alongside the EPM system to enhance operational maintenance capabilities.

For more details, refer to [The DataMiner Planned Maintenance (PLM) tool](xref:DataMiner_PLM_Tool_Overview).
