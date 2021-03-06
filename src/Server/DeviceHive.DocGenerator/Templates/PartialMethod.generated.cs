﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.269
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DeviceHive.DocGenerator.Templates
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    #line 2 "..\..\Templates\PartialMethod.cshtml"
    using DeviceHive.API.Models;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "1.4.1.0")]
    public partial class PartialMethod : RazorGenerator.Templating.RazorTemplateBase
    {
#line hidden

        #line 4 "..\..\Templates\PartialMethod.cshtml"

    public MetadataResource Resource { get; set; }
    public MetadataMethod Method { get; set; }

        #line default
        #line hidden

        public override void Execute()
        {


WriteLiteral("\r\n");


WriteLiteral("\r\n");


WriteLiteral("\r\n\r\n<h1>");


            
            #line 9 "..\..\Templates\PartialMethod.cshtml"
Write(Html.Encode(Resource.Name));

            
            #line default
            #line hidden
WriteLiteral(": ");


            
            #line 9 "..\..\Templates\PartialMethod.cshtml"
                            Write(Html.Encode(Method.Name));

            
            #line default
            #line hidden
WriteLiteral("</h1>\r\n\r\n<p>");


            
            #line 11 "..\..\Templates\PartialMethod.cshtml"
Write(Html.Documentation(Method.Documentation));

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n\r\n<h2>Request</h2>\r\n    \r\n<h3>HTTP Request</h3>\r\n<pre class=\"uri\">");


            
            #line 16 "..\..\Templates\PartialMethod.cshtml"
            Write(Html.Encode(Method.Verb));

            
            #line default
            #line hidden
WriteLiteral(" ");


            
            #line 16 "..\..\Templates\PartialMethod.cshtml"
                                      Write(Html.Encode(Method.Uri));

            
            #line default
            #line hidden
WriteLiteral("</pre>\r\n    \r\n");


            
            #line 18 "..\..\Templates\PartialMethod.cshtml"
 if (Method.UriParameters != null && Method.UriParameters.Any())
{

            
            #line default
            #line hidden
WriteLiteral("<h3>Parameters</h3>\r\n");



WriteLiteral("<table>\r\n    <tr>\r\n        <th style=\"width:200px\">Parameter Name</th>\r\n        <" +
"th style=\"width:80px\">Required</th>\r\n        <th style=\"width:80px\">Type</th>\r\n " +
"       <th style=\"width:400px\">Description</th>\r\n    </tr>\r\n");


            
            #line 28 "..\..\Templates\PartialMethod.cshtml"
     foreach (var parameter in Method.UriParameters)
    {

            
            #line default
            #line hidden
WriteLiteral("    <tr>\r\n        <td>");


            
            #line 31 "..\..\Templates\PartialMethod.cshtml"
       Write(Html.Encode(parameter.Name));

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n        <td>");


            
            #line 32 "..\..\Templates\PartialMethod.cshtml"
        Write(parameter.IsRequred ? "Yes" : "No");

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n        <td>");


            
            #line 33 "..\..\Templates\PartialMethod.cshtml"
       Write(Html.Encode(parameter.Type));

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n        <td>");


            
            #line 34 "..\..\Templates\PartialMethod.cshtml"
       Write(Html.Documentation(parameter.Documentation));

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n    </tr>\r\n");


            
            #line 36 "..\..\Templates\PartialMethod.cshtml"
    }

            
            #line default
            #line hidden
WriteLiteral("</table>\r\n");


            
            #line 38 "..\..\Templates\PartialMethod.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral("    \r\n<h3>Authorization</h3>\r\n<p>");


            
            #line 41 "..\..\Templates\PartialMethod.cshtml"
Write(Html.Encode(Method.Authorization));

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n\r\n");


            
            #line 43 "..\..\Templates\PartialMethod.cshtml"
 if (Method.RequestDocumentation != null)
{

            
            #line default
            #line hidden
WriteLiteral("<h3>Request Body</h3>\r\n");



WriteLiteral("<p>");


            
            #line 46 "..\..\Templates\PartialMethod.cshtml"
Write(Html.Documentation(Method.RequestDocumentation));

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n");


            
            #line 47 "..\..\Templates\PartialMethod.cshtml"

if (Method.RequestParameters != null && Method.RequestParameters.Any())
{

            
            #line default
            #line hidden
WriteLiteral("<table>\r\n    <tr>\r\n        <th style=\"width:200px\">Property Name</th>\r\n        <t" +
"h style=\"width:80px\">Required</th>\r\n        <th style=\"width:80px\">Type</th>\r\n  " +
"      <th style=\"width:400px\">Description</th>\r\n    </tr>\r\n");


            
            #line 57 "..\..\Templates\PartialMethod.cshtml"
     foreach (var parameter in Method.RequestParameters)
    {

            
            #line default
            #line hidden
WriteLiteral("    <tr>\r\n        <td>");


            
            #line 60 "..\..\Templates\PartialMethod.cshtml"
       Write(Html.Encode(parameter.Name));

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n        <td>");


            
            #line 61 "..\..\Templates\PartialMethod.cshtml"
        Write(parameter.IsRequred ? "Yes" : "No");

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n        <td>");


            
            #line 62 "..\..\Templates\PartialMethod.cshtml"
       Write(Html.Encode(parameter.Type));

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n        <td>");


            
            #line 63 "..\..\Templates\PartialMethod.cshtml"
       Write(Html.Documentation(parameter.Documentation));

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n    </tr>\r\n");


            
            #line 65 "..\..\Templates\PartialMethod.cshtml"
    }

            
            #line default
            #line hidden
WriteLiteral("</table>\r\n");


            
            #line 67 "..\..\Templates\PartialMethod.cshtml"
}
}

            
            #line default
            #line hidden
WriteLiteral("    \r\n");


            
            #line 70 "..\..\Templates\PartialMethod.cshtml"
 if (Method.ResponseDocumentation != null)
{

            
            #line default
            #line hidden
WriteLiteral("<h2>Response</h2>\r\n");



WriteLiteral("<p>");


            
            #line 73 "..\..\Templates\PartialMethod.cshtml"
Write(Html.Documentation(Method.ResponseDocumentation));

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n");


            
            #line 74 "..\..\Templates\PartialMethod.cshtml"
    
if (Method.ResponseParameters != null && Method.ResponseParameters.Any())
{

            
            #line default
            #line hidden
WriteLiteral("<table>\r\n    <tr>\r\n        <th style=\"width:200px\">Property Name</th>\r\n        <t" +
"h style=\"width:80px\">Type</th>\r\n        <th style=\"width:400px\">Description</th>" +
"\r\n    </tr>\r\n");


            
            #line 83 "..\..\Templates\PartialMethod.cshtml"
     foreach (var parameter in Method.ResponseParameters)
    {

            
            #line default
            #line hidden
WriteLiteral("    <tr>\r\n        <td>");


            
            #line 86 "..\..\Templates\PartialMethod.cshtml"
       Write(Html.Encode(parameter.Name));

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n        <td>");


            
            #line 87 "..\..\Templates\PartialMethod.cshtml"
       Write(Html.Encode(parameter.Type));

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n        <td>");


            
            #line 88 "..\..\Templates\PartialMethod.cshtml"
       Write(Html.Documentation(parameter.Documentation));

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n    </tr>\r\n");


            
            #line 90 "..\..\Templates\PartialMethod.cshtml"
    }

            
            #line default
            #line hidden
WriteLiteral("</table>\r\n");


            
            #line 92 "..\..\Templates\PartialMethod.cshtml"
}
}
            
            #line default
            #line hidden

        }
    }
}
#pragma warning restore 1591
