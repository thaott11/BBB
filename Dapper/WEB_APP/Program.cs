using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Syncfusion.Blazor;
using WEB_APP;
using WEB_APP.Service;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7274/") });
builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<IEmployessService, EmployessService>();
builder.Services.AddSyncfusionBlazor();
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NMaF5cXmBCf1FpR2pGfV5ycEVHYVZUTHxcQ00DNHVRdkdnWH1ccnZWQ2hfUEN0WUQ=");
await builder.Build().RunAsync();
