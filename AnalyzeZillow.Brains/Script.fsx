// Learn more about F# at http://fsharp.net. See the 'F# Tutorial' project
// for more guidance on F# programming.
#r @"..\packages\FSharp.Data.2.2.1\lib\net40\FSharp.Data.dll"
#r @"C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.5\System.Xml.Linq.dll"

open System.Xml.Linq
open FSharp.Data

[<Literal>]
let zillowBasicSample = "http://www.zillow.com/webservice/GetUpdatedPropertyDetails.htm?zws-id={YOURKEY}&zpid=48749425"
let zillowBasicUrl = "http://www.zillow.com/webservice/GetUpdatedPropertyDetails.htm?zws-id={YOURKEY}&zpid="
[<Literal>]
let zillowDeepSample = "http://www.zillow.com/webservice/GetDeepSearchResults.htm?zws-id={YOURKEY}&address=2114+Bigelow+Ave&citystatezip=Seattle%2C+WA"
let zillowDeepsUrl = "http://www.zillow.com/webservice/GetDeepSearchResults.htm?zws-id={YOURKEY}"
type ZillowBasic = XmlProvider<zillowBasicSample>
type ZillowDeep = XmlProvider<zillowDeepSample>

let z1 = ZillowBasic.Load(zillowBasicUrl + "1")
let address = z1.Response.Address.Street.Replace(" ", "+")
let citystatezip = z1.Response.Address.City + @"%2C+" + z1.Response.Address.State
let deepUrl = zillowDeepsUrl + "&address=" + address + "citystatezip=" + citystatezip
let z3 = ZillowDeep.Load(zillowDeepsUrl + "&address=" + address + "&citystatezip=" + citystatezip)
//let z2 = ZillowComparisons.Load(zillowComparisonsUrl + "2345&count=5")
// Define your library scripting code here 

