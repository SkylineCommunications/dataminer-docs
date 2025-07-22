---
uid: KI_Restart_loop_when_Elasticsearch_unavailable
---

# DataMiner keeps trying to restart when Elasticsearch is unavailable

## Affected versions

DataMiner 10.3 main and feature releases.

## Cause

When DataMiner detects that Elasticsearch is down, instead of attempting to reconnect, it triggers a DataMiner restart.

## Workaround

Restore the connection to the Elasticsearch database or remove the Elasticsearch database from DB.xml.

## Fix

No fix is available yet.

## Issue description

After a DataMiner upgrade, DataMiner keeps restarting. Each restart usually happens shortly after DataMiner begins starting up elements.

In SLWatchdog2.txt, the following log line is present:

```txt
Restart (with SLNet) is called by The connection with the database has been restored.
```
