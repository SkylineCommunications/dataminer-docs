---
uid: Checking_SLA_Key_Performance_Indicators
---

# Checking SLA Key Performance Indicators

To check the key performance indicators for the SLA, check the section *Performance Indicators* on the *Main View* page of the SLA element. There you will find the following information:

- **Availability**: The availability of the service in the current window.

- **Predicted Availability**: The predicted availability, taking into account current and past outages.

  > [!NOTE]
  > From version 3.0.0 of the *Skyline SLA Definition Basic* protocol onwards, the *Predicted Availability* has been moved to the *Predictions* page of the SLA. However, note that predictions will only work if, on the *Advanced Configuration* page of the SLA, *Outages* and *Predictions* have been set to *Enabled*. These settings can only be modified by users with at least security level 3.

- **Total Violation Time**: The total duration of all violations that occurred in this window.

- **Longest Violation Time**: The duration of the longest violation that occurred in this window.

- **Number of Violations**: The total number of violations that occurred in this window.

- **Number of Affecting Alarms**: Available when using at least version 3.0.0.10 of the *Skyline SLA Definition Basic* protocol. Indicates the number of alarms currently affecting the SLA, as determined by the *Affecting Alarms Level* setting on the *Advanced Configuration* page. See [Advanced SLA alarm configuration](xref:Configuring_the_alarm_settings_for_an_SLA#advanced-sla-alarm-configuration).

- **Availability Without Correction**: The availability of the service in the current window, without taking in account any corrections that were made.

  > [!NOTE]
  > For more information on how to make corrections on outages, see [Correcting an outage in the outage list](xref:Correcting_an_outage_in_the_outage_list).

- **Total Outage Time**: The actual total duration of all alarms that occurred in this window, without corrections.

- **Longest Outage Time**: The actual total duration of the longest alarm that occurred in this window, without corrections.

> [!NOTE]
> In earlier versions of the SLA protocol, the naming of some parameters may be different, e.g., *Total Affected Time* instead of *Total Outage Time*.
