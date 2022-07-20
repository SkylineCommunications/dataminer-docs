---
uid: Could_not_load_type_Maps_DataMinerMap
---

# Could not load type Maps.DataMinerMap

If you receive a parser error message when trying to display a DataMiner Map, the problem is probably due to the Maps folder of the DMA’s default website not having been converted to an application yet.

## Symptom

When trying to display a DataMiner Map, you receive the following error message:

```txt
Parser Error Message: Could not load type 'Maps.DataMinerMap'.
```

## Resolution

In IIS Manager, convert the Maps folder of the DMA’s default website to an application.

1. Start IIS Manager.

2. In the tree on the left, go to *Sites \> Default Web Site \> Maps*.

3. Right-click the *Maps* node and select *Convert to Application*.

4. In the *Add Application* dialog box, click *OK*.
