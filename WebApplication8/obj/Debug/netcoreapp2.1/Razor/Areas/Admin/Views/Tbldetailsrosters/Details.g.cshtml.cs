#pragma checksum "C:\Users\tien\Downloads\Compressed\QLNHang-master\QLNHang-master\WebApplication8\Areas\Admin\Views\Tbldetailsrosters\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a7d4f9e16ad405e82f124e6d298d1f472f3ef89d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Tbldetailsrosters_Details), @"mvc.1.0.view", @"/Areas/Admin/Views/Tbldetailsrosters/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Admin/Views/Tbldetailsrosters/Details.cshtml", typeof(AspNetCore.Areas_Admin_Views_Tbldetailsrosters_Details))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a7d4f9e16ad405e82f124e6d298d1f472f3ef89d", @"/Areas/Admin/Views/Tbldetailsrosters/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a195f33263845ab48ac39bf7972ff81be67288e6", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Tbldetailsrosters_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DAL.QLNHangData.Tbldetailsroster>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(40, 1, true);
            WriteLiteral("\n");
            EndContext();
#line 3 "C:\Users\tien\Downloads\Compressed\QLNHang-master\QLNHang-master\WebApplication8\Areas\Admin\Views\Tbldetailsrosters\Details.cshtml"
  
    ViewData["Title"] = "Details";
    Layout = "~/Areas/Admin/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(139, 122, true);
            WriteLiteral("\n<h2>Details</h2>\n\n<div>\n    <h4>Tbldetailsroster</h4>\n    <hr />\n    <dl class=\"dl-horizontal\">\n        <dt>\n            ");
            EndContext();
            BeginContext(262, 41, false);
#line 15 "C:\Users\tien\Downloads\Compressed\QLNHang-master\QLNHang-master\WebApplication8\Areas\Admin\Views\Tbldetailsrosters\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.SeqNo));

#line default
#line hidden
            EndContext();
            BeginContext(303, 40, true);
            WriteLiteral("\n        </dt>\n        <dd>\n            ");
            EndContext();
            BeginContext(344, 37, false);
#line 18 "C:\Users\tien\Downloads\Compressed\QLNHang-master\QLNHang-master\WebApplication8\Areas\Admin\Views\Tbldetailsrosters\Details.cshtml"
       Write(Html.DisplayFor(model => model.SeqNo));

#line default
#line hidden
            EndContext();
            BeginContext(381, 40, true);
            WriteLiteral("\n        </dd>\n        <dt>\n            ");
            EndContext();
            BeginContext(422, 41, false);
#line 21 "C:\Users\tien\Downloads\Compressed\QLNHang-master\QLNHang-master\WebApplication8\Areas\Admin\Views\Tbldetailsrosters\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.OnnTm));

#line default
#line hidden
            EndContext();
            BeginContext(463, 40, true);
            WriteLiteral("\n        </dt>\n        <dd>\n            ");
            EndContext();
            BeginContext(504, 37, false);
#line 24 "C:\Users\tien\Downloads\Compressed\QLNHang-master\QLNHang-master\WebApplication8\Areas\Admin\Views\Tbldetailsrosters\Details.cshtml"
       Write(Html.DisplayFor(model => model.OnnTm));

#line default
#line hidden
            EndContext();
            BeginContext(541, 40, true);
            WriteLiteral("\n        </dd>\n        <dt>\n            ");
            EndContext();
            BeginContext(582, 41, false);
#line 27 "C:\Users\tien\Downloads\Compressed\QLNHang-master\QLNHang-master\WebApplication8\Areas\Admin\Views\Tbldetailsrosters\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.OnnRd));

#line default
#line hidden
            EndContext();
            BeginContext(623, 40, true);
            WriteLiteral("\n        </dt>\n        <dd>\n            ");
            EndContext();
            BeginContext(664, 37, false);
#line 30 "C:\Users\tien\Downloads\Compressed\QLNHang-master\QLNHang-master\WebApplication8\Areas\Admin\Views\Tbldetailsrosters\Details.cshtml"
       Write(Html.DisplayFor(model => model.OnnRd));

#line default
#line hidden
            EndContext();
            BeginContext(701, 40, true);
            WriteLiteral("\n        </dd>\n        <dt>\n            ");
            EndContext();
            BeginContext(742, 41, false);
