---
uid: How_SLA_monitoring_works
description: "Learn how DataMiner Business Intelligence turns service alarms into SLA results, with table visibility and availability examples."
---

# How SLA monitoring works

DataMiner Business Intelligence monitors Service Level Agreement (SLA) compliance for a DataMiner service. An SLA element links the monitored service to an SLA definition. Usually, this is the *Skyline SLA Definition Basic* SLA definition.

The monitored service supplies alarm information. DataMiner Core determines how those alarms affect the SLA and calculates outage, availability, and compliance information. The SLA protocol provides the configuration parameters, tables, display pages, and supporting actions.

> [!NOTE]
> This page describes SLA monitoring with the 3.x range of the Skyline SLA Definition Basic protocol. Available settings and page names depend on the protocol version.

## From service alarms to compliance

An alarm is an input to the SLA calculation, not automatically a full service outage.

The alarm's impact depends on the SLA configuration, including its violation level, violation filters, validity and offline windows, and inclusion settings. Service capping can also affect the severity used by the SLA when that option is enabled.

The SLA uses the resulting alarm impacts to maintain outage intervals and calculate violations within its monitoring window. An outage does not necessarily mean that the SLA has been breached: compliance also depends on the configured limits for violation duration and number of violations.

For the configuration procedures, see [Configuring the alarm settings for an SLA](xref:Configuring_the_alarm_settings_for_an_SLA) and [Checking the SLA compliance](xref:Checking_the_SLA_compliance).

## SLA tables in Skyline SLA Definition Basic

Different tables are used for alarms, outages, configuration, and historical information. Some are displayed on standard element pages, while others support internal calculations.

The following table summarizes visibility on the standard element card. Display settings can also control whether active alarms are shown.

| Table (parameter ID) | Purpose | Shown on the element card |
|---|---|---|
| Outage List (37) | Recorded outage intervals and their details | Yes, on *Outage List* |
| Active Service Alarms (250) | Current alarms and their SLA impact | Yes, on *Active Service Alarms* |
| Offline Windows (400) | Offline-window configuration | Yes, on *Offline Window* |
| Violation Settings (450) | Violation-filter configuration | Yes, on *Violation Configuration* |
| Root-to-outage links (550) | Links between outages and contributing alarms | No |
| Alarm history (750) | Historical alarm events used by the SLA | No |
| History Statistics (1000) | Tracking-period compliance and availability summaries | Yes, on *History* (fixed-window SLAs) |

Tables 550 and 750 support the SLA internally and are not displayed on the standard element card.

The *History* page displays tracking period summaries from table 1000, rather than individual alarm events from table 750.

Outages and alarms also have different roles: one outage can involve several alarms, and an alarm can contribute to more than one outage interval.

For the parameter contract, see [Reserved SLA parameter IDs](xref:ReservedIDsSLA).

## Example: availability and outage impact

Availability depends on the violation time counted by the SLA within the evaluated monitoring span. Alarm weighting, exclusions, thresholds, and corrections can affect that counted time.

For a simple example, assume:

- A complete 24-hour monitoring span.
- One outage lasting one hour.
- No excluded time, delay, minimum outage threshold, or manual correction.
- A constant outage impact for the full hour.

The calculation is:

```text
Availability (%) = 100 - (weighted violation time / monitoring span) x 100
```

| Outage impact | Weighted violation time | Availability |
|---|---|---|
| 100% | 1 hour | 95.8333% |
| 50% | 0.5 hours | 97.9167% |

At 100% impact, one hour in a 24-hour span reduces availability by 4.1667 percentage points.

## Example: delay time versus minimum outage threshold

Delay time and minimum outage threshold have different effects:

- *Delay Time* determines whether an outage has lasted long enough to count. Once the delay is reached, the delay itself is not subtracted from the outage duration.
- *Minimum Outage Threshold* is subtracted from the outage duration once the outage qualifies.

When both are configured, an outage must reach both values before it contributes corrected duration.

The following examples assume 100% impact, no manual correction, and an outage entirely within the counted monitoring span:

| Outage duration | Delay time | Minimum outage threshold | Corrected duration |
|---|---|---|---|
| 5 minutes | 2 minutes | 0 | 5 minutes |
| 5 minutes | 0 | 1 minute | 4 minutes |
| 5 minutes | 2 minutes | 1 minute | 4 minutes |
| 90 seconds | 2 minutes | 0 | 0 |
| 90 seconds | 2 minutes | 1 minute | 0 |

In the third example, the one-minute threshold is subtracted from the five-minute outage. The two-minute delay determines whether the outage qualifies.

In the fourth example, the 90-second outage is shorter than the two-minute delay, so its corrected duration is zero even though the minimum outage threshold is zero.

See [Configuring the alarm settings for an SLA](xref:Configuring_the_alarm_settings_for_an_SLA).

## Combining alarm impacts

### Configuring Component Info on source alarms

*Component info* is text associated with an alarm-generating parameter, for example `Video` or `Audio`. You can configure it in the information template for the **protocol of the monitored element**, not in the information template for Skyline SLA Definition Basic.

In Cube:

1. Open *Apps > Protocols & Templates*.

1. Select the source protocol.

1. Create or edit an information template.

1. Select the relevant parameter.

1. Configure *Parameters > Component info*.

1. Save the template.

1. Activate the template if necessary.

For the complete procedures, see [Creating an information template](xref:Creating_an_information_template) and [Activating an information template](xref:Activating_an_information_template). Check the scope before making changes: an information template can affect multiple elements.

The configured text becomes part of the source alarm. The SLA displays the received value in the *Component Info* column of its *Active Service Alarms* table (table 250, column PID 264). This column reflects the incoming alarm information; it is not where you configure the grouping.

### Combining simultaneous alarm impacts

Component Info does not assign an impact percentage. It determines how the SLA combines the impacts of alarms that contribute at the same time:

- Alarms with the same nonempty text form one group. Only the highest impact within that group contributes.
- Contributions from different groups are added.
- Alarms with empty Component Info contribute individually.
- The combined impact is capped at 100%.

Assuming the individual alarm impacts have already been determined and no other alarms contribute:

| First alarm impact | Second alarm impact | Component Info on the source alarms | Combined outage impact |
|---|---|---|---|
| 20% | 50% | Both `Video` | 50% |
| 20% | 50% | `Video` and `Audio` | 70% |
| 20% | 50% | Both empty | 70% |
| 70% | 60% | `Video` and `Audio` | 100% |

Choose the text according to which alarms should share one impact contribution. The same text groups contributing alarms even when they originate from different elements within the monitored service.

## Tracking, display, and retention

Tracking controls whether the SLA actively monitors the service. Display settings control which information is shown on particular pages. Retention determines how long old outage information and its supporting detail remain available.

See [Turning SLA tracking on and off](xref:Turning_SLA_tracking_on_and_off) and [Setting the time to keep outages](xref:Setting_the_time_to_keep_outages).
