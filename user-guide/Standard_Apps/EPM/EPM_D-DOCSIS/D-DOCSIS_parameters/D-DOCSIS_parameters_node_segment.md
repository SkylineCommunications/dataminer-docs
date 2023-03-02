---
uid: D-DOCSIS_parameters_node_segment
---

# D-DOCSIS parameters – Node Segment

This page contains an overview of the Node Segment parameters available in the D-DOCSIS branch of the EPM Solution.

## KPIs & KQIs

- **Number CM**: Calculated. The number of cable modems (CMs) the RPD is managing.

  Calculated by counting the number of CMs connected to the RPD.

- **Percentage CM Offline**: Calculated. The percentage of offline CMs linked to the RPD.

- **Percentage CM DS Partial Service**: Calculated. The percentage of CMs linked to the RPD that have CMs with DS partial service channels.

  Calculated based on the CMs with DS channels in the CM impaired table on the CCAP.

  - CM Impaired Table OID: 1.3.6.1.4.1.9.9.116.1.5.13.
  - DS Channel Index OID: 1.3.6.1.4.1.9.9.116.1.5.13.1.7.

- **Number CM DS Partial Service**: Calculated. The number of CMs linked to the RPD that have CMs with DS partial service channels.

  Calculated by counting the CMs with DS channels in the CM impaired table on the CCAP.

  - CM Impaired Table OID: 1.3.6.1.4.1.9.9.116.1.5.13.
  - DS Channel Index OID: 1.3.6.1.4.1.9.9.116.1.5.13.1.7.

- **Percentage CM US Partial Service**: Calculated. The percentage of CMs linked to the RPD that have CMs with US partial service channels.

  Calculated based on the CMs with US channels in the CM impaired table on the CCAP.

  - CM Impaired Table OID: 1.3.6.1.4.1.9.9.116.1.5.13.
  - US Channel Index OID: 1.3.6.1.4.1.9.9.116.1.5.13.1.8.

- **Number CM US Partial Service**: Calculated. The number of CMs linked to the RPD that have CMs with US partial service channels.

  Calculated by counting the CMs with US channels in the CM impaired table on the CCAP.

  - CM Impaired Table OID: 1.3.6.1.4.1.9.9.116.1.5.13.
  - US Channel Index OID: 1.3.6.1.4.1.9.9.116.1.5.13.1.8.

- **Percentage CM TX LVL OOS**: Calculated. The percentage of US ATDMA channels of CMs linked to the RPD that have the power status OOS.

  Calculated based on the CMs with US channels of type ATDMA in the CM upstream channels table with Rx power that is OOS.

  - CM Upstream Channels OID: 1.3.6.1.4.1.4491.2.1.20.1.4.
  - Rx Power OID: 1.3.6.1.4.1.4491.2.1.20.1.4.1.3.

- **Percentage CWERR OOS**: Calculated. The percentage of US ATDMA channels of CMs linked to the RPD with post-FEC OOS.

  Calculated based on the CMs with US channels of type ATDMA in the CM upstream channels table with post-FEC that is OOS.

  - CM Upstream Channels OID: 1.3.6.1.4.1.4491.2.1.20.1.4.
  - Rx Power OID: 1.3.6.1.4.1.4491.2.1.20.1.4.1.3.

- **Percentage SNR OOS**: Calculated. The percentage of US ATDMA channels of CMs linked to the RPD with signal noise OOS.

  Calculated based on the CMs with US channels of type ATDMA in the CM upstream channels table with SNR that is OOS.

  - CM Upstream Channels OID: 1.3.6.1.4.1.4491.2.1.20.1.4.
  - SNR OID: 1.3.6.1.4.1.4491.2.1.20.1.4.1.4.

- **Percentage Time Offset OOS**: Calculated. The percentage of US ATDMA channels of CMs linked to the RPD with high resolution timing offset OOS.

  Calculated based on the CMs with US channels of type ATDMA in the CM upstream channels table with high resolution timing offset that is OOS.

  - CM Upstream Channels OID: 1.3.6.1.4.1.4491.2.1.20.1.4.
  - SNR OID: 1.3.6.1.4.1.4491.2.1.20.1.4.1.10.