#line 33 "C:\Users\tien\Downloads\Compressed\QLNHang-master\QLNHang-master\WebApplication8\Areas\Admin\Views\Tbldetailsrosters\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.OnnBt));

#line default
#line hidden
            EndContext();
            BeginContext(783, 40, true);
            WriteLiteral("\n        </dt>\n        <dd>\n            ");
            EndContext();
            BeginContext(824, 37, false);
#line 36 "C:\Users\tien\Downloads\Compressed\QLNHang-master\QLNHang-master\WebApplication8\Areas\Admin\Views\Tbldetailsrosters\Details.cshtml"
       Write(Html.DisplayFor(model => model.OnnBt));

#line default
#line hidden
            EndContext();
            BeginContext(861, 40, true);
            WriteLiteral("\n        </dd>\n        <dt>\n            ");
            EndContext();
            BeginContext(902, 41, false);
#line 39 "C:\Users\tien\Downloads\Compressed\QLNHang-master\QLNHang-master\WebApplication8\Areas\Admin\Views\Tbldetailsrosters\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.OffTm));

#line default
#line hidden
            EndContext();
            BeginContext(943, 40, true);
            WriteLiteral("\n        </dt>\n        <dd>\n            ");
            EndContext();
            BeginContext(984, 37, false);
#line 42 "C:\Users\tien\Downloads\Compressed\QLNHang-master\QLNHang-master\WebApplication8\Areas\Admin\Views\Tbldetailsrosters\Details.cshtml"
       Write(Html.DisplayFor(model => model.OffTm));

#line default
#line hidden
            EndContext();
            BeginContext(1021, 40, true);
            WriteLiteral("\n        </dd>\n        <dt>\n            ");
            EndContext();
            BeginContext(1062, 41, false);
#line 45 "C:\Users\tien\Downloads\Compressed\QLNHang-master\QLNHang-master\WebApplication8\Areas\Admin\Views\Tbldetailsrosters\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.OffRd));

#line default
#line hidden
            EndContext();
            BeginContext(1103, 40, true);
            WriteLiteral("\n        </dt>\n        <dd>\n            ");
            EndContext();
            BeginContext(1144, 37, false);
#line 48 "C:\Users\tien\Downloads\Compressed\QLNHang-master\QLNHang-master\WebApplication8\Areas\Admin\Views\Tbldetailsrosters\Details.cshtml"
       Write(Html.DisplayFor(model => model.OffRd));

#line default
#line hidden
            EndContext();
            BeginContext(1181, 40, true);
            WriteLiteral("\n        </dd>\n        <dt>\n            ");
            EndContext();
            BeginContext(1222, 41, false);
#line 51 "C:\Users\tien\Downloads\Compressed\QLNHang-master\QLNHang-master\WebApplication8\Areas\Admin\Views\Tbldetailsrosters\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.OffBt));

#line default
#line hidden
            EndContext();
            BeginContext(1263, 40, true);
            WriteLiteral("\n        </dt>\n        <dd>\n            ");
            EndContext();
            BeginContext(1304, 37, false);
#line 54 "C:\Users\tien\Downloads\Compressed\QLNHang-master\QLNHang-master\WebApplication8\Areas\Admin\Views\Tbldetailsrosters\Details.cshtml"
       Write(Html.DisplayFor(model => model.OffBt));

#line default
#line hidden
            EndContext();
            BeginContext(1341, 40, true);
            WriteLiteral("\n        </dd>\n        <dt>\n            ");
            EndContext();
            BeginContext(1382, 41, false);
#line 57 "C:\Users\tien\Downloads\Compressed\QLNHang-master\QLNHang-master\WebApplication8\Areas\Admin\Views\Tbldetailsrosters\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.TypId));

#line default
#line hidden
            EndContext();
            BeginContext(1423, 40, true);
            WriteLiteral("\n        </dt>\n        <dd>\n            ");
            EndContext();
            BeginContext(1464, 37, false);
#line 60 "C:\Users\tien\Downloads\Compressed\QLNHang-master\QLNHang-master\WebApplication8\Areas\Admin\Views\Tbldetailsrosters\Details.cshtml"
       Write(Html.DisplayFor(model => model.TypId));

#line default
#line hidden
            EndContext();
            BeginContext(1501, 40, true);
            WriteLiteral("\n        </dd>\n        <dt>\n            ");
            EndContext();
            BeginContext(1542, 41, false);
