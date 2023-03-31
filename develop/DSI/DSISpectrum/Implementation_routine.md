---
uid: Implementation_routine
---

# Implementation routine

Certain routines must be followed in a spectrum analyzer driver.

- When parameter 64118 has value 1 (settings done), you need to execute the commands that configure new settings on the spectrum analyzer.

- When parameter 64116 has value 1 (applied settings), you need to execute the command that retrieves the trace.

- By default, we use 401 as the number of points in the trace. You may need to configure the spectrum analyzer (send command) to use 401 points. Parameter 64001 contains the trace data, so there too you need to specify the number of points in the range tag (0 to 401). This parameter is of type string because the trace data (points) are passed by means of a comma-separated string. Note that this parameter expects values in dBm.

	```xml
	<Param id="64001">
	   <Name>Trace Data</Name>
	   <Description></Description>
	   <Type>read</Type>
	   <Interprete>
	      <RawType>other</RawType>
	      <LengthType>next param</LengthType>
	      <Type>string</Type>
	   </Interprete>
	   <Display>
	      <RTDisplay>true</RTDisplay>
	      <Units></Units>
	      <Decimals></Decimals>
	      <Steps></Steps>
	      <Range>
	         <Low>0</Low>
	         <High>401</High>
	      </Range>
	      <Positions>
	         <Position>
	            <Page></Page>
	            <Row></Row>
	            <Column></Column>
	         </Position>
	      </Positions>
	   </Display>
	```

- To allow conversion of units, the following parameters need to be defined in the protocol:

	```xml
	<Param id="64024">
	   <Name>dBmV Conversion Factor</Name>
	   <Description>dBmV Conversion Factor</Description>
	   <Type>read</Type>
	   <Interprete>
	      <RawType>numeric text</RawType>
	      <LengthType>fixed</LengthType>
	     <Length>5</Length>
	      <Type>double</Type>
	     <Value>48.75</Value>
	   </Interprete>
	  ...
	<Param/>
	<Param id="64025">
	   <Name>dBuV Conversion Factor</Name>
	   <Description>dBuV Conversion Factor</Description>
	   <Type>read</Type>
	   <Interprete>
	      <RawType>numeric text</RawType>
	      <LengthType>fixed</LengthType>
	     <Length>6</Length>
	      <Type>double</Type>
	     <Value>108.75</Value>
	   </Interprete>
	  ...
	<Param/>
	```

- Spectrum traces are requested through SLSpectrum. When no trace is returned, a new trace will be requested after a certain amount of time:

    - When specified, the number of ms taken from parameter 64026 (timeout time).

    - When the above does not apply: 4 times the sweep time (at least 500 ms).

    - Never longer than 2 minutes.

- Note that the spectrum analyzer module is a multi-user module. When no trace is returned for user A, the next requested trace will be for user B. Per user/monitor, the settings are stored and sent to the device when necessary before a trace is requested. Settings and trace are requested before going to a different user.

- Either start and stop frequency, or frequency span and center frequency are used to determine the frequency settings. Only one of these pairs should be used. If both pairs are used, priority is given to start/stop frequency, and center/span will not work properly.

- Frequency settings should be within the range defined on the parameter, otherwise “Invalid Settings (Parameter name)” will be shown in the spectrum analyzer display.

- After setting parameter 64118 (set parameters), SLSpectrum will wait for some time for the 64xxx read parameters to be adjusted (read back from device). After this read back, it will continue with other functions. This means that if the device does not send a response on a change settings command, the settings have to be requested by the protocol.

- DependencyID/DependencyValues do not work on 64xxx parameters.

	![](~/develop/images/spectrum_1.png)

	<br><br>

	![](~/develop/images/spectrum_2.png)

-  Parameter 64118: this will change with the settings that need to be sent to the device. Every client can have different settings for the same protocol/device. The way this is handled is:

    - SLSpectrum keeps track of what settings each client has visible

    - SLSpectrum chooses to 'update client 1'

        - SLSpectrum sends all the settings configured by client 1 to 64118.

        - Driver should then detect that change, grab all the settings, send the command(s) to the device to set THESE settings.

        - SLSpectrum will then set 64116 to 1, requesting a trace.

        - Driver then performs the (SWEEP +) TRACE commands as indicated above and sets the trace in parameter 64001.

        - SLSpectrum grabs the trace, and updates client 1.

    - SLSpectrum will then choose to update a different client.

    - The cycle continues.

- The delay timer between SWEEP & TRACE

    - Driver should GET the SWEEP TIME from the device

    - Uses a fixed timer of 100 ms that uses a 'non-poll' group.

    - Every time a trace is requested from SLSpectrum (64116) it copies the SWEEP TIME into a parameter (sweep time counter) in ms.

    - The timer should decrement the "sweep time counter" with 100 ms.

    - If the "sweep time counter" is \< 0 then the device performs the Trace command.
