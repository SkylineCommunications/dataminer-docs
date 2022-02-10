---
uid: Protocol_pending_calls
---

# Protocol pending calls

To get an overview of the pending calls, select *Diagnostics* > *DMA* > *Protocol Pendingcalls…*

A pop-up window will be shown where you must provide the ID of the element for which you want to see the pending calls. After you press *OK*, a new entry will be added to the *Message Info Table* under the *Properties* tab. Double-click this entry to open a new window that displays the pending calls.

![](~/develop/images/MessageInfo.png)
<br>Figure 107: SLNetClientTest Pending Calls

The *Turn On*/*Turn Off* button allows you to enable/disable the automatic refresh of the current status. In the *Interval* box, you can configure the refresh rate. By default, the value is set to 5 seconds.

> [!NOTE]
> -  When the logging levels of the element are set to Level 2, some additional information will be available.
> -  If you use the *Protocol Pendingcalls* option for an element that is stuck, you will not get any diagnostics info, because this feature will try to add a lock on the element and that will fail, since it is stuck. If you use the *Protocol Pendingcalls\[no lock\]* option instead, you will get some diagnostics info.

- First, you get the ID of the ProtocolThread;

    ```txt
    ProtocolThread ID = 28924
    ```

- Then, for each item that is being executed, you will get the following information:

    - Item ID

    - Thread ID

    - Indication of how long ago the item started

    ```txt
    Timer id 1 in thread 8008 started 162 ms ago
    Group id 1200 in thread 28924 started 62 ms ago
    ```

The following info is included in the diagnostics:

- Timers: A list of the Timers that are waiting for their last group to finish. (The timers that are not listed are waiting for their next iteration.)

- Pairs: Pairs listed in the diagnostics output are being processed at that time.

    ```txt
    Pair id 52 in thread 18696 started 15048 ms ago
    Pair 52, Response 0: Content:
             000000 742870 6172616D5F 6765742830 29290D0A30  out(param_get(0))..0
             000020  0D0A2420
                                    ..$
    ```

- Parameters: SetParameters listed in the diagnostics output are being executed at that time.

    ```txt
    Parameter id 38408 in thread 25112 started 0 ms ago
    Element: 15, Parameter: 38408, User: External data, Time: 2012/10/12 11:48:35, Value: <NULL>
    ```

- QActions: QActions listed in the diagnostics output are being executed at that time.

- Groups: Groups listed in the diagnostics output are being executed at that time.
