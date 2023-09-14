---
uid: Connector_help_Axel_Technology_Wolf2MS
---

# Axel Technology Wolf2MS

The Wolf2MS connector is an FM Controller. The device monitors FM transmissions. This connector can be used to process this data and configure the device.

## About

The connector communicates with the device via **SNMP**. It also uses traps in order to save bandwidth.

### Timing

All data gets retrieved from the device in 3 different ways.

- **Timers**:

  - Slow timer that triggers every hour and polls a few general parameters.

  - Fast timer that triggers every minute and polls Tuner 1 status parameters.

  - Some tables can be made to update faster. (Refer to the information on the different tables below for more details).

- **Traps**:

  - Status parameters can be received through traps from the device. As soon as a trap is received, the parameter is updated in the element.

    Note: When a trap is received, the default time in the trap is used to display the time of the alarm in the Alarm Console.

  - The connector has a setting (**Trap Polling**) on the General page that will cause the relevant parameters to be polled again when a trap is received.

- **Refresh All** button (on the General page):

  - This button refreshes all necessary parameters.

  - Some parameters are not polled by default. They will only be polled when the **Refresh All** button is clicked (more details below).

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 0.8.5                       |

## Installation and configuration

### Creation

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device. The default value is *public*.
- **Set community string**: The community string used when setting values on the device. The default value is *private*.

## Usage

### General Page

This page contains general parameters such as the **Device Name**, **Location** and **Firmware**.

If the **Trap Polling** setting is enabled, a trap that is triggered will trigger a repolling of the parameters associated with this particular trap. (See Processed Traps table in the Notes section below).

The **Refresh Values** button triggers a repoll of all parameters.

There is a also a **Trap Time Period** parameter, which determines the maximum time interval between retrieving **Heartbeat Traps**. If no **Heartbeat Trap** is retrieved within this interval, 2 parameters (**Name** and **Location** of the device) will be polled, and the time of the **Activity Heart Notify** parameter will be adapted.

The page contains 8 page buttons:

- **GP3**: Opens a subpage with parameters such as the **GP0 Input**, the **GP1 Output**, and the **GP3 Input**.
- **SMTP**: Opens a subpage with parameters such as the **SMTP Server IP Address** and the **SMTPE Mail1 Address**.
- **Audio I/O**: Opens a subpage with the **Audio** parameters, such as the **Analogic Output Mode**, the **Analog Output Gain**, and the **Digital Input Gain**.
- **NTP**: Opens a subpage with the **NTP** parameters, such as the **NTP IP Address**, the **NTP Auto Request Time** and the **NTP Trap Failure**.
- **NMS4**: Opens a subpage with the **NMS4** parameters, such as the **NMS 4 IP Address**, the **NMS 4 Trap Port** and the **NMS 4 Trap Community**.
- **NMS3**: Opens a subpage with the **NMS3** parameters, such as the **NMS 3 IP Address**, the **NMS 3 Trap Port** and the **NMS 3 Trap Community**.
- **NMS2**: Opens a subpage with the **NMS2** parameters, such as the **NMS 2 IP Address**, the **NMS 2 Trap Port** and the **NMS 2 Trap Community**.
- **NMS1**: Opens a subpage with the **NMS1** parameters, such as the **NMS 1 IP Address**, the **NMS 1 Trap Port** and the **NMS 1 Trap Community**.

### Tuner Page

This page contains parameters concerning both **Tuner 1** (on the left) and **Tuner 2** (on the right), such as **IStream1 Encoder**, **Tuner 2 Stereo**, **Tuner 1 Freqs Channel**.

A number of page buttons lead to further parameters: **Audio**, **RDS**, **Status** and **Configuration.**

- The **Tuner 1 Status** subpage contains the **Tuner 1 Status** table and a **Polling Tuner 1 Status** toggle button.

- The **Tuner 1 Status** table contains parameters such as **Tuner 1 Tuned**, **Tuner 1 Frequency** and **Tuner 1 RF Level Low 1 Status**. The table is always polled when the element starts up, as well as every 60 seconds if the **Polling Tuner 1 Status** is set to *Enabled*. If the **Polling** **Tuner 1 Status** is set to *Disabled,* the table is polled every hour. There is also a **Refresh** button that allows you to trigger the instant polling for this specific table. Also, in case the **Refresh Values** button is clicked on the **General** page, this is one of the tables that is polled once. If a trap is received that is related to this table, the related parameters will be updated with the information from the trap, unless **Trap Polling** is enabled, in which case those parameters are repolled.

