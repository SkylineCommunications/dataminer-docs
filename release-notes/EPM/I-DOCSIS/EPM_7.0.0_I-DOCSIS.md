---
uid: EPM_7.0.0_I-DOCSIS
---

# EPM 7.0.0 I-DOCSIS

## New features

#### Separate procedures for adding a single CCAP/CM pair and creating elements in bulk [ID 38518]

In DataMiner Cube, the interactive automation script *epm_i_docsis_addnewccapcmpair* now includes the *Create Bulk* and *Create Single* options, to either create a single CCAP/CM pair, or create elements in bulk from a CSV file. Additionally, the *Create Single* procedure now includes a step for entering both the get community string and set community string for the collector.

#### Skyline EPM Platform: Creating multiple threshold tables for CCAP and CM collectors streamlined [ID 38741]

To streamline the process of creating multiple threshold tables for CCAP and CM collectors, the possibility to create multiple sets directly from the Upstream and Downstream tables within the platform has been added.

For this purpose, a new script has also been added, which copies the table from the front-end *Thresholds Settings* page and applies it across active CCAP and CM collectors: *EPM_I_DOCSIS_SetThresholdsTableToCollectors*. These pages can be accessed via the *Configuration* page or *Threshold Settings* page.

## Changes

### Enhancements

#### CISCO CBR-8 CCAP Platform: Toggle button to enable/disable polling of OFDM/OFDMA tables [ID 36635]

In some cases, it can occur that CCAP elements using the Cisco CBR-8 CCAP Platform are not able to retrieve IDs when polling the OFDM/OFDMA tables, and DataMiner interprets this as a timeout.

As such, it is now possible to enable or disable the polling of these tables with a new toggle button on the *Configuration* page, so that you can prevent such timeouts.

#### Only active channels associated with cable modem shown [ID 37376]

When you view all channels associated with a cable modem, now only the active channels will be shown instead of all potentially available channels. This will make it easier to focus on the relevant cable modem KPIs.

#### Visual pages now include parent shapes for enhanced network topology [ID 37592]

Alignment errors on the Visual pages for Port, Distribution, and FAT (Forwarding Access Terminal) pages have been corrected. These Visual pages now include parent shapes, making it possible to identify the hub and the Optical Line Terminal (OLT) associated with each entity.

> [!NOTE]
> This change is related to the EPM xPON Solution because of shared components across solutions.

#### Visual enhancements to EPM entity tables [ID 37776]

The column order for the EPM entity tables in the *Below this view* section has been adjusted to align with the column format of the *Data* section for that same entity.

#### Improved performance when navigating to EPM cards through Topology app [ID 38194]

Performance has improved when you navigate to EPM cards through the Topology app. The Visual pages will now load faster and KPIs will no longer appear one at a time.

#### Generic DOCSIS CM Collector now supports both comma and period as decimal separator [ID 38195]

The Generic DOCSIS CM Collector connector can now parse numeric values regardless of whether a comma or period is used as decimal separator (invariant culture).

#### Generic DOCSIS CM Collector: Improved calculation method for FEC values [ID 38196]

The calculation method for Forward Error Correction (FEC) values in the Generic CM Collector has been enhanced. Previously, FEC values were calculated using averages of channel instances, leading to potential discrepancies, particularly in scenarios where Uncorrectable Packet Ratio (UER) was high while the Corrected Packet Ratio (CER) showed as zero. Now, instead of relying on averages, the system aggregates all counters to accurately determine the ratio.

#### Huawei 5688-5800 CCAP Platform connector now aligns CCAP name with element name [ID 38197]

​The Huawei 5688-5800 CCAP Platform connector previously used a custom system name for its EPM CCAP name, which could cause mapping issues when retrieving element data. Now, the connector uses the element name as the CCAP name, resolving problems in Visio when looking up element-specific data.

#### Skyline EPM Platform: DOCSIS 3.1 OFDM/OFDMA integration [ID 38198]

DOCSIS 3.1 polling support is available, displaying all instances of OFDM/OFDMA channels from both the CCAP and CM perspectives. At both Node Segment and Service Group levels, you can now view all associated 3.1 channels and corresponding KPIs using the *OFDM channels* dashboard and *OFDMA channels* dashboard. You can also view all instances of CM 3.1 channels using the *CM OFDM channels* dashboard and *CM OFDMA channels* dashboard.

#### Skyline EPM Platform: Maps now use relational filtering [ID 38199]

Maps now employ relational filtering to identify all available map entities. This ensures a precise alignment with the data presented on the EPM card, enhancing data reliability.