- **DS SCQAM Utilization**: Calculated. The average percentage of DS QAM utilization of CMs linked to the RPD.

  Calculated based on the DS QAM utilization of channels associated with CMs managed by the RPD.

- **US ATDMA Utilization**: Calculated. The average percentage of US QAM utilization of CMs linked to the RPD.

  Calculated based on the US QAM utilization of channels associated with CMs managed by the RPD.

- **OFDMA Utilization**: Calculated. The average percentage of US OFDM utilization of CMs linked to the RPD.

  Calculated based on the US OFDM utilization of channels associated with CMs managed by the RPD.

- **Number L2TPv3 Session in Error**: Calculated. The number of L2TPv3 sessions that are in error.

  Calculated by counting the number of sessions from RPD depi (retrieved with the call "show cable rpd depi") that do not have the remote state "UP".

- **Percentage L2TPv3 Session in Error**: Calculated. The percentage of L2TPv3 sessions that are in error.

  Calculated based on the sessions from RPD depi (retrieved with the call "show cable rpd depi") that do not have the remote state "UP".

- **Temperature**: The temperature of the RPD.

  Calculated by scaling the value from the RPD Sensors table.

  - RPD Sensors table OID: 1.3.6.1.4.1.4491.2.1.30.1.2.2.
  - Value column OID: 1.3.6.1.4.1.4491.2.1.30.1.2.2.1.4.

- **Destination IF In Utilization**: Calculated. The In (Upstream) Utilization of the external interface(s) connected to the RPD. This is the data that flows from the RPD up to a CIN device (i.e. Layer 2 Switch).

  Calculated by mapping the In utilization (calculated using the change in input octets) of the external interface(s) connected to the RPD.

  - Interface table OID: 1.3.6.1.2.1.2.2.
  - Interface in octets OID: 1.3.6.1.2.1.2.2.1.10.

- **Destination IF Out Utilization**: Calculated. The Out (Downstream) Utilization of the external interface(s) connected to the RPD. This is the data that flows from the CIN device (i.e. Layer 2 Switch) to the RPD interface(s).

  Calculated by mapping the Out utilization (calculated using the change in output octets) of the external interface(s) connected to the RPD.

  - Interface table OID: 1.3.6.1.2.1.2.2.
  - Interface out octets OID: 1.3.6.1.2.1.2.2.1.16.

- **Number CM OFDM CH 1 Profile 0**: Calculated. The number of CMs linked to the RPD with OFDM CH 1 Current Profile equal to the first profile available (i.e. 0).

- **Number CM OFDM CH 1 Profile 1**: Calculated. The number of CMs linked to the RPD with OFDM CH 1 Current Profile equal to the second profile available (i.e. 1).

- **Number CM OFDM CH 1 Profile 2**: Calculated. The number of CMs linked to the RPD with OFDM CH 1 Current Profile equal to the third profile available (i.e. 2).

- **Number CM OFDM CH 1 Profile 3**: Calculated. The number of CMs linked to the RPD with OFDM CH 1 Current Profile equal to the fourth profile available (i.e. 3).

- **Percentage CM OFDM CH 1 Profile 0**: Calculated. The percentage of CMs linked to the RPD with OFDM CH 1 Current Profile equal to the first profile available (i.e. 0).

- **Percentage CM OFDM CH 1 Profile 1**: Calculated. The percentage of CMs linked to the RPD with OFDM CH 1 Current Profile equal to the second profile available (i.e. 1).

- **Percentage CM OFDM CH 1 Profile 2**: Calculated. The percentage of CMs linked to the RPD with OFDM CH 1 Current Profile equal to the third profile available (i.e. 2).

- **Percentage CM OFDM CH 1 Profile 3**: Calculated. The percentage of CMs linked to the RPD with OFDM CH 1 Current Profile equal to the fourth profile available (i.e. 3).

- **Number CM OFDM CH 2 Profile 0**: Calculated. The number of CMs linked to the RPD with OFDM CH 2 Current Profile equal to the first profile available (i.e. 0).

