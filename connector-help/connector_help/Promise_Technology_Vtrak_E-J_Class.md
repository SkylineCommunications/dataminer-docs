---
uid: Connector_help_Promise_Technology_Vtrak_E-J_Class
---

# Promise Technology Vtrak E-J Class

With this drive, you can gather and view general information from the **Promise Technology VTrak E-J Class** RAID storage systems.

## About

The Promise Technology VTrak E-J Class connector is used to monitor a RAID Array. The connector gives the user an overview of the different paramaters of the array along with its status. The connector uses SNMP protocol to retrieve the data from the device. All tables are polled every 30 seconds.

## Installation and configuration

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP CONNECTION:**

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*
- **Device address**: Not used.

**SNMP Settings:**

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device. The default value is *public*.
- **Set community string**: The community string used when setting values on the device. The default value is *private.*

## Usage

### System page

This page displays the **Instance Table** and **Subsystem Table**.

- The Instance Table has twelve columns: **Instance ID**, **Type**, **Description**, **Identification**, **Time**, **Redundancy Status** and **Type**, **Controller Present**, **Inter Connection Type**, **Enclosures Present**, **Host Interface Type** and **Cache Mirroring Enabled**.
- The Subsystem Table displays the **Subsystem ID**, **Alias**, **WWN**, **Vendor Name**, **Model Name**, **Serial** and **Part Number**, **Revision** and **Manufacture Date**.

### Controller -Enclosure page

On this page, there are three tables: the **Controller Table**, the **Controller Stats Table** and the **Enclosure Table**.

- The first table, the Controller Table, has 72 columns. The table provides a total overview of all controller data.
- The second table, the Controller Stats Table, has the following columns: **Data Transferred** (Total, Read and Write), **Number of Errors** (Total, Non RW, Read and Write), **Number of Requests** (IO, Non RW, Read and Write) and **Start** and **Collection Time**.
- The Enclosure Table has an **Enclosure ID**, **Type**, **Status** and **Status description** column.

### PS - Voltage - Temp page

On this page, there are three tables:

- The **Power Supply Table** displays the **Power Supply Status**.
- The **Voltage Sensor Table** displays the measured **Voltage**.
- The **Temperature Sensor Table** displays the measured **Temperature** and the **Sensor Status**.

### Battery - Cooling Device page

There are two tables on this page: the **Battery** **Table** and the **Cooling Device Table**.

- The first table contains general information about the battery, such as the **Serial Number**, **Manufacture Date** and **Name**, **Device Name** and **Chemistry**. It also has columns for the **Temperature** and the corresponding **Thresholds**, the **Cycle** **Count**, **Remaining** **Capacity**, **Voltage**, **Current**, **Status** , **CellType** and **Hold** **Time**.
- The second table provides information about the **Cooling** **Device**, **Type**, **Status** and **Speed**.

### Physical drive page

This page contains the **Physical** **Drive** **Table**, which displays general information about the drives, like the **Interface**, **Alias**, **Model** **Number**, **Serial** **Number**, **Firmware** and **Protocol** **Version**, **Operational** **Status**, **Condition**, **Operation** and **Configuration**. Also the **Array** **ID**, **Sequence** **Number**, **Enclosure** **ID**, **Slot** **Number** and **Block** **Size** are mentioned, as well as the **Drive** **Type** and **Capacity** (Physical, Configurable and Used).

### Disk array page

This page contains the **Disk** **Array** **Table**, which displays information about the disk array, such as the **Array** **Alias**, **Operational** **Status**, **Condition**, **Operation**, **Capacity** (Physical, Configurable, Free and Max Contiguous), **Media** **Patrol** and **PDM** **Enabled**, **Number** **of** **Physical** and **Logical** **Drives**, **Number** **of** **Dedicated** **Spares**, some **IDs** (Physical and Logical Drives) and the **Array** **WWN**.

### Logical - Spare drive page

This page displays the **Logical** and **Spare** **Drive** **Table**.

- The Logical Table contains the columns **Logical** **Alias**, **Serial** **Number**, **WWN**, **Operational** **Status**, **Condition**, **Operation**, **Synchronized**, **RAIDLevel**, **Capacities**, **Sector** **Size**, **Number** **of** **Axels** and **Used** **PD** and **Preferred** **Controller** **ID**.
- The Spare Drive Table contains the columns **Spare** **Operational** **Status**, **ID**, **Capacities** (Physical and Configurable), **Revertible**, **Type**, **Associated** **Array** **IDs** and **Spare** **WWN**.

### Driver statistics page

There are two tables on this page: the **Physical** and the **Logical** **Drive** **Statistics** **Tables**. Both tables contain the same columns. These colums are: **Data** **Transferred** (Total, Read and Write), **Number** **of** **Errors** (Total, Non RW, Read and Write), **Number** **of** **Requests** (IO, Non RW, Read and Write) and **Start** and **Collection** **Time.**

### Initiator - LUN Map page

The two tables on this page are the **Initiator** **Table** and **LUNMap** **Table**.

- The Initiator Table contains the **Initiator** **Type** and **Name**.
- The LUNMap Table contains the **Target** **ID** and **LUN** **ID** columns.

### Interface page

The interface page displays the **SAS Port Table** which has the following columns: **Channel** **index**, **Type**, **Link** **Status** and **Speed**, **SAS** **Address** and **Cable** **Signal** **Strength**.

### Accessory page

On this page, you can find the **UPS Table**, containing the **Status**, **Model**, **Serial** **Number**, **Firmware** **Rev**, **Manufacture** **Date**, **Line** **Rating**, **Loading** **Ratio**, **Battery** **Capacity**, **Temperature** and **Remaining** **Run** **Time** of the UPS.

### Traps page

This page displays information about received traps, such as the **Trap Sequence Number**, **ID**, **Severity**, **Source**, **Time** **Stamp** and **Description**.

### Web Interface page

On this page, you can view the web interface of the device. However, the client machine has to be able to access the device. If not, it will not be possible to open the web interface.
