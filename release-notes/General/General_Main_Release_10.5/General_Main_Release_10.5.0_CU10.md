---
uid: General_Main_Release_10.5.0_CU10
---

# General Main Release 10.5.0 CU10 - Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube 10.5.0 CU10](xref:Cube_Main_Release_10.5.0_CU10).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Main Release 10.5.0 CU10](xref:Web_apps_Main_Release_10.5.0_CU10).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### SLNetClientTest tool now allows you to check the contents of the hosting cache used by SLDataMiner [ID 43605]

<!-- MR 10.5.0 [CU10] - FR 10.6.1 -->

Using the *SLNetClientTest* tool, you can now send a DiagnosticMessage with LIST_HOSTAGENTCACHE to SLDataMiner to retrieve the contents of the hosting cache used by SLDataMiner. This will allow you to check if an element is local or not.

To send such a message, open the *SLNetClientTest* tool, and go to *Diagnostics > Dma > Elements (Hosting Cache)*.

> [!CAUTION]
> Always be extremely careful when using the *SLNetClientTest* tool, as it can have far-reaching consequences on the functionality of your DataMiner System.

#### Automation: All methods that use parameter descriptions have now been marked as obsolete [ID 43948]

<!-- MR 10.4.0 [CU22] / 10.5.0 [CU10] / 10.6.0 [CU0] - FR 10.6.1 -->

All methods in the `Skyline.DataMiner.Automation` namespace that use parameter descriptions have now been marked as obsolete.

### Fixes

#### Service templates: Problem when parsing conditions to dynamically include or exclude child elements [ID 43120]

<!-- MR 10.5.0 [CU10] - FR 10.6.1 -->

In some cases, conditional triggers to dynamically include or exclude child elements would be parsed incorrectly, especially when the first condition was a NOT clause.

#### SLElement could stop working when DVE elements were deleted [ID 43947]

<!-- MR 10.5.0 [CU10] - FR 10.6.1 -->

Up to now, when DVE elements were deleted while multiple DVE elements were having their state changed to deleted/stopped, in some cases, SLElement could stop working.

#### SLNet: Information messages triggered in a QAction would incorrectly only be forwarded to the DMA hosting the element in question [ID 43958]

<!-- MR 10.5.0 [CU10] - FR 10.6.1 -->

When a QAction triggered an information message with regard to a particular element, SLNet would incorrectly only forward that message to the DataMiner Agent that hosted that element. As a result, that information message would not appear in client applications connected to any of the other DataMiner Agents in the system.

#### Failover: 'C:\\Skyline DataMiner\\Elements' folder on offline Agents could unexpectedly be cleared [ID 44005]

<!-- MR 10.5.0 [CU10] - FR 10.6.1 -->

In Failover clusters, in some rare cases where specific conditions related to DVE element handling and naming conflicts were met, the `C:\Skyline DataMiner\Elements` folder on offline Agents could unexpectedly be cleared, sometimes leaving no elements behind.

To detect whether this has occurred:

- Compare the number of elements on the online and offline Agents.
- Check the offline Agent's Recycle Bin for entries named "Element   deleted", indicating a deletion occurred without a known element name.

#### SLProtocol would silently fail to parse the Protocol.Advanced@stuffing attribute when its value contained spaces [ID 44010]

<!-- MR 10.5.0 [CU10] - FR 10.6.1 -->

Up to now, SLProtocol would silently fail to parse the *stuffing* attribute of the *Protocol.Advanced* tag when its value contained spaces.
