---
uid: GetAnnotationsLinkForView
---

# GetAnnotationsLinkForView

**Obsolete**. This method is no longer available as of DataMiner 10.5.0 [CU10]/10.6.1.<!-- RN 44136 -->

Use this method to retrieve a link to open the annotations page of the specified view.

## Input

| Item       | Format  | Description                                          |
|------------|---------|------------------------------------------------------|
| connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| viewID     | Integer | The view ID.                                         |

## Output

| Item                            | Format | Description                                   |
|---------------------------------|--------|-----------------------------------------------|
| GetAnnotationsLinkForViewResult | String | The link to the annotations page of the view. |
