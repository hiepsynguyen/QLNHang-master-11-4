#pragma checksum "C:\Users\tien\Downloads\Compressed\QLNHang-master\QLNHang-master\WebApplication8\Areas\Admin\Views\Shared\Components\NotificationAdmin\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7223a8d3f6bd74f67a2405ec06612d7be1320aef"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Shared_Components_NotificationAdmin_Default), @"mvc.1.0.view", @"/Areas/Admin/Views/Shared/Components/NotificationAdmin/Default.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Admin/Views/Shared/Components/NotificationAdmin/Default.cshtml", typeof(AspNetCore.Areas_Admin_Views_Shared_Components_NotificationAdmin_Default))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\tien\Downloads\Compressed\QLNHang-master\QLNHang-master\WebApplication8\Areas\Admin\Views\_ViewImports.cshtml"
using WebApplication8;

#line default
#line hidden
#line 2 "C:\Users\tien\Downloads\Compressed\QLNHang-master\QLNHang-master\WebApplication8\Areas\Admin\Views\_ViewImports.cshtml"
using WebApplication8.Models;

#line default
#line hidden
#line 3 "C:\Users\tien\Downloads\Compressed\QLNHang-master\QLNHang-master\WebApplication8\Areas\Admin\Views\_ViewImports.cshtml"
using WebApplication8.Models.AccountViewModels;

#line default
#line hidden
#line 4 "C:\Users\tien\Downloads\Compressed\QLNHang-master\QLNHang-master\WebApplication8\Areas\Admin\Views\_ViewImports.cshtml"
using WebApplication8.Models.ManageViewModels;

#line default
#line hidden
#line 5 "C:\Users\tien\Downloads\Compressed\QLNHang-master\QLNHang-master\WebApplication8\Areas\Admin\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7223a8d3f6bd74f67a2405ec06612d7be1320aef", @"/Areas/Admin/Views/Shared/Components/NotificationAdmin/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a195f33263845ab48ac39bf7972ff81be67288e6", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Shared_Components_NotificationAdmin_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(118, 1, true);
            WriteLiteral("\n");
            EndContext();
            BeginContext(124, 1568, true);
            WriteLiteral(@" <!-- Notifications: style can be found in dropdown.less -->

<li class=""dropdown notifications-menu hidden"">
    <a href=""#"" class=""dropdown-toggle"" data-toggle=""dropdown"">
        <i class=""fa fa-bell-o""></i>
        <span class=""label label-warning"">10</span>
    </a>
    <ul class=""dropdown-menu"">
        <li class=""header"">You have 10 notifications</li>
        <li>
            <!-- inner menu: contains the actual data -->
            <ul class=""menu"">
                <li>
                    <a href=""#"">
                        <i class=""fa fa-users text-aqua""></i> 5 new members joined today
                    </a>
                </li>
                <li>
                    <a href=""#"">
                        <i class=""fa fa-warning text-yellow""></i> Very long description here that may not fit into the page and may cause design problems
                    </a>
                </li>
                <li>
                    <a href=""#"">
                        <i class=""fa fa-users text-red""></i> 5 ");
            WriteLiteral(@"new members joined
                    </a>
                </li>

                <li>
                    <a href=""#"">
                        <i class=""fa fa-shopping-cart text-green""></i> 25 sales made
                    </a>
                </li>
                <li>
                    <a href=""#"">
                        <i class=""fa fa-user text-red""></i> You changed your username
                    </a>
                </li>
            </ul>
        </li>
        <li class=""footer""><a href=""#"">View all</a></li>
    </ul>
</li>");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
