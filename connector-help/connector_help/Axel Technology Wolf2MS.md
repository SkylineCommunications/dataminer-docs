---
uid: Connector_help_Axel_Technology_Wolf2MS
---

# Axel Technology Wolf2MS

The Wolf2MS driver is an FM Controller. The device monitors FM transmissions. This driver can be used to process this data and configure the device.

## About

The driver communicates with the device via **SNMP**. It also uses traps in order to save bandwidth.

### Timing

All data gets retrieved from the device in 3 different ways.

1.  **Timers**:

2.  - Slow timer that triggers every hour and polls a few general parameters.
    - Fast timer that triggers every minute and polls Tuner 1 status parameters.
    - Some tables can be made to update faster. (Refer to the information on the different tables below for more details).

3.  **Traps**:

4.  - Status parameters can be received through traps from the device. As soon as a trap is received, the parameter is updated in the element.Note: When a trap is received, the default time in the trap is used to display the time of the alarm in the Alarm Console.
    - The driver has a setting (**Trap Polling**) on the General page that will cause the relevant parameters to be polled again when a trap is received.

5.  **Refresh All** button (on the General page):

6.  - This button refreshes all necessary parameters.
    - Some parameters are not polled by default. They will only be polled when the **Refresh All** button is clicked (more details below).

### Ranges of the driver

| **Driver Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Supported firmware versions

| **Driver Range** | **Device Firmware Version** |
|------------------|-----------------------------|
| 1.0.0.x          | 0.8.5                       |

## Installation and configuration

### Creation

#### SNMP main connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

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

- The **Tuner 2 Status** table contains parameters such as **Tuner 2 Tuned**, **Tuner 2 Frequency** and **Tuner 2 RF Level Low 1 Status**. The table is always polled during element startup. If the **Polling Tuner 2 Status** is set to *Enabled*, it is also polled every 60 seconds, otherwise it is not polled after the initial polling during startup. There is also a **Refresh** button that allows you to trigger the instant polling for this specific table.Also, in case the **Refresh Values** button is clicked on the **General** page, this is one of the tables that is polled once. If a trap is received that is related to this table, the related parameters will be updated with the information from the trap, unless **Trap Polling** is enabled, in which case those parameters are repolled.

- The **Tuner 2 Configuration** subpage contains the **Tuner 2 Configuration** table and the **Tuner 2 RF Level Configuration** table. It also contains the **Polling Tuner 2 Configuration** toggle button.

- The **Tuner 2 Configuration** table contains parameters such as **Tuner 2** **Frequency** and **Tuner 2 RDS Level Mask**. If the **Polling Tuner 2 Configuration** toggle button is set to *Enabled*, the **Tuner 2 Configuration** is polled every hour, otherwise it is **not polled**. If a trap is received that is related to this table, the related parameters will be updated with the information from the trap, unless **Trap Polling** is enabled, in which case those parameters are repolled.
  - The **Tuner 2 RF Level Configuration** table contains parameters such as **Tuner 2 RF Level Channel Name**, **Tuner 2 RF Level Low 1** and **Tuner 1 RF Level Low 2 Trap Label**. If the **Polling Tuner 2 Configuration** toggle button is set to *Enabled*, the **Tuner 2 RF Level Configuration** is polled every hour, otherwise it is **not polled**.If a trap is received that is related to this table, the related parameters will be updated with the information from the trap, unless **Trap Polling** is enabled, in which case those parameters are repolled.

- The **Tuner 2 RDS** subpage contains the **Tun2 Rds** table and the **Tuner 2 Rds Scan Data** table.

- The **Tun2 Rds** Table contains parameters such as **Tuner 2 Rds Settings Pi Ref2** and **Tuner 2 Rds Settings PS Ref1**. The **Tuner 2 Rds** table is not polled after element startup. If the **Refresh Values** button is clicked on the **General** page, this is one of the tables that is polled once. If a trap is received that is related to this table, the related parameters will be updated with the information from the trap, unless **Trap Polling** is enabled, in which case those parameters are repolled.
  - The **Tuner 2 Rds Scan Data** table contains parameters such as **Tuner 2 Data Scan Ms Val** and **Tuner 2 Data Scan AFStatus**. The **Tuner 2 Rds Scan Data** table is not polled after element startup. If the **Refresh Values** button is clicked on the **General** page, this is one of the tables that is polled once. If a trap is received that is related to this table, the related parameters will be updated with the information from the trap, unless **Trap Polling** is enabled, in which case those parameters are repolled.

- The **Tuner 2 Audio** subpage contains the **Audio Tun2 Setup** table and the **Audio Tun2 Data** table.

- The **Audio Tun2 Setup** table contains parameters such as **Audio Tun2 Left Silence Mask** and **Audio Tun2 Left Silence Thr**. The **Audio Tun2 Setup** table is polled once during element startup, as well as when the **Refresh Values** button is clicked on the **General** page. If a trap is received that is related to this table, the related parameters will be updated with the information from the trap, unless **Trap Polling** is enabled, in which case those parameters are repolled.
  - The **Audio Tun2 Data** table contains parameters such as **Audio Tun2 Left Peak** and **Audio Tun2 Right Silence Alarm Status**. The **Audio Tun 2 Data** Table is only polled when the **Refresh Values** button is clicked on the **General** page. If a trap is received that is related to this table, the related parameters will be updated with the information from the trap, unless **Trap Polling** is enabled, in which case those parameters are repolled.

### Audio Digital page

The **Audio Digital**page contains the **Audio Digital Setup** table and the **Audio Digital Data** Table.

- The **Audio Digital Setup** table contains parameters such as **Audio Digital Left Silence Mask** and **Audio Digital Left Silence Thr**. This table is **not polled** during element startup. It is only polled when the **Refresh Values** button is clicked on the **General** page.
- The **Audio Digital Data** table contains parameters such as **Audio Digital Left Peak** and **Audio Digital Right Silence Alarm Status**. This table is **not polled** during element startup. It is only polled when the **Refresh Values** button is clicked on the **General** page. If a trap is received that is related to this table, the related parameters will be updated with the information from the trap, unless **Trap Polling** is enabled, in which case those parameters are repolled.

### Audio Analog page

The **Audio Analog**page contains the **Audio Analog Setup** table and the **Audio Analog Data** table.

- The **Audio Analog** table contains parameters such as **Audio Analog Left Silence Mask** and **Audio Analog Left Silence Thr**. This table is **not polled** during element startup. It is only polled when the **Refresh Values** button is clicked on the **General** page.
- The **Audio Analog Data** table contains parameters such as **Audio Analog Left Peak** and **Audio Analog Right Silence Alarm Status**. This table is **not polled** during element startup. It is only polled when the **Refresh Values** button is clicked on the **General** page. If a trap is received that is related to this table, the related parameters will be updated with the information from the trap, unless **Trap Polling** is enabled, in which case those parameters are repolled.

### Webinterface

This page displays the web interface of the original device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## Notes

The following tables provide additional information on the processed traps.

