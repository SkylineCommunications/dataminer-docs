---
uid: EPM_7.0.0_I-DOCSIS
---

# EPM 7.0.0 I-DOCSIS

## New features

## Changes

### Enhancements

#### CISCO CBR-8 CCAP Platform: Toggle button to enable/disable polling of OFDM/OFDMA tables [ID_36635]

In some cases, it can occur that the CCAP is not able to retrieve OIDs when polling the OFDM/OFDMA tables, and DataMiner interprets this as a timeout.

As such, it is now possible to enable or disable the polling of these tables with a new toggle button, so that you can prevent such timeouts.

#### Only active channels associated with cable modem shown [ID_37376]

When you view all channels associated with a cable modem, now only the active channels will be shown instead of all potentially available channels. This will make it easier to focus on the relevant cable modem KPIs.

#### Improved performance when navigating to EPM cards through Topology app [ID_38194]

Performance has improved when you navigate to EPM cards through the Topology app. The Visual pages will now load faster and KPIs will no longer appear one at a time.

#### Generic DOCSIS CM Collector now supports both comma and period as decimal separator [ID_38195]

The Generic DOCSIS CM Collector connector can now parse numeric values regardless of whether a comma or period is used as decimal separator.

### Fixes

#### Cisco CBR-8 CCAP Platform: Timeouts caused by use PartialSNMP option [ID_36609]

Because the *PartialSNMP* option was used together with the MultipleGetBulk method for a device with a packet limit, timeouts could occur in Cisco CBR-8 CCAP Platform elements. This option has now been removed to prevent this.
