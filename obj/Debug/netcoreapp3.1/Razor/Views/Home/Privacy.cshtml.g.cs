#pragma checksum "E:\ABEER_WEB\HTU\Tecnical\FinalProject\Views\Home\Privacy.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "de08ce04a940c9051c5418bf5c7971a3d6e17f33"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Privacy), @"mvc.1.0.view", @"/Views/Home/Privacy.cshtml")]
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
#nullable restore
#line 1 "E:\ABEER_WEB\HTU\Tecnical\FinalProject\Views\_ViewImports.cshtml"
using FinalProject;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\ABEER_WEB\HTU\Tecnical\FinalProject\Views\_ViewImports.cshtml"
using FinalProject.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"de08ce04a940c9051c5418bf5c7971a3d6e17f33", @"/Views/Home/Privacy.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f1cd403b176af46e85ea812cbc8b3a7a1a86d4d8", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Privacy : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/img/LOGO.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("30%"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("Alternate Text"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n\r\n<br />\r\n<div class=\"container\">\r\n\r\n    <div class=\"row\">\r\n        <div class=\"col-sm-8\"> <h2>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "de08ce04a940c9051c5418bf5c7971a3d6e17f334225", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@" <b>REST API PROJECT MANAGERS</b> </h2></div>
        <div class=""col-sm-4 mt-4""> <a href=""/ProjectManager/CreatProjectManager"" type=""button"" class=""btn LeftColer"" style="" margin-top: 18px; margin-bottom: 26px;""> Add New Project Manager</a> </div>

    </div>

    <table id=""WorkTable"" class="" table table-responsive-sm"" style=""text-align:center"">
        <thead class=""thead-dark""");
            BeginWriteAttribute("id", " id=\"", 555, "\"", 560, 0);
            EndWriteAttribute();
            WriteLiteral(@">
            <tr>
                <th hidden>
                    Id
                </th>
                <th>
                    First Name
                </th>
                <th>
                    Last Name
                </th>
                <th>Email</th>
                <th> Edit</th>
                <th>Delete</th>
            </tr>
        </thead>


    </table>

</div>




<script>
    $('document').ready(function () {
        //show
        $.ajax({
            url: '/api/ApiProject/APIShowProjectManagers',
            //data: { ProjectID: ProjectId },
            contentType: ""application/json"",
            dataType: ""json"",
            success: function (data) {

                var html = """";
                var i;

                for (i = 0; i < data.length; i++) {

                    html = html + ""<tr>"" +
                        ""<td hidden>"" + data[i].id + ""</td>"" +
                        ""<td>"" + data[i].firstName + ""</td >"" +
         ");
            WriteLiteral(@"               ""<td>"" + data[i].lastName + ""</td>"" +
                        ""<td>"" + data[i].email + ""</td>"" +
                        ""<td><a href=\""/ProjectManager/EditProjectManager?ProjectManagerID="" + data[i].id + ""\"" class=\""btn LeftColer\""><i class=\""glyphicon glyphicon-user\""></i>Edit</a></td>""+
                        ""<td><button class=\""APIDeleteProjectManager btn TopColer\"" value=\"""" + data[i].id + ""\""> Delet </button ></td >"" +
                        ""<tr>"";
                }
                $(""#WorkTable"").append(html);

                

                $("".APIDeleteProjectManager"").click(function () {
                    var ProjectManagerId = $(this).val();
                   
                    $.ajax({

                        url: '/ProjectManager/DeletProjectManager',
                        data: { ProjectManagerID: ProjectManagerId },
                        contentType: ""application/json"",
                        dataType: ""json"",
                        success: ");
            WriteLiteral(@"function (data) {

                            if (data == ""YES"") {

                                alert('Delete operation completed.');
                                location.reload(true);

                            }
                            else {

                                alert(""The project manager is still managing projects.\n You can't delete him until all his projects are completed."");
                            }
                           
                        },
                        error: function () {
                            alert(""error"");
                        }
                    });
                });

            },
            error: function () {
                alert(""error"");
            }
        });

    });

</script>


");
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
