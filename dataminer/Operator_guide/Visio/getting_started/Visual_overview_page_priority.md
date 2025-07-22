---
uid: Visual_overview_page_priority
---

# Visual overview page priority

When a visual overview is (re)loaded in DataMiner, the page to be displayed is determined in the following way (top-down):

1. If a visual overview is reloaded automatically (e.g. after a save operation), then the page that is displayed is the one that was last selected before the reload.

1. During a forward/back operation between visual overviews (e.g. when navigating from one element to another), the displayed page is the page that was selected the last time a particular drawing was displayed.

1. If a visual overview is opened after you click a shape containing a link in which a particular page has been specified, then that particular page is displayed.

1. If a visual overview is opened after you click a shape containing a link in which no particular page has been specified, then DataMiner tries to find a page in the current visual overview that has the same name as the page where the link was clicked.

1. If a default page selection was enforced when the Visio drawing was assigned, the default page is always displayed. See [Switching between different Visio files](xref:Managing_Visio_files_linked_to_protocols#switching-between-different-visio-files).

1. If no specific page could be determined by means of the above-mentioned rules, then the first page of the visual overview is displayed.
