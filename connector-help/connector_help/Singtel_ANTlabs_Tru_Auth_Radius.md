---
uid: Connector_help_Singtel_ANTlabs_Tru_Auth_Radius
---

# Singtel ANTlabs Tru Auth Radius

The ANTlabs Tru Auth Radius keeps track of the usage of the satellite network for each vessel. For each user, trend and alarm data are available, separated in DVEs.

## About

The ANTlabs Tru Auth Radius connector makes it possible to monitor the usage of the satellite network. The data is located on an SFTP server, and is parsed by DataMiner. Global statistics such as Auth and ACCT statistics are also available in the connector.

## Installation and configuration

### Creation

**HTTP CONNECTION:**

- **IP address/host**: The polling IP of the device, e.g. *27.96.104.57.*
- **IP Port**: The polling IP port of the device, e.g. *443*.
- **Bus Address**: If there are problems with the proxy server on the DMA, specify "*byPassProxy*".

**SNMP Settings**:

- **IP address/host**: The polling IP of the device.
- **Port number**: The port of the connected device.
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private.*

## Usage

### Statistics page

The **Statistics Page** displays general information regarding the device. All the parameters on this page are SNMP polled.

There are two sections of statistics: **Auth Statistics** on the left, and **Acct Statistics** on the right.

### Users page

This page contains a table with all the users. Above the table you can fill in the **API Password** with a connection status (**API Status**). Below the table you can add a user by clicking the page button **New User.** A pop-up page will appear, on which you can enter the new user into the system. Below the page button there is also a **Delete User** drop-down list box. This box contains all the users. When you select a user in this list, the user will be deleted and the list will be updated automatically.

### Sessions page

At the top, you can see the **API Password** and **Status** again (the same two parameters as on the **Users** page).

Further down, there are two tables on this page. The first table contains all the active sessions, which are linked to the users table. The second table contains the Session Logs.

### Last week Table page

This page contains the **Last Week Graph** table. This table is used in the background for the Portal. All session data is filled in for each user for the last 7 days. Below the table there is a button **Clear Last Week Table**.

### Connection Server page

This page is used to configure the connection with the SFTP server that contains the files that need to be parsed. All parameters are mandatory. For instance: **SFTP Server**, **Server User Name**, **Server Password**, **File Path**.
You can also upload a single file manually. (This functionality has been implemented to make the system complete again when there is a problem with the SFTP server.)

### DVE page

The **DVE** page displays all the DVEs created. You can enable the DVE for each user, in the users table on the **Users** Page. For each user in this table, a DVE will be created, containing only user-specific information.
