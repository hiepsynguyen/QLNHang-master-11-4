#pragma checksum "C:\Users\tien\Downloads\Compressed\QLNHang-master\QLNHang-master\WebApplication8\Areas\Admin\Views\Tblleaves\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b47d338b1e1efda46fee27e4db6570b1b6ee2df7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Tblleaves_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/Tblleaves/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Admin/Views/Tblleaves/Index.cshtml", typeof(AspNetCore.Areas_Admin_Views_Tblleaves_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b47d338b1e1efda46fee27e4db6570b1b6ee2df7", @"/Areas/Admin/Views/Tblleaves/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a195f33263845ab48ac39bf7972ff81be67288e6", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Tblleaves_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<DAL.QLNHangData.Tblleave>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(45, 1, true);
            WriteLiteral("\n");
            EndContext();
#line 3 "C:\Users\tien\Downloads\Compressed\QLNHang-master\QLNHang-master\WebApplication8\Areas\Admin\Views\Tblleaves\Index.cshtml"
  
    ViewData["Title"] = "Quản lý nghỉ phép";
    Layout = "~/Areas/Admin/Views/Shared/_Layout.cshtml";
    var list_emp = (List<DAL.QLNHangData.Tblemployee>)ViewData["list_emp"];

#line default
#line hidden
            BeginContext(230, 114, true);
            WriteLiteral("\n<div class=\"col-md-12\">\n    <a class=\"btn btn-success btn-flat btn-sm\" id=\"url-create-leave\" href=\"#\" data-burl=\"");
            EndContext();
            BeginContext(345, 79, false);
#line 10 "C:\Users\tien\Downloads\Compressed\QLNHang-master\QLNHang-master\WebApplication8\Areas\Admin\Views\Tblleaves\Index.cshtml"
                                                                                    Write(Url.RouteUrl(new { controller="Tblleaves", action= "LeaveInsert",area="admin"}));

