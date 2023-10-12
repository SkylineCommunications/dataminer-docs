---
uid: Cloud_connectivity_and_security
---

# Cloud connectivity and security

From version 10.2.0 onwards, a DataMiner System can be connected to dataminer.services to gain access to a wealth of cloud features. Because the cloud means connecting your system to the dangers of the internet, we have built security into the core design of our Cloud Connectivity framework.

In highly secured environments, it is not always possible to set up a direct internet connection. For those scenarios, it is possible to [connect to dataminer.services using a DMZ](xref:Connect_to_cloud_with_DMZ).

In any case, connecting your DataMiner System to dataminer.services is opt-in, meaning DataMiner will not transfer anything to the cloud without an Administrator explicitly enabling this on the DataMiner System.

## Connecting to dataminer.services

To connect your DataMiner System to dataminer.services, please refer to [Connecting your DataMiner System to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).

dataminer.services is hosted in Microsoft Azure on the following endpoints:

- ``https://*.dataminer.services/``
- ``wss://tunnel.dataminer.services/``

At present, the following IP addresses are used to connect to dataminer.services:

- 52.149.106.174
- 20.50.2.35
- 20.50.217.191
- 20.103.147.5
- 20.31.240.20

When emails are sent from dataminer.services, these come from the `dataminer.services` domain.

When you connect your DataMiner System to dataminer.services, a secure connect flow needs to be completed. The administrator needs to authenticate on the DataMiner System and then needs to authenticate towards dataminer.services.

At the end of this flow, a **secure JSON Web Token** is delivered directly from dataminer.services to the DataMiner System, which is used by the DataMiner System to authenticate towards dataminer.services.

- The signature of these JSON Web Tokens is created using the HMAC SHA256 algorithm. The secret is kept in a Key Vault, which is only accessed using Managed Identities.

- Every JSON web token is only valid for 1 week, after which it is automatically renewed using a single-use refresh key.

All communication between the DataMiner System and dataminer.services happens using HTTPS and WSS protocols, both using encrypted TLS connections. Currently, **only TLS 1.2 is supported**.

Only outgoing traffic needs to be allowed through for the domain *.dataminer.services.

> [!NOTE]
>
> - Technical details of this implementation may be subject to change, as we regularly review our security implementations.
> - Users can disconnect their system from dataminer.services at any given time. For more information, please refer to [Connecting your DataMiner System to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).

## Live sharing

Users can share a dashboard by clicking the *Start sharing* button in the dashboard menu bar. They can then specify a list of email addresses to share the dashboard with. Those email addresses will receive a link to the shared dashboard.

When the recipients open the link, they will need to authenticate by logging in with the account on dataminer.services linked to that email address, or by creating a dedicated dataminer.services account if they do not have any of the formerly mentioned accounts. After successfully authenticating, the recipient will be directed to the dashboard through the dataminer.services tunnel.

No data from the private DataMiner System hosting the dashboard is stored on dataminer.services. The share can be deleted in the same way as it was created. All emailed links will then automatically become unreachable. For more information, please refer to [Sharing a dashboard](xref:Sharing_a_dashboard).

Behind the scenes, DataMiner relies on several defense mechanisms to prevent unauthorized access to the shared dashboards.

### dataminer.services users

When a dashboard is shared, DataMiner will generate a **dataminer.services user** (see [Types of users](xref:Types_of_users)), which is used to view the shared dashboards. These dataminer.services users have randomly generated passwords (17 characters) and can only be used through the DataMiner Cloud Gateway. The passwords for these users are encrypted using the Blowfish algorithm (308-bit key, ECB mode) before being stored. These users are **only granted permissions on the items in the shared dashboard**. For example, if your dashboard contains 2 elements, the resulting dataminer.services user for that shared dashboard will only have read access to those 2 elements. Even if the user sharing the dashboard has access to all elements in the system.

### Web Application Firewall (WAF)

When a dashboard is shared, DataMiner will build a **whitelist based on the API calls** (and their parameters) of the dashboard. For example, consider your dashboard is displaying all active alarms for element "SOC" with Element ID 100 and DataMiner ID 2000. When the dashboard is shared, DataMiner will infer it calls the *GetActiveAlarmsForElement* method with element ID 100 and DataMiner ID 200. If that shared dashboard connection were to suddenly request the active alarms for a different element, or even a different API call, DataMiner would block the request.

## Encryption

All data is encrypted at rest using AES-256 encryption. The keys are managed by our cloud providers, which also control the key rotation schedule. For more information, see [Database security](https://docs.microsoft.com/en-us/azure/cosmos-db/database-security?tabs=sql-api).

## Physical security

Currently, dataminer.services is hosted on Microsoft Azure. For more information, see [Azure physical security](https://docs.microsoft.com/en-us/azure/security/fundamentals/physical-security#physical-security).

## Disaster recovery

All data on dataminer.services is backed up multiple times per day and stored in a geo-redundant setup.
