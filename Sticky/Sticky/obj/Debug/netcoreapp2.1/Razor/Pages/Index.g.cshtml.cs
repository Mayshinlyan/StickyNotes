#pragma checksum "C:\Users\May\Documents\GitHub\StickyNotes\Sticky\Sticky\Pages\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0ab2b4e03f3ec24e0a3ea37f3f81637ad411e8c0"
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
#line 2 "C:\Users\May\Documents\GitHub\StickyNotes\Sticky\Sticky\Pages\Index.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#line 2 "C:\Users\May\Documents\GitHub\StickyNotes\Sticky\Sticky\Pages\_ViewImports.cshtml"
using Sticky;

#line default
#line hidden
#line 3 "C:\Users\May\Documents\GitHub\StickyNotes\Sticky\Sticky\Pages\_ViewImports.cshtml"
using Sticky.Data;

#line default
#line hidden
#line 3 "C:\Users\May\Documents\GitHub\StickyNotes\Sticky\Sticky\Pages\Index.cshtml"
using Sticky.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0ab2b4e03f3ec24e0a3ea37f3f81637ad411e8c0", @"/Pages/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1d9c20eb7816565b540c11813af94fbd3f3d0fb0", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Index : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(171, 76, true);
            WriteLiteral("\r\n\r\n<div class=\"header\">\r\n    <h1 class=\"font-effect-3d\">Sticky Notes</h1>\r\n");
            EndContext();
#line 10 "C:\Users\May\Documents\GitHub\StickyNotes\Sticky\Sticky\Pages\Index.cshtml"
     if (SignInManager.IsSignedIn(User))
    {

#line default
#line hidden
            BeginContext(296, 67, true);
            WriteLiteral("        <a href=\"/Profile\"><div class=\"profile\">Profile</div></a>\r\n");
            EndContext();
#line 13 "C:\Users\May\Documents\GitHub\StickyNotes\Sticky\Sticky\Pages\Index.cshtml"
    }

#line default
#line hidden
            BeginContext(370, 458, true);
            WriteLiteral(@"</div>
<div class=""strong"">
    <div class=""create"">
        <h1><a href=""/Board"">Create a new board!</a></h1>
      <input type=""submit"" value=""Create"" id=""createButton"" onclick=""createNewBoard()"">
       </div>
    <div class=""join"">
        <h1>Join a friend's board!</h1>
            <input type=""text"" name=""code"" placeholder=""Enter Board Id Here"" id=""EnterBoard"">
            <br>
            <input type=""submit"" value=""Join"" id=""joinButton""");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 828, "\"", 879, 3);
            WriteAttributeValue("", 838, "joinBoard(\'", 838, 11, true);
#line 24 "C:\Users\May\Documents\GitHub\StickyNotes\Sticky\Sticky\Pages\Index.cshtml"
WriteAttributeValue("", 849, UserManager.GetUserId(User), 849, 28, false);

#line default
#line hidden
            WriteAttributeValue("", 877, "\')", 877, 2, true);
            EndWriteAttribute();
            BeginContext(880, 21, true);
            WriteLiteral(">\r\n    </div>\r\n</div>");
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
