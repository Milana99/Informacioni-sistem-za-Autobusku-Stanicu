﻿#pragma checksum "..\..\..\..\xaml_window\admin_as\manipulacija_cene_voznje_izmena.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "2CFBD3ECE9F2E15394AF36F10EFA9D54B06BBC510940A53BD085E37C71B7D7EE"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using IISAS.xaml_window.admin_as;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
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


namespace IISAS.xaml_window.admin_as {
    
    
    /// <summary>
    /// manipulacija_cene_voznje_izmena
    /// </summary>
    public partial class manipulacija_cene_voznje_izmena : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\..\xaml_window\admin_as\manipulacija_cene_voznje_izmena.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbCena;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\..\xaml_window\admin_as\manipulacija_cene_voznje_izmena.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbErrorCena;
        
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
            System.Uri resourceLocater = new System.Uri("/IISAS;component/xaml_window/admin_as/manipulacija_cene_voznje_izmena.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\xaml_window\admin_as\manipulacija_cene_voznje_izmena.xaml"
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
            this.tbCena = ((System.Windows.Controls.TextBox)(target));
            
            #line 13 "..\..\..\..\xaml_window\admin_as\manipulacija_cene_voznje_izmena.xaml"
            this.tbCena.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.tbCenaTextChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.lbErrorCena = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            
            #line 17 "..\..\..\..\xaml_window\admin_as\manipulacija_cene_voznje_izmena.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Potvrdi);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 23 "..\..\..\..\xaml_window\admin_as\manipulacija_cene_voznje_izmena.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Izadji);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

