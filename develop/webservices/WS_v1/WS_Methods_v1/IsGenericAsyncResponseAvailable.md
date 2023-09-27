---
uid: IsGenericAsyncResponseAvailable
---

# IsGenericAsyncResponseAvailable

Use this method to check whether the server has finished executing a task that was sent to it using the [ExecuteGenericAsyncRequest](xref:ExecuteGenericAsyncRequest) method.

If this method returns true, you can use the [GetGenericAsyncResponse](xref:GetGenericAsyncResponse) method to retrieve the result.

> [!TIP]
> See also: [Executing methods asynchronously](xref:ExecuteGenericAsyncRequest#executing-methods-asynchronously)

## Input

| Item | Format | Description |
|--|--|--|
| ticket | String | The ticket that was returned by the [ExecuteGenericAsyncRequest](xref:ExecuteGenericAsyncRequest) method. |

## Output

| Item | Format | Description |
|--|--|--|
| IsGenericAsyncResponseAvailableResult | Boolean | Whether the server has finished executing the task associated with the specified ticket. |
