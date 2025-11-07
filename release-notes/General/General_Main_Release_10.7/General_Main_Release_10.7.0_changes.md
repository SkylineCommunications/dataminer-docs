---
uid: General_Main_Release_10.7.0_changes
---

# General Main Release 10.7.0 – Changes (preview)

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

## Changes

### Enhancements

#### SLNetClientTest tool now allows you to check the contents of the hosting cache used by SLDataMiner [ID 43605]

<!-- MR 10.7.0 - FR 10.6.1 -->

Using the *SLNetClientTest* tool, you can now send a DiagnosticMessage with LIST_HOSTAGENTCACHE to SLDataMiner to retrieve the contents of the hosting cache used by SLDataMiner. This will allow you to check if an element is local or not.

To send such a message, open the *SLNetClientTest* tool, and go to *Diagnostics > Dma > Elements (Hosting Cache)*.

> [!CAUTION]
> Always be extremely careful when using the *SLNetClientTest* tool, as it can have far-reaching consequences on the functionality of your DataMiner System.

#### Automation: Engine class now has an OnDestroy handler that will allow resources to be cleaned up when a script ends [ID 43919]

<!-- MR 10.7.0 - FR 10.6.1 -->

An `OnDestroy` handler has now been added to the `Engine` class. This handler will allow resources to be cleaned up when a script ends.

Multiple handlers can be added. They will run synchronously, and if one handler throws an error, the others will keep on running.

### Fixes

#### SLAnalytics would not receive 'swarming complete' notifications for swarmed DVE child elements [ID 43984]

<!-- MR 10.7.0 - FR 10.6.1 -->

Up to now, SLAnalytics would incorrectly not receive any "swarming complete" notifications for swarmed DVE child elements. As a result, alarm focus calculations for DVE child elements would be restarted from scratch instead of being fetched from the database.
