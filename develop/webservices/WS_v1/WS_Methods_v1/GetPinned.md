---
uid: GetPinned
---

# GetPinned

Use this method to retrieve the list of all the pinned items in the Recent list.

## Input

| Item       | Format | Description                                           |
|------------|--------|-------------------------------------------------------|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |

## Output

| Item | Format | Description |
|--|--|--|
| GetPinnedResult | Array of [DMARecent](xref:DMARecent) | The list of all the pinned items in the Recent list. |
