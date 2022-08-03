---
uid: PA_1.1.1
---

# PA 1.1.1

## New features

#### Process Automation: Queue profile definition parameters setup \[ID_28359\]

The *SRM_Setup* script now sets up the following profile definition parameters for Process Automation: PA Queue max empty duration, PA Queue max activity duration, PA Queue Depth, PA Queue Type, PA Preemptive, PA Priority, PA Max Time In Queue and PA Queue Admin State.

#### Skyline Queue Manager: New and updated parameters \[ID_28377\]\[ID_28483\]\[ID_28536\]

The following parameters have been added in the *Skyline Queue Manager* driver:

- Queue Type: Can be *FIFO* (default value) or *LIFO*. This will determine which of several tokens is processed first.
- Queue Admin State: Can be *Up* (default value) or *Down*. When this parameter is set to *Down*, the queue manager will continue to receive tokens from other queues and add them to the queue, as well as process messages from activities that were already processing a token, but it will no longer assign tokens to resources or send tokens to the next queue.
- Queue Maximum Empty Duration: By default 1 hour.
- Queue Maximum Activity Duration: By default 10 minutes.

In addition, the default value of the *Queue Size* parameter is now 1000 instead of *Unlimited*.

When a queue profile instance is loaded, these parameters will be updated with the values from the profile instance.

#### Max Time in Queue can now be configured per token \[ID_28631\]

While previously the maximum time a token could be in the queue was determined by the *Max Time in Queue* standalone parameter, this can now be configured for each token separately. The maximum time in the queue must be configured through the selection of a profile instance or setting while a booking is created. The default value is 60 minutes.

The *SRM_LSO_ProcessAutomation* script will process this value while creating tokens. The value will then be transferred like any other token value. If a token exceeds the maximum time in the queue, the *Skyline Queue Manager* will set the token error state to *Error_queue_timeout* in the *Incoming* or *Outgoing Token Table*. Entries in this state remain in the queue as long as the booking is active.

## Changes

### Enhancements

#### Booking automatically unregistered \[ID_28467\]

In case for some reason a booking is still registered in the Process Automation framework while it has in fact already finished, e.g. because of a malfunction or because the DMA is down, it will now be automatically unregistered from the Queue Manager element.

#### Queue Error State now indicates if maximum empty duration is exceeded \[ID_28558\]

When the queue error state has been empty for longer than the value defined in the parameter *Queue Maximum Empty Duration*, the *Queue Error State* parameter will now display "Empty for too long".

#### Skyline Generic Token: Token function now has fixed GUID \[ID_28578\]

The "Token" function of the Skyline Generic Token driver now has a fixed GUID.

#### Token now goes into timeout if not processed before Queue Maximum Activity Timeout \[ID_28601\]

When a token has had the *Processing* status for longer than the value defined in the parameter *Queue Maximum Activity Timeout*, the token will now enter the *Error_Activity_Timeout* token error state. When this happens, a message of type "ForceFinish" is sent to the corresponding Profile Load script and the resource is released and made available to process other tokens.
