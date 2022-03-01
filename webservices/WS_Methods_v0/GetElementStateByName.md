---
uid: GetElementStateByName
---

# GetElementStateByName

Use this method to request the current state of an element (referenced by name).

Examples of element states: Active, Stopped, etc.

## Input

| Item        | Format | Description                                   |
|-------------|--------|-----------------------------------------------|
| Connection  | String | The connection ID. See [Connect](xref:Connect). |
| ElementName | String | The element name.                             |

## Output

| Item                         | Format | Description                       |
|------------------------------|--------|-----------------------------------|
| GetElementStateByName­Result | String | The current state of the element. |

