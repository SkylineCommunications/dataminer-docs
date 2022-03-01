---
uid: GetHistogramSnapshotForView
---

# GetHistogramSnapshotForView

Use this method to retrieve a snapshot of trend data for a specified protocol parameter in the form of a histogram.

## Input

| Item            | Format  | Description                                                                                                 |
|-----------------|---------|-------------------------------------------------------------------------------------------------------------|
| Connection      | String  | The connection ID. See [ConnectApp](xref:ConnectApp) .                                                        |
| ViewID          | Integer | The ID of the view.                                                                                         |
| IncludeSubViews | Boolean | Indicates whether subviews should be included.                                                              |
| ProtocolName    | String  | The name of the protocol.                                                                                   |
| ProtocolVersion | String  | The version of the protocol.                                                                                |
| ParameterID     | Integer | The ID of the parameter.                                                                                    |
| TableIndex      | String  | The table index. This field must be specified for table column parameters; otherwise it must be left empty. |
| IntervalAmount  | Integer | The number of intervals used in the histogram.                                                              |
| AsPercentages   | Boolean | Indicates whether the histogram should use percentages (= true) or absolute frequencies (= false).          |

## Output

| Item                              | Format                                                                               | Description                                         |
|-----------------------------------|--------------------------------------------------------------------------------------|-----------------------------------------------------|
| GetHistogramSnapshotForViewResult | Array of DMATrendData (see [DMATrendData](xref:DMATrendData)) | The histogram for the specified protocol parameter. |

> [!NOTE]
> The DMATrendData array includes an array of timestamps of type “long”. These values should be divided by 1000 to get the correct boundary values.

### Examples

### SOAP 1.1

##### Request:

            ```txt
            POST /API/v1/soap.asmx HTTP/1.1
            Host: localhost
            Content-Type: text/xml; charset=utf-8
            Content-Length: length
            SOAPAction: "http://www.skyline.be/api/v1/"

            <?xml version="1.0" encoding="utf-8"?>
            <soap:Envelope xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"   xmlns:xsd="http://www.w3.org/2001/XMLSchema"   xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/">
                <soap:Body>
                    <GetHistogramSnapshotForView xmlns="http://www.skyline.be/api/v1">
                        <connection>string</connection>
                        <viewID>int</viewID>
                        <includeSubViews>boolean</includeSubViews>
                        <protocolName>string</protocolName>
                        <protocolVersion>string</protocolVersion>
                        <parameterID>int</parameterID>
                        <tableIndex>string</tableIndex>
                        <intervalAmount>int</intervalAmount>
                        <asPercentages>boolean</asPercentages>
                    </GetHistogramSnapshotForView>
                </soap:Body>
            </soap:Envelope>
            ```

##### Response:

            ```txt
            HTTP/1.1 200 OK
            Content-Type: text/xml; charset=utf-8
            Content-Length: length

            <?xml version="1.0" encoding="utf-8"?>
            <soap:Envelope xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"   xmlns:xsd="http://www.w3.org/2001/XMLSchema"   xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/">
                <soap:Body>
                    <GetHistogramSnapshotForViewResponse xmlns="http://www.skyline.be/api/v1">
                        <GetHistogramSnapshotForViewResult>
                            <Avg>
                                <double>double</double>
                                <double>double</double>
                            </Avg>
                            <Min>
                                <double>double</double>
                                <double>double</double>
                            </Min> <Max>
                                <double>double</double>
                                <double>double</double>
                            </Max>
                            <Timestamps>
                                <long>long</long>
                                <long>long</long>
                            </Timestamps>
                            <StartTime>long</StartTime>
                            <EndTime>long</EndTime>
                            <Error>string</Error>
                            <Units>string</Units>
                            <Logarithmic>boolean</Logarithmic>
                            <Exceptions>
                                <DMAParameterEditDiscreet>
                                    <Display>string</Display>
                                    <Value>string</Value>
                                    <DisabledIf xsi:nil="true" />
                                </DMAParameterEditDiscreet>
                            </Exceptions>
                            <Discreets>
                                <DMAParameterEditDiscreet>
                                    <Display>string</Display>
                                    <Value>string</Value>
                                    <DisabledIf xsi:nil="true" />
                                </DMAParameterEditDiscreet>
                            </Discreets>
                        </GetHistogramSnapshotForViewResult>
                    </GetHistogramSnapshotForViewResponse>
                </soap:Body>
            </soap:Envelope>
            ```

### SOAP 1.2

