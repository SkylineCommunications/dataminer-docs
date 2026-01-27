---
uid: SiteManager_change_log
---

# Site Manager change log

#### 9 December 2025 - Enhancement - SiteManager 1.0.1 - Improved handling of files in use during upgrades [ID 44231]

The Windows Restart Manager is now enabled during installations, preventing unnecessary delays caused by files still in use by the SiteManager instance that is being upgraded. This change improves the speed and reliability of the upgrade process.

#### 8 September 2025 - New feature - SiteManager 1.0.0 - Ability to communicate from a DaaS system with selected on-premises data sources [ID 42932] [ID 43684] [ID 43685]

With the new SiteManager DxM, it is now possible to create and tear down communication tunnels enabling communication with selected on-premises data sources from a DaaS system. This new module makes use of zrok, a secure, open-source platform that allows private sharing of data sources.

When the DxM has been installed on the DataMiner Agent and the on-premises setup has been configured to enable the connection, users will be able to create elements that communicate with the on-premises data sources by selecting the configured site during element creation.

For detailed information, refer to [About Site Manager](xref:SiteManagerOverview).
