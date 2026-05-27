---
uid: GQI_Extensions_Common_Exceptions
---

# Common exceptions from GQI extensions

The following exceptions can commonly occur when developing GQI extensions:

- [System.ObjectDisposedException: The CancellationTokenSource has been disposed](#systemobjectdisposedexception-the-cancellationtokensource-has-been-disposed)
- [System.Threading.Tasks.TaskCanceledException: A task was canceled](#systemthreadingtaskstaskcanceledexception-a-task-was-canceled)

## System.ObjectDisposedException: The CancellationTokenSource has been disposed

- Data is requested via `GQIDMS` after the session is closed. After [OnDestroy](xref:GQI_IGQIOnDestroy) is invoked, the `GQIDMS` object is disposed and can no longer accept new requests.

## System.Threading.Tasks.TaskCanceledException: A task was canceled

- A `GQIDMS` request is still in progress when the session is closed. When [OnDestroy](xref:GQI_IGQIOnDestroy) is invoked, any ongoing requests are canceled.
