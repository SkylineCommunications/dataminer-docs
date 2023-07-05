---
uid: ModelHost_1.1.0
---

# Model Host 1.1.0 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!NOTE]
> For features included in older Model Host releases, refer to the [General DataMiner release notes](xref:DataMiner_General_RNs_index).

## Enhancements

#### Relation request models normalized even if not all model types are hosted [ID_36733]

When you use the relation learning feature in Cube (i.e. the light bulb in a trend graph), requests are sent to Model Host to get relations.
From now on, Model Host will always balance the relation strengths when multiple kinds of relations are asked in a request, which will lead to more accurate suggestions in Cube.
