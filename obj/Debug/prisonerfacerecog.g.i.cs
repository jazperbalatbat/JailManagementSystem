﻿#pragma checksum "..\..\prisonerfacerecog.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "322549FC524872E1BDA66B462D2B3F8B030A0D3C"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using JailManagementSystem;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Transitions;
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


namespace JailManagementSystem {
    
    
    /// <summary>
    /// prisonerfacerecog
    /// </summary>
    public partial class prisonerfacerecog : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 23 "..\..\prisonerfacerecog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image face_preview;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\prisonerfacerecog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button deten_recog;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\prisonerfacerecog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label face_count;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\prisonerfacerecog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock face_persons;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\prisonerfacerecog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button face_add;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\prisonerfacerecog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox person_name;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\prisonerfacerecog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image train_image;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\prisonerfacerecog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button train_detect;
        
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
            System.Uri resourceLocater = new System.Uri("/JailManagementSystem;component/prisonerfacerecog.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\prisonerfacerecog.xaml"
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
            
            #line 16 "..\..\prisonerfacerecog.xaml"
            ((JailManagementSystem.prisonerfacerecog)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.face_preview = ((System.Windows.Controls.Image)(target));
            return;
            case 3:
            this.deten_recog = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\prisonerfacerecog.xaml"
            this.deten_recog.Click += new System.Windows.RoutedEventHandler(this.deten_recog_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.face_count = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.face_persons = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.face_add = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\prisonerfacerecog.xaml"
            this.face_add.Click += new System.Windows.RoutedEventHandler(this.face_add_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.person_name = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.train_image = ((System.Windows.Controls.Image)(target));
            return;
            case 9:
            this.train_detect = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\prisonerfacerecog.xaml"
            this.train_detect.Click += new System.Windows.RoutedEventHandler(this.train_detect_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
