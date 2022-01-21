---
uid: Roaming_support
---

# Roaming support

Mobile Gateway supports roaming calls.

### What if there was no roaming support?

If Mobile Gateway did not support roaming calls, it would refuse to connect to other networks in order to avoid roaming costs. However, this would cause a problem for full mobile virtual network operators (MVNOs), which have their own network code although they actually use the network of another operator.

When the modem searches a network using the network code of a full MVNO, it will not find any (as the network code refers to a virtual network) and will then try to connect to another network. As such, without roaming support, Mobile Gateway would not only refuse actual roaming calls, it would also refuse calls using a network code belonging to an MVNO.

> [!CAUTION]
> In areas with poor home network reception, the modem might connect to other networks, which could lead to extra costs.

### Logging

The name of the network on which the modem is registered is being logged. Newer modems will show the name of the MVNO, while older modems will show the name of the network.

Examples:

```txt
2013/07/30 16:09:25.941|Mobile Gateway|13156|7212|Info|
INF|-1|Registered on network: "NetworkOperatorName" (Roaming)
2013/07/30 16:20:58.038|Mobile Gateway|13304|10672|Info|
INF|-1|Registered on network: "MVNOName" (Roaming)
```
