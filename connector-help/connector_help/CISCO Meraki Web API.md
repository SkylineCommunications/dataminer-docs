---
uid: Connector_help_CISCO_Meraki_Web_API
---

# CISCO Meraki Web API

CISCO Meraki Web API is used by Kordia to monitor their Meraki devices (Cisco Meraki MX64, MX67, MX84, MX100, MS120-8, MS120-8FP, and vMX100) exclusively through the Meraki Web API.

## About

### Version Info

| **Range** | **Key Features**                                                                                         | **Based on** | **System Impact** |
|-----------|----------------------------------------------------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x   | Initial version Polling and Monitoring via Meraki API over HTTPS                                         | \-           | \-                |
| 2.0.0.x   | Virtual Driver Captures and Processes Webhook Notifications Automatic clearing of cleared/expired alarms | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | Not Applicable         |
| 2.0.0.x   | Not Applicable         |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 2.0.0.x   | No                  | No                      | \-                    | \-                      |

## Configuration 1.0.0.X

### Cisco Meraki API Key

The driver in version range 1.0.0.x captures alarms through communication with the Meraki API via HTTPS requests.

After filling in the connection details on the element card, the **Authorization Value** on the General page must be filled in.
This is the API Key used for authorization to access the API.



## Configuration 2.0.0.X

### Webhook Connections

The driver in version range 2.0.0.x captures alarms through webhook notifications.

The **Configuration** page needs to be set where the driver catches the webhooks from.

The user is required to set the following parameters:

- **Webhooks Status**: Toggle to determine if driver is receptive to webhook notifications
- **Webhooks URI**: URI webhook notifications will be caught with
- **Webhooks Port**: Port webhook notifications
- **Webhooks Protocol**: Select between HTTP and HTTPS protocol
- **Webhooks Certificate**: Select certificate to be used by driver (Applicable only for HTTPS protocol)

The status of the webhooks service is reflected below under the parameter **Webhooks Web Service Status**. If all parameters are configured correctly, it should display "Opened".


## How To Use

Once the webhook web service is configured, the element is ready to receive and process webhook notifications.

The notifications are processed and displayed in the following pages:

- **General**: Displays the last notification captured in a string. (*removed in version 2.0.0.X*)

- **Alarms**: Saves and displays notifications into an alarm table

- Alarm Settings: User can determine if the table automatically clears alarms that have been cleared/expired. User may determine the lifetime of these alarms.

## Notes

### Support for Webhook Alerts

The element currently supports the following alertTypeIds:

- stopped_reporting
- started_reporting
- vrrp (Failover event detected)
- failover_event (Uplink status changed)