#line 63 "C:\Users\tien\Downloads\Compressed\QLNHang-master\QLNHang-master\WebApplication8\Areas\Admin\Views\Tbldetailsrosters\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.MinSt));

#line default
#line hidden
            EndContext();
            BeginContext(1583, 40, true);
            WriteLiteral("\n        </dt>\n        <dd>\n            ");
            EndContext();
            BeginContext(1624, 37, false);
#line 66 "C:\Users\tien\Downloads\Compressed\QLNHang-master\QLNHang-master\WebApplication8\Areas\Admin\Views\Tbldetailsrosters\Details.cshtml"
       Write(Html.DisplayFor(model => model.MinSt));

#line default
#line hidden
            EndContext();
            BeginContext(1661, 40, true);
            WriteLiteral("\n        </dd>\n        <dt>\n            ");
            EndContext();
            BeginContext(1702, 41, false);
#line 69 "C:\Users\tien\Downloads\Compressed\QLNHang-master\QLNHang-master\WebApplication8\Areas\Admin\Views\Tbldetailsrosters\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.WrkHr));

#line default
#line hidden
            EndContext();
            BeginContext(1743, 40, true);
            WriteLiteral("\n        </dt>\n        <dd>\n            ");
            EndContext();
            BeginContext(1784, 37, false);
#line 72 "C:\Users\tien\Downloads\Compressed\QLNHang-master\QLNHang-master\WebApplication8\Areas\Admin\Views\Tbldetailsrosters\Details.cshtml"
       Write(Html.DisplayFor(model => model.WrkHr));

#line default
#line hidden
            EndContext();
            BeginContext(1821, 40, true);
            WriteLiteral("\n        </dd>\n        <dt>\n            ");
            EndContext();
            BeginContext(1862, 41, false);
#line 75 "C:\Users\tien\Downloads\Compressed\QLNHang-master\QLNHang-master\WebApplication8\Areas\Admin\Views\Tbldetailsrosters\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.LatBt));

#line default
#line hidden
            EndContext();
            BeginContext(1903, 40, true);
            WriteLiteral("\n        </dt>\n        <dd>\n            ");
            EndContext();
            BeginContext(1944, 37, false);
#line 78 "C:\Users\tien\Downloads\Compressed\QLNHang-master\QLNHang-master\WebApplication8\Areas\Admin\Views\Tbldetailsrosters\Details.cshtml"
       Write(Html.DisplayFor(model => model.LatBt));

#line default
#line hidden
            EndContext();
            BeginContext(1981, 40, true);
            WriteLiteral("\n        </dd>\n        <dt>\n            ");
            EndContext();
            BeginContext(2022, 41, false);
#line 81 "C:\Users\tien\Downloads\Compressed\QLNHang-master\QLNHang-master\WebApplication8\Areas\Admin\Views\Tbldetailsrosters\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.BltNm));

#line default
#line hidden
            EndContext();
            BeginContext(2063, 40, true);
            WriteLiteral("\n        </dt>\n        <dd>\n            ");
            EndContext();
            BeginContext(2104, 37, false);
#line 84 "C:\Users\tien\Downloads\Compressed\QLNHang-master\QLNHang-master\WebApplication8\Areas\Admin\Views\Tbldetailsrosters\Details.cshtml"
       Write(Html.DisplayFor(model => model.BltNm));

#line default
#line hidden
            EndContext();
            BeginContext(2141, 40, true);
            WriteLiteral("\n        </dd>\n        <dt>\n            ");
            EndContext();
            BeginContext(2182, 41, false);
#line 87 "C:\Users\tien\Downloads\Compressed\QLNHang-master\QLNHang-master\WebApplication8\Areas\Admin\Views\Tbldetailsrosters\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.BltDt));

#line default
#line hidden
            EndContext();
            BeginContext(2223, 40, true);
            WriteLiteral("\n        </dt>\n        <dd>\n            ");
            EndContext();
            BeginContext(2264, 37, false);
#line 90 "C:\Users\tien\Downloads\Compressed\QLNHang-master\QLNHang-master\WebApplication8\Areas\Admin\Views\Tbldetailsrosters\Details.cshtml"
       Write(Html.DisplayFor(model => model.BltDt));

#line default
#line hidden
            EndContext();
            BeginContext(2301, 40, true);
            WriteLiteral("\n        </dd>\n        <dt>\n            ");
            EndContext();
            BeginContext(2342, 41, false);
