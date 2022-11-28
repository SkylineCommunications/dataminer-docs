---
uid: Investigating_a_protocol_thread_RTE
---

# Investigating a protocol thread RTE

Below, you can read how you can find the root cause when the following alarm is shown in the Alarm Console:

```txt
Thread problem in SLProtocol.exe: [DriverName/DriverVersion] ElementName – Protocolthread
```

## User skills required

- Basic knowledge of drivers.
- Basic knowledge of how to use DataMiner Cube.

## What does this alarm mean?

This alarm indicates that the protocol thread that is used to execute polling or logical flows has stopped showing activity for a specific duration. By default, this duration is 15 minutes.

The protocol thread is used by the element in the error and has an impact on the SLProtocol process that is running it. This can lead to other elements failing to perform polling or logical flows. This is indicated with "(+ x Pending)" at the end of the error message.

## Investigation

1. Confirm if the indicated element is really the first element for which the protocol thread stopped showing activity.

    1. In DataMiner Cube, go to *System Center > Logging > DataMiner*, and check the Watchdog log (see [DataMiner logging](xref:DataMiner_logging)).
    1. Search for the first indication of an RTE (i.e. search for "count = 1").

1. Verify if the RTE is switching between active and cleared.

    - If this is the case, it means an operation is taking longer than 15 minutes (or 7.5 min for a half-open RTE).

1. Request the pending calls for this element via the SLNetClientTest tool (see [How to retrieve protocol pending calls](xref:How_to_retrieve_protocol_pending_calls)).

    - This is only useful if the error is still active.
    - This will indicate the amount of time a specific component in the driver is busy.
    - The group component that indicates the largest amount of time, longer than 15 minutes (or 7.5 for a half-open RTE), is the one blocking the activity on the protocol thread.

## Resolving the issue

Verify the logic linked to the long-running group in the protocol definition. Either this group is taking a long time to fully finish or it is stuck, for example because of the malfunctioning of a (third-party) software component responsible for retrieving data from the data source.

As a rule of thumb, a **group is finished** when:

- The content of the group is fully executed. For example, all data has been received for each request in the group.
- All linked logic is fully executed. For example, a calculation that needs to be done after data has been received.

Use **DataMiner Integration Studio** to navigate through the defined logic linked to the detected group.

A poorly designed definition can have **a cascade of linked logic**. The longer the chain, the longer the group that initiated the first step will block the protocol thread.

To avoid this, **break the chain** by executing the logical flow via a new group. Polling of data depends on the communication speed and on the amount of info to retrieve. A large polling operation and even logical steps in a big workflow are best taken care of in different chunks.

## Total estimated time

While investigating the issue should only take about 15 minutes, the time to resolve the issue depends on the complexity of the protocol involved, and can therefore vary a lot.

## Useful links

- For more information about protocol threads and SLProtocol processes, see [SLProtocol](xref:InnerWorkingsSLProtocol).
- For more information on how to request the pending calls via the SLNetClientTest tool, see [How to retrieve protocol pending calls](xref:How_to_retrieve_protocol_pending_calls).
- For more information about DataMiner Integration Studio, see [DataMiner Integration Studio](xref:DIS).