- The **Tuner 1 Configuration** subpage contains the **Tuner 1 Configuration** table and the **Tuner 1 RF Level Configuration** table. It also contains the **Polling Tuner 1 Configuration** toggle button.

- The **Tuner 1 Configuration** table contains parameters such as **Tuner 1 Tuned**, **Tuner 1 Frequency** and **Tuner 1 RF Level Low 1 Status**. If the **Polling Tuner 1 Configuration** toggle button is set to *Enabled*, this table is polled every hour, otherwise it is not polled after the initial polling during element startup. During element startup, it is always polled. If a trap is received that is related to this table, the related parameters will be updated with the information from the trap, unless **Trap Polling** is enabled, in which case those parameters are repolled.
  - The **Tuner 1 RF Level Configuration** table contains parameters such as **Tuner 1 RF Level Channel Name**, **Tuner 1 RF Level Low 1** and **Tuner 1 RF Level Low 1 Trap Label.** If the **Polling Tuner 1 Configuration** toggle button is set to *Enabled*, this table is polled every hour, otherwise it is not polled after the initial polling during element startup. During element startup, it is always polled. If a trap is received that is related to this table, the related parameters will be updated with the information from the trap, unless **Trap Polling** is enabled, in which case those parameters are repolled.

- The **Tuner 1 RDS** subpage contains the **Tuner 1 Rds** table and the **Tuner 1 Rds Scan Data** table. It also contains the **Polling Tuner 1 Rds** toggle button and the **Polling Tuner 1 Rds Scan Data** toggle button.

- The **Tuner 1 Rds** table contains parameters such as **Tuner 1 Rds Settings Pi Ref2** and **Tuner 1 Rds Settings PS Ref1**.
  - The **Tuner 1 Rds Scan Data** table contains parameters such as **Tuner 1 Data Scan Ms Val** and **Tuner 1 Data Scan AFStatus**. If the **Polling Tuner 1 Rds Scan** toggle button is set to *Enabled*, the **Tuner 1 Rds Scan Data** table is polled every 60 seconds, otherwise it is not polled after the initial polling during element startup. During element startup, it is always polled. Also, in case the **Refresh Values** button is clicked on the **General** page, this is one of the tables that is polled once. If a trap is received that is related to this table, the related parameters will be updated with the information from the trap, unless **Trap Polling** is enabled, in which case those parameters are repolled.

- The **Tuner 1 Audio** subpage contains the **Audio Tun1 Setup** table and the **Audio Tun1 Data** table.

- The **Audio Tun1 Setup** table contains parameters such as **Audio Tun1 Left Silence Mask** and **Audio Tun1 Left Silence Thr**. The table is polled once during element startup, as well as when the **Refresh Values** button is clicked on the **General** page. If a trap is received that is related to this table, the related parameters will be updated with the information from the trap, unless **Trap Polling** is enabled, in which case those parameters are repolled.
  - The **Audio Tun1 Data** table contains parameters such as **Audio Tun1 Left Peak** and **Audio Tun1 Right Silence Alarm Status**. The table is only polled when the **Refresh Values** button is clicked on the **General** page. If a trap is received that is related to this table, the related parameters will be updated with the information from the trap, unless **Trap Polling** is enabled, in which case those parameters are repolled.

- The **Tuner 2 Status** subpage contains the **Tuner 2 Status** table and the **Polling Tuner 2 Status** toggle button.

- The **Tuner 2 Status** table contains parameters such as **Tuner 2 Tuned**, **Tuner 2 Frequency** and **Tuner 2 RF Level Low 1 Status**. The table is always polled during element startup. If the **Polling Tuner 2 Status** is set to *Enabled*, it is also polled every 60 seconds, otherwise it is not polled after the initial polling during startup. There is also a **Refresh** button that allows you to trigger the instant polling for this specific table. Also, in case the **Refresh Values** button is clicked on the **General** page, this is one of the tables that is polled once. If a trap is received that is related to this table, the related parameters will be updated with the information from the trap, unless **Trap Polling** is enabled, in which case those parameters are repolled.

