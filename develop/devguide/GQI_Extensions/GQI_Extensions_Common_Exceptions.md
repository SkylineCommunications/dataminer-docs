---
uid: GQI_Extensions_Common_Exceptions
---

# Common exceptions from GQI extensions

The following exceptions can commonly occur when developing GQI extensions. For each exception, a number of known common causes are listed, but these are not exclusive. Other causes may exist.

- [System.ObjectDisposedException: The CancellationTokenSource has been disposed](#systemobjectdisposedexception-the-cancellationtokensource-has-been-disposed)
- [System.Threading.Tasks.TaskCanceledException: A task was canceled](#systemthreadingtaskstaskcanceledexception-a-task-was-canceled)

## System.ObjectDisposedException: The CancellationTokenSource has been disposed

- Data is requested via `GQIDMS` after the session is closed. After [OnDestroy](xref:GQI_IGQIOnDestroy) is invoked, the `GQIDMS` object is disposed of, and it can no longer accept new requests.

## System.Threading.Tasks.TaskCanceledException: A task was canceled

- A `GQIDMS` request is still in progress when the session is closed. When [OnDestroy](xref:GQI_IGQIOnDestroy) is invoked, any ongoing requests are canceled.
