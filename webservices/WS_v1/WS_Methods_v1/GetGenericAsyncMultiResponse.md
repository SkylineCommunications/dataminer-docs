---
uid: GetGenericAsyncMultiResponse
---

# GetGenericAsyncMultiResponse

Use this method to retrieve the result of multiple tasks that were sent to the server using the ExecuteGenericAsyncRequest method (see [ExecuteGenericAsyncRequest](xref:ExecuteGenericAsyncRequest)).

> [!TIP]
> See also:
> [Executing methods asynchronously](xref:ExecuteGenericAsyncRequest#executing-methods-asynchronously)

## Input

| Item    | Format          | Description                                                                                                                                |
|---------|-----------------|--------------------------------------------------------------------------------------------------------------------------------------------|
| Tickets | Array of string | The tickets that were returned by the ExecuteGenericAsyncRequest method (see [ExecuteGenericAsyncRequest](xref:ExecuteGenericAsyncRequest)). |

## Output

| Item                                | Format                | Description                                                                                                                                                       |
|-------------------------------------|-----------------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| GetGenericAsyncMulti­ResponseResult | Depending on the task | The result of the task that was sent to the server using the ExecuteGenericAsyncRequest method (see [ExecuteGenericAsyncRequest](xref:ExecuteGenericAsyncRequest)). |

