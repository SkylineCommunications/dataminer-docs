---
uid: Promoting_a_protocol_version_to_production_version
keywords: production protocol, production driver, production connector
---

# Promoting a protocol version to production version

When you promote a protocol version to “production version”, all elements using the “production version” of that protocol will automatically start using that particular version.

Within a DataMiner System, you can maintain different versions of a particular protocol. Typically, all elements will use the so-called production version of their respective protocol. Automation scripts and correlation rules will also be based on production versions of protocols.

When you add a new version of a particular protocol to your DataMiner System, it is good practice to first test that new version with one element only.

1. In the settings of your test element, set the protocol version to the newly added version instead of *Production*.

1. If, after a certain test period, you notice that the element has been running smoothly, switch the element’s protocol version back to *Production*.

1. Promote the new protocol version to production version.

To promote a protocol version to the production version:

1. Go to *Apps* > *Protocols & Templates*.

1. Under *Protocols*, select the protocol.

1. Under *Versions*, right-click the protocol version and select *Set as production*.

> [!NOTE]
>
> - DVE child protocols cannot be set as production protocol.
> - From DataMiner 10.4.10/10.5.0 onwards<!--RN 40291-->, when you deploy a protocol for the first time, it will automatically be promoted to the production version. From DataMiner 10.5.0 [CU4]/10.5.7 onwards, this will also happen for protocols that are deployed for the first time as part of a .dmapp package.<!-- RN 42623 -->
