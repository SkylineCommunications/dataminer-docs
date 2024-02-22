---
uid: EPM_1.0.8_VSAT
---

# EPM 1.0.8 VSAT

## New features

#### Intelsat Flex Platform VSAT: Circuit Name added to Terminals Table [ID_38242]

A new parameter, Circuit Name, has been added to the Terminals Table of the Intelsat Flex Platform VSAT connector. In addition, the Circuits Table has been updated to also include remotes that are not present in the VSAT database.

#### Verizon iDirect Evolution Platform Collector: New Nominal Carrier Remotes KPI [ID_38372]

In the Hub Return Overview table of the Verizon iDirect Evolution Platform Collector, a new Nominal Carrier Remotes column has been added. This column will show the number of remotes reporting to a nominal carrier per inroute group.

## Changes

### Enhancements

#### Verizon iDirect Evolution Platform Collector: Improved descriptions for Hub Return Overview and Carriers tables KPIs [ID_38074]

The descriptions for the Hub Return Overview and Carriers tables KPIs have been improved, so that these now include the correct calculations and sources.

#### Intelsat Flex Platform VSAT: Remote stats history sets integration [ID_38136]

Previously, The Intelsat Flex Platform VSAT connector was configured to poll and record only one data point every 5 minutes, or at an interval set by the *Topic Data Import Timer* parameter on the *Topic Settings* page.

To improve the granularity and timeliness of the data being captured and displayed in the trend graph, history sets have now been implemented to the KPIs in the *Terminals* and *SSPCs* tables. This enhancement means that instead of capturing a single data point per polling cycle, the system now records all available data points.

#### Newtec Dialog Platform VSAT: Logging added for query timeouts [ID_38371]

Additional logging has been implemented in the Newtec Dialog Platform VSAT connector to get more transparency on query timeouts. This logging includes the query that failed and the method or QAction it originated from.

In addition, the TSDB tables have been updated with cleanup logic, and the connector will now check for missing columns in the response.

#### Verizon iDirect Evolution Platform Collector: Polling and table lock improvements [ID_38373]

To prevent possible issues, the cancellation token logic in the Verizon iDirect Evolution Platform Collector connector has been updated to deal with child methods, allowing cancellation all the way down the chain. In addition, the locked table query logic has been updated to prevent false positives.

#### Generic Trap Processor: Improved tooltips [ID_38375]

The tooltips for parameters in the Generic Trap Processor connector have been improved. They now provide more details, and spelling errors have been removed.

#### Generic Sun Outage: Buffer improvement [ID_38378]

The buffer logic of the Generic Sun Outage connector has been updated: The number of keys that can be processed has increased, and performance has significantly improved.

#### Verizon iDirect Evolution Platform Collector: Unused parameters no longer shown [ID_38475]

Because the following parameters of the Verizon iDirect Evolution Platform Collector were unused, these will now no longer be displayed:

- For the Hub Return Overview, Hub Forward Overview, Linecard, Hub Network, Protocol Processor Blades and Chassis tables:

  - Infrastructure Up/Down

  - Infrastructure Performance Fault

  - Network Connectivity Fault

- For the Circuit Overview Table:

  - Up/Down Fault

  - Performance Fault

  - Network Connectivity Fault

### Fixes

#### Verizon iDirect Evolution Platform Collector: Actual Data Rate for Hub Return Carriers Table averaged incorrectly [ID_38074]

Because of a problem with the way the Actual Data Rate for Hub Return Carriers Table was averaged, it could occur that the aggregated value in the Hub Return Overview Table was not correct.

#### Kafka Consumer RTE [ID_38076]

In case there were issues with the Kafka calls, the Kafka consumer could generate RTEs. To prevent this, the logic for the consume loop has been adjusted so that it now runs until the token expires. This means that there are now two ways the consume loop can terminate: when a token expires or when the loop naturally exits.

#### Skyline Universal Weather: Communication with other elements failing [ID_38431]

Because of inconsistencies in the versions of the used NuGet packages, it could occur that InterApp communication between elements using the Skyline Universal Weather connector and other elements failed.

#### Generic Kafka Consumer: Required DLLs not deployed during connector installation [ID_38474]

Up to now, when the Generic Kafka Consumer connector was installed, some DLLs were missing, which meant manual work was required to get the Kafka stream to work as intended.

#### Verizon iDirect Evolution Platform Collector: Polling failure during alarm flood [ID_38579]

If many alarms happened at the same time, it could occur that the Verizon iDirect Evolution Platform Collector connector failed to poll properly. This was caused by ​RTE prevention logic and cancellation token logic, which has now been removed to prevent this issue.
