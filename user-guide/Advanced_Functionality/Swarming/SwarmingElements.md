---
uid: SwarmingElements
---

# Swarming elements

With DataMiner Swarming, you can swarm basic elements from one DataMiner Agent in a cluster to another. At present, the *Swarming* [soft-launch option](xref:SoftLaunchOptions) must be enabled for this.

When you are swarming an element so it gets hosted on a different DataMiner Agent, a temporary transition occurs.

To indicate this, the following message will be displayed:

```txt
'ElementName' is currently switching.
           More info
```

During this transition, the ability to open element cards or change element configuration will be temporarily suspended.

Once the element migration is complete, it will become accessible again.
