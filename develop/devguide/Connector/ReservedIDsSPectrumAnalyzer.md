---
uid: ReservedIDsSpectrumAnalyzer
---

# Spectrum analyzer

|ID|Name|Description|
|--- |--- |--- |
|64001|SPA_PARAM_TRACE_COMMA|Trace|
|64003|SPA_PARAM_FREQ_CENTER|Center frequency (read)|
|64004|SPA_PARAM_FREQ_SPAN|Frequency span (read)|
|64005|SPA_PARAM_FREQ_START|Start frequency (read)|
|64006|SPA_PARAM_FREQ_STOP|Stop frequency (read)|
|64008|SPA_PARAM_AMP_UNITS|Amplitude units (read)|
|64009|SPA_PARAM_INPUT_ATTEN|Input attenuation (read)|
|64010|SPA_PARAM_REFLEVEL|Reference level (read)|
|64011|SPA_PARAM_REFSCALE|Reference scale (read)|
|64012|SPA_PARAM_VBW|Video bandwidth (read) AUTO=-1|
|64013|SPA_PARAM_FREQBW|Freq bandwidth (read) AUTO=-1|
|64014|SPA_PARAM_RBW|Resolution bandwidth (read)|
|64015|SPA_PARAM_SWEEPTIME|Sweep time (read) AUTO=-1|
|64016|SETTINGS_DONE||
|64017|CLIENTCOUNT||
|64018|ALLCHANGESSENT||
|64019|SPA_PARAM_AUTO_VBW|Real VBW value when VBW set to Auto (read)|
|64020|SPA_PARAM_AUTO_RBW|Real RBW value when RBW set to Auto (read)|
|64021|SPA_PARAM_AUTO_SWEEP|Real SweepTime value when sweeptime set to Auto (read)|
|64022|SPA_PARAM_AUTO_ATTEN|Real input attenuation when attenuation set to Auto|
|64023|SPA_PARAM_CALIB_ERR|Indicates if the measurement is uncalibrated (1) or not (0) (read)|
|64024|SPA_PARAM_OFFSET_DBMV|Difference between dbm/dbmv (0 dbm = (64024) dbmv)|
|64025|SPA_PARAM_OFFSET_DBUV|Difference between dbm/dbuv (0 dbm = (64025) dbuv)|
|64026|SPA_PARAM_TRACETIMEOUT|Specific timeout if actual trace get time >>>> 4*sweeptime|
|64027|SPA_PARAM_UNAVAILABLE|Set to 1 when device is doing other things (which means we should not request traces)|
|64028|SPA_PARAM_UNAVAILABLE_REASON|String indicating why the spectrum analyzer is unavailable|
|64029|SPA_PARAM_PRE_AMPLIFIER|PreAmplifier (0 = disabled / 1 = enabled)|
|64030|SPA_PARAM_FIRST_MIXER_INPUT|First mixer input (analog) dbm|
|64031|SPA_PARAM_DETECTION_MODE|Detection mode|
|64032|SPA_PARAM_SCALE_TYPE|Scale type (log = 0, lin = 1)|
|64033|OBSOLETE_SPA_PARAM_NOISE_MARKER|Noise marker function (noise marker freq) // obsolete FR458|
|64034|SPA_PARAM_SETTIMEOUT|Specific "wait for 'set' to succeed" timeout (overrides the default 5s)|
|64035|OBSOLETE_SPA_PARAM_NOISE_MARKER_RES|Noise marker function result // obsolete FR458|
|64036|SPA_PARAM_OVER_RESP_NBW|Over-response noise bandwidth (to calculate marker noise levels)|
|64037|SPA_PARAM_AMOUNTPTS|Number of points to expect in traces|
|64038|SPA_PARAM_AMOUNT_HOR_DIVS|Number of horizontal divisions (default: 10)|
|64039|SPA_PARAM_AMOUNT_VER_DIVS|Number of vertical divisions (default: 10)|
|64040|SPA_PARAM_FACTOR_AUTO_VBW|(read) Factor by which auto VBW needs to be calculated. -1 to let device handle this.|
|64041|SPA_PARAM_FACTOR_AUTO_RBW|(read) Factor by which auto RBW needs to be calculated. -1 to let device handle this.|
|64051|SPA_PARAM_CONSTELLATION|(read) Constellation points x1,x2,x3|
|64052|SPA_PARAM_CONST_FREQ|(read) Input freq|
|64053|SPA_PARAM_CONST_SYMRATE|(read) Symbol rate|
|64054|SPA_PARAM_CONST_MODE|(read) QAM mode (8,16,32,64,128,256,...)|
|64055|SPA_PARAM_CONST_IFSPECTRUM|(read) IF spectrum|
|64103|SPA_WPARAM_FREQ_CENTER|Center frequency (write)|
|64104|SPA_WPARAM_FREQ_SPAN|Frequency span (write)|
|64105|SPA_WPARAM_FREQ_START|Start frequency (write)|
|64106|SPA_WPARAM_FREQ_STOP|Stop frequency (write)|
|64108|SPA_WPARAM_AMP_UNITS|Amplitude units (write)|
|64109|SPA_WPARAM_INPUT_ATTEN|Input attenuation (write)|
|64110|SPA_WPARAM_REFLEVEL|Reference level (write)|
|64111|SPA_WPARAM_REFSCALE|Reference scale (write)|
|64112|SPA_WPARAM_VBW|Video bandwidth (write)|
|64113|SPA_WPARAM_FREQBW|Freq bandwidth (write)|
|64114|SPA_WPARAM_RBW|Resolution bandwidth (write)|
|64115|SPA_WPARAM_SWEEPTIME|Sweep time (write)|
|64116|SPA_WPARAM_SETTINGS_DONE|0 (do not request trace), 1 (OK to request trace. All settings done.)|
|64117|SPA_WPARAM_CLIENTCOUNT|Number of data display/monitor clients|
|64118|SPA_WPARAM_ALLCHANGESSENT|Set to 1 after all changed parameters have been sent|
|64119 - 64128||Read-only parameters|
|64129|SPA_WPARAM_PRE_AMPLIFIER|Pre-amplifier|
|64130|SPA_WPARAM_FIRST_MIXER_INPUT|First mixer input|
|64131|SPA_WPARAM_DETECTION_MODE|Detection mode|
|64132|SPA_WPARAM_SCALE_TYPE|Scale type|
|64133|OBSOLETE_SPA_WPARAM_NOISE_MARKER|Noise marker function // obsolete FR458|
|64137|SPA_WPARAM_AMOUNTPTS|Number of points to expect in traces (write)|
|64140|SPA_WPARAM_FACTOR_AUTO_VBW|(write) Factor by which auto VBW needs to be calculated. -1 to let device handle this.|
|64141|SPA_WPARAM_FACTOR_AUTO_RBW|(write) Factor by which auto RBW needs to be calculated. -1 to let device handle this.|
|64152|SPA_WPARAM_CONST_FREQ|(write) Input freq|
|64153|SPA_WPARAM_CONST_SYMRATE|(write) Symbol rate|
|64154|SPA_WPARAM_CONST_MODE|(write) Mode|
|64155|SPA_WPARAM_CONST_IFSPECTRUM|(write) IF spectrum|
|64201|SPA_SPARAM_MODE|Status: mode change notifications -> element display|
|64202|SPA_SPARAM_FROZEN|Status: frozen state (BOOL)|
|64203|SPA_SPARAM_RECORDING|Status: recording state (BOOL)|
|64204|SPA_SPARAM_PLAY_PROGRESS|Percentage of playback completed (double)|
|64205|SPA_SPARAM_PLAY_MANUAL|Modified: playback state requires manual prev|
|64206|SPA_SPARAM_PLAY_ORIGTIME|Original time of event (String Y-m-d H:M:S)|
|64207|SPA_SPARAM_ALARM_MARKER|Special marker used in alarm recordings to indicate that the next trace is the one that generated the alarm (double; 1)|
|64208|SPA_SPARAM_MEASPOINT|Current measurement point|
|64209|SPA_SPARAM_SCRIPTRESULTS|In script mode: the script results (variable values; string)|
|64210|SPA_SPARAM_TRACENAME|Trace name (in script mode)|
|64211|SPA_SPARAM_CLIENTCOUNT|Real-time info on the number of connected clients|
|64212|SPA_SPARAM_MONITOR|Monitor info (id:estimated time). Reset to empty after monitor has run. Can also contain a full message instead of id:estimatedtime|
|64213|SPA_SPARAM_WATCH_INFO|Info about which data is currently being displayed (watch mode)|
|64214|SPA_SPARAM_INVALID_PID|Notifies Cube of a PID for which the current value is invalid|
|64215|SPA_SPARAM_UNAVAILABLE|Notifies Cube that the device is currently unavailable for measurements (string)|
|64216|SPA_SPARAM_PRESET_UPDATE|Notifies Cube that a preset got updated. Contains the name of the preset (string). Feature introduced in DataMiner 9.0.5 (RN 13968).|
|64217|SPA_SPARAM_WARN_SWEEP|Notifies Cube that it needs to display a warning to allow a sweep time > 20 sec (value = sweep time value)|
|64218|SPA_SPARAM_GENERIC_MSG|Notifies Cube with a generic message to display in the top-right corner (string "[message type id]:[message]")|
|64219|SPA_SPARAM_PROGRESS|Notifies Cube of some kind of progress (double; see SPA_PROGRESS_*)|
|64220|SPA_SPARAM_TRACEPRESET|Preset with which trace was taken (on playback). string. preset ID.|
|64221|SPA_SPARAM_HAS_RT_SLOT|0 = no more RT slots available, client will not get new traces. 1 = has slot|
|64222|SPA_SPARAM_HEARTBEAT|Heartbeat to indicate that the client is still known by SLSpectrum (sent every xs)|
|64223|SPA_SPARAM_RANGES|frequency ranges (when changed by offsets and such): startmin;startmax;centermin;centermax;stopmin;stopmax|
|64224|SPA_SPARAM_MONITOR_PRESET|current preset (when watching a buffer or alarm recording for a monitor which iterates over presets)|
