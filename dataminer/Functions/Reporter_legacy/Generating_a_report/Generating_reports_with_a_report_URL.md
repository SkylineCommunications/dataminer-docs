---
uid: Generating_reports_with_a_report_URL
---

# Generating reports with a report URL

In a report URL, you can combine the following parameters to directly generate a report.

| Parameter       | Description                                                                 |
|-----------------|-----------------------------------------------------------------------------|
| report-element  | DmaID/ElementID                                                             |
| report-element  | DmaID/ElementID:ParameterID1,ParameterID2(rowindex,option),ParameterID3,... |
| report-format   | Output format (html, pdf, ods, csv or xml)                                  |
| report-message  | Message                                                                     |
| report-protocol | ProtocolName:ProtocolVersion                                                |
| report-template | Name of the template                                                        |
| report-title    | Title of the report (i.e., email subject)                                    |
| report-view     | ViewID                                                                      |

> [!NOTE]
>
> - A "report-element" variable has to be added for every element that has to be included in the report.
> - Instead of the DMAID/ElementID combination, you can also use the element name.
> - The "report-view" and "report-protocol" variables should only be used for report templates which can have an unspecified amount of elements.
> - All URL parameter values must be URL encoded. For more information, see <http://www.w3schools.com/tags/ref_urlencode.asp>.

## Examples of a report URLs

Example 1

```txt
http://localhost/Reports/Report.asp?report-template=trending&report-element=157%2F2& report-parameter=107%28SL*%7C1%29&report-parameter=350&report-title=Trending& report-message=This+is+a+trending+report&report-format=html
```

Example 2

```txt
http://localhost/Reports/Report.asp?report-template=MyCompany+CSV+Multiple& report-title=Report&report-message=&report-view=4& report-protocol=Microsoft+Platform%3AProduction&report-parameter=180%28SL*%7C1%29&report-parameter=350&report-format=html
```
