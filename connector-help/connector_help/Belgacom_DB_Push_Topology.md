---
uid: Connector_help_Belgacom_DB_Push_Topology
---

# Belgacom DB Push Topology

The **Belgacom DB Push Topology** element will upload CSV files that were created by **Belgacom CPE Manager** elements into an Oracle database.

## About

This connector can load CSV files that were created by **Belgacom CPE Manager** elements into an Oracle database. Oracle client software (SQLLDR) needs to be installed for this to work.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

## Configuration

### Connections

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

### Configuration

To configure the element:

1. Open the **Oracle** page.

1. In the parameters **DB Host**, **Port**, **Username**, **Password** and **Service Name**, fill in the credentials to be able to connect to the database.

1. Configure the necessary settings:

   - **SQLLDR Arguments** are arguments that can be used to pass to SQLLDR (example *BINDSIZE=5242880*).

   - **Oracle Folder** is the folder where sqlldr.exe is located (e.g. *C:\oracle\product\10.2.0\client_1\BIN\\*). The element will create the Oracle control files, which describe the offload CSV structures, and will place these control files in this folder.

   - **Data Folder** is the folder where the extended offload CSV files are located.

## Usage

### Oracle

This page contains the configuration parameters on the left side. For more information, refer to the "Configuration" section above.

On the right side are the parameters that are used to execute the offload:

- **Total Lines (Since Startup Element)** displays the total number of rows that have been offloaded to the database since the element was started.
- **Last Offload** displays the timestamp when the last offload occurred.
- **Offload Failed** is an indication of whether the last offload succeeded or not. You can clear this value by clicking the **Reset** button.
- The **Offload** button can be clicked to execute the actual offload.

### CPE Managers

This page contains a table that gives an overview of all the local **Belgacom CPE Manager** elements found on the DMA where the **Belgacom DB Push Topology** element is located.
