﻿#pragma checksum "..\..\..\..\xaml_window\obican_korisnik\Uvid_u_red_voznje.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "AD96395B33AE207BA6AF5A82CB3C9052EAD8E868DB5012BA8A5A244604C1D93F"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using IISAS.xaml_window.obican_korisnik;
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


namespace IISAS.xaml_window.obican_korisnik {
    
    
    /// <summary>
    /// Uvid_u_red_voznje
    /// </summary>
    public partial class Uvid_u_red_voznje : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 50 "..\..\..\..\xaml_window\obican_korisnik\Uvid_u_red_voznje.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Name;
        
        #line default
        #line hidden
        
        
        #line 136 "..\..\..\..\xaml_window\obican_korisnik\Uvid_u_red_voznje.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbPocetnaStanica;
        
        #line default
        #line hidden
        
        
        #line 151 "..\..\..\..\xaml_window\obican_korisnik\Uvid_u_red_voznje.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbKrajnjaStanica;
        
        #line default
        #line hidden
        
        
        #line 160 "..\..\..\..\xaml_window\obican_korisnik\Uvid_u_red_voznje.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dpDatum;
        
        #line default
        #line hidden
        
        
        #line 162 "..\..\..\..\xaml_window\obican_korisnik\Uvid_u_red_voznje.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbVreme;
        
        #line default
        #line hidden
        
        
        #line 190 "..\..\..\..\xaml_window\obican_korisnik\Uvid_u_red_voznje.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lvDataBinding;
        
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
            System.Uri resourceLocater = new System.Uri("/IISAS;component/xaml_window/obican_korisnik/uvid_u_red_voznje.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\xaml_window\obican_korisnik\Uvid_u_red_voznje.xaml"
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
            this.Name = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            
            #line 72 "..\..\..\..\xaml_window\obican_korisnik\Uvid_u_red_voznje.xaml"
            ((System.Windows.Controls.ListViewItem)(target)).Selected += new System.Windows.RoutedEventHandler(this.ListViewItem_Selected);
            
            #line default
            #line hidden
            return;
            case 3:
            this.cbPocetnaStanica = ((System.Windows.Controls.ComboBox)(target));
            
            #line 136 "..\..\..\..\xaml_window\obican_korisnik\Uvid_u_red_voznje.xaml"
            this.cbPocetnaStanica.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ComboBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.cbKrajnjaStanica = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.dpDatum = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 6:
            this.tbVreme = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.lvDataBinding = ((System.Windows.Controls.ListView)(target));
            return;
            case 8:
            
            #line 227 "..\..\..\..\xaml_window\obican_korisnik\Uvid_u_red_voznje.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Detaljinije);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

