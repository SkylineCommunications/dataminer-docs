---
uid: ModelHost_1.1.0
---

# Model Host 1.1.0

> [!NOTE]
> For features included in older Model Host releases, refer to the [General DataMiner release notes](xref:DataMiner_General_RNs_index).

## New features

### Host service for relation learning added [ID_35703]

Model Host now includes a host service for alarm relation learning models.

## Changes

### Enhancements

#### Relation model combinations normalized [ID_36086] [ID_36733]

When a request asks for multiple kinds of relations, Model Host will now combine these relations in a better way, which can result in better suggestions (for example for related parameters in a trend graph in Cube).

### Fixes

#### Model Host installation triggered server restart [ID_36172]

When the Model Host module was installed, this could trigger a restart of the server. This will no longer occur. In addition, the installation UI has been improved, and the license agreement has been updated.
