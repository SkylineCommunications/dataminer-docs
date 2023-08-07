---
uid: SwitchingObjects
---

# Switching objects

With DataMiner Swarming, you can switch any [DataMiner object](xref:BasicConcepts#system-components) from one DataMiner Agent in a cluster to another.

## Switching an element

When you are switching an element from being hosted on one DataMiner Agent to another, a temporary transition occurs.

To indicate this, the following message will be displayed:

```txt
'ElementName' is currently switching.
           More info
```

During this transition, the ability to open element cards or change element configuration will be temporarily suspended.

Once the element migration is complete, it will become accessible again.
