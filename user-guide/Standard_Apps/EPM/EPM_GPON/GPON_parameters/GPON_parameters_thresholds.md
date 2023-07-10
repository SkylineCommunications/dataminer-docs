---
uid: GPON_parameters_thresholds
---

# EPM GPON parameter thresholds

The EPM Solution is aimed to detect behavioral patterns in a network. As such, it will never generate alarms at the lower CPE level, in this case an ONT, as a massive failure would generate an alarm storm, which would make troubleshooting and follow-up difficult for the NOC operators or automatic systems receiving the notifications. For that reason, the ONT's operational levels need to be compared to a set of conditions to know if the ONT (and by aggregation) the network is behaving as expected or if there is any issue that needs to be fixed.

These conditions are called **thresholds**, and they can be configured by the GPON EPM administrator with the values that are most suited for the normal behavior of the network.

As mentioned under [GPON Architecture](xref:GPON_architecture#ont-data-connector) all operational data related to the ONTs is acquired from a third-party stream, then parsed, and finally stored for analysis. The storage takes place in the OLT connector detecting the ONT. The threshold configuration needs to be done in the OLT element. If multiple elements use the same connector, you can use the [multiple set feature](xref:Updating_elements#setting-a-parameter-value-in-multiple-elements) to speed up the process.

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

After the data acquisition takes place, the data is parsed, analyzed for formatting errors, and adjusted to be stored in the OLT element parameters. Unless instructed otherwise, all parameters are named the same way as the threshold counterparts.

Once the data is stored, the received value is compared with the maximum and minimum configured thresholds. If the value is within the accepted interval, the value is calculated as OK. If the value is higher or lower, the value is calculated as *OOS*. This calculated value is also stored for future analysis and aggregation. The parameters storing this value end in *state*. For example, for the *Bias Current* and *Tx Power* values, this will be *Bias Current State* and *Tx Power State*, respectively.