- **Number CM OFDM CH 2 Profile 1**: Calculated. The number of CMs linked to the RPD with OFDM CH 2 Current Profile equal to the second profile available (i.e. 1).

- **Number CM OFDM CH 2 Profile 2**: Calculated. The number of CMs linked to the RPD with OFDM CH 2 Current Profile equal to the third profile available (i.e. 2).

- **Number CM OFDM CH 2 Profile 3**: Calculated. The number of CMs linked to the RPD with OFDM CH 2 Current Profile equal to the fourth profile available (i.e. 3).

- **Percentage CM OFDM CH 2 Profile 0**: Calculated. The percentage of CMs linked to the RPD with OFDM CH 2 Current Profile equal to the first profile available (i.e. 0).

- **Percentage CM OFDM CH 2 Profile 1**: Calculated. The percentage of CMs linked to the RPD with OFDM CH 2 Current Profile equal to the second profile available (i.e. 1).

- **Percentage CM OFDM CH 2 Profile 2**: Calculated. The percentage of CMs linked to the RPD with OFDM CH 2 Current Profile equal to the third profile available (i.e. 2).

- **Percentage CM OFDM CH 2 Profile 3**: Calculated. The percentage of CMs linked to the RPD with OFDM CH 2 Current Profile equal to the fourth profile available (i.e. 3).

- **Average OFDM CH 1 Utilization**: Calculated. The average channel 1 utilization for the RPD's CMs.

  Calculated by averaging the utilization (OID: 1.3.6.1.4.1.4491.2.1.28.1.19.1.20) for all CH 1 instances reported by the RPD's CMs.

- **Number MTA**: Calculated. The total number of Multimedia Terminal Adapters (MTAs) for the level.

- **Percentage MTA Offline**: Calculated. The percentage of offline Multimedia Terminal Adapters (MTAs) for the level.

- **Number DSG**: Calculated. The total number of set-top gateways (DSGs) for the level.

- **Percentage DSG Offline**: Calculated. The percentage of offline set-top gateways (DSGs) for the level.

- **Aux Status**: Calculated. The Aux Core RPD State for the first active auxiliary (non-principle) core.

  Calculated by retrieving the Aux Core RPD State value (OID: 1.3.6.1.4.1.4491.2.1.30.1.1.4.1.12, Table: RPD CCAP Cores) for the first active (core mode) auxiliary (non-principal) core and mapping it to the corresponding RPD.

- **\# 3.1 CM**: Calculated. The total number of CMs that are currently running DOCSIS 3.1.

  Calculated based on the base CLI call "show cable modem docsis device-class".

- **\# CM OFDM**: Calculated. The number of CMs using OFDM.

  Calculated by counting the number of CMs with OFDM Status equal to "Active".

- **Percentage CM OFDM**: Calculated. The percentage of CMs using OFDM.

  Calculated based on the CMs with OFDM Status equal to "Active".

- **Number CM OFDM Partial**: Calculated. The number of CMs using OFDM in a partial state.

  Calculated by counting the number of CMs actively using OFDM with DS Service Status equal to "Partial".

- **Percentage CM OFDM Partial**: Calculated. The percentage of CMs using OFDM in a partial state.

  Calculated based on the CMs actively using OFDM with DS Service Status equal to "Partial".

- **Number CM OFDM Profile Downgrade**: Calculated. The number of CMs that have downgraded to a lower OFDM profile for at least one channel.

  Calculated by counting the number of CMs with OFDM CH 1 Profile Status or OFDM CH 2 Profile Status equal to "Downgrade".

- **Percentage CM OFDM Profile Downgrade**: Calculated. The percentage of CMs that have downgraded to a lower OFDM profile for at least one channel.

  Calculated based on the CMs with OFDM CH 1 Profile Status or OFDM CH 2 Profile Status equal to "Downgrade".

- **Nearcast Video Interface**: Calculated. The Nearcast Video Interface, calculated by retrieving the core assignment using Smart PHY RPD data (call: v1/smartphycache/rpd/details/active/1) and mapping this to the RPD.

