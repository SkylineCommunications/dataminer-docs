---
metadata_version: 1
uid: SwarmingSmartSerialServerMode
description: "Describe the DataMiner connector development topic Enabling Swarming for elements with smart-serial connection in server mo, including its purpose, behavi."
area: develop
content_type: conceptual
authority: unknown
authority_source: unknown
lifecycle: active
applies_to:
  - DataMiner
version: unknown
owner: unknown
review_status: needs_update
review_date: 2026-09-17
compatibility:
  uid: stable
  url: stable
---

# Enabling Swarming for elements with smart-serial connection in server mode

For elements with smart-serial connections configured in server mode, Swarming is disabled by default. However, from DataMiner 10.6.6/10.7.0 onwards<!--RN 45173-->, if an element can communicate with its data source at startup to specify where data should be sent, you can enable Swarming by adding the following configuration to the *Protocol.xml* file:

**Schema requirement:** The `Check` value must be the exact [smartSerialAsServer](xref:Protocol-EnumSwarmingBypassCheck) enumeration value.

```xml
<Swarming>
    <BypassChecks>
        <Check>smartSerialAsServer</Check>
    </BypassChecks>
</Swarming>
```

**Recommendation:** Use this bypass only when the element can send a startup message that configures the data source's destination. The setting does not make an otherwise unconfigurable server-mode connection safe to swarm.

With this configuration in place, at startup, the element can send a message to the data source to indicate where data should be sent. As a result, the fact that the smart-serial connection is in server mode will no longer be considered a valid reason to prevent the element from being swarmed. See [Protocol.Swarming](xref:Protocol.Swarming) for the generated schema.
