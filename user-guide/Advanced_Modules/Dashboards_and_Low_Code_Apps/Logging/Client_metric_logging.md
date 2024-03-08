---
uid: Dashboards_and_Low_Code_Apps_Client_Metric_Logging
---

# Client metric logging

In client metric logging, each log line in a file represents a JSON object containing a metric. The outer object includes properties identifying the metric type, the web app it originated from, and the creation time.

| Property name | Type | Description |
|-|-|-|
| Time | long | UTC time when the metric was created |
| SourcePath | string | Path identifying the specific web app |
| MetricID | string | Key identifying the metric |
| Metric | object | The metric itself |

## Metrics

Three types of metrics are logged, each with its own properties.

### Version info

This metric contains information about the versions of the server, web APIs, and client being used.

| Property name | Type | Description |
|-|-|-|
| ClientAppVersion | string | Client version |
| ClientBuildVersion | string | Specific build of the client version |
| WebAPIVersion | string | WebAPI version |
| ServerVersion | string | Server version |
| ServerBuild | string | Specific build of the server version |


### Dashboard load time

This metric tracks the initial load time of a dashboard, including pages and panels of Low Code Apps, but excluding load times during dashboard or app editing.

| Property name | Type | Description |
|-|-|-|
| Name | string | Name of the dashboard including the folder structure where it is located |
| Time | int | Actual time it took to load the dashboard in milliseconds |
| Timeout | bool | Indicates if measurement was stopped due to excessive duration. When true, it means the dashboard took at least the indicated time to load |

### Uncaught error

All uncaught errors are logged to facilitate debugging hard-to-reproduce issues and to proactively identify problems.

| Property name | Type | Description |
|-|-|-|
| Times | int | Amount of times the error occured before it was logged. Once logged, no new metric for the exact same error is created in the same session |
| Name | string | Name of the error |
| Message | string | Error message |
| Stacktrace | string | Stacktrace of the error |