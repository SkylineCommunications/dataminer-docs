---
uid: Viewing_a_list_of_outages
---

# Viewing a list of outages

One or more alarms that potentially affect the SLA at a particular time are grouped in an outage. To view a list of outages, go to the *Outage list* page of the SLA element. The following information is indicated for each outage:

- **Adm. State**: Shows whether the SLA was tracking or not at the time when the outage occurred.

- **Current window**: Shows whether the outage occurred in the current window or not.

- **Outage impact**: The impact of the outage, taking in account the violation filters and offline window configuration.

- **Begin Timestamp** and **End Timestamp**: Show when the outage occurred.

- **Outage**: Shows the duration of the outage.

- **Outage Corrected**: Shows the duration of the outage with corrections applied.

- **Violation**: Shows the duration of the violation, taking into account the SLA settings (e.g. violation filter settings).

- **Correction** and **Motivation**: Show a possible correction on the outage, and its motivation.

    > [!NOTE]
    >
    > - For more information on how to make corrections on outages, see [Making corrections to existing outages](xref:Making_corrections_to_existing_outages).
    > - If there is currently an outage, but a delay time is applicable, the outage impact is not yet set to 0%. This is only done afterwards, once the outage is closed, if the outage is in fact shorter than the delay time.
    > - Timeout alarms are only registered by SLAs from DataMiner 9.5.5 onwards. By default, they have 0% impact, but this can be modified using violation filters.
