﻿#pragma checksum "..\..\..\..\xaml_window\korisnik_stan_usluga\Rezervacija_karata.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "24054D73653097CB7D88E1F38DB110C77C4E26E8CCC841FE4FF31D1D8C797354"
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
    /// Rezervacija_karata
    /// </summary>
    public partial class Rezervacija_karata : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 55 "..\..\..\..\xaml_window\korisnik_stan_usluga\Rezervacija_karata.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Name;
        
        #line default
        #line hidden
        
        
        #line 170 "..\..\..\..\xaml_window\korisnik_stan_usluga\Rezervacija_karata.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbUser;
        
        #line default
        #line hidden
        
        
        #line 171 "..\..\..\..\xaml_window\korisnik_stan_usluga\Rezervacija_karata.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbStatus;
        
        #line default
        #line hidden
        
        
        #line 194 "..\..\..\..\xaml_window\korisnik_stan_usluga\Rezervacija_karata.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbPocetnaStanica;
        
        #line default
        #line hidden
        
        
        #line 209 "..\..\..\..\xaml_window\korisnik_stan_usluga\Rezervacija_karata.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbKrajnjaStanica;
        
        #line default
        #line hidden
        
        
        #line 218 "..\..\..\..\xaml_window\korisnik_stan_usluga\Rezervacija_karata.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dpDatum;
        
        #line default
        #line hidden
        
        
        #line 220 "..\..\..\..\xaml_window\korisnik_stan_usluga\Rezervacija_karata.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbVreme;
        
        #line default
        #line hidden
        
        
        #line 248 "..\..\..\..\xaml_window\korisnik_stan_usluga\Rezervacija_karata.xaml"
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
            System.Uri resourceLocater = new System.Uri("/IISAS;component/xaml_window/korisnik_stan_usluga/rezervacija_karata.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\xaml_window\korisnik_stan_usluga\Rezervacija_karata.xaml"
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
            
            #line 69 "..\..\..\..\xaml_window\korisnik_stan_usluga\Rezervacija_karata.xaml"
            ((System.Windows.Controls.ListViewItem)(target)).Selected += new System.Windows.RoutedEventHandler(this.Red_voznje);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 85 "..\..\..\..\xaml_window\korisnik_stan_usluga\Rezervacija_karata.xaml"
            ((System.Windows.Controls.ListViewItem)(target)).Selected += new System.Windows.RoutedEventHandler(this.Kupovina_karte);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 98 "..\..\..\..\xaml_window\korisnik_stan_usluga\Rezervacija_karata.xaml"
            ((System.Windows.Controls.ListViewItem)(target)).Selected += new System.Windows.RoutedEventHandler(this.PregledKarata);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 124 "..\..\..\..\xaml_window\korisnik_stan_usluga\Rezervacija_karata.xaml"
            ((System.Windows.Controls.ListViewItem)(target)).Selected += new System.Windows.RoutedEventHandler(this.PregledRezervisanihKarata);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 138 "..\..\..\..\xaml_window\korisnik_stan_usluga\Rezervacija_karata.xaml"
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
            
            #line 232 "..\..\..\..\xaml_window\korisnik_stan_usluga\Rezervacija_karata.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Pretraga);
            
            #line default
            #line hidden
            return;
            case 14:
            this.lvDataBinding = ((System.Windows.Controls.ListView)(target));
            return;
            case 15:
            
            #line 289 "..\..\..\..\xaml_window\korisnik_stan_usluga\Rezervacija_karata.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Rezervisi);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

