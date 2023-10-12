---
uid: IGQIOnInit
---

# IGQIOnInit

The *IGQIOnInit* interface is called when the data source is initialized, for example when the data source is selected in the query builder or when a dashboard using a query with ad hoc data is opened. It can for instance be used to connect to a database. This interface has one method:

| Method | Input arguments | Output arguments | Description |
|--|--|--|--|
| OnInit | OnInitInputArgs | OnInitOutputArgs | Indicates that an instance of the class has been created. |
