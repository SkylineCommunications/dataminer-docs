---
uid: GetGenericAsyncResponse
---

# GetGenericAsyncResponse

Use this method to retrieve the result of a task that was sent to the server using the [ExecuteGenericAsyncRequest](xref:ExecuteGenericAsyncRequest) method.

> [!TIP]
> See also: [Executing methods asynchronously](xref:ExecuteGenericAsyncRequest#executing-methods-asynchronously)

## Input

| Item | Format | Description |
|--|--|--|
| ticket | String | The ticket that was returned by the [ExecuteGenericAsyncRequest](xref:ExecuteGenericAsyncRequest) method. |

## Output

| Item | Format | Description |
|--|--|--|
| GetGenericAsyncResponseResult | Depending on the task | The result of the task that was sent to the server using the [ExecuteGenericAsyncRequest](xref:ExecuteGenericAsyncRequest) method. |