#line 93 "C:\Users\tien\Downloads\Compressed\QLNHang-master\QLNHang-master\WebApplication8\Areas\Admin\Views\Tbldetailsrosters\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.LstNm));

#line default
#line hidden
            EndContext();
            BeginContext(2383, 40, true);
            WriteLiteral("\n        </dt>\n        <dd>\n            ");
            EndContext();
            BeginContext(2424, 37, false);
#line 96 "C:\Users\tien\Downloads\Compressed\QLNHang-master\QLNHang-master\WebApplication8\Areas\Admin\Views\Tbldetailsrosters\Details.cshtml"
       Write(Html.DisplayFor(model => model.LstNm));

#line default
#line hidden
            EndContext();
            BeginContext(2461, 40, true);
            WriteLiteral("\n        </dd>\n        <dt>\n            ");
            EndContext();
            BeginContext(2502, 41, false);
#line 99 "C:\Users\tien\Downloads\Compressed\QLNHang-master\QLNHang-master\WebApplication8\Areas\Admin\Views\Tbldetailsrosters\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.LstDt));

#line default
#line hidden
            EndContext();
            BeginContext(2543, 40, true);
            WriteLiteral("\n        </dt>\n        <dd>\n            ");
            EndContext();
            BeginContext(2584, 37, false);
#line 102 "C:\Users\tien\Downloads\Compressed\QLNHang-master\QLNHang-master\WebApplication8\Areas\Admin\Views\Tbldetailsrosters\Details.cshtml"
       Write(Html.DisplayFor(model => model.LstDt));

#line default
#line hidden
            EndContext();
            BeginContext(2621, 40, true);
            WriteLiteral("\n        </dd>\n        <dt>\n            ");
            EndContext();
            BeginContext(2662, 41, false);
#line 105 "C:\Users\tien\Downloads\Compressed\QLNHang-master\QLNHang-master\WebApplication8\Areas\Admin\Views\Tbldetailsrosters\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.ManIn));

#line default
#line hidden
            EndContext();
            BeginContext(2703, 40, true);
            WriteLiteral("\n        </dt>\n        <dd>\n            ");
            EndContext();
            BeginContext(2744, 37, false);
#line 108 "C:\Users\tien\Downloads\Compressed\QLNHang-master\QLNHang-master\WebApplication8\Areas\Admin\Views\Tbldetailsrosters\Details.cshtml"
       Write(Html.DisplayFor(model => model.ManIn));

#line default
#line hidden
            EndContext();
            BeginContext(2781, 40, true);
            WriteLiteral("\n        </dd>\n        <dt>\n            ");
            EndContext();
            BeginContext(2822, 41, false);
#line 111 "C:\Users\tien\Downloads\Compressed\QLNHang-master\QLNHang-master\WebApplication8\Areas\Admin\Views\Tbldetailsrosters\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.ManOu));

#line default
#line hidden
            EndContext();
            BeginContext(2863, 40, true);
            WriteLiteral("\n        </dt>\n        <dd>\n            ");
            EndContext();
            BeginContext(2904, 37, false);
#line 114 "C:\Users\tien\Downloads\Compressed\QLNHang-master\QLNHang-master\WebApplication8\Areas\Admin\Views\Tbldetailsrosters\Details.cshtml"
       Write(Html.DisplayFor(model => model.ManOu));

#line default
#line hidden
            EndContext();
            BeginContext(2941, 42, true);
            WriteLiteral("\n        </dd>\n    </dl>\n</div>\n<div>\n    ");
            EndContext();
            BeginContext(2984, 68, false);
#line 119 "C:\Users\tien\Downloads\Compressed\QLNHang-master\QLNHang-master\WebApplication8\Areas\Admin\Views\Tbldetailsrosters\Details.cshtml"
Write(Html.ActionLink("Edit", "Edit", new { /* id = Model.PrimaryKey */ }));

#line default
#line hidden
            EndContext();
            BeginContext(3052, 7, true);
            WriteLiteral(" |\n    ");
            EndContext();
            BeginContext(3059, 38, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "387ce998106b448286f9914049ff5990", async() => {
                BeginContext(3081, 12, true);
                WriteLiteral("Back to List");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3097, 8, true);
            WriteLiteral("\n</div>\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DAL.QLNHangData.Tbldetailsroster> Html { get; private set; }
    }
}
#pragma warning restore 1591
