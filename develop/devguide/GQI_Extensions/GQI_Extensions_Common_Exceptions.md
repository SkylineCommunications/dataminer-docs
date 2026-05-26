---
uid: GQI_Extensions_Common_Exceptions
---

# When requesting data via the GQIDMS interface

The GQIDMS interface that is provided via the [OnInitInputArgs](xref:GQI_OnInitInputArgs) should only be used within the lifecycle of that query. After [OnDestroy](xref:GQI_IGQIOnDestroy) is invoked, the GQIDMS interface is marked as disposed.  
This behavior can lead to the following exceptions:

- `System.ObjectDisposedException: The CancellationTokenSource has been disposed`
    - Occurs if data is requested after the session is closed
- `System.Threading.Tasks.TaskCanceledException: A task was canceled`
    - Occurs if a request is still ongoing when the session is closed
