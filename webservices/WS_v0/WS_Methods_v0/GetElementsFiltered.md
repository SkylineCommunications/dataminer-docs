---
uid: GetElementsFiltered
---

# GetElementsFiltered

Use this method to request a specified series of elements.

> [!NOTE]
> Using this method, you can e.g. request elements in batches in order to minimize loading time.

## Input

| Item       | Format  | Description                                       |
|------------|---------|---------------------------------------------------|
| Connection | String  | The connection ID. See [Connect](xref:Connect).     |
| Index      | Integer | The point from which to start returning elements. |
| Count      | Integer | The number of elements to be returned.            |

## Output

| Item                      | Format                                                                                    | Description                       |
|---------------------------|-------------------------------------------------------------------------------------------|-----------------------------------|
| GetElementsFilteredResult | Array of DMAElement (see[DMAElement](xref:DMAElement1#dmaelement)) | The specified series of elements. |

