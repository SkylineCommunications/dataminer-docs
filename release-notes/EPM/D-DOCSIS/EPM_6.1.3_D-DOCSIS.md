---
uid: EPM_6.1.3_D-DOCSIS
---

# EPM 6.1.3 D-DOCSIS

## New features

#### New "# Connected Cores" KPI \[ID_33566\]

A new "# Connected Cores" KPI is now extracted based on the "# Cores" KPI on the RPD Details page of an RPD, by filtering out the cores where Status is not Active or Backup. The corresponding new parameter is available in the table on the RPD page for each collector.

#### Auto Offset and Maximum size options \[ID_33688\]

On the *Configuration* page, the following options are now also available:

- *Auto Offset*: Allows you to select whether to get the earliest or latest offset when subscribing to the Kafka topic if none has been assigned yet.
- *Maximum Size*: Determines the maximum size of exported files. Setting this limit can prevent system out of memory exceptions and RTEs.

## Changes

### Enhancements

#### Link to dashboard now filters displayed data \[ID_33359\]

When a link is clicked to view RPD data or node segment data in a dashboard, the dashboard is now filtered to show only the relevant data.

#### InterApp communication used instead of information events to communicate between elements \[ID_33374\]

InterApp communication is now used for the communication between the different elements used for EPM. Previously, information events were used, so now fewer information events will be generated. This will improve stability and decrease the amount of data that needs to be replicated across the cluster.

#### Controller system data retrieved from Smart PHY \[ID_33375\]

The controller system data are now retrieved from the Smart PHY endpoint instead of from the CCAP device itself. This will provide more reliable data and reduce the load and latency of the system.

#### Improved performance for CCAP WM topic requests \[ID_33377\]

Performance has improved for CCAP WM topic requests. This will improve memory utilization and ensure requests are handled more quickly so that the data are always up to date.

#### Default parameter feed index filters in dashboards \[ID_33397\]

In the CCAP and NCS overviews, default filters have been added to the parameter feed indexes of the temperatures component. This way, the displayed temperatures match the temperatures for which alarm monitoring and trending are activated in the DataMiner element.

#### Installed DPICs displayed in rear chassis image \[ID_33501\]

The rear chassis visual overview image can now display the correct number of installed DPICs. It will check the DPIC overview table for the installed DPICS and display these in the appropriate slot, with the correct interface speed monitoring.

#### Summary alarm link after navigation \[ID_33567\]

When you navigate to a specific level from the hub, you can now click the summary alarm to load the relevant alarms.

#### Improved RPD Details \[ID_33611\]

On the RPD Details page of the RPD visual overview, the "US QAM" label has been changed to "US ATDMA".

In addition, the calculations for Post-FEC, Rx Power, and SNR have been improved, so that the weight is now taken into account when these values are averaged.

#### Avg. Reflection Distance removed from visual overview \[ID_33636\]

The Avg. Reflection Distance value has been removed from the Service Group \[Fiber Node\] Overview page of the EPM Platform visual overview.

#### Improved mapping of CM US QAM channels \[ID_33673\]

The mapping of the CM US QAM channels has been adjusted to improve performance. This will also prevent possible run-time errors.

#### Configuration cache backup \[ID_33689\]

A cache backup feature was implemented in the EPM front end to prevent the potential loss of the configuration file containing the unique IDs in the system, which could in turn cause the loss of trend and alarm data.

#### RPD OFDM Profile Distribution now only targets 3.1 CMs \[ID_33690\]

The OFDM distribution graph on the RPD and Node Segment Overview pages of the topology app now only uses the 3.1 CMs associated with the entities to calculate the percentages. This means that if the CMs are configured correctly, they should add up to 100%. Additional bars have also been added for the OFDM CH2 profile distribution.

#### Improved alarm summary for EPM entities \[ID_33691\]

The alarm summary on the EPM entity overview pages now shows all alarms associated with the EPM object instead of just the view or element alarms. This will provide a more contextual summary of the alarms directly associated with the entities.

### Fixes

#### Utilization calculation issues \[ID_33395\]

In the Cox CBR-8 Platform D-DOCSIS, CISCO Manager CIN Platform, Juniper Networks Manager CIN Platform, and Cisco CBR-8 Platform D-DOCSIS connectors, the input, output, and total utilization could be calculated incorrectly. The used formula has been adjusted to resolve this issue. In addition, the calculation of the total utilization now takes both half-duplex and full-duplex interfaces into account.

#### Cox CBR-8 Platform D-DOCSIS: Incorrect Signal Noise values in US Channels table \[ID_33396\]

In the *Signal Noise* column of the US Channels table, values were displayed incorrectly because an excessive division by 10 was applied to the polled values.

#### Incorrect DS OFDM Partial Service Cable Modems number \[ID_33502\]

Up to now, OFDM cable modems with status "Not Supported" were also included in the DS OFDM Partial Service Cable Modems number.

#### Incorrect column order CM channel profiles \[ID_33564\]

The CM channel profiles in the CM Overview table were displayed in an incorrect order. The column order of the Preferred and Downgrade OFDM Profiles in the EPM CCAP Core level has now been switched, so that this matches the order of the element table.

#### RPD Node Leaf US/DS Utilization not displayed correctly \[ID_33565\]

The RPD Node Leaf US/DS Utilization parameters were not displayed correctly in Visual Overview.

#### Missing Controller and Controller Profile RPD details \[ID_33566\]

On the RPD Details page of an RPD, up to now no values could be displayed for the "Controller" and "Controller Profile" parameters. These values will now be displayed. In case there are multiple video service groups, these are now separated by a comma and space to improve readability.

#### Incorrect DS QAM SNR Status \[ID_33674\]

In some cases, it could occur that the DS QAM SNR Status values were not updated correctly for some CMs.
