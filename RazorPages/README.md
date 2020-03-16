# Razor Pages 技術分享

- [Razor Pages 技術分享](#razor-pages-%e6%8a%80%e8%a1%93%e5%88%86%e4%ba%ab)
  - [環境](#%e7%92%b0%e5%a2%83)
  - [啟用 Razor Pages](#%e5%95%9f%e7%94%a8-razor-pages)
  - [Routing](#routing)
    - [預設](#%e9%a0%90%e8%a8%ad)
    - [自訂](#%e8%87%aa%e8%a8%82)
    - [參數化](#%e5%8f%83%e6%95%b8%e5%8c%96)
  - [Razor Page](#razor-page)
  - [\<PageName>Model](#pagenamemodel)
  - [View 與 PageModel 的溝通](#view-%e8%88%87-pagemodel-%e7%9a%84%e6%ba%9d%e9%80%9a)
    - [Get](#get)
    - [Post 至 PageModel](#post-%e8%87%b3-pagemodel)
    - [單一 Http Method 支援多個處理](#%e5%96%ae%e4%b8%80-http-method-%e6%94%af%e6%8f%b4%e5%a4%9a%e5%80%8b%e8%99%95%e7%90%86)
  - [參考資料](#%e5%8f%83%e8%80%83%e8%b3%87%e6%96%99)
  - [Ajax](#ajax)
  - [Partial Pages](#partial-pages)

---

## 環境

- Asp.Net Core 3.1

---

## 啟用 Razor Pages

- 新增 Service 至 Asp.NET Core Dependency Injection Service 中

  Startup.cs > ConfigureServices() 加上以下語法

  > services.AddRazorPages();

- 新增 Routing 至 Asp.Net Core 中

  Startup.cs > Configure() > app.UseEndpoints() 加上以下語法

  > endpoints.MapRazorPages();

---

## Routing

### 預設

| View 檔案                   | URL                    |
| --------------------------- | ---------------------- |
| /Pages/Index.cshtml         | / 或 /Index            |
| /Pages/Contact.cshtml       | /Contact               |
| /Pages/Store/Contact.cshtml | /Store/Contact         |
| /Pages/Store/Index.cshtml   | /Store 或 /Store/Index |

### 自訂

```csharp
@page "/Sample/Routing/Test/Custom"
```

### [參數化](https://www.learnrazorpages.com/razor-pages/routing)

- 給定參數化規則

  - 透過 @Page 給定

    - @page "{Id}"
    - @page "{Id:int}"
    - @page "/sample/routing/parameter/{id}"

  - 透過 AddRazorPagesOptions 給定

    ```csharp
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddRazorPages()
                .AddRazorPagesOptions(options =>
                                        {
                                            options.Conventions.AddPageRoute("/Order/Detail", "/Order/Detail/{Id}");
                                        });
    }
    ```

- 取出參數值

  - 以 BindProperty 來取值

    ```csharp
    public class Detail : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string Id { get; set; }
        public void OnGet()
        {
        }
    }
    ```

  - 以 RouteData.Values[""] 來取值

    ```csharp
    public class Detail : PageModel
    {
        public string Id { get; set; }

        public void OnGet()
        {
            Id = RouteData.Values["Id"]?.ToString();
        }
    }
    ```

---

## Razor Page

- 幾乎等於 MVC 的 View
- 支援 Html Helper (Asp.Net MVC 新增)
- 支援 Tag Helper (Asp.Net Core 新增) - 更貼近 Html 的語法
- 副檔名是 .cshtml
- @page

  - 必要 且 必定是 Razor Page 第一個 directive
  - request 不透過 controller 處理

- @model

  - 非必要
  - 指向 \<PageName>Model 的 directive

    當 Razor Page 宣告了 @model Index2Model
    那麼對應的 \<PageName>Model 就是 Index2Model，而且該 Class 繼承了 PageModel

---

## \<PageName>Model

- 非必要
- 與 View 結對的 .cshtml.cs 檔
- 類似 MVC 的 Controller
- 可用建構子 DI Instance
- [Model Binding](https://docs.microsoft.com/en-us/aspnet/core/mvc/models/model-binding)

  透過 BindProperty Attribute 給定

  - 用於 Client 端會變更的 Property
  - Binding Property Setter 存取權限要為 public

---

## View 與 PageModel 的溝通

### Get

- Http Get Request 會尋找下面的 Method

  - void OnGet()
  - async Task OnGetAsync()

    > 如果同時宣告二個對應至 Http Get 的 Method 時，於執行階段出現 `InvalidOperationException: Multiple handlers matched.`

  - BindProperty 強制用在 Http Get 的方式

    > \[BindProperty(SupportsGet = true)]

- 如果 PageModel 只有 Post 的處理邏輯，可以不宣告 OnGet()，就會以 PageModel 初始化的 Instance 去 Render Page
- 回傳

  回到當前頁面

  > return Page();

  其餘與 MVC 相同。

### Post 至 PageModel

- Http Post Request 會尋找下面的 Method

  - IActionResult OnPost()
  - async Task\<IActionResult> OnPostAsync()

### 單一 Http Method 支援多個處理

- [asp-page-handler](https://www.learnrazorpages.com/razor-pages/handler-methods)

---

## 參考資料

- [Learn Razor Pages](https://www.learnrazorpages.com/)

## Ajax

可搭配 [jquery-ajax-unobtrusive](https://www.jsdelivr.com/package/npm/jquery-ajax-unobtrusive) 及 asp-page-handler

## [Partial Pages](https://www.learnrazorpages.com/razor-pages/partial-pages)

- 回傳資料型態為 PartialViewResult

- PartialViewResult.ViewName 為 _HelloWorldPartial 時，就會尋找 _HelloWorldPartial.cshtml 來回傳內容

```csharp
public IActionResult OnGetPartial()
{
    return new PartialViewResult
    {
        ViewName = "_HelloWorldPartial",
        ViewData = this.ViewData
    };
}
```
