---
uid: ConnectorsVissibilityChainsFields
---

# Visibility of Chains and Fields

Within the EPM Manager connector, it is possble to configure the visibility of a Chain or a Field.
To enable this functionality, it is necessary to add a `<display>` tag within the corresponding Chain or Field. Additionally, a Read-Write parameter needs to be created for each Chain or Field. This parameter will allow users to configure visibility of these items according to their requirements.

## Example Parameter

```xml
	<Param id="301" trending="false" save="true">
		<Name>chainVisibilityCustomer</Name>
		<Description>Customer Topology</Description>
		<Type>read</Type>
		<Information>...</Information>
		<Interprete>...</Interprete>
		<Display>...</Display>
		<Measurement>
			<Type>discreet</Type>
			<Discreets>
				<Discreet>
					<Display>Disabled</Display>
					<Value>1</Value>
				</Discreet>
				<Discreet>
					<Display>Enabled</Display>
					<Value>2</Value>
				</Discreet>
			</Discreets>
		</Measurement>
	</Param>
	<Param id="351" setter="true">
		<Name>chainVisibilityCustomer</Name>
		<Description>Customer Topology</Description>
		<Type>write</Type>
		<Interprete>...</Interprete>
		<Display>...</Display>
		<Measurement>
			<Type>togglebutton</Type>
			<Discreets>
				<Discreet>
					<Display>Disabled</Display>
					<Value>1</Value>
				</Discreet>
				<Discreet>
					<Display>Enabled</Display>
					<Value>2</Value>
				</Discreet>
			</Discreets>
		</Measurement>
	</Param>

```

## Example Chain

```xml
<Chain name="Customer Topology">
    <Display>
        <Visibility default="true">
            <Standalone pid="301">
                <Value>1</Value>
            </Standalone>
        </Visibility>
    </Display>
    <Field name="Customer" options="displayInFilter;showCPEChilds;ignoreEmptyFilterValues;tabs:3500-KPI;details:3500;ShowBubbleupAndInstanceAlarmLevel" pid="3502">
        <Display>
            <Selection>
                <Visibility default="true">
                    <Standalone pid="308">
                        <Value>1</Value>
                    </Standalone>
                </Visibility>
            </Selection>
        </Display>
    </Field>
    <Field name="Device" options="displayInFilter;ignoreEmptyFilterValues;tabs:2500-KPI;details:2500;ShowBubbleupAndInstanceAlarmLevel" pid="2501">
        <Display>
            <Selection>
                <Visibility default="true">
                    <Standalone pid="310">
                        <Value>1</Value>
                    </Standalone>
                </Visibility>
            </Selection>
        </Display>
    </Field>
</Chain>

```

### Chain configuration

| Tag                | Attribute  | Description                                                                                   |
|--------------------|------------|-----------------------------------------------------------------------------------------------|
| `<Visibility>`     | `default`  | Specifies if the Chain or Field should be displayed by default (`true` or `false`).           |
| `<Standalone>`     | `pid`      | Specifies the ID of the configurable parameter linked to toggle visibility.                  |
| `<Value>`        |            | Defines one of the possible values the parameter must have to toggle the visibility to the opposite setting in relation to the default attribute.        |