- **Nearcast Video Service Group**: Calculated. The Nearcast Video Service Group, calculated by retrieving the ports using Smart PHY RPD data (call: v1/smartphycache/rpd/details/active/1) and mapping this to the RPD.

- **Nearcast Video Controller**: Calculated. The Nearcast Video Controller, calculated by retrieving the templates using Smart PHY RPD data (call: v1/smartphycache/rpd/details/active/1) and mapping this to the RPD.

- **Nearcast Video DEPI**: Calculated. The Nearcast Video DEPI, calculated using the RPD cores interface to the Nearcast interface to retrieve the address.

- **Nearcast Video Controller Profile**: Calculated. The Nearcast Video Controller Profile, calculated by retrieving the templates using Smart PHY RPD data (call: v1/smartphycache/rpd/details/active/1) and mapping this to the RPD.

- **Broadcast Video Interface**: Calculated. The Broadcast Video Interface, calculated by retrieving the core assignment using Smart PHY RPD data (call: v1/smartphycache/rpd/details/active/1) and mapping this to the RPD.

- **Broadcast Video Service Group**: Calculated. The Broadcast Video Service Group, calculated by retrieving the ports using Smart PHY RPD data (call: v1/smartphycache/rpd/details/active/1) and mapping this to the RPD.

- **Broadcast Video Controller**: Calculated. The Broadcast Video Controller, calculated by retrieving the templates using Smart PHY RPD data (call: v1/smartphycache/rpd/details/active/1) and mapping this to the RPD.

- **Broadcast Video DEPI**: Calculated. The Broadcast Video DEPI, calculated using the RPD cores interface to the Broadcast interface to retrieve the address.

- **Broadcast Video Controller Profile**: Calculated. The Broadcast Video Controller Profile, calculated by retrieving the templates using Smart PHY RPD data (call: v1/smartphycache/rpd/details/active/1) and mapping this to the RPD.

- **US AVG Post-FEC**: Calculated. The average of the US AVG Post-FEC for all associated CMs.

- **US Number Partial Service**: Calculated. The percentage of CMs linked to the RPD that have CMs with US partial service channels.

  Calculated based on the CMs with US channels in the CM impaired table on the CCAP (OID 1.3.6.1.4.1.9.9.116.1.5.13.1.2).

- **US Percent Partial Service**: Calculated. The number of CMs linked to the RPD that have CMs with US partial service channels.

  Calculated by counting the CMs with US channels in the CM impaired table on the CCAP (OID 1.3.6.1.4.1.9.9.116.1.5.13.1.2).

- **US AVG Power**: Calculated. The average of the US AVG Power for all associated CMs.

- **US AVG SNR**: Calculated. The average of the US AVG SNR for all associated CMs.

- **Out of Band Interface**: Calculated. The Out of Band Interface, calculated by retrieving the cores using Smart PHY RPD data (call: v1/smartphycache/rpd/details/active/1) and mapping this to the RPD.

- **Number Cores**: Calculated. The number of cores, including remote, associated with the RPD.

  This value is obtained by counting unique Core MAC associations from the RPD CCAP Cores table (MIB OID: 1.3.6.1.4.1.4491.2.1.30.1.1.4.1.12) and the RPD RPM Cores table (Vecima RPM Apigee: rpd/mac-address;rpd/ccap-cores/ccap-core/state).

- **US ICFR AVG**: Calculated. Total number of ICFR from US channels associated with the CMs connected to the node, divided by the total number of channels.

  Acquired from the "cmIcfr" metric name in the "UpstreamScQamChannelInfo" metric group from the Kafka topic.

- **US ICFR OOS Count**: Calculated. Total number of CMs where a US channel's ICFR metric breaches the OOS threshold.

  Acquired from the "cmIcfr" metric name in the "UpstreamScQamChannelInfo" metric group from the Kafka topic.

- **US ICFR OOS Percentage**: Calculated. Percentage of CMs connected to the node that breached the ICFR OOS threshold.

  Acquired from the "cmIcfr" metric name in the "UpstreamScQamChannelInfo" metric group from the Kafka topic.

