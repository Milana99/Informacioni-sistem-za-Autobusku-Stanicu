﻿#pragma checksum "..\..\..\..\xaml_window\korisnik_stan_usluga\Kupovina_karte.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "E490ED74756FFE7BDCC26E3AA5F8B8D15E2B2273069E1D3A5D9BEC49EFC45C23"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using IISAS.xaml_window.korisnik_stan_usluga;
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


namespace IISAS.xaml_window.korisnik_stan_usluga {
    
    
    /// <summary>
    /// Kupovina_karte
    /// </summary>
    public partial class Kupovina_karte : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 56 "..\..\..\..\xaml_window\korisnik_stan_usluga\Kupovina_karte.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Name;
        
        #line default
        #line hidden
        
        
        #line 194 "..\..\..\..\xaml_window\korisnik_stan_usluga\Kupovina_karte.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbUser;
        
        #line default
        #line hidden
        
        
        #line 195 "..\..\..\..\xaml_window\korisnik_stan_usluga\Kupovina_karte.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbStatus;
        
        #line default
        #line hidden
        
        
        #line 216 "..\..\..\..\xaml_window\korisnik_stan_usluga\Kupovina_karte.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbPocetnaStanica;
        
        #line default
        #line hidden
        
        
        #line 231 "..\..\..\..\xaml_window\korisnik_stan_usluga\Kupovina_karte.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbKrajnjaStanica;
        
        #line default
        #line hidden
        
        
        #line 240 "..\..\..\..\xaml_window\korisnik_stan_usluga\Kupovina_karte.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dpDatum;
        
        #line default
        #line hidden
        
        
        #line 242 "..\..\..\..\xaml_window\korisnik_stan_usluga\Kupovina_karte.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbVreme;
        
        #line default
        #line hidden
        
        
        #line 270 "..\..\..\..\xaml_window\korisnik_stan_usluga\Kupovina_karte.xaml"
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
            System.Uri resourceLocater = new System.Uri("/IISAS;component/xaml_window/korisnik_stan_usluga/kupovina_karte.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\xaml_window\korisnik_stan_usluga\Kupovina_karte.xaml"
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
            
            #line 79 "..\..\..\..\xaml_window\korisnik_stan_usluga\Kupovina_karte.xaml"
            ((System.Windows.Controls.ListViewItem)(target)).Selected += new System.Windows.RoutedEventHandler(this.ListViewItem_Selected);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 92 "..\..\..\..\xaml_window\korisnik_stan_usluga\Kupovina_karte.xaml"
            ((System.Windows.Controls.ListViewItem)(target)).Selected += new System.Windows.RoutedEventHandler(this.PregledKarata);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 106 "..\..\..\..\xaml_window\korisnik_stan_usluga\Kupovina_karte.xaml"
            ((System.Windows.Controls.ListViewItem)(target)).Selected += new System.Windows.RoutedEventHandler(this.RezervacijaKarte);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 119 "..\..\..\..\xaml_window\korisnik_stan_usluga\Kupovina_karte.xaml"
            ((System.Windows.Controls.ListViewItem)(target)).Selected += new System.Windows.RoutedEventHandler(this.PregledRezervisanihKarata);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 161 "..\..\..\..\xaml_window\korisnik_stan_usluga\Kupovina_karte.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Korisnik_st_usluga_logout);
            
            #line default
            #line hidden
            return;
            case 7:
            this.lbUser = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.lbStatus = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            this.cbPocetnaStanica = ((System.Windows.Controls.ComboBox)(target));
            
            #line 216 "..\..\..\..\xaml_window\korisnik_stan_usluga\Kupovina_karte.xaml"
            this.cbPocetnaStanica.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ComboBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 10:
            this.cbKrajnjaStanica = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 11:
            this.dpDatum = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 12:
            this.tbVreme = ((System.Windows.Controls.TextBox)(target));
            return;
            case 13:
            
            #line 254 "..\..\..\..\xaml_window\korisnik_stan_usluga\Kupovina_karte.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 14:
            this.lvDataBinding = ((System.Windows.Controls.ListView)(target));
            return;
            case 15:
            
            #line 311 "..\..\..\..\xaml_window\korisnik_stan_usluga\Kupovina_karte.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Detaljinije);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

