---
uid: KI_IE9_Cube_application_not_downloading_over_HTTPS
---

# IE9: Cube application not downloading over HTTPS

## Description of the issue

When Internet Explorer 9 is used, downloading the DataMiner Cube XBAP browser application over HTTPS fails with the following reason in the *More Information* section:

```txt
The download of the specified resource has failed.
```

This can also occur when files are downloaded from `https://<DMA IP>/Tools`.

This issue does not occur in Internet Explorer 10 or higher.

## Cause

The option *Do not save encrypted page to disk* is enabled in the advanced internet options. If this option is enabled, the XBAP downloader cannot download the necessary files.

## Resolution

Disable the option.

To do so:

1. In Internet Explorer, go to *Internet Options*.
1. Open the *Advanced* tab.
1. In the *Security* group, clear the selection for the option *Do not save encrypted pages to disk*.

Note that this option is not selected by default, except in Windows Server systems.

> [!TIP]
> See also: <http://support.microsoft.com/kb/2549423>