#line default
#line hidden
            EndContext();
            BeginContext(424, 406, true);
            WriteLiteral(@"?EmpId={0}""><i class=""fa fa-plus""></i></a>
</div>
<div class=""col-md-12"" >
    <div class=""table-responsive"" style=""max-height:50%"">
        <table class=""table table-hover"">
            <thead>
                <tr>
                    <th>Mã nhân viên</th>
                    <th>Tên Nhân Viên</th>
                    <th>Ngày vào làm</th>
                </tr>
            </thead>
            <tbody>
");
            EndContext();
#line 23 "C:\Users\tien\Downloads\Compressed\QLNHang-master\QLNHang-master\WebApplication8\Areas\Admin\Views\Tblleaves\Index.cshtml"
                 foreach (var e in list_emp)
                {

#line default
#line hidden
            BeginContext(893, 53, true);
            WriteLiteral("                    <tr class=\"emp-details\" data-id=\"");
            EndContext();
            BeginContext(947, 7, false);
#line 25 "C:\Users\tien\Downloads\Compressed\QLNHang-master\QLNHang-master\WebApplication8\Areas\Admin\Views\Tblleaves\Index.cshtml"
                                                Write(e.EmpId);

#line default
#line hidden
            EndContext();
            BeginContext(954, 31, true);
            WriteLiteral("\">\n                        <td>");
            EndContext();
            BeginContext(986, 7, false);
#line 26 "C:\Users\tien\Downloads\Compressed\QLNHang-master\QLNHang-master\WebApplication8\Areas\Admin\Views\Tblleaves\Index.cshtml"
                       Write(e.EmpId);

#line default
#line hidden
            EndContext();
            BeginContext(993, 34, true);
            WriteLiteral("</td>\n                        <td>");
            EndContext();
            BeginContext(1028, 7, false);
#line 27 "C:\Users\tien\Downloads\Compressed\QLNHang-master\QLNHang-master\WebApplication8\Areas\Admin\Views\Tblleaves\Index.cshtml"
                       Write(e.EmpNm);

#line default
#line hidden
            EndContext();
            BeginContext(1035, 34, true);
            WriteLiteral("</td>\n                        <td>");
            EndContext();
            BeginContext(1070, 36, false);
#line 28 "C:\Users\tien\Downloads\Compressed\QLNHang-master\QLNHang-master\WebApplication8\Areas\Admin\Views\Tblleaves\Index.cshtml"
                       Write(e.InhDt.Value.ToString("dd/MM/yyyy"));

#line default
#line hidden
            EndContext();
            BeginContext(1106, 32, true);
            WriteLiteral("</td>\n                    </tr>\n");
            EndContext();
#line 30 "C:\Users\tien\Downloads\Compressed\QLNHang-master\QLNHang-master\WebApplication8\Areas\Admin\Views\Tblleaves\Index.cshtml"
                }

#line default
#line hidden
            BeginContext(1156, 598, true);
            WriteLiteral(@"            </tbody>
        </table>
    </div>
</div>
<div class=""col-md-12"">
    <div class=""table-responsive"" style=""max-height:50%"">
        <table class=""table"">
            <thead>
                <tr>
                    <th>Mã nhân viên</th>
                    <th>Ngày bắt đầu</th>
                    <th>Ngày kết thúc</th>
                    <th>Giờ bắt đầu</th>
                    <th>Giờ kết thúc</th>
                    <th>Tổng giờ nghỉ</th>
                </tr>
            </thead>
            <tbody id=""body-leave"">

            </tbody>
        </table>
    </div>
</div>
");
            EndContext();
            DefineSection("scripts", async() => {
                BeginContext(1771, 509, true);
                WriteLiteral(@" 
    <script>
        $(document).ready(function () {
            //alert('abc');
            $('.emp-details').off().on('click', function (e) {
                $('.emp-details').removeClass('bg-blue-selected');
                $(this).addClass('bg-blue-selected');
                var id = $(this).data('id');
                var href_a = $('#url-create-leave').data('burl');
                $('#url-create-leave').attr('href', href_a.replace('{0}', id));
                $.ajax({
                    url: '");
                EndContext();
                BeginContext(2281, 89, false);
#line 65 "C:\Users\tien\Downloads\Compressed\QLNHang-master\QLNHang-master\WebApplication8\Areas\Admin\Views\Tblleaves\Index.cshtml"
                     Write(Url.RouteUrl(new {controller= "Tblleaves", action= "GetListLeaveByEmpId", area="admin" }));

#line default
#line hidden
                EndContext();
                BeginContext(2370, 475, true);
                WriteLiteral(@"',
                    data: {
                        EmpId: id
                    },
                    type: 'GET',
                    success: function (response) {
                        $('#body-leave').html(response);
                    },
                    error: function (xhr) {

                    }
                });
            });
        });
        function deleteLeave(idForm) {
            if (confirm(""Bạn muốn xóa ?"")) {
                $.post('");
                EndContext();
                BeginContext(2846, 81, false);
#line 81 "C:\Users\tien\Downloads\Compressed\QLNHang-master\QLNHang-master\WebApplication8\Areas\Admin\Views\Tblleaves\Index.cshtml"
                   Write(Url.RouteUrl(new {controller= "Tblleaves", action= "LeaveDelete", area="admin" }));

#line default
#line hidden
                EndContext();
                BeginContext(2927, 540, true);
                WriteLiteral(@"', $(idForm).serialize(), function (response) {
                    console.log(response);
                    if (typeof (response) === ""object"") {
                        if (response.err === null) {
                            $('.bg-blue-selected').click();
                        }
                        else {
                            alert(response.err);
                        }
                    }
                })

                //console.log(""Xóa"");
            }
            return false;
        }

    </script>

");
                EndContext();
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<DAL.QLNHangData.Tblleave>> Html { get; private set; }
    }
}
#pragma warning restore 1591