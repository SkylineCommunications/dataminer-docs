---
uid: Spectrum_Analyzer_script_actions
---

# Spectrum Analyzer script actions

When you add action lines to a spectrum analyzer script, a vast array of actions is available. You can select this in the *Operation* dropdown list in the *Edit Monitor Script* pane. When you select an action, a brief description is shown below, and the input fields for the statement are adjusted to the selected action.

> [!NOTE]
> Some actions only become available if certain other actions have been used earlier in the script. E.g. the *Check Threshold* action is not available unless an action *Get Threshold* is used first.

## Variables

Below, the following abbreviations will be used to indicate the different types of variables in the script actions.

| Variable | Description                                      |
|----------|--------------------------------------------------|
| d        | double value                                     |
| int      | integer value                                    |
| str      | string                                           |
| b        | condition (true/false)                           |
| p        | preset variable                                  |
| s/t      | trace variable                                   |
| l        | threshold variable                               |
| r        | reference object (marker or frequency reference) |

From DataMiner 10.5.0 [CU12]/10.6.0/10.6.3 onwards<!--RN 44650-->, numeric input fields in spectrum script actions support values up to 1 quadrillion. This allows configuring frequency values well above 100 MHz where required. In older versions, number input fields support values up to 11 billion.

## Actions

The following table provides an overview of the available actions in spectrum scripts. For some of the actions, more information is provided below the table.

