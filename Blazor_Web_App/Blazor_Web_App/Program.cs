using Blazor_Web_App;
using Blazor_Web_App.Service;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Syncfusion.Blazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7194/") });
builder.Services.AddScoped<IContactService , ContactService>();
builder.Services.AddScoped<INoteService, NoteService>();

builder.Services.AddSyncfusionBlazor();
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NMaF5cXmBCf1FpR2pGfV5ycEVHYVZUTHxcQ00DNHVRdkdnWH1ccnZWQ2hfUEN0WUQ=");
await builder.Build().RunAsync();
