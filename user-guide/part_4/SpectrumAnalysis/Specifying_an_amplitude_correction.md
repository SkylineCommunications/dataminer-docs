## Specifying an amplitude correction

You can specify an amplitude correction in order to e.g. compensate for amplitude slope or/and other amplitude distortions on the cable path to a spectrum analyzer.

Specifying an amplitude correction is done by defining a set of frequency/amplitude offset pairs for a spectrum analyzer measurement point. Those are then interpolated for the whole frequency band of the spectrum analyzer and added to the trace data for display. The more pairs are defined, the more accurate the interpolated offset curve will be.

> [!NOTE]
> The amplitude corrections are applied prior to applying any frequency offsets or spectrum trace inversions.

To specify an amplitude correction:

1. On a spectrum analyzer card, go to the *Measurement points* tab and select *Edit measurement point*.

2. In the tree view on the left, select a measurement point.

3. Open the *Advanced* section and click *Add amplitude correction*.

4. Fill in the offset in dBm.

5. Fill in the frequency, and determine its unit of measure. By default, the latter is MHz. However, you can click the underlined *MHz* field to choose a different unit of measure for the frequency: Hz, kHz, or GHz.

6. To specify another amplitude correction, click *Add amplitude correction* again and proceed according to steps 4 and 5.

7. Click *Apply* to apply your changes.
