---
uid: SLNetClientTest_Inspecting_the_parameter_notification_queue
---

# Inspecting the parameter notification queue

To inspect the state and the settings of the SLNet parameter notification queue, go to *Diagnostics* > *SLNet* > *ParameterNotificationQueueInfo*.

In this queue, you will find all events received by the SLNet process:

- incoming parameter changes from SLElement,
- incoming element states,
- incoming alarm events,
- etc.

The most important piece of information on this screen is the *Total Queued* value. If this is a large value, and if it does not come down after a refresh, this means that there is something that cannot keep up.

At the bottom of the screen, you can find queues per element (DmaID/ElementID). These queues allow you to pinpoint the element(s) causing problems.
