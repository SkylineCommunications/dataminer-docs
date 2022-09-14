---
uid: General_Feature_Release_10.2.11
---

# General Feature Release 10.2.11 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube 10.2.11](xref:Cube_Feature_Release_10.2.11).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### Security enhancements [ID_34251]

A number of security enhancements have been made.

#### Performance improvement to update service state more quickly [ID_34165]

<!-- Main Release Version 10.1.0 [CU20]/10.2.0 [CU8] - Feature Release Version 10.2.11 -->

Because of a performance improvement, the calculated service alarm state will now be updated more quickly in the client.

#### Enhanced performance when querying large XML files [ID_34299]

<!-- Main Release Version 10.1.0 [CU20]/10.2.0 [CU8] - Feature Release Version 10.2.11 -->

Because of a number of enhancements made to SLXML, overall performance has increased when querying large XML files.

#### Web apps - Interactive Automation scripts: Enhanced performance [ID_34348]

<!-- Main Release Version 10.2.0 [CU8] - Feature Release Version 10.2.11 -->

Because of a number of enhancements to the buffering mechanism, overall performance has improved when executing interactive Automation scripts in web apps.

#### Ticketing app: Enhanced error handling [ID_33414]

<!-- Main Release Version 10.2.0 [CU8] - Feature Release Version 10.2.11 -->

Because of a number of enhancements, overall error handling has improved.

### Fixes

#### Dashboard Gateway (legacy): Dashboards would fail to show the Maps component when the DMA had HTTPS configured [ID_33777]

<!-- Main Release Version 10.1.0 [CU20]/10.2.0 [CU8] - Feature Release Version 10.2.11 -->

When a legacy Dashboard Gateway was connected to a DataMiner Agent with HTTPS configured and port 80 blocked, dashboards would fail to show the Maps component.

#### Dashboards app / Low-code apps: Creating a custom theme with a custom color palette would incorrectly cause the color palette of all built-in themes to be updated [ID_34368]

<!-- Main Release Version 10.1.0 [CU20]/10.2.0 [CU8] - Feature Release Version 10.2.11 -->

Creating a custom theme with a custom color palette would incorrectly cause the color palette of all built-in themes to be updated.

#### Dashboards app: Email reports would incorrectly not include CSV files when the 'Include CSV' option had been selected [ID_34370]

<!-- Main Release Version 10.2.0 [CU8] - Feature Release Version 10.2.11 -->

In some cases, email reports would incorrectly not include CSV files when the *Include CSV* option had been selected.

#### Low-code apps: Problem when creating a new component theme [ID_34372]

<!-- Main Release Version 10.2.0 [CU8] - Feature Release Version 10.2.11 -->

When you created a new component theme while a built-in dashboard theme was active, in some cases, a Web Services API error could occur.

#### Problem with SLProtocol when reading incorrectly configured port settings [ID_34379]

<!-- Main Release Version 10.1.0 [CU20]/10.2.0 [CU8] - Feature Release Version 10.2.11 -->

In some cases, an error could occur in SLProtocol when reading incorrectly configured port settings.

#### Dashboards app: URL parameter data would not be parsed correctly [ID_34380]

<!-- Main Release Version 10.2.0 [CU8] - Feature Release Version 10.2.11 -->

In some cases, parameter data in a dashboard URL would incorrectly only get parsed when followed by a forward slash ("/").
