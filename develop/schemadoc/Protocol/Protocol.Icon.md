---
uid: Protocol.Icon
---

# Icon element

Defines the icon that is to be used in the Applications list in the DataMiner Cube Surveyor.

## Type

[TypeNonEmptyString](xref:Protocol-TypeNonEmptyString)

## Parent

[Protocol](xref:Protocol)

## Remarks

For DataMiner apps, it is possible to define the icon that is to be used in the Applications list in the DataMiner Cube Surveyor (and in the top left corner of the visual overview of the app).

The Icon element should contain XAML inside a CDATA tag defining the icon.

## Examples

```xml
<Icon>
	<![CDATA[
	<Viewbox Width="13.877" Height="14.005"
		xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
		xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">

		<Canvas xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
			xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
			x:Name="_6x16__ateme" Width="21.3333" Height="21.3333" Clip="F1 M 0,0L 21.3333,0L 21.3333,21.3333L 0,21.3333L 0,0" UseLayoutRounding="False">
			<Canvas x:Name="_6x16_ateme" Width="21.3333" Height="21.3333" Canvas.Left="0" Canvas.Top="0">
				<Rectangle x:Name="Rectangle" Width="7.74185" Height="1.42273" Canvas.Left="12.9776" Canvas.Top="9.18704" Stretch="Fill" Fill="#FFFFFF"/>
				<Rectangle x:Name="Rectangle_0" Width="8.34604" Height="1.42267" Canvas.Left="12.9949" Canvas.Top="16.5773" Stretch="Fill" Fill="#FFFFFF"/>
				<Rectangle x:Name="Rectangle_1" Width="8.34601" Height="1.42273" Canvas.Left="11.5937" Canvas.Top="12.787" Stretch="Fill" Fill="#FFFFFF"/>
				<Path x:Name="Path" Width="20.6431" Height="14.9036" Canvas.Left="0" Canvas.Top="3.07307" Stretch="Fill" Fill="#FFFFFF" Data="F1 M 18.9913,7.18228L 20.6431,7.18228L 20.3493,6.70332C 19.0128,4.46279 16.5743,3.07307 13.9835,3.07307C 11.6527,3.07307 9.50576,4.13742 8.09313,5.99331L 7.96851,6.15632L 5.90985,6.15632C 2.65145,6.15632 0,8.80777 0,12.0662C 0,15.3253 2.65145,17.9767 5.90985,17.9767L 11.619,17.9767L 11.619,16.5715L 5.90985,16.5715C 3.42547,16.5715 1.40455,14.5506 1.40455,12.0662C 1.40455,9.58179 3.42547,7.56087 5.90985,7.56087L 8.34305,7.56087C 8.5822,7.56087 8.80315,7.44028 8.93316,7.23887C 10.0474,5.50963 11.9356,4.47761 13.9835,4.47761C 16.0179,4.47761 17.8731,5.48403 18.9913,7.18228 Z "/>
			</Canvas>
		</Canvas>
	</Viewbox>
	]]>
</Icon>
```
