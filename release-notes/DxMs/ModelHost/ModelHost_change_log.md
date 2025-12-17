---
uid: ModelHost_change_log
---

# Model Host change log

### 6 May 2025 - Fix - ModelHost 1.1.6 - Models not loaded after CloudGateway restart [ID 42702]

After a Cloud Gateway restart, it could occur that models were not loaded. To prevent this, Model Host will now try to load any cached local models when unable to communicate with Cloud Gateway.

### 6 July 2023 - Fix - ModelHost 1.1.0 - Installation triggered server restart [ID 36172]

When the Model Host module was installed, this could trigger a restart of the server. This will no longer occur. In addition, the installation UI has been improved, and the license agreement has been updated.

### 6 July 2023 - Enhancement - ModelHost 1.1.0 - Relation model combinations normalized [ID 36086] [ID 36733]

When a request asks for multiple kinds of relations, Model Host will now combine these relations in a better way, which can result in better suggestions (for example for related parameters in a trend graph in Cube).

### 6 July 2023 - New feature - ModelHost 1.1.0 -  Host service for relation learning added [ID 35703]

Model Host now includes a host service for alarm relation learning models.

> [!NOTE]
> For features included in older Model Host releases, refer to the [General DataMiner release notes](xref:DataMiner_General_RNs_index).
