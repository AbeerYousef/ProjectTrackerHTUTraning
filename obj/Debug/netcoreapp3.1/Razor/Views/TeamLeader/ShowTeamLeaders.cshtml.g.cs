#pragma checksum "E:\ABEER_WEB\HTU\Tecnical\FinalProject\Views\TeamLeader\ShowTeamLeaders.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cb36c769ff51d3c3e8f0f12548bb232e2d94efee"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_TeamLeader_ShowTeamLeaders), @"mvc.1.0.view", @"/Views/TeamLeader/ShowTeamLeaders.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cb36c769ff51d3c3e8f0f12548bb232e2d94efee", @"/Views/TeamLeader/ShowTeamLeaders.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f1cd403b176af46e85ea812cbc8b3a7a1a86d4d8", @"/Views/_ViewImports.cshtml")]
    public class Views_TeamLeader_ShowTeamLeaders : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<TeamLeader>>
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
            WriteLiteral("\r\n");
            WriteLiteral("<br />\r\n<div class=\"container\">\r\n    <div class=\"row\">\r\n        <div class=\"col-sm-8\"> <h2>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "cb36c769ff51d3c3e8f0f12548bb232e2d94efee4323", async() => {
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
            WriteLiteral(@" <b> TEAM LEADERS</b> </h2></div>
       
        <div class=""col-sm-4 mt-4""> <a href=""/TeamLeader/CreatTeamLeader"" type=""button"" class=""btn LeftColer"" style="" margin-top: 18px; margin-bottom: 26px;""> Add New Team Leader</a> </div>

    </div>

    <table class=""table table-responsive-sm"" style=""text-align:center"">
        <thead class=""thead-dark"">
            <tr>

                <th>First Name</th>
                <th>Last Name</th>
                <th>Edit</th>
                <th>Delet</th>


            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 25 "E:\ABEER_WEB\HTU\Tecnical\FinalProject\Views\TeamLeader\ShowTeamLeaders.cshtml"
             foreach (var item in Model)
            {
                var TeamLeader = item;

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>");
#nullable restore
#line 29 "E:\ABEER_WEB\HTU\Tecnical\FinalProject\Views\TeamLeader\ShowTeamLeaders.cshtml"
                   Write(TeamLeader.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 30 "E:\ABEER_WEB\HTU\Tecnical\FinalProject\Views\TeamLeader\ShowTeamLeaders.cshtml"
                   Write(TeamLeader.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td><a");
            BeginWriteAttribute("href", " href=\"", 1009, "\"", 1064, 2);
            WriteAttributeValue("", 1016, "/TeamLeader/EditTeamLeader?TeamLeaderID=", 1016, 40, true);
#nullable restore
#line 31 "E:\ABEER_WEB\HTU\Tecnical\FinalProject\Views\TeamLeader\ShowTeamLeaders.cshtml"
WriteAttributeValue("", 1056, item.Id, 1056, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn LeftColer\"><i class=\"glyphicon glyphicon-user\"></i>Edit</a></td>\r\n                    <td>\r\n");
            WriteLiteral("                        <button class=\"DeleteTeamLeader btn TopColer\"");
            BeginWriteAttribute("value", " value=\"", 1400, "\"", 1416, 1);
#nullable restore
#line 34 "E:\ABEER_WEB\HTU\Tecnical\FinalProject\Views\TeamLeader\ShowTeamLeaders.cshtml"
WriteAttributeValue("", 1408, item.Id, 1408, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Delet </button>\r\n\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 38 "E:\ABEER_WEB\HTU\Tecnical\FinalProject\Views\TeamLeader\ShowTeamLeaders.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        </tbody>
    </table>

    <br /><br /><br />
    <div class=""row"">

        <div class=""col-sm-4 mt-4""> <a href=""/Home/Index"" type=""button"" class=""btn LeftColer"" style="" margin-top: -10px; margin-bottom: 26px;""> Go Back To Home</a> </div>

    </div>

</div>

<script>

    $('document').ready(function () {
        $("".DeleteTeamLeader"").click(function () {
            var TeamLeaderID = $(this).val();
            $.ajax({

                url: 'DeletTeamLeader',
                data: { TeamLeaderId: TeamLeaderID} ,
                contentType: ""application/json"",
                dataType: ""json"",
                success: function (data) {

                    if (data == ""YES"") {

                        alert('Delete operation completed.');
                        location.reload(true);

                    }
                    else {

                        alert(""This Team Leader works on a project.\n You can't delete him until all his projects are completed."");");
            WriteLiteral("\n                    }\r\n                   \r\n                },\r\n                error: function () {\r\n                    alert(\"error\");\r\n                }\r\n            });\r\n        });\r\n    });\r\n\r\n</script>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<TeamLeader>> Html { get; private set; }
    }
}
#pragma warning restore 1591
