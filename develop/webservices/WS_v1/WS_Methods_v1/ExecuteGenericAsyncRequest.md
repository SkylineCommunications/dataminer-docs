---
uid: ExecuteGenericAsyncRequest
---

# ExecuteGenericAsyncRequest

Use this method to have a method executed asynchronously.

## Executing methods asynchronously

Some methods can take quite some time to execute (e.g. the *GetVisio*... methods). As it is not advised to block an HTTP channel for long periods of time, methods that take a long time to execute should be executed asynchronously.

To execute a method asynchronously, do the following:

1. Send the task to the server using the *ExecuteGenericAsyncRequest* method.

1. Check whether the server has finished executing the task using the *IsGenericAsyncResponseAvailable* method (see [IsGenericAsyncResponseAvailable](xref:IsGenericAsyncResponseAvailable)).

   > [!NOTE]
   > To cancel the execution, use the method *CancelAsyncRequest*. See [CancelAsyncRequest](xref:CancelAsyncRequest).

1. If the server has finished executing the task, use the *GetGenericAsyncResponse* method to retrieve the result (see [GetGenericAsyncResponse](xref:GetGenericAsyncResponse)).

## Input

| Item       | Format          | Description                               |
|------------|-----------------|-------------------------------------------|
| method     | String          | The name of the method.                   |
| parameters | Array of string | The arguments to be passed to the method. |

## Output

| Item | Format | Description |
|--|--|--|
| ExecuteGenericAsyncRequestResult | String | The ticket that has to be passed along when executing the [IsGenericAsyncResponseAvailable](xref:IsGenericAsyncResponseAvailable) method or the [GetGenericAsyncResponse](xref:GetGenericAsyncResponse) method. |
