#pragma checksum "C:\Users\henry\OneDrive\Documents\Coding Practice\C#\Database_ORMS\Chef_Dishes\Views\Home\Dishes.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6453be7e0852f08c5b07d367a8bf03ef36664a1d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Dishes), @"mvc.1.0.view", @"/Views/Home/Dishes.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Dishes.cshtml", typeof(AspNetCore.Views_Home_Dishes))]
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
#line 1 "C:\Users\henry\OneDrive\Documents\Coding Practice\C#\Database_ORMS\Chef_Dishes\Views\_ViewImports.cshtml"
using Chef_Dishes;

#line default
#line hidden
#line 2 "C:\Users\henry\OneDrive\Documents\Coding Practice\C#\Database_ORMS\Chef_Dishes\Views\_ViewImports.cshtml"
using Chef_Dishes.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6453be7e0852f08c5b07d367a8bf03ef36664a1d", @"/Views/Home/Dishes.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2f00ea43bd1b2438c9d16beec6e62c0f6af1f6d5", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Dishes : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Dish>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(20, 81, true);
            WriteLiteral("<nav class=\"text-center\">\r\n    <div style=\"display: inline-block;\">\r\n        <h2>");
            EndContext();
            BeginContext(101, 53, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6453be7e0852f08c5b07d367a8bf03ef36664a1d3943", async() => {
                BeginContext(145, 5, true);
                WriteLiteral("Chefs");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(154, 463, true);
            WriteLiteral(@"| Dishes</h2>
    </div>
    <div class=""text-right"">
        <a href=""/dishes/new"">Add a Dish</a>
    </div>
</nav>
<h3>Yum, take a look at our tasty dishes!</h3>
<hr style=""border: 1px solid black;"">
<div>
    <table class=""table table-striped"">
        <thead>
            <tr>
                <th>Name</th>
                <th>Chef</th>
                <th>Tastiness</th>
                <th>Calories</th>
            </tr>
        </thead>
");
            EndContext();
#line 22 "C:\Users\henry\OneDrive\Documents\Coding Practice\C#\Database_ORMS\Chef_Dishes\Views\Home\Dishes.cshtml"
         foreach (var dish in Model)
        {

#line default
#line hidden
            BeginContext(666, 55, true);
            WriteLiteral("        <tbody>\r\n            <tr>\r\n                <td>");
            EndContext();
            BeginContext(722, 9, false);
#line 26 "C:\Users\henry\OneDrive\Documents\Coding Practice\C#\Database_ORMS\Chef_Dishes\Views\Home\Dishes.cshtml"
               Write(dish.Name);

#line default
#line hidden
            EndContext();
            BeginContext(731, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(759, 22, false);
#line 27 "C:\Users\henry\OneDrive\Documents\Coding Practice\C#\Database_ORMS\Chef_Dishes\Views\Home\Dishes.cshtml"
               Write(dish.Creator.FirstName);

#line default
#line hidden
            EndContext();
            BeginContext(781, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(809, 14, false);
#line 28 "C:\Users\henry\OneDrive\Documents\Coding Practice\C#\Database_ORMS\Chef_Dishes\Views\Home\Dishes.cshtml"
               Write(dish.Tastiness);

#line default
#line hidden
            EndContext();
            BeginContext(823, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(851, 13, false);
#line 29 "C:\Users\henry\OneDrive\Documents\Coding Practice\C#\Database_ORMS\Chef_Dishes\Views\Home\Dishes.cshtml"
               Write(dish.Calories);

#line default
#line hidden
            EndContext();
            BeginContext(864, 44, true);
            WriteLiteral("</td>\r\n            </tr>\r\n        </tbody>\r\n");
            EndContext();
#line 32 "C:\Users\henry\OneDrive\Documents\Coding Practice\C#\Database_ORMS\Chef_Dishes\Views\Home\Dishes.cshtml"
        }

#line default
#line hidden
            BeginContext(919, 20, true);
            WriteLiteral("    </table>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Dish>> Html { get; private set; }
    }
}
#pragma warning restore 1591
