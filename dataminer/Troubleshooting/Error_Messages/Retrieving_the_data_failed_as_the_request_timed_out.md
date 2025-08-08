---
uid: Retrieving_the_data_failed_as_the_request_timed_out
---

# Retrieving the data failed as the request timed out

## Symptom

The following error message is displayed in DataMiner Cube:

```txt
Retrieving the data failed as the request timed out. See the log files for more information.
```

## Cause

The server has not been able to respond in time to a request made by DataMiner Cube. This can be caused by many different things, such as high server load, or a lot of data being requested at the same time (e.g. alarm history data for a very long time period).

## Resolution

Additional investigation is required to find the root cause of this issue. The first step is to pinpoint which actions exactly trigger the message. Then you should look at the log files related to that specific process. Only when you know what causes the issue, is it possible to look into a possible solution.
