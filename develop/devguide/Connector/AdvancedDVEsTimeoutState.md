---
uid: AdvancedDVEsTimeoutState
---

# Timeout state

DVEs are by default not set into timeout when the main element is set into timeout. If you want an automatic timeout on the DVE when the main element is in timeout, you have to specify the following in the protocol:

```xml
<Type overrideTimeoutDVE="true" >
```

It is also possible to set the timeout state in a QAction using the change communication state notify NT_CHANGE_COMMUNICATION_STATE (249). See [NT_CHANGE_COMMUNICATION_STATE (249)](xref:NT_CHANGE_COMMUNICATION_STATE).
