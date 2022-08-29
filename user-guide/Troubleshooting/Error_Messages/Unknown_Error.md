---
uid: Unknown_Error
---

# Unknown Error

## Symptom

You get the following error while using the DataMiner Cube browser app

```txt
Unknown Error. Object reference not set to an instance of an object.
```

## Cause

There is probably a problem with the XBAP cache.

## Resolution

Do the following:

1. Go to `http://[DMA]/tools`.

1. Click *Clean DataMiner Cube XBAP Cache*.

1. In the *File Download* dialog, click *Run*.

If you restart the browser app after performing the above-mentioned procedure, a fresh copy of the app will be downloaded.
