---
uid: DMAPropertyFilter
---

# DMAPropertyFilter

| Item   | Format | Description |
|--------|--------|-------------|
| Method | String | The method used for filtering: *equal*, *not-equal*, *contains* or *not-contains*. |
| ID     | String | The ID of the field that is being filtered on: *PropertyExposers.Name* or *PropertyExposers.Value*. |
| Value  | String | A string that allows DataMiner to filter based on the value identified in the ID field. |

For example, the following JSON property filter can be used with the [GetServicesForFilter](xref:GetServicesForFilter) method to filter out the services with the property name *Class* and the property value *Gold*.

```json
{
  "genericFilter": {
    "propertyFilters": [
      {
        "Children": [
        {
            "Children": [],
            "Condition": {
              "Method": "equal",
              "Value": "Class",
              "ID": "PropertyExposers.Name"
            }
          }
         ,
          {
            "Children": [],
            "Condition": {
              "Method": "equal",
              "Value": "Gold",
              "ID": "PropertyExposers.Value"
            }
          }
        ],
        "Condition": null
      }
    ]
  },
  "connection": "b5c9085c-0a41-43ee-9460-7c5fb8076105"
}
```
