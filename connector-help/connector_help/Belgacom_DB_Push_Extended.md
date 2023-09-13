---
uid: Connector_help_Belgacom_DB_Push_Extended
---

# Belgacom DB Push Extended

The **Belgacom DB Push Extended** element will upload CSV files that were created by **Belgacom RTCP Collector** elements into an Oracle database.

## About

This connector can load CSV files that were created by **Belgacom RTCP Collector** elements into an Oracle database. Oracle client software (SQLLDR) needs to be installed for this to work.

## Configuration

### Connections

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

### Configuration

To configure the element:

1. Open the **Oracle** page.

1. In the parameters **DB Host**, **Port**, **Username**, **Password** and **Service Name**, fill in the credentials to be able to connect to the database.

1. Configure the necessary settings:

   - **Table Name** should contain the name of the database table that the data will be offloaded to.
   - **SQLLDR Arguments** are arguments that can be used to pass to SQLLDR (example *BINDSIZE=5242880*).
   - **Oracle Folder** is the folder where sqlldr.exe is located (e.g. *C:\oracle\product\10.2.0\client_1\BIN\\*). The element will create the Oracle control files, which describe the offload CSV structures, and will place these control files in this folder.
   - **Data Folder** is the folder where the extended offload CSV files are located. These files will be placed into the database table configured in **Table Name**.
   - **HDD Failures Data Folder** is the folder where the HDD Failures offload CSV files are located. These files will be placed into the OFFL_HDD database table (not configurable).

This configuration can be forwarded to the **Belgacom RTCP Collector** elements by clicking the button **Send** of the parameter **Send Config to RTCP**.

## Usage

### Oracle

The **Oracle** page contains the configuration parameters on the left side, as described in the "Configuration" section above.

On the right side are the parameters that are used to execute the offload:

- **Total Lines (Since Startup Element)** displays the total number of rows that have been offloaded to the database since the element was started.
- **Last Offload** displays the timestamp when the last offload occurred.
- **Offload Failed** is an indication of whether the last offload succeeded or not. You can clear this value by clicking the **Reset** button.
- The **Offload** button can be clicked to execute the actual offload.
- Every 5 minutes a dummy query is executed to check if the database can be reached. This status is displayed in the **DB Connectivity State** parameter.
