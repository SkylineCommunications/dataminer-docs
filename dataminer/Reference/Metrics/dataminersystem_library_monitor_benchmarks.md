---
uid: dataminersystem_library_monitor_benchmarks
---

# DataMinerSystem library benchmarks

> [!NOTE]
> Keep in mind that when the monitor executes heavy actions that put a load on the system, the expected latency may be much higher.

## Specifications of the test server

- Intel Xeon Silver 4110
- 8 cores (16TH) VM
- 16 GB RAM
- Windows Server 2016 Standard

## Benchmarks

### Parameter value monitor

```C#
StartValueMonitor<T>(this IDmsStandaloneParameter<T> parameter, SLProtocol protocol, Action<ParamValueChange<T>> onChange)
```

| #    | Metric |
|------|--------|
| 100  | 138 ms |
| 1600 | 258 ms |
| 3600 | 271 ms |

### Cell value monitor

```C#
StartValueMonitor<T>(this IDmsColumn<T> column, string primaryKey, SLProtocol protocol, Action<CellValueChange<T>> onChange)
```

| #     | Metric |
|-------|--------|
| 8     | 157 ms |
| 512   | 163 ms |
| 2048  | 176 ms |
| 8192  | 240 ms |
| 12800 | 246 ms |

### Column value monitor

```C#
StartValueMonitor<T>(this IDmsColumn<T> column, SLProtocol protocol, Action<ColumnValueChange<T>> onChange)
```

| #     | Metric |
|-------|--------|
| 4     | 123 ms |
| 256   | 178 ms |
| 4096  | 190 ms |
| 16384 | 245 ms |

### Table value monitor

```C#
StartValueMonitor(this IDmsTable table, SLProtocol protocol, int primaryKeyColumnIdx, Action<TableValueChange> onChange)
```

| #     | Metric  |
|-------|---------|
| 4     | 175 ms  |
| 256   | 189 ms  |
| 1024  | 232 ms  |
| 4096  | 968 ms  |
| 16384 | 7812 ms |
