#pragma checksum "E:\ABEER_WEB\HTU\Tecnical\FinalProject\Views\Project\ShowTeamLeaderProjects.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f8ff8097dfbb2da13a0a9ed418f00037a95210ce"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Project_ShowTeamLeaderProjects), @"mvc.1.0.view", @"/Views/Project/ShowTeamLeaderProjects.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f8ff8097dfbb2da13a0a9ed418f00037a95210ce", @"/Views/Project/ShowTeamLeaderProjects.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f1cd403b176af46e85ea812cbc8b3a7a1a86d4d8", @"/Views/_ViewImports.cshtml")]
    public class Views_Project_ShowTeamLeaderProjects : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<TeamLeader>
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
#nullable restore
#line 3 "E:\ABEER_WEB\HTU\Tecnical\FinalProject\Views\Project\ShowTeamLeaderProjects.cshtml"
  

    var ProjectManager = (ProjectManager)ViewBag.ProjectManager;
    var TeamLeader=(TeamLeader)ViewBag.TeamLeader;
    ViewBag.User = TeamLeader.FirstName + " " + TeamLeader.LastName;



#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<div class=\"container\">\r\n    <br />\r\n\r\n    <div class=\"row\">\r\n\r\n        <div class=\"col-sm-6\">\r\n\r\n           \r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "f8ff8097dfbb2da13a0a9ed418f00037a95210ce4748", async() => {
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
            WriteLiteral(@"

        </div>
        <div class=""col-sm-6"" style=""text-align:center; margin-top: 9%;""><h5>
    <b> TEAM LEADER PROJECTS </b>
</h5></div>
        
    </div>
    <br />
  
    <table class=""table table-responsive-sm"" style=""text-align:center"">
        <thead class=""thead-dark"">
            <tr>
                
                <th>Project Name</th>
");
            WriteLiteral("                <th>Project Manager</th>\r\n                <th>Status</th>\r\n                <th>Sprints</th>\r\n                <th>More</th>\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n");
#nullable restore
#line 44 "E:\ABEER_WEB\HTU\Tecnical\FinalProject\Views\Project\ShowTeamLeaderProjects.cshtml"
             foreach (var item in Model.Projects)
            {
                var Project = (Project)item;
                

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td hidden>");
#nullable restore
#line 49 "E:\ABEER_WEB\HTU\Tecnical\FinalProject\Views\Project\ShowTeamLeaderProjects.cshtml"
                          Write(Project.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 50 "E:\ABEER_WEB\HTU\Tecnical\FinalProject\Views\Project\ShowTeamLeaderProjects.cshtml"
                   Write(Project.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td hidden>");
#nullable restore
#line 51 "E:\ABEER_WEB\HTU\Tecnical\FinalProject\Views\Project\ShowTeamLeaderProjects.cshtml"
                          Write(Project.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 52 "E:\ABEER_WEB\HTU\Tecnical\FinalProject\Views\Project\ShowTeamLeaderProjects.cshtml"
                   Write(Project.ProjectManager.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" &nbsp; ");
#nullable restore
#line 52 "E:\ABEER_WEB\HTU\Tecnical\FinalProject\Views\Project\ShowTeamLeaderProjects.cshtml"
                                                            Write(Project.ProjectManager.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                    <td>");
#nullable restore
#line 53 "E:\ABEER_WEB\HTU\Tecnical\FinalProject\Views\Project\ShowTeamLeaderProjects.cshtml"
                   Write(Project.StatusProject);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n");
#nullable restore
#line 56 "E:\ABEER_WEB\HTU\Tecnical\FinalProject\Views\Project\ShowTeamLeaderProjects.cshtml"
                         if (Project.StatusProject == (ProjectStatus)2)
                        {


#line default
#line hidden
#nullable disable
            WriteLiteral("                            <td><a");
            BeginWriteAttribute("href", " href=\"", 1647, "\"", 1695, 2);
            WriteAttributeValue("", 1654, "/Sprint/ShowSprints?ProjectId=", 1654, 30, true);
#nullable restore
#line 59 "E:\ABEER_WEB\HTU\Tecnical\FinalProject\Views\Project\ShowTeamLeaderProjects.cshtml"
WriteAttributeValue("", 1684, Project.Id, 1684, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn LeftColer\"><i class=\"glyphicon glyphicon-user\"></i>Sprints</a></td>\r\n");
#nullable restore
#line 60 "E:\ABEER_WEB\HTU\Tecnical\FinalProject\Views\Project\ShowTeamLeaderProjects.cshtml"

                        }
                        else 

#line default
#line hidden
#nullable disable
#nullable restore
#line 62 "E:\ABEER_WEB\HTU\Tecnical\FinalProject\Views\Project\ShowTeamLeaderProjects.cshtml"
                              if (Project.StatusProject == (ProjectStatus)1)
                   {


#line default
#line hidden
#nullable disable
            WriteLiteral("                <td>\r\n\r\n                    <a");
            BeginWriteAttribute("href", " href=\"", 1954, "\"", 2002, 2);
            WriteAttributeValue("", 1961, "/Sprint/ShowSprints?ProjectId=", 1961, 30, true);
#nullable restore
#line 67 "E:\ABEER_WEB\HTU\Tecnical\FinalProject\Views\Project\ShowTeamLeaderProjects.cshtml"
WriteAttributeValue("", 1991, Project.Id, 1991, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn LeftColer\"><i class=\"glyphicon glyphicon-user\"></i>Sprints</a>\r\n                </td> \r\n                  <td> \r\n");
            WriteLiteral("\r\n                <button  class=\"SubmitProject btn LeftColer\"");
            BeginWriteAttribute("value", " value=\"", 2239, "\"", 2258, 1);
#nullable restore
#line 72 "E:\ABEER_WEB\HTU\Tecnical\FinalProject\Views\Project\ShowTeamLeaderProjects.cshtml"
WriteAttributeValue("", 2247, Project.Id, 2247, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Complet Project </button>\r\n                </td>\r\n");
#nullable restore
#line 74 "E:\ABEER_WEB\HTU\Tecnical\FinalProject\Views\Project\ShowTeamLeaderProjects.cshtml"

                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n                </tr>\r\n");
#nullable restore
#line 82 "E:\ABEER_WEB\HTU\Tecnical\FinalProject\Views\Project\ShowTeamLeaderProjects.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        </tbody>
    </table>
    <br /><br />
    <div class=""row"">

        <div class=""col-sm-4 mt-4""> <a href=""/Home/Index"" type=""button"" class=""btn LeftColer"" style="" margin-top: -10px; margin-bottom: 26px;""> Go Back To Home</a> </div>

    </div>

</div>

<script>
   
    $('document').ready(function () {
        $("".SubmitProject"").click(function () {
            var ThisProjectId = $(this).val();
            
            $.ajax({
                
                url: '/Project/CompletProject',
                data: { ProjectID: ThisProjectId} ,
                contentType: ""application/json"",
                dataType: ""json"",
                success: function (data) {
                   

                    if (data == ""YES"") {
                        location.reload(true);
                        alert('Great !\n All Sprint has been completed.\n Your Project completed successfully.');

                    }
                    else {

                        alert('N");
            WriteLiteral(@"ot all Sprint are complet !!!\n Or you didn\'t Create any Sprint until now!');
                    }
                    
                },
                error: function () {
                    alert(""error"");
                }
            });

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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TeamLeader> Html { get; private set; }
    }
}
#pragma warning restore 1591
