﻿

#pragma checksum "D:\BackupBusIndia\BusIndia_Universal_17-04-15\BusIndia_Universal\BusIndia_Universal.WindowsPhone\BusSearchDepartureCity.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "31FC4715660ECE7986ECB162F5A08A13"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BusIndia_Universal
{
    partial class BusSearchDepartureCity : global::Windows.UI.Xaml.Controls.Page, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 143 "..\..\BusSearchDepartureCity.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.Selector)(target)).SelectionChanged += this.ListMenuItems_SelectionChanged;
                 #line default
                 #line hidden
                #line 143 "..\..\BusSearchDepartureCity.xaml"
                ((global::Windows.UI.Xaml.FrameworkElement)(target)).LayoutUpdated += this.ListMenuItems_LayoutUpdated;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 130 "..\..\BusSearchDepartureCity.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).LostFocus += this.txtSerchCity_LostFocus;
                 #line default
                 #line hidden
                #line 130 "..\..\BusSearchDepartureCity.xaml"
                ((global::Windows.UI.Xaml.Controls.TextBox)(target)).TextChanged += this.txtSerchCity_TextChanged;
                 #line default
                 #line hidden
                break;
            case 3:
                #line 115 "..\..\BusSearchDepartureCity.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).Tapped += this.imgClose_Tapped;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}


