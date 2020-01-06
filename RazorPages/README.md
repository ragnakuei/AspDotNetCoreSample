# Razor Pages 技術分享

- [Razor Pages 技術分享](#razor-pages-%e6%8a%80%e8%a1%93%e5%88%86%e4%ba%ab)
  - [環境](#%e7%92%b0%e5%a2%83)
  - [啟用 Razor Pages](#%e5%95%9f%e7%94%a8-razor-pages)
  - [Routing](#routing)
  - [Razor Page](#razor-page)
  - [&lt;PageName&gt;Model](#ltpagenamegtmodel)
  - [View 傳遞資料至 PageModel](#view-%e5%82%b3%e9%81%9e%e8%b3%87%e6%96%99%e8%87%b3-pagemodel)
    - [Get](#get)
    - [非 Get](#%e9%9d%9e-get)
    - [單一 Http Method 支援多個處理](#%e5%96%ae%e4%b8%80-http-method-%e6%94%af%e6%8f%b4%e5%a4%9a%e5%80%8b%e8%99%95%e7%90%86)
  - [Razor Pages 與 MVC 的比較](#razor-pages-%e8%88%87-mvc-%e7%9a%84%e6%af%94%e8%bc%83)
  - [參考資料](#%e5%8f%83%e8%80%83%e8%b3%87%e6%96%99)

---

## 環境

- Asp.Net Core 3.1

---

## 啟用 Razor Pages

- 新增 Service 至 Asp.NET Core DependencyInjection Service 中

  Startup.cs > ConfigureServices() 加上以下語法

  > services.AddRazorPages();

- 新增 Routing 至 Asp.Net Core 中

  Startup.cs > Configure() > app.UseEndpoints() 加上以下語法

  > endpoints.MapRazorPages();

---

## Routing

範例

| View 檔案                   | Routing URL            |
| --------------------------- | ---------------------- |
| /Pages/Index.cshtml         | / 或 /Index            |
| /Pages/Contact.cshtml       | /Contact               |
| /Pages/Store/Contact.cshtml | /Store/Contact         |
| /Pages/Store/Index.cshtml   | /Store 或 /Store/Index |

---

## Razor Page

- 等於 MVC 的 View
- 支援 Html Helper (Asp.Net MVC 新增) - Razor 語法
- 支援 Tag Helper (Asp.Net Core 新增) - 更貼近 Html 的語法
- @page

  - 必要 且 必定是 Razor Page 第一個 directive
  - request 不透過 controller 處理
  - 副檔名是 .cshtml

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
- 建構子 DI Instance
- [Model Binding](https://docs.microsoft.com/en-us/aspnet/core/mvc/models/model-binding?view=aspnetcore-3.1)

  透過 BindProperty Attribute 給定

  - 主要用在非 Http Get

  - 用於 Client 端會變更的 Property

---

## View 傳遞資料至 PageModel

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

### 非 Get

- Http Post Request 會尋找下面的 Method

  - IActionResult OnPost()
  - async Task\<IActionResult> OnPostAsync()

### 單一 Http Method 支援多個處理

- [asp-page-handler](https://www.learnrazorpages.com/razor-pages/handler-methods)

---

## Razor Pages 與 MVC 的比較

| 項目                                         | Razor Pages                               | MVC                                 |
| -------------------------------------------- | ----------------------------------------- | ----------------------------------- |
| \<PageName>Model / Controller 與 View 的關係 | 一個 \<PageName>Model 只對應至一個 cshtml | 一個 Controller 可對應至多個 cshtml |
|                                              |                                           |                                     |
|                                              |                                           |                                     |
|                                              |                                           |                                     |
|                                              |                                           |                                     |

## 參考資料

- [Learn Razor Pages](https://www.learnrazorpages.com/)
