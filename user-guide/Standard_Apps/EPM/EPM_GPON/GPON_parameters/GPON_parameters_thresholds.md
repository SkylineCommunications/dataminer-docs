---
uid: GPON_parameters_thresholds
---

# GPON parameters – Thresholds

## Overview

The EPM Solution is aimed to detect behavioral patterns in a network, due to this, it will never generate alarms at the lower CPE leven - _in this case an ONT_ - as a massive failure will generate an alarm Storm that the NOC operators or automatic systems receiving the notifications will have a hard time troubleshooting and following them up. For that reason, it is necessary to compare the ONT's operational levels to a set of conditions to know if the ONT (and by aggregation) the network is behaving as expected or there is any issue that needs to be fixed.

Those conditions are called Thresholds, and they can be configured by the GPON EPM administrator with the values that are most suited for the normal behavior of the network.

As mentioned in [GPON Architecture / ONT Data](xref:GPON_architecture#ont-data-connector) all operational data related to the ONTs is acquired from a third party stream, then parsed, and finally stored for analysis. The storage takes place in the OLT connector in which the ONT is detected. The threshold configuration needs to be done at the OLT element, in case of multiple elements using the same connector, you can use the **Multiple set feature** in dataminer to speed up your process.

## Available configuration

- **Bias Current Minimum and Maximum**: Upper and lower boundaries for acceptable values reported by the data stream in the parameter:

  ```json
  "InternetGatewayDevice.WANDevice{i}WANPONInterfaceConfig.BiasCurrent"
  ```

- **Supply Voltage Minimum and Maximum**: Upper and lower boundaries for acceptable values reported by the data stream in the parameter:

  ```json
  "InternetGatewayDevice.WANDevice{i}WANPONInterfaceConfig.SupplyVoltage"
  ```

- **Rx Power Minimum and Maximum**: Upper and lower boundaries for acceptable values reported by the data stream in the parameter:

  ```json
  "InternetGatewayDevice.WANDevice{i}WANPONInterfaceConfig.RXPower"
  ```

- **Tx Power Minimum and Maximum**: Upper and lower boundaries for acceptable values reported by the data stream in the parameter:

  ```json
  "InternetGatewayDevice.WANDevice{i}WANPONInterfaceConfig.TXPower"
  ```

- **Transceiver Temperature Minimum and Maximum**: Upper and lower boundaries for acceptable values reported by the data stream in the parameter:

  ```json
  "InternetGatewayDevice.WANDevice{i}WANPONInterfaceConfig.TransceiverTemperature"
  ```

After the data acquisition takes place, the data is parsed, analyzed for errors in format, and adjusted to be stored in the OLT element parameters. Unless instructed otherwise, all parameters are named in the same way as its threshold counterpart.

Once stored, the received value is compared with the Maximum and Minimum configured thresholds, if the value is within the accepted interval the value is calculated as OK, it the value is higher or lower, the value is calculated as OOS. This calculated value is also stored for future analysis and aggregation. The parameters in which is stored have a _state_ at the end, For instance, for Bias Current and Tx Power, the storage will take place in:

|Operational Value received|Threshold compliance|
|:--|:--|
|Bias Current|Bias Current State|
|Tx Power|Tx Power State|
