---
uid: PTP_1.1.2
---

# PTP 1.1.2

## New features

#### Specifying a domain name for a PTP app instance \[ID_29882\]\[ID_29975\]\[ID_30034\]

It is now possible to specify a domain name for the PTP app. You can do so in the PTP setup wizard, or on the *Admin* page of the app. In case multiple PTP domains need to be monitored in the same DMS, a different domain can be specified for different instances of the PTP app.

On the right side of the *Admin* page, the *All Domains* table lists all configured PTP domains. You can add more domains here using the *Add* button.

When a domain is specified for an instance of the PTP app, the corresponding element is renamed to *DataMiner PTP - {domain name}*. In addition, a service is created containing all PTP devices, with the name *PTP Domain - {domain name}*.

In each instance of the PTP app, only the alarms that are relevant for the specified domain will be taken into account. If no domain is specified, all PTP-related alarms are taken into account.

#### Improved information on synchronization with preferred grandmaster \[ID_29990\]

When you click the table icon on the *Summary* tab of the PTP app, now all nodes are displayed instead of only the nodes that are not reporting to a preferred grandmaster. In the *Status* column, information is displayed about the synchronization status of the node. This field can have the following values:

- *Synced With Active Preferred Grandmaster*: The node is synchronized with the active grandmaster.
- *Synced With Preferred Grandmaster*: The node is synchronized with the preferred grandmaster, but this grandmaster is not active at the moment.
- *Synced With Non-Preferred Grandmaster*: The node is synchronized with a grandmaster that is not configured as a preferred grandmaster.
- *Synced With Other Device*: The node is synchronized with another node, which is not a grandmaster. This situation is typically to be avoided.
- *Unknown*: The node is synchronized with a node that is not known by the PTP application.

By means of an alarm template, you can configure monitoring of this column. Any alarms that are triggered are included in the count on the *Summary* tab of the app.

## Changes

### Fixes

#### PTP_Communication_Mode component info configured for wrong mediation parameter \[ID_29290\]

When generating the information templates, the PTP setup wizard configured the component info *PTP_Communication_Mode* for the wrong mediation parameter (74624 instead of 74215).
