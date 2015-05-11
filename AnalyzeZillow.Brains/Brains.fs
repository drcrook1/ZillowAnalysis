namespace AnalyzeZillow.Brains

open FSharp.Data
open AnalyzeZillow.Core.SQL
open System.Xml.Linq

module Brains =
    [<Literal>]
    let zillowBasicSample = "http://www.zillow.com/webservice/GetUpdatedPropertyDetails.htm?zws-id={YOURKEY}&zpid=48749425"
    let zillowBasicUrl = "http://www.zillow.com/webservice/GetUpdatedPropertyDetails.htm?zws-id={YOURKEY}&zpid="
    [<Literal>]
    let zillowDeepSample = "http://www.zillow.com/webservice/GetDeepSearchResults.htm?zws-id={YOURKEY}&address=2114+Bigelow+Ave&citystatezip=Seattle%2C+WA"
    let zillowDeepsUrl = "http://www.zillow.com/webservice/GetDeepSearchResults.htm?zws-id={YOURKEY}"
    type ZillowBasic = XmlProvider<zillowBasicSample>
    type ZillowDeep = XmlProvider<zillowDeepSample>

    let GetHome (id:int, zillowApiKey:string) = 
        let idString = id.ToString()
        let zBasic = ZillowBasic.Load(zillowBasicUrl + idString)
        let address = zBasic.Response.Address.Street.Replace(" ", "+")
        let citystatezip = zBasic.Response.Address.City + @"%2C+" + zBasic.Response.Address.State
        let deepUrl = zillowDeepsUrl + "&address=" + address + "citystatezip=" + citystatezip
        let zFull = ZillowDeep.Load(zillowDeepsUrl + "&address=" + address + "&citystatezip=" + citystatezip)
        let home = new Home();
        home.City <- zFull.Response.Result.Address.City
        home.FIPSCounty <- zFull.Response.Result.FipScounty
        home.HomeSize <- zFull.Response.Result.FinishedSqFt
        home.HomeType <- zFull.Response.Result.UseCode
        home.Latitude <- zFull.Response.Result.Address.Latitude
        home.Longitude <- zFull.Response.Result.Address.Longitude
        home.NumBedrooms <- zFull.Response.Result.Bedrooms
        home.State <- zFull.Response.Result.Address.State
        home.Street <- zFull.Response.Result.Address.Street
        home.TaxAssesmentYear <- zFull.Response.Result.TaxAssessmentYear
        home.TaxAssessment <- zFull.Response.Result.TaxAssessment
        home.YearBuild <- zFull.Response.Result.YearBuilt
        home.zId <- id
        try
            home.NumBathrooms <- zFull.Response.Result.Bathrooms
        with 
            | :? System.Exception -> home.NumBathrooms <- 0.1m
        try
            home.LotSize <- zFull.Response.Result.LotSizeSqFt
        with 
            | :? System.Exception -> home.LotSize <- 0
        try
            home.ZillowEstimate <- float(zFull.Response.Result.Zestimate.Amount.Value)
            home.ZillowHighEstimate <- float(zFull.Response.Result.Zestimate.ValuationRange.High.Value)
            home.ZillowLowEstimate <- float(zFull.Response.Result.Zestimate.ValuationRange.Low.Value)
        with 
            | :? System.Exception -> 
                home.ZillowEstimate <- float(0)
                home.ZillowHighEstimate <- float(0)
                home.ZillowLowEstimate <- float(0)
        home


    let GetData (something:int) =
        let data = 1
        0
