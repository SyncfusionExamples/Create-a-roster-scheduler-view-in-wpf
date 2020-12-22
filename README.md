# Create a Roster Scheduler View in WPF

You can create a roster schedule view using SfScheduler in WPF. A roster schedule is a schedule that provides information about a list of employees and associated information for a given time period.

**Creating a roster scheduler**

**Step 1:** Following the getting started [UG documentation](https://help.syncfusion.com/wpf/scheduler/getting-started), create a WPF application and then add **SfScheduler** control in it.

**Step 2:** Make the following property changes in the add instance of SfScheduler:

* Set scheduler [ViewType](https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Scheduler.SfScheduler.html#Syncfusion_UI_Xaml_Scheduler_SfScheduler_ViewType) property as **TimelineMonth**.
* Add the resources data and bind it to scheduler using [ResourceCollection](https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Scheduler.SfScheduler.html#Syncfusion_UI_Xaml_Scheduler_SfScheduler_ResourceCollection) property.
* Enable resource view by setting the [ResourceGroupType](https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Scheduler.SfScheduler.html#Syncfusion_UI_Xaml_Scheduler_SfScheduler_ResourceGroupType) property as **Resource**.

**Step 3:** Customize the appearance of the appointment using [AppointmentTemplate](https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Scheduler.ViewSettingsBase.html#Syncfusion_UI_Xaml_Scheduler_ViewSettingsBase_AppointmentTemplate), as explained in the following code example.

**Step 4:** Make the following property changes in **TimelineViewSettings**, 

* By using the [ViewHeaderDateFormat](https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Scheduler.TimeSlotViewSettings.html#Syncfusion_UI_Xaml_Scheduler_TimeSlotViewSettings_ViewHeaderDateFormat) property, customize the view header date format as required. 
* Default visible resource count is 3, you can customize it by using [VisibleResourceCount](https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Scheduler.ViewSettingsBase.html#Syncfusion_UI_Xaml_Scheduler_ViewSettingsBase_VisibleResourceCount) property.

``` xml 
        <syncfusion:SfScheduler 
            ViewType="TimelineMonth" 
            ResourceGroupType="Resource">
            <syncfusion:SfScheduler.TimelineViewSettings>
                <syncfusion:TimelineViewSettings>
                    <syncfusion:TimelineViewSettings.AppointmentTemplate>
                        <DataTemplate>
                            <Grid>
                                <Label Foreground="Black" FontWeight="Bold" Content="{Binding Subject}" Grid.Row="0" HorizontalContentAlignment="Center" VerticalContentAlignment="Top"/>
                                <Border Background="{Binding AppointmentBackground}" CornerRadius="5" Height="10" Width="10" HorizontalAlignment="Center" VerticalAlignment="Center" />
                            </Grid>
                        </DataTemplate>
                    </syncfusion:TimelineViewSettings.AppointmentTemplate>
                </syncfusion:TimelineViewSettings>
            </syncfusion:SfScheduler.TimelineViewSettings>
        </syncfusion:SfScheduler>
```

``` c# 
            scheduler.TimelineViewSettings.ViewHeaderDateFormat = "dd";
            scheduler.TimelineViewSettings.VisibleResourceCount = 5;
```

**Output**

![RosterSchedulerView](https://github.com/SyncfusionExamples/Create-a-roster-scheduler-view-in-wpf/blob/main/ScreenShot/wpf-roster-scheduler-view.png)



