---
uid: GetServiceElementListByName
---

# GetServiceElementListByName

Use this method to request a list of all the elements and services in a specific service (referenced by name).

## Input

| Item        | Format | Description                                   |
|-------------|--------|-----------------------------------------------|
| Connection  | String | The connection ID. See [Connect](xref:Connect). |
| ServiceName | String | The service name.                             |

## Output

| Item                               | Format                                                                                     | Description                                         |
|------------------------------------|--------------------------------------------------------------------------------------------|-----------------------------------------------------|
| GetServiceElement­ListByNameResult | Array of DMAElement (see [DMAElement](xref:DMAElement1#dmaelement)) | The elements and services in the specified service. |

