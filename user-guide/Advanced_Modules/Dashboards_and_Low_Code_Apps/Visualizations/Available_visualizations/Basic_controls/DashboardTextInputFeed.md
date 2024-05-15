---
uid: DashboardTextInputFeed
---

# Text input

Available from DataMiner 10.3.5/10.4.0 onwards<!--  RN 35902 -->. This basic control allows the user to enter text, which will then be available as a string feed in the dashboard or low-code app. The string feed can be used by queries and by script parameters in low-code app actions.

The following options are available to fine-tune the component layout:

- *Label*: Text that will be displayed next to the text input box.

- *Inline*: Available from DataMiner 10.3.9/10.4.0 onwards<!-- RN 36983 -->. Determines whether the label is displayed above the text input box or next to it. If this option is selected, it is displayed next to the box.

- *Placeholder*: Placeholder that will be displayed inside the text input box.

- *Icon*: Icon that will be displayed in the text input box.

In the *Settings* tab, you can also configure the following optional settings:

- *Feed value on*: Determines when the value in the box becomes available as a feed. This can be when the user presses Enter ("Enter"), when the focus is no longer on the box ("Focus lost"), or when the value in the box changes ("Value change"). If you select *Focus lost*, the value will also become available when the user presses Enter.

- *Multiline*: Determines whether the input can consist of multiple lines or not.

> [!NOTE]
> From DataMiner 10.3.0 [CU10]/10.4.1 onwards<!-- RN 37736 -->, you can drag a data feed to the component to link it to that feed, or [specify a feed in the URL](xref:Specifying_data_input_in_a_dashboard_URL). This way, the component will be filled in based on the feed, but users will still be able to modify the value.
