---
uid: Could_not_load_Visio_file
---

# Could not load Visio file

## Symptom

When trying to open a Visio file in DataMiner Cube, you get one of the following errors:

```txt
Could not load Visio file: Visio cannot open the file because it's not a Visio file or it has become corrupted.
```

```txt
Could not load Visio file, please verify that your version of Visio supports VSDX files. VSDX files are supported in Visio 2010 SP2 with compatibility pack installed and in Visio 2013.
```

## Cause

You are probably trying to open a VSDX file in a version of Microsoft Visio that does not support the VSDX file format.

## Resolution

If you use Microsoft Visio 2010:

- Install Visio 2010 SP2, or

- Install Visio Compatibility Pack, or

- Upgrade to Microsoft Visio 2013.
