﻿#pragma checksum "..\..\..\..\xaml_window\salterski_radnik\Rezervacija_karata_rezervisi.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "822DDAACDA009CFD139B7D224326FBF43FF94856256DB513C4132762ED409DAE"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using IISAS.xaml_window.salterski_radnik;
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


namespace IISAS.xaml_window.salterski_radnik {
    
    
    /// <summary>
    /// Rezervacija_karata_rezervisi
    /// </summary>
    public partial class Rezervacija_karata_rezervisi : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 65 "..\..\..\..\xaml_window\salterski_radnik\Rezervacija_karata_rezervisi.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbTipKarte;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\..\xaml_window\salterski_radnik\Rezervacija_karata_rezervisi.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbStatus;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\..\..\xaml_window\salterski_radnik\Rezervacija_karata_rezervisi.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbKorisnickoIme;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\..\..\xaml_window\salterski_radnik\Rezervacija_karata_rezervisi.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbErrorKorisnickoIme;
        
        #line default
        #line hidden
        
        
        #line 85 "..\..\..\..\xaml_window\salterski_radnik\Rezervacija_karata_rezervisi.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbIme;
        
        #line default
        #line hidden
        
        
        #line 91 "..\..\..\..\xaml_window\salterski_radnik\Rezervacija_karata_rezervisi.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbPrezime;
        
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
            System.Uri resourceLocater = new System.Uri("/IISAS;component/xaml_window/salterski_radnik/rezervacija_karata_rezervisi.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\xaml_window\salterski_radnik\Rezervacija_karata_rezervisi.xaml"
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
            this.cbTipKarte = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 2:
            this.cbStatus = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.tbKorisnickoIme = ((System.Windows.Controls.TextBox)(target));
            
            #line 77 "..\..\..\..\xaml_window\salterski_radnik\Rezervacija_karata_rezervisi.xaml"
            this.tbKorisnickoIme.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.tbUsername_TextChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.lbErrorKorisnickoIme = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.tbIme = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.tbPrezime = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            
            #line 102 "..\..\..\..\xaml_window\salterski_radnik\Rezervacija_karata_rezervisi.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Rezervisi);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 108 "..\..\..\..\xaml_window\salterski_radnik\Rezervacija_karata_rezervisi.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Izadji);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

