#pragma checksum "E:\WPF_projects\nCov1.0\Pages\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a61b7580839bf35c512d2b37bbb2c44bca3c657a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(nCov1._0.Pages.Pages_Index), @"mvc.1.0.razor-page", @"/Pages/Index.cshtml")]
namespace nCov1._0.Pages
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
#line 1 "E:\WPF_projects\nCov1.0\Pages\_ViewImports.cshtml"
using nCov1._0;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a61b7580839bf35c512d2b37bbb2c44bca3c657a", @"/Pages/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0de291c9d70d665ae4b25e26bfae15c746bdeb88", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Index : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "E:\WPF_projects\nCov1.0\Pages\Index.cshtml"
  
    ViewData["Title"] = "Home";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""container"">
    <div id=""mapid"" style=""
           height:100%;
           z-index: 1;
           position: relative;"">
    </div>

    <div class=""overlay"" style=""
            border-radius:5px;
            height: 85px;
            width: 85px;
            border: 2px solid #BCBAB7;
            z-index:2;
            background-color: #FFFFFF;
            position: absolute;
            bottom:15px;
            left:15px"">
        <img id=""heatmapButton"" src=""/placewithoutheatmap.jpg""
             style=""
                position: absolute;
                height:100%;
                width:100%;
                border:none;
                box-shadow:none;"" 
                onclick=""heatmaponoffchange()"" />
    </div>
    <div class=""search"" style=""        
        border-radius: 5px 5px 0px 0px;
        height: 50px;
        width: 300px;
        border-style: solid;
        border-width: 2px 2px 0px 2px;
        border-color:#BCBAB7; 
        z-index: 3;
    ");
            WriteLiteral(@"    background-color: #FFFFFF;
        position: fixed;
        top: 10px;
        right: 10px;
        box-shadow: 20px;"">
        <input type=""text"" id=""searchEntry"" style=""
                height:40px;
                width:225px;
                top:2px;
                left:5px;
                object-position:left;
                position:absolute;
                font-size:20px;
                box-shadow:none;
                border:none;
                "">
        <button style=""
                height: 45px;
                top:2px;
                right:2px;
                object-position:right;
                position: absolute;"" onclick=""myFunction()"">
            Search
        </button>
    </div>
    <div id=""Data"" class=""dropdown"" style=""
        height: 37px;
        width: 300px;
        top: 60px;
        right: 10px;
        z-index: 3;
        position: absolute;
        display:block;
        background-color: #FFFFFF;
        border-color: #BCBAB7;");
            WriteLiteral(@"
        border-style:solid;
        border-width: 1px 2px 2px 2px;
        border-radius:0px 0px 5px 5px;
        text-align:center;"">
        <label id=""totalcases"" style=""padding: inherit"">
                Total Cases
        </label>

    </div>
</div>
<script>
    var coordinates = [22.944877, 81.075196];
    var heatmaponoff = true;
    var zoom = 4;
    var myArr = [];
    var mymap = L.map('mapid').setView(coordinates, zoom);
     L.tileLayer('https://{s}.tiles.mapbox.com/v4/openstreetmap.1b68f018/{z}/{x}/{y}.png?access_token=pk.eyJ1Ijoib3NtLWluIiwiYSI6ImNqcnVxMTNrNTJwbHc0M250anUyOW81MjgifQ.cZnvZEyWT5AzNeO3ajg5tg', {
        attribution: '&copy; <a href=""https://www.openstreetmap.org/copyright"">OpenStreetMap</a> contributors'
     }).addTo(mymap);
    var heat = L.heatLayer(myArr, { radius: 25 }
    ).addTo(mymap);
    var xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            //console.lo");
            WriteLiteral(@"g(this.responseText);
            myArr = JSON.parse(this.responseText);
            heat = L.heatLayer(myArr, { radius: 25 }
            ).addTo(mymap);
        }
    };
    xhttp.open(""GET"", ""api/ncsdget"", true);
    xhttp.send();

    async function heatmaponoffchange() {
        if (heatmaponoff == false) {
            heatmaponoff = true;
            heat = L.heatLayer(myArr, { radius: 25 }
            ).addTo(mymap);
            document.getElementById(""heatmapButton"").src = ""https://1.bp.blogspot.com/-_t_IxPhAtQU/X154biSv8uI/AAAAAAAAHwo/cJ7DGF7wXOgv9axNkpSyP860-ScG6o3GACLcBGAsYHQ/s685/placewithoutheatmap.JPG""; 
        }
        else {
            heatmaponoff = false;
            mymap.removeLayer(heat);
            document.getElementById(""heatmapButton"").src = ""https://1.bp.blogspot.com/-OejNjOgW-sA/X154bvCk9-I/AAAAAAAAHwk/7QyX2yClkpA2hmNDi83R6P-j3TipmWgOACLcBGAsYHQ/s686-rw/placewithheatmap.JPG"";
        }
    }

    async function myFunction() {
        const response = awai");
            WriteLiteral("t fetch(\'");
#nullable restore
#line 123 "E:\WPF_projects\nCov1.0\Pages\Index.cshtml"
                                 Write(Model.url);

#line default
#line hidden
#nullable disable
            WriteLiteral("\' + document.getElementById(\"searchEntry\").value.split(\" \").join(\'+\') + \"+India\" + \'");
#nullable restore
#line 123 "E:\WPF_projects\nCov1.0\Pages\Index.cshtml"
                                                                                                                               Write(Model.key);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"');
        const data = await response.json();
        //console.log(data);
        coordinates = [data.features[0].center[1], data.features[0].center[0]];
        mymap.setView(coordinates, zoom);
        mymap.fitBounds([
            [data.features[0].bbox[1], data.features[0].bbox[0]],
            [data.features[0].bbox[3], data.features[0].bbox[2]]
        ]);

        //console.log(data.features[0].context);
        for (var i in data.features[0].context) {
            if (data.features[0].context[i].id.split(""."")[0] == ""district"") 
            {
                var district = data.features[0].context[i].text;
                var xhttp = new XMLHttpRequest();
                xhttp.onreadystatechange = function () {
                    if (this.readyState == 4 && this.status == 200) {
                        //console.log(this.responseText);
                        var myarr = JSON.parse(this.responseText);
                        for (var d in myarr) {
                            if");
            WriteLiteral(@" (myarr[d].dName == district) {
                                document.getElementById(""totalcases"").innerHTML = district + "" has total "" + myarr[d].totalCases + "" COVID cases."";
                                break;
                            }
                        }
                        document.getElementById(""totalcases"").value += ""100"";
                    }
                };
                xhttp.open(""GET"", ""api/ncovstatedatas"", true);
                xhttp.send();
                break;
            }
        }


    }
</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IndexModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<IndexModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<IndexModel>)PageContext?.ViewData;
        public IndexModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