- The **Tuner 2 Configuration** subpage contains the **Tuner 2 Configuration** table and the **Tuner 2 RF Level Configuration** table. It also contains the **Polling Tuner 2 Configuration** toggle button.

- The **Tuner 2 Configuration** table contains parameters such as **Tuner 2** **Frequency** and **Tuner 2 RDS Level Mask**. If the **Polling Tuner 2 Configuration** toggle button is set to *Enabled*, the **Tuner 2 Configuration** is polled every hour, otherwise it is **not polled**. If a trap is received that is related to this table, the related parameters will be updated with the information from the trap, unless **Trap Polling** is enabled, in which case those parameters are repolled.
  - The **Tuner 2 RF Level Configuration** table contains parameters such as **Tuner 2 RF Level Channel Name**, **Tuner 2 RF Level Low 1** and **Tuner 1 RF Level Low 2 Trap Label**. If the **Polling Tuner 2 Configuration** toggle button is set to *Enabled*, the **Tuner 2 RF Level Configuration** is polled every hour, otherwise it is **not polled**. If a trap is received that is related to this table, the related parameters will be updated with the information from the trap, unless **Trap Polling** is enabled, in which case those parameters are repolled.

- The **Tuner 2 RDS** subpage contains the **Tun2 Rds** table and the **Tuner 2 Rds Scan Data** table.

- The **Tun2 Rds** Table contains parameters such as **Tuner 2 Rds Settings Pi Ref2** and **Tuner 2 Rds Settings PS Ref1**. The **Tuner 2 Rds** table is not polled after element startup. If the **Refresh Values** button is clicked on the **General** page, this is one of the tables that is polled once. If a trap is received that is related to this table, the related parameters will be updated with the information from the trap, unless **Trap Polling** is enabled, in which case those parameters are repolled.
  - The **Tuner 2 Rds Scan Data** table contains parameters such as **Tuner 2 Data Scan Ms Val** and **Tuner 2 Data Scan AFStatus**. The **Tuner 2 Rds Scan Data** table is not polled after element startup. If the **Refresh Values** button is clicked on the **General** page, this is one of the tables that is polled once. If a trap is received that is related to this table, the related parameters will be updated with the information from the trap, unless **Trap Polling** is enabled, in which case those parameters are repolled.

- The **Tuner 2 Audio** subpage contains the **Audio Tun2 Setup** table and the **Audio Tun2 Data** table.

- The **Audio Tun2 Setup** table contains parameters such as **Audio Tun2 Left Silence Mask** and **Audio Tun2 Left Silence Thr**. The **Audio Tun2 Setup** table is polled once during element startup, as well as when the **Refresh Values** button is clicked on the **General** page. If a trap is received that is related to this table, the related parameters will be updated with the information from the trap, unless **Trap Polling** is enabled, in which case those parameters are repolled.
  - The **Audio Tun2 Data** table contains parameters such as **Audio Tun2 Left Peak** and **Audio Tun2 Right Silence Alarm Status**. The **Audio Tun 2 Data** Table is only polled when the **Refresh Values** button is clicked on the **General** page. If a trap is received that is related to this table, the related parameters will be updated with the information from the trap, unless **Trap Polling** is enabled, in which case those parameters are repolled.

### Audio Digital page

The **Audio Digital** page contains the **Audio Digital Setup** table and the **Audio Digital Data** Table.

- The **Audio Digital Setup** table contains parameters such as **Audio Digital Left Silence Mask** and **Audio Digital Left Silence Thr**. This table is **not polled** during element startup. It is only polled when the **Refresh Values** button is clicked on the **General** page.
- The **Audio Digital Data** table contains parameters such as **Audio Digital Left Peak** and **Audio Digital Right Silence Alarm Status**. This table is **not polled** during element startup. It is only polled when the **Refresh Values** button is clicked on the **General** page. If a trap is received that is related to this table, the related parameters will be updated with the information from the trap, unless **Trap Polling** is enabled, in which case those parameters are repolled.

### Audio Analog page

The **Audio Analog** page contains the **Audio Analog Setup** table and the **Audio Analog Data** table.

