---
uid: VSAT_deployment
---

# EPM VSAT deployment

This page outlines the procedure for deploying the DataMiner EPM VSAT package on an **empty DataMiner System**. It provides step-by-step guidance for configuring VSAT collectors, the EPM setup, and peripheral integrations to ensure a fully operational VSAT management system.

## Package deployment

Start by deploying the DataMiner EPM VSAT package to the system:

1. Go to the [DataMiner EPM VSAT](https://catalog.dataminer.services/details/4879501c-9716-4a33-8846-ff1835fef7ea) package in the Catalog.

1. Click the *Deploy* button to [deploy the package](xref:Deploying_a_catalog_item) on your DMA.

This will install the connectors, Automation scripts, and Visio drawings needed to create and configure the DataMiner EPM VSAT Solution.

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

1. In DataMiner Cube, create the front-end and back-end elements using the *Skyline EPM Platform VSAT GEO* connector.

   Make sure you carefully plan your elements across the DMS. For more info, see [EPM VSAT architecture](xref:VSAT_architecture). You will configure these elements in a later step.

1. For each of the collectors, the front end, and the back-end elements, right-click the element, select *Properties*, and take note of the element ID (in the format "DMAID/ElementID") displayed in the *Properties* window.

   You will need these IDs in the next steps to configure the EPM elements.

1. Configure the **front-end element**:

   1. Go to the *Visual* > *configuration* page of the element, and select the *settings* tab.

   1. Configure the settings as follows:

      | Parameter                   | Value                                                       |
      |-----------------------------|:-----------------------------------------------------------:|
      | Element Manager Type        | `Frontend`                                                  |
      | Entities Config Backup Path | A shared folder path, for example `C:\EPM\Documents\GEO\BU` |
      | File Config Export Path     | A shared folder path, for example `C:\EPM\Documents\GEO`    |
      | File Import Path            | A shared folder path, for example `C:\EPM\Documents\GEO`    |
      | File Export Path            | A shared folder path, for example `C:\EPM\Documents\GEO`    |

   1. Select the *assignments* tab.
      
   1. Add the element IDs (in DMAID/ElementID format) to the *Frontend Assignments* table.

   1. Add the element IDs (in DMAID/ElementID format) to the *Backend Assignments* table.

   1. Add the element IDs (in DMAID/ElementID format) to the *Collector Assignments* table.

   > [!NOTE]
   > On the DMA hosting the front-end element, now is a good time to share the folder defined above for other DMAs to reference in the DMS. In most cases, you can leave the folder type as "Local" and use a remote path if permissions are defined the same across the DMAs in the system. Otherwise, you can set the directory type to *Remote* and use the file handling credentials to define a username/password.

1. Configure each of the **back-end elements** in a similar way:

   1. Go to the *Visual* > *configuration* page of the element, and select the *settings* tab.

   1. Configure the settings as follows:

      | Parameter                   | Value                       |
      |-----------------------------|:---------------------------:|
      | Element Manager Type        | `Backend`                   |
      | File Config Export Path     | Shared folder of front end. |
      | File Import Path            | Shared folder of front end. |
      | File Export Path            | Shared folder of front end. |

   1. Select the *assignments* tab.

   1. Add the element IDs (in DMAID/ElementID format) to the *Frontend Assignments* table.

   1. Add the element IDs (in DMAID/ElementID format) to the *Collector Assignments* table.

      > [!NOTE]
      > The back-end element should only be configured for **collector elements hosted by the same DMA**.

1. For the front-end element and each of the back-end elements, on the **Configuration** page, select the *settings* tab and set the provisioning status to *Enabled*.

1. Restart the collectors and EPM elements to complete the initial configuration.

> [!NOTE]
> To assist with troubleshooting, you can enable the *Debug* parameter. This will activate debugging for all elements (collectors, front end, and back end).

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