##### Request:

            ```txt
            POST /API/v1/soap.asmx HTTP/1.1
            Host: localhost
            Content-Type: application/soap+xml; charset=utf-8
            Content-Length: length

            <?xml version="1.0" encoding="utf-8"?>
            <soap12:Envelope xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"  xmlns:xsd="http://www.w3.org/2001/XMLSchema"  xmlns:soap12="http://www.w3.org/2003/05/soap-envelope">
                <soap12:Body>
                    <GetHistogramSnapshotForView xmlns="http://www.skyline.be/api/v1">
                        <connection>string</connection>
                        <viewID>int</viewID>
                        <includeSubViews>boolean</includeSubViews>
                        <protocolName>string</protocolName>
                        <protocolVersion>string</protocolVersion>
                        <parameterID>int</parameterID>
                        <tableIndex>string</tableIndex>
                        <intervalAmount>int</intervalAmount>
                        <asPercentages>boolean</asPercentages>
                    </GetHistogramSnapshotForView>
                </soap12:Body>
            </soap12:Envelope>
            ```

##### Response:

            ```txt
            HTTP/1.1 200 OK
            Content-Type: application/soap+xml; charset=utf-8
            Content-Length: length

            <?xml version="1.0" encoding="utf-8"?>
            <soap12:Envelope xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"  xmlns:xsd="http://www.w3.org/2001/XMLSchema"  xmlns:soap12="http://www.w3.org/2003/05/soap-envelope">
                <soap12:Body>
                    <GetHistogramSnapshotForViewResponse xmlns="http://www.skyline.be/api/v1">
                        <GetHistogramSnapshotForViewResult>
                            <Avg>
                                <double>double</double>
                                <double>double</double>
                            </Avg>
                            <Min>
                                <double>double</double>
                                <double>double</double>
                            </Min>
                            <Max>
                                <double>double</double>
                                <double>double</double>
                            </Max>
                            <Timestamps>
                                <long>long</long>
                                <long>long</long>
                            </Timestamps>
                            <StartTime>long</StartTime>
                            <EndTime>long</EndTime>
                            <Error>string</Error>
                            <Units>string</Units>
                            <Logarithmic>boolean</Logarithmic>
                            <Exceptions>
                                <DMAParameterEditDiscreet>
                                    <Display>string</Display>
                                    <Value>string</Value>
                                    <DisabledIf xsi:nil="true" />
                                </DMAParameterEditDiscreet>
                            </Exceptions>
                            <Discreets>
                                <DMAParameterEditDiscreet>
                                    <Display>string</Display>
                                    <Value>string</Value>
                                    <DisabledIf xsi:nil="true" />
                                </DMAParameterEditDiscreet>
                            </Discreets>
                        </GetHistogramSnapshotForViewResult>
                    </GetHistogramSnapshotForViewResponse>
                </soap12:Body>
            </soap12:Envelope>
            ```

### HTTP Post:

##### Request:

            ```txt
            POST /API/v1/soap.asmx/GetHistogramSnapshotForView HTTP/1.1
            Host: localhost
            Content-Type: application/x-www-form-urlencoded
            Content-Length: length

            connection=string&viewID=string&includeSubViews=string&protocolName=string&protocolVersion=string&parameterID=string&tableIndex=string&intervalAmount=string&asPercentages=string
            ```

##### Response:

            ```txt
            HTTP/1.1 200 OK
            Content-Type: text/xml; charset=utf-8
            Content-Length: length

            <?xml version="1.0" encoding="utf-8"?>
            <DMATrendData xmlns="http://www.skyline.be/api/v1">
                <Avg>
                    <double>double</double>
                    <double>double</double>
                </Avg>
                <Min>
                    <double>double</double>
                    <double>double</double>
                </Min>
                <Max>
                    <double>double</double>
                    <double>double</double>
                </Max>
                <Timestamps>
                    <long>long</long>
                    <long>long</long>
                </Timestamps>
                <StartTime>long</StartTime>
                <EndTime>long</EndTime>
                <Error>string</Error>
                <Units>string</Units>
                <Logarithmic>boolean</Logarithmic>
                <Exceptions>
                    <DMAParameterEditDiscreet>
                        <Display>string</Display>
                        <Value>string</Value>
                        <DisabledIf>
                            <ParameterID>int</ParameterID>
                            <Value>string</Value>
                        </DisabledIf>
                    </DMAParameterEditDiscreet>
                </Exceptions>
                <Discreets>
                    <DMAParameterEditDiscreet>
                        <Display>string</Display>
                        <Value>string</Value>
                        <DisabledIf>
                            <ParameterID>int</ParameterID>
                            <Value>string</Value>
                        </DisabledIf>
                    </DMAParameterEditDiscreet>
                </Discreets>
            </DMATrendData>
            ```
