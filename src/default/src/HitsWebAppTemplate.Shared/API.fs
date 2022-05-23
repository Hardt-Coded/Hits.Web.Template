module HitsWebAppTemplate.Shared.API

type Service = {
    GetMessage : bool -> Async<string>
}
with
    static member HomeRouteBuilder s m = sprintf "/api/home/%s/%s" s m
    static member Page1RouteBuilder s m = sprintf "/api/page1/%s/%s" s m
    static member Page2RouteBuilder s m = sprintf "/api/page2/%s/%s" s m