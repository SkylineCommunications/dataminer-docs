---
uid: Skyline_DataMiner_DataSources_OpenConfig_2.0.2
---

# Skyline DataMiner DataSources OpenConfig 2.0.2

## Enhancements

#### Improved request/response handling in gNMI middleware [ID_37961]

To improve the request/response handling in the gNMI middleware, a timeout time of 10 seconds has now been added. This way, if something goes wrong, DataMiner will not keep waiting for a response indefinitely. In addition, if something goes wrong, the exception will now be logged.
