#pragma checksum "C:\Users\Andre\OneDrive\Documents\URochester\Fall 2018\CSC210\StickyNotes\Sticky\Sticky\Pages\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0e69ce625dba3feb988711d21dc4052a37226ad2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Sticky.Pages.Pages_Index), @"mvc.1.0.razor-page", @"/Pages/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Pages/Index.cshtml", typeof(Sticky.Pages.Pages_Index), null)]
namespace Sticky.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 2 "C:\Users\Andre\OneDrive\Documents\URochester\Fall 2018\CSC210\StickyNotes\Sticky\Sticky\Pages\Index.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#line 2 "C:\Users\Andre\OneDrive\Documents\URochester\Fall 2018\CSC210\StickyNotes\Sticky\Sticky\Pages\_ViewImports.cshtml"
using Sticky;

#line default
#line hidden
#line 3 "C:\Users\Andre\OneDrive\Documents\URochester\Fall 2018\CSC210\StickyNotes\Sticky\Sticky\Pages\_ViewImports.cshtml"
using Sticky.Data;

#line default
#line hidden
#line 3 "C:\Users\Andre\OneDrive\Documents\URochester\Fall 2018\CSC210\StickyNotes\Sticky\Sticky\Pages\Index.cshtml"
using Sticky.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0e69ce625dba3feb988711d21dc4052a37226ad2", @"/Pages/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"af511ad489dc33f15b147d8c15d34620b300cd8f", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Index : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(166, 72, true);
            WriteLiteral("\n\n<div class=\"header\">\n    <h1 class=\"font-effect-3d\">Sticky Notes</h1>\n");
            EndContext();
#line 10 "C:\Users\Andre\OneDrive\Documents\URochester\Fall 2018\CSC210\StickyNotes\Sticky\Sticky\Pages\Index.cshtml"
     if (SignInManager.IsSignedIn(User))
    {

#line default
#line hidden
            BeginContext(285, 66, true);
            WriteLiteral("        <a href=\"/Profile\"><div class=\"profile\">Profile</div></a>\n");
            EndContext();
#line 13 "C:\Users\Andre\OneDrive\Documents\URochester\Fall 2018\CSC210\StickyNotes\Sticky\Sticky\Pages\Index.cshtml"
    }

#line default
#line hidden
            BeginContext(357, 448, true);
            WriteLiteral(@"</div>
<div class=""strong"">
    <div class=""create"">
        <h1><a href=""/Board"">Create a new board!</a></h1>
      <input type=""submit"" value=""Create"" id=""createButton"" onclick=""createNewBoard()"">
       </div>
    <div class=""join"">
        <h1>Join a friend's board!</h1>
            <input type=""text"" name=""code"" placeholder=""Enter Board ID Here"" id=""EnterBoard"">
            <br>
            <input type=""submit"" value=""Join"" id=""joinButton""");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 805, "\"", 856, 3);
            WriteAttributeValue("", 815, "joinBoard(\'", 815, 11, true);
#line 24 "C:\Users\Andre\OneDrive\Documents\URochester\Fall 2018\CSC210\StickyNotes\Sticky\Sticky\Pages\Index.cshtml"
WriteAttributeValue("", 826, UserManager.GetUserId(User), 826, 28, false);

#line default
#line hidden
            WriteAttributeValue("", 854, "\')", 854, 2, true);
            EndWriteAttribute();
            BeginContext(857, 19, true);
            WriteLiteral(">\n    </div>\n</div>");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public UserManager<ApplicationUser> UserManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public SignInManager<ApplicationUser> SignInManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Pages_Index> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Pages_Index> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Pages_Index>)PageContext?.ViewData;
        public Pages_Index Model => ViewData.Model;
    }
}
#pragma warning restore 1591
