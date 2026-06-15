---
uid: SwarmingSmartSerialServerMode
---

# Enabling Swarming for elements with smart-serial connection in server mode

For elements with smart-serial connections configured in server mode, Swarming is disabled by default. However, from DataMiner 10.6.6/10.7.0 onwards<!--RN 45173-->, you can explicitly allow such elements to be swarmed by adding the following configuration to the *Protocol.xml* file:

```xml

<Swarming>
    <BypassChecks>
        <Check>smartSerialAsServer</Check>
    </BypassChecks>
</Swarming>

```

With this configuration in place, at startup, the element can send a message to the data source to indicate where data should be sent. As a result, the fact that the smart-serial connection is in server mode will no longer be considered a valid reason to prevent the element from being swarmed.
