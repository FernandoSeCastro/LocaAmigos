#pragma checksum "D:\Trabalho\InvalliaBase\LocaAmigos\LocaAmigos\Views\Jogos\Reservar.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fbf5743a1e154efd0c2e1aa8fd4d317c30a8a065"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Jogos_Reservar), @"mvc.1.0.view", @"/Views/Jogos/Reservar.cshtml")]
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
#line 1 "D:\Trabalho\InvalliaBase\LocaAmigos\LocaAmigos\Views\_ViewImports.cshtml"
using LocaAmigos;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Trabalho\InvalliaBase\LocaAmigos\LocaAmigos\Views\_ViewImports.cshtml"
using LocaAmigos.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fbf5743a1e154efd0c2e1aa8fd4d317c30a8a065", @"/Views/Jogos/Reservar.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"405fd5ae7006232f1f826561bed9ee9d4a2e6128", @"/Views/_ViewImports.cshtml")]
    public class Views_Jogos_Reservar : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<LocaAmigos.Models.Jogos>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\Trabalho\InvalliaBase\LocaAmigos\LocaAmigos\Views\Jogos\Reservar.cshtml"
 using (Html.BeginForm("Reservar", "Jogos", FormMethod.Post))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\Trabalho\InvalliaBase\LocaAmigos\LocaAmigos\Views\Jogos\Reservar.cshtml"
Write(Html.Hidden("JogosId", Model.id));

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"row\">\r\n        <div class=\"col-4\">\r\n            <h4>Jogo</h4>\r\n            <hr />\r\n            <dl class=\"row\">\r\n                <dt class=\"col-sm-2\">\r\n                    ");
#nullable restore
#line 12 "D:\Trabalho\InvalliaBase\LocaAmigos\LocaAmigos\Views\Jogos\Reservar.cshtml"
               Write(Html.DisplayNameFor(model => model.nome));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dt>\r\n                <dd class=\"col-sm-10\">\r\n                    ");
#nullable restore
#line 15 "D:\Trabalho\InvalliaBase\LocaAmigos\LocaAmigos\Views\Jogos\Reservar.cshtml"
               Write(Html.DisplayFor(model => model.nome));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dd>\r\n                <dt class=\"col-sm-2\">\r\n                    ");
#nullable restore
#line 18 "D:\Trabalho\InvalliaBase\LocaAmigos\LocaAmigos\Views\Jogos\Reservar.cshtml"
               Write(Html.DisplayNameFor(model => model.tipojogo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dt>\r\n                <dd class=\"col-sm-10\">\r\n                    ");
#nullable restore
#line 21 "D:\Trabalho\InvalliaBase\LocaAmigos\LocaAmigos\Views\Jogos\Reservar.cshtml"
               Write(Html.DisplayFor(model => model.tipojogo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dd>\r\n                <dt class=\"col-sm-3\">\r\n                    ");
#nullable restore
#line 24 "D:\Trabalho\InvalliaBase\LocaAmigos\LocaAmigos\Views\Jogos\Reservar.cshtml"
               Write(Html.DisplayNameFor(model => model.ativo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dt>\r\n                <dd class=\"col-sm-7\">\r\n                    ");
#nullable restore
#line 27 "D:\Trabalho\InvalliaBase\LocaAmigos\LocaAmigos\Views\Jogos\Reservar.cshtml"
               Write(Html.DisplayFor(model => model.ativo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dd>\r\n                <dt class=\"col-sm-2\">\r\n                    ");
#nullable restore
#line 30 "D:\Trabalho\InvalliaBase\LocaAmigos\LocaAmigos\Views\Jogos\Reservar.cshtml"
               Write(Html.DisplayNameFor(model => model.created));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dt>\r\n                <dd class=\"col-sm-10\">\r\n                    ");
#nullable restore
#line 33 "D:\Trabalho\InvalliaBase\LocaAmigos\LocaAmigos\Views\Jogos\Reservar.cshtml"
               Write(Html.DisplayFor(model => model.created));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </dd>\r\n            </dl>\r\n        </div>\r\n        <div class=\"col-4\">\r\n            <div>\r\n                ");
#nullable restore
#line 39 "D:\Trabalho\InvalliaBase\LocaAmigos\LocaAmigos\Views\Jogos\Reservar.cshtml"
           Write(Html.Label("Pesquisar"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <input type=\"text\" id=\"txtPesquisar\" onchange=\"getPessoaFiltrado();\" />\r\n            </div>\r\n            <div id=\"ListaPessoas\">\r\n            </div>\r\n\r\n        </div>\r\n        <div class=\"col-4\">\r\n\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 50 "D:\Trabalho\InvalliaBase\LocaAmigos\LocaAmigos\Views\Jogos\Reservar.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("<script type=\"text/javascript\">\r\nwindow.setTimeout(function () { getPessoaFiltrado();},1);\r\nfunction getPessoaFiltrado() {\r\n    var nome = document.getElementById(\"txtPesquisar\").value;\r\n    $.ajax({\r\n    type: \"GET\",\r\n        url: \'");
#nullable restore
#line 57 "D:\Trabalho\InvalliaBase\LocaAmigos\LocaAmigos\Views\Jogos\Reservar.cshtml"
         Write(Url.Action("_GetListaPessoas", "Pessoas"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\',\r\n        data: \"nome=\"+ nome,\r\n        success: function(d) {\r\n        /* d is the HTML of the returned response */\r\n            $(\"#ListaPessoas\").html(d); //replaces previous HTML with action\r\n        }\r\n    });\r\n}\r\n</script>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<LocaAmigos.Models.Jogos> Html { get; private set; }
    }
}
#pragma warning restore 1591
