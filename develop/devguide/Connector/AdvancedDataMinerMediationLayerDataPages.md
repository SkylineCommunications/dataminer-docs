---
uid: AdvancedDataMinerMediationLayerDataPages
---

# Data pages

From DataMiner 9.5.0 \[CU9\]/9.5.14 (RN 19166) onwards, the page order, the default page and the option DisplayWideColmunPages are retrieved from the mediation protocol instead of the protocol assigned to the element.

From this same DataMiner version onwards, webpages of the device protocol are no longer added by default. To add these, define the page in the mediation protocol.

> [!NOTE]
> Only the name of the webpage needs to be defined (not the # + arguments). The arguments containing the URL data will be retrieved from the protocol assigned to the element.
