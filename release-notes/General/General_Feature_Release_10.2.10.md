---
uid: General_Feature_Release_10.2.10
---

# General Feature Release 10.2.10 – preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For release notes related to DataMiner Cube, see [DataMiner Cube 10.2.9](xref:Cube_Feature_Release_10.2.9).

## Highlights

*No highlights have been selected for this release yet*

## Other features

*No new features have been added to this release yet*

## Changes

### Enhancements

#### Edge WebView2 now preferred when SAML authentication is used [ID_34162]

When SAML authentication is used, Cube will now try to use the Edge WebView2 browser engine instead of CefSharp. It will only fall back to using CefSharp if WebView2 is not available.

This will prevent the following possible issues:

- The CefSharp browser engine version used by Cube is not updated frequently and therefore not always trusted by certain SAML identity provider websites, such as Microsoft Azure. This can cause a lengthy authentication procedure, even if the browser cache is enabled.
- The CefSharp browser engine needs to be downloaded from the DMA before a first authentication (on a new device). However, this is currently not supported for HTTPS-only setups.

### Fixes

*No fixes have been added to this release yet.*
