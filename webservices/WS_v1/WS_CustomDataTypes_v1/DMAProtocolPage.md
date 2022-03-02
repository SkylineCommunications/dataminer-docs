---
uid: DMAProtocolPage
---

# DMAProtocolPage

| Item                | Format          | Description                                                                                               |
|---------------------|-----------------|-----------------------------------------------------------------------------------------------------------|
| ProtocolName        | String          | The name of the protocol.                                                                                 |
| ProtocolVersion     | String          | The version of the protocol.                                                                              |
| Name                | String          | The name of the page.                                                                                     |
| Position            | Integer         | The position of the page in the list of pages of the protocol (zero-based).                               |
| Children            | Array of string | The subpages of this page.                                                                                |
| IsSeparator         | Boolean         | Indicates whether the page is a separator.                                                                |
| IsPopup             | Boolean         | Indicates whether the page is a pop-up page.                                                              |
| IsWeb               | Boolean         | Indicates whether the page is an embedded webpage.                                                        |
| IsSpectrum          | Boolean         | Indicates whether the page is a spectrum page.                                                            |
| IsGeneralParameters | Boolean         | Indicates whether the page is the general parameters page.                                                |
| LastChangeUTC       | Long integer    | The time when the page was last changed, in UTC format (milliseconds since midnight January 1, 1970 GMT). |
