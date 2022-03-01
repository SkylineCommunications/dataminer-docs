---
uid: IsGenericAsyncResponseAvailable
---

# IsGenericAsyncResponseAvailable

Use this method to check whether the server has finished executing a task that was sent to it using the ExecuteGenericAsyncRequest method (see [ExecuteGenericAsyncRequest](xref:ExecuteGenericAsyncRequest)).

If this method returns true, you can use the GetGenericAsyncResponse method (see [GetGenericAsyncResponse](xref:GetGenericAsyncResponse)) to retrieve the result.

> [!TIP]
> See also:
> [Executing methods asynchronously](xref:ExecuteGenericAsyncRequest#executing-methods-asynchronously)

## Input

| Item   | Format | Description                                                                                                                                                          |
|--------|--------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Ticket | String | The ticket that was returned by the ExecuteGenericAsyncRequest method (see [ExecuteGenericAsyncRequest](xref:ExecuteGenericAsyncRequest)). |

## Output

| Item                                   | Format  | Description                                                                                     |
|----------------------------------------|---------|-------------------------------------------------------------------------------------------------|
| IsGenericAsyncResponse­AvailableResult | Boolean | Whether or not the server has finished executing the task associated with the specified ticket. |