#### Improved OOS reporting: Define thresholds per channel [ID 38425]

Improvements have been made to *Out of Spec (OOS)* reporting by allowing different thresholds for the Rx Power Status, SNR Status, and Post-FEC Status parameters for the US QAM and DS QAM channel modulations. Previously, one threshold was used globally across all channels. Now, thresholds vary depending on the modulation of the associated cable modem (CM) channel. Parameters that used to have fixed thresholds have been replaced with a new table containing the different modulations along with their corresponding thresholds.

#### Conditional coloring added to dashboard tables [ID 38565]

Conditional coloring has now been implemented across all *CM Overview* and *CM Offline Overview* dashboards. A green color indicates an *OK* parameter status, while a red color indicates an *Out of Spec (OOS)* parameter status.

#### Cisco CBR-8 CCAP Platform: New OID for fiber node to channel mapping [ID 38765]

A new OID has been introduced for mapping fiber nodes to channels. This enhancement results in a more accurate and efficient representation of all available channels in the system.

#### Cisco CBR-8 CCAP Platform: Improved Physical Channel instances allocation [ID 38766]

The allocation of Physical Channel instances has been improved to accurately represent all node segments and calculate the KPIs.

#### Enhancements to EPM_I_DOCSIS_AddNewCcapCmPair script [ID 38850]

Several changes have been made to the existing *EPM_I_DOCSIS_AddNewCcapCmPair* script, used to create a CCAP/CM pair from the EPM UI:

- The script will check for existing custom properties. If they are absent, they will be automatically created.
- The script will restart both elements (CCAP and Collector) once the properties/parameters have been set.
- When creating the element, issues with the port 161 could occur, preventing the pulling of information. This issue has now been resolved.

### Fixes

#### Cisco CBR-8 CCAP Platform: Timeouts caused by use PartialSNMP option [ID 36609]

Because the *PartialSNMP* option was used together with the MultipleGetBulk method for a device with a packet limit, timeouts could occur in Cisco CBR-8 CCAP Platform elements. This option has now been removed to prevent this.

#### Visual enhancements to CCAP overview pages [ID 37636]

KPI value boxes have been expanded on the CCAP overview pages to prevent overlap between KPI labels and values.

#### Generic DOCSIS CM Collector: Incorrect displayed count for Number CM DOCSIS 1.x parameter [ID 37768]

It could occur that aggregation actions to retrieve the value of the DOCSIS 1.x counter parameter were not executed correctly. This could cause the actual count of cable modems reporting a DOCSIS version within the 1.x range to deviate from the displayed count. To prevent this, the parameter ID on the action has been adjusted to accurately reflect the parameter required for fetching the correct count.

#### Percentage Utilization value above 100% [ID 38410]

It could occur that values above 100% were shown for the utilization percentage in *DOCSIS US Ports* tables. This problem has been resolved to ensure that utilization percentage values now consistently range between 0% and 100%.

#### Minimum threshold incorrectly set higher than maximum threshold [ID 38534]

When adjusting values in the threshold table, it could occur that the minimum threshold was set higher than the maximum. To prevent this, a validation action was added, which automatically runs to check if the minimum threshold is lower than the maximum whenever a threshold value is adjusted.

#### Customer configurations showed duplicate entries [ID 38558]

With only Fiber Node channel instances available, duplicate entries could occur in specific customer configurations. To prevent this, new sets of channels have been introduced, linked to the physical representation of interfaces within the CMTSs. With this enhancement, when viewing the channels associated with a node segment, only the physical channels will be displayed, accompanied by their respective KPIs calculated at that level.

#### Firefox browser removed quotation marks from links generated by Microsoft Visio [ID 38651]

The Firefox browser removed quotation marks from links generated by Microsoft Visio, causing display issues when opening Firefox through Citrix. This affected the viewing of dashboards when clicking a dashboard link in Cube. To resolve this issue, enhancements have been made to ensure proper dashboard viewing when loading Cube within the Citrix application.

#### CCAP platforms: Visio lacked 'Entity Import' section [ID 38740]

The CCAP platform connectors have been adjusted so that an *Entity Import* section is now available for Visio, which allows the customer to set the correct path for importing EP files.

#### Percentage Ping Unreachable indicated value of 0% [ID 38768]

On the DS Line Card level, it could occur that the *Percentage Ping Unreachable* parameter incorrectly indicated a value of 0.00%. The percentage calculation has now been adjusted to prevent this.
