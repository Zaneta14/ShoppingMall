#pragma checksum "C:\Users\Zane\ShoppingMall\ShoppingMall\Views\Employments\About.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "86e8820e0a3e5767082317da84f519feb0c83776"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Employments_About), @"mvc.1.0.view", @"/Views/Employments/About.cshtml")]
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
#line 1 "C:\Users\Zane\ShoppingMall\ShoppingMall\Views\_ViewImports.cshtml"
using ShoppingMall;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Zane\ShoppingMall\ShoppingMall\Views\_ViewImports.cshtml"
using ShoppingMall.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"86e8820e0a3e5767082317da84f519feb0c83776", @"/Views/Employments/About.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4b40c17694d30bb91bd668ae5e44d083cc80d158", @"/Views/_ViewImports.cshtml")]
    public class Views_Employments_About : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ShoppingMall.Models.Employee>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Zane\ShoppingMall\ShoppingMall\Views\Employments\About.cshtml"
  
    ViewData["Title"] = "За мене";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h1>За мене</h1>

<div class=""row"">
        <div class=""card"" style=""width:550px;margin-right:6px;margin-bottom:6px"">
            <div class=""card-body"" style=""text-align:center;"">
                <div class=""card-img"" style=""text-align:center""><img");
            BeginWriteAttribute("src", " src=\"", 338, "\"", 361, 1);
#nullable restore
#line 12 "C:\Users\Zane\ShoppingMall\ShoppingMall\Views\Employments\About.cshtml"
WriteAttributeValue("", 344, Model.PictureUrl, 344, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" width=\"500\" height=\"334\" style=\"padding-bottom:10px\" /></div>\r\n                <h4 style=\"color:darkolivegreen\"><b>");
#nullable restore
#line 13 "C:\Users\Zane\ShoppingMall\ShoppingMall\Views\Employments\About.cshtml"
                                               Write(Model.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b></h4>\r\n                <p><b>");
#nullable restore
#line 14 "C:\Users\Zane\ShoppingMall\ShoppingMall\Views\Employments\About.cshtml"
                 Write(Model.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b></p>\r\n");
#nullable restore
#line 15 "C:\Users\Zane\ShoppingMall\ShoppingMall\Views\Employments\About.cshtml"
                 if (Model.CVUrl != null)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <p>\r\n                        CV:\r\n                        <a");
            BeginWriteAttribute("href", " href=\"", 690, "\"", 729, 1);
#nullable restore
#line 19 "C:\Users\Zane\ShoppingMall\ShoppingMall\Views\Employments\About.cshtml"
WriteAttributeValue("", 697, "/employeeCVs/" + Model.CVUrl, 697, 32, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" target=\"_blank\">\r\n                            ");
#nullable restore
#line 20 "C:\Users\Zane\ShoppingMall\ShoppingMall\Views\Employments\About.cshtml"
                       Write(Model.CVUrl);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </a>\r\n                    </p>\r\n");
#nullable restore
#line 23 "C:\Users\Zane\ShoppingMall\ShoppingMall\Views\Employments\About.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </div>\r\n        </div>\r\n    \r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ShoppingMall.Models.Employee> Html { get; private set; }
    }
}
#pragma warning restore 1591