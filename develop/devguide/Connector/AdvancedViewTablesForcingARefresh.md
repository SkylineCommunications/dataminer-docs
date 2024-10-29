---
uid: AdvancedViewTablesForcingARefresh
---

# Forcing a (direct) view table refresh from within a protocol

From DataMiner 9.6.4 (RN 20300, 20577) onwards, it is possible to force a refresh of a (direct) view table displayed in DataMiner Cube from within a protocol.

To configure this, create a string parameter named "[TableName]_REFRESHVIEWFORKEY", and set its RTDisplay property to "True".

When values in a particular row have changed because of a forced poll by the user (i.e. a user clicking a row's Update, Force poll or Refresh button), then set the "[TableName]_REFRESHVIEWFORKEY" parameter to the following value: the primary key of the row in question, followed by a pipe character (`|`) and a random value (e.g. the current time).

If, for example, there is a direct view table named "View_Cable Modems", and the protocol has a parameter named "View_Cable Modems_REFRESHVIEWFORKEY", you can force an immediate update of that table in DataMiner Cube by setting that parameter to the following value: "ABCDEF|124831898" (in which “ABCDEF” is the primary key of the row and “124831898” is a random value).

> [!NOTE]
>
> - We advise you not to use this refresh mechanism too often, but to limit its use to when the contents of a row have changed because of some user action.
> - This force refresh can also be used to refresh child tables displayed in the EPM KPI list.