- The **Audio Analog** table contains parameters such as **Audio Analog Left Silence Mask** and **Audio Analog Left Silence Thr**. This table is **not polled** during element startup. It is only polled when the **Refresh Values** button is clicked on the **General** page.
- The **Audio Analog Data** table contains parameters such as **Audio Analog Left Peak** and **Audio Analog Right Silence Alarm Status**. This table is **not polled** during element startup. It is only polled when the **Refresh Values** button is clicked on the **General** page. If a trap is received that is related to this table, the related parameters will be updated with the information from the trap, unless **Trap Polling** is enabled, in which case those parameters are repolled.

### Web Interface

This page displays the web interface of the original device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## Notes

The following tables provide additional information on the processed traps.

|                                    | **Processed Traps**                            |                                  |                                        |                         |                         |                                          |                                   |                                   |                                      |
|------------------------------------|------------------------------------------------|----------------------------------|----------------------------------------|-------------------------|-------------------------|------------------------------------------|-----------------------------------|-----------------------------------|--------------------------------------|
| **Tuner 1**                        | **Value Param**                                | **Status Param 1**               | **Status Param 2**                     | **Status Param 3**      | **Status Param 4**      | **Status Param 5**                       | **Time Param 1**                  | **Time Param 2**                  | **Time Param 3**                     |
| 1.3.6.1.4.1.27295.1.3.6.4.1.1.0.1  | Tuner 1 RF Level Low 1 Alarm                   | Tuner 1 RF Level                 | Tuner 1 RF Level Low 1 Status          | Tuner 1 time            |                         |                                          |                                   |                                   |                                      |
| 1.3.6.1.4.1.27295.1.3.6.4.1.1.0.2  | Tuner 1 RF Level Low 2 Alarm                   | Tuner 1 RF Level                 | Tuner 1 RF Level Low 2 Status          | Tuner 1 time            |                         |                                          |                                   |                                   |                                      |
| 1.3.6.1.4.1.27295.1.3.6.4.1.1.0.3  | Tuner 1 RF Level High 1 Alarm                  | Tuner 1 RF Level                 | Tuner 1 RF Level High 1 Status         | Tuner 1 time            |                         |                                          |                                   |                                   |                                      |
| 1.3.6.1.4.1.27295.1.3.6.4.1.1.0.4  | Tuner 1 RF Level High 2 Alarm                  | Tuner 1 RF Level                 | Tuner 1 RF Level High 2 Status         | Tuner 1 time            |                         |                                          |                                   |                                   |                                      |
| 1.3.6.1.4.1.27295.1.3.6.4.1.1.0.5  | Tuner 1 Deviation Alarm                        | Tuner 1 Deviation Trap           | Tuner 1 Deviation Status               | Tuner 1 time            |                         |                                          |                                   |                                   |                                      |
| 1.3.6.1.4.1.27295.1.3.6.4.1.1.0.6  | Tuner 1 Pilot Level Alarm                      | Tuner 1 Pilot Level              | Tuner 1 Pilot Level Status             | Tuner 1 time            |                         |                                          |                                   |                                   |                                      |
| 1.3.6.1.4.1.27295.1.3.6.4.1.1.0.7  | Tuner 1 RDS Level Alarm                        | Tuner 1 RDS Level                | Tuner 1 Level Status                   | Tuner 1 time            |                         |                                          |                                   |                                   |                                      |
| 1.3.6.1.4.1.27295.1.3.6.4.1.1.0.8  | Tuner 1 Audio Silence Alarm                    | Tuner 1 Audio Silence            | Tuner 1 Audio Silence Status           | Tuner 1 time            |                         |                                          |                                   |                                   |                                      |
| 1.3.6.1.4.1.27295.1.3.6.4.1.1.0.9  | Tuner 1 Pilot Low Level Alarm                  | Tuner 1 Pilot Level              | Tuner 1 Pilot Low Level Alarm Status   | Tuner 1 time            |                         |                                          |                                   |                                   |                                      |
| 1.3.6.1.4.1.27295.1.3.6.4.1.1.0.10 | Tuner 1 RDS Low Level Alarm Status Notify      | Tuner 1 RDS Level                | Tuner 1 RDS Low Level Alarm Status     | Tuner 1 RDS Scan Time   |                         |                                          |                                   |                                   |                                      |
| 1.3.6.1.4.1.27295.1.3.6.4.1.2.0.1  | Tuner 1 Data Scan Pi Status Notify             | Tuner 1 Data Scan Pi Value       | Tuner 1 Data Scan Pi Status            | Tuner 1 RDS Scan Time   |                         |                                          |                                   |                                   |                                      |
| 1.3.6.1.4.1.27295.1.3.6.4.1.2.0.2  | Tuner 1 Data Scan Ps Status Notify             | Tuner 1 Data Scan PS Value       | Tuner 1 Data Scan PS Status            | Tuner 1 RDS Scan Time   |                         |                                          |                                   |                                   |                                      |
| 1.3.6.1.4.1.27295.1.3.6.4.1.2.0.3  | Tuner 1 Data Scan Ta Status Notify             | Tuner 1 Data Scan Ta Val         | Tuner 1 Data Scan Ta Status            | Tuner 1 RDS Scan Time   |                         |                                          |                                   |                                   |                                      |
| 1.3.6.1.4.1.27295.1.3.6.4.1.2.0.4  | Tuner 1 Data Scan Rt Status Notify             | Tuner 1 Data Scan Rt Status      | Tuner 1 RDS Scan Time                  |                         |                         |                                          |                                   |                                   |                                      |
| 1.3.6.1.4.1.27295.1.3.6.4.1.2.0.5  | Tuner 1 Data Scan AF Status Notify             | Tuner 1 Data Scan AF Status      | Tuner 1 RDS Scan Time                  |                         |                         |                                          |                                   |                                   |                                      |
| 1.3.6.1.4.1.27295.1.3.6.4.1.2.0.7  | Tuner 1 Data Scan Oda Tmc Status Notify        | Tuner 1 Data Scan Oda Tmc Status | Tuner 1 time                           |                         |                         |                                          |                                   |                                   |                                      |
| 1.3.6.1.4.1.27295.1.3.6.4.1.2.0.11 | Tuner 1 Data Scan Bler Status Notify           | Tuner 1 Data Scan Bler           | Tuner 1 Data Scan Bler Status          | Tuner 1 RDS Scan Time   |                         |                                          |                                   |                                   |                                      |
| 1.3.6.1.4.1.27295.1.3.6.4.1.2.0.12 | Tuner 1 Data Scan Ct Status Notify             | Tuner 1 Data Scan Ct Val         | Tuner 1 Data Scan Ct Status            | Tuner 1 RDS Scan Time   |                         |                                          |                                   |                                   |                                      |
| 1.3.6.1.4.1.27295.1.3.6.4.1.2.0.13 | Tuner 1 Data Scan Tp Status Notify             | Tuner 1 Data Scan Tp Val         | Tuner 1 Data Scan Tp Status            | Tuner 1 RDS Scan Time   |                         |                                          |                                   |                                   |                                      |
| 1.3.6.1.4.1.27295.1.3.6.4.1.2.0.14 | Tuner 1 Data Scan Ih Status Notify             | Tuner 1 Data Scan Ih Status      | Tuner 1 RDS Scan Time                  |                         |                         |                                          |                                   |                                   |                                      |
| 1.3.6.1.4.1.27295.1.3.6.4.3.0.1    | Audio Tuner 1 Left Silence Alarm Status        | Tuner 1 Left Silence Mask        | Audio Tun1 Left Silence Trap Label     | Tuner 1 Tuned Frequency | Audio Tuner 1 Left Rms  | Audio Tuner 1 Left Silence Alarm Status  | Tuner 1 Configuration Update Time | Tuner 1 Setup Update Time         | Audio Tuner 1 Data Table Update Time |
| 1.3.6.1.4.1.27295.1.3.6.4.3.0.2    | Audio Tuner 1 Right Silence Alarm Status       | Tuner 1 Right Silence Mask       | Audio Tun1 Right Silence Trap Label    | Tuner 1 Tuned Frequency | Audio Tuner 1 Right Rms | Audio Tuner 1 Right Silence Alarm Status | Tuner 1 Configuration Update Time | Tuner 1 Setup Update Time         | Audio Tuner 1 Data Table Update Time |
| 1.3.6.1.4.1.27295.1.3.6.4.3.0.5    | Audio Digital Left Silence Alarm Status        | Audio Digital Left Silence Mask  | Audio Digital Left Silence Trap Label  | Digital Input Reference | Audio Digital Left Rms  | Audio Digital Left Silence Alarm Status  |                                   |                                   |                                      |
| 1.3.6.1.4.1.27295.1.3.6.4.3.0.6    | Audio Digital Right Silence Alarm Status       | Audio Digital Right Silence Mask | Audio Digital Right Silence Trap Label | Digital Input Reference | Audio Digital Right Rms | Audio Digital Right Silence Alarm Status |                                   |                                   |                                      |
| 1.3.6.1.4.1.27295.1.3.6.4.3.0.7    | Audio Analog Left Silence Alarm Status         | Audio Analog Left Silence Mask   | Audio Analog Left Silence Trap Label   | Analog Input Reference  | Audio Analog Left Rms   | Audio Analog Left Silence Alarm Status   |                                   |                                   |                                      |
| 1.3.6.1.4.1.27295.1.3.6.4.3.0.8    | Audio Analog Right Silence Alarm Status        | Audio Analog Right Silence Mask  | Audio Analog Right Silence Trap Label  | Analog Input Reference  | Audio Analog Right Rms  | Audio Analog Right Silence Alarm Status  |                                   |                                   |                                      |
| 1.3.6.1.4.1.27295.1.3.6.4.3.0.9    | Audio Tuner 1 Mono Silence Alarm Status Notify | Tuner 1 Audio Silence Mask       | Tuner 1 Audio Silence Trap Label       | Tuner 1 Tuned Frequency | Audio Tuner 1 Mono Rms  | Audio Tuner 1 Mono Silence Alarm Status  | Tuner 1 time                      | Tuner1 Configuration Update Time  |                                      |
| 1.3.6.1.4.1.27295.1.3.6.4.3.0.11   | Audio Tuner 1 Imbalance Alarm Status Notify    | Audio Tuner 1 Imbalance          | Audio Tuner 1 Imbalance Alarm Status   | Tuner 1 time            |                         |                                          |                                   |                                   |                                      |
| 1.3.6.1.4.1.27295.1.3.6.4.5.0.1    | NTP Alarm Status Notify                        | NTP Alarm Status                 | Activity Heart Notify                  |                         |                         |                                          |                                   |                                   |                                      |
| 1.3.6.1.4.1.27295.1.3.6.4.5.0.2    | Activity Heart Notify Trap                     |                                  |                                        |                         |                         |                                          |                                   |                                   |                                      |
|                                    |                                                |                                  |                                        |                         |                         |                                          |                                   |                                   |                                      |
| Tuner 2                            |                                                |                                  |                                        |                         |                         |                                          |                                   |                                   |                                      |
| 1.3.6.1.4.1.27295.1.3.6.4.2.1.0.1  | Tuner 2 RF Level Low 1 Alarm                   | Tuner 2 RF Level                 | Tuner 2 RF Level Low 1 Status          | Tuner 2 Time            |                         |                                          |                                   |                                   |                                      |
| 1.3.6.1.4.1.27295.1.3.6.4.2.1.0.2  | Tuner 2 RF Level Low 2 Alarm                   | Tuner 2 RF Level                 | Tuner 2 RF Level Low 2 Status          | Tuner 2 Time            |                         |                                          |                                   |                                   |                                      |
| 1.3.6.1.4.1.27295.1.3.6.4.2.1.0.3  | Tuner 2 RF Level High 1 Alarm                  | Tuner 2 RF Level                 | Tuner 2 RF Level High 1 Status         | Tuner 2 Time            |                         |                                          |                                   |                                   |                                      |
| 1.3.6.1.4.1.27295.1.3.6.4.2.1.0.4  | Tuner 2 RF Level High 2 Alarm                  | Tuner 2 RF Level                 | Tuner 2 RF Level High 2 Status         | Tuner 2 Time            |                         |                                          |                                   |                                   |                                      |
| 1.3.6.1.4.1.27295.1.3.6.4.2.1.0.5  | Tuner 2 Deviation Alarm                        | Tuner 2 Deviation                | Tuner 2 Deviation Status               | Tuner 2 Time            |                         |                                          |                                   |                                   |                                      |
| 1.3.6.1.4.1.27295.1.3.6.4.2.1.0.6  | Tuner 2 Pilot Level Alarm                      | Tuner 2 Pilot Level              | Tuner 2 Pilot Level Status             | Tuner 2 Time            |                         |                                          |                                   |                                   |                                      |
| 1.3.6.1.4.1.27295.1.3.6.4.2.1.0.7  | Tuner 2 RDS Level Alarm                        | Tuner 2 RDS Level                | Tuner 2 Level Status                   | Tuner 2 RDS Time        |                         |                                          |                                   |                                   |                                      |
| 1.3.6.1.4.1.27295.1.3.6.4.2.1.0.8  | Tuner 2 Audio Silence Alarm                    | Tuner 2 Audio Silence            | Tuner 2 Audio Silence Status           | Tuner 2 Time            |                         |                                          |                                   |                                   |                                      |
| 1.3.6.1.4.1.27295.1.3.6.4.2.1.0.9  | Tuner 2 Pilot Low Level Alarm                  | Tuner 2 Pilot Level              | Tuner 2 Pilot Low Level Alarm Status   | Tuner 2 Time            |                         |                                          |                                   |                                   |                                      |
| 1.3.6.1.4.1.27295.1.3.6.4.2.1.0.10 | Tuner 2 RDS Low Level Alarm Status Notify      | Tuner 2 RDS Level                | Tuner 2 RDS Low Level Alarm Status     | Tuner 2 Time            |                         |                                          |                                   |                                   |                                      |
| 1.3.6.1.4.1.27295.1.3.6.4.2.2.0.1  | Tuner 2 Data Scan Pi Status Notify             | Tuner 2 Data Scan Pi Value       | Tuner 2 Data Scan Pi Status            | Tuner 2 RDS Time        |                         |                                          |                                   |                                   |                                      |
| 1.3.6.1.4.1.27295.1.3.6.4.2.2.0.2  | Tuner 2 Data Scan Ps Status Notify             | Tuner 2 Data Scan Ps Value       | Tuner 2 Data Scan Ps Status            | Tuner 2 RDS Time        |                         |                                          |                                   |                                   |                                      |
| 1.3.6.1.4.1.27295.1.3.6.4.2.2.0.3  | Tuner 2 Data Scan Ta Status Notify             | Tuner 2 Data Scan Ta Val         | Tuner 2 Data Scan Ta Status            | Tuner 2 RDS Time        |                         |                                          |                                   |                                   |                                      |
| 1.3.6.1.4.1.27295.1.3.6.4.2.2.0.4  | Tuner 2 Data Scan Rt Status Notify             | Tuner 2 Data Scan Rt Status      | Tuner 2 Time                           |                         |                         |                                          |                                   |                                   |                                      |
| 1.3.6.1.4.1.27295.1.3.6.4.2.2.0.5  | Tuner 2 Data Scan AF Status Notify             | Tuner 2 Data Scan AFStatus       | Tuner 2 Time                           |                         |                         |                                          |                                   |                                   |                                      |
| 1.3.6.1.4.1.27295.1.3.6.4.2.2.0.11 | Tuner 2 Data Scan Bler Status Notify           | Tuner 2 Data Scan Bler           | Tuner 2 Data Scan Bler Status          | Tuner 2 Time            |                         |                                          |                                   |                                   |                                      |
| 1.3.6.1.4.1.27295.1.3.6.4.2.2.0.12 | Tuner 2 Data Scan Ct Status Notify             | Tuner 2 Data Scan Ct Val         | Tuner 2 Data Scan Ct Status            | Tuner 2 RDS Time        |                         |                                          |                                   |                                   |                                      |
| 1.3.6.1.4.1.27295.1.3.6.4.2.2.0.13 | Tuner 2 Data Scan Tp Status Notify             | Tuner 2 Data Scan Tp Val         | Tuner 2 Data Scan Tp Status            | Tuner 2 RDS Time        |                         |                                          |                                   |                                   |                                      |
| 1.3.6.1.4.1.27295.1.3.6.4.2.2.0.14 | Tuner 2 Data Scan Ih Status Notify             | Tuner 2 Data Scan Ih Status      | Tuner 2 RDS Time                       |                         |                         |                                          |                                   |                                   |                                      |
| 1.3.6.1.4.1.27295.1.3.6.4.3.0.10   | Tuner 2 Mono Silence Alarm Status Notify       | Tuner 2 Audio Silence Mask       | Tuner 2 Audio Silence Trap Label       | Tuner 2 Tuned Frequency | Audio Tuner 2 Mono Rms  | Audio Tuner 2 Mono Silence Alarm Status  | Tuner 2 Time                      | Tuner 2 Configuration Update Time |                                      |
