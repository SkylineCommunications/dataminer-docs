---
uid: Connector_help_Cisco_Netflow
---

# Cisco Netflow

The **Cisco Netflow** connector can be used to capture and aggregate netflow data.

## About

Cisco Netflow services provide network administrator with access to IP flow information from their network. Network elements such as routers and switches gather flow data and export it to Netflow collector. The flow data include details such as IP addresses, packet, and byte counts, timestamps, Type of Services (ToS), applications ports, input and output interfaces.

The connector uses a smart-serial connection to receive netflow datapackets from the devices.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Netflow v5, v9 and IPFIX    |

## Installation and configuration

### Creation

#### Smart-Serial Main connection

This connector uses a smart-serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **Type of port**: Default *UDP/IP*.
  - **IP address/host**: specify "*any*" to receive data from all devices
  - **IP port**: The IP port of the device. Default: *2055*.

## Usage

The connector contains 4 pages. Note that since Qactions are importing the System.WebExtensions.dll it is required the 4.0 .Net framework.

### General

This page displays parameters related with Netflow collector such as **Netflow packet, Header, Count, sysUpTime, Unix Time, Source ID and Flowset.**

### Fields

A table containing all well-defined Netfow fields are displayed on this page. The **Field ID**, **Field Name**, **Custom Field Name** (data packet), **Length Type** and **Length fields** are columns present on the Field Table.

- Field ID: contains the numerical ID associated with this Netflow field.

- Filed Name: contains the readable field name for this filed.

- Custom Field Name: String parameter containing a read/write string parameter. By default the "Custom Field Name" should contain the same value as the "Field Name".

- Length Type and Length: contains a total of 2 discreet values. "Fixed" and "Variable". This column is directly related to the "Length" column.

- When length type is "Fixed" the "Length" column will contain the size of the field.

  - When the length type is "Variable" the "Length" column will contain the default size of the field.

### Templates

A table containing all the templates received from the Netflow collector are displayed on this page. **The Template ID, Flowset ID, Field Count, Field Array, Last Refresh and State** are columns present on the Template Table.

- Template ID: The ID associated with this Template.
- Flowset ID: The value of this column is always 0. This is the value reserved for Template Flowsets.
- Field Count: Contains the number of fields in the template record.
- Field Array: Contains the array with all Field IDs included in the template.
- Last refresh: The time stamp of the last time the template definition was refreshed. As per the protocol definition a timeout time needs to be defined (make this a configurable parameter with a default value).

The user can define the number of rows in the table. It is also present a timeout time in order to remove the rows that overcomes that time. Furthermore the user is able to clear the table.

### Data Record

The Data Record table displays all data records through the defined templates. The following columns are present in the table:

- **Record ID**: Auto-increment Index key
- **Flowset ID**: Contains the Flowset ID of the received flowset. This ID is the same ID of the corresponding Template to be used when "decoding" the received values.
- **Record Number**: The numerical identifier of each record within the same Data Flowset.
- **Field ID**: The ID of the field contained in the data record
- **Field Value**: The received value of the field + record combination.

The user can define the number of rows in the table. Furthermore the user is able to clear the table.

## Notes
