#pragma checksum "C:\Users\tien\Downloads\Compressed\QLNHang-master\QLNHang-master\WebApplication8\Views\Shared\_ModelPopup.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "043da56d4bf080b57e0128959330e5fff6d8390c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__ModelPopup), @"mvc.1.0.view", @"/Views/Shared/_ModelPopup.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/_ModelPopup.cshtml", typeof(AspNetCore.Views_Shared__ModelPopup))]
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
#line 1 "C:\Users\tien\Downloads\Compressed\QLNHang-master\QLNHang-master\WebApplication8\Views\_ViewImports.cshtml"
using WebApplication8;

#line default
#line hidden
#line 2 "C:\Users\tien\Downloads\Compressed\QLNHang-master\QLNHang-master\WebApplication8\Views\_ViewImports.cshtml"
using WebApplication8.Models;

#line default
#line hidden
#line 3 "C:\Users\tien\Downloads\Compressed\QLNHang-master\QLNHang-master\WebApplication8\Views\_ViewImports.cshtml"
using WebApplication8.Models.AccountViewModels;

#line default
#line hidden
#line 4 "C:\Users\tien\Downloads\Compressed\QLNHang-master\QLNHang-master\WebApplication8\Views\_ViewImports.cshtml"
using WebApplication8.Models.ManageViewModels;

#line default
#line hidden
#line 5 "C:\Users\tien\Downloads\Compressed\QLNHang-master\QLNHang-master\WebApplication8\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#line 6 "C:\Users\tien\Downloads\Compressed\QLNHang-master\QLNHang-master\WebApplication8\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Mvc.Localization;

#line default
#line hidden
#line 7 "C:\Users\tien\Downloads\Compressed\QLNHang-master\QLNHang-master\WebApplication8\Views\_ViewImports.cshtml"
using Microsoft.Extensions.Localization;

#line default
#line hidden
#line 8 "C:\Users\tien\Downloads\Compressed\QLNHang-master\QLNHang-master\WebApplication8\Views\_ViewImports.cshtml"
using WebApplication8.Models.IdentityModels;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"043da56d4bf080b57e0128959330e5fff6d8390c", @"/Views/Shared/_ModelPopup.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c0a3fafe41e76a33d850d2ac657d18b4d78f4541", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__ModelPopup : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 821, true);
            WriteLiteral(@"<!-- Modal Dialog -->
<div class=""modal fade"" id=""confirmDelete"" role=""dialog"" aria-labelledby=""confirmDeleteLabel"" aria-hidden=""true"">
    <div class=""modal-dialog"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-hidden=""true"">&times;</button>
                <h4 class=""modal-title"">Delete Parmanently</h4>
            </div>
            <div class=""modal-body"">
                <p>Are you sure about this ?</p>


            </div>
            <div class=""modal-footer"">
                <button type=""button"" class=""btn btn-default"" data-dismiss=""modal"">Cancel</button>
                <button type=""button"" class=""btn btn-danger"" id=""confirm"">Delete</button>
            </div>
        </div>
    </div>
</div>
");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public CustomerIdentity CustomerIdentity { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IViewLocalizer Global { get; private set; }
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
