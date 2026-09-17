---
metadata_version: 1
uid: AutomationActionLog
description: "Describe the DataMiner Automation development topic Log, including its purpose, behavior, implementation guidance, and relevant constraints."
area: develop
content_type: conceptual
authority: unknown
authority_source: unknown
lifecycle: active
applies_to:
  - DataMiner
version: unknown
owner: unknown
review_status: needs_update
review_date: 2026-09-17
compatibility:
  uid: stable
  url: stable
---

# Log

Creates a log message that will be saved in the SLAutomation.txt log file.

- To log a predefined message:

    ```xml
    <Exe id="2" type="logmessage">
       <Message>MyLogMessage</Message>
    </Exe>
    ```

- To log the value of a script variable:

    ```xml
    <Exe id="2" type="logmessage">
        <Message ref="param1"></Message>
    </Exe>
    ```
