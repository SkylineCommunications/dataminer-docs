---
uid: ClassLibraryMonitorsStoppingAStoppedMonitor
---

# Stopping a stopped monitor

If you try to stop a monitor that has not been started yet, you will receive an InvalidOperation exception. This serves to indicate that you may have tried stopping, for example, a Value Monitor while you previously started an AlarmLevel Monitor.

If you wish to stop monitors regardless of whether you have previously started one, you can do so by performing the StopMonitor method with the force boolean set to true; in that case, no InvalidOperation exception will be thrown.