- **US Ripples OOS AVG**: Calculated. Total number of ripples from US channels associated with the CMs connected to the node, divided by the total number of channels.

  Acquired from the"ripples" metric name in the "UpstreamScQamChannelInfo" metric group from the Kafka topic.

- **US Ripples OOS Count**: Calculated. Total number of CMs where a US channel's ripples metric breaches the OOS threshold.

  Acquired from the"ripples" metric name in the "UpstreamScQamChannelInfo" metric group from the Kafka topic.

- **US Ripples OOS Percentage**: Calculated. Percentage of CMs connected to the node that breached the Ripples OOS threshold.

  Acquired from the"ripples" metric name in the "UpstreamScQamChannelInfo" metric group from the Kafka topic.

- **US TX Power AVG**: Calculated. Total TX power from US channels associated with the CMs connected to the node, divided by the total number of channels.

  Acquired from the"txPower" metric name in the "UpstreamScQamChannelInfo" metric group from the Kafka topic.

- **US TX Power OOS Count**: Calculated. Total number of CMs where a US channel's TX power metric breaches the OOS threshold.

  Acquired from the"txPower" metric name in the "UpstreamScQamChannelInfo" metric group from the Kafka topic.

- **US TX Power OOS Percentage**: Calculated. Percentage of CMs connected to the node that breached the TX Power OOS threshold.

  Acquired from the"txPower" metric name in the "UpstreamScQamChannelInfo" metric group from the Kafka topic.

- **US T3 24 Hour AVG**: Calculated. Total number of T3 timeouts in the last 24 hours from US channels associated with the CMs connected to the node, divided by the total number of channels.

  Acquired from the"t3" metric name in the "UpstreamScQamChannelInfo" metric group from the Kafka topic.

- **US T3 24 Hour OOS Count**: Calculated. Total number of CMs where a US channel's T3 timeouts in the last 24 hours metric breaches the OOS threshold.

  Acquired from the"t3" metric name in the "UpstreamScQamChannelInfo" metric group from the Kafka topic.

- **US T3 24 Hour OOS Percentage**: Calculated. Percentage of CMs connected to the node that breached the T3 timeouts in the last 24 hours OOS threshold.

  Acquired from the"t3" metric name in the "UpstreamScQamChannelInfo" metric group from the Kafka topic.

- **US T4 24 Hour AVG**: Calculated. Total number of T4 timeouts in the last 24 hours from US channels associated with the CMs connected to the node, divided by the total number of channels.

  Acquired from the"t4" metric name in the "UpstreamScQamChannelInfo" metric group from the Kafka topic.

- **US T4 24 Hour OOS Count**: Calculated. Total number of CMs where a US channel's T4 timeouts in the last 24 hours metric breaches the OOS threshold.

  Acquired from the"t4" metric name in the "UpstreamScQamChannelInfo" metric group from the Kafka topic.

- **US T4 24 Hour OOS Percentage**: Calculated. Percentage of CMs connected to the node that breached the T4 timeouts in the last 24 hours OOS threshold.

  Acquired from the"t4" metric name in the "UpstreamScQamChannelInfo" metric group from the Kafka topic.

- **DS RX AVG**: Calculated. Total RX power from DS channels associated with the CMs connected to the node, divided by the total number of channels.

  Acquired from the"rxPower" metric name in the "downstreamScQamChannels" metric group from the Kafka topic.

- **DS RX Minimum**: Calculated. Minimum RX power from DS channels associated with the CMs connected to the node.

  Acquired from the"rxPower" metric name in the "downstreamScQamChannels" metric group from the Kafka topic.

- **DS RX Maximum**: Calculated. Maximum RX power from DS channels associated with the CMs connected to the node.

  Acquired from the"rxPower" metric name in the "downstreamScQamChannels" metric group from the Kafka topic.

- **DS SNR AVG**: Calculated. Total SNR power from DS channels associated with the CMs connected to the node, divided by the total number of channels.

  Acquired from the"snr" metric name in the "downstreamScQamChannels" metric group from the Kafka topic.

- **DS SNR Minimum**: Calculated. Minimum SNR power from DS channels associated with the CMs connected to the node.

  Acquired from the"snr" metric name in the "downstreamScQamChannels" metric group from the Kafka topic.

