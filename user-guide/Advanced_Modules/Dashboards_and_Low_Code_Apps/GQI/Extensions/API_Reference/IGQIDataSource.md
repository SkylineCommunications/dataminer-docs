---
uid: IGQIDataSource
---

# IGQIDataSource

The *IGQIDataSource* interface is the only required interface. It must be implemented for the class to be detected by GQI as a data source. This interface has the following methods:

| Method | Input arguments | Output arguments | Description |
|--|--|--|--|
| GetColumns | - | GQIColumn[] | The GQI will request the columns. |
| GetNextPage | GetNextPageInputArgs | GQIPage | The GQI will request data. |
