---
uid: Multi_Threaded_Timer_Polling_Rate_Calculator
---

# Multithreaded timer polling rate calculator

## About this tool

When a multithreaded timer is configured in a protocol, sometimes the *pollingrate* attribute is needed. Calculating the correct values for this attribute can be a bit cumbersome, as many different settings need to be taken into consideration. The PollingRate Calculator tool will make this job easier. This tool is available as a spreadsheet document.

> You can download this tool from [DataMiner Dojo](https://community.dataminer.services/download/pollingrate-calculator/).

## Usage

To use this tool, in the spreadsheet document, fill in the required parameters for your multithreaded timer. The following three KPIs are expected: "each", "Timer Timer", and "Table Rows".

Take for example the following multithreaded timer configuration:

```xml
<Timer id="1" options="ip:100,1;each:10000;threadpool:20;qactionbefore:2">
    <Name>HTTP Timer</Name>
    <Time>1000</Time>
    <Interval>0</Interval>
    <Content>
        <Group>100</Group>
    </Content>
</Timer>
```

With this configuration, the KPI parameters are respectively “10 000”, “1000” and “200”.

If you fill in these values in the PollingRate Calculator tool, the output will look like this:

![PollingRate Calculator tool](~/dataminer/images/Multi-threaded1.png)

> [!NOTE]
> The “freq.” value is an indication of how many cycles will be performed every Timer Time. Each cycle, a number of threads will be released, until all rows have been polled within the defined “each” time.

The result box will display the optimal *pollingrate* configuration. This can then be applied to the multithreaded timer, ensuring a correct spread of threads:

```xml
<Timer id="1" options="ip:100,1;each:10000;pollingrate:200,4,4;threadpool:20;qactionbefore:2">
    <Name>HTTP Timer</Name>
    <Time>1000</Time>
    <Interval>0</Interval>
    <Content>
        <Group>100</Group>
    </Content>
</Timer>
```

## Useful links

- [Multithreaded timers](xref:AdvancedMultiThreadedTimers)

- [How to configure multithreaded timers](xref:How_to_configure_multi_threaded_timers)
