#pragma checksum "G:\Chat\AspCourse\Views\Chats\ShowMembers.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bb3c5ce50c5aa8c0e3a826c1f84e7d28562e984a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Chats_ShowMembers), @"mvc.1.0.view", @"/Views/Chats/ShowMembers.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Chats/ShowMembers.cshtml", typeof(AspNetCore.Views_Chats_ShowMembers))]
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
#line 1 "G:\Chat\AspCourse\Views\_ViewImports.cshtml"
using AspCourse;

#line default
#line hidden
#line 2 "G:\Chat\AspCourse\Views\_ViewImports.cshtml"
using AspCourse.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bb3c5ce50c5aa8c0e3a826c1f84e7d28562e984a", @"/Views/Chats/ShowMembers.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"27f90e78f8dc2b9be5146fea58400bcb16e6e8fd", @"/Views/_ViewImports.cshtml")]
    public class Views_Chats_ShowMembers : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<AspCourse.Models.database.entity.ChatMember>>
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
            BeginContext(65, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "G:\Chat\AspCourse\Views\Chats\ShowMembers.cshtml"
  
    ViewData["Title"] = "ShowMembars";

#line default
#line hidden
            BeginContext(114, 168, true);
            WriteLiteral("\r\n<h2>ShowMembars</h2>\r\n\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n               Role\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(283, 40, false);
#line 16 "G:\Chat\AspCourse\Views\Chats\ShowMembers.cshtml"
           Write(Html.DisplayNameFor(model => model.User));

#line default
#line hidden
            EndContext();
            BeginContext(323, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(379, 40, false);
#line 19 "G:\Chat\AspCourse\Views\Chats\ShowMembers.cshtml"
           Write(Html.DisplayNameFor(model => model.Chat));

#line default
#line hidden
            EndContext();
            BeginContext(419, 86, true);
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
            EndContext();
#line 25 "G:\Chat\AspCourse\Views\Chats\ShowMembers.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
            BeginContext(537, 32, true);
            WriteLiteral("        <tr>\r\n            <td>\r\n");
            EndContext();
#line 28 "G:\Chat\AspCourse\Views\Chats\ShowMembers.cshtml"
                 if (item.IsAdmin)
                {

#line default
#line hidden
            BeginContext(624, 68, true);
            WriteLiteral("                    <span class=\"badge badge-primary\">Admin</span>\r\n");
            EndContext();
#line 31 "G:\Chat\AspCourse\Views\Chats\ShowMembers.cshtml"
                }
                else
                {

#line default
#line hidden
            BeginContext(752, 69, true);
            WriteLiteral("                    <span class=\"badge badge-secondary\">User</span>\r\n");
            EndContext();
#line 35 "G:\Chat\AspCourse\Views\Chats\ShowMembers.cshtml"
                }

#line default
#line hidden
            BeginContext(840, 53, true);
            WriteLiteral("            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(894, 44, false);
#line 38 "G:\Chat\AspCourse\Views\Chats\ShowMembers.cshtml"
           Write(Html.DisplayFor(modelItem => item.User.Name));

#line default
#line hidden
            EndContext();
            BeginContext(938, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(994, 44, false);
#line 41 "G:\Chat\AspCourse\Views\Chats\ShowMembers.cshtml"
           Write(Html.DisplayFor(modelItem => item.Chat.Name));

#line default
#line hidden
            EndContext();
            BeginContext(1038, 36, true);
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
            EndContext();
#line 44 "G:\Chat\AspCourse\Views\Chats\ShowMembers.cshtml"
}

#line default
#line hidden
            BeginContext(1077, 35, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n<div>\r\n    ");
            EndContext();
            BeginContext(1112, 38, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bb3c5ce50c5aa8c0e3a826c1f84e7d28562e984a6854", async() => {
                BeginContext(1134, 12, true);
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
            BeginContext(1150, 8, true);
            WriteLiteral("\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<AspCourse.Models.database.entity.ChatMember>> Html { get; private set; }
    }
}
#pragma warning restore 1591