- **DS SNR Maximum Total**: Calculated. Maximum SNR power from DS channels associated with the CMs connected to the node.

  Acquired from the"snr" metric name in the "downstreamScQamChannels" metric group from the Kafka topic.

- **DS Post-FEC 24 Hour AVG**: Calculated. Total uncorrectable packets in 24 hours from DS channels associated with the CMs connected to the node, divided by the total number of packets in 24 hours from the channels.

  Acquired from the"unerroreds", "correcteds", and "uncorrectables" metric names in the "downstreamScQamChannels" metric group from the Kafka topic.

- **DS Post-FEC 24 Hour OOS Count**: Calculated. Total number of CMs where a DS channel's Post-FEC in the last 24 hours metric breaches the OOS threshold.

  Acquired from the"unerroreds", "correcteds", and "uncorrectables" metric names in the "downstreamScQamChannels" metric group from the Kafka topic.

- **DS Post-FEC 24 Hour OOS Percentage**: Calculated. Percentage of CMs where a DS channel's Post-FEC in the last 24 hours metric breaches the OOS threshold.

  Acquired from the"unerroreds", "correcteds", and "uncorrectables" metric names in the "downstreamScQamChannels" metric group from the Kafka topic.

- **OFDMA Post-FEC 24 Hour AVG**: Calculated. Total uncorrectable packets in 24 hours from OFDMA channels associated with the CMs connected to the node, divided by the total number of packets in 24 hours from the channels.

  Acquired from the"totalCodeWords" and "unreliable" metric names in the "UpstreamOfdmaChannelInfo" metric group from the Kafka topic.

- **OFDMA Post-FEC 24 Hour OOS Count**: Calculated. Total number of CMs where an OFDMA channel's Post-FEC in the last 24 hours metric breaches the OOS threshold.

  Acquired from the"totalCodeWords" and "unreliable" metric names in the "UpstreamOfdmaChannelInfo" metric group from the Kafka topic.

- **OFDMA Post-FEC 24 Hour OOS Percentage**: Calculated. Percentage number of CMs where an OFDMA channel's Post-FEC in the last 24 hours metric breaches the OOS threshold.

  Acquired from the"totalCodeWords" and "unreliable" metric names in the "UpstreamOfdmaChannelInfo" metric group from the Kafka topic.

- **OFDMA TX Level AVG**: Calculated. Total TX power from OFDMA channels associated with the CMs connected to the node, divided by the total number of channels.

  Acquired from the"txPower" metric name in the "UpstreamOfdmaChannelInfo" metric group from the Kafka topic.

- **OFDMA TX Level OOS Count**: Calculated. Total number of CMs where an OFDMA channel's TX power metric breaches the OOS threshold.

  Acquired from the"txPower" metric name in the "UpstreamOfdmaChannelInfo" metric group from the Kafka topic.

- **OFDMA TX Level OOS Percentage**: Calculated. Percentage of CMs connected to the node that breached the TX Power OOS threshold.

  Acquired from the"txPower" metric name in the "UpstreamOfdmaChannelInfo" metric group from the Kafka topic.

- **OFDMA MER AVG**: Calculated. Total MER power from OFDMA channels associated with the CMs connected to the node, divided by the total number of channels.

  Acquired from the"rxPower" metric name in the "UpstreamOfdmaChannelInfo" metric group from the Kafka topic.

- **OFDMA MER OOS Count**: Calculated. Total number of CMs where an OFDMA channel's MER power metric breaches the OOS threshold.

  Acquired from the"rxPower" metric name in the "UpstreamOfdmaChannelInfo" metric group from the Kafka topic.

- **OFDMA MER OOS Percentage**: Calculated. Percentage of CMs connected to the node that breached the MER Power OOS threshold.

  Acquired from the"rxPower" metric name in the "UpstreamOfdmaChannelInfo" metric group from the Kafka topic.

- **OFDMA T3 24 Hour AVG**: Calculated. Total number of T3 timeouts in the last 24 hours from OFDMA channels associated with the CMs connected to the node, divided by the total number of channels.

  Acquired from the"t3TimeoutsUpTm" metric name in the "UpstreamOfdmaChannelInfo" metric group from the Kafka topic.

