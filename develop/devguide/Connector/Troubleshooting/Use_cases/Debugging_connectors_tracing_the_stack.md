---
uid: Debugging_connectors_tracing_the_stack
---

# Debugging connectors: Tracing the stack

This use case focuses on a connector, *Cisco IP SLA CMP-Jitter*, that threw exceptions after a DataMiner update. Based on the *Protocol.xml* file and the log files showing the exceptions, we will try to find the root cause of the problem.

>*“In solving a problem of this sort, the grand thing is to be able to reason backwards.” – Sherlock Holmes*

When you are trying to fix a problem, one of the key principles in finding the root cause is being able to work backwards. When you give someone a sequence of events, most people can tell you what will eventually happen. But in this case, what you need to do is see the result and try to reason backwards, analytically.

This means that at this point, you should not focus too much on the exact point when the issues started happening. While it is certainly an interesting clue that it happened after a DMA restart, it is not the starting point for your investigation.

## Investigation

>*“It is a capital mistake to theorize before one has data.  Insensibly one begins to twist facts to suit theories, instead of theories to suit facts.” – Sherlock Holmes*

Let’s start by observing the problem and highlighting some information. The **element logging** is the data source you can use to see the exception and the stack trace.

![Debugging connectors TTS1](~/develop/images/Debugging_Connectors_TTS1.png)

Remember that you should always **read a stack trace from bottom to top.** The best information is usually at the bottom.

From the logging illustrated above, you can recover the following information:

- A QAction triggered by parameter 108 is failing.

- The problem happened inside the *Run* method.

- The problem happened because of a *Convert.ToInt64* method.

- There is a failure to convert “something” to an Int64.

From this, you can move on to finding the QAction and taking a closer look at the code to try and find this *Convert* call. This means you now need to dive into the **Protocol.xml**.

![Debugging connectors TTS2](~/develop/images/Debugging_Connectors_TTS2.png)

In the image above, you can see that QAction 61 is the QAction we are looking for. Let’s take a closer look at this.

![Debugging connectors TTS3](~/develop/images/Debugging_Connectors_TTS3.png)

As you can see, there are a lot of conversions. So now what you need to discover is which one of these is responsible.

For this, you will need to engage in the good old art of **deduction**. As *Convert.ToInt64* changes “something” into an INT64 or a number, the only way this can fail is if this “something” is not a number.

With this in mind, take another look at the *Protocol.xml* and check every parameter called from the QAction until you notice one that is different. In this case, parameter 80 is defined as a string internally instead of as a number like the other ones.

![Debugging connectors TTS4](~/develop/images/Debugging_Connectors_TTS4.png)

A closer look at this parameter and the corresponding write parameter yields the following information:

- Parameter 80 is the only parameter getting converted that is defined as a string instead of a number.

- The parameter is saved, so once data is filled in, it will always have a value.

- There is a “Discreet” defined that has only two possible values, 1 or 2.

- PID 80 is only writable from a setter with the same 2 discrete options.

## Conclusion

Based on the findings above, we can state that either parameter 80 was somehow set to a non-numeric value or it was left as “Not Initialized”.

We know that setting to a non-numeric value is not possible from within the element. While it is still possible that an incorrect multiple set was done or the value as set by a script or by another element, this is unlikely. We can therefore table this possibility for now.

Then there is the possibility that the parameter being “Not Initialized” is the root cause. This can only happen if the element has just been created or if the parameter value has never been defined. However, we can easily prevent both of these possibilities from ever occurring again, so we may not need to continue to search further:

1. On the active system, a multiple set should be done that sets this parameter to 1 or 2 as required.

1. The connector must be modified so that parameter 80 is defined as a number, just like the other parameters.

1. To avoid “Not Initialized”, a *“`<DefaultValue>`”* should be used to make sure that even on initial startup the configuration parameters are already 1 or 2.

When these steps have been carried, all possible causes for the issue have been fixed.

## Tips & tricks

Based on the investigation above, the following tips & tricks are worth remembering:

- When you develop a connector, never hide the stack trace when logging errors. A stack trace is a vital tool to observe a problem and start an investigation.

- DataMiner is an interconnected system of modules and processes. You sometimes have to jump from C# to XML or maybe even to other elements or scripts when tracking down a problem.

- Always start from the problem, and reason backwards using as many hard facts as you can.
