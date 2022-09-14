---
uid: General_Main_Release_10.1.0_CU20
---

# General Main Release 10.1.0 CU20 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### Security enhancements [ID_34251]

A number of security enhancements have been made.

#### SLSNMPManager: Enhanced performance [ID_33940]

<!-- Main Release Version 10.1.0 [CU20]/10.2.0 [CU6] - Feature Release Version 10.2.9 -->

Because of a number of enhancements, overall performance of the SLSNMPManager process has improved.

#### Performance improvement to update service state more quickly [ID_34165]

<!-- Main Release Version 10.1.0 [CU20]/10.2.0 [CU8] - Feature Release Version 10.2.11 -->

Because of a performance improvement, the calculated service alarm state will now be updated more quickly in the client.

#### Enhanced performance when querying large XML files [ID_34299]

<!-- Main Release Version 10.1.0 [CU20]/10.2.0 [CU8] - Feature Release Version 10.2.11 -->

Because of a number of enhancements made to SLXML, overall performance has increased when querying large XML files.

#### DataMiner Cube - Visual Overview: Service context of a linked shape will only be determined when the service context has been specified [ID_34340]

<!-- Main Release Version 10.1.0 [CU20]/10.2.0 [CU8] - Feature Release Version 10.2.11 -->

When a shape was linked to an element that was not part of a service, up to now, an attempt would be made to determine the service context even when no service context had been specified. From now on, the service context will only be determined when the service context has been specified in the shape.

### Fixes

#### Dashboard Gateway (legacy): Dashboards would fail to show the Maps component when the DMA had HTTPS configured [ID_33777]

<!-- Main Release Version 10.1.0 [CU20]/10.2.0 [CU8] - Feature Release Version 10.2.11 -->

When a legacy Dashboard Gateway was connected to a DataMiner Agent with HTTPS configured and port 80 blocked, dashboards would fail to show the Maps component.

#### Dashboards app / Low-code apps: Creating a custom theme with a custom color palette would incorrectly cause the color palette of all built-in themes to be updated [ID_34368]

<!-- Main Release Version 10.1.0 [CU20]/10.2.0 [CU8] - Feature Release Version 10.2.11 -->

Creating a custom theme with a custom color palette would incorrectly cause the color palette of all built-in themes to be updated.

#### Problem with SLProtocol when reading incorrectly configured port settings [ID_34379]

<!-- Main Release Version 10.1.0 [CU20]/10.2.0 [CU8] - Feature Release Version 10.2.11 -->

In some cases, an error could occur in SLProtocol when reading incorrectly configured port settings.