- **OFDMA T3 24 Hour OOS Count**: Calculated. Total number of CMs where an OFDMA channel's T3 timeouts in the last 24 hours metric breaches the OOS threshold.

  Acquired from the"t3TimeoutsUpTm" metric name in the "UpstreamOfdmaChannelInfo" metric group from the Kafka topic.

- **OFDMA T3 24 Hour OOS Percentage**: Calculated. Percentage of CMs connected to the node that breached the T3 timeouts in the last 24 hours OOS threshold.

  Acquired from the"t3TimeoutsUpTm" metric name in the "UpstreamOfdmaChannelInfo" metric group from the Kafka topic.

- **OFDMA T4 24 Hour AVG**: Calculated. Total number of T4 timeouts in the last 24 hours from OFDMA channels associated with the CMs connected to the node, divided by the total number of channels.

  Acquired from the"t4TimeoutsUpTm" metric name in the "UpstreamOfdmaChannelInfo" metric group from the Kafka topic.

- **OFDMA T4 24 Hour OOS Count**: Calculated. Total number of CMs where an OFDMA channel's T4 timeouts in the last 24 hours metric breaches the OOS threshold.

  Acquired from the"t4TimeoutsUpTm" metric name in the "UpstreamOfdmaChannelInfo" metric group from the Kafka topic.

- **OFDMA T4 24 Hour OOS Percentage**: Calculated. Percentage of CMs connected to the node that breached the T4 timeouts in the last 24 hours OOS threshold.

  Acquired from the"t4TimeoutsUpTm" metric name in the "UpstreamOfdmaChannelInfo" metric group from the Kafka topic.

- **OFDM Post-FEC 24 Hour AVG**: Calculated. Total uncorrectable packets in 24 hours from OFDM channels associated with the CMs connected to the node, divided by the total number of packets in 24 hours from the channels.

  Acquired from the"totalCodeWords" and "uncorrectables" metric names in the "downstreamOfdmChannels" metric group from the Kafka topic.

- **OFDM Post-FEC 24 Hour OOS Count**: Calculated. Total number of CMs where an OFDM channel's Post-FEC in the last 24 hours metric breaches the OOS threshold.

  Acquired from the"totalCodeWords" and "uncorrectables" metric names in the "downstreamOfdmChannels" metric group from the Kafka topic.

- **OFDM Post-FEC 24 Hour OOS Percentage**: Calculated. Percentage number of CMs where an OFDM channel's Post-FEC in the last 24 hours metric breaches the OOS threshold.

  Acquired from the"totalCodeWords" and "uncorrectables" metric names in the "downstreamOfdmChannels" metric group from the Kafka topic.

- **OFDM RX Level AVG**: Calculated. Total RX power from OFDM channels associated with the CMs connected to the node, divided by the total number of channels.

  Acquired from the"rxPowerLevelAvg" metric name in the "downstreamOfdmChannels" metric group from the Kafka topic.

- **OFDM RX Level OOS Count**: Calculated. Total number of CMs where an OFDM channel's RX power metric breaches the OOS threshold.

  Acquired from the"rxPowerLevelAvg" metric name in the "downstreamOfdmChannels" metric group from the Kafka topic.

- **OFDM RX Level OOS Percentage**: Calculated. Percentage of CMs connected to the node that breached the RX Power OOS threshold.

  Acquired from the"rxPowerLevelAvg" metric name in the "downstreamOfdmChannels" metric group from the Kafka topic.

- **OFDM MER AVG**: Calculated. Total MER power from OFDM channels associated with the CMs connected to the node, divided by the total number of channels.

  Acquired from the"subcarrierMerAvg" metric name in the "downstreamOfdmChannels" metric group from the Kafka topic.

- **OFDM MER OOS Count**: Calculated. Total number of CMs where an OFDM channel's MER power metric breaches the OOS threshold.

  Acquired from the"subcarrierMerAvg" metric name in the "downstreamOfdmChannels" metric group from the Kafka topic.

