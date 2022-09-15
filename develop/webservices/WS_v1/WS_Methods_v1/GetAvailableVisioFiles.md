---
uid: GetAvailableVisioFiles
---

# GetAvailableVisioFiles

Use this method to retrieve all available Visio files that can be assigned to views and services.

## Input

| Item       | Format | Description                                          |
|------------|--------|------------------------------------------------------|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |

## Output

| Item                          | Format          | Description                                                      |
|-------------------------------|-----------------|------------------------------------------------------------------|
| GetAvailableVisioFilesResult | Array of string | The names of the available Visio files (for views and services). |
