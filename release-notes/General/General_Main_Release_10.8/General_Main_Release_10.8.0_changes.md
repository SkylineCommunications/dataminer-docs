---
uid: General_Main_Release_10.8.0_changes
description: "Changes in DataMiner General Main Release 10.8.0, including breaking changes, enhancements, and fixes planned for this preview release."
---

# General Main Release 10.8.0 – Changes (preview)

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

## Important changes

*No important changes have been selected yet.*

## Changes

### Enhancements

#### DataMiner upgrade: Upgrade action to configure SAML authentication redirects [ID 46589]

<!-- MR 10.8.0 - FR 10.7.1 -->

From now on, an upgrade action will automatically add a `Set-Cookie` header to `WebPages/web.config` on systems with SAML authentication enabled. This cookie configures web authentication to use redirects instead of an embedded iframe, ensuring compatibility with SAML providers that do not allow their sign-in pages to be displayed in an iframe.

The upgrade action will leave the configuration unchanged if SAML is disabled or the required cookie header is already configured. Existing custom headers, including `Set-Cookie` headers for other cookies, will be preserved.

#### DataMiner upgrade: Prerequisite check for Communication Gateway DxM version [ID 46798]

<!-- MR 10.8.0 - FR 10.7.1 -->

During a DataMiner upgrade, a new prerequisite check will verify the version of the installed Communication Gateway DxM. If the installed version is older than 5.3.5, the upgrade will be blocked.

If the installed Communication Gateway DxM version is older than 4.0.0, the check will also identify the following connectors that use an outdated version of the `Skyline.DataMiner.DataSources.OpenConfig.Gnmi.Protocol` NuGet package:

- Arista eOS Manager versions older than 1.0.0.5
- CISCO Nexus versions older than 3.0.7.3

To resolve these issues, upgrade Communication Gateway DxM to version 5.3.5 or higher. If any elements use a listed connector, configure them to use a connector version that uses version 6.0.0 or higher of the NuGet package. Remove listed connectors that are not in use.

The additional connector check only detects these known connectors. Make sure no other connectors in use depend on a version of the NuGet package older than 6.0.0.

### Fixes

*No fixes have been added yet.*
