---
uid: Viewing_aggregation_information
---

# Viewing aggregation information

To view aggregation rules for a particular view, open the view card in DataMiner Cube, and go to the *Aggregation* page.

> [!TIP]
> See also: [View cards](xref:View_cards).

The page consists of a header banner and two panes:

- The header banner shows data of the aggregation rules that are used by the current view.

- The left pane displays a tree view with folders containing aggregation rules.

- The right pane displays detailed aggregation information about items selected in the left pane.

To view aggregation data:

- Click a folder in the pane on the left to see data of all rules in the folder combined in one table.

- Click the \> icon next to a folder to expand it and see any subfolders or rules it contains.

- Click a rule in the pane on the left to see aggregated data for this particular rule.

  > [!NOTE]
  > If a rule is grayed out, that means it is currently disabled. In that case, no data will be shown when you click the rule.

- Use the *Search* box at the top of the list of rules to quickly find a rule.

- Click *Refresh* to manually refresh the displayed data.

  > [!NOTE]
  > If a rule has been configured to update automatically, this will happen after the configured time, even if the *Refresh* button is not used.

- At the top of the pane on the right:

  - Click *TREE* to see a table with a tree view showing the subviews for each view and their corresponding aggregation rules.

  - Click *TABLE* to see the aggregation rules for the view in a table with functions such as: a quick filter, sorting by column header, and a right-click menu to copy or export the table or parts of the table.

  > [!NOTE]
  > Whether you select *TREE* or *TABLE*, the aggregation rules will be shown in a table where each row represents a view, and each column contains the data for one particular rule.

- For any rules that have trending enabled, a trending icon is shown in the table with aggregation rule details. If you have the necessary permission to access trending, you can click the icon to open a window with detailed trending information, similar to the information shown when you drill down on a regular parameter. For more information, see [Accessing trend information from a card](xref:Accessing_trend_information_from_a_card).

> [!NOTE]
> Aggregation information can also be viewed in the Reports & Dashboards module:
>
> - For more information on reports, see [DMS Reporter](xref:reporter).
> - For more information on dashboards, see [DMS Dashboards](xref:dashboards).
