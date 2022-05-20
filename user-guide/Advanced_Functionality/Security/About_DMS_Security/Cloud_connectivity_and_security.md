---
uid: Cloud_connectivity_and_security
---

# Cloud connectivity and security

From version 10.2.0 onwards, DataMiner comes bundled with a number of cloud features. Because the cloud means connecting your system to the dangers of the internet, we built security into the core design of our Cloud Connectivity framework.

In highly secured environments, it is not always possible to set up a direct internet connection. For those scenarios, we intend to add support for hosting a dedicated Cloud Gateway node in a DMZ, acting as a tunnel to the DataMiner Cloud Platform.

In any case, connecting your DataMiner System to our Cloud Platform is opt-in, meaning DataMiner will not transfer anything to the cloud without an Administrator explicitly enabling this on the DataMiner System.

## Connecting to the DataMiner Cloud Platform

To connect your DataMiner System to the DataMiner Cloud Platform, please refer to [Connecting your DataMiner System to the cloud](xref:Connecting_your_DataMiner_System_to_the_cloud).

The DataMiner Cloud Platform is hosted in Microsoft Azure on the following endpoints:

- ``https://*.dataminer.services/``
- ``wss://tunnel.dataminer.services/``

At present, the following IP addresses are used to connect to the DataMiner Cloud Platform:

- 52.149.106.174
- 20.50.2.35
- 20.50.217.191
- 20.103.147.5

The DataMiner Cloud Platform sends emails from the following domain:

- dataminer.services

When you connect your DataMiner System to the DataMiner Cloud Platform, a secure connect flow needs to be completed. The administrator needs to authenticate on the DataMiner System and then needs to authenticate towards the DataMiner Cloud Platform.

At the end of this flow, a secure JSON Web Token is delivered directly from the DataMiner Cloud Platform to the DataMiner System, which is used by the DataMiner System to authenticate towards the DataMiner Cloud Platform.

- The signature of these JSON Web Tokens is created using the HMAC SHA256 algorithm. The secret is kept in a Key Vault, which is only accessed using Managed Identities.

- Every JSON web token is only valid for 1 week, after which it is automatically renewed using a single-use refresh key.

All communication between the DataMiner System and the DataMiner Cloud Platform happens using HTTPS and WSS protocols, both using encrypted TLS connections. Currently, only TLS 1.2 is supported.

Only outgoing traffic needs to be allowed through for the domain *.dataminer.services.

> [!NOTE]
>
> - Technical details of this implementation may be subject to change, as we regularly review our security implementations.
> - Users can disconnect their system from the DataMiner Cloud Platform at any given time. For more information, please refer to [Connecting your DataMiner System to the cloud](xref:Connecting_your_DataMiner_System_to_the_cloud).

## Live Sharing

Users can share a dashboard by clicking the *Start sharing* button in the dashboard menu bar. They can then specify a list of email addresses to share the dashboard with. Those email addresses will receive a link to the shared dashboard.

When the recipients open the link, they will need to authenticate by logging in with the account on the DataMiner Cloud Platform linked to that email address, or by creating a dedicated DataMiner Cloud Platform account if they do not have any of the formerly mentioned accounts. After successfully authenticating, the recipient will be directed to the dashboard through the DataMiner Cloud Platform tunnel.

No data from the private DataMiner System hosting the dashboard is stored on the DataMiner Cloud Platform. The share can be deleted in the same way as it was created. All emailed links will then automatically become unreachable. For more information, please refer to [Sharing a dashboard](xref:Sharing_a_dashboard).

Behind the scenes, DataMiner relies on several defense mechanisms to prevent unauthorized access to the shared dashboards.

### Cloud users

When a dashboard is shared, DataMiner will generate a special cloud user (see [Types of users](xref:Types_of_users)), which is used to view the shared dashboards. These cloud users have randomly generated passwords (17 characters) and can only be used through the DataMiner Cloud Gateway. The passwords for these users are encrypted using the Blowfish algorithm (308-bit key, ECB mode) before being stored. These users are only granted permissions on the items in the shared dashboard. For example, if your dashboard contains 2 elements, the resulting cloud user for that shared dashboard will only have read access to those 2 elements. Even if the user sharing the dashboard has access to all elements in the system.

### Web Application Firewall (WAF)

When a dashboard is shared, DataMiner will build a whitelist based on the API calls (and their parameters) of the dashboard. For example, consider your dashboard is displaying all active alarms for element 'SOC' with Element ID 100 and DataMiner ID 2000. When the dashboard is shared, DataMiner will infer it calls the GetActiveAlarmsForElement API with parameters Element ID 100 and DataMiner ID 200. If that shared dashboard connection were to suddenly request the active alarms for a different element, or even a different API call, DataMiner will block the request.

## Encryption

All data is encrypted at rest using AES-256 encryption. The keys are managed by our cloud providers, which also control the key rotation schedule. For more information, see [Database security](https://docs.microsoft.com/en-us/azure/cosmos-db/database-security?tabs=sql-api).

## Physical Security

Currently, the DataMiner Cloud Platform is hosted on Microsoft Azure. For more information, see [Azure physical security](https://docs.microsoft.com/en-us/azure/security/fundamentals/physical-security#physical-security).

## Disaster Recovery

All data on the DataMiner Cloud Platform is backed up multiple times per day and stored in a geo-redundant setup.