- **OFDM MER OOS Percentage**: Calculated. Percentage of CMs connected to the node that breached the MER Power OOS threshold.

  Acquired from the"subcarrierMerAvg" metric name in the "downstreamOfdmChannels" metric group from the Kafka topic.

## System parameters

- **Name**: Direct value. The RPD name.

  SNMP OID: 1.3.6.1.4.1.4491.2.1.30.1.1.2.1.5.

- **Uptime**: Direct value. The RPD uptime.

  SNMP OID: 1.3.6.1.4.1.4491.2.1.30.1.1.1.1.2.

- **Device Type**: Direct value. The RPD type.

  SNMP OID: 1.3.6.1.4.1.4491.2.1.30.1.1.2.1.6.

- **Vendor**: Direct value. The RPD vendor.

  SNMP OID: 1.3.6.1.4.1.4491.2.1.30.1.1.2.1.1.

- **Serial Number**: Direct value. The RPD serial number.

  SNMP OID: 1.3.6.1.4.1.4491.2.1.30.1.1.2.1.4.

- **Model**: Direct value. The RPD model.

  SNMP OID: 1.3.6.1.4.1.4491.2.1.30.1.1.2.1.3.

- **Software Version**: Direct value. The RPD software version.

  SNMP OID: 1.3.6.1.4.1.4491.2.1.30.1.1.2.1.8.

- **IP**: Converted. The RPD IPv6 address.

  Extracted from RPD IP table index (OID 1.3.6.1.4.1.4491.2.1.30.1.3.6.1.1).

- **City**: Direct value. The city of the RPD location.

  Retrieved from the custom property *Location City*.

- **Site**: Direct value. The site of the RPD location.

  Retrieved from the custom property *Location Site*.

- **Service Template**: Direct value. The RPD service template.

  Retrieved using the Smart PHY API (call: v1/smartphycache/rpd/details/active/1).

- **Status**: Direct value. The RPD status.

  Retrieved using the Smart PHY API (call: v1/smartphycache/rpd/details/active/1).

- **Sensors**: Direct value. The RPD Sensors table.

  SNMP OID: 1.3.6.1.4.1.4491.2.1.30.1.2.2.

- **Interfaces**: Direct value. The RPD Interfaces table.

  SNMP OID: 1.3.6.1.4.1.4491.2.1.30.1.2.4.

- **Sessions**: Direct value. The RPD DEPI sessions table.

  Retrieved using the call "show cable rpd depi".

- **RPD Tunnel Summary**: Direct value. The RPD Sessions Tunnel summary.

  Retrieved from the RPD Tunnel Summary table from CLI (call: show cable rpd depi).

- **Latitude**: Direct value. The RPD latitude.

  Retrieved using the Smart PHY API (call: v1/smartphycache/rpd/details/active/1).

- **Longitude**: Direct value. The RPD longitude.

  Retrieved using the Smart PHY API (call: v1/smartphycache/rpd/details/active/1).

- **Remote Cores Connected**: Direct value. The remote cores connected to the RPD.

  Retrieved from the Vecima Apigee API (call:/rpm/V1/restconf/data/entra/r-phy/rpds?fields=rpd/mac-address;rpd/ccap-cores/ccap-core/state) and Ceeview (call: /rpds/1/details Query: Rpm = "fields=mac-address;state;ccap-cores/ccap-core/state", Ceeview = "glassCore,modelNumber,vendorName,deviceAlias,connectedCores,isConnected,bootTime,bootTimeUTC,uptime,disConnectedAt,connectedAt,glassCoreMAC,rpdEndpoint").

- **Cores Connected**: Direct value. The cores connected to the RPD.

  These are the RPD CCAP Core rows from the RPD CCAP Cores table (OID: 1.3.6.1.4.1.4491.2.1.30.1.1.4).

- **US Channels**: Direct value. The RPD's upstream channels.

  Retrieved by filtering the Upstream Channels table (1.3.6.1.4.1.4491.2.1.20.1.4) to the RPD.

- **MLD**: Information on the Multicast Listener Discovery (MLD) Neighbors.

  Retrieved using the call "show mld group | no-more".
