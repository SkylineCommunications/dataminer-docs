---
uid: General_Main_Release_10.6.0_new_features
---

# General Main Release 10.6.0 – New features - Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

## Highlights

*No highlights have been selected yet.*

## New features

#### New SLNet call GetProtocolQActionsStateRequestMessage to retrieve QAction compilation warnings and errors [ID 41218]

<!-- MR 10.6.0 - FR 10.5.1 -->

A new SLNet call `GetProtocolQActionsStateRequestMessage` can now be used to retrieve the compilation warnings and errors of a given protocol and version. The response, `GetProtocolQActionsStateResponseMessage`, will then contains all faulty QActions and their respective warnings and errors.

In future versions, this call will be used to verify whether DataMiner Swarming can be enabled on a DataMiner System.
