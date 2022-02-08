---
uid: DashboardTriggerFeed
---

# Trigger feed

This dashboard feed allows you to trigger other components either manually or automatically. Available from DataMiner 10.2.0/10.1.1 onwards.

At present, this feed can only be used as a filter feed for a component using a query feed. It will function as a refresh trigger for that component.

To configure the trigger feed:

1. Optionally, customize the following component options in the *Component* > *Settings* tab:

   - *Trigger timer*: Determines whether a countdown bar will be displayed to the next time the trigger goes off.

   - *Time*: If *Trigger Timer* is selected, this setting determines after how many seconds the data is refreshed. By default, this is set to 60 seconds.

1. Optionally, fine-tune the component layout. In the *Component* > *Layout* tab, the following options are available:

   - The default options available for all components. See [Customizing the component layout](xref:Configuring_dashboard_components#customizing-the-component-layout).

   - *Label*: Allows you to specify text that should be displayed on the trigger button.

   - *Icon*: Allows you to select which icon will be displayed on the trigger button.

   - *Show when the last trigger happened*: Select this option to have the component display when the trigger last went off.

   - *Time description format*: If *Show when the last trigger happened* is selected, in this box you can customize the format in which the time when the trigger last went off is displayed. The following placeholders are supported in this format:

     | Placeholder | Description    |
     |-------------|----------------|
     | {duration}  | The approximate time since the trigger last went off. Example: “2 minutes ago” |
     | {time}      | The exact time when the trigger last went off. Example: “Nov 20, 2020, 12:33”  |

   - *Align*: Determines whether the label and icon are displayed on the left side, in the middle or on the right side of the component.
