---
uid: General_Main_Release_10.4.0_CU7
---

# General Main Release 10.4.0 CU7 - Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

*No enhancements have been added to this release yet.*

### Fixes

#### GQI: Problems with persisting GQI sessions and incorrectly serialized GenIfAggregateException messages [ID_40333]

<!-- MR 10.4.0 [CU7] - FR 10.4.9 -->

When the user's SLNet connection was lost, the GQI session of a query with real-time updates enabled would incorrectly persist, potentially causing both an unhandled exception to be thrown when GQI tried to send an update to the user and SLHelper to crash.

Also, *GenIfAggregateException* messages would not be serialized correctly, causing the following exception to be added to the SLHelperWrapper log file:

```txt
2024/07/25 15:25:35.636|SLNet.exe|SendMessage|ERR|0|264|System.Reflection.TargetInvocationException: Exception has been thrown by the target of an invocation. ---> System.Runtime.Serialization.SerializationException: Member 'InnerExceptions' was not found.
   at System.Runtime.Serialization.SerializationInfo.GetElement(String name, Type& foundType)
   at System.Runtime.Serialization.SerializationInfo.GetValue(String name, Type type)
   at Skyline.DataMiner.Analytics.GenericInterface.GenIfAggregateException..ctor(SerializationInfo info, StreamingContext context)
```
