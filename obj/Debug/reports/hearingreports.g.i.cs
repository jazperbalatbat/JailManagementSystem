﻿#pragma checksum "..\..\..\reports\hearingreports.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "605B99533D0524F6918B5B81C65DDAB37578EEFE"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using JailManagementSystem.reports;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Transitions;
using Microsoft.Reporting.WinForms;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace JailManagementSystem.reports {
    
    
    /// <summary>
    /// hearingreports
    /// </summary>
    public partial class hearingreports : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 46 "..\..\..\reports\hearingreports.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel panel_prisoner;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\reports\hearingreports.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid date;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\reports\hearingreports.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker from;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\..\reports\hearingreports.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker to;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\reports\hearingreports.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Microsoft.Reporting.WinForms.ReportViewer hearingReportViewer;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/JailManagementSystem;component/reports/hearingreports.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\reports\hearingreports.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 40 "..\..\..\reports\hearingreports.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_3);
            
            #line default
            #line hidden
            return;
            case 2:
            this.panel_prisoner = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 3:
            this.date = ((System.Windows.Controls.Grid)(target));
            return;
            case 4:
            this.from = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 5:
            this.to = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 6:
            
            #line 69 "..\..\..\reports\hearingreports.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_1);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 74 "..\..\..\reports\hearingreports.xaml"
            ((System.Windows.Forms.Integration.WindowsFormsHost)(target)).ChildChanged += new System.EventHandler<System.Windows.Forms.Integration.ChildChangedEventArgs>(this.WindowsFormsHost_ChildChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this.hearingReportViewer = ((Microsoft.Reporting.WinForms.ReportViewer)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

