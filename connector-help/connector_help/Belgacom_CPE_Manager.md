---
uid: Connector_help_Belgacom_CPE_Manager
---

# Belgacom CPE Manager

The **Belgacom CPE Manager** is part of a CPE setup, where it works together with the **Belgacom RTCP Collector**, **Belgacom Modem Collector** and **Belgacom DB Push Topology** connectors. This particular connector is responsible for aggregating the data and providing the user interface.

## About

Different elements are needed for this setup:

- One front-end element, responsible for provisioning and aggregating data at the top levels. This data comes from the back-end elements.
- Multiple back-end elements, each responsible for some rings of a POP. These elements will perform the aggregation of the data coming from the collector elements.

All elements provide access to the CPE UI. It does not matter which element is opened, they all show the same data.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

## Installation and configuration

### Creation

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

### Configuration parameters

The CPE Manager's Data Display pages are not intended to be opened. Instead, the configuration should be performed through a Visio file. Such a file is already available and embedded in the CPE UI. You can access the parameters by clicking on **configuration**. In these sections, the different pages are described.

### Configuration of the Admin parameters

This page contains 3 sections:

- Front-end DMA credentials that can be used to access the share files.
- The location where the local files can be stored.
- Provisioning ability and feedback if there were any errors present.

### Configuration of the FE1 parameters

On this page, you can fill in the credentials for the **LT Port Config**, **Eth Lag Alifc FTP**, **Procodac** and **SDH Ring** source location settings. These sources are used by the front-end element during provisioning.

### Configuration of the FE2 parameters

On this page, you can fill in the credentials for the **Physical Device** and **Eth Ring FTP** source location settings. These sources are used by the front-end element during provisioning.

### Configuration of the FE3 parameters

On this page, you can fill in the credentials for the **AI Oracle** and **STB Oracle** source location settings. These sources are used by the front-end element during provisioning.

### Configuration of the POP parameters

This page contains the subnet setting for every POP.

To add a new subnet to the **POP Table**, fill in an *IP/Subnet* in **New Subnet IP/Num** and click the **Add Row** button. A row will be added to the **POP Table**, where you can fill in the POP in the **Subnet POP** column.

To remove a row, use the **Delete Subnet** column.

### Configuration of the RTCP parameters

The **Belgacom RTCP Collector** elements will offload their data, which can be used for aggregation, into .csv files. On this page, the credentials can be configured to access the share folders where this data is offloaded.

### Configuration of the FE Ring parameters

This page will display if the front-end element found new rings during provisioning. If a new ring was found, the page will suggest to which back-end element it can be assigned. This suggestion can be changed or removed. If the suggestion is approved, you can click the **Manual Fill Rings** button. This is not done automatically, because it could be that a back-end DMA is down during provisioning, so that the front-end element would then automatically assign these rings to other back-end DMAs, which would lead to duplicate data when the first back-end DMA is activated again.

### Configuration of the BE Ring parameters

On this page, you can configure for which POP a back-end element is responsible, by filling in **Backend Responsible for POP**. The front-end element will then assign rings that belong to this POP to this element during provisioning.

## Usage

As described above, the data pages of the CPE Manager are not intended to be used.

If you open the card in Cube, the CPE interface will be displayed, with different chains providing a different topology view.

If you fill in one of the filters (on the left side), the topology diagram view is displayed. If you click a KPI item in this diagram view, a pop-up window with parameters opens. In most cases, KPI items of the currently selected item are also displayed below the topology diagram view.

You can also right-click an alarm in Cube and select **Open** \>*CPE Manager element name*. This will open the CPE Manager with the filter already filled in at the right position, so the topology is immediately shown.

## Notes

As the data pages are not accessible, to provide an easier way to configure the settings, a custom Visio file is available and can be used.
