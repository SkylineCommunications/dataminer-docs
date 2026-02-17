---
uid: GetElementsFiltered
---

# GetElementsFiltered

Use this method to request a specified series of elements.

> [!NOTE]
> Using this method, you can e.g., request elements in batches in order to minimize loading time.

## Input

| Item       | Format  | Description                                       |
|------------|---------|---------------------------------------------------|
| connection | String  | The connection ID. See [Connect](xref:Connect).     |
| index      | Integer | The point from which to start returning elements. |
| count      | Integer | The number of elements to be returned.            |

## Output

| Item | Format | Description |
|--|--|--|
| GetElementsFilteredResult | Array of [DMAElement](xref:DMAElement1) | The specified series of elements. |
