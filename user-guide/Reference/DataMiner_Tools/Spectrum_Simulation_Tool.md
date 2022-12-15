---
uid: Spectrum_Simulation_protocol
---

# Spectrum simulation protocol

To test DataMiner Spectrum Analysis, a spectrum simulation protocol is available. You can for example use it to verify the “set parameter” commands that SLSpectrum sends to the protocol, or to get a trace on the screen and test the various features of the spectrum user interface and spectrum monitoring without a real device.

> You can download this protocol from [DataMiner Dojo](https://community.dataminer.services/download/spectrum-simulation-driver/).

To use this protocol:

1. Upload the protocol in the *Protocols & Templates* app in DataMiner Cube.

1. Create an element that uses this protocol.

The element has the following data pages:

- *Spectrum Analyzer*: Displays the standard Spectrum Analysis user interface.

- *General*: Contains general information, as well as the following parameters:

  - *Track Parameter Sets*: Open the button next to this parameter to open a tracking window. This window allows you to trace which parameter sets were done. In the window, sets will only be logged if the *Track Sets* parameter is enabled. If *Track Status Sets* is also enabled, status sets (communication between SLSpectrum and the protocol, e.g. requesting a new trace) are also logged.

  - *Trace pattern*: Allows you to select a specific trace pattern instead of the default pattern. The following patterns are available:

    - *Default*: A single flat line at the center of the trace window, simulating no available signals or carriers.

    - *Jump Up*: A single spike at the center of the window, wider than the channel pattern. This can be used to simulate e.g. a band pass filter.

    - *Jump Down*: Inverse pattern of *Jump Up*. This can be used to simulate e.g. a notch filter.

    - *Channel*: A single spike in the center of the trace window, simulating a typical view of one channel.

    - *Band*: A set of 8 spikes spread over the trace window, simulating a band with several channels.

  - *Floor*: A single line in the lower part of the trace window, simulating no available signals or carriers.

  - *Noise*: Allows you to disable noise in the simulated pattern.

  - *Noise depth*: Allows you to modify the amount of random noise added to the simulated pattern, so that you can for instance simulate environments with poor reception.

  - *Mirror Values*: This page shows the current values of the spectrum interfacing parameters, and allows you to change them as if they were changed directly on the device. Note that the protocol will automatically sync start/stop frequency or center frequency/frequency span if one of these settings is changed.
