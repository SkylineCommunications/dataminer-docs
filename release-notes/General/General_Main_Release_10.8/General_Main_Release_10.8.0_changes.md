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

### Fixes

*No fixes have been added yet.*
