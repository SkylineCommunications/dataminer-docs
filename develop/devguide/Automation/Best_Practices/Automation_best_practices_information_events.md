---
uid: Automation_best_practices_information_events
---

# Generating information events

To make sure your on-premises databases remain in good shape and do not get cluttered with unnecessary data, or to ensure a cost-efficient solution in case you make use of Storage as a Service, it is important to avoid producing unnecessary information events. As a general rule of thumb, when developing automation scripts, use information events in a meaningful way to do **audit trailing for events that are useful for end users**, e.g. CRUD actions on DataMiner objects such as "Start booking" or "Script x executed by y". Do not use them if they are only useful to you as a DevOps engineer creating the scripts in order to debug a flow.

Keep the following best practices in mind:

- Avoid *Engine.GenerateInformation* for tracing. While it is very informative to see the progress of a script that is running, if you have a script that runs a lot, this quickly becomes overhead.

  Instead, use *engine.Log* for tracing. This way, instead of generating information events, you will add lines in the Automation log file. If for some reason, you want convert these log lines to information events for a short amount of time, consider using preprocessor directives, or make a wrapper that allows you to quickly switch between information events and log lines.

  We also recommend keeping the trace logging to a minimum to prevent the Automation log file from being spammed. Using preprocessor directives, you can quickly enable and disable the trace logging for specific scripts when investigating problems.

- Avoid generating information events when your script executes sets.

  By default, DataMiner generates an information event when an automation script executes a set operation. If at all possible, avoid the generation of these information events by using the [Engine.SetFlag](xref:Skyline.DataMiner.Automation.Engine.SetFlag(Skyline.DataMiner.Automation.RunTimeFlags)) method.

- Avoid generating information events at the start and end of a subscript.

  By default, DataMiner generates an information event when an automation script is started and when it finishes.

  In case you run the script from code, you can add `SKIP_STARTED_INFO_EVENT:TRUE` in the options array of the *ExecuteScriptMessage* message.

  If you have created an automation script that launches subscripts, use the [SkipStartedInfoEvent](xref:Skyline.DataMiner.Automation.SubScriptOptions.SkipStartedInfoEvent) option so that these information events are not generated for the subscripts. From DataMiner 10.4.12/10.5.0 onwards, these information events will be skipped by default. <!-- RN 40867 -->
