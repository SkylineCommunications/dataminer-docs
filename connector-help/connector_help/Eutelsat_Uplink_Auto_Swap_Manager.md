---
uid: Connector_help_Eutelsat_Uplink_Auto_Swap_Manager
---

# Eutelsat Uplink Auto Swap Manager

Management system for automatic swap of uplink sites

## About

The connector will monitor the uplink and downlink sites. Based on detected issues, the connector will decide if a swap of the uplink should be executed.

### Version Info

| **Range** | **Description** |
|------------------|-----------------|
| 1.0.0.x          | Initial version |

## Installation and configuration

### Creation

#### Virtual connection

This connector uses a virtual connection and does not need any user information.

### Configuration of Sites and Carriers

User can add/delete manually sites and carriers by right clicking on the **Sites** or **Carriers Config** table and choose the add/delete. Another option is to add predefined setups with the **Load Configuration** button.

### Configuration of Measurements

For each configured Site there are different parameters measured. In the Measurements table you will have an overview of all measured parameters. For each parameter you need to select the correct **Meas. Element** for the dropdown list. If the data is retrieved from a table, you also need to add the index into the **Meas. Index** column. Afterwards you need to click the subscribe button the activate the subscription on all configured elements. If the **Meas. Status** displays *Not Subscribed*, there's probably no element configured or we expect a **Meas. Index** but it's not configured (or vice versa).

Supported Protocols:

- Vertex DTR (Beacon Lvl)
- AppearTV General Platform (Rx Eb/No)
- Bridge Technologies VB220 (Tx BW)
- Newtec AZ210 (switch)
- Newtec 2185 (switch)

## Usage

### General page

The General page contains the **Carriers** table displaying extra info for each carrier. This table displays the current status for each carrier. You can find the different statuses used for the automatic swapping logic.

Status:

- **TXP_STATE_FINAL**: overwritten by **TXP_State User Defined** when **TXP_STATE_TMP** equals *TBC*
- **TXP_SWAP_POSSIBLE**: Defines if a swap is possible or not
- **TXP_SWAP**: Shows if a swap should be executed. Auto swapping can be overwritten by the **Maintenance** state or the **Swap Blocked.**

Swap:

- **SWAP**: This will start the manual swap if the switches are not offline.

Swap Info:

- **Swap Status**: extra info during swap
- **Swap Blocked**: to avoid toggling, the carrier will be blocked. Unblocking only possible by manual change.
- **Nominal**: transmission site configured as nominal (yes, no or unknown)

### Logging

Overview of all swap actions, the number of history rows can be configured in **Log Max Number**. If **Log Max Number** is configured to *Last Month*, all log entries older then 1 month are automatically cleared.

### Configuration page

This page contains all configurable data. More info about configuring the **Sites**, **Carries** and **Measurements** can be found below 'Installation and Configuration' of this connector help.

The **Enable Subscription** button defines if subscription should be enabled or not.

**Load Configuration** will initialize different sites and carriers based on a predefined setup. Setting this value to *Clear* will remove all sites and carriers.

**Stabilization time** defines the number of seconds we will wait after a swap before starting another swap on the same carrier.

**Carriers Config:**

- Activating the **Maintenance (Config)** mode will prevent the automatic swapping of the uplink sites.

- If the **Back to Nominal (Config)** is set to Window or Duration, the carrier will try to return towards it's nominal site. The nominal site is configured in the **Nominal Site (Config).**

- Window: **Start Hour (Config)** and **Duration (Config)** defines the window size for returning to nominal site.
  - Duration: **Duration (Config)** defines the time to wait after the last swap was executed before returning to nominal site.

Behind the **Elements** page button you can find all the supported elements from the DMS. This list is refreshed every hour, if necessary you can update the list manually by clicking the **Refresh** button.

## Notes

Custom Visio file is available.

If no data is retrieved at startup, you can check the **Element Overview** table (configuration \> Elements). If this table doesn't contain all needed elements, you can use the **Refresh** button. This will retrieve all elements and subscribe them if necessary.
