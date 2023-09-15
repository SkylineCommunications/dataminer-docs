---
uid: Connector_help_UPC_Nederland_B2B_CPE_Provisioning
---

# UPC Nederland B2B CPE Provisioning

This connector will be used to automatically create and configure elements of the **CISCO ISR** protocol.

## About

This connector will execute soap calls to retrieve data. Every 5 minutes there will be a version check. If there is a newer version then the other soap calls will be executed. The **Get Devices** soap command will create the missing **CISCO ISR** elements in the correct views in the Surveyor or reconfigure existing elements, e.g. if the alarm template has changed. The **Get Interfaces** and **Get QoS** soap commands will contain the interfaces for which the polling does or does not need to be enabled in the **CISCO ISR Measurement Configuration Table**.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | N/A                         |

## Installation and configuration

### Creation

#### Main Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.
- **Bus address**: If the proxy server has to be bypassed, specify *bypassproxy*.

### Configuration

Before the element is able to execute the soap calls, the username and password need to be configured.
To do so, go to the **General** page and click the **Configuration** page button. Then fill in the **Username** and **Password** parameters with the correct values.

It is strongly advised to fill in the **Customer Sites Grouping** parameter before the polling and creation of elements starts, as this way the elements will be created under the correct view. This parameter contains a comma-separated list of service types. If the service type is not found in this list, then the element will be added under the view *Service Grouping -\> Service Type*, otherwise the element will be added under the view *Service Grouping -\> Service Type -\> Service PTSID.*

The **Trend Template** parameter value can be filled in from a drop-down list. This will assign the trend template to new elements when they are created. To refresh the drop-down list, in case new trend templates were created, click the **Get Templates** button.

## Usage

### General

The following single parameters can be found on the **General** page:

- **Flow Last Execution Time**: This will display the last time that the flow was started
- **Flow Last Execution Status**: This will display the current execution state of the flow or, if the flow is not being executed now, if it was last executed without problems (*OK*) or not (**Error**).
- **Version Number**: The version number that was last retrieved from the soap call. This will be used to verify if there is a newer version available or not

There is one table displayed on the **General** page, the **Device Table**. This table will contain various columns with items polled from the soap call. With the **Delete** column parameter, you can manually remove a row from the table. Normally rows and elements are removed automatically when the soap response contains the *DEL* operation type. Note that clicking Delete will only remove the row, but no elements will be deleted. If the row is present when polling next occurs, the row will be added again.

The **Configuration** page button can be used to access the **Configuration** page. For more info see the **Installation and configuration** section above. There is one extra button on that page that is not yet mentioned in that section, **Force Poll**. This button can be used in case manual changes were done to the elements. If the version number is still the same, then the soap will not be processed any further and elements will not be (re)created/configured. Click this button to by bypass this as if there were a new version.

## Notes

This element creates **CISCO ISR** elements. Please make sure that the **CISCO ISR** connector is present on the DMA and is set as production.

The alarm templates that are in the soap response need to be created on the DMA, as otherwise the created element will not be monitored.

Element properties have been configured. These will once need to be added manually to the DMA. To do so, right-click a random element in **DataMiner Cube** and select **Properties**. Then go to the **custom** tab page. The following properties need to be mentioned on this tab page: **Region**, **Service Type** and **UID**. For each of these properties that is not on the tab page, click the cogwheel button at the bottom of the window and select **Add**. Then fill in the correct property name and click **OK**.
