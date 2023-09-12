---
uid: Connector_help_Carel_PCO5_Lennox
---

# Carel PCO5 Lennox

This connector will communicate with the Carel PCO5 Lennox, which is an air conditioning system.

The connector communicates via a TCP/IP connection using the MODBUS RTU protocol.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.17 HF12001415        |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Serial connection - Main

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Direct connection:

- **Bus address:** between 0 and 255
  - **Baudrate**: Should match the settings on the pCO5 and application.
  - **Databits**: Should match the settings on the pCO5 and application.
  - **Stopbits**: Should match the settings on the pCO5 and application.
  - **Parity**: Should match the settings on the pCO5 and application.
  - **FlowControl**: Should match the settings on the pCO5 and application.

- Interface connection:

- **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device.
  - **Bus address**: The bus address of the device. Range: *0-255*.

### Configuration

The **Carel PCO5 Lennox** needs to be set to the bus parameter selected in DataMiner.

In case of a direct **serial connection**, the pCO5+ application settings for baud rate, stop bits, and parity need to match the ones specified in DataMiner.

## How to Use

### General

The General page defines general parameters such as **Software Version**, **Date and Time**, and **Unit Status**.

### Measurements

The Measurements page defines general measurement values and contains parameters such as **Current Airflow**, **Filter Working Hours**, **Active Power Absorbed**, and **Envelope Action C1**.

There are also page buttons to the following subpages:

- **Humidifier Measurements**: Contains measurements related to the humidifier function of the air conditioning, such as **Valve 1 Inlet Water Pressure**, **Cooling Capacity Water C1**, **External Air Humidity**, and **Inlet Air Humidity**.
- **Compressor Measurements**: Contains measurements related to the compressor function of the air conditioning, such as **Compressor Status 5** and **Compressor 3 Working Hours**
- **Temperature Measurements**: Contains temperature measurement information, such as **External Air Temperature by Probe**, **Inlet Temperature 1**, **Outlet Temperature 1**, and **Condensation Temperature Dew-Point C1**.
- **Inverter Measurements**: Contains measurements related to the inverter function, such as **Inverter Compressor 1 Speed** and Feedback Inverter 2.,
- **Fans Measurements**: Contains measurements related to the fans, such as **Fans Request 1**, **Fan Working Hours**, and **Fans Speed 3**.
- **Pressure Measurements**: Contains pressure-related measurements, such as **DP**, **Hot Gas Pressure C2**, **Low Pressure C1**, **High Pressure C2**, and **Valve 1 Position**.
- **EEV Measurements**: Contains measurements related to the Electronic Expansion Valves, such as **Electronic Expansion Valve 1 Position**.
- **Condenser Measurements**: Contains measurements related to the condenser function, such as **Condenser Evaporator or Drycooler Fans Speed**.

### Alarms

The Alarms page defines general alarms and contains parameters such as **General Status**, **AL066 Flooding Status**, **Configurable Alarm Status**, **AL048 Dirty Filter Status**, and **AL010 Clock Status**.

There are also page buttons to the following subpages:

- **Pressure Alarms**: Contains pressure-related alarms, such as **AL031 Low Pressure C1 Probe Status**, **AL059 High Pressure C1 Status by Probe**, **AL086 Minimum Evaporating Pressure Envelope 2 Status**, and **Hot Gas Precise Request C2**.
- **Temperature Alarms**: Contains temperature-related alarms, such as **AL071 High Room Temperature Status**, **AL014 Inlet Temperature Probe 1 Status**, and **AL035 Suction Temperature C1 Probe Status**.
- **Humidifier Alarms**: Contains humidifier-related alarms, such as **AL233 CPY Internal Memory Status**, **AL245 Drain Valve Problem Status**, **AL028 Inlet Humidity Probe Status**, and **AL098 Working Hours FC Status**.
- **Fan Alarms**: Contains fan-related alarms, such as **AL096 Working Hours Fan Status**, and **AL281 Status User Fan 3**.
- **Condenser Alarms**: Contains condenser-related alarms, such as **AL049 Thermal Fan Status**, **AL078 Maximum Condensing Pressure Envelope 1 Status**.
- **Compressor Alarms**: Contains compressor-related alarms, such as **AL061 Thermal Head Comp. Inverter 1**, **AL091 Working Hours Compressor 2 Status** and **Compressor 3 Status**.
- **Inverter 1 Alarms**: Contains alarms related to inverter 1, such as **AL144 Communication Status Inverter 1**, **AL138 Earth Status Inverter 1**, and **AL148 Excessive Speed Deviation Status Inverter 1**
- **Inverter 2 Alarms**: Contains alarms related to inverter 2, such as **AL204 Communication Status Inverter 2**, **AL198 Earth Status Inverter 2**, and **AL208 Excessive Speed Deviation Status Inverter 2**.
- **PCOE Alarms**: Contains PCOE-related alarms, such as **AL101 pCOE1 Offline Status** and **AL105 pCOE5 Offline Status**.
- **EEV Alarms**: Contains alarms related to the Electronic Expansion Valves, such as **AL106 EEV 1 Offline Status**, **AL112 EEV 2 LAN Status**, and **AL261 EEV 3 Step Motor Status**.

### Settings

The Settings page defines general settings and contains parameters such as **Request BMS Unit Info**, **Reset Alarm**, and **Reset Electrical Energy Totalizer**.

There are also page buttons to the following subpages:

- **BMS**: Contains BMS-related settings, such as **Request BMS Unit Info**, **BMS 1 Watchdog Integer Variables**, **BMS Airflow Set-Point**, **Heating Request by BMS**, and **Dehumidifier Request by BMS**.
- **pLan**: Contains pLan-related settings, such as **Set all Units Status by pLAN (Only from Unit 1)** and **Reset Alarm All Units in pLAN**.
- **Temperature Settings**: Contains temperature-related settings, such as **External Air Temperature by BMS**, **Valve 1 Status Unit by BMS**, **Valve 2 Logic Temperature Function Valve by BMS**, **Free-Cooling Deactivation Status**, and **Dual Cooling Priority**.
- **Humidifier Settings**: Contains humidifier-related settings, such as **Reset Energy Water C1 Totalizer**, **Humidifier Request by BMS**, and **Dehumidifier Status Request by BMS**
- **Condenser Settings**: Contains condenser-related settings, such as **Fans Speed determined by BMS** and **Reset Energy Modbus Fan Totalizer**.
- **Compressor Settings**: Contains compressor-related settings, such as **Limit Maximum Compressor Speed Forced by BMS**.
- **Fan Settings**: Contains fan-related settings, such as **External Fan Request**.
