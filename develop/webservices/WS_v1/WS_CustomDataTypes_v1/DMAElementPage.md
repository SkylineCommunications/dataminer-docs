---
uid: DMAElementPage
---

# DMAElementPage

| Item                | Format          | Description        |
|---------------------|-----------------|--------------------|
| DataMinerID         | Integer         | The ID of the DataMiner Agent. |
| ElementID           | Integer         | The ID of the element. |
| Name                | String          | The name of the Data Display page. |
| AlarmState          | String          | The current alarm state of the Data Display page. |
| Position            | Integer         | The position of the page in the list of pages of the element specified in *ElementID*. |
| Children            | Array of string | The subpages of this page. |
| IsSeparator         | Boolean         | Whether the page is an actual page or merely a separator. |
| IsPopup             | Boolean         | Whether or not the page is a pop-up page. |
| IsWeb               | Boolean         | Whether or not the page is a webpage. |
| IsSpectrum          | Boolean         | Whether or not the page is a spectrum page. |
| IsGeneralParameters | Boolean         | Whether or not the page is a “General Parameters” page. |
| Url                 | String          | If *IsWeb* is true, this field contains the URL of the web page. |
| LastChangeUTC       | Long integer    | The time when the page was last changed, in UTC format (milliseconds since midnight January 1, 1970 GMT). |
