---
uid: Connector_help_EBU_Synopsis_Web_Service
---

# EBU Synopsis Web Service

The EBU Synopsis Web Service connector retrieves information from the **European Broadcasting Union (EBU)** by interacting with the **Eurovision Web Services**.

## About

The EBU Synopsis Web Service is used to retrieve information from **eurovision.net** via the [**Eurovision Web Services**](https://workspace.ebu.ch/display/EurovisionWebServices).
There is also a possibility to use **callbacks** and get notified immediately in case of changes to synopses or requests.

There are multiple ranges of the EBU Synopsis Web Service connector. The **2.x range** is the generic, recommended range. This help only describes the configuration and usage of this range.

Note that your DMA will require an **internet connection** and a correctly configured firewall to connect with the **public** **Eurovision Web Services**.

### Version Info

<table>
<colgroup>
<col style="width: 25%" />
<col style="width: 25%" />
<col style="width: 25%" />
<col style="width: 25%" />
</colgroup>
<tbody>
<tr class="odd">
<td><strong>Range</strong></td>
<td><strong>Key Features</strong></td>
<td><strong>Based on</strong></td>
<td><strong>System Impact</strong></td>
</tr>
<tr class="even">
<td>1.0.0.x</td>
<td>Customer-specific range.</td>
<td>-</td>
<td>-</td>
</tr>
<tr class="odd">
<td>2.0.0.x</td>
<td>Generic
<ul>
<li>Polling of synopses, events, satellites, etc.</li>
<li>Supports callbacks</li>
<li><ul>
<li>Synopsis notifications</li>
<li>Request notifications</li>
</ul></li>
<li>Supports external requests to book</li>
<li><ul>
<li>News events</li>
<li>Program events</li>
<li>Satellite capacity</li>
<li>Unilateral transmissions</li>
<li>OSS transmissions</li>
</ul></li>
</ul></td>
<td>-</td>
<td>-</td>
</tr>
<tr class="even">
<td>2.0.1.x [SLC Main]</td>
<td>Generic
<ul>
<li>Supports all features available in 2.0.0.x.</li>
<li>Additional polling configuration:</li>
<li><ul>
<li>Enabling/disabling polling of specific data</li>
<li>Configuring polling frequency</li>
</ul></li>
</ul></td>
<td>2.0.0.8</td>
<td>Most polling is disabled by default to avoid a lot of requests (as most of this data is not needed if no bookings are created using this connector). <strong>If this data is required, manually enable polling when you move to this range.</strong></td>
</tr>
</tbody>
</table>

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 2.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 2.0.1.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Main Connection

This driver uses an HTTP(s) connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: www.eurovision.net
- **IP port**: 80 or 443
- **Bus address**: If the proxy server has to be bypassed, specify *bypassproxy.*

### Initialization

#### Credentials

The **Web Service ID** and **Web Service Secret Key** need to be configured for the element to be able to retrieve data from the Eurovision Web Services. This ID and secret key link to a specific user account at Eurovision. For more information on generating these credentials, go to <https://workspace.ebu.ch/display/EurovisionWebServices/Access+Management>.

#### Polling Frequency

The element will start polling as soon as the credentials are configured.

However, from range 2.0.1.x onwards, **only synopsis polling is enabled by default**. If you want to request additional information (e.g. events), you first need to configure the polling frequency for this. On each page, you can access the configuration of the polling frequency and you can configure if possible linked items should be retrieved.

#### Callbacks

It is possible to receive notifications as soon as there is a change to a synopsis or a request (for your account).

**Callbacks are disabled by default** but can be enabled on the **Callbacks** page. There you can also configure additional settings for the web service running in DataMiner that will listen to incoming requests. The callback configuration should match the **configuration on eurovision.net**, which can be found at <https://www.eurovision.net/myeurovision/callbacks>.

The linked data (for example a synopsis) will be polled again as soon as a notification is received.

## How to Use

### Synopses

The **Synopses** page has an overview of all synopses retrieved from EBU. As this is the most important data, **polling cannot be disabled**. However, you can configure the **polling frequency** (by default 15 min.).

As there are new synopses each day, this table is cleaned up automatically based on the configuration of when a synopsis should be removed (by default 7 days after its end date).

There is a lot of data in a synopsis, but only **limited information is available in the synopsis table**. There is, however, a hidden column that contains the full received synopsis XML. This information can be retrieved from the element using an API.

The **textual** representation of a synopsis will only be retrieved if this is enabled. This textual representation is more readable but does require an additional API request for each synopsis.

When the **Synopsis Offload Directory** is configured (by default disabled), then the synopsis XML and textual representation (if enabled) will also be offloaded to the configured directory.

### Events

The **Events** page has an overview of all upcoming events. Note that events are only retrieved when the **polling frequency** is configured.

Like for synopses, you can configure for how long events should be stored once the end time is reached. You can also configure for how far in the future events should be retrieved.

Depending on the type of event, additional details can be retrieved (when polling is enabled). When this is enabled, **multilateral transmissions** will be retrieved for each **Program** event. For **News** events, the **broadcast centers** can be retrieved.

### Customer Orders

The **Customer Orders** page contains an overview of all the customer orders that were created by the customer the API key is linked to.

The work orders linked to a specific customer order can also be retrieved. Note that this data is only retrieved when the polling frequency is configured and polling is enabled.

### Contracts

The **Contracts** page shows an overview of the contracts for the **selected organization**.

Note that an organization can only be selected if polling of the organization itself is enabled on the Organizations page. This data is also only retrieved when the polling frequency is configured.

### Organizations

The **Organizations** page shows a lot of information linked to the different organizations that are part of EBU. In addition to the organizations, the **countries**, **cities** and **broadcast centers** can all be retrieved when polling is enabled.

There is also an additional subpage for the **Broadcast Center Details**, which contains more details on the capabilities of each broadcast center.
**Polling of this data should not be enabled** unless it is specifically needed to for example create EBU bookings via this connector. This data could then help to make sure nothing can be booked that is technically not possible.

### Satellites

On the **Satellites** page, you can find the satellites, their **satellite families**, and the **transportables**. Note that this data is only retrieved when the polling frequency is configured.

### Video

The **Video** page and its subpages contain multiple tables with **video details**.
**Polling of this data should not be enabled** unless it is specifically needed to for example create EBU bookings via this connector. This data could then help to make sure nothing can be booked that is technically not possible.

### Audio

The **Audio** page contains a list of **audio codes** that are used in the **synopses** and can also be used when creating bookings through the EBU API.
**Polling of this data should not be enabled** unless it is specifically needed to for example create EBU bookings via this connector. This data could then help to make sure nothing can be booked that is technically not possible.

### Callbacks

The **Callbacks** page contains the configuration details for the callbacks as described in the Callbacks **Initialization** section.

Note that callbacks will only work when this is both enabled in the element and at EBU itself.

Once this is enabled, when a **notification** is received, the linked synopsis or customer order will **immediately be polled** again to make sure the latest information is available in the element.

### External Requests

The **External** **Requests** page contains a table that lists all the requests sent to the element from an external source (another element or an Automation script, for example).

These requests can be used to create bookings at EBU. This table will show an **overview of all requests** (if they have not exceeded the configured time to live) with an indication of whether they succeeded and of the response.

### Configuration

The **Configuration** page is where the **Web Service ID** and **Web Service Secret Key** need to be configured. No data can be polled as long as these have not been specified.
