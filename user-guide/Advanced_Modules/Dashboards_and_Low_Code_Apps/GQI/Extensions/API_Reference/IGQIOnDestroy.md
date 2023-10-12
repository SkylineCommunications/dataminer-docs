---
uid: IGQIOnDestroy
---

# IGQIOnDestroy

The *IGQIOnDestroy* interface is called when the instance object is destroyed, which happens when the session is closed, e.g. in case of inactivity or when all the necessary data has been retrieved. It can for instance be used to end the connection with a database. This interface has one method:

| Method | Input arguments | Output arguments | Description |
|--|--|--|--|
| OnDestroy | OnDestroyInputArgs | OnDestroyOutputArgs | Indicates that the GQI will close the session. |