| Script action name | Script action | Description |
|--|--|--|
| // | Comment(...) | Adds a line with comments. Such lines are ignored on script execution, but can help future maintenance of scripts.<br> Example: Comment(Hello world!) |
| Assign | d = Assign(double) | Assigns a hard-coded double value. |
| Create amplitude reference (dB) | r = CreateAmpRef(d) | Creates a reference line variable representing a certain level. This variable can then be used further down the script as if it was a reference line. |
| Create boolean var | b = Bool(boolean) | Assigns a boolean. The following instructions are allowed:<br> -  b = Bool (TRUE) or b = Bool (1)<br> -  b = Bool (FALSE) or b = Bool (0) |
| Create frequency reference (Hz) | r = CreateFreqRef(d) | Creates a reference line variable representing a certain frequency. This variable can then be used further down the script as if it was a reference line or reference marker. The value should be provided in Hertz (Hz). |
| Find first frequency left | r = FindLeft(t, refFreq, refAmp, int) | Finds the first frequency level to the left of the given reference, having a level that is int dB lower than the amplitude reference refAmp.<br> E.g. *FindLeft(trace, refFreq, refAmp, 3)* and *FindRight(trace, refFreq, refAmp, 3)* can be used to find the -3dB points. |
| Find first frequency right | r = FindRight(t, refFreq, refAmp, int) | Finds the first frequency level to the right of the given reference, having a level that is int dB lower than the amplitude reference refAmp.<br> E.g. *FindLeft(trace, refFreq, refAmp, 3)* and *FindRight(trace, refFreq, refAmp, 3)* can be used to find the -3dB points. |
| Get amplitude difference between | d = Delta(s,r1,r2) | Returns the amplitude difference of a trace s measured at reference objects r1 and r2. The resulting value can be positive or negative. |
| Get amplitude level at | d = GetLevel(s,r) | Returns the amplitude level of a trace s at a reference object r. |
| N/A | d = GetLevelNoise(s,r) | Returns the amplitude level of a trace s at a reference object r \[noise level\]. |
| Get average level between | d = Avg(s,r1,r2) | Calculates the average level of a trace s between reference objects r1 and r2. |
| Get average trace | t = GetAvgTrace(p, int) | Requests a number (int) of traces using the specified preset p, and returns the average of these traces. |
| Get channel power between frequencies | d = ChannelPower(t, r1, r2) | Calculates the channel power between two frequency references on a trace. |
| Get frequency at | d = FreqAt(r) | Returns the frequency level of a trace s at a reference object r. |
| Get frequency delta between | d = FreqDelta(r1,r2) | Returns the absolute value of the frequency difference taken at reference objects r1 and r2. |
| Get frequency maximum | d = FreqMax(s) | Returns the frequency for highest measured level in trace s. |
| Get frequency minimum | d = FreqMin(s) | Returns the frequency for lowest measured level in trace s. |
| Get from preset | d = GetFromPreset(preset,<br>presetContent) | Reads the selected preset content from the given preset p. |
| Get global constant | d = GetGlobal(id) | Finds a global constant by ID. |
| Get historic average trace | t = HistAvgTrace(t, int) | Combines the given trace t with up to int-1 previously requested traces (from earlier monitor runs). The returned trace is the average of all these traces. |
| Get historic maximum trace | t = HistMaxTrace(t, int) | Combines the given trace t with up to int-1 previously requested traces (from earlier monitor runs). The returned trace is the maximum of all these traces. |
| Get historic minimum trace | t = HistMinTrace(t, int) | Combines the given trace t with up to int-1 previously requested traces (from earlier monitor runs). The returned trace is the minimum of all these traces. |
| Get low peak frequency | d = FreqPeakLow(s,r1,r2) | Returns the frequency of a trace s between reference objects r1 and r2 at which the amplitude level reaches the lowest peak. |
| Get marker from preset | r = GetMarker(p,int) | Retrieves a marker from a given preset p. The second parameter indicates which marker is requested (1..max). |
| Get maximum amplitude level for trace | d = Max(s) | Returns the maximum level measured in trace s. |
| Get maximum hold trace | t = GetMaxTrace(p, int) | Requests a number (int) of traces using the specified preset, and returns the maximum of all these traces. |
| Get minimum amplitude level for trace | d = Min(s) | Returns the minimum level measured in trace s. |
| Get minimum hold trace | t = GetMinTrace(p, int) | Requests a number (int) of traces using the specified preset p, and returns the minimum of all these traces. |
| Get parameter value | d = GetParam(parameter) | Gets a double value for a parameter of the spectrum element. |
| Get peak frequency | d = FreqPeak(s,r1,r2) | Returns the frequency of a trace s between reference objects r1 and r2 at which the amplitude level reaches the highest peak. |
| Get preset | p = GetPreset(str) | Loads a preset with name str into preset variable p.<br> -  The preset is not applied when this function is executed, it is only loaded into memory.<br> -  This function can only be used on public presets. |
| Get preset from monitor | p = GetPresetFromMonitor() | Loads the current preset for a monitor that specifies a series of preset names. This option allows a monitor to execute the script multiple times using different presets. |
| Get reference line from preset | r = GetRefline(p,int) | Retrieves a reference line from a given preset p. The second parameter indicates which reference line is requested (1..max). |
| Get start frequency for trace | d = Start(s) | Returns the start frequency for trace s. |
| Get stop frequency for trace | d = Stop(s) | Returns the stop frequency for trace s. |
| Get the highest level out of | d = Peak(s,r1,r2) | Returns the highest peak level of a trace s between reference objects r1 and r2. |
| Get the lowest level out of | d = PeakLow(s,r1,r2) | Returns the lowest peak level of a trace s between reference objects r1 and r2. |
| Get threshold from preset | l = GetThreshold(p) | Gets a threshold object from a given preset p. |
| Get trace | s = GetTrace(p) | Requests a trace s using the settings from the given preset variable p.<br> -  The preset variable p should be loaded by executing the function GetPreset(str).<br> -  This function will cause the settings stored in the preset to be applied prior to getting the trace. |
| Is condition fulfilled | b = Condition(d1>d2) | Returns the condition status between brackets.<br> Available operators: \>, \<, \<=, \>=, =, != |
| Is exceeded threshold on trace hist | b = HistCheckThreshold(s, l, amountFail, amountCheck) | Looks up the given trace together with up to int-1 previously requested traces (from earlier monitor runs), then checks all these against the given threshold. If the number of failures exceeds amountFail, true is returned. |
| Is trace above maximum threshold | b = CheckThreshold(s, l) | Checks a trace s against a threshold l. If the level of the trace is higher than the level of the threshold for one or more frequencies, the boolean b will be set to TRUE. |
| Is trace below minimum threshold | d = CheckMinThreshold(s,l) | Checks a trace s against a threshold l. If the level of the trace is lower than the level of the threshold for one or more frequencies, the boolean b will be set to TRUE. |
| Math.Abs | d = Abs(d1) | Takes the absolute value of a double value d1. |
| Math.Divide | d = Div(d1,d2) | Divides the double value d1 by d2. |
| Math.Max | d = MathMax(d1,d2) | Finds the maximum of the two given values d1 and d2. |
| Math.Min | d = MathMin(d1,d2) | Finds the minimum of the two given values d1 and d2. |
| Math.Multiply | d = Mul(d1,d2) | Multiplies the values d1 and d2. |
| Math.Rand | d = Rand(int) | Gets a random number between 0 and int. |
| Math.Subtract | d = Sub(d1,d2) | Subtracts the values d1 and d2. |
| Math.Sum | d = Sum(d1,d2) | Returns the sum of the values d1 and d2. |
| Perform logic | b = Logic(b1 \|\| b2) | Returns the result of simple logical operations. Available operators: &&, \|\| |
| Set measurement point | SetMeasPoint<br>(measPointId) | Selects the given measurement point measPointId. |
| Set parameter in preset | SetInPreset(preset, setting, value) | Sets a particular setting in the given preset to the specified value. Note that the preset itself is not updated, only its in-memory representation. This modified preset can be used to dynamically request traces with different settings. |
| Set parameter value | SetParam(parameter, value, options) | Sets a parameter on the spectrum element. By way of options, you can specify whether there should be a 1-second delay between set and verify, and whether the set should be verified. |
| Sleep (ms) | Sleep(d) | Pauses script execution for a specific number of milliseconds. From DataMiner 10.5.0 [CU12]/10.6.0/10.6.3 onwards<!--RN 44650-->, the value must be between 0 and 10,000 ms. |
| Stop script | StopScript(b) | Stops script execution if condition is true. |
