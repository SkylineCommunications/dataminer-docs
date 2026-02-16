---
uid: Localization
---

# Localization

- As DataMiner is used across the world, regional settings of DataMiner servers can differ (i.e., different regional cultures or locales can be in use). This means that, among others, specific formatting of dates and numbers is applied. When data is requested or sent (in particular strings that contain culture-dependent information such as numbers and dates), this must be taken into account to ensure the correct results.

    For example, suppose a DataMiner Agent requests a value from a device and the device sends back the following string: "*10.05MHz*". In this case, the device uses a dot as the decimal symbol. However, it is possible that the DataMiner Agent has regional settings applied where a comma is used as the decimal symbol. In this case, converting the numeric part of this string using Convert.ToDouble("10.05") would not result in the correct conversion, as the current local culture is used, and the current local culture assumes a comma is used as the decimal symbol. Instead, e.g., the following code should be used:

    ```txt
    Double.TryParse("10.05", NumberStyles.Float, CultureInfo.InvariantCulture, out signalStrength);
    ```

    For the same reason, when a command containing a numeric value as string is created from a QAction, conversion using culture info is necessary as otherwise the command string could be formatted incorrectly. E.g. Convert.ToString(signalStrength) could result in "10,05" where the device would expect "10.05". Therefore, additional culture info is necessary when the conversion is done:

    ```txt
    Convert.ToString(signalStrength, CultureInfo.InvariantCulture);
    ```

    > [!NOTE]
    > When the value of a protocol parameter containing a value of type double is retrieved, culture info is not required. You can use the ToDouble method, i.e., the overload that requires only the value object as parameter (defined in the Convert class (namespace System)), e.g., *double signalStrength = Convert.ToDouble(protocol.SingalStrength);*.
    >
