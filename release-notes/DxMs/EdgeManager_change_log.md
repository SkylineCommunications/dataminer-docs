---
uid: EdgeManager_change_log
---

# Edge Manager change log

#### 8 September 2025 - New feature - SiteManager 1.0.0 - Ability to set up secure communicate tunnels with remote locations [ID 42932] [ID 43684] [ID 43685]

With the new SiteManager DxM, it is now possible to create and tear down secure tunnels for communication with remote locations. At present, it is mainly intended for communication with selected on-premises data sources from a DaaS system without the need to configure, for instance, a site-to-site VPN.

This new module makes use of zrok, a secure, open-source platform that allows private sharing of data sources.

When the DxM has been installed on the DataMiner Agent and the setup in the remote location has been configured to enable the connection, users will be able to create elements that communicate with the data sources in the remote location by selecting the configured location during element creation.

For detailed information, refer to [About Edge Manager](xref:EdgeManagerOverview).
