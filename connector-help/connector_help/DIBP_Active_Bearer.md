---
uid: Connector_help_DIBP_Active_Bearer
---

# DIBP Active Bearer

Via configurable element connections, the **DIBP Active Bearer** connects with multiple different element parameters in order to determine the current active bearer.

## About

This is a virtual connector that uses element connections to receive values from **EBEM** and **Cobra** devices and an **average ping-based latency** connector.

The received parameter values are used in a series of checks that help the connector to determine the **Active Bearer** of the vessel.

The **Active Bearer** is determined by first checking the **latency** value. The expected values for latency for GX or WGS should fall between the lower and higher threshold values. The connector will then check if GX or WGS is configured to be active, based on the parameters from the EBEM and/or Cobra devices, in order to determine if the active bearer is **GX, WGS, Unknown, Blocked, Down** or **Off**.

The EBEM and/or Cobra parameter values are then used to determine if **Statistics** parameters should be started, such as **Uptime**, **Downtime** and **Outage Time**. Basically, if the EBEM and/or the Cobra are configured to transmit as GX and/or WGS, but the measured latency indicates that this is not the case (i.e. the latency is outside of the expected lower or upper ranges for GX or WGS), this is considered to be an outage.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial version | No                  | Yes                     |

## Installation and configuration

### Creation

This connector uses element connections which need to be configured during element creation (or in **DataMiner Cube**, using the **Element Connections** app).

## Usage

### General

This page contains parameters from the different connected elements, as well as configurable parameters that are used in the logic to determine the **Active Bearer**.

The parameters on this page are:

- **Latency Lower Threshold**: Allows you to set the **lowest value** the latency can have in order to have a **valid active bearer** value that is either **GX or WGS.**
- **Latency Higher Threshold**: Allows you to set the **highest value** the latency can have in order to have a **valid active bearer** value that is either **GX or WGS.**
- **Latency:** For this parameter, a numeric value is retrieved trom the **average ping-based latency** **element** via element connections.
- **Cobra Satellite**: This parameter is retrieved from the **Cobra Device element** via element connections. The parameter can have the value *GX*, *WGS* or *Generic*.
- **Modem Network State**: This parameter is retrieved from the **Cobra Device element** via element connections. The parameter should have the value *In Network*.
- **Terminal Mode Configuration**: This parameter is retrieved from the **Cobra Device element** via element connections. The parameter should have the value *Operating*.
- **Transmission** **Status**: This parameter is retrieved from the **Cobra Device element** via element connections. The parameter can have the value *Disabled* or *Enabled*.
- **Safety Zone**: This parameter is retrieved from the **Cobra Device element** via element connections. The parameter can have the value *Disabled* or *Enabled*.
- **Modem Status**: This parameter is retrieved from the **Cobra Device element** via element connections. The parameter can have the value *Locked* or *Unlocked*.
- **EBEM Acquired State**: This parameter is retrieved from the **EBEM Device element** via element connections. The parameter can have the value *Idle*, *Init Acquired*, *Init Re-Acquired* or *Acquired*.
- **EBEM Transmission Operation**: This parameter is retrieved from the **EBEM** **Device element** via element connections. The parameter can have the value *Disabled* or *Enabled*.
- **Active Bearer:** Based on the values of the parameters received via element connections, this parameter can have the following values: *GX*, *WGS*, *3G/4G*, *FB500*, *Blocked*, *Off*, *Down*, *None*, *Unknown*.
- **Wooded:** Based on a check of the Active Bearer parameter, this parameter can have the values *Disabled* or *Enabled*. This indicates whether the transmission is being blocked because the antenna is positioned towards a safety zone.
- **Uptime:** This parameter displays the uptime of the active bearer. However, it only does so if the Active Bearer parameter is set to *GX* or *WGS*, the Terminal Mode Configuration is set to *Operating*, the Transmission Status is *Enabled* and either the Modem Status is *Locked* or EBEM Transmission Operation is *Enabled*. The parameter is updated every 5 seconds.
- **Downtime:** This parameter displays the downtime of the Active Bearer. However, it only does so if the parameters mentioned for Uptime do not have the above-mentioned values or the Active Bearer is set to *Off*. This parameter is updated every 5 seconds.
- **Outage:** This parameter displays the outage time of the Active Bearer. However, it only does so if the Wooded parameter is *Disabled*. This parameter is updated every 5 seconds.
- **Time of Outage**: This parameter displays the start time of the outage of the **Active Bearer**. This parameter is only activated if the Wooded parameter is *Disabled*. The parameter is updated every 5 seconds.
- **Event Logging**: This parameter allows you to turn on additional logging related to the checks that occur in order to determine the **Current Active Bearer**.

## Notes

The vessel can have several different active bearers. The active bearer is determined based on the state of several different parameters:

1. The first step to determine the active bearer checks the value of the latency that is received from the **average ping-based latency** element.

   The possible values of the **Active Bearer** parameter can be limited based on the received value:

   - If the value is **between the lower and higher** threshold, the active bearer is expected to be ***GX*, *WGS*** or ***Blocked***.

   - If the value is **above the higher threshold**, the active bearer is expected to be ***FB500*** or ***Blocked*.**

   - If the value is **below the lower threshold**, the active bearer is expected to be ***3G/4G*** or ***Blocked*.**

   - if the latency is **not available** or **does not exist**, the active bearer is ***Down***.

   - If none of the above apply, this will result in **Unknown**. In normal circumstances, this value will never occur. It was implemented in case unexpected situations should occur.

1. The second step checks parameters from the Cobra and EBEM element to determine the active bearer. **Cobra parameters** are used to check if the active bearer is **GX**, while both **Cobra and EBEM parameters** are used to determine if it is **WGS**.

   **GX** and **WGS** are considered to be the expected active bearer under normal operating conditions.

   These are some of the combinations of parameters used to perform these checks:

   - If Cobra Satellite is *GX*, Modem Network State is *In Network*, Safety Zone is *Enabled* and Transmission Status is *Enabled*, this will result in **GX** if the latency is between the lower and higher threshold, and in **Unknown** if the latency is not between the thresholds.

   - If Cobra Satellite is *WGS* or *Generic*, EBEM Acquired State is *Acquired*, Safety Zone is *Enabled* and Transmission Status is *Enabled*, this will result in **WGS** if the latency is between the lower and higher threshold, and in **Unknown** if the latency is not between the thresholds.

   - If Cobra Satellite is *WGS* or *Generic*, EBEM Acquired State is not *Acquired*, Safety Zone is *Enabled* and Transmission Status is *Enabled*, this will result in **FB500** if the latency is higher than the threshold, **3G/4G** if it is lower than the threshold, and **Unknown** if neither of these apply.

1. The final step also checks parameters from the Cobra and EBEM elements. **Cobra** **parameters** are used in the check if the active bearer is **GX**, while both **Cobra** **and** **EBEM parameters** are used in the check if it is **WGS.** This is similar to the previous step, but now the check is executed in order to determine which **statistics** will be started.

   The following active bearer values activate the statistics:

   - ***GX*** **and** ***WGS***: For these values, the **Uptime** is activated as these are the **only values that are expected during normal operation.**

   - ***FB500*, *3G/4G*, *Down*, *Unknown* and *Blocked***: These values activate the **Downtime**, as these are not expected during normal operation. These can also activate the **Outage and Time of Outage,** if **Wooded** is ***Disabled***.
