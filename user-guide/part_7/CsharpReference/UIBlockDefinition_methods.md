## UIBlockDefinition methods

- [AddCheckBoxListOption](#addcheckboxlistoption)

- [AddDropDownOption](#adddropdownoption)

- [AddRadioButtonListOption](#addradiobuttonlistoption)

- [ToCode](#tocode)

- [ToString](#tostring)

#### AddCheckBoxListOption

Adds an entry to a checkbox list. Available from DataMiner 9.6.6 onwards.

UIBlockType: [CheckBoxList](UIBlockType_enumeration.md#checkboxlist)

```txt
void AddCheckBoxListOption(string def)
void AddCheckBoxListOption(string rawValue, string displayValue)
```

Example:

```txt
UIBlockDefinition blockItem = new UIBlockDefinition();

blockItem.Type = UIBlockType.CheckBoxList;

blockItem.AddCheckBoxListOption("1","First option");
blockItem.AddCheckBoxListOption("2","Second option");

uibDialogBox1.AppendBlock(blockItem);
```

#### AddDropDownOption

Adds an entry to a drop-down list.

UIBlockType: [DropDown](UIBlockType_enumeration.md#dropdown)

```txt
void AddDropDownOption(string def)
void AddDropDownOption(string rawValue, string displayValue)
```

Example:

```txt
UIBlockDefinition blockItem = new UIBlockDefinition();

blockItem.Type = UIBlockType.DropDown;

blockItem.AddDropDownOption("option_a","First option");
blockItem.AddDropDownOption("option_b","Second option");
...
uibDialogBox1.AppendBlock(blockItem);
```

#### AddRadioButtonListOption

Adds an entry to a radio button list. Available from DataMiner 9.6.6 onwards.

UIBlockType: [RadioButtonList](UIBlockType_enumeration.md#radiobuttonlist)

```txt
void AddRadioButtonListOption(string option)
void AddRadioButtonListOption(string rawValue, string displayValue)
```

Example:

```txt
UIBlockDefinition uibDef = new UIBlockDefinition();
uibDef.Type = UIBlockType.RadioButtonList;
...
if (initialValue == InitialDropDownValue)
{
 uibDef.AddRadioButtonListOption(InitialDropDownValue);
}
foreach (string sOption in dropDownOptions)
{
 uibDef.AddRadioButtonListOption(sOption);
}
```

#### ToCode

Returns a string representation of the dialog box item.

```txt
string ToCode()
```

Example:

```txt
UIBlockDefinition numericBlock = new UIBlockDefinition();
numericBlock.Type = UIBlockType.Numeric;
numericBlock.InitialValue = "5";
numericBlock.DestVar = "num";
numericBlock.WantsOnChange = true;
numericBlock.Row = 0;
numericBlock.Column = 1;
numericBlock.HorizontalAlignment = "Center";
numericBlock.VerticalAlignment = "Top";
numericBlock.RangeHigh = 300;
numericBlock.RangeLow = 5;
numericBlock.RangeStep = 5;
numericBlock.Decimals = 6;
numericBlock.Extra = "Discreet 1;Discreet 2;Discreet 3";

string result = numericBlock.ToCode();

// result:
// [UI]
// type=numeric
// column = 1
// row=0
// range-low=5
// range-high=300
// range-step=5
// decimals=6
// align-hor=Center
// align-ver=Top
// initial = 5
// destvar=num
// extra = Discreet 1; Discreet 2;Discreet 3
// onchange=true
// [/UI]
```

#### ToString

Returns a string representation of the specified block type

```txt
string ToString()
```

Example:

```txt
string type = UIBlockDefinition.ToString(UIBlockType.Parameter); // type = "parameter".
```
