---
uid: Connector_help_Generic_Table_Offload
---

# Generic Table Offload

This connector can be used to offload table data to CSV files.

## About

This connector will offload table data from any element to CSV files. The commands with the data that needs to be offloaded has to be set on parameter 10 of the Generic Table Offload element.

For more information about the format of the command (xsd), refer to the Notes section below.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

## Installation and configuration

### Creation

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

### Configuration of Directory

The directory path needs to be configured before an element can start offloading the data to CSV files. If the directory is a network share, then the username and password also need to be specified.

## Usage

### General

There is only one page in this connector. This page is used for the configuration and to check the amount of data still in the buffer awaiting execution.

The **Directory Path Name** should contain the directory where the CSV file(s) you want to import are located. For example, if this is the Downloads folder of your local C:\\ drive, specify *C:\Downloads*. If the directory containing the files is accessed remotely (e.g. if you specify '*\\80.62.121.234'*), you also need to specify a **Network Share User Name** (can contain a domain name, but not always needed) and a **Network Share Password**.

Offload issues can have two main causes:

- The specified directory is not accessible. In this case, every command in the buffer will fail.
- The specified directory is accessible, but there is a problem with the command in question. In this case, this offload command and the reason for failing are mentioned in the **Command Specific Issues** Table on the **Issues** pop-up page.

There is also a **Buffer Handling** pop-up page. This page contains the following settings and button:

- **Accept Commands**: Enable this parameter if you want the connector to accept commands, offload table data and send responses. By default *enabled.*
- **Retry Interval**: When an offload fails, it is retried 3 times. After that, it will only be retried again after this interval. By default set to *30 minutes*.
- **Delete From Buffer After Exceeding TTL**: With this toggle button, you can enable deletion of commands from the buffer when they exceed their time to live. This makes sure that the buffer does not keep growing endlessly. If you disable this setting, you can be sure that no data will be lost, but you run the risk of using a endlessly growing amount of memory to store the buffer. By default *enabled*.
- **Time To Live**: In order to avoid an endlessly growing buffer, there should be a limit to how long commands can be retried. With this parameter, you can set the maximum time that a command can stay in the buffer and be retried again. By default set to *1 day.* This parameter cannot be set if the **Delete From Buffer After Exceeding TTL** setting is *disabled*.
- **Delete Entire Buffer**: With this button, you can delete all commands from the buffer and thereby reset the buffer to its original state, when it had not received any command. If you click this button, an extra pop-up warning will appear.

## Notes

The offload commands need to follow the following scheme:

\<xs:schema xmlns:xs="http://www.w3.org/2001/XMLSchema" targetNamespace="<http://www.skyline.be/offloadcommands>" attributeFormDefault="unqualified" elementFormDefault="qualified" \>
\<xs:element name="OffloadCommands"\>
\<xs:complexType\>
\<xs:sequence\>
\<xs:element name="OffloadCommand" maxOccurs="unbounded" minOccurs="0"\>
\<xs:complexType\>
\<xs:sequence\>
\<xs:element name="TableData" minOccurs="1" maxOccurs="1"\>
\<xs:complexType\>
\<xs:sequence\>
\<xs:element name="Descriptions" minOccurs="1" maxOccurs="1"\>
\<xs:complexType\>
\<xs:sequence\>
\<xs:element name="Description" maxOccurs="unbounded" minOccurs="0"\>
\<xs:complexType\>
\<xs:simpleContent\>
\<xs:extension base="xs:string"\>
\<xs:attribute type="xs:integer" name="pid" use="required"/\>
\<xs:attribute type="xs:string" name="key" use="optional"/\>
\</xs:extension\>
\</xs:simpleContent\>
\</xs:complexType\>
\</xs:element\>
\</xs:sequence\>
\</xs:complexType\>
\</xs:element\>
\<xs:element name="Rows" maxOccurs="1" minOccurs="1"\>
\<xs:complexType\>
\<xs:sequence\>
\<xs:element name="Row" maxOccurs="unbounded" minOccurs="1"\>
\<xs:complexType\>
\<xs:sequence\>
\<xs:element name="Column" maxOccurs="unbounded" minOccurs="1"\>
\<xs:complexType\>
\<xs:simpleContent\>
\<xs:extension base="xs:string"\>
\<xs:attribute type="xs:integer" name="pid" use="required"/\>
\</xs:extension\>
\</xs:simpleContent\>
\</xs:complexType\>
\</xs:element\>
\</xs:sequence\>
\</xs:complexType\>
\</xs:element\>
\</xs:sequence\>
\</xs:complexType\>
\</xs:element\>
\</xs:sequence\>
\<xs:attribute type="xs:integer" name="tableId" use="required"/\>
\<xs:attribute type="xs:string" name="tableName" use="required"/\>
\</xs:complexType\>
\</xs:element\>
\</xs:sequence\>
\<xs:attribute type="xs:string" name="type" use="required"/\>
\<xs:attribute type="xs:integer" name="dmaId" use="required"/\>
\<xs:attribute type="xs:integer" name="elementId" use="required"/\>
\<xs:attribute type="xs:integer" name="paramIdToRespond" use="required"/\>
\</xs:complexType\>
\</xs:element\>
\</xs:sequence\>
\</xs:complexType\>
\</xs:element\>
\</xs:schema\>
