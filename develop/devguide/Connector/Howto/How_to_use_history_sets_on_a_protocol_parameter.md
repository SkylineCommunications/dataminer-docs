---
uid: How_to_use_history_sets_on_a_protocol_parameter
---

# How to use history sets on a protocol parameter

Below, you can learn how to implement the flow to store value changes in the past using parameter history sets.

## User skills required

- Basic knowledge of drivers.
- Basic knowledge of how to use DataMiner Cube.

## What is a history set?

A history set allows a protocol to set a parameter of an element with values for a specific time in the past. This allows DataMiner to create accurate trend graphs even if the data is not retrieved in real time.

Below you can find a use case to further illustrate the concept and its requirements.

## Use case

Imagine an API where only historical data can be retrieved. Each API call must contain a time frame for which we would like to receive the data of the desired KPI. The API will return all changes that happened to the requested KPI within this time frame, each change accompanied by its respective timestamp. We will do an API call every 5 minutes and use the history set on the DataMiner parameter in such a way that the trending is filled in and average trending is calculated correctly.

The procedure below can be used to handle the history sets for a KPI that has changed multiple times within the same time frame.

## How to

Steps:

1. Allow history sets.
1. Sort the incoming data based on the timestamp.
1. Perform the history sets.

### Allow history sets

In order to make sure the sets are correctly stored and linked with the provided timestamp, the parameter must allow changes in the past. You can configure this by using the attribute historySet on the parameter. For example:

```xml
<Param id="1" trending="true" historySet="true">
```

> [!NOTE]
> When this attribute is not present, it is possible that the data is not stored correctly, and an incorrect result can be shown when the historical data is accessed, e.g. via a trend graph.

### Sort the incoming data based on the timestamp

When average trending is enabled in DataMiner, multiple parameter values in a fixed time slot (e.g. 5 minutes) are averaged. If the values were to be set in a random order, the average calculation and update of the database would have to be done every time a new data point is added. To reduce the load on the system and database, a safety mechanism is in place: values can only be set in chronological order. Once we set a value with timestamp x, we can no longer set a parameter value with a timestamp older than x.

Because of this, it is important to sort the incoming data, so that the history sets can be performed (via QActions) in chronological order.

### Perform the history sets

A history set can only be done via a QAction. This is similar to performing any other set on a parameter, with the addition of the date and time (DateTime format).

Refer to [History sets](xref:MonitoringTrending#history-sets) for an overview of the methods that can be used to perform a history set.

## Dealing with timeouts

It is tempting to use history sets to recover from a timeout. By requesting all parameters that have changed during the timeout and using a history set for them, it could be possible to restore the trend graph after a timeout.

However, for the database, a timeout acts as a parameter set. The moment a timeout happens or is resolved, these values are set. Because of this, all windows during the timeout are closed and it becomes impossible to do correct history sets.

Luckily, there is a workaround, which involves the following two steps:

1. As you have timestamps for each set, you can detect when the device is in timeout yourself. Add an extra read parameter to indicate the connection state: Responding (value 0) or Timeout (value 1). To determine if the device is responding, verify the last received timestamp. Make sure this parameter can be monitored, so that an alarm can be raised when the state is equal to Timeout.

1. Disable the native timeout feature on the DataMiner element. That way, the element will never go into the timeout state. This avoids the timeout sets in the database and enables history sets within that time period. To do this, edit the element, open the *More [type of connection]* settings section, and clear the check box *Include timeout*.
