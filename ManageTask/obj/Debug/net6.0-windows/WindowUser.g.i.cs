﻿#pragma checksum "..\..\..\WindowUser.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "FE90923C1DF9959048D19F4E6B619D731CFD8BAF"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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
using ToDoListProject;


namespace ToDoListProject {
    
    
    /// <summary>
    /// WindowUser
    /// </summary>
    public partial class WindowUser : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 13 "..\..\..\WindowUser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabControl tab_MainTab;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\WindowUser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lst_Todo;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\WindowUser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel stack1;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\WindowUser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_previous;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\WindowUser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ItemsControl ctrl_paging;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\..\WindowUser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_Name_detail;
        
        #line default
        #line hidden
        
        
        #line 81 "..\..\..\WindowUser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker date_Deadline_detail;
        
        #line default
        #line hidden
        
        
        #line 86 "..\..\..\WindowUser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_Description_detail;
        
        #line default
        #line hidden
        
        
        #line 89 "..\..\..\WindowUser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox cbo_Status_detail;
        
        #line default
        #line hidden
        
        
        #line 90 "..\..\..\WindowUser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_Id_detail;
        
        #line default
        #line hidden
        
        
        #line 100 "..\..\..\WindowUser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lst_Done;
        
        #line default
        #line hidden
        
        
        #line 147 "..\..\..\WindowUser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lst_overdue;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ToDoListProject;V1.0.0.0;component/windowuser.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\WindowUser.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.tab_MainTab = ((System.Windows.Controls.TabControl)(target));
            
            #line 13 "..\..\..\WindowUser.xaml"
            this.tab_MainTab.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.tab_MainTab_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.lst_Todo = ((System.Windows.Controls.ListView)(target));
            
            #line 20 "..\..\..\WindowUser.xaml"
            this.lst_Todo.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ListView_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.stack1 = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 6:
            this.btn_previous = ((System.Windows.Controls.Button)(target));
            
            #line 53 "..\..\..\WindowUser.xaml"
            this.btn_previous.Click += new System.Windows.RoutedEventHandler(this.btn_previous_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.ctrl_paging = ((System.Windows.Controls.ItemsControl)(target));
            return;
            case 9:
            
            #line 68 "..\..\..\WindowUser.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.txt_Name_detail = ((System.Windows.Controls.TextBox)(target));
            return;
            case 11:
            this.date_Deadline_detail = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 12:
            this.txt_Description_detail = ((System.Windows.Controls.TextBox)(target));
            return;
            case 13:
            this.cbo_Status_detail = ((System.Windows.Controls.TextBox)(target));
            return;
            case 14:
            this.txt_Id_detail = ((System.Windows.Controls.TextBox)(target));
            return;
            case 15:
            this.lst_Done = ((System.Windows.Controls.ListView)(target));
            return;
            case 17:
            
            #line 122 "..\..\..\WindowUser.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btn_previous_Click);
            
            #line default
            #line hidden
            return;
            case 18:
            
            #line 137 "..\..\..\WindowUser.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 19:
            this.lst_overdue = ((System.Windows.Controls.ListView)(target));
            return;
            case 20:
            
            #line 162 "..\..\..\WindowUser.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btn_previous_Click);
            
            #line default
            #line hidden
            return;
            case 21:
            
            #line 177 "..\..\..\WindowUser.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 3:
            
            #line 35 "..\..\..\WindowUser.xaml"
            ((System.Windows.Controls.ComboBox)(target)).SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ComboBox_SelectionChanged);
            
            #line default
            #line hidden
            break;
            case 4:
            
            #line 45 "..\..\..\WindowUser.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_1);
            
            #line default
            #line hidden
            break;
            case 8:
            
            #line 64 "..\..\..\WindowUser.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_2);
            
            #line default
            #line hidden
            break;
            case 16:
            
            #line 114 "..\..\..\WindowUser.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btn_ReOpen_Click);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}
