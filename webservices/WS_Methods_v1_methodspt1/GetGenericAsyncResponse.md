---
uid: GetGenericAsyncResponse
---

# GetGenericAsyncResponse

Use this method to retrieve the result of a task that was sent to the server using the ExecuteGenericAsyncRequest method (see [ExecuteGenericAsyncRequest](xref:ExecuteGenericAsyncRequest)).

> [!TIP]
> See also:
> [Executing methods asynchronously](xref:ExecuteGenericAsyncRequest#executing-methods-asynchronously)

## Input

| Item   | Format | Description                                                                                                                              |
|--------|--------|------------------------------------------------------------------------------------------------------------------------------------------|
| Ticket | String | The ticket that was returned by the ExecuteGenericAsyncRequest method (see [ExecuteGenericAsyncRequest](xref:ExecuteGenericAsyncRequest)). |

## Output

| Item                           | Format                | Description                                                                                                                                                       |
|--------------------------------|-----------------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| GetGenericAsync­ResponseResult | Depending on the task | The result of the task that was sent to the server using the ExecuteGenericAsyncRequest method (see [ExecuteGenericAsyncRequest](xref:ExecuteGenericAsyncRequest)). |

